# Debugging Log: Family Thumbnail Lazy Loading, Multi-Source Strategy & Caching

**Date:** 2026-08-04  
**Skill:** `revit-addin-gui-design`  
**Tags:** `WPF`, `Thumbnail`, `GetPreviewImage`, `ShellAPI`, `IShellItemImageFactory`, `LazyLoading`, `Cache`

---

## Overview
Efficient 3D preview thumbnail extraction across multiple Revit add-in sources: Active Open Models, Linked Models (`RevitLinkInstance`), Local `.rfa` Disk Directories, and Azure Cloud Storage.

---

## Strategy Matrix by Source

| Source Type | Primary Mechanism | Fallback Mechanism | Memory Overhead |
|---|---|---|---|
| **Active Open Model** | `elementType.GetPreviewImage(new Size(128, 128))` via `RevitTask` | Shell extraction on document `.rvt` path if null | Low (uses Revit's internal Properties Palette cache) |
| **Linked Model (`RevitLinkInstance`)** | `elementType.GetPreviewImage(new Size(128, 128))` on linked `Document` via `RevitTask` | Shell extraction on linked `.rvt` file path | Low |
| **Local Folder (`.rfa`)** | Windows Shell API (`IShellItemImageFactory`) directly on `.rfa` disk path | Default Category Placeholder Icon | 0 ms Revit API overhead |
| **Azure Cloud (`.rfa`)** | Windows Shell API on cached `%TEMP%\TransferPlus_Cache\*.rfa` file | Default Placeholder Icon | Instant after temp download |

---

## Key Best Practices

1. **Size Optimization:** Always request `new Size(128, 128)` from `ElementType.GetPreviewImage`. Revit's internal preview generator caches 128x128 bitmaps for the Properties Palette. Larger custom sizes (e.g. 256x256) force on-the-fly re-renders that can return null or cause delays.
2. **Cross-Thread Safety:** Always call `bmpSource.Freeze()` on generated `BitmapSource` objects before returning across threads to WPF ViewModels.
3. **GDI Handle Cleanup:** Always wrap `IntPtr hBitmap = bmp.GetHbitmap()` inside a `try/finally` block that calls `DeleteObject(hBitmap)` to prevent GDI resource leaks.
4. **Session-Wide Caching:** Store generated `BitmapSource` objects in a `ConcurrentDictionary<string, BitmapSource>` keyed by `"{SourceName}_{FamilyName}"` for instant 0 ms retrieval on repeat selections.
5. **ProgressBar Reset:** Ensure `family.IsLoadingThumbnail = false;` in ViewModel `finally` blocks executes unconditionally regardless of cancellation tokens.

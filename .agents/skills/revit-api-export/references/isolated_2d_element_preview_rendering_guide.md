# Technical Guide: Isolated 2D Element Preview Rendering via Scratch DraftingView & Rollback Transaction

## 1. Context & Architectural Challenge

In Revit Add-in UI development (such as TransferPlus or FilterPlus), showing high-fidelity thumbnail previews for 2D elements (Detail Components `OST_DetailComponents`, Detail Groups, and CAD instances) faces a core limitation in Revit API:
- `ElementType.GetPreviewImage(Size)` natively designed for 3D families frequently returns `null` or empty bitmaps for 2D annotation components and detail items.
- Rendering the entire host view via `doc.ExportImage(ImageExportOptions)` displays the full drawing context (surrounding walls, multiple details, annotations), failing to focus solely on the isolated selected item.

---

## 2. The Scratch DraftingView & Rollback Architecture

To render **strictly the isolated 2D element** in crisp vector resolution without leaving artifacts in the user's Revit model:

```
┌────────────────────────────────────────────────────────┐
│  1. Open Silent Transaction with WarningSwallower     │
│     tx.Start()                                         │
└───────────────────────────┬────────────────────────────┘
                            │
                            ▼
┌────────────────────────────────────────────────────────┐
│  2. Create Scratch DraftingView at 1:1 Scale           │
│     ViewDrafting tempView = ViewDrafting.Create(...)   │
└───────────────────────────┬────────────────────────────┘
                            │
                            ▼
┌────────────────────────────────────────────────────────┐
│  3. Instantiate / Copy Isolated Element at Origin      │
│     doc.Create.NewFamilyInstance(XYZ.Zero, symbol, tv) │
│     doc.Regenerate()                                   │
└───────────────────────────┬────────────────────────────┘
                            │
                            ▼
┌────────────────────────────────────────────────────────┐
│  4. Export PNG via ImageExportOptions                  │
│     ZoomType = ZoomFitType.FitToPage (Tight framing!)  │
│     doc.ExportImage(options)                           │
└───────────────────────────┬────────────────────────────┘
                            │
                            ▼
┌────────────────────────────────────────────────────────┐
│  5. Immediate Rollback of Transaction                  │
│     tx.RollBack() -> Model 100% untouched!             │
└───────────────────────────┬────────────────────────────┘
                            │
                            ▼
┌────────────────────────────────────────────────────────┐
│  6. Load PNG -> BitmapImage.Freeze() for WPF UI Binding│
└────────────────────────────────────────────────────────┘
```

---

## 3. Key Rules & Best Practices

1. **Transaction Safety**: Always wrap the scratch creation in a `using (var tx = new Transaction(doc, "..."))` block and ensure `tx.RollBack()` is called in the `finally` block if the transaction has started and not ended.
2. **Warning Suppression**: Attach `WarningSwallower` to the transaction to eliminate non-fatal Revit warning popups.
3. **Symbol Activation**: For `FamilySymbol`, ensure `if (!symbol.IsActive) symbol.Activate();` is called before instantiation.
4. **Tight Fit Framing**: Configure `ZoomType = ZoomFitType.FitToPage` with `PixelSize = 512` so the camera strictly frames the element boundaries.
5. **WPF UI Thread Isolation**: Always call `bitmapImage.Freeze()` after loading the PNG to allow safe binding across background and UI dispatcher threads.

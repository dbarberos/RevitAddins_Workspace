# WPF & Revit Add-in UI: BitmapImage Freezing & Thumbnail Caching Guide

## 1. Multi-Threading & Freezing Rule
When asynchronous tasks or background services fetch or generate images (`BitmapSource` or `BitmapImage`) for WPF controls:
1. `BitmapImage` must have `CacheOption = BitmapCacheOption.OnLoad` and `CreateOptions = BitmapCreateOptions.IgnoreImageCache`.
2. **`Freeze()` is Mandatory**: Calling `.Freeze()` transitions the `Freezable` image into an unmodifiable, thread-safe state, allowing it to be bound to WPF Image controls across any UI or background thread without `InvalidOperationException` (cross-thread access).

```csharp
var bitmap = new BitmapImage();
bitmap.BeginInit();
bitmap.CacheOption = BitmapCacheOption.OnLoad;
bitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
bitmap.UriSource = new Uri(filePath, UriKind.Absolute);
bitmap.EndInit();
bitmap.Freeze(); // Crucial for cross-thread binding
```

## 2. In-Memory Cache
Use a thread-safe `ConcurrentDictionary<string, BitmapSource>` keyed by unique entity identifiers (e.g. document name + element id) to eliminate redundant disk writes and Revit API render passes.

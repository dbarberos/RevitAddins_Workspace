# Debugging Log: Microscopic / Tiny Ribbon and Window Icons Due to Embedded High DPI Metadata

* **Date:** 2026-09-24
* **Context:** Autodesk Revit Ribbon (`PushButton.SetLargeImage` / `PushButton.SetImage`) & WPF Window Title Icon (`Window.Icon`).
* **Symptoms:** The Ribbon button icon renders as a tiny 3-pixel dot instead of a 32x32 px image, and the window icon in the title bar is practically invisible (1-pixel speck), even though the PNG files have dimensions of 32x32 and 16x16 px.

---

## 1. Root Cause

Autodesk Revit uses WPF internally to render its Ribbon panels and host add-in controls. WPF measures layout elements in **Device-Independent Pixels (DIP)** where $1\text{ DIP} = 1/96\text{ inch}$.

When WPF's `BitmapDecoder` loads a PNG bitmap from a pack URI or file stream, it reads the image's embedded horizontal (`DpiX`) and vertical (`DpiY`) resolution metadata:

$$\text{Rendered Size (DIP)} = \text{Pixel Dimensions} \times \left(\frac{96}{\text{Embedded DPI}}\right)$$

If an icon is exported from design tools (Photoshop, Illustrator, online converters) with print or arbitrary resolution metadata (e.g. **900 DPI** or **1500 DPI**):
* **32x32 px at 900 DPI:** $32 \times (96 / 900) \approx \mathbf{3.41\text{ DIP}}$ (rendered as a 3-pixel speck).
* **16x16 px at 1500 DPI:** $16 \times (96 / 1500) \approx \mathbf{1.02\text{ DIP}}$ (rendered as a 1-pixel speck).
* **120x120 px at 300 DPI:** $120 \times (96 / 300) = \mathbf{38.4\text{ DIP}}$ (shrunk to a fraction of its intended size).

---

## 2. Diagnosis Method

In PowerShell, inspect the image dimensions, DPI, and calculated WPF DIP:

```powershell
Add-Type -AssemblyName System.Drawing
$img = [System.Drawing.Image]::FromFile("path\to\icon.png")
$dipW = [math]::Round($img.Width * 96.0 / $img.HorizontalResolution, 2)
$dipH = [math]::Round($img.Height * 96.0 / $img.VerticalResolution, 2)
Write-Output "$($img.Width)x$($img.Height) px @ $($img.HorizontalResolution) DPI -> WPF DIP: ${dipW}x${dipH}"
$img.Dispose()
```

---

## 3. Solution

Re-encode the PNG file setting the DPI explicitly to standard **96.0 DPI** while preserving 32-bit ARGB pixel data and alpha transparency:

```powershell
Add-Type -AssemblyName System.Drawing

function Normalize-PngTo96Dpi {
    param ([string]$Path)
    
    $src = [System.Drawing.Bitmap]::FromFile($Path)
    $dest = New-Object System.Drawing.Bitmap($src.Width, $src.Height, [System.Drawing.Imaging.PixelFormat]::Format32bppArgb)
    $dest.SetResolution(96.0, 96.0)

    $g = [System.Drawing.Graphics]::FromImage($dest)
    $g.Clear([System.Drawing.Color]::Transparent)
    $g.CompositingQuality = [System.Drawing.Drawing2D.CompositingQuality]::HighQuality
    $g.InterpolationMode = [System.Drawing.Drawing2D.InterpolationMode]::NearestNeighbor
    $g.PixelOffsetMode = [System.Drawing.Drawing2D.PixelOffsetMode]::Half
    $g.DrawImage($src, 0, 0, $src.Width, $src.Height)
    $g.Dispose()
    $src.Dispose()

    $temp = [System.IO.Path]::GetTempFileName()
    $dest.Save($temp, [System.Drawing.Imaging.ImageFormat]::Png)
    $dest.Dispose()

    Move-Item -Path $temp -Destination $Path -Force
}
```

After normalizing, WPF calculates:
$$32 \times \frac{96}{96} = \mathbf{32.0\text{ DIP}}$$
$$16 \times \frac{96}{96} = \mathbf{16.0\text{ DIP}}$$

and the ribbon push buttons and window title icons render crisp and at full expected dimensions.

# Debugging & Pattern: WPF DataGrid Drag & Drop Viewport HUD Overlay & Multi-Version Deployment Gotchas

**Date**: 2026-09-30  
**Context**: Autodesk Revit WPF Add-in GUI Design (`revit-addin-gui-design`)  
**Components**: `MainWindowView.xaml`, `MainWindowView.xaml.cs`, Nice3point Revit SDK, `TablePlus.addin`  

---

## 1. Problem Description (Symptoms)

1. **Occlusion of Crucial DataGrid Anatomy**:
   When implementing a drag-and-drop feedback overlay over a table (`DataGrid`), rendering a generic full-area overlay across the parent container inadvertently covered:
   - The **column header row** (`DataGridColumnHeadersPresenter`), concealing column titles and sort glyphs.
   - The **vertical and horizontal scrollbars** (`ScrollBar`), blocking scroll feedback and visually clamping the grid edges.
2. **Aggressive Color & Disruptive Borders**:
   Placing high-contrast blue borders (`#007ACC`, 2px) around the container perimeter disrupted the add-in's card aesthetic. A solid or overly dark translucent overlay (`#8C...`) darkened rows excessively.
3. **Stale Addin Binary Deployment Gotcha**:
   Compiling with `/p:DeployAddin=false` and manually copying `TablePlus.dll` to the root addin directory (`%AppData%\Autodesk\Revit\Addins\202X\`) failed to update the active addin in Revit. Revit continued loading the older DLL from the `TablePlus\` subfolder specified in `TablePlus.addin` (`<Assembly>TablePlus\TablePlus.dll</Assembly>`).

---

## 2. Root Cause Analysis

### Visual & Layout Tree Structure
WPF's `DataGrid` template houses an internal `ScrollViewer` named `DG_ScrollViewer`. Its internal layout grid separates distinct components into separate rows and columns:
- **Row 0, Col 0**: `SelectAllButton` + `DataGridColumnHeadersPresenter` (Column Headers).
- **Row 1, Col 0**: `ScrollContentPresenter` (Viewport holding rows and virtualized cells).
- **Row 1, Col 1**: `ScrollBar` (Vertical).
- **Row 2, Col 0**: `ScrollBar` (Horizontal).

When an overlay (`Border`) is declared as a sibling to `DataGrid` inside a parent container `Grid`, it defaults to `Margin="0"` and stretches across all rows and columns. Consequently, it covers the column headers and both scrollbars unless dynamically bounded.

### Revit Addin Manifest Resolution
In Revit add-in manifests (`.addin`), standard practice places the binary within a dedicated product subfolder:
```xml
<Assembly>TablePlus\TablePlus.dll</Assembly>
```
If build commands suppress deployment (`/p:DeployAddin=false`) and developers copy output DLLs directly to `%AppData%\...\Addins\202X\`, Revit's Autoloader still loads `%AppData%\...\Addins\202X\TablePlus\TablePlus.dll`. The developer runs tests against a stale binary while believing the compilation updated it.

---

## 3. Solution & Architecture

### A. Dynamic Viewport Margin Calculation
Rather than hardcoding margins or breaking the DataGrid template, find the internal `ScrollContentPresenter` via `FindVisualChild<ScrollContentPresenter>` and transform its viewport bounds relative to the parent `DataGridContainer`:

```csharp
var transform = presenter.TransformToAncestor(DataGridContainer);
var topLeft = transform.Transform(new System.Windows.Point(0, 0));

double topMargin = Math.Max(0, topLeft.Y);
double leftMargin = Math.Max(0, topLeft.X);
double rightMargin = Math.Max(0, DataGridContainer.ActualWidth - (topLeft.X + presenter.ActualWidth));
double bottomMargin = Math.Max(0, DataGridContainer.ActualHeight - (topLeft.Y + presenter.ActualHeight));

DropOverlay.Margin = new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);
```

- **Top Margin**: Exactly equals the column header height (`topLeft.Y`), keeping headers 100% uncovered.
- **Right Margin**: Exactly equals the vertical scrollbar width (`container.Width - (left + width)`).
- **Bottom Margin**: Exactly equals the horizontal scrollbar height (`container.Height - (top + height)`).
- **Fallback**: If measured before layout completes, fallback safely to `Thickness(0, 29, 10, 10)`.

### B. Minimalist Overlay Aesthetics
To adhere to the add-in's card-based design system:
1. **Outer Overlay**:
   - `BorderThickness="0"`, `Background="#60E0E0E0"` (luminous translucent gray, blending over rows to ~`#F3F3F3`, identical to a clean disabled button surface).
2. **Inner Card**:
   - `Background="#FFFFFF"`, `CornerRadius="8"`, `Padding="15"`, subtle drop shadow (`Opacity="0.08"`).
   - Centered strictly with `HorizontalAlignment="Center"` and `VerticalAlignment="Center"`.
3. **Typography**:
   - Matches header cards ("Filter:" and "Organize:"): `FontWeight="Bold"`, `FontSize="12"`, `Foreground="#999"`.
   - Free of icons, emojis, or secondary subtitles.

### C. Multi-Version Automated Build & Deploy
Always leverage Nice3point SDK's native deployment targets during compilation:
```bash
dotnet build TablePlus\TablePlus.csproj -c "Debug R25"
dotnet build TablePlus\TablePlus.csproj -c "Release R24"
```
Ensure `<DeployAddin>true</DeployAddin>` in `.csproj` so MSBuild automatically populates `%AppData%\Autodesk\Revit\Addins\202X\TablePlus\` and synchronizes `.addin` manifests.

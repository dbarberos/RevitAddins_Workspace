# Walkthrough: Drag & Drop Table Import & Multi-Format Authorization (Excel, Word, Text, PDF & Markdown)

## Overview
Implemented drag-and-drop support on the primary dashboard data zone (`TablesDataGrid`) in [MainWindowView.xaml](file:///b:/REVIT/C%23/RevitAddins_Workspace/TablePlus/Views/MainWindowView.xaml) and authorized:
1. **Excel Workbooks**: `.xlsx`, `.xls`, `.xlsm`, `.xltx`, `.xltm`
2. **Word & RTF Documents**: `.docx`, `.doc`, `.rtf`
3. **Markdown Documents**: `.md`, `.markdown`
4. **Text Files in all modalities**: `.txt`, `.csv`, `.tsv`, `.tab`, `.prn`, `.dat`, `.log`, `.asc`
5. **Adobe PDF Documents**: `.pdf`

Users can drag any authorized file from Windows Explorer or other applications directly onto the table area. Dropping opens the **Table Import View** modal with the source file pre-inspected, structure mapped, and configuration fields filled.

---

## Changes Implemented

### 1. Multi-Format Authorization (Excel, Word, Markdown, Text, PDF)
- **Supported Formats**:
  - **Excel**: `.xlsx`, `.xls`, `.xlsm`, `.xltx`, `.xltm`
  - **Word & RTF**: `.docx`, `.doc`, `.rtf`
  - **Markdown**: `.md`, `.markdown`
  - **Text & Delimited**: `.txt`, `.csv`, `.tsv`, `.tab`, `.prn`, `.dat`, `.log`, `.asc`
  - **PDF Documents**: `.pdf`
- **Models & Enums**:
  - Added `TableSourceType.MarkdownDocument` and mapped badge `"MD"`.
  - Mapped `TableSourceType.WordDocument` to badge `"DOC"`.
  - Mapped `TableSourceType.TextFile` to badge `"TXT"`.
  - Mapped `TableSourceType.PdfDocument` to badge `"PDF"`.
  - Configured `TableRegistryService` to infer `MarkdownDocument` (`.md`, `.markdown`), `WordDocument`, `TextFile`, and `PdfDocument` from file extensions.

### 2. High-Performance Multi-Format Document Engine (`ExcelReaderService.cs`)
- **Markdown Document Engine**:
  - **GFM Pipe Table Parser**: Automatically detects and parses GitHub-Flavored Markdown tables (`| Col 1 | Col 2 |`), discarding divider lines (`|---|---|`), creating bold header cells and clean tabular rows.
  - **Structured Document Parser**: When no pipe table is present, parses headings (`#`, `##`, `###`), list items (`-`, `*`, `1.`), quotes (`>`), and text blocks into a structured table view with metadata (file name, format, size, last modified timestamp).
  - Employs a fresh emerald header accent (`#166534` / `#F0FDF4`) with clean borders.
- **Word & RTF Document Engine**:
  - `.docx` (OpenXML): Uses `System.IO.Compression.ZipArchive` to read `word/document.xml`. If the document contains tables (`<w:tbl>`), extracts true tabular cells (`<w:tc>`) with dynamic column widths; if no table is present, parses paragraphs (`<w:p>`) as indexed items alongside document metadata.
  - `.rtf`: Cleans RTF control words and formats clean text sections.
  - `.doc`: Legacy binary inspection extracting file properties and clean ASCII/Unicode text blocks.
  - Generates vector tables with subtle violet header accent (`#5B21B6` / `#EDE9FE`) and thin borders.
- **Delimited Text Engine**:
  - `InspectTextFile`: Automatically inspects file content and dynamically detects delimiters (tab `\t`, semicolon `;`, comma `,`, pipe `|`) based on occurrence frequency.
  - `ExtractTextCells`: Converts text lines into structured `ExcelCellModel` instances with dynamic column widths (clamped between 18mm and 180mm), bold header row, background tint (`#F2F4F7`), and borders.
- **PDF Document Engine**:
  - `InspectPdfFile` & `ExtractPdfCells`: Extracts page count, file size, and timestamps from PDF streams, parses visible text operators (`Tj`), and packages them into a structured Revit vector table with blue-tinted header styling (`#0369A1` / `#E0F2FE`).
- **ClosedXML Isolation**:
  - `ExtractMergedCells` and `ExtractCells` bypass `XLWorkbook` when reading Markdown, Word, RTF, Text, or PDF files, avoiding corrupt stream exceptions.

### 3. Drag & Drop Surface and Visual Feedback (`MainWindowView.xaml` & `MainWindowView.xaml.cs`)
- Enclosed `TablesDataGrid` inside a parent `Grid` within `DataGridContainer` (`Border Grid.Row="1"`).
- Configured `AllowDrop="True"` on container border and `DataGrid`.
- Expanded `SupportedTableExtensions` hash set to include `.md` and `.markdown`.
- **Minimalist Aesthetic Overlay (`DropOverlay`)**:
  - **No Blue Border**: Eliminated perimeter border changes on `DataGridContainer` during drag-over; container retains its natural clean border.
  - **Lighter Translucent Gray (`Background="#60E0E0E0"` / `BorderThickness="0"`)**: Soft, luminous translucent gray tone matching subtle disabled/neutral surfaces, keeping underlying table rows easily readable.
  - **Exclusion of Column Headers & Scrollbars (`UpdateDropOverlayBounds`)**: The overlay dynamically synchronizes with the `ScrollContentPresenter` bounds inside `DG_ScrollViewer`. It exclusively covers the data rows viewport, leaving the column headers row at the top, the vertical scrollbar on the right, and the horizontal scrollbar at the bottom completely visible, uncovered, and interactive.
  - **Centered White Inner Card**: Solid white card (`Background="#FFFFFF"`, `CornerRadius="8"`, `Padding="15"`, subtle drop shadow) sized strictly to the title text plus 15px perimeter gap.
  - **Card Title Typography**: Strictly text `"Drop your file here to create or link a table"` using `FontWeight="Bold"`, `FontSize="12"`, `Foreground="#999"`, completely free of icons, emojis, or secondary subtitles, matching the exact styling of the "Filter" and "Organize" card headers.
- In `DragEnter` and `DragOver`:
  - Activates `DragDropEffects.Copy`, recalculates viewport bounds (`UpdateDropOverlayBounds()`), and reveals `DropOverlay` when dragging authorized files.
- In `DragLeave` and `Drop`:
  - Collapses `DropOverlay` and restores normal view state.

### 4. File Picker & Wizard Integration (`TableImportViewModel.cs` & `TableImportView.xaml`)
- Updated `OpenFileDialog` filter to categorize:
  - *All Supported Tables (*.xlsx;*.xls;*.csv;*.xlsm;*.txt;*.tsv;*.tab;*.prn;*.pdf;*.docx;*.doc;*.rtf;*.md;*.markdown)*
  - *Excel Workbooks (*.xlsx;*.xls;*.xlsm;*.xltx;*.xltm)*
  - *Markdown Files (*.md;*.markdown)*
  - *Word & RTF Documents (*.docx;*.doc;*.rtf)*
  - *PDF Documents (*.pdf)*
  - *Text & Delimited Files (*.txt;*.csv;*.tsv;*.tab;*.prn;*.dat;*.log;*.asc)*
- In `ImportTableAsync`: Infers and assigns `config.SourceType` (`MarkdownDocument`, `WordDocument`, `TextFile`, `PdfDocument`, `Csv`, `ExcelXlsx`, `ExcelXlsm`) upon import.
- Updated drop hint text in `TableImportView.xaml`:
  - *"💡 Drag & drop an Excel, Word, Markdown (.md), Text or PDF file directly into this window"*.
- Updated external source providers (`Directory`, `Azure Storage`, `AWS S3`, `Autodesk Docs / ACC`) to list Markdown files.

---

## Verification & Deployment
- **Compilations Succeeded**:
  - `Debug R25` (.NET 8): `0 Warning(s), 0 Error(s)`
  - `Release R24` (.NET Framework 4.8): `0 Warning(s), 0 Error(s)`
- **Binaries Deployed**:
  - `C:\Users\dbarb\AppData\Roaming\Autodesk\Revit\Addins\2025\TablePlus\`
  - `C:\Users\dbarb\AppData\Roaming\Autodesk\Revit\Addins\2024\TablePlus\`

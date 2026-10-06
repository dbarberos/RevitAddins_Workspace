namespace TablePlus.Models;

/// <summary>
/// Synchronization status of a table relative to its external source document.
/// </summary>
public enum TableSyncStatus
{
    /// <summary>
    /// File timestamp on disk is less than or equal to the last recorded synchronization timestamp.
    /// </summary>
    UpToDate,

    /// <summary>
    /// File timestamp on disk is newer than the recorded synchronization timestamp.
    /// </summary>
    Modified,

    /// <summary>
    /// Source file path does not exist on disk or is inaccessible.
    /// </summary>
    FileNotFound,

    /// <summary>
    /// Table exists as Revit view but metadata link has been detached or cleared.
    /// </summary>
    Unlinked
}

/// <summary>
/// Source document format/origin for a TablePlus table view.
/// </summary>
public enum TableSourceType
{
    /// <summary>
    /// Standard OpenXML Excel workbook (.xlsx).
    /// </summary>
    ExcelXlsx,

    /// <summary>
    /// Macro-enabled OpenXML Excel workbook (.xlsm).
    /// </summary>
    ExcelXlsm,

    /// <summary>
    /// Comma-separated or delimited text table (.csv).
    /// </summary>
    Csv,

    /// <summary>
    /// Plain or delimited text file (.txt, .tsv, .tab, .prn).
    /// </summary>
    TextFile,

    /// <summary>
    /// Adobe PDF document (.pdf).
    /// </summary>
    PdfDocument,

    /// <summary>
    /// Microsoft Word or rich text document (.docx, .doc, .rtf).
    /// </summary>
    WordDocument,

    /// <summary>
    /// Markdown document with tables or rich text notes (.md, .markdown).
    /// </summary>
    MarkdownDocument,

    /// <summary>
    /// Reserved for future spec: Native Revit Schedule View (.rvt).
    /// </summary>
    ScheduleView
}

/// <summary>
/// Import format type (matches DiRoots TableGen ImportTypes and native schedules).
/// </summary>
public enum TableImportType
{
    /// <summary>
    /// Editable 2D vector table elements in Revit view (Drafting or Legend view).
    /// </summary>
    Table,

    /// <summary>
    /// Native Revit Key Schedule view with database rows and reusable parameter pool.
    /// </summary>
    KeySchedule,

    /// <summary>
    /// Native Revit Schedule view using freeform Header grid with zero project parameters.
    /// </summary>
    HeaderSchedule,

    /// <summary>
    /// High-resolution raster rendering image inserted into Revit view.
    /// </summary>
    Image
}

/// <summary>
/// Page selection option for multi-page documents (Word, PDF, Markdown).
/// </summary>
public enum TablePageOption
{
    AllPages,
    SelectPages
}

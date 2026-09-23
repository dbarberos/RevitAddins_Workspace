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
    /// Reserved for future spec: Adobe PDF document (.pdf).
    /// </summary>
    PdfDocument,

    /// <summary>
    /// Reserved for future spec: Microsoft Word document (.docx).
    /// </summary>
    WordDocument,

    /// <summary>
    /// Reserved for future spec: Native Revit Schedule View (.rvt).
    /// </summary>
    ScheduleView
}

namespace TablePlus.Models;

/// <summary>
/// Defines a contiguous rectangular range of merged Excel cells.
/// </summary>
public class MergedCellRange
{
    public int StartRow { get; set; }
    public int EndRow { get; set; }
    public int StartColumn { get; set; }
    public int EndColumn { get; set; }

    public double TotalWidthMillimeters { get; set; }
    public double TotalHeightMillimeters { get; set; }

    public bool Contains(int row, int col)
    {
        return row >= StartRow && row <= EndRow && col >= StartColumn && col <= EndColumn;
    }

    public bool IsMaster(int row, int col)
    {
        return row == StartRow && col == StartColumn;
    }
}

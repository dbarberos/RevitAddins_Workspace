using Autodesk.Revit.DB;

namespace TransferPlus;

/// <summary>
/// Provides cross-version compatibility helper extensions for Autodesk Revit ElementId.
/// In Revit 2024+, ElementId.Value is a 64-bit integer (long).
/// In Revit 2023 and earlier, ElementId.IntegerValue is a 32-bit integer (int).
/// </summary>
public static class ElementIdExtensions
{
    /// <summary>
    /// Gets the unique numeric identifier value of the element across all Revit API versions.
    /// </summary>
    /// <param name="id">The Revit ElementId instance.</param>
    /// <returns>The numeric ID as a 64-bit integer (long).</returns>
    public static long GetIdValue(this ElementId? id)
    {
        if (id == null) return -1;
#if REVIT2024_OR_GREATER
        return id.Value;
#else
        return id.IntegerValue;
#endif
    }

    /// <summary>
    /// Creates an ElementId from a long value with cross-version compatibility.
    /// </summary>
    public static ElementId FromLong(long value)
    {
#if REVIT2024_OR_GREATER
        return new ElementId(value);
#else
        return new ElementId((int)value);
#endif
    }
}

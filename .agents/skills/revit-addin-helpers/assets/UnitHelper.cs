namespace {{Namespace}}.Helpers;

/// <summary>
/// Utilidades de conversiÃ³n de unidades usando ForgeTypeId.
/// </summary>
public static class UnitHelper
{
    public static double FeetToMeters(double feetValue)
        => UnitUtils.ConvertFromInternalUnits(feetValue, UnitTypeId.Meters);

    public static double MetersToFeet(double metersValue)
        => UnitUtils.ConvertToInternalUnits(metersValue, UnitTypeId.Meters);

    public static double FeetToMillimeters(double feetValue)
        => UnitUtils.ConvertFromInternalUnits(feetValue, UnitTypeId.Millimeters);

    public static double MillimetersToFeet(double mmValue)
        => UnitUtils.ConvertToInternalUnits(mmValue, UnitTypeId.Millimeters);

    public static double SqFeetToSqMeters(double sqFeetValue)
        => UnitUtils.ConvertFromInternalUnits(sqFeetValue, UnitTypeId.SquareMeters);

    public static double CuFeetToCuMeters(double cuFeetValue)
        => UnitUtils.ConvertFromInternalUnits(cuFeetValue, UnitTypeId.CubicMeters);

    public static string FormatWithDocUnits(Document doc, ForgeTypeId specTypeId, double internalValue)
    {
        var formatOptions = doc.GetUnits().GetFormatOptions(specTypeId);
        return UnitFormatUtils.Format(doc.GetUnits(), specTypeId, internalValue, false);
    }
}

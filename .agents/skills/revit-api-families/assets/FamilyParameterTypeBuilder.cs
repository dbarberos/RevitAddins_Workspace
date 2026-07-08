// ==============================================================================
// SKILL: revit-api-families (Family API & Document Creation)
// PATTERN: Family Parameter and Types Generator
// PURPOSE: Programmatically registers parameters and sets values across FamilyTypes.
// ==============================================================================

using Autodesk.Revit.DB;

namespace RevitAddinBase.Families
{
    public class FamilyParameterTypeBuilder
    {
        public void InjectParametersAndTypes(Document doc)
        {
            FamilyManager fm = doc.FamilyManager;

            using (Transaction t = new Transaction(doc, "Configure Parameters"))
            {
                t.Start();

                // 1. Add Parametric Dimension Parameter
                FamilyParameter widthParam = fm.AddParameter(
                    "Clear Width", 
                    GroupTypeId.Geometry, 
                    SpecTypeId.Length, 
                    false // false = Type Parameter, true = Instance Parameter
                );

                // 2. Create a new Type definition
                FamilyType standardType = fm.NewType("Standard Model 1000mm");

                // 3. Assign internal value (Revit stores length internally in Feet; conversion required)
                fm.Set(widthParam, UnitUtils.ConvertToInternalUnits(1000.0, UnitTypeId.Millimeters));
                
                t.Commit();
            }
        }
    }
}

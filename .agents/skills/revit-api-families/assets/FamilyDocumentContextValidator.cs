// ==============================================================================
// SKILL: revit-api-families (Family API & Document Creation)
// PATTERN: Document Context Validation Guard
// PURPOSE: Ensures Family Editor APIs are not invoked in project (.rvt) scopes.
// ==============================================================================

using Autodesk.Revit.DB;
using System;

namespace RevitAddinBase.Families
{
    public class FamilyDocumentContextValidator
    {
        public void VerifyEnvironment(Document doc)
        {
            if (!doc.IsFamilyDocument)
            {
                throw new InvalidOperationException("This command can only be executed in the Family Editor context.");
            }
        }
    }
}

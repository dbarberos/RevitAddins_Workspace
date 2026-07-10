using System;
using Autodesk.Revit.DB;

namespace TransferSingleApp
{
	// Token: 0x0200000F RID: 15
	internal class FamilyOption : IFamilyLoadOptions
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00006DD5 File Offset: 0x00004FD5
		public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
		{
			overwriteParameterValues = true;
			return true;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00006DDB File Offset: 0x00004FDB
		public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
		{
			source = 1;
			overwriteParameterValues = true;
			return true;
		}
	}
}

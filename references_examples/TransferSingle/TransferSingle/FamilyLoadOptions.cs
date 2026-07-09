using System;
using Autodesk.Revit.DB;

namespace TransferSingleApp
{
	// Token: 0x02000025 RID: 37
	internal class FamilyLoadOptions : IFamilyLoadOptions
	{
		// Token: 0x06000187 RID: 391 RVA: 0x00006DD5 File Offset: 0x00004FD5
		public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
		{
			overwriteParameterValues = true;
			return true;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00006DDB File Offset: 0x00004FDB
		bool IFamilyLoadOptions.OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
		{
			source = 1;
			overwriteParameterValues = true;
			return true;
		}
	}
}

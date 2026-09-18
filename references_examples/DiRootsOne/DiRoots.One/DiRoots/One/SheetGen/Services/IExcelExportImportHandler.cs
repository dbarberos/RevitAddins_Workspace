using System;
using System.Collections.Generic;

namespace DiRoots.One.SheetGen.Services
{
	// Token: 0x02000315 RID: 789
	public interface IExcelExportImportHandler
	{
		// Token: 0x0600222F RID: 8751
		void ExportToExcel<TSheet>(IList<TSheet> sheets, string fileName) where TSheet : ISheetModel;

		// Token: 0x06002230 RID: 8752
		bool ImportSheetsFromExcel(string filePath, Action populateParams);

		// Token: 0x06002231 RID: 8753
		bool ImportSheetsFromExcel(Action populateParams);

		// Token: 0x06002232 RID: 8754
		bool ImportPlaceholdersFromExcel(Action populateParams);
	}
}

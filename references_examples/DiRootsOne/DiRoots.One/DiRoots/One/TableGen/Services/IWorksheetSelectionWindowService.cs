using System;
using System.Collections.Generic;
using DiRoots.One.TGDatabaseLayer;

namespace DiRoots.One.TableGen.Services
{
	// Token: 0x0200016D RID: 365
	public interface IWorksheetSelectionWindowService
	{
		// Token: 0x06000D7D RID: 3453
		bool? ShowSelectionWindow(List<string> filePaths);

		// Token: 0x06000D7E RID: 3454
		bool? ShowSelectionWindow(string filePath);

		// Token: 0x06000D7F RID: 3455
		List<SelectedExcel> GetSelectedItems();
	}
}

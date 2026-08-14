using System;
using System.Collections.Generic;
using DiRoots.One.TableGen.ViewModels;
using DiRoots.One.TGDatabaseLayer;

namespace DiRoots.One.TableGen.Services
{
	// Token: 0x02000167 RID: 359
	public interface IFileInfoExtractionService
	{
		// Token: 0x06000D65 RID: 3429
		void Initialize(long importTypes, long viewTypeId, int viewScale);

		// Token: 0x06000D66 RID: 3430
		SelectedExcel ExtractFromFile(string filePath);

		// Token: 0x06000D67 RID: 3431
		List<SelectedExcel> ExtractFromFileViewModel(IFileInfoViewModel fileInfoViewModel);
	}
}

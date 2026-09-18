using System;
using System.Collections.Generic;
using DiRoots.One.SheetGen.Models;

namespace DiRoots.One.SheetGen.Delegates
{
	// Token: 0x02000388 RID: 904
	// (Invoke) Token: 0x060024CD RID: 9421
	public delegate void CreateSheetsAndViewsFinishedHandler(bool isSuccess, bool isDelete, ICollection<FailedSheetReport> reports);
}

using System;
using System.Collections.Generic;
using DiRoots.One.SheetGen.Models;

namespace DiRoots.One.SheetGen.Delegates
{
	// Token: 0x02000389 RID: 905
	// (Invoke) Token: 0x060024D1 RID: 9425
	public delegate void DeletingSheetsFinishedHandler(bool isSuccess, ICollection<FailedSheetReport> reports);
}

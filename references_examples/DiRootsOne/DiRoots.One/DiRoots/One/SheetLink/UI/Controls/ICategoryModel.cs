using System;
using System.Collections.Generic;

namespace DiRoots.One.SheetLink.UI.Controls
{
	// Token: 0x02000222 RID: 546
	public interface ICategoryModel
	{
		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x06001538 RID: 5432
		// (set) Token: 0x06001539 RID: 5433
		long Id { get; set; }

		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x0600153A RID: 5434
		// (set) Token: 0x0600153B RID: 5435
		string Name { get; set; }

		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x0600153C RID: 5436
		// (set) Token: 0x0600153D RID: 5437
		bool IsSelected { get; set; }

		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x0600153E RID: 5438
		// (set) Token: 0x0600153F RID: 5439
		bool FilterPassed { get; set; }

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x06001540 RID: 5440
		// (set) Token: 0x06001541 RID: 5441
		List<string> CatType { get; set; }
	}
}

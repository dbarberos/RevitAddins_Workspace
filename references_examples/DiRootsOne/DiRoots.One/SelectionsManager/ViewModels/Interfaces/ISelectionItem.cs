using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace SelectionsManager.ViewModels.Interfaces
{
	// Token: 0x02000028 RID: 40
	public interface ISelectionItem
	{
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600015C RID: 348
		// (set) Token: 0x0600015D RID: 349
		long Id { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600015E RID: 350
		// (set) Token: 0x0600015F RID: 351
		Element Element { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000160 RID: 352
		// (set) Token: 0x06000161 RID: 353
		string Name { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000162 RID: 354
		// (set) Token: 0x06000163 RID: 355
		List<SelectedElementsBagViewModel> SelectedElements { get; set; }
	}
}

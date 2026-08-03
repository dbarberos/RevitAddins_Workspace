using System;
using DiRoots.One.ViewAligner.Data.Models;

namespace A
{
	// Token: 0x020000C7 RID: 199
	internal interface \u0004\u0019
	{
		// Token: 0x1700020C RID: 524
		// (get) Token: 0x060007AE RID: 1966
		// (set) Token: 0x060007AF RID: 1967
		string SearchWord { get; set; }

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x060007B0 RID: 1968
		Predicate<ViewInfo> IsTargetViewFilter { get; }

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x060007B1 RID: 1969
		Predicate<ViewInfo> InViewSetFilter { get; }

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x060007B2 RID: 1970
		Predicate<ViewInfo> SimilarViewsOnlyFilter { get; }

		// Token: 0x060007B3 RID: 1971
		bool \u0004(object \u001F);
	}
}

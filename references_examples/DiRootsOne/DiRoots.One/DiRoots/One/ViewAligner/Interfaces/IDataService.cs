using System;
using System.Collections.Generic;
using DiRoots.One.ViewAligner.Data.Models;

namespace DiRoots.One.ViewAligner.Interfaces
{
	// Token: 0x020000C9 RID: 201
	public interface IDataService
	{
		// Token: 0x060007C0 RID: 1984
		List<ViewInfo> GetSheets();

		// Token: 0x060007C1 RID: 1985
		List<ViewInfo> GetSheetsByBrowserOrganization(List<ViewInfo> views);

		// Token: 0x060007C2 RID: 1986
		List<ViewSetInfo> GetViewSets();

		// Token: 0x060007C3 RID: 1987
		bool IsSimilarViews(ViewInfo source, ViewInfo target);

		// Token: 0x060007C4 RID: 1988
		long GetActiveSheetViewId();

		// Token: 0x060007C5 RID: 1989
		string GetSectionBoxName(long viewId);
	}
}

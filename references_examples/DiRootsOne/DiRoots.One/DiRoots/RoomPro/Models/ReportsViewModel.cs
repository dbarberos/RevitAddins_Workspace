using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x0200007F RID: 127
	public class ReportsViewModel : BaseReportsViewModel, IShowElements
	{
		// Token: 0x06000578 RID: 1400 RVA: 0x00020144 File Offset: 0x0001E344
		public ReportsViewModel(List<Report> reports, Type type, int width = 500) : base(reports, type)
		{
			\u001D\u000A\u001D.\u000A(this, width);
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x00020160 File Offset: 0x0001E360
		public override void ExportToExcel()
		{
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x00020170 File Offset: 0x0001E370
		public void ShowHighlightedItems(List<Report> selectedItems)
		{
			ReportsViewModel.\u001E\u001D u001E_u001D = new ReportsViewModel.\u001E\u001D();
			UIDocument u001F = \u0004\u000A\u001D.\u000A(\u0019\u000A\u001D.\u000A());
			u001E_u001D.\u001F = \u0011\u0020\u000A.\u0007(u001F);
			IEnumerable<ViewsReport> enumerable = Enumerable.Distinct<ViewsReport>(Enumerable.OfType<ViewsReport>(selectedItems));
			Func<ViewsReport, bool> func;
			if ((func = ReportsViewModel.<>c.\u000A) == null)
			{
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReportsViewModel.ShowHighlightedItems(List<Report>)).MethodHandle;
				}
				func = (ReportsViewModel.<>c.\u000A = new Func<ViewsReport, bool>(ReportsViewModel.<>c.\u001F.\u001D));
			}
			IEnumerable<ViewsReport> enumerable2 = Enumerable.Where<ViewsReport>(enumerable, func);
			Func<ViewsReport, ElementId> func2;
			if ((func2 = ReportsViewModel.<>c.\u0007) == null)
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				func2 = (ReportsViewModel.<>c.\u0007 = new Func<ViewsReport, ElementId>(ReportsViewModel.<>c.\u001F.\u0004));
			}
			List<ElementId> list = Enumerable.ToList<ElementId>(Enumerable.Where<ElementId>(Enumerable.Select<ViewsReport, ElementId>(enumerable2, func2), new Func<ElementId, bool>(u001E_u001D.\u000A)));
			if (Enumerable.Any<ElementId>(list))
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				\u000D\u001E\u000A.\u000A(\u0010\u001E\u000A.\u0007(u001F), list);
				\u000E\u0013\u000A.\u000A(u001F, list);
			}
		}

		// Token: 0x020007B8 RID: 1976
		[CompilerGenerated]
		private sealed class \u001E\u001D
		{
			// Token: 0x06004C24 RID: 19492 RVA: 0x001DBA30 File Offset: 0x001D9C30
			internal bool \u000A(ElementId \u001F)
			{
				return \u0011\u0017\u000A.\u0007(this.\u001F, \u001F) != \u0007\u000B\u000E.\u001F;
			}

			// Token: 0x04001F3F RID: 7999
			public Document \u001F;
		}
	}
}

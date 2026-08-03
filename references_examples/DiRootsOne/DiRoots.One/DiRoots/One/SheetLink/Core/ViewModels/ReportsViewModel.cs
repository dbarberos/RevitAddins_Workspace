using System;
using System.Collections.Generic;
using System.Linq;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;

namespace DiRoots.One.SheetLink.Core.ViewModels
{
	// Token: 0x0200027A RID: 634
	public class ReportsViewModel : BaseReportsViewModel
	{
		// Token: 0x06001924 RID: 6436 RVA: 0x000A2F74 File Offset: 0x000A1174
		public ReportsViewModel(List<Report> reports, Type type, int width = 1005) : base(reports, type)
		{
			\u001D\u000A\u001D.\u000A(this, width);
		}

		// Token: 0x06001925 RID: 6437 RVA: 0x000A2F90 File Offset: 0x000A1190
		public override void ExportToExcel()
		{
			string text = \u0004\u000F.\u0018(\u001F\u0011\u0018.\u000A().\u0007(), false, false);
			if (!\u001A\u0006\u0007.\u000A(text))
			{
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReportsViewModel.ExportToExcel()).MethodHandle;
				}
				if (\u0014\u001C\u001D.\u000A(Enumerable.ToList<Report>(\u001A\u001C\u001D.\u0007(this)), \u0013\u001C\u001D.\u0007(this), text, "Issues"))
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
					\u0018\u0020\u000A.\u001D(\u0017\u001C\u001D.\u000A(text));
				}
			}
		}
	}
}

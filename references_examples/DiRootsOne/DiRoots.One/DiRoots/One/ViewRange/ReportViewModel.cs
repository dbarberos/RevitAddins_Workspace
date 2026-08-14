using System;
using System.Collections.Generic;
using System.Linq;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.SheetGen.Data;

namespace DiRoots.One.ViewRange
{
	// Token: 0x02000293 RID: 659
	public class ReportViewModel : BaseReportsViewModel
	{
		// Token: 0x060019C0 RID: 6592 RVA: 0x000A6060 File Offset: 0x000A4260
		public ReportViewModel(List<Report> reports) : base(reports, \u001E\u0011\u000A.\u000A(\u0014\u0012\u000E.\u001F()))
		{
			\u001D\u000A\u001D.\u000A(this, 800);
		}

		// Token: 0x060019C1 RID: 6593 RVA: 0x000A6090 File Offset: 0x000A4290
		public override void ExportToExcel()
		{
			string text = \u000D\u001B\u000A.\u001F("", \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004).\u0007(), \u001E\u001D\u000E.\u001F);
			if (!\u001A\u0006\u0007.\u000A(text))
			{
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReportViewModel.ExportToExcel()).MethodHandle;
				}
				if (\u0014\u001C\u001D.\u000A(Enumerable.ToList<Report>(\u001A\u001C\u001D.\u0007(this)), \u0013\u001C\u001D.\u0007(this), text, "Issues"))
				{
					for (;;)
					{
						switch (1)
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

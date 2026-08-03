using System;
using System.Collections.Generic;
using System.Linq;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;

namespace ProSheets.ScheduleAssistant.ViewModel
{
	// Token: 0x020000A7 RID: 167
	public class ReportsViewModel : BaseReportsViewModel
	{
		// Token: 0x060009A4 RID: 2468 RVA: 0x0003BFCC File Offset: 0x0003A1CC
		public ReportsViewModel(List<Report> reports) : base(reports, \u000A\u001D\u0018.\u0018(\u0008\u0007\u000F.\u000C()))
		{
			\u0005\u0018\u0016.\u0018(this, 800);
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0003BFFC File Offset: 0x0003A1FC
		public override void ExportToExcel()
		{
			string text = \u0004\u0006\u0014.\u0018(\u0008\u0002\u0018.\u0018(\u0007\u0015\u0018.\u0003));
			if (\u001F\u001A\u0018.\u0018(text))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReportsViewModel.ExportToExcel()).MethodHandle;
				}
				text = \u0004\u0006\u0014.\u0018(\u0006\u0004\u0018.\u0018(\u0007\u0015\u0018.\u0003));
			}
			string u = \u0014\u001E\u0018.\u0018(\u0015\u0010\u0014.\u0018(), text, ".xlsx");
			try
			{
				\u000E\u0018\u0016.\u0018(Enumerable.ToList<Report>(\u0018\u0014\u0016.\u0018(this)), \u000C\u0014\u0016.\u0018(this), u, "Issues");
			}
			catch (Exception)
			{
			}
		}
	}
}

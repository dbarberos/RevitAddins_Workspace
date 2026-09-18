using System;
using System.Collections.Generic;
using System.Linq;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;

namespace DiRoots.One.Morta.ViewModel
{
	// Token: 0x020001AD RID: 429
	public class ReportsViewModel : BaseReportsViewModel
	{
		// Token: 0x06000FE2 RID: 4066 RVA: 0x000652DC File Offset: 0x000634DC
		public ReportsViewModel(List<Report> reports, Type type, int width = 1005) : base(reports, type)
		{
			\u001D\u000A\u001D.\u000A(this, width);
		}

		// Token: 0x06000FE3 RID: 4067 RVA: 0x000652F8 File Offset: 0x000634F8
		public override void ExportToExcel()
		{
			string text = \u0004\u000F.\u0018("Morta_Warnings", false, false);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReportsViewModel.ExportToExcel()).MethodHandle;
				}
				if (\u0014\u001C\u001D.\u000A(Enumerable.ToList<Report>(\u001A\u001C\u001D.\u0007(this)), \u0013\u001C\u001D.\u0007(this), text, "Issues"))
				{
					for (;;)
					{
						switch (7)
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

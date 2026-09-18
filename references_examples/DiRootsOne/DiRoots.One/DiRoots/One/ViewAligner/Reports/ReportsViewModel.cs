using System;
using System.Collections.Generic;
using System.Linq;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;

namespace DiRoots.One.ViewAligner.Reports
{
	// Token: 0x020000C2 RID: 194
	public class ReportsViewModel : BaseReportsViewModel
	{
		// Token: 0x06000793 RID: 1939 RVA: 0x0002BCDC File Offset: 0x00029EDC
		public ReportsViewModel(List<Report> reports, Type type, string excelFileName, int width = 1005) : base(reports, type)
		{
			\u001D\u000A\u001D.\u000A(this, width);
			this.DL = excelFileName;
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x0002BD00 File Offset: 0x00029F00
		public override void ExportToExcel()
		{
			string text = \u000D\u001B\u000A.\u001F("", this.DL, \u001E\u001D\u000E.\u001F);
			if (!\u001A\u0006\u0007.\u000A(text))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReportsViewModel.ExportToExcel()).MethodHandle;
				}
				if (\u0014\u001C\u001D.\u000A(Enumerable.ToList<Report>(\u001A\u001C\u001D.\u0007(this)), \u0013\u001C\u001D.\u0007(this), text, "Issues"))
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
					\u0018\u0020\u000A.\u001D(\u0017\u001C\u001D.\u000A(text));
				}
			}
		}

		// Token: 0x0400030D RID: 781
		private readonly string DL;
	}
}

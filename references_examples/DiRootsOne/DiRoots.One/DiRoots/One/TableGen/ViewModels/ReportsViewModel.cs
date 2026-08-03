using System;
using System.Collections.Generic;
using System.Linq;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;

namespace DiRoots.One.TableGen.ViewModels
{
	// Token: 0x02000151 RID: 337
	public class ReportsViewModel : BaseReportsViewModel
	{
		// Token: 0x06000CA2 RID: 3234 RVA: 0x0004FD60 File Offset: 0x0004DF60
		public ReportsViewModel(List<Report> reports, Type type, int width = 1005) : base(reports, type)
		{
			\u001D\u000A\u001D.\u000A(this, width);
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x0004FD7C File Offset: 0x0004DF7C
		public override void ExportToExcel()
		{
			string u000A = \u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()).\u0007();
			string text = \u000D\u001B\u000A.\u001F("", u000A, \u001E\u001D\u000E.\u001F);
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

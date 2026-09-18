using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.ViewAligner.Interfaces;

namespace DiRoots.One.ViewAligner.Services
{
	// Token: 0x020000C5 RID: 197
	public class ReportingService : IReportingService
	{
		// Token: 0x060007A5 RID: 1957 RVA: 0x0002C570 File Offset: 0x0002A770
		public ReportingService(Window window, string pluginName, string fileName)
		{
			this.\u001F = window;
			this.\u000A = pluginName;
			this.\u0007 = fileName;
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0002C598 File Offset: 0x0002A798
		public void Report(string message)
		{
			\u000C\u000D\u001D.\u000A(message, this.\u001F);
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0002C5B4 File Offset: 0x0002A7B4
		public void Report(Exception ex)
		{
			string u001F = \u000A\u0010\u001D.\u000A(\u001F\u0010\u001D.\u000A(ex));
			string u000A = \u0003\u0012\u001D.\u000A(\u001F\u0010\u001D.\u000A(ex));
			string u;
			if (\u0003\u001A\u000A.\u000A(ex) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReportingService.Report(Exception)).MethodHandle;
				}
				u = "";
			}
			else
			{
				u = \u0003\u001A\u000A.\u000A(ex);
			}
			string u001D;
			if (\u0009\u000D\u001D.\u000A(ex) == null)
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
				u001D = "";
			}
			else
			{
				u001D = \u0003\u001A\u000A.\u000A(\u0009\u000D\u001D.\u000A(ex));
			}
			string u2;
			if (\u001E\u0018\u001D.\u000A(ex) == null)
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
				u2 = "";
			}
			else
			{
				u2 = \u001E\u0018\u001D.\u000A(ex);
			}
			ErrorWindow u001F2 = \u0001\u000D\u001D.\u000A(u001F, u000A, u, u001D, u2, this.\u000A);
			\u0015\u000D\u001D.\u000A(u001F2, this.\u001F);
			\u0018\u0020\u000A.\u0007(u001F2);
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0002C67C File Offset: 0x0002A87C
		public void Report(List<AlignReport> reports, string title)
		{
			if (\u0004\u0010\u001D.\u000A(reports) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReportingService.Report(List<AlignReport>, string)).MethodHandle;
				}
				return;
			}
			ReportsWindow u001F = \u0003\u0018\u001D.\u000A(\u001D\u0010\u001D.\u000A(Enumerable.ToList<Report>(Enumerable.Cast<Report>(reports)), \u001E\u0011\u000A.\u000A(\u0020\u001D\u000E.\u001F()), this.\u0007, 1005), false);
			\u0007\u0010\u001D.\u0007(u001F, title);
			\u0015\u000D\u001D.\u000A(u001F, this.\u001F);
			\u0018\u0020\u000A.\u0007(u001F);
		}

		// Token: 0x04000314 RID: 788
		private readonly Window \u001F;

		// Token: 0x04000315 RID: 789
		private readonly string \u000A;

		// Token: 0x04000316 RID: 790
		private readonly string \u0007;
	}
}

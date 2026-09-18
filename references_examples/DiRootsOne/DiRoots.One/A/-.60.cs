using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.TableGen.Services;

namespace A
{
	// Token: 0x0200016C RID: 364
	internal class \u001E\u000B : IReportWindowService
	{
		// Token: 0x06000D7C RID: 3452 RVA: 0x00056ED4 File Offset: 0x000550D4
		public void ShowReportWindow(IEnumerable<Report> reports, Type reportType, Window ownerWindow)
		{
			if (!Enumerable.Any<Report>(reports))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u000B.ShowReportWindow(IEnumerable<Report>, Type, Window)).MethodHandle;
				}
				return;
			}
			ReportsWindow u001F = \u0003\u0018\u001D.\u000A(\u000E\u0005\u0019.\u000A(Enumerable.ToList<Report>(reports), reportType, 1005), false);
			\u0007\u0010\u001D.\u0007(u001F, \u0015\u000E\u001D.\u000A());
			\u0020\u0014\u000A.\u0007(u001F, WindowStartupLocation.CenterOwner);
			\u0015\u000D\u001D.\u000A(u001F, ownerWindow);
			\u0018\u0020\u000A.\u0007(u001F);
		}
	}
}

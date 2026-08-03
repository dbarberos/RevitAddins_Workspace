using System;
using System.Collections.Generic;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.SheetGen.Services;

namespace A
{
	// Token: 0x02000354 RID: 852
	internal class \u000F\u0014 : IReportsWindowService
	{
		// Token: 0x0600238C RID: 9100 RVA: 0x000DB7A4 File Offset: 0x000D99A4
		public void ShowWindow<TReport>(ICollection<TReport> reports) where TReport : Report
		{
			\u001F\u000B\u000B.\u000A(\u0007\u0020\u0016.\u000A(), \u0008\u0003\u000B.\u000A(reports));
			\u0009\u0016\u000B.\u000A(\u0007\u0020\u0016.\u000A(), \u001E\u0011\u000A.\u000A(typeof(TReport).TypeHandle));
			ReportsWindow u001F = \u0003\u0018\u001D.\u000A(\u0007\u0020\u0016.\u000A(), false);
			\u0015\u000D\u001D.\u000A(u001F, \u001D\u0011\u0016.\u000A());
			EventHandler u000A;
			if ((u000A = \u000F\u0014.<>c__0<TReport>.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0014.ShowWindow(ICollection<TReport>)).MethodHandle;
				}
				u000A = (\u000F\u0014.<>c__0<TReport>.\u000A = new EventHandler(\u000F\u0014.<>c__0<TReport>.\u001F.\u0007));
			}
			\u0016\u0015\u0007.\u0007(u001F, u000A);
			\u0009\u0001\u0007.\u0007(u001F);
		}
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.One.ViewAligner.Wpf.Windows
{
	// Token: 0x020000BE RID: 190
	public partial class MainWindow : DiRootsWindow
	{
		// Token: 0x0600074B RID: 1867 RVA: 0x0002A8C4 File Offset: 0x00028AC4
		public MainWindow()
		{
			\u0008\u0012\u001D.\u000A(this);
			\u0016\u000C\u0007.\u000A(this, "");
			\u000E\u0012\u001D.\u000A(this);
			EventHandler u000A;
			if ((u000A = MainWindow.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow..ctor()).MethodHandle;
				}
				u000A = (MainWindow.<>c.\u000A = new EventHandler(MainWindow.<>c.\u001F.\u0007));
			}
			\u0016\u0015\u0007.\u001D(this, u000A);
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x0600074C RID: 1868 RVA: 0x0002A928 File Offset: 0x00028B28
		// (set) Token: 0x0600074D RID: 1869 RVA: 0x0002A93C File Offset: 0x00028B3C
		public static MainWindow CurrentWindow { get; private set; }

		// Token: 0x0600074E RID: 1870 RVA: 0x0002A950 File Offset: 0x00028B50
		protected override void ApplyLicense(bool isLicenseValid)
		{
			if (!isLicenseValid)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.ApplyLicense(bool)).MethodHandle;
				}
				\u0019\u000B\u0007.\u0007(this);
			}
		}
	}
}

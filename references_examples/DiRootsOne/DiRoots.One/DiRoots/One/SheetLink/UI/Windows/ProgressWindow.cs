using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.One.SheetLink.UI.Windows
{
	// Token: 0x0200021A RID: 538
	public class ProgressWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x0600149E RID: 5278 RVA: 0x000869A0 File Offset: 0x00084BA0
		public ProgressWindow(ProgressModel progressModel)
		{
			this.VH = progressModel;
			\u0018\u001A\u0019.\u000A(this.VH, this);
			\u0017\u001A\u000A.\u0007(this, this.VH);
			\u0007\u001D\u0005.\u000A(this);
			\u000A\u001D\u0005.\u000A(this, false);
			if (\u001F\u001D\u0005.\u000A(this.VH))
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProgressWindow..ctor(ProgressModel)).MethodHandle;
				}
				\u0014\u001A\u000A.\u000A(this.PH, "");
				\u0009\u0007\u0005.\u000A(this.XH, \u001F\u001D\u0005.\u000A(this.VH));
			}
			\u0016\u0015\u0007.\u001D(this, new EventHandler(this.ProgressWindow_Closed));
		}

		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x0600149F RID: 5279 RVA: 0x00086A3C File Offset: 0x00084C3C
		// (set) Token: 0x060014A0 RID: 5280 RVA: 0x00086A50 File Offset: 0x00084C50
		public bool CancelProgress { get; private set; }

		// Token: 0x060014A1 RID: 5281 RVA: 0x00086A64 File Offset: 0x00084C64
		private void ProgressWindow_Closed(object sender, EventArgs e)
		{
			\u001D\u001D\u0005.\u000A(this, true);
		}

		// Token: 0x060014A2 RID: 5282 RVA: 0x00086A78 File Offset: 0x00084C78
		private void wndProgress_ContentRendered(object sender, EventArgs ea)
		{
			\u001D\u001D\u0005.\u000A(this, false);
			\u0004\u001D\u0005.\u000A(this.VH);
		}

		// Token: 0x060014A3 RID: 5283 RVA: 0x00086A98 File Offset: 0x00084C98
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProgressWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink.core/ui/windows/progresswindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060014A4 RID: 5284 RVA: 0x00086AE0 File Offset: 0x00084CE0
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0020\u0002\u0019.\u000A(\u000C\u0002\u000E.\u001F(R), new EventHandler(this.wndProgress_ContentRendered));
				return;
			case 2:
				this.KR = \u001B\u0001\u0010.\u001F(R);
				return;
			case 3:
				this.XH = \u0013\u000A\u000E.\u001F(R);
				return;
			case 4:
				this.PH = \u001A\u000A\u000E.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x040007DC RID: 2012
		private readonly ProgressModel VH;

		// Token: 0x040007DD RID: 2013
		[CompilerGenerated]
		private bool ZH;

		// Token: 0x040007DE RID: 2014
		internal TextBlock KR;

		// Token: 0x040007DF RID: 2015
		internal ProgressBar XH;

		// Token: 0x040007E0 RID: 2016
		internal Label PH;

		// Token: 0x040007E1 RID: 2017
		private bool R;
	}
}

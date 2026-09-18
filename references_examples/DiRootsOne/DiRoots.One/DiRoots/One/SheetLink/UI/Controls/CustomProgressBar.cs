using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons;

namespace DiRoots.One.SheetLink.UI.Controls
{
	// Token: 0x02000225 RID: 549
	public class CustomProgressBar : UserControl, IComponentConnector
	{
		// Token: 0x0600156C RID: 5484 RVA: 0x0008B5D4 File Offset: 0x000897D4
		public CustomProgressBar()
		{
			\u0010\u0018\u0005.\u000A(this, new ProgressModel());
			\u0017\u001A\u000A.\u0007(this, \u0010\u0014\u0019.\u001D(this));
			\u000D\u0018\u0005.\u000A(this);
		}

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x0600156D RID: 5485 RVA: 0x0008B608 File Offset: 0x00089808
		// (set) Token: 0x0600156E RID: 5486 RVA: 0x0008B61C File Offset: 0x0008981C
		public ProgressModel ViewModel { get; set; }

		// Token: 0x0600156F RID: 5487 RVA: 0x0008B630 File Offset: 0x00089830
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.H)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomProgressBar.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.H = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink.core/ui/usercontrols/customprogressbar.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001570 RID: 5488 RVA: 0x0008B678 File Offset: 0x00089878
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.C(int F, object R)
		{
			if (F == 1)
			{
				this.R = \u0013\u000A\u000E.\u001F(R);
				return;
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(CustomProgressBar.C(int, object)).MethodHandle;
			}
			if (F != 2)
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
				this.H = true;
				return;
			}
			this.D = \u001B\u0001\u0010.\u001F(R);
		}

		// Token: 0x04000850 RID: 2128
		[CompilerGenerated]
		private ProgressModel F;

		// Token: 0x04000851 RID: 2129
		internal ProgressBar R;

		// Token: 0x04000852 RID: 2130
		internal TextBlock D;

		// Token: 0x04000853 RID: 2131
		private bool H;
	}
}

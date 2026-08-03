using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace ProSheets
{
	// Token: 0x0200006C RID: 108
	public class ExportLimitWarning : DiRootsWindow, IComponentConnector
	{
		// Token: 0x06000637 RID: 1591 RVA: 0x000253E4 File Offset: 0x000235E4
		public ExportLimitWarning(int maxNumberOfExports)
		{
			\u0010\u000F\u0003.\u0018(this);
			\u000B\u000F\u0003.\u0018(this.FR, \u001C\u001E\u0018.\u0018(\u0007\u000F\u0003.\u0018(this.FR), maxNumberOfExports));
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x00025424 File Offset: 0x00023624
		private void btnOpenLink_Click(object sender, RoutedEventArgs e)
		{
			\u0006\u000F\u0003.\u0018("https://diroots.com/ProSheets/upgrade-to-premium");
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x00025444 File Offset: 0x00023644
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.Q)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportLimitWarning.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.Q = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/ui/warnings/exportlimitwarning.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0002548C File Offset: 0x0002368C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		void IComponentConnector.CN(int P, object Q)
		{
			if (P == 1)
			{
				this.FR = \u000C\u0004\u000F.\u000C(Q);
				return;
			}
			for (;;)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(ExportLimitWarning.CN(int, object)).MethodHandle;
			}
			if (P != 2)
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
				this.Q = true;
				return;
			}
			this.RR = \u000E\u0002\u000F.\u000C(Q);
			\u000C\u0019\u0018.\u0018(this.RR, new RoutedEventHandler(this.btnOpenLink_Click));
		}

		// Token: 0x04000249 RID: 585
		internal TextBlock FR;

		// Token: 0x0400024A RID: 586
		internal Button RR;

		// Token: 0x0400024B RID: 587
		private bool Q;
	}
}

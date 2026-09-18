using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Navigation;
using A;
using DiRoots.One.Commons.WindowControl;

namespace ProSheets
{
	// Token: 0x02000069 RID: 105
	public class NwcNotInstalledWarning : DiRootsWindow, IComponentConnector
	{
		// Token: 0x060005C4 RID: 1476 RVA: 0x00021D0C File Offset: 0x0001FF0C
		public NwcNotInstalledWarning()
		{
			\u001E\u000C\u0003.\u0018(this);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x00021D28 File Offset: 0x0001FF28
		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			ProcessStartInfo u000C = \u001D\u000C\u0003.\u0018(\u001A\u000C\u0003.\u0018(\u000B\u000C\u0003.\u0018(e)));
			\u0004\u000C\u0003.\u0018(u000C, true);
			\u0002\u000C\u0003.\u0018(u000C);
			\u001D\u000B\u0018.\u0018(e, true);
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x00021D64 File Offset: 0x0001FF64
		private void btnOpenFolder_Click(object sender, RoutedEventArgs e)
		{
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x00021D78 File Offset: 0x0001FF78
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.Q)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NwcNotInstalledWarning.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.Q = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/ui/nwcnotinstalledwarning.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00021DC0 File Offset: 0x0001FFC0
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.CN(int P, object Q)
		{
			if (P == 1)
			{
				\u0019\u000C\u0003.\u0018(\u0009\u000B\u000F.\u000C(Q), new RequestNavigateEventHandler(this.Hyperlink_RequestNavigate));
				return;
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(NwcNotInstalledWarning.CN(int, object)).MethodHandle;
			}
			if (P != 2)
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
				this.Q = true;
				return;
			}
			this.XJ = \u000E\u0002\u000F.\u000C(Q);
			\u000C\u0019\u0018.\u0018(this.XJ, new RoutedEventHandler(this.btnOpenFolder_Click));
		}

		// Token: 0x04000206 RID: 518
		internal Button XJ;

		// Token: 0x04000207 RID: 519
		private bool Q;
	}
}

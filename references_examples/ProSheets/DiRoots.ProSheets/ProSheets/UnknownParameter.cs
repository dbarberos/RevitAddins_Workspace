using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace ProSheets
{
	// Token: 0x0200006B RID: 107
	public class UnknownParameter : DiRootsWindow, IComponentConnector
	{
		// Token: 0x06000630 RID: 1584 RVA: 0x000252A8 File Offset: 0x000234A8
		public UnknownParameter()
		{
			\u001A\u000F\u0003.\u0018(this);
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000631 RID: 1585 RVA: 0x000252C4 File Offset: 0x000234C4
		// (set) Token: 0x06000632 RID: 1586 RVA: 0x000252D8 File Offset: 0x000234D8
		public string Message { get; set; }

		// Token: 0x06000633 RID: 1587 RVA: 0x000252EC File Offset: 0x000234EC
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			\u000B\u000F\u0003.\u0018(this.QB, \u0019\u000F\u0003.\u0018(this));
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0002530C File Offset: 0x0002350C
		private void btnCancel_Click_1(object sender, RoutedEventArgs e)
		{
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00025320 File Offset: 0x00023520
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		public void InitializeComponent()
		{
			if (this.Q)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UnknownParameter.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.Q = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/ui/unknownparameter.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x00025368 File Offset: 0x00023568
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		void IComponentConnector.CN(int P, object Q)
		{
			switch (P)
			{
			case 1:
				\u0018\u0019\u0018.\u0018(\u000C\u0019\u000F.\u000C(Q), new RoutedEventHandler(this.Window_Loaded));
				return;
			case 2:
				this.QB = \u000C\u0004\u000F.\u000C(Q);
				return;
			case 3:
				this.PB = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.PB, new RoutedEventHandler(this.btnCancel_Click_1));
				return;
			default:
				this.Q = true;
				return;
			}
		}

		// Token: 0x04000245 RID: 581
		[CompilerGenerated]
		private string JR;

		// Token: 0x04000246 RID: 582
		internal TextBlock QB;

		// Token: 0x04000247 RID: 583
		internal Button PB;

		// Token: 0x04000248 RID: 584
		private bool Q;
	}
}

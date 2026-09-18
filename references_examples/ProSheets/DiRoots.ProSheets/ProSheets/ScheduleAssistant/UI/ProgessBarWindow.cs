using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace ProSheets.ScheduleAssistant.UI
{
	// Token: 0x020000AA RID: 170
	public class ProgessBarWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x06000A01 RID: 2561 RVA: 0x0003E190 File Offset: 0x0003C390
		public ProgessBarWindow()
		{
			\u0011\u0012\u0016.\u0018(this);
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x0003E1AC File Offset: 0x0003C3AC
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProgessBarWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.Q = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/scheduleassistant/ui/progessbar.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x0003E1F4 File Offset: 0x0003C3F4
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.CN(int P, object Q)
		{
			switch (P)
			{
			case 1:
				this.XH = \u0009\u0019\u000F.\u000C(Q);
				return;
			case 2:
				this.YH = \u000C\u0004\u000F.\u000C(Q);
				return;
			case 3:
				this.OH = \u000C\u0004\u000F.\u000C(Q);
				return;
			default:
				this.Q = true;
				return;
			}
		}

		// Token: 0x040004A6 RID: 1190
		internal ProgressBar XH;

		// Token: 0x040004A7 RID: 1191
		internal TextBlock YH;

		// Token: 0x040004A8 RID: 1192
		internal TextBlock OH;

		// Token: 0x040004A9 RID: 1193
		private bool Q;
	}
}

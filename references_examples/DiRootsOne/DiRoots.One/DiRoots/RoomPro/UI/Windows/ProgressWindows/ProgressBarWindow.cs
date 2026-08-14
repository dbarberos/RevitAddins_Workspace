using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;
using A;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.RoomPro.UI.Windows.ProgressWindows
{
	// Token: 0x0200006A RID: 106
	public class ProgressBarWindow : DiRootsWindow, IProgressWindow, IComponentConnector
	{
		// Token: 0x060004AA RID: 1194 RVA: 0x0001DC28 File Offset: 0x0001BE28
		public ProgressBarWindow(string title = "")
		{
			\u0012\u0015\u0007.\u000A(this);
			\u000F\u0015\u0007.\u000A(this.KR, title);
			\u0016\u000C\u0007.\u000A(this, title);
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x0001DC5C File Offset: 0x0001BE5C
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x0001DC70 File Offset: 0x0001BE70
		public bool IsStopped { get; set; }

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x0001DC84 File Offset: 0x0001BE84
		// (set) Token: 0x060004AE RID: 1198 RVA: 0x0001DC98 File Offset: 0x0001BE98
		public Action IsClosedEvent { get; set; }

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x0001DCAC File Offset: 0x0001BEAC
		// (set) Token: 0x060004B0 RID: 1200 RVA: 0x0001DCC0 File Offset: 0x0001BEC0
		public bool ClosedByUser { get; set; } = true;

		// Token: 0x060004B1 RID: 1201 RVA: 0x0001DCD4 File Offset: 0x0001BED4
		public void TrackProgress(double percent, string text = null, string infoText = "")
		{
			object u001F = \u001C\u0015\u0007.\u0007(this);
			Delegate u000A = new ProgressBarWindow.\u0011\u001D(this.PropagateProgressToView);
			object[] array = \u0004\u0015\u0010.\u001F(3);
			array[0] = percent;
			array[1] = text;
			array[2] = infoText;
			\u000D\u0015\u0007.\u000A(u001F, u000A, array);
			object u001F2 = \u001C\u0015\u0007.\u0007(this);
			DispatcherPriority u000A2 = DispatcherPriority.Background;
			Action u;
			if ((u = ProgressBarWindow.<>c.\u000A) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProgressBarWindow.TrackProgress(double, string, string)).MethodHandle;
				}
				u = (ProgressBarWindow.<>c.\u000A = new Action(ProgressBarWindow.<>c.\u001F.\u0007));
			}
			\u0003\u0015\u0007.\u000A(u001F2, u000A2, u);
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0001DD5C File Offset: 0x0001BF5C
		public void PropagateProgressToView(double percent, string text = null, string infoText = "")
		{
			if (text == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProgressBarWindow.PropagateProgressToView(double, string, string)).MethodHandle;
				}
				text = "";
			}
			\u000E\u0015\u0007.\u000A(this.JR, \u0008\u0015\u0007.\u000A(percent));
			\u0014\u001A\u000A.\u000A(this.NR, \u0002\u0013\u000A.\u000A(text, \u0010\u0015\u0007.\u000A(ref percent), "%"));
			\u000F\u0015\u0007.\u000A(this.ER, infoText);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0001DDC8 File Offset: 0x0001BFC8
		private void ProgressWindow_Closing(object sender, CancelEventArgs e)
		{
			if (\u0020\u0015\u0007.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProgressBarWindow.ProgressWindow_Closing(object, CancelEventArgs)).MethodHandle;
				}
				\u001E\u0015\u0007.\u000A(this, true);
			}
			Action action = \u0011\u0015\u0007.\u0007(this);
			if (action == null)
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
				return;
			}
			\u001B\u0015\u0007.\u000A(action);
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0001DE18 File Offset: 0x0001C018
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProgressBarWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/quickviews/ui/window/progresswindows/progressbarwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0001DE60 File Offset: 0x0001C060
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0017\u0015\u0007.\u0007(\u0014\u000A\u000E.\u001F(R), new CancelEventHandler(this.ProgressWindow_Closing));
				return;
			case 2:
				this.KR = \u001B\u0001\u0010.\u001F(R);
				return;
			case 3:
				this.JR = \u0013\u000A\u000E.\u001F(R);
				return;
			case 4:
				this.ER = \u001B\u0001\u0010.\u001F(R);
				return;
			case 5:
				this.NR = \u001A\u000A\u000E.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x040001BF RID: 447
		[CompilerGenerated]
		private bool BR;

		// Token: 0x040001C0 RID: 448
		[CompilerGenerated]
		private Action UR;

		// Token: 0x040001C1 RID: 449
		[CompilerGenerated]
		private bool WR;

		// Token: 0x040001C2 RID: 450
		internal TextBlock KR;

		// Token: 0x040001C3 RID: 451
		internal ProgressBar JR;

		// Token: 0x040001C4 RID: 452
		internal TextBlock ER;

		// Token: 0x040001C5 RID: 453
		internal Label NR;

		// Token: 0x040001C6 RID: 454
		private bool R;

		// Token: 0x020007B5 RID: 1973
		// (Invoke) Token: 0x06004C19 RID: 19481
		private delegate void \u0011\u001D(double percent, string text, string infoText);
	}
}

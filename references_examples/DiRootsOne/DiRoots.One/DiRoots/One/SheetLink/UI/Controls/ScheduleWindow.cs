using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.SheetLink.ViewModels;
using Microsoft.Xaml.Behaviors;

namespace DiRoots.One.SheetLink.UI.Controls
{
	// Token: 0x0200022D RID: 557
	public class ScheduleWindow : UserControl, IComponentConnector
	{
		// Token: 0x060015D1 RID: 5585 RVA: 0x0008D888 File Offset: 0x0008BA88
		public ScheduleWindow()
		{
			\u000F\u0016\u0005.\u000A(this);
		}

		// Token: 0x060015D2 RID: 5586 RVA: 0x0008D8A4 File Offset: 0x0008BAA4
		public void Initialize(UIDocument uidoc, Window parent)
		{
			if (!this.F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleWindow.Initialize(UIDocument, Window)).MethodHandle;
				}
				if (!\u001F\u000C\u000A.\u001D(\u0011\u0020\u000A.\u0007(uidoc)))
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
					this.R = \u0012\u0016\u0005.\u000A(uidoc, parent, this);
					\u0017\u001A\u000A.\u0007(this, this.R);
					this.F = true;
				}
			}
		}

		// Token: 0x060015D3 RID: 5587 RVA: 0x0008D90C File Offset: 0x0008BB0C
		public void CustomDispose()
		{
			ScheduleWindowModel r = this.R;
			if (r == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleWindow.CustomDispose()).MethodHandle;
				}
			}
			else
			{
				\u0014\u001A\u0018.\u001D(r);
			}
			this.R = \u000E\u000F\u000E.\u001F;
		}

		// Token: 0x060015D4 RID: 5588 RVA: 0x0008D948 File Offset: 0x0008BB48
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x060015D5 RID: 5589 RVA: 0x0008D970 File Offset: 0x0008BB70
		private void chkTypeId_Checked(object sender, RoutedEventArgs e)
		{
			\u0003\u0016\u0005.\u000A(this.K, true);
		}

		// Token: 0x060015D6 RID: 5590 RVA: 0x0008D98C File Offset: 0x0008BB8C
		private void chkTypeId_Unchecked(object sender, RoutedEventArgs e)
		{
			\u0003\u0016\u0005.\u000A(this.K, false);
		}

		// Token: 0x060015D7 RID: 5591 RVA: 0x0008D9A8 File Offset: 0x0008BBA8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.J)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.J = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink/ui/usercontrols/schedulewindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060015D8 RID: 5592 RVA: 0x0008D9F0 File Offset: 0x0008BBF0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate N(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x060015D9 RID: 5593 RVA: 0x0008DA08 File Offset: 0x0008BC08
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.E(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u0007\u0006\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.D = \u001D\u0009\u0010.\u001F(R);
				return;
			case 3:
				this.H = \u0007\u000F\u000E.\u001F(R);
				return;
			case 4:
				this.C = \u001D\u0009\u0010.\u001F(R);
				return;
			case 5:
				this.L = \u0004\u0009\u0010.\u001F(R);
				return;
			case 6:
				this.S = \u0018\u0009\u0010.\u001F(R);
				return;
			case 7:
				this.B = \u001E\u0001\u0010.\u001F(R);
				return;
			case 8:
				this.U = \u0013\u0006\u000E.\u001F(R);
				return;
			case 9:
				this.W = \u0016\u0009\u0010.\u001F(R);
				\u000E\u0015\u000A.\u000A(this.W, new RoutedEventHandler(this.chkTypeId_Checked));
				\u000D\u0015\u000A.\u000A(this.W, new RoutedEventHandler(this.chkTypeId_Unchecked));
				return;
			case 10:
				this.K = \u001C\u000F\u000E.\u001F(R);
				return;
			default:
				this.J = true;
				return;
			}
		}

		// Token: 0x040008A2 RID: 2210
		private bool F;

		// Token: 0x040008A3 RID: 2211
		private ScheduleWindowModel R;

		// Token: 0x040008A4 RID: 2212
		internal RadioButton D;

		// Token: 0x040008A5 RID: 2213
		internal InvokeCommandAction H;

		// Token: 0x040008A6 RID: 2214
		internal RadioButton C;

		// Token: 0x040008A7 RID: 2215
		internal LeftImageButton L;

		// Token: 0x040008A8 RID: 2216
		internal LeftStripToggleButton S;

		// Token: 0x040008A9 RID: 2217
		internal Button B;

		// Token: 0x040008AA RID: 2218
		internal ScheduleNavigator U;

		// Token: 0x040008AB RID: 2219
		internal CheckBox W;

		// Token: 0x040008AC RID: 2220
		internal ScheduleParameters K;

		// Token: 0x040008AD RID: 2221
		private bool J;
	}
}

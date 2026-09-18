using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;

namespace SelectionsManager.UI.Controls
{
	// Token: 0x02000036 RID: 54
	public class SavedSelectionItemControl : BaseUserControl, IComponentConnector
	{
		// Token: 0x060001C0 RID: 448 RVA: 0x00009440 File Offset: 0x00007640
		public SavedSelectionItemControl()
		{
			\u001B\u0015\u000A.\u000A(this);
			\u0008\u0015\u000A.\u000A(this.L, true);
			\u0008\u0015\u000A.\u000A(this.C, true);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00009474 File Offset: 0x00007674
		protected override void ApplyLicense(bool isLicenseValid)
		{
			\u0011\u0015\u000A.\u0007(this.L, isLicenseValid);
			\u0011\u0015\u000A.\u0007(this.C, isLicenseValid);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000949C File Offset: 0x0000769C
		private void ColorAnimation_Completed(object sender, EventArgs e)
		{
			\u001E\u0015\u000A.\u000A(this.R, \u001E\u000C\u000A.\u000A(\u000A\u0001\u0010.\u001F(\u0020\u000C\u000A.\u000A("#FDF2B9"))));
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000094D0 File Offset: 0x000076D0
		private void ColorAnimation_Completed_1(object sender, EventArgs e)
		{
			\u001E\u0015\u000A.\u000A(this.R, \u0017\u000C\u000A.\u000A());
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x000094F0 File Offset: 0x000076F0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.B)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionItemControl.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.B = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/onefilter/selectionsmanager/ui/controls/savedselections/savedselectionitemcontrol.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00009538 File Offset: 0x00007738
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate GR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00009550 File Offset: 0x00007750
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.QR(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.F = \u0010\u0001\u0010.\u001F(R);
				return;
			case 2:
				\u0017\u0015\u000A.\u000A(\u000E\u0001\u0010.\u001F(R), new EventHandler(this.ColorAnimation_Completed));
				return;
			case 3:
				\u0017\u0015\u000A.\u000A(\u000E\u0001\u0010.\u001F(R), new EventHandler(this.ColorAnimation_Completed_1));
				return;
			case 4:
				this.R = \u0008\u0001\u0010.\u001F(R);
				return;
			case 5:
				this.D = \u001B\u0001\u0010.\u001F(R);
				return;
			case 6:
				this.H = \u0011\u0001\u0010.\u001F(R);
				return;
			case 7:
				this.C = \u001E\u0001\u0010.\u001F(R);
				return;
			case 8:
				this.L = \u001E\u0001\u0010.\u001F(R);
				return;
			case 9:
				this.S = \u0020\u0001\u0010.\u001F(R);
				return;
			default:
				this.B = true;
				return;
			}
		}

		// Token: 0x040000B3 RID: 179
		internal SavedSelectionItemControl F;

		// Token: 0x040000B4 RID: 180
		internal Border R;

		// Token: 0x040000B5 RID: 181
		internal TextBlock D;

		// Token: 0x040000B6 RID: 182
		internal StackPanel H;

		// Token: 0x040000B7 RID: 183
		internal Button C;

		// Token: 0x040000B8 RID: 184
		internal Button L;

		// Token: 0x040000B9 RID: 185
		internal DataGrid S;

		// Token: 0x040000BA RID: 186
		private bool B;
	}
}

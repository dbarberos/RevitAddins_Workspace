using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetGen.DI.Interfaces;

namespace DiRoots.One.SheetGen.Profiles
{
	// Token: 0x020002E5 RID: 741
	public class NewProfileDialog : DiRootsWindow, INewProfile, IComponentConnector
	{
		// Token: 0x06001EA5 RID: 7845 RVA: 0x000C10B0 File Offset: 0x000BF2B0
		public NewProfileDialog()
		{
			\u0019\u0009\u0016.\u000A(this);
		}

		// Token: 0x06001EA6 RID: 7846 RVA: 0x000C10CC File Offset: 0x000BF2CC
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			\u0011\u000E\u0019.\u0007(this.GC);
		}

		// Token: 0x06001EA7 RID: 7847 RVA: 0x000C10E8 File Offset: 0x000BF2E8
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001EA8 RID: 7848 RVA: 0x000C10FC File Offset: 0x000BF2FC
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewProfileDialog.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/profilecontrols/newprofiledialog.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001EA9 RID: 7849 RVA: 0x000C1144 File Offset: 0x000BF344
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06001EAA RID: 7850 RVA: 0x000C115C File Offset: 0x000BF35C
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.VW = \u001B\u000D\u000E.\u001F(R);
				\u0011\u000C\u000A.\u0007(this.VW, new RoutedEventHandler(this.Window_Loaded));
				return;
			case 2:
				this.AC = \u001A\u000A\u000E.\u001F(R);
				return;
			case 3:
				this.GC = \u0001\u000A\u000E.\u001F(R);
				return;
			case 4:
				this.KR = \u001B\u0001\u0010.\u001F(R);
				return;
			case 5:
				this.FL = \u001A\u000A\u000E.\u001F(R);
				return;
			case 6:
				this.RL = \u0001\u000A\u000E.\u001F(R);
				return;
			case 7:
				this.YL = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.YL, new RoutedEventHandler(this.btnCancel_Click));
				return;
			case 8:
				this.H = \u001E\u0001\u0010.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x06001EAB RID: 7851 RVA: 0x000C1244 File Offset: 0x000BF444
		object INewProfile.DFR()
		{
			return \u0007\u000C\u000A.\u001D(this);
		}

		// Token: 0x06001EAC RID: 7852 RVA: 0x000C125C File Offset: 0x000BF45C
		void INewProfile.HFR(object F)
		{
			\u0017\u001A\u000A.\u0007(this, F);
		}

		// Token: 0x06001EAD RID: 7853 RVA: 0x000C1270 File Offset: 0x000BF470
		Window INewProfile.YFR()
		{
			return \u000D\u0011\u0016.\u0007(this);
		}

		// Token: 0x06001EAE RID: 7854 RVA: 0x000C1288 File Offset: 0x000BF488
		void INewProfile.CFR(Window F)
		{
			\u000C\u000E\u0007.\u001D(this, F);
		}

		// Token: 0x06001EAF RID: 7855 RVA: 0x000C129C File Offset: 0x000BF49C
		bool? INewProfile.LFR()
		{
			return \u0018\u0020\u000A.\u001D(this);
		}

		// Token: 0x04000C94 RID: 3220
		internal NewProfileDialog VW;

		// Token: 0x04000C95 RID: 3221
		internal Label AC;

		// Token: 0x04000C96 RID: 3222
		internal TextBox GC;

		// Token: 0x04000C97 RID: 3223
		internal TextBlock KR;

		// Token: 0x04000C98 RID: 3224
		internal Label FL;

		// Token: 0x04000C99 RID: 3225
		internal TextBox RL;

		// Token: 0x04000C9A RID: 3226
		internal Button YL;

		// Token: 0x04000C9B RID: 3227
		internal Button H;

		// Token: 0x04000C9C RID: 3228
		private bool R;
	}
}

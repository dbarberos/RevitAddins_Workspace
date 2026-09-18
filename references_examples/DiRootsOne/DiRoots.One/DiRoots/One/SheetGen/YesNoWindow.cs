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

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002CB RID: 715
	public class YesNoWindow : DiRootsWindow, IYesNoDialog, IComponentConnector
	{
		// Token: 0x06001D13 RID: 7443 RVA: 0x000B7D58 File Offset: 0x000B5F58
		public YesNoWindow()
		{
			\u0010\u0011\u0016.\u000A(this);
		}

		// Token: 0x06001D14 RID: 7444 RVA: 0x000B7D74 File Offset: 0x000B5F74
		public YesNoWindow(string content)
		{
			\u0010\u0011\u0016.\u000A(this);
			\u000E\u0011\u0016.\u000A(this, content);
		}

		// Token: 0x17000829 RID: 2089
		// (get) Token: 0x06001D15 RID: 7445 RVA: 0x000B7D94 File Offset: 0x000B5F94
		// (set) Token: 0x06001D16 RID: 7446 RVA: 0x000B7DA8 File Offset: 0x000B5FA8
		public string Message
		{
			get
			{
				return this.WL;
			}
			set
			{
				this.WL = value;
				\u0008\u0011\u0016.\u000A(this, "Message");
			}
		}

		// Token: 0x06001D17 RID: 7447 RVA: 0x000B7DC8 File Offset: 0x000B5FC8
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001D18 RID: 7448 RVA: 0x000B7DDC File Offset: 0x000B5FDC
		private void btnYes_Click(object sender, RoutedEventArgs e)
		{
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001D19 RID: 7449 RVA: 0x000B7DFC File Offset: 0x000B5FFC
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(YesNoWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/dialogs/yesnowindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001D1A RID: 7450 RVA: 0x000B7E44 File Offset: 0x000B6044
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.KL = \u0016\u001C\u000E.\u001F(R);
				return;
			case 2:
				this.JL = \u001B\u0001\u0010.\u001F(R);
				return;
			case 3:
				this.EL = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.EL, new RoutedEventHandler(this.btnYes_Click));
				return;
			case 4:
				this.NL = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.NL, new RoutedEventHandler(this.btnCancel_Click));
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x06001D1B RID: 7451 RVA: 0x000B7EDC File Offset: 0x000B60DC
		bool? IYesNoDialog.DA()
		{
			return \u0018\u0020\u000A.\u001D(this);
		}

		// Token: 0x06001D1C RID: 7452 RVA: 0x000B7EF4 File Offset: 0x000B60F4
		Window IYesNoDialog.HA()
		{
			return \u000D\u0011\u0016.\u0007(this);
		}

		// Token: 0x06001D1D RID: 7453 RVA: 0x000B7F0C File Offset: 0x000B610C
		void IYesNoDialog.YA(Window F)
		{
			\u000C\u000E\u0007.\u001D(this, F);
		}

		// Token: 0x06001D1E RID: 7454 RVA: 0x000B7F20 File Offset: 0x000B6120
		WindowStartupLocation IYesNoDialog.CA()
		{
			return \u001B\u0011\u0016.\u000A(this);
		}

		// Token: 0x06001D1F RID: 7455 RVA: 0x000B7F38 File Offset: 0x000B6138
		void IYesNoDialog.LA(WindowStartupLocation F)
		{
			\u0020\u0014\u000A.\u001D(this, F);
		}

		// Token: 0x04000BA4 RID: 2980
		private string WL;

		// Token: 0x04000BA5 RID: 2981
		internal YesNoWindow KL;

		// Token: 0x04000BA6 RID: 2982
		internal TextBlock JL;

		// Token: 0x04000BA7 RID: 2983
		internal Button EL;

		// Token: 0x04000BA8 RID: 2984
		internal Button NL;

		// Token: 0x04000BA9 RID: 2985
		private bool R;
	}
}

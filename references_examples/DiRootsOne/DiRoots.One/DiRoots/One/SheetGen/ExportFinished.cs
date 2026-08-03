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
using DiRoots.One.SheetGen.DI.Interfaces;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002D0 RID: 720
	public class ExportFinished : DiRootsWindow, IExportFinished, IComponentConnector
	{
		// Token: 0x06001D55 RID: 7509 RVA: 0x000B90AC File Offset: 0x000B72AC
		public ExportFinished()
		{
			\u0013\u001E\u0016.\u000A(this);
		}

		// Token: 0x1700082D RID: 2093
		// (get) Token: 0x06001D56 RID: 7510 RVA: 0x000B90C8 File Offset: 0x000B72C8
		// (set) Token: 0x06001D57 RID: 7511 RVA: 0x000B90DC File Offset: 0x000B72DC
		public string Message
		{
			get
			{
				return this.HS;
			}
			set
			{
				this.HS = value;
				\u0008\u0011\u0016.\u000A(this, "Message");
			}
		}

		// Token: 0x1700082E RID: 2094
		// (get) Token: 0x06001D58 RID: 7512 RVA: 0x000B90FC File Offset: 0x000B72FC
		// (set) Token: 0x06001D59 RID: 7513 RVA: 0x000B9110 File Offset: 0x000B7310
		public string FilePath { get; set; }

		// Token: 0x06001D5A RID: 7514 RVA: 0x000B9124 File Offset: 0x000B7324
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001D5B RID: 7515 RVA: 0x000B9138 File Offset: 0x000B7338
		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			\u0004\u0019\u0019.\u000A(\u001A\u001E\u0016.\u000A(this));
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001D5C RID: 7516 RVA: 0x000B9158 File Offset: 0x000B7358
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportFinished.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/exportfinished.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001D5D RID: 7517 RVA: 0x000B91A0 File Offset: 0x000B73A0
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.YS = \u0002\u001C\u000E.\u001F(R);
				return;
			case 2:
				this.UL = \u001B\u0001\u0010.\u001F(R);
				return;
			case 3:
				this.H = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.H, new RoutedEventHandler(this.btnOk_Click));
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x06001D5E RID: 7518 RVA: 0x000B9210 File Offset: 0x000B7410
		WindowStartupLocation IExportFinished.TA()
		{
			return \u001B\u0011\u0016.\u000A(this);
		}

		// Token: 0x06001D5F RID: 7519 RVA: 0x000B9228 File Offset: 0x000B7428
		void IExportFinished.IA(WindowStartupLocation F)
		{
			\u0020\u0014\u000A.\u001D(this, F);
		}

		// Token: 0x06001D60 RID: 7520 RVA: 0x000B923C File Offset: 0x000B743C
		Window IExportFinished.QA()
		{
			return \u000D\u0011\u0016.\u0007(this);
		}

		// Token: 0x06001D61 RID: 7521 RVA: 0x000B9254 File Offset: 0x000B7454
		void IExportFinished.AA(Window F)
		{
			\u000C\u000E\u0007.\u001D(this, F);
		}

		// Token: 0x06001D62 RID: 7522 RVA: 0x000B9268 File Offset: 0x000B7468
		bool? IExportFinished.GA()
		{
			return \u0018\u0020\u000A.\u001D(this);
		}

		// Token: 0x04000BCA RID: 3018
		private string HS;

		// Token: 0x04000BCB RID: 3019
		[CompilerGenerated]
		private string OH;

		// Token: 0x04000BCC RID: 3020
		internal ExportFinished YS;

		// Token: 0x04000BCD RID: 3021
		internal TextBlock UL;

		// Token: 0x04000BCE RID: 3022
		internal Button H;

		// Token: 0x04000BCF RID: 3023
		private bool R;
	}
}

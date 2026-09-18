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

namespace DiRoots.One.SheetGen.UI.Windows
{
	// Token: 0x02000394 RID: 916
	public class RenameSheetsWindow : DiRootsWindow, IRenameWindow, IComponentConnector
	{
		// Token: 0x06002538 RID: 9528 RVA: 0x000E0F08 File Offset: 0x000DF108
		public RenameSheetsWindow()
		{
			\u0006\u001F\u0002.\u000A(this);
			\u0011\u000C\u000A.\u001D(this, delegate(object _, RoutedEventArgs __)
			{
				this.XYR();
			});
		}

		// Token: 0x17000A6D RID: 2669
		// (get) Token: 0x06002539 RID: 9529 RVA: 0x000E0F34 File Offset: 0x000DF134
		// (set) Token: 0x0600253A RID: 9530 RVA: 0x000E0F48 File Offset: 0x000DF148
		public FeatureSource FeatureSource { get; set; }

		// Token: 0x0600253B RID: 9531 RVA: 0x000E0F5C File Offset: 0x000DF15C
		private void XYR()
		{
			object vk = this.VK;
			object u000A;
			if (\u001C\u001F\u0002.\u000A(this) != FeatureSource.SheetList)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RenameSheetsWindow.XYR()).MethodHandle;
				}
				u000A = \u0003\u001F\u0002.\u000A();
			}
			else
			{
				u000A = \u0012\u001F\u0002.\u000A();
			}
			\u000F\u001F\u0002.\u000A(vk, u000A);
		}

		// Token: 0x0600253C RID: 9532 RVA: 0x000E0FA4 File Offset: 0x000DF1A4
		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x0600253D RID: 9533 RVA: 0x000E0FC4 File Offset: 0x000DF1C4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RenameSheetsWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/renamesheetswindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x0600253E RID: 9534 RVA: 0x000E100C File Offset: 0x000DF20C
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.MK = \u0011\u000E\u000E.\u001F(R);
				return;
			case 2:
				this.VK = \u001E\u000E\u000E.\u001F(R);
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

		// Token: 0x0600253F RID: 9535 RVA: 0x000E107C File Offset: 0x000DF27C
		bool? IRenameWindow.OFR()
		{
			return \u0018\u0020\u000A.\u001D(this);
		}

		// Token: 0x06002540 RID: 9536 RVA: 0x000E1094 File Offset: 0x000DF294
		object IRenameWindow.TFR()
		{
			return \u0007\u000C\u000A.\u001D(this);
		}

		// Token: 0x06002541 RID: 9537 RVA: 0x000E10AC File Offset: 0x000DF2AC
		void IRenameWindow.IFR(object F)
		{
			\u0017\u001A\u000A.\u0007(this, F);
		}

		// Token: 0x06002542 RID: 9538 RVA: 0x000E10C0 File Offset: 0x000DF2C0
		Window IRenameWindow.QFR()
		{
			return \u000D\u0011\u0016.\u0007(this);
		}

		// Token: 0x06002543 RID: 9539 RVA: 0x000E10D8 File Offset: 0x000DF2D8
		void IRenameWindow.AFR(Window F)
		{
			\u000C\u000E\u0007.\u001D(this, F);
		}

		// Token: 0x04000ED1 RID: 3793
		[CompilerGenerated]
		private FeatureSource NK;

		// Token: 0x04000ED2 RID: 3794
		internal RenameSheetsWindow MK;

		// Token: 0x04000ED3 RID: 3795
		internal GroupBox VK;

		// Token: 0x04000ED4 RID: 3796
		internal Button H;

		// Token: 0x04000ED5 RID: 3797
		private bool R;
	}
}

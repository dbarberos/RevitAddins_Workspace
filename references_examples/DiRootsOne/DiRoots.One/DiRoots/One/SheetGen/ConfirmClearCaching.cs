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
	// Token: 0x020002CA RID: 714
	public class ConfirmClearCaching : DiRootsWindow, IConfirmClearCache, IComponentConnector
	{
		// Token: 0x06001D0B RID: 7435 RVA: 0x000B7C08 File Offset: 0x000B5E08
		public ConfirmClearCaching()
		{
			\u001C\u0011\u0016.\u000A(this);
		}

		// Token: 0x06001D0C RID: 7436 RVA: 0x000B7C24 File Offset: 0x000B5E24
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			\u0006\u0015\u0007.\u0007(this, new bool?(false));
		}

		// Token: 0x06001D0D RID: 7437 RVA: 0x000B7C40 File Offset: 0x000B5E40
		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
		}

		// Token: 0x06001D0E RID: 7438 RVA: 0x000B7C5C File Offset: 0x000B5E5C
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ConfirmClearCaching.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/dialogs/confirmclearcaching.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001D0F RID: 7439 RVA: 0x000B7CA4 File Offset: 0x000B5EA4
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			if (F == 1)
			{
				this.UL = \u001B\u0001\u0010.\u001F(R);
				return;
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(ConfirmClearCaching.QQ(int, object)).MethodHandle;
			}
			if (F != 2)
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
				this.R = true;
				return;
			}
			this.H = \u001E\u0001\u0010.\u001F(R);
			\u0010\u0015\u000A.\u000A(this.H, new RoutedEventHandler(this.btnOk_Click));
		}

		// Token: 0x06001D10 RID: 7440 RVA: 0x000B7D14 File Offset: 0x000B5F14
		bool? IConfirmClearCache.GQ()
		{
			return \u0018\u0020\u000A.\u001D(this);
		}

		// Token: 0x06001D11 RID: 7441 RVA: 0x000B7D2C File Offset: 0x000B5F2C
		Window IConfirmClearCache.FA()
		{
			return \u000D\u0011\u0016.\u0007(this);
		}

		// Token: 0x06001D12 RID: 7442 RVA: 0x000B7D44 File Offset: 0x000B5F44
		void IConfirmClearCache.RA(Window F)
		{
			\u000C\u000E\u0007.\u001D(this, F);
		}

		// Token: 0x04000BA1 RID: 2977
		internal TextBlock UL;

		// Token: 0x04000BA2 RID: 2978
		internal Button H;

		// Token: 0x04000BA3 RID: 2979
		private bool R;
	}
}

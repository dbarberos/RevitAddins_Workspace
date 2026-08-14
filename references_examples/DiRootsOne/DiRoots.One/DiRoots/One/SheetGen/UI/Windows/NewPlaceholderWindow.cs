using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.One.SheetGen.UI.Windows
{
	// Token: 0x02000390 RID: 912
	public class NewPlaceholderWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x0600250E RID: 9486 RVA: 0x000E046C File Offset: 0x000DE66C
		public NewPlaceholderWindow()
		{
			\u000C\u0009\u000B.\u000A(this);
			\u0005\u001B\u000A.\u0018.\u001D<\u001C\u0014>(this, new Action<\u001C\u0014>(this.PCR));
		}

		// Token: 0x0600250F RID: 9487 RVA: 0x000E04A0 File Offset: 0x000DE6A0
		private void PCR(\u001C\u0014 F)
		{
			\u0019\u000B\u0007.\u0007(this);
			\u0005\u001B\u000A.\u0018.\u0004<\u001C\u0014>(this);
		}

		// Token: 0x06002510 RID: 9488 RVA: 0x000E04C0 File Offset: 0x000DE6C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewPlaceholderWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/newplaceholderwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06002511 RID: 9489 RVA: 0x000E0508 File Offset: 0x000DE708
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06002512 RID: 9490 RVA: 0x000E0520 File Offset: 0x000DE720
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.QQ(int F, object R)
		{
			if (F == 1)
			{
				this.KR = \u001B\u0001\u0010.\u001F(R);
				return;
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(NewPlaceholderWindow.QQ(int, object)).MethodHandle;
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
			this.FS = \u001E\u0001\u0010.\u001F(R);
		}

		// Token: 0x04000EA7 RID: 3751
		internal TextBlock KR;

		// Token: 0x04000EA8 RID: 3752
		internal Button FS;

		// Token: 0x04000EA9 RID: 3753
		private bool R;
	}
}

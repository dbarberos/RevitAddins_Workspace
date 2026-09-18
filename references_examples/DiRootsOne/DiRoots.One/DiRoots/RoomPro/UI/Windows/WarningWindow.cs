using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.RoomPro.UI.Windows
{
	// Token: 0x02000068 RID: 104
	public class WarningWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x060004A3 RID: 1187 RVA: 0x0001DAFC File Offset: 0x0001BCFC
		public WarningWindow()
		{
			\u0002\u0015\u0007.\u000A(this);
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0001DB18 File Offset: 0x0001BD18
		private void cancel_Click(object sender, RoutedEventArgs e)
		{
			\u0006\u0015\u0007.\u0007(this, new bool?(false));
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x0001DB38 File Offset: 0x0001BD38
		private void ok_Click(object sender, RoutedEventArgs e)
		{
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x0001DB58 File Offset: 0x0001BD58
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WarningWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/quickviews/ui/window/warningwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0001DBA0 File Offset: 0x0001BDA0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.QQ(int F, object R)
		{
			if (F == 1)
			{
				this.LR = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.LR, new RoutedEventHandler(this.cancel_Click));
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(WarningWindow.QQ(int, object)).MethodHandle;
			}
			if (F != 2)
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
				this.R = true;
				return;
			}
			this.SR = \u001E\u0001\u0010.\u001F(R);
			\u0010\u0015\u000A.\u000A(this.SR, new RoutedEventHandler(this.ok_Click));
		}

		// Token: 0x040001BC RID: 444
		internal Button LR;

		// Token: 0x040001BD RID: 445
		internal Button SR;

		// Token: 0x040001BE RID: 446
		private bool R;
	}
}

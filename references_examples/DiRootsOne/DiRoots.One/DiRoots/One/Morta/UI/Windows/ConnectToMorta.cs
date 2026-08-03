using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Navigation;
using A;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.Morta.Model;
using DiRoots.One.Morta.ViewModel;

namespace DiRoots.One.Morta.UI.Windows
{
	// Token: 0x020001B0 RID: 432
	public class ConnectToMorta : DiRootsWindow, IComponentConnector
	{
		// Token: 0x0600101C RID: 4124 RVA: 0x00066090 File Offset: 0x00064290
		public ConnectToMorta(Login login)
		{
			\u0007\u001D\u0018.\u000A(this);
			\u001C\u000C\u0007.\u0007(this, \u001B\u000A\u0018.\u000A());
			\u0008\u000E\u001D.\u000A(\u0009\u0007\u0018.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\UI\\Windows\\ConnectToMorta.xaml.cs", ".ctor");
			\u000A\u001D\u0018.\u000A(this, new ConnectToMortaViewModel(login));
			\u000A\u000C\u0007.\u0007(\u001F\u001D\u0018.\u000A(this), this);
			\u0017\u001A\u000A.\u0007(this, \u001F\u001D\u0018.\u000A(this));
			\u0008\u000E\u001D.\u000A(\u0009\u0007\u0018.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\UI\\Windows\\ConnectToMorta.xaml.cs", ".ctor");
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x0600101D RID: 4125 RVA: 0x0006610C File Offset: 0x0006430C
		// (set) Token: 0x0600101E RID: 4126 RVA: 0x00066120 File Offset: 0x00064320
		public ConnectToMortaViewModel ViewModel { get; set; }

		// Token: 0x0600101F RID: 4127 RVA: 0x00066134 File Offset: 0x00064334
		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			\u0004\u0019\u0019.\u000A(\u0019\u0019\u0019.\u000A(\u0018\u0019\u0019.\u000A(e)));
			\u0019\u0013\u000A.\u000A(e, true);
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x0006615C File Offset: 0x0006435C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ConnectToMorta.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/morta/ui/windows/connecttomorta.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x000661A4 File Offset: 0x000643A4
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.BH = \u0001\u000A\u000E.\u001F(R);
				return;
			case 2:
				\u0005\u0019\u0019.\u000A(\u0017\u0018\u000E.\u001F(R), new RequestNavigateEventHandler(this.Hyperlink_RequestNavigate));
				return;
			case 3:
				this.UH = \u001E\u0001\u0010.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x04000667 RID: 1639
		[CompilerGenerated]
		private ConnectToMortaViewModel SH;

		// Token: 0x04000668 RID: 1640
		internal TextBox BH;

		// Token: 0x04000669 RID: 1641
		internal Button UH;

		// Token: 0x0400066A RID: 1642
		private bool R;
	}
}

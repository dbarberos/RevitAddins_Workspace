using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.PanelLink.UI.Controls;
using DiRoots.One.PanelLink.ViewModels;
using DiRoots.One.SheetLink.UI.Controls;

namespace DiRoots.One.PanelLink.UI.Windows
{
	// Token: 0x02000199 RID: 409
	public class PanelWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x06000F21 RID: 3873 RVA: 0x00060F10 File Offset: 0x0005F110
		public PanelWindow(UIDocument uidoc)
		{
			\u001C\u000C\u0007.\u0007(this, \u0010\u0011\u000A.\u000A());
			\u000A\u001A\u0019.\u000A(this);
			PanelWindowModel u000A = new PanelWindowModel(uidoc, this);
			\u0017\u001A\u000A.\u0007(this, u000A);
			\u0016\u000C\u0007.\u000A(this, "");
		}

		// Token: 0x06000F22 RID: 3874 RVA: 0x00060F50 File Offset: 0x0005F150
		private void MainWindow_Closed(object sender, EventArgs e)
		{
			\u0019\u0013\u0019.\u000A(true);
			\u0004\u001A\u0019.\u000A(\u0019\u001A\u0019.\u000A());
			\u0007\u001A\u0019.\u000A(\u001D\u001A\u0019.\u000A());
			\u000B\u0012.\u001D();
			\u000D\u0011\u0019.\u000A(\u000D\u0018\u000E.\u001F);
		}

		// Token: 0x06000F23 RID: 3875 RVA: 0x00060F8C File Offset: 0x0005F18C
		private void PanelWindow_OnInitialized(object sender, EventArgs e)
		{
			\u0018\u001A\u0019.\u000A(\u0010\u0014\u0019.\u0007(this.RH), this);
		}

		// Token: 0x06000F24 RID: 3876 RVA: 0x00060FAC File Offset: 0x0005F1AC
		protected override void ApplyLicense(bool isLicenseValid)
		{
			\u0015\u0009\u000A.\u000A(this.YH, isLicenseValid);
		}

		// Token: 0x06000F25 RID: 3877 RVA: 0x00060FC8 File Offset: 0x0005F1C8
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/panellink/ui/windows/panelwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06000F26 RID: 3878 RVA: 0x00061010 File Offset: 0x0005F210
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06000F27 RID: 3879 RVA: 0x00061028 File Offset: 0x0005F228
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0016\u0015\u0007.\u0007(\u0009\u0005\u000E.\u001F(R), new EventHandler(this.MainWindow_Closed));
				\u0005\u001A\u0019.\u000A(\u0009\u0005\u000E.\u001F(R), new EventHandler(this.PanelWindow_OnInitialized));
				return;
			case 2:
				this.RH = \u001F\u0016\u000E.\u001F(R);
				return;
			case 3:
				this.DH = \u000A\u0016\u000E.\u001F(R);
				return;
			case 4:
				this.KR = \u001A\u000A\u000E.\u001F(R);
				return;
			case 5:
				this.HH = \u001E\u0001\u0010.\u001F(R);
				return;
			case 6:
				this.YH = \u001E\u0001\u0010.\u001F(R);
				return;
			case 7:
				this.CH = \u001B\u0001\u0010.\u001F(R);
				return;
			case 8:
				this.LH = \u001E\u0001\u0010.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x040005EF RID: 1519
		internal CustomProgressBar RH;

		// Token: 0x040005F0 RID: 1520
		internal PanelControl DH;

		// Token: 0x040005F1 RID: 1521
		internal Label KR;

		// Token: 0x040005F2 RID: 1522
		internal Button HH;

		// Token: 0x040005F3 RID: 1523
		internal Button YH;

		// Token: 0x040005F4 RID: 1524
		internal TextBlock CH;

		// Token: 0x040005F5 RID: 1525
		internal Button LH;

		// Token: 0x040005F6 RID: 1526
		private bool R;
	}
}

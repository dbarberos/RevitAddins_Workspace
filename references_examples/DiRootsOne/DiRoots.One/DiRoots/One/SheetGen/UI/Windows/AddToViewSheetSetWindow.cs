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

namespace DiRoots.One.SheetGen.UI.Windows
{
	// Token: 0x0200038F RID: 911
	public class AddToViewSheetSetWindow : DiRootsWindow, IAddToViewSheetSetWindow, IComponentConnector
	{
		// Token: 0x06002505 RID: 9477 RVA: 0x000E02D0 File Offset: 0x000DE4D0
		public AddToViewSheetSetWindow()
		{
			\u001A\u0009\u000B.\u000A(this);
		}

		// Token: 0x06002506 RID: 9478 RVA: 0x000E02EC File Offset: 0x000DE4EC
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			\u0006\u0015\u0007.\u0007(this, new bool?(false));
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06002507 RID: 9479 RVA: 0x000E030C File Offset: 0x000DE50C
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddToViewSheetSetWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/addtoviewsheetsetwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06002508 RID: 9480 RVA: 0x000E0354 File Offset: 0x000DE554
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.PW = \u000D\u000E\u000E.\u001F(R);
				return;
			case 2:
				this.AC = \u001B\u0001\u0010.\u001F(R);
				return;
			case 3:
				this.GC = \u000B\u000A\u000E.\u001F(R);
				return;
			case 4:
				this.KR = \u001B\u0001\u0010.\u001F(R);
				return;
			case 5:
				this.YL = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.YL, new RoutedEventHandler(this.btnCancel_Click));
				return;
			case 6:
				this.H = \u001E\u0001\u0010.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x06002509 RID: 9481 RVA: 0x000E03FC File Offset: 0x000DE5FC
		object IAddToViewSheetSetWindow.SFR()
		{
			return \u0007\u000C\u000A.\u001D(this);
		}

		// Token: 0x0600250A RID: 9482 RVA: 0x000E0414 File Offset: 0x000DE614
		void IAddToViewSheetSetWindow.BFR(object F)
		{
			\u0017\u001A\u000A.\u0007(this, F);
		}

		// Token: 0x0600250B RID: 9483 RVA: 0x000E0428 File Offset: 0x000DE628
		Window IAddToViewSheetSetWindow.UFR()
		{
			return \u000D\u0011\u0016.\u0007(this);
		}

		// Token: 0x0600250C RID: 9484 RVA: 0x000E0440 File Offset: 0x000DE640
		void IAddToViewSheetSetWindow.WFR(Window F)
		{
			\u000C\u000E\u0007.\u001D(this, F);
		}

		// Token: 0x0600250D RID: 9485 RVA: 0x000E0454 File Offset: 0x000DE654
		bool? IAddToViewSheetSetWindow.KFR()
		{
			return \u0018\u0020\u000A.\u001D(this);
		}

		// Token: 0x04000EA0 RID: 3744
		internal AddToViewSheetSetWindow PW;

		// Token: 0x04000EA1 RID: 3745
		internal TextBlock AC;

		// Token: 0x04000EA2 RID: 3746
		internal ComboBox GC;

		// Token: 0x04000EA3 RID: 3747
		internal TextBlock KR;

		// Token: 0x04000EA4 RID: 3748
		internal Button YL;

		// Token: 0x04000EA5 RID: 3749
		internal Button H;

		// Token: 0x04000EA6 RID: 3750
		private bool R;
	}
}

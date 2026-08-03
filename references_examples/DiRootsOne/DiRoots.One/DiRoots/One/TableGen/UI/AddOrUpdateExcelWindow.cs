using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Navigation;
using A;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.TableGen.ViewModels;
using DiRoots.One.TGDatabaseLayer;

namespace DiRoots.One.TableGen.UI
{
	// Token: 0x02000159 RID: 345
	public class AddOrUpdateExcelWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x06000CD0 RID: 3280 RVA: 0x00050B7C File Offset: 0x0004ED7C
		public AddOrUpdateExcelWindow(List<SelectedExcel> existingTables)
		{
			\u001D\u0019\u0019.\u000A(this);
			\u0017\u001A\u000A.\u0007(this, new AddBulkViewModel(existingTables));
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x00050BA4 File Offset: 0x0004EDA4
		public AddOrUpdateExcelWindow(List<SelectedExcel> existingTables, SelectedExcel selectedExcel)
		{
			\u001D\u0019\u0019.\u000A(this);
			\u0017\u001A\u000A.\u0007(this, new UpdateViewModel(existingTables, selectedExcel));
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x00050BCC File Offset: 0x0004EDCC
		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			\u0004\u0019\u0019.\u000A(\u0019\u0019\u0019.\u000A(\u0018\u0019\u0019.\u000A(e)));
			\u0019\u0013\u000A.\u000A(e, true);
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x00050BF4 File Offset: 0x0004EDF4
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddOrUpdateExcelWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/tablegen/tablegen/ui/windows/addorupdateexcelwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x00050C3C File Offset: 0x0004EE3C
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.VR = \u000B\u000A\u000E.\u001F(R);
				return;
			case 2:
				this.ZR = \u000B\u000A\u000E.\u001F(R);
				return;
			case 3:
				this.XR = \u0001\u000A\u000E.\u001F(R);
				return;
			case 4:
				this.PR = \u000B\u000A\u000E.\u001F(R);
				return;
			case 5:
				this.OR = \u000B\u000A\u000E.\u001F(R);
				return;
			case 6:
				this.TR = \u000B\u000A\u000E.\u001F(R);
				return;
			case 7:
				this.IR = \u0001\u000A\u000E.\u001F(R);
				return;
			case 8:
				this.QR = \u000B\u000A\u000E.\u001F(R);
				return;
			case 9:
				this.AR = \u0001\u000A\u000E.\u001F(R);
				return;
			case 10:
				\u0005\u0019\u0019.\u000A(\u0017\u0018\u000E.\u001F(R), new RequestNavigateEventHandler(this.Hyperlink_RequestNavigate));
				return;
			case 11:
				this.GR = \u001E\u0001\u0010.\u001F(R);
				return;
			case 12:
				this.H = \u001E\u0001\u0010.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x0400050B RID: 1291
		internal ComboBox VR;

		// Token: 0x0400050C RID: 1292
		internal ComboBox ZR;

		// Token: 0x0400050D RID: 1293
		internal TextBox XR;

		// Token: 0x0400050E RID: 1294
		internal ComboBox PR;

		// Token: 0x0400050F RID: 1295
		internal ComboBox OR;

		// Token: 0x04000510 RID: 1296
		internal ComboBox TR;

		// Token: 0x04000511 RID: 1297
		internal TextBox IR;

		// Token: 0x04000512 RID: 1298
		internal ComboBox QR;

		// Token: 0x04000513 RID: 1299
		internal TextBox AR;

		// Token: 0x04000514 RID: 1300
		internal Button GR;

		// Token: 0x04000515 RID: 1301
		internal Button H;

		// Token: 0x04000516 RID: 1302
		private bool R;
	}
}

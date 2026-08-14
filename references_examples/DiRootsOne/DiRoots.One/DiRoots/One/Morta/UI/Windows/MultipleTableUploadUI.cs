using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.Morta.Interfaces;

namespace DiRoots.One.Morta.UI.Windows
{
	// Token: 0x020001B1 RID: 433
	public class MultipleTableUploadUI : BaseUploadWindow, IComponentConnector
	{
		// Token: 0x06001022 RID: 4130 RVA: 0x00066208 File Offset: 0x00064408
		internal MultipleTableUploadUI(\u0013\u0006 F, IDataFactory R)
		{
			\u001D\u001D\u0018.\u000A(this);
			\u0008\u000E\u001D.\u000A(\u0009\u0007\u0018.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\UI\\Windows\\MultipleTableUploadUI.xaml.cs", ".ctor");
			S s = new S(F, R);
			\u000A\u000C\u0007.\u0007(s, this);
			S u000A = s;
			\u0017\u001A\u000A.\u0007(this, u000A);
			\u0005\u000E\u001D.\u000A(\u0009\u0007\u0018.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\UI\\Windows\\MultipleTableUploadUI.xaml.cs", ".ctor");
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x00066268 File Offset: 0x00064468
		private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
		{
			\u0004\u001D\u0018.\u000A(this, sender, e);
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x00066280 File Offset: 0x00064480
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MultipleTableUploadUI.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/morta/ui/windows/multipletableuploadui.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001025 RID: 4133 RVA: 0x000662C8 File Offset: 0x000644C8
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06001026 RID: 4134 RVA: 0x000662E0 File Offset: 0x000644E0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.WH = \u0014\u0001\u0010.\u001F(R);
				return;
			case 2:
				this.KH = \u0005\u0009\u0010.\u001F(R);
				return;
			case 3:
				this.JH = \u0005\u0009\u0010.\u001F(R);
				return;
			case 4:
				this.EH = \u0007\u0016\u000E.\u001F(R);
				return;
			case 5:
				\u001F\u001F\u0007.\u000A(\u0020\u0001\u0010.\u001F(R), new DataGridSortingEventHandler(this.DataGrid_Sorting));
				return;
			case 6:
				this.NH = \u000B\u000A\u000E.\u001F(R);
				return;
			case 7:
				this.MH = \u001E\u0001\u0010.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x0400066B RID: 1643
		internal Grid WH;

		// Token: 0x0400066C RID: 1644
		internal WatermarkTextBox KH;

		// Token: 0x0400066D RID: 1645
		internal WatermarkTextBox JH;

		// Token: 0x0400066E RID: 1646
		internal ListBox EH;

		// Token: 0x0400066F RID: 1647
		internal ComboBox NH;

		// Token: 0x04000670 RID: 1648
		internal Button MH;

		// Token: 0x04000671 RID: 1649
		private bool R;
	}
}

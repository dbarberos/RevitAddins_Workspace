using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.Morta.Interfaces;
using DiRoots.One.Morta.ViewModel;

namespace DiRoots.One.Morta.UI.Windows
{
	// Token: 0x020001B2 RID: 434
	public class SingleTableUploadUI : BaseUploadWindow, IComponentConnector
	{
		// Token: 0x06001027 RID: 4135 RVA: 0x00066390 File Offset: 0x00064590
		internal SingleTableUploadUI(\u0013\u0006 F, IDataFactory R, bool D)
		{
			\u0019\u001D\u0018.\u000A(this);
			\u0008\u000E\u001D.\u000A(\u0009\u0007\u0018.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\UI\\Windows\\SingleTableUploadUI.xaml.cs", ".ctor");
			SingleTableUploadViewModel u000A;
			if (D)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SingleTableUploadUI..ctor(\u0013\u0006, IDataFactory, bool)).MethodHandle;
				}
				SingleTableUploadViewModel singleTableUploadViewModel = new SingleTableUploadViewModel(F, R);
				\u000A\u000C\u0007.\u0007(singleTableUploadViewModel, this);
				u000A = singleTableUploadViewModel;
			}
			else
			{
				ImportTableViewModel importTableViewModel = new ImportTableViewModel(F, R);
				\u000A\u000C\u0007.\u0007(importTableViewModel, this);
				u000A = importTableViewModel;
			}
			\u0017\u001A\u000A.\u0007(this, u000A);
			\u0005\u000E\u001D.\u000A(\u0009\u0007\u0018.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\UI\\Windows\\SingleTableUploadUI.xaml.cs", ".ctor");
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x00066414 File Offset: 0x00064614
		private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
		{
			\u0004\u001D\u0018.\u000A(this, sender, e);
		}

		// Token: 0x06001029 RID: 4137 RVA: 0x0006642C File Offset: 0x0006462C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
			{
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SingleTableUploadUI.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/morta/ui/windows/singletableuploadui.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x0600102A RID: 4138 RVA: 0x00066474 File Offset: 0x00064674
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x0600102B RID: 4139 RVA: 0x0006648C File Offset: 0x0006468C
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
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x04000672 RID: 1650
		internal Grid WH;

		// Token: 0x04000673 RID: 1651
		internal WatermarkTextBox KH;

		// Token: 0x04000674 RID: 1652
		internal WatermarkTextBox JH;

		// Token: 0x04000675 RID: 1653
		internal ListBox EH;

		// Token: 0x04000676 RID: 1654
		internal ComboBox NH;

		// Token: 0x04000677 RID: 1655
		private bool R;
	}
}

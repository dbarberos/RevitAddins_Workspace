using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using DiRoots.ProSheets.ViewModels;
using ProSheets.Models;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x02000043 RID: 67
	public partial class UI_OrderPdf : DiRootsWindow
	{
		// Token: 0x060002C6 RID: 710 RVA: 0x000101CC File Offset: 0x0000E3CC
		public UI_OrderPdf(OrderBaseModel<SheetInfo> viewModel)
		{
			\u0016\u0009\u0014.\u0018(this);
			DataGridSelectionBehavior<SheetInfo> dataGridSelectionBehavior = new DataGridSelectionBehavior<SheetInfo>();
			\u0007\u0001\u0018.\u0018(dataGridSelectionBehavior, DataGridSelectionBehavior<SheetInfo>.SelectedItemsProperty, new Binding("SelectedItems"));
			\u000B\u0001\u0018.\u0018(\u0019\u0001\u0018.\u0018(this.AQ), dataGridSelectionBehavior);
			\u000B\u0005\u0018.\u0014(viewModel, this);
			\u001C\u000B\u0018.\u0003(this, viewModel);
			\u0018\u0009\u0014.\u0018(this.DQ, \u001C\u001E\u0018.\u0018(\u000D\u0009\u0018.\u0001\u0014, \u0014\u0009\u0014.\u0018(\u0003\u0009\u0014.\u0018(viewModel))));
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0001029C File Offset: 0x0000E49C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		internal Delegate TN(Type P, string Q)
		{
			return \u000E\u000B\u0018.\u0018(P, this, Q);
		}
	}
}

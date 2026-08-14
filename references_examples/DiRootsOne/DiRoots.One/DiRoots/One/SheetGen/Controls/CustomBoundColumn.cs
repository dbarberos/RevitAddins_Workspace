using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using A;

namespace DiRoots.One.SheetGen.Controls
{
	// Token: 0x020003BE RID: 958
	public class CustomBoundColumn : DataGridBoundColumn
	{
		// Token: 0x17000A7F RID: 2687
		// (get) Token: 0x06002600 RID: 9728 RVA: 0x000E4A08 File Offset: 0x000E2C08
		// (set) Token: 0x06002601 RID: 9729 RVA: 0x000E4A1C File Offset: 0x000E2C1C
		public string TemplateName { get; set; }

		// Token: 0x17000A80 RID: 2688
		// (get) Token: 0x06002602 RID: 9730 RVA: 0x000E4A30 File Offset: 0x000E2C30
		// (set) Token: 0x06002603 RID: 9731 RVA: 0x000E4A44 File Offset: 0x000E2C44
		public string CellStyleName { get; set; }

		// Token: 0x17000A81 RID: 2689
		// (get) Token: 0x06002604 RID: 9732 RVA: 0x000E4A58 File Offset: 0x000E2C58
		// (set) Token: 0x06002605 RID: 9733 RVA: 0x000E4A6C File Offset: 0x000E2C6C
		public int ColumnIndex { get; internal set; }

		// Token: 0x06002606 RID: 9734 RVA: 0x000E4A80 File Offset: 0x000E2C80
		protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
		{
			int num = \u0001\u0007\u0018.\u000A(\u0012\u001D\u0002.\u000A(cell)) - 3;
			Binding binding = \u0004\u0017\u0016.\u000A(\u000E\u000C\u0007.\u0007(\u0008\u000C\u0007.\u000A(\u000E\u000A\u000E.\u001F(\u000F\u001D\u0002.\u000A(this)))));
			\u0006\u001D\u0002.\u000A(binding, dataItem);
			Binding u = binding;
			ContentControl contentControl = \u0002\u001D\u0002.\u000A();
			\u0016\u001D\u0002.\u000A(contentControl, \u000F\u000E\u000E.\u001F(\u0009\u0018\u0005.\u001D(cell, \u000B\u001D\u0002.\u000A(this))));
			\u0005\u001D\u0002.\u0007(this, \u0007\u001B\u000E.\u001F(\u0009\u0018\u0005.\u001D(cell, "ViewCellStyle")));
			\u0019\u0015\u000A.\u001D(contentControl, FrameworkElement.TagProperty, num);
			\u0018\u001D\u0002.\u000A(contentControl, ContentControl.ContentProperty, u);
			return contentControl;
		}

		// Token: 0x06002607 RID: 9735 RVA: 0x000E4B2C File Offset: 0x000E2D2C
		protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
		{
			return \u0003\u001D\u0002.\u000A(this, cell, dataItem);
		}

		// Token: 0x04000F1F RID: 3871
		[CompilerGenerated]
		private string \u001F;

		// Token: 0x04000F20 RID: 3872
		[CompilerGenerated]
		private string \u000A;

		// Token: 0x04000F21 RID: 3873
		[CompilerGenerated]
		private int \u0007;
	}
}

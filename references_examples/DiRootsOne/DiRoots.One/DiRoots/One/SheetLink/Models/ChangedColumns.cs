using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000242 RID: 578
	public class ChangedColumns
	{
		// Token: 0x1700064E RID: 1614
		// (get) Token: 0x0600170D RID: 5901 RVA: 0x00096EB8 File Offset: 0x000950B8
		// (set) Token: 0x0600170C RID: 5900 RVA: 0x00096EA4 File Offset: 0x000950A4
		public string ColumnName { get; set; }

		// Token: 0x1700064F RID: 1615
		// (get) Token: 0x0600170F RID: 5903 RVA: 0x00096EE0 File Offset: 0x000950E0
		// (set) Token: 0x0600170E RID: 5902 RVA: 0x00096ECC File Offset: 0x000950CC
		public string Value { get; set; }

		// Token: 0x17000650 RID: 1616
		// (get) Token: 0x06001711 RID: 5905 RVA: 0x00096F08 File Offset: 0x00095108
		// (set) Token: 0x06001710 RID: 5904 RVA: 0x00096EF4 File Offset: 0x000950F4
		public string CurrentValue { get; set; }

		// Token: 0x17000651 RID: 1617
		// (get) Token: 0x06001713 RID: 5907 RVA: 0x00096F30 File Offset: 0x00095130
		// (set) Token: 0x06001712 RID: 5906 RVA: 0x00096F1C File Offset: 0x0009511C
		public Parameter Param { get; set; }

		// Token: 0x17000652 RID: 1618
		// (get) Token: 0x06001715 RID: 5909 RVA: 0x00096F58 File Offset: 0x00095158
		// (set) Token: 0x06001714 RID: 5908 RVA: 0x00096F44 File Offset: 0x00095144
		public string CellNumber { get; set; }

		// Token: 0x17000653 RID: 1619
		// (get) Token: 0x06001717 RID: 5911 RVA: 0x00096F80 File Offset: 0x00095180
		// (set) Token: 0x06001716 RID: 5910 RVA: 0x00096F6C File Offset: 0x0009516C
		public bool IsType { get; set; }

		// Token: 0x17000654 RID: 1620
		// (get) Token: 0x06001719 RID: 5913 RVA: 0x00096FA8 File Offset: 0x000951A8
		// (set) Token: 0x06001718 RID: 5912 RVA: 0x00096F94 File Offset: 0x00095194
		public long ElementId { get; set; }

		// Token: 0x04000918 RID: 2328
		[CompilerGenerated]
		private string \u001F;

		// Token: 0x04000919 RID: 2329
		[CompilerGenerated]
		private string \u000A;

		// Token: 0x0400091A RID: 2330
		[CompilerGenerated]
		private string \u0007;

		// Token: 0x0400091B RID: 2331
		[CompilerGenerated]
		private Parameter \u001D;

		// Token: 0x0400091C RID: 2332
		[CompilerGenerated]
		private string \u0004;

		// Token: 0x0400091D RID: 2333
		[CompilerGenerated]
		private bool \u0019;

		// Token: 0x0400091E RID: 2334
		[CompilerGenerated]
		private long \u0018;
	}
}

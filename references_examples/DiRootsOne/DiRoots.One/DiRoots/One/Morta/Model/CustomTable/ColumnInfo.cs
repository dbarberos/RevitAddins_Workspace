using System;
using System.Runtime.CompilerServices;
using System.Text;
using A;
using DiRoots.One.SheetLink.Models;

namespace DiRoots.One.Morta.Model.CustomTable
{
	// Token: 0x020001BD RID: 445
	public class ColumnInfo
	{
		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x0600109A RID: 4250 RVA: 0x00068CB4 File Offset: 0x00066EB4
		// (set) Token: 0x0600109B RID: 4251 RVA: 0x00068CC8 File Offset: 0x00066EC8
		public string Name { get; set; }

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x0600109C RID: 4252 RVA: 0x00068CDC File Offset: 0x00066EDC
		// (set) Token: 0x0600109D RID: 4253 RVA: 0x00068CF0 File Offset: 0x00066EF0
		public string ParameterName { get; set; }

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x0600109E RID: 4254 RVA: 0x00068D04 File Offset: 0x00066F04
		// (set) Token: 0x0600109F RID: 4255 RVA: 0x00068D18 File Offset: 0x00066F18
		public string DataType { get; set; } = "text";

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x060010A0 RID: 4256 RVA: 0x00068D2C File Offset: 0x00066F2C
		// (set) Token: 0x060010A1 RID: 4257 RVA: 0x00068D40 File Offset: 0x00066F40
		public string Description { get; set; }

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x060010A2 RID: 4258 RVA: 0x00068D54 File Offset: 0x00066F54
		// (set) Token: 0x060010A3 RID: 4259 RVA: 0x00068D68 File Offset: 0x00066F68
		public int Width { get; set; } = 100;

		// Token: 0x060010A4 RID: 4260 RVA: 0x00068D7C File Offset: 0x00066F7C
		internal static string \u0019(ParamExportInfo \u001F)
		{
			StringBuilder u001F = \u001A\u0013\u0007.\u000A();
			\u001A\u0016\u0019.\u000A(u001F, "THIS CODE MAPS THE COLUMN IN THIS TABLE TO REVIT'S SCHEDULE, PLEASE ** DO NOT CHANGE **");
			\u0015\u0016\u0019.\u000A(u001F);
			\u0015\u0016\u0019.\u000A(u001F);
			\u001A\u0016\u0019.\u000A(u001F, \u0019\u0005\u0018.\u000A(\u001F));
			\u0015\u0016\u0019.\u000A(u001F);
			\u0015\u0016\u0019.\u000A(u001F);
			\u001A\u0016\u0019.\u000A(u001F, "PLEASE ADD YOUR CUSTOM DESCRIPTION BELOW THIS LINE");
			return \u001A\u000C\u000A.\u000A(u001F);
		}

		// Token: 0x04000690 RID: 1680
		[CompilerGenerated]
		private string \u001F;

		// Token: 0x04000691 RID: 1681
		[CompilerGenerated]
		private string \u000A;

		// Token: 0x04000692 RID: 1682
		[CompilerGenerated]
		private string \u0007;

		// Token: 0x04000693 RID: 1683
		[CompilerGenerated]
		private string \u001D;

		// Token: 0x04000694 RID: 1684
		[CompilerGenerated]
		private int \u0004;
	}
}

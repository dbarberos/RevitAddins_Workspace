using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.SheetLink.Enums;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x0200024B RID: 587
	public class ParamValueInfo
	{
		// Token: 0x17000682 RID: 1666
		// (get) Token: 0x0600179C RID: 6044 RVA: 0x0009A6E4 File Offset: 0x000988E4
		// (set) Token: 0x0600179D RID: 6045 RVA: 0x0009A6F8 File Offset: 0x000988F8
		public int GroupIndex { get; set; }

		// Token: 0x17000683 RID: 1667
		// (get) Token: 0x0600179E RID: 6046 RVA: 0x0009A70C File Offset: 0x0009890C
		// (set) Token: 0x0600179F RID: 6047 RVA: 0x0009A720 File Offset: 0x00098920
		public int ColumnIndex { get; set; }

		// Token: 0x17000684 RID: 1668
		// (get) Token: 0x060017A0 RID: 6048 RVA: 0x0009A734 File Offset: 0x00098934
		// (set) Token: 0x060017A1 RID: 6049 RVA: 0x0009A748 File Offset: 0x00098948
		public int StartRow { get; set; }

		// Token: 0x17000685 RID: 1669
		// (get) Token: 0x060017A2 RID: 6050 RVA: 0x0009A75C File Offset: 0x0009895C
		// (set) Token: 0x060017A3 RID: 6051 RVA: 0x0009A770 File Offset: 0x00098970
		public int Rows { get; set; }

		// Token: 0x17000686 RID: 1670
		// (get) Token: 0x060017A4 RID: 6052 RVA: 0x0009A784 File Offset: 0x00098984
		// (set) Token: 0x060017A5 RID: 6053 RVA: 0x0009A798 File Offset: 0x00098998
		public int ExcelSheetIndex { get; set; }

		// Token: 0x17000687 RID: 1671
		// (get) Token: 0x060017A6 RID: 6054 RVA: 0x0009A7AC File Offset: 0x000989AC
		// (set) Token: 0x060017A7 RID: 6055 RVA: 0x0009A7C0 File Offset: 0x000989C0
		public string SheetName { get; set; }

		// Token: 0x17000688 RID: 1672
		// (get) Token: 0x060017A8 RID: 6056 RVA: 0x0009A7D4 File Offset: 0x000989D4
		// (set) Token: 0x060017A9 RID: 6057 RVA: 0x0009A7E8 File Offset: 0x000989E8
		public long ParamValueType { get; set; }

		// Token: 0x17000689 RID: 1673
		// (get) Token: 0x060017AA RID: 6058 RVA: 0x0009A7FC File Offset: 0x000989FC
		// (set) Token: 0x060017AB RID: 6059 RVA: 0x0009A810 File Offset: 0x00098A10
		public BuiltInCategory ValueCategory { get; set; }

		// Token: 0x1700068A RID: 1674
		// (get) Token: 0x060017AC RID: 6060 RVA: 0x0009A824 File Offset: 0x00098A24
		// (set) Token: 0x060017AD RID: 6061 RVA: 0x0009A838 File Offset: 0x00098A38
		public bool IsOptional { get; set; }

		// Token: 0x1700068B RID: 1675
		// (get) Token: 0x060017AE RID: 6062 RVA: 0x0009A84C File Offset: 0x00098A4C
		// (set) Token: 0x060017AF RID: 6063 RVA: 0x0009A860 File Offset: 0x00098A60
		public bool IsType { get; set; }

		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x060017B0 RID: 6064 RVA: 0x0009A874 File Offset: 0x00098A74
		// (set) Token: 0x060017B1 RID: 6065 RVA: 0x0009A888 File Offset: 0x00098A88
		public bool IsKeyParam { get; set; }

		// Token: 0x1700068D RID: 1677
		// (get) Token: 0x060017B2 RID: 6066 RVA: 0x0009A89C File Offset: 0x00098A9C
		// (set) Token: 0x060017B3 RID: 6067 RVA: 0x0009A8B0 File Offset: 0x00098AB0
		public ExcelParamTypes ExcelParamType { get; set; }

		// Token: 0x1700068E RID: 1678
		// (get) Token: 0x060017B4 RID: 6068 RVA: 0x0009A8C4 File Offset: 0x00098AC4
		// (set) Token: 0x060017B5 RID: 6069 RVA: 0x0009A8D8 File Offset: 0x00098AD8
		public string Error { get; set; }

		// Token: 0x1700068F RID: 1679
		// (get) Token: 0x060017B6 RID: 6070 RVA: 0x0009A8EC File Offset: 0x00098AEC
		// (set) Token: 0x060017B7 RID: 6071 RVA: 0x0009A900 File Offset: 0x00098B00
		public ExcelNamedRange NamedRange { get; set; }

		// Token: 0x0400094C RID: 2380
		[CompilerGenerated]
		private int \u001F;

		// Token: 0x0400094D RID: 2381
		[CompilerGenerated]
		private int \u000A;

		// Token: 0x0400094E RID: 2382
		[CompilerGenerated]
		private int \u0007;

		// Token: 0x0400094F RID: 2383
		[CompilerGenerated]
		private int \u001D;

		// Token: 0x04000950 RID: 2384
		[CompilerGenerated]
		private int \u0004;

		// Token: 0x04000951 RID: 2385
		[CompilerGenerated]
		private string \u0019;

		// Token: 0x04000952 RID: 2386
		[CompilerGenerated]
		private long \u0018;

		// Token: 0x04000953 RID: 2387
		[CompilerGenerated]
		private BuiltInCategory \u0005;

		// Token: 0x04000954 RID: 2388
		[CompilerGenerated]
		private bool \u0016;

		// Token: 0x04000955 RID: 2389
		[CompilerGenerated]
		private bool \u000B;

		// Token: 0x04000956 RID: 2390
		[CompilerGenerated]
		private bool \u0002;

		// Token: 0x04000957 RID: 2391
		[CompilerGenerated]
		private ExcelParamTypes \u0006;

		// Token: 0x04000958 RID: 2392
		[CompilerGenerated]
		private string \u000F;

		// Token: 0x04000959 RID: 2393
		[CompilerGenerated]
		private ExcelNamedRange \u0012;
	}
}

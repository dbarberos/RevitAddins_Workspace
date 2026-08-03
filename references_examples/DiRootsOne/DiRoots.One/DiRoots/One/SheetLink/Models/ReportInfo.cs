using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using A;
using DiRoots.One.Commons.Attributes;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x0200024F RID: 591
	public class ReportInfo : Report
	{
		// Token: 0x06001800 RID: 6144 RVA: 0x0009BDF8 File Offset: 0x00099FF8
		public ReportInfo()
		{
		}

		// Token: 0x06001801 RID: 6145 RVA: 0x0009BE0C File Offset: 0x0009A00C
		public ReportInfo(string sheetName, string elementId)
		{
			\u0006\u0020\u0005.\u0007(this, sheetName);
			\u0002\u0020\u0005.\u000A(this, "");
			\u0012\u0006\u0018.\u001D(this, "");
			\u0020\u0010\u0005.\u001D(this, \u001A\u000C\u000A.\u000A(elementId));
			\u000B\u0020\u0005.\u0007(this, "");
			\u0016\u0020\u0005.\u0007(this, "");
			\u0008\u0012\u0018.\u001D(this, "");
			\u0014\u0010\u0005.\u001D(this, "");
			\u0020\u0014\u0007.\u000A(this, ReportStates.Error);
		}

		// Token: 0x06001802 RID: 6146 RVA: 0x0009BE80 File Offset: 0x0009A080
		public ReportInfo(string sheetName, string elementId, ChangedColumns ChangedColumn)
		{
			\u0006\u0020\u0005.\u0007(this, sheetName);
			\u0002\u0020\u0005.\u000A(this, \u0012\u0020\u0005.\u000A(ChangedColumn));
			\u0012\u0006\u0018.\u001D(this, "");
			\u0020\u0010\u0005.\u001D(this, \u001A\u000C\u000A.\u000A(elementId));
			\u000B\u0020\u0005.\u0007(this, \u0017\u0006\u0018.\u000A(ChangedColumn));
			\u0016\u0020\u0005.\u0007(this, \u0008\u000B\u0005.\u000A(ChangedColumn));
			\u0008\u0012\u0018.\u001D(this, \u000F\u0020\u0005.\u000A(ChangedColumn));
			\u0020\u0014\u0007.\u000A(this, ReportStates.Error);
			if (\u0014\u0006\u0018.\u000A(ChangedColumn) != null)
			{
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReportInfo..ctor(string, string, ChangedColumns)).MethodHandle;
				}
				long num = \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u0014\u0006\u0018.\u000A(ChangedColumn)));
				\u0014\u0010\u0005.\u001D(this, \u0011\u0013\u000A.\u000A(ref num));
			}
		}

		// Token: 0x170006A8 RID: 1704
		// (get) Token: 0x06001803 RID: 6147 RVA: 0x0009BF38 File Offset: 0x0009A138
		// (set) Token: 0x06001804 RID: 6148 RVA: 0x0009BF4C File Offset: 0x0009A14C
		public string ParamId { get; set; }

		// Token: 0x170006A9 RID: 1705
		// (get) Token: 0x06001805 RID: 6149 RVA: 0x0009BF60 File Offset: 0x0009A160
		// (set) Token: 0x06001806 RID: 6150 RVA: 0x0009BF74 File Offset: 0x0009A174
		public int RowIndex { get; set; }

		// Token: 0x170006AA RID: 1706
		// (get) Token: 0x06001808 RID: 6152 RVA: 0x0009BF9C File Offset: 0x0009A19C
		// (set) Token: 0x06001807 RID: 6151 RVA: 0x0009BF88 File Offset: 0x0009A188
		[Report("Report-Description", 1.5, DataGridLengthUnitType.Star, false, false)]
		public string Description { get; set; }

		// Token: 0x170006AB RID: 1707
		// (get) Token: 0x0600180A RID: 6154 RVA: 0x0009BFC4 File Offset: 0x0009A1C4
		// (set) Token: 0x06001809 RID: 6153 RVA: 0x0009BFB0 File Offset: 0x0009A1B0
		[Report("Report-SheetName", 1.0, DataGridLengthUnitType.Star, false, false)]
		public string SheetName { get; set; }

		// Token: 0x170006AC RID: 1708
		// (get) Token: 0x0600180C RID: 6156 RVA: 0x0009BFEC File Offset: 0x0009A1EC
		// (set) Token: 0x0600180B RID: 6155 RVA: 0x0009BFD8 File Offset: 0x0009A1D8
		[Report("Report-CellNumber", 80.0, DataGridLengthUnitType.Pixel, false, false)]
		public string CellNumber { get; set; }

		// Token: 0x170006AD RID: 1709
		// (get) Token: 0x0600180E RID: 6158 RVA: 0x0009C014 File Offset: 0x0009A214
		// (set) Token: 0x0600180D RID: 6157 RVA: 0x0009C000 File Offset: 0x0009A200
		[Report("Report-ElementId", 80.0, DataGridLengthUnitType.Pixel, false, false)]
		public string ElementId { get; set; }

		// Token: 0x170006AE RID: 1710
		// (get) Token: 0x06001810 RID: 6160 RVA: 0x0009C03C File Offset: 0x0009A23C
		// (set) Token: 0x0600180F RID: 6159 RVA: 0x0009C028 File Offset: 0x0009A228
		[Report("Report-RevitProperty", 0.6, DataGridLengthUnitType.Star, false, false)]
		public string RevitProperty { get; set; }

		// Token: 0x170006AF RID: 1711
		// (get) Token: 0x06001812 RID: 6162 RVA: 0x0009C064 File Offset: 0x0009A264
		// (set) Token: 0x06001811 RID: 6161 RVA: 0x0009C050 File Offset: 0x0009A250
		[Report("Report-CurrentValue", 0.6, DataGridLengthUnitType.Star, false, false)]
		public string CurrentValue { get; set; }

		// Token: 0x170006B0 RID: 1712
		// (get) Token: 0x06001814 RID: 6164 RVA: 0x0009C08C File Offset: 0x0009A28C
		// (set) Token: 0x06001813 RID: 6163 RVA: 0x0009C078 File Offset: 0x0009A278
		[Report("Report-NewValue", 0.6, DataGridLengthUnitType.Star, false, false)]
		public string NewValue { get; set; }

		// Token: 0x04000973 RID: 2419
		[CompilerGenerated]
		private string SC;

		// Token: 0x04000974 RID: 2420
		[CompilerGenerated]
		private int BC;

		// Token: 0x04000975 RID: 2421
		[CompilerGenerated]
		private string CR;

		// Token: 0x04000976 RID: 2422
		[CompilerGenerated]
		private string SY;

		// Token: 0x04000977 RID: 2423
		[CompilerGenerated]
		private string UC;

		// Token: 0x04000978 RID: 2424
		[CompilerGenerated]
		private string WC;

		// Token: 0x04000979 RID: 2425
		[CompilerGenerated]
		private string KC;

		// Token: 0x0400097A RID: 2426
		[CompilerGenerated]
		private string JC;

		// Token: 0x0400097B RID: 2427
		[CompilerGenerated]
		private string EC;
	}
}

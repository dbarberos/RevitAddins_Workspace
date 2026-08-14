using System;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.SheetLink.Core.Enums;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x0200023F RID: 575
	public class ExportOption : IExportOption
	{
		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x060016DD RID: 5853 RVA: 0x0009687C File Offset: 0x00094A7C
		// (set) Token: 0x060016DE RID: 5854 RVA: 0x00096890 File Offset: 0x00094A90
		public bool KeepFormatting { get; set; }

		// Token: 0x17000639 RID: 1593
		// (get) Token: 0x060016DF RID: 5855 RVA: 0x000968A4 File Offset: 0x00094AA4
		// (set) Token: 0x060016E0 RID: 5856 RVA: 0x000968B8 File Offset: 0x00094AB8
		public bool RemoveUnitSymbol { get; set; }

		// Token: 0x1700063A RID: 1594
		// (get) Token: 0x060016E1 RID: 5857 RVA: 0x000968CC File Offset: 0x00094ACC
		// (set) Token: 0x060016E2 RID: 5858 RVA: 0x000968E0 File Offset: 0x00094AE0
		public bool OpenFile { get; set; }

		// Token: 0x1700063B RID: 1595
		// (get) Token: 0x060016E3 RID: 5859 RVA: 0x000968F4 File Offset: 0x00094AF4
		// (set) Token: 0x060016E4 RID: 5860 RVA: 0x00096908 File Offset: 0x00094B08
		public bool IsExportProjectStandards { get; set; }

		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x060016E5 RID: 5861 RVA: 0x0009691C File Offset: 0x00094B1C
		public bool ToExcel
		{
			get
			{
				return \u0020\u000C\u0018.\u001D(this) == ExportOutputTypes.Excel;
			}
		}

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x060016E6 RID: 5862 RVA: 0x00096934 File Offset: 0x00094B34
		// (set) Token: 0x060016E7 RID: 5863 RVA: 0x00096948 File Offset: 0x00094B48
		public ExportOutputTypes ExportOutputType { get; set; }

		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x060016E8 RID: 5864 RVA: 0x0009695C File Offset: 0x00094B5C
		// (set) Token: 0x060016E9 RID: 5865 RVA: 0x00096970 File Offset: 0x00094B70
		public string FileName { get; set; }

		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x060016EA RID: 5866 RVA: 0x00096984 File Offset: 0x00094B84
		// (set) Token: 0x060016EB RID: 5867 RVA: 0x00096998 File Offset: 0x00094B98
		public string FilePath { get; set; } = "";

		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x060016EC RID: 5868 RVA: 0x000969AC File Offset: 0x00094BAC
		// (set) Token: 0x060016ED RID: 5869 RVA: 0x000969C0 File Offset: 0x00094BC0
		public bool ExportByType { get; set; }

		// Token: 0x04000903 RID: 2307
		[CompilerGenerated]
		private bool \u001F;

		// Token: 0x04000904 RID: 2308
		[CompilerGenerated]
		private bool \u000A;

		// Token: 0x04000905 RID: 2309
		[CompilerGenerated]
		private bool \u0007;

		// Token: 0x04000906 RID: 2310
		[CompilerGenerated]
		private bool \u001D;

		// Token: 0x04000907 RID: 2311
		[CompilerGenerated]
		private ExportOutputTypes \u0004;

		// Token: 0x04000908 RID: 2312
		[CompilerGenerated]
		private string \u0019;

		// Token: 0x04000909 RID: 2313
		[CompilerGenerated]
		private string \u0018;

		// Token: 0x0400090A RID: 2314
		[CompilerGenerated]
		private bool \u0005;
	}
}

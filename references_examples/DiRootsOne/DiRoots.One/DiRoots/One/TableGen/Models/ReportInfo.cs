using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using A;
using DiRoots.One.Commons.Attributes;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.TGDatabaseLayer;

namespace DiRoots.One.TableGen.Models
{
	// Token: 0x02000182 RID: 386
	public class ReportInfo : Report
	{
		// Token: 0x06000E5C RID: 3676 RVA: 0x0005BC34 File Offset: 0x00059E34
		public ReportInfo()
		{
		}

		// Token: 0x06000E5D RID: 3677 RVA: 0x0005BC48 File Offset: 0x00059E48
		public ReportInfo(SelectedExcel excel, string message)
		{
			\u001C\u000E\u0019.\u000A(this, \u0014\u0005\u0004.\u0007(excel));
			\u0003\u000E\u0019.\u000A(this, \u000B\u0011\u001D.\u000A(\u0006\u0020\u001D.\u0007(excel)));
			\u0012\u000E\u0019.\u000A(this, \u0011\u0020\u001D.\u0007(excel));
			\u000F\u000E\u0019.\u000A(this, message);
			\u0020\u0014\u0007.\u000A(this, ReportStates.Error);
		}

		// Token: 0x06000E5E RID: 3678 RVA: 0x0005BC9C File Offset: 0x00059E9C
		public ReportInfo(SelectedExcel excel, string message, string filePath) : this(excel, message)
		{
			\u0012\u000E\u0019.\u000A(this, filePath);
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x06000E60 RID: 3680 RVA: 0x0005BCCC File Offset: 0x00059ECC
		// (set) Token: 0x06000E5F RID: 3679 RVA: 0x0005BCB8 File Offset: 0x00059EB8
		[Report("TG-ViewName", 135.0, DataGridLengthUnitType.Pixel, false, false)]
		public string WorkSheet { get; set; }

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x06000E62 RID: 3682 RVA: 0x0005BCF4 File Offset: 0x00059EF4
		// (set) Token: 0x06000E61 RID: 3681 RVA: 0x0005BCE0 File Offset: 0x00059EE0
		[Report("Report-ViewType", 120.0, DataGridLengthUnitType.Pixel, false, false)]
		public string ViewType { get; set; }

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x06000E64 RID: 3684 RVA: 0x0005BD1C File Offset: 0x00059F1C
		// (set) Token: 0x06000E63 RID: 3683 RVA: 0x0005BD08 File Offset: 0x00059F08
		[Report("Report-Location", 1.0, DataGridLengthUnitType.Star, false, false)]
		public string Location { get; set; }

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06000E66 RID: 3686 RVA: 0x0005BD44 File Offset: 0x00059F44
		// (set) Token: 0x06000E65 RID: 3685 RVA: 0x0005BD30 File Offset: 0x00059F30
		[Report("Report-Message", 0.8, DataGridLengthUnitType.Star, false, false, WrapText = true)]
		public string Message { get; set; }

		// Token: 0x040005AB RID: 1451
		[CompilerGenerated]
		private string WH;

		// Token: 0x040005AC RID: 1452
		[CompilerGenerated]
		private string M;

		// Token: 0x040005AD RID: 1453
		[CompilerGenerated]
		private string KH;

		// Token: 0x040005AE RID: 1454
		[CompilerGenerated]
		private string UH;
	}
}

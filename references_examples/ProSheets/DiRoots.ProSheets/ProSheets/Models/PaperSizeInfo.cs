using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;

namespace ProSheets.Models
{
	// Token: 0x02000102 RID: 258
	public class PaperSizeInfo
	{
		// Token: 0x06000C9B RID: 3227 RVA: 0x0004A498 File Offset: 0x00048698
		public PaperSizeInfo(ExportPaperFormat paperFormat, string displayName, string paperSizeName, string pageSize)
		{
			\u0014\u001D\u0016.\u0018(this, paperFormat);
			\u0018\u001D\u0016.\u0018(this, displayName);
			\u000C\u001D\u0016.\u0018(this, paperSizeName);
			\u000E\u0004\u0016.\u0018(this, pageSize);
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x06000C9C RID: 3228 RVA: 0x0004A4C8 File Offset: 0x000486C8
		// (set) Token: 0x06000C9D RID: 3229 RVA: 0x0004A4DC File Offset: 0x000486DC
		public ExportPaperFormat PaperFormat { get; set; }

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06000C9E RID: 3230 RVA: 0x0004A4F0 File Offset: 0x000486F0
		// (set) Token: 0x06000C9F RID: 3231 RVA: 0x0004A504 File Offset: 0x00048704
		public string DisplayName { get; set; }

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x06000CA0 RID: 3232 RVA: 0x0004A518 File Offset: 0x00048718
		// (set) Token: 0x06000CA1 RID: 3233 RVA: 0x0004A52C File Offset: 0x0004872C
		public string PaperSizeName { get; set; }

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x06000CA2 RID: 3234 RVA: 0x0004A540 File Offset: 0x00048740
		// (set) Token: 0x06000CA3 RID: 3235 RVA: 0x0004A554 File Offset: 0x00048754
		public string PageSize { get; set; }

		// Token: 0x040005C3 RID: 1475
		[CompilerGenerated]
		private ExportPaperFormat \u000C;

		// Token: 0x040005C4 RID: 1476
		[CompilerGenerated]
		private string \u0018;

		// Token: 0x040005C5 RID: 1477
		[CompilerGenerated]
		private string \u0014;

		// Token: 0x040005C6 RID: 1478
		[CompilerGenerated]
		private string \u0003;
	}
}

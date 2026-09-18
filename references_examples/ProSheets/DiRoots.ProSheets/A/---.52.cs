using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProSheets.DrawingRegister.Model;
using ProSheets.Models;

namespace A
{
	// Token: 0x02000129 RID: 297
	internal static class \u0001\u0015\u0018
	{
		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x06000F51 RID: 3921 RVA: 0x00057280 File Offset: 0x00055480
		// (set) Token: 0x06000F52 RID: 3922 RVA: 0x00057294 File Offset: 0x00055494
		public static List<ParameterInformation> ProjectParameter { get; set; }

		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x06000F53 RID: 3923 RVA: 0x000572A8 File Offset: 0x000554A8
		// (set) Token: 0x06000F54 RID: 3924 RVA: 0x000572BC File Offset: 0x000554BC
		public static List<ParameterInformation> SheetParameter { get; set; }

		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x06000F55 RID: 3925 RVA: 0x000572D0 File Offset: 0x000554D0
		// (set) Token: 0x06000F56 RID: 3926 RVA: 0x000572E4 File Offset: 0x000554E4
		public static List<ParameterInformation> LinkedSheetParameter { get; set; } = \u0001\u001A\u0016.\u0018();

		// Token: 0x1700054C RID: 1356
		// (get) Token: 0x06000F57 RID: 3927 RVA: 0x000572F8 File Offset: 0x000554F8
		// (set) Token: 0x06000F58 RID: 3928 RVA: 0x0005730C File Offset: 0x0005550C
		public static List<RevisionInformation> RevisionInformation { get; set; }

		// Token: 0x1700054D RID: 1357
		// (get) Token: 0x06000F59 RID: 3929 RVA: 0x00057320 File Offset: 0x00055520
		// (set) Token: 0x06000F5A RID: 3930 RVA: 0x00057334 File Offset: 0x00055534
		public static List<ParameterInformation> SelectedSheetParameter { get; set; } = \u0001\u001A\u0016.\u0018();

		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x06000F5B RID: 3931 RVA: 0x00057348 File Offset: 0x00055548
		// (set) Token: 0x06000F5C RID: 3932 RVA: 0x0005735C File Offset: 0x0005555C
		public static List<SheetInformation> LinkDocSheetInformation { get; set; } = \u000C\u0018\u000F.\u0018();

		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x06000F5D RID: 3933 RVA: 0x00057370 File Offset: 0x00055570
		// (set) Token: 0x06000F5E RID: 3934 RVA: 0x00057384 File Offset: 0x00055584
		public static List<RevisionInformation> LinkDocRevisionInformation { get; set; } = \u0016\u0004\u0016.\u0018();

		// Token: 0x040006D9 RID: 1753
		[CompilerGenerated]
		private static List<ParameterInformation> \u000C;

		// Token: 0x040006DA RID: 1754
		[CompilerGenerated]
		private static List<ParameterInformation> \u0018;

		// Token: 0x040006DB RID: 1755
		[CompilerGenerated]
		private static List<ParameterInformation> \u0014;

		// Token: 0x040006DC RID: 1756
		[CompilerGenerated]
		private static List<RevisionInformation> \u0003;

		// Token: 0x040006DD RID: 1757
		[CompilerGenerated]
		private static List<ParameterInformation> \u0016;

		// Token: 0x040006DE RID: 1758
		[CompilerGenerated]
		private static List<SheetInformation> \u000F;

		// Token: 0x040006DF RID: 1759
		[CompilerGenerated]
		private static List<RevisionInformation> \u0012;
	}
}

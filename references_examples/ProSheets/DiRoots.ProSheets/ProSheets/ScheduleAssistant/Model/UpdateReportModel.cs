using System;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Models;
using ProSheets.ScheduleAssistant.Model.Enum;

namespace ProSheets.ScheduleAssistant.Model
{
	// Token: 0x020000B1 RID: 177
	public class UpdateReportModel : ModelBase
	{
		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000A3B RID: 2619 RVA: 0x0003E744 File Offset: 0x0003C944
		// (set) Token: 0x06000A3C RID: 2620 RVA: 0x0003E758 File Offset: 0x0003C958
		public string Description { get; set; }

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000A3D RID: 2621 RVA: 0x0003E76C File Offset: 0x0003C96C
		// (set) Token: 0x06000A3E RID: 2622 RVA: 0x0003E780 File Offset: 0x0003C980
		public string PropertyName { get; set; }

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06000A3F RID: 2623 RVA: 0x0003E794 File Offset: 0x0003C994
		// (set) Token: 0x06000A40 RID: 2624 RVA: 0x0003E7A8 File Offset: 0x0003C9A8
		public string TabName { get; set; }

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06000A41 RID: 2625 RVA: 0x0003E7BC File Offset: 0x0003C9BC
		// (set) Token: 0x06000A42 RID: 2626 RVA: 0x0003E7D0 File Offset: 0x0003C9D0
		public TabName Tab { get; set; }

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000A43 RID: 2627 RVA: 0x0003E7E4 File Offset: 0x0003C9E4
		// (set) Token: 0x06000A44 RID: 2628 RVA: 0x0003E7F8 File Offset: 0x0003C9F8
		public string StatusString { get; set; }

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000A45 RID: 2629 RVA: 0x0003E80C File Offset: 0x0003CA0C
		// (set) Token: 0x06000A46 RID: 2630 RVA: 0x0003E820 File Offset: 0x0003CA20
		public UpdateReportStatus Status { get; set; }

		// Token: 0x040004C9 RID: 1225
		[CompilerGenerated]
		private string E;

		// Token: 0x040004CA RID: 1226
		[CompilerGenerated]
		private string A;

		// Token: 0x040004CB RID: 1227
		[CompilerGenerated]
		private string V;

		// Token: 0x040004CC RID: 1228
		[CompilerGenerated]
		private TabName D;

		// Token: 0x040004CD RID: 1229
		[CompilerGenerated]
		private string K;

		// Token: 0x040004CE RID: 1230
		[CompilerGenerated]
		private UpdateReportStatus PB;
	}
}

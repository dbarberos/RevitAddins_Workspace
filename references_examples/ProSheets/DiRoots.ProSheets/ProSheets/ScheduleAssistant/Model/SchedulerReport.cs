using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using DiRoots.One.Commons.Attributes;
using DiRoots.One.Commons.Models;

namespace ProSheets.ScheduleAssistant.Model
{
	// Token: 0x020000AF RID: 175
	public class SchedulerReport : Report
	{
		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000A23 RID: 2595 RVA: 0x0003E558 File Offset: 0x0003C758
		// (set) Token: 0x06000A24 RID: 2596 RVA: 0x0003E56C File Offset: 0x0003C76C
		[Report("Id", 1.0, DataGridLengthUnitType.Star, false, false)]
		public long ElementId { get; set; }

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000A25 RID: 2597 RVA: 0x0003E580 File Offset: 0x0003C780
		// (set) Token: 0x06000A26 RID: 2598 RVA: 0x0003E594 File Offset: 0x0003C794
		[Report("Sheet Number", 1.0, DataGridLengthUnitType.Star, false, false)]
		public string Number { get; set; }

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000A27 RID: 2599 RVA: 0x0003E5A8 File Offset: 0x0003C7A8
		// (set) Token: 0x06000A28 RID: 2600 RVA: 0x0003E5BC File Offset: 0x0003C7BC
		[Report("Name", 1.0, DataGridLengthUnitType.Star, false, false)]
		public string Name { get; set; }

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000A29 RID: 2601 RVA: 0x0003E5D0 File Offset: 0x0003C7D0
		// (set) Token: 0x06000A2A RID: 2602 RVA: 0x0003E5E4 File Offset: 0x0003C7E4
		[Report("Format", 1.0, DataGridLengthUnitType.Star, false, false)]
		public string Format { get; set; }

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000A2B RID: 2603 RVA: 0x0003E5F8 File Offset: 0x0003C7F8
		// (set) Token: 0x06000A2C RID: 2604 RVA: 0x0003E60C File Offset: 0x0003C80C
		[Report("Description", 1.0, DataGridLengthUnitType.Star, false, false)]
		public string Description { get; set; }

		// Token: 0x040004BE RID: 1214
		[CompilerGenerated]
		private long S;

		// Token: 0x040004BF RID: 1215
		[CompilerGenerated]
		private string U;

		// Token: 0x040004C0 RID: 1216
		[CompilerGenerated]
		private string F;

		// Token: 0x040004C1 RID: 1217
		[CompilerGenerated]
		private string L;

		// Token: 0x040004C2 RID: 1218
		[CompilerGenerated]
		private string E;
	}
}

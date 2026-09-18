using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000250 RID: 592
	public class ScheduleData
	{
		// Token: 0x170006B1 RID: 1713
		// (get) Token: 0x06001816 RID: 6166 RVA: 0x0009C0C0 File Offset: 0x0009A2C0
		// (set) Token: 0x06001817 RID: 6167 RVA: 0x0009C0D4 File Offset: 0x0009A2D4
		public long RevitElementId { get; set; }

		// Token: 0x170006B2 RID: 1714
		// (get) Token: 0x06001818 RID: 6168 RVA: 0x0009C0E8 File Offset: 0x0009A2E8
		// (set) Token: 0x06001819 RID: 6169 RVA: 0x0009C0FC File Offset: 0x0009A2FC
		public Element RevitElement { get; set; }

		// Token: 0x170006B3 RID: 1715
		// (get) Token: 0x0600181A RID: 6170 RVA: 0x0009C110 File Offset: 0x0009A310
		// (set) Token: 0x0600181B RID: 6171 RVA: 0x0009C124 File Offset: 0x0009A324
		public int ElementIndex { get; set; }

		// Token: 0x170006B4 RID: 1716
		// (get) Token: 0x0600181C RID: 6172 RVA: 0x0009C138 File Offset: 0x0009A338
		// (set) Token: 0x0600181D RID: 6173 RVA: 0x0009C14C File Offset: 0x0009A34C
		public Dictionary<int, SchedulParameter> ScheduleParamsAndValues { get; set; } = new Dictionary<int, SchedulParameter>();

		// Token: 0x0400097C RID: 2428
		[CompilerGenerated]
		private long \u001F;

		// Token: 0x0400097D RID: 2429
		[CompilerGenerated]
		private Element \u000A;

		// Token: 0x0400097E RID: 2430
		[CompilerGenerated]
		private int \u0007;

		// Token: 0x0400097F RID: 2431
		[CompilerGenerated]
		private Dictionary<int, SchedulParameter> \u001D;
	}
}

using System;
using System.Collections.Generic;

namespace ProSheets.ScheduleAssistant.Model
{
	// Token: 0x020000B0 RID: 176
	[Serializable]
	public class SchedulerTimer
	{
		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000A2E RID: 2606 RVA: 0x0003E640 File Offset: 0x0003C840
		// (set) Token: 0x06000A2F RID: 2607 RVA: 0x0003E654 File Offset: 0x0003C854
		public DateTime Date { get; set; }

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000A30 RID: 2608 RVA: 0x0003E668 File Offset: 0x0003C868
		// (set) Token: 0x06000A31 RID: 2609 RVA: 0x0003E67C File Offset: 0x0003C87C
		public DateTime Time { get; set; }

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000A32 RID: 2610 RVA: 0x0003E690 File Offset: 0x0003C890
		// (set) Token: 0x06000A33 RID: 2611 RVA: 0x0003E6A4 File Offset: 0x0003C8A4
		public RepeatMode RepeatMode { get; set; }

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000A34 RID: 2612 RVA: 0x0003E6B8 File Offset: 0x0003C8B8
		// (set) Token: 0x06000A35 RID: 2613 RVA: 0x0003E6CC File Offset: 0x0003C8CC
		public bool IsCompleted { get; set; }

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000A36 RID: 2614 RVA: 0x0003E6E0 File Offset: 0x0003C8E0
		// (set) Token: 0x06000A37 RID: 2615 RVA: 0x0003E6F4 File Offset: 0x0003C8F4
		public List<WeekDay> SelectedWeekday { get; set; } = new List<WeekDay>();

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000A38 RID: 2616 RVA: 0x0003E708 File Offset: 0x0003C908
		// (set) Token: 0x06000A39 RID: 2617 RVA: 0x0003E71C File Offset: 0x0003C91C
		public string SchedulerProfile { get; set; }
	}
}

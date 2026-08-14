using System;

namespace ProSheets.ScheduleAssistant.Model
{
	// Token: 0x020000AC RID: 172
	[Serializable]
	public class PrintDetails
	{
		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06000A09 RID: 2569 RVA: 0x0003E350 File Offset: 0x0003C550
		// (set) Token: 0x06000A0A RID: 2570 RVA: 0x0003E364 File Offset: 0x0003C564
		public string Oriendtation { get; set; }

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06000A0B RID: 2571 RVA: 0x0003E378 File Offset: 0x0003C578
		// (set) Token: 0x06000A0C RID: 2572 RVA: 0x0003E38C File Offset: 0x0003C58C
		public string Format { get; set; }

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06000A0D RID: 2573 RVA: 0x0003E3A0 File Offset: 0x0003C5A0
		// (set) Token: 0x06000A0E RID: 2574 RVA: 0x0003E3B4 File Offset: 0x0003C5B4
		public string SheetSize { get; set; }

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06000A0F RID: 2575 RVA: 0x0003E3C8 File Offset: 0x0003C5C8
		// (set) Token: 0x06000A10 RID: 2576 RVA: 0x0003E3DC File Offset: 0x0003C5DC
		public string Name { get; set; }

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000A11 RID: 2577 RVA: 0x0003E3F0 File Offset: 0x0003C5F0
		// (set) Token: 0x06000A12 RID: 2578 RVA: 0x0003E404 File Offset: 0x0003C604
		public string Number { get; set; }

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000A13 RID: 2579 RVA: 0x0003E418 File Offset: 0x0003C618
		// (set) Token: 0x06000A14 RID: 2580 RVA: 0x0003E42C File Offset: 0x0003C62C
		public long Id { get; set; }

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000A15 RID: 2581 RVA: 0x0003E440 File Offset: 0x0003C640
		// (set) Token: 0x06000A16 RID: 2582 RVA: 0x0003E454 File Offset: 0x0003C654
		public bool IsView { get; set; }
	}
}

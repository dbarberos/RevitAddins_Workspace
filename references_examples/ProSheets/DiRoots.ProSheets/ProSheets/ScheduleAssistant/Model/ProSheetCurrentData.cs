using System;
using System.Collections.Generic;
using ProSheets.Models;
using ProSheets.ScheduleAssistant.Attributes;
using ProSheets.ScheduleAssistant.Model.Enum;

namespace ProSheets.ScheduleAssistant.Model
{
	// Token: 0x020000AD RID: 173
	[Serializable]
	public class ProSheetCurrentData : Profile
	{
		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000A18 RID: 2584 RVA: 0x0003E47C File Offset: 0x0003C67C
		// (set) Token: 0x06000A19 RID: 2585 RVA: 0x0003E490 File Offset: 0x0003C690
		[UpdateReport("FileSavePath", TabName.Create, "Report-LocationFolderChanged", false)]
		public string FileSavePath { get; set; }

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06000A1A RID: 2586 RVA: 0x0003E4A4 File Offset: 0x0003C6A4
		// (set) Token: 0x06000A1B RID: 2587 RVA: 0x0003E4B8 File Offset: 0x0003C6B8
		[UpdateReport("SplitFiles", TabName.Create, "Report-SplitFilesByFileFormatOptionWasChanged", false)]
		public bool SplitFiles { get; set; }

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06000A1C RID: 2588 RVA: 0x0003E4CC File Offset: 0x0003C6CC
		// (set) Token: 0x06000A1D RID: 2589 RVA: 0x0003E4E0 File Offset: 0x0003C6E0
		[UpdateReport("ReportSaveType", TabName.Create, "Report-ReportSavingOptionWasChanged", false)]
		public string ReportSaveType { get; set; }

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06000A1E RID: 2590 RVA: 0x0003E4F4 File Offset: 0x0003C6F4
		// (set) Token: 0x06000A1F RID: 2591 RVA: 0x0003E508 File Offset: 0x0003C708
		public List<PrintDetails> PrintDetails { get; set; }

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06000A20 RID: 2592 RVA: 0x0003E51C File Offset: 0x0003C71C
		// (set) Token: 0x06000A21 RID: 2593 RVA: 0x0003E530 File Offset: 0x0003C730
		public List<SheetInfo> SheetInfos { get; set; }
	}
}

using System;
using A;
using ProSheets.ScheduleAssistant.Model.Enum;

namespace ProSheets.ScheduleAssistant.Attributes
{
	// Token: 0x020000BA RID: 186
	public class UpdateReportAttribute : Attribute
	{
		// Token: 0x06000A69 RID: 2665 RVA: 0x0003FC68 File Offset: 0x0003DE68
		public UpdateReportAttribute(string propName, TabName tabName, string description, bool isRadioBtn = false)
		{
			\u0018\u000D\u0016.\u0018(this, propName);
			\u000C\u000D\u0016.\u0018(this, tabName);
			\u000E\u0012\u0016.\u0018(this, description);
			\u0005\u0012\u0016.\u0018(this, isRadioBtn);
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06000A6A RID: 2666 RVA: 0x0003FC98 File Offset: 0x0003DE98
		// (set) Token: 0x06000A6B RID: 2667 RVA: 0x0003FCAC File Offset: 0x0003DEAC
		public string PropertyName { get; set; }

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06000A6C RID: 2668 RVA: 0x0003FCC0 File Offset: 0x0003DEC0
		// (set) Token: 0x06000A6D RID: 2669 RVA: 0x0003FCD4 File Offset: 0x0003DED4
		public TabName TabName { get; set; }

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06000A6E RID: 2670 RVA: 0x0003FCE8 File Offset: 0x0003DEE8
		// (set) Token: 0x06000A6F RID: 2671 RVA: 0x0003FCFC File Offset: 0x0003DEFC
		public string Description { get; set; }

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06000A70 RID: 2672 RVA: 0x0003FD10 File Offset: 0x0003DF10
		// (set) Token: 0x06000A71 RID: 2673 RVA: 0x0003FD24 File Offset: 0x0003DF24
		public bool IsRadioBtn { get; set; }
	}
}

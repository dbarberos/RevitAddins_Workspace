using System;
using System.Runtime.CompilerServices;
using ProSheets.ScheduleAssistant.Attributes;
using ProSheets.ScheduleAssistant.Model.Enum;
using ProSheets.Xml.Enums;

namespace ProSheets.Xml.Models.Dto
{
	// Token: 0x0200007D RID: 125
	public class XmlExportOptionsDto
	{
		// Token: 0x17000329 RID: 809
		// (get) Token: 0x060007C9 RID: 1993 RVA: 0x00027D28 File Offset: 0x00025F28
		// (set) Token: 0x060007CA RID: 1994 RVA: 0x00027D3C File Offset: 0x00025F3C
		[UpdateReport("XmlExportAsOption", TabName.FormatXml, "PS-XML-Report-XmlExportAsOptionWasChanged", false)]
		public XmlExportAsOptions XmlExportAsOption { get; set; }

		// Token: 0x04000310 RID: 784
		[CompilerGenerated]
		private XmlExportAsOptions \u000C;
	}
}

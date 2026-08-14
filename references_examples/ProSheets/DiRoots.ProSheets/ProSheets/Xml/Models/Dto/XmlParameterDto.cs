using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DiRoots.ProSheets.Xml.Models;
using ProSheets.ScheduleAssistant.Attributes;
using ProSheets.ScheduleAssistant.Model.Enum;

namespace ProSheets.Xml.Models.Dto
{
	// Token: 0x0200007E RID: 126
	public class XmlParameterDto
	{
		// Token: 0x1700032A RID: 810
		// (get) Token: 0x060007CC RID: 1996 RVA: 0x00027D64 File Offset: 0x00025F64
		// (set) Token: 0x060007CD RID: 1997 RVA: 0x00027D78 File Offset: 0x00025F78
		[UpdateReport("SheetParameters", TabName.FormatXml, "PS-XML-Report-SheetParametersChanged", false)]
		public List<ParameterDto> SheetParameters { get; set; }

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x060007CE RID: 1998 RVA: 0x00027D8C File Offset: 0x00025F8C
		// (set) Token: 0x060007CF RID: 1999 RVA: 0x00027DA0 File Offset: 0x00025FA0
		[UpdateReport("ViewParameters", TabName.FormatXml, "PS-XML-Report-ViewParametersChanged", false)]
		public List<ParameterDto> ViewParameters { get; set; }

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x060007D0 RID: 2000 RVA: 0x00027DB4 File Offset: 0x00025FB4
		// (set) Token: 0x060007D1 RID: 2001 RVA: 0x00027DC8 File Offset: 0x00025FC8
		public XmlExportOptionsDto ExportOptions { get; set; }

		// Token: 0x04000311 RID: 785
		[CompilerGenerated]
		private List<ParameterDto> \u000C;

		// Token: 0x04000312 RID: 786
		[CompilerGenerated]
		private List<ParameterDto> \u0018;

		// Token: 0x04000313 RID: 787
		[CompilerGenerated]
		private XmlExportOptionsDto \u0014;
	}
}

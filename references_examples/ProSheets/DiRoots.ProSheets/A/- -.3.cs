using System;
using ProSheets.ScheduleAssistant.Model;
using ProSheets.ScheduleAssistant.Model.Enum;

namespace A
{
	// Token: 0x020000B7 RID: 183
	internal static class \u0002\u0020\u0018
	{
		// Token: 0x06000A55 RID: 2645 RVA: 0x0003E978 File Offset: 0x0003CB78
		public static string \u000C(this TabName \u000C)
		{
			string result = string.Empty;
			switch (\u000C)
			{
			case TabName.Selection:
				result = "PS-Selection";
				break;
			case TabName.Format:
				result = "Common-Format";
				break;
			case TabName.Create:
				result = "Common-Create";
				break;
			case TabName.FormatPDF:
				result = "Report-Format[PDF]";
				break;
			case TabName.FormatDWG:
				result = "Report-Format[DWG]";
				break;
			case TabName.FormatDGN:
				result = "Report-Format[DGN]";
				break;
			case TabName.FormatDWF:
				result = "Report-Format[DWF]";
				break;
			case TabName.FormatNWC:
				result = "Report-Format[NWC]";
				break;
			case TabName.FormatIFC:
				result = "Report-Format[IFC]";
				break;
			case TabName.FormatIMG:
				result = "Report-Format[IMG]";
				break;
			case TabName.FormatXml:
				result = "Report-Format[XML]";
				break;
			}
			return result;
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x0003EA18 File Offset: 0x0003CC18
		public static string \u000C(this UpdateReportStatus \u000C)
		{
			string result = string.Empty;
			switch (\u000C)
			{
			case UpdateReportStatus.Added:
				result = "Report-Added";
				break;
			case UpdateReportStatus.Removed:
				result = "Report-Removed";
				break;
			case UpdateReportStatus.Changed:
				result = "Report-Changed";
				break;
			}
			return result;
		}
	}
}

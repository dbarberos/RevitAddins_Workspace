using System;
using Autodesk.Revit.DB;
using BIM.IFC.Export.UI;

namespace A
{
	// Token: 0x020000EE RID: 238
	internal static class \u001A\u0011\u0018
	{
		// Token: 0x06000BCB RID: 3019 RVA: 0x00048138 File Offset: 0x00046338
		public static void \u000C(IFCExportOptions \u000C, string \u0018)
		{
			IFCExportConfiguration ifcexportConfiguration = \u0004\u0017\u0016.\u0018(\u0018);
			if (ifcexportConfiguration == null)
			{
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u0011\u0018.\u000C(IFCExportOptions, string)).MethodHandle;
				}
				return;
			}
			\u0007\u001E\u0018.\u0018(\u000C, "COBieCompanyInfo", \u0020\u001E\u0016.\u0018(ifcexportConfiguration));
			\u0007\u001E\u0018.\u0018(\u000C, "COBieProjectInfo", \u000A\u001E\u0016.\u0018(ifcexportConfiguration));
			\u0007\u001E\u0018.\u0018(\u000C, "ExchangeRequirement", \u0017\u0017\u0016.\u0018(ifcexportConfiguration).ToString());
			string u = "GeoRefCRSName";
			string u2;
			if ((u2 = \u0009\u001E\u0016.\u0018(ifcexportConfiguration)) == null)
			{
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				u2 = "";
			}
			\u0007\u001E\u0018.\u0018(\u000C, u, u2);
			string u3 = "GeoRefCRSDesc";
			string u4;
			if ((u4 = \u0013\u001E\u0016.\u0018(ifcexportConfiguration)) == null)
			{
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				u4 = "";
			}
			\u0007\u001E\u0018.\u0018(\u000C, u3, u4);
			string u5 = "GeoRefEPSGCode";
			string u6;
			if ((u6 = \u001C\u001E\u0016.\u0018(ifcexportConfiguration)) == null)
			{
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				u6 = "";
			}
			\u0007\u001E\u0018.\u0018(\u000C, u5, u6);
			string u7 = "GeoRefGeodeticDatum";
			string u8;
			if ((u8 = \u000D\u001E\u0016.\u0018(ifcexportConfiguration)) == null)
			{
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				u8 = "";
			}
			\u0007\u001E\u0018.\u0018(\u000C, u7, u8);
			string u9 = "GeoRefMapUnit";
			string u10;
			if ((u10 = \u0012\u001E\u0016.\u0018(ifcexportConfiguration)) == null)
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				u10 = "";
			}
			\u0007\u001E\u0018.\u0018(\u000C, u9, u10);
		}
	}
}

using System;
using A;
using Autodesk.Revit.DB;
using BIM.IFC.Export.UI;
using Revit.IFC.Common.Enums;
using Revit.IFC.Common.Extensions;

namespace ProSheets.Exporters.IFC
{
	// Token: 0x020000EB RID: 235
	public static class FileHeaderHelper
	{
		// Token: 0x06000BBA RID: 3002 RVA: 0x00047D74 File Offset: 0x00045F74
		public static void SetFileHeader(Document doc, string setupName)
		{
			IFCFileHeaderItem u000C;
			if (!\u0013\u001A\u0003.\u0018(\u0009\u001A\u0003.\u0018(), doc, ref u000C))
			{
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileHeaderHelper.SetFileHeader(Document, string)).MethodHandle;
				}
				u000C = \u001A\u0017\u0016.\u0018(doc);
			}
			\u001D\u0017\u0016.\u0018(u000C);
			IFCExportConfiguration ifcexportConfiguration = \u0004\u0017\u0016.\u0018(setupName);
			if (ifcexportConfiguration == null)
			{
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				return;
			}
			\u0015\u0017\u0016.\u0018(\u0002\u0017\u0016.\u0018(ifcexportConfiguration), \u001E\u0017\u0016.\u0018(ifcexportConfiguration), \u0017\u0017\u0016.\u0018(ifcexportConfiguration));
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x00047DEC File Offset: 0x00045FEC
		public static void SetFileHeader(SiteTransformBasis sitePlacement, string selectedSite, KnownERNames exchangeRequirement)
		{
			IFCFileHeaderItem ifcfileHeaderItem = \u0006\u0017\u0016.\u0018();
			if (ifcfileHeaderItem == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileHeaderHelper.SetFileHeader(SiteTransformBasis, string, KnownERNames)).MethodHandle;
				}
				return;
			}
			string u000C = "CoordinateBase: ";
			IFCSitePlacementAttributes ifcsitePlacementAttributes = \u0010\u0017\u0016.\u0018(sitePlacement);
			string u;
			if (ifcsitePlacementAttributes == null)
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				u = \u0005\u001E\u000F.\u000C;
			}
			else
			{
				u = \u0001\u0017\u0018.\u0018(ifcsitePlacementAttributes);
			}
			string text = \u000D\u001E\u0018.\u0018(u000C, u);
			if (!\u001F\u001A\u0018.\u0018(selectedSite))
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				string u000C2 = ", ";
				string[] array = \u000C\u0002\u000F.\u000C(2);
				array[0] = text;
				array[1] = \u000D\u001E\u0018.\u0018("ProjectSite: ", selectedSite);
				text = \u0007\u0017\u0016.\u0018(u000C2, array);
			}
			\u000C\u0002\u0018.\u0018(\u0019\u0017\u0016.\u0018(ifcfileHeaderItem), \u0014\u001E\u0018.\u0018("CoordinateReference [", text, "]"));
			if (exchangeRequirement != 3)
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				string u2 = \u0014\u001E\u0018.\u0018("ExchangeRequirement [", exchangeRequirement.ToString(), "]");
				\u000B\u0017\u0016.\u0018(ifcfileHeaderItem, u2);
			}
		}
	}
}

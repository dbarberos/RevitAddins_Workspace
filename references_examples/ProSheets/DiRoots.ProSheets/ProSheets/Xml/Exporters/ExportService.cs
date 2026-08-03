using System;
using System.Collections.Generic;
using System.Xml;
using A;
using DiRoots.ProSheets.Xml.Models;
using ProSheets.Xml.Enums;

namespace ProSheets.Xml.Exporters
{
	// Token: 0x0200007F RID: 127
	public static class ExportService
	{
		// Token: 0x060007D2 RID: 2002 RVA: 0x00027DDC File Offset: 0x00025FDC
		public static void Export(string rootName, string filePath, List<XmlParameterInfo> parameters, XmlExportOptions xmlExportAsOption)
		{
			if (\u001C\u0012\u0003.\u0018(xmlExportAsOption) == XmlExportAsOptions.Document)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportService.Export(string, string, List<XmlParameterInfo>, XmlExportOptions)).MethodHandle;
				}
				ExportService.\u000C(rootName, filePath, parameters);
				return;
			}
			ExportService.\u0018(filePath, parameters);
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x00027E18 File Offset: 0x00026018
		private static void \u000C(string \u000C, string \u0018, List<XmlParameterInfo> \u0014)
		{
			XmlTextWriter xmlTextWriter = \u0004\u0012\u0003.\u0018(\u0018, \u001D\u0012\u0003.\u0018());
			try
			{
				\u0002\u0012\u0003.\u0018(xmlTextWriter, Formatting.Indented);
				\u001E\u0012\u0003.\u0018(xmlTextWriter);
				\u0011\u0012\u0003.\u0018(xmlTextWriter, \u000C);
				List<XmlParameterInfo>.Enumerator enumerator = \u0017\u0012\u0003.\u0018(\u0014);
				try
				{
					while (\u000A\u0012\u0003.\u0018(ref enumerator))
					{
						XmlParameterInfo u000C = \u0015\u0012\u0003.\u0018(ref enumerator);
						\u0011\u0012\u0003.\u0018(xmlTextWriter, \u000C\u0005\u0018.\u0003(u000C));
						\u0020\u0012\u0003.\u0018(xmlTextWriter, \u001F\u0012\u0003.\u0018(u000C));
						\u0009\u0012\u0003.\u0018(xmlTextWriter);
					}
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ExportService.\u000C(string, string, List<XmlParameterInfo>)).MethodHandle;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				\u0009\u0012\u0003.\u0018(xmlTextWriter);
				\u0013\u0012\u0003.\u0018(xmlTextWriter);
			}
			finally
			{
				if (xmlTextWriter != null)
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
					\u0020\u001E\u0018.\u0018(xmlTextWriter);
				}
			}
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x00027EEC File Offset: 0x000260EC
		private static void \u0018(string \u000C, List<XmlParameterInfo> \u0018)
		{
			XmlTextWriter xmlTextWriter = \u0004\u0012\u0003.\u0018(\u000C, \u001D\u0012\u0003.\u0018());
			try
			{
				\u0002\u0012\u0003.\u0018(xmlTextWriter, Formatting.Indented);
				List<XmlParameterInfo>.Enumerator enumerator = \u0017\u0012\u0003.\u0018(\u0018);
				try
				{
					while (\u000A\u0012\u0003.\u0018(ref enumerator))
					{
						XmlParameterInfo u000C = \u0015\u0012\u0003.\u0018(ref enumerator);
						\u0011\u0012\u0003.\u0018(xmlTextWriter, \u000C\u0005\u0018.\u0003(u000C));
						\u0020\u0012\u0003.\u0018(xmlTextWriter, \u001F\u0012\u0003.\u0018(u000C));
						\u0009\u0012\u0003.\u0018(xmlTextWriter);
					}
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ExportService.\u0018(string, List<XmlParameterInfo>)).MethodHandle;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			finally
			{
				if (xmlTextWriter != null)
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
					\u0020\u001E\u0018.\u0018(xmlTextWriter);
				}
			}
		}
	}
}

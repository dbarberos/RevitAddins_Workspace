using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.ProSheets.Xml.Enums;
using DiRoots.ProSheets.Xml.Interfaces;
using DiRoots.ProSheets.Xml.Models;
using DiRoots.ProSheets.Xml.ViewModels;
using ProSheets.Helpers;
using ProSheets.Models;
using ProSheets.ViewModels;

namespace A
{
	// Token: 0x020000EA RID: 234
	internal static class \u0002\u0011\u0018
	{
		// Token: 0x06000BB8 RID: 3000 RVA: 0x00047AA4 File Offset: 0x00045CA4
		public static bool \u000C(View \u000C, string \u0018, SheetInfo \u0014)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\XmlExporter.cs", "Export");
			bool result = false;
			try
			{
				string u = \u001F\u0010\u0014.\u0018(\u0014, \u000C, \u0015\u0010\u0014.\u0018(), "XML", \u0018, ".xml", \u0011\u0010\u0014.\u0018());
				if (!\u001F\u001A\u0018.\u0018(\u0014\u0017\u0014.\u0018(\u0014)))
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0011\u0018.\u000C(View, string, SheetInfo)).MethodHandle;
					}
					return false;
				}
				bool flag = \u000E\u001A\u000F.\u000C(\u000C) != \u0014\u000B\u000F.\u000C;
				XmlExporterViewModel service = \u0004\u0005\u0018.\u0018().GetService<XmlExporterViewModel>(false);
				XmlParameterBaseModel xmlParameterBaseModel;
				if (!flag)
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
					xmlParameterBaseModel = \u0014\u000D\u0003.\u0014(service);
				}
				else
				{
					xmlParameterBaseModel = \u000C\u000D\u0003.\u0014(service);
				}
				XmlParameterBaseModel u000C = xmlParameterBaseModel;
				List<IParameterInfo> u2 = Enumerable.ToList<IParameterInfo>(\u0012\u0008\u0018.\u0003(u000C));
				List<XmlParameterInfo> u3 = \u0002\u0011\u0018.\u0018(\u000C, \u0014, u2);
				string u000C2;
				if (!flag)
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
					u000C2 = \u001C\u0009\u0018.\u0019;
				}
				else
				{
					u000C2 = \u001C\u0009\u0018.\u001A;
				}
				\u0020\u0017\u0016.\u0018(u000C2, u, u3, \u000E\u0012\u0003.\u0018(u000C));
				result = true;
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\XmlExporter.cs", "Export");
			}
			catch (Exception ex)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\XmlExporter.cs", "Export");
				\u0018\u0017\u0014.\u0014(\u0014, \u000A\u0001\u0018.\u0018(ex));
			}
			return result;
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x00047BFC File Offset: 0x00045DFC
		private static List<XmlParameterInfo> \u0018(View \u000C, SheetInfo \u0018, List<IParameterInfo> \u0014)
		{
			List<XmlParameterInfo> list = \u0011\u0017\u0016.\u0018();
			List<IParameterInfo>.Enumerator enumerator = \u001E\u0008\u0018.\u0018(\u0014);
			try
			{
				while (\u001F\u0008\u0018.\u0018(ref enumerator))
				{
					XmlParameterInfo xmlParameterInfo = \u000D\u0019\u000F.\u000C(\u0017\u0008\u0018.\u0018(ref enumerator));
					if (xmlParameterInfo != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0011\u0018.\u0018(View, SheetInfo, List<IParameterInfo>)).MethodHandle;
						}
						XmlParameterInfo xmlParameterInfo2 = \u0014\u0005\u0018.\u0018();
						\u0001\u001B\u0018.\u0003(xmlParameterInfo2, \u000C\u0005\u0018.\u0003(xmlParameterInfo));
						XmlParameterInfo xmlParameterInfo3 = xmlParameterInfo2;
						if (\u0011\u001B\u0018.\u0014(xmlParameterInfo) == ParameterType.Environment)
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
							if (\u001B\u0013\u0018.\u0018(\u0009\u001B\u0018.\u0014(xmlParameterInfo), "%sheetsize%", true))
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
								\u0006\u001B\u0018.\u0003(xmlParameterInfo3, \u0004\u0017\u0014.\u0018(\u0018));
							}
							else
							{
								\u0006\u001B\u0018.\u0003(xmlParameterInfo3, \u0018\u001F\u0018.\u0018(\u0009\u001B\u0018.\u0014(xmlParameterInfo)));
							}
						}
						else
						{
							ParameterType parameterType = \u0011\u001B\u0018.\u0014(xmlParameterInfo);
							bool flag;
							if (parameterType <= ParameterType.Project)
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
								flag = true;
							}
							else
							{
								flag = false;
							}
							if (flag)
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
								\u0006\u001B\u0018.\u0003(xmlParameterInfo3, \u000C\u000A\u0018.\u001D(\u000C, \u0020\u001B\u0018.\u0014(xmlParameterInfo), \u0009\u001B\u0018.\u0014(xmlParameterInfo), \u0011\u001B\u0018.\u0014(xmlParameterInfo) == ParameterType.Project));
							}
							else
							{
								\u0006\u001B\u0018.\u0003(xmlParameterInfo3, \u001F\u0012\u0003.\u0018(xmlParameterInfo));
							}
						}
						\u001F\u0017\u0016.\u0018(list, xmlParameterInfo3);
					}
				}
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}
	}
}

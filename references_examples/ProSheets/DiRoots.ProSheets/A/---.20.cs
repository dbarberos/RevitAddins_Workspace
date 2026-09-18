using System;
using System.Collections.Generic;
using System.Linq;
using DiRoots.ProSheets.Xml.Enums;
using DiRoots.ProSheets.Xml.Interfaces;
using DiRoots.ProSheets.Xml.Models;
using DiRoots.ProSheets.Xml.ViewModels;
using ProSheets;
using ProSheets.ViewModels;
using ProSheets.Xml.Models.Dto;

namespace A
{
	// Token: 0x02000082 RID: 130
	internal static class \u001E\u000A\u0018
	{
		// Token: 0x060007D7 RID: 2007 RVA: 0x0002849C File Offset: 0x0002669C
		internal static List<IParameterInfo> \u000C(List<SelectionParameter> \u000C)
		{
			Func<SelectionParameter, XmlParameterInfo> func;
			if ((func = \u001E\u000A\u0018.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u000A\u0018.\u000C(List<SelectionParameter>)).MethodHandle;
				}
				func = (\u001E\u000A\u0018.<>c.\u0018 = new Func<SelectionParameter, XmlParameterInfo>(\u001E\u000A\u0018.<>c.\u000C.\u0003));
			}
			List<IParameterInfo> list = Enumerable.ToList<IParameterInfo>(Enumerable.Select<SelectionParameter, XmlParameterInfo>(\u000C, func));
			List<IParameterInfo>.Enumerator enumerator = \u001E\u0008\u0018.\u0018(list);
			try
			{
				while (\u001F\u0008\u0018.\u0018(ref enumerator))
				{
					IParameterInfo u000C = \u0017\u0008\u0018.\u0018(ref enumerator);
					if (\u000C\u0001\u0018.\u0018(u000C) == ParameterType.Project)
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
						\u0006\u0012\u0003.\u0018(u000C, \u000C\u000A\u0018.\u001D(null, \u0001\u0012\u0003.\u0018(u000C), \u0008\u0012\u0003.\u0018(u000C), true));
					}
				}
				for (;;)
				{
					switch (3)
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

		// Token: 0x060007D8 RID: 2008 RVA: 0x0002856C File Offset: 0x0002676C
		private static ParameterType \u0018(SelectionParameter \u000C)
		{
			if (\u000B\u0020\u0014.\u0014(\u000C) == SelectionParameterType.Variable)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u000A\u0018.\u0018(SelectionParameter)).MethodHandle;
				}
				return ParameterType.Environment;
			}
			if (\u000E\u000C\u0014.\u0018(\u000C))
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
				return ParameterType.Project;
			}
			return ParameterType.Element;
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x000285B0 File Offset: 0x000267B0
		internal static List<ParameterDto> \u000C(IEnumerable<XmlParameterInfo> \u000C)
		{
			Func<XmlParameterInfo, ParameterDto> func;
			if ((func = \u001E\u000A\u0018.<>c.\u0014) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u000A\u0018.\u000C(IEnumerable<XmlParameterInfo>)).MethodHandle;
				}
				func = (\u001E\u000A\u0018.<>c.\u0014 = new Func<XmlParameterInfo, ParameterDto>(\u001E\u000A\u0018.<>c.\u000C.\u0016));
			}
			return Enumerable.ToList<ParameterDto>(Enumerable.Select<XmlParameterInfo, ParameterDto>(\u000C, func));
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x00028600 File Offset: 0x00026800
		internal static void \u0014(XmlExporterViewModel \u000C, ExportTemPlateInfo \u0018)
		{
			\u0003\u000D\u0003.\u0018(\u0005\u0012\u0003.\u0018(\u0018), \u001E\u000A\u0018.\u000C(Enumerable.Cast<XmlParameterInfo>(\u0012\u0008\u0018.\u0003(\u000C\u000D\u0003.\u0014(\u000C)))));
			\u0018\u000D\u0003.\u0018(\u0005\u0012\u0003.\u0018(\u0018), \u001E\u000A\u0018.\u000C(Enumerable.Cast<XmlParameterInfo>(\u0012\u0008\u0018.\u0003(\u0014\u000D\u0003.\u0014(\u000C)))));
			XmlExportOptionsDto u = \u001E\u000A\u0018.\u0012(\u000E\u0012\u0003.\u0018(\u000C\u000D\u0003.\u0014(\u000C)));
			\u001B\u0012\u0003.\u0018(\u0005\u0012\u0003.\u0018(\u0018), u);
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x00028688 File Offset: 0x00026888
		internal static void \u0003(XmlExporterViewModel \u000C, ExportTemPlateInfo \u0018)
		{
			\u001E\u000A\u0018.\u0016(\u000C\u000D\u0003.\u0014(\u000C), \u000D\u000D\u0003.\u0018(\u0005\u0012\u0003.\u0018(\u0018)));
			\u001E\u000A\u0018.\u0016(\u0014\u000D\u0003.\u0014(\u000C), \u0012\u000D\u0003.\u0018(\u0005\u0012\u0003.\u0018(\u0018)));
			XmlExportOptions u = \u001E\u000A\u0018.\u000F(\u000F\u000D\u0003.\u0018(\u0005\u0012\u0003.\u0018(\u0018)));
			\u0016\u000D\u0003.\u0018(\u000C\u000D\u0003.\u0014(\u000C), u);
			\u0016\u000D\u0003.\u0018(\u0014\u000D\u0003.\u0014(\u000C), u);
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x00028700 File Offset: 0x00026900
		private static void \u0016(XmlParameterBaseModel \u000C, List<ParameterDto> \u0018)
		{
			\u001A\u0008\u0018.\u0014(\u000C);
			if (\u0018 == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u000A\u0018.\u0016(XmlParameterBaseModel, List<ParameterDto>)).MethodHandle;
				}
				return;
			}
			List<ParameterDto>.Enumerator enumerator = \u000A\u000D\u0003.\u0018(\u0018);
			try
			{
				while (\u001C\u000D\u0003.\u0018(ref enumerator))
				{
					ParameterDto parameterDto = \u0009\u000D\u0003.\u0018(ref enumerator);
					ParameterType parameterType = \u0015\u001B\u0018.\u0003(parameterDto);
					bool flag;
					if (parameterType <= ParameterType.Environment)
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
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						IParameterInfo parameterInfo = Enumerable.FirstOrDefault<IParameterInfo>(\u000C\u0008\u0018.\u0003(\u000C), new Func<IParameterInfo, bool>(parameterDto.Equals));
						XmlParameterInfo xmlParameterInfo = \u000D\u0019\u000F.\u000C(parameterInfo);
						if (xmlParameterInfo != null)
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
							\u0001\u001B\u0018.\u0003(xmlParameterInfo, \u001B\u001B\u0018.\u0018(parameterDto));
							\u000F\u0008\u0018.\u0018(\u000C\u0008\u0018.\u0003(\u000C), parameterInfo);
							\u000D\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0003(\u000C), parameterInfo);
						}
					}
					else
					{
						\u000D\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0003(\u000C), \u0013\u000D\u0003.\u0018(parameterDto));
					}
				}
				for (;;)
				{
					switch (3)
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
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x00028824 File Offset: 0x00026A24
		private static XmlExportOptions \u000F(XmlExportOptionsDto \u000C)
		{
			if (\u000C != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u000A\u0018.\u000F(XmlExportOptionsDto)).MethodHandle;
				}
				XmlExportOptions xmlExportOptions = \u0020\u000D\u0003.\u0018();
				\u001F\u000D\u0003.\u0018(xmlExportOptions, \u0011\u000D\u0003.\u0018(\u000C));
				return xmlExportOptions;
			}
			return \u0020\u000D\u0003.\u0018();
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x00028864 File Offset: 0x00026A64
		private static XmlExportOptionsDto \u0012(XmlExportOptions \u000C)
		{
			XmlExportOptionsDto xmlExportOptionsDto = \u0017\u000D\u0003.\u0018();
			\u0015\u000D\u0003.\u0018(xmlExportOptionsDto, \u001C\u0012\u0003.\u0018(\u000C));
			return xmlExportOptionsDto;
		}
	}
}

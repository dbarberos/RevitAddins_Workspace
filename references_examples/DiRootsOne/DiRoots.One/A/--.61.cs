using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Profiles;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.TableGen.Models;
using DiRoots.One.TableGen.TGRevitHelper;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.Dto;
using DiRoots.One.TGDatabaseLayer.StyleMapping;
using Newtonsoft.Json;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x020000FC RID: 252
	internal static class \u0002\u0005
	{
		// Token: 0x06000918 RID: 2328 RVA: 0x0003E7E4 File Offset: 0x0003C9E4
		// Note: this type is marked as 'beforefieldinit'.
		static \u0002\u0005()
		{
			Dictionary<ExcelLineStyle, \u000C\u0005> dictionary = \u000A\u001C\u0004.\u000A();
			ExcelLineStyle u000A = ExcelLineStyle.Thin;
			\u000C\u0005 u000C_u = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u, ExcelLineStyle.Thin);
			\u0009\u0003\u0004.\u000A(u000C_u, "Thin");
			\u0001\u0003\u0004.\u000A(u000C_u, 1);
			\u0015\u0003\u0004.\u000A(dictionary, u000A, u000C_u);
			ExcelLineStyle u000A2 = ExcelLineStyle.Dashed;
			\u000C\u0005 u000C_u2 = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u2, ExcelLineStyle.Dashed);
			\u0009\u0003\u0004.\u000A(u000C_u2, "Dash");
			\u0001\u0003\u0004.\u000A(u000C_u2, 1);
			\u0015\u0003\u0004.\u000A(dictionary, u000A2, u000C_u2);
			ExcelLineStyle u000A3 = ExcelLineStyle.Dash_dot;
			\u000C\u0005 u000C_u3 = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u3, ExcelLineStyle.Dash_dot);
			\u0009\u0003\u0004.\u000A(u000C_u3, "Dash Dot");
			\u0001\u0003\u0004.\u000A(u000C_u3, 1);
			\u0015\u0003\u0004.\u000A(dictionary, u000A3, u000C_u3);
			ExcelLineStyle u000A4 = ExcelLineStyle.Dash_dot_dot;
			\u000C\u0005 u000C_u4 = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u4, ExcelLineStyle.Dash_dot_dot);
			\u0009\u0003\u0004.\u000A(u000C_u4, "Dash Dot Dot");
			\u0001\u0003\u0004.\u000A(u000C_u4, 1);
			\u0015\u0003\u0004.\u000A(dictionary, u000A4, u000C_u4);
			ExcelLineStyle u000A5 = ExcelLineStyle.Dotted;
			\u000C\u0005 u000C_u5 = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u5, ExcelLineStyle.Dotted);
			\u0009\u0003\u0004.\u000A(u000C_u5, "Dot");
			\u0001\u0003\u0004.\u000A(u000C_u5, 1);
			\u0015\u0003\u0004.\u000A(dictionary, u000A5, u000C_u5);
			ExcelLineStyle u000A6 = ExcelLineStyle.Medium_dashed;
			\u000C\u0005 u000C_u6 = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u6, ExcelLineStyle.Medium_dashed);
			\u0009\u0003\u0004.\u000A(u000C_u6, "Medium Dash");
			\u0001\u0003\u0004.\u000A(u000C_u6, 3);
			\u0015\u0003\u0004.\u000A(dictionary, u000A6, u000C_u6);
			ExcelLineStyle u000A7 = ExcelLineStyle.Medium_dash_dot;
			\u000C\u0005 u000C_u7 = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u7, ExcelLineStyle.Medium_dash_dot);
			\u0009\u0003\u0004.\u000A(u000C_u7, "Medium Dash Dot");
			\u0001\u0003\u0004.\u000A(u000C_u7, 3);
			\u0015\u0003\u0004.\u000A(dictionary, u000A7, u000C_u7);
			ExcelLineStyle u000A8 = ExcelLineStyle.Medium_dash_dot_dot;
			\u000C\u0005 u000C_u8 = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u8, ExcelLineStyle.Medium_dash_dot_dot);
			\u0009\u0003\u0004.\u000A(u000C_u8, "Medium Dash Dot Dot");
			\u0001\u0003\u0004.\u000A(u000C_u8, 3);
			\u0015\u0003\u0004.\u000A(dictionary, u000A8, u000C_u8);
			ExcelLineStyle u000A9 = ExcelLineStyle.Medium;
			\u000C\u0005 u000C_u9 = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u9, ExcelLineStyle.Medium);
			\u0009\u0003\u0004.\u000A(u000C_u9, "Medium");
			\u0001\u0003\u0004.\u000A(u000C_u9, 3);
			\u0015\u0003\u0004.\u000A(dictionary, u000A9, u000C_u9);
			ExcelLineStyle u000A10 = ExcelLineStyle.Thick;
			\u000C\u0005 u000C_u10 = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u10, ExcelLineStyle.Thick);
			\u0009\u0003\u0004.\u000A(u000C_u10, "Thick");
			\u0001\u0003\u0004.\u000A(u000C_u10, 6);
			\u0015\u0003\u0004.\u000A(dictionary, u000A10, u000C_u10);
			ExcelLineStyle u000A11 = ExcelLineStyle.Hair;
			\u000C\u0005 u000C_u11 = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u11, ExcelLineStyle.Hair);
			\u0009\u0003\u0004.\u000A(u000C_u11, "Hairline");
			\u0001\u0003\u0004.\u000A(u000C_u11, 1);
			\u0015\u0003\u0004.\u000A(dictionary, u000A11, u000C_u11);
			ExcelLineStyle u000A12 = ExcelLineStyle.Double;
			\u000C\u0005 u000C_u12 = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u12, ExcelLineStyle.Double);
			\u0009\u0003\u0004.\u000A(u000C_u12, "Double");
			\u0001\u0003\u0004.\u000A(u000C_u12, 6);
			\u0015\u0003\u0004.\u000A(dictionary, u000A12, u000C_u12);
			ExcelLineStyle u000A13 = ExcelLineStyle.Slanted_dash_dot;
			\u000C\u0005 u000C_u13 = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u13, ExcelLineStyle.Slanted_dash_dot);
			\u0009\u0003\u0004.\u000A(u000C_u13, "Slanted Dash Dot");
			\u0001\u0003\u0004.\u000A(u000C_u13, 3);
			\u0015\u0003\u0004.\u000A(dictionary, u000A13, u000C_u13);
			ExcelLineStyle u000A14 = ExcelLineStyle.None;
			\u000C\u0005 u000C_u14 = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u14, ExcelLineStyle.None);
			\u0009\u0003\u0004.\u000A(u000C_u14, "None");
			\u0001\u0003\u0004.\u000A(u000C_u14, 0);
			\u0015\u0003\u0004.\u000A(dictionary, u000A14, u000C_u14);
			ExcelLineStyle u000A15 = (ExcelLineStyle)(-1);
			\u000C\u0005 u000C_u15 = new \u000C\u0005();
			\u001F\u001C\u0004.\u000A(u000C_u15, ExcelLineStyle.Thin);
			\u0009\u0003\u0004.\u000A(u000C_u15, "Thin");
			\u0001\u0003\u0004.\u000A(u000C_u15, 1);
			\u0015\u0003\u0004.\u000A(dictionary, u000A15, u000C_u15);
			\u0002\u0005.\u001D = dictionary;
			ValueTuple<byte, byte, byte>[] array = \u001A\u0019\u000E.\u001F(6);
			array[0] = new ValueTuple<byte, byte, byte>(byte.MaxValue, 0, 0);
			array[1] = new ValueTuple<byte, byte, byte>(0, byte.MaxValue, 0);
			array[2] = new ValueTuple<byte, byte, byte>(0, 0, byte.MaxValue);
			array[3] = new ValueTuple<byte, byte, byte>(byte.MaxValue, byte.MaxValue, 0);
			array[4] = new ValueTuple<byte, byte, byte>(0, byte.MaxValue, byte.MaxValue);
			array[5] = new ValueTuple<byte, byte, byte>(byte.MaxValue, 0, byte.MaxValue);
			\u0002\u0005.\u0004 = array;
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x0003EADC File Offset: 0x0003CCDC
		internal static List<LineStyleMapping> \u0019(IReadOnlyCollection<ExcelLineStyleInfo> \u001F, Document \u000A)
		{
			List<LineStyleMapping> list = \u0002\u001C\u0004.\u000A();
			List<ValueTuple<string, long?>> u000A = \u0002\u0005.\u0011(\u000A);
			\u0007\u001C\u0004.\u000A(list, \u0002\u0005.\u0018());
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0019(IReadOnlyCollection<ExcelLineStyleInfo>, Document)).MethodHandle;
				}
				return list;
			}
			IEnumerator<ExcelLineStyleInfo> enumerator = \u000B\u001C\u0004.\u000A(\u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ExcelLineStyleInfo excelLineStyleInfo = \u0016\u001C\u0004.\u000A(enumerator);
					LineStyleMapping lineStyleMapping = \u0005\u001C\u0004.\u000A();
					\u0018\u001C\u0004.\u000A(lineStyleMapping, excelLineStyleInfo);
					LineStyleMapping lineStyleMapping2 = lineStyleMapping;
					string text = \u0002\u0005.\u0008(excelLineStyleInfo);
					ValueTuple<string, long?>? valueTuple = \u0002\u0005.\u001E(text, u000A);
					if (\u0019\u001C\u0004.\u000A(ref valueTuple))
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
						\u001D\u001C\u0004.\u000A(lineStyleMapping2, \u0004\u001C\u0004.\u000A(ref valueTuple).Item1);
						\u0005\u0002\u0004.\u000A(lineStyleMapping2, \u0004\u001C\u0004.\u000A(ref valueTuple).Item2);
						\u0018\u0002\u0004.\u000A(lineStyleMapping2, false);
					}
					else
					{
						\u001D\u001C\u0004.\u000A(lineStyleMapping2, text);
						\u0018\u0002\u0004.\u000A(lineStyleMapping2, true);
					}
					\u0007\u001C\u0004.\u000A(list, lineStyleMapping2);
				}
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return list;
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x0003EBFC File Offset: 0x0003CDFC
		internal static LineStyleMapping \u0018()
		{
			LineStyleMapping lineStyleMapping = \u0005\u001C\u0004.\u000A();
			\u0018\u001C\u0004.\u000A(lineStyleMapping, ExcelLineStyleInfo.Gridlines);
			\u0006\u001C\u0004.\u000A(lineStyleMapping, true);
			\u0018\u0002\u0004.\u000A(lineStyleMapping, false);
			\u001D\u001C\u0004.\u000A(lineStyleMapping, \u000F\u0015\u0010.\u001F);
			long? u000A;
			\u000B\u0019\u000E.\u001F(ref u000A);
			\u0005\u0002\u0004.\u000A(lineStyleMapping, u000A);
			return lineStyleMapping;
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x0003EC44 File Offset: 0x0003CE44
		internal static void \u0005(StyleMappingDto \u001F)
		{
			bool flag;
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0005(StyleMappingDto)).MethodHandle;
				}
				flag = (null != null);
			}
			else
			{
				flag = (\u0012\u001C\u0004.\u001D(\u001F) != null);
			}
			if (!flag)
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
				return;
			}
			bool flag2 = false;
			List<LineStyleMapping>.Enumerator enumerator = \u000D\u001C\u0004.\u000A(\u0012\u001C\u0004.\u0007(\u001F));
			try
			{
				while (\u0003\u001C\u0004.\u000A(ref enumerator))
				{
					LineStyleMapping lineStyleMapping = \u001C\u001C\u0004.\u000A(ref enumerator);
					bool flag3;
					if (lineStyleMapping == null)
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
						flag3 = (null != null);
					}
					else
					{
						flag3 = (\u000D\u0002\u0004.\u001D(lineStyleMapping) != null);
					}
					if (flag3)
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
						if (\u0017\u0001\u001D.\u001D(\u000D\u0002\u0004.\u0007(lineStyleMapping)))
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
							flag2 = true;
							goto IL_B4;
						}
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
			IL_B4:
			if (!flag2)
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
				\u000F\u001C\u0004.\u000A(\u0012\u001C\u0004.\u0007(\u001F), 0, \u0002\u0005.\u0018());
			}
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x0003ED38 File Offset: 0x0003CF38
		internal static List<TextStyleMapping> \u0016(IReadOnlyCollection<ExcelTextStyleInfo> \u001F, Document \u000A)
		{
			List<TextStyleMapping> list = \u0013\u001C\u0004.\u000A();
			List<TextNoteType> u000A = Enumerable.ToList<TextNoteType>(\u000A.GetElements<TextNoteType>());
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0016(IReadOnlyCollection<ExcelTextStyleInfo>, Document)).MethodHandle;
				}
				return list;
			}
			IEnumerator<ExcelTextStyleInfo> enumerator = \u0014\u001C\u0004.\u000A(\u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ExcelTextStyleInfo excelTextStyleInfo = \u0017\u001C\u0004.\u000A(enumerator);
					TextStyleMapping textStyleMapping = \u0020\u001C\u0004.\u000A();
					\u001E\u001C\u0004.\u000A(textStyleMapping, excelTextStyleInfo);
					TextStyleMapping textStyleMapping2 = textStyleMapping;
					double u000A2 = \u0002\u0018.\u0005(\u001B\u0006\u0004.\u0007(excelTextStyleInfo));
					string text = \u0002\u0005.\u001B(excelTextStyleInfo);
					ValueTuple<string, string>? valueTuple = \u0002\u0005.\u0020(text, u000A);
					if (\u0011\u001C\u0004.\u000A(ref valueTuple))
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
						\u0008\u001C\u0004.\u000A(textStyleMapping2, \u001B\u001C\u0004.\u000A(ref valueTuple).Item1);
						\u001C\u0006\u0004.\u000A(textStyleMapping2, \u001B\u001C\u0004.\u000A(ref valueTuple).Item2);
						\u0003\u0006\u0004.\u000A(textStyleMapping2, false);
					}
					else
					{
						\u0008\u001C\u0004.\u000A(textStyleMapping2, text);
						\u0003\u0006\u0004.\u000A(textStyleMapping2, true);
					}
					\u000E\u001C\u0004.\u000A(textStyleMapping2, u000A2);
					\u0010\u001C\u0004.\u000A(list, textStyleMapping2);
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
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return list;
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x0003EE6C File Offset: 0x0003D06C
		internal static StyleMappingDto \u000B(IReadOnlyCollection<ExcelLineStyleInfo> \u001F, IReadOnlyCollection<ExcelTextStyleInfo> \u000A, Document \u0007)
		{
			StyleMappingDto styleMappingDto = \u001F\u000D\u0004.\u000A();
			GeneralMappingSetting generalMappingSetting = \u0009\u001C\u0004.\u000A();
			\u0001\u001C\u0004.\u000A(generalMappingSetting, \u0002\u0005.\u0002(\u0007));
			\u0015\u001C\u0004.\u000A(styleMappingDto, generalMappingSetting);
			\u000C\u001C\u0004.\u000A(styleMappingDto, \u0002\u0005.\u0019(\u001F, \u0007));
			\u001A\u001C\u0004.\u000A(styleMappingDto, \u0002\u0005.\u0016(\u000A, \u0007));
			return styleMappingDto;
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x0003EEBC File Offset: 0x0003D0BC
		internal static bool \u0002(Document \u001F)
		{
			try
			{
				List<DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel> list = SchemaUtil.\u0004(\u001F);
				IEnumerable<DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel> enumerable;
				if (list == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0002(Document)).MethodHandle;
					}
					enumerable = \u0013\u0019\u000E.\u001F;
				}
				else
				{
					Func<DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel, bool> func;
					if ((func = \u0002\u0005.<>c.\u000A) == null)
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
						func = (\u0002\u0005.<>c.\u000A = new Func<DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel, bool>(\u0002\u0005.<>c.\u001F.\u0019));
					}
					enumerable = Enumerable.Where<DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel>(list, func);
				}
				IEnumerable<DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel> enumerable2 = enumerable;
				if (enumerable2 != null)
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
					if (Enumerable.Count<DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel>(enumerable2) > 0)
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
						return false;
					}
				}
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\StyleMappingHelper.cs", "ShouldDefaultToAdvancedMapping");
			}
			return true;
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x0003EF78 File Offset: 0x0003D178
		internal static void \u0006(StyleMappingDto \u001F, IReadOnlyCollection<ExcelLineStyleInfo> \u000A, IReadOnlyCollection<ExcelTextStyleInfo> \u0007, Document \u001D)
		{
			\u0002\u0005.\u0005\u0005 u0005_u = new \u0002\u0005.\u0005\u0005();
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0006(StyleMappingDto, IReadOnlyCollection<ExcelLineStyleInfo>, IReadOnlyCollection<ExcelTextStyleInfo>, Document)).MethodHandle;
				}
				return;
			}
			if (\u000A == null)
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
				\u000A = Array.Empty<ExcelLineStyleInfo>();
			}
			if (\u0007 == null)
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
				\u0007 = Array.Empty<ExcelTextStyleInfo>();
			}
			\u0002\u0005.\u0005(\u001F);
			List<LineStyleMapping> list = \u0012\u001C\u0004.\u0007(\u001F);
			List<LineStyleMapping> list2;
			if (list == null)
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
				list2 = null;
			}
			else
			{
				list2 = Enumerable.ToList<LineStyleMapping>(list);
			}
			List<LineStyleMapping> list3;
			if ((list3 = list2) == null)
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
				list3 = \u0002\u001C\u0004.\u000A();
			}
			List<LineStyleMapping> list4 = list3;
			List<TextStyleMapping> list5 = \u0005\u000D\u0004.\u0007(\u001F);
			List<TextStyleMapping> list6;
			if (list5 == null)
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
				list6 = null;
			}
			else
			{
				list6 = Enumerable.ToList<TextStyleMapping>(list5);
			}
			List<TextStyleMapping> list7;
			if ((list7 = list6) == null)
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
				list7 = \u0013\u001C\u0004.\u000A();
			}
			List<TextStyleMapping> u001F = list7;
			u0005_u.\u001F = \u0018\u000D\u0004.\u000A(LineStyleMappingComparer.Instance);
			u0005_u.\u000A = \u0019\u000D\u0004.\u000A(TextStyleMappingComparer.Instance);
			List<LineStyleMapping> list8 = \u0002\u001C\u0004.\u000A();
			object u001F2 = list4;
			Predicate<LineStyleMapping> u000A;
			if ((u000A = \u0002\u0005.<>c.\u0007) == null)
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
				u000A = (\u0002\u0005.<>c.\u0007 = new Predicate<LineStyleMapping>(\u0002\u0005.<>c.\u001F.\u0018));
			}
			LineStyleMapping lineStyleMapping;
			if ((lineStyleMapping = \u0004\u000D\u0004.\u000A(u001F2, u000A)) == null)
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
				lineStyleMapping = \u0002\u0005.\u0018();
			}
			LineStyleMapping u000A2 = lineStyleMapping;
			\u0007\u001C\u0004.\u000A(list8, u000A2);
			List<ValueTuple<string, long?>> u000A3 = \u0002\u0005.\u0011(\u001D);
			IEnumerator<ExcelLineStyleInfo> enumerator = \u000B\u001C\u0004.\u000A(\u000A);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u0002\u0005.\u0016\u0005 u0016_u = new \u0002\u0005.\u0016\u0005();
					u0016_u.\u000A = u0005_u;
					u0016_u.\u001F = \u0016\u001C\u0004.\u000A(enumerator);
					if (u0016_u.\u001F != null)
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
						if (\u0017\u0001\u001D.\u001D(u0016_u.\u001F))
						{
							continue;
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
					}
					LineStyleMapping lineStyleMapping2 = \u0004\u000D\u0004.\u000A(list4, new Predicate<LineStyleMapping>(u0016_u.\u0007));
					if (lineStyleMapping2 != null)
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
						\u001D\u000D\u0004.\u000A(u0016_u.\u000A.\u001F, lineStyleMapping2);
						\u0007\u001C\u0004.\u000A(list8, lineStyleMapping2);
					}
					else
					{
						string text = \u0002\u0005.\u0008(u0016_u.\u001F);
						ValueTuple<string, long?>? valueTuple = \u0002\u0005.\u001E(text, u000A3);
						object u001F3 = list8;
						LineStyleMapping lineStyleMapping3 = \u0005\u001C\u0004.\u000A();
						\u0018\u001C\u0004.\u000A(lineStyleMapping3, u0016_u.\u001F);
						string u000A4;
						if (!\u0019\u001C\u0004.\u000A(ref valueTuple))
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
							u000A4 = text;
						}
						else
						{
							u000A4 = \u0004\u001C\u0004.\u000A(ref valueTuple).Item1;
						}
						\u001D\u001C\u0004.\u000A(lineStyleMapping3, u000A4);
						long? u000A5;
						if (!\u0019\u001C\u0004.\u000A(ref valueTuple))
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
							long? num;
							\u000B\u0019\u000E.\u001F(ref num);
							u000A5 = num;
						}
						else
						{
							u000A5 = \u0004\u001C\u0004.\u000A(ref valueTuple).Item2;
						}
						\u0005\u0002\u0004.\u000A(lineStyleMapping3, u000A5);
						\u0018\u0002\u0004.\u000A(lineStyleMapping3, !\u0019\u001C\u0004.\u000A(ref valueTuple));
						\u0007\u001C\u0004.\u000A(u001F3, lineStyleMapping3);
					}
				}
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			\u000C\u001C\u0004.\u000A(\u001F, list8);
			List<TextStyleMapping> list9 = \u0013\u001C\u0004.\u000A();
			List<TextNoteType> u000A6 = Enumerable.ToList<TextNoteType>(\u001D.GetElements<TextNoteType>());
			IEnumerator<ExcelTextStyleInfo> enumerator2 = \u0014\u001C\u0004.\u000A(\u0007);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator2))
				{
					\u0002\u0005.\u000B\u0005 u000B_u = new \u0002\u0005.\u000B\u0005();
					u000B_u.\u000A = u0005_u;
					u000B_u.\u001F = \u0017\u001C\u0004.\u000A(enumerator2);
					TextStyleMapping textStyleMapping = \u0007\u000D\u0004.\u000A(u001F, new Predicate<TextStyleMapping>(u000B_u.\u0007));
					if (textStyleMapping != null)
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
						\u000A\u000D\u0004.\u000A(u000B_u.\u000A.\u000A, textStyleMapping);
						\u0010\u001C\u0004.\u000A(list9, textStyleMapping);
					}
					else
					{
						double u000A7 = \u0002\u0018.\u0005(\u001B\u0006\u0004.\u0007(u000B_u.\u001F));
						string text2 = \u0002\u0005.\u001B(u000B_u.\u001F);
						ValueTuple<string, string>? valueTuple2 = \u0002\u0005.\u0020(text2, u000A6);
						object u001F4 = list9;
						TextStyleMapping textStyleMapping2 = \u0020\u001C\u0004.\u000A();
						\u001E\u001C\u0004.\u000A(textStyleMapping2, u000B_u.\u001F);
						string u000A8;
						if (!\u0011\u001C\u0004.\u000A(ref valueTuple2))
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
							u000A8 = text2;
						}
						else
						{
							u000A8 = \u001B\u001C\u0004.\u000A(ref valueTuple2).Item1;
						}
						\u0008\u001C\u0004.\u000A(textStyleMapping2, u000A8);
						string u000A9;
						if (!\u0011\u001C\u0004.\u000A(ref valueTuple2))
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
							u000A9 = \u000F\u0015\u0010.\u001F;
						}
						else
						{
							u000A9 = \u001B\u001C\u0004.\u000A(ref valueTuple2).Item2;
						}
						\u001C\u0006\u0004.\u000A(textStyleMapping2, u000A9);
						\u000E\u001C\u0004.\u000A(textStyleMapping2, u000A7);
						\u0003\u0006\u0004.\u000A(textStyleMapping2, !\u0011\u001C\u0004.\u000A(ref valueTuple2));
						\u0010\u001C\u0004.\u000A(u001F4, textStyleMapping2);
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
				if (enumerator2 != null)
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
					\u001F\u0017\u000A.\u000A(enumerator2);
				}
			}
			\u001A\u001C\u0004.\u000A(\u001F, list9);
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x0003F414 File Offset: 0x0003D614
		internal static void \u000F(StyleMappingDto \u001F, StyleMappingDto \u000A, Document \u0007)
		{
			if (\u001F != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u000F(StyleMappingDto, StyleMappingDto, Document)).MethodHandle;
				}
				if (\u000A != null)
				{
					List<ValueTuple<string, long?>> u000A = \u0002\u0005.\u0011(\u0007);
					if (\u0012\u001C\u0004.\u0007(\u001F) != null)
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
						List<LineStyleMapping>.Enumerator enumerator = \u000D\u001C\u0004.\u000A(\u0012\u001C\u0004.\u0007(\u001F));
						try
						{
							while (\u0003\u001C\u0004.\u000A(ref enumerator))
							{
								LineStyleMapping lineStyleMapping = \u001C\u001C\u0004.\u000A(ref enumerator);
								ExcelLineStyleInfo u001F;
								if (lineStyleMapping == null)
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
									u001F = \u0005\u0004\u000E.\u001F;
								}
								else
								{
									u001F = \u000D\u0002\u0004.\u001D(lineStyleMapping);
								}
								LineStyleMapping lineStyleMapping2 = \u000A.\u001D(u001F);
								if (lineStyleMapping2 != null)
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
									\u001D\u001C\u0004.\u000A(lineStyleMapping, \u0010\u0002\u0004.\u0007(lineStyleMapping2));
									\u0006\u001C\u0004.\u000A(lineStyleMapping, \u001B\u0002\u0004.\u0007(lineStyleMapping2));
									ValueTuple<string, long?>? valueTuple = \u0002\u0005.\u001E(\u0010\u0002\u0004.\u0007(lineStyleMapping2), u000A);
									object u001F2 = lineStyleMapping;
									long? u000A2;
									if (!\u0019\u001C\u0004.\u000A(ref valueTuple))
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
										long? num;
										\u000B\u0019\u000E.\u001F(ref num);
										u000A2 = num;
									}
									else
									{
										u000A2 = \u0012\u000D\u0004.\u000A(ref valueTuple).Item2;
									}
									\u0005\u0002\u0004.\u000A(u001F2, u000A2);
									\u0018\u0002\u0004.\u000A(lineStyleMapping, !\u0019\u001C\u0004.\u000A(ref valueTuple));
								}
							}
							for (;;)
							{
								switch (4)
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
					List<TextNoteType> u000A3 = Enumerable.ToList<TextNoteType>(\u0007.GetElements<TextNoteType>());
					if (\u0005\u000D\u0004.\u0007(\u001F) != null)
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
						List<TextStyleMapping>.Enumerator enumerator2 = \u000F\u000D\u0004.\u000A(\u0005\u000D\u0004.\u0007(\u001F));
						try
						{
							while (\u0016\u000D\u0004.\u000A(ref enumerator2))
							{
								TextStyleMapping textStyleMapping = \u0006\u000D\u0004.\u000A(ref enumerator2);
								ExcelTextStyleInfo u001F3;
								if (textStyleMapping == null)
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
									u001F3 = \u0014\u0019\u000E.\u001F;
								}
								else
								{
									u001F3 = \u0002\u000D\u0004.\u0007(textStyleMapping);
								}
								TextStyleMapping textStyleMapping2 = \u000A.\u0004(u001F3);
								if (textStyleMapping2 != null)
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
									\u0008\u001C\u0004.\u000A(textStyleMapping, \u000E\u0006\u0004.\u0007(textStyleMapping2));
									\u000E\u001C\u0004.\u000A(textStyleMapping, \u0011\u0006\u0004.\u0007(textStyleMapping2));
									ValueTuple<string, string>? valueTuple2 = \u0002\u0005.\u0020(\u000E\u0006\u0004.\u0007(textStyleMapping2), u000A3);
									object u001F4 = textStyleMapping;
									string u000A4;
									if (!\u0011\u001C\u0004.\u000A(ref valueTuple2))
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
										u000A4 = \u000F\u0015\u0010.\u001F;
									}
									else
									{
										u000A4 = \u000B\u000D\u0004.\u000A(ref valueTuple2).Item2;
									}
									\u001C\u0006\u0004.\u000A(u001F4, u000A4);
									\u0003\u0006\u0004.\u000A(textStyleMapping, !\u0011\u001C\u0004.\u000A(ref valueTuple2));
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
							((IDisposable)enumerator2).Dispose();
						}
					}
					return;
				}
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x0003F698 File Offset: 0x0003D898
		internal static StyleMappingDto \u0012(Profile \u001F, StyleMappingDto \u000A)
		{
			bool flag;
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0012(Profile, StyleMappingDto)).MethodHandle;
				}
				flag = (null != null);
			}
			else
			{
				flag = (\u001C\u000D\u0004.\u001D(\u001F) != null);
			}
			if (!flag)
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
				StyleMappingDto result = \u000A;
				if (\u000A == null)
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
					result = \u001F\u000D\u0004.\u000A();
				}
				return result;
			}
			StyleMappingProfileTemplate styleMappingProfileTemplate = \u0017\u0019\u000E.\u001F(\u001C\u000D\u0004.\u0007(\u001F));
			if (styleMappingProfileTemplate != null)
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
				return \u0003\u000D\u0004.\u000A(styleMappingProfileTemplate);
			}
			return \u001F\u000D\u0004.\u000A();
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x0003F718 File Offset: 0x0003D918
		internal static void \u0003(StyleMappingDto \u001F, StyleMappingDto \u000A, IReadOnlyCollection<ExcelLineStyleInfo> \u0007, IReadOnlyCollection<ExcelTextStyleInfo> \u001D, Document \u0004, Profile \u0019)
		{
			if (\u001F == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0003(StyleMappingDto, StyleMappingDto, IReadOnlyCollection<ExcelLineStyleInfo>, IReadOnlyCollection<ExcelTextStyleInfo>, Document, Profile)).MethodHandle;
				}
				return;
			}
			\u0002\u0005.\u0006(\u001F, \u0007, \u001D, \u0004);
			StyleMappingDto u000A = \u0002\u0005.\u0012(\u0019, \u000A);
			\u0002\u0005.\u000F(\u001F, u000A, \u0004);
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x0003F75C File Offset: 0x0003D95C
		internal static void \u001C(Document \u001F)
		{
			\u0001\u0018.\u000A();
			\u0009\u0018.\u000A();
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x0003F774 File Offset: 0x0003D974
		internal static void \u000D(\u0020\u0019 \u001F)
		{
			bool flag;
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u000D(\u0020\u0019)).MethodHandle;
				}
				flag = (null != null);
			}
			else
			{
				flag = (\u000C\u001D\u0004.\u001D(\u001F) != null);
			}
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
				return;
			}
			if (\u0003\u0016\u0004.\u000A(\u001F) == null)
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
				\u0010\u000D\u0004.\u000A(\u001F, \u001D\u000F\u0004.\u000A());
			}
			if (\u0012\u0016\u0004.\u000A(\u001F) == null)
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
				\u000D\u000D\u0004.\u000A(\u001F, \u0007\u000F\u0004.\u000A());
			}
			List<\u001C\u0005>.Enumerator enumerator = \u0014\u001F\u0004.\u000A(\u000C\u001D\u0004.\u0007(\u001F));
			try
			{
				while (\u0004\u001F\u0004.\u000A(ref enumerator))
				{
					\u001C\u0005 u001C_u = \u0017\u001F\u0004.\u000A(ref enumerator);
					if (u001C_u != null)
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
						if (\u0004\u001D\u0004.\u000A(u001C_u) != null)
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
							\u0019\u000F\u0004.\u000A(\u0012\u0016\u0004.\u000A(\u001F), \u0004\u001D\u0004.\u000A(u001C_u));
						}
						\u000D\u0005 u000D_u = \u0005\u0007\u0004.\u000A(u001C_u);
						if (u000D_u != null)
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
							if (\u0001\u000A\u0004.\u000A(u000D_u) != null)
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
								\u0004\u000F\u0004.\u000A(\u0003\u0016\u0004.\u000A(\u001F), \u0001\u000A\u0004.\u000A(u000D_u));
							}
							if (\u0017\u000A\u0004.\u000A(u000D_u) != null)
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
								\u0004\u000F\u0004.\u000A(\u0003\u0016\u0004.\u000A(\u001F), \u0017\u000A\u0004.\u000A(u000D_u));
							}
							if (\u000C\u000A\u0004.\u000A(u000D_u) != null)
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
								\u0004\u000F\u0004.\u000A(\u0003\u0016\u0004.\u000A(\u001F), \u000C\u000A\u0004.\u000A(u000D_u));
							}
							if (\u0013\u000A\u0004.\u000A(u000D_u) != null)
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
								\u0004\u000F\u0004.\u000A(\u0003\u0016\u0004.\u000A(\u001F), \u0013\u000A\u0004.\u000A(u000D_u));
							}
						}
						\u0012\u0005 u0012_u = \u0020\u0019\u000E.\u001F(u001C_u);
						if (u0012_u != null)
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
							if (\u0020\u0001\u001D.\u000A(u0012_u) != null)
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
								\u0004\u000F\u0004.\u000A(\u0003\u0016\u0004.\u000A(\u001F), \u0020\u0001\u001D.\u000A(u0012_u));
							}
						}
					}
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x0003F9B8 File Offset: 0x0003DBB8
		internal static StyleMappingDto \u0010(StyleMappingDto \u001F, IReadOnlyCollection<ExcelLineStyleInfo> \u000A, IReadOnlyCollection<ExcelTextStyleInfo> \u0007)
		{
			\u0002\u0005.\u0018\u0005 u0018_u = new \u0002\u0005.\u0018\u0005();
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0010(StyleMappingDto, IReadOnlyCollection<ExcelLineStyleInfo>, IReadOnlyCollection<ExcelTextStyleInfo>)).MethodHandle;
				}
				return \u001F\u000D\u0004.\u000A();
			}
			StyleMappingDto styleMappingDto = \u0002\u0005.\u000E(\u001F);
			if (styleMappingDto == null)
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
				return \u001F\u000D\u0004.\u000A();
			}
			HashSet<ExcelLineStyleInfo> u001F;
			if (\u000A != null)
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
				HashSet<ExcelLineStyleInfo> hashSet = \u001D\u000F\u0004.\u000A();
				IEnumerator<ExcelLineStyleInfo> enumerator = \u000B\u001C\u0004.\u000A(\u000A);
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						ExcelLineStyleInfo u000A = \u0016\u001C\u0004.\u000A(enumerator);
						\u0004\u000F\u0004.\u000A(hashSet, u000A);
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
				}
				finally
				{
					if (enumerator != null)
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
				u001F = hashSet;
			}
			else
			{
				u001F = \u001D\u000F\u0004.\u000A();
			}
			u0018_u.\u001F = u001F;
			HashSet<ExcelTextStyleInfo> u000A3;
			if (\u0007 != null)
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
				HashSet<ExcelTextStyleInfo> hashSet2 = \u0007\u000F\u0004.\u000A();
				IEnumerator<ExcelTextStyleInfo> enumerator2 = \u0014\u001C\u0004.\u000A(\u0007);
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator2))
					{
						ExcelTextStyleInfo u000A2 = \u0017\u001C\u0004.\u000A(enumerator2);
						\u0019\u000F\u0004.\u000A(hashSet2, u000A2);
					}
					for (;;)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				finally
				{
					if (enumerator2 != null)
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
						\u001F\u0017\u000A.\u000A(enumerator2);
					}
				}
				u000A3 = hashSet2;
			}
			else
			{
				u000A3 = \u0007\u000F\u0004.\u000A();
			}
			u0018_u.\u000A = u000A3;
			if (\u0012\u001C\u0004.\u0007(styleMappingDto) != null)
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
				\u000C\u001C\u0004.\u000A(styleMappingDto, Enumerable.ToList<LineStyleMapping>(Enumerable.Where<LineStyleMapping>(\u0012\u001C\u0004.\u0007(styleMappingDto), new Func<LineStyleMapping, bool>(u0018_u.\u0007))));
			}
			if (\u0005\u000D\u0004.\u0007(styleMappingDto) != null)
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
				\u001A\u001C\u0004.\u000A(styleMappingDto, Enumerable.ToList<TextStyleMapping>(Enumerable.Where<TextStyleMapping>(\u0005\u000D\u0004.\u0007(styleMappingDto), new Func<TextStyleMapping, bool>(u0018_u.\u001D))));
			}
			return styleMappingDto;
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0003FB90 File Offset: 0x0003DD90
		internal static StyleMappingDto \u000E(StyleMappingDto \u001F)
		{
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u000E(StyleMappingDto)).MethodHandle;
				}
				return null;
			}
			StyleMappingDto result;
			try
			{
				StyleMappingDto styleMappingDto;
				if ((styleMappingDto = JsonConvert.DeserializeObject<StyleMappingDto>(\u000E\u000D\u0004.\u000A(\u001F, Formatting.None))) == null)
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
					styleMappingDto = \u001F\u000D\u0004.\u000A();
				}
				result = styleMappingDto;
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\StyleMappingHelper.cs", "CloneDto");
				result = \u001F\u000D\u0004.\u000A();
			}
			return result;
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0003FC14 File Offset: 0x0003DE14
		internal static string \u0008(ExcelLineStyleInfo \u001F)
		{
			string text = \u0002\u0005.\u0014(\u0015\u0002\u0004.\u0007(\u001F));
			string text2 = \u0002\u0005.\u0015(new System.Drawing.Color?(\u0012\u0002\u0004.\u0007(\u001F)), \u0002\u0005.\u0007, \u0002\u0005.\u001F, \u0002\u0005.\u000A);
			if (\u001D\u0017\u000A.\u000A(text2, "Black"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0008(ExcelLineStyleInfo)).MethodHandle;
				}
				text = \u0002\u0013\u000A.\u000A(text, " ", text2);
			}
			return \u0019\u0005.\u000A(\u0018\u000E\u0007.\u000A("Imported - {0} - {1}", text, \u001C\u0002\u0004.\u0007(\u001F)));
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0003FCA8 File Offset: 0x0003DEA8
		internal static string \u001B(ExcelTextStyleInfo \u001F)
		{
			double num = \u001B\u0006\u0004.\u0007(\u001F);
			string text = \u0010\u0015\u0007.\u000A(ref num);
			string text2 = \u0002\u0005.\u0015(new System.Drawing.Color?(\u0005\u001D\u0004.\u0007(\u001F)), \u0002\u0005.\u0007, \u0002\u0005.\u001F, \u0002\u0005.\u000A);
			if (\u001D\u0017\u000A.\u000A(text2, "Black"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u001B(ExcelTextStyleInfo)).MethodHandle;
				}
				text = \u0002\u0013\u000A.\u000A(text, " ", text2);
			}
			string u001F = \u001E\u0020\u001D.\u000A("Imported - ", \u0016\u001D\u0004.\u0007(\u001F), " ", text);
			if (\u0018\u001D\u0004.\u0007(\u001F))
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
				u001F = \u0004\u001E\u000A.\u000A(u001F, " Bold");
			}
			if (\u0019\u001D\u0004.\u0007(\u001F))
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
				u001F = \u0004\u001E\u000A.\u000A(u001F, " Italic");
			}
			if (\u001D\u001D\u0004.\u0007(\u001F))
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
				u001F = \u0004\u001E\u000A.\u000A(u001F, " Underline");
			}
			return \u0019\u0005.\u000A(u001F);
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x0003FDA8 File Offset: 0x0003DFA8
		[return: TupleElementNames(new string[]
		{
			"name",
			"elementId"
		})]
		private static List<ValueTuple<string, long?>> \u0011(Document \u001F)
		{
			List<ValueTuple<string, long?>> list = \u001B\u000D\u0004.\u000A();
			try
			{
				List<Category>.Enumerator enumerator = \u0020\u0002\u0004.\u000A(\u0014\u0002\u0004.\u000A(\u001F));
				try
				{
					while (\u0011\u0002\u0004.\u000A(ref enumerator))
					{
						Category u001F = \u001E\u0002\u0004.\u000A(ref enumerator);
						GraphicsStyle graphicsStyle = \u0012\u0001\u001D.\u0007(u001F, 1);
						if (graphicsStyle != null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0011(Document)).MethodHandle;
							}
							\u0008\u000D\u0004.\u000A(list, new ValueTuple<string, long?>(\u0009\u0014\u000A.\u001D(u001F), new long?(\u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(graphicsStyle)))));
						}
					}
					for (;;)
					{
						switch (4)
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
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\StyleMappingHelper.cs", "GetLineSubCategoryNameAndGraphicStyleIds");
			}
			return list;
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x0003FE80 File Offset: 0x0003E080
		[return: TupleElementNames(new string[]
		{
			"name",
			"elementId"
		})]
		private static ValueTuple<string, long?>? \u001E(string \u001F, [TupleElementNames(new string[]
		{
			"name",
			"elementId"
		})] List<ValueTuple<string, long?>> \u000A)
		{
			List<ValueTuple<string, long?>>.Enumerator enumerator = \u0020\u000D\u0004.\u000A(\u000A);
			try
			{
				while (\u0011\u000D\u0004.\u000A(ref enumerator))
				{
					ValueTuple<string, long?> valueTuple = \u001E\u000D\u0004.\u000A(ref enumerator);
					if (\u0008\u0013\u000A.\u000A(valueTuple.Item1, \u001F))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u001E(string, List<ValueTuple<string, long?>>)).MethodHandle;
						}
						return new ValueTuple<string, long?>?(new ValueTuple<string, long?>(valueTuple.Item1, valueTuple.Item2));
					}
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			ValueTuple<string, long?>? result;
			\u001E\u0019\u000E.\u001F(ref result);
			return result;
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x0003FF20 File Offset: 0x0003E120
		[return: TupleElementNames(new string[]
		{
			"name",
			"elementUniqueId"
		})]
		private static ValueTuple<string, string>? \u0020(string \u001F, List<TextNoteType> \u000A)
		{
			List<TextNoteType>.Enumerator enumerator = \u0013\u000D\u0004.\u000A(\u000A);
			try
			{
				while (\u0017\u000D\u0004.\u000A(ref enumerator))
				{
					TextNoteType u001F = \u0014\u000D\u0004.\u000A(ref enumerator);
					if (\u000D\u0008\u000A.\u000A(\u0005\u001E\u000A.\u000A(u001F), \u001F, true))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0020(string, List<TextNoteType>)).MethodHandle;
						}
						return new ValueTuple<string, string>?(new ValueTuple<string, string>(\u0005\u001E\u000A.\u000A(u001F), \u0012\u0010\u0007.\u000A(u001F)));
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
			ValueTuple<string, string>? result;
			\u0011\u0019\u000E.\u001F(ref result);
			return result;
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x0003FFC4 File Offset: 0x0003E1C4
		internal static \u000C\u0005 \u0017(ExcelLineStyle \u001F)
		{
			\u000C\u0005 result;
			if (\u000C\u000D\u0004.\u000A(\u0002\u0005.\u001D, \u001F, ref result))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0017(ExcelLineStyle)).MethodHandle;
				}
				return result;
			}
			return \u001A\u000D\u0004.\u000A(\u0002\u0005.\u001D, (ExcelLineStyle)(-1));
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x00040004 File Offset: 0x0003E204
		private static string \u0014(ExcelLineStyle \u001F)
		{
			switch (\u001F)
			{
			case ExcelLineStyle.Thin:
				return "Thin";
			case ExcelLineStyle.Medium:
				return "Medium";
			case ExcelLineStyle.Dashed:
				return "Dash";
			case ExcelLineStyle.Dotted:
				return "Dot";
			case ExcelLineStyle.Thick:
			case ExcelLineStyle.Double:
				return "Thick";
			case ExcelLineStyle.Hair:
				return "Hairline";
			case ExcelLineStyle.Medium_dashed:
				return "Medium Dash";
			case ExcelLineStyle.Dash_dot:
				return "Dash Dot";
			case ExcelLineStyle.Medium_dash_dot:
			case ExcelLineStyle.Slanted_dash_dot:
				return "Medium Dash Dot";
			case ExcelLineStyle.Dash_dot_dot:
				return "Dash Dot Dot";
			case ExcelLineStyle.Medium_dash_dot_dot:
				return "Medium Dash Dot Dot";
			}
			return "None";
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x00040098 File Offset: 0x0003E298
		internal static IReadOnlyList<LinePatternSegmentType> \u0013(ExcelLineStyle \u001F)
		{
			switch (\u001F)
			{
			case ExcelLineStyle.Dashed:
			case ExcelLineStyle.Medium_dashed:
			{
				LinePatternSegmentType[] array = \u001B\u0019\u000E.\u001F(2);
				array[1] = 1;
				return array;
			}
			case ExcelLineStyle.Dotted:
			case ExcelLineStyle.Hair:
			{
				LinePatternSegmentType[] array2 = \u001B\u0019\u000E.\u001F(2);
				array2[0] = 2;
				array2[1] = 1;
				return array2;
			}
			case ExcelLineStyle.Dash_dot:
			case ExcelLineStyle.Medium_dash_dot:
			case ExcelLineStyle.Slanted_dash_dot:
			{
				LinePatternSegmentType[] array3 = \u001B\u0019\u000E.\u001F(4);
				\u001B\u000B\u001D.\u000A(array3, fieldof(\u0001\u001B\u000A.\u0004).FieldHandle);
				return array3;
			}
			case ExcelLineStyle.Dash_dot_dot:
			case ExcelLineStyle.Medium_dash_dot_dot:
			{
				LinePatternSegmentType[] array4 = \u001B\u0019\u000E.\u001F(6);
				\u001B\u000B\u001D.\u000A(array4, fieldof(\u0001\u001B\u000A.\u001D).FieldHandle);
				return array4;
			}
			}
			return Array.Empty<LinePatternSegmentType>();
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x00040128 File Offset: 0x0003E328
		[return: TupleElementNames(new string[]
		{
			"bucket",
			"primary",
			"secondary"
		})]
		internal static ValueTuple<int, double, double> \u001A(System.Windows.Media.Color \u001F)
		{
			if (\u000A\u0010\u0004.\u000A(ref \u001F) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u001A(System.Windows.Media.Color)).MethodHandle;
				}
				if (\u001F\u0010\u0004.\u000A(ref \u001F) == 0)
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
					if (\u0009\u000D\u0004.\u000A(ref \u001F) == 0)
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
						return new ValueTuple<int, double, double>(0, 0.0, 0.0);
					}
				}
			}
			if (\u000A\u0010\u0004.\u000A(ref \u001F) == \u001F\u0010\u0004.\u000A(ref \u001F))
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
				if (\u001F\u0010\u0004.\u000A(ref \u001F) == \u0009\u000D\u0004.\u000A(ref \u001F))
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
					if (\u000A\u0010\u0004.\u000A(ref \u001F) == 255)
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
						return new ValueTuple<int, double, double>(2, 0.0, 0.0);
					}
					return new ValueTuple<int, double, double>(1, (double)\u000A\u0010\u0004.\u000A(ref \u001F), 0.0);
				}
			}
			for (int i = 0; i < \u0007\u0010\u0004.\u000A(\u0002\u0005.\u0004); i++)
			{
				ValueTuple<byte, byte, byte> valueTuple = \u001D\u0010\u0004.\u000A(\u0002\u0005.\u0004, i);
				if (\u000A\u0010\u0004.\u000A(ref \u001F) == valueTuple.Item1)
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
					if (\u001F\u0010\u0004.\u000A(ref \u001F) == valueTuple.Item2)
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
						if (\u0009\u000D\u0004.\u000A(ref \u001F) == valueTuple.Item3)
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
							return new ValueTuple<int, double, double>(3, (double)i, 0.0);
						}
					}
				}
			}
			for (;;)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			System.Drawing.Color color = \u0001\u000D\u0004.\u000A((int)\u000A\u0010\u0004.\u000A(ref \u001F), (int)\u001F\u0010\u0004.\u000A(ref \u001F), (int)\u0009\u000D\u0004.\u000A(ref \u001F));
			double item = (double)\u0015\u000D\u0004.\u000A(ref color);
			return new ValueTuple<int, double, double>(4, item, 0.0);
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x000402F4 File Offset: 0x0003E4F4
		internal static int \u000C(bool \u001F, bool \u000A, bool \u0007 = false)
		{
			if (\u001F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u000C(bool, bool, bool)).MethodHandle;
				}
				return 1;
			}
			if (\u000A)
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
				return 2;
			}
			if (\u0007)
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
				return 3;
			}
			return 0;
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x00040338 File Offset: 0x0003E538
		internal static string \u0015(System.Drawing.Color? \u001F, string \u000A, string \u0007 = "", string \u001D = "")
		{
			if (\u0020\u0006\u0004.\u000A(ref \u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0015(System.Drawing.Color?, string, string, string)).MethodHandle;
				}
				System.Drawing.Color color = \u0004\u0010\u0004.\u000A(ref \u001F);
				if (\u0015\u0017\u001D.\u000A(ref color) == 0)
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
					color = \u0004\u0010\u0004.\u000A(ref \u001F);
					if (\u000C\u0017\u001D.\u000A(ref color) == 0)
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
						color = \u0004\u0010\u0004.\u000A(ref \u001F);
						if (\u0013\u0017\u001D.\u000A(ref color) == 0)
						{
							for (;;)
							{
								switch (2)
								{
								case 0:
									continue;
								}
								goto IL_7B;
							}
						}
					}
				}
				color = \u0004\u0010\u0004.\u000A(ref \u001F);
				if (\u0015\u0017\u001D.\u000A(ref color) == 255)
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
					color = \u0004\u0010\u0004.\u000A(ref \u001F);
					if (\u000C\u0017\u001D.\u000A(ref color) == 0)
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
						color = \u0004\u0010\u0004.\u000A(ref \u001F);
						if (\u0013\u0017\u001D.\u000A(ref color) == 0)
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
							return "Red";
						}
					}
				}
				color = \u0004\u0010\u0004.\u000A(ref \u001F);
				if (\u0015\u0017\u001D.\u000A(ref color) == 0)
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
					color = \u0004\u0010\u0004.\u000A(ref \u001F);
					if (\u000C\u0017\u001D.\u000A(ref color) == 255)
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
						color = \u0004\u0010\u0004.\u000A(ref \u001F);
						if (\u0013\u0017\u001D.\u000A(ref color) == 0)
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
							return "Green";
						}
					}
				}
				color = \u0004\u0010\u0004.\u000A(ref \u001F);
				if (\u0015\u0017\u001D.\u000A(ref color) == 0)
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
					color = \u0004\u0010\u0004.\u000A(ref \u001F);
					if (\u000C\u0017\u001D.\u000A(ref color) == 0)
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
						color = \u0004\u0010\u0004.\u000A(ref \u001F);
						if (\u0013\u0017\u001D.\u000A(ref color) == 255)
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
							return "Blue";
						}
					}
				}
				color = \u0004\u0010\u0004.\u000A(ref \u001F);
				if (\u0015\u0017\u001D.\u000A(ref color) == 255)
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
					color = \u0004\u0010\u0004.\u000A(ref \u001F);
					if (\u000C\u0017\u001D.\u000A(ref color) == 255)
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
						color = \u0004\u0010\u0004.\u000A(ref \u001F);
						if (\u0013\u0017\u001D.\u000A(ref color) == 0)
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
							return "Yellow";
						}
					}
				}
				color = \u0004\u0010\u0004.\u000A(ref \u001F);
				if (\u0015\u0017\u001D.\u000A(ref color) == 0)
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
					color = \u0004\u0010\u0004.\u000A(ref \u001F);
					if (\u000C\u0017\u001D.\u000A(ref color) == 255)
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
						color = \u0004\u0010\u0004.\u000A(ref \u001F);
						if (\u0013\u0017\u001D.\u000A(ref color) == 255)
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
							return "Cyan";
						}
					}
				}
				color = \u0004\u0010\u0004.\u000A(ref \u001F);
				if (\u0015\u0017\u001D.\u000A(ref color) == 255)
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
					color = \u0004\u0010\u0004.\u000A(ref \u001F);
					if (\u000C\u0017\u001D.\u000A(ref color) == 0)
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
						color = \u0004\u0010\u0004.\u000A(ref \u001F);
						if (\u0013\u0017\u001D.\u000A(ref color) == 255)
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
							return "Magenta";
						}
					}
				}
				color = \u0004\u0010\u0004.\u000A(ref \u001F);
				if (\u0015\u0017\u001D.\u000A(ref color) == 255)
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
					color = \u0004\u0010\u0004.\u000A(ref \u001F);
					if (\u000C\u0017\u001D.\u000A(ref color) == 255)
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
						color = \u0004\u0010\u0004.\u000A(ref \u001F);
						if (\u0013\u0017\u001D.\u000A(ref color) == 255)
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
							return "White";
						}
					}
				}
				string u001F = "{0}{1}{2}{3}{4}{5}{6}";
				object[] array = \u0004\u0015\u0010.\u001F(7);
				array[0] = \u0007;
				int num = 1;
				color = \u0004\u0010\u0004.\u000A(ref \u001F);
				array[num] = \u0015\u0017\u001D.\u000A(ref color);
				array[2] = \u000A;
				int num2 = 3;
				color = \u0004\u0010\u0004.\u000A(ref \u001F);
				array[num2] = \u000C\u0017\u001D.\u000A(ref color);
				array[4] = \u000A;
				int num3 = 5;
				color = \u0004\u0010\u0004.\u000A(ref \u001F);
				array[num3] = \u0013\u0017\u001D.\u000A(ref color);
				array[6] = \u001D;
				return \u001C\u0015\u001D.\u000A(u001F, array);
			}
			IL_7B:
			return "Black";
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0004072C File Offset: 0x0003E92C
		public static void \u0001(StyleMappingDto \u001F, List<DiRoots.One.TGDatabaseLayer.SelectedExcel> \u000A)
		{
			try
			{
				List<DiRoots.One.TGDatabaseLayer.SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(\u000A);
				try
				{
					while (\u0001\u0005\u0004.\u000A(ref enumerator))
					{
						DiRoots.One.TGDatabaseLayer.SelectedExcel u001F = \u001F\u0016\u0004.\u000A(ref enumerator);
						if (\u0001\u0016\u0004.\u0007(u001F) == UpdateStates.Updated)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0001(StyleMappingDto, List<DiRoots.One.TGDatabaseLayer.SelectedExcel>)).MethodHandle;
							}
							if (\u0019\u0010\u0004.\u0007(u001F) == ActionTypes.None)
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
								\u0006\u0016\u0004.\u000A(u001F, \u0002\u0005.\u0009(u001F, \u001F));
								continue;
							}
						}
						\u0006\u0016\u0004.\u000A(u001F, false);
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
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\StyleMappingHelper.cs", "RecomputeOutOfDateFlags");
			}
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x000407F8 File Offset: 0x0003E9F8
		private static bool \u0009(DiRoots.One.TGDatabaseLayer.SelectedExcel \u001F, StyleMappingDto \u000A)
		{
			StyleMappingDto styleMappingDto;
			if ((styleMappingDto = \u000B\u0010\u0004.\u000A(\u001F)) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0009(DiRoots.One.TGDatabaseLayer.SelectedExcel, StyleMappingDto)).MethodHandle;
				}
				styleMappingDto = \u001F\u000D\u0004.\u000A();
			}
			StyleMappingDto u001F = styleMappingDto;
			GeneralMappingSetting generalMappingSetting;
			if ((generalMappingSetting = \u0009\u0004\u0004.\u0007(u001F)) == null)
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
				generalMappingSetting = \u0009\u001C\u0004.\u000A();
			}
			GeneralMappingSetting u001F2 = generalMappingSetting;
			GeneralMappingSetting generalMappingSetting2;
			if (\u000A == null)
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
				generalMappingSetting2 = null;
			}
			else
			{
				generalMappingSetting2 = \u0009\u0004\u0004.\u001D(\u000A);
			}
			GeneralMappingSetting generalMappingSetting3;
			if ((generalMappingSetting3 = generalMappingSetting2) == null)
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
				generalMappingSetting3 = \u0009\u001C\u0004.\u000A();
			}
			GeneralMappingSetting u001F3 = generalMappingSetting3;
			if (\u0001\u0004\u0004.\u0007(u001F2) != \u0001\u0004\u0004.\u0007(u001F3))
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
				return true;
			}
			if (\u0016\u0010\u0004.\u000A(u001F2) != \u0016\u0010\u0004.\u000A(u001F3))
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
				return true;
			}
			FormatOptions formatOptions = \u000A\u000B\u0004.\u0007(\u001F);
			bool flag;
			if (formatOptions == null)
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
				flag = false;
			}
			else
			{
				flag = \u001F\u000B\u0004.\u001D(formatOptions);
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
				if (\u0005\u0010\u0004.\u0007(u001F2) != \u0005\u0010\u0004.\u0007(u001F3))
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
					return true;
				}
				if (\u0018\u0010\u0004.\u000A(u001F2) != \u0018\u0010\u0004.\u000A(u001F3))
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
					return true;
				}
			}
			HashSet<ExcelLineStyleInfo> u000A = \u0002\u0005.\u001F\u000A(\u0012\u001C\u0004.\u0007(u001F));
			List<LineStyleMapping> u001F4;
			if (\u000A == null)
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
				u001F4 = null;
			}
			else
			{
				u001F4 = \u0012\u001C\u0004.\u001D(\u000A);
			}
			List<LineStyleMapping> list = \u0002\u0005.\u0007\u000A(u001F4, u000A);
			List<LineStyleMapping> u001F5 = \u0012\u001C\u0004.\u0007(u001F);
			List<LineStyleMapping> u000A2 = list;
			Func<LineStyleMapping, LineStyleMapping, bool> u;
			if ((u = \u0002\u0005.<>c.\u001D) == null)
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
				u = (\u0002\u0005.<>c.\u001D = new Func<LineStyleMapping, LineStyleMapping, bool>(\u0002\u0005.<>c.\u001F.\u0005));
			}
			if (!\u0001\u0005.\u001F<LineStyleMapping>(u001F5, u000A2, u))
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
				return true;
			}
			HashSet<ExcelTextStyleInfo> u000A3 = \u0002\u0005.\u000A\u000A(\u0005\u000D\u0004.\u0007(u001F));
			List<TextStyleMapping> u001F6;
			if (\u000A == null)
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
				u001F6 = null;
			}
			else
			{
				u001F6 = \u0005\u000D\u0004.\u001D(\u000A);
			}
			List<TextStyleMapping> list2 = \u0002\u0005.\u001D\u000A(u001F6, u000A3);
			List<TextStyleMapping> u001F7 = \u0005\u000D\u0004.\u0007(u001F);
			List<TextStyleMapping> u000A4 = list2;
			Func<TextStyleMapping, TextStyleMapping, bool> u2;
			if ((u2 = \u0002\u0005.<>c.\u0004) == null)
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
				u2 = (\u0002\u0005.<>c.\u0004 = new Func<TextStyleMapping, TextStyleMapping, bool>(\u0002\u0005.<>c.\u001F.\u0016));
			}
			if (!\u0001\u0005.\u001F<TextStyleMapping>(u001F7, u000A4, u2))
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
				return true;
			}
			return false;
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00040A14 File Offset: 0x0003EC14
		private static HashSet<ExcelLineStyleInfo> \u001F\u000A(List<LineStyleMapping> \u001F)
		{
			HashSet<ExcelLineStyleInfo> hashSet = \u001D\u000F\u0004.\u000A();
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u001F\u000A(List<LineStyleMapping>)).MethodHandle;
				}
				return hashSet;
			}
			List<LineStyleMapping>.Enumerator enumerator = \u000D\u001C\u0004.\u000A(\u001F);
			try
			{
				while (\u0003\u001C\u0004.\u000A(ref enumerator))
				{
					LineStyleMapping lineStyleMapping = \u001C\u001C\u0004.\u000A(ref enumerator);
					bool flag;
					if (lineStyleMapping == null)
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
						flag = (null != null);
					}
					else
					{
						flag = (\u000D\u0002\u0004.\u001D(lineStyleMapping) != null);
					}
					if (flag)
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
						\u0004\u000F\u0004.\u000A(hashSet, \u000D\u0002\u0004.\u0007(lineStyleMapping));
					}
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return hashSet;
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00040AC4 File Offset: 0x0003ECC4
		private static HashSet<ExcelTextStyleInfo> \u000A\u000A(List<TextStyleMapping> \u001F)
		{
			HashSet<ExcelTextStyleInfo> hashSet = \u0007\u000F\u0004.\u000A();
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u000A\u000A(List<TextStyleMapping>)).MethodHandle;
				}
				return hashSet;
			}
			List<TextStyleMapping>.Enumerator enumerator = \u000F\u000D\u0004.\u000A(\u001F);
			try
			{
				while (\u0016\u000D\u0004.\u000A(ref enumerator))
				{
					TextStyleMapping textStyleMapping = \u0006\u000D\u0004.\u000A(ref enumerator);
					bool flag;
					if (textStyleMapping == null)
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
						flag = (null != null);
					}
					else
					{
						flag = (\u0002\u000D\u0004.\u0007(textStyleMapping) != null);
					}
					if (flag)
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
						\u0019\u000F\u0004.\u000A(hashSet, \u0002\u000D\u0004.\u001D(textStyleMapping));
					}
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return hashSet;
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00040B74 File Offset: 0x0003ED74
		private static List<LineStyleMapping> \u0007\u000A(List<LineStyleMapping> \u001F, HashSet<ExcelLineStyleInfo> \u000A)
		{
			List<LineStyleMapping> list = \u0002\u001C\u0004.\u000A();
			if (\u001F == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0007\u000A(List<LineStyleMapping>, HashSet<ExcelLineStyleInfo>)).MethodHandle;
				}
				return list;
			}
			List<LineStyleMapping>.Enumerator enumerator = \u000D\u001C\u0004.\u000A(\u001F);
			try
			{
				while (\u0003\u001C\u0004.\u000A(ref enumerator))
				{
					LineStyleMapping lineStyleMapping = \u001C\u001C\u0004.\u000A(ref enumerator);
					bool flag;
					if (lineStyleMapping == null)
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
						flag = (null != null);
					}
					else
					{
						flag = (\u000D\u0002\u0004.\u001D(lineStyleMapping) != null);
					}
					if (flag)
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
						if (!\u0017\u0001\u001D.\u001D(\u000D\u0002\u0004.\u0007(lineStyleMapping)))
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
							if (!\u0002\u0010\u0004.\u000A(\u000A, \u000D\u0002\u0004.\u0007(lineStyleMapping)))
							{
								continue;
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
						}
						\u0007\u001C\u0004.\u000A(list, lineStyleMapping);
					}
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00040C50 File Offset: 0x0003EE50
		private static List<TextStyleMapping> \u001D\u000A(List<TextStyleMapping> \u001F, HashSet<ExcelTextStyleInfo> \u000A)
		{
			List<TextStyleMapping> list = \u0013\u001C\u0004.\u000A();
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u001D\u000A(List<TextStyleMapping>, HashSet<ExcelTextStyleInfo>)).MethodHandle;
				}
				return list;
			}
			List<TextStyleMapping>.Enumerator enumerator = \u000F\u000D\u0004.\u000A(\u001F);
			try
			{
				while (\u0016\u000D\u0004.\u000A(ref enumerator))
				{
					TextStyleMapping textStyleMapping = \u0006\u000D\u0004.\u000A(ref enumerator);
					bool flag;
					if (textStyleMapping == null)
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
						flag = (null != null);
					}
					else
					{
						flag = (\u0002\u000D\u0004.\u0007(textStyleMapping) != null);
					}
					if (flag)
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
						if (\u0006\u0010\u0004.\u000A(\u000A, \u0002\u000D\u0004.\u001D(textStyleMapping)))
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
							\u0010\u001C\u0004.\u000A(list, textStyleMapping);
						}
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

		// Token: 0x0400037B RID: 891
		private static string \u001F = "RGB(";

		// Token: 0x0400037C RID: 892
		private static string \u000A = ")";

		// Token: 0x0400037D RID: 893
		private static string \u0007 = "-";

		// Token: 0x0400037E RID: 894
		private static Dictionary<ExcelLineStyle, \u000C\u0005> \u001D;

		// Token: 0x0400037F RID: 895
		[TupleElementNames(new string[]
		{
			"R",
			"G",
			"B"
		})]
		private static readonly IReadOnlyList<ValueTuple<byte, byte, byte>> \u0004;

		// Token: 0x020007FF RID: 2047
		[CompilerGenerated]
		private sealed class \u0018\u0005
		{
			// Token: 0x06004D5B RID: 19803 RVA: 0x001DE224 File Offset: 0x001DC424
			internal bool \u0007(LineStyleMapping \u001F)
			{
				bool flag;
				if (\u001F == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0018\u0005.\u0007(LineStyleMapping)).MethodHandle;
					}
					flag = (null != null);
				}
				else
				{
					flag = (\u000D\u0002\u0004.\u001D(\u001F) != null);
				}
				if (!flag)
				{
					return false;
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
				if (!\u0017\u0001\u001D.\u001D(\u000D\u0002\u0004.\u0007(\u001F)))
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
					return \u0002\u0010\u0004.\u000A(this.\u001F, \u000D\u0002\u0004.\u0007(\u001F));
				}
				return true;
			}

			// Token: 0x06004D5C RID: 19804 RVA: 0x001DE294 File Offset: 0x001DC494
			internal bool \u001D(TextStyleMapping \u001F)
			{
				bool flag;
				if (\u001F == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0018\u0005.\u001D(TextStyleMapping)).MethodHandle;
					}
					flag = (null != null);
				}
				else
				{
					flag = (\u0002\u000D\u0004.\u0007(\u001F) != null);
				}
				if (flag)
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
					return \u0006\u0010\u0004.\u000A(this.\u000A, \u0002\u000D\u0004.\u001D(\u001F));
				}
				return false;
			}

			// Token: 0x04002031 RID: 8241
			public HashSet<ExcelLineStyleInfo> \u001F;

			// Token: 0x04002032 RID: 8242
			public HashSet<ExcelTextStyleInfo> \u000A;
		}

		// Token: 0x02000800 RID: 2048
		[CompilerGenerated]
		private sealed class \u0005\u0005
		{
			// Token: 0x04002033 RID: 8243
			public HashSet<LineStyleMapping> \u001F;

			// Token: 0x04002034 RID: 8244
			public HashSet<TextStyleMapping> \u000A;
		}

		// Token: 0x02000801 RID: 2049
		[CompilerGenerated]
		private sealed class \u0016\u0005
		{
			// Token: 0x06004D5F RID: 19807 RVA: 0x001DE310 File Offset: 0x001DC510
			internal bool \u0007(LineStyleMapping \u001F)
			{
				if (\u001F != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u0016\u0005.\u0007(LineStyleMapping)).MethodHandle;
					}
					if (!\u0012\u001F\u0010.\u000A(this.\u000A.\u001F, \u001F))
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
						if (\u000D\u0002\u0004.\u0007(\u001F) != null)
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
							if (!\u0017\u0001\u001D.\u001D(\u000D\u0002\u0004.\u0007(\u001F)))
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
								return \u000A\u0009\u001D.\u0007(\u000D\u0002\u0004.\u0007(\u001F), this.\u001F);
							}
						}
					}
				}
				return false;
			}

			// Token: 0x04002035 RID: 8245
			public ExcelLineStyleInfo \u001F;

			// Token: 0x04002036 RID: 8246
			public \u0002\u0005.\u0005\u0005 \u000A;
		}

		// Token: 0x02000802 RID: 2050
		[CompilerGenerated]
		private sealed class \u000B\u0005
		{
			// Token: 0x06004D61 RID: 19809 RVA: 0x001DE3B0 File Offset: 0x001DC5B0
			internal bool \u0007(TextStyleMapping \u001F)
			{
				if (\u001F != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0005.\u000B\u0005.\u0007(TextStyleMapping)).MethodHandle;
					}
					if (!\u0003\u001F\u0010.\u000A(this.\u000A.\u000A, \u001F))
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
						if (\u0002\u000D\u0004.\u001D(\u001F) != null)
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
							return \u001D\u0020\u0004.\u001D(\u0002\u000D\u0004.\u001D(\u001F), this.\u001F);
						}
					}
				}
				return false;
			}

			// Token: 0x04002037 RID: 8247
			public ExcelTextStyleInfo \u001F;

			// Token: 0x04002038 RID: 8248
			public \u0002\u0005.\u0005\u0005 \u000A;
		}
	}
}

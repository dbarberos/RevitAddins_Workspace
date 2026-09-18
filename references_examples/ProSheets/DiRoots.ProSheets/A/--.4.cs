using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Enums;
using ProSheets.Helpers;
using ProSheets.Models;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x020000D1 RID: 209
	internal static class \u0009\u001F\u0018
	{
		// Token: 0x06000B3E RID: 2878 RVA: 0x000431FC File Offset: 0x000413FC
		public static void \u000C(bool \u000C, string \u0018, DateTime \u0014, DateTime \u0003, DateTime \u0016, DateTime \u000F, DateTime \u0012, DateTime \u000D, DateTime \u001C, DateTime \u0013)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\ReportHandler.cs", "ExportReporttoExcel");
			ExcelEngine excelEngine = \u0012\u0020\u0016.\u0018();
			try
			{
				int u = 1;
				int u2 = 2;
				int u3 = 3;
				int u4 = 4;
				int u5 = 5;
				int u6 = 6;
				int u7 = 7;
				int num = 8;
				int u8 = 10;
				int u9 = 11;
				int u10 = 12;
				int u11 = 13;
				string text = \u0009\u001F\u0018.\u0003();
				if (!\u000C\u001A\u0018.\u0018(text))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u001F\u0018.\u000C(bool, string, DateTime, DateTime, DateTime, DateTime, DateTime, DateTime, DateTime, DateTime)).MethodHandle;
					}
					return;
				}
				IApplication u000C = \u000F\u0020\u0016.\u0018(excelEngine);
				\u0016\u0020\u0016.\u0018(u000C, ExcelVersion.Excel2013);
				IWorkbook workbook = \u0014\u0020\u0016.\u0018(\u0003\u0020\u0016.\u0018(u000C), text);
				if (workbook != null)
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
					try
					{
						\u0018\u0020\u0016.\u0018(workbook);
						IWorksheet u000C2 = \u000C\u0020\u0016.\u0018(\u0018\u0020\u0016.\u0018(workbook), 0);
						TimeSpan timeSpan = \u0019\u000A\u0016.\u0018(\u0003, \u0014);
						string u12 = \u0007\u000C\u0003.\u0018("{0}:{1}:{2}", \u000B\u000A\u0016.\u0018(ref timeSpan), \u001A\u000A\u0016.\u0018(ref timeSpan), \u001D\u000A\u0016.\u0018(ref timeSpan));
						\u0017\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), 2, u8), u12);
						\u0017\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), 2, u9), \u000E\u000A\u0016.\u0018(ref \u0014));
						object u000C3 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), 2, u9);
						string[] array = \u000C\u0002\u000F.\u000C(5);
						int num2 = 0;
						int i = \u0004\u000C\u0016.\u0018(ref \u0014);
						array[num2] = \u0010\u001E\u0018.\u0018(ref i);
						array[1] = "/";
						int num3 = 2;
						i = \u0002\u000C\u0016.\u0018(ref \u0014);
						array[num3] = \u0010\u001E\u0018.\u0018(ref i);
						array[3] = "/";
						int num4 = 4;
						i = \u0017\u000C\u0016.\u0018(ref \u0014);
						array[num4] = \u0010\u001E\u0018.\u0018(ref i);
						\u0017\u000A\u0016.\u0018(u000C3, \u000F\u001D\u0018.\u0018(array));
						\u0017\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), 2, u10), \u0005\u000A\u0016.\u0018(ref \u0014));
						\u0017\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), 2, u11), \u0005\u000A\u0016.\u0018(ref \u0003));
						IEnumerable<SheetInfo> enumerable = \u001C\u0017\u0014.\u0018();
						Func<SheetInfo, bool> func;
						if ((func = \u0009\u001F\u0018.<>c.\u0018) == null)
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
							func = (\u0009\u001F\u0018.<>c.\u0018 = new Func<SheetInfo, bool>(\u0009\u001F\u0018.<>c.\u000C.\u001C));
						}
						List<SheetInfo> list = Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable, func));
						IEnumerable<SheetInfo> enumerable2 = \u001C\u0017\u0014.\u0018();
						Func<SheetInfo, bool> func2;
						if ((func2 = \u0009\u001F\u0018.<>c.\u0014) == null)
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
							func2 = (\u0009\u001F\u0018.<>c.\u0014 = new Func<SheetInfo, bool>(\u0009\u001F\u0018.<>c.\u000C.\u0013));
						}
						List<SheetInfo> list2 = Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable2, func2));
						IEnumerable<SheetInfo> enumerable3 = \u001C\u0017\u0014.\u0018();
						Func<SheetInfo, bool> func3;
						if ((func3 = \u0009\u001F\u0018.<>c.\u0003) == null)
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
							func3 = (\u0009\u001F\u0018.<>c.\u0003 = new Func<SheetInfo, bool>(\u0009\u001F\u0018.<>c.\u000C.\u0009));
						}
						List<SheetInfo> list3 = Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable3, func3));
						IEnumerable<SheetInfo> enumerable4 = \u001C\u0017\u0014.\u0018();
						Func<SheetInfo, bool> func4;
						if ((func4 = \u0009\u001F\u0018.<>c.\u0016) == null)
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
							func4 = (\u0009\u001F\u0018.<>c.\u0016 = new Func<SheetInfo, bool>(\u0009\u001F\u0018.<>c.\u000C.\u000A));
						}
						List<SheetInfo> list4 = Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable4, func4));
						IEnumerable<SheetInfo> enumerable5 = \u001C\u0017\u0014.\u0018();
						Func<SheetInfo, bool> func5;
						if ((func5 = \u0009\u001F\u0018.<>c.\u000F) == null)
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
							func5 = (\u0009\u001F\u0018.<>c.\u000F = new Func<SheetInfo, bool>(\u0009\u001F\u0018.<>c.\u000C.\u0020));
						}
						List<SheetInfo> list5 = Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable5, func5));
						IEnumerable<SheetInfo> enumerable6 = \u001C\u0017\u0014.\u0018();
						Func<SheetInfo, bool> func6;
						if ((func6 = \u0009\u001F\u0018.<>c.\u0012) == null)
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
							func6 = (\u0009\u001F\u0018.<>c.\u0012 = new Func<SheetInfo, bool>(\u0009\u001F\u0018.<>c.\u000C.\u001F));
						}
						List<SheetInfo> list6 = Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable6, func6));
						IEnumerable<SheetInfo> enumerable7 = \u001C\u0017\u0014.\u0018();
						Func<SheetInfo, bool> func7;
						if ((func7 = \u0009\u001F\u0018.<>c.\u000D) == null)
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
							func7 = (\u0009\u001F\u0018.<>c.\u000D = new Func<SheetInfo, bool>(\u0009\u001F\u0018.<>c.\u000C.\u0011));
						}
						List<SheetInfo> u000C4 = Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable7, func7));
						int num5 = 3;
						if (\u0002\u0005\u0018.\u0018(list) > 0)
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
							if (\u000B\u0017\u0014.\u0018())
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
								IRange u000C5 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u2);
								\u0017\u000A\u0016.\u0018(u000C5, "PDF");
								\u0009\u001F\u0018.\u0016(u000C5);
								IRange u000C6 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u3);
								\u0017\u000A\u0016.\u0018(u000C6, "pdf");
								\u0009\u001F\u0018.\u0016(u000C6);
								IRange u000C7 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u4);
								if (\u0001\u000A\u0016.\u0018())
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
									\u0017\u000A\u0016.\u0018(u000C7, \u001B\u000A\u0016.\u0018());
								}
								else
								{
									\u0017\u000A\u0016.\u0018(u000C7, \u000A\u0010\u0014.\u0018(\u000F\u000C\u0003.\u0018(list, 0)));
								}
								\u0009\u001F\u0018.\u0016(u000C7);
								IRange u000C8 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u5);
								\u0017\u000A\u0016.\u0018(u000C8, \u0004\u0017\u0014.\u0018(\u000F\u000C\u0003.\u0018(list, 0)));
								\u0009\u001F\u0018.\u0016(u000C8);
								IRange u000C9 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u6);
								if (\u0001\u000A\u0016.\u0018())
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
									\u0017\u000A\u0016.\u0018(u000C9, \u0008\u000A\u0016.\u0018());
								}
								else
								{
									\u0017\u000A\u0016.\u0018(u000C9, \u0014\u001B\u0014.\u0014(\u000F\u000C\u0003.\u0018(list, 0)));
								}
								\u0009\u001F\u0018.\u0016(u000C9);
								IRange u000C10 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u7);
								TimeSpan timeSpan2 = \u0019\u000A\u0016.\u0018(\u000F, \u0016);
								string u13 = \u0007\u000C\u0003.\u0018("{0}:{1}:{2}", \u000B\u000A\u0016.\u0018(ref timeSpan2), \u001A\u000A\u0016.\u0018(ref timeSpan2), \u001D\u000A\u0016.\u0018(ref timeSpan2));
								\u0017\u000A\u0016.\u0018(u000C10, u13);
								\u0009\u001F\u0018.\u0016(u000C10);
								IRange u000C11 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, num);
								string text2;
								if (\u0002\u000A\u0016.\u0018(\u000F\u000C\u0003.\u0018(list, 0)) != PublishStatus.Success)
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
									text2 = \u000D\u0009\u0018.\u000C;
								}
								else
								{
									text2 = \u000D\u0009\u0018.\u001F;
								}
								string u14 = text2;
								Color color;
								if (\u0002\u000A\u0016.\u0018(\u000F\u000C\u0003.\u0018(list, 0)) != PublishStatus.Success)
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
									color = \u001E\u000A\u0016.\u0018(192, 0, 0);
								}
								else
								{
									color = \u001E\u000A\u0016.\u0018(146, 208, 80);
								}
								Color u15 = color;
								\u0017\u000A\u0016.\u0018(u000C11, u14);
								\u0015\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C11), u15);
								\u001F\u000A\u0016.\u0018(\u0011\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C11)), \u0020\u000A\u0016.\u0018());
								\u000A\u000A\u0016.\u0018(u000C11, ExcelLineStyle.Thin, \u0020\u000A\u0016.\u0018());
								num5++;
							}
							else
							{
								\u0009\u001F\u0018.\u0018(u000C2, ref num5, list, "PDF", "pdf");
							}
							IRange u000C12 = \u0013\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u2, num5, num);
							\u001C\u000A\u0016.\u0018(u000C12);
							\u0012\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C12), ExcelVAlign.VAlignCenter);
							num5++;
						}
						if (\u0002\u0005\u0018.\u0018(list2) > 0)
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
							\u0009\u001F\u0018.\u0018(u000C2, ref num5, list2, "DWG", "dwg");
							IRange u000C13 = \u0013\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u2, num5, num);
							\u001C\u000A\u0016.\u0018(u000C13);
							\u0012\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C13), ExcelVAlign.VAlignCenter);
							num5++;
						}
						if (\u0002\u0005\u0018.\u0018(list3) > 0)
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
							\u0009\u001F\u0018.\u0018(u000C2, ref num5, list3, "DGN", "dgn");
							IRange u000C14 = \u0013\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u2, num5, num);
							\u001C\u000A\u0016.\u0018(u000C14);
							\u0012\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C14), ExcelVAlign.VAlignCenter);
							num5++;
						}
						if (\u0002\u0005\u0018.\u0018(list4) > 0)
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
							string text3;
							if (!\u0015\u0017\u0014.\u0018())
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
								text3 = "dwf";
							}
							else
							{
								text3 = "dwfx";
							}
							string text4 = text3;
							if (\u0017\u0017\u0014.\u0018())
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
								IRange u000C15 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u2);
								\u0017\u000A\u0016.\u0018(u000C15, "DWF");
								\u0009\u001F\u0018.\u0016(u000C15);
								IRange u000C16 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u3);
								\u0017\u000A\u0016.\u0018(u000C16, text4);
								\u0009\u001F\u0018.\u0016(u000C16);
								IRange u000C17 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u4);
								\u0017\u000A\u0016.\u0018(u000C17, \u000A\u0010\u0014.\u0018(\u000F\u000C\u0003.\u0018(list4, 0)));
								\u0009\u001F\u0018.\u0016(u000C17);
								IRange u000C18 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u5);
								\u0017\u000A\u0016.\u0018(u000C18, \u0004\u0017\u0014.\u0018(\u000F\u000C\u0003.\u0018(list4, 0)));
								\u0009\u001F\u0018.\u0016(u000C18);
								IRange u000C19 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u6);
								\u0017\u000A\u0016.\u0018(u000C19, \u0014\u001B\u0014.\u0014(\u000F\u000C\u0003.\u0018(list4, 0)));
								\u0009\u001F\u0018.\u0016(u000C19);
								IRange u000C20 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u7);
								TimeSpan timeSpan3 = \u0019\u000A\u0016.\u0018(\u000D, \u0012);
								string u16 = \u0007\u000C\u0003.\u0018("{0}:{1}:{2}", \u000B\u000A\u0016.\u0018(ref timeSpan3), \u001A\u000A\u0016.\u0018(ref timeSpan3), \u001D\u000A\u0016.\u0018(ref timeSpan3));
								\u0017\u000A\u0016.\u0018(u000C20, u16);
								\u0009\u001F\u0018.\u0016(u000C20);
								IRange u000C21 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, num);
								string text5;
								if (\u0002\u000A\u0016.\u0018(\u000F\u000C\u0003.\u0018(list4, 0)) != PublishStatus.Success)
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
									text5 = \u000D\u0009\u0018.\u000C;
								}
								else
								{
									text5 = \u000D\u0009\u0018.\u001F;
								}
								string u17 = text5;
								Color color2;
								if (\u0002\u000A\u0016.\u0018(\u000F\u000C\u0003.\u0018(list4, 0)) != PublishStatus.Success)
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
									color2 = \u001E\u000A\u0016.\u0018(192, 0, 0);
								}
								else
								{
									color2 = \u001E\u000A\u0016.\u0018(146, 208, 80);
								}
								Color u18 = color2;
								\u0017\u000A\u0016.\u0018(u000C21, u17);
								\u0015\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C21), u18);
								\u001F\u000A\u0016.\u0018(\u0011\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C21)), \u0020\u000A\u0016.\u0018());
								\u000A\u000A\u0016.\u0018(u000C21, ExcelLineStyle.Thin, \u0020\u000A\u0016.\u0018());
								num5++;
							}
							else
							{
								\u0009\u001F\u0018.\u0018(u000C2, ref num5, list4, "DWF", text4);
							}
							IRange u000C22 = \u0013\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u2, num5, num);
							\u001C\u000A\u0016.\u0018(u000C22);
							\u0012\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C22), ExcelVAlign.VAlignCenter);
							num5++;
						}
						if (\u0002\u0005\u0018.\u0018(list5) > 0)
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
							\u0009\u001F\u0018.\u0018(u000C2, ref num5, list5, "NWC", "nwc");
							IRange u000C23 = \u0013\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u2, num5, num);
							\u001C\u000A\u0016.\u0018(u000C23);
							\u0012\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C23), ExcelVAlign.VAlignCenter);
							num5++;
						}
						if (\u0002\u0005\u0018.\u0018(list6) > 0)
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
							\u0009\u001F\u0018.\u0018(u000C2, ref num5, list6, "IFC", \u0014\u000E\u0014.\u0018().ToString());
							\u0009\u001F\u0018.\u0018(u000C2, ref num5, \u0006\u000A\u0016.\u0018(), "IFC", \u0014\u000E\u0014.\u0018().ToString());
							IRange u000C24 = \u0013\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u2, num5, num);
							\u001C\u000A\u0016.\u0018(u000C24);
							\u0012\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C24), ExcelVAlign.VAlignCenter);
							num5++;
						}
						if (\u0002\u0005\u0018.\u0018(u000C4) > 0)
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
							if (\u0020\u0017\u0014.\u0018())
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
								IRange u000C25 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u2);
								\u0017\u000A\u0016.\u0018(u000C25, "IMG");
								\u0009\u001F\u0018.\u0016(u000C25);
								IRange u000C26 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u3);
								\u0017\u000A\u0016.\u0018(u000C26, "html");
								\u0009\u001F\u0018.\u0016(u000C26);
								IRange u000C27 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u4);
								\u0017\u000A\u0016.\u0018(u000C27, \u000A\u0010\u0014.\u0018(\u000F\u000C\u0003.\u0018(u000C4, 0)));
								\u0009\u001F\u0018.\u0016(u000C27);
								IRange u000C28 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u5);
								string u19 = "";
								if (\u000C\u001A\u0018.\u0018(\u0014\u001B\u0014.\u0014(\u000F\u000C\u0003.\u0018(u000C4, 0))))
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
									u19 = \u0009\u001F\u0018.\u0014(\u0001\u001E\u0014.\u0018(\u001B\u001E\u0014.\u0018(\u0014\u001B\u0014.\u0014(\u000F\u000C\u0003.\u0018(u000C4, 0)))));
								}
								\u0017\u000A\u0016.\u0018(u000C28, u19);
								\u0009\u001F\u0018.\u0016(u000C28);
								IRange u000C29 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u6);
								\u0017\u000A\u0016.\u0018(u000C29, \u0014\u001B\u0014.\u0014(\u000F\u000C\u0003.\u0018(u000C4, 0)));
								\u0009\u001F\u0018.\u0016(u000C29);
								IRange u000C30 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u7);
								TimeSpan timeSpan4 = \u0019\u000A\u0016.\u0018(\u0013, \u001C);
								string u20 = \u0007\u000C\u0003.\u0018("{0}:{1}:{2}", \u000B\u000A\u0016.\u0018(ref timeSpan4), \u001A\u000A\u0016.\u0018(ref timeSpan4), \u001D\u000A\u0016.\u0018(ref timeSpan4));
								\u0017\u000A\u0016.\u0018(u000C30, u20);
								\u0009\u001F\u0018.\u0016(u000C30);
								IRange u000C31 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, num);
								string text6;
								if (\u0002\u000A\u0016.\u0018(\u000F\u000C\u0003.\u0018(u000C4, 0)) != PublishStatus.Success)
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
									text6 = \u000D\u0009\u0018.\u000C;
								}
								else
								{
									text6 = \u000D\u0009\u0018.\u001F;
								}
								string u21 = text6;
								Color color3;
								if (\u0002\u000A\u0016.\u0018(\u000F\u000C\u0003.\u0018(u000C4, 0)) != PublishStatus.Success)
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
									color3 = \u001E\u000A\u0016.\u0018(192, 0, 0);
								}
								else
								{
									color3 = \u001E\u000A\u0016.\u0018(146, 208, 80);
								}
								Color u22 = color3;
								\u0017\u000A\u0016.\u0018(u000C31, u21);
								\u0015\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C31), u22);
								\u001F\u000A\u0016.\u0018(\u0011\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C31)), \u0020\u000A\u0016.\u0018());
								\u000A\u000A\u0016.\u0018(u000C31, ExcelLineStyle.Thin, \u0020\u000A\u0016.\u0018());
								num5++;
							}
							else
							{
								List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(u000C4);
								try
								{
									while (\u0019\u000E\u0018.\u0018(ref enumerator))
									{
										SheetInfo u000C32 = \u000C\u000C\u0014.\u0018(ref enumerator);
										IRange u000C33 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u);
										\u0017\u000A\u0016.\u0018(u000C33, \u0002\u000E\u0018.\u0014(u000C32));
										\u0009\u001F\u0018.\u0016(u000C33);
										IRange u000C34 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u2);
										\u0017\u000A\u0016.\u0018(u000C34, "Images");
										\u0009\u001F\u0018.\u0016(u000C34);
										IRange range = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u3);
										try
										{
											object u000C35 = range;
											object u000C36 = \u000A\u0010\u0014.\u0018(u000C32);
											char[] array2 = \u0020\u0002\u000F.\u000C(1);
											array2[0] = '.';
											\u0017\u000A\u0016.\u0018(u000C35, Enumerable.LastOrDefault<string>(\u0011\u001C\u0003.\u0018(u000C36, array2)));
										}
										catch
										{
										}
										\u0009\u001F\u0018.\u0016(range);
										IRange u000C37 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u4);
										\u0017\u000A\u0016.\u0018(u000C37, \u000A\u0010\u0014.\u0018(u000C32));
										\u0009\u001F\u0018.\u0016(u000C37);
										IRange u000C38 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u5);
										string u23 = "";
										if (\u000C\u001A\u0018.\u0018(\u0014\u001B\u0014.\u0014(\u000F\u000C\u0003.\u0018(u000C4, 0))))
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
											u23 = \u0009\u001F\u0018.\u0014(\u0001\u001E\u0014.\u0018(\u001B\u001E\u0014.\u0018(\u0014\u001B\u0014.\u0014(\u000F\u000C\u0003.\u0018(u000C4, 0)))));
										}
										\u0017\u000A\u0016.\u0018(u000C38, u23);
										\u0009\u001F\u0018.\u0016(u000C38);
										IRange u000C39 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u6);
										\u0017\u000A\u0016.\u0018(u000C39, \u0014\u001B\u0014.\u0014(u000C32));
										\u0009\u001F\u0018.\u0016(u000C39);
										IRange u000C40 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u7);
										TimeSpan timeSpan5 = \u0019\u000A\u0016.\u0018(\u0010\u000A\u0016.\u0018(u000C32), \u0007\u000A\u0016.\u0018(u000C32));
										string u24 = \u0007\u000C\u0003.\u0018("{0}:{1}:{2}", \u000B\u000A\u0016.\u0018(ref timeSpan5), \u001A\u000A\u0016.\u0018(ref timeSpan5), \u001D\u000A\u0016.\u0018(ref timeSpan5));
										\u0017\u000A\u0016.\u0018(u000C40, u24);
										\u0009\u001F\u0018.\u0016(u000C40);
										IRange u000C41 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, num);
										string text7;
										if (\u0002\u000A\u0016.\u0018(u000C32) != PublishStatus.Success)
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
											text7 = \u000D\u0009\u0018.\u000C;
										}
										else
										{
											text7 = \u000D\u0009\u0018.\u001F;
										}
										string u25 = text7;
										Color color4;
										if (\u0002\u000A\u0016.\u0018(u000C32) != PublishStatus.Success)
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
											color4 = \u001E\u000A\u0016.\u0018(192, 0, 0);
										}
										else
										{
											color4 = \u001E\u000A\u0016.\u0018(146, 208, 80);
										}
										Color u26 = color4;
										\u0017\u000A\u0016.\u0018(u000C41, u25);
										\u0015\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C41), u26);
										\u001F\u000A\u0016.\u0018(\u0011\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C41)), \u0020\u000A\u0016.\u0018());
										\u000A\u000A\u0016.\u0018(u000C41, ExcelLineStyle.Thin, \u0020\u000A\u0016.\u0018());
										num5++;
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
							}
							IRange u000C42 = \u0013\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C2), num5, u2, num5, num);
							\u001C\u000A\u0016.\u0018(u000C42);
							\u0012\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C42), ExcelVAlign.VAlignCenter);
						}
						int num6 = 1;
						IRange[] array3 = \u000F\u000A\u0016.\u0018(u000C2);
						for (i = 0; i < (int)\u001F\u0010\u000F.\u000C(array3); i++)
						{
							IRange range2 = array3[i];
							\u0016\u000A\u0016.\u0018(u000C2, num6);
							num6++;
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
						if (\u000C)
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
							\u0003\u000A\u0016.\u0018(u000C2, \u0018, ",");
						}
						else
						{
							\u0014\u000A\u0016.\u0018(workbook, \u0018);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
			}
			finally
			{
				if (excelEngine != null)
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
					\u0020\u001E\u0018.\u0018(excelEngine);
				}
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\ReportHandler.cs", "ExportReporttoExcel");
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x00044350 File Offset: 0x00042550
		private unsafe static void \u0018(IWorksheet \u000C, ref int \u0018, List<SheetInfo> \u0014, string \u0003, string \u0016)
		{
			int u = 1;
			int u2 = 2;
			int u3 = 3;
			int u4 = 4;
			int u5 = 5;
			int u6 = 6;
			int u7 = 7;
			int u8 = 8;
			List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u0014);
			try
			{
				while (\u0019\u000E\u0018.\u0018(ref enumerator))
				{
					SheetInfo u000C = \u000C\u000C\u0014.\u0018(ref enumerator);
					IRange u000C2 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(\u000C), \u0018, u);
					\u0017\u000A\u0016.\u0018(u000C2, \u0002\u000E\u0018.\u0014(u000C));
					\u0009\u001F\u0018.\u0016(u000C2);
					IRange u000C3 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(\u000C), \u0018, u2);
					\u0017\u000A\u0016.\u0018(u000C3, \u0003);
					\u0009\u001F\u0018.\u0016(u000C3);
					IRange u000C4 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(\u000C), \u0018, u3);
					\u0017\u000A\u0016.\u0018(u000C4, \u0016);
					\u0009\u001F\u0018.\u0016(u000C4);
					IRange u000C5 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(\u000C), \u0018, u4);
					\u0017\u000A\u0016.\u0018(u000C5, \u000A\u0010\u0014.\u0018(u000C));
					\u0009\u001F\u0018.\u0016(u000C5);
					IRange u000C6 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(\u000C), \u0018, u5);
					\u0017\u000A\u0016.\u0018(u000C6, \u0004\u0017\u0014.\u0018(u000C));
					\u0009\u001F\u0018.\u0016(u000C6);
					IRange u000C7 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(\u000C), \u0018, u6);
					\u0017\u000A\u0016.\u0018(u000C7, \u0014\u001B\u0014.\u0014(u000C));
					\u0009\u001F\u0018.\u0016(u000C7);
					IRange u000C8 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(\u000C), \u0018, u7);
					TimeSpan timeSpan = \u0019\u000A\u0016.\u0018(\u0010\u000A\u0016.\u0018(u000C), \u0007\u000A\u0016.\u0018(u000C));
					string u9 = \u0007\u000C\u0003.\u0018("{0}:{1}:{2}", \u000B\u000A\u0016.\u0018(ref timeSpan), \u001A\u000A\u0016.\u0018(ref timeSpan), \u001D\u000A\u0016.\u0018(ref timeSpan));
					\u0017\u000A\u0016.\u0018(u000C8, u9);
					\u0009\u001F\u0018.\u0016(u000C8);
					IRange u000C9 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(\u000C), \u0018, u8);
					string text;
					if (\u0002\u000A\u0016.\u0018(u000C) != PublishStatus.Success)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u001F\u0018.\u0018(IWorksheet, int*, List<SheetInfo>, string, string)).MethodHandle;
						}
						text = \u000D\u0009\u0018.\u000C;
					}
					else
					{
						text = \u000D\u0009\u0018.\u001F;
					}
					string u10 = text;
					Color color;
					if (\u0002\u000A\u0016.\u0018(u000C) != PublishStatus.Success)
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
						color = \u001E\u000A\u0016.\u0018(192, 0, 0);
					}
					else
					{
						color = \u001E\u000A\u0016.\u0018(146, 208, 80);
					}
					Color u11 = color;
					\u0017\u000A\u0016.\u0018(u000C9, u10);
					\u0015\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C9), u11);
					\u001F\u000A\u0016.\u0018(\u0011\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C9)), \u0020\u000A\u0016.\u0018());
					\u000A\u000A\u0016.\u0018(u000C9, ExcelLineStyle.Thin, \u0020\u000A\u0016.\u0018());
					\u0018++;
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

		// Token: 0x06000B40 RID: 2880 RVA: 0x000445E0 File Offset: 0x000427E0
		private static string \u0014(long \u000C)
		{
			string text = "";
			long num = 1L;
			long num2 = 1024L * num;
			long num3 = 1024L * num2;
			long num4 = 1024L * num3;
			if (\u000C >= num2)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u001F\u0018.\u0014(long)).MethodHandle;
				}
				if (\u000C >= num3)
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
					if (\u000C >= num4)
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
						try
						{
							double num5 = (double)\u000C / (double)num4;
							text = \u000D\u0005\u0014.\u0018(ref num5);
							return \u000D\u001E\u0018.\u0018(\u0003\u000B\u0018.\u0018(Enumerable.ToArray<char>(Enumerable.Take<char>(text, 3))), " GB");
						}
						catch
						{
							return text;
						}
					}
					try
					{
						double num5 = (double)\u000C / (double)num3;
						text = \u000D\u0005\u0014.\u0018(ref num5);
						return \u000D\u001E\u0018.\u0018(\u0003\u000B\u0018.\u0018(Enumerable.ToArray<char>(Enumerable.Take<char>(text, 3))), " MB");
					}
					catch
					{
						return text;
					}
				}
				try
				{
					double num5 = (double)\u000C / (double)num2;
					text = \u000D\u0005\u0014.\u0018(ref num5);
					return \u000D\u001E\u0018.\u0018(\u0003\u000B\u0018.\u0018(Enumerable.ToArray<char>(Enumerable.Take<char>(text, 4))), " KB");
				}
				catch
				{
					return text;
				}
			}
			try
			{
				double num5 = (double)\u000C / (double)num;
				text = \u000D\u0005\u0014.\u0018(ref num5);
				text = \u000D\u001E\u0018.\u0018(\u0003\u000B\u0018.\u0018(Enumerable.ToArray<char>(Enumerable.Take<char>(text, 4))), " B");
			}
			catch
			{
			}
			return text;
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x00044780 File Offset: 0x00042980
		private static string \u0003()
		{
			string text = \u000D\u001E\u0018.\u0018(\u0005\u000F\u0003.\u0018(), "\\ExcelTemplate.xlsx");
			if (\u000C\u001A\u0018.\u0018(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u001F\u0018.\u0003()).MethodHandle;
				}
				try
				{
					\u000C\u0020\u0014.\u0018(text);
				}
				catch (Exception)
				{
				}
			}
			try
			{
				\u000D\u0020\u0016.\u0018(text, \u001C\u0020\u0016.\u0018());
			}
			catch (Exception)
			{
			}
			return text;
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x000447FC File Offset: 0x000429FC
		private static void \u0016(IRange \u000C)
		{
			\u0015\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(\u000C), \u001E\u000A\u0016.\u0018(255, 192, 0));
			\u000A\u000A\u0016.\u0018(\u000C, ExcelLineStyle.Thin, \u0020\u000A\u0016.\u0018());
		}
	}
}

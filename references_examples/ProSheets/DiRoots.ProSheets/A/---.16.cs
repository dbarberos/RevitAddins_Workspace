using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Enums;
using ProSheets.Helpers;
using ProSheets.Models;
using ProSheets.UI;

namespace A
{
	// Token: 0x02000063 RID: 99
	internal static class \u0019\u0009\u0018
	{
		// Token: 0x17000236 RID: 566
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x00019B7C File Offset: 0x00017D7C
		// (set) Token: 0x0600051D RID: 1309 RVA: 0x00019B90 File Offset: 0x00017D90
		public static List<string> objLstFormat { get; set; }

		// Token: 0x0600051E RID: 1310 RVA: 0x00019BA4 File Offset: 0x00017DA4
		public static List<PaperSize> \u0018(Document \u000C)
		{
			List<PaperSize> list = \u0003\u0002\u0014.\u0018();
			List<PaperSize> result;
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PrinterConfiguration.cs", "getPaperSizeList");
				IEnumerator u000C = \u0018\u0002\u0014.\u0018(\u0014\u0002\u0014.\u0018(\u0005\u0003\u0014.\u0018(\u000C)));
				try
				{
					while (\u001F\u001E\u0018.\u0018(u000C))
					{
						PaperSize u = \u0001\u001A\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C));
						\u000C\u0002\u0014.\u0018(list, u);
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0009\u0018.\u0018(Document)).MethodHandle;
					}
				}
				finally
				{
					IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C);
					if (disposable != null)
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
						\u0020\u001E\u0018.\u0018(disposable);
					}
				}
				IEnumerable<PaperSize> enumerable = list;
				Func<PaperSize, int> func;
				if ((func = \u0019\u0009\u0018.\u000B\u0009\u0018.\u000C) == null)
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
					func = (\u0019\u0009\u0018.\u000B\u0009\u0018.\u000C = new Func<PaperSize, int>(\u001E\u001F\u0018.\u0014));
				}
				IOrderedEnumerable<PaperSize> orderedEnumerable = Enumerable.OrderBy<PaperSize, int>(enumerable, func);
				Func<PaperSize, string> func2;
				if ((func2 = \u0019\u0009\u0018.<>c.\u0018) == null)
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
					func2 = (\u0019\u0009\u0018.<>c.\u0018 = new Func<PaperSize, string>(\u0019\u0009\u0018.<>c.\u000C.\u0016));
				}
				list = Enumerable.ToList<PaperSize>(Enumerable.ThenBy<PaperSize, string>(orderedEnumerable, func2, new \u0014\u0017\u0018()));
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PrinterConfiguration.cs", "getPaperSizeList");
				result = list;
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PrinterConfiguration.cs", "getPaperSizeList");
				result = list;
			}
			return result;
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00019D14 File Offset: 0x00017F14
		public static List<EnumInfo> \u0014()
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0006\u0018, "No Margin", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0008\u0018, "Printer Limit", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0001\u0018, "User Defined", false));
			return list;
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00019D78 File Offset: 0x00017F78
		public static void \u0003(Document \u000C)
		{
			try
			{
				ElementClassFilter u = \u0009\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u0008\u001A\u000F.\u000C()));
				\u001F\u0002\u0014.\u0018(Enumerable.ToList<ExportDWGSettings>(Enumerable.Cast<ExportDWGSettings>(\u0013\u001D\u0018.\u0003(\u0020\u001D\u0018.\u0018(\u000C), u))));
				\u000D\u0002\u0014.\u0018(\u0011\u0002\u0018.\u0018());
				List<ExportDWGSettings>.Enumerator enumerator = \u000A\u0002\u0014.\u0018(\u0020\u0002\u0014.\u0018());
				try
				{
					while (\u0013\u0002\u0014.\u0018(ref enumerator))
					{
						ExportDWGSettings u000C = \u0009\u0002\u0014.\u0018(ref enumerator);
						\u0019\u0017\u0014.\u0018(\u001C\u0002\u0014.\u0018(), \u001E\u0016\u0014.\u0018(u000C));
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0009\u0018.\u0003(Document)).MethodHandle;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				IEnumerable<string> enumerable = \u001C\u0002\u0014.\u0018();
				Func<string, string> func;
				if ((func = \u0019\u0009\u0018.<>c.\u0014) == null)
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
					func = (\u0019\u0009\u0018.<>c.\u0014 = new Func<string, string>(\u0019\u0009\u0018.<>c.\u000C.\u000F));
				}
				\u000D\u0002\u0014.\u0018(Enumerable.ToList<string>(Enumerable.OrderBy<string, string>(enumerable, func)));
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PrinterConfiguration.cs", "getDWGSettings");
			}
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00019EA0 File Offset: 0x000180A0
		public static void \u0016(Document \u000C)
		{
			try
			{
				ElementClassFilter u = \u0009\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u0006\u001A\u000F.\u000C()));
				\u001D\u0002\u0014.\u0018(Enumerable.ToList<ExportDGNSettings>(Enumerable.Cast<ExportDGNSettings>(\u0013\u001D\u0018.\u0003(\u0020\u001D\u0018.\u0018(\u000C), u))));
				\u0011\u0002\u0014.\u0018(\u0011\u0002\u0018.\u0018());
				List<ExportDGNSettings>.Enumerator enumerator = \u0002\u0002\u0014.\u0018(\u0004\u0002\u0014.\u0018());
				try
				{
					while (\u0017\u0002\u0014.\u0018(ref enumerator))
					{
						ExportDGNSettings u000C = \u001E\u0002\u0014.\u0018(ref enumerator);
						\u0019\u0017\u0014.\u0018(\u0015\u0002\u0014.\u0018(), \u001E\u0016\u0014.\u0018(u000C));
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0009\u0018.\u0016(Document)).MethodHandle;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				IEnumerable<string> enumerable = \u0015\u0002\u0014.\u0018();
				Func<string, string> func;
				if ((func = \u0019\u0009\u0018.<>c.\u0003) == null)
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
					func = (\u0019\u0009\u0018.<>c.\u0003 = new Func<string, string>(\u0019\u0009\u0018.<>c.\u000C.\u0012));
				}
				\u0011\u0002\u0014.\u0018(Enumerable.ToList<string>(Enumerable.OrderBy<string, string>(enumerable, func)));
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PrinterConfiguration.cs", "getDGNSettings");
			}
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x00019FC8 File Offset: 0x000181C8
		public static List<EnumInfo> \u000F()
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0017\u0018, "Low", 72, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0002\u0018, "Medium", 150, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0004\u0018, "High", 300, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u001D\u0018, "Presentation", 600, false));
			return list;
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0001A058 File Offset: 0x00018258
		public static List<EnumInfo> \u0012()
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u001A\u0018, "Color", 2, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u000B\u0018, "Gray Scale", 1, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0019\u0018, "Black Line", 0, false));
			return list;
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0001A0C0 File Offset: 0x000182C0
		public static List<EnumInfo> \u000D()
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			if (\u0014\u001F\u0018.\u0003())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0009\u0018.\u000D()).MethodHandle;
				}
				\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0005\u0018, "PDF24", false));
			}
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u000D\u0009\u0018.\u001B\u0018, "Revit Native", true));
			return list;
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0001A128 File Offset: 0x00018328
		public static bool \u001C(string \u000C)
		{
			bool result = false;
			if (!\u001F\u001A\u0018.\u0018(\u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0009\u0018.\u001C(string)).MethodHandle;
				}
				List<PaperSize>.Enumerator enumerator = \u0010\u0002\u0014.\u0018(\u0006\u0002\u0014.\u0018());
				try
				{
					while (\u000B\u0002\u0014.\u0018(ref enumerator))
					{
						if (\u001B\u0013\u0018.\u0018(\u0019\u0002\u0014.\u0018(\u0007\u0002\u0014.\u0018(ref enumerator)), \u000C, true))
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
			return result;
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0001A1C8 File Offset: 0x000183C8
		public static List<SheetInfo> \u0013(List<SheetInfo> \u000C)
		{
			List<SheetInfo> list = \u0010\u001A\u000F.\u000C;
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PrinterConfiguration.cs", "getSelectedList");
				list = \u001D\u0017\u0014.\u0018();
				if (\u0008\u0017\u0014.\u0018() != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0009\u0018.\u0013(List<SheetInfo>)).MethodHandle;
					}
					List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u000C);
					try
					{
						while (\u0019\u000E\u0018.\u0018(ref enumerator))
						{
							SheetInfo u000C = \u000C\u000C\u0014.\u0018(ref enumerator);
							List<string>.Enumerator enumerator2 = \u0008\u0015\u0014.\u0018(\u0008\u0017\u0014.\u0018());
							try
							{
								while (\u0010\u0015\u0014.\u0018(ref enumerator2))
								{
									string u = \u0006\u0015\u0014.\u0018(ref enumerator2);
									SheetInfo sheetInfo = \u0012\u0004\u0014.\u0018();
									\u000F\u0004\u0014.\u0018(sheetInfo, \u0015\u0005\u0018.\u0014(u000C));
									\u0016\u0004\u0014.\u0018(sheetInfo, \u001E\u000E\u0018.\u0014(u000C));
									\u0003\u0004\u0014.\u0018(sheetInfo, \u0002\u000E\u0018.\u0014(u000C));
									\u000C\u0004\u0014.\u0018(sheetInfo, u);
									\u0018\u0004\u0014.\u0018(sheetInfo, \u0014\u0004\u0014.\u0014(u000C));
									if (\u000F\u0002\u0018.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "DWF"))
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
										if (\u0015\u0017\u0014.\u0018())
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
											\u000C\u0004\u0014.\u0018(sheetInfo, "DWFx");
										}
									}
									if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "PDF"))
									{
										goto IL_142;
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
									if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "DWF"))
									{
										for (;;)
										{
											switch (6)
											{
											case 0:
												continue;
											}
											goto IL_142;
										}
									}
									else
									{
										\u0006\u000E\u0018.\u0018(sheetInfo, "-");
									}
									IL_23E:
									if (\u000F\u0002\u0018.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "PDF"))
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
										\u0013\u0017\u0014.\u0018(1);
										if (\u001F\u001A\u0018.\u0018(\u001B\u0002\u0014.\u0018(u000C)))
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
											if (!\u0019\u0009\u0018.\u001C(\u0004\u0017\u0014.\u0018(u000C)))
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
												\u0005\u000E\u0018.\u0018(sheetInfo, "");
											}
											else if (\u000B\u0017\u0014.\u0018())
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
												if (Create.ispdfsizes_same)
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
													\u0005\u000E\u0018.\u0018(sheetInfo, \u0004\u0017\u0014.\u0018(u000C));
												}
											}
											else
											{
												\u0005\u000E\u0018.\u0018(sheetInfo, \u0004\u0017\u0014.\u0018(u000C));
											}
											if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0014.\u0018(), "Revit Native"))
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
												if (\u001F\u000B\u0018.\u0018(\u0004\u0017\u0014.\u0018(sheetInfo)))
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
													\u0005\u000E\u0018.\u0018(sheetInfo, \u0004\u0017\u0014.\u0018(u000C));
												}
											}
										}
										else
										{
											\u0005\u000E\u0018.\u0018(sheetInfo, \u001B\u0002\u0014.\u0018(u000C));
										}
									}
									else if (\u000F\u0002\u0018.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "XML"))
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
										\u0005\u000E\u0018.\u0018(sheetInfo, \u0004\u0017\u0014.\u0018(u000C));
									}
									else
									{
										\u0005\u000E\u0018.\u0018(sheetInfo, \u0010\u0020\u0014.\u0014(sheetInfo));
									}
									\u0001\u0002\u0014.\u0018(sheetInfo, \u001F\u000E\u0018.\u0018(u000C));
									bool flag = true;
									if (\u000F\u0002\u0018.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "NWC"))
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
										if (\u0009\u001E\u0018.\u0018(\u0014\u000C\u0014.\u0014(u000C), \u000D\u0009\u0018.\u001E))
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
											flag = false;
										}
									}
									if (\u000F\u0002\u0018.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "IFC"))
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
										if (\u0009\u001E\u0018.\u0018(\u0014\u000C\u0014.\u0014(u000C), \u000D\u0009\u0018.\u001E))
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
											flag = false;
										}
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
										if (sheetInfo.\u0003())
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
											\u0008\u0002\u0014.\u0018(sheetInfo, \u0004\u0017\u0014.\u0018(sheetInfo));
										}
										\u0007\u000E\u0018.\u0018(list, sheetInfo);
										continue;
									}
									continue;
									IL_142:
									if (!\u001F\u001A\u0018.\u0018(\u000E\u0002\u0014.\u0018(u000C)))
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
										if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "PDF"))
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
											\u0006\u000E\u0018.\u0018(sheetInfo, \u000E\u0002\u0014.\u0018(u000C));
											goto IL_23E;
										}
									}
									if (!\u001F\u001A\u0018.\u0018(\u0005\u0002\u0014.\u0018(u000C)))
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
										if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "DWF"))
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
											\u0006\u000E\u0018.\u0018(sheetInfo, \u0005\u0002\u0014.\u0018(u000C));
											goto IL_23E;
										}
									}
									if (\u0009\u001E\u0018.\u0018(\u0011\u0017\u0014.\u0014(u000C), "-"))
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
										if (!\u001F\u001A\u0018.\u0018(\u0011\u0017\u0014.\u0014(u000C)))
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
											\u0006\u000E\u0018.\u0018(sheetInfo, \u0011\u0017\u0014.\u0014(u000C));
											goto IL_23E;
										}
									}
									\u0006\u000E\u0018.\u0018(sheetInfo, "");
									goto IL_23E;
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
								((IDisposable)enumerator2).Dispose();
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
						((IDisposable)enumerator).Dispose();
					}
				}
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PrinterConfiguration.cs", "getSelectedList");
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\PrinterConfiguration.cs", "getSelectedList");
			}
			return list;
		}

		// Token: 0x040001D7 RID: 471
		[CompilerGenerated]
		private static List<string> \u000C;

		// Token: 0x0200017A RID: 378
		[CompilerGenerated]
		private static class \u000B\u0009\u0018
		{
			// Token: 0x040007AC RID: 1964
			public static Func<PaperSize, int> \u000C;
		}
	}
}

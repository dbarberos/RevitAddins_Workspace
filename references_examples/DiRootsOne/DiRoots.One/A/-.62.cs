using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DiRoots.One.PanelLink;
using DiRoots.One.PanelLink.Models;
using Microsoft.CSharp.RuntimeBinder;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x020001A9 RID: 425
	internal static class \u0009\u0002
	{
		// Token: 0x06000FC4 RID: 4036 RVA: 0x00062FC8 File Offset: 0x000611C8
		private static string \u000A(string \u001F)
		{
			string u001F = \u000A\u000B\u001D.\u000A(\u001F, 0, \u000E\u0015\u0019.\u000A(\u001F, ','));
			int i = \u0015\u0013\u0007.\u000A(u001F);
			string u000A = \u0010\u000B\u001D.\u000A(\u001F, \u001C\u000F\u0007.\u0007(u001F) + 1);
			string text = string.Empty;
			while (i > 0)
			{
				char c = \u001E\u001E\u0007.\u0007("ABCDEFGHIJKLMNOPQRSTUVWXYZ", (i - 1) % 26);
				text = \u0004\u001E\u000A.\u000A(\u001E\u000E\u0004.\u000A(ref c), text);
				i /= 26;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u0002.\u000A(string)).MethodHandle;
			}
			return \u0004\u001E\u000A.\u000A(text, u000A);
		}

		// Token: 0x06000FC5 RID: 4037 RVA: 0x00063058 File Offset: 0x00061258
		internal static void \u0007(List<PanelData> \u001F, string \u000A, Delegate \u0007)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Helper\\WriteExcel.cs", "WriteToExcel");
			object obj = \u001B\u001F\u0018.\u000A(\u0011\u001F\u0018.\u000A("Excel.Application"));
			if (\u0009\u0002.\u0001\u0002.\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u0002.\u0007(List<PanelData>, string, Delegate)).MethodHandle;
				}
				CSharpBinderFlags u001F = CSharpBinderFlags.None;
				string u000A = "Visible";
				Type u = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
				CSharpArgumentInfo[] array = \u000F\u0016\u000E.\u001F(2);
				array[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
				array[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, \u000F\u0015\u0010.\u001F);
				\u0009\u0002.\u0001\u0002.\u001F = \u000E\u0001\u0019.\u000A(\u000D\u0001\u0019.\u000A(u001F, u000A, u, array));
			}
			\u0010\u0001\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u001F.Target, \u0009\u0002.\u0001\u0002.\u001F, obj, false);
			if (\u0009\u0002.\u0001\u0002.\u000A == null)
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
				CSharpBinderFlags u001F2 = CSharpBinderFlags.None;
				string u000A2 = "DisplayAlerts";
				Type u2 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
				CSharpArgumentInfo[] array2 = \u000F\u0016\u000E.\u001F(2);
				array2[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
				array2[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, \u000F\u0015\u0010.\u001F);
				\u0009\u0002.\u0001\u0002.\u000A = \u000E\u0001\u0019.\u000A(\u000D\u0001\u0019.\u000A(u001F2, u000A2, u2, array2));
			}
			\u0010\u0001\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u000A.Target, \u0009\u0002.\u0001\u0002.\u000A, obj, false);
			if (\u0009\u0002.\u0001\u0002.\u0007 == null)
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
				CSharpBinderFlags u001F3 = CSharpBinderFlags.None;
				string u000A3 = "Workbooks";
				Type u3 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
				CSharpArgumentInfo[] array3 = \u000F\u0016\u000E.\u001F(1);
				array3[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
				\u0009\u0002.\u0001\u0002.\u0007 = \u0019\u0001\u0019.\u000A(\u0018\u0001\u0019.\u000A(u001F3, u000A3, u3, array3));
			}
			object u001D = \u0004\u0001\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u0007.Target, \u0009\u0002.\u0001\u0002.\u0007, obj);
			List<object> list = \u000C\u000D\u0007.\u000A();
			try
			{
				int num = 1;
				List<PanelData>.Enumerator enumerator = \u0008\u001F\u0018.\u000A(\u001F);
				try
				{
					while (\u0009\u0015\u0019.\u000A(ref enumerator))
					{
						PanelData u001F4 = \u000E\u001F\u0018.\u000A(ref enumerator);
						double num2 = 0.0;
						if (\u0007 != null)
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
							object[] array4 = \u0004\u0015\u0010.\u001F(1);
							array4[0] = num++;
							\u0010\u001F\u0018.\u000A(\u0007, array4);
						}
						string text;
						if (\u0015\u0013\u0019.\u000A(\u001F) == 1)
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
							text = \u000A;
						}
						else
						{
							text = \u001B\u0015\u001D.\u000A(\u000A, \u0004\u001E\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u000D\u001F\u0018.\u000A(u001F4)), ".xlsx"));
						}
						try
						{
							string u001F5 = text;
							List<string> list2 = \u001C\u001F\u0018.\u000A(1);
							\u001A\u0008\u0007.\u000A(list2, "Main Sheet");
							\u0010\u0008\u000A u0010_u0008_u000A = new \u0010\u0008\u000A(u001F5, list2);
							IWorkbook u001F6 = \u0003\u001F\u0018.\u0007(u0010_u0008_u000A);
							IWorksheet worksheet = \u0012\u001E\u001D.\u000A(\u0003\u001E\u001D.\u000A(u001F6), 0);
							List<ExcelSheetInfo>.Enumerator enumerator2 = \u0014\u0001\u0019.\u000A(\u0013\u0001\u0019.\u000A(u001F4));
							try
							{
								while (\u0007\u0001\u0019.\u000A(ref enumerator2))
								{
									ExcelSheetInfo u001F7 = \u0017\u0001\u0019.\u000A(ref enumerator2);
									int num3 = -1;
									List<int> u001F8 = \u0017\u000B\u001D.\u000A();
									bool flag = false;
									IWorksheet u001F9;
									if (\u0008\u0013\u000A.\u000A(\u0012\u0001\u0019.\u000A(u001F7), "Body"))
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
										u001F9 = worksheet;
										flag = true;
									}
									else
									{
										u001F9 = \u0012\u001F\u0018.\u000A(\u0003\u001E\u001D.\u000A(u001F6), \u0012\u0001\u0019.\u000A(u001F7));
										if (\u001B\u0001\u0019.\u000A(u001F7) > 2)
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
											for (int i = 1; i < \u001B\u0001\u0019.\u000A(u001F7); i++)
											{
												\u000F\u001F\u0018.\u000A(u001F9, i, false);
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
									}
									\u0006\u001F\u0018.\u000A(\u001F\u0014\u001D.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(u001F9), \u001B\u0001\u0019.\u000A(u001F7), 1, \u001E\u0001\u0019.\u000A(u001F7) - 1, \u0020\u0001\u0019.\u000A(u001F7) - 1)), true);
									List<ExcelCell>.Enumerator enumerator3 = \u000B\u001F\u0018.\u000A(\u0002\u001F\u0018.\u000A(u001F7));
									try
									{
										while (\u000C\u0001\u0019.\u000A(ref enumerator3))
										{
											ExcelCell u001F10 = \u0016\u001F\u0018.\u000A(ref enumerator3);
											try
											{
												if (!\u0005\u001F\u0018.\u000A(u001F8, \u0016\u0009\u0019.\u000A(u001F10)))
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
													\u0019\u001F\u0018.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(u001F9), 1, \u0016\u0009\u0019.\u000A(u001F10)), \u0018\u001F\u0018.\u000A(u001F10) * 165.3);
													\u0020\u000B\u001D.\u000A(u001F8, \u0016\u0009\u0019.\u000A(u001F10));
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
														num2 += \u0019\u001A\u001D.\u000A(\u0018\u001A\u001D.\u000A(u001F9), (double)\u0005\u001A\u001D.\u000A(u001F9, \u0016\u0009\u0019.\u000A(u001F10)), MeasureUnits.Pixel, MeasureUnits.Point);
													}
												}
												if (\u0005\u0009\u0019.\u000A(u001F10) != num3)
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
													\u001D\u001F\u0018.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet), \u0005\u0009\u0019.\u000A(u001F10), 1), \u0004\u001F\u0018.\u000A(u001F10) * 864.0);
													\u001D\u001F\u0018.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(u001F9), \u0005\u0009\u0019.\u000A(u001F10), 1), \u0004\u001F\u0018.\u000A(u001F10) * 859.0);
													num3 = \u0005\u0009\u0019.\u000A(u001F10);
												}
												MergedCells u001F11 = \u0014\u0020\u0019.\u000A(u001F10);
												if (\u0007\u001F\u0018.\u000A(u001F10))
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
													ImageInfo u001F12 = \u000A\u001F\u0018.\u000A(u001F10);
													IPictureShape u001F13 = \u0009\u0009\u0019.\u000A(\u0002\u0015\u001D.\u000A(u001F9), \u0005\u0009\u0019.\u000A(u001F10) - 1, \u0016\u0009\u0019.\u000A(u001F10) - 1, \u001F\u001F\u0018.\u000A(u001F12));
													double u001F14 = \u0013\u0020\u0019.\u000A(u001F12) * 1152.0;
													double u001F15 = \u000C\u0020\u0019.\u000A(u001F12) * 1152.0;
													\u0001\u0009\u0019.\u000A(u001F13, (int)\u0020\u001E\u0004.\u000A(u001F14));
													\u0015\u0009\u0019.\u000A(u001F13, (int)\u0020\u001E\u0004.\u000A(u001F15));
													if (\u000B\u0009\u0019.\u000A(u001F11))
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
														if (\u0016\u0009\u0019.\u000A(u001F10) == \u0009\u0001\u0019.\u000A(u001F11))
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
															if (\u0005\u0009\u0019.\u000A(u001F10) == \u001F\u0009\u0019.\u000A(u001F11))
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
																\u0015\u0001\u0019.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(u001F9), \u001F\u0009\u0019.\u000A(u001F11), \u0009\u0001\u0019.\u000A(u001F11), \u001A\u0020\u0019.\u000A(u001F11), \u0017\u0020\u0019.\u000A(u001F11)));
															}
														}
													}
												}
												else
												{
													IRange range = \u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(u001F9), \u0005\u0009\u0019.\u000A(u001F10), \u0016\u0009\u0019.\u000A(u001F10));
													FontInfo u001F16 = \u000C\u0009\u0019.\u000A(u001F10);
													\u0013\u0009\u0019.\u000A(range, \u001A\u0009\u0019.\u000A(u001F10));
													IFont u001F17 = \u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(range));
													\u0017\u0009\u0019.\u000A(u001F17, \u0014\u0009\u0019.\u000A(u001F16));
													\u001E\u0009\u0019.\u000A(u001F17, \u0020\u0009\u0019.\u000A(u001F16));
													\u001B\u0009\u0019.\u000A(u001F17, \u0011\u0009\u0019.\u000A(u001F16));
													ExcelUnderline u000A4;
													if (!\u0008\u0009\u0019.\u000A(u001F16))
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
														u000A4 = ExcelUnderline.None;
													}
													else
													{
														u000A4 = ExcelUnderline.Single;
													}
													\u000E\u0009\u0019.\u000A(u001F17, u000A4);
													\u000D\u0009\u0019.\u000A(u001F17, \u0010\u0009\u0019.\u000A(u001F16));
													\u0003\u0009\u0019.\u000A(u001F17, (double)\u001C\u0009\u0019.\u000A(u001F16));
													\u0012\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(range), ExcelPattern.Solid);
													\u000F\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(range), \u0006\u0009\u0019.\u000A(u001F16));
													\u0002\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(range), \u0006\u0009\u0019.\u000A(u001F16));
													if (!\u000B\u0009\u0019.\u000A(\u0014\u0020\u0019.\u000A(u001F10)))
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
														\u0009\u0002.\u001D(\u0007\u0009\u0019.\u000A(u001F10), range);
													}
													\u0009\u0002.\u0019(u001F10, range);
													if (\u000B\u0009\u0019.\u000A(u001F11))
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
														if (\u0016\u0009\u0019.\u000A(u001F10) == \u0009\u0001\u0019.\u000A(u001F11))
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
															if (\u0005\u0009\u0019.\u000A(u001F10) == \u001F\u0009\u0019.\u000A(u001F11))
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
																for (int j = \u001F\u0009\u0019.\u000A(u001F11); j <= \u001A\u0020\u0019.\u000A(u001F11); j++)
																{
																	range = \u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(u001F9), j, \u0009\u0001\u0019.\u000A(u001F11));
																	\u0009\u0002.\u0004(\u000A\u0013\u001D.\u000A(\u001D\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(range)), ExcelBordersIndex.EdgeLeft), \u0018\u0009\u0019.\u000A(\u0007\u0009\u0019.\u000A(u001F10)));
																	range = \u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(u001F9), j, \u0017\u0020\u0019.\u000A(u001F11));
																	\u0009\u0002.\u0004(\u000A\u0013\u001D.\u000A(\u001D\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(range)), ExcelBordersIndex.EdgeRight), \u0019\u0009\u0019.\u000A(\u0007\u0009\u0019.\u000A(u001F10)));
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
																for (int k = \u0009\u0001\u0019.\u000A(u001F11); k <= \u0017\u0020\u0019.\u000A(u001F11); k++)
																{
																	range = \u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(u001F9), \u001F\u0009\u0019.\u000A(u001F11), k);
																	\u0009\u0002.\u0004(\u000A\u0013\u001D.\u000A(\u001D\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(range)), ExcelBordersIndex.EdgeTop), \u0004\u0009\u0019.\u000A(\u0007\u0009\u0019.\u000A(u001F10)));
																	range = \u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(u001F9), \u001A\u0020\u0019.\u000A(u001F11), k);
																	\u0009\u0002.\u0004(\u000A\u0013\u001D.\u000A(\u001D\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(range)), ExcelBordersIndex.EdgeBottom), \u000A\u0009\u0019.\u000A(\u0007\u0009\u0019.\u000A(u001F10)));
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
																\u0015\u0001\u0019.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(u001F9), \u001F\u0009\u0019.\u000A(u001F11), \u0009\u0001\u0019.\u000A(u001F11), \u001A\u0020\u0019.\u000A(u001F11), \u0017\u0020\u0019.\u000A(u001F11)));
															}
														}
													}
												}
											}
											catch (Exception u000A5)
											{
												\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A5, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Helper\\WriteExcel.cs", "WriteToExcel");
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
										((IDisposable)enumerator3).Dispose();
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
							\u001A\u0001\u0019.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet), 1, 1));
							u0010_u0008_u000A.\u0004("");
							u0010_u0008_u000A.\u0019();
							if (\u0009\u0002.\u0001\u0002.\u0004 == null)
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
								CSharpBinderFlags u001F18 = CSharpBinderFlags.None;
								string u000A6 = "Open";
								IEnumerable<Type> u4 = null;
								Type u001D2 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
								CSharpArgumentInfo[] array5 = \u000F\u0016\u000E.\u001F(2);
								array5[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
								array5[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
								\u0009\u0002.\u0001\u0002.\u0004 = \u0011\u0001\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F18, u000A6, u4, u001D2, array5));
							}
							object target = \u0009\u0002.\u0001\u0002.\u0004.Target;
							CallSite u5 = \u0009\u0002.\u0001\u0002.\u0004;
							if (\u0009\u0002.\u0001\u0002.\u001D == null)
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
								CSharpBinderFlags u001F19 = CSharpBinderFlags.None;
								string u000A7 = "Workbooks";
								Type u6 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
								CSharpArgumentInfo[] array6 = \u000F\u0016\u000E.\u001F(1);
								array6[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
								\u0009\u0002.\u0001\u0002.\u001D = \u0019\u0001\u0019.\u000A(\u0018\u0001\u0019.\u000A(u001F19, u000A7, u6, array6));
							}
							object obj2 = \u0008\u0001\u0019.\u000A(target, u5, \u0004\u0001\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u001D.Target, \u0009\u0002.\u0001\u0002.\u001D, obj), text);
							if (\u0009\u0002.\u0001\u0002.\u0019 == null)
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
								CSharpBinderFlags u001F20 = CSharpBinderFlags.ResultDiscarded;
								string u000A8 = "Add";
								IEnumerable<Type> u7 = null;
								Type u001D3 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
								CSharpArgumentInfo[] array7 = \u000F\u0016\u000E.\u001F(2);
								array7[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
								array7[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
								\u0009\u0002.\u0001\u0002.\u0019 = \u0013\u0015\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F20, u000A8, u7, u001D3, array7));
							}
							\u0014\u0015\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u0019.Target, \u0009\u0002.\u0001\u0002.\u0019, list, obj2);
							enumerator2 = \u0014\u0001\u0019.\u000A(\u0013\u0001\u0019.\u000A(u001F4));
							try
							{
								while (\u0007\u0001\u0019.\u000A(ref enumerator2))
								{
									ExcelSheetInfo u001F21 = \u0017\u0001\u0019.\u000A(ref enumerator2);
									try
									{
										if (\u001D\u0017\u000A.\u000A(\u0012\u0001\u0019.\u000A(u001F21), "Body"))
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
											if (\u0009\u0002.\u0001\u0002.\u0005 == null)
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
												CSharpBinderFlags u001F22 = CSharpBinderFlags.None;
												Type u000A9 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array8 = \u000F\u0016\u000E.\u001F(2);
												array8[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												array8[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u0005 = \u0011\u0001\u0019.\u000A(\u0016\u0001\u0019.\u000A(u001F22, u000A9, array8));
											}
											object target2 = \u0009\u0002.\u0001\u0002.\u0005.Target;
											CallSite u8 = \u0009\u0002.\u0001\u0002.\u0005;
											if (\u0009\u0002.\u0001\u0002.\u0018 == null)
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
												CSharpBinderFlags u001F23 = CSharpBinderFlags.ResultIndexed;
												string u000A10 = "Sheets";
												Type u9 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array9 = \u000F\u0016\u000E.\u001F(1);
												array9[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u0018 = \u0019\u0001\u0019.\u000A(\u0018\u0001\u0019.\u000A(u001F23, u000A10, u9, array9));
											}
											object obj3 = \u0008\u0001\u0019.\u000A(target2, u8, \u0004\u0001\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u0018.Target, \u0009\u0002.\u0001\u0002.\u0018, obj2), \u0012\u0001\u0019.\u000A(u001F21));
											if (\u0009\u0002.\u0001\u0002.\u0016 == null)
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
												CSharpBinderFlags u001F24 = CSharpBinderFlags.ResultDiscarded;
												string u000A11 = "Add";
												IEnumerable<Type> u10 = null;
												Type u001D4 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array10 = \u000F\u0016\u000E.\u001F(2);
												array10[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
												array10[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u0016 = \u0013\u0015\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F24, u000A11, u10, u001D4, array10));
											}
											\u0014\u0015\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u0016.Target, \u0009\u0002.\u0001\u0002.\u0016, list, obj3);
											if (\u0009\u0002.\u0001\u0002.\u0002 == null)
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
												CSharpBinderFlags u001F25 = CSharpBinderFlags.None;
												Type u000A12 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array11 = \u000F\u0016\u000E.\u001F(2);
												array11[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												array11[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u0002 = \u0011\u0001\u0019.\u000A(\u0016\u0001\u0019.\u000A(u001F25, u000A12, array11));
											}
											object target3 = \u0009\u0002.\u0001\u0002.\u0002.Target;
											CallSite u11 = \u0009\u0002.\u0001\u0002.\u0002;
											if (\u0009\u0002.\u0001\u0002.\u000B == null)
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
												CSharpBinderFlags u001F26 = CSharpBinderFlags.ResultIndexed;
												string u000A13 = "Range";
												Type u12 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array12 = \u000F\u0016\u000E.\u001F(1);
												array12[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u000B = \u0019\u0001\u0019.\u000A(\u0018\u0001\u0019.\u000A(u001F26, u000A13, u12, array12));
											}
											object u13 = \u0004\u0001\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u000B.Target, \u0009\u0002.\u0001\u0002.\u000B, obj3);
											string u001F27 = "1,";
											int num4 = \u001B\u0001\u0019.\u000A(u001F21);
											string u001F28 = \u0009\u0002.\u000A(\u0004\u001E\u000A.\u000A(u001F27, \u000C\u0013\u0007.\u000A(ref num4)));
											string u000A14 = ":";
											num4 = \u0020\u0001\u0019.\u000A(u001F21) - 1;
											string u001F29 = \u000C\u0013\u0007.\u000A(ref num4);
											string u000A15 = ",";
											num4 = \u001E\u0001\u0019.\u000A(u001F21) - 1;
											object obj4 = \u0008\u0001\u0019.\u000A(target3, u11, u13, \u0002\u0013\u000A.\u000A(u001F28, u000A14, \u0009\u0002.\u000A(\u0002\u0013\u000A.\u000A(u001F29, u000A15, \u000C\u0013\u0007.\u000A(ref num4)))));
											if (\u0009\u0002.\u0001\u0002.\u0006 == null)
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
												CSharpBinderFlags u001F30 = CSharpBinderFlags.ResultDiscarded;
												string u000A16 = "Add";
												IEnumerable<Type> u14 = null;
												Type u001D5 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array13 = \u000F\u0016\u000E.\u001F(2);
												array13[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
												array13[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u0006 = \u0013\u0015\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F30, u000A16, u14, u001D5, array13));
											}
											\u0014\u0015\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u0006.Target, \u0009\u0002.\u0001\u0002.\u0006, list, obj4);
											if (\u0009\u0002.\u0001\u0002.\u000F == null)
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
												CSharpBinderFlags u001F31 = CSharpBinderFlags.ResultDiscarded;
												string u000A17 = "Copy";
												IEnumerable<Type> u15 = null;
												Type u001D6 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array14 = \u000F\u0016\u000E.\u001F(1);
												array14[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u000F = \u0001\u0015\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F31, u000A17, u15, u001D6, array14));
											}
											\u0015\u0015\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u000F.Target, \u0009\u0002.\u0001\u0002.\u000F, obj4);
											if (\u0009\u0002.\u0001\u0002.\u0003 == null)
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
												CSharpBinderFlags u001F32 = CSharpBinderFlags.None;
												Type u000A18 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array15 = \u000F\u0016\u000E.\u001F(2);
												array15[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												array15[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u0003 = \u0011\u0001\u0019.\u000A(\u0016\u0001\u0019.\u000A(u001F32, u000A18, array15));
											}
											object target4 = \u0009\u0002.\u0001\u0002.\u0003.Target;
											CallSite u16 = \u0009\u0002.\u0001\u0002.\u0003;
											if (\u0009\u0002.\u0001\u0002.\u0012 == null)
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
												CSharpBinderFlags u001F33 = CSharpBinderFlags.ResultIndexed;
												string u000A19 = "Sheets";
												Type u17 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array16 = \u000F\u0016\u000E.\u001F(1);
												array16[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u0012 = \u0019\u0001\u0019.\u000A(\u0018\u0001\u0019.\u000A(u001F33, u000A19, u17, array16));
											}
											object obj5 = \u0008\u0001\u0019.\u000A(target4, u16, \u0004\u0001\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u0012.Target, \u0009\u0002.\u0001\u0002.\u0012, obj2), "Main Sheet");
											if (\u0009\u0002.\u0001\u0002.\u001C == null)
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
												CSharpBinderFlags u001F34 = CSharpBinderFlags.ResultDiscarded;
												string u000A20 = "Add";
												IEnumerable<Type> u18 = null;
												Type u001D7 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array17 = \u000F\u0016\u000E.\u001F(2);
												array17[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
												array17[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u001C = \u0013\u0015\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F34, u000A20, u18, u001D7, array17));
											}
											\u0014\u0015\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u001C.Target, \u0009\u0002.\u0001\u0002.\u001C, list, obj5);
											if (\u0009\u0002.\u0001\u0002.\u000D == null)
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
												CSharpBinderFlags u001F35 = CSharpBinderFlags.ResultDiscarded;
												string u000A21 = "Activate";
												IEnumerable<Type> u19 = null;
												Type u001D8 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array18 = \u000F\u0016\u000E.\u001F(1);
												array18[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u000D = \u0001\u0015\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F35, u000A21, u19, u001D8, array18));
											}
											\u0015\u0015\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u000D.Target, \u0009\u0002.\u0001\u0002.\u000D, obj5);
											if (\u0009\u0002.\u0001\u0002.\u000E == null)
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
												CSharpBinderFlags u001F36 = CSharpBinderFlags.None;
												Type u000A22 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array19 = \u000F\u0016\u000E.\u001F(2);
												array19[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												array19[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u000E = \u0011\u0001\u0019.\u000A(\u0016\u0001\u0019.\u000A(u001F36, u000A22, array19));
											}
											object target5 = \u0009\u0002.\u0001\u0002.\u000E.Target;
											CallSite u000E = \u0009\u0002.\u0001\u0002.\u000E;
											if (\u0009\u0002.\u0001\u0002.\u0010 == null)
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
												CSharpBinderFlags u001F37 = CSharpBinderFlags.ResultIndexed;
												string u000A23 = "Range";
												Type u20 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array20 = \u000F\u0016\u000E.\u001F(1);
												array20[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u0010 = \u0019\u0001\u0019.\u000A(\u0018\u0001\u0019.\u000A(u001F37, u000A23, u20, array20));
											}
											object u21 = \u0004\u0001\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u0010.Target, \u0009\u0002.\u0001\u0002.\u0010, obj5);
											string u001F38 = "1,";
											num4 = \u001B\u0001\u0019.\u000A(u001F21);
											object obj6 = \u0008\u0001\u0019.\u000A(target5, u000E, u21, \u0009\u0002.\u000A(\u0004\u001E\u000A.\u000A(u001F38, \u000C\u0013\u0007.\u000A(ref num4))));
											if (\u0009\u0002.\u0001\u0002.\u0008 == null)
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
												CSharpBinderFlags u001F39 = CSharpBinderFlags.ResultDiscarded;
												string u000A24 = "Add";
												IEnumerable<Type> u22 = null;
												Type u001D9 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array21 = \u000F\u0016\u000E.\u001F(2);
												array21[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
												array21[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u0008 = \u0013\u0015\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F39, u000A24, u22, u001D9, array21));
											}
											\u0014\u0015\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u0008.Target, \u0009\u0002.\u0001\u0002.\u0008, list, obj6);
											if (\u0009\u0002.\u0001\u0002.\u001B == null)
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
												CSharpBinderFlags u001F40 = CSharpBinderFlags.ResultDiscarded;
												string u000A25 = "Select";
												IEnumerable<Type> u23 = null;
												Type u001D10 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array22 = \u000F\u0016\u000E.\u001F(1);
												array22[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u001B = \u0001\u0015\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F40, u000A25, u23, u001D10, array22));
											}
											\u0015\u0015\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u001B.Target, \u0009\u0002.\u0001\u0002.\u001B, obj6);
											if (\u0009\u0002.\u0001\u0002.\u0011 == null)
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
												CSharpBinderFlags u001F41 = CSharpBinderFlags.None;
												string u000A26 = "Pictures";
												IEnumerable<Type> u24 = null;
												Type u001D11 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array23 = \u000F\u0016\u000E.\u001F(1);
												array23[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u0011 = \u0019\u0001\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F41, u000A26, u24, u001D11, array23));
											}
											object obj7 = \u0004\u0001\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u0011.Target, \u0009\u0002.\u0001\u0002.\u0011, obj5);
											if (\u0009\u0002.\u0001\u0002.\u001E == null)
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
												CSharpBinderFlags u001F42 = CSharpBinderFlags.ResultDiscarded;
												string u000A27 = "Add";
												IEnumerable<Type> u25 = null;
												Type u001D12 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array24 = \u000F\u0016\u000E.\u001F(2);
												array24[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
												array24[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u001E = \u0013\u0015\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F42, u000A27, u25, u001D12, array24));
											}
											\u0014\u0015\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u001E.Target, \u0009\u0002.\u0001\u0002.\u001E, list, obj7);
											if (\u0009\u0002.\u0001\u0002.\u0020 == null)
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
												CSharpBinderFlags u001F43 = CSharpBinderFlags.None;
												string u000A28 = "paste";
												IEnumerable<Type> u26 = null;
												Type u001D13 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array25 = \u000F\u0016\u000E.\u001F(2);
												array25[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												array25[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u0020 = \u000E\u0001\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F43, u000A28, u26, u001D13, array25));
											}
											object u27 = \u0010\u0001\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u0020.Target, \u0009\u0002.\u0001\u0002.\u0020, obj7, true);
											if (\u0009\u0002.\u0001\u0002.\u0017 == null)
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
												CSharpBinderFlags u001F44 = CSharpBinderFlags.None;
												string u000A29 = "Width";
												Type u28 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array26 = \u000F\u0016\u000E.\u001F(2);
												array26[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												array26[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u0017 = \u001C\u0001\u0019.\u000A(\u000D\u0001\u0019.\u000A(u001F44, u000A29, u28, array26));
											}
											\u0003\u0001\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u0017.Target, \u0009\u0002.\u0001\u0002.\u0017, u27, num2);
											if (\u0008\u0013\u000A.\u000A(\u0012\u0001\u0019.\u000A(u001F21), "Header"))
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
												if (\u0009\u0002.\u0001\u0002.\u001A == null)
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
													CSharpBinderFlags u001F45 = CSharpBinderFlags.ResultDiscarded;
													string u000A30 = "Move";
													IEnumerable<Type> u29 = null;
													Type u001D14 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
													CSharpArgumentInfo[] array27 = \u000F\u0016\u000E.\u001F(2);
													array27[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
													array27[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.NamedArgument, "Before");
													\u0009\u0002.\u0001\u0002.\u001A = \u000F\u0001\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F45, u000A30, u29, u001D14, array27));
												}
												object target6 = \u0009\u0002.\u0001\u0002.\u001A.Target;
												CallSite u001A = \u0009\u0002.\u0001\u0002.\u001A;
												object u30 = obj5;
												if (\u0009\u0002.\u0001\u0002.\u0013 == null)
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
													CSharpBinderFlags u001F46 = CSharpBinderFlags.None;
													Type u000A31 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
													CSharpArgumentInfo[] array28 = \u000F\u0016\u000E.\u001F(2);
													array28[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
													array28[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, \u000F\u0015\u0010.\u001F);
													\u0009\u0002.\u0001\u0002.\u0013 = \u0006\u0001\u0019.\u000A(\u0016\u0001\u0019.\u000A(u001F46, u000A31, array28));
												}
												object target7 = \u0009\u0002.\u0001\u0002.\u0013.Target;
												CallSite u31 = \u0009\u0002.\u0001\u0002.\u0013;
												if (\u0009\u0002.\u0001\u0002.\u0014 == null)
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
													CSharpBinderFlags u001F47 = CSharpBinderFlags.ResultIndexed;
													string u000A32 = "Worksheets";
													Type u32 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
													CSharpArgumentInfo[] array29 = \u000F\u0016\u000E.\u001F(1);
													array29[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
													\u0009\u0002.\u0001\u0002.\u0014 = \u0019\u0001\u0019.\u000A(\u0018\u0001\u0019.\u000A(u001F47, u000A32, u32, array29));
												}
												\u000B\u0001\u0019.\u000A(target6, u001A, u30, \u0002\u0001\u0019.\u000A(target7, u31, \u0004\u0001\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u0014.Target, \u0009\u0002.\u0001\u0002.\u0014, obj2), 1));
											}
											if (\u0009\u0002.\u0001\u0002.\u0001 == null)
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
												CSharpBinderFlags u001F48 = CSharpBinderFlags.ResultDiscarded;
												string u000A33 = "Select";
												IEnumerable<Type> u33 = null;
												Type u001D15 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array30 = \u000F\u0016\u000E.\u001F(1);
												array30[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u0001 = \u0001\u0015\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F48, u000A33, u33, u001D15, array30));
											}
											object target8 = \u0009\u0002.\u0001\u0002.\u0001.Target;
											CallSite u34 = \u0009\u0002.\u0001\u0002.\u0001;
											if (\u0009\u0002.\u0001\u0002.\u0015 == null)
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
												CSharpBinderFlags u001F49 = CSharpBinderFlags.None;
												Type u000A34 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array31 = \u000F\u0016\u000E.\u001F(3);
												array31[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												array31[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, \u000F\u0015\u0010.\u001F);
												array31[2] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u0015 = \u0005\u0001\u0019.\u000A(\u0016\u0001\u0019.\u000A(u001F49, u000A34, array31));
											}
											object target9 = \u0009\u0002.\u0001\u0002.\u0015.Target;
											CallSite u35 = \u0009\u0002.\u0001\u0002.\u0015;
											if (\u0009\u0002.\u0001\u0002.\u000C == null)
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
												CSharpBinderFlags u001F50 = CSharpBinderFlags.ResultIndexed;
												string u000A35 = "Cells";
												Type u36 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
												CSharpArgumentInfo[] array32 = \u000F\u0016\u000E.\u001F(1);
												array32[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
												\u0009\u0002.\u0001\u0002.\u000C = \u0019\u0001\u0019.\u000A(\u0018\u0001\u0019.\u000A(u001F50, u000A35, u36, array32));
											}
											\u0015\u0015\u0019.\u000A(target8, u34, \u001D\u0001\u0019.\u000A(target9, u35, \u0004\u0001\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u000C.Target, \u0009\u0002.\u0001\u0002.\u000C, obj5), 1, 1));
										}
									}
									catch (Exception u000A36)
									{
										\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A36, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Helper\\WriteExcel.cs", "WriteToExcel");
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
								((IDisposable)enumerator2).Dispose();
							}
							if (\u0009\u0002.\u0001\u0002.\u0009 == null)
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
								CSharpBinderFlags u001F51 = CSharpBinderFlags.ResultDiscarded;
								string u000A37 = "Close";
								IEnumerable<Type> u37 = null;
								Type u001D16 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
								CSharpArgumentInfo[] array33 = \u000F\u0016\u000E.\u001F(4);
								array33[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
								array33[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, \u000F\u0015\u0010.\u001F);
								array33[2] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
								array33[3] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
								\u0009\u0002.\u0001\u0002.\u0009 = \u000A\u0001\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F51, u000A37, u37, u001D16, array33));
							}
							\u001F\u0001\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u0009.Target, \u0009\u0002.\u0001\u0002.\u0009, obj2, true, Type.Missing, Type.Missing);
						}
						catch (Exception u000A38)
						{
							\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A38, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Helper\\WriteExcel.cs", "WriteToExcel");
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
			}
			finally
			{
				if (\u0009\u0002.\u0001\u0002.\u001F\u000A == null)
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
					CSharpBinderFlags u001F52 = CSharpBinderFlags.ResultDiscarded;
					string u000A39 = "Quit";
					IEnumerable<Type> u38 = null;
					Type u001D17 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
					CSharpArgumentInfo[] array34 = \u000F\u0016\u000E.\u001F(1);
					array34[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
					\u0009\u0002.\u0001\u0002.\u001F\u000A = \u0001\u0015\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F52, u000A39, u38, u001D17, array34));
				}
				\u0015\u0015\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u001F\u000A.Target, \u0009\u0002.\u0001\u0002.\u001F\u000A, obj);
				if (\u0009\u0002.\u0001\u0002.\u000A\u000A == null)
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
					CSharpBinderFlags u001F53 = CSharpBinderFlags.ResultDiscarded;
					string u000A40 = "Add";
					IEnumerable<Type> u39 = null;
					Type u001D18 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
					CSharpArgumentInfo[] array35 = \u000F\u0016\u000E.\u001F(2);
					array35[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
					array35[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
					\u0009\u0002.\u0001\u0002.\u000A\u000A = \u0013\u0015\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F53, u000A40, u39, u001D18, array35));
				}
				\u0014\u0015\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u000A\u000A.Target, \u0009\u0002.\u0001\u0002.\u000A\u000A, list, u001D);
				if (\u0009\u0002.\u0001\u0002.\u0007\u000A == null)
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
					CSharpBinderFlags u001F54 = CSharpBinderFlags.ResultDiscarded;
					string u000A41 = "Add";
					IEnumerable<Type> u40 = null;
					Type u001D19 = \u001E\u0011\u000A.\u000A(\u0006\u0016\u000E.\u001F());
					CSharpArgumentInfo[] array36 = \u000F\u0016\u000E.\u001F(2);
					array36[0] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.UseCompileTimeType, \u000F\u0015\u0010.\u001F);
					array36[1] = \u000C\u0015\u0019.\u000A(CSharpArgumentInfoFlags.None, \u000F\u0015\u0010.\u001F);
					\u0009\u0002.\u0001\u0002.\u0007\u000A = \u0013\u0015\u0019.\u000A(\u001A\u0015\u0019.\u000A(u001F54, u000A41, u40, u001D19, array36));
				}
				\u0014\u0015\u0019.\u000A(\u0009\u0002.\u0001\u0002.\u0007\u000A.Target, \u0009\u0002.\u0001\u0002.\u0007\u000A, list, obj);
				List<object>.Enumerator enumerator4 = \u0017\u0015\u0019.\u000A(list);
				try
				{
					while (\u0011\u0015\u0019.\u000A(ref enumerator4))
					{
						\u001E\u0015\u0019.\u000A(\u0020\u0015\u0019.\u000A(ref enumerator4));
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
					((IDisposable)enumerator4).Dispose();
				}
				\u001B\u0015\u0019.\u000A();
				\u0008\u0015\u0019.\u000A();
				\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Helper\\WriteExcel.cs", "WriteToExcel");
			}
		}

		// Token: 0x06000FC6 RID: 4038 RVA: 0x00064B90 File Offset: 0x00062D90
		internal static void \u001D(BorderLinestyle \u001F, IRange \u000A)
		{
			\u0009\u0002.\u0004(\u000A\u0013\u001D.\u000A(\u001D\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(\u000A)), ExcelBordersIndex.EdgeTop), \u0004\u0009\u0019.\u000A(\u001F));
			\u0009\u0002.\u0004(\u000A\u0013\u001D.\u000A(\u001D\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(\u000A)), ExcelBordersIndex.EdgeBottom), \u000A\u0009\u0019.\u000A(\u001F));
			\u0009\u0002.\u0004(\u000A\u0013\u001D.\u000A(\u001D\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(\u000A)), ExcelBordersIndex.EdgeLeft), \u0018\u0009\u0019.\u000A(\u001F));
			\u0009\u0002.\u0004(\u000A\u0013\u001D.\u000A(\u001D\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(\u000A)), ExcelBordersIndex.EdgeRight), \u0019\u0009\u0019.\u000A(\u001F));
		}

		// Token: 0x06000FC7 RID: 4039 RVA: 0x00064C30 File Offset: 0x00062E30
		internal static void \u0004(IBorder \u001F, BorderLinestyles \u000A)
		{
			if (\u0012\u001A\u001D.\u000A(\u001F) == ExcelLineStyle.None)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u0002.\u0004(IBorder, BorderLinestyles)).MethodHandle;
				}
				switch (\u000A)
				{
				case BorderLinestyles.None:
					\u001E\u001F\u0018.\u000A(\u001F, ExcelLineStyle.None);
					return;
				case BorderLinestyles.Thin:
					\u001E\u001F\u0018.\u000A(\u001F, ExcelLineStyle.Thin);
					return;
				case BorderLinestyles.Medium:
					\u001E\u001F\u0018.\u000A(\u001F, ExcelLineStyle.Medium);
					return;
				case BorderLinestyles.Thick:
					\u001E\u001F\u0018.\u000A(\u001F, ExcelLineStyle.Thick);
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x00064C90 File Offset: 0x00062E90
		internal static void \u0019(ExcelCell \u001F, IRange \u000A)
		{
			VerticalAlignments verticalAlignments = \u0013\u001F\u0018.\u000A(\u001F);
			HorizontalAlignments horizontalAlignments = \u0014\u001F\u0018.\u000A(\u001F);
			if (verticalAlignments != VerticalAlignments.Bottom)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u0002.\u0019(ExcelCell, IRange)).MethodHandle;
				}
				if (verticalAlignments != VerticalAlignments.Middle)
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
					\u0017\u001F\u0018.\u000A(\u001F\u0014\u001D.\u000A(\u000A), ExcelVAlign.VAlignTop);
				}
				else
				{
					\u0017\u001F\u0018.\u000A(\u001F\u0014\u001D.\u000A(\u000A), ExcelVAlign.VAlignCenter);
				}
			}
			else
			{
				\u0017\u001F\u0018.\u000A(\u001F\u0014\u001D.\u000A(\u000A), ExcelVAlign.VAlignBottom);
			}
			if (horizontalAlignments == HorizontalAlignments.Left)
			{
				\u0020\u001F\u0018.\u000A(\u001F\u0014\u001D.\u000A(\u000A), ExcelHAlign.HAlignLeft);
				return;
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
			if (horizontalAlignments != HorizontalAlignments.Center)
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
				\u0020\u001F\u0018.\u000A(\u001F\u0014\u001D.\u000A(\u000A), ExcelHAlign.HAlignRight);
				return;
			}
			\u0020\u001F\u0018.\u000A(\u001F\u0014\u001D.\u000A(\u000A), ExcelHAlign.HAlignCenter);
		}

		// Token: 0x0400064C RID: 1612
		private static string \u001F;

		// Token: 0x0200086C RID: 2156
		[CompilerGenerated]
		private static class \u0001\u0002
		{
			// Token: 0x0400217A RID: 8570
			public static CallSite<Func<CallSite, object, bool, object>> \u001F;

			// Token: 0x0400217B RID: 8571
			public static CallSite<Func<CallSite, object, bool, object>> \u000A;

			// Token: 0x0400217C RID: 8572
			public static CallSite<Func<CallSite, object, object>> \u0007;

			// Token: 0x0400217D RID: 8573
			public static CallSite<Func<CallSite, object, object>> \u001D;

			// Token: 0x0400217E RID: 8574
			public static CallSite<Func<CallSite, object, string, object>> \u0004;

			// Token: 0x0400217F RID: 8575
			public static CallSite<Action<CallSite, List<object>, object>> \u0019;

			// Token: 0x04002180 RID: 8576
			public static CallSite<Func<CallSite, object, object>> \u0018;

			// Token: 0x04002181 RID: 8577
			public static CallSite<Func<CallSite, object, string, object>> \u0005;

			// Token: 0x04002182 RID: 8578
			public static CallSite<Action<CallSite, List<object>, object>> \u0016;

			// Token: 0x04002183 RID: 8579
			public static CallSite<Func<CallSite, object, object>> \u000B;

			// Token: 0x04002184 RID: 8580
			public static CallSite<Func<CallSite, object, string, object>> \u0002;

			// Token: 0x04002185 RID: 8581
			public static CallSite<Action<CallSite, List<object>, object>> \u0006;

			// Token: 0x04002186 RID: 8582
			public static CallSite<Action<CallSite, object>> \u000F;

			// Token: 0x04002187 RID: 8583
			public static CallSite<Func<CallSite, object, object>> \u0012;

			// Token: 0x04002188 RID: 8584
			public static CallSite<Func<CallSite, object, string, object>> \u0003;

			// Token: 0x04002189 RID: 8585
			public static CallSite<Action<CallSite, List<object>, object>> \u001C;

			// Token: 0x0400218A RID: 8586
			public static CallSite<Action<CallSite, object>> \u000D;

			// Token: 0x0400218B RID: 8587
			public static CallSite<Func<CallSite, object, object>> \u0010;

			// Token: 0x0400218C RID: 8588
			public static CallSite<Func<CallSite, object, string, object>> \u000E;

			// Token: 0x0400218D RID: 8589
			public static CallSite<Action<CallSite, List<object>, object>> \u0008;

			// Token: 0x0400218E RID: 8590
			public static CallSite<Action<CallSite, object>> \u001B;

			// Token: 0x0400218F RID: 8591
			public static CallSite<Func<CallSite, object, object>> \u0011;

			// Token: 0x04002190 RID: 8592
			public static CallSite<Action<CallSite, List<object>, object>> \u001E;

			// Token: 0x04002191 RID: 8593
			public static CallSite<Func<CallSite, object, bool, object>> \u0020;

			// Token: 0x04002192 RID: 8594
			public static CallSite<Func<CallSite, object, double, object>> \u0017;

			// Token: 0x04002193 RID: 8595
			public static CallSite<Func<CallSite, object, object>> \u0014;

			// Token: 0x04002194 RID: 8596
			public static CallSite<Func<CallSite, object, int, object>> \u0013;

			// Token: 0x04002195 RID: 8597
			public static CallSite<Action<CallSite, object, object>> \u001A;

			// Token: 0x04002196 RID: 8598
			public static CallSite<Func<CallSite, object, object>> \u000C;

			// Token: 0x04002197 RID: 8599
			public static CallSite<Func<CallSite, object, int, int, object>> \u0015;

			// Token: 0x04002198 RID: 8600
			public static CallSite<Action<CallSite, object>> \u0001;

			// Token: 0x04002199 RID: 8601
			public static CallSite<Action<CallSite, object, bool, object, object>> \u0009;

			// Token: 0x0400219A RID: 8602
			public static CallSite<Action<CallSite, object>> \u001F\u000A;

			// Token: 0x0400219B RID: 8603
			public static CallSite<Action<CallSite, List<object>, object>> \u000A\u000A;

			// Token: 0x0400219C RID: 8604
			public static CallSite<Action<CallSite, List<object>, object>> \u0007\u000A;
		}
	}
}

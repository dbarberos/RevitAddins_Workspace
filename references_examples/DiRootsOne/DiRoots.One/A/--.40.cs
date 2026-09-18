using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace A
{
	// Token: 0x020000E2 RID: 226
	internal static class \u001D\u0018
	{
		// Token: 0x1700023A RID: 570
		// (get) Token: 0x0600087B RID: 2171 RVA: 0x00033648 File Offset: 0x00031848
		// (set) Token: 0x0600087C RID: 2172 RVA: 0x0003365C File Offset: 0x0003185C
		internal static Dictionary<BorderLinestyles, GraphicsStyle> LineStyles { get; set; } = \u0018\u0001\u001D.\u000A();

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x0600087D RID: 2173 RVA: 0x00033670 File Offset: 0x00031870
		// (set) Token: 0x0600087E RID: 2174 RVA: 0x00033684 File Offset: 0x00031884
		internal static Dictionary<BorderLinestyles, ElementId> BlackLineStyleIds { get; set; } = \u0019\u0001\u001D.\u000A();

		// Token: 0x0600087F RID: 2175 RVA: 0x00033698 File Offset: 0x00031898
		internal static DetailCurve \u0007(XYZ \u001F, XYZ \u000A, BorderLinestyles \u0007, View \u001D, Document \u0004)
		{
			DetailCurve result;
			try
			{
				Line u = \u0002\u0007\u0007.\u000A(\u001F, \u000A);
				DetailCurve detailCurve = \u0016\u0001\u001D.\u000A(\u000B\u0001\u001D.\u000A(\u0004), \u001D, u);
				GraphicsStyle u000A = \u001D\u0018.\u001D(\u0004, \u0007);
				\u0005\u0001\u001D.\u000A(detailCurve, u000A);
				result = detailCurve;
			}
			catch (Exception u000A2)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\LineHandler.cs", "DrawLineOnView");
				result = \u0020\u0004\u000E.\u001F;
			}
			return result;
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x00033708 File Offset: 0x00031908
		internal static GraphicsStyle \u001D(Document \u001F, BorderLinestyles \u000A)
		{
			if (\u000F\u0001\u001D.\u000A(\u0006\u0001\u001D.\u000A(), \u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0018.\u001D(Document, BorderLinestyles)).MethodHandle;
				}
				return \u0011\u0001\u001D.\u000A(\u0006\u0001\u001D.\u000A(), \u000A);
			}
			GraphicsStyle graphicsStyle = \u0011\u0004\u000E.\u001F;
			string u000A = \u001D\u0018.\u0004(\u000A);
			string text = \u0004\u001E\u000A.\u000A("Imported_", u000A);
			Category category = \u001B\u0001\u001D.\u000A(\u000D\u0001\u001D.\u000A(\u0010\u0001\u001D.\u000A(\u001F)), -2000051L);
			try
			{
				IEnumerator u001F = \u000E\u0001\u001D.\u000A(\u0008\u0001\u001D.\u000A(category));
				try
				{
					while (\u000A\u0017\u000A.\u000A(u001F))
					{
						Category u001F2 = \u001E\u0004\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F));
						if (!\u0008\u0013\u000A.\u000A(\u0009\u0014\u000A.\u001D(u001F2), u000A))
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
							if (!\u0008\u0013\u000A.\u000A(\u0009\u0014\u000A.\u001D(u001F2), text))
							{
								continue;
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
						graphicsStyle = \u0012\u0001\u001D.\u0007(u001F2, 1);
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
					IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
					if (disposable != null)
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
						\u001F\u0017\u000A.\u000A(disposable);
					}
				}
			}
			catch (Exception u000A2)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\LineHandler.cs", "GetOrCreateLineStyle");
				throw;
			}
			if (graphicsStyle == null)
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
				Category u001F3 = \u001C\u0001\u001D.\u000A(\u000D\u0001\u001D.\u000A(\u0010\u0001\u001D.\u000A(\u001F)), category, text);
				\u0003\u0001\u001D.\u000A(u001F3, 4, 1);
				graphicsStyle = \u0012\u0001\u001D.\u0007(u001F3, 1);
			}
			if (!\u000F\u0001\u001D.\u000A(\u0006\u0001\u001D.\u000A(), \u000A))
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
				\u0002\u0001\u001D.\u000A(\u0006\u0001\u001D.\u000A(), \u000A, graphicsStyle);
			}
			return graphicsStyle;
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x000338C0 File Offset: 0x00031AC0
		private static string \u0004(BorderLinestyles \u001F)
		{
			string result = "<Thin Lines>";
			if (\u001F == BorderLinestyles.Thin)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0018.\u0004(BorderLinestyles)).MethodHandle;
				}
				result = "<Thin Lines>";
			}
			else if (\u001F == BorderLinestyles.Thick)
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
				result = "<Wide Lines>";
			}
			else if (\u001F == BorderLinestyles.Medium)
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
				result = "<Medium Lines>";
			}
			else if (\u001F == BorderLinestyles.Overhead)
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
				result = "<Overhead>";
			}
			return result;
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x00033934 File Offset: 0x00031B34
		private static BuiltInCategory \u0019(BorderLinestyles \u001F)
		{
			BuiltInCategory result = -2000042L;
			if (\u001F == BorderLinestyles.Thin)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0018.\u0019(BorderLinestyles)).MethodHandle;
				}
				result = -2000042L;
			}
			else if (\u001F == BorderLinestyles.Thick)
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
				result = -2000044L;
			}
			else if (\u001F == BorderLinestyles.Medium)
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
				result = -2000043L;
			}
			else if (\u001F == BorderLinestyles.Overhead)
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
				result = -2000284L;
			}
			return result;
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x000339AC File Offset: 0x00031BAC
		internal static ElementId \u0018(Document \u001F, BorderLinestyles \u000A)
		{
			BuiltInCategory u000A = \u001D\u0018.\u0019(\u000A);
			ElementId elementId = \u0015\u0014\u000A.\u001D(\u0009\u0018\u0007.\u000A(\u001F, u000A));
			if (\u001B\u001B\u001D.\u000A(elementId, \u0012\u0015\u0010.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0018.\u0018(Document, BorderLinestyles)).MethodHandle;
				}
				return elementId;
			}
			return Constants.InvalidElementId;
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x000339FC File Offset: 0x00031BFC
		internal static List<\u0012\u0005> \u0005(List<\u0012\u0005> \u001F)
		{
			List<\u0012\u0005> list = \u0008\u0013\u001D.\u000A();
			List<\u0012\u0005>.Enumerator enumerator = \u001F\u0009\u001D.\u000A(\u001F);
			try
			{
				while (\u001E\u0001\u001D.\u000A(ref enumerator))
				{
					\u0012\u0005 u0012_u = \u0009\u0001\u001D.\u000A(ref enumerator);
					if (\u0001\u0001\u001D.\u000A(u0012_u) == InputTypes.Line)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0018.\u0005(List<\u0012\u0005>)).MethodHandle;
						}
						double num = \u0015\u0001\u001D.\u000A(u0012_u);
						double num2 = \u000C\u0001\u001D.\u000A(u0012_u);
						double num3 = \u001A\u0001\u001D.\u000A(u0012_u);
						double num4 = \u0013\u0001\u001D.\u000A(u0012_u);
						BorderLinestyles borderLinestyles = \u0014\u0001\u001D.\u000A(u0012_u);
						ExcelLineStyleInfo excelLineStyleInfo = \u0020\u0001\u001D.\u000A(u0012_u);
						bool flag;
						if (excelLineStyleInfo == null)
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
							flag = \u0017\u0001\u001D.\u0007(excelLineStyleInfo);
						}
						bool flag2 = flag;
						bool flag3 = false;
						List<\u0012\u0005>.Enumerator enumerator2 = \u001F\u0009\u001D.\u000A(list);
						try
						{
							while (\u001E\u0001\u001D.\u000A(ref enumerator2))
							{
								\u0012\u0005 u001F = \u0009\u0001\u001D.\u000A(ref enumerator2);
								if (\u0001\u0001\u001D.\u000A(u001F) == InputTypes.Line)
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
									double num5 = \u0015\u0001\u001D.\u000A(u001F);
									double num6 = \u000C\u0001\u001D.\u000A(u001F);
									double num7 = \u001A\u0001\u001D.\u000A(u001F);
									double num8 = \u0013\u0001\u001D.\u000A(u001F);
									BorderLinestyles borderLinestyles2 = \u0014\u0001\u001D.\u000A(u001F);
									ExcelLineStyleInfo excelLineStyleInfo2 = \u0020\u0001\u001D.\u000A(u001F);
									bool flag4;
									if (excelLineStyleInfo2 == null)
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
										flag4 = false;
									}
									else
									{
										flag4 = \u0017\u0001\u001D.\u0007(excelLineStyleInfo2);
									}
									bool flag5 = flag4;
									if (flag2 == flag5)
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
										if (\u001D\u0018.\u0016(\u0020\u0001\u001D.\u000A(u0012_u), \u0020\u0001\u001D.\u000A(u001F)))
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
											if (borderLinestyles == borderLinestyles2)
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
												if (num == num5)
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
													if (num3 == num7)
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
														if (num == num3)
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
															if (num4 >= num8)
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
																if (num2 <= num6)
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
																	flag3 = true;
																	goto IL_243;
																}
															}
														}
													}
												}
												if (num2 == num6)
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
													if (num4 == num8)
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
														if (num2 == num4)
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
															if (num >= num5)
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
																if (num3 <= num7)
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
																	flag3 = true;
																	goto IL_243;
																}
															}
														}
													}
												}
											}
										}
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
							((IDisposable)enumerator2).Dispose();
						}
						IL_243:
						if (!flag3)
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
							double num9 = num3;
							double num10 = num2;
							double num11 = num;
							double num12 = num4;
							enumerator2 = \u001F\u0009\u001D.\u000A(\u001F);
							try
							{
								while (\u001E\u0001\u001D.\u000A(ref enumerator2))
								{
									\u0012\u0005 u001F2 = \u0009\u0001\u001D.\u000A(ref enumerator2);
									if (\u0001\u0001\u001D.\u000A(u001F2) == InputTypes.Line)
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
										double num13 = \u0015\u0001\u001D.\u000A(u001F2);
										double num14 = \u000C\u0001\u001D.\u000A(u001F2);
										double num15 = \u001A\u0001\u001D.\u000A(u001F2);
										double num16 = \u0013\u0001\u001D.\u000A(u001F2);
										BorderLinestyles borderLinestyles3 = \u0014\u0001\u001D.\u000A(u001F2);
										ExcelLineStyleInfo excelLineStyleInfo3 = \u0020\u0001\u001D.\u000A(u001F2);
										bool flag6;
										if (excelLineStyleInfo3 == null)
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
											flag6 = false;
										}
										else
										{
											flag6 = \u0017\u0001\u001D.\u0007(excelLineStyleInfo3);
										}
										bool flag7 = flag6;
										if (flag2 == flag7)
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
											if (\u001D\u0018.\u0016(\u0020\u0001\u001D.\u000A(u0012_u), \u0020\u0001\u001D.\u000A(u001F2)))
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
												if (borderLinestyles == borderLinestyles3)
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
													if (num == num13)
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
														if (num3 == num15)
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
															if (num == num3)
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
																if (num16 >= num12)
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
																	if (num16 <= num10)
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
																		if (num14 > num10)
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
																			num10 = num14;
																			\u0005\u0017\u001D.\u000A(u0012_u, num10);
																			continue;
																		}
																	}
																}
																if (num14 < num12)
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
																if (num14 > num10)
																{
																	continue;
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
																if (num16 < num12)
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
																	num12 = num16;
																	\u0019\u0017\u001D.\u000A(u0012_u, num12);
																	continue;
																}
																continue;
															}
														}
													}
													if (num2 == num14)
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
														if (num4 == num16)
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
															if (num2 == num4)
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
																if (num13 >= num11)
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
																	if (num13 <= num9)
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
																		if (num15 > num9)
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
																			num9 = num15;
																			\u0018\u0017\u001D.\u000A(u0012_u, num9);
																			continue;
																		}
																	}
																}
																if (num15 >= num11)
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
																	if (num15 <= num9)
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
																		if (num13 < num11)
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
																			num11 = num13;
																			\u0016\u0017\u001D.\u000A(u0012_u, num11);
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
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
								((IDisposable)enumerator2).Dispose();
							}
							\u001A\u0020\u001D.\u000A(list, u0012_u);
						}
					}
					else
					{
						\u001A\u0020\u001D.\u000A(list, u0012_u);
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

		// Token: 0x06000885 RID: 2181 RVA: 0x00033F68 File Offset: 0x00032168
		private static bool \u0016(ExcelLineStyleInfo \u001F, ExcelLineStyleInfo \u000A)
		{
			if (\u001F == \u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0018.\u0016(ExcelLineStyleInfo, ExcelLineStyleInfo)).MethodHandle;
				}
				return true;
			}
			if (\u001F != null)
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
				if (\u000A != null)
				{
					return \u000A\u0009\u001D.\u0007(\u001F, \u000A);
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
			return false;
		}

		// Token: 0x04000353 RID: 851
		[CompilerGenerated]
		private static Dictionary<BorderLinestyles, GraphicsStyle> \u001F;

		// Token: 0x04000354 RID: 852
		[CompilerGenerated]
		private static Dictionary<BorderLinestyles, ElementId> \u000A;
	}
}

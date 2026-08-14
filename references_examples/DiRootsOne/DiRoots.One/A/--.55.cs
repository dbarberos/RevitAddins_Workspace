using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.StyleMapping;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x020000F2 RID: 242
	internal static class \u0001\u0018
	{
		// Token: 0x060008D3 RID: 2259 RVA: 0x0003B7D8 File Offset: 0x000399D8
		internal static void \u000A()
		{
			\u0004\u0002\u0004.\u000A(\u0001\u0018.\u001F);
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x0003B7F0 File Offset: 0x000399F0
		internal static DetailCurve \u0007(XYZ \u001F, XYZ \u000A, ExcelLineStyleInfo \u0007, BorderLinestyles \u001D, StyleMappingDto \u0004, View \u0019, Document \u0018, List<\u0015\u0005> \u0005)
		{
			DetailCurve result;
			try
			{
				GraphicsStyle graphicsStyle = \u0001\u0018.\u001D(\u0018, \u0007, \u001D, \u0004, \u0005);
				if (graphicsStyle == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u0018.\u0007(XYZ, XYZ, ExcelLineStyleInfo, BorderLinestyles, StyleMappingDto, View, Document, List<\u0015\u0005>)).MethodHandle;
					}
					result = \u0020\u0004\u000E.\u001F;
				}
				else
				{
					Line u = \u0002\u0007\u0007.\u000A(\u001F, \u000A);
					DetailCurve detailCurve = \u0016\u0001\u001D.\u000A(\u000B\u0001\u001D.\u000A(\u0018), \u0019, u);
					\u0005\u0001\u001D.\u000A(detailCurve, graphicsStyle);
					result = detailCurve;
				}
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\AdvancedLineHandler.cs", "DrawLineOnView");
				result = \u0020\u0004\u000E.\u001F;
			}
			return result;
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x0003B884 File Offset: 0x00039A84
		internal static GraphicsStyle \u001D(Document \u001F, ExcelLineStyleInfo \u000A, BorderLinestyles \u0007, StyleMappingDto \u001D, List<\u0015\u0005> \u0004)
		{
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u0018.\u001D(Document, ExcelLineStyleInfo, BorderLinestyles, StyleMappingDto, List<\u0015\u0005>)).MethodHandle;
				}
				return \u001D\u0018.\u001D(\u001F, \u0007);
			}
			Category category = \u0001\u0018.\u0019(\u001F, \u000A, \u0007, \u001D, \u0004);
			if (category == null)
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
				return null;
			}
			return \u0012\u0001\u001D.\u001D(category, 1);
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x0003B8D8 File Offset: 0x00039AD8
		internal static ElementId \u0004(Document \u001F, ExcelLineStyleInfo \u000A, BorderLinestyles \u0007, StyleMappingDto \u001D, List<\u0015\u0005> \u0004)
		{
			Category category = \u0001\u0018.\u0019(\u001F, \u000A, \u0007, \u001D, \u0004);
			ElementId elementId;
			if (category == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u0018.\u0004(Document, ExcelLineStyleInfo, BorderLinestyles, StyleMappingDto, List<\u0015\u0005>)).MethodHandle;
				}
				elementId = null;
			}
			else
			{
				elementId = \u0015\u0014\u000A.\u0007(category);
			}
			ElementId result;
			if ((result = elementId) == null)
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
				result = \u0011\u001B\u001D.\u000A();
			}
			return result;
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x0003B928 File Offset: 0x00039B28
		private static Category \u0019(Document \u001F, ExcelLineStyleInfo \u000A, BorderLinestyles \u0007, StyleMappingDto \u001D, List<\u0015\u0005> \u0004)
		{
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u0018.\u0019(Document, ExcelLineStyleInfo, BorderLinestyles, StyleMappingDto, List<\u0015\u0005>)).MethodHandle;
				}
				return \u000E\u0002\u0004.\u000A(\u001F, \u001D\u0018.\u0018(\u001F, \u0007));
			}
			LineStyleMapping lineStyleMapping;
			if (\u001D == null)
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
				lineStyleMapping = \u0016\u0019\u000E.\u001F;
			}
			else
			{
				lineStyleMapping = \u001D.\u001D(\u000A);
			}
			LineStyleMapping lineStyleMapping2 = lineStyleMapping;
			if (lineStyleMapping2 != null)
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
				if (\u001B\u0002\u0004.\u0007(lineStyleMapping2))
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
					return null;
				}
			}
			if (lineStyleMapping2 == null)
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
				if (\u0017\u0001\u001D.\u001D(\u000A))
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
					return null;
				}
			}
			int u000A = \u0001\u0018.\u0018(\u000A);
			ElementId u000A2;
			if (\u0008\u0002\u0004.\u000A(\u0001\u0018.\u001F, u000A, ref u000A2))
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
				return \u000E\u0002\u0004.\u000A(\u001F, u000A2);
			}
			string text;
			long? u;
			int u000A3;
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
				text = \u0010\u0002\u0004.\u0007(lineStyleMapping2);
				u = \u000B\u0002\u0004.\u000A(lineStyleMapping2);
				u000A3 = \u001C\u0002\u0004.\u0007(\u000D\u0002\u0004.\u0007(lineStyleMapping2));
			}
			else
			{
				u000A3 = \u001C\u0002\u0004.\u0007(\u000A);
				text = \u0019\u0005.\u000A(\u0002\u0005.\u0008(\u000A));
				\u000B\u0019\u000E.\u001F(ref u);
			}
			Category category = \u0001\u0018.\u0005(\u001F, text, u);
			bool flag = category == \u0002\u0019\u000E.\u001F;
			if (flag)
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
				Category u000A4 = \u001B\u0001\u001D.\u000A(\u000D\u0001\u001D.\u000A(\u0010\u0001\u001D.\u000A(\u001F)), -2000051L);
				Category category2 = \u001C\u0001\u001D.\u000A(\u000D\u0001\u001D.\u000A(\u0010\u0001\u001D.\u000A(\u001F)), u000A4, text);
				\u0003\u0001\u001D.\u000A(category2, u000A3, 1);
				ElementId elementId = \u0001\u0018.\u0016(\u001F, \u000A);
				if (\u001B\u001B\u001D.\u000A(elementId, \u0011\u001B\u001D.\u000A()))
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
					\u0003\u0002\u0004.\u000A(category2, elementId, 1);
				}
				Color color = \u0012\u0002\u0004.\u0007(\u000A);
				if (\u0015\u0017\u001D.\u000A(ref color) == 0)
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
					color = \u0012\u0002\u0004.\u0007(\u000A);
					if (\u000C\u0017\u001D.\u000A(ref color) == 0)
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
						color = \u0012\u0002\u0004.\u0007(\u000A);
						if (\u0013\u0017\u001D.\u000A(ref color) == 0)
						{
							goto IL_21E;
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
				}
				\u000F\u0002\u0004.\u000A(category2, \u0012\u0002\u0004.\u0007(\u000A).\u001F());
				IL_21E:
				category = category2;
			}
			if (\u0004 != null)
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
				\u0002\u0002\u0004.\u000A(\u0004, new \u0015\u0005(\u0006\u0002\u0004.\u000A(), text, flag));
			}
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
					long? num = \u000B\u0002\u0004.\u000A(lineStyleMapping2);
					if (\u0016\u0002\u0004.\u000A(ref num))
					{
						goto IL_29B;
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
				\u0005\u0002\u0004.\u000A(lineStyleMapping2, new long?(\u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(category))));
				IL_29B:
				\u0018\u0002\u0004.\u000A(lineStyleMapping2, false);
			}
			\u0019\u0002\u0004.\u000A(\u0001\u0018.\u001F, u000A, \u0015\u0014\u000A.\u001D(category));
			return category;
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x0003BBF0 File Offset: 0x00039DF0
		private static int \u0018(ExcelLineStyleInfo \u001F)
		{
			return \u001B\u0013\u000A.\u000A(\u001F);
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0003BC08 File Offset: 0x00039E08
		private static Category \u0005(Document \u001F, string \u000A, long? \u0007)
		{
			List<Category> u001F = \u0014\u0002\u0004.\u000A(\u001F);
			List<Category>.Enumerator enumerator;
			if (\u0016\u0002\u0004.\u000A(ref \u0007))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u0018.\u0005(Document, string, long?)).MethodHandle;
				}
				enumerator = \u0020\u0002\u0004.\u000A(u001F);
				try
				{
					while (\u0011\u0002\u0004.\u000A(ref enumerator))
					{
						Category category = \u001E\u0002\u0004.\u000A(ref enumerator);
						if (\u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(category)) == \u0017\u0002\u0004.\u000A(ref \u0007))
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
							return category;
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
			enumerator = \u0020\u0002\u0004.\u000A(u001F);
			try
			{
				while (\u0011\u0002\u0004.\u000A(ref enumerator))
				{
					Category category2 = \u001E\u0002\u0004.\u000A(ref enumerator);
					if (\u0008\u0013\u000A.\u000A(\u0009\u0014\u000A.\u001D(category2), \u000A))
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
						return category2;
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
			return null;
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x0003BD20 File Offset: 0x00039F20
		internal static ElementId \u0016(Document \u001F, ExcelLineStyleInfo \u000A)
		{
			List<LinePatternElement> list = Enumerable.ToList<LinePatternElement>(Enumerable.Cast<LinePatternElement>(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u001E\u0011\u000A.\u000A(\u0005\u0019\u000E.\u001F()))));
			List<ElementId> u001F2;
			switch (\u0015\u0002\u0004.\u0007(\u000A))
			{
			case ExcelLineStyle.Dashed:
			case ExcelLineStyle.Medium_dashed:
			{
				List<LinePatternElement> u001F = list;
				List<LinePatternSegmentType> list2 = \u000C\u0002\u0004.\u000A(2);
				\u001A\u0002\u0004.\u000A(list2, 0);
				\u001A\u0002\u0004.\u000A(list2, 1);
				u001F2 = \u0001\u0018.\u000B(u001F, list2, 0, 1);
				goto IL_139;
			}
			case ExcelLineStyle.Dotted:
			case ExcelLineStyle.Hair:
			{
				List<LinePatternElement> u001F3 = list;
				List<LinePatternSegmentType> list3 = \u000C\u0002\u0004.\u000A(2);
				\u001A\u0002\u0004.\u000A(list3, 2);
				\u001A\u0002\u0004.\u000A(list3, 1);
				u001F2 = \u0001\u0018.\u000B(u001F3, list3, 1, 1);
				goto IL_139;
			}
			case ExcelLineStyle.Dash_dot:
			case ExcelLineStyle.Medium_dash_dot:
			case ExcelLineStyle.Slanted_dash_dot:
			{
				List<LinePatternElement> u001F4 = list;
				List<LinePatternSegmentType> list4 = \u000C\u0002\u0004.\u000A(4);
				\u001A\u0002\u0004.\u000A(list4, 0);
				\u001A\u0002\u0004.\u000A(list4, 1);
				\u001A\u0002\u0004.\u000A(list4, 2);
				\u001A\u0002\u0004.\u000A(list4, 1);
				u001F2 = \u0001\u0018.\u000B(u001F4, list4, 0, 1);
				goto IL_139;
			}
			case ExcelLineStyle.Dash_dot_dot:
			case ExcelLineStyle.Medium_dash_dot_dot:
			{
				List<LinePatternElement> u001F5 = list;
				List<LinePatternSegmentType> list5 = \u000C\u0002\u0004.\u000A(6);
				\u001A\u0002\u0004.\u000A(list5, 0);
				\u001A\u0002\u0004.\u000A(list5, 1);
				\u001A\u0002\u0004.\u000A(list5, 2);
				\u001A\u0002\u0004.\u000A(list5, 1);
				\u001A\u0002\u0004.\u000A(list5, 2);
				\u001A\u0002\u0004.\u000A(list5, 1);
				u001F2 = \u0001\u0018.\u000B(u001F5, list5, 0, 1);
				goto IL_139;
			}
			}
			return \u0011\u001B\u001D.\u000A();
			IL_139:
			if (\u001A\u0014\u000A.\u000A(u001F2) <= 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u0018.\u0016(Document, ExcelLineStyleInfo)).MethodHandle;
				}
				return \u0011\u001B\u001D.\u000A();
			}
			return \u0013\u0002\u0004.\u000A(u001F2, 0);
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x0003BE98 File Offset: 0x0003A098
		private static List<ElementId> \u000B(List<LinePatternElement> \u001F, List<LinePatternSegmentType> \u000A, LinePatternSegmentType \u0007, int \u001D)
		{
			if (\u001D > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u0018.\u000B(List<LinePatternElement>, List<LinePatternSegmentType>, LinePatternSegmentType, int)).MethodHandle;
				}
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
					if (\u000A != null)
					{
						List<ValueTuple<ElementId, double>> list = \u0002\u0006\u0004.\u000A();
						List<LinePatternElement>.Enumerator enumerator = \u000B\u0006\u0004.\u000A(\u001F);
						try
						{
							IL_18E:
							while (\u0001\u0002\u0004.\u000A(ref enumerator))
							{
								LinePatternElement u001F = \u0016\u0006\u0004.\u000A(ref enumerator);
								LinePattern linePattern = \u0005\u0006\u0004.\u0007(u001F);
								IList<LinePatternSegment> list2;
								if (linePattern == null)
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
									list2 = \u0018\u0019\u000E.\u001F;
								}
								else
								{
									list2 = \u0018\u0006\u0004.\u000A(linePattern);
								}
								IList<LinePatternSegment> list3 = list2;
								if (list3 != null)
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
									if (\u0009\u0002\u0004.\u000A(list3) == \u0019\u0006\u0004.\u000A(\u000A))
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
										bool flag = true;
										int i = 0;
										while (i < \u0009\u0002\u0004.\u000A(list3))
										{
											if (\u001D\u0006\u0004.\u000A(\u0007\u0006\u0004.\u000A(list3, i)) != \u0004\u0006\u0004.\u000A(\u000A, i))
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
												IL_FD:
												if (!flag)
												{
													goto IL_18E;
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
												int j = 0;
												while (j < \u0009\u0002\u0004.\u000A(list3))
												{
													if (\u001D\u0006\u0004.\u000A(\u0007\u0006\u0004.\u000A(list3, j)) == \u0007)
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
														double num = \u000A\u0006\u0004.\u000A(\u0007\u0006\u0004.\u000A(list3, j));
														if (num > 0.0)
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
															\u001F\u0006\u0004.\u000A(list, new ValueTuple<ElementId, double>(\u0002\u001E\u000A.\u0007(u001F), num));
															goto IL_18E;
														}
														goto IL_18E;
													}
													else
													{
														j++;
													}
												}
												for (;;)
												{
													switch (4)
													{
													case 0:
														continue;
													}
													goto IL_18E;
												}
											}
											else
											{
												i++;
											}
										}
										for (;;)
										{
											switch (1)
											{
											case 0:
												continue;
											}
											goto IL_FD;
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
						IEnumerable<ValueTuple<ElementId, double>> enumerable = list;
						Func<ValueTuple<ElementId, double>, double> func;
						if ((func = \u0001\u0018.<>c.\u000A) == null)
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
							func = (\u0001\u0018.<>c.\u000A = new Func<ValueTuple<ElementId, double>, double>(\u0001\u0018.<>c.\u001F.\u001D));
						}
						IEnumerable<ValueTuple<ElementId, double>> enumerable2 = Enumerable.Take<ValueTuple<ElementId, double>>(Enumerable.OrderBy<ValueTuple<ElementId, double>, double>(enumerable, func), \u001D);
						Func<ValueTuple<ElementId, double>, ElementId> func2;
						if ((func2 = \u0001\u0018.<>c.\u0007) == null)
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
							func2 = (\u0001\u0018.<>c.\u0007 = new Func<ValueTuple<ElementId, double>, ElementId>(\u0001\u0018.<>c.\u001F.\u0004));
						}
						return Enumerable.ToList<ElementId>(Enumerable.Select<ValueTuple<ElementId, double>, ElementId>(enumerable2, func2));
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
			}
			return \u001C\u0013\u000A.\u000A();
		}

		// Token: 0x04000361 RID: 865
		private static readonly Dictionary<int, ElementId> \u001F = \u001D\u0002\u0004.\u000A();
	}
}

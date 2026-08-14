using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Autodesk.Revit.DB;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.Revit.GroupHelper;
using DiRoots.One.SheetLink.Core.Models;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.UI.Windows;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x02000205 RID: 517
	internal static class \u001B\u0012
	{
		// Token: 0x06001341 RID: 4929 RVA: 0x00078BC8 File Offset: 0x00076DC8
		internal static Tuple<Workbook, List<ParamValueInfo>, Dictionary<string, List<int>>> \u000A(\u0015\u001C \u001F, List<CategoryCollection> \u000A, List<RevitParameter> \u0007, Document \u001D, ProgressModel \u0004, IExportOption \u0019)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityImportExport.cs", "GetData");
			string u001F = \u0020\u001E\u0018.\u000A(\u0019);
			bool flag = \u001E\u001E\u0018.\u000A(\u0019);
			string u000A = \u0018\u000E\u0007.\u000A(\u001F\u0013\u0019.\u000A(), 1, 1);
			List<string> u001F2 = \u001B\u0012.\u0005(\u000A);
			Workbook workbook = \u0011\u001E\u0018.\u000A(u001F);
			Dictionary<string, List<int>> dictionary = \u001B\u001E\u0018.\u000A();
			List<ParamValueInfo> list = \u0008\u001E\u0018.\u000A();
			bool u000A2 = false;
			try
			{
				int u001F3 = \u001B\u0012.\u001F;
				int num = 0;
				string u001D = \u000E\u001E\u0018.\u000A(\u001D);
				List<string>.Enumerator enumerator = \u0013\u0008\u0007.\u000A(u001F2);
				try
				{
					while (\u0017\u0008\u0007.\u000A(ref enumerator))
					{
						\u001B\u0012.\u0002\u0012 u0002_u = new \u001B\u0012.\u0002\u0012();
						u0002_u.\u001F = \u0014\u0008\u0007.\u000A(ref enumerator);
						\u001B\u0012.\u0006\u0012 u0006_u = new \u001B\u0012.\u0006\u0012();
						Worksheet worksheet = \u0012\u0002\u0018.\u000A(u0002_u.\u001F);
						\u0010\u001E\u0018.\u000A(worksheet, workbook);
						\u000D\u001E\u0018.\u000A(worksheet, true);
						\u001C\u001E\u0018.\u000A(worksheet, true);
						\u000F\u0002\u0018.\u000A(\u001E\u001D\u0018.\u000A(workbook), worksheet);
						List<CategoryCollection> list2 = Enumerable.ToList<CategoryCollection>(Enumerable.Where<CategoryCollection>(\u000A, new Func<CategoryCollection, bool>(u0002_u.\u000A)));
						List<RevitParameter> list3 = \u001B\u0012.\u0018(\u001F, list2, \u0007, true);
						int num2 = 2;
						if (\u001D\u0017\u000A.\u000A(u0002_u.\u001F, \u0012\u001E\u0018.\u000A(Enumerable.First<CategoryCollection>(\u000A, new Func<CategoryCollection, bool>(u0002_u.\u0007)))))
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u000A(\u0015\u001C, List<CategoryCollection>, List<RevitParameter>, Document, ProgressModel, IExportOption)).MethodHandle;
							}
							num2 = 3;
						}
						List<ScheduleData> u001F4 = \u0006\u000B\u000E.\u001F;
						List<Element> list4;
						if (\u0016\u001E\u0018.\u0007(\u000B\u001E\u0018.\u000A(\u000A, 0)))
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
							list4 = \u0017\u000D.\u0009(Enumerable.ToList<CategoryCollection>(list2), \u001D, false, ref u001F4);
						}
						else
						{
							IEnumerable<CategoryCollection> enumerable = list2;
							Func<CategoryCollection, IEnumerable<Element>> func;
							if ((func = \u001B\u0012.<>c.\u000A) == null)
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
								func = (\u001B\u0012.<>c.\u000A = new Func<CategoryCollection, IEnumerable<Element>>(\u001B\u0012.<>c.\u001F.\u001B));
							}
							list4 = Enumerable.ToList<Element>(Enumerable.SelectMany<CategoryCollection, Element>(enumerable, func));
						}
						if (\u0004 != null)
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
							Delegate @delegate = \u0006\u000F\u0018.\u001D(\u0004);
							if (@delegate == null)
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
							}
							else
							{
								object[] array = \u0004\u0015\u0010.\u001F(1);
								array[0] = num + 1;
								\u0010\u001F\u0018.\u000A(@delegate, array);
							}
						}
						string u000A3 = \u001E\u0007\u0007.\u000A(\u0003\u001E\u0018.\u000A(), u000A, num + 1, \u0015\u0007\u0019.\u000A(u001F2));
						if (\u0004 != null)
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
							\u0007\u000F\u0018.\u001D(\u0004, u000A3);
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
							list4 = \u0017\u000D.\u0004\u000A(list4, list3);
						}
						else if (!\u0016\u001E\u0018.\u0007(\u000B\u001E\u0018.\u000A(\u000A, 0)))
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
							IEnumerable<Element> enumerable2 = list4;
							Func<Element, string> func2;
							if ((func2 = \u001B\u0012.<>c.\u0007) == null)
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
								func2 = (\u001B\u0012.<>c.\u0007 = new Func<Element, string>(\u001B\u0012.<>c.\u001F.\u0011));
							}
							list4 = Enumerable.ToList<Element>(Enumerable.OrderBy<Element, string>(enumerable2, func2));
						}
						List<Range> list5 = \u0018\u0002\u0018.\u000A();
						if (num2 == 3)
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
							object u001F5 = list5;
							Range range = \u0019\u0002\u0018.\u000A(false);
							\u000B\u0019\u0018.\u000A(range, \u0004\u001E\u000A.\u000A("Name - ", \u0012\u001E\u0018.\u000A(Enumerable.First<CategoryCollection>(\u000A, new Func<CategoryCollection, bool>(u0002_u.\u001D)))));
							\u0013\u0011\u0018.\u000A(range, "DiRootsFullNameTitleStyle");
							\u0004\u0002\u0018.\u000A(range, 1);
							\u001D\u0002\u0018.\u000A(range, 2);
							\u0007\u0002\u0018.\u000A(u001F5, range);
						}
						\u000F\u001E\u0018.\u000A(list3, num2, list5);
						\u0006\u001E\u0018.\u000A(list3, num2, list5);
						u0006_u.\u001F = 1;
						int num3 = 1;
						int num4 = \u0019\u0016\u0004.\u0007(list4);
						int num5 = ProgressModel.EAD(\u0019\u0016\u0004.\u0007(list4));
						int i = num2;
						while (i < num4 + num2)
						{
							if (num3 % num5 == 0)
							{
								goto IL_393;
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
							if (num3 == num4)
							{
								for (;;)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									goto IL_393;
								}
							}
							IL_3D6:
							num3++;
							Element u001F6 = \u000B\u0013\u0019.\u000A(list4, i - num2);
							Dictionary<long, List<Parameter>> u000A4 = \u0015\u001C.\u000B(\u000B\u0013\u0019.\u000A(list4, i - num2), false, \u0016\u001E\u0018.\u0007(\u000B\u001E\u0018.\u000A(\u000A, 0)));
							Dictionary<long, List<Parameter>> u = \u0015\u001C.\u000B(\u000B\u0013\u0019.\u000A(list4, i - num2), true, \u0016\u001E\u0018.\u0007(\u000B\u001E\u0018.\u000A(\u000A, 0)));
							ScheduleData scheduleData = \u0008\u000B\u000E.\u001F;
							if (u001F4 != null)
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
								if (\u0005\u001E\u0018.\u000A(u001F4) > 0)
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
									\u001B\u0012.\u000F\u0012 u000F_u = new \u001B\u0012.\u000F\u0012();
									u000F_u.\u000A = u0006_u;
									u000F_u.\u001F = \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F6));
									scheduleData = \u0018\u001E\u0018.\u000A(u001F4, new Predicate<ScheduleData>(u000F_u.\u0007));
									int u001F7 = u000F_u.\u000A.\u001F;
									u000F_u.\u000A.\u001F = u001F7 + 1;
								}
							}
							bool flag2 = \u0019\u001E\u0018.\u000A(\u0008\u0019\u0007.\u000A(u001F6));
							int num6 = ProgressModel.EAD(\u0008\u000D\u0018.\u000A(list3));
							for (int j = 1; j <= \u0008\u000D\u0018.\u000A(list3); j++)
							{
								if (num6 >= 10)
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
									if (j % num6 != 0)
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
										if (j != num4)
										{
											goto IL_529;
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
									\u0008\u000B\u0004.\u000A();
								}
								IL_529:
								if (\u0005\u0006\u0018.\u000A())
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
									throw \u0003\u0003\u0018.\u000A();
								}
								RevitParameter revitParameter = \u0004\u0008\u0018.\u000A(list3, j - 1);
								string u000A5 = \u0004\u001E\u0018.\u0007(revitParameter);
								Parameter u001F8 = \u0012\u000B\u000E.\u001F;
								object u000A6 = \u0019\u001D\u000E.\u001F;
								bool flag3 = \u0018\u000C\u0019.\u001D(revitParameter);
								string u000A7 = "";
								if (\u0004\u001B\u0018.\u0007(revitParameter) != OtherParamTypes.Schedule)
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
									u000A6 = \u0018\u0012.\u001F(u001F6, u000A4, u, revitParameter, false, out u001F8);
									\u0016\u000F.\u000A(list, num, u0002_u.\u001F, num2, \u0019\u0016\u0004.\u0007(list4), i, j, u001F8, revitParameter, false);
								}
								else if (scheduleData != null)
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
									if (\u001D\u001E\u0018.\u000A(\u0019\u0010\u0018.\u000A(scheduleData), \u0004\u0010\u0018.\u000A(revitParameter)))
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
										SchedulParameter u001F9 = \u0007\u001E\u0018.\u000A(\u0019\u0010\u0018.\u000A(scheduleData), \u0004\u0010\u0018.\u000A(revitParameter));
										string text = \u000A\u001E\u0018.\u000A(u001F9);
										if (!\u0008\u0013\u000A.\u000A(\u001F\u001E\u0018.\u0007(revitParameter), "Count"))
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
											if (!\u0008\u0013\u000A.\u000A(\u001F\u001E\u0018.\u0007(revitParameter), "Formula"))
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
												if (!\u0008\u0013\u000A.\u000A(\u001F\u001E\u0018.\u0007(revitParameter), "ViewBased"))
												{
													u000A7 = "@";
													u000A6 = text;
													goto IL_6F3;
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
										\u0001\u0011\u0018.\u000A(revitParameter, \u0010\u0008\u0018.\u000A(\u0009\u0011\u0018.\u000A(u001F9)));
										\u000C\u0011\u0018.\u000A(\u0010\u0008\u0018.\u000A(revitParameter), \u0015\u0011\u0018.\u000A(\u0019));
										u000A6 = \u001B\u0012.\u001D(list3, j - 1, text, u001D);
										u000A7 = \u001A\u0011\u0018.\u000A(\u0010\u0008\u0018.\u000A(revitParameter));
									}
								}
								IL_6F3:
								string u000A8 = "";
								if (j == 2)
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
									u000A8 = "DiRootsCustomParamStyle";
								}
								else
								{
									if (!flag2)
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
										if (\u0015\u001C.\u000D(u001F8, u000A5))
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
										}
										else
										{
											if (u001F8 != \u0012\u000B\u000E.\u001F && flag3)
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
												u000A8 = "DiRootsTypeStyle";
												goto IL_776;
											}
											if (u001F8 == null)
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
												u000A8 = "DiRootsParameterNotFound";
												goto IL_776;
											}
											goto IL_776;
										}
									}
									u000A8 = "DiRootsReadOnly";
								}
								IL_776:
								object u001F10 = list5;
								Range range2 = \u0019\u0002\u0018.\u000A(false);
								\u000B\u0019\u0018.\u000A(range2, u000A6);
								\u0013\u0011\u0018.\u000A(range2, u000A8);
								\u0004\u0002\u0018.\u000A(range2, i + 1);
								\u001D\u0002\u0018.\u000A(range2, j);
								\u0014\u0011\u0018.\u000A(range2, u000A7);
								\u0007\u0002\u0018.\u000A(u001F10, range2);
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
							i++;
							continue;
							IL_393:
							string u000A9 = \u001E\u0007\u0007.\u000A(\u0002\u001E\u0018.\u000A(), u000A3, num3, \u0019\u0016\u0004.\u0007(list4));
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
								\u0007\u000F\u0018.\u001D(\u0004, u000A9);
							}
							\u0008\u000B\u0004.\u000A();
							goto IL_3D6;
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
						if (\u0008\u000D\u0018.\u000A(\u0007) > 2)
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
							if (\u0017\u0011\u0018.\u000A(\u0004\u0008\u0018.\u000A(\u0007, 2)) != ExportTypes.Rooms)
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
								if (\u0017\u0011\u0018.\u000A(\u0004\u0008\u0018.\u000A(\u0007, 2)) != ExportTypes.Spaces)
								{
									goto IL_8EC;
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
							u000A2 = true;
							if (\u000E\u0011\u0018.\u000A(list) > 0)
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
								List<ParamValueInfo>.Enumerator enumerator2 = \u0001\u000B\u0018.\u000A(list);
								try
								{
									while (\u0014\u000B\u0018.\u000A(ref enumerator2))
									{
										ParamValueInfo u001F11 = \u0015\u000B\u0018.\u000A(ref enumerator2);
										\u0018\u000B\u0018.\u000A(u001F11, \u001B\u0002\u0018.\u000A(u001F11) + 1000);
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
									goto IL_8EC;
								}
								finally
								{
									((IDisposable)enumerator2).Dispose();
								}
							}
							List<ParamValueInfo> u001F12 = list;
							int u000A10 = num;
							int u2 = num2;
							string u001F13 = u0002_u.\u001F;
							Func<RevitParameter, bool> func3;
							if ((func3 = \u001B\u0012.<>c.\u001D) == null)
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
								func3 = (\u001B\u0012.<>c.\u001D = new Func<RevitParameter, bool>(\u001B\u0012.<>c.\u001F.\u001E));
							}
							\u0016\u000F.\u0007(u001F12, u000A10, u2, u001F13, Enumerable.FirstOrDefault<RevitParameter>(\u0007, func3));
						}
						IL_8EC:
						\u0020\u0011\u0018.\u000A(dictionary, u0002_u.\u001F, \u0017\u000B\u001D.\u000A());
						for (int k = 3; k <= \u0008\u000D\u0018.\u000A(list3); k++)
						{
							if (\u0008\u0013\u000A.\u000A(\u001E\u0011\u0018.\u0007(\u0004\u0008\u0018.\u000A(list3, k - 1)), "String"))
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
								\u0020\u000B\u001D.\u000A(\u0011\u0011\u0018.\u000A(dictionary, u0002_u.\u001F), k);
							}
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
						IEnumerable<ParamValueInfo> enumerable3 = list;
						Func<ParamValueInfo, int> func4;
						if ((func4 = \u001B\u0012.<>c.\u0004) == null)
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
							func4 = (\u001B\u0012.<>c.\u0004 = new Func<ParamValueInfo, int>(\u001B\u0012.<>c.\u001F.\u0020));
						}
						IEnumerable<IGrouping<int, ParamValueInfo>> enumerable4 = Enumerable.GroupBy<ParamValueInfo, int>(enumerable3, func4);
						Func<IGrouping<int, ParamValueInfo>, int> func5;
						if ((func5 = \u001B\u0012.<>c.\u0019) == null)
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
							func5 = (\u001B\u0012.<>c.\u0019 = new Func<IGrouping<int, ParamValueInfo>, int>(\u001B\u0012.<>c.\u001F.\u0017));
						}
						Func<IGrouping<int, ParamValueInfo>, List<ParamValueInfo>> func6;
						if ((func6 = \u001B\u0012.<>c.\u0018) == null)
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
							func6 = (\u001B\u0012.<>c.\u0018 = new Func<IGrouping<int, ParamValueInfo>, List<ParamValueInfo>>(\u001B\u0012.<>c.\u001F.\u0014));
						}
						Dictionary<int, List<ParamValueInfo>>.Enumerator enumerator3 = \u001B\u0011\u0018.\u000A(Enumerable.ToDictionary<IGrouping<int, ParamValueInfo>, int, List<ParamValueInfo>>(enumerable4, func5, func6));
						try
						{
							while (\u000D\u0011\u0018.\u000A(ref enumerator3))
							{
								KeyValuePair<int, List<ParamValueInfo>> keyValuePair = \u0008\u0011\u0018.\u000A(ref enumerator3);
								if (\u000E\u0011\u0018.\u000A(\u0010\u0011\u0018.\u000A(ref keyValuePair)) > 0)
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
									\u0016\u000F.\u001D(\u001D, workbook, \u0010\u0011\u0018.\u000A(ref keyValuePair), u001F3++);
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
							((IDisposable)enumerator3).Dispose();
						}
						\u001C\u0011\u0018.\u000A(worksheet, list5);
						\u0003\u0011\u0018.\u000A(worksheet, \u000B\u0002\u0018.\u000A(num2, \u0019\u0016\u0004.\u0007(list4) + num2, 1, \u0008\u000D\u0018.\u000A(list3)));
						if (num2 == 3)
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
							\u000F\u0011\u0018.\u000A(\u0012\u0011\u0018.\u000A(worksheet), \u000B\u0002\u0018.\u000A(1, 1, 2, \u0008\u000D\u0018.\u000A(list3)));
						}
						object u001F14 = \u0006\u0011\u0018.\u000A(worksheet);
						ExcelRow excelRow = \u0002\u0011\u0018.\u000A();
						\u000B\u0011\u0018.\u000A(excelRow, num2);
						\u0016\u0011\u0018.\u000A(excelRow, 54.0);
						\u0018\u0011\u0018.\u000A(u001F14, excelRow);
						object u001F15 = \u0006\u0011\u0018.\u000A(worksheet);
						ExcelRow excelRow2 = \u0002\u0011\u0018.\u000A();
						\u000B\u0011\u0018.\u000A(excelRow2, num2 - 1);
						\u0016\u0011\u0018.\u000A(excelRow2, 0.0);
						\u0005\u0011\u0018.\u000A(excelRow2, true);
						\u0018\u0011\u0018.\u000A(u001F15, excelRow2);
						num++;
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
				\u001B\u0012.\u0016(workbook, u000A2);
			}
			catch (Exception u000A11)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A11, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityImportExport.cs", "GetData");
				throw;
			}
			finally
			{
				Action<CategoryCollection> u000A12;
				if ((u000A12 = \u001B\u0012.<>c.\u0005) == null)
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
					u000A12 = (\u001B\u0012.<>c.\u0005 = new Action<CategoryCollection>(\u001B\u0012.<>c.\u001F.\u0013));
				}
				\u0019\u0011\u0018.\u000A(\u000A, u000A12);
			}
			\u001B\u0012.\u001F = 1;
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityImportExport.cs", "GetData");
			return \u0004\u0011\u0018.\u000A(workbook, list, dictionary);
		}

		// Token: 0x06001342 RID: 4930 RVA: 0x00079820 File Offset: 0x00077A20
		internal static bool \u0007(\u0015\u001C \u001F, List<CategoryCollection> \u000A, List<RevitParameter> \u0007, Document \u001D, IExportOption \u0004, Delegate \u0019)
		{
			string u001F = \u0020\u001E\u0018.\u000A(\u0004);
			List<string> list = \u001B\u0012.\u0005(\u000A);
			bool result;
			try
			{
				\u0010\u0008\u000A u0010_u0008_u000A = new \u0010\u0008\u000A(u001F, list);
				IWorkbook u001F2 = \u0003\u001F\u0018.\u0007(u0010_u0008_u000A);
				\u000A\u0020\u0018.\u000A(u001F2);
				string u001D = \u000E\u001E\u0018.\u000A(\u001D);
				int num = 1;
				List<string>.Enumerator enumerator = \u0013\u0008\u0007.\u000A(list);
				try
				{
					while (\u0017\u0008\u0007.\u000A(ref enumerator))
					{
						\u001B\u0012.\u0012\u0012 u0012_u = new \u001B\u0012.\u0012\u0012();
						u0012_u.\u001F = \u0014\u0008\u0007.\u000A(ref enumerator);
						if (\u0019 != null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u0007(\u0015\u001C, List<CategoryCollection>, List<RevitParameter>, Document, IExportOption, Delegate)).MethodHandle;
							}
							object[] array = \u0004\u0015\u0010.\u001F(1);
							array[0] = num;
							\u0010\u001F\u0018.\u000A(\u0019, array);
						}
						IWorksheet worksheet = Enumerable.FirstOrDefault<IWorksheet>(\u0003\u001E\u001D.\u000A(u001F2), new Func<IWorksheet, bool>(u0012_u.\u000A));
						if (worksheet == null)
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
							worksheet = \u0012\u001F\u0018.\u000A(\u0003\u001E\u001D.\u000A(u001F2), u0012_u.\u001F);
						}
						List<RevitParameter> list2 = \u001B\u0012.\u0018(\u001F, Enumerable.ToList<CategoryCollection>(Enumerable.Where<CategoryCollection>(\u000A, new Func<CategoryCollection, bool>(u0012_u.\u0007))), \u0007, false);
						int num2 = 1;
						if (\u001D\u0017\u000A.\u000A(u0012_u.\u001F, \u0012\u001E\u0018.\u000A(Enumerable.First<CategoryCollection>(\u000A, new Func<CategoryCollection, bool>(u0012_u.\u001D)))))
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
							num2 = 2;
						}
						\u001F\u0020\u0018.\u000A(list2, worksheet, num2);
						DataTable dataTable = \u001F\u0012.\u0019(Enumerable.First<CategoryCollection>(\u000A, new Func<CategoryCollection, bool>(u0012_u.\u0004)), \u001D, list2);
						if (dataTable != null)
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
							if (\u000A\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(dataTable)) > 0)
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
								List<int> u001F3 = \u0017\u000B\u001D.\u000A();
								for (int i = 0; i < \u0008\u000D\u0018.\u000A(list2); i++)
								{
									if (\u0008\u0013\u000A.\u000A(\u001E\u0011\u0018.\u0007(\u0004\u0008\u0018.\u000A(list2, i)), "String"))
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
										\u0020\u000B\u001D.\u000A(u001F3, i);
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
								for (int j = num2; j < \u000A\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(dataTable)) + num2; j++)
								{
									for (int k = 0; k < \u0008\u000D\u0018.\u000A(list2); k++)
									{
										IRange range = \u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet), j + 1, k + 1);
										object u = \u001F\u000F\u0018.\u000A(\u0011\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(dataTable), j - num2), k);
										\u000C\u0011\u0018.\u000A(\u0010\u0008\u0018.\u000A(\u0004\u0008\u0018.\u000A(list2, k)), \u0015\u0011\u0018.\u000A(\u0004));
										object obj = \u001B\u0012.\u001D(list2, k, u, u001D);
										if (\u0005\u001F\u0018.\u000A(u001F3, k))
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
											\u0015\u001E\u0018.\u000A(range, "@");
											object u001F4 = range;
											string u000A;
											if (obj == null)
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
												u000A = \u000F\u0015\u0010.\u001F;
											}
											else
											{
												u000A = \u001A\u000C\u000A.\u000A(obj);
											}
											\u0009\u001E\u0018.\u000A(u001F4, u000A);
										}
										else
										{
											\u0001\u001E\u0018.\u000A(range, obj);
										}
										string text = \u001A\u0011\u0018.\u000A(\u0010\u0008\u0018.\u000A(\u0004\u0008\u0018.\u000A(list2, k)));
										if (!\u001A\u0006\u0007.\u000A(text))
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
											\u0015\u001E\u0018.\u000A(range, text);
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
						\u000C\u001E\u0018.\u000A(\u0018\u001E\u001D.\u000A(worksheet));
						\u0013\u001E\u0018.\u000A(\u001A\u001E\u0018.\u000A(worksheet), \u0018\u001E\u001D.\u000A(worksheet));
						\u0014\u001E\u0018.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(worksheet), num2, 1, num2, \u0008\u000D\u0018.\u000A(list2)), true);
						if (num2 == 2)
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
							\u0017\u001E\u0018.\u000A(\u0012\u001E\u0018.\u000A(Enumerable.First<CategoryCollection>(\u000A, new Func<CategoryCollection, bool>(u0012_u.\u0019))), worksheet, \u0008\u000D\u0018.\u000A(list2));
						}
						num++;
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
				u0010_u0008_u000A.\u0004("");
				u0010_u0008_u000A.\u0019();
				result = true;
			}
			finally
			{
				Action<CategoryCollection> u000A2;
				if ((u000A2 = \u001B\u0012.<>c.\u0016) == null)
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
					u000A2 = (\u001B\u0012.<>c.\u0016 = new Action<CategoryCollection>(\u001B\u0012.<>c.\u001F.\u001A));
				}
				\u0019\u0011\u0018.\u000A(\u000A, u000A2);
			}
			return result;
		}

		// Token: 0x06001343 RID: 4931 RVA: 0x00079CA4 File Offset: 0x00077EA4
		private static object \u001D(List<RevitParameter> \u001F, int \u000A, object \u0007, string \u001D)
		{
			UnitOption u001F = \u0010\u0008\u0018.\u000A(\u0004\u0008\u0018.\u000A(\u001F, \u000A));
			if (\u0003\u0008\u0018.\u000A(u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u001D(List<RevitParameter>, int, object, string)).MethodHandle;
				}
				string text = \u001A\u000C\u000A.\u000A(\u0007);
				if (!\u001A\u0006\u0007.\u000A(\u0007\u0020\u0018.\u000A(u001F)))
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
					text = \u0003\u000B\u001D.\u0007(\u001C\u000B\u001D.\u0007(text, \u0007\u0020\u0018.\u000A(u001F), ""));
				}
				text = \u001C\u000B\u001D.\u0007(text, \u001D, "");
				if (\u000F\u000C\u001D.\u0007(text, ","))
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
					text = \u001C\u000B\u001D.\u0007(text, ",", ".");
				}
				double num;
				if (\u0017\u001B\u0018.\u000A(text, NumberStyles.Any, \u001F\u0015\u000A.\u000A(), ref num))
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
					\u0007 = num;
				}
				else
				{
					\u0007 = text;
				}
			}
			return \u0007;
		}

		// Token: 0x06001344 RID: 4932 RVA: 0x00079D94 File Offset: 0x00077F94
		internal static Workbook \u0004(\u0015\u001C \u001F, List<CategoryCollection> \u000A, List<RevitParameter> \u0007, Document \u001D, IExportOption \u0004, Delegate \u0019)
		{
			string u001F = \u0020\u001E\u0018.\u000A(\u0004);
			List<string> u001F2 = \u001B\u0012.\u0005(\u000A);
			Workbook workbook = \u0011\u001E\u0018.\u000A(u001F);
			Workbook result;
			try
			{
				string u001D = \u000E\u001E\u0018.\u000A(\u001D);
				List<string>.Enumerator enumerator = \u0013\u0008\u0007.\u000A(u001F2);
				try
				{
					while (\u0017\u0008\u0007.\u000A(ref enumerator))
					{
						\u001B\u0012.\u0003\u0012 u0003_u = new \u001B\u0012.\u0003\u0012();
						u0003_u.\u001F = \u0014\u0008\u0007.\u000A(ref enumerator);
						if (\u0019 != null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u0004(\u0015\u001C, List<CategoryCollection>, List<RevitParameter>, Document, IExportOption, Delegate)).MethodHandle;
							}
							object[] array = \u0004\u0015\u0010.\u001F(1);
							array[0] = 1;
							\u0010\u001F\u0018.\u000A(\u0019, array);
						}
						Worksheet worksheet = \u0012\u0002\u0018.\u000A(u0003_u.\u001F);
						\u000F\u0002\u0018.\u000A(\u001E\u001D\u0018.\u000A(workbook), worksheet);
						List<RevitParameter> list = \u001B\u0012.\u0018(\u001F, Enumerable.ToList<CategoryCollection>(Enumerable.Where<CategoryCollection>(\u000A, new Func<CategoryCollection, bool>(u0003_u.\u000A))), \u0007, false);
						int num = 1;
						List<Range> list2 = \u0018\u0002\u0018.\u000A();
						if (\u001D\u0017\u000A.\u000A(u0003_u.\u001F, \u0012\u001E\u0018.\u000A(Enumerable.First<CategoryCollection>(\u000A, new Func<CategoryCollection, bool>(u0003_u.\u0007)))))
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
							num = 2;
							object u001F3 = list2;
							Range range = \u0019\u0002\u0018.\u000A(false);
							\u000B\u0019\u0018.\u000A(range, \u0004\u001E\u000A.\u000A("Name - ", \u0012\u001E\u0018.\u000A(Enumerable.First<CategoryCollection>(\u000A, new Func<CategoryCollection, bool>(u0003_u.\u001D)))));
							\u0013\u0011\u0018.\u000A(range, "DiRootsFullNameTitleStyle");
							\u0004\u0002\u0018.\u000A(range, 0);
							\u001D\u0002\u0018.\u000A(range, 2);
							\u0007\u0002\u0018.\u000A(u001F3, range);
						}
						for (int i = 0; i < \u0008\u000D\u0018.\u000A(list); i++)
						{
							object u001F4 = list2;
							Range range2 = \u0019\u0002\u0018.\u000A(false);
							\u000B\u0019\u0018.\u000A(range2, \u001D\u001B\u0018.\u0007(\u0004\u0008\u0018.\u000A(list, i)));
							\u0004\u0002\u0018.\u000A(range2, num - 1);
							\u001D\u0002\u0018.\u000A(range2, i);
							\u0013\u0011\u0018.\u000A(range2, "DiRootsHeaderStyle");
							\u0007\u0002\u0018.\u000A(u001F4, range2);
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
						DataTable dataTable = \u001F\u0012.\u0018(Enumerable.First<CategoryCollection>(\u000A, new Func<CategoryCollection, bool>(u0003_u.\u0004)), \u001D, list);
						if (dataTable != null)
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
							if (\u000A\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(dataTable)) > 0)
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
								for (int j = 0; j < \u000A\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(dataTable)); j++)
								{
									for (int k = 0; k < \u0008\u000D\u0018.\u000A(list); k++)
									{
										object obj = \u001F\u000F\u0018.\u000A(\u0011\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(dataTable), j), k);
										obj = \u001B\u0012.\u001D(list, k, obj, u001D);
										object u001F5 = list2;
										Range range3 = \u0019\u0002\u0018.\u000A(false);
										\u000B\u0019\u0018.\u000A(range3, obj);
										\u0004\u0002\u0018.\u000A(range3, j + num);
										\u001D\u0002\u0018.\u000A(range3, k);
										\u0007\u0002\u0018.\u000A(u001F5, range3);
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
						\u001C\u0011\u0018.\u000A(worksheet, list2);
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
				result = workbook;
			}
			finally
			{
				Action<CategoryCollection> u000A;
				if ((u000A = \u001B\u0012.<>c.\u000B) == null)
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
					u000A = (\u001B\u0012.<>c.\u000B = new Action<CategoryCollection>(\u001B\u0012.<>c.\u001F.\u000C));
				}
				\u0019\u0011\u0018.\u000A(\u000A, u000A);
			}
			return result;
		}

		// Token: 0x06001345 RID: 4933 RVA: 0x0007A0FC File Offset: 0x000782FC
		internal unsafe static bool \u0019(List<CategoryCollection> \u001F, Window \u000A, ref string \u0007)
		{
			\u001B\u0012.\u0005(\u001F);
			if (!\u0010\u0002\u001D.\u000A(\u0007))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u0019(List<CategoryCollection>, Window, string*)).MethodHandle;
				}
				return true;
			}
			bool result = true;
			List<string> u001F = \u0014\u000D\u0007.\u000A();
			try
			{
				\u0010\u0008\u000A u0010_u0008_u000A = new \u0010\u0008\u000A(\u0007, false);
				IWorkbook u001F2 = \u0003\u001F\u0018.\u0007(u0010_u0008_u000A);
				IWorksheets worksheets = \u0003\u001E\u001D.\u000A(u001F2);
				\u001B\u0012.\u001F = \u0016\u0020\u0018.\u000A(\u0007\u0020\u001D.\u000A(u001F2)) + 1;
				List<CategoryCollection>.Enumerator enumerator = \u0014\u0016\u0018.\u000A(\u001F);
				try
				{
					while (\u001E\u0016\u0018.\u000A(ref enumerator))
					{
						\u001B\u0012.\u001C\u0012 u001C_u = new \u001B\u0012.\u001C\u0012();
						u001C_u.\u001F = \u0017\u0016\u0018.\u000A(ref enumerator);
						if (Enumerable.FirstOrDefault<IWorksheet>(worksheets, new Func<IWorksheet, bool>(u001C_u.\u000A)) != null)
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
							\u001A\u0008\u0007.\u000A(u001F, \u0001\u0016\u0018.\u000A(u001C_u.\u001F));
						}
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
					((IDisposable)enumerator).Dispose();
				}
				ReplaceConfirmation u001F3 = \u0005\u0020\u0018.\u000A(u001F, \u0007);
				\u0015\u000D\u001D.\u000A(u001F3, \u000A);
				bool? flag = \u0018\u0020\u000A.\u0007(u001F3);
				if (\u0012\u0015\u000A.\u000A(ref flag))
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
					if (\u0019\u0020\u0018.\u000A(u001F3) == WriteModes.CreateFile)
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
						\u0007 = \u0018\u0020\u0018.\u0007(u001F3);
						result = false;
					}
					else if (\u0019\u0020\u0018.\u000A(u001F3) == WriteModes.RemoveSheets)
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
						enumerator = \u0014\u0016\u0018.\u000A(\u001F);
						try
						{
							while (\u001E\u0016\u0018.\u000A(ref enumerator))
							{
								\u001B\u0012.\u000D\u0012 u000D_u = new \u001B\u0012.\u000D\u0012();
								u000D_u.\u001F = \u0017\u0016\u0018.\u000A(ref enumerator);
								IWorksheet worksheet = Enumerable.FirstOrDefault<IWorksheet>(worksheets, new Func<IWorksheet, bool>(u000D_u.\u000A));
								if (worksheet == null)
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
								}
								else
								{
									\u0004\u0020\u0018.\u000A(\u0010\u0014\u001D.\u000A(worksheet), false);
								}
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
							((IDisposable)enumerator).Dispose();
						}
						u0010_u0008_u000A.\u0004("");
					}
				}
				else
				{
					\u0007 = "";
				}
				u0010_u0008_u000A.\u0019();
			}
			catch (SystemException u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityImportExport.cs", "ProceedWithFile");
				\u0007 = "";
				\u000F\u0005\u0019.\u000A(\u001D\u0020\u0018.\u000A(), \u000A, MessageBoxButtons.OK);
			}
			return result;
		}

		// Token: 0x06001346 RID: 4934 RVA: 0x0007A378 File Offset: 0x00078578
		internal static List<RevitParameter> \u0018(\u0015\u001C \u001F, List<CategoryCollection> \u000A, List<RevitParameter> \u0007, bool \u001D)
		{
			\u001B\u0012.\u0010\u0012 u0010_u = new \u001B\u0012.\u0010\u0012();
			u0010_u.\u001F = \u0007;
			u0010_u.\u0007 = \u001F;
			u0010_u.\u000A = \u000D\u000E\u0018.\u000A();
			u0010_u.\u001D = \u001F\u001B\u0019.\u000A();
			List<CategoryCollection>.Enumerator enumerator = \u0014\u0016\u0018.\u000A(\u000A);
			try
			{
				while (\u001E\u0016\u0018.\u000A(ref enumerator))
				{
					long u000A = \u001B\u0020\u0018.\u000A(\u0017\u0016\u0018.\u000A(ref enumerator));
					\u0001\u000E\u0019.\u000A(u0010_u.\u001D, u000A);
					if (\u0008\u0020\u0018.\u000A(\u000E\u0020\u0018.\u000A(u0010_u.\u0007), u000A))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u0018(\u0015\u001C, List<CategoryCollection>, List<RevitParameter>, bool)).MethodHandle;
						}
						\u000D\u0020\u0018.\u000A(u0010_u.\u000A, \u0010\u0020\u0018.\u000A(\u000E\u0020\u0018.\u000A(u0010_u.\u0007), u000A));
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
			List<RevitParameter> list;
			if (\u0016\u001E\u0018.\u0007(\u000B\u001E\u0018.\u000A(\u000A, 0)))
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
				list = Enumerable.ToList<RevitParameter>(Enumerable.Where<RevitParameter>(u0010_u.\u000A, new Func<RevitParameter, bool>(u0010_u.\u0019)));
			}
			else
			{
				list = Enumerable.ToList<RevitParameter>(Enumerable.Where<RevitParameter>(u0010_u.\u001F, new Func<RevitParameter, bool>(u0010_u.\u0018)));
			}
			object u001F = list;
			Action<RevitParameter> u000A2;
			if ((u000A2 = \u001B\u0012.<>c.\u0002) == null)
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
				u000A2 = (\u001B\u0012.<>c.\u0002 = new Action<RevitParameter>(\u001B\u0012.<>c.\u001F.\u0015));
			}
			\u001C\u0020\u0018.\u000A(u001F, u000A2);
			if (\u001D)
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
				Func<CategoryCollection, bool> func;
				if ((func = \u001B\u0012.<>c.\u0006) == null)
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
					func = (\u001B\u0012.<>c.\u0006 = new Func<CategoryCollection, bool>(\u001B\u0012.<>c.\u001F.\u0001));
				}
				bool d = Enumerable.Any<CategoryCollection>(\u000A, func);
				RevitParameter.DO(u0010_u.\u0007, list, d);
			}
			\u001C\u0020\u0018.\u000A(list, new Action<RevitParameter>(u0010_u.\u0005));
			List<RevitParameter>.Enumerator enumerator2 = \u0013\u000D\u0018.\u000A(list);
			try
			{
				while (\u0011\u000D\u0018.\u000A(ref enumerator2))
				{
					RevitParameter u001F2 = \u0014\u000D\u0018.\u000A(ref enumerator2);
					if (\u0003\u0020\u0018.\u000A(\u0012\u0020\u0018.\u0007(u0010_u.\u0007), \u000F\u0020\u0018.\u0007(u001F2)))
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
						IEnumerable<KeyValuePair<long, List<long>>> enumerable = \u0002\u0020\u0018.\u000A(\u0006\u0020\u0018.\u000A(\u0012\u0020\u0018.\u0007(u0010_u.\u0007), \u000F\u0020\u0018.\u0007(u001F2)));
						Func<KeyValuePair<long, List<long>>, bool> func2;
						if ((func2 = u0010_u.\u0004) == null)
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
							func2 = (u0010_u.\u0004 = new Func<KeyValuePair<long, List<long>>, bool>(u0010_u.\u0016));
						}
						IEnumerable<KeyValuePair<long, List<long>>> enumerable2 = Enumerable.Where<KeyValuePair<long, List<long>>>(enumerable, func2);
						Func<KeyValuePair<long, List<long>>, IEnumerable<long>> func3;
						if ((func3 = \u001B\u0012.<>c.\u000F) == null)
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
							func3 = (\u001B\u0012.<>c.\u000F = new Func<KeyValuePair<long, List<long>>, IEnumerable<long>>(\u001B\u0012.<>c.\u001F.\u0009));
						}
						List<long> u000A3 = Enumerable.ToList<long>(Enumerable.SelectMany<KeyValuePair<long, List<long>>, long>(enumerable2, func3));
						\u000B\u0020\u0018.\u000A(u001F2, u000A3);
					}
					else
					{
						\u000B\u0020\u0018.\u000A(u001F2, \u001F\u001B\u0019.\u000A());
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
			return list;
		}

		// Token: 0x06001347 RID: 4935 RVA: 0x0007A66C File Offset: 0x0007886C
		internal static List<string> \u0005(List<CategoryCollection> \u001F)
		{
			List<CategoryCollection> list = \u0017\u0017\u0019.\u000A();
			Func<CategoryCollection, bool> func;
			if ((func = \u001B\u0012.<>c.\u0012) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u0005(List<CategoryCollection>)).MethodHandle;
				}
				func = (\u001B\u0012.<>c.\u0012 = new Func<CategoryCollection, bool>(\u001B\u0012.<>c.\u001F.\u001F\u000A));
			}
			object u001F = Enumerable.ToList<CategoryCollection>(Enumerable.Where<CategoryCollection>(\u001F, func));
			Action<CategoryCollection> u000A;
			if ((u000A = \u001B\u0012.<>c.\u0003) == null)
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
				u000A = (\u001B\u0012.<>c.\u0003 = new Action<CategoryCollection>(\u001B\u0012.<>c.\u001F.\u000A\u000A));
			}
			\u0019\u0011\u0018.\u000A(u001F, u000A);
			Action<CategoryCollection> u000A2;
			if ((u000A2 = \u001B\u0012.<>c.\u001C) == null)
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
				u000A2 = (\u001B\u0012.<>c.\u001C = new Action<CategoryCollection>(\u001B\u0012.<>c.\u001F.\u0007\u000A));
			}
			\u0019\u0011\u0018.\u000A(\u001F, u000A2);
			Action<CategoryCollection> u000A3;
			if ((u000A3 = \u001B\u0012.<>c.\u000D) == null)
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
				u000A3 = (\u001B\u0012.<>c.\u000D = new Action<CategoryCollection>(\u001B\u0012.<>c.\u001F.\u001D\u000A));
			}
			\u0019\u0011\u0018.\u000A(\u001F, u000A3);
			\u0004\u000F.\u000B(\u001F);
			Func<CategoryCollection, string> func2;
			if ((func2 = \u001B\u0012.<>c.\u0010) == null)
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
				func2 = (\u001B\u0012.<>c.\u0010 = new Func<CategoryCollection, string>(\u001B\u0012.<>c.\u001F.\u0004\u000A));
			}
			IEnumerable<IGrouping<string, CategoryCollection>> enumerable = Enumerable.GroupBy<CategoryCollection, string>(\u001F, func2);
			Func<IGrouping<string, CategoryCollection>, CategoryCollection> func3;
			if ((func3 = \u001B\u0012.<>c.\u000E) == null)
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
				func3 = (\u001B\u0012.<>c.\u000E = new Func<IGrouping<string, CategoryCollection>, CategoryCollection>(\u001B\u0012.<>c.\u001F.\u0019\u000A));
			}
			\u0011\u0020\u0018.\u000A(list, Enumerable.Select<IGrouping<string, CategoryCollection>, CategoryCollection>(enumerable, func3));
			Func<CategoryCollection, string> func4;
			if ((func4 = \u001B\u0012.<>c.\u0008) == null)
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
				func4 = (\u001B\u0012.<>c.\u0008 = new Func<CategoryCollection, string>(\u001B\u0012.<>c.\u001F.\u0018\u000A));
			}
			return Enumerable.ToList<string>(Enumerable.Select<CategoryCollection, string>(list, func4));
		}

		// Token: 0x06001348 RID: 4936 RVA: 0x0007A7F4 File Offset: 0x000789F4
		internal static void \u0016(Workbook \u001F, bool \u000A = false)
		{
			Worksheet worksheet = \u0012\u0002\u0018.\u000A("Instructions");
			List<Range> list = \u0018\u0002\u0018.\u000A();
			DiRoots.One.Commons.Models.Style style = \u0001\u0020\u0018.\u000A();
			\u0015\u0020\u0018.\u000A(\u000C\u0020\u0018.\u000A(style), true);
			\u001A\u0020\u0018.\u000A(\u000C\u0020\u0018.\u000A(style), 12f);
			object u001F = list;
			Range range = \u0019\u0002\u0018.\u000A(true);
			\u000B\u0019\u0018.\u000A(range, \u001D\u0017\u0018.\u000A());
			\u0014\u0020\u0018.\u000A(range, style);
			\u0004\u0002\u0018.\u000A(range, 2);
			\u001D\u0002\u0018.\u000A(range, 2);
			\u0007\u0002\u0018.\u000A(u001F, range);
			object u001F2 = list;
			Range range2 = \u0019\u0002\u0018.\u000A(true);
			\u000B\u0019\u0018.\u000A(range2, \u0007\u0017\u0018.\u000A());
			\u0014\u0020\u0018.\u000A(range2, style);
			\u0004\u0002\u0018.\u000A(range2, 2);
			\u001D\u0002\u0018.\u000A(range2, 3);
			\u0007\u0002\u0018.\u000A(u001F2, range2);
			style = \u0001\u0020\u0018.\u000A();
			\u0015\u0020\u0018.\u000A(\u000C\u0020\u0018.\u000A(style), false);
			\u001A\u0020\u0018.\u000A(\u000C\u0020\u0018.\u000A(style), 10f);
			object u001F3 = list;
			Range range3 = \u0019\u0002\u0018.\u000A(true);
			\u0013\u0011\u0018.\u000A(range3, "DiRootsTypeStyle");
			\u0004\u0002\u0018.\u000A(range3, 3);
			\u001D\u0002\u0018.\u000A(range3, 2);
			\u0007\u0002\u0018.\u000A(u001F3, range3);
			object u001F4 = list;
			Range range4 = \u0019\u0002\u0018.\u000A(true);
			\u000B\u0019\u0018.\u000A(range4, \u000A\u0017\u0018.\u000A());
			\u0014\u0020\u0018.\u000A(range4, style);
			\u0004\u0002\u0018.\u000A(range4, 3);
			\u001D\u0002\u0018.\u000A(range4, 3);
			\u0007\u0002\u0018.\u000A(u001F4, range4);
			object u001F5 = list;
			Range range5 = \u0019\u0002\u0018.\u000A(true);
			\u0013\u0011\u0018.\u000A(range5, "DiRootsReadOnly");
			\u0004\u0002\u0018.\u000A(range5, 4);
			\u001D\u0002\u0018.\u000A(range5, 2);
			\u0007\u0002\u0018.\u000A(u001F5, range5);
			object u001F6 = list;
			Range range6 = \u0019\u0002\u0018.\u000A(true);
			\u000B\u0019\u0018.\u000A(range6, \u001F\u0017\u0018.\u000A());
			\u0014\u0020\u0018.\u000A(range6, style);
			\u0004\u0002\u0018.\u000A(range6, 4);
			\u001D\u0002\u0018.\u000A(range6, 3);
			\u0007\u0002\u0018.\u000A(u001F6, range6);
			object u001F7 = list;
			Range range7 = \u0019\u0002\u0018.\u000A(true);
			\u0013\u0011\u0018.\u000A(range7, "DiRootsParameterNotFound");
			\u0004\u0002\u0018.\u000A(range7, 5);
			\u001D\u0002\u0018.\u000A(range7, 2);
			\u0007\u0002\u0018.\u000A(u001F7, range7);
			object u001F8 = list;
			Range range8 = \u0019\u0002\u0018.\u000A(true);
			\u000B\u0019\u0018.\u000A(range8, \u0009\u0020\u0018.\u000A());
			\u0014\u0020\u0018.\u000A(range8, style);
			\u0004\u0002\u0018.\u000A(range8, 5);
			\u001D\u0002\u0018.\u000A(range8, 3);
			\u0007\u0002\u0018.\u000A(u001F8, range8);
			style = \u0001\u0020\u0018.\u000A();
			\u0015\u0020\u0018.\u000A(\u000C\u0020\u0018.\u000A(style), true);
			\u001A\u0020\u0018.\u000A(\u000C\u0020\u0018.\u000A(style), 10f);
			object u001F9 = list;
			Range range9 = \u0019\u0002\u0018.\u000A(true);
			\u000B\u0019\u0018.\u000A(range9, \u0013\u0020\u0018.\u000A());
			\u0014\u0020\u0018.\u000A(range9, style);
			\u0004\u0002\u0018.\u000A(range9, 7);
			\u001D\u0002\u0018.\u000A(range9, 2);
			\u0007\u0002\u0018.\u000A(u001F9, range9);
			if (\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u0016(Workbook, bool)).MethodHandle;
				}
				object u001F10 = list;
				Range range10 = \u0019\u0002\u0018.\u000A(true);
				\u000B\u0019\u0018.\u000A(range10, \u0017\u0020\u0018.\u000A());
				\u0004\u0002\u0018.\u000A(range10, 8);
				\u001D\u0002\u0018.\u000A(range10, 2);
				\u0007\u0002\u0018.\u000A(u001F10, range10);
				object u001F11 = list;
				Range range11 = \u0019\u0002\u0018.\u000A(true);
				\u000B\u0019\u0018.\u000A(range11, \u0020\u0020\u0018.\u000A());
				\u0004\u0002\u0018.\u000A(range11, 9);
				\u001D\u0002\u0018.\u000A(range11, 2);
				\u0007\u0002\u0018.\u000A(u001F11, range11);
			}
			else
			{
				object u001F12 = list;
				Range range12 = \u0019\u0002\u0018.\u000A(true);
				\u000B\u0019\u0018.\u000A(range12, \u001E\u0020\u0018.\u000A());
				\u0004\u0002\u0018.\u000A(range12, 8);
				\u001D\u0002\u0018.\u000A(range12, 2);
				\u0007\u0002\u0018.\u000A(u001F12, range12);
			}
			\u001C\u0011\u0018.\u000A(worksheet, list);
			\u000F\u0011\u0018.\u000A(\u0012\u0011\u0018.\u000A(worksheet), \u000B\u0002\u0018.\u000A(8, 8, 2, 16));
			\u000F\u0011\u0018.\u000A(\u0012\u0011\u0018.\u000A(worksheet), \u000B\u0002\u0018.\u000A(9, 9, 2, 16));
			\u000F\u0002\u0018.\u000A(\u001E\u001D\u0018.\u000A(\u001F), worksheet);
		}

		// Token: 0x06001349 RID: 4937 RVA: 0x0007AB00 File Offset: 0x00078D00
		internal static Dictionary<DataTable, List<ParamExportInfo>> \u000B(string \u001F)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityImportExport.cs", "GetDataTablesFromFile");
			Dictionary<DataTable, List<ParamExportInfo>> dictionary = \u0019\u0017\u0018.\u000A();
			try
			{
				ExcelEngine excelEngine = \u0008\u001E\u001D.\u000A();
				try
				{
					IApplication u001F = \u000E\u001E\u001D.\u000A(excelEngine);
					\u0010\u001E\u001D.\u000A(u001F, ExcelVersion.Excel2013);
					IWorkbook workbook = \u0004\u0017\u0018.\u000A(\u000D\u001E\u001D.\u000A(u001F), \u001F, ExcelParseOptions.DoNotParsePivotTable);
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
						if (!true)
						{
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u000B(string)).MethodHandle;
						}
						\u001B\u0012.\u0002(workbook, dictionary, -1);
						\u0019\u001A\u0004.\u000A(workbook);
					}
				}
				finally
				{
					if (excelEngine != null)
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
						\u001F\u0017\u000A.\u000A(excelEngine);
					}
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityImportExport.cs", "GetDataTablesFromFile");
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityImportExport.cs", "GetDataTablesFromFile");
			return dictionary;
		}

		// Token: 0x0600134A RID: 4938 RVA: 0x0007ABD8 File Offset: 0x00078DD8
		internal static void \u0002(IWorkbook \u001F, Dictionary<DataTable, List<ParamExportInfo>> \u000A, int \u0007 = -1)
		{
			try
			{
				\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityImportExport.cs", "GetTables");
				for (int i = 0; i < \u0017\u0011\u001D.\u000A(\u0003\u001E\u001D.\u000A(\u001F)); i++)
				{
					IWorksheet u001F = \u0012\u001E\u001D.\u000A(\u0003\u001E\u001D.\u000A(\u001F), i);
					if (!\u000D\u0008\u000A.\u001F(\u0014\u0011\u001D.\u000A(u001F), "instructions"))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u0002(IWorkbook, Dictionary<DataTable, List<ParamExportInfo>>, int)).MethodHandle;
						}
						if (!\u0008\u0013\u000A.\u000A(\u0014\u0011\u001D.\u000A(u001F), "ParamValues"))
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
							if (!\u0008\u0013\u000A.\u000A(\u0014\u0011\u001D.\u000A(u001F), "Copy$Temp"))
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
								ParamExportInfo paramExportInfo = \u001B\u0012.\u000F(u001F);
								if (paramExportInfo != null)
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
									int num = \u0019\u0019\u0018.\u000A(paramExportInfo);
									\u0016\u0017\u0018.\u000A(u001F, false);
									int num2 = \u000B\u0013\u001D.\u000A(\u0018\u001E\u001D.\u000A(u001F));
									if (\u0007 != -1)
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
										if (\u0007 < num2)
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
											num2 = \u0007;
										}
									}
									num2 -= num;
									List<ParamExportInfo> list;
									if (\u001D\u0012\u0018.\u000A(paramExportInfo) == ExportTypes.ProjectInformation)
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
										list = \u001B\u0012.\u0003(u001F, 1);
									}
									else
									{
										list = \u001B\u0012.\u0012(u001F, num, false);
									}
									if (\u0008\u0004\u0018.\u000A(list) > 0)
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
										DataTable dataTable = \u001B\u0012.\u0006(u001F, paramExportInfo, num, num2);
										if (dataTable != null)
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
											\u0005\u0017\u0018.\u000A(\u000A, dataTable, list);
										}
									}
								}
							}
						}
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
			catch (HiddenCellModifiedException ex)
			{
				\u0018\u0017\u0018.\u000A(\u000A);
				\u0005\u0013\u000A.\u000A(\u0003\u001A\u000A.\u000A(ex), 600.0);
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), ex, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityImportExport.cs", "GetTables");
			}
			catch (Exception ex2)
			{
				\u0018\u0017\u0018.\u000A(\u000A);
				\u0004\u000F.\u0016(ex2);
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), ex2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityImportExport.cs", "GetTables");
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityImportExport.cs", "GetTables");
		}

		// Token: 0x0600134B RID: 4939 RVA: 0x0007AE20 File Offset: 0x00079020
		private static DataTable \u0006(IWorksheet \u001F, ParamExportInfo \u000A, int \u0007, int \u001D)
		{
			if (\u001D\u0012\u0018.\u000A(\u000A) == ExportTypes.ProjectInformation)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u0006(IWorksheet, ParamExportInfo, int, int)).MethodHandle;
				}
				if (\u0013\u0013\u0007.\u000A(\u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A())) != null)
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
					return \u0012\u001C.\u001D(\u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A()), \u001F, \u000A);
				}
			}
			DataTable result;
			if (\u001D > 0)
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
				result = \u0002\u0017\u0018.\u000A(\u001F, \u0007 + 1, 1, \u001D, \u0016\u0013\u001D.\u000A(\u0018\u001E\u001D.\u000A(\u001F)), ExcelExportDataTableOptions.ComputedFormulaValues | ExcelExportDataTableOptions.ExportHiddenColumns | ExcelExportDataTableOptions.ExportHiddenRows);
			}
			else
			{
				result = \u000B\u0017\u0018.\u000A();
			}
			return result;
		}

		// Token: 0x0600134C RID: 4940 RVA: 0x0007AEC0 File Offset: 0x000790C0
		internal static ParamExportInfo \u000F(IWorksheet \u001F)
		{
			ParamExportInfo result = \u0003\u0016\u000E.\u001F;
			for (int i = 1; i < 3; i++)
			{
				string u001F = \u0003\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), i, 1));
				if (!\u001A\u0006\u0007.\u000A(u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u000F(IWorksheet)).MethodHandle;
					}
					if (\u0014\u001E\u001D.\u000A(u001F, "{"))
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
						if (\u0001\u0016\u001D.\u000A(u001F, "}"))
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
							result = ParamExportInfo.\u0004(u001F);
						}
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
			return result;
		}

		// Token: 0x0600134D RID: 4941 RVA: 0x0007AF60 File Offset: 0x00079160
		internal static List<ParamExportInfo> \u0012(IWorksheet \u001F, int \u000A, bool \u0007 = false)
		{
			List<ParamExportInfo> list = \u0012\u000A\u0018.\u000A();
			int num = Enumerable.Count<IRange>(\u001A\u0014\u001D.\u000A(\u0018\u001E\u001D.\u000A(\u001F)));
			for (int i = 1; i <= num; i++)
			{
				string u001F = \u0003\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), \u000A - 1, i));
				ParamExportInfo paramExportInfo = \u0003\u0016\u000E.\u001F;
				if (!\u001A\u0006\u0007.\u000A(u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u0012(IWorksheet, int, bool)).MethodHandle;
					}
					paramExportInfo = ParamExportInfo.\u0004(u001F);
				}
				if (paramExportInfo == null)
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
					paramExportInfo = \u0002\u000A\u0018.\u000A();
				}
				\u000B\u000A\u0018.\u000A(paramExportInfo, \u000A);
				\u0016\u000A\u0018.\u000A(list, paramExportInfo);
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
			return list;
		}

		// Token: 0x0600134E RID: 4942 RVA: 0x0007B014 File Offset: 0x00079214
		internal static List<ParamExportInfo> \u0003(IWorksheet \u001F, int \u000A)
		{
			List<ParamExportInfo> list = \u0012\u000A\u0018.\u000A();
			ParamExportInfo paramExportInfo = \u0002\u000A\u0018.\u000A();
			\u0006\u0017\u0018.\u000A(paramExportInfo, "UniqueId");
			\u0009\u0004\u0018.\u000A(paramExportInfo, "UniqueId");
			\u0016\u000A\u0018.\u000A(list, paramExportInfo);
			paramExportInfo = \u0002\u000A\u0018.\u000A();
			\u0006\u0017\u0018.\u000A(paramExportInfo, "ElementId");
			\u0009\u0004\u0018.\u000A(paramExportInfo, "ElementId");
			\u0016\u000A\u0018.\u000A(list, paramExportInfo);
			int num = \u000B\u0013\u001D.\u000A(\u0018\u001E\u001D.\u000A(\u001F));
			for (int i = \u000A; i <= num; i++)
			{
				string u001F = \u0003\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), i, 1));
				if (!\u001A\u0006\u0007.\u000A(u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u0003(IWorksheet, int)).MethodHandle;
					}
					ParamExportInfo paramExportInfo2 = ParamExportInfo.\u0004(u001F);
					if (paramExportInfo2 != null)
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
						\u0016\u000A\u0018.\u000A(list, paramExportInfo2);
						\u000B\u000A\u0018.\u000A(paramExportInfo2, \u000A);
					}
				}
				else if (i != num)
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
					ParamExportInfo paramExportInfo3 = \u0002\u000A\u0018.\u000A();
					\u0016\u000A\u0018.\u000A(list, paramExportInfo3);
					\u000B\u000A\u0018.\u000A(paramExportInfo3, \u000A);
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
			return list;
		}

		// Token: 0x0600134F RID: 4943 RVA: 0x0007B12C File Offset: 0x0007932C
		internal unsafe static DiRoots.One.SheetLink.Enums.UpdateStatus \u001C(Dictionary<DataTable, List<ParamExportInfo>> \u001F, Document \u000A, ProgressModel \u0007, Window \u001D, out List<ReportInfo> \u0004)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityImportExport.cs", "ImportExcelFile");
			DiRoots.One.SheetLink.Enums.UpdateStatus updateStatus = DiRoots.One.SheetLink.Enums.UpdateStatus.InvalidModel;
			\u0004 = \u0012\u000F\u0018.\u000A();
			try
			{
				GroupHandler groupHandler = \u000E\u0017\u0018.\u000A(\u001D);
				int num = 1;
				int num2 = \u0010\u0017\u0018.\u000A(\u001F);
				Dictionary<DataTable, List<ParamExportInfo>>.Enumerator enumerator = \u000D\u0017\u0018.\u000A(\u001F);
				try
				{
					while (\u0012\u0017\u0018.\u000A(ref enumerator))
					{
						KeyValuePair<DataTable, List<ParamExportInfo>> u001F = \u001C\u0017\u0018.\u000A(ref enumerator);
						List<ReportInfo> list = \u0012\u000F\u0018.\u000A();
						\u000E\u000A\u001D.\u000A(\u001E\u000F\u0018.\u000A(groupHandler));
						DiRoots.One.SheetLink.Enums.UpdateStatus updateStatus2 = DiRoots.One.SheetLink.Enums.UpdateStatus.None;
						if (\u001D\u0012\u0018.\u000A(\u001E\u0004\u0018.\u000A(\u0004\u0012\u0018.\u000A(ref u001F), 0)) == ExportTypes.Normal)
						{
							goto IL_10A;
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
						if (!true)
						{
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u001C(Dictionary<DataTable, List<ParamExportInfo>>, Document, ProgressModel, Window, List<ReportInfo>*)).MethodHandle;
						}
						if (\u001D\u0012\u0018.\u000A(\u001E\u0004\u0018.\u000A(\u0004\u0012\u0018.\u000A(ref u001F), 0)) == ExportTypes.ProjectInformation)
						{
							goto IL_10A;
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
						if (\u001D\u0012\u0018.\u000A(\u001E\u0004\u0018.\u000A(\u0004\u0012\u0018.\u000A(ref u001F), 0)) == ExportTypes.Rooms)
						{
							goto IL_10A;
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
						if (\u001D\u0012\u0018.\u000A(\u001E\u0004\u0018.\u000A(\u0004\u0012\u0018.\u000A(ref u001F), 0)) == ExportTypes.Spaces)
						{
							for (;;)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								goto IL_10A;
							}
						}
						else
						{
							if (\u001D\u0012\u0018.\u000A(\u001E\u0004\u0018.\u000A(\u0004\u0012\u0018.\u000A(ref u001F), 0)) != ExportTypes.AnnotationObjects)
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
								if (\u001D\u0012\u0018.\u000A(\u001E\u0004\u0018.\u000A(\u0004\u0012\u0018.\u000A(ref u001F), 0)) != ExportTypes.ModelObjects)
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
									if (\u001D\u0012\u0018.\u000A(\u001E\u0004\u0018.\u000A(\u0004\u0012\u0018.\u000A(ref u001F), 0)) != ExportTypes.AnalyticalModelObjects)
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
										if (\u001D\u0012\u0018.\u000A(\u001E\u0004\u0018.\u000A(\u0004\u0012\u0018.\u000A(ref u001F), 0)) != ExportTypes.LineStyles)
										{
											goto IL_1DE;
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
								}
							}
							updateStatus2 = \u0002\u001C.\u0002(u001F, \u000A, out list);
						}
						IL_1DE:
						if (updateStatus2 == DiRoots.One.SheetLink.Enums.UpdateStatus.Cancel)
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
							updateStatus = updateStatus2;
							goto IL_24E;
						}
						if (updateStatus != DiRoots.One.SheetLink.Enums.UpdateStatus.Updated)
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
							updateStatus = updateStatus2;
						}
						if (Enumerable.Any<ReportInfo>(list))
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
							\u0006\u0012\u0018.\u000A(\u0004, list);
						}
						num++;
						continue;
						IL_10A:
						updateStatus2 = \u0003\u000F.\u001F(u001F, \u000A, groupHandler, \u0018\u000E\u0007.\u000A(\u0003\u0017\u0018.\u000A(), num, num2), \u0007, out list);
						goto IL_1DE;
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
				IL_24E:;
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityImportExport.cs", "ImportExcelFile");
			}
			\u000F\u0017\u0018.\u000A(\u0011\u0008\u0018.\u000A());
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityImportExport.cs", "ImportExcelFile");
			return updateStatus;
		}

		// Token: 0x040007A4 RID: 1956
		private static int \u001F = 1;

		// Token: 0x020008B0 RID: 2224
		[CompilerGenerated]
		private sealed class \u0002\u0012
		{
			// Token: 0x06004FF9 RID: 20473 RVA: 0x001E6170 File Offset: 0x001E4370
			internal bool \u000A(CategoryCollection \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0001\u0016\u0018.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x06004FFA RID: 20474 RVA: 0x001E6194 File Offset: 0x001E4394
			internal bool \u0007(CategoryCollection \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0001\u0016\u0018.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x06004FFB RID: 20475 RVA: 0x001E61B8 File Offset: 0x001E43B8
			internal bool \u001D(CategoryCollection \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0001\u0016\u0018.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x040022A2 RID: 8866
			public string \u001F;
		}

		// Token: 0x020008B1 RID: 2225
		[CompilerGenerated]
		private sealed class \u0006\u0012
		{
			// Token: 0x040022A3 RID: 8867
			public int \u001F;
		}

		// Token: 0x020008B2 RID: 2226
		[CompilerGenerated]
		private sealed class \u000F\u0012
		{
			// Token: 0x06004FFE RID: 20478 RVA: 0x001E6204 File Offset: 0x001E4404
			internal bool \u0007(ScheduleData \u001F)
			{
				if (\u0001\u0017\u0005.\u000A(\u001F) == this.\u001F)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0012.\u000F\u0012.\u0007(ScheduleData)).MethodHandle;
					}
					return \u000F\u0016\u0010.\u000A(\u001F) == this.\u000A.\u001F;
				}
				return false;
			}

			// Token: 0x040022A4 RID: 8868
			public long \u001F;

			// Token: 0x040022A5 RID: 8869
			public \u001B\u0012.\u0006\u0012 \u000A;
		}

		// Token: 0x020008B3 RID: 2227
		[CompilerGenerated]
		private sealed class \u0012\u0012
		{
			// Token: 0x06005000 RID: 20480 RVA: 0x001E6260 File Offset: 0x001E4460
			internal bool \u000A(IWorksheet \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0014\u0011\u001D.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x06005001 RID: 20481 RVA: 0x001E6284 File Offset: 0x001E4484
			internal bool \u0007(CategoryCollection \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0001\u0016\u0018.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x06005002 RID: 20482 RVA: 0x001E62A8 File Offset: 0x001E44A8
			internal bool \u001D(CategoryCollection \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0001\u0016\u0018.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x06005003 RID: 20483 RVA: 0x001E62CC File Offset: 0x001E44CC
			internal bool \u0004(CategoryCollection \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0001\u0016\u0018.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x06005004 RID: 20484 RVA: 0x001E62F0 File Offset: 0x001E44F0
			internal bool \u0019(CategoryCollection \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0001\u0016\u0018.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x040022A6 RID: 8870
			public string \u001F;
		}

		// Token: 0x020008B4 RID: 2228
		[CompilerGenerated]
		private sealed class \u0003\u0012
		{
			// Token: 0x06005006 RID: 20486 RVA: 0x001E6328 File Offset: 0x001E4528
			internal bool \u000A(CategoryCollection \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0001\u0016\u0018.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x06005007 RID: 20487 RVA: 0x001E634C File Offset: 0x001E454C
			internal bool \u0007(CategoryCollection \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0001\u0016\u0018.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x06005008 RID: 20488 RVA: 0x001E6370 File Offset: 0x001E4570
			internal bool \u001D(CategoryCollection \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0001\u0016\u0018.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x06005009 RID: 20489 RVA: 0x001E6394 File Offset: 0x001E4594
			internal bool \u0004(CategoryCollection \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0001\u0016\u0018.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x040022A7 RID: 8871
			public string \u001F;
		}

		// Token: 0x020008B5 RID: 2229
		[CompilerGenerated]
		private sealed class \u001C\u0012
		{
			// Token: 0x0600500B RID: 20491 RVA: 0x001E63CC File Offset: 0x001E45CC
			internal bool \u000A(IWorksheet \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0014\u0011\u001D.\u000A(\u001F), \u0001\u0016\u0018.\u000A(this.\u001F));
			}

			// Token: 0x040022A8 RID: 8872
			public CategoryCollection \u001F;
		}

		// Token: 0x020008B6 RID: 2230
		[CompilerGenerated]
		private sealed class \u000D\u0012
		{
			// Token: 0x0600500D RID: 20493 RVA: 0x001E640C File Offset: 0x001E460C
			internal bool \u000A(IWorksheet \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0014\u0011\u001D.\u000A(\u001F), \u0001\u0016\u0018.\u000A(this.\u001F));
			}

			// Token: 0x040022A9 RID: 8873
			public CategoryCollection \u001F;
		}

		// Token: 0x020008B7 RID: 2231
		[CompilerGenerated]
		private sealed class \u0010\u0012
		{
			// Token: 0x0600500F RID: 20495 RVA: 0x001E644C File Offset: 0x001E464C
			internal bool \u0019(RevitParameter \u001F)
			{
				\u001B\u0012.\u000E\u0012 u000E_u = new \u001B\u0012.\u000E\u0012();
				u000E_u.\u001F = \u001F;
				return Enumerable.Any<RevitParameter>(this.\u001F, new Func<RevitParameter, bool>(u000E_u.\u000A));
			}

			// Token: 0x06005010 RID: 20496 RVA: 0x001E6480 File Offset: 0x001E4680
			internal bool \u0018(RevitParameter \u001F)
			{
				\u001B\u0012.\u0008\u0012 u0008_u = new \u001B\u0012.\u0008\u0012();
				u0008_u.\u001F = \u001F;
				return Enumerable.Any<RevitParameter>(this.\u000A, new Func<RevitParameter, bool>(u0008_u.\u000A));
			}

			// Token: 0x06005011 RID: 20497 RVA: 0x001E64B4 File Offset: 0x001E46B4
			internal void \u0005(RevitParameter \u001F)
			{
				\u0012\u0016\u0010.\u000A(\u001F, \u0007\u0020\u0005.\u000A(this.\u0007));
			}

			// Token: 0x06005012 RID: 20498 RVA: 0x001E64D4 File Offset: 0x001E46D4
			internal bool \u0016(KeyValuePair<long, List<long>> \u001F)
			{
				return \u001A\u0008\u0019.\u000A(this.\u001D, \u0003\u0016\u0010.\u000A(ref \u001F));
			}

			// Token: 0x040022AA RID: 8874
			public List<RevitParameter> \u001F;

			// Token: 0x040022AB RID: 8875
			public List<RevitParameter> \u000A;

			// Token: 0x040022AC RID: 8876
			public \u0015\u001C \u0007;

			// Token: 0x040022AD RID: 8877
			public List<long> \u001D;

			// Token: 0x040022AE RID: 8878
			public Func<KeyValuePair<long, List<long>>, bool> \u0004;
		}

		// Token: 0x020008B8 RID: 2232
		[CompilerGenerated]
		private sealed class \u000E\u0012
		{
			// Token: 0x06005014 RID: 20500 RVA: 0x001E650C File Offset: 0x001E470C
			internal bool \u000A(RevitParameter \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u000F\u0020\u0018.\u0007(\u001F), \u000F\u0020\u0018.\u0007(this.\u001F));
			}

			// Token: 0x040022AF RID: 8879
			public RevitParameter \u001F;
		}

		// Token: 0x020008B9 RID: 2233
		[CompilerGenerated]
		private sealed class \u0008\u0012
		{
			// Token: 0x06005016 RID: 20502 RVA: 0x001E654C File Offset: 0x001E474C
			internal bool \u000A(RevitParameter \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u000F\u0020\u0018.\u0007(\u001F), \u000F\u0020\u0018.\u0007(this.\u001F));
			}

			// Token: 0x040022B0 RID: 8880
			public RevitParameter \u001F;
		}
	}
}

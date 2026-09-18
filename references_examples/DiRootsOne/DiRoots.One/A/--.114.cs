using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using DiRoots.One.Commons;
using DiRoots.One.Revit.GroupHelper;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x020001FA RID: 506
	internal static class \u0003\u000F
	{
		// Token: 0x060012E4 RID: 4836 RVA: 0x0006D4A8 File Offset: 0x0006B6A8
		internal unsafe static DiRoots.One.SheetLink.Enums.UpdateStatus \u001F(KeyValuePair<DataTable, List<ParamExportInfo>> \u001F, Document \u000A, GroupHandler \u0007, string \u001D, ProgressModel \u0004, out List<ReportInfo> \u0019)
		{
			\u0003\u000F.\u000B\u000F u000B_u000F = new \u0003\u000F.\u000B\u000F();
			u000B_u000F.\u001F = \u0007;
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Helpers\\Import\\DataUpdateHandler.cs", "UpdateModel");
			\u0019 = \u0012\u000F\u0018.\u000A();
			DiRoots.One.SheetLink.Enums.UpdateStatus updateStatus = DiRoots.One.SheetLink.Enums.UpdateStatus.InvalidModel;
			TransactionGroup transactionGroup = \u001D\u000B\u000E.\u001F;
			try
			{
				ExportTypes exportTypes = \u001D\u0012\u0018.\u000A(\u001E\u0004\u0018.\u000A(\u0004\u0012\u0018.\u000A(ref \u001F), 0));
				if (\u000A\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F))) > 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u000F.\u001F(KeyValuePair<DataTable, List<ParamExportInfo>>, Document, GroupHandler, string, ProgressModel, List<ReportInfo>*)).MethodHandle;
					}
					if (\u000A\u0012\u0018.\u000A(\u0007\u0012\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F))) > 1)
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
						Dictionary<int, Element> dictionary = \u0003\u000F.\u0004(\u001F, \u000A, \u0019, exportTypes);
						IEnumerable<Element> enumerable = \u001F\u0012\u0018.\u000A(dictionary);
						Func<Element, bool> func;
						if ((func = \u0003\u000F.<>c.\u000A) == null)
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
							func = (\u0003\u000F.<>c.\u000A = new Func<Element, bool>(\u0003\u000F.<>c.\u001F.\u0011));
						}
						IEnumerable<Element> enumerable2 = Enumerable.Where<Element>(enumerable, func);
						Func<Element, string> func2;
						if ((func2 = \u0003\u000F.<>c.\u0007) == null)
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
							func2 = (\u0003\u000F.<>c.\u0007 = new Func<Element, string>(\u0003\u000F.<>c.\u001F.\u001E));
						}
						IEnumerable<IGrouping<string, Element>> enumerable3 = Enumerable.GroupBy<Element, string>(enumerable2, func2);
						Func<IGrouping<string, Element>, string> func3;
						if ((func3 = \u0003\u000F.<>c.\u001D) == null)
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
							func3 = (\u0003\u000F.<>c.\u001D = new Func<IGrouping<string, Element>, string>(\u0003\u000F.<>c.\u001F.\u0020));
						}
						Func<IGrouping<string, Element>, Element> func4;
						if ((func4 = \u0003\u000F.<>c.\u0004) == null)
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
							func4 = (\u0003\u000F.<>c.\u0004 = new Func<IGrouping<string, Element>, Element>(\u0003\u000F.<>c.\u001F.\u0017));
						}
						Dictionary<string, Element> dictionary2 = Enumerable.ToDictionary<IGrouping<string, Element>, string, Element>(enumerable3, func3, func4);
						\u0009\u0014\u0019.\u000A(\u0004, \u0009\u000F\u0018.\u000A(dictionary), \u0017\u0006\u0007.\u000A(\u0001\u000F\u0018.\u000A(), \u001D));
						Dictionary<string, List<ChangedColumns>> dictionary3 = \u0003\u000F.\u0005(dictionary, \u001F, \u000A, \u0004);
						if (\u0015\u000F\u0018.\u000A(dictionary3) > 0)
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
							if (exportTypes != ExportTypes.ProjectInformation)
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
								IEnumerable<KeyValuePair<string, List<ChangedColumns>>> enumerable4 = dictionary3;
								Func<KeyValuePair<string, List<ChangedColumns>>, IEnumerable<ChangedColumns>> func5;
								if ((func5 = \u0003\u000F.<>c.\u0019) == null)
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
									func5 = (\u0003\u000F.<>c.\u0019 = new Func<KeyValuePair<string, List<ChangedColumns>>, IEnumerable<ChangedColumns>>(\u0003\u000F.<>c.\u001F.\u0014));
								}
								IEnumerable<ChangedColumns> enumerable5 = Enumerable.ToList<ChangedColumns>(Enumerable.Where<ChangedColumns>(Enumerable.ToList<ChangedColumns>(Enumerable.SelectMany<KeyValuePair<string, List<ChangedColumns>>, ChangedColumns>(enumerable4, func5)), new Func<ChangedColumns, bool>(u000B_u000F.\u000A)));
								Dictionary<long, List<long>> dictionary4 = \u000C\u000F\u0018.\u000A(\u000A);
								List<long> list = \u001F\u001B\u0019.\u000A();
								Func<ChangedColumns, long> func6;
								if ((func6 = \u0003\u000F.<>c.\u0018) == null)
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
									func6 = (\u0003\u000F.<>c.\u0018 = new Func<ChangedColumns, long>(\u0003\u000F.<>c.\u001F.\u0013));
								}
								List<long> u001F = Enumerable.ToList<long>(Enumerable.Select<ChangedColumns, long>(enumerable5, func6));
								Dictionary<string, List<ChangedColumns>>.KeyCollection.Enumerator enumerator = \u0013\u000F\u0018.\u000A(\u001A\u000F\u0018.\u000A(dictionary3));
								try
								{
									while (\u0017\u000F\u0018.\u000A(ref enumerator))
									{
										\u0003\u000F.\u0002\u000F u0002_u000F = new \u0003\u000F.\u0002\u000F();
										u0002_u000F.\u001F = \u0014\u000F\u0018.\u000A(ref enumerator);
										KeyValuePair<string, Element> keyValuePair = Enumerable.FirstOrDefault<KeyValuePair<string, Element>>(dictionary2, new Func<KeyValuePair<string, Element>, bool>(u0002_u000F.\u000A));
										Element element = \u000A\u000F\u0018.\u000A(ref keyValuePair);
										if (element != null)
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
											if (\u001A\u0008\u0019.\u000A(u001F, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(element))))
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
												\u0001\u000E\u0019.\u000A(list, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(element)));
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
								finally
								{
									((IDisposable)enumerator).Dispose();
								}
								\u0020\u000F\u0018.\u000A(u000B_u000F.\u001F, dictionary4, list);
								if (\u001B\u000A\u001D.\u000A(\u001E\u000F\u0018.\u000A(u000B_u000F.\u001F)) > 0)
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
									if (!\u0011\u000F\u0018.\u000A(u000B_u000F.\u001F))
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
										updateStatus = DiRoots.One.SheetLink.Enums.UpdateStatus.Cancel;
										return updateStatus;
									}
									if (\u0001\u0006\u0018.\u000A(u000B_u000F.\u001F))
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
										object u001F2 = u000B_u000F.\u001F;
										IEnumerable<KeyValuePair<long, List<long>>> enumerable6 = dictionary4;
										Func<KeyValuePair<long, List<long>>, IEnumerable<long>> func7;
										if ((func7 = \u0003\u000F.<>c.\u0005) == null)
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
											func7 = (\u0003\u000F.<>c.\u0005 = new Func<KeyValuePair<long, List<long>>, IEnumerable<long>>(\u0003\u000F.<>c.\u001F.\u001A));
										}
										\u001B\u000F\u0018.\u000A(u001F2, Enumerable.ToList<long>(Enumerable.SelectMany<KeyValuePair<long, List<long>>, long>(enumerable6, func7)));
									}
								}
							}
						}
						List<DropDownparamInfo> u001D = \u0004\u000B\u000E.\u001F;
						IEnumerable<List<ChangedColumns>> enumerable7 = \u000E\u000F\u0018.\u000A(dictionary3);
						Func<List<ChangedColumns>, bool> func8;
						if ((func8 = \u0003\u000F.<>c.\u0016) == null)
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
							func8 = (\u0003\u000F.<>c.\u0016 = new Func<List<ChangedColumns>, bool>(\u0003\u000F.<>c.\u001F.\u000C));
						}
						if (Enumerable.Any<List<ChangedColumns>>(enumerable7, func8))
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
							u001D = DropDownparamInfo.\u0005(false);
						}
						List<ChangedColumns> list2 = \u0008\u000F\u0018.\u000A();
						object u001F3 = list2;
						IEnumerable<List<ChangedColumns>> enumerable8 = \u000E\u000F\u0018.\u000A(dictionary3);
						Func<List<ChangedColumns>, IEnumerable<ChangedColumns>> func9;
						if ((func9 = \u0003\u000F.<>c.\u000B) == null)
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
							func9 = (\u0003\u000F.<>c.\u000B = new Func<List<ChangedColumns>, IEnumerable<ChangedColumns>>(\u0003\u000F.<>c.\u001F.\u0015));
						}
						\u0010\u000F\u0018.\u000A(u001F3, Enumerable.SelectMany<List<ChangedColumns>, ChangedColumns>(enumerable8, func9));
						IEnumerable<ChangedColumns> enumerable9 = list2;
						Func<ChangedColumns, bool> func10;
						if ((func10 = \u0003\u000F.<>c.\u0002) == null)
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
							func10 = (\u0003\u000F.<>c.\u0002 = new Func<ChangedColumns, bool>(\u0003\u000F.<>c.\u001F.\u0001));
						}
						list2 = Enumerable.ToList<ChangedColumns>(Enumerable.Where<ChangedColumns>(enumerable9, func10));
						IEnumerable<ChangedColumns> enumerable10 = list2;
						Func<ChangedColumns, long> func11;
						if ((func11 = \u0003\u000F.<>c.\u0006) == null)
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
							func11 = (\u0003\u000F.<>c.\u0006 = new Func<ChangedColumns, long>(\u0003\u000F.<>c.\u001F.\u0009));
						}
						IEnumerable<IGrouping<long, ChangedColumns>> enumerable11 = Enumerable.GroupBy<ChangedColumns, long>(enumerable10, func11);
						Func<IGrouping<long, ChangedColumns>, ChangedColumns> func12;
						if ((func12 = \u0003\u000F.<>c.\u000F) == null)
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
							func12 = (\u0003\u000F.<>c.\u000F = new Func<IGrouping<long, ChangedColumns>, ChangedColumns>(\u0003\u000F.<>c.\u001F.\u001F\u000A));
						}
						list2 = Enumerable.ToList<ChangedColumns>(Enumerable.Select<IGrouping<long, ChangedColumns>, ChangedColumns>(enumerable11, func12));
						if (\u0003\u000F\u0018.\u000A(list2) == 0)
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
							updateStatus = DiRoots.One.SheetLink.Enums.UpdateStatus.NoChangesFound;
						}
						else
						{
							\u0009\u0014\u0019.\u000A(\u0004, \u0003\u000F\u0018.\u000A(list2), \u0017\u0006\u0007.\u000A(\u000D\u000F\u0018.\u000A(), \u001D));
						}
						bool u000A = \u001C\u000F\u0018.\u000A(\u000A);
						TransactionGroup transactionGroup2;
						transactionGroup = (transactionGroup2 = \u0009\u0017\u0007.\u000A(\u000A, "SheetLink_UpdateModel"));
						try
						{
							\u0001\u0017\u0007.\u000A(transactionGroup);
							\u0003\u000F.\u001D(\u000A, u000B_u000F.\u001F);
							int num = \u0003\u000F\u0018.\u000A(list2);
							int num2 = ProgressModel.EAD(num);
							List<ReportInfo> list3 = \u0012\u000F\u0018.\u000A();
							int i = 0;
							while (i < num)
							{
								\u0003\u000F.\u0006\u000F u0006_u000F = new \u0003\u000F.\u0006\u000F();
								\u0003\u000F.\u0002();
								u0006_u000F.\u001F = \u000F\u000F\u0018.\u000A(list2, i);
								int num3 = i + 1;
								if (num3 % num2 == 0)
								{
									goto IL_5FE;
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
								if (num3 == num)
								{
									for (;;)
									{
										switch (3)
										{
										case 0:
											continue;
										}
										goto IL_5FE;
									}
								}
								IL_631:
								List<DataRow> u001F4 = Enumerable.ToList<DataRow>(Enumerable.Cast<DataRow>(\u0002\u000F\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F))));
								List<List<DataRow>> u001F5 = \u0003\u000F.\u0019(u001F4, 4000);
								int num4 = \u0005\u000F\u0018.\u000A(u001F4);
								int num5 = ProgressModel.EAD(num4);
								int num6 = 1;
								int num7 = 0;
								List<List<DataRow>>.Enumerator enumerator2 = \u000B\u000F\u0018.\u000A(u001F5);
								try
								{
									while (\u0002\u0006\u0018.\u000A(ref enumerator2))
									{
										List<DataRow> list4 = \u0016\u000F\u0018.\u000A(ref enumerator2);
										num7 += \u0005\u000F\u0018.\u000A(list4);
										Transaction transaction = \u001D\u0014\u0007.\u000A(\u000A, "SetParameter");
										try
										{
											\u001E\u001C u001E_u001C = new \u001E\u001C(\u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u0014\u0006\u0018.\u000A(u0006_u000F.\u001F))));
											FailureHandlingOptions failureHandlingOptions = \u0006\u0014\u0007.\u000A(transaction);
											\u0018\u000F\u0018.\u000A(failureHandlingOptions, false);
											\u0002\u0014\u0007.\u000A(failureHandlingOptions, u001E_u001C);
											\u000B\u0014\u0007.\u000A(transaction, failureHandlingOptions);
											\u0007\u0014\u0007.\u000A(transaction);
											\u001C\u000F.\u001F(\u000A, list4, dictionary3, u000B_u000F.\u001F);
											List<DataRow>.Enumerator enumerator3 = \u0019\u000F\u0018.\u000A(list4);
											try
											{
												while (\u001B\u0006\u0018.\u000A(ref enumerator3))
												{
													DataRow u001F6 = \u0004\u000F\u0018.\u000A(ref enumerator3);
													\u0003\u000F.\u000F\u000F u000F_u000F = new \u0003\u000F.\u000F\u000F();
													\u0003\u000F.\u0002();
													if (num6 % num5 == 0)
													{
														goto IL_760;
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
													if (num6 == num7)
													{
														for (;;)
														{
															switch (3)
															{
															case 0:
																continue;
															}
															goto IL_760;
														}
													}
													IL_784:
													num6++;
													long num8 = 0L;
													u000F_u000F.\u001F = \u001A\u000C\u000A.\u000A(\u001F\u000F\u0018.\u000A(u001F6, 0));
													if (\u001A\u0006\u0007.\u000A(u000F_u000F.\u001F))
													{
														continue;
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
													KeyValuePair<string, Element> keyValuePair = Enumerable.FirstOrDefault<KeyValuePair<string, Element>>(dictionary2, new Func<KeyValuePair<string, Element>, bool>(u000F_u000F.\u000A));
													Element element2 = \u000A\u000F\u0018.\u000A(ref keyValuePair);
													if (element2 != null)
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
														num8 = \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(element2));
													}
													else
													{
														\u0009\u0006\u0018.\u000A(\u001A\u000C\u000A.\u000A(\u001F\u000F\u0018.\u000A(u001F6, 1)), ref num8);
													}
													if (updateStatus != DiRoots.One.SheetLink.Enums.UpdateStatus.Updated)
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
														updateStatus = DiRoots.One.SheetLink.Enums.UpdateStatus.NoChangesFound;
													}
													if (\u0001\u0006\u0018.\u000A(u000B_u000F.\u001F))
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
														if (!\u0015\u0006\u0018.\u000A(u0006_u000F.\u001F))
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
															if (\u001A\u0008\u0019.\u000A(\u000C\u0006\u0018.\u000A(u000B_u000F.\u001F), num8))
															{
																continue;
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
													if (element2 == null)
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
													if (!\u001A\u0006\u0018.\u000A(dictionary3, u000F_u000F.\u001F))
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
													List<ChangedColumns> list5 = \u0013\u0006\u0018.\u000A(dictionary3, u000F_u000F.\u001F);
													IEnumerable<ChangedColumns> enumerable12 = list5;
													Func<ChangedColumns, bool> func13;
													if ((func13 = u0006_u000F.\u000A) == null)
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
														func13 = (u0006_u000F.\u000A = new Func<ChangedColumns, bool>(u0006_u000F.\u0007));
													}
													ChangedColumns changedColumns = Enumerable.FirstOrDefault<ChangedColumns>(enumerable12, func13);
													if (changedColumns == null)
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
													if (!\u0003\u000F.\u000A(\u000A, u000A, num8))
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
														ReportInfo reportInfo = \u0003\u000F.\u0007(\u000A, num8, \u0016\u0006\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F)), changedColumns);
														\u001E\u0006\u0018.\u000A(reportInfo, num6 - 1);
														\u000F\u0006\u0018.\u000A(\u0019, reportInfo);
														continue;
													}
													if (updateStatus != DiRoots.One.SheetLink.Enums.UpdateStatus.Updated)
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
														updateStatus = DiRoots.One.SheetLink.Enums.UpdateStatus.ChangesFound;
													}
													if (\u0014\u0006\u0018.\u000A(changedColumns) != null)
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
														if (!\u0010\u0014\u0007.\u000A(\u0014\u0006\u0018.\u000A(changedColumns)))
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
															ReportInfo reportInfo2 = \u0020\u0006\u0018.\u000A(\u0016\u0006\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F)), \u0011\u0013\u000A.\u000A(ref num8), changedColumns);
															\u001E\u0006\u0018.\u000A(reportInfo2, num6 - 1);
															try
															{
																if (!\u0010\u000F.\u001D(\u0019, reportInfo2, changedColumns, u001D))
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
																	continue;
																}
																try
																{
																	\u0016\u0012.\u001F(\u0014\u0006\u0018.\u000A(changedColumns), \u0017\u0006\u0018.\u000A(changedColumns), \u000A);
																}
																catch (Exception u001F7)
																{
																	\u0012\u0006\u0018.\u0007(reportInfo2, \u0003\u001A\u000A.\u000A(u001F7));
																}
																\u000F\u0006\u0018.\u000A(list3, reportInfo2);
															}
															catch (Exception u001F8)
															{
																\u0012\u0006\u0018.\u0007(reportInfo2, \u0003\u001A\u000A.\u000A(u001F8));
															}
															if (!\u001A\u0006\u0007.\u000A(\u0003\u0006\u0018.\u000A(reportInfo2)))
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
																\u000F\u0006\u0018.\u000A(\u0019, reportInfo2);
															}
															updateStatus = DiRoots.One.SheetLink.Enums.UpdateStatus.Updated;
															continue;
														}
														continue;
													}
													else
													{
														if (\u0014\u0006\u0018.\u000A(changedColumns) != null)
														{
															continue;
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
														if (!\u001A\u0006\u0007.\u000A(\u0017\u0006\u0018.\u000A(changedColumns)))
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
															ReportInfo reportInfo3 = \u0020\u0006\u0018.\u000A(\u0016\u0006\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F)), \u0011\u0013\u000A.\u000A(ref num8), changedColumns);
															\u001E\u0006\u0018.\u000A(reportInfo3, num6 - 1);
															\u0012\u0006\u0018.\u0007(reportInfo3, \u0011\u0006\u0018.\u000A());
															\u000F\u0006\u0018.\u000A(\u0019, reportInfo3);
															continue;
														}
														continue;
													}
													IL_760:
													\u0007\u000F\u0018.\u0007(\u0004, \u001E\u0007\u0007.\u000A(\u001D\u000F\u0018.\u000A(), \u001D, num6, num4));
													goto IL_784;
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
											\u0007\u0016\u0004.\u000A(transaction, failureHandlingOptions);
											if (u001E_u001C != null)
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
												if (\u0008\u0006\u0018.\u000A(\u000E\u0006\u0018.\u0007(u001E_u001C)) > 0)
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
													List<ReportInfo>.Enumerator enumerator4 = \u000D\u0006\u0018.\u000A(\u000E\u0006\u0018.\u0007(u001E_u001C));
													try
													{
														while (\u0006\u0006\u0018.\u000A(ref enumerator4))
														{
															\u0003\u000F.\u0012\u000F u0012_u000F = new \u0003\u000F.\u0012\u000F();
															u0012_u000F.\u001F = \u001C\u0006\u0018.\u000A(ref enumerator4);
															if (\u0008\u0013\u000A.\u000A(\u0010\u0006\u0018.\u000A(u0012_u000F.\u001F), "-1"))
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
																\u000F\u0006\u0018.\u000A(\u0019, u0012_u000F.\u001F);
															}
															else
															{
																List<ReportInfo>.Enumerator enumerator5 = \u000D\u0006\u0018.\u000A(Enumerable.ToList<ReportInfo>(Enumerable.Where<ReportInfo>(Enumerable.ToList<ReportInfo>(Enumerable.Where<ReportInfo>(list3, new Func<ReportInfo, bool>(u0012_u000F.\u000A))), new Func<ReportInfo, bool>(u0012_u000F.\u0007))));
																try
																{
																	while (\u0006\u0006\u0018.\u000A(ref enumerator5))
																	{
																		ReportInfo reportInfo4 = \u001C\u0006\u0018.\u000A(ref enumerator5);
																		\u0012\u0006\u0018.\u0007(reportInfo4, \u0003\u0006\u0018.\u000A(u0012_u000F.\u001F));
																		\u000F\u0006\u0018.\u000A(\u0019, reportInfo4);
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
																	((IDisposable)enumerator5).Dispose();
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
														((IDisposable)enumerator4).Dispose();
													}
												}
											}
										}
										finally
										{
											if (transaction != null)
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
												\u001F\u0017\u000A.\u000A(transaction);
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
								finally
								{
									((IDisposable)enumerator2).Dispose();
								}
								i++;
								continue;
								IL_5FE:
								Delegate @delegate = \u0006\u000F\u0018.\u0007(\u0004);
								if (@delegate == null)
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
									goto IL_631;
								}
								object[] array = \u0004\u0015\u0010.\u001F(1);
								array[0] = num3;
								\u0010\u001F\u0018.\u000A(@delegate, array);
								goto IL_631;
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
							\u000C\u0017\u0007.\u000A(transactionGroup);
						}
						catch (TaskCanceledException)
						{
							\u001A\u0017\u0007.\u000A(transactionGroup);
							throw;
						}
						finally
						{
							if (transactionGroup2 != null)
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
								\u001F\u0017\u000A.\u000A(transactionGroup2);
							}
						}
						IEnumerable<ReportInfo> enumerable13 = \u0019;
						Func<ReportInfo, int> func14;
						if ((func14 = \u0003\u000F.<>c.\u0012) == null)
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
							func14 = (\u0003\u000F.<>c.\u0012 = new Func<ReportInfo, int>(\u0003\u000F.<>c.\u001F.\u000A\u000A));
						}
						\u0019 = Enumerable.ToList<ReportInfo>(Enumerable.OrderBy<ReportInfo, int>(enumerable13, func14));
						\u0003\u000F.\u0018(\u000A, \u0016\u0006\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F)), \u001F, dictionary, \u0019);
						return updateStatus;
					}
				}
				updateStatus = DiRoots.One.SheetLink.Enums.UpdateStatus.NoChangesFound;
			}
			catch (TaskCanceledException)
			{
				updateStatus = DiRoots.One.SheetLink.Enums.UpdateStatus.Cancel;
			}
			catch (Exception u001F9)
			{
				if (\u0005\u0006\u0018.\u000A())
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
					if (transactionGroup != null)
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
						if (\u0018\u0006\u0018.\u000A(transactionGroup))
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
							\u001A\u0017\u0007.\u000A(transactionGroup);
						}
					}
					updateStatus = DiRoots.One.SheetLink.Enums.UpdateStatus.Cancel;
				}
				else
				{
					\u0004\u000F.\u0016(u001F9);
					updateStatus = DiRoots.One.SheetLink.Enums.UpdateStatus.None;
				}
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Helpers\\Import\\DataUpdateHandler.cs", "UpdateModel");
			return updateStatus;
		}

		// Token: 0x060012E5 RID: 4837 RVA: 0x0006E3A8 File Offset: 0x0006C5A8
		private static bool \u000A(Document \u001F, bool \u000A, long \u0007)
		{
			if (!\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u000F.\u000A(Document, bool, long)).MethodHandle;
				}
				return true;
			}
			ElementId u000A = \u001E\u0001\u000A.\u000A(\u0007);
			return \u0019\u0012\u0018.\u000A(\u001F, u000A) != 1;
		}

		// Token: 0x060012E6 RID: 4838 RVA: 0x0006E3E8 File Offset: 0x0006C5E8
		private static ReportInfo \u0007(Document \u001F, long \u000A, string \u0007, ChangedColumns \u001D)
		{
			ElementId u000A = \u001E\u0001\u000A.\u000A(\u000A);
			WorksharingTooltipInfo u001F = \u0016\u0012\u0018.\u000A(\u001F, u000A);
			ReportInfo reportInfo = \u0020\u0006\u0018.\u000A(\u0007, \u0011\u0013\u000A.\u000A(ref \u000A), \u001D);
			\u0012\u0006\u0018.\u0007(reportInfo, \u0017\u0006\u0007.\u000A(\u0005\u0012\u0018.\u000A(), \u0018\u0012\u0018.\u000A(u001F)));
			return reportInfo;
		}

		// Token: 0x060012E7 RID: 4839 RVA: 0x0006E438 File Offset: 0x0006C638
		private static void \u001D(Document \u001F, GroupHandler \u000A)
		{
			if (!\u0001\u0006\u0018.\u000A(\u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u000F.\u001D(Document, GroupHandler)).MethodHandle;
				}
				if (\u001B\u000A\u001D.\u000A(\u001E\u000F\u0018.\u000A(\u000A)) > 0)
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
					Transaction transaction = \u001D\u0014\u0007.\u000A(\u001F, "UnGroupElements");
					try
					{
						FailureHandlingOptions failureHandlingOptions = \u0006\u0014\u0007.\u000A(transaction);
						\u0002\u0014\u0007.\u000A(failureHandlingOptions, new \u001E\u001C());
						\u000B\u0014\u0007.\u000A(transaction, failureHandlingOptions);
						\u0007\u0014\u0007.\u000A(transaction);
						\u000B\u0012\u0018.\u000A(\u000A, \u001F);
						\u001B\u0001\u000A.\u000A(transaction);
					}
					finally
					{
						if (transaction != null)
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
							\u001F\u0017\u000A.\u000A(transaction);
						}
					}
				}
			}
		}

		// Token: 0x060012E8 RID: 4840 RVA: 0x0006E4EC File Offset: 0x0006C6EC
		private static Dictionary<int, Element> \u0004(KeyValuePair<DataTable, List<ParamExportInfo>> \u001F, Document \u000A, List<ReportInfo> \u0007, ExportTypes \u001D)
		{
			Dictionary<int, Element> dictionary = \u0010\u0012\u0018.\u000A();
			if (\u001D != ExportTypes.ProjectInformation)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u000F.\u0004(KeyValuePair<DataTable, List<ParamExportInfo>>, Document, List<ReportInfo>, ExportTypes)).MethodHandle;
				}
				if (\u001D == ExportTypes.Rooms)
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
					\u000C\u000D u000C_u000D = new \u000C\u000D();
					\u000D\u0012\u0018.\u0007(u000C_u000D, \u000A);
					\u001C\u0012\u0018.\u000A(u000C_u000D, \u001F);
					\u0003\u0012\u0018.\u000A(u000C_u000D, \u001D);
					\u0012\u0012\u0018.\u0007(u000C_u000D, \u0016\u0006\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F)));
					\u001F\u0010 u001F_u = u000C_u000D;
					dictionary = u001F_u.\u0005();
					\u0006\u0012\u0018.\u000A(\u0007, \u000F\u0012\u0018.\u0007(u001F_u));
				}
				else if (\u001D == ExportTypes.Spaces)
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
					\u0015\u000D u0015_u000D = new \u0015\u000D();
					\u000D\u0012\u0018.\u0007(u0015_u000D, \u000A);
					\u001C\u0012\u0018.\u000A(u0015_u000D, \u001F);
					\u0003\u0012\u0018.\u000A(u0015_u000D, \u001D);
					\u0012\u0012\u0018.\u0007(u0015_u000D, \u0016\u0006\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F)));
					\u001F\u0010 u001F_u2 = u0015_u000D;
					dictionary = u001F_u2.\u0005();
					\u0006\u0012\u0018.\u000A(\u0007, \u000F\u0012\u0018.\u0007(u001F_u2));
				}
				else
				{
					IEnumerable<ParamExportInfo> enumerable = \u0004\u0012\u0018.\u000A(ref \u001F);
					Func<ParamExportInfo, bool> func;
					if ((func = \u0003\u000F.<>c.\u0003) == null)
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
						func = (\u0003\u000F.<>c.\u0003 = new Func<ParamExportInfo, bool>(\u0003\u000F.<>c.\u001F.\u0007\u000A));
					}
					bool u = Enumerable.Any<ParamExportInfo>(enumerable, func);
					\u0003\u000F.\u0004(\u001F, \u000A, \u0007, dictionary, u);
				}
			}
			else
			{
				\u0002\u0012\u0018.\u000A(dictionary, 0, \u0013\u0013\u0007.\u000A(\u000A));
			}
			return dictionary;
		}

		// Token: 0x060012E9 RID: 4841 RVA: 0x0006E628 File Offset: 0x0006C828
		private static void \u0004(KeyValuePair<DataTable, List<ParamExportInfo>> \u001F, Document \u000A, List<ReportInfo> \u0007, Dictionary<int, Element> \u001D, bool \u0004)
		{
			List<string> u001F = \u0014\u000D\u0007.\u000A();
			for (int i = 0; i < \u000A\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F))); i++)
			{
				DataRow u001F2 = \u0011\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F)), i);
				string text = \u001A\u000C\u000A.\u000A(\u001F\u000F\u0018.\u000A(u001F2, 0));
				if (\u001A\u0006\u0007.\u000A(text))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u000F.\u0004(KeyValuePair<DataTable, List<ParamExportInfo>>, Document, List<ReportInfo>, Dictionary<int, Element>, bool)).MethodHandle;
					}
					\u0002\u0012\u0018.\u000A(\u001D, i, \u0007\u000B\u000E.\u001F);
				}
				else
				{
					if (!\u0004)
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
						if (\u001F\u0020\u001D.\u000A(u001F, text))
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
							int num = i + \u0019\u0019\u0018.\u000A(\u001E\u0004\u0018.\u000A(\u0004\u0012\u0018.\u000A(ref \u001F), 0)) + 1;
							ReportInfo reportInfo = \u001B\u0012\u0018.\u000A(\u0016\u0006\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F)), \u001A\u000C\u000A.\u000A(\u001F\u000F\u0018.\u000A(u001F2, 1)));
							\u0008\u0012\u0018.\u0007(reportInfo, \u0004\u001E\u000A.\u000A(\u0004\u000F.\u0002(1), \u000C\u0013\u0007.\u000A(ref num)));
							\u001E\u0006\u0018.\u000A(reportInfo, i);
							\u0012\u0006\u0018.\u0007(reportInfo, \u000E\u0012\u0018.\u000A());
							ReportInfo u000A = reportInfo;
							\u000F\u0006\u0018.\u000A(\u0007, u000A);
							\u0002\u0012\u0018.\u000A(\u001D, i, \u0007\u000B\u000E.\u001F);
							goto IL_13A;
						}
					}
					\u001A\u0008\u0007.\u000A(u001F, text);
					Element u = \u000C\u0008\u0007.\u000A(\u000A, text);
					\u0002\u0012\u0018.\u000A(\u001D, i, u);
				}
				IL_13A:;
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

		// Token: 0x060012EA RID: 4842 RVA: 0x0006E79C File Offset: 0x0006C99C
		private static List<List<DataRow>> \u0019(List<DataRow> \u001F, int \u000A)
		{
			List<List<DataRow>> list = \u0017\u0012\u0018.\u000A();
			for (int i = 0; i < \u0005\u000F\u0018.\u000A(\u001F); i += \u000A)
			{
				int u = \u001F\u0019\u0004.\u000A(\u000A, \u0005\u000F\u0018.\u000A(\u001F) - i);
				\u001E\u0012\u0018.\u000A(list, \u0020\u0012\u0018.\u000A(\u001F, i, u));
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u000F.\u0019(List<DataRow>, int)).MethodHandle;
			}
			return list;
		}

		// Token: 0x060012EB RID: 4843 RVA: 0x0006E7FC File Offset: 0x0006C9FC
		private static void \u0018(Document \u001F, string \u000A, KeyValuePair<DataTable, List<ParamExportInfo>> \u0007, Dictionary<int, Element> \u001D, List<ReportInfo> \u0004)
		{
			List<Document> u000A = \u0017\u000D.\u0015(\u001F);
			Dictionary<int, Element>.Enumerator enumerator = \u0009\u0012\u0018.\u000A(\u001D);
			try
			{
				while (\u0014\u0012\u0018.\u000A(ref enumerator))
				{
					KeyValuePair<int, Element> keyValuePair = \u0001\u0012\u0018.\u000A(ref enumerator);
					Element element = \u0015\u0012\u0018.\u000A(ref keyValuePair);
					if (element == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u000F.\u0018(Document, string, KeyValuePair<DataTable, List<ParamExportInfo>>, Dictionary<int, Element>, List<ReportInfo>)).MethodHandle;
						}
						int num = \u000C\u0012\u0018.\u000A(ref keyValuePair);
						DataRow dataRow = \u0011\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u0007)), num);
						element = \u0017\u000D.\u000A\u000A(\u001A\u000C\u000A.\u000A(\u001F\u000F\u0018.\u000A(dataRow, 0)), u000A);
						string u000A2 = "";
						try
						{
							u000A2 = \u001A\u000C\u000A.\u000A(\u001F\u000F\u0018.\u000A(dataRow, 1));
						}
						catch (Exception u000A3)
						{
							\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Helpers\\Import\\DataUpdateHandler.cs", "GetErrorReports");
						}
						if (element != null)
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
							List<ChangedColumns> u001F = \u0003\u000F.\u0016(\u0004\u0012\u0018.\u000A(ref \u0007), element, dataRow, num);
							for (int i = 0; i < \u0003\u000F\u0018.\u000A(u001F); i++)
							{
								long num2 = \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(element));
								ReportInfo reportInfo = \u0020\u0006\u0018.\u000A(\u000A, \u0011\u0013\u000A.\u000A(ref num2), \u000F\u000F\u0018.\u000A(u001F, i));
								\u001E\u0006\u0018.\u000A(reportInfo, num);
								\u0012\u0006\u0018.\u0007(reportInfo, \u001A\u0012\u0018.\u000A());
								\u000F\u0006\u0018.\u000A(\u0004, reportInfo);
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
						else
						{
							ReportInfo reportInfo2 = \u001B\u0012\u0018.\u000A(\u000A, u000A2);
							\u001E\u0006\u0018.\u000A(reportInfo2, num);
							\u0012\u0006\u0018.\u0007(reportInfo2, \u0013\u0012\u0018.\u000A());
							\u000F\u0006\u0018.\u000A(\u0004, reportInfo2);
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

		// Token: 0x060012EC RID: 4844 RVA: 0x0006E9E8 File Offset: 0x0006CBE8
		private static Dictionary<string, List<ChangedColumns>> \u0005(Dictionary<int, Element> \u001F, KeyValuePair<DataTable, List<ParamExportInfo>> \u000A, Document \u0007, ProgressModel \u001D)
		{
			Dictionary<string, List<ChangedColumns>> dictionary = \u0007\u0003\u0018.\u000A();
			int num = \u000A\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u000A)));
			int num2 = ProgressModel.EAD(num);
			int i = 0;
			while (i < num)
			{
				\u0003\u000F.\u0002();
				int num3 = i + 1;
				if (num3 % num2 == 0)
				{
					goto IL_62;
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u000F.\u0005(Dictionary<int, Element>, KeyValuePair<DataTable, List<ParamExportInfo>>, Document, ProgressModel)).MethodHandle;
				}
				if (num3 == num)
				{
					for (;;)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						goto IL_62;
					}
				}
				IL_94:
				Element element;
				if (\u000A\u0003\u0018.\u000A(\u001F, i, ref element))
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
					if (element != null)
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
						string u000A = \u0012\u0010\u0007.\u000A(element);
						DataRow u = \u0011\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u000A)), i);
						List<ChangedColumns> list = \u0003\u000F.\u0016(\u0004\u0012\u0018.\u000A(ref \u000A), element, u, i + 1);
						if (\u0003\u000F\u0018.\u000A(list) > 0)
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
							if (!\u001A\u0006\u0018.\u000A(dictionary, u000A))
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
								\u001F\u0003\u0018.\u000A(dictionary, u000A, list);
							}
						}
					}
				}
				i++;
				continue;
				IL_62:
				Delegate @delegate = \u0006\u000F\u0018.\u0007(\u001D);
				if (@delegate == null)
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
					goto IL_94;
				}
				object[] array = \u0004\u0015\u0010.\u001F(1);
				array[0] = num3;
				\u0010\u001F\u0018.\u000A(@delegate, array);
				goto IL_94;
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
			return dictionary;
		}

		// Token: 0x060012ED RID: 4845 RVA: 0x0006EB40 File Offset: 0x0006CD40
		private static List<ChangedColumns> \u0016(List<ParamExportInfo> \u001F, Element \u000A, DataRow \u0007, int \u001D)
		{
			IEnumerable<Parameter> enumerable = \u0015\u001C.\u0002(\u000A, false, false);
			Func<Parameter, long> func;
			if ((func = \u0003\u000F.<>c.\u001C) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u000F.\u0016(List<ParamExportInfo>, Element, DataRow, int)).MethodHandle;
				}
				func = (\u0003\u000F.<>c.\u001C = new Func<Parameter, long>(\u0003\u000F.<>c.\u001F.\u001D\u000A));
			}
			IEnumerable<IGrouping<long, Parameter>> enumerable2 = Enumerable.GroupBy<Parameter, long>(enumerable, func);
			Func<IGrouping<long, Parameter>, long> func2;
			if ((func2 = \u0003\u000F.<>c.\u000D) == null)
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
				func2 = (\u0003\u000F.<>c.\u000D = new Func<IGrouping<long, Parameter>, long>(\u0003\u000F.<>c.\u001F.\u0004\u000A));
			}
			Func<IGrouping<long, Parameter>, List<Parameter>> func3;
			if ((func3 = \u0003\u000F.<>c.\u0010) == null)
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
				func3 = (\u0003\u000F.<>c.\u0010 = new Func<IGrouping<long, Parameter>, List<Parameter>>(\u0003\u000F.<>c.\u001F.\u0019\u000A));
			}
			Dictionary<long, List<Parameter>> u000A = Enumerable.ToDictionary<IGrouping<long, Parameter>, long, List<Parameter>>(enumerable2, func2, func3);
			IEnumerable<Parameter> enumerable3 = \u0015\u001C.\u0002(\u000A, true, false);
			Func<Parameter, long> func4;
			if ((func4 = \u0003\u000F.<>c.\u000E) == null)
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
				func4 = (\u0003\u000F.<>c.\u000E = new Func<Parameter, long>(\u0003\u000F.<>c.\u001F.\u0018\u000A));
			}
			IEnumerable<IGrouping<long, Parameter>> enumerable4 = Enumerable.GroupBy<Parameter, long>(enumerable3, func4);
			Func<IGrouping<long, Parameter>, long> func5;
			if ((func5 = \u0003\u000F.<>c.\u0008) == null)
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
				func5 = (\u0003\u000F.<>c.\u0008 = new Func<IGrouping<long, Parameter>, long>(\u0003\u000F.<>c.\u001F.\u0005\u000A));
			}
			Func<IGrouping<long, Parameter>, List<Parameter>> func6;
			if ((func6 = \u0003\u000F.<>c.\u001B) == null)
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
				func6 = (\u0003\u000F.<>c.\u001B = new Func<IGrouping<long, Parameter>, List<Parameter>>(\u0003\u000F.<>c.\u001F.\u0016\u000A));
			}
			Dictionary<long, List<Parameter>> u = Enumerable.ToDictionary<IGrouping<long, Parameter>, long, List<Parameter>>(enumerable4, func5, func6);
			int num = \u0008\u0004\u0018.\u000A(\u001F);
			int num2 = ProgressModel.EAD(num);
			List<ChangedColumns> list = \u0008\u000F\u0018.\u000A();
			for (int i = 1; i < num; i++)
			{
				\u0003\u000F.\u0002();
				if (i % num2 == 0)
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
					\u0008\u000B\u0004.\u000A();
				}
				bool u000A2 = \u000F\u0003\u0018.\u000A(\u001E\u0004\u0018.\u000A(\u001F, i));
				Parameter parameter;
				string text = \u0018\u0012.\u001F(\u000A, u000A, u, \u001E\u0004\u0018.\u000A(\u001F, i), false, out parameter);
				if (parameter != null)
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
					if (!\u0010\u0014\u0007.\u000A(parameter))
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
						if (!\u0015\u001C.\u000D(parameter, \u0014\u0004\u0018.\u0007(\u001E\u0004\u0018.\u000A(\u001F, i))))
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
							if (\u0003\u000F.\u000B(\u001A\u000C\u000A.\u000A(\u001F\u000F\u0018.\u000A(\u0007, i)), parameter, text))
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
								object u001F = list;
								ChangedColumns changedColumns = \u0006\u0003\u0018.\u000A();
								\u0002\u0003\u0018.\u000A(changedColumns, \u0014\u0004\u0018.\u0007(\u001E\u0004\u0018.\u000A(\u001F, i)));
								\u000B\u0003\u0018.\u000A(changedColumns, \u001A\u000C\u000A.\u000A(\u001F\u000F\u0018.\u000A(\u0007, i)));
								\u0016\u0003\u0018.\u000A(changedColumns, parameter);
								\u0005\u0003\u0018.\u000A(changedColumns, text);
								string u001F2 = \u0004\u000F.\u0002(i + 1);
								int num3 = \u001D + \u0019\u0019\u0018.\u000A(\u001E\u0004\u0018.\u000A(\u001F, i));
								\u0018\u0003\u0018.\u000A(changedColumns, \u0004\u001E\u000A.\u000A(u001F2, \u000C\u0013\u0007.\u000A(ref num3)));
								\u0019\u0003\u0018.\u000A(changedColumns, u000A2);
								\u0004\u0003\u0018.\u000A(changedColumns, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u000A)));
								\u001D\u0003\u0018.\u000A(u001F, changedColumns);
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
			return list;
		}

		// Token: 0x060012EE RID: 4846 RVA: 0x0006EE20 File Offset: 0x0006D020
		internal static bool \u000B(string \u001F, Parameter \u000A, string \u0007)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u000F.\u000B(string, Parameter, string)).MethodHandle;
				}
				return false;
			}
			bool flag = \u0012\u0003\u0018.\u0007(\u000A);
			StorageType storageType = \u0011\u001F\u001D.\u0007(\u000A);
			if (!flag)
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
				if (\u001A\u0006\u0007.\u000A(\u001F))
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
					return false;
				}
			}
			if (!flag)
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
				return \u001D\u0017\u000A.\u000A(\u001F, \u0007);
			}
			if (\u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u000A)) == -1006304L)
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
				if (\u0016\u0012.\u001D(\u001F) != \u0016\u0012.\u001D(\u0007))
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
					return true;
				}
				return false;
			}
			else
			{
				if (storageType == 2)
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
					return \u001D\u0017\u000A.\u000A(\u001F, \u0007);
				}
				if (storageType == 3)
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
					\u0007 = \u001C\u000B\u001D.\u0007(\u0007, "\r\n", "\n");
					return \u001D\u0017\u000A.\u000A(\u001F, \u0007);
				}
				if (!\u001E\u000B\u0018.\u000A(\u0020\u001F\u001D.\u0007(\u000A)))
				{
					return \u001D\u0017\u000A.\u000A(\u001F, \u0007);
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
				if (!\u001A\u0006\u0007.\u000A(\u001F))
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
					return \u001D\u0017\u000A.\u000A(\u001F, \u0007);
				}
				return false;
			}
		}

		// Token: 0x060012EF RID: 4847 RVA: 0x0006EF5C File Offset: 0x0006D15C
		private static void \u0002()
		{
			if (\u0005\u0006\u0018.\u000A())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u000F.\u0002()).MethodHandle;
				}
				throw \u0003\u0003\u0018.\u000A();
			}
		}

		// Token: 0x02000892 RID: 2194
		[CompilerGenerated]
		private sealed class \u000B\u000F
		{
			// Token: 0x06004F89 RID: 20361 RVA: 0x001E541C File Offset: 0x001E361C
			internal bool \u000A(ChangedColumns \u001F)
			{
				if (!\u0015\u0006\u0018.\u000A(\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u000F.\u000B\u000F.\u000A(ChangedColumns)).MethodHandle;
					}
					return !\u000F\u0012\u0006.\u000A(this.\u001F, \u0014\u0006\u0018.\u000A(\u001F));
				}
				return false;
			}

			// Token: 0x04002251 RID: 8785
			public GroupHandler \u001F;
		}

		// Token: 0x02000893 RID: 2195
		[CompilerGenerated]
		private sealed class \u0002\u000F
		{
			// Token: 0x06004F8B RID: 20363 RVA: 0x001E5474 File Offset: 0x001E3674
			internal bool \u000A(KeyValuePair<string, Element> \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0020\u0005\u0010.\u000A(ref \u001F), this.\u001F);
			}

			// Token: 0x04002252 RID: 8786
			public string \u001F;
		}

		// Token: 0x02000894 RID: 2196
		[CompilerGenerated]
		private sealed class \u0006\u000F
		{
			// Token: 0x06004F8D RID: 20365 RVA: 0x001E54AC File Offset: 0x001E36AC
			internal bool \u0007(ChangedColumns \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u0014\u0006\u0018.\u000A(\u001F))) == \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u0014\u0006\u0018.\u000A(this.\u001F)));
			}

			// Token: 0x04002253 RID: 8787
			public ChangedColumns \u001F;

			// Token: 0x04002254 RID: 8788
			public Func<ChangedColumns, bool> \u000A;
		}

		// Token: 0x02000895 RID: 2197
		[CompilerGenerated]
		private sealed class \u000F\u000F
		{
			// Token: 0x06004F8F RID: 20367 RVA: 0x001E5500 File Offset: 0x001E3700
			internal bool \u000A(KeyValuePair<string, Element> \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0020\u0005\u0010.\u000A(ref \u001F), this.\u001F);
			}

			// Token: 0x04002255 RID: 8789
			public string \u001F;
		}

		// Token: 0x02000896 RID: 2198
		[CompilerGenerated]
		private sealed class \u0012\u000F
		{
			// Token: 0x06004F91 RID: 20369 RVA: 0x001E5538 File Offset: 0x001E3738
			internal bool \u000A(ReportInfo \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0010\u0006\u0018.\u000A(\u001F), \u0010\u0006\u0018.\u000A(this.\u001F));
			}

			// Token: 0x06004F92 RID: 20370 RVA: 0x001E5564 File Offset: 0x001E3764
			internal bool \u0007(ReportInfo \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0017\u0005\u0010.\u000A(\u001F), \u0017\u0005\u0010.\u000A(this.\u001F));
			}

			// Token: 0x04002256 RID: 8790
			public ReportInfo \u001F;
		}
	}
}

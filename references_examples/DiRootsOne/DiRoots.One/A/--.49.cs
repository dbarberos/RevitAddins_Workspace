using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.TableGen.TGRevitHelper;
using DiRoots.One.TableGen.TGRevitHelper.Script;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.Dto;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace A
{
	// Token: 0x020000EC RID: 236
	internal static class \u000E\u0018
	{
		// Token: 0x060008AF RID: 2223 RVA: 0x000373BC File Offset: 0x000355BC
		internal unsafe static void \u001F(Document \u001F, View \u000A, \u0020\u0019 \u0007, CancellationTokenSource \u001D, out int \u0004, out int \u0019, out int \u0018, out int \u0005)
		{
			\u0004 = 0;
			\u0019 = 0;
			\u0018 = 0;
			\u0005 = 0;
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u0018.\u001F(Document, View, \u0020\u0019, CancellationTokenSource, int*, int*, int*, int*)).MethodHandle;
				}
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
					if (\u0007 != null)
					{
						\u0008\u0016 u0008_u = new \u0008\u0016(\u000A);
						DiRoots.One.TGDatabaseLayer.Dto.SelectedExcel selectedExcel = SchemaUtil.\u0007(\u000A);
						StyleMappingDto styleMappingDto;
						if (selectedExcel == null)
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
							styleMappingDto = \u0001\u0004\u000E.\u001F;
						}
						else
						{
							styleMappingDto = \u0017\u0019\u0004.\u0007(selectedExcel);
						}
						StyleMappingDto styleMappingDto2 = styleMappingDto;
						bool flag;
						if (styleMappingDto2 == null)
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
						else
						{
							GeneralMappingSetting generalMappingSetting = \u0009\u0004\u0004.\u001D(styleMappingDto2);
							bool? flag2;
							bool? flag3;
							if (generalMappingSetting == null)
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
								\u001B\u000A\u000E.\u001F(ref flag2);
								flag3 = flag2;
							}
							else
							{
								flag3 = new bool?(\u0001\u0004\u0004.\u001D(generalMappingSetting));
							}
							flag2 = flag3;
							flag = \u0012\u0015\u000A.\u000A(ref flag2);
						}
						bool u = flag;
						Transaction transaction = \u0013\u0001\u000A.\u000A(\u001F);
						try
						{
							\u0017\u0001\u000A.\u000A(transaction, "TableGen Update Data Only");
							IEnumerator<\u0012\u0005> enumerator = \u0020\u0019\u0004.\u000A(Enumerable.OfType<\u0012\u0005>(\u000C\u001D\u0004.\u0007(\u0007)));
							try
							{
								while (\u000A\u0017\u000A.\u000A(enumerator))
								{
									\u0012\u0005 u0012_u = \u001E\u0019\u0004.\u000A(enumerator);
									if (\u0004\u0013\u001D.\u0007(\u001D))
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
										throw \u001A\u001D\u0004.\u000A();
									}
									if (\u0001\u0001\u001D.\u000A(u0012_u) == InputTypes.Text)
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
										if (\u001A\u001F\u0004.\u0007(u0012_u) != null)
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
											TextNote textNote = u0008_u.\u0007(u0012_u);
											if (textNote == null)
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
												if (\u001A\u0006\u0007.\u000A(\u000A\u0014\u001D.\u001D(\u001A\u001F\u0004.\u0007(u0012_u))))
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
													\u0019++;
													continue;
												}
												try
												{
													if (\u000E\u0018.\u000A(\u001F, \u000A, u0012_u, styleMappingDto2, u) != null)
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
														\u0004++;
													}
													else
													{
														\u0019++;
													}
													continue;
												}
												catch (Exception u000A)
												{
													\u0019++;
													\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\DraftingUpdateDataOnlyHandler.cs", "Update");
													continue;
												}
											}
											try
											{
												\u0014\u0016.\u001D(textNote, \u001A\u001F\u0004.\u0007(u0012_u), ScriptRenderMode.Supported);
												\u0004++;
											}
											catch (Exception u000A2)
											{
												\u0019++;
												\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\DraftingUpdateDataOnlyHandler.cs", "Update");
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
							try
							{
								IEnumerable<TextNote> enumerable = u0008_u.\u001D();
								Func<TextNote, ElementId> func;
								if ((func = \u000E\u0018.<>c.\u000A) == null)
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
									func = (\u000E\u0018.<>c.\u000A = new Func<TextNote, ElementId>(\u000E\u0018.<>c.\u001F.\u0016));
								}
								List<ElementId> list = Enumerable.ToList<ElementId>(Enumerable.Select<TextNote, ElementId>(enumerable, func));
								if (\u001A\u0014\u000A.\u000A(list) > 0)
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
									\u0003\u0009\u001D.\u000A(\u001F, list);
								}
							}
							catch (Exception u000A3)
							{
								\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\DraftingUpdateDataOnlyHandler.cs", "Update");
							}
							List<\u0012\u0005> u001F = \u0008\u0013\u001D.\u000A();
							try
							{
								\u000E\u0018.\u0010\u0018 u0010_u = new \u000E\u0018.\u0010\u0018();
								ICollection<ElementId> collection = \u0011\u0019\u0004.\u000A(\u0017\u0011\u000A.\u0007(\u001A\u0018\u0007.\u000A(\u001F, \u0002\u001E\u000A.\u0007(\u000A)), -2000560L));
								\u000E\u0018.\u0010\u0018 u0010_u2 = u0010_u;
								IEnumerable<Element> enumerable2 = Enumerable.Select<ElementId, Element>(collection, new Func<ElementId, Element>(\u001F.GetElement));
								Func<Element, string> func2;
								if ((func2 = \u000E\u0018.<>c.\u0007) == null)
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
									func2 = (\u000E\u0018.<>c.\u0007 = new Func<Element, string>(\u000E\u0018.<>c.\u001F.\u000B));
								}
								u0010_u2.\u000A = Enumerable.ToLookup<Element, string>(enumerable2, func2);
								IEnumerable<\u0012\u0005> enumerable3 = Enumerable.OfType<\u0012\u0005>(\u000C\u001D\u0004.\u0007(\u0007));
								Func<\u0012\u0005, bool> func3;
								if ((func3 = \u000E\u0018.<>c.\u001D) == null)
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
									func3 = (\u000E\u0018.<>c.\u001D = new Func<\u0012\u0005, bool>(\u000E\u0018.<>c.\u001F.\u0002));
								}
								List<\u0012\u0005> list2 = Enumerable.ToList<\u0012\u0005>(Enumerable.Where<\u0012\u0005>(enumerable3, func3));
								\u000E\u0018.\u0010\u0018 u0010_u3 = u0010_u;
								IEnumerable<\u0012\u0005> enumerable4 = list2;
								Func<\u0012\u0005, string> func4;
								if ((func4 = \u000E\u0018.<>c.\u0004) == null)
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
									func4 = (\u000E\u0018.<>c.\u0004 = new Func<\u0012\u0005, string>(\u000E\u0018.<>c.\u001F.\u0006));
								}
								u0010_u3.\u001F = Enumerable.ToLookup<\u0012\u0005, string>(enumerable4, func4);
								IEnumerable<IGrouping<string, Element>> enumerable5 = Enumerable.Where<IGrouping<string, Element>>(u0010_u.\u000A, new Func<IGrouping<string, Element>, bool>(u0010_u.\u0007));
								Func<IGrouping<string, Element>, IEnumerable<Element>> func5;
								if ((func5 = \u000E\u0018.<>c.\u0019) == null)
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
									func5 = (\u000E\u0018.<>c.\u0019 = new Func<IGrouping<string, Element>, IEnumerable<Element>>(\u000E\u0018.<>c.\u001F.\u000F));
								}
								IEnumerable<Element> enumerable6 = Enumerable.SelectMany<IGrouping<string, Element>, Element>(enumerable5, func5);
								Func<Element, ElementId> func6;
								if ((func6 = \u000E\u0018.<>c.\u0018) == null)
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
									func6 = (\u000E\u0018.<>c.\u0018 = new Func<Element, ElementId>(\u000E\u0018.<>c.\u001F.\u0012));
								}
								List<ElementId> list3 = Enumerable.ToList<ElementId>(Enumerable.Select<Element, ElementId>(enumerable6, func6));
								IEnumerable<IGrouping<string, \u0012\u0005>> enumerable7 = Enumerable.Where<IGrouping<string, \u0012\u0005>>(u0010_u.\u001F, new Func<IGrouping<string, \u0012\u0005>, bool>(u0010_u.\u001D));
								Func<IGrouping<string, \u0012\u0005>, IEnumerable<\u0012\u0005>> func7;
								if ((func7 = \u000E\u0018.<>c.\u0005) == null)
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
									func7 = (\u000E\u0018.<>c.\u0005 = new Func<IGrouping<string, \u0012\u0005>, IEnumerable<\u0012\u0005>>(\u000E\u0018.<>c.\u001F.\u0003));
								}
								u001F = Enumerable.ToList<\u0012\u0005>(Enumerable.SelectMany<IGrouping<string, \u0012\u0005>, \u0012\u0005>(enumerable7, func7));
								if (\u001A\u0014\u000A.\u000A(list3) > 0)
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
									\u0003\u0009\u001D.\u000A(\u001F, list3);
								}
							}
							catch (Exception u000A4)
							{
								\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A4, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\DraftingUpdateDataOnlyHandler.cs", "Update");
							}
							List<\u0012\u0005>.Enumerator enumerator2 = \u001F\u0009\u001D.\u000A(u001F);
							try
							{
								while (\u001E\u0001\u001D.\u000A(ref enumerator2))
								{
									\u0012\u0005 u001F2 = \u0009\u0001\u001D.\u000A(ref enumerator2);
									if (\u0004\u0013\u001D.\u0007(\u001D))
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
										throw \u001A\u001D\u0004.\u000A();
									}
									if (\u0010\u0019\u0004.\u000A(u001F2) != null)
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
										if (\u0010\u0019\u0004.\u000A(u001F2).\u0002())
										{
											try
											{
												double u001F3 = \u001B\u0019\u0004.\u000A(u001F2) / 12.0;
												double u000A5 = \u0008\u0019\u0004.\u000A(u001F2) / 12.0;
												Element u001F4 = \u0018\u0016.\u0007(\u001F, \u000A, \u0007\u0019\u0004.\u0007(\u0010\u0019\u0004.\u000A(u001F2)), \u001B\u001F\u0007.\u000A(u001F3, u000A5, 0.0), \u000E\u0019\u0004.\u000A(\u0010\u0019\u0004.\u000A(u001F2)));
												\u0002\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(u001F4, -1007751L), \u0005\u0014\u001D.\u000A(\u0010\u0019\u0004.\u000A(u001F2)) / 12.0);
												\u0002\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(u001F4, -1007750L), \u0016\u0014\u001D.\u000A(\u0010\u0019\u0004.\u000A(u001F2)) / 12.0);
												\u0018++;
											}
											catch (Exception u000A6)
											{
												\u0005++;
												\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A6, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\DraftingUpdateDataOnlyHandler.cs", "Update");
											}
											finally
											{
												\u000A\u0018.\u0005(\u0007\u0019\u0004.\u0007(\u0010\u0019\u0004.\u000A(u001F2)));
											}
											continue;
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
									\u0005++;
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
								((IDisposable)enumerator2).Dispose();
							}
							\u0018\u0018.\u001F(\u001F);
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
						\u0008\u0018.\u001D(\u001F, \u000A);
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
				}
			}
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x00037B68 File Offset: 0x00035D68
		private static TextNote \u000A(Document \u001F, View \u000A, \u0012\u0005 \u0007, StyleMappingDto \u001D, bool \u0004)
		{
			double num = \u001F\u001D\u0004.\u000A(\u0006\u0017\u001D.\u000A(\u0007));
			bool flag;
			ElementId elementId;
			if (\u0004)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u0018.\u000A(Document, View, \u0012\u0005, StyleMappingDto, bool)).MethodHandle;
				}
				if (\u0004\u001D\u0004.\u000A(\u0007) != null)
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
					elementId = \u0009\u0018.\u0007(\u0004\u001D\u0004.\u000A(\u0007), num, \u001D, \u001F, null, out flag);
					goto IL_9B;
				}
			}
			elementId = \u0008\u0018.\u0007(num, \u0017\u0017\u001D.\u000A(\u0006\u0017\u001D.\u000A(\u0007)), \u0014\u0017\u001D.\u000A(\u0006\u0017\u001D.\u000A(\u0007)), \u0020\u0017\u001D.\u000A(\u0006\u0017\u001D.\u000A(\u0007)), \u0007\u001D\u0004.\u000A(\u0006\u0017\u001D.\u000A(\u0007)), \u001F);
			flag = true;
			IL_9B:
			if (\u0011\u0016\u001D.\u000A(elementId, \u0012\u0015\u0010.\u001F))
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
				return null;
			}
			TextNote textNote = \u0008\u0018.\u000A(\u001F, \u000A, elementId, \u0007);
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
				if (textNote != null)
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
					\u0010\u0005 u0010_u = \u0006\u0017\u001D.\u000A(\u0007);
					bool flag2;
					if (u0010_u == null)
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
						flag2 = false;
					}
					else
					{
						\u001A\u0017\u001D.\u001D(u0010_u);
						flag2 = true;
					}
					if (flag2)
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
						OverrideGraphicSettings overrideGraphicSettings = \u000F\u0005\u0007.\u000A();
						\u0014\u0019\u0004.\u000A(overrideGraphicSettings, \u001A\u0017\u001D.\u0007(\u0006\u0017\u001D.\u000A(\u0007)).\u001F());
						\u0002\u0005\u0007.\u000A(\u000A, \u0002\u001E\u000A.\u0007(textNote), overrideGraphicSettings);
					}
				}
			}
			return textNote;
		}

		// Token: 0x020007F5 RID: 2037
		[CompilerGenerated]
		private sealed class \u0010\u0018
		{
			// Token: 0x06004D36 RID: 19766 RVA: 0x001DDC80 File Offset: 0x001DBE80
			internal bool \u0007(IGrouping<string, Element> \u001F)
			{
				return !\u0019\u001F\u0010.\u000A(this.\u001F, \u0001\u000C\u000D.\u000A(\u001F));
			}

			// Token: 0x06004D37 RID: 19767 RVA: 0x001DDCA8 File Offset: 0x001DBEA8
			internal bool \u001D(IGrouping<string, \u0012\u0005> \u001F)
			{
				return !\u0018\u001F\u0010.\u000A(this.\u000A, \u0005\u001F\u0010.\u000A(\u001F));
			}

			// Token: 0x04002012 RID: 8210
			public ILookup<string, \u0012\u0005> \u001F;

			// Token: 0x04002013 RID: 8211
			public ILookup<string, Element> \u000A;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000203 RID: 515
	internal static class \u0016\u0012
	{
		// Token: 0x06001334 RID: 4916 RVA: 0x00073F48 File Offset: 0x00072148
		internal static void \u001F(Parameter \u001F, string \u000A, Document \u0007)
		{
			\u0016\u0012.\u0005\u0012 u0005_u = new \u0016\u0012.\u0005\u0012();
			u0005_u.\u0007 = \u000A;
			u0005_u.\u001F = \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F));
			StorageType storageType = \u0011\u001F\u001D.\u0007(\u001F);
			List<DropDownparamInfo> list = DropDownparamInfo.\u0005(false);
			u0005_u.\u000A = Enumerable.FirstOrDefault<DropDownparamInfo>(list, new Func<DropDownparamInfo, bool>(u0005_u.\u001D));
			if (u0005_u.\u001F == -1002053L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0012.\u001F(Parameter, string, Document)).MethodHandle;
				}
				int num = \u0017\u000D.\u0011(\u0007, u0005_u.\u0007);
				if (num > -1)
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
					\u0006\u0018\u0007.\u000A(\u001F, num);
					return;
				}
			}
			else
			{
				if (u0005_u.\u001F != -1114147L)
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
					if (u0005_u.\u001F == -1140230L)
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
					}
					else
					{
						if (u0005_u.\u001F != -1114146L)
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
							if (u0005_u.\u001F == -1114136L)
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
							}
							else if (u0005_u.\u001F == -1006210L)
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
								ElementId elementId = \u0017\u000D.\u0004(\u0007, u0005_u.\u0007);
								if (\u001B\u001B\u001D.\u000A(elementId, Constants.InvalidElementId))
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
									\u0019\u0018\u0007.\u000A(\u001F, elementId);
									return;
								}
								return;
							}
							else if (u0005_u.\u001F == -1140333L)
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
								ElementId elementId2 = \u0017\u000D.\u0006(\u0007, u0005_u.\u0007);
								if (\u001B\u001B\u001D.\u000A(elementId2, Constants.InvalidElementId))
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
									\u0019\u0018\u0007.\u000A(\u001F, elementId2);
									return;
								}
								return;
							}
							else if (u0005_u.\u001F == -1140334L)
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
								ElementId elementId3 = \u0017\u000D.\u0012(\u0007, u0005_u.\u0007);
								if (\u001B\u001B\u001D.\u000A(elementId3, Constants.InvalidElementId))
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
									\u0019\u0018\u0007.\u000A(\u001F, elementId3);
									return;
								}
								return;
							}
							else
							{
								if (u0005_u.\u001F == -1002106L)
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
									ElementId u000A = \u0017\u000D.\u0018(\u0007, u0005_u.\u0007);
									\u0019\u0018\u0007.\u000A(\u001F, u000A);
									return;
								}
								if (u0005_u.\u001F == -1005163L)
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
									bool flag = false;
									ViewDiscipline u000A2 = EnumHandler.\u000D<ViewDiscipline>(u0005_u.\u0007, ref flag);
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
										\u0006\u0018\u0007.\u000A(\u001F, u000A2);
										return;
									}
									return;
								}
								else if (u0005_u.\u001F == -1011002L)
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
									bool flag2 = false;
									ViewDetailLevel u000A3 = EnumHandler.\u000D<ViewDetailLevel>(u0005_u.\u0007, ref flag2);
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
										\u0006\u0018\u0007.\u000A(\u001F, u000A3);
										return;
									}
									return;
								}
								else if (u0005_u.\u001F == -1006305L)
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
									ElementId elementId4 = \u0017\u000D.\u0013(\u0007, u0005_u.\u0007);
									if (\u001B\u001B\u001D.\u000A(elementId4, Constants.InvalidElementId))
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
										\u0019\u0018\u0007.\u000A(\u001F, elementId4);
										return;
									}
									return;
								}
								else if (u0005_u.\u001F == -1001122L)
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
									int num2 = EnumHandler.\u0016(u0005_u.\u0007);
									if (num2 > 0)
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
										\u0006\u0018\u0007.\u000A(\u001F, num2);
										return;
									}
									return;
								}
								else
								{
									if (u0005_u.\u001F != -1005172L)
									{
										if (u0005_u.\u001F != -1006304L)
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
											if (u0005_u.\u001F == -1002550L)
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
											}
											else if (u0005_u.\u001F == -1140335L)
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
												int num3 = EnumHandler.\u000F(u0005_u.\u0007);
												if (num3 > -2)
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
													\u0006\u0018\u0007.\u000A(\u001F, num3);
													return;
												}
												return;
											}
											else if (u0005_u.\u001F == -1001006L)
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
												int num4 = EnumHandler.\u0003(u0005_u.\u0007);
												if (num4 > -1)
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
													\u0006\u0018\u0007.\u000A(\u001F, num4);
													return;
												}
												return;
											}
											else if (u0005_u.\u000A != null)
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
												if (\u0008\u000B\u0018.\u000A(u0005_u.\u000A) == -2009014L)
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
													ElementId elementId5 = \u0017\u000D.\u001E(\u0007, u0005_u.\u0007);
													if (\u001B\u001B\u001D.\u000A(elementId5, Constants.InvalidElementId))
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
														\u0019\u0018\u0007.\u000A(\u001F, elementId5);
														return;
													}
													return;
												}
												else if (\u0012\u000B\u0018.\u000A(u0005_u.\u000A))
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
													\u001A\u000F u001A_u000F = Enumerable.FirstOrDefault<\u001A\u000F>(\u0019\u001A\u0019.\u000A(), new Func<\u001A\u000F, bool>(u0005_u.\u0004));
													if (u001A_u000F == null)
													{
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
													KeyValuePair<long, string> keyValuePair = Enumerable.FirstOrDefault<KeyValuePair<long, string>>(\u0007\u0006\u0018.\u000A(u001A_u000F), new Func<KeyValuePair<long, string>, bool>(u0005_u.\u0019));
													if (\u001E\u001B\u0018.\u000A(ref keyValuePair) == 0L)
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
														throw \u0008\u0013\u0007.\u000A(\u0020\u001B\u0018.\u000A());
													}
													ElementId u000A4 = \u001E\u0001\u000A.\u000A(\u001E\u001B\u0018.\u000A(ref keyValuePair));
													\u0019\u0018\u0007.\u000A(\u001F, u000A4);
													return;
												}
												else
												{
													ElementId elementId6 = \u0017\u000D.\u0017(\u0007, \u001C\u000B\u0018.\u000A(u0005_u.\u000A), \u0008\u000B\u0018.\u000A(u0005_u.\u000A), u0005_u.\u0007);
													if (\u001B\u001B\u001D.\u000A(elementId6, \u0012\u0015\u0010.\u001F))
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
														if (\u001B\u001B\u001D.\u000A(elementId6, Constants.InvalidElementId))
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
															\u0019\u0018\u0007.\u000A(\u001F, elementId6);
															return;
														}
													}
													if (!\u0010\u000B\u0018.\u000A(u0005_u.\u000A))
													{
														return;
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
													if (\u0011\u0016\u001D.\u000A(elementId6, Constants.InvalidElementId))
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
														\u0019\u0018\u0007.\u000A(\u001F, elementId6);
														return;
													}
													return;
												}
											}
											else
											{
												if (storageType == 4)
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
													if (\u0011\u001B\u0018.\u000A(\u0020\u001F\u001D.\u0007(\u001F)))
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
														if (\u001B\u001B\u0018.\u000A(\u0020\u001F\u001D.\u0007(\u001F), "Material"))
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
															Element element = Enumerable.FirstOrDefault<Element>(Enumerable.ToList<Element>(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u0007), \u001E\u0011\u000A.\u000A(\u000E\u000B\u000E.\u001F()))), new Func<Element, bool>(u0005_u.\u0018));
															if (element != null)
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
																\u0019\u0018\u0007.\u000A(\u001F, \u0002\u001E\u000A.\u0007(element));
																return;
															}
															throw \u0008\u0013\u0007.\u000A(\u0008\u001B\u0018.\u000A());
														}
													}
												}
												if (storageType == 2)
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
													CultureInfo u = \u0010\u001B\u0018.\u000A(\u000E\u001B\u0018.\u000A());
													double u000A5 = \u000D\u001B\u0018.\u000A(u0005_u.\u0007, NumberStyles.Any, u);
													\u0016\u0012.\u0007(\u001F, u000A5);
													return;
												}
												if (storageType == 1)
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
													if (\u001E\u000B\u0018.\u000A(\u0020\u001F\u001D.\u0007(\u001F)))
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
														\u0006\u0018\u0007.\u000A(\u001F, (!\u000D\u0008\u000A.\u000A(\u0003\u000B\u001D.\u0007(u0005_u.\u0007), "no", true)) ? 1 : 0);
														return;
													}
													int u000A6 = \u0015\u0013\u0007.\u000A(u0005_u.\u0007);
													\u0006\u0018\u0007.\u000A(\u001F, u000A6);
													return;
												}
												else
												{
													if (storageType == 3)
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
														\u0016\u0012.\u0007(\u001F, u0005_u.\u0007);
														return;
													}
													if (storageType == 4)
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
														ElementId u000A7 = Constants.InvalidElementId;
														if (\u001D\u0017\u000A.\u000A(u0005_u.\u0007, "None"))
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
															u000A7 = \u001D\u0012.\u0007(\u001F, \u001E\u001B\u001D.\u001D(\u001F), u0005_u.\u0007);
														}
														\u0019\u0018\u0007.\u000A(\u001F, u000A7);
														return;
													}
													return;
												}
											}
										}
										\u0006\u0018\u0007.\u000A(\u001F, \u0016\u0012.\u001D(u0005_u.\u0007));
										return;
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
									int num5 = EnumHandler.\u0002(u0005_u.\u0007);
									if (num5 > 0)
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
										\u0006\u0018\u0007.\u000A(\u001F, num5);
										return;
									}
									return;
								}
							}
						}
						string text = \u0017\u000D.\u001C(u0005_u.\u0007);
						if (!\u001A\u0006\u0007.\u000A(text))
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
							\u0016\u0018\u001D.\u0007(\u001F, text);
							return;
						}
						return;
					}
				}
				string text2 = \u0017\u000D.\u000E(u0005_u.\u0007);
				if (!\u001A\u0006\u0007.\u000A(text2))
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
					\u0016\u0018\u001D.\u0007(\u001F, text2);
					return;
				}
			}
		}

		// Token: 0x06001335 RID: 4917 RVA: 0x000747B4 File Offset: 0x000729B4
		internal static double \u000A(string \u001F)
		{
			double num = 0.0;
			string u001F = "(\\d+)";
			string u000A = "(\\.)";
			string u = "(\\d+)";
			Match u001F2 = \u000C\u001B\u0018.\u000A(\u001D\u000C\u0004.\u000A(\u0002\u0013\u000A.\u000A(u001F, u000A, u), 17), \u001F);
			if (\u001C\u0005\u0018.\u000A(u001F2))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0012.\u000A(string)).MethodHandle;
				}
				string u001F3 = \u001A\u000C\u000A.\u000A(\u0013\u001B\u0018.\u000A(\u001A\u001B\u0018.\u000A(u001F2), 1));
				string u000A2 = \u001A\u000C\u000A.\u000A(\u0013\u001B\u0018.\u000A(\u001A\u001B\u0018.\u000A(u001F2), 2));
				string u2 = \u001A\u000C\u000A.\u000A(\u0013\u001B\u0018.\u000A(\u001A\u001B\u0018.\u000A(u001F2), 3));
				num = \u0014\u001B\u0018.\u000A(\u0002\u0013\u000A.\u000A(u001F3, u000A2, u2));
			}
			if (num == 0.0)
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
				string u001F4 = \u0005\u000C\u0004.\u000A(\u000D\u0005\u0018.\u000A(\u001F, "\\d+"));
				CultureInfo u3 = \u0010\u001B\u0018.\u000A(\u000E\u001B\u0018.\u000A());
				\u0017\u001B\u0018.\u000A(u001F4, NumberStyles.Any, u3, ref num);
			}
			return num;
		}

		// Token: 0x06001336 RID: 4918 RVA: 0x000748BC File Offset: 0x00072ABC
		internal static void \u0007(Parameter \u001F, string \u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0012.\u0007(Parameter, string)).MethodHandle;
				}
				if (!\u0010\u0014\u0007.\u000A(\u001F))
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
					\u0016\u0018\u001D.\u0007(\u001F, \u000A);
				}
			}
		}

		// Token: 0x06001337 RID: 4919 RVA: 0x00074900 File Offset: 0x00072B00
		internal static void \u0007(Parameter \u001F, double \u000A)
		{
			\u000A = \u0015\u001B\u0018.\u000A(\u001F, \u000A);
			\u0002\u0018\u0007.\u000A(\u001F, \u000A);
		}

		// Token: 0x06001338 RID: 4920 RVA: 0x00074924 File Offset: 0x00072B24
		internal static int \u001D(string \u001F)
		{
			char[] array = \u001C\u0007\u000E.\u001F(1);
			array[0] = ',';
			string[] array2 = \u0009\u0007\u001D.\u000A(\u001F, array);
			if ((int)\u000C\u0007\u000E.\u001F(array2) == 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0012.\u001D(string)).MethodHandle;
				}
				int u001F;
				if (\u001C\u0015\u0004.\u000A(array2[0], ref u001F))
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
					object u001F2 = \u001A\u000C\u000A.\u000A(\u0018\u0012.\u001D(u001F));
					char[] array3 = \u001C\u0007\u000E.\u001F(1);
					array3[0] = ',';
					array2 = \u0009\u0007\u001D.\u000A(u001F2, array3);
				}
			}
			if ((int)\u000C\u0007\u000E.\u001F(array2) == 3)
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
				return (int)\u0001\u001B\u0018.\u000A(array2[0]) << 16 | (int)\u0001\u001B\u0018.\u000A(array2[1]) << 8 | (int)\u0001\u001B\u0018.\u000A(array2[2]);
			}
			return 0;
		}

		// Token: 0x020008AE RID: 2222
		[CompilerGenerated]
		private sealed class \u0005\u0012
		{
			// Token: 0x06004FDF RID: 20447 RVA: 0x001E5E8C File Offset: 0x001E408C
			internal bool \u001D(DropDownparamInfo \u001F)
			{
				return \u0005\u0019\u0010.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x06004FE0 RID: 20448 RVA: 0x001E5EAC File Offset: 0x001E40AC
			internal bool \u0004(\u001A\u000F \u001F)
			{
				return \u0020\u0008\u0005.\u000A(\u001F) == \u0005\u0019\u0010.\u000A(this.\u000A);
			}

			// Token: 0x06004FE1 RID: 20449 RVA: 0x001E5ED0 File Offset: 0x001E40D0
			internal bool \u0019(KeyValuePair<long, string> \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0019\u0016\u0010.\u000A(ref \u001F), this.\u0007);
			}

			// Token: 0x06004FE2 RID: 20450 RVA: 0x001E5EF4 File Offset: 0x001E40F4
			internal bool \u0018(Element \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u0007);
			}

			// Token: 0x0400228B RID: 8843
			public long \u001F;

			// Token: 0x0400228C RID: 8844
			public DropDownparamInfo \u000A;

			// Token: 0x0400228D RID: 8845
			public string \u0007;
		}
	}
}

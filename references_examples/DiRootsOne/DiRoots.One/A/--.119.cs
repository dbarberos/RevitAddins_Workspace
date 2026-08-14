using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000200 RID: 512
	internal static class \u001F\u0012
	{
		// Token: 0x0600131E RID: 4894 RVA: 0x00071A14 File Offset: 0x0006FC14
		internal static List<long> \u000A(ViewSchedule \u001F)
		{
			List<long> result;
			if (\u001F\u0010\u0018.\u000A(\u000B\u0007\u0004.\u000A(\u001F)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0012.\u000A(ViewSchedule)).MethodHandle;
				}
				IEnumerable<ElementId> enumerable = \u0009\u000D\u0018.\u000A();
				Func<ElementId, long> func;
				if ((func = \u001F\u0012.<>c.\u000A) == null)
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
					func = (\u001F\u0012.<>c.\u000A = new Func<ElementId, long>(\u001F\u0012.<>c.\u001F.\u0016));
				}
				result = Enumerable.ToList<long>(Enumerable.Select<ElementId, long>(enumerable, func));
			}
			else if (\u0001\u000D\u0018.\u000A(\u000B\u0007\u0004.\u000A(\u001F)))
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
				IEnumerable<ElementId> enumerable2 = \u0015\u000D\u0018.\u000A();
				Func<ElementId, long> func2;
				if ((func2 = \u001F\u0012.<>c.\u0007) == null)
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
					func2 = (\u001F\u0012.<>c.\u0007 = new Func<ElementId, long>(\u001F\u0012.<>c.\u001F.\u000B));
				}
				result = Enumerable.ToList<long>(Enumerable.Select<ElementId, long>(enumerable2, func2));
			}
			else
			{
				IEnumerable<ElementId> enumerable3 = \u000C\u000D\u0018.\u000A();
				Func<ElementId, long> func3;
				if ((func3 = \u001F\u0012.<>c.\u001D) == null)
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
					func3 = (\u001F\u0012.<>c.\u001D = new Func<ElementId, long>(\u001F\u0012.<>c.\u001F.\u0002));
				}
				result = Enumerable.ToList<long>(Enumerable.Select<ElementId, long>(enumerable3, func3));
			}
			return result;
		}

		// Token: 0x0600131F RID: 4895 RVA: 0x00071B28 File Offset: 0x0006FD28
		internal static List<ScheduleData> \u0007(Document \u001F, ViewSchedule \u000A, List<Element> \u0007, bool \u001D)
		{
			List<ScheduleData> list = \u0014\u000E\u0018.\u000A();
			ViewScheduleExportOptions viewScheduleExportOptions = \u0017\u000E\u0018.\u000A();
			\u0020\u000E\u0018.\u000A(viewScheduleExportOptions, 0);
			\u001E\u000E\u0018.\u000A(viewScheduleExportOptions, false);
			\u0011\u000E\u0018.\u000A(viewScheduleExportOptions, false);
			\u001B\u000E\u0018.\u000A(viewScheduleExportOptions, 0);
			\u0008\u000E\u0018.\u000A(viewScheduleExportOptions, "---DRONE---");
			ViewScheduleExportOptions u001D = viewScheduleExportOptions;
			string u001F = "";
			string u001F2 = "";
			try
			{
				\u001F\u0012.\u0015\u000F u0015_u000F = new \u001F\u0012.\u0015\u000F();
				List<ScheduleFilter> u001F3 = \u000E\u000E\u0018.\u000A();
				BuiltInParameter builtInParameter = -1L;
				u0015_u000F.\u001F = \u001F\u0012.\u0004(\u000A, \u000B\u0013\u0019.\u000A(\u0007, 0), ref builtInParameter);
				if (\u0010\u000E\u0018.\u000A(u0015_u000F.\u001F, \u0015\u0004\u000E.\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0012.\u0007(Document, ViewSchedule, List<Element>, bool)).MethodHandle;
					}
					return list;
				}
				string text = \u0004\u000F.\u0004();
				List<RevitParameter> list2 = \u000D\u000E\u0018.\u000A();
				Transaction transaction = \u001D\u0014\u0007.\u000A(\u001F, "Export Schedule");
				try
				{
					FailureHandlingOptions failureHandlingOptions = \u0006\u0014\u0007.\u000A(transaction);
					\u0002\u0014\u0007.\u000A(failureHandlingOptions, new \u001E\u001C());
					\u000B\u0014\u0007.\u000A(transaction, failureHandlingOptions);
					\u0007\u0014\u0007.\u000A(transaction);
					ViewSchedule u001F4 = \u001A\u0004\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u001F, \u000A\u0013\u0007.\u000A(\u000A, 0)));
					IEnumerator<ScheduleFilter> enumerator = \u001C\u000E\u0018.\u000A(\u0002\u000E\u0018.\u000A(\u000B\u0007\u0004.\u000A(u001F4)));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							ScheduleFilter scheduleFilter = \u0003\u000E\u0018.\u000A(enumerator);
							if (\u000B\u001E\u000A.\u000A(\u0011\u0004\u0004.\u000A(\u001E\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F4), \u0005\u000E\u0018.\u000A(scheduleFilter)))) == (long)builtInParameter)
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
								\u0012\u000E\u0018.\u000A(u001F3, scheduleFilter);
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
								switch (4)
								{
								case 0:
									continue;
								}
								break;
							}
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
					List<ScheduleFilter>.Enumerator enumerator2 = \u000F\u000E\u0018.\u000A(u001F3);
					try
					{
						IL_239:
						while (\u0019\u000E\u0018.\u000A(ref enumerator2))
						{
							ScheduleFilter u001F5 = \u0006\u000E\u0018.\u000A(ref enumerator2);
							int num = \u000B\u000E\u0018.\u000A(\u0002\u000E\u0018.\u000A(\u000B\u0007\u0004.\u000A(u001F4)));
							for (int i = 0; i < num; i++)
							{
								if (\u0018\u000E\u0018.\u000A(\u0005\u000E\u0018.\u000A(\u0016\u000E\u0018.\u000A(\u000B\u0007\u0004.\u000A(u001F4), i))) == \u0018\u000E\u0018.\u000A(\u0005\u000E\u0018.\u000A(u001F5)))
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
									\u000E\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F4), i);
									goto IL_239;
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
						((IDisposable)enumerator2).Dispose();
					}
					bool flag = false;
					IEnumerator<ScheduleFieldId> enumerator3 = \u0007\u000E\u0018.\u000A(\u0014\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F4)));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator3))
						{
							ScheduleFieldId u000A = \u000A\u000E\u0018.\u000A(enumerator3);
							ScheduleField u001F6 = \u001E\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F4), u000A);
							if (\u000B\u001E\u000A.\u000A(\u0011\u0004\u0004.\u000A(u001F6)) == (long)builtInParameter)
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
								if (\u0013\u0010\u0018.\u000A(u001F6) != null)
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
									if (\u0004\u000E\u0018.\u000A(u0015_u000F.\u001F) != 1)
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
								\u001D\u000E\u0018.\u000A(u001F6, false);
								flag = true;
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
						if (enumerator3 != null)
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
							\u001F\u0017\u000A.\u000A(enumerator3);
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
						\u001B\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F4), u0015_u000F.\u001F);
					}
					int num2 = 0;
					enumerator3 = \u0007\u000E\u0018.\u000A(\u0014\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F4)));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator3))
						{
							ScheduleFieldId u000A2 = \u000A\u000E\u0018.\u000A(enumerator3);
							ScheduleField scheduleField = \u001E\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F4), u000A2);
							if (!\u001F\u000E\u0018.\u000A(scheduleField))
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
								RevitParameter revitParameter = \u0009\u0010\u0018.\u000A();
								\u000E\u001B\u0019.\u0007(revitParameter, \u0001\u0010\u0018.\u000A(scheduleField));
								\u000C\u0010\u0018.\u0007(revitParameter, \u0015\u0010\u0018.\u000A(scheduleField));
								\u001A\u0010\u0018.\u000A(revitParameter, num2);
								\u0008\u001B\u0019.\u0007(revitParameter, \u000B\u001E\u000A.\u000A(\u0011\u0004\u0004.\u000A(scheduleField)));
								RevitParameter revitParameter2 = revitParameter;
								if (\u0013\u0010\u0018.\u000A(scheduleField) != null)
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
									if (\u0013\u0010\u0018.\u000A(scheduleField) != 1)
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
										\u0014\u0010\u0018.\u0007(revitParameter2, OtherParamTypes.Schedule);
										\u0013\u001B\u0019.\u0007(revitParameter2, true);
									}
								}
								\u001F\u0012.\u0016(\u001F, scheduleField, revitParameter2);
								\u0017\u0010\u0018.\u000A(list2, revitParameter2);
								num2++;
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
						if (enumerator3 != null)
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
							\u001F\u0017\u000A.\u000A(enumerator3);
						}
					}
					\u0011\u0010\u0018.\u000A(\u000B\u0007\u0004.\u000A(u001F4), true);
					if (\u0020\u0010\u0018.\u000A(\u000B\u0007\u0004.\u000A(u001F4)))
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
						\u001E\u0010\u0018.\u000A(\u000B\u0007\u0004.\u000A(u001F4), false);
					}
					string text2 = \u0004\u001E\u000A.\u000A(\u0006\u0013\u0004.\u000A(), ".txt");
					\u001B\u0010\u0018.\u000A(u001F4, text, text2, u001D);
					\u001F\u0012.\u001D(\u001F, \u0007, \u001D, builtInParameter);
					string text3 = \u0004\u001E\u000A.\u000A(\u0006\u0013\u0004.\u000A(), ".txt");
					\u0011\u0010\u0018.\u000A(\u000B\u0007\u0004.\u000A(u001F4), false);
					\u0011\u0010\u0018.\u000A(\u000B\u0007\u0004.\u000A(u001F4), true);
					\u001B\u0010\u0018.\u000A(u001F4, text, text3, u001D);
					\u001F\u0014\u0007.\u000A(transaction);
					if (\u0010\u0002\u001D.\u000A(\u001B\u0015\u001D.\u000A(text, text3)))
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
						u001F = \u001B\u0015\u001D.\u000A(text, text2);
						u001F2 = \u001B\u0015\u001D.\u000A(text, text3);
					}
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
				int num3 = \u000B\u0010\u0018.\u000A(Enumerable.First<RevitParameter>(list2, new Func<RevitParameter, bool>(u0015_u000F.\u000A)));
				IEnumerable<RevitParameter> enumerable = list2;
				Func<RevitParameter, bool> func;
				if ((func = \u001F\u0012.<>c.\u0004) == null)
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
					func = (\u001F\u0012.<>c.\u0004 = new Func<RevitParameter, bool>(\u001F\u0012.<>c.\u001F.\u0006));
				}
				IEnumerable<RevitParameter> enumerable2 = Enumerable.Where<RevitParameter>(enumerable, func);
				Func<RevitParameter, int> func2;
				if ((func2 = \u001F\u0012.<>c.\u0019) == null)
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
					func2 = (\u001F\u0012.<>c.\u0019 = new Func<RevitParameter, int>(\u001F\u0012.<>c.\u001F.\u000F));
				}
				IEnumerable<IGrouping<int, RevitParameter>> enumerable3 = Enumerable.GroupBy<RevitParameter, int>(enumerable2, func2);
				Func<IGrouping<int, RevitParameter>, int> func3;
				if ((func3 = \u001F\u0012.<>c.\u0018) == null)
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
					func3 = (\u001F\u0012.<>c.\u0018 = new Func<IGrouping<int, RevitParameter>, int>(\u001F\u0012.<>c.\u001F.\u0012));
				}
				Func<IGrouping<int, RevitParameter>, RevitParameter> func4;
				if ((func4 = \u001F\u0012.<>c.\u0005) == null)
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
					func4 = (\u001F\u0012.<>c.\u0005 = new Func<IGrouping<int, RevitParameter>, RevitParameter>(\u001F\u0012.<>c.\u001F.\u0003));
				}
				Dictionary<int, RevitParameter> u001F7 = Enumerable.ToDictionary<IGrouping<int, RevitParameter>, int, RevitParameter>(enumerable3, func3, func4);
				if (\u001A\u0006\u0007.\u000A(u001F))
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
					return \u0006\u000B\u000E.\u001F;
				}
				\u000C\u000F u000C_u000F = new \u000C\u000F(u001F, list2);
				\u000C\u000F u000C_u000F2 = new \u000C\u000F(u001F2, list2);
				try
				{
					\u0007\u0001\u001D.\u000A(u001F);
					\u0007\u0001\u001D.\u000A(u001F2);
				}
				catch (Exception u000A3)
				{
					\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Models\\Schedule\\ScheduleHandler.cs", "GetSchedulAdditionalElements");
				}
				int num4 = 1;
				int num5 = 1;
				if (u000C_u000F.\u001D == null)
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
					return \u0006\u000B\u000E.\u001F;
				}
				IEnumerator u001F8 = \u0008\u0010\u0018.\u000A(\u0002\u000F\u0018.\u000A(u000C_u000F.\u001D));
				try
				{
					while (\u000A\u0017\u000A.\u000A(u001F8))
					{
						DataRow u001F9 = \u000F\u000B\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F8));
						\u001F\u0012.\u0001\u000F u0001_u000F = new \u001F\u0012.\u0001\u000F();
						if (!\u001D)
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
							if (num5 % 20 == 0)
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
								\u0008\u000B\u0004.\u000A();
							}
						}
						num5++;
						u0001_u000F.\u001F = \u000E\u0010\u0018.\u000A();
						try
						{
							DataRow u001F10 = \u0011\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(u000C_u000F2.\u001D), num5 - 2);
							string text4;
							if (\u0002\u0010\u0018.\u000A(u001F10)[num3] != null)
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
								text4 = \u001A\u000C\u000A.\u000A(\u0002\u0010\u0018.\u000A(u001F10)[num3]);
							}
							else
							{
								text4 = "";
							}
							string text5;
							object u001F11 = text5 = text4;
							string[] array = \u001B\u001F\u000E.\u001F(1);
							array[0] = "-DRONE-";
							string[] array2 = \u000E\u000B\u001D.\u000A(u001F11, array, StringSplitOptions.None);
							if (Enumerable.Count<string>(array2) > 1)
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
								text5 = array2[1];
							}
							Regex u001F12 = \u0015\u000F\u0007.\u000A("^-?[0-9]+$");
							if (!\u001A\u0006\u0007.\u000A(text5))
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
								if (\u000C\u000F\u0007.\u001D(u001F12, text5))
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
									\u000D\u0010\u0018.\u000A(u0001_u000F.\u001F, \u0010\u0010\u0018.\u000A(text5));
									if (\u001C\u0010\u0018.\u000A(u001F3) > 0)
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
										if (!Enumerable.Any<Element>(\u0007, new Func<Element, bool>(u0001_u000F.\u000A)))
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
											continue;
										}
									}
									\u0003\u0010\u0018.\u000A(u0001_u000F.\u001F, num4);
									Dictionary<int, RevitParameter>.ValueCollection.Enumerator enumerator4 = \u000F\u0010\u0018.\u000A(\u0012\u0010\u0018.\u000A(u001F7));
									try
									{
										while (\u0007\u0010\u0018.\u000A(ref enumerator4))
										{
											RevitParameter revitParameter3 = \u0006\u0010\u0018.\u000A(ref enumerator4);
											string text6;
											if (\u0002\u0010\u0018.\u000A(u001F9)[\u000B\u0010\u0018.\u000A(revitParameter3)] != null)
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
												text6 = \u001A\u000C\u000A.\u000A(\u0002\u0010\u0018.\u000A(u001F9)[\u000B\u0010\u0018.\u000A(revitParameter3)]);
											}
											else
											{
												text6 = "";
											}
											string u000A4 = text6;
											SchedulParameter schedulParameter = \u0016\u0010\u0018.\u000A();
											\u0005\u0010\u0018.\u000A(schedulParameter, revitParameter3);
											\u0018\u0010\u0018.\u000A(schedulParameter, u000A4);
											SchedulParameter u = schedulParameter;
											\u001D\u0010\u0018.\u000A(\u0019\u0010\u0018.\u000A(u0001_u000F.\u001F), \u0004\u0010\u0018.\u000A(revitParameter3), u);
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
										goto IL_92A;
									}
									finally
									{
										((IDisposable)enumerator4).Dispose();
									}
									continue;
									IL_92A:
									goto IL_92F;
								}
							}
							continue;
						}
						catch (Exception)
						{
							continue;
						}
						IL_92F:
						\u000A\u0010\u0018.\u000A(list, u0001_u000F.\u001F);
						num4++;
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
					IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F8);
					if (disposable != null)
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
						\u001F\u0017\u000A.\u000A(disposable);
					}
				}
				return list;
			}
			catch (Exception u000A5)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A5, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Models\\Schedule\\ScheduleHandler.cs", "GetSchedulAdditionalElements");
			}
			return list;
		}

		// Token: 0x06001320 RID: 4896 RVA: 0x000725CC File Offset: 0x000707CC
		private static void \u001D(Document \u001F, List<Element> \u000A, bool \u0007, BuiltInParameter \u001D)
		{
			SubTransaction subTransaction = \u0016\u0014\u0007.\u000A(\u001F);
			try
			{
				\u0005\u0014\u0007.\u000A(subTransaction);
				int num = 1;
				List<Element>.Enumerator enumerator = \u0001\u0010\u0007.\u000A(\u000A);
				try
				{
					while (\u000C\u0010\u0007.\u000A(ref enumerator))
					{
						Element u001F = \u0015\u0010\u0007.\u000A(ref enumerator);
						if (!\u0007)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0012.\u001D(Document, List<Element>, bool, BuiltInParameter)).MethodHandle;
							}
							if (num % 20 == 0)
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
								\u0008\u000B\u0004.\u000A();
							}
						}
						Parameter parameter = \u0016\u0018\u0007.\u0007(u001F, \u001D);
						if (parameter != null)
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
							if (!\u0010\u0014\u0007.\u000A(parameter))
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
								string text = \u001A\u0014\u0007.\u0007(parameter);
								object u001F2 = parameter;
								string u001F3 = text;
								string u000A = "-DRONE-";
								long num2 = \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F));
								\u0016\u0018\u001D.\u0007(u001F2, \u0002\u0013\u000A.\u000A(u001F3, u000A, \u0011\u0013\u000A.\u000A(ref num2)));
							}
						}
						num++;
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
				\u0019\u0014\u0007.\u000A(subTransaction);
			}
			finally
			{
				if (subTransaction != null)
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
					\u001F\u0017\u000A.\u000A(subTransaction);
				}
			}
		}

		// Token: 0x06001321 RID: 4897 RVA: 0x00072704 File Offset: 0x00070904
		private unsafe static SchedulableField \u0004(ViewSchedule \u001F, Element \u000A, ref BuiltInParameter \u0007)
		{
			\u001F\u0012.\u0009\u000F u0009_u000F = new \u001F\u0012.\u0009\u000F();
			IEnumerable<SchedulableField> enumerable = Enumerable.ToList<SchedulableField>(\u0015\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(\u001F)));
			if (\u0015\u001D\u000E.\u001F(\u000A) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0012.\u0004(ViewSchedule, Element, BuiltInParameter*)).MethodHandle;
				}
				\u0007 = -1007408L;
			}
			else if (\u0005\u001F\u000E.\u001F(\u000A) != null)
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
				\u0007 = -1005114L;
			}
			else
			{
				if (\u0016\u0007\u000E.\u001F(\u000A) == null)
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
					if (\u0014\u0009\u0010.\u001F(\u000A) == null)
					{
						\u0007 = -1001203L;
						goto IL_9B;
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
				\u0007 = -1006901L;
			}
			IL_9B:
			u0009_u000F.\u001F = \u0007;
			return Enumerable.FirstOrDefault<SchedulableField>(enumerable, new Func<SchedulableField, bool>(u0009_u000F.\u000A));
		}

		// Token: 0x06001322 RID: 4898 RVA: 0x000727C8 File Offset: 0x000709C8
		internal static DataTable \u0019(CategoryCollection \u001F, Document \u000A, List<RevitParameter> \u0007)
		{
			ViewSchedule viewSchedule = \u0001\u001D\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u000A, \u001E\u0001\u000A.\u000A(\u0013\u000E\u0018.\u0007(\u001F))));
			TransactionGroup transactionGroup = \u000E\u000E\u001D.\u000A(\u000A);
			string u001F;
			try
			{
				\u0010\u000E\u001D.\u000A(transactionGroup, "Get Schedule Data");
				u001F = \u001F\u0012.\u000B(viewSchedule);
				\u001A\u0017\u0007.\u000A(transactionGroup);
			}
			finally
			{
				if (transactionGroup != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0012.\u0019(CategoryCollection, Document, List<RevitParameter>)).MethodHandle;
					}
					\u001F\u0017\u000A.\u000A(transactionGroup);
				}
			}
			if (!\u001A\u0006\u0007.\u000A(u001F))
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
				\u000C\u000F u000C_u000F = new \u000C\u000F(u001F, \u0007);
				try
				{
					\u0007\u0001\u001D.\u000A(u001F);
					\u001F\u0012.\u0005(\u000A, viewSchedule, \u0007);
				}
				catch (Exception u000A)
				{
					\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Models\\Schedule\\ScheduleHandler.cs", "GetScheduleData");
				}
				return u000C_u000F.\u001D;
			}
			return null;
		}

		// Token: 0x06001323 RID: 4899 RVA: 0x000728AC File Offset: 0x00070AAC
		internal static DataTable \u0018(CategoryCollection \u001F, Document \u000A, List<RevitParameter> \u0007)
		{
			ViewSchedule viewSchedule = \u0001\u001D\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u000A, \u001E\u0001\u000A.\u000A(\u0013\u000E\u0018.\u0007(\u001F))));
			TransactionGroup transactionGroup = \u000E\u000E\u001D.\u000A(\u000A);
			string u001F2;
			try
			{
				\u0010\u000E\u001D.\u000A(transactionGroup, "Get Schedule Data");
				Transaction transaction = \u0013\u0001\u000A.\u000A(\u000A);
				try
				{
					\u0017\u0001\u000A.\u000A(transaction, "Get Schedule Data");
					\u000D\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(viewSchedule), false);
					\u001D\u0008\u0018.\u000A(\u000B\u0007\u0004.\u000A(viewSchedule), false);
					\u0007\u0008\u0018.\u000A(\u000B\u0007\u0004.\u000A(viewSchedule), false);
					IList<ScheduleSortGroupField> u001F = \u000A\u0008\u0018.\u000A(\u000B\u0007\u0004.\u000A(viewSchedule));
					for (int i = 0; i < \u001A\u000E\u0018.\u000A(u001F); i++)
					{
						ScheduleSortGroupField scheduleSortGroupField = \u001F\u0008\u0018.\u000A(u001F, i);
						\u0009\u000E\u0018.\u000A(scheduleSortGroupField, false);
						\u0001\u000E\u0018.\u000A(scheduleSortGroupField, false);
						\u0015\u000E\u0018.\u000A(scheduleSortGroupField, false);
						\u000C\u000E\u0018.\u000A(\u000B\u0007\u0004.\u000A(viewSchedule), i, scheduleSortGroupField);
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0012.\u0018(CategoryCollection, Document, List<RevitParameter>)).MethodHandle;
					}
					\u001B\u0001\u000A.\u000A(transaction);
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
				u001F2 = \u001F\u0012.\u000B(viewSchedule);
				\u001A\u0017\u0007.\u000A(transactionGroup);
			}
			finally
			{
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
					\u001F\u0017\u000A.\u000A(transactionGroup);
				}
			}
			if (!\u001A\u0006\u0007.\u000A(u001F2))
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
				\u000C\u000F u000C_u000F = new \u000C\u000F(u001F2, \u0007);
				try
				{
					\u0007\u0001\u001D.\u000A(u001F2);
					\u001F\u0012.\u0005(\u000A, viewSchedule, \u0007);
				}
				catch (Exception u000A)
				{
					\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Models\\Schedule\\ScheduleHandler.cs", "GetScheduleDataV1");
				}
				return u000C_u000F.\u001D;
			}
			return null;
		}

		// Token: 0x06001324 RID: 4900 RVA: 0x00072A68 File Offset: 0x00070C68
		private static void \u0005(Document \u001F, ViewSchedule \u000A, List<RevitParameter> \u0007)
		{
			try
			{
				int num = 0;
				IEnumerator<ScheduleFieldId> enumerator = \u0007\u000E\u0018.\u000A(\u0014\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(\u000A)));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						ScheduleFieldId u000A = \u000A\u000E\u0018.\u000A(enumerator);
						ScheduleField scheduleField = \u001E\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(\u000A), u000A);
						if (!\u001F\u000E\u0018.\u000A(scheduleField))
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0012.\u0005(Document, ViewSchedule, List<RevitParameter>)).MethodHandle;
							}
							\u001F\u0012.\u0016(\u001F, scheduleField, \u0004\u0008\u0018.\u000A(\u0007, num));
							num++;
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
			}
			catch (Exception u000A2)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Models\\Schedule\\ScheduleHandler.cs", "CollectUnitSymbols");
			}
		}

		// Token: 0x06001325 RID: 4901 RVA: 0x00072B40 File Offset: 0x00070D40
		internal static void \u0016(Document \u001F, ScheduleField \u000A, RevitParameter \u0007)
		{
			if (\u000A == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0012.\u0016(Document, ScheduleField, RevitParameter)).MethodHandle;
				}
				return;
			}
			UnitOption u001F = \u0010\u0008\u0018.\u000A(\u0007);
			\u001C\u0008\u0018.\u000A(u001F, \u000D\u0008\u0018.\u000A(\u000A));
			if (\u0003\u0008\u0018.\u000A(u001F))
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
				FormatOptions u001F2 = \u0012\u0008\u0018.\u000A(\u000A, \u001F);
				\u0006\u0008\u0018.\u000A(u001F, \u000F\u0008\u0018.\u000A(u001F2));
				\u000B\u0008\u0018.\u000A(u001F, \u0002\u0008\u0018.\u000A(u001F2));
				\u0005\u0008\u0018.\u000A(u001F, \u0016\u0008\u0018.\u000A(u001F2));
				\u0019\u0008\u0018.\u000A(u001F, \u0018\u0008\u0018.\u000A(u001F2, \u001F));
			}
		}

		// Token: 0x06001326 RID: 4902 RVA: 0x00072BD4 File Offset: 0x00070DD4
		private static string \u000B(ViewSchedule \u001F)
		{
			try
			{
				ViewScheduleExportOptions viewScheduleExportOptions = \u0017\u000E\u0018.\u000A();
				\u0020\u000E\u0018.\u000A(viewScheduleExportOptions, 0);
				\u0011\u000E\u0018.\u000A(viewScheduleExportOptions, false);
				\u001B\u000E\u0018.\u000A(viewScheduleExportOptions, 0);
				\u0008\u000E\u0018.\u000A(viewScheduleExportOptions, "---DRONE---");
				string text = \u0004\u000F.\u0004();
				string text2 = \u0004\u001E\u000A.\u000A(\u0006\u0013\u0004.\u000A(), ".txt");
				\u001B\u0010\u0018.\u000A(\u001F, text, text2, viewScheduleExportOptions);
				if (\u0010\u0002\u001D.\u000A(\u001B\u0015\u001D.\u000A(text, text2)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0012.\u000B(ViewSchedule)).MethodHandle;
					}
					return \u001B\u0015\u001D.\u000A(text, text2);
				}
			}
			catch (Exception u001F)
			{
				\u0004\u000F.\u0016(u001F);
			}
			return null;
		}

		// Token: 0x0400079F RID: 1951
		private static string \u001F;

		// Token: 0x020008A5 RID: 2213
		[CompilerGenerated]
		private sealed class \u0015\u000F
		{
			// Token: 0x06004FC8 RID: 20424 RVA: 0x001E5B78 File Offset: 0x001E3D78
			internal bool \u000A(RevitParameter \u001F)
			{
				if (\u0017\u000B\u0018.\u0007(\u001F) == \u000B\u001E\u000A.\u000A(\u0013\u0004\u0004.\u000A(this.\u001F)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0012.\u0015\u000F.\u000A(RevitParameter)).MethodHandle;
					}
					return \u0004\u001B\u0018.\u0007(\u001F) != OtherParamTypes.Schedule;
				}
				return false;
			}

			// Token: 0x0400227D RID: 8829
			public SchedulableField \u001F;
		}

		// Token: 0x020008A6 RID: 2214
		[CompilerGenerated]
		private sealed class \u0001\u000F
		{
			// Token: 0x06004FCA RID: 20426 RVA: 0x001E5BDC File Offset: 0x001E3DDC
			internal bool \u000A(Element \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)) == \u0001\u0017\u0005.\u000A(this.\u001F);
			}

			// Token: 0x0400227E RID: 8830
			public ScheduleData \u001F;
		}

		// Token: 0x020008A7 RID: 2215
		[CompilerGenerated]
		private sealed class \u0009\u000F
		{
			// Token: 0x06004FCC RID: 20428 RVA: 0x001E5C1C File Offset: 0x001E3E1C
			internal bool \u000A(SchedulableField \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0013\u0004\u0004.\u000A(\u001F)) == this.\u001F;
			}

			// Token: 0x0400227F RID: 8831
			public BuiltInParameter \u001F;
		}
	}
}

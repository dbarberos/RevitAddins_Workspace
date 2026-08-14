using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000244 RID: 580
	internal class \u001F\u000D : \u0015\u001C
	{
		// Token: 0x06001738 RID: 5944 RVA: 0x00098144 File Offset: 0x00096344
		public override void \u0005(CategoryCollection \u001F, Document \u000A)
		{
			if (RevitParameter.CO(this, \u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u000D.\u0005(CategoryCollection, Document)).MethodHandle;
				}
				return;
			}
			if (\u0014\u0012\u0005.\u001D(\u001F) == null)
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
				if (\u0016\u001E\u0018.\u0007(\u001F))
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
					ViewSchedule u001F = \u0001\u001D\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u000A, \u001E\u0001\u000A.\u000A(\u0013\u000E\u0018.\u0007(\u001F))));
					List<long> list = \u001F\u001B\u0019.\u000A();
					List<Element> list2 = \u0016\u0016\u0004.\u000A();
					if (\u0011\u000E\u0005.\u000A(\u000A, \u0002\u001E\u000A.\u0007(u001F)))
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
						list2 = Enumerable.ToList<Element>(\u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(\u001A\u0018\u0007.\u000A(\u000A, \u0002\u001E\u000A.\u0007(u001F)))));
						object u001F2 = list;
						IEnumerable<Element> enumerable = list2;
						Func<Element, bool> func;
						if ((func = \u001F\u000D.<>c.\u000A) == null)
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
							func = (\u001F\u000D.<>c.\u000A = new Func<Element, bool>(\u001F\u000D.<>c.\u001F.\u0012));
						}
						IEnumerable<Element> enumerable2 = Enumerable.Where<Element>(enumerable, func);
						Func<Element, long> func2;
						if ((func2 = \u001F\u000D.<>c.\u0007) == null)
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
							func2 = (\u001F\u000D.<>c.\u0007 = new Func<Element, long>(\u001F\u000D.<>c.\u001F.\u0003));
						}
						\u0009\u0008\u0019.\u000A(u001F2, Enumerable.ToList<long>(Enumerable.Select<Element, long>(enumerable2, func2)));
						IEnumerable<long> enumerable3 = Enumerable.Distinct<long>(list);
						Func<long, bool> func3;
						if ((func3 = \u001F\u000D.<>c.\u001D) == null)
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
							func3 = (\u001F\u000D.<>c.\u001D = new Func<long, bool>(\u001F\u000D.<>c.\u001F.\u001C));
						}
						list = Enumerable.ToList<long>(Enumerable.Where<long>(enumerable3, func3));
					}
					ScheduleDefinition u001F3 = \u000B\u0007\u0004.\u000A(u001F);
					if (\u000F\u0007\u0004.\u000A(u001F3) > 0)
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
						Dictionary<ScheduleField, Parameter> dictionary = \u001B\u000E\u0005.\u000A();
						Dictionary<ScheduleField, Parameter> dictionary2 = \u001B\u000E\u0005.\u000A();
						List<ScheduleField> u001F4 = \u0008\u000E\u0005.\u000A();
						if (\u001B\u000A\u001D.\u000A(list) == 0)
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
							if (\u0019\u0016\u0004.\u0007(list2) > 0)
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
								\u001F\u000D.\u0010(u001F3, list2, dictionary, dictionary2);
								goto IL_308;
							}
						}
						IEnumerable<Element> enumerable4 = list2;
						Func<Element, bool> func4;
						if ((func4 = \u001F\u000D.<>c.\u0004) == null)
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
							func4 = (\u001F\u000D.<>c.\u0004 = new Func<Element, bool>(\u001F\u000D.<>c.\u001F.\u000D));
						}
						List<Element> u000A;
						if (!Enumerable.Any<Element>(enumerable4, func4))
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
							if (\u001B\u001B\u001D.\u000A(\u000E\u000E\u0005.\u000A(u001F3), \u0012\u0015\u0010.\u001F))
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
								if (\u001B\u001B\u001D.\u000A(\u000E\u000E\u0005.\u000A(u001F3), Constants.InvalidElementId))
								{
									for (;;)
									{
										switch (7)
										{
										case 0:
											continue;
										}
										goto IL_266;
									}
								}
							}
							\u001F\u000D.\u0001\u001C u0001_u001C = new \u001F\u000D.\u0001\u001C();
							u0001_u001C.\u001F = \u001F\u0012.\u000A(u001F);
							List<Element> list3 = Enumerable.ToList<Element>(Enumerable.Where<Element>(list2, new Func<Element, bool>(u0001_u001C.\u000A)));
							if (\u0019\u0016\u0004.\u0007(list3) == 0)
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
								u000A = list2;
								goto IL_2F4;
							}
							u000A = list3;
							goto IL_2F4;
						}
						IL_266:
						IEnumerable<Element> enumerable5 = list2;
						Func<Element, bool> func5;
						if ((func5 = \u001F\u000D.<>c.\u0019) == null)
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
							func5 = (\u001F\u000D.<>c.\u0019 = new Func<Element, bool>(\u001F\u000D.<>c.\u001F.\u0010));
						}
						u000A = Enumerable.ToList<Element>(Enumerable.Where<Element>(enumerable5, func5));
						IL_2F4:
						\u0011\u0017\u0019.\u0007(\u001F, u000A);
						\u001F\u000D.\u0010(u001F3, u000A, dictionary, dictionary2);
						IL_308:
						for (int i = 0; i < \u000F\u0007\u0004.\u000A(u001F3); i++)
						{
							\u001F\u000D.\u0009\u001C u0009_u001C = new \u001F\u000D.\u0009\u001C();
							ScheduleField scheduleField = \u0010\u000E\u0005.\u000A(u001F3, i);
							if (!\u001F\u000E\u0018.\u000A(scheduleField))
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
								u0009_u001C.\u000A = \u0001\u0010\u0018.\u000A(scheduleField);
								u0009_u001C.\u001F = \u000B\u001E\u000A.\u000A(\u0011\u0004\u0004.\u000A(scheduleField));
								u0009_u001C.\u0007 = \u0013\u0010\u0018.\u000A(scheduleField);
								KeyValuePair<ScheduleField, Parameter> keyValuePair = Enumerable.FirstOrDefault<KeyValuePair<ScheduleField, Parameter>>(dictionary, new Func<KeyValuePair<ScheduleField, Parameter>, bool>(u0009_u001C.\u001D));
								if (\u000D\u000E\u0005.\u000A(ref keyValuePair) == null)
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
									keyValuePair = Enumerable.FirstOrDefault<KeyValuePair<ScheduleField, Parameter>>(dictionary2, new Func<KeyValuePair<ScheduleField, Parameter>, bool>(u0009_u001C.\u0004));
								}
								if (\u000D\u000E\u0005.\u000A(ref keyValuePair) == null)
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
									\u001C\u000E\u0005.\u000A(u001F4, scheduleField);
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
						List<RevitParameter> list4 = \u000D\u000E\u0018.\u000A();
						\u000D\u0020\u0018.\u000A(list4, this.\u0003(dictionary, \u001F, false));
						\u000D\u0020\u0018.\u000A(list4, this.\u0003(dictionary2, \u001F, true));
						\u000D\u0020\u0018.\u000A(list4, this.\u0003(u001F4, \u001F));
						IEnumerable<RevitParameter> enumerable6 = list4;
						Func<RevitParameter, int> func6;
						if ((func6 = \u001F\u000D.<>c.\u0018) == null)
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
							func6 = (\u001F\u000D.<>c.\u0018 = new Func<RevitParameter, int>(\u001F\u000D.<>c.\u001F.\u000E));
						}
						list4 = Enumerable.ToList<RevitParameter>(Enumerable.OrderBy<RevitParameter, int>(enumerable6, func6));
						base.\u001C(list4, \u001F);
					}
				}
			}
		}

		// Token: 0x06001739 RID: 5945 RVA: 0x000985CC File Offset: 0x000967CC
		private static void \u0010(ScheduleDefinition \u001F, List<Element> \u000A, Dictionary<ScheduleField, Parameter> \u0007, Dictionary<ScheduleField, Parameter> \u001D)
		{
			Dictionary<ScheduleField, long> u001F = \u001D\u0008\u0005.\u000A();
			for (int i = 0; i < \u000F\u0007\u0004.\u000A(\u001F); i++)
			{
				ScheduleField scheduleField = \u0010\u000E\u0005.\u000A(\u001F, i);
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u000D.\u0010(ScheduleDefinition, List<Element>, Dictionary<ScheduleField, Parameter>, Dictionary<ScheduleField, Parameter>)).MethodHandle;
					}
					if (\u0013\u0010\u0018.\u000A(scheduleField) != null)
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
						if (\u0013\u0010\u0018.\u000A(scheduleField) != 1)
						{
							goto IL_72;
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
					\u0007\u0008\u0005.\u000A(u001F, scheduleField, \u000B\u001E\u000A.\u000A(\u0011\u0004\u0004.\u000A(scheduleField)));
				}
				IL_72:;
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
			for (int j = 0; j < \u0019\u0016\u0004.\u0007(\u000A); j++)
			{
				if (j % 20 == 0)
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
					if (\u000A\u0008\u0005.\u000A())
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
						\u0008\u000B\u0004.\u000A();
					}
				}
				IEnumerable<Parameter> enumerable = \u0015\u001C.\u0002(\u000B\u0013\u0019.\u000A(\u000A, j), false, true);
				Func<Parameter, long> func;
				if ((func = \u001F\u000D.<>c.\u0005) == null)
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
					func = (\u001F\u000D.<>c.\u0005 = new Func<Parameter, long>(\u001F\u000D.<>c.\u001F.\u0008));
				}
				IEnumerable<IGrouping<long, Parameter>> enumerable2 = Enumerable.GroupBy<Parameter, long>(enumerable, func);
				Func<IGrouping<long, Parameter>, long> func2;
				if ((func2 = \u001F\u000D.<>c.\u0016) == null)
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
					func2 = (\u001F\u000D.<>c.\u0016 = new Func<IGrouping<long, Parameter>, long>(\u001F\u000D.<>c.\u001F.\u001B));
				}
				Func<IGrouping<long, Parameter>, List<Parameter>> func3;
				if ((func3 = \u001F\u000D.<>c.\u000B) == null)
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
					func3 = (\u001F\u000D.<>c.\u000B = new Func<IGrouping<long, Parameter>, List<Parameter>>(\u001F\u000D.<>c.\u001F.\u0011));
				}
				Dictionary<long, List<Parameter>> u001F2 = Enumerable.ToDictionary<IGrouping<long, Parameter>, long, List<Parameter>>(enumerable2, func2, func3);
				IEnumerable<Parameter> enumerable3 = \u0015\u001C.\u0002(\u000B\u0013\u0019.\u000A(\u000A, j), true, true);
				Func<Parameter, long> func4;
				if ((func4 = \u001F\u000D.<>c.\u0002) == null)
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
					func4 = (\u001F\u000D.<>c.\u0002 = new Func<Parameter, long>(\u001F\u000D.<>c.\u001F.\u001E));
				}
				IEnumerable<IGrouping<long, Parameter>> enumerable4 = Enumerable.GroupBy<Parameter, long>(enumerable3, func4);
				Func<IGrouping<long, Parameter>, long> func5;
				if ((func5 = \u001F\u000D.<>c.\u0006) == null)
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
					func5 = (\u001F\u000D.<>c.\u0006 = new Func<IGrouping<long, Parameter>, long>(\u001F\u000D.<>c.\u001F.\u0020));
				}
				Func<IGrouping<long, Parameter>, List<Parameter>> func6;
				if ((func6 = \u001F\u000D.<>c.\u000F) == null)
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
					func6 = (\u001F\u000D.<>c.\u000F = new Func<IGrouping<long, Parameter>, List<Parameter>>(\u001F\u000D.<>c.\u001F.\u0017));
				}
				Dictionary<long, List<Parameter>> u001F3 = Enumerable.ToDictionary<IGrouping<long, Parameter>, long, List<Parameter>>(enumerable4, func5, func6);
				Dictionary<ScheduleField, long>.Enumerator enumerator = \u001F\u0008\u0005.\u000A(u001F);
				try
				{
					while (\u0017\u000E\u0005.\u000A(ref enumerator))
					{
						KeyValuePair<ScheduleField, long> keyValuePair = \u0009\u000E\u0005.\u000A(ref enumerator);
						long u000A = \u0001\u000E\u0005.\u000A(ref keyValuePair);
						ScheduleField u000A2 = \u0015\u000E\u0005.\u000A(ref keyValuePair);
						if (!\u000C\u000E\u0005.\u000A(\u0007, u000A2))
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
							if (!\u000C\u000E\u0005.\u000A(\u001D, u000A2))
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
								if (\u001A\u000E\u0005.\u000A(u001F2, u000A))
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
									\u0014\u000E\u0005.\u000A(\u0007, u000A2, \u000B\u001B\u0018.\u000A(\u0013\u000E\u0005.\u000A(u001F2, u000A), 0));
								}
								else if (\u001A\u000E\u0005.\u000A(u001F3, u000A))
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
									\u0014\u000E\u0005.\u000A(\u001D, u000A2, \u000B\u001B\u0018.\u000A(\u0013\u000E\u0005.\u000A(u001F3, u000A), 0));
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
					((IDisposable)enumerator).Dispose();
				}
				if (\u0020\u000E\u0005.\u000A(u001F) == \u001E\u000E\u0005.\u000A(\u0007) + \u001E\u000E\u0005.\u000A(\u001D))
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
			}
			for (;;)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				return;
			}
		}

		// Token: 0x0600173A RID: 5946 RVA: 0x0009890C File Offset: 0x00096B0C
		private List<RevitParameter> \u0003(Dictionary<ScheduleField, Parameter> \u001F, CategoryCollection \u000A, bool \u0007)
		{
			List<RevitParameter> list = \u000D\u000E\u0018.\u000A();
			Dictionary<ScheduleField, Parameter>.Enumerator enumerator = \u0016\u0008\u0005.\u000A(\u001F);
			try
			{
				while (\u0004\u0008\u0005.\u000A(ref enumerator))
				{
					KeyValuePair<ScheduleField, Parameter> keyValuePair = \u0005\u0008\u0005.\u000A(ref enumerator);
					RevitParameter u000A = \u0019\u0008\u0005.\u000A(\u0018\u0008\u0005.\u000A(ref keyValuePair), \u0013\u000E\u0018.\u0007(\u000A), \u000D\u000E\u0005.\u000A(ref keyValuePair), \u0007);
					\u0017\u0010\u0018.\u000A(list, u000A);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u000D.\u0003(Dictionary<ScheduleField, Parameter>, CategoryCollection, bool)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			ParamNameGroupUniqueHandler.\u0018(this, list);
			ParamUniqueHandler.\u001D(this, list, \u000A);
			return list;
		}

		// Token: 0x0600173B RID: 5947 RVA: 0x000989B0 File Offset: 0x00096BB0
		private List<RevitParameter> \u0003(List<ScheduleField> \u001F, CategoryCollection \u000A)
		{
			List<RevitParameter> list = \u000D\u000E\u0018.\u000A();
			List<ScheduleField>.Enumerator enumerator = \u000F\u0008\u0005.\u000A(\u001F);
			try
			{
				while (\u000B\u0008\u0005.\u000A(ref enumerator))
				{
					RevitParameter u000A = \u0002\u0008\u0005.\u000A(\u0006\u0008\u0005.\u000A(ref enumerator), \u0013\u000E\u0018.\u0007(\u000A));
					\u0017\u0010\u0018.\u000A(list, u000A);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u000D.\u0003(List<ScheduleField>, CategoryCollection)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			ParamNameGroupUniqueHandler.\u0018(this, list);
			ParamUniqueHandler.\u001D(this, list, \u000A);
			return list;
		}

		// Token: 0x0200091A RID: 2330
		[CompilerGenerated]
		private sealed class \u0001\u001C
		{
			// Token: 0x060051BD RID: 20925 RVA: 0x001E939C File Offset: 0x001E759C
			internal bool \u000A(Element \u001F)
			{
				if (\u000E\u0007\u000E.\u001F(\u001F) != null)
				{
					return false;
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u000D.\u0001\u001C.\u000A(Element)).MethodHandle;
				}
				if (\u000D\u0003\u0018.\u0007(\u001F) != null)
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
					return \u001A\u0008\u0019.\u000A(this.\u001F, \u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(\u001F))));
				}
				return false;
			}

			// Token: 0x040023EA RID: 9194
			public List<long> \u001F;
		}

		// Token: 0x0200091B RID: 2331
		[CompilerGenerated]
		private sealed class \u0009\u001C
		{
			// Token: 0x060051BF RID: 20927 RVA: 0x001E9418 File Offset: 0x001E7618
			internal bool \u001D(KeyValuePair<ScheduleField, Parameter> \u001F)
			{
				if (\u000B\u001E\u000A.\u000A(\u0011\u0004\u0004.\u000A(\u000D\u000E\u0005.\u000A(ref \u001F))) == this.\u001F)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u000D.\u0009\u001C.\u001D(KeyValuePair<ScheduleField, Parameter>)).MethodHandle;
					}
					if (\u0008\u0013\u000A.\u000A(\u0001\u0010\u0018.\u000A(\u000D\u000E\u0005.\u000A(ref \u001F)), this.\u000A))
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
						return \u0013\u0010\u0018.\u000A(\u000D\u000E\u0005.\u000A(ref \u001F)) == this.\u0007;
					}
				}
				return false;
			}

			// Token: 0x060051C0 RID: 20928 RVA: 0x001E949C File Offset: 0x001E769C
			internal bool \u0004(KeyValuePair<ScheduleField, Parameter> \u001F)
			{
				if (\u000B\u001E\u000A.\u000A(\u0011\u0004\u0004.\u000A(\u000D\u000E\u0005.\u000A(ref \u001F))) == this.\u001F)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u000D.\u0009\u001C.\u0004(KeyValuePair<ScheduleField, Parameter>)).MethodHandle;
					}
					if (\u0008\u0013\u000A.\u000A(\u0001\u0010\u0018.\u000A(\u000D\u000E\u0005.\u000A(ref \u001F)), this.\u000A))
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
						return \u0013\u0010\u0018.\u000A(\u000D\u000E\u0005.\u000A(ref \u001F)) == this.\u0007;
					}
				}
				return false;
			}

			// Token: 0x040023EB RID: 9195
			public long \u001F;

			// Token: 0x040023EC RID: 9196
			public string \u000A;

			// Token: 0x040023ED RID: 9197
			public ScheduleFieldType \u0007;
		}
	}
}

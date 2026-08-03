using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Revit.Extensions;

namespace A
{
	// Token: 0x02000201 RID: 513
	internal static class \u001D\u0012
	{
		// Token: 0x06001327 RID: 4903 RVA: 0x00072C7C File Offset: 0x00070E7C
		// Note: this type is marked as 'beforefieldinit'.
		static \u001D\u0012()
		{
			string[] array = \u001B\u001F\u000E.\u001F(1);
			array[0] = " : ";
			\u001D\u0012.\u001F = array;
			\u001D\u0012.ParameterValueCache = \u000E\u0008\u0018.\u000A();
		}

		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x06001328 RID: 4904 RVA: 0x00072CAC File Offset: 0x00070EAC
		// (set) Token: 0x06001329 RID: 4905 RVA: 0x00072CC0 File Offset: 0x00070EC0
		internal static Dictionary<long, List<Element>> ParameterValueCache { get; set; }

		// Token: 0x0600132A RID: 4906 RVA: 0x00072CD4 File Offset: 0x00070ED4
		internal static ElementId \u0007(Parameter \u001F, ElementId \u000A, string \u0007)
		{
			if (\u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F)) == -1005176L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0012.\u0007(Parameter, ElementId, string)).MethodHandle;
				}
				return \u001D\u0012.\u001D(\u001F, \u0007);
			}
			\u001D\u0012.\u000A\u0012 u000A_u = new \u001D\u0012.\u000A\u0012();
			u000A_u.\u000A = \u0007;
			u000A_u.\u001F = \u0007;
			if (\u000F\u000C\u001D.\u0007(\u0007, " : "))
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
				string[] array = \u000E\u000B\u001D.\u000A(\u0007, \u001D\u0012.\u001F, StringSplitOptions.RemoveEmptyEntries);
				u000A_u.\u001F = array[0];
				u000A_u.\u000A = array[1];
			}
			List<Element> list = \u0016\u0016\u0004.\u000A();
			if (!\u0015\u0008\u0018.\u000A(\u0011\u0008\u0018.\u000A(), \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F))))
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
				Document u001F = \u0008\u0019\u0007.\u000A(\u0010\u0003\u0018.\u000A(\u001F));
				if (\u0011\u0016\u001D.\u000A(\u000A, Constants.InvalidElementId))
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
					if (\u000D\u0003\u0018.\u0007(\u0010\u0003\u0018.\u000A(\u001F)) != null)
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
						FilterableValueProvider u001F2 = \u0015\u0011\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F));
						FilterNumericRuleEvaluator u000A = \u000C\u0008\u0018.\u000A();
						ElementId invalidElementId = Constants.InvalidElementId;
						ElementParameterFilter u000A2 = \u0013\u0011\u000A.\u000A(\u000A\u001E\u000A.\u000A(u001F2, u000A, invalidElementId));
						Element element = \u001B\u0011\u000A.\u000A(\u0014\u0011\u000A.\u0007(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(u001F), \u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(\u0010\u0003\u0018.\u000A(\u001F))))), u000A2));
						Parameter parameter;
						if (element == null)
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
							parameter = \u0012\u000B\u000E.\u001F;
						}
						else
						{
							parameter = \u001A\u0008\u0018.\u0007(element, \u0020\u001F\u001D.\u0007(\u001F));
						}
						Parameter parameter2 = parameter;
						if (parameter2 != null)
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
							\u000A = \u001E\u001B\u001D.\u001D(parameter2);
						}
					}
				}
				if (\u001B\u001B\u001D.\u000A(\u000A, Constants.InvalidElementId))
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
					Element u001F3 = \u0011\u0017\u000A.\u0007(u001F, \u000A);
					object u001F4 = Enumerable.ToList<ElementId>(\u0013\u0008\u0018.\u000A(u001F3));
					FilteredElementCollector filteredElementCollector = \u0003\u000B\u000E.\u001F;
					if (\u001A\u0014\u000A.\u000A(u001F4) == 0)
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
						if (\u000D\u0003\u0018.\u0007(u001F3) != null)
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
							filteredElementCollector = \u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(u001F), \u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(u001F3))));
						}
						else if (\u0014\u0008\u0018.\u000A(u001F3))
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
							if (\u001B\u001B\u001D.\u000A(\u0017\u0008\u0018.\u000A(u001F3), \u0012\u0015\u0010.\u001F))
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
								ViewSchedule viewSchedule = \u0001\u001D\u000E.\u001F(\u0011\u0017\u000A.\u0007(u001F, \u0017\u0008\u0018.\u000A(u001F3)));
								if (viewSchedule != null)
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
									if (\u001F\u0010\u0018.\u000A(\u000B\u0007\u0004.\u000A(viewSchedule)))
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
										filteredElementCollector = \u001A\u0018\u0007.\u000A(u001F, \u0017\u0008\u0018.\u000A(u001F3));
									}
								}
							}
						}
						if (filteredElementCollector != null)
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
							list = Enumerable.ToList<Element>(\u0001\u001E\u000A.\u0007(filteredElementCollector));
						}
						if (\u001C\u000B\u000E.\u001F(u001F3) != null)
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
							IEnumerable<Element> enumerable = list;
							Func<Element, bool> func;
							if ((func = \u001D\u0012.<>c.\u000A) == null)
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
								func = (\u001D\u0012.<>c.\u000A = new Func<Element, bool>(\u001D\u0012.<>c.\u001F.\u0004));
							}
							list = Enumerable.ToList<Element>(Enumerable.Where<Element>(enumerable, func));
						}
						else
						{
							IEnumerable<Element> enumerable2 = list;
							Func<Element, bool> func2;
							if ((func2 = \u001D\u0012.<>c.\u0007) == null)
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
								func2 = (\u001D\u0012.<>c.\u0007 = new Func<Element, bool>(\u001D\u0012.<>c.\u001F.\u0019));
							}
							list = Enumerable.ToList<Element>(Enumerable.Where<Element>(enumerable2, func2));
						}
					}
					\u001E\u0008\u0018.\u000A(\u0011\u0008\u0018.\u000A(), \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F)), list);
				}
				else
				{
					FilteredElementCollector filteredElementCollector2 = \u0020\u0008\u0018.\u0007(\u0020\u0011\u000A.\u000A(u001F));
					if (filteredElementCollector2 != null)
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
						list = Enumerable.ToList<Element>(\u0001\u001E\u000A.\u0007(filteredElementCollector2));
					}
					IEnumerable<Element> enumerable3 = list;
					Func<Element, bool> func3;
					if ((func3 = \u001D\u0012.<>c.\u001D) == null)
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
						func3 = (\u001D\u0012.<>c.\u001D = new Func<Element, bool>(\u001D\u0012.<>c.\u001F.\u0018));
					}
					list = Enumerable.ToList<Element>(Enumerable.Where<Element>(enumerable3, func3));
					\u001E\u0008\u0018.\u000A(\u0011\u0008\u0018.\u000A(), \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F)), list);
				}
			}
			list = \u001B\u0008\u0018.\u000A(\u0011\u0008\u0018.\u000A(), \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F)));
			if (\u0019\u0016\u0004.\u0007(list) > 0)
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
				if (\u001C\u000B\u000E.\u001F(Enumerable.First<Element>(list)) != null)
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
					list = Enumerable.ToList<Element>(Enumerable.Where<Element>(list, new Func<Element, bool>(u000A_u.\u0007)));
				}
			}
			Element element2 = Enumerable.FirstOrDefault<Element>(list, new Func<Element, bool>(u000A_u.\u001D));
			if (element2 != null)
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
				return \u0002\u001E\u000A.\u0007(element2);
			}
			throw \u0008\u0013\u0007.\u000A(\u0008\u0008\u0018.\u000A());
		}

		// Token: 0x0600132B RID: 4907 RVA: 0x000731B0 File Offset: 0x000713B0
		private static ElementId \u001D(Parameter \u001F, string \u000A)
		{
			\u001D\u0012.\u0007\u0012 u0007_u = new \u001D\u0012.\u0007\u0012();
			u0007_u.\u001F = \u000A;
			Element element = Enumerable.FirstOrDefault<View>(Enumerable.Cast<View>(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u0008\u0019\u0007.\u000A(\u0010\u0003\u0018.\u000A(\u001F))), -2000279L))), new Func<View, bool>(u0007_u.\u000A));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0012.\u001D(Parameter, string)).MethodHandle;
				}
				return \u0002\u001E\u000A.\u0007(element);
			}
			throw \u0008\u0013\u0007.\u000A(\u0008\u0008\u0018.\u000A());
		}

		// Token: 0x040007A0 RID: 1952
		internal static readonly string[] \u001F;

		// Token: 0x040007A1 RID: 1953
		[CompilerGenerated]
		private static Dictionary<long, List<Element>> \u000A;

		// Token: 0x020008A9 RID: 2217
		[CompilerGenerated]
		private sealed class \u000A\u0012
		{
			// Token: 0x06004FD3 RID: 20435 RVA: 0x001E5CDC File Offset: 0x001E3EDC
			internal bool \u0007(Element \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0001\u0015\u0018.\u0007(\u000B\u0002\u000E.\u001F(\u001F)), this.\u001F);
			}

			// Token: 0x06004FD4 RID: 20436 RVA: 0x001E5D08 File Offset: 0x001E3F08
			internal bool \u001D(Element \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u000A);
			}

			// Token: 0x04002284 RID: 8836
			public string \u001F;

			// Token: 0x04002285 RID: 8837
			public string \u000A;
		}

		// Token: 0x020008AA RID: 2218
		[CompilerGenerated]
		private sealed class \u0007\u0012
		{
			// Token: 0x06004FD6 RID: 20438 RVA: 0x001E5D40 File Offset: 0x001E3F40
			internal bool \u000A(View \u001F)
			{
				if (\u000C\u0009\u001D.\u000A(\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0012.\u0007\u0012.\u000A(View)).MethodHandle;
					}
					return \u000D\u0008\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u001F, true);
				}
				return false;
			}

			// Token: 0x04002286 RID: 8838
			public string \u001F;
		}
	}
}

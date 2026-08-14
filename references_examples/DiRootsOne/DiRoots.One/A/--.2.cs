using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x0200004F RID: 79
	internal static class \u001F\u0007
	{
		// Token: 0x06000287 RID: 647 RVA: 0x0000E400 File Offset: 0x0000C600
		internal static List<XYZ> \u001F(this Curve \u001F)
		{
			List<XYZ> list = \u000B\u000A\u0007.\u000A();
			\u0005\u000A\u0007.\u000A(list, \u0013\u001F\u0007.\u0007(\u001F, 0));
			\u0005\u000A\u0007.\u000A(list, \u0013\u001F\u0007.\u0007(\u001F, 1));
			return list;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000E434 File Offset: 0x0000C634
		internal static XYZ \u000A(this Line \u001F)
		{
			return \u0001\u001D\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0), \u0013\u001F\u0007.\u0007(\u001F, 1)), 2.0);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000E46C File Offset: 0x0000C66C
		internal static XYZ \u0007(this Line \u001F)
		{
			double u001F = 0.5 * (\u000D\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0)) + \u000D\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1)));
			double u000A = 0.5 * (\u001C\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0)) + \u001C\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1)));
			double u = \u0003\u000A\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0));
			return \u001B\u001F\u0007.\u000A(u001F, u000A, u);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000E4EC File Offset: 0x0000C6EC
		internal static Line \u001D(this Line \u001F, XYZ \u000A)
		{
			return \u0002\u0007\u0007.\u000A(\u000F\u0007\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0), \u000A), \u000F\u0007\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1), \u000A));
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000E524 File Offset: 0x0000C724
		internal static double \u0004(this Line \u001F)
		{
			return \u0003\u000A\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1)) - \u0003\u000A\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0));
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000E554 File Offset: 0x0000C754
		internal static List<XYZ> \u0019(this IEnumerable<Curve> \u001F, Line \u000A, bool \u0007 = false)
		{
			List<XYZ> list = \u000B\u000A\u0007.\u000A();
			if (\u0006\u001D\u0007.\u000A(\u000A, \u001C\u0009\u0010.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IEnumerable<Curve>.\u0019(Line, bool)).MethodHandle;
				}
				return list;
			}
			Func<Curve, double> func;
			if ((func = \u001F\u0007.<>c.\u000A) == null)
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
				func = (\u001F\u0007.<>c.\u000A = new Func<Curve, double>(\u001F\u0007.<>c.\u001F.\u0016));
			}
			IEnumerator<Curve> enumerator = \u0017\u001D\u0007.\u000A(Enumerable.OrderBy<Curve, double>(\u001F, func));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Curve u001F = \u0020\u001D\u0007.\u000A(enumerator);
					Line line = \u000D\u0009\u0010.\u001F(u001F);
					if (line != null)
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
						if (\u0007)
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
							if (\u001D\u000A\u0007.\u000A(line).\u0007())
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
						}
						\u001F\u0007.\u0005(\u000A, list, line);
					}
					else
					{
						Arc arc = \u0017\u0009\u0010.\u001F(u001F);
						if (arc != null)
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
							if (\u0007)
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
								if (\u0013\u000A\u0007.\u000A(arc).\u0007())
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
									if (\u0014\u000A\u0007.\u000A(arc).\u0007())
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
								}
							}
							\u001F\u0007.\u0018(\u000A, list, arc);
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
			IEnumerable<XYZ> enumerable = list;
			Func<XYZ, double> func2;
			if ((func2 = \u001F\u0007.<>c.\u0007) == null)
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
				func2 = (\u001F\u0007.<>c.\u0007 = new Func<XYZ, double>(\u001F\u0007.<>c.\u001F.\u000B));
			}
			return Enumerable.ToList<XYZ>(Enumerable.OrderBy<XYZ, double>(enumerable, func2));
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000E6FC File Offset: 0x0000C8FC
		private static void \u0018(Line \u001F, List<XYZ> \u000A, Arc \u0007)
		{
			List<XYZ> list = \u0009\u001D\u0007.\u000A(\u0007, \u001F, false);
			\u0002\u000A\u0007.\u000A(\u000A, Enumerable.ToList<XYZ>(Enumerable.Distinct<XYZ>(list, new \u0008\u0007())));
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000E730 File Offset: 0x0000C930
		private static void \u0005(Line \u001F, List<XYZ> \u000A, Line \u0007)
		{
			XYZ xyz;
			XYZ xyz2;
			bool flag = \u0017\u000A.\u0018(out xyz, out xyz2, \u001F, \u0007);
			if (xyz != \u0020\u0009\u0010.\u001F && flag)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0007.\u0005(Line, List<XYZ>, Line)).MethodHandle;
				}
				if (xyz.\u001D(\u0007))
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
					if (xyz.\u001D(\u001F))
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
						if (!Enumerable.Contains<XYZ>(\u000A, xyz, new \u0008\u0007()))
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
							\u0005\u000A\u0007.\u000A(\u000A, xyz);
						}
					}
				}
			}
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000E7B8 File Offset: 0x0000C9B8
		internal static Line \u0016(this Line \u001F, double \u000A, double \u0007)
		{
			if (\u000A == 0.0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Line.\u0016(double, double)).MethodHandle;
				}
				if (\u0007 == 0.0)
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
					return \u001F;
				}
			}
			XYZ u001F = \u0013\u001F\u0007.\u0007(\u001F, 0);
			XYZ u001F2 = \u0013\u001F\u0007.\u0007(\u001F, 1);
			XYZ u000A = \u001D\u000A\u0007.\u000A(\u001F);
			return \u0002\u0007\u0007.\u000A(\u001F\u0007\u0007.\u000A(u001F, \u0009\u0007\u0007.\u000A(\u000A, u000A)), \u000F\u0007\u0007.\u000A(u001F2, \u0009\u0007\u0007.\u000A(\u0007, u000A)));
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000E840 File Offset: 0x0000CA40
		internal static Line \u000B(this Line \u001F, \u001E\u000A \u000A)
		{
			IEnumerable<Curve> enumerable = \u0011\u0009\u0010.\u001F;
			\u0011\u000A u0011_u000A = \u0008\u0009\u0010.\u001F(\u000A);
			if (u0011_u000A != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Line.\u000B(\u001E\u000A)).MethodHandle;
				}
				enumerable = u0011_u000A.\u0006;
			}
			else
			{
				\u000D\u000A u000D_u000A = \u001B\u0009\u0010.\u001F(\u000A);
				if (u000D_u000A != null)
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
					enumerable = u000D_u000A.\u0004;
				}
			}
			List<XYZ> list = enumerable.\u0019(\u001F, false);
			if (\u000F\u000A\u0007.\u000A(list) == 2)
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
				return \u0002\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(list, 0), \u0016\u000A\u0007.\u000A(list, 1));
			}
			if (\u000F\u000A\u0007.\u000A(list) != 1)
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
				return \u001F;
			}
			IEnumerable<XYZ> enumerable2 = list;
			Func<XYZ, bool> func;
			if ((func = \u001F\u0007.<>c.\u001D) == null)
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
				func = (\u001F\u0007.<>c.\u001D = new Func<XYZ, bool>(\u001F\u0007.<>c.\u001F.\u0002));
			}
			XYZ xyz = Enumerable.FirstOrDefault<XYZ>(enumerable2, func);
			IList<XYZ> list2 = \u000D\u001D\u0007.\u000A(\u001F);
			List<XYZ> u001F = \u001E\u0009\u0010.\u001F;
			if (\u0008\u0009\u0010.\u001F(\u000A) != null)
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
				u001F = Enumerable.ToList<XYZ>(Enumerable.Cast<Line>(enumerable).\u000A());
			}
			else
			{
				\u000D\u000A u000D_u000A2 = \u001B\u0009\u0010.\u001F(\u000A);
				if (u000D_u000A2 != null)
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
					IEnumerable<Arc> u = u000D_u000A2.\u0004;
					Func<Arc, IEnumerable<XYZ>> func2;
					if ((func2 = \u001F\u0007.<>c.\u0004) == null)
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
						func2 = (\u001F\u0007.<>c.\u0004 = new Func<Arc, IEnumerable<XYZ>>(\u001F\u0007.<>c.\u001F.\u0006));
					}
					u001F = Enumerable.ToList<XYZ>(Enumerable.SelectMany<Arc, XYZ>(u, func2).\u0007().\u000A());
				}
			}
			if (\u000E\u000A.\u000A.\u0019(u001F, Enumerable.First<XYZ>(list2)))
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
				return \u0002\u0007\u0007.\u000A(Enumerable.First<XYZ>(list2), xyz);
			}
			return \u0002\u0007\u0007.\u000A(xyz, Enumerable.Last<XYZ>(list2));
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000EA14 File Offset: 0x0000CC14
		private static List<Line> \u0002(Line \u001F, bool \u000A, XYZ \u0007, IOrderedEnumerable<XYZ> \u001D)
		{
			List<Line> result;
			try
			{
				if (\u0011\u0007\u0007.\u000A(\u0007, Enumerable.First<XYZ>(\u001D), 0.0001))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0007.\u0002(Line, bool, XYZ, IOrderedEnumerable<XYZ>)).MethodHandle;
					}
					if (!\u0011\u0007\u0007.\u000A(\u0007, Enumerable.Last<XYZ>(\u001D), 0.0001))
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
						if (\u000A)
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
							Line u000A = \u0002\u0007\u0007.\u000A(\u0007, Enumerable.First<XYZ>(\u001D)).\u0016(-0.01.\u001F(), -0.01.\u001F());
							List<Line> list = \u0003\u001D\u0007.\u000A();
							\u000B\u0007\u0007.\u000A(list, \u0002\u0007\u0007.\u000A(\u0007, Enumerable.Last<XYZ>(\u001D)));
							\u000B\u0007\u0007.\u000A(list, u000A);
							return list;
						}
						List<Line> list2 = \u0003\u001D\u0007.\u000A();
						\u000B\u0007\u0007.\u000A(list2, \u0002\u0007\u0007.\u000A(\u0007, Enumerable.Last<XYZ>(\u001D)));
						return list2;
					}
				}
				if (\u000A)
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
					Line u000A2 = \u0002\u0007\u0007.\u000A(\u0007, Enumerable.Last<XYZ>(\u001D)).\u0016(-0.01.\u001F(), -0.01.\u001F());
					List<Line> list3 = \u0003\u001D\u0007.\u000A();
					\u000B\u0007\u0007.\u000A(list3, \u0002\u0007\u0007.\u000A(\u0007, Enumerable.First<XYZ>(\u001D)));
					\u000B\u0007\u0007.\u000A(list3, u000A2);
					result = list3;
				}
				else
				{
					List<Line> list4 = \u0003\u001D\u0007.\u000A();
					\u000B\u0007\u0007.\u000A(list4, \u0002\u0007\u0007.\u000A(Enumerable.First<XYZ>(\u001D), \u0007));
					result = list4;
				}
			}
			catch (Exception)
			{
				List<Line> list5 = \u0003\u001D\u0007.\u000A();
				\u000B\u0007\u0007.\u000A(list5, \u001F);
				result = list5;
			}
			return result;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000EBC8 File Offset: 0x0000CDC8
		private static List<Line> \u0006(Line \u001F, bool \u000A, XYZ \u0007, IOrderedEnumerable<XYZ> \u001D)
		{
			List<Line> result;
			try
			{
				if (\u000A)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0007.\u0006(Line, bool, XYZ, IOrderedEnumerable<XYZ>)).MethodHandle;
					}
					Line u000A = \u0002\u0007\u0007.\u000A(\u0007, Enumerable.First<XYZ>(\u001D)).\u0016(-0.01.\u001F(), -0.01.\u001F());
					List<Line> list = \u0003\u001D\u0007.\u000A();
					\u000B\u0007\u0007.\u000A(list, \u0002\u0007\u0007.\u000A(\u0007, Enumerable.Last<XYZ>(\u001D)));
					\u000B\u0007\u0007.\u000A(list, u000A);
					result = list;
				}
				else
				{
					List<Line> list2 = \u0003\u001D\u0007.\u000A();
					\u000B\u0007\u0007.\u000A(list2, \u0002\u0007\u0007.\u000A(\u0007, Enumerable.Last<XYZ>(\u001D)));
					result = list2;
				}
			}
			catch (Exception)
			{
				List<Line> list3 = \u0003\u001D\u0007.\u000A();
				\u000B\u0007\u0007.\u000A(list3, \u001F);
				result = list3;
			}
			return result;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000EC90 File Offset: 0x0000CE90
		private static List<Line> \u000F(Line \u001F, bool \u000A, List<XYZ> \u0007)
		{
			\u001F\u0007.\u0015\u000A u0015_u000A = new \u001F\u0007.\u0015\u000A();
			u0015_u000A.\u001F = \u001F;
			Line u000A2;
			try
			{
				List<double> u001F = Enumerable.ToList<double>(Enumerable.Select<XYZ, double>(\u0007, new Func<XYZ, double>(u0015_u000A.\u000A)));
				double u000A = \u0015\u001D\u0007.\u000A(u001F);
				u000A2 = \u0002\u0007\u0007.\u000A(\u0013\u001F\u0007.\u0007(u0015_u000A.\u001F, 0), \u0016\u000A\u0007.\u000A(\u0007, \u001F\u0004\u0007.\u000A(u001F, u000A)));
			}
			catch (Exception)
			{
				u000A2 = \u0002\u0007\u0007.\u000A(\u0013\u001F\u0007.\u0007(u0015_u000A.\u001F, 0), \u000F\u0007\u0007.\u000A(\u0013\u001F\u0007.\u0007(u0015_u000A.\u001F, 0), \u0009\u0007\u0007.\u000A(0.03, \u001D\u000A\u0007.\u000A(u0015_u000A.\u001F))));
			}
			Line u000A4;
			try
			{
				List<double> u001F2 = Enumerable.ToList<double>(Enumerable.Select<XYZ, double>(\u0007, new Func<XYZ, double>(u0015_u000A.\u0007)));
				double u000A3 = \u0015\u001D\u0007.\u000A(u001F2);
				u000A4 = \u0002\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u0007, \u001F\u0004\u0007.\u000A(u001F2, u000A3)), \u0013\u001F\u0007.\u0007(u0015_u000A.\u001F, 1));
			}
			catch (Exception)
			{
				u000A4 = \u0002\u0007\u0007.\u000A(\u0013\u001F\u0007.\u0007(u0015_u000A.\u001F, 1), \u000F\u0007\u0007.\u000A(\u0013\u001F\u0007.\u0007(u0015_u000A.\u001F, 1), \u0009\u0007\u0007.\u000A(0.03, \u001D\u000A\u0007.\u000A(u0015_u000A.\u001F))));
			}
			if (\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0007.\u000F(Line, bool, List<XYZ>)).MethodHandle;
				}
				Line u000A5 = \u0002\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u0007, 0), \u0016\u000A\u0007.\u000A(\u0007, 1)).\u0016(-0.01.\u001F(), -0.01.\u001F());
				List<Line> list = \u0003\u001D\u0007.\u000A();
				\u000B\u0007\u0007.\u000A(list, u000A2);
				\u000B\u0007\u0007.\u000A(list, u000A5);
				\u000B\u0007\u0007.\u000A(list, u000A4);
				return list;
			}
			List<Line> list2 = \u0003\u001D\u0007.\u000A();
			\u000B\u0007\u0007.\u000A(list2, u000A2);
			\u000B\u0007\u0007.\u000A(list2, u000A4);
			return list2;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000EE8C File Offset: 0x0000D08C
		internal static Line \u0012(this Line \u001F, XYZ \u000A)
		{
			XYZ u000A = \u0013\u001F\u0007.\u0007(\u001F, 0);
			XYZ u001F = \u0013\u001F\u0007.\u0007(\u001F, 1);
			if (!\u0011\u0007\u0007.\u000A(\u001D\u000A\u0007.\u000A(\u001F), \u000A, 0.001))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Line.\u0012(XYZ)).MethodHandle;
				}
				return \u0002\u0007\u0007.\u000A(u001F, u000A);
			}
			return \u001F;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000EEE8 File Offset: 0x0000D0E8
		internal static bool \u0003(this Line \u001F, Line \u000A, List<Line> \u0007)
		{
			\u001F\u0007.\u0001\u000A u0001_u000A = new \u001F\u0007.\u0001\u000A();
			u0001_u000A.\u001F = \u001F;
			u0001_u000A.\u000A = \u000A;
			if (!\u000A\u0004\u0007.\u000A(\u0013\u001F\u0007.\u0007(u0001_u000A.\u001F, 0), \u0013\u001F\u0007.\u0007(u0001_u000A.\u000A, 0)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Line.\u0003(Line, List<Line>)).MethodHandle;
				}
				if (!\u000A\u0004\u0007.\u000A(\u0013\u001F\u0007.\u0007(u0001_u000A.\u001F, 0), \u0013\u001F\u0007.\u0007(u0001_u000A.\u000A, 1)))
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
					if (!\u000A\u0004\u0007.\u000A(\u0013\u001F\u0007.\u0007(u0001_u000A.\u001F, 1), \u0013\u001F\u0007.\u0007(u0001_u000A.\u000A, 0)))
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
						if (!\u000A\u0004\u0007.\u000A(\u0013\u001F\u0007.\u0007(u0001_u000A.\u001F, 1), \u0013\u001F\u0007.\u0007(u0001_u000A.\u000A, 1)))
						{
							return false;
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
			}
			return Enumerable.Any<Line>(\u0007, new Func<Line, bool>(u0001_u000A.\u0007));
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000EFE8 File Offset: 0x0000D1E8
		internal static List<Line> \u001C(this Line \u001F, \u001E\u000A \u000A, bool \u0007 = false)
		{
			\u0011\u000A u0011_u000A = \u0008\u0009\u0010.\u001F(\u000A);
			IEnumerable<Curve> enumerable;
			if (u0011_u000A == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Line.\u001C(\u001E\u000A, bool)).MethodHandle;
				}
				enumerable = Enumerable.Cast<Curve>(\u001B\u0009\u0010.\u001F(\u000A).\u0004);
			}
			else
			{
				enumerable = Enumerable.Cast<Curve>(u0011_u000A.\u0006);
			}
			IEnumerable<Curve> u001F = enumerable;
			List<XYZ> list = u001F.\u0019(\u001F, false);
			if (\u000F\u000A\u0007.\u000A(list) == 2)
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
				return \u001F\u0007.\u000F(\u001F, \u0007, list);
			}
			if (\u000F\u000A\u0007.\u000A(list) != 1)
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
				List<Line> list2 = \u0003\u001D\u0007.\u000A();
				\u000B\u0007\u0007.\u000A(list2, \u001F);
				return list2;
			}
			IEnumerable<XYZ> enumerable2 = list;
			Func<XYZ, bool> func;
			if ((func = \u001F\u0007.<>c.\u0019) == null)
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
				func = (\u001F\u0007.<>c.\u0019 = new Func<XYZ, bool>(\u001F\u0007.<>c.\u001F.\u000F));
			}
			XYZ u = Enumerable.FirstOrDefault<XYZ>(enumerable2, func);
			IEnumerable<XYZ> enumerable3 = \u000D\u001D\u0007.\u000A(\u001F);
			Func<XYZ, double> func2;
			if ((func2 = \u001F\u0007.<>c.\u0018) == null)
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
				func2 = (\u001F\u0007.<>c.\u0018 = new Func<XYZ, double>(\u001F\u0007.<>c.\u001F.\u0012));
			}
			IOrderedEnumerable<XYZ> orderedEnumerable = Enumerable.OrderBy<XYZ, double>(enumerable3, func2);
			List<XYZ> u001F2 = Enumerable.ToList<XYZ>(u001F.\u0007());
			if (\u000E\u000A.\u000A.\u0019(u001F2, Enumerable.First<XYZ>(orderedEnumerable)))
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
				return \u001F\u0007.\u0006(\u001F, \u0007, u, orderedEnumerable);
			}
			return \u001F\u0007.\u0002(\u001F, \u0007, u, orderedEnumerable);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000F148 File Offset: 0x0000D348
		internal static List<Line> \u001C(this Line \u001F, IEnumerable<\u001E\u000A> \u000A, bool \u0007 = false, List<Line> \u001D = null)
		{
			\u001F\u0007.\u0009\u000A u0009_u000A = new \u001F\u0007.\u0009\u000A();
			u0009_u000A.\u001F = \u001F;
			if (\u001D == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Line.\u001C(IEnumerable<\u001E\u000A>, bool, List<Line>)).MethodHandle;
				}
				\u001D = \u0003\u001D\u0007.\u000A();
			}
			if (!Enumerable.Any<\u001E\u000A>(\u000A))
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
				\u000B\u0007\u0007.\u000A(\u001D, u0009_u000A.\u001F);
				return \u001D;
			}
			\u000A = Enumerable.OrderBy<\u001E\u000A, double>(\u000A, new Func<\u001E\u000A, double>(u0009_u000A.\u000A));
			int num = 1;
			IEnumerator<\u001E\u000A> enumerator = \u0004\u0004\u0007.\u000A(\u000A);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u001E\u000A u000A = \u001D\u0004\u0007.\u000A(enumerator);
					List<Line> list = u0009_u000A.\u001F.\u001C(u000A, \u0007);
					u0009_u000A.\u001F = Enumerable.Last<Line>(list);
					if (num != Enumerable.Count<\u001E\u000A>(\u000A))
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
						\u0007\u0004\u0007.\u000A(list, Enumerable.Last<Line>(list));
					}
					\u0002\u001D\u0007.\u000A(\u001D, list);
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return \u001D;
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000F264 File Offset: 0x0000D464
		internal static bool \u000D(this Line \u001F, Line \u000A)
		{
			XYZ xyz = \u0013\u001F\u0007.\u0007(\u001F, 0);
			XYZ xyz2 = \u0013\u001F\u0007.\u0007(\u001F, 1);
			XYZ xyz3 = \u0013\u001F\u0007.\u0007(\u000A, 0);
			XYZ xyz4 = \u0013\u001F\u0007.\u0007(\u000A, 1);
			int num = \u001F\u0007.\u000E(xyz, xyz2, xyz3);
			int num2 = \u001F\u0007.\u000E(xyz, xyz2, xyz4);
			int num3 = \u001F\u0007.\u000E(xyz3, xyz4, xyz);
			int num4 = \u001F\u0007.\u000E(xyz3, xyz4, xyz2);
			if (num != num2)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Line.\u000D(Line)).MethodHandle;
				}
				if (num3 != num4)
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
					return true;
				}
			}
			if (num == 0)
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
				if (\u001F\u0007.\u0010(xyz, xyz3, xyz2))
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
					return true;
				}
			}
			if (num2 == 0)
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
				if (\u001F\u0007.\u0010(xyz, xyz4, xyz2))
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
			}
			if (num3 == 0)
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
				if (\u001F\u0007.\u0010(xyz3, xyz, xyz4))
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
					return true;
				}
			}
			if (num4 == 0)
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
				if (\u001F\u0007.\u0010(xyz3, xyz2, xyz4))
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
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000F390 File Offset: 0x0000D590
		private static bool \u0010(XYZ \u001F, XYZ \u000A, XYZ \u0007)
		{
			if (\u000D\u001F\u0007.\u000A(\u000A) <= \u0018\u0004\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F), \u000D\u001F\u0007.\u000A(\u0007)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0007.\u0010(XYZ, XYZ, XYZ)).MethodHandle;
				}
				if (\u000D\u001F\u0007.\u000A(\u000A) >= \u0019\u0004\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F), \u000D\u001F\u0007.\u000A(\u0007)))
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
					if (\u001C\u001F\u0007.\u000A(\u000A) <= \u0018\u0004\u0007.\u000A(\u001C\u001F\u0007.\u000A(\u001F), \u001C\u001F\u0007.\u000A(\u0007)))
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
						if (\u001C\u001F\u0007.\u000A(\u000A) >= \u0019\u0004\u0007.\u000A(\u001C\u001F\u0007.\u000A(\u001F), \u001C\u001F\u0007.\u000A(\u0007)))
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
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000F458 File Offset: 0x0000D658
		private static int \u000E(XYZ \u001F, XYZ \u000A, XYZ \u0007)
		{
			double num = (\u001C\u001F\u0007.\u000A(\u000A) - \u001C\u001F\u0007.\u000A(\u001F)) * (\u000D\u001F\u0007.\u000A(\u0007) - \u000D\u001F\u0007.\u000A(\u000A)) - (\u000D\u001F\u0007.\u000A(\u000A) - \u000D\u001F\u0007.\u000A(\u001F)) * (\u001C\u001F\u0007.\u000A(\u0007) - \u001C\u001F\u0007.\u000A(\u000A));
			if (num == 0.0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0007.\u000E(XYZ, XYZ, XYZ)).MethodHandle;
				}
				return 0;
			}
			if (num <= 0.0)
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
				return 2;
			}
			return 1;
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000F4E8 File Offset: 0x0000D6E8
		internal static bool \u0008(this Line \u001F, Line \u000A)
		{
			if (!\u000A\u0004\u0007.\u000A(\u0007\u000A\u0007.\u000A(\u001D\u000A\u0007.\u000A(\u001F)), \u0007\u000A\u0007.\u000A(\u001D\u000A\u0007.\u000A(\u000A))))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Line.\u0008(Line)).MethodHandle;
				}
				return \u000A\u0004\u0007.\u000A(\u0007\u000A\u0007.\u000A(\u001D\u000A\u0007.\u000A(\u001F)), \u0005\u0004\u0007.\u000A(\u0007\u000A\u0007.\u000A(\u001D\u000A\u0007.\u000A(\u000A))));
			}
			return true;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000F560 File Offset: 0x0000D760
		internal static XYZ \u001B(this Line \u001F, List<Line> \u000A)
		{
			XYZ xyz = \u001B\u001F\u0007.\u000A(-\u001C\u001F\u0007.\u000A(\u001D\u000A\u0007.\u000A(\u001F)), \u000D\u001F\u0007.\u000A(\u001D\u000A\u0007.\u000A(\u001F)), 0.0);
			if (\u001F\u0007.\u0011(\u000A, \u001F, xyz))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Line.\u001B(List<Line>)).MethodHandle;
				}
				xyz = \u001B\u001F\u0007.\u000A(\u001C\u001F\u0007.\u000A(\u001D\u000A\u0007.\u000A(\u001F)), -\u000D\u001F\u0007.\u000A(\u001D\u000A\u0007.\u000A(\u001F)), 0.0);
			}
			return xyz;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000F5F0 File Offset: 0x0000D7F0
		private static bool \u0011(List<Line> \u001F, Line \u000A, XYZ \u0007)
		{
			Func<Line, double> func;
			if ((func = \u001F\u0007.<>c.\u0005) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0007.\u0011(List<Line>, Line, XYZ)).MethodHandle;
				}
				func = (\u001F\u0007.<>c.\u0005 = new Func<Line, double>(\u001F\u0007.<>c.\u001F.\u0003));
			}
			double num = Enumerable.Max<Line>(\u001F, func);
			XYZ xyz = \u000A.\u0007();
			XYZ u001F = xyz;
			XYZ u000A = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(xyz) + \u000D\u001F\u0007.\u000A(\u0007) * 10.0 * num, \u001C\u001F\u0007.\u000A(xyz) + \u001C\u001F\u0007.\u000A(\u0007) * 10.0 * num, 0.0);
			int num2 = 0;
			List<Line>.Enumerator enumerator = \u0012\u001D\u0007.\u000A(\u001F);
			try
			{
				while (\u000B\u001D\u0007.\u000A(ref enumerator))
				{
					Line u001F2 = \u000F\u001D\u0007.\u000A(ref enumerator);
					XYZ xyz2 = \u0013\u001F\u0007.\u0007(u001F2, 0);
					XYZ xyz3 = \u0013\u001F\u0007.\u0007(u001F2, 1);
					XYZ u001F3 = \u0013\u001F\u0007.\u0007(\u000A, 0);
					XYZ u000A2 = \u0013\u001F\u0007.\u0007(\u000A, 1);
					\u0002\u000A u0002_u000A = new \u0002\u000A(xyz2, xyz3, false);
					\u0002\u000A u0002_u000A2 = new \u0002\u000A(u001F3, u000A2, false);
					if (u0002_u000A.\u0016(u0002_u000A2, 0.0001))
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
						if (\u0002\u000A.\u0003(u0002_u000A, u0002_u000A2) < 1E-05)
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
					}
					if (\u001F\u0007.\u001E(u001F, u000A, xyz2, xyz3))
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
						num2++;
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
			return num2 % 2 == 1;
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000F788 File Offset: 0x0000D988
		private static bool \u001E(XYZ \u001F, XYZ \u000A, XYZ \u0007, XYZ \u001D)
		{
			XYZ xyz = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u000A) - \u000D\u001F\u0007.\u000A(\u001F), \u001C\u001F\u0007.\u000A(\u000A) - \u001C\u001F\u0007.\u000A(\u001F), 0.0);
			XYZ u000A = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001D) - \u000D\u001F\u0007.\u000A(\u0007), \u001C\u001F\u0007.\u000A(\u001D) - \u001C\u001F\u0007.\u000A(\u0007), 0.0);
			double num = \u001F\u0007.\u0020(xyz, u000A);
			if (\u0008\u001F\u0007.\u000A(num) < 1E-05)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0007.\u001E(XYZ, XYZ, XYZ, XYZ)).MethodHandle;
				}
				return false;
			}
			XYZ u001F = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0007) - \u000D\u001F\u0007.\u000A(\u001F), \u001C\u001F\u0007.\u000A(\u0007) - \u001C\u001F\u0007.\u000A(\u001F), 0.0);
			double num2 = \u001F\u0007.\u0020(u001F, u000A) / num;
			double num3 = \u001F\u0007.\u0020(u001F, xyz) / num;
			if (0.0 <= num2)
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
				if (num2 <= 1.00001)
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
					if (0.0 <= num3)
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
						return num3 <= 1.00001;
					}
				}
			}
			return false;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000F8CC File Offset: 0x0000DACC
		private static double \u0020(XYZ \u001F, XYZ \u000A)
		{
			return \u000D\u001F\u0007.\u000A(\u001F) * \u001C\u001F\u0007.\u000A(\u000A) - \u001C\u001F\u0007.\u000A(\u001F) * \u000D\u001F\u0007.\u000A(\u000A);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000F8FC File Offset: 0x0000DAFC
		internal static bool \u0017(this Line \u001F, Line \u000A)
		{
			if (\u0006\u0007\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0), \u0013\u001F\u0007.\u0007(\u000A, 0)) >= 0.01)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Line.\u0017(Line)).MethodHandle;
				}
				if (\u0006\u0007\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0), \u0013\u001F\u0007.\u0007(\u000A, 1)) >= 0.01)
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
					if (\u0006\u0007\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1), \u0013\u001F\u0007.\u0007(\u000A, 0)) >= 0.01)
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
						if (\u0006\u0007\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1), \u0013\u001F\u0007.\u0007(\u000A, 1)) >= 0.01)
						{
							return false;
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
				}
			}
			return true;
		}

		// Token: 0x0200077C RID: 1916
		[CompilerGenerated]
		private sealed class \u0015\u000A
		{
			// Token: 0x06004AF9 RID: 19193 RVA: 0x001D8180 File Offset: 0x001D6380
			internal double \u000A(XYZ \u001F)
			{
				return \u0006\u0007\u0007.\u000A(\u001F, \u0013\u001F\u0007.\u0007(this.\u001F, 0));
			}

			// Token: 0x06004AFA RID: 19194 RVA: 0x001D81A4 File Offset: 0x001D63A4
			internal double \u0007(XYZ \u001F)
			{
				return \u0006\u0007\u0007.\u000A(\u001F, \u0013\u001F\u0007.\u0007(this.\u001F, 1));
			}

			// Token: 0x04001E26 RID: 7718
			public Line \u001F;
		}

		// Token: 0x0200077D RID: 1917
		[CompilerGenerated]
		private sealed class \u0001\u000A
		{
			// Token: 0x06004AFC RID: 19196 RVA: 0x001D81DC File Offset: 0x001D63DC
			internal bool \u0007(Line \u001F)
			{
				if (!\u000A\u0004\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0), \u0013\u001F\u0007.\u0007(this.\u001F, 0)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0007.\u0001\u000A.\u0007(Line)).MethodHandle;
					}
					if (!\u000A\u0004\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0), \u0013\u001F\u0007.\u0007(this.\u001F, 1)))
					{
						goto IL_B7;
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
				if (!\u000A\u0004\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1), \u0013\u001F\u0007.\u0007(this.\u000A, 0)))
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
					if (!\u000A\u0004\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1), \u0013\u001F\u0007.\u0007(this.\u000A, 1)))
					{
						for (;;)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							goto IL_B7;
						}
					}
				}
				return true;
				IL_B7:
				if (!\u000A\u0004\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1), \u0013\u001F\u0007.\u0007(this.\u001F, 0)))
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
					if (!\u000A\u0004\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1), \u0013\u001F\u0007.\u0007(this.\u001F, 1)))
					{
						return false;
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
				if (!\u000A\u0004\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0), \u0013\u001F\u0007.\u0007(this.\u000A, 0)))
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
					return \u000A\u0004\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0), \u0013\u001F\u0007.\u0007(this.\u000A, 1));
				}
				return true;
			}

			// Token: 0x04001E27 RID: 7719
			public Line \u001F;

			// Token: 0x04001E28 RID: 7720
			public Line \u000A;
		}

		// Token: 0x0200077E RID: 1918
		[CompilerGenerated]
		private sealed class \u0009\u000A
		{
			// Token: 0x06004AFE RID: 19198 RVA: 0x001D8358 File Offset: 0x001D6558
			internal double \u000A(\u001E\u000A \u001F)
			{
				return \u0006\u0007\u0007.\u000A(Enumerable.First<XYZ>(\u001F.\u0010), \u0013\u001F\u0007.\u0007(this.\u001F, 0));
			}

			// Token: 0x04001E29 RID: 7721
			public Line \u001F;
		}
	}
}

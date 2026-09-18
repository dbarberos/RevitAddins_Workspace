using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Revit.Extensions;
using DiRoots.RoomPro.Models;
using DiRoots.SpatialElementViews.Enums;
using DiRoots.SpatialElementViews.Models;

namespace A
{
	// Token: 0x02000051 RID: 81
	internal static class \u0012\u0007
	{
		// Token: 0x060002A5 RID: 677 RVA: 0x0000FA38 File Offset: 0x0000DC38
		internal static XYZ \u000A(this SpatialElement \u001F, View \u000A)
		{
			BoundingBoxXYZ u001F = \u0002\u0004\u0007.\u000A(\u001F, \u000A);
			XYZ u001F2 = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(u001F)), \u001C\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(u001F)), \u0003\u000A\u0007.\u000A(\u000B\u0004\u0007.\u000A(u001F)));
			XYZ u001F3 = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F)), \u001C\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F)), \u0003\u000A\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F)));
			XYZ u001F4 = \u001B\u001F\u0007.\u000A((\u000D\u001F\u0007.\u000A(u001F2) + \u000D\u001F\u0007.\u000A(u001F3)) / 2.0, (\u001C\u001F\u0007.\u000A(u001F2) + \u001C\u001F\u0007.\u000A(u001F3)) / 2.0, (\u0003\u000A\u0007.\u000A(u001F2) + \u0003\u000A\u0007.\u000A(u001F3)) / 2.0);
			return \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F4), \u001C\u001F\u0007.\u000A(u001F4), \u0003\u000A\u0007.\u000A(u001F2));
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000FB34 File Offset: 0x0000DD34
		internal static List<XYZ> \u0007(this SpatialElement \u001F, View \u000A)
		{
			XYZ u001F = \u001F.\u000A(\u000A);
			List<Line> list = \u001F.\u000F(1, \u000C\u0009\u0010.\u001F);
			Func<Line, bool> func;
			if ((func = \u0012\u0007.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElement.\u0007(View)).MethodHandle;
				}
				func = (\u0012\u0007.<>c.\u000A = new Func<Line, bool>(\u0012\u0007.<>c.\u001F.\u0014\u000A));
			}
			IEnumerable<Line> enumerable = Enumerable.Where<Line>(list, func);
			Func<Line, double> func2;
			if ((func2 = \u0012\u0007.<>c.\u0007) == null)
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
				func2 = (\u0012\u0007.<>c.\u0007 = new Func<Line, double>(\u0012\u0007.<>c.\u001F.\u0013\u000A));
			}
			List<Line> list2 = Enumerable.ToList<Line>(Enumerable.OrderByDescending<Line, double>(enumerable, func2));
			Func<Line, bool> func3;
			if ((func3 = \u0012\u0007.<>c.\u001D) == null)
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
				func3 = (\u0012\u0007.<>c.\u001D = new Func<Line, bool>(\u0012\u0007.<>c.\u001F.\u001A\u000A));
			}
			IEnumerable<Line> enumerable2 = Enumerable.Where<Line>(list, func3);
			Func<Line, double> func4;
			if ((func4 = \u0012\u0007.<>c.\u0004) == null)
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
				func4 = (\u0012\u0007.<>c.\u0004 = new Func<Line, double>(\u0012\u0007.<>c.\u001F.\u000C\u000A));
			}
			List<Line> list3 = Enumerable.ToList<Line>(Enumerable.OrderByDescending<Line, double>(enumerable2, func4));
			Line line = Enumerable.FirstOrDefault<Line>(list2);
			double? num;
			double? num2;
			if (line == null)
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
				\u0015\u0009\u0010.\u001F(ref num);
				num2 = num;
			}
			else
			{
				num2 = new double?(\u001C\u001F\u0007.\u000A(\u0013\u001F\u0007.\u001D(line, 0)));
			}
			double? num3 = num2;
			Line line2 = Enumerable.LastOrDefault<Line>(list2);
			double? num4;
			if (line2 == null)
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
				\u0015\u0009\u0010.\u001F(ref num);
				num4 = num;
			}
			else
			{
				num4 = new double?(\u001C\u001F\u0007.\u000A(\u0013\u001F\u0007.\u001D(line2, 0)));
			}
			double? num5 = num4;
			double? num6;
			if (!(\u0010\u0004\u0007.\u000A(ref num3) & \u0010\u0004\u0007.\u000A(ref num5)))
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
				\u0015\u0009\u0010.\u001F(ref num);
				num6 = num;
			}
			else
			{
				num6 = new double?(\u000D\u0004\u0007.\u000A(ref num3) - \u000D\u0004\u0007.\u000A(ref num5));
			}
			double? num7 = num6;
			double u001F2 = \u000D\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(Enumerable.FirstOrDefault<Line>(list3), 0)) - \u000D\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(Enumerable.LastOrDefault<Line>(list3), 0));
			Line u001F3 = \u0012\u0007.\u000E(u001F2, list2);
			Line u001F4 = \u0012\u0007.\u000E(u001F2, Enumerable.ToList<Line>(Enumerable.Reverse<Line>(list2)));
			Line u001F5 = \u0012\u0007.\u000E(\u001C\u0004\u0007.\u000A(ref num7), list3);
			Line u001F6 = \u0012\u0007.\u000E(\u001C\u0004\u0007.\u000A(ref num7), Enumerable.ToList<Line>(Enumerable.Reverse<Line>(list3)));
			\u0003\u000A u0003_u000A = new \u0003\u000A();
			\u0003\u0004\u0007.\u000A(u0003_u000A, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F), \u001C\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(u001F3, 0)), \u0003\u000A\u0007.\u000A(u001F)));
			\u0012\u0004\u0007.\u000A(u0003_u000A, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F), \u001C\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(u001F4, 0)), \u0003\u000A\u0007.\u000A(u001F)));
			\u000F\u0004\u0007.\u000A(u0003_u000A, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(u001F5, 0)), \u001C\u001F\u0007.\u000A(u001F), \u0003\u000A\u0007.\u000A(u001F)));
			\u0006\u0004\u0007.\u000A(u0003_u000A, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(u001F6, 0)), \u001C\u001F\u0007.\u000A(u001F), \u0003\u000A\u0007.\u000A(u001F)));
			return u0003_u000A.\u0004();
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000FE30 File Offset: 0x0000E030
		internal static List<XYZ> \u0007(this SpatialElement \u001F, XYZ \u000A)
		{
			List<Line> list = \u001F.\u000F(1, \u000C\u0009\u0010.\u001F);
			Func<Line, bool> func;
			if ((func = \u0012\u0007.<>c.\u0019) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElement.\u0007(XYZ)).MethodHandle;
				}
				func = (\u0012\u0007.<>c.\u0019 = new Func<Line, bool>(\u0012\u0007.<>c.\u001F.\u0015\u000A));
			}
			IEnumerable<Line> enumerable = Enumerable.Where<Line>(list, func);
			Func<Line, double> func2;
			if ((func2 = \u0012\u0007.<>c.\u0018) == null)
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
				func2 = (\u0012\u0007.<>c.\u0018 = new Func<Line, double>(\u0012\u0007.<>c.\u001F.\u0001\u000A));
			}
			List<Line> list2 = Enumerable.ToList<Line>(Enumerable.OrderByDescending<Line, double>(enumerable, func2));
			Func<Line, bool> func3;
			if ((func3 = \u0012\u0007.<>c.\u0005) == null)
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
				func3 = (\u0012\u0007.<>c.\u0005 = new Func<Line, bool>(\u0012\u0007.<>c.\u001F.\u0009\u000A));
			}
			IEnumerable<Line> enumerable2 = Enumerable.Where<Line>(list, func3);
			Func<Line, double> func4;
			if ((func4 = \u0012\u0007.<>c.\u0016) == null)
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
				func4 = (\u0012\u0007.<>c.\u0016 = new Func<Line, double>(\u0012\u0007.<>c.\u001F.\u001F\u0007));
			}
			List<Line> list3 = Enumerable.ToList<Line>(Enumerable.OrderByDescending<Line, double>(enumerable2, func4));
			double? num;
			double? num2;
			if (list2 == null)
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
				\u0015\u0009\u0010.\u001F(ref num);
				num2 = num;
			}
			else
			{
				num2 = new double?(\u001C\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(Enumerable.FirstOrDefault<Line>(list2), 0)));
			}
			double? num3 = num2;
			double num4 = \u001C\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(Enumerable.LastOrDefault<Line>(list2), 0));
			double? num5;
			if (!\u0010\u0004\u0007.\u000A(ref num3))
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
				\u0015\u0009\u0010.\u001F(ref num);
				num5 = num;
			}
			else
			{
				num5 = new double?(\u000D\u0004\u0007.\u000A(ref num3) - num4);
			}
			double? num6 = num5;
			double u001F = \u000D\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(Enumerable.FirstOrDefault<Line>(list3), 0)) - \u000D\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(Enumerable.LastOrDefault<Line>(list3), 0));
			Line u001F2 = \u0012\u0007.\u000E(u001F, list2);
			Line u001F3 = \u0012\u0007.\u000E(u001F, Enumerable.ToList<Line>(Enumerable.Reverse<Line>(list2)));
			Line u001F4 = \u0012\u0007.\u000E(\u001C\u0004\u0007.\u000A(ref num6), list3);
			Line u001F5 = \u0012\u0007.\u000E(\u001C\u0004\u0007.\u000A(ref num6), Enumerable.ToList<Line>(Enumerable.Reverse<Line>(list3)));
			\u0003\u000A u0003_u000A = new \u0003\u000A();
			\u0003\u0004\u0007.\u000A(u0003_u000A, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u000A), \u001C\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(u001F2, 0)), \u0003\u000A\u0007.\u000A(\u000A)));
			\u0012\u0004\u0007.\u000A(u0003_u000A, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u000A), \u001C\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(u001F3, 0)), \u0003\u000A\u0007.\u000A(\u000A)));
			\u000F\u0004\u0007.\u000A(u0003_u000A, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(u001F4, 0)), \u001C\u001F\u0007.\u000A(\u000A), \u0003\u000A\u0007.\u000A(\u000A)));
			\u0006\u0004\u0007.\u000A(u0003_u000A, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(u001F5, 0)), \u001C\u001F\u0007.\u000A(\u000A), \u0003\u000A\u0007.\u000A(\u000A)));
			return u0003_u000A.\u0004();
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x000100F0 File Offset: 0x0000E2F0
		internal static IEnumerable<ViewSection> \u001D(this SpatialElement \u001F, ViewsCreationHandler \u000A, Document \u0007, SectionData \u001D, ElementId \u0004, Action \u0019 = null)
		{
			\u0012\u0007.\u0006\u0007 u0006_u = new \u0012\u0007.\u0006\u0007(-2);
			u0006_u.\u0002 = \u001F;
			u0006_u.\u0016 = \u000A;
			u0006_u.\u0018 = \u0007;
			u0006_u.\u0004 = \u001D;
			u0006_u.\u000F = \u0004;
			return u0006_u;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00010128 File Offset: 0x0000E328
		internal static IEnumerable<ViewSection> \u0004(this SpatialElement \u001F, ViewsCreationHandler \u000A, Document \u0007, SectionData \u001D, ElementId \u0004, bool \u0019 = true)
		{
			\u0012\u0007.\u0002\u0007 u0002_u = new \u0012\u0007.\u0002\u0007(-2);
			u0002_u.\u0012 = \u001F;
			u0002_u.\u0006 = \u000A;
			u0002_u.\u0004 = \u0007;
			u0002_u.\u0018 = \u001D;
			u0002_u.\u001C = \u0004;
			u0002_u.\u000B = \u0019;
			return u0002_u;
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00010168 File Offset: 0x0000E368
		internal static IEnumerable<ViewSection> \u0019(this SpatialElement \u001F, ViewsCreationHandler \u000A, Document \u0007, SectionData \u001D, bool \u0004 = true)
		{
			\u0012\u0007.\u000F\u0007 u000F_u = new \u0012\u0007.\u000F\u0007(-2);
			u000F_u.\u0002 = \u001F;
			u000F_u.\u0016 = \u000A;
			u000F_u.\u000F = \u0007;
			u000F_u.\u0004 = \u001D;
			u000F_u.\u0018 = \u0004;
			return u000F_u;
		}

		// Token: 0x060002AB RID: 683 RVA: 0x000101A0 File Offset: 0x0000E3A0
		internal static List<Boundary> \u0018(this SpatialElement \u001F, Document \u000A, SectionData \u0007, List<BuiltInCategory> \u001D)
		{
			List<Boundary> list = \u000C\u0004\u0007.\u000A(\u0007);
			double u = \u001A\u0004\u0007.\u000A(\u0007);
			double u001F = \u0013\u0004\u0007.\u000A(\u0007);
			bool flag = \u0014\u0004\u0007.\u000A(\u0007);
			SortingDirections u000A = \u0017\u0004\u0007.\u000A(\u0007);
			List<Boundary> list2 = \u0020\u0004\u0007.\u000A();
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElement.\u0018(Document, SectionData, List<BuiltInCategory>)).MethodHandle;
				}
				list = \u0012\u0007.\u0012(list, u000A);
			}
			else
			{
				list = \u0012\u0007.\u0003(list, u000A);
			}
			for (int i = 0; i < \u000E\u0004\u0007.\u000A(list); i++)
			{
				XYZ u001F2 = \u0013\u001F\u0007.\u0007(\u001E\u0004\u0007.\u0007(\u001B\u0004\u0007.\u000A(list, i)), 0);
				XYZ u001F3 = \u0013\u001F\u0007.\u0007(\u001E\u0004\u0007.\u0007(\u001B\u0004\u0007.\u000A(list, i)), 1);
				Line u001F4 = \u0002\u0007\u0007.\u000A(\u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F2), \u001C\u001F\u0007.\u000A(u001F2), \u0003\u000A\u0007.\u000A(u001F3)), \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F3), \u001C\u001F\u0007.\u000A(u001F3), \u0003\u000A\u0007.\u000A(u001F3)));
				IEnumerable<Boundary> enumerable = list;
				Func<Boundary, Line> func;
				if ((func = \u0012\u0007.<>c.\u000B) == null)
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
					func = (\u0012\u0007.<>c.\u000B = new Func<Boundary, Line>(\u0012\u0007.<>c.\u001F.\u000A\u0007));
				}
				XYZ u000A2 = u001F4.\u001B(Enumerable.ToList<Line>(Enumerable.Select<Boundary, Line>(enumerable, func)));
				Line u000A3 = u001F4.\u001D(\u0009\u0007\u0007.\u000A(u001F, u000A2));
				Outline u001F5 = \u0012\u0007.\u0020(\u0012\u0007.\u0006(u001F4, u000A3, u));
				ElementMulticategoryFilter u000A4 = \u0011\u0004\u0007.\u000A(\u001D);
				if (Enumerable.Any<Element>(Enumerable.ToList<Element>(\u0009\u001E\u000A.\u001D(\u0014\u0011\u000A.\u0007(\u0014\u0011\u000A.\u001D(\u0020\u0011\u000A.\u000A(\u000A), \u0012\u0007.\u001E(u001F5)), u000A4)))))
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
					\u0008\u0004\u0007.\u000A(list2, \u001B\u0004\u0007.\u000A(list, i));
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
			return list2;
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00010380 File Offset: 0x0000E580
		internal static List<Boundary> \u0005(this SpatialElement \u001F, double \u000A, SpatialElementBoundaryLocation \u0007 = 1, Transform \u001D = null)
		{
			\u0012\u0007.\u000B\u0007 u000B_u = new \u0012\u0007.\u000B\u0007();
			u000B_u.\u000A = \u000A;
			if (u000B_u.\u000A == 0.0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElement.\u0005(double, SpatialElementBoundaryLocation, Transform)).MethodHandle;
				}
				u000B_u.\u000A = 0.0328084;
			}
			List<Tuple<Line, double>> u001F = \u000B\u0019\u0007.\u000A();
			List<Boundary> list = \u0020\u0004\u0007.\u000A();
			u000B_u.\u001F = \u001F.\u000F(\u0007, \u001D);
			IEnumerable<Line> u001F2 = u000B_u.\u001F;
			Func<Line, \u0006\u000A> func;
			if ((func = \u0012\u0007.<>c.\u0002) == null)
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
				func = (\u0012\u0007.<>c.\u0002 = new Func<Line, \u0006\u000A>(\u0012\u0007.<>c.\u001F.\u0007\u0007));
			}
			IEnumerable<\u0006\u000A> enumerable = Enumerable.ToList<\u0006\u000A>(Enumerable.Select<Line, \u0006\u000A>(u001F2, func));
			Func<\u0006\u000A, double> func2;
			if ((func2 = \u0012\u0007.<>c.\u0006) == null)
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
				func2 = (\u0012\u0007.<>c.\u0006 = new Func<\u0006\u000A, double>(\u0012\u0007.<>c.\u001F.\u001D\u0007));
			}
			object u001F3 = Enumerable.ToList<IGrouping<double, \u0006\u000A>>(Enumerable.GroupBy<\u0006\u000A, double>(enumerable, func2));
			List<Tuple<XYZ, List<Line>>> list2 = \u0016\u0019\u0007.\u000A();
			List<IGrouping<double, \u0006\u000A>>.Enumerator enumerator = \u0005\u0019\u0007.\u000A(u001F3);
			try
			{
				while (\u0019\u0019\u0007.\u000A(ref enumerator))
				{
					IEnumerable<\u0006\u000A> enumerable2 = \u0018\u0019\u0007.\u000A(ref enumerator);
					Func<\u0006\u000A, \u0006\u000A> func3;
					if ((func3 = \u0012\u0007.<>c.\u000F) == null)
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
						func3 = (\u0012\u0007.<>c.\u000F = new Func<\u0006\u000A, \u0006\u000A>(\u0012\u0007.<>c.\u001F.\u0004\u0007));
					}
					IEnumerable<\u0006\u000A> enumerable3 = Enumerable.Select<\u0006\u000A, \u0006\u000A>(enumerable2, func3);
					Func<\u0006\u000A, double> func4;
					if ((func4 = \u0012\u0007.<>c.\u0012) == null)
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
						func4 = (\u0012\u0007.<>c.\u0012 = new Func<\u0006\u000A, double>(\u0012\u0007.<>c.\u001F.\u0019\u0007));
					}
					IEnumerable<\u0006\u000A> enumerable4 = Enumerable.ToList<\u0006\u000A>(Enumerable.OrderBy<\u0006\u000A, double>(enumerable3, func4));
					Func<\u0006\u000A, XYZ> func5;
					if ((func5 = u000B_u.\u0007) == null)
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
						func5 = (u000B_u.\u0007 = new Func<\u0006\u000A, XYZ>(u000B_u.\u0004));
					}
					List<IGrouping<XYZ, \u0006\u000A>> u = Enumerable.ToList<IGrouping<XYZ, \u0006\u000A>>(Enumerable.GroupBy<\u0006\u000A, XYZ>(enumerable4, func5, new \u0020\u000A()));
					\u0012\u0007.\u0016(u000B_u.\u000A, list2, u);
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
			List<Tuple<XYZ, List<Line>>>.Enumerator enumerator2 = \u0004\u0019\u0007.\u000A(list2);
			try
			{
				while (\u0015\u0004\u0007.\u000A(ref enumerator2))
				{
					Tuple<XYZ, List<Line>> u001F4 = \u001D\u0019\u0007.\u000A(ref enumerator2);
					IEnumerable<Line> enumerable5 = \u0007\u0019\u0007.\u000A(u001F4);
					Func<Line, \u0006\u000A> func6;
					if ((func6 = \u0012\u0007.<>c.\u0003) == null)
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
						func6 = (\u0012\u0007.<>c.\u0003 = new Func<Line, \u0006\u000A>(\u0012\u0007.<>c.\u001F.\u0018\u0007));
					}
					List<\u0006\u000A> list3 = Enumerable.ToList<\u0006\u000A>(Enumerable.Select<Line, \u0006\u000A>(enumerable5, func6));
					IEnumerable<\u0006\u000A> enumerable6 = list3;
					Func<\u0006\u000A, double> func7;
					if ((func7 = \u0012\u0007.<>c.\u001C) == null)
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
						func7 = (\u0012\u0007.<>c.\u001C = new Func<\u0006\u000A, double>(\u0012\u0007.<>c.\u001F.\u0005\u0007));
					}
					double num = Enumerable.Max<\u0006\u000A>(enumerable6, func7);
					IEnumerable<\u0006\u000A> enumerable7 = list3;
					Func<\u0006\u000A, double> func8;
					if ((func8 = \u0012\u0007.<>c.\u000D) == null)
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
						func8 = (\u0012\u0007.<>c.\u000D = new Func<\u0006\u000A, double>(\u0012\u0007.<>c.\u001F.\u0016\u0007));
					}
					double num2 = num - Enumerable.Min<\u0006\u000A>(enumerable7, func8);
					IEnumerable<Line> enumerable8 = \u0007\u0019\u0007.\u000A(u001F4);
					Func<Line, \u0006\u000A> func9;
					if ((func9 = \u0012\u0007.<>c.\u0010) == null)
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
						func9 = (\u0012\u0007.<>c.\u0010 = new Func<Line, \u0006\u000A>(\u0012\u0007.<>c.\u001F.\u000B\u0007));
					}
					IEnumerable<\u0006\u000A> enumerable9 = Enumerable.Select<Line, \u0006\u000A>(enumerable8, func9);
					IEnumerable<\u0006\u000A> enumerable10;
					if (enumerable9 == null)
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
						enumerable10 = null;
					}
					else
					{
						Func<\u0006\u000A, bool> func10;
						if ((func10 = u000B_u.\u001D) == null)
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
							func10 = (u000B_u.\u001D = new Func<\u0006\u000A, bool>(u000B_u.\u0019));
						}
						IEnumerable<\u0006\u000A> enumerable11 = Enumerable.Where<\u0006\u000A>(enumerable9, func10);
						Func<\u0006\u000A, double> func11;
						if ((func11 = \u0012\u0007.<>c.\u000E) == null)
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
							func11 = (\u0012\u0007.<>c.\u000E = new Func<\u0006\u000A, double>(\u0012\u0007.<>c.\u001F.\u0002\u0007));
						}
						enumerable10 = Enumerable.ToList<\u0006\u000A>(Enumerable.OrderBy<\u0006\u000A, double>(enumerable11, func11));
					}
					if (Enumerable.Any<\u0006\u000A>(enumerable10))
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
						IEnumerable<Line> enumerable12 = \u0007\u0019\u0007.\u000A(u001F4);
						Func<Line, \u0006\u000A> func12;
						if ((func12 = \u0012\u0007.<>c.\u0008) == null)
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
							func12 = (\u0012\u0007.<>c.\u0008 = new Func<Line, \u0006\u000A>(\u0012\u0007.<>c.\u001F.\u0006\u0007));
						}
						Line line = \u0012\u0007.\u001C(Enumerable.ToList<\u0006\u000A>(Enumerable.Select<Line, \u0006\u000A>(enumerable12, func12)), \u001F\u0019\u0007.\u000A(u001F4));
						\u000A\u0019\u0007.\u000A(u001F, Tuple.Create<Line, double>(line, num2));
						Boundary boundary = \u0009\u0004\u0007.\u000A(line, num2, \u001F\u0019\u0007.\u000A(u001F4));
						if (\u0001\u0004\u0007.\u000A(\u001E\u0004\u0007.\u0007(boundary)) > u000B_u.\u000A)
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
							\u0008\u0004\u0007.\u000A(list, boundary);
						}
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
				((IDisposable)enumerator2).Dispose();
			}
			return list;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000107EC File Offset: 0x0000E9EC
		private static void \u0016(double \u001F, List<Tuple<XYZ, List<Line>>> \u000A, List<IGrouping<XYZ, \u0006\u000A>> \u0007)
		{
			List<IGrouping<XYZ, \u0006\u000A>>.Enumerator enumerator = \u000D\u0019\u0007.\u000A(\u0007);
			try
			{
				while (\u0002\u0019\u0007.\u000A(ref enumerator))
				{
					IGrouping<XYZ, \u0006\u000A> grouping = \u001C\u0019\u0007.\u000A(ref enumerator);
					if (Enumerable.Count<\u0006\u000A>(grouping) == 1)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u0007.\u0016(double, List<Tuple<XYZ, List<Line>>>, List<IGrouping<XYZ, \u0006\u000A>>)).MethodHandle;
						}
						XYZ item = \u000F\u0019\u0007.\u000A(grouping);
						IEnumerable<\u0006\u000A> enumerable = grouping;
						Func<\u0006\u000A, Line> func;
						if ((func = \u0012\u0007.<>c.\u001B) == null)
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
							func = (\u0012\u0007.<>c.\u001B = new Func<\u0006\u000A, Line>(\u0012\u0007.<>c.\u001F.\u000F\u0007));
						}
						\u0006\u0019\u0007.\u000A(\u000A, Tuple.Create<XYZ, List<Line>>(item, Enumerable.ToList<Line>(Enumerable.Select<\u0006\u000A, Line>(enumerable, func))));
					}
					else
					{
						List<Line> list = \u0003\u001D\u0007.\u000A();
						IEnumerable<\u0006\u000A> enumerable2 = grouping;
						Func<\u0006\u000A, double> func2;
						if ((func2 = \u0012\u0007.<>c.\u0011) == null)
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
							func2 = (\u0012\u0007.<>c.\u0011 = new Func<\u0006\u000A, double>(\u0012\u0007.<>c.\u001F.\u0012\u0007));
						}
						List<\u0006\u000A> list2 = Enumerable.ToList<\u0006\u000A>(Enumerable.OrderByDescending<\u0006\u000A, double>(enumerable2, func2));
						\u000B\u0007\u0007.\u000A(list, \u0012\u0019\u0007.\u000A(\u0003\u0019\u0007.\u000A(list2, 0)));
						list = \u0012\u0007.\u000B(\u001F, \u000A, grouping, list, list2);
						if (Enumerable.Any<Line>(list))
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
							\u0006\u0019\u0007.\u000A(\u000A, Tuple.Create<XYZ, List<Line>>(\u000F\u0019\u0007.\u000A(grouping), list));
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
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00010954 File Offset: 0x0000EB54
		private static List<Line> \u000B(double \u001F, List<Tuple<XYZ, List<Line>>> \u000A, IGrouping<XYZ, \u0006\u000A> \u0007, List<Line> \u001D, List<\u0006\u000A> \u0004)
		{
			for (int i = 1; i < \u0010\u0019\u0007.\u000A(\u0004); i++)
			{
				if (\u0002\u000A.\u0003(\u0018\u000A\u0007.\u000A(\u0003\u0019\u0007.\u000A(\u0004, i - 1)), \u0018\u000A\u0007.\u000A(\u0003\u0019\u0007.\u000A(\u0004, i))) <= \u001F)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u0007.\u000B(double, List<Tuple<XYZ, List<Line>>>, IGrouping<XYZ, \u0006\u000A>, List<Line>, List<\u0006\u000A>)).MethodHandle;
					}
					\u000B\u0007\u0007.\u000A(\u001D, \u0012\u0019\u0007.\u000A(\u0003\u0019\u0007.\u000A(\u0004, i)));
				}
				else if (Enumerable.Any<Line>(\u001D))
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
					\u0006\u0019\u0007.\u000A(\u000A, Tuple.Create<XYZ, List<Line>>(\u000F\u0019\u0007.\u000A(\u0007), \u001D));
					\u001D = \u0003\u001D\u0007.\u000A();
					\u000B\u0007\u0007.\u000A(\u001D, \u0012\u0019\u0007.\u000A(\u0003\u0019\u0007.\u000A(\u0004, i)));
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
			return \u001D;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00010A2C File Offset: 0x0000EC2C
		internal static Level \u0002(this SpatialElement \u001F, Document \u000A)
		{
			\u0012\u0007.\u0007\u0007 u0007_u = new \u0012\u0007.\u0007\u0007();
			u0007_u.\u001F = \u001F;
			IEnumerable<Level> enumerable = Enumerable.Cast<Level>(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u000A), -2000240L)));
			Level level = \u001A\u0009\u0010.\u001F(\u0011\u0017\u000A.\u0007(\u000A, \u000E\u0019\u0007.\u000A(u0007_u.\u001F)));
			if (level == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElement.\u0002(Document)).MethodHandle;
				}
				level = Enumerable.FirstOrDefault<Level>(enumerable, new Func<Level, bool>(u0007_u.\u000A));
			}
			return level;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00010AB4 File Offset: 0x0000ECB4
		internal static Level \u0002(this SpatialElement \u001F)
		{
			return \u001A\u0009\u0010.\u001F(\u0011\u0017\u000A.\u0007(\u0008\u0019\u0007.\u000A(\u001F), \u000E\u0019\u0007.\u000A(\u001F)));
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00010AE0 File Offset: 0x0000ECE0
		internal static BoundingBoxXYZ \u0006(Line \u001F, Line \u000A, double \u0007)
		{
			XYZ u000A = \u001B\u001F\u0007.\u000A(\u0019\u0004\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0)), \u000D\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u000A, 0))), \u0019\u0004\u0007.\u000A(\u001C\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0)), \u001C\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u000A, 0))), 0.0);
			XYZ u000A2 = \u001B\u001F\u0007.\u000A(\u0018\u0004\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1)), \u000D\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u000A, 1))), \u0018\u0004\u0007.\u000A(\u001C\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1)), \u001C\u001F\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u000A, 1))), \u0007);
			BoundingBoxXYZ boundingBoxXYZ = \u001E\u0019\u0007.\u000A();
			\u0011\u0019\u0007.\u000A(boundingBoxXYZ, u000A);
			\u001B\u0019\u0007.\u000A(boundingBoxXYZ, u000A2);
			return boundingBoxXYZ;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00010BB8 File Offset: 0x0000EDB8
		internal static List<Line> \u000F(this SpatialElement \u001F, SpatialElementBoundaryLocation \u000A = 1, Transform \u0007 = null)
		{
			\u0012\u0007.\u001D\u0007 u001D_u = new \u0012\u0007.\u001D\u0007();
			u001D_u.\u001F = \u0007;
			SpatialElementBoundaryOptions spatialElementBoundaryOptions = \u0013\u0019\u0007.\u000A();
			\u0014\u0019\u0007.\u000A(spatialElementBoundaryOptions, true);
			\u0017\u0019\u0007.\u000A(spatialElementBoundaryOptions, \u000A);
			IEnumerable<IList<BoundarySegment>> enumerable = \u0020\u0019\u0007.\u000A(\u001F, spatialElementBoundaryOptions);
			Func<IList<BoundarySegment>, int> func;
			if ((func = \u0012\u0007.<>c.\u001E) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElement.\u000F(SpatialElementBoundaryLocation, Transform)).MethodHandle;
				}
				func = (\u0012\u0007.<>c.\u001E = new Func<IList<BoundarySegment>, int>(\u0012\u0007.<>c.\u001F.\u0003\u0007));
			}
			IList<BoundarySegment> list = Enumerable.FirstOrDefault<IList<BoundarySegment>>(Enumerable.OrderByDescending<IList<BoundarySegment>, int>(enumerable, func));
			if (list != null)
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
				if (Enumerable.Any<BoundarySegment>(list))
				{
					IEnumerable<BoundarySegment> enumerable2 = list;
					Func<BoundarySegment, Curve> func2;
					if ((func2 = \u0012\u0007.<>c.\u0020) == null)
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
						func2 = (\u0012\u0007.<>c.\u0020 = new Func<BoundarySegment, Curve>(\u0012\u0007.<>c.\u001F.\u001C\u0007));
					}
					IEnumerable<Curve> enumerable3 = Enumerable.Select<BoundarySegment, Curve>(enumerable2, func2);
					Func<Curve, bool> func3;
					if ((func3 = \u0012\u0007.<>c.\u0017) == null)
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
						func3 = (\u0012\u0007.<>c.\u0017 = new Func<Curve, bool>(\u0012\u0007.<>c.\u001F.\u000D\u0007));
					}
					List<XYZ> list2 = Enumerable.Cast<Line>(Enumerable.Where<Curve>(enumerable3, func3)).\u0007();
					if (u001D_u.\u001F != null)
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
						list2 = Enumerable.ToList<XYZ>(Enumerable.Select<XYZ, XYZ>(list2, new Func<XYZ, XYZ>(u001D_u.\u000A)));
					}
					return new \u0011\u000A(\u0012\u000A.\u000A(list2)).\u0006;
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
			return \u0003\u001D\u0007.\u000A();
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00010D10 File Offset: 0x0000EF10
		private static List<Boundary> \u0012(List<Boundary> \u001F, SortingDirections \u000A = SortingDirections.North)
		{
			\u0012\u0007.\u0004\u0007 u0004_u = new \u0012\u0007.\u0004\u0007();
			u0004_u.\u0007 = \u000A;
			\u0012\u0007.\u0004\u0007 u0004_u2 = u0004_u;
			Func<Boundary, double> func;
			if ((func = \u0012\u0007.<>c.\u0014) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u0007.\u0012(List<Boundary>, SortingDirections)).MethodHandle;
				}
				func = (\u0012\u0007.<>c.\u0014 = new Func<Boundary, double>(\u0012\u0007.<>c.\u001F.\u0010\u0007));
			}
			double u001F = Enumerable.Average<Boundary>(\u001F, func);
			Func<Boundary, double> func2;
			if ((func2 = \u0012\u0007.<>c.\u0013) == null)
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
				func2 = (\u0012\u0007.<>c.\u0013 = new Func<Boundary, double>(\u0012\u0007.<>c.\u001F.\u000E\u0007));
			}
			u0004_u2.\u001F = \u001B\u001F\u0007.\u000A(u001F, Enumerable.Average<Boundary>(\u001F, func2), 0.0);
			u0004_u.\u000A = \u000E\u0009\u0010.\u001F;
			switch (u0004_u.\u0007)
			{
			case SortingDirections.North:
			{
				\u0012\u0007.\u0004\u0007 u0004_u3 = u0004_u;
				Func<Boundary, bool> func3;
				if ((func3 = \u0012\u0007.<>c.\u001A) == null)
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
					func3 = (\u0012\u0007.<>c.\u001A = new Func<Boundary, bool>(\u0012\u0007.<>c.\u001F.\u0008\u0007));
				}
				IEnumerable<Boundary> enumerable = Enumerable.Where<Boundary>(\u001F, func3);
				Func<Boundary, double> func4;
				if ((func4 = \u0012\u0007.<>c.\u000C) == null)
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
					func4 = (\u0012\u0007.<>c.\u000C = new Func<Boundary, double>(\u0012\u0007.<>c.\u001F.\u001B\u0007));
				}
				Boundary boundary = Enumerable.FirstOrDefault<Boundary>(Enumerable.OrderByDescending<Boundary, double>(enumerable, func4));
				Line u000A;
				if (boundary == null)
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
					u000A = \u000E\u0009\u0010.\u001F;
				}
				else
				{
					u000A = \u001E\u0004\u0007.\u001D(boundary);
				}
				u0004_u3.\u000A = u000A;
				break;
			}
			case SortingDirections.East:
			{
				\u0012\u0007.\u0004\u0007 u0004_u4 = u0004_u;
				Func<Boundary, bool> func5;
				if ((func5 = \u0012\u0007.<>c.\u0015) == null)
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
					func5 = (\u0012\u0007.<>c.\u0015 = new Func<Boundary, bool>(\u0012\u0007.<>c.\u001F.\u0011\u0007));
				}
				IEnumerable<Boundary> enumerable2 = Enumerable.Where<Boundary>(\u001F, func5);
				Func<Boundary, double> func6;
				if ((func6 = \u0012\u0007.<>c.\u0001) == null)
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
					func6 = (\u0012\u0007.<>c.\u0001 = new Func<Boundary, double>(\u0012\u0007.<>c.\u001F.\u001E\u0007));
				}
				Boundary boundary2 = Enumerable.FirstOrDefault<Boundary>(Enumerable.OrderByDescending<Boundary, double>(enumerable2, func6));
				Line u000A2;
				if (boundary2 == null)
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
					u000A2 = \u000E\u0009\u0010.\u001F;
				}
				else
				{
					u000A2 = \u001E\u0004\u0007.\u001D(boundary2);
				}
				u0004_u4.\u000A = u000A2;
				break;
			}
			case SortingDirections.South:
			{
				\u0012\u0007.\u0004\u0007 u0004_u5 = u0004_u;
				Func<Boundary, bool> func7;
				if ((func7 = \u0012\u0007.<>c.\u0009) == null)
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
					func7 = (\u0012\u0007.<>c.\u0009 = new Func<Boundary, bool>(\u0012\u0007.<>c.\u001F.\u0020\u0007));
				}
				IEnumerable<Boundary> enumerable3 = Enumerable.Where<Boundary>(\u001F, func7);
				Func<Boundary, double> func8;
				if ((func8 = \u0012\u0007.<>c.\u001F\u000A) == null)
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
					func8 = (\u0012\u0007.<>c.\u001F\u000A = new Func<Boundary, double>(\u0012\u0007.<>c.\u001F.\u0017\u0007));
				}
				Boundary boundary3 = Enumerable.FirstOrDefault<Boundary>(Enumerable.OrderBy<Boundary, double>(enumerable3, func8));
				Line u000A3;
				if (boundary3 == null)
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
					u000A3 = \u000E\u0009\u0010.\u001F;
				}
				else
				{
					u000A3 = \u001E\u0004\u0007.\u001D(boundary3);
				}
				u0004_u5.\u000A = u000A3;
				break;
			}
			case SortingDirections.West:
			{
				\u0012\u0007.\u0004\u0007 u0004_u6 = u0004_u;
				Func<Boundary, bool> func9;
				if ((func9 = \u0012\u0007.<>c.\u000A\u000A) == null)
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
					func9 = (\u0012\u0007.<>c.\u000A\u000A = new Func<Boundary, bool>(\u0012\u0007.<>c.\u001F.\u0014\u0007));
				}
				IEnumerable<Boundary> enumerable4 = Enumerable.Where<Boundary>(\u001F, func9);
				Func<Boundary, double> func10;
				if ((func10 = \u0012\u0007.<>c.\u0007\u000A) == null)
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
					func10 = (\u0012\u0007.<>c.\u0007\u000A = new Func<Boundary, double>(\u0012\u0007.<>c.\u001F.\u0013\u0007));
				}
				Boundary boundary4 = Enumerable.FirstOrDefault<Boundary>(Enumerable.OrderBy<Boundary, double>(enumerable4, func10));
				Line u000A4;
				if (boundary4 == null)
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
					u000A4 = \u000E\u0009\u0010.\u001F;
				}
				else
				{
					u000A4 = \u001E\u0004\u0007.\u001D(boundary4);
				}
				u0004_u6.\u000A = u000A4;
				break;
			}
			}
			\u001A\u0019\u0007.\u000A(\u001F, new Comparison<Boundary>(u0004_u.\u001D));
			return \u001F;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00011024 File Offset: 0x0000F224
		private static List<Boundary> \u0003(List<Boundary> \u001F, SortingDirections \u000A = SortingDirections.North)
		{
			List<Boundary> list = \u0012\u0007.\u0012(\u001F, \u000A);
			Boundary u = Enumerable.First<Boundary>(list);
			\u0001\u0019\u0007.\u000A(list, 0);
			\u0015\u0019\u0007.\u000A(list);
			\u000C\u0019\u0007.\u000A(list, 0, u);
			return list;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00011058 File Offset: 0x0000F258
		private static Line \u001C(List<\u0006\u000A> \u001F, XYZ \u000A)
		{
			List<\u0006\u000A> list;
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u0007.\u001C(List<\u0006\u000A>, XYZ)).MethodHandle;
				}
				list = \u0013\u0009\u0010.\u001F;
			}
			else
			{
				IEnumerable<\u0006\u000A> enumerable = \u001F;
				Func<\u0006\u000A, double> func;
				if ((func = \u0012\u0007.<>c.\u001D\u000A) == null)
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
					func = (\u0012\u0007.<>c.\u001D\u000A = new Func<\u0006\u000A, double>(\u0012\u0007.<>c.\u001F.\u001A\u0007));
				}
				list = Enumerable.ToList<\u0006\u000A>(Enumerable.OrderBy<\u0006\u000A, double>(enumerable, func));
			}
			\u001F = list;
			\u0006\u000A u001F = Enumerable.First<\u0006\u000A>(\u001F);
			XYZ xyz = \u0017\u001F\u0007.\u001D(u001F);
			XYZ xyz2 = \u0007\u000A\u0007.\u000A(\u001F\u0007\u0007.\u000A(\u0020\u001F\u0007.\u001D(u001F), xyz));
			\u0006\u000A u001F2 = Enumerable.Last<\u0006\u000A>(\u001F);
			IEnumerable<\u0006\u000A> enumerable2 = \u001F;
			Func<\u0006\u000A, XYZ> func2;
			if ((func2 = \u0012\u0007.<>c.\u0004\u000A) == null)
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
				func2 = (\u0012\u0007.<>c.\u0004\u000A = new Func<\u0006\u000A, XYZ>(\u0012\u0007.<>c.\u001F.\u000C\u0007));
			}
			IEnumerable<XYZ> enumerable3 = Enumerable.ToList<XYZ>(Enumerable.Select<\u0006\u000A, XYZ>(enumerable2, func2));
			IEnumerable<\u0006\u000A> enumerable4 = \u001F;
			Func<\u0006\u000A, XYZ> func3;
			if ((func3 = \u0012\u0007.<>c.\u0019\u000A) == null)
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
				func3 = (\u0012\u0007.<>c.\u0019\u000A = new Func<\u0006\u000A, XYZ>(\u0012\u0007.<>c.\u001F.\u0015\u0007));
			}
			List<XYZ> list2 = Enumerable.ToList<XYZ>(Enumerable.Select<\u0006\u000A, XYZ>(enumerable4, func3));
			object u001F3 = Enumerable.ToList<XYZ>(Enumerable.Concat<XYZ>(enumerable3, list2));
			List<XYZ> list3 = \u000B\u000A\u0007.\u000A();
			List<XYZ>.Enumerator enumerator = \u0004\u0007\u0007.\u000A(u001F3);
			try
			{
				while (\u000A\u0007\u0007.\u000A(ref enumerator))
				{
					XYZ u000A = \u001D\u0007\u0007.\u000A(ref enumerator).\u0003(xyz2);
					\u0005\u000A\u0007.\u000A(list3, u000A);
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
			IEnumerable<XYZ> enumerable5 = list3;
			Func<XYZ, double> func4;
			if ((func4 = \u0012\u0007.<>c.\u0018\u000A) == null)
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
				func4 = (\u0012\u0007.<>c.\u0018\u000A = new Func<XYZ, double>(\u0012\u0007.<>c.\u001F.\u0001\u0007));
			}
			IOrderedEnumerable<XYZ> orderedEnumerable = Enumerable.OrderBy<XYZ, double>(enumerable5, func4);
			Func<XYZ, double> func5;
			if ((func5 = \u0012\u0007.<>c.\u0005\u000A) == null)
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
				func5 = (\u0012\u0007.<>c.\u0005\u000A = new Func<XYZ, double>(\u0012\u0007.<>c.\u001F.\u0009\u0007));
			}
			list3 = Enumerable.ToList<XYZ>(Enumerable.ThenBy<XYZ, double>(orderedEnumerable, func5));
			double u000A2 = \u0006\u0007\u0007.\u000A(Enumerable.First<XYZ>(list3), Enumerable.Last<XYZ>(list3));
			XYZ xyz3 = \u0009\u0019\u0007.\u000A(xyz, \u0003\u0007\u0007.\u000A(xyz2, u000A2));
			Line line;
			if (\u000A\u0004\u0007.\u000A(\u0007\u000A\u0007.\u000A(\u0015\u001F\u0007.\u001D(u001F)), xyz2))
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
				line = \u0002\u0007\u0007.\u000A(xyz, xyz3);
			}
			else
			{
				line = \u0002\u0007\u0007.\u000A(xyz3, xyz);
			}
			if (\u001D\u001D\u0007.\u000A(\u001F\u0007\u0007.\u000A(\u0012\u0019\u0007.\u000A(u001F2).\u000A(), \u0012\u0019\u0007.\u000A(u001F).\u000A()), \u000A) < 0.0)
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
				line.\u001D(\u0009\u0007\u0007.\u000A(\u0002\u000A.\u0003(\u0018\u000A\u0007.\u000A(u001F), \u0018\u000A\u0007.\u000A(u001F2)), \u000A));
			}
			return line;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0001131C File Offset: 0x0000F51C
		private static ElevationMarker \u000D(Document \u001F, List<Boundary> \u000A, ElementId \u0007, int \u001D)
		{
			Func<Boundary, Line> func;
			if ((func = \u0012\u0007.<>c.\u0016\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u0007.\u000D(Document, List<Boundary>, ElementId, int)).MethodHandle;
				}
				func = (\u0012\u0007.<>c.\u0016\u000A = new Func<Boundary, Line>(\u0012\u0007.<>c.\u001F.\u001F\u001D));
			}
			XYZ xyz = Enumerable.Select<Boundary, Line>(\u000A, func).\u0018();
			ElevationMarker elevationMarker = \u0004\u0018\u0007.\u000A(\u001F, \u0007, xyz, \u001D);
			XYZ u001F = \u0013\u001F\u0007.\u0007(\u001E\u0004\u0007.\u0007(\u001B\u0004\u0007.\u000A(\u000A, 0)), 0);
			XYZ u001F2 = \u0013\u001F\u0007.\u0007(\u001E\u0004\u0007.\u0007(\u001B\u0004\u0007.\u000A(\u000A, 0)), 1);
			Line u001F3 = \u0002\u0007\u0007.\u000A(\u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F), \u001C\u001F\u0007.\u000A(u001F), \u0003\u000A\u0007.\u000A(u001F2)), \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F2), \u001C\u001F\u0007.\u000A(u001F2), \u0003\u000A\u0007.\u000A(u001F2)));
			Func<Boundary, Line> func2;
			if ((func2 = \u0012\u0007.<>c.\u000B\u000A) == null)
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
				func2 = (\u0012\u0007.<>c.\u000B\u000A = new Func<Boundary, Line>(\u0012\u0007.<>c.\u001F.\u000A\u001D));
			}
			XYZ u000A = \u0005\u0004\u0007.\u000A(u001F3.\u001B(Enumerable.ToList<Line>(Enumerable.Select<Boundary, Line>(\u000A, func2))));
			double num = \u000A\u0018\u0007.\u000A(\u001D\u0018\u0007.\u000A(), u000A, \u0007\u0018\u0007.\u000A());
			\u001F\u0018\u0007.\u000A(\u001F, \u0002\u001E\u000A.\u0007(elevationMarker), \u0002\u0007\u0007.\u000A(xyz, \u0009\u0019\u0007.\u000A(xyz, \u001B\u001F\u0007.\u000A(0.0, 0.0, 5.0))), num - 6.283185307179586);
			return elevationMarker;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0001149C File Offset: 0x0000F69C
		private static ViewSection \u0010(SpatialElement \u001F, Document \u000A, ElevationMarker \u0007, SectionData \u001D, List<Boundary> \u0004, ElementId \u0019, int \u0018, int \u0005)
		{
			\u0012\u0007.\u0019\u0007 u0019_u = new \u0012\u0007.\u0019\u0007();
			u0019_u.\u001F = \u000A;
			double num = \u001A\u0004\u0007.\u000A(\u001D);
			double num2 = \u001B\u0018\u0007.\u000A(\u001D);
			int u000A = \u0008\u0018\u0007.\u000A(\u001D);
			double num3 = \u0013\u0004\u0007.\u000A(\u001D);
			double num4 = \u000E\u0018\u0007.\u000A(\u001D);
			ViewDetailLevel u000A2 = \u0010\u0018\u0007.\u000A(\u001D);
			Func<Boundary, Line> func;
			if ((func = \u0012\u0007.<>c.\u0002\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u0007.\u0010(SpatialElement, Document, ElevationMarker, SectionData, List<Boundary>, ElementId, int, int)).MethodHandle;
				}
				func = (\u0012\u0007.<>c.\u0002\u000A = new Func<Boundary, Line>(\u0012\u0007.<>c.\u001F.\u0007\u001D));
			}
			XYZ u000A3 = Enumerable.Select<Boundary, Line>(\u0004, func).\u0018();
			double num5 = \u000D\u0018\u0007.\u000A(\u001B\u0004\u0007.\u000A(\u0004, \u0005));
			XYZ u001F = \u0013\u001F\u0007.\u0007(\u001E\u0004\u0007.\u0007(\u001B\u0004\u0007.\u000A(\u0004, \u0005)), 0);
			XYZ u001F2 = \u0013\u001F\u0007.\u0007(\u001E\u0004\u0007.\u0007(\u001B\u0004\u0007.\u000A(\u0004, \u0005)), 1);
			Line line = \u0002\u0007\u0007.\u000A(\u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F), \u001C\u001F\u0007.\u000A(u001F), \u0003\u000A\u0007.\u000A(u001F2)), \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F2), \u001C\u001F\u0007.\u000A(u001F2), \u0003\u000A\u0007.\u000A(u001F2)));
			line = line.\u001D(\u0009\u0007\u0007.\u000A(num2, \u0005\u0004\u0007.\u000A(\u0007\u0018\u0007.\u000A())));
			double u = num + num2;
			XYZ u001F3 = line.\u0007();
			u0019_u.\u000A = \u001C\u0018\u0007.\u000A(\u0007, u0019_u.\u001F, \u0019, \u0018);
			Line u001F4 = line;
			Func<Boundary, Line> func2;
			if ((func2 = \u0012\u0007.<>c.\u0006\u000A) == null)
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
				func2 = (\u0012\u0007.<>c.\u0006\u000A = new Func<Boundary, Line>(\u0012\u0007.<>c.\u001F.\u001D\u001D));
			}
			XYZ u001F5 = \u0005\u0004\u0007.\u000A(u001F4.\u001B(Enumerable.ToList<Line>(Enumerable.Select<Boundary, Line>(\u0004, func2))));
			ElementId u000A4 = Enumerable.FirstOrDefault<ElementId>(\u0012\u0018\u0007.\u000A(\u0007, \u0003\u0018\u0007.\u000A(-2000278L)), new Func<ElementId, bool>(u0019_u.\u0007));
			XYZ u2 = \u0003\u0007\u0007.\u000A(u001F5, num3);
			XYZ u3 = \u001F\u0007\u0007.\u000A(u001F3, u000A3);
			\u000F\u0018\u0007.\u000A(u0019_u.\u001F, u000A4, u3);
			\u000F\u0018\u0007.\u000A(u0019_u.\u001F, u000A4, u2);
			\u0019\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(u0019_u.\u000A, -1005176L), Constants.InvalidElementId);
			\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(u0019_u.\u000A, -1005123L), -1);
			\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(u0019_u.\u000A, -1011002L), u000A2);
			\u0002\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(u0019_u.\u000A, -1005104L), num4 + num5 + num3);
			\u000B\u0018\u0007.\u000A(u0019_u.\u000A, u000A);
			\u0019\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(u0019_u.\u000A, -1012102L), \u001E\u0001\u000A.\u000A(\u0018\u0018\u0007.\u0007(\u0005\u0018\u0007.\u000A(\u001D))));
			\u001F.\u0008(u0019_u.\u001F, \u001D, line, u0019_u.\u000A, u);
			return u0019_u.\u000A;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00011790 File Offset: 0x0000F990
		private static Line \u000E(double \u001F, List<Line> \u000A)
		{
			List<Line> list = \u0003\u001D\u0007.\u000A();
			\u000B\u0007\u0007.\u000A(list, Enumerable.FirstOrDefault<Line>(\u000A));
			List<Line> list2 = list;
			Line result = Enumerable.LastOrDefault<Line>(list2);
			for (int i = 1; i < \u000E\u0007\u0007.\u0007(\u000A); i++)
			{
				IEnumerable<Line> enumerable = list2;
				Func<Line, double> func;
				if ((func = \u0012\u0007.<>c.\u000F\u000A) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u0007.\u000E(double, List<Line>)).MethodHandle;
					}
					func = (\u0012\u0007.<>c.\u000F\u000A = new Func<Line, double>(\u0012\u0007.<>c.\u001F.\u0004\u001D));
				}
				if (\u0008\u001F\u0007.\u000A(\u0011\u0018\u0007.\u000A(Enumerable.Select<Line, double>(enumerable, func)) - \u001F) <= 0.1)
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
					return Enumerable.LastOrDefault<Line>(list2);
				}
				\u000B\u0007\u0007.\u000A(list2, \u0008\u0007\u0007.\u000A(\u000A, i));
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
			return result;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0001185C File Offset: 0x0000FA5C
		private static bool \u0008(this SpatialElement \u001F, Document \u000A, SectionData \u0007, Line \u001D, ViewSection \u0004, double \u0019)
		{
			\u0012\u0007.\u0018\u0007 u0018_u = new \u0012\u0007.\u0018\u0007();
			u0018_u.\u001F = \u001F;
			double u001F = \u001B\u0018\u0007.\u000A(\u0007);
			double num = \u0015\u0018\u0007.\u000A(\u0007);
			double num2 = \u000C\u0018\u0007.\u000A(\u0007);
			bool result = true;
			try
			{
				\u0012\u0007.\u001B(\u000A, \u0004);
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u001E\u000A\u0007.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\SpatialElementViews\\Externsions\\SpatialElementExtensions.cs", "CorrectElevationCropShape");
			}
			BoundingBoxXYZ u001F2 = \u0002\u0004\u0007.\u000A(u0018_u.\u001F, \u0004);
			BuiltInCategory builtInCategory;
			if (\u0014\u0009\u0010.\u001F(u0018_u.\u001F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElement.\u0008(Document, SectionData, Line, ViewSection, double)).MethodHandle;
				}
				builtInCategory = -2000160L;
			}
			else
			{
				builtInCategory = -2003600L;
			}
			BuiltInCategory u000A2 = builtInCategory;
			if (Enumerable.FirstOrDefault<Element>(\u0017\u0011\u000A.\u0007(\u001A\u0018\u0007.\u000A(\u000A, \u0002\u001E\u000A.\u0007(\u0004)), u000A2), new Func<Element, bool>(u0018_u.\u000A)) != null)
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
				Line line = \u0002\u0007\u0007.\u000A(\u000B\u0004\u0007.\u000A(u001F2), \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F2)), \u001C\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F2)), \u0003\u000A\u0007.\u000A(\u000B\u0004\u0007.\u000A(u001F2))));
				if (\u001D.\u0008(line))
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
					if (\u0008\u001F\u0007.\u000A(\u0001\u0004\u0007.\u000A(\u001D) - \u0001\u0004\u0007.\u000A(line)) < 1.5)
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
						\u001D = line;
					}
				}
			}
			\u001D = \u001D.\u001D(\u0009\u0007\u0007.\u000A(u001F, \u0005\u0004\u0007.\u000A(\u0007\u0018\u0007.\u000A())));
			ViewCropRegionShapeManager u001F3 = \u0013\u0018\u0007.\u000A(\u0004);
			Line u001F4 = \u001D;
			XYZ u000A3 = \u0007\u000A\u0007.\u000A(\u0014\u0018\u0007.\u000A(\u0004)).\u0012();
			u001F4 = u001F4.\u0012(u000A3);
			Line line2;
			if (\u0011\u0007\u0007.\u000A(\u0007\u000A\u0007.\u000A(\u0014\u0018\u0007.\u000A(\u0004)), u000A3, 0.01))
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
				line2 = u001F4.\u0016(num, num2);
			}
			else
			{
				line2 = u001F4.\u0016(num2, num);
			}
			XYZ xyz = \u0013\u001F\u0007.\u0007(line2, 0);
			XYZ u001F5 = \u0013\u001F\u0007.\u0007(line2, 1);
			Line line3 = \u0002\u0007\u0007.\u000A(u001F5, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F5), \u001C\u001F\u0007.\u000A(u001F5), \u0003\u000A\u0007.\u000A(u001F5) + \u0019));
			Line line4 = \u0002\u0007\u0007.\u000A(\u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(xyz), \u001C\u001F\u0007.\u000A(xyz), \u0003\u000A\u0007.\u000A(xyz) + \u0019), xyz);
			Line u000A4 = \u0002\u0007\u0007.\u000A(\u0013\u001F\u0007.\u0007(line3, 1), \u0013\u001F\u0007.\u0007(line4, 0));
			List<Curve> u001F6 = \u0013\u001D\u0007.\u000A();
			\u0014\u001D\u0007.\u000A(u001F6, line2);
			\u0014\u001D\u0007.\u000A(u001F6, line3);
			\u0014\u001D\u0007.\u000A(u001F6, u000A4);
			\u0014\u001D\u0007.\u000A(u001F6, line4);
			CurveLoop u000A5 = \u0017\u0018\u0007.\u000A(u001F6);
			try
			{
				\u0020\u0018\u0007.\u000A(u001F3, u000A5);
			}
			catch
			{
				result = false;
			}
			\u001E\u0018\u0007.\u000A(\u000A);
			return result;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00011B68 File Offset: 0x0000FD68
		private static void \u001B(Document \u001F, ViewSection \u000A)
		{
			Category u001F = \u0009\u0018\u0007.\u000A(\u001F, -2000160L);
			Category u001F2 = \u0009\u0018\u0007.\u000A(\u001F, -2003600L);
			\u0001\u0018\u0007.\u000A(\u000A, \u0015\u0014\u000A.\u001D(u001F), false);
			\u0001\u0018\u0007.\u000A(\u000A, \u0015\u0014\u000A.\u001D(u001F2), false);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00011BB4 File Offset: 0x0000FDB4
		private static BoundingBoxXYZ \u0011(Curve \u001F, double \u000A)
		{
			XYZ xyz = \u0013\u001F\u0007.\u0007(\u001F, 0);
			XYZ xyz2 = \u001F\u0007\u0007.\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1), xyz);
			double num = \u0018\u0005\u0007.\u000A(xyz2) / 2.0;
			double num2 = \u000A / 2.0;
			XYZ u001F = \u000F\u0007\u0007.\u000A(xyz, \u0009\u0007\u0007.\u000A(0.5, xyz2));
			BoundingBoxXYZ boundingBoxXYZ = \u001E\u0019\u0007.\u000A();
			\u0011\u0019\u0007.\u000A(boundingBoxXYZ, \u001B\u001F\u0007.\u000A(-num, \u001C\u001F\u0007.\u000A(u001F) - num, 0.0));
			\u001B\u0019\u0007.\u000A(boundingBoxXYZ, \u001B\u001F\u0007.\u000A(num, \u001C\u001F\u0007.\u000A(u001F) + num, \u000A));
			XYZ xyz3 = \u0007\u000A\u0007.\u000A(\u001D\u000A\u0007.\u000A(\u000D\u0009\u0010.\u001F(\u001F)));
			XYZ u000A = \u0007\u0018\u0007.\u000A();
			XYZ u000A2 = \u0012\u0007\u0007.\u000A(xyz3, u000A);
			Transform transform = \u0019\u0005\u0007.\u000A();
			\u0004\u0005\u0007.\u000A(transform, xyz3);
			\u001D\u0005\u0007.\u000A(transform, u000A);
			\u0007\u0005\u0007.\u000A(transform, u000A2);
			XYZ u000A3 = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F), \u001C\u001F\u0007.\u000A(u001F), \u0003\u000A\u0007.\u000A(u001F) + num2);
			\u000A\u0005\u0007.\u000A(transform, u000A3);
			\u001F\u0005\u0007.\u000A(boundingBoxXYZ, transform);
			return boundingBoxXYZ;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00011CE4 File Offset: 0x0000FEE4
		private static BoundingBoxIntersectsFilter \u001E(Outline \u001F)
		{
			return \u0005\u0005\u0007.\u000A(\u001F);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00011CFC File Offset: 0x0000FEFC
		private static Outline \u0020(BoundingBoxXYZ \u001F)
		{
			XYZ u000A = \u001B\u001F\u0007.\u000A(\u0016\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(\u001F)), 5), \u0016\u001F\u0007.\u000A(\u001C\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(\u001F)), 5), \u0016\u001F\u0007.\u000A(\u0003\u000A\u0007.\u000A(\u0016\u0004\u0007.\u000A(\u001F)), 5));
			XYZ u000A2 = \u001B\u001F\u0007.\u000A(\u0016\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(\u001F)), 5), \u0016\u001F\u0007.\u000A(\u001C\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(\u001F)), 5), \u0016\u001F\u0007.\u000A(\u0003\u000A\u0007.\u000A(\u000B\u0004\u0007.\u000A(\u001F)), 5));
			List<XYZ> list = \u000B\u000A\u0007.\u000A();
			\u0005\u000A\u0007.\u000A(list, u000A2);
			\u0005\u000A\u0007.\u000A(list, u000A);
			Func<XYZ, double> func;
			if ((func = \u0012\u0007.<>c.\u0012\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u0007.\u0020(BoundingBoxXYZ)).MethodHandle;
				}
				func = (\u0012\u0007.<>c.\u0012\u000A = new Func<XYZ, double>(\u0012\u0007.<>c.\u001F.\u0019\u001D));
			}
			IEnumerable<XYZ> enumerable = Enumerable.OrderBy<XYZ, double>(list, func);
			Func<XYZ, double> func2;
			if ((func2 = \u0012\u0007.<>c.\u0003\u000A) == null)
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
				func2 = (\u0012\u0007.<>c.\u0003\u000A = new Func<XYZ, double>(\u0012\u0007.<>c.\u001F.\u0018\u001D));
			}
			double u001F = Enumerable.FirstOrDefault<double>(Enumerable.Select<XYZ, double>(enumerable, func2));
			List<XYZ> list2 = \u000B\u000A\u0007.\u000A();
			\u0005\u000A\u0007.\u000A(list2, u000A2);
			\u0005\u000A\u0007.\u000A(list2, u000A);
			Func<XYZ, double> func3;
			if ((func3 = \u0012\u0007.<>c.\u001C\u000A) == null)
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
				func3 = (\u0012\u0007.<>c.\u001C\u000A = new Func<XYZ, double>(\u0012\u0007.<>c.\u001F.\u0005\u001D));
			}
			IEnumerable<XYZ> enumerable2 = Enumerable.OrderBy<XYZ, double>(list2, func3);
			Func<XYZ, double> func4;
			if ((func4 = \u0012\u0007.<>c.\u000D\u000A) == null)
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
				func4 = (\u0012\u0007.<>c.\u000D\u000A = new Func<XYZ, double>(\u0012\u0007.<>c.\u001F.\u0016\u001D));
			}
			double u000A3 = Enumerable.FirstOrDefault<double>(Enumerable.Select<XYZ, double>(enumerable2, func4));
			List<XYZ> list3 = \u000B\u000A\u0007.\u000A();
			\u0005\u000A\u0007.\u000A(list3, u000A2);
			\u0005\u000A\u0007.\u000A(list3, u000A);
			Func<XYZ, double> func5;
			if ((func5 = \u0012\u0007.<>c.\u0010\u000A) == null)
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
				func5 = (\u0012\u0007.<>c.\u0010\u000A = new Func<XYZ, double>(\u0012\u0007.<>c.\u001F.\u000B\u001D));
			}
			IEnumerable<XYZ> enumerable3 = Enumerable.OrderBy<XYZ, double>(list3, func5);
			Func<XYZ, double> func6;
			if ((func6 = \u0012\u0007.<>c.\u000E\u000A) == null)
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
				func6 = (\u0012\u0007.<>c.\u000E\u000A = new Func<XYZ, double>(\u0012\u0007.<>c.\u001F.\u0002\u001D));
			}
			double u = Enumerable.FirstOrDefault<double>(Enumerable.Select<XYZ, double>(enumerable3, func6));
			List<XYZ> list4 = \u000B\u000A\u0007.\u000A();
			\u0005\u000A\u0007.\u000A(list4, u000A2);
			\u0005\u000A\u0007.\u000A(list4, u000A);
			Func<XYZ, double> func7;
			if ((func7 = \u0012\u0007.<>c.\u0008\u000A) == null)
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
				func7 = (\u0012\u0007.<>c.\u0008\u000A = new Func<XYZ, double>(\u0012\u0007.<>c.\u001F.\u0006\u001D));
			}
			IEnumerable<XYZ> enumerable4 = Enumerable.OrderByDescending<XYZ, double>(list4, func7);
			Func<XYZ, double> func8;
			if ((func8 = \u0012\u0007.<>c.\u001B\u000A) == null)
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
				func8 = (\u0012\u0007.<>c.\u001B\u000A = new Func<XYZ, double>(\u0012\u0007.<>c.\u001F.\u000F\u001D));
			}
			double u001F2 = Enumerable.FirstOrDefault<double>(Enumerable.Select<XYZ, double>(enumerable4, func8));
			List<XYZ> list5 = \u000B\u000A\u0007.\u000A();
			\u0005\u000A\u0007.\u000A(list5, u000A2);
			\u0005\u000A\u0007.\u000A(list5, u000A);
			Func<XYZ, double> func9;
			if ((func9 = \u0012\u0007.<>c.\u0011\u000A) == null)
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
				func9 = (\u0012\u0007.<>c.\u0011\u000A = new Func<XYZ, double>(\u0012\u0007.<>c.\u001F.\u0012\u001D));
			}
			IEnumerable<XYZ> enumerable5 = Enumerable.OrderByDescending<XYZ, double>(list5, func9);
			Func<XYZ, double> func10;
			if ((func10 = \u0012\u0007.<>c.\u001E\u000A) == null)
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
				func10 = (\u0012\u0007.<>c.\u001E\u000A = new Func<XYZ, double>(\u0012\u0007.<>c.\u001F.\u0003\u001D));
			}
			double u000A4 = Enumerable.FirstOrDefault<double>(Enumerable.Select<XYZ, double>(enumerable5, func10));
			List<XYZ> list6 = \u000B\u000A\u0007.\u000A();
			\u0005\u000A\u0007.\u000A(list6, u000A2);
			\u0005\u000A\u0007.\u000A(list6, u000A);
			Func<XYZ, double> func11;
			if ((func11 = \u0012\u0007.<>c.\u0020\u000A) == null)
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
				func11 = (\u0012\u0007.<>c.\u0020\u000A = new Func<XYZ, double>(\u0012\u0007.<>c.\u001F.\u001C\u001D));
			}
			IEnumerable<XYZ> enumerable6 = Enumerable.OrderByDescending<XYZ, double>(list6, func11);
			Func<XYZ, double> func12;
			if ((func12 = \u0012\u0007.<>c.\u0017\u000A) == null)
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
				func12 = (\u0012\u0007.<>c.\u0017\u000A = new Func<XYZ, double>(\u0012\u0007.<>c.\u001F.\u000D\u001D));
			}
			double u2 = Enumerable.FirstOrDefault<double>(Enumerable.Select<XYZ, double>(enumerable6, func12));
			XYZ u001F3 = \u001B\u001F\u0007.\u000A(u001F, u000A3, u);
			XYZ u000A5 = \u001B\u001F\u0007.\u000A(u001F2, u000A4, u2);
			return \u0016\u0005\u0007.\u000A(u001F3, u000A5);
		}

		// Token: 0x04000109 RID: 265
		private static double \u001F;

		// Token: 0x02000780 RID: 1920
		[CompilerGenerated]
		private sealed class \u0007\u0007
		{
			// Token: 0x06004B3A RID: 19258 RVA: 0x001D8B88 File Offset: 0x001D6D88
			internal bool \u000A(Level \u001F)
			{
				return \u0016\u001F\u0007.\u000A(\u000E\u0007\u001D.\u000A(\u001F), 5) == \u0016\u001F\u0007.\u000A(\u000E\u0007\u001D.\u000A(\u0019\u0013\u0007.\u000A(this.\u001F)), 5);
			}

			// Token: 0x04001E63 RID: 7779
			public SpatialElement \u001F;
		}

		// Token: 0x02000781 RID: 1921
		[CompilerGenerated]
		private sealed class \u001D\u0007
		{
			// Token: 0x06004B3C RID: 19260 RVA: 0x001D8BD8 File Offset: 0x001D6DD8
			internal XYZ \u000A(XYZ \u001F)
			{
				return \u0007\u0013\u0007.\u000A(this.\u001F, \u001F);
			}

			// Token: 0x04001E64 RID: 7780
			public Transform \u001F;
		}

		// Token: 0x02000782 RID: 1922
		[CompilerGenerated]
		private sealed class \u0004\u0007
		{
			// Token: 0x06004B3E RID: 19262 RVA: 0x001D8C08 File Offset: 0x001D6E08
			internal int \u001D(Boundary \u001F, Boundary \u000A)
			{
				object u001F = \u001E\u0004\u0007.\u0007(\u001F);
				Line u001F2 = \u001E\u0004\u0007.\u0007(\u000A);
				XYZ u001F3 = \u001A\u0007\u0007.\u000A(u001F, 0.5, true);
				XYZ u001F4 = \u001A\u0007\u0007.\u000A(u001F2, 0.5, true);
				double num = \u0018\u0015\u000D.\u000A(\u001C\u001F\u0007.\u000A(u001F3) - \u001C\u001F\u0007.\u000A(this.\u001F), \u000D\u001F\u0007.\u000A(u001F3) - \u000D\u001F\u0007.\u000A(this.\u001F));
				double num2 = \u0018\u0015\u000D.\u000A(\u001C\u001F\u0007.\u000A(u001F4) - \u001C\u001F\u0007.\u000A(this.\u001F), \u000D\u001F\u0007.\u000A(u001F4) - \u000D\u001F\u0007.\u000A(this.\u001F));
				if (\u001C\u001D\u0007.\u000A(this.\u000A, \u001C\u0009\u0010.\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u0007.\u0004\u0007.\u001D(Boundary, Boundary)).MethodHandle;
					}
					XYZ u001F5 = \u001A\u0007\u0007.\u000A(this.\u000A, 0.5, true);
					double num3 = \u0018\u0015\u000D.\u000A(\u001C\u001F\u0007.\u000A(u001F5) - \u001C\u001F\u0007.\u000A(this.\u001F), \u000D\u001F\u0007.\u000A(u001F5) - \u000D\u001F\u0007.\u000A(this.\u001F));
					num = (num - num3 + 6.283185307179586) % 6.283185307179586;
					num2 = (num2 - num3 + 6.283185307179586) % 6.283185307179586;
				}
				else
				{
					double num4 = 1.5707963267948966 * (double)this.\u0007;
					num = (num + num4 + 6.283185307179586) % 6.283185307179586;
					num2 = (num2 + num4 + 6.283185307179586) % 6.283185307179586;
				}
				return \u0003\u0014\u0007.\u000A(ref num2, num);
			}

			// Token: 0x04001E65 RID: 7781
			public XYZ \u001F;

			// Token: 0x04001E66 RID: 7782
			public Line \u000A;

			// Token: 0x04001E67 RID: 7783
			public SortingDirections \u0007;
		}

		// Token: 0x02000783 RID: 1923
		[CompilerGenerated]
		private sealed class \u0019\u0007
		{
			// Token: 0x06004B40 RID: 19264 RVA: 0x001D8DCC File Offset: 0x001D6FCC
			internal bool \u0007(ElementId \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u0011\u0017\u000A.\u0007(this.\u001F, \u001F)), \u0005\u001E\u000A.\u000A(this.\u000A));
			}

			// Token: 0x04001E68 RID: 7784
			public Document \u001F;

			// Token: 0x04001E69 RID: 7785
			public ViewSection \u000A;
		}

		// Token: 0x02000784 RID: 1924
		[CompilerGenerated]
		private sealed class \u0018\u0007
		{
			// Token: 0x06004B42 RID: 19266 RVA: 0x001D8E18 File Offset: 0x001D7018
			internal bool \u000A(Element \u001F)
			{
				return \u0011\u0016\u001D.\u000A(\u0002\u001E\u000A.\u0007(\u001F), \u0002\u001E\u000A.\u0007(this.\u001F));
			}

			// Token: 0x04001E6A RID: 7786
			public SpatialElement \u001F;
		}

		// Token: 0x02000785 RID: 1925
		[CompilerGenerated]
		private sealed class \u0005\u0007
		{
			// Token: 0x04001E6B RID: 7787
			public Document \u001F;
		}

		// Token: 0x02000786 RID: 1926
		[CompilerGenerated]
		private sealed class \u0016\u0007
		{
			// Token: 0x06004B45 RID: 19269 RVA: 0x001D8E6C File Offset: 0x001D706C
			internal bool \u0007(ElementId \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u0011\u0017\u000A.\u0007(this.\u000A.\u001F, \u001F)), \u0005\u001E\u000A.\u000A(this.\u001F));
			}

			// Token: 0x04001E6C RID: 7788
			public ViewSection \u001F;

			// Token: 0x04001E6D RID: 7789
			public \u0012\u0007.\u0005\u0007 \u000A;
		}

		// Token: 0x02000787 RID: 1927
		[CompilerGenerated]
		private sealed class \u000B\u0007
		{
			// Token: 0x06004B47 RID: 19271 RVA: 0x001D8EBC File Offset: 0x001D70BC
			internal XYZ \u0004(\u0006\u000A \u001F)
			{
				return \u0012\u0019\u0007.\u000A(\u001F).\u001B(this.\u001F).\u0006(5);
			}

			// Token: 0x06004B48 RID: 19272 RVA: 0x001D8EE8 File Offset: 0x001D70E8
			internal bool \u0019(\u0006\u000A \u001F)
			{
				return \u0001\u0004\u0007.\u000A(\u0012\u0019\u0007.\u000A(\u001F)) >= this.\u000A;
			}

			// Token: 0x04001E6E RID: 7790
			public List<Line> \u001F;

			// Token: 0x04001E6F RID: 7791
			public double \u000A;

			// Token: 0x04001E70 RID: 7792
			public Func<\u0006\u000A, XYZ> \u0007;

			// Token: 0x04001E71 RID: 7793
			public Func<\u0006\u000A, bool> \u001D;
		}
	}
}

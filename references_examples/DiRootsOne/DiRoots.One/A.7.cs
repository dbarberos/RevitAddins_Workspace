using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x0200004E RID: 78
	internal static class \u000C\u000A
	{
		// Token: 0x0600027E RID: 638 RVA: 0x0000D918 File Offset: 0x0000BB18
		internal static List<Line> \u001F(this List<Line> \u001F, \u0011\u000A \u000A, bool \u0007 = false)
		{
			List<Line> list = \u0003\u001D\u0007.\u000A();
			List<Line>.Enumerator enumerator = \u0012\u001D\u0007.\u000A(\u001F);
			try
			{
				while (\u000B\u001D\u0007.\u000A(ref enumerator))
				{
					Line line = \u000F\u001D\u0007.\u000A(ref enumerator);
					if (\u0006\u001D\u0007.\u000A(line, \u001C\u0009\u0010.\u001F))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(List<Line>.\u001F(\u0011\u000A, bool)).MethodHandle;
						}
						\u000B\u0007\u0007.\u000A(list, \u000E\u0009\u0010.\u001F);
					}
					List<Line> list2 = line.\u001C(\u000A, \u0007);
					if (Enumerable.Any<Line>(list2))
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
						\u0002\u001D\u0007.\u000A(list, list2);
					}
					else
					{
						\u000B\u0007\u0007.\u000A(list, line);
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
			return list;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000D9D4 File Offset: 0x0000BBD4
		internal static List<XYZ> \u000A(this IEnumerable<Line> \u001F)
		{
			\u000C\u000A.\u0014\u000A u0014_u000A = new \u000C\u000A.\u0014\u000A();
			List<XYZ> list = \u000B\u000A\u0007.\u000A();
			u0014_u000A.\u001F = Enumerable.ElementAt<Line>(\u001F, 0);
			\u0005\u000A\u0007.\u000A(list, \u0013\u001F\u0007.\u0007(u0014_u000A.\u001F, 0));
			\u0005\u000A\u0007.\u000A(list, \u0013\u001F\u0007.\u0007(u0014_u000A.\u001F, 1));
			IL_18F:
			while (\u001C\u001D\u0007.\u000A(u0014_u000A.\u001F, \u001C\u0009\u0010.\u001F))
			{
				Func<Line, bool> func;
				if ((func = u0014_u000A.\u000A) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(IEnumerable<Line>.\u000A()).MethodHandle;
					}
					func = (u0014_u000A.\u000A = new Func<Line, bool>(u0014_u000A.\u001D));
				}
				IEnumerator<Line> enumerator = \u000E\u001D\u0007.\u000A(Enumerable.Where<Line>(\u001F, func));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						Line u001F = \u0010\u001D\u0007.\u000A(enumerator);
						\u000C\u000A.\u0013\u000A u0013_u000A = new \u000C\u000A.\u0013\u000A();
						IList<XYZ> list2 = \u000D\u001D\u0007.\u000A(u001F);
						\u000C\u000A.\u0013\u000A u0013_u000A2 = u0013_u000A;
						IEnumerable<XYZ> enumerable = list2;
						Func<XYZ, bool> func2;
						if ((func2 = u0014_u000A.\u0007) == null)
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
							func2 = (u0014_u000A.\u0007 = new Func<XYZ, bool>(u0014_u000A.\u0004));
						}
						if ((u0013_u000A2.\u001F = Enumerable.FirstOrDefault<XYZ>(enumerable, func2)) != null)
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
							\u000C\u000A.\u001A\u000A u001A_u000A = new \u000C\u000A.\u001A\u000A();
							u001A_u000A.\u001F = Enumerable.FirstOrDefault<XYZ>(list2, new Func<XYZ, bool>(u0013_u000A.\u000A));
							if (!Enumerable.Any<XYZ>(list, new Func<XYZ, bool>(u001A_u000A.\u000A)))
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
								\u0005\u000A\u0007.\u000A(list, u001A_u000A.\u001F);
								u0014_u000A.\u001F = u001F;
								goto IL_18F;
							}
							u0014_u000A.\u001F = \u000E\u0009\u0010.\u001F;
							goto IL_18F;
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
							switch (6)
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
			for (;;)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
			return Enumerable.ToList<XYZ>(list);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000DBAC File Offset: 0x0000BDAC
		internal static List<XYZ> \u0007(this CurveArray \u001F)
		{
			HashSet<XYZ> u001F = \u001E\u001D\u0007.\u000A(new \u0008\u0007());
			IEnumerator u001F2 = \u0011\u001D\u0007.\u000A(\u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(u001F2))
				{
					Curve u001F3 = \u0010\u0009\u0010.\u001F(\u0003\u0013\u000A.\u000A(u001F2));
					\u001B\u001D\u0007.\u000A(u001F, \u0013\u001F\u0007.\u0007(u001F3, 0));
					\u001B\u001D\u0007.\u000A(u001F, \u0013\u001F\u0007.\u0007(u001F3, 1));
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CurveArray.\u0007()).MethodHandle;
				}
			}
			finally
			{
				IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F2);
				if (disposable != null)
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
					\u001F\u0017\u000A.\u000A(disposable);
				}
			}
			return \u0008\u001D\u0007.\u000A(u001F);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000DC5C File Offset: 0x0000BE5C
		internal static List<XYZ> \u0007(this IEnumerable<Curve> \u001F)
		{
			HashSet<XYZ> u001F = \u001E\u001D\u0007.\u000A(new \u0008\u0007());
			IEnumerator<Curve> enumerator = \u0017\u001D\u0007.\u000A(\u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Curve u001F2 = \u0020\u001D\u0007.\u000A(enumerator);
					if (!\u0006\u001D\u0007.\u000A(u001F2, \u001C\u0009\u0010.\u001F))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(IEnumerable<Curve>.\u0007()).MethodHandle;
						}
						\u001B\u001D\u0007.\u000A(u001F, \u0013\u001F\u0007.\u0007(u001F2, 0));
						\u001B\u001D\u0007.\u000A(u001F, \u0013\u001F\u0007.\u0007(u001F2, 1));
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
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return \u0008\u001D\u0007.\u000A(u001F);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000DD14 File Offset: 0x0000BF14
		internal static List<XYZ> \u001D(this IEnumerable<Curve> \u001F)
		{
			HashSet<XYZ> u001F = \u001E\u001D\u0007.\u000A(new \u0008\u0007());
			IEnumerator<Curve> enumerator = \u0017\u001D\u0007.\u000A(\u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Curve u001F2 = \u0020\u001D\u0007.\u000A(enumerator);
					if (\u001C\u001D\u0007.\u000A(u001F2, \u001C\u0009\u0010.\u001F))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(IEnumerable<Curve>.\u001D()).MethodHandle;
						}
						\u001B\u001D\u0007.\u000A(u001F, \u000D\u0009\u0010.\u001F(u001F2).\u0007());
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
			return \u0008\u001D\u0007.\u000A(u001F);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000DDC0 File Offset: 0x0000BFC0
		internal static List<Curve> \u0004(this IEnumerable<Curve> \u001F, double \u000A)
		{
			HashSet<XYZ> hashSet = \u001E\u001D\u0007.\u000A(new \u0008\u0007());
			List<Curve> list = \u0013\u001D\u0007.\u000A();
			IEnumerator<Curve> enumerator = \u0017\u001D\u0007.\u000A(\u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Curve u001F = \u0020\u001D\u0007.\u000A(enumerator);
					\u001B\u001D\u0007.\u000A(hashSet, \u0013\u001F\u0007.\u0007(u001F, 0));
					\u001B\u001D\u0007.\u000A(hashSet, \u0013\u001F\u0007.\u0007(u001F, 1));
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IEnumerable<Curve>.\u0004(double)).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			List<XYZ> u001F2 = Enumerable.ToList<XYZ>(hashSet).\u001D(\u000A);
			for (int i = 0; i < \u000F\u000A\u0007.\u000A(u001F2); i++)
			{
				int u000A = (i + 1) % \u000F\u000A\u0007.\u000A(u001F2);
				\u0014\u001D\u0007.\u000A(list, \u0002\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(u001F2, i), \u0016\u000A\u0007.\u000A(u001F2, u000A)));
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
			return list;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000DEC4 File Offset: 0x0000C0C4
		internal static List<Line> \u0019(this IEnumerable<Line> \u001F)
		{
			List<Line> list = Enumerable.ToList<Line>(\u001F);
			Comparison<Line> u000A;
			if ((u000A = \u000C\u000A.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IEnumerable<Line>.\u0019()).MethodHandle;
				}
				u000A = (\u000C\u000A.<>c.\u000A = new Comparison<Line>(\u000C\u000A.<>c.\u001F.\u001B));
			}
			\u001A\u001D\u0007.\u000A(list, u000A);
			return list;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000DF14 File Offset: 0x0000C114
		internal static XYZ \u0018(this IEnumerable<Line> \u001F)
		{
			List<XYZ> list = \u001F.\u001D();
			Func<XYZ, double> func;
			if ((func = \u000C\u000A.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IEnumerable<Line>.\u0018()).MethodHandle;
				}
				func = (\u000C\u000A.<>c.\u0007 = new Func<XYZ, double>(\u000C\u000A.<>c.\u001F.\u0011));
			}
			double num = \u0015\u001D\u0007.\u000A(Enumerable.Select<XYZ, double>(list, func));
			Func<XYZ, double> func2;
			if ((func2 = \u000C\u000A.<>c.\u001D) == null)
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
				func2 = (\u000C\u000A.<>c.\u001D = new Func<XYZ, double>(\u000C\u000A.<>c.\u001F.\u001E));
			}
			double num2 = \u0015\u001D\u0007.\u000A(Enumerable.Select<XYZ, double>(list, func2));
			Func<XYZ, double> func3;
			if ((func3 = \u000C\u000A.<>c.\u0004) == null)
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
				func3 = (\u000C\u000A.<>c.\u0004 = new Func<XYZ, double>(\u000C\u000A.<>c.\u001F.\u0020));
			}
			double num3 = \u000C\u001D\u0007.\u000A(Enumerable.Select<XYZ, double>(list, func3));
			Func<XYZ, double> func4;
			if ((func4 = \u000C\u000A.<>c.\u0019) == null)
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
				func4 = (\u000C\u000A.<>c.\u0019 = new Func<XYZ, double>(\u000C\u000A.<>c.\u001F.\u0017));
			}
			double num4 = \u000C\u001D\u0007.\u000A(Enumerable.Select<XYZ, double>(list, func4));
			Func<XYZ, double> func5;
			if ((func5 = \u000C\u000A.<>c.\u0018) == null)
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
				func5 = (\u000C\u000A.<>c.\u0018 = new Func<XYZ, double>(\u000C\u000A.<>c.\u001F.\u0014));
			}
			double num5 = \u0015\u001D\u0007.\u000A(Enumerable.Select<XYZ, double>(list, func5));
			Func<XYZ, double> func6;
			if ((func6 = \u000C\u000A.<>c.\u0005) == null)
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
				func6 = (\u000C\u000A.<>c.\u0005 = new Func<XYZ, double>(\u000C\u000A.<>c.\u001F.\u0013));
			}
			double num6 = \u000C\u001D\u0007.\u000A(Enumerable.Select<XYZ, double>(list, func6));
			double u001F = 0.5 * (num + num3);
			double u000A = 0.5 * (num2 + num4);
			double u = 0.5 * (num5 + num6);
			return \u001B\u001F\u0007.\u000A(u001F, u000A, u);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000E0C4 File Offset: 0x0000C2C4
		internal static List<Line> \u0005(this IEnumerable<Curve> \u001F)
		{
			Func<Curve, List<XYZ>> func;
			if ((func = \u000C\u000A.<>c.\u0016) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IEnumerable<Curve>.\u0005()).MethodHandle;
				}
				func = (\u000C\u000A.<>c.\u0016 = new Func<Curve, List<XYZ>>(\u000C\u000A.<>c.\u001F.\u001A));
			}
			IEnumerable<List<XYZ>> enumerable = Enumerable.Select<Curve, List<XYZ>>(\u001F, func);
			Func<List<XYZ>, IEnumerable<XYZ>> func2;
			if ((func2 = \u000C\u000A.<>c.\u000B) == null)
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
				func2 = (\u000C\u000A.<>c.\u000B = new Func<List<XYZ>, IEnumerable<XYZ>>(\u000C\u000A.<>c.\u001F.\u000C));
			}
			IEnumerable<XYZ> enumerable2 = Enumerable.SelectMany<List<XYZ>, XYZ>(enumerable, func2);
			Func<XYZ, double> func3;
			if ((func3 = \u000C\u000A.<>c.\u0002) == null)
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
				func3 = (\u000C\u000A.<>c.\u0002 = new Func<XYZ, double>(\u000C\u000A.<>c.\u001F.\u0015));
			}
			double u001F = Enumerable.Min<XYZ>(enumerable2, func3);
			Func<Curve, List<XYZ>> func4;
			if ((func4 = \u000C\u000A.<>c.\u0006) == null)
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
				func4 = (\u000C\u000A.<>c.\u0006 = new Func<Curve, List<XYZ>>(\u000C\u000A.<>c.\u001F.\u0001));
			}
			IEnumerable<List<XYZ>> enumerable3 = Enumerable.Select<Curve, List<XYZ>>(\u001F, func4);
			Func<List<XYZ>, IEnumerable<XYZ>> func5;
			if ((func5 = \u000C\u000A.<>c.\u000F) == null)
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
				func5 = (\u000C\u000A.<>c.\u000F = new Func<List<XYZ>, IEnumerable<XYZ>>(\u000C\u000A.<>c.\u001F.\u0009));
			}
			IEnumerable<XYZ> enumerable4 = Enumerable.SelectMany<List<XYZ>, XYZ>(enumerable3, func5);
			Func<XYZ, double> func6;
			if ((func6 = \u000C\u000A.<>c.\u0012) == null)
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
				func6 = (\u000C\u000A.<>c.\u0012 = new Func<XYZ, double>(\u000C\u000A.<>c.\u001F.\u001F\u000A));
			}
			double u001F2 = Enumerable.Max<XYZ>(enumerable4, func6);
			Func<Curve, List<XYZ>> func7;
			if ((func7 = \u000C\u000A.<>c.\u0003) == null)
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
				func7 = (\u000C\u000A.<>c.\u0003 = new Func<Curve, List<XYZ>>(\u000C\u000A.<>c.\u001F.\u000A\u000A));
			}
			IEnumerable<List<XYZ>> enumerable5 = Enumerable.Select<Curve, List<XYZ>>(\u001F, func7);
			Func<List<XYZ>, IEnumerable<XYZ>> func8;
			if ((func8 = \u000C\u000A.<>c.\u001C) == null)
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
				func8 = (\u000C\u000A.<>c.\u001C = new Func<List<XYZ>, IEnumerable<XYZ>>(\u000C\u000A.<>c.\u001F.\u0007\u000A));
			}
			IEnumerable<XYZ> enumerable6 = Enumerable.SelectMany<List<XYZ>, XYZ>(enumerable5, func8);
			Func<XYZ, double> func9;
			if ((func9 = \u000C\u000A.<>c.\u000D) == null)
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
				func9 = (\u000C\u000A.<>c.\u000D = new Func<XYZ, double>(\u000C\u000A.<>c.\u001F.\u001D\u000A));
			}
			double u000A = Enumerable.Min<XYZ>(enumerable6, func9);
			Func<Curve, List<XYZ>> func10;
			if ((func10 = \u000C\u000A.<>c.\u0010) == null)
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
				func10 = (\u000C\u000A.<>c.\u0010 = new Func<Curve, List<XYZ>>(\u000C\u000A.<>c.\u001F.\u0004\u000A));
			}
			IEnumerable<List<XYZ>> enumerable7 = Enumerable.Select<Curve, List<XYZ>>(\u001F, func10);
			Func<List<XYZ>, IEnumerable<XYZ>> func11;
			if ((func11 = \u000C\u000A.<>c.\u000E) == null)
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
				func11 = (\u000C\u000A.<>c.\u000E = new Func<List<XYZ>, IEnumerable<XYZ>>(\u000C\u000A.<>c.\u001F.\u0019\u000A));
			}
			IEnumerable<XYZ> enumerable8 = Enumerable.SelectMany<List<XYZ>, XYZ>(enumerable7, func11);
			Func<XYZ, double> func12;
			if ((func12 = \u000C\u000A.<>c.\u0008) == null)
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
				func12 = (\u000C\u000A.<>c.\u0008 = new Func<XYZ, double>(\u000C\u000A.<>c.\u001F.\u0018\u000A));
			}
			double u000A2 = Enumerable.Max<XYZ>(enumerable8, func12);
			Line u000A3 = \u0002\u0007\u0007.\u000A(\u001B\u001F\u0007.\u000A(u001F, u000A, 0.0), \u001B\u001F\u0007.\u000A(u001F2, u000A, 0.0));
			Line u000A4 = \u0002\u0007\u0007.\u000A(\u001B\u001F\u0007.\u000A(u001F2, u000A, 0.0), \u001B\u001F\u0007.\u000A(u001F2, u000A2, 0.0));
			Line u000A5 = \u0002\u0007\u0007.\u000A(\u001B\u001F\u0007.\u000A(u001F2, u000A2, 0.0), \u001B\u001F\u0007.\u000A(u001F, u000A2, 0.0));
			Line u000A6 = \u0002\u0007\u0007.\u000A(\u001B\u001F\u0007.\u000A(u001F, u000A2, 0.0), \u001B\u001F\u0007.\u000A(u001F, u000A, 0.0));
			List<Line> list = \u0003\u001D\u0007.\u000A();
			\u000B\u0007\u0007.\u000A(list, u000A3);
			\u000B\u0007\u0007.\u000A(list, u000A4);
			\u000B\u0007\u0007.\u000A(list, u000A5);
			\u000B\u0007\u0007.\u000A(list, u000A6);
			return list;
		}

		// Token: 0x02000778 RID: 1912
		[CompilerGenerated]
		private sealed class \u0014\u000A
		{
			// Token: 0x06004AE9 RID: 19177 RVA: 0x001D7FDC File Offset: 0x001D61DC
			internal bool \u001D(Line \u001F)
			{
				return \u001C\u001D\u0007.\u000A(\u001F, this.\u001F);
			}

			// Token: 0x06004AEA RID: 19178 RVA: 0x001D7FF8 File Offset: 0x001D61F8
			internal bool \u0004(XYZ \u001F)
			{
				return \u0011\u0007\u0007.\u000A(\u001F, \u0013\u001F\u0007.\u0007(this.\u001F, 1), 0.0001);
			}

			// Token: 0x04001E19 RID: 7705
			public Line \u001F;

			// Token: 0x04001E1A RID: 7706
			public Func<Line, bool> \u000A;

			// Token: 0x04001E1B RID: 7707
			public Func<XYZ, bool> \u0007;
		}

		// Token: 0x02000779 RID: 1913
		[CompilerGenerated]
		private sealed class \u0013\u000A
		{
			// Token: 0x06004AEC RID: 19180 RVA: 0x001D8038 File Offset: 0x001D6238
			internal bool \u000A(XYZ \u001F)
			{
				return \u001F != this.\u001F;
			}

			// Token: 0x04001E1C RID: 7708
			public XYZ \u001F;
		}

		// Token: 0x0200077A RID: 1914
		[CompilerGenerated]
		private sealed class \u001A\u000A
		{
			// Token: 0x06004AEE RID: 19182 RVA: 0x001D8068 File Offset: 0x001D6268
			internal bool \u000A(XYZ \u001F)
			{
				return \u0011\u0007\u0007.\u000A(\u001F, this.\u001F, 0.0001);
			}

			// Token: 0x04001E1D RID: 7709
			public XYZ \u001F;
		}
	}
}

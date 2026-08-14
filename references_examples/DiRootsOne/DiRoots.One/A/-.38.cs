using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Media.Media3D;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x0200004D RID: 77
	internal static class \u0017\u000A
	{
		// Token: 0x0600026E RID: 622 RVA: 0x0000D048 File Offset: 0x0000B248
		internal unsafe static bool \u0007(out XYZ \u001F, out XYZ \u000A, XYZ \u0007, XYZ \u001D, XYZ \u0004, XYZ \u0019)
		{
			Vector3D vector3D = \u0014\u0007\u0007.\u000A(\u001D.\u0004(), \u0007.\u0004());
			Vector3D vector3D2 = \u0014\u0007\u0007.\u000A(\u0019.\u0004(), \u0004.\u0004());
			\u001F = \u001B\u0007\u0007.\u000A();
			\u000A = \u001B\u0007\u0007.\u000A();
			double num = \u0017\u0007\u0007.\u000A(vector3D, vector3D);
			double num2 = \u0017\u0007\u0007.\u000A(vector3D, vector3D2);
			double num3 = \u0017\u0007\u0007.\u000A(vector3D2, vector3D2);
			double num4 = num * num3 - num2 * num2;
			if (num4 == 0.0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000A.\u0007(XYZ*, XYZ*, XYZ, XYZ, XYZ, XYZ)).MethodHandle;
				}
				return false;
			}
			Vector3D u000A = \u0014\u0007\u0007.\u000A(\u0007.\u0004(), \u0004.\u0004());
			double num5 = \u0017\u0007\u0007.\u000A(vector3D, u000A);
			double num6 = \u0017\u0007\u0007.\u000A(vector3D2, u000A);
			double u000A2 = (num2 * num6 - num5 * num3) / num4;
			double u000A3 = (num * num6 - num5 * num2) / num4;
			\u001F = \u001B\u000A\u0007.\u000A(\u0007.\u0004(), \u0020\u0007\u0007.\u000A(vector3D, u000A2)).\u0019();
			\u000A = \u001B\u000A\u0007.\u000A(\u0004.\u0004(), \u0020\u0007\u0007.\u000A(vector3D2, u000A3)).\u0019();
			return true;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000D17C File Offset: 0x0000B37C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static double \u001D(XYZ \u001F, XYZ \u000A)
		{
			return \u0011\u001F\u0007.\u000A(\u0013\u0007\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F) - \u000D\u001F\u0007.\u000A(\u000A), 2.0) + \u0013\u0007\u0007.\u000A(\u001C\u001F\u0007.\u000A(\u001F) - \u001C\u001F\u0007.\u000A(\u000A), 2.0) + \u0013\u0007\u0007.\u000A(\u0003\u000A\u0007.\u000A(\u001F) - \u0003\u000A\u0007.\u000A(\u000A), 2.0));
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000D1F8 File Offset: 0x0000B3F8
		internal static List<XYZ> \u0004(Arc \u001F, int \u000A)
		{
			List<XYZ> list = \u000B\u000A\u0007.\u000A();
			for (double num = 1.0; num < (double)(\u000A - 1); num += 1.0)
			{
				double u000A = num / (double)(\u000A - 1);
				\u0005\u000A\u0007.\u000A(list, \u001A\u0007\u0007.\u000A(\u001F, u000A, true));
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000A.\u0004(Arc, int)).MethodHandle;
			}
			return list;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000D258 File Offset: 0x0000B458
		internal unsafe static bool \u0019(out XYZ \u001F, Curve \u000A, Curve \u0007)
		{
			if (!\u000C\u0007\u0007.\u000A(\u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000A.\u0019(XYZ*, Curve, Curve)).MethodHandle;
				}
				\u001F = null;
				return false;
			}
			XYZ u000A = \u0013\u001F\u0007.\u0007(\u000A, 0);
			XYZ u = \u0013\u001F\u0007.\u0007(\u000A, 1);
			XYZ u001D = \u0013\u001F\u0007.\u0007(\u0007, 0);
			XYZ u2 = \u0013\u001F\u0007.\u0007(\u0007, 1);
			return \u0017\u000A.\u0019(out \u001F, u000A, u, u001D, u2);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000D2BC File Offset: 0x0000B4BC
		internal unsafe static bool \u0019(out XYZ \u001F, XYZ \u000A, XYZ \u0007, XYZ \u001D, XYZ \u0004)
		{
			double num = \u001C\u001F\u0007.\u000A(\u0007) - \u001C\u001F\u0007.\u000A(\u000A);
			double num2 = \u000D\u001F\u0007.\u000A(\u000A) - \u000D\u001F\u0007.\u000A(\u0007);
			double num3 = num * \u000D\u001F\u0007.\u000A(\u000A) + num2 * \u001C\u001F\u0007.\u000A(\u000A);
			double num4 = \u001C\u001F\u0007.\u000A(\u0004) - \u001C\u001F\u0007.\u000A(\u001D);
			double num5 = \u000D\u001F\u0007.\u000A(\u001D) - \u000D\u001F\u0007.\u000A(\u0004);
			double num6 = num4 * \u000D\u001F\u0007.\u000A(\u001D) + num5 * \u001C\u001F\u0007.\u000A(\u001D);
			double num7 = num * num5 - num4 * num2;
			if (num7 == 0.0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000A.\u0019(XYZ*, XYZ, XYZ, XYZ, XYZ)).MethodHandle;
				}
				\u001F = \u001B\u001F\u0007.\u000A(double.MaxValue, double.MaxValue, 0.0);
				return false;
			}
			double u001F = (num5 * num3 - num2 * num6) / num7;
			double u000A = (num * num6 - num4 * num3) / num7;
			\u001F = \u001B\u001F\u0007.\u000A(u001F, u000A, 0.0);
			return true;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000D3C4 File Offset: 0x0000B5C4
		internal unsafe static bool \u0018(out XYZ \u001F, out XYZ \u000A, Curve \u0007, Curve \u001D)
		{
			if (!\u000C\u0007\u0007.\u000A(\u0007))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000A.\u0018(XYZ*, XYZ*, Curve, Curve)).MethodHandle;
				}
				\u001F = null;
				\u000A = null;
				return false;
			}
			XYZ u = \u0013\u001F\u0007.\u0007(\u0007, 0);
			XYZ u001D = \u0013\u001F\u0007.\u0007(\u0007, 1);
			XYZ u2 = \u0013\u001F\u0007.\u0007(\u001D, 0);
			XYZ u3 = \u0013\u001F\u0007.\u0007(\u001D, 1);
			return \u0017\u000A.\u0007(out \u001F, out \u000A, u, u001D, u2, u3);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000D42C File Offset: 0x0000B62C
		internal static List<XYZ> \u0005(Arc \u001F, int \u000A)
		{
			List<XYZ> list = \u000B\u000A\u0007.\u000A();
			for (double num = 2.0; num < (double)\u000A; num += 2.0)
			{
				double u000A = num / (double)\u000A;
				\u0005\u000A\u0007.\u000A(list, \u001A\u0007\u0007.\u000A(\u001F, u000A, true));
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000A.\u0005(Arc, int)).MethodHandle;
			}
			return list;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000D488 File Offset: 0x0000B688
		internal static List<XYZ> \u0016(Arc \u001F, int \u000A)
		{
			List<XYZ> list = \u000B\u000A\u0007.\u000A();
			for (double num = 1.0; num < (double)\u000A; num += 2.0)
			{
				double u000A = num / (double)\u000A;
				\u0005\u000A\u0007.\u000A(list, \u001A\u0007\u0007.\u000A(\u001F, u000A, true));
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000A.\u0016(Arc, int)).MethodHandle;
			}
			return list;
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000D4E4 File Offset: 0x0000B6E4
		internal static SketchPlane \u000B(Document \u001F, Arc \u000A)
		{
			XYZ u000A = \u0013\u001F\u0007.\u0007(\u000A, 0);
			Plane u000A2 = \u0001\u0007\u0007.\u000A(\u0012\u0007\u0007.\u000A(\u0013\u000A\u0007.\u000A(\u000A), \u0014\u000A\u0007.\u000A(\u000A)), u000A);
			return \u0015\u0007\u0007.\u000A(\u001F, u000A2);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000D524 File Offset: 0x0000B724
		internal static double[] \u0002(XYZ \u001F, XYZ \u000A, XYZ \u0007)
		{
			double num = \u000D\u001F\u0007.\u000A(\u001F);
			double num2 = \u000D\u001F\u0007.\u000A(\u000A);
			double num3 = \u000D\u001F\u0007.\u000A(\u0007);
			double num4 = \u001C\u001F\u0007.\u000A(\u001F);
			double num5 = \u001C\u001F\u0007.\u000A(\u000A);
			double num6 = \u001C\u001F\u0007.\u000A(\u0007);
			double num7 = \u0003\u000A\u0007.\u000A(\u001F);
			double num8 = \u0003\u000A\u0007.\u000A(\u000A);
			double num9 = \u0003\u000A\u0007.\u000A(\u0007);
			double num10 = num2 - num;
			double num11 = num5 - num4;
			double num12 = num8 - num7;
			double num13 = num3 - num;
			double num14 = num6 - num4;
			double num15 = num9 - num7;
			double num16 = num11 * num15 - num14 * num12;
			double num17 = num13 * num12 - num10 * num15;
			double num18 = num10 * num14 - num11 * num13;
			double num19 = -num16 * num - num17 * num4 - num18 * num7;
			double[] array = \u0003\u0009\u0010.\u001F(4);
			array[0] = num16;
			array[1] = num17;
			array[2] = num18;
			array[3] = num19;
			return array;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000D5F8 File Offset: 0x0000B7F8
		internal static List<XYZ> \u0006(XYZ \u001F, XYZ \u000A, int \u0007)
		{
			List<XYZ> list = \u000B\u000A\u0007.\u000A();
			double num = 0.0;
			if (\u0007 > 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000A.\u0006(XYZ, XYZ, int)).MethodHandle;
				}
				num = 1.0 / ((double)\u0007 - 1.0);
			}
			XYZ u000A = \u001F\u0007\u0007.\u000A(\u000A, \u001F);
			for (int i = 0; i < \u0007; i++)
			{
				\u0005\u000A\u0007.\u000A(list, \u000F\u0007\u0007.\u000A(\u001F, \u0009\u0007\u0007.\u000A((double)i * num, u000A)));
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
			return list;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000D680 File Offset: 0x0000B880
		internal static List<XYZ> \u0006(Line \u001F, int \u000A)
		{
			return \u0017\u000A.\u0006(\u0013\u001F\u0007.\u0007(\u001F, 0), \u0013\u001F\u0007.\u0007(\u001F, 1), \u000A);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000D6A8 File Offset: 0x0000B8A8
		internal static XYZ \u000F(XYZ \u001F, XYZ \u000A, XYZ \u0007, XYZ \u001D)
		{
			XYZ u001F = \u001F\u0007\u0007.\u000A(\u000A, \u001F);
			double num = \u001D\u001D\u0007.\u000A(\u001F\u0007\u0007.\u000A(\u001F, \u001D), \u0007);
			double num2 = \u001D\u001D\u0007.\u000A(u001F, \u0007);
			double num3 = num / num2;
			if (!\u0007\u001D\u0007.\u000A(num3))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000A.\u000F(XYZ, XYZ, XYZ, XYZ)).MethodHandle;
				}
				if (!\u000A\u001D\u0007.\u000A(num3))
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
					if (\u001F\u001D\u0007.\u000A(num3))
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
					}
					else
					{
						XYZ xyz = \u001F\u0007\u0007.\u000A(\u001F, \u0003\u0007\u0007.\u000A(u001F, num3));
						if (\u0017\u000A.\u001D(\u001F, xyz) + \u0017\u000A.\u001D(xyz, \u000A) - \u0017\u000A.\u001D(\u001F, \u000A) > 5E-06)
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
							return null;
						}
						return xyz;
					}
				}
			}
			return null;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000D76C File Offset: 0x0000B96C
		internal static SketchPlane \u0012(Document \u001F, Line \u000A)
		{
			Random u001F = \u0005\u001D\u0007.\u000A();
			XYZ u000A = \u0013\u001F\u0007.\u0007(\u000A, 0);
			XYZ u = \u0013\u001F\u0007.\u0007(\u000A, 1);
			Plane u000A2 = \u0004\u001D\u0007.\u000A(\u0019\u001D\u0007.\u000A(\u000A.\u001D(\u001B\u001F\u0007.\u000A(\u0018\u001D\u0007.\u000A(u001F), \u0018\u001D\u0007.\u000A(u001F), \u0018\u001D\u0007.\u000A(u001F)))), u000A, u);
			return \u0015\u0007\u0007.\u000A(\u001F, u000A2);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000D7D8 File Offset: 0x0000B9D8
		internal static List<XYZ> \u0003(Arc \u001F, int \u000A)
		{
			List<XYZ> list = \u000B\u000A\u0007.\u000A();
			List<XYZ> result;
			try
			{
				for (int i = 0; i < \u000A + 1; i++)
				{
					double u000A = (double)i / (double)\u000A;
					\u0005\u000A\u0007.\u000A(list, \u001A\u0007\u0007.\u000A(\u001F, u000A, true));
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000A.\u0003(Arc, int)).MethodHandle;
				}
				\u0006\u000A\u0007.\u000A(list, \u000F\u000A\u0007.\u000A(list) - 1);
				result = list;
			}
			catch (Exception u000A2)
			{
				\u000D\u0011\u000A.\u0007(\u001E\u000A\u0007.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\SpatialElementViews\\GeometryUtilities.cs", "CalculatePointsOnXYArc");
				result = \u000B\u000A\u0007.\u000A();
			}
			return result;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000D870 File Offset: 0x0000BA70
		internal static bool \u001C(XYZ \u001F, XYZ \u000A)
		{
			double num = \u0016\u001D\u0007.\u000A(\u001D\u001D\u0007.\u000A(\u0007\u000A\u0007.\u000A(\u001F), \u0007\u000A\u0007.\u000A(\u000A)) / (\u0007\u000A\u0007.\u000A(\u001F).\u0002() * \u0007\u000A\u0007.\u000A(\u000A).\u0002()));
			if (\u0008\u001F\u0007.\u000A(num) > \u0017\u000A.\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000A.\u001C(XYZ, XYZ)).MethodHandle;
				}
				if (\u0008\u001F\u0007.\u000A(num - 3.141592653589793) > \u0017\u000A.\u000A)
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
					if (!\u001F\u001D\u0007.\u000A(num))
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
			return true;
		}

		// Token: 0x04000107 RID: 263
		public static double \u001F;

		// Token: 0x04000108 RID: 264
		private static readonly double \u000A = 1E-06;
	}
}

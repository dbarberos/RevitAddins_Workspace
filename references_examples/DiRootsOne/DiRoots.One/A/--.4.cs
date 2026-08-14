using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Media3D;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000053 RID: 83
	internal static class \u0010\u0007
	{
		// Token: 0x060002C2 RID: 706 RVA: 0x00012360 File Offset: 0x00010560
		internal static Vector3D \u001F(this List<XYZ> \u001F)
		{
			Vector3D u001F = \u0014\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, 0).\u0004(), \u0016\u000A\u0007.\u000A(\u001F, 1).\u0004());
			Vector3D u000A = \u0014\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, 1).\u0004(), \u0016\u000A\u0007.\u000A(\u001F, 3).\u0004());
			Vector3D result = \u0003\u0005\u0007.\u000A(u001F, u000A);
			\u0012\u0005\u0007.\u000A(ref result);
			return result;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x000123D0 File Offset: 0x000105D0
		internal static List<XYZ> \u000A(this List<XYZ> \u001F)
		{
			Func<XYZ, XYZ> func;
			if ((func = \u0010\u0007.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(List<XYZ>.\u000A()).MethodHandle;
				}
				func = (\u0010\u0007.<>c.\u000A = new Func<XYZ, XYZ>(\u0010\u0007.<>c.\u001F.\u0007));
			}
			return Enumerable.ToList<XYZ>(Enumerable.Select<XYZ, XYZ>(\u001F, func));
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00012420 File Offset: 0x00010620
		internal static List<Line> \u0007(this IEnumerable<XYZ> \u001F)
		{
			List<Line> list = \u0003\u001D\u0007.\u000A();
			for (int i = 0; i < Enumerable.Count<XYZ>(\u001F) - 1; i++)
			{
				\u000B\u0007\u0007.\u000A(list, \u0002\u0007\u0007.\u000A(Enumerable.ElementAt<XYZ>(\u001F, i), Enumerable.ElementAt<XYZ>(\u001F, i + 1)));
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(IEnumerable<XYZ>.\u0007()).MethodHandle;
			}
			return list;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00012480 File Offset: 0x00010680
		internal static List<XYZ> \u001D(this List<XYZ> \u001F, double \u000A)
		{
			List<XYZ> list = \u000B\u000A\u0007.\u000A();
			int num = \u000F\u000A\u0007.\u000A(\u001F);
			for (int i = 0; i < num; i++)
			{
				int num2 = i - 1;
				if (num2 < 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(List<XYZ>.\u001D(double)).MethodHandle;
					}
					num2 += num;
				}
				int u000A = (i + 1) % num;
				Vector3D u001F;
				\u000E\u0005\u0007.\u000A(ref u001F, \u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, i)) - \u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, num2)), \u001C\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, i)) - \u001C\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, num2)), \u0003\u000A\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, i)) - \u0003\u000A\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, num2)));
				\u0012\u0005\u0007.\u000A(ref u001F);
				u001F = \u0020\u0007\u0007.\u000A(u001F, \u000A);
				Vector3D vector3D = \u0003\u0005\u0007.\u000A(u001F, \u001F.\u001F());
				XYZ u = new Point3D(\u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, num2)) + \u0010\u0005\u0007.\u000A(ref vector3D), \u001C\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, num2)) + \u000D\u0005\u0007.\u000A(ref vector3D), \u0003\u000A\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, num2)) + \u001C\u0005\u0007.\u000A(ref vector3D)).\u0019();
				XYZ u001D = new Point3D(\u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, i)) + \u0010\u0005\u0007.\u000A(ref vector3D), \u001C\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, i)) + \u000D\u0005\u0007.\u000A(ref vector3D), \u0003\u000A\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, i)) + \u001C\u0005\u0007.\u000A(ref vector3D)).\u0019();
				Vector3D u001F2;
				\u000E\u0005\u0007.\u000A(ref u001F2, \u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, u000A)) - \u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, i)), \u001C\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, u000A)) - \u001C\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, i)), \u0003\u000A\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, u000A)) - \u0003\u000A\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, i)));
				\u0012\u0005\u0007.\u000A(ref u001F2);
				u001F2 = \u0020\u0007\u0007.\u000A(u001F2, \u000A);
				Vector3D vector3D2 = \u0003\u0005\u0007.\u000A(u001F2, \u001F.\u001F());
				XYZ u2 = new Point3D(\u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, i)) + \u0010\u0005\u0007.\u000A(ref vector3D2), \u001C\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, i)) + \u000D\u0005\u0007.\u000A(ref vector3D2), \u0003\u000A\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, i)) + \u001C\u0005\u0007.\u000A(ref vector3D2)).\u0019();
				XYZ u3 = new Point3D(\u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, u000A)) + \u0010\u0005\u0007.\u000A(ref vector3D2), \u001C\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, u000A)) + \u000D\u0005\u0007.\u000A(ref vector3D2), \u0003\u000A\u0007.\u000A(\u0016\u000A\u0007.\u000A(\u001F, u000A)) + \u001C\u0005\u0007.\u000A(ref vector3D2)).\u0019();
				XYZ u000A2;
				XYZ xyz;
				\u0017\u000A.\u0007(out u000A2, out xyz, u, u001D, u2, u3);
				\u0005\u000A\u0007.\u000A(list, u000A2);
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
			return list;
		}
	}
}

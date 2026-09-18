using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Media3D;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000054 RID: 84
	internal static class \u000E\u0007
	{
		// Token: 0x060002C6 RID: 710 RVA: 0x00012794 File Offset: 0x00010994
		internal static UV \u000A(this XYZ \u001F)
		{
			return \u0008\u0005\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F), \u001C\u001F\u0007.\u000A(\u001F));
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x000127B8 File Offset: 0x000109B8
		internal static bool \u0007(this XYZ \u001F)
		{
			XYZ u001F = \u0007\u000A\u0007.\u000A(\u001F);
			if (!\u000A\u0004\u0007.\u000A(u001F, \u001B\u0005\u0007.\u000A()))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(XYZ.\u0007()).MethodHandle;
				}
				return \u000A\u0004\u0007.\u000A(u001F, \u0009\u0007\u0007.\u000A(-1.0, \u001B\u0005\u0007.\u000A()));
			}
			return true;
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00012814 File Offset: 0x00010A14
		internal static bool \u001D(this XYZ \u001F, Line \u000A)
		{
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(XYZ.\u001D(Line)).MethodHandle;
				}
				if (\u000A != null)
				{
					double num = \u000D\u001F\u0007.\u000A(\u001F);
					double num2 = \u001C\u001F\u0007.\u000A(\u001F);
					double num3 = \u0003\u000A\u0007.\u000A(\u001F);
					XYZ u001F = \u0013\u001F\u0007.\u0007(\u000A, 0);
					XYZ u001F2 = \u0013\u001F\u0007.\u0007(\u000A, 1);
					double num4 = \u000D\u001F\u0007.\u000A(u001F);
					double num5 = \u001C\u001F\u0007.\u000A(u001F);
					double num6 = \u0003\u000A\u0007.\u000A(u001F);
					double num7 = \u000D\u001F\u0007.\u000A(u001F2);
					double num8 = \u001C\u001F\u0007.\u000A(u001F2);
					double num9 = \u0003\u000A\u0007.\u000A(u001F2);
					double num10 = \u0011\u001F\u0007.\u000A((num7 - num4) * (num7 - num4) + (num8 - num5) * (num8 - num5) + (num9 - num6) * (num9 - num6));
					double num11 = \u0011\u001F\u0007.\u000A((num - num4) * (num - num4) + (num2 - num5) * (num2 - num5) + (num3 - num6) * (num3 - num6));
					double num12 = \u0011\u001F\u0007.\u000A((num7 - num) * (num7 - num) + (num8 - num2) * (num8 - num2) + (num9 - num3) * (num9 - num3));
					return \u0008\u001F\u0007.\u000A(num10 - (num11 + num12)) <= 5E-06;
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
			return false;
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00012940 File Offset: 0x00010B40
		internal static Point3D \u0004(this XYZ \u001F)
		{
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(XYZ.\u0004()).MethodHandle;
				}
				Point3D result;
				\u0001\u0009\u0010.\u001F(ref result);
				return result;
			}
			return new Point3D(\u000D\u001F\u0007.\u000A(\u001F), \u001C\u001F\u0007.\u000A(\u001F), \u0003\u000A\u0007.\u000A(\u001F));
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0001298C File Offset: 0x00010B8C
		internal static XYZ \u0019(this Point3D \u001F)
		{
			return \u001B\u001F\u0007.\u000A(\u0020\u0005\u0007.\u000A(ref \u001F), \u001E\u0005\u0007.\u000A(ref \u001F), \u0011\u0005\u0007.\u000A(ref \u001F));
		}

		// Token: 0x060002CB RID: 715 RVA: 0x000129BC File Offset: 0x00010BBC
		internal static XYZ \u0019(this Vector3D \u001F)
		{
			return \u001B\u001F\u0007.\u000A(\u0010\u0005\u0007.\u000A(ref \u001F), \u000D\u0005\u0007.\u000A(ref \u001F), \u001C\u0005\u0007.\u000A(ref \u001F));
		}

		// Token: 0x060002CC RID: 716 RVA: 0x000129EC File Offset: 0x00010BEC
		internal static XYZ \u0018(this XYZ \u001F)
		{
			return \u001B\u001F\u0007.\u000A(\u0008\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F)), \u0008\u001F\u0007.\u000A(\u001C\u001F\u0007.\u000A(\u001F)), \u0008\u001F\u0007.\u000A(\u0003\u000A\u0007.\u000A(\u001F)));
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00012A30 File Offset: 0x00010C30
		internal static XYZ \u0005(this XYZ \u001F)
		{
			return \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F), \u001C\u001F\u0007.\u000A(\u001F), 0.0);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00012A60 File Offset: 0x00010C60
		internal static XYZ \u0016(this XYZ \u001F, double \u000A)
		{
			return \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F), \u001C\u001F\u0007.\u000A(\u001F), \u000A);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00012A88 File Offset: 0x00010C88
		internal static XYZ \u000B(this XYZ \u001F, List<XYZ> \u000A)
		{
			XYZ xyz = Enumerable.FirstOrDefault<XYZ>(\u000A);
			double num = \u0006\u0007\u0007.\u000A(\u001F, xyz);
			List<XYZ>.Enumerator enumerator = \u0004\u0007\u0007.\u000A(\u000A);
			try
			{
				while (\u000A\u0007\u0007.\u000A(ref enumerator))
				{
					XYZ xyz2 = \u001D\u0007\u0007.\u000A(ref enumerator);
					if (\u0006\u0007\u0007.\u000A(\u001F, xyz2) < num)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(XYZ.\u000B(List<XYZ>)).MethodHandle;
						}
						xyz = xyz2;
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
			return xyz;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00012B14 File Offset: 0x00010D14
		internal static double \u0002(this XYZ \u001F)
		{
			return \u0011\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F) * \u000D\u001F\u0007.\u000A(\u001F) + \u001C\u001F\u0007.\u000A(\u001F) * \u001C\u001F\u0007.\u000A(\u001F) + \u0003\u000A\u0007.\u000A(\u001F) * \u0003\u000A\u0007.\u000A(\u001F));
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00012B60 File Offset: 0x00010D60
		internal static XYZ \u0006(this XYZ \u001F, int \u000A = 5)
		{
			return \u001B\u001F\u0007.\u000A(\u0016\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F), \u000A), \u0016\u001F\u0007.\u000A(\u001C\u001F\u0007.\u000A(\u001F), \u000A), \u0016\u001F\u0007.\u000A(\u0003\u000A\u0007.\u000A(\u001F), \u000A));
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00012BA4 File Offset: 0x00010DA4
		internal static bool \u000F(this XYZ \u001F, XYZ \u000A, double \u0007 = 5.0)
		{
			if (\u0008\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F) - \u000D\u001F\u0007.\u000A(\u000A)) < \u0007)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(XYZ.\u000F(XYZ, double)).MethodHandle;
				}
				if (\u0008\u001F\u0007.\u000A(\u001C\u001F\u0007.\u000A(\u001F) - \u001C\u001F\u0007.\u000A(\u000A)) < \u0007)
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
					return \u0008\u001F\u0007.\u000A(\u0003\u000A\u0007.\u000A(\u001F) - \u0003\u000A\u0007.\u000A(\u000A)) < \u0007;
				}
			}
			return false;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00012C24 File Offset: 0x00010E24
		internal static XYZ \u0012(this XYZ \u001F)
		{
			if (\u000D\u001F\u0007.\u000A(\u001F) < 0.0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(XYZ.\u0012()).MethodHandle;
				}
				if (\u001C\u001F\u0007.\u000A(\u001F) < 0.0)
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
					return \u001B\u001F\u0007.\u000A(-\u000D\u001F\u0007.\u000A(\u001F), -\u001C\u001F\u0007.\u000A(\u001F), \u0003\u000A\u0007.\u000A(\u001F));
				}
			}
			if (\u000D\u001F\u0007.\u000A(\u001F) < 0.0)
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
				if (\u001C\u001F\u0007.\u000A(\u001F) == 0.0)
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
					return \u001B\u001F\u0007.\u000A(-\u000D\u001F\u0007.\u000A(\u001F), \u001C\u001F\u0007.\u000A(\u001F), \u0003\u000A\u0007.\u000A(\u001F));
				}
			}
			if (\u000D\u001F\u0007.\u000A(\u001F) == 0.0)
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
				if (\u001C\u001F\u0007.\u000A(\u001F) < 0.0)
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
					return \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F), -\u001C\u001F\u0007.\u000A(\u001F), \u0003\u000A\u0007.\u000A(\u001F));
				}
			}
			if (\u000D\u001F\u0007.\u000A(\u001F) > 0.0)
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
				if (\u001C\u001F\u0007.\u000A(\u001F) > 0.0)
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
			}
			XYZ result;
			if (\u0008\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F)) > \u0008\u001F\u0007.\u000A(\u001C\u001F\u0007.\u000A(\u001F)))
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
				result = \u001B\u001F\u0007.\u000A(\u0008\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F)), -\u0008\u001F\u0007.\u000A(\u001C\u001F\u0007.\u000A(\u001F)), \u0003\u000A\u0007.\u000A(\u001F));
			}
			else
			{
				result = \u001B\u001F\u0007.\u000A(-\u0008\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u001F)), \u0008\u001F\u0007.\u000A(\u001C\u001F\u0007.\u000A(\u001F)), \u0003\u000A\u0007.\u000A(\u001F));
			}
			return result;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00012E28 File Offset: 0x00011028
		internal static XYZ \u0003(this XYZ \u001F, XYZ \u000A)
		{
			double u000A = \u001D\u001D\u0007.\u000A(\u001F, \u000A);
			return \u0017\u0005\u0007.\u000A(\u0007\u000A\u0007.\u000A(\u000A), u000A);
		}

		// Token: 0x0400010A RID: 266
		public static double \u001F;
	}
}

using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000044 RID: 68
	internal static class \u0012\u000A
	{
		// Token: 0x06000234 RID: 564 RVA: 0x0000B2E8 File Offset: 0x000094E8
		internal static List<XYZ> \u001F(List<XYZ> \u001F, double \u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u000A.\u001F(List<XYZ>, double)).MethodHandle;
				}
				if (\u000F\u000A\u0007.\u000A(\u001F) <= 2)
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
				}
				else
				{
					int num = 0;
					double num2 = 0.0;
					int num3 = \u000F\u000A\u0007.\u000A(\u001F) - 1;
					for (int i = 1; i < num3; i++)
					{
						double num4 = \u0012\u000A.\u0007(\u0016\u000A\u0007.\u000A(\u001F, i), \u0016\u000A\u0007.\u000A(\u001F, 0), \u0016\u000A\u0007.\u000A(\u001F, num3));
						if (num4 > num2)
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
							num2 = num4;
							num = i;
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
					if (num2 > \u000A)
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
						List<XYZ> list = \u000B\u000A\u0007.\u000A();
						List<XYZ> u000A = \u0012\u000A.\u001F(\u0012\u000A\u0007.\u000A(\u001F, 0, num + 1), \u000A);
						List<XYZ> u000A2 = \u0012\u000A.\u001F(\u0012\u000A\u0007.\u000A(\u001F, num, num3 - num + 1), \u000A);
						\u0002\u000A\u0007.\u000A(list, u000A);
						\u0006\u000A\u0007.\u000A(list, \u000F\u000A\u0007.\u000A(list) - 1);
						\u0002\u000A\u0007.\u000A(list, u000A2);
						return list;
					}
					List<XYZ> list2 = \u000B\u000A\u0007.\u000A();
					\u0005\u000A\u0007.\u000A(list2, \u0016\u000A\u0007.\u000A(\u001F, 0));
					\u0005\u000A\u0007.\u000A(list2, \u0016\u000A\u0007.\u000A(\u001F, num3));
					return list2;
				}
			}
			return \u001F;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000B410 File Offset: 0x00009610
		internal static List<XYZ> \u000A(List<XYZ> \u001F)
		{
			List<XYZ> list = \u000B\u000A\u0007.\u000A();
			for (int i = 0; i < \u000F\u000A\u0007.\u000A(\u001F); i++)
			{
				if (i == 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u000A.\u000A(List<XYZ>)).MethodHandle;
					}
					if (!\u0012\u000A.\u0004(\u0016\u000A\u0007.\u000A(\u001F, i), \u0016\u000A\u0007.\u000A(\u001F, \u000F\u000A\u0007.\u000A(\u001F) - 1), \u0016\u000A\u0007.\u000A(\u001F, i + 1)))
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
						\u0005\u000A\u0007.\u000A(list, \u0016\u000A\u0007.\u000A(\u001F, i));
					}
				}
				else if (i == \u000F\u000A\u0007.\u000A(\u001F) - 1)
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
					if (!\u0012\u000A.\u0004(\u0016\u000A\u0007.\u000A(\u001F, i), \u0016\u000A\u0007.\u000A(\u001F, \u000F\u000A\u0007.\u000A(\u001F) - 2), \u0016\u000A\u0007.\u000A(\u001F, 0)))
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
						\u0005\u000A\u0007.\u000A(list, \u0016\u000A\u0007.\u000A(\u001F, i));
					}
				}
				else if (!\u0012\u000A.\u0004(\u0016\u000A\u0007.\u000A(\u001F, i), \u0016\u000A\u0007.\u000A(\u001F, i - 1), \u0016\u000A\u0007.\u000A(\u001F, i + 1)))
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
					\u0005\u000A\u0007.\u000A(list, \u0016\u000A\u0007.\u000A(\u001F, i));
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
			return list;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000B550 File Offset: 0x00009750
		private static double \u0007(XYZ \u001F, XYZ \u000A, XYZ \u0007)
		{
			double num = \u000D\u001F\u0007.\u000A(\u0007) - \u000D\u001F\u0007.\u000A(\u000A);
			double num2 = \u001C\u001F\u0007.\u000A(\u0007) - \u001C\u001F\u0007.\u000A(\u000A);
			if (num == 0.0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u000A.\u0007(XYZ, XYZ, XYZ)).MethodHandle;
				}
				if (num2 == 0.0)
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
					return double.NegativeInfinity;
				}
			}
			double num3 = ((\u000D\u001F\u0007.\u000A(\u001F) - \u000D\u001F\u0007.\u000A(\u000A)) * num + (\u001C\u001F\u0007.\u000A(\u001F) - \u001C\u001F\u0007.\u000A(\u000A)) * num2) / (num * num + num2 * num2);
			if (num3 <= 0.0)
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
				return \u0012\u000A.\u001D(\u001F, \u000A);
			}
			if (num3 >= 1.0)
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
				return \u0012\u000A.\u001D(\u001F, \u0007);
			}
			XYZ u000A = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u000A) + num3 * num, \u001C\u001F\u0007.\u000A(\u000A) + num3 * num2, \u0003\u000A\u0007.\u000A(\u000A));
			return \u0012\u000A.\u001D(\u001F, u000A);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000B664 File Offset: 0x00009864
		private static double \u001D(XYZ \u001F, XYZ \u000A)
		{
			double num = \u000D\u001F\u0007.\u000A(\u001F) - \u000D\u001F\u0007.\u000A(\u000A);
			double num2 = \u001C\u001F\u0007.\u000A(\u001F) - \u001C\u001F\u0007.\u000A(\u000A);
			return \u0011\u001F\u0007.\u000A(num * num + num2 * num2);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000B6A4 File Offset: 0x000098A4
		private static bool \u0004(XYZ \u001F, XYZ \u000A, XYZ \u0007)
		{
			double num = \u001C\u001F\u0007.\u000A(\u000A) - \u001C\u001F\u0007.\u000A(\u001F);
			double num2 = \u000D\u001F\u0007.\u000A(\u000A) - \u000D\u001F\u0007.\u000A(\u001F);
			double num3 = \u001C\u001F\u0007.\u000A(\u0007) - \u001C\u001F\u0007.\u000A(\u000A);
			double num4 = \u000D\u001F\u0007.\u000A(\u0007) - \u000D\u001F\u0007.\u000A(\u000A);
			if (\u0008\u001F\u0007.\u000A(num2 * num3 - num * num4) < 0.001)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u000A.\u0004(XYZ, XYZ, XYZ)).MethodHandle;
				}
				return true;
			}
			return false;
		}
	}
}

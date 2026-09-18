using System;
using System.Collections.Generic;
using System.Linq;
using DiRoots.One.Commons.Interfaces;

namespace A
{
	// Token: 0x02000146 RID: 326
	internal static class \u0013\u0016
	{
		// Token: 0x06000BE1 RID: 3041 RVA: 0x0004C13C File Offset: 0x0004A33C
		public static List<int> \u001F(string \u001F)
		{
			try
			{
				if (!\u001A\u0006\u0007.\u000A(\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0016.\u001F(string)).MethodHandle;
					}
					return \u0013\u0016.\u000A(\u001F);
				}
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Exporter\\PageHandler.cs", "GetPages");
			}
			return \u0017\u000B\u001D.\u000A();
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x0004C1A4 File Offset: 0x0004A3A4
		private static List<int> \u000A(string \u001F)
		{
			List<int> list = \u0017\u000B\u001D.\u000A();
			char[] array = \u001C\u0007\u000E.\u001F(1);
			array[0] = ',';
			string[] array2 = \u0009\u0007\u001D.\u000A(\u001F, array);
			for (int i = 0; i < (int)\u000C\u0007\u000E.\u001F(array2); i++)
			{
				string u001F = \u0003\u000B\u001D.\u0007(array2[i]);
				if (\u000F\u000C\u001D.\u0007(u001F, "-"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0016.\u000A(string)).MethodHandle;
					}
					if (!\u0013\u0016.\u0007(u001F, list))
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
						return \u0017\u000B\u001D.\u000A();
					}
				}
				else
				{
					int u000A;
					if (!\u001C\u0015\u0004.\u000A(u001F, ref u000A))
					{
						return \u0017\u000B\u001D.\u000A();
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
					\u0020\u000B\u001D.\u000A(list, u000A);
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
			IEnumerable<int> enumerable = Enumerable.Distinct<int>(list);
			Func<int, int> func;
			if ((func = \u0013\u0016.<>c.\u000A) == null)
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
				func = (\u0013\u0016.<>c.\u000A = new Func<int, int>(\u0013\u0016.<>c.\u001F.\u001D));
			}
			IEnumerable<int> enumerable2 = Enumerable.Select<int, int>(enumerable, func);
			Func<int, bool> func2;
			if ((func2 = \u0013\u0016.<>c.\u0007) == null)
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
				func2 = (\u0013\u0016.<>c.\u0007 = new Func<int, bool>(\u0013\u0016.<>c.\u001F.\u0004));
			}
			return Enumerable.ToList<int>(Enumerable.Where<int>(enumerable2, func2));
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x0004C2D8 File Offset: 0x0004A4D8
		private static bool \u0007(string \u001F, List<int> \u000A)
		{
			char[] array = \u001C\u0007\u000E.\u001F(1);
			array[0] = '-';
			string[] array2 = \u0009\u0007\u001D.\u000A(\u001F, array);
			if ((int)\u000C\u0007\u000E.\u001F(array2) == 2)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0016.\u0007(string, List<int>)).MethodHandle;
				}
				int num;
				if (\u001C\u0015\u0004.\u000A(\u0003\u000B\u001D.\u0007(array2[0]), ref num))
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
					int num2;
					if (\u001C\u0015\u0004.\u000A(\u0003\u000B\u001D.\u0007(array2[1]), ref num2))
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
						for (int i = num; i <= num2; i++)
						{
							\u0020\u000B\u001D.\u000A(\u000A, i);
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
						return true;
					}
				}
				return false;
			}
			return true;
		}
	}
}

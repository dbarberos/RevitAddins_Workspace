using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x0200008F RID: 143
	internal static class \u0001\u001D
	{
		// Token: 0x06000643 RID: 1603 RVA: 0x00022CE4 File Offset: 0x00020EE4
		internal static int \u001F(string \u001F, DisplayUnit \u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u001D.\u001F(string, DisplayUnit)).MethodHandle;
				}
				return 0;
			}
			int result;
			if (\u000A == 1)
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
				int num;
				int num2;
				if (!\u001F\u001D\u001D.\u000A(\u0009\u001D.\u001D, \u001F, ref num))
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
					num2 = 192;
				}
				else
				{
					num2 = num;
				}
				result = num2;
			}
			else
			{
				char[] array = \u001C\u0007\u000E.\u001F(1);
				array[0] = ':';
				result = \u0015\u0013\u0007.\u000A(Enumerable.LastOrDefault<string>(\u0009\u0007\u001D.\u000A(\u001F, array)));
			}
			return result;
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x00022D64 File Offset: 0x00020F64
		internal static string \u000A(int \u001F, DisplayUnit \u000A)
		{
			\u0001\u001D.\u0015\u001D u0015_u001D = new \u0001\u001D.\u0015\u001D();
			u0015_u001D.\u001F = \u001F;
			string result;
			if (\u000A == 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u001D.\u000A(int, DisplayUnit)).MethodHandle;
				}
				KeyValuePair<string, int> keyValuePair = Enumerable.FirstOrDefault<KeyValuePair<string, int>>(\u0009\u001D.\u001D, new Func<KeyValuePair<string, int>, bool>(u0015_u001D.\u000A));
				result = \u0007\u001D\u001D.\u000A(ref keyValuePair);
			}
			else
			{
				result = \u000A\u001D\u001D.\u000A("1", " : ", u0015_u001D.\u001F);
			}
			return result;
		}

		// Token: 0x020007BE RID: 1982
		[CompilerGenerated]
		private sealed class \u0015\u001D
		{
			// Token: 0x06004C6D RID: 19565 RVA: 0x001DC2C0 File Offset: 0x001DA4C0
			internal bool \u000A(KeyValuePair<string, int> \u001F)
			{
				return \u0003\u0009\u000D.\u000A(ref \u001F) == this.\u001F;
			}

			// Token: 0x04001F81 RID: 8065
			public int \u001F;
		}
	}
}

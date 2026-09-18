using System;
using System.Reflection;

namespace A
{
	// Token: 0x020000F1 RID: 241
	internal static class \u0007\u0011\u0018
	{
		// Token: 0x06000BD5 RID: 3029 RVA: 0x00048604 File Offset: 0x00046804
		public static void \u000C(Type \u000C, string \u0018, object \u0014)
		{
			PropertyInfo propertyInfo = \u000B\u0009\u0016.\u0018(\u000C, \u0018, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (propertyInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0007\u0011\u0018.\u000C(Type, string, object)).MethodHandle;
				}
				return;
			}
			\u0018\u0002\u0016.\u0014(propertyInfo, null, \u0014);
		}
	}
}

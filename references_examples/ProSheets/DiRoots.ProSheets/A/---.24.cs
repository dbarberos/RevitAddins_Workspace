using System;
using System.Reflection;

namespace A
{
	// Token: 0x020000CF RID: 207
	internal static class \u001C\u001F\u0018
	{
		// Token: 0x06000B37 RID: 2871 RVA: 0x00042C40 File Offset: 0x00040E40
		public static \u000C \u000C<\u000C>(object \u000C, string \u0018, \u000C \u0014 = default(\u000C))
		{
			if (\u000C == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u001F\u0018.\u000C(object, string, \u000C)).MethodHandle;
				}
				return \u0014;
			}
			\u000C result;
			try
			{
				PropertyInfo u000C = \u000B\u0009\u0016.\u0018(\u0004\u0017\u0018.\u0014(\u000C), \u0018, BindingFlags.Instance | BindingFlags.Public);
				if (\u001A\u0009\u0016.\u0018(u000C, \u0020\u0010\u000F.\u000C))
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
					result = \u0014;
				}
				else
				{
					object obj = \u001D\u0009\u0016.\u0018(u000C, \u000C);
					if (obj is \u000C)
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
						\u000C u000C2 = (\u000C)((object)obj);
						result = u000C2;
					}
					else
					{
						result = \u001C\u001F\u0018.\u0018<\u000C>(obj, \u0014);
					}
				}
			}
			catch
			{
				result = \u0014;
			}
			return result;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x00042CE0 File Offset: 0x00040EE0
		private static \u000C \u0018<\u000C>(object \u000C, \u000C \u0018)
		{
			if (\u000C == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u001F\u0018.\u0018(object, \u000C)).MethodHandle;
				}
				return \u0018;
			}
			\u000C result;
			try
			{
				Type type = \u000A\u001D\u0018.\u0018(typeof(\u000C).TypeHandle);
				if (\u0006\u0009\u0016.\u0018(type))
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
					if (\u001A\u000F\u0014.\u0018(\u0010\u0009\u0016.\u0018(type), \u000A\u001D\u0018.\u0018(\u000A\u0010\u000F.\u000C())))
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
						type = \u0007\u0009\u0016.\u0018(type);
					}
				}
				result = (\u000C)((object)\u0019\u0009\u0016.\u0018(\u000C, type));
			}
			catch
			{
				result = \u0018;
			}
			return result;
		}
	}
}

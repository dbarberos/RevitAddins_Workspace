using System;
using System.Collections.Generic;
using System.Linq;
using DiRoots.One.SheetLink.Enums;

namespace A
{
	// Token: 0x0200025F RID: 607
	internal static class \u000A\u0010
	{
		// Token: 0x060018A5 RID: 6309 RVA: 0x0009F538 File Offset: 0x0009D738
		internal static Dictionary<string, object> \u001F(Dictionary<string, object> \u001F, Dictionary<string, object> \u000A, bool \u0007)
		{
			Dictionary<string, object> u001F = \u0006\u0014\u0018.\u000A();
			if (\u0007)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0010.\u001F(Dictionary<string, object>, Dictionary<string, object>, bool)).MethodHandle;
				}
				\u001F\u0014\u0018.\u000A(u001F, ParameterSource.Type.\u001F(), 2);
				if (\u000D\u0005\u0005.\u000A(\u000A, ParameterSource.ReadOnly.\u001F()))
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
					\u001F\u0014\u0018.\u000A(u001F, ParameterSource.ReadOnly.\u001F(), 3);
				}
			}
			else
			{
				u001F = \u000A;
			}
			Dictionary<string, object> dictionary = \u0006\u0014\u0018.\u000A();
			Dictionary<string, object>.Enumerator enumerator = \u0009\u0014\u0005.\u000A(\u001F);
			try
			{
				while (\u001A\u0014\u0005.\u000A(ref enumerator))
				{
					KeyValuePair<string, object> keyValuePair = \u0001\u0014\u0005.\u000A(ref enumerator);
					if (Enumerable.Contains<object>(\u001D\u0019\u0005.\u000A(u001F), \u000C\u0014\u0005.\u000A(ref keyValuePair)))
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
						\u001F\u0014\u0018.\u000A(dictionary, \u0015\u0014\u0005.\u000A(ref keyValuePair), \u000C\u0014\u0005.\u000A(ref keyValuePair));
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
				((IDisposable)enumerator).Dispose();
			}
			return dictionary;
		}

		// Token: 0x060018A6 RID: 6310 RVA: 0x0009F63C File Offset: 0x0009D83C
		internal static Dictionary<string, object> \u000A()
		{
			Dictionary<string, object> dictionary = \u0006\u0014\u0018.\u000A();
			\u001F\u0014\u0018.\u000A(dictionary, ParameterSource.Type.\u001F(), 2);
			\u001F\u0014\u0018.\u000A(dictionary, ParameterSource.ReadOnly.\u001F(), 3);
			return dictionary;
		}

		// Token: 0x060018A7 RID: 6311 RVA: 0x0009F678 File Offset: 0x0009D878
		internal static Dictionary<string, object> \u0007()
		{
			Dictionary<string, object> dictionary = \u0006\u0014\u0018.\u000A();
			\u001F\u0014\u0018.\u000A(dictionary, ParameterSource.Instance.\u001F(), 1);
			\u001F\u0014\u0018.\u000A(dictionary, ParameterSource.ReadOnly.\u001F(), 3);
			return dictionary;
		}

		// Token: 0x060018A8 RID: 6312 RVA: 0x0009F6B4 File Offset: 0x0009D8B4
		internal static Dictionary<string, object> \u001D()
		{
			Dictionary<string, object> dictionary = \u0006\u0014\u0018.\u000A();
			\u001F\u0014\u0018.\u000A(dictionary, ParameterSource.Instance.\u001F(), 1);
			\u001F\u0014\u0018.\u000A(dictionary, ParameterSource.Type.\u001F(), 2);
			\u001F\u0014\u0018.\u000A(dictionary, ParameterSource.ReadOnly.\u001F(), 3);
			return dictionary;
		}
	}
}

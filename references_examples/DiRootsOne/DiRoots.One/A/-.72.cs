using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using DiRoots.One.SheetLink.Enums;

namespace A
{
	// Token: 0x02000259 RID: 601
	internal static class \u0014\u000D
	{
		// Token: 0x0600188C RID: 6284 RVA: 0x0009EDC4 File Offset: 0x0009CFC4
		internal static string \u001F(this Enum \u001F)
		{
			return \u0002\u0014\u0005.\u000A(Enumerable.First<MemberInfo>(\u0006\u0014\u0005.\u000A(\u0003\u0011\u000A.\u0007(\u001F), \u001A\u000C\u000A.\u000A(\u001F))).GetCustomAttribute<DisplayAttribute>());
		}

		// Token: 0x0600188D RID: 6285 RVA: 0x0009EE00 File Offset: 0x0009D000
		internal static string \u001F(this ParameterSource \u001F)
		{
			string result;
			if (\u001F != ParameterSource.Type)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterSource.\u001F()).MethodHandle;
				}
				if (\u001F != ParameterSource.ReadOnly)
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
					result = \u001C\u001E\u0005.\u000A();
				}
				else
				{
					result = \u000F\u0014\u0005.\u000A();
				}
			}
			else
			{
				result = \u0003\u001E\u0005.\u000A();
			}
			return result;
		}
	}
}

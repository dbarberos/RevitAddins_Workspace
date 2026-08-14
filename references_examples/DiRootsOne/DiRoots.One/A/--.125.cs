using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DiRoots.One.SheetLink.UI.Controls;

namespace A
{
	// Token: 0x02000223 RID: 547
	internal static class \u0001\u0003
	{
		// Token: 0x06001542 RID: 5442 RVA: 0x0008A508 File Offset: 0x00088708
		public static bool? \u001F(IEnumerable \u001F)
		{
			Func<ICategoryModel, bool> u000A;
			if ((u000A = \u0001\u0003.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u0003.\u001F(IEnumerable)).MethodHandle;
				}
				u000A = (\u0001\u0003.<>c.\u000A = new Func<ICategoryModel, bool>(\u0001\u0003.<>c.\u001F.\u0007));
			}
			return \u0001\u0003.\u001F<ICategoryModel>(\u001F, u000A);
		}

		// Token: 0x06001543 RID: 5443 RVA: 0x0008A550 File Offset: 0x00088750
		public static bool? \u001F<\u001F>(IEnumerable \u001F, Func<\u001F, bool> \u000A)
		{
			List<\u001F> list = Enumerable.ToList<\u001F>(Enumerable.Cast<\u001F>(\u001F));
			bool? result;
			\u001B\u000A\u000E.\u001F(ref result);
			if (Enumerable.Any<\u001F>(list, \u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u0003.\u001F(IEnumerable, Func<\u001F, bool>)).MethodHandle;
				}
				if (Enumerable.All<\u001F>(list, \u000A))
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
					\u0010\u0019\u0005.\u000A(ref result, true);
				}
			}
			else
			{
				\u0010\u0019\u0005.\u000A(ref result, false);
			}
			return result;
		}
	}
}

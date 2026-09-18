using System;
using System.Collections.Generic;
using System.Linq;

namespace A
{
	// Token: 0x020001F0 RID: 496
	internal static class \u0015\u0006
	{
		// Token: 0x060012A3 RID: 4771 RVA: 0x0006B7D0 File Offset: 0x000699D0
		internal static List<List<\u001F>> \u001F<\u001F>(List<\u001F> \u001F, int \u000A)
		{
			List<List<\u001F>> list = new List<List<\u001F>>();
			for (int i = 0; i < \u001F.Count; i += \u000A)
			{
				list.Add(Enumerable.ToList<\u001F>(Enumerable.Take<\u001F>(Enumerable.Skip<\u001F>(\u001F, i), \u000A)));
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0006.\u001F(List<\u001F>, int)).MethodHandle;
			}
			return list;
		}
	}
}

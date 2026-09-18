using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x020000E5 RID: 229
	internal class \u0018\u0011\u0018
	{
		// Token: 0x06000BA4 RID: 2980 RVA: 0x00047278 File Offset: 0x00045478
		public static bool \u000C(Document \u000C, View \u0018)
		{
			\u0018\u0011\u0018.\u000C\u0011\u0018 u000C_u0011_u = new \u0018\u0011\u0018.\u000C\u0011\u0018();
			if (\u0019\u0010\u000F.\u000C(\u0018) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0011\u0018.\u000C(Document, View)).MethodHandle;
				}
				return false;
			}
			IEnumerable<Element> enumerable = \u0013\u0015\u0016.\u0014(\u0009\u0015\u0016.\u0018(\u000C, \u0009\u0002\u0018.\u0018(\u0018)));
			\u0018\u0011\u0018.\u000C\u0011\u0018 u000C_u0011_u2 = u000C_u0011_u;
			List<long> u000C = \u0011\u000C\u0014.\u0018();
			\u001C\u0015\u0016.\u0018(u000C, -2000500L);
			\u001C\u0015\u0016.\u0018(u000C, -2000301L);
			u000C_u0011_u2.\u000C = u000C;
			return \u0012\u001A\u0014.\u0018(Enumerable.ToList<Element>(Enumerable.Where<Element>(enumerable, new Func<Element, bool>(u000C_u0011_u.\u0018)))) == 0;
		}

		// Token: 0x020001DF RID: 479
		[CompilerGenerated]
		private sealed class \u000C\u0011\u0018
		{
			// Token: 0x06001229 RID: 4649 RVA: 0x0005E5A4 File Offset: 0x0005C7A4
			internal bool \u0018(Element \u000C)
			{
				if (\u001B\u0004\u0018.\u0018(\u000C) != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0011\u0018.\u000C\u0011\u0018.\u0018(Element)).MethodHandle;
					}
					return !\u0013\u000E\u0018.\u0018(this.\u000C, \u0018\u0015\u000F.\u0018(\u001B\u0004\u0018.\u0018(\u000C)).\u000C());
				}
				return false;
			}

			// Token: 0x040008AB RID: 2219
			public List<long> \u000C;
		}
	}
}

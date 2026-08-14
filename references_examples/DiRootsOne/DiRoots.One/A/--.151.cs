using System;
using System.Collections;
using System.Collections.Generic;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000286 RID: 646
	internal class \u0002\u000E : IComparer, IComparer<SpatialBaseElement>
	{
		// Token: 0x06001948 RID: 6472 RVA: 0x000A37A0 File Offset: 0x000A19A0
		public \u0002\u000E(bool \u001F)
		{
			this.\u001F = \u001F;
		}

		// Token: 0x06001949 RID: 6473 RVA: 0x000A37BC File Offset: 0x000A19BC
		public int Compare(object x, object y)
		{
			int num;
			if (!this.\u001F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u000E.Compare(object, object)).MethodHandle;
				}
				num = -1;
			}
			else
			{
				num = 1;
			}
			return num * \u000C\u0016\u001D.\u000A(\u0014\u0016\u0005.\u000A(\u0011\u000F\u000E.\u001F(x)), \u0014\u0016\u0005.\u000A(\u0011\u000F\u000E.\u001F(y)));
		}

		// Token: 0x0600194A RID: 6474 RVA: 0x000A3810 File Offset: 0x000A1A10
		public int Compare(SpatialBaseElement x, SpatialBaseElement y)
		{
			int num;
			if (!this.\u001F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u000E.Compare(SpatialBaseElement, SpatialBaseElement)).MethodHandle;
				}
				num = -1;
			}
			else
			{
				num = 1;
			}
			return num * \u000C\u0016\u001D.\u000A(\u0014\u0016\u0005.\u000A(x), \u0014\u0016\u0005.\u000A(y));
		}

		// Token: 0x04000A09 RID: 2569
		private readonly bool \u001F;
	}
}

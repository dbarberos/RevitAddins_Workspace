using System;
using System.Collections;
using System.Collections.Generic;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000285 RID: 645
	internal class \u000B\u000E : IComparer, IComparer<SpatialBaseElement>
	{
		// Token: 0x06001945 RID: 6469 RVA: 0x000A36EC File Offset: 0x000A18EC
		public \u000B\u000E(bool \u001F)
		{
			this.\u001F = \u001F;
		}

		// Token: 0x06001946 RID: 6470 RVA: 0x000A3708 File Offset: 0x000A1908
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u000E.Compare(object, object)).MethodHandle;
				}
				num = -1;
			}
			else
			{
				num = 1;
			}
			return num * \u000C\u0016\u001D.\u000A(\u0013\u0016\u0005.\u0007(\u0011\u000F\u000E.\u001F(x)), \u0013\u0016\u0005.\u0007(\u0011\u000F\u000E.\u001F(y)));
		}

		// Token: 0x06001947 RID: 6471 RVA: 0x000A375C File Offset: 0x000A195C
		public int Compare(SpatialBaseElement x, SpatialBaseElement y)
		{
			int num;
			if (!this.\u001F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u000E.Compare(SpatialBaseElement, SpatialBaseElement)).MethodHandle;
				}
				num = -1;
			}
			else
			{
				num = 1;
			}
			return num * \u000C\u0016\u001D.\u000A(\u0013\u0016\u0005.\u0007(x), \u0013\u0016\u0005.\u0007(y));
		}

		// Token: 0x04000A08 RID: 2568
		private readonly bool \u001F;
	}
}

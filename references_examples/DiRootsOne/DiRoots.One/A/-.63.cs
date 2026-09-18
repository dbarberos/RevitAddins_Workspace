using System;
using System.Collections;
using System.Collections.Generic;
using DiRoots.One.Morta.Model.Base;

namespace A
{
	// Token: 0x020001BE RID: 446
	internal class \u000C\u0006 : IComparer, IComparer<BaseInfo>
	{
		// Token: 0x060010A5 RID: 4261 RVA: 0x00068DE8 File Offset: 0x00066FE8
		public \u000C\u0006(bool \u001F)
		{
			this.\u001F = \u001F;
		}

		// Token: 0x060010A6 RID: 4262 RVA: 0x00068E04 File Offset: 0x00067004
		public int Compare(object x, object y)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0006.Compare(object, object)).MethodHandle;
				}
				num = -1;
			}
			else
			{
				num = 1;
			}
			return num * \u000C\u0016\u001D.\u000A(\u0003\u000A\u0018.\u0007(\u000C\u0016\u000E.\u001F(x)), \u0003\u000A\u0018.\u0007(\u000C\u0016\u000E.\u001F(y)));
		}

		// Token: 0x060010A7 RID: 4263 RVA: 0x00068E58 File Offset: 0x00067058
		public int Compare(BaseInfo x, BaseInfo y)
		{
			int num;
			if (!this.\u001F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0006.Compare(BaseInfo, BaseInfo)).MethodHandle;
				}
				num = -1;
			}
			else
			{
				num = 1;
			}
			return num * \u000C\u0016\u001D.\u000A(\u0003\u000A\u0018.\u0007(x), \u0003\u000A\u0018.\u0007(y));
		}

		// Token: 0x04000695 RID: 1685
		private readonly bool \u001F;
	}
}

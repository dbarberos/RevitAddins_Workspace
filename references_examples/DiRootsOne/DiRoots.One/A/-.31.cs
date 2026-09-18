using System;
using System.Collections.Generic;

namespace A
{
	// Token: 0x02000043 RID: 67
	internal class \u000F\u000A : IEqualityComparer<\u0006\u000A>
	{
		// Token: 0x06000232 RID: 562 RVA: 0x0000B204 File Offset: 0x00009404
		public bool Equals(\u0006\u000A p, \u0006\u000A q)
		{
			if (\u0008\u001F\u0007.\u000A(\u0012\u001F\u0007.\u001D(\u0018\u000A\u0007.\u000A(p)) - \u0012\u001F\u0007.\u001D(\u0018\u000A\u0007.\u000A(q))) <= 1E-05)
			{
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A.Equals(\u0006\u000A, \u0006\u000A)).MethodHandle;
				}
				if (\u0008\u001F\u0007.\u000A(\u0006\u001F\u0007.\u001D(\u0018\u000A\u0007.\u000A(p)) - \u0006\u001F\u0007.\u001D(\u0018\u000A\u0007.\u000A(q))) <= 1E-05)
				{
					for (;;)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					return \u0008\u001F\u0007.\u000A(\u000B\u001F\u0007.\u001D(\u0018\u000A\u0007.\u000A(p)) - \u000B\u001F\u0007.\u001D(\u0018\u000A\u0007.\u000A(q))) <= 1E-05;
				}
			}
			return false;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000B2CC File Offset: 0x000094CC
		public int GetHashCode(\u0006\u000A obj)
		{
			return \u001B\u0013\u000A.\u000A(\u001A\u000C\u000A.\u000A(obj));
		}

		// Token: 0x040000F7 RID: 247
		private static double \u001F;
	}
}

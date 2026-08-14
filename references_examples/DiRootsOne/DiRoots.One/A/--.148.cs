using System;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000281 RID: 641
	internal class \u0018\u000E : \u0016\u000E
	{
		// Token: 0x170006F2 RID: 1778
		// (get) Token: 0x06001938 RID: 6456 RVA: 0x000A356C File Offset: 0x000A176C
		// (set) Token: 0x06001939 RID: 6457 RVA: 0x000A3580 File Offset: 0x000A1780
		public int Value { get; set; }

		// Token: 0x0600193A RID: 6458 RVA: 0x000A3594 File Offset: 0x000A1794
		public override bool \u0018(string \u001F, long \u000A)
		{
			int num;
			bool result = \u001C\u0015\u0004.\u000A(\u001F, ref num);
			if (num < \u0005\u0015\u0005.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u000E.\u0018(string, long)).MethodHandle;
				}
				\u0014\u000C\u0005.\u000A(this, \u0017\u0006\u0007.\u000A(\u001D\u0015\u0005.\u000A(), \u0005\u0015\u0005.\u000A(this)));
				result = false;
			}
			return result;
		}

		// Token: 0x04000A00 RID: 2560
		[CompilerGenerated]
		private int \u000A;
	}
}

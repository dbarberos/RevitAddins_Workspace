using System;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000282 RID: 642
	internal class \u0005\u000E : \u0016\u000E
	{
		// Token: 0x170006F3 RID: 1779
		// (get) Token: 0x0600193C RID: 6460 RVA: 0x000A3604 File Offset: 0x000A1804
		// (set) Token: 0x0600193D RID: 6461 RVA: 0x000A3618 File Offset: 0x000A1818
		public int Value { get; set; }

		// Token: 0x0600193E RID: 6462 RVA: 0x000A362C File Offset: 0x000A182C
		public override bool \u0018(string \u001F, long \u000A)
		{
			int num;
			bool result = \u001C\u0015\u0004.\u000A(\u001F, ref num);
			if (num > \u0016\u0015\u0005.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005\u000E.\u0018(string, long)).MethodHandle;
				}
				\u0014\u000C\u0005.\u000A(this, \u0017\u0006\u0007.\u000A(\u000A\u001F\u0019.\u000A(), \u0016\u0015\u0005.\u000A(this)));
				result = false;
			}
			return result;
		}

		// Token: 0x04000A01 RID: 2561
		[CompilerGenerated]
		private int \u000A;
	}
}

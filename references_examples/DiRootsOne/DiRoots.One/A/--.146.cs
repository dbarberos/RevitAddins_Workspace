using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x0200027F RID: 639
	internal class \u0004\u000E : \u0016\u000E
	{
		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x06001932 RID: 6450 RVA: 0x000A331C File Offset: 0x000A151C
		// (set) Token: 0x06001933 RID: 6451 RVA: 0x000A3330 File Offset: 0x000A1530
		public double Value { get; set; }

		// Token: 0x06001934 RID: 6452 RVA: 0x000A3344 File Offset: 0x000A1544
		public override bool \u0018(string \u001F, long \u000A)
		{
			double num;
			bool result = \u0017\u001B\u0018.\u000A(\u001F, NumberStyles.Any, \u001F\u0015\u000A.\u000A(), ref num);
			if (num > \u0004\u0015\u0005.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u000E.\u0018(string, long)).MethodHandle;
				}
				\u0014\u000C\u0005.\u000A(this, \u0017\u0006\u0007.\u000A(\u000A\u001F\u0019.\u000A(), \u0004\u0015\u0005.\u000A(this)));
				result = false;
			}
			return result;
		}

		// Token: 0x040009FD RID: 2557
		[CompilerGenerated]
		private double \u000A;
	}
}

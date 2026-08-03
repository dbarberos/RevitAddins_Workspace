using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x0200027E RID: 638
	internal class \u001D\u000E : \u0016\u000E
	{
		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x0600192E RID: 6446 RVA: 0x000A3278 File Offset: 0x000A1478
		// (set) Token: 0x0600192F RID: 6447 RVA: 0x000A328C File Offset: 0x000A148C
		public double Value { get; set; }

		// Token: 0x06001930 RID: 6448 RVA: 0x000A32A0 File Offset: 0x000A14A0
		public override bool \u0018(string \u001F, long \u000A)
		{
			double num;
			bool result = \u0017\u001B\u0018.\u000A(\u001F, NumberStyles.Any, \u001F\u0015\u000A.\u000A(), ref num);
			if (num < \u0007\u0015\u0005.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u000E.\u0018(string, long)).MethodHandle;
				}
				\u0014\u000C\u0005.\u000A(this, \u0017\u0006\u0007.\u000A(\u001D\u0015\u0005.\u000A(), \u0007\u0015\u0005.\u000A(this)));
				result = false;
			}
			return result;
		}

		// Token: 0x040009FC RID: 2556
		[CompilerGenerated]
		private double \u000A;
	}
}

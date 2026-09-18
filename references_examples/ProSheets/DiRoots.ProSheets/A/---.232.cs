using System;
using System.Threading.Tasks;

namespace A
{
	// Token: 0x020002CE RID: 718
	internal sealed class \u0002\u0013\u0003 : MulticastDelegate
	{
		// Token: 0x060015AE RID: 5550
		public extern \u0002\u0013\u0003(object, IntPtr);

		// Token: 0x060015AF RID: 5551 RVA: 0x000631CC File Offset: 0x000613CC
		static \u0002\u0013\u0003()
		{
			\u000A\u0017\u0018.\u0007(33555150, 167772269, 16777215);
		}

		// Token: 0x060015B0 RID: 5552
		public extern Task Invoke(Func<Task>);

		// Token: 0x060015B1 RID: 5553 RVA: 0x000631E4 File Offset: 0x000613E4
		public static Task \u0018(Func<Task> \u000C)
		{
			return \u0002\u0013\u0003.\u000C(\u000C);
		}

		// Token: 0x04000A26 RID: 2598
		internal static readonly \u0002\u0013\u0003 \u000C;
	}
}

using System;
using System.Threading.Tasks;

namespace A
{
	// Token: 0x02000495 RID: 1173
	internal sealed class \u0006\u0011\u0016 : MulticastDelegate
	{
		// Token: 0x06001C6D RID: 7277
		public extern \u0006\u0011\u0016(object, IntPtr);

		// Token: 0x06001C6E RID: 7278 RVA: 0x000674B4 File Offset: 0x000656B4
		static \u0006\u0011\u0016()
		{
			\u000A\u0017\u0018.\u0007(33555605, 167772481, 16777215);
		}

		// Token: 0x06001C6F RID: 7279
		public extern Task Invoke(Action);

		// Token: 0x06001C70 RID: 7280 RVA: 0x000674CC File Offset: 0x000656CC
		public static Task \u0018(Action \u000C)
		{
			return \u0006\u0011\u0016.\u000C(\u000C);
		}

		// Token: 0x04000BE1 RID: 3041
		internal static readonly \u0006\u0011\u0016 \u000C;
	}
}

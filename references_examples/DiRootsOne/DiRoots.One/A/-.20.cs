using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace A
{
	// Token: 0x0200001B RID: 27
	internal static class \u001A
	{
		// Token: 0x060000D4 RID: 212 RVA: 0x00004A80 File Offset: 0x00002C80
		internal static Task<\u001F> \u001F<\u001F>(this MethodInfo \u001F, object \u000A, params object[] \u0007)
		{
			\u001A.\u0017<\u001F> u;
			u.\u000A = AsyncTaskMethodBuilder<\u001F>.Create();
			u.\u0007 = \u001F;
			u.\u001D = \u000A;
			u.\u0004 = \u0007;
			u.\u001F = -1;
			u.\u000A.Start<\u001A.\u0017<\u001F>>(ref u);
			return u.\u000A.Task;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00004AD8 File Offset: 0x00002CD8
		internal static Task \u001F(this MethodInfo \u001F, object \u000A, params object[] \u0007)
		{
			\u001A.\u0013 u;
			u.\u000A = \u0008\u0011\u000A.\u000A();
			u.\u0007 = \u001F;
			u.\u001D = \u000A;
			u.\u0004 = \u0007;
			u.\u001F = -1;
			u.\u000A.Start<\u001A.\u0013>(ref u);
			return \u000E\u0011\u000A.\u000A(ref u.\u000A);
		}

		// Token: 0x02000763 RID: 1891
		[CompilerGenerated]
		private static class \u001E<\u001F>
		{
			// Token: 0x04001DAF RID: 7599
			public static CallSite<Func<CallSite, object, object>> \u001F;

			// Token: 0x04001DB0 RID: 7600
			public static CallSite<Func<CallSite, object, object>> \u000A;

			// Token: 0x04001DB1 RID: 7601
			public static CallSite<Func<CallSite, object, \u001F>> \u0007;
		}
	}
}

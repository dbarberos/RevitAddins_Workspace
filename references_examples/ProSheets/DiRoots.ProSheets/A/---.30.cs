using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x020000DF RID: 223
	internal class \u0010\u001F\u0018 : IFailuresProcessor
	{
		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06000B7C RID: 2940 RVA: 0x00046114 File Offset: 0x00044314
		// (set) Token: 0x06000B7D RID: 2941 RVA: 0x00046128 File Offset: 0x00044328
		internal static bool IsEnabled { get; set; }

		// Token: 0x06000B7E RID: 2942 RVA: 0x0004613C File Offset: 0x0004433C
		public void Dismiss(Document document)
		{
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x0004614C File Offset: 0x0004434C
		public FailureProcessingResult ProcessFailures(FailuresAccessor data)
		{
			if (!\u000A\u0011\u0016.\u0018())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010\u001F\u0018.ProcessFailures(FailuresAccessor)).MethodHandle;
				}
				return 0;
			}
			FailureProcessingResult result;
			try
			{
				\u0017\u000D\u0016.\u0018(data);
				result = 0;
			}
			catch (Exception)
			{
				result = 2;
			}
			return result;
		}

		// Token: 0x04000557 RID: 1367
		[CompilerGenerated]
		private static bool \u000C;
	}
}

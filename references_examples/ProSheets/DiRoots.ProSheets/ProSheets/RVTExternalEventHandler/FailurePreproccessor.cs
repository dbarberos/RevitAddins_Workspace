using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;

namespace ProSheets.RVTExternalEventHandler
{
	// Token: 0x020000BE RID: 190
	public class FailurePreproccessor : IFailuresPreprocessor
	{
		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06000A9B RID: 2715 RVA: 0x00040634 File Offset: 0x0003E834
		// (set) Token: 0x06000A9C RID: 2716 RVA: 0x00040648 File Offset: 0x0003E848
		public string TransactionName { get; set; }

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06000A9D RID: 2717 RVA: 0x0004065C File Offset: 0x0003E85C
		// (set) Token: 0x06000A9E RID: 2718 RVA: 0x00040670 File Offset: 0x0003E870
		public string Error { get; set; }

		// Token: 0x06000A9F RID: 2719 RVA: 0x00040684 File Offset: 0x0003E884
		public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
		{
			IList<FailureMessageAccessor> list = \u001B\u000D\u0016.\u0018(failuresAccessor);
			if (\u0001\u000D\u0016.\u0018(list) == 0)
			{
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(FailurePreproccessor.PreprocessFailures(FailuresAccessor)).MethodHandle;
				}
				return 0;
			}
			\u0008\u000D\u0016.\u0018(failuresAccessor);
			IEnumerable<FailureMessageAccessor> enumerable = list;
			Func<FailureMessageAccessor, bool> func;
			if ((func = FailurePreproccessor.<>c.\u0018) == null)
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
				func = (FailurePreproccessor.<>c.\u0018 = new Func<FailureMessageAccessor, bool>(FailurePreproccessor.<>c.\u000C.\u0014));
			}
			if (Enumerable.Any<FailureMessageAccessor>(enumerable, func))
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
				IEnumerator<FailureMessageAccessor> enumerator = \u0006\u000D\u0016.\u0018(list);
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						FailureMessageAccessor failureMessageAccessor = \u0010\u000D\u0016.\u0018(enumerator);
						FailureSeverity failureSeverity = \u0007\u000D\u0016.\u0018(failureMessageAccessor);
						if (\u001A\u000D\u0016.\u0018(\u0019\u000D\u0016.\u0018(failureMessageAccessor), \u000B\u000D\u0016.\u0018()))
						{
							for (;;)
							{
								switch (2)
								{
								case 0:
									continue;
								}
								break;
							}
							return 2;
						}
						if (failureSeverity != 1)
						{
							\u0004\u000D\u0016.\u0018(failureMessageAccessor);
							\u0002\u000D\u0016.\u0018(failureMessageAccessor);
							\u001E\u000D\u0016.\u0018(failuresAccessor, failureMessageAccessor);
							return 1;
						}
						for (;;)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							break;
						}
						\u001D\u000D\u0016.\u0018(failuresAccessor, failureMessageAccessor);
					}
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					return 0;
				}
				finally
				{
					if (enumerator != null)
					{
						for (;;)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
						\u0020\u001E\u0018.\u0018(enumerator);
					}
				}
			}
			\u0017\u000D\u0016.\u0018(failuresAccessor);
			return 1;
		}

		// Token: 0x04000501 RID: 1281
		[CompilerGenerated]
		private string \u000C;

		// Token: 0x04000502 RID: 1282
		[CompilerGenerated]
		private string \u0018;
	}
}

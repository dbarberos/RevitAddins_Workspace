using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x020000F0 RID: 240
	internal class \u001E\u0018 : IFailuresPreprocessor
	{
		// Token: 0x060008C0 RID: 2240 RVA: 0x0003951C File Offset: 0x0003771C
		public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
		{
			IEnumerator<FailureMessageAccessor> enumerator = \u001B\u0005\u0004.\u000A(\u0013\u0017\u0007.\u000A(failuresAccessor));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					FailureMessageAccessor failureMessageAccessor = \u0008\u0005\u0004.\u000A(enumerator);
					if (\u000E\u0005\u0004.\u000A(failureMessageAccessor) == 1)
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
						if (!true)
						{
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0018.PreprocessFailures(FailuresAccessor)).MethodHandle;
						}
						\u0010\u0005\u0004.\u000A(failuresAccessor, failureMessageAccessor);
					}
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
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return 0;
		}
	}
}

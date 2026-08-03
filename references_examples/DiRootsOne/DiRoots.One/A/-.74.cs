using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x0200025B RID: 603
	internal class \u001A\u000D : IFailuresPreprocessor
	{
		// Token: 0x06001890 RID: 6288 RVA: 0x0009EE7C File Offset: 0x0009D07C
		public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
		{
			IList<FailureMessageAccessor> u001F = \u0013\u0017\u0007.\u000A(failuresAccessor);
			if (\u0014\u0017\u0007.\u000A(u001F) == 0)
			{
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u000D.PreprocessFailures(FailuresAccessor)).MethodHandle;
				}
				return 0;
			}
			IEnumerator<FailureMessageAccessor> enumerator = \u001B\u0005\u0004.\u000A(u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					FailureMessageAccessor failureMessageAccessor = \u0008\u0005\u0004.\u000A(enumerator);
					if (\u000E\u0005\u0004.\u000A(failureMessageAccessor) == 1)
					{
						for (;;)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						\u0010\u0005\u0004.\u000A(failuresAccessor, failureMessageAccessor);
					}
				}
				for (;;)
				{
					switch (5)
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
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return 1;
		}
	}
}

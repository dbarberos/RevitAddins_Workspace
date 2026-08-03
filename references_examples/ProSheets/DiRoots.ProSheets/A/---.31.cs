using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x020000E0 RID: 224
	internal class \u0006\u001F\u0018 : IFailuresPreprocessor
	{
		// Token: 0x06000B81 RID: 2945 RVA: 0x000461AC File Offset: 0x000443AC
		public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
		{
			IList<FailureMessageAccessor> u000C = \u001B\u000D\u0016.\u0018(failuresAccessor);
			if (\u0001\u000D\u0016.\u0018(u000C) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0006\u001F\u0018.PreprocessFailures(FailuresAccessor)).MethodHandle;
				}
				return 0;
			}
			IEnumerator<FailureMessageAccessor> enumerator = \u0006\u000D\u0016.\u0018(u000C);
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					FailureMessageAccessor failureMessageAccessor = \u0010\u000D\u0016.\u0018(enumerator);
					try
					{
						FailureDefinitionId u = \u0019\u000D\u0016.\u0018(failureMessageAccessor);
						if (\u0007\u000D\u0016.\u0018(failureMessageAccessor) == 2)
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
							if (\u001A\u000D\u0016.\u0018(\u0020\u0011\u0016.\u0018(), u))
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
								\u001D\u001B\u0014.\u0018(true);
								return 1;
							}
						}
						\u001E\u000D\u0016.\u0018(failuresAccessor, failureMessageAccessor);
					}
					catch (Exception)
					{
						\u001D\u000D\u0016.\u0018(failuresAccessor, failureMessageAccessor);
					}
				}
				for (;;)
				{
					switch (7)
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
			return 1;
		}
	}
}

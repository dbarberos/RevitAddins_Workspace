using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x0200018A RID: 394
	internal class \u0018\u0002 : IFailuresPreprocessor
	{
		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x06000E8A RID: 3722 RVA: 0x0005C400 File Offset: 0x0005A600
		// (set) Token: 0x06000E8B RID: 3723 RVA: 0x0005C414 File Offset: 0x0005A614
		public List<long> FailedIds { get; set; } = new List<long>();

		// Token: 0x06000E8C RID: 3724 RVA: 0x0005C428 File Offset: 0x0005A628
		public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
		{
			IList<FailureMessageAccessor> u001F = \u0013\u0017\u0007.\u000A(failuresAccessor);
			if (\u0014\u0017\u0007.\u000A(u001F) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0002.PreprocessFailures(FailuresAccessor)).MethodHandle;
				}
				return 0;
			}
			bool flag = false;
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
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						\u0010\u0005\u0004.\u000A(failuresAccessor, failureMessageAccessor);
					}
					else if (\u000E\u0005\u0004.\u000A(failureMessageAccessor) == 2)
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
						flag = true;
						if (\u000A\u0008\u0019.\u000A(\u001F\u0008\u0019.\u000A(failureMessageAccessor)) > 0)
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
							IEnumerator<ElementId> enumerator2 = \u000B\u0013\u0007.\u000A(\u001F\u0008\u0019.\u000A(failureMessageAccessor));
							try
							{
								while (\u000A\u0017\u000A.\u000A(enumerator2))
								{
									ElementId u001F2 = \u0016\u0013\u0007.\u000A(enumerator2);
									\u0001\u000E\u0019.\u000A(\u0009\u000E\u0019.\u0007(this), \u000B\u001E\u000A.\u000A(u001F2));
								}
								for (;;)
								{
									switch (1)
									{
									case 0:
										continue;
									}
									break;
								}
							}
							finally
							{
								if (enumerator2 != null)
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
									\u001F\u0017\u000A.\u000A(enumerator2);
								}
							}
						}
					}
				}
				for (;;)
				{
					switch (2)
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
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			if (flag)
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
			return 1;
		}

		// Token: 0x040005BC RID: 1468
		[CompilerGenerated]
		private List<long> \u001F;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x020000E4 RID: 228
	internal static class \u0019\u0018
	{
		// Token: 0x06000887 RID: 2183 RVA: 0x00033FD4 File Offset: 0x000321D4
		private static List<PerformanceAdviserRuleId> \u0007()
		{
			List<PerformanceAdviserRuleId> list = \u000B\u0009\u001D.\u000A();
			IEnumerator<PerformanceAdviserRuleId> enumerator = \u0018\u0009\u001D.\u000A(\u0005\u0009\u001D.\u000A(\u0016\u0009\u001D.\u000A()));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					PerformanceAdviserRuleId performanceAdviserRuleId = \u0019\u0009\u001D.\u000A(enumerator);
					if (\u0008\u0013\u000A.\u000A(\u0004\u0009\u001D.\u0007(performanceAdviserRuleId).ToString(), "e8c63650-70b7-435a-9010-ec97660c1bda"))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0018.\u0007()).MethodHandle;
						}
						\u001D\u0009\u001D.\u000A(list, performanceAdviserRuleId);
					}
				}
				for (;;)
				{
					switch (6)
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
			enumerator = \u0018\u0009\u001D.\u000A(\u0005\u0009\u001D.\u000A(\u0016\u0009\u001D.\u000A()));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					PerformanceAdviserRuleId performanceAdviserRuleId2 = \u0019\u0009\u001D.\u000A(enumerator);
					if (\u0008\u0013\u000A.\u000A(\u0004\u0009\u001D.\u0007(performanceAdviserRuleId2).ToString(), "b341a0f3-a468-4fad-8b26-39237d8486e7"))
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
						\u001D\u0009\u001D.\u000A(list, performanceAdviserRuleId2);
					}
				}
				for (;;)
				{
					switch (3)
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
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return list;
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x00034114 File Offset: 0x00032314
		internal static List<ElementId> \u001D(Document \u001F)
		{
			List<ElementId> list = \u001C\u0013\u000A.\u000A();
			List<PerformanceAdviserRuleId> u = \u0019\u0018.\u0007();
			IList<FailureMessage> u001F = \u0012\u0009\u001D.\u000A(\u0016\u0009\u001D.\u000A(), \u001F, u);
			if (\u000F\u0009\u001D.\u000A(u001F) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0018.\u001D(Document)).MethodHandle;
				}
				\u000F\u0013\u000A.\u000A(list, Enumerable.ToList<ElementId>(\u0002\u0009\u001D.\u000A(\u0006\u0009\u001D.\u000A(u001F, 0))));
			}
			return list;
		}

		// Token: 0x04000355 RID: 853
		private static string \u001F;

		// Token: 0x04000356 RID: 854
		private static string \u000A;
	}
}

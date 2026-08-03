using System;
using System.Collections.Generic;
using System.Threading;
using DiRoots.One.Commons;
using ProSheets.ScheduleAssistant.Model;

namespace A
{
	// Token: 0x020000B8 RID: 184
	internal static class \u0004\u0020\u0018
	{
		// Token: 0x06000A57 RID: 2647 RVA: 0x0003EA58 File Offset: 0x0003CC58
		internal static void \u000C()
		{
			ParameterizedThreadStart u000C;
			if ((u000C = \u0004\u0020\u0018.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0020\u0018.\u000C()).MethodHandle;
				}
				u000C = (\u0004\u0020\u0018.<>c.\u0018 = new ParameterizedThreadStart(\u0004\u0020\u0018.<>c.\u000C.\u0014));
			}
			\u000D\u0011\u0014.\u0018(\u001C\u0011\u0014.\u0018(u000C));
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x0003EAA4 File Offset: 0x0003CCA4
		private static void \u0018()
		{
			\u0004\u0020\u0018.\u0014<SchedulerTimer>(\u001D\u0020\u0018.\u0014());
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x0003EAC0 File Offset: 0x0003CCC0
		private static void \u0014<\u000C>(string \u000C)
		{
			try
			{
				if (!\u0012\u0006\u0018.\u0018(\u000C))
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0020\u0018.\u0014(string)).MethodHandle;
					}
				}
				else
				{
					IEnumerator<string> enumerator = \u0013\u0004\u0018.\u0018(\u0002\u0012\u0016.\u0018(\u000C, "*.xml"));
					try
					{
						while (\u001F\u001E\u0018.\u0018(enumerator))
						{
							string text = \u001C\u0004\u0018.\u0018(enumerator);
							try
							{
								if (XMLUtility.DeserialiseInfo<\u000C>(text) == null)
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
									\u000C\u0020\u0014.\u0018(text);
								}
							}
							catch
							{
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
								switch (3)
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
			}
			catch
			{
			}
		}
	}
}

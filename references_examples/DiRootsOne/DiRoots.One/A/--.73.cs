using System;
using System.Collections.Generic;

namespace A
{
	// Token: 0x02000126 RID: 294
	internal static class \u0001\u0005
	{
		// Token: 0x06000B19 RID: 2841 RVA: 0x0004733C File Offset: 0x0004553C
		internal static bool \u001F<\u001F>(List<\u001F> \u001F, List<\u001F> \u000A, Func<\u001F, \u001F, bool> \u0007)
		{
			if (\u001F == \u000A)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u0005.\u001F(List<\u001F>, List<\u001F>, Func<\u001F, \u001F, bool>)).MethodHandle;
				}
				return true;
			}
			if (\u001F != null)
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
				if (\u000A == null)
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
				}
				else
				{
					if (\u001F.Count != \u000A.Count)
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
						return false;
					}
					for (int i = 0; i < \u001F.Count; i++)
					{
						if (!\u0007(\u001F[i], \u000A[i]))
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
							return false;
						}
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
					return true;
				}
			}
			int num;
			if (\u001F == null)
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
				num = 0;
			}
			else
			{
				num = \u001F.Count;
			}
			int num2;
			if (\u000A == null)
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
				num2 = 0;
			}
			else
			{
				num2 = \u000A.Count;
			}
			return num == num2;
		}
	}
}

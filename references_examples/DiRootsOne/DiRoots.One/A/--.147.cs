using System;
using System.Collections.Generic;

namespace A
{
	// Token: 0x02000280 RID: 640
	internal class \u0019\u000E : \u0016\u000E
	{
		// Token: 0x06001935 RID: 6453 RVA: 0x000A33AC File Offset: 0x000A15AC
		public \u0019\u000E()
		{
			List<\u0016\u000E> list = new List<\u0016\u000E>();
			\u0018\u000E u0018_u000E = new \u0018\u000E();
			\u000C\u000C\u0005.\u000A(u0018_u000E, -1005436L);
			\u0018\u0015\u0005.\u000A(u0018_u000E, 1);
			\u0013\u000C\u0005.\u000A(list, u0018_u000E);
			\u0005\u000E u0005_u000E = new \u0005\u000E();
			\u000C\u000C\u0005.\u000A(u0005_u000E, -1005436L);
			\u0019\u0015\u0005.\u000A(u0005_u000E, 6);
			\u0013\u000C\u0005.\u000A(list, u0005_u000E);
			\u0018\u000E u0018_u000E2 = new \u0018\u000E();
			\u000C\u000C\u0005.\u000A(u0018_u000E2, -1140335L);
			\u0018\u0015\u0005.\u000A(u0018_u000E2, -1);
			\u0013\u000C\u0005.\u000A(list, u0018_u000E2);
			\u0005\u000E u0005_u000E2 = new \u0005\u000E();
			\u000C\u000C\u0005.\u000A(u0005_u000E2, -1140335L);
			\u0019\u0015\u0005.\u000A(u0005_u000E2, 4);
			\u0013\u000C\u0005.\u000A(list, u0005_u000E2);
			this.\u0007 = list;
			\u0005\u000E u0005_u000E3 = new \u0005\u000E();
			\u0019\u0015\u0005.\u000A(u0005_u000E3, int.MaxValue);
			this.\u001D = u0005_u000E3;
			base..ctor();
		}

		// Token: 0x06001936 RID: 6454 RVA: 0x000A3458 File Offset: 0x000A1658
		public override bool \u0018(string \u001F, long \u000A)
		{
			long num;
			bool flag = \u0009\u0006\u0018.\u000A(\u001F, ref num);
			if (!flag)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u000E.\u0018(string, long)).MethodHandle;
				}
				\u0014\u000C\u0005.\u000A(this, \u001F\u001F\u0019.\u000A());
			}
			else
			{
				List<\u0016\u000E>.Enumerator enumerator = \u000A\u0015\u0005.\u000A(this.\u0007);
				try
				{
					while (\u0001\u000C\u0005.\u000A(ref enumerator))
					{
						\u0016\u000E u0016_u000E = \u001F\u0015\u0005.\u000A(ref enumerator);
						if (\u000A == \u0009\u000C\u0005.\u000A(u0016_u000E))
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
							if (!u0016_u000E.\u0018(\u001F, \u000A))
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
								\u0014\u000C\u0005.\u000A(this, \u001C\u0003\u0018.\u000A(u0016_u000E));
								return false;
							}
						}
						else if (!this.\u001D.\u0018(\u001F, \u000A))
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
							\u0014\u000C\u0005.\u000A(this, \u001C\u0003\u0018.\u000A(u0016_u000E));
							return false;
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
					((IDisposable)enumerator).Dispose();
				}
			}
			return flag;
		}

		// Token: 0x040009FE RID: 2558
		private readonly List<\u0016\u000E> \u0007;

		// Token: 0x040009FF RID: 2559
		private readonly \u0005\u000E \u001D;
	}
}

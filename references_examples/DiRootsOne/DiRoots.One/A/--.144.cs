using System;
using System.Collections.Generic;
using System.Globalization;

namespace A
{
	// Token: 0x0200027D RID: 637
	internal class \u0007\u000E : \u0016\u000E
	{
		// Token: 0x0600192B RID: 6443 RVA: 0x000A311C File Offset: 0x000A131C
		public \u0007\u000E()
		{
			List<\u0016\u000E> u001F = new List<\u0016\u000E>();
			\u001D\u000E u001D_u000E = new \u001D\u000E();
			\u000C\u000C\u0005.\u000A(u001D_u000E, -1005435L);
			\u0015\u000C\u0005.\u000A(u001D_u000E, 0.1);
			\u0013\u000C\u0005.\u000A(u001F, u001D_u000E);
			\u0004\u000E u0004_u000E = new \u0004\u000E();
			\u000C\u000C\u0005.\u000A(u0004_u000E, -1005435L);
			\u001A\u000C\u0005.\u000A(u0004_u000E, 0.95);
			\u0013\u000C\u0005.\u000A(u001F, u0004_u000E);
			this.\u001F = u001F;
			base..ctor();
		}

		// Token: 0x0600192C RID: 6444 RVA: 0x000A3188 File Offset: 0x000A1388
		public override bool \u0018(string \u001F, long \u000A)
		{
			double num;
			bool flag = \u0017\u001B\u0018.\u000A(\u001F, NumberStyles.Any, \u001F\u0015\u000A.\u000A(), ref num);
			if (!flag)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0007\u000E.\u0018(string, long)).MethodHandle;
				}
				\u0014\u000C\u0005.\u000A(this, \u001F\u001F\u0019.\u000A());
			}
			else
			{
				List<\u0016\u000E>.Enumerator enumerator = \u000A\u0015\u0005.\u000A(this.\u001F);
				try
				{
					while (\u0001\u000C\u0005.\u000A(ref enumerator))
					{
						\u0016\u000E u0016_u000E = \u001F\u0015\u0005.\u000A(ref enumerator);
						if (\u000A == \u0009\u000C\u0005.\u000A(u0016_u000E))
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
					((IDisposable)enumerator).Dispose();
				}
			}
			return flag;
		}

		// Token: 0x040009FB RID: 2555
		private readonly List<\u0016\u000E> \u001F;
	}
}

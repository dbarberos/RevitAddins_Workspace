using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000048 RID: 72
	internal class \u000E\u000A
	{
		// Token: 0x0600024D RID: 589 RVA: 0x0000BBFC File Offset: 0x00009DFC
		private \u000E\u000A()
		{
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600024E RID: 590 RVA: 0x0000BC10 File Offset: 0x00009E10
		internal static \u000E\u000A \u000A
		{
			get
			{
				if (\u000E\u000A.\u001F == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u000A.get_\u000A()).MethodHandle;
					}
					\u000E\u000A.\u001F = new \u000E\u000A();
				}
				return \u000E\u000A.\u001F;
			}
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000BC48 File Offset: 0x00009E48
		private int \u0007(UV \u001F, UV \u000A)
		{
			if (\u0016\u0007\u0007.\u000A(\u001F) > \u0016\u0007\u0007.\u000A(\u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u000A.\u0007(UV, UV)).MethodHandle;
				}
				if (\u0005\u0007\u0007.\u000A(\u001F) <= \u0005\u0007\u0007.\u000A(\u000A))
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
					return 3;
				}
				return 0;
			}
			else
			{
				if (\u0005\u0007\u0007.\u000A(\u001F) <= \u0005\u0007\u0007.\u000A(\u000A))
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
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000BCBC File Offset: 0x00009EBC
		private double \u001D(UV \u001F, UV \u000A, double \u0007)
		{
			return \u0016\u0007\u0007.\u000A(\u000A) - (\u0005\u0007\u0007.\u000A(\u000A) - \u0007) * ((\u0016\u0007\u0007.\u000A(\u001F) - \u0016\u0007\u0007.\u000A(\u000A)) / (\u0005\u0007\u0007.\u000A(\u001F) - \u0005\u0007\u0007.\u000A(\u000A)));
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000BD00 File Offset: 0x00009F00
		private unsafe void \u0004(ref int \u001F, UV \u000A, UV \u0007, UV \u001D)
		{
			switch (\u001F)
			{
			case -3:
				\u001F = 1;
				return;
			case -2:
			case 2:
				if (this.\u001D(\u000A, \u0007, \u0005\u0007\u0007.\u000A(\u001D)) > \u0016\u0007\u0007.\u000A(\u001D))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u000A.\u0004(int*, UV, UV, UV)).MethodHandle;
					}
					\u001F = -\u001F;
				}
				break;
			case -1:
			case 0:
			case 1:
				break;
			case 3:
				\u001F = -1;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000BD74 File Offset: 0x00009F74
		public bool \u0019(List<XYZ> \u001F, XYZ \u000A)
		{
			\u0010\u000A u001F = new \u0010\u000A(\u001F);
			return this.\u0018(u001F, \u000A.\u000A());
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000BD9C File Offset: 0x00009F9C
		public bool \u0018(\u0010\u000A \u001F, UV \u000A)
		{
			int num = this.\u0007(\u001F.\u000A(0), \u000A);
			int num2 = 0;
			int u = \u001F.\u0007;
			for (int i = 0; i < u; i++)
			{
				UV u000A = \u001F.\u000A(i);
				int u001F;
				if (i + 1 >= u)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u000A.\u0018(\u0010\u000A, UV)).MethodHandle;
					}
					u001F = 0;
				}
				else
				{
					u001F = i + 1;
				}
				UV uv = \u001F.\u000A(u001F);
				int num3 = this.\u0007(uv, \u000A);
				int num4 = num3 - num;
				this.\u0004(ref num4, u000A, uv, \u000A);
				num2 += num4;
				num = num3;
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
			if (num2 != 4)
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
				return num2 == -4;
			}
			return true;
		}

		// Token: 0x040000FE RID: 254
		private static \u000E\u000A \u001F;
	}
}

using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x0200004A RID: 74
	internal abstract class \u001E\u000A
	{
		// Token: 0x06000266 RID: 614 RVA: 0x0000CC28 File Offset: 0x0000AE28
		protected \u001E\u000A()
		{
			this.\u001D = new List<XYZ>();
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000267 RID: 615 RVA: 0x0000CC48 File Offset: 0x0000AE48
		public List<XYZ> \u0010
		{
			get
			{
				return this.\u001D;
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000CC5C File Offset: 0x0000AE5C
		public XYZ \u000E()
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			int i = 0;
			int u000A = \u000F\u000A\u0007.\u000A(this.\u001D) - 1;
			while (i < \u000F\u000A\u0007.\u000A(this.\u001D))
			{
				double num7 = \u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i)) * \u001C\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, u000A)) - \u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, u000A)) * \u001C\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i));
				num += num7;
				num3 += (\u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i)) + \u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, u000A))) * num7;
				num5 += (\u001C\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, i)) + \u001C\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, u000A))) * num7;
				u000A = i++;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u000A.\u000E()).MethodHandle;
			}
			int j = 0;
			int u000A2 = \u000F\u000A\u0007.\u000A(this.\u001D) - 1;
			while (j < \u000F\u000A\u0007.\u000A(this.\u001D))
			{
				double num8 = \u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, j)) * \u0003\u000A\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, u000A2)) - \u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, u000A2)) * \u0003\u000A\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, j));
				num2 += num8;
				num4 += (\u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, j)) + \u000D\u001F\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, u000A2))) * num8;
				num6 += (\u0003\u000A\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, j)) + \u0003\u000A\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, u000A2))) * num8;
				u000A2 = j++;
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
			if (\u0008\u001F\u0007.\u000A(num) >= 1.0000000116860974E-07)
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
				if (\u0008\u001F\u0007.\u000A(num2) >= 1.0000000116860974E-07)
				{
					num *= 3.0;
					num2 *= 3.0;
					return \u001B\u001F\u0007.\u000A(num3 / num, num5 / num, num6 / num2);
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
			return \u001B\u0007\u0007.\u000A();
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000CF30 File Offset: 0x0000B130
		public XYZ \u0008()
		{
			object u001F = \u001F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, 0), \u0016\u000A\u0007.\u000A(this.\u001D, 1));
			XYZ u000A = \u001F\u0007\u0007.\u000A(\u0016\u000A\u0007.\u000A(this.\u001D, 1), \u0016\u000A\u0007.\u000A(this.\u001D, 3));
			return \u0007\u000A\u0007.\u000A(\u0012\u0007\u0007.\u000A(u001F, u000A));
		}

		// Token: 0x04000101 RID: 257
		protected List<XYZ> \u001D;
	}
}

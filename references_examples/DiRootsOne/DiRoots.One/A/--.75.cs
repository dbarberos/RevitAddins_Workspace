using System;
using System.Drawing;

namespace A
{
	// Token: 0x0200012C RID: 300
	internal static class \u0007\u0016
	{
		// Token: 0x06000B78 RID: 2936 RVA: 0x00048400 File Offset: 0x00046600
		internal static double \u001F(double \u001F, double \u000A, bool \u0007 = false)
		{
			double num = \u001F / \u000A;
			double num2;
			if (!\u0007)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0007\u0016.\u001F(double, double, bool)).MethodHandle;
				}
				num2 = \u000F\u0014\u0007.\u000A(num * 25.4);
			}
			else
			{
				num2 = num * 25.4;
			}
			return num2 / 304.8;
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x00048450 File Offset: 0x00046650
		internal static float \u000A(bool \u001F)
		{
			Graphics graphics = \u0008\u001A\u001D.\u000A(IntPtr.Zero);
			float result;
			try
			{
				float num;
				if (!\u001F)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0007\u0016.\u000A(bool)).MethodHandle;
					}
					num = \u000E\u0014\u0004.\u000A(graphics);
				}
				else
				{
					num = \u0010\u0014\u0004.\u000A(graphics);
				}
				result = num;
			}
			finally
			{
				if (graphics != null)
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
					\u001F\u0017\u000A.\u000A(graphics);
				}
			}
			return result;
		}

		// Token: 0x06000B7A RID: 2938 RVA: 0x000484BC File Offset: 0x000466BC
		internal static int \u0007(int \u001F, float \u000A)
		{
			float num = \u0007\u0016.\u000A(true);
			float num2 = \u000A / num;
			return (int)((float)\u001F * num2);
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x000484DC File Offset: 0x000466DC
		internal static int \u001D(int \u001F, float \u000A)
		{
			float num = \u0007\u0016.\u000A(false);
			float num2 = \u000A / num;
			return (int)((float)\u001F * num2);
		}
	}
}

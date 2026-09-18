using System;
using System.Drawing;

namespace A
{
	// Token: 0x0200012F RID: 303
	internal static class \u0019\u0016
	{
		// Token: 0x06000B84 RID: 2948 RVA: 0x000488FC File Offset: 0x00046AFC
		public static void \u001F(Image \u001F, int \u000A, \u0020\u0019 \u0007, bool \u001D = false)
		{
			Bitmap bitmap = \u0018\u0013\u0004.\u000A(\u001F);
			try
			{
				\u0019\u0016.\u001F(bitmap, \u000A, \u0007, \u001D);
			}
			finally
			{
				if (bitmap != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0016.\u001F(Image, int, \u0020\u0019, bool)).MethodHandle;
					}
					\u001F\u0017\u000A.\u000A(bitmap);
				}
			}
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x0004894C File Offset: 0x00046B4C
		public static void \u001F(Bitmap \u001F, int \u000A, \u0020\u0019 \u0007, bool \u001D = false)
		{
			string u000A = \u001B\u0015\u001D.\u000A(\u0006\u0015\u001D.\u000A(), \u0002\u0013\u000A.\u000A("TableGen_Import", \u0006\u0013\u0004.\u000A(), ".png"));
			\u0002\u0013\u0004.\u000A(\u001F, (float)\u000A, (float)\u000A);
			\u0015\u000C\u001D.\u000A(\u001F, u000A, \u0001\u000C\u001D.\u000A());
			\u001B\u0005 u001B_u = new \u001B\u0005();
			\u000A\u0001\u001D.\u000A(u001B_u, u000A);
			\u000B\u0013\u0004.\u000A(u001B_u, (double)\u000A);
			\u0017\u0015\u001D.\u000A(u001B_u, \u0007\u0016.\u001F((double)\u0016\u0013\u0004.\u000A(\u001F), (double)\u000A, \u001D));
			\u001E\u0015\u001D.\u000A(u001B_u, \u0007\u0016.\u001F((double)\u0005\u0013\u0004.\u000A(\u001F), (double)\u000A, \u001D));
			\u000C\u000C\u001D.\u000A(\u0012\u0007\u0004.\u000A(\u0007), u001B_u);
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x000489F0 File Offset: 0x00046BF0
		public static Bitmap \u000A(Image \u001F, int \u000A)
		{
			int num = \u0007\u0016.\u0007(\u0016\u0013\u0004.\u000A(\u001F), (float)\u000A);
			int num2 = \u0007\u0016.\u001D(\u0005\u0013\u0004.\u000A(\u001F), (float)\u000A);
			Bitmap bitmap = \u000A\u0002\u001D.\u000A(num, num2);
			\u0002\u0013\u0004.\u000A(bitmap, (float)\u000A, (float)\u000A);
			Graphics graphics = \u001C\u0013\u0004.\u000A(bitmap);
			try
			{
				\u0012\u0013\u0004.\u000A(graphics, \u0003\u0013\u0004.\u000A());
				\u000F\u0013\u0004.\u000A(graphics, \u001F, new Rectangle(0, 0, num, num2));
			}
			finally
			{
				if (graphics != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0016.\u000A(Image, int)).MethodHandle;
					}
					\u001F\u0017\u000A.\u000A(graphics);
				}
			}
			return bitmap;
		}
	}
}

using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x020000E8 RID: 232
	internal static class \u0002\u0018
	{
		// Token: 0x06000893 RID: 2195 RVA: 0x00034600 File Offset: 0x00032800
		internal static double \u0019(double \u001F)
		{
			return \u001F * 0.26458333;
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x00034618 File Offset: 0x00032818
		internal static double \u0018(double \u001F)
		{
			return \u001F * 0.75 / 72.0 * 256.0 / 256.0 * 25.4;
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00034658 File Offset: 0x00032858
		internal static double \u0005(double \u001F)
		{
			return \u0002\u0018.\u0018(\u001F) / 25.4 / 12.0;
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00034684 File Offset: 0x00032884
		internal static double \u0016(double \u001F)
		{
			return \u001F * 0.85;
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x0003469C File Offset: 0x0003289C
		internal static double \u0018(IFont \u001F, string \u000A)
		{
			FontFamily u001F = \u0002\u0018.\u0006(\u001F);
			double num = (double)\u0007\u001F\u0004.\u000A(u001F, FontStyle.Regular);
			int num2 = \u000A\u001F\u0004.\u000A(u001F, FontStyle.Regular);
			double num3 = \u001E\u0017\u001D.\u000A(\u001F) * (double)num2 / num;
			int num4 = \u001F\u001F\u0004.\u000A(u001F, FontStyle.Regular);
			double num5 = \u001E\u0017\u001D.\u000A(\u001F) * (double)num4 / num;
			\u0009\u0009\u001D.\u000A(u001F, FontStyle.Regular);
			\u000E\u001A\u001D.\u000A(\u0008\u001A\u001D.\u000A(IntPtr.Zero), \u000A, \u0001\u0009\u001D.\u000A(u001F, (float)\u001E\u0017\u001D.\u000A(\u001F)));
			return num3 + num5 / 2.0;
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x0003472C File Offset: 0x0003292C
		internal static double \u000B(double \u001F)
		{
			return 8.43 * \u001F * 0.26458333;
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x00034750 File Offset: 0x00032950
		internal static double \u0002(double \u001F)
		{
			double result = 0.1;
			double num = 0.1;
			double num2 = 0.02646;
			do
			{
				if (num2 <= \u001F)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0018.\u0002(double)).MethodHandle;
					}
					result = num;
				}
				num += 0.1;
				num2 += 0.02646;
			}
			while (num2 <= \u001F);
			for (;;)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			return result;
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x000347BC File Offset: 0x000329BC
		internal static FontFamily \u0006(IFont \u001F)
		{
			\u0002\u0018.\u000B\u0018 u000B_u = new \u0002\u0018.\u000B\u0018();
			u000B_u.\u001F = \u001F;
			if (\u0011\u001A\u001D.\u000A(u000B_u.\u001F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0018.\u0006(IFont)).MethodHandle;
				}
				return \u001E\u001A\u001D.\u000A("Calibri");
			}
			FontFamily fontFamily = Enumerable.FirstOrDefault<FontFamily>(\u0017\u001A\u001D.\u000A(\u0013\u001A\u001D.\u000A()), new Func<FontFamily, bool>(u000B_u.\u000A));
			if (fontFamily == null)
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
				fontFamily = Enumerable.FirstOrDefault<FontFamily>(\u0017\u001A\u001D.\u000A(\u0014\u001A\u001D.\u000A()), new Func<FontFamily, bool>(u000B_u.\u0007));
			}
			if (fontFamily == null)
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
				fontFamily = \u001E\u001A\u001D.\u000A("Calibri");
			}
			return fontFamily;
		}

		// Token: 0x04000357 RID: 855
		public static double \u001F;

		// Token: 0x04000358 RID: 856
		private static double \u000A;

		// Token: 0x04000359 RID: 857
		private static double \u0007;

		// Token: 0x0400035A RID: 858
		private static double \u001D;

		// Token: 0x0400035B RID: 859
		private static double \u0004;

		// Token: 0x020007EF RID: 2031
		[CompilerGenerated]
		private sealed class \u000B\u0018
		{
			// Token: 0x06004D1E RID: 19742 RVA: 0x001DD984 File Offset: 0x001DBB84
			internal bool \u000A(FontFamily \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0020\u001A\u001D.\u000A(\u001F), \u0011\u001A\u001D.\u000A(this.\u001F));
			}

			// Token: 0x06004D1F RID: 19743 RVA: 0x001DD9B0 File Offset: 0x001DBBB0
			internal bool \u0007(FontFamily \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0020\u001A\u001D.\u000A(\u001F), \u0011\u001A\u001D.\u000A(this.\u001F));
			}

			// Token: 0x04002004 RID: 8196
			public IFont \u001F;
		}
	}
}

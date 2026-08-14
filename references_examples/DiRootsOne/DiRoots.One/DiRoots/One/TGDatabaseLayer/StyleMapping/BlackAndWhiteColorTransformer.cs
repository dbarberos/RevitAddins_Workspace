using System;
using System.Drawing;
using A;

namespace DiRoots.One.TGDatabaseLayer.StyleMapping
{
	// Token: 0x0200011C RID: 284
	public static class BlackAndWhiteColorTransformer
	{
		// Token: 0x06000ABF RID: 2751 RVA: 0x00046008 File Offset: 0x00044208
		public static bool IsGray(Color c)
		{
			if (\u0015\u0017\u001D.\u000A(ref c) == \u000C\u0017\u001D.\u000A(ref c))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BlackAndWhiteColorTransformer.IsGray(Color)).MethodHandle;
				}
				return \u000C\u0017\u001D.\u000A(ref c) == \u0013\u0017\u001D.\u000A(ref c);
			}
			return false;
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x00046054 File Offset: 0x00044254
		public static Color ToGrayscale(Color c)
		{
			int num = (int)\u0020\u001E\u0004.\u000A(0.299 * (double)\u0015\u0017\u001D.\u000A(ref c) + 0.587 * (double)\u000C\u0017\u001D.\u000A(ref c) + 0.114 * (double)\u0013\u0017\u001D.\u000A(ref c));
			if (num < 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BlackAndWhiteColorTransformer.ToGrayscale(Color)).MethodHandle;
				}
				num = 0;
			}
			if (num > 255)
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
				num = 255;
			}
			return \u001E\u001E\u0004.\u000A((int)\u000D\u000C\u001D.\u000A(ref c), num, num, num);
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x000460EC File Offset: 0x000442EC
		public static Color TransformTextOrLine(Color input, BlackAndWhiteTextLinesOption option)
		{
			switch (option)
			{
			case BlackAndWhiteTextLinesOption.KeepWhiteAndGrays:
				if (!\u0014\u001E\u0004.\u000A(input))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(BlackAndWhiteColorTransformer.TransformTextOrLine(Color, BlackAndWhiteTextLinesOption)).MethodHandle;
					}
					return \u001E\u001E\u0004.\u000A((int)\u000D\u000C\u001D.\u000A(ref input), 0, 0, 0);
				}
				return input;
			case BlackAndWhiteTextLinesOption.ConvertColorsToGrayscale:
				if (!\u0014\u001E\u0004.\u000A(input))
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
					return \u0017\u001E\u0004.\u000A(input);
				}
				return input;
			}
			return \u001E\u001E\u0004.\u000A((int)\u000D\u000C\u001D.\u000A(ref input), 0, 0, 0);
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x00046174 File Offset: 0x00044374
		public static Color? TransformBackground(Color input, BlackAndWhiteBackgroundOption option)
		{
			Color? result;
			switch (option)
			{
			case BlackAndWhiteBackgroundOption.KeepGraysRemoveColors:
				if (!\u0014\u001E\u0004.\u000A(input))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(BlackAndWhiteColorTransformer.TransformBackground(Color, BlackAndWhiteBackgroundOption)).MethodHandle;
					}
					\u0009\u0019\u000E.\u001F(ref result);
					return result;
				}
				return new Color?(input);
			case BlackAndWhiteBackgroundOption.ConvertToGrayscale:
			{
				Color value;
				if (!\u0014\u001E\u0004.\u000A(input))
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
					value = \u0017\u001E\u0004.\u000A(input);
				}
				else
				{
					value = input;
				}
				return new Color?(value);
			}
			}
			\u0009\u0019\u000E.\u001F(ref result);
			return result;
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x000461F0 File Offset: 0x000443F0
		public static BlackAndWhiteSettings GetSettings(StyleMappingDto styleMappings)
		{
			if (styleMappings == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BlackAndWhiteColorTransformer.GetSettings(StyleMappingDto)).MethodHandle;
				}
				StyleMappingDto u001F = \u001F\u000D\u0004.\u000A();
				return new BlackAndWhiteSettings(\u0005\u0010\u0004.\u0007(\u0009\u0004\u0004.\u0007(u001F)), \u0018\u0010\u0004.\u000A(\u0009\u0004\u0004.\u0007(u001F)));
			}
			return new BlackAndWhiteSettings(\u0005\u0010\u0004.\u0007(\u0009\u0004\u0004.\u0007(styleMappings)), \u0018\u0010\u0004.\u000A(\u0009\u0004\u0004.\u0007(styleMappings)));
		}
	}
}

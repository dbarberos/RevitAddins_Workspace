using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using A;
using Newtonsoft.Json;

namespace DiRoots.One.TGDatabaseLayer.StyleMapping
{
	// Token: 0x02000120 RID: 288
	public sealed class ExcelTextStyleInfo : IEquatable<ExcelTextStyleInfo>
	{
		// Token: 0x06000ADC RID: 2780 RVA: 0x00046778 File Offset: 0x00044978
		public ExcelTextStyleInfo(string fontName, Color fontColor, double sizeInPt, bool isBold, bool isItalic, bool isUnderlined)
		{
			string text = fontName;
			if (fontName == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelTextStyleInfo..ctor(string, Color, double, bool, bool, bool)).MethodHandle;
				}
				text = string.Empty;
			}
			this.FontName = text;
			this.FontColor = fontColor;
			this.SizeInPt = sizeInPt;
			this.IsBold = isBold;
			this.IsItalic = isItalic;
			this.IsUnderlined = isUnderlined;
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x000467D4 File Offset: 0x000449D4
		[JsonConstructor]
		public ExcelTextStyleInfo(string fontName, int fontColorArgb, double sizeInPt, bool isBold, bool isItalic, bool isUnderlined)
		{
			string text = fontName;
			if (fontName == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelTextStyleInfo..ctor(string, int, double, bool, bool, bool)).MethodHandle;
				}
				text = string.Empty;
			}
			this.FontName = text;
			this.FontColor = \u000C\u001E\u0004.\u000A(fontColorArgb);
			this.SizeInPt = sizeInPt;
			this.IsBold = isBold;
			this.IsItalic = isItalic;
			this.IsUnderlined = isUnderlined;
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x00046838 File Offset: 0x00044A38
		private static long \u0005(double \u001F)
		{
			return (long)\u0007\u0020\u0004.\u000A(\u001F / 1E-06, MidpointRounding.AwayFromZero);
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000ADF RID: 2783 RVA: 0x0004685C File Offset: 0x00044A5C
		public string FontName { get; }

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000AE0 RID: 2784 RVA: 0x00046870 File Offset: 0x00044A70
		[JsonIgnore]
		public Color FontColor { get; }

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000AE1 RID: 2785 RVA: 0x00046884 File Offset: 0x00044A84
		public int FontColorArgb
		{
			get
			{
				Color color = \u0005\u001D\u0004.\u001D(this);
				return \u0001\u001E\u0004.\u000A(ref color);
			}
		}

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000AE2 RID: 2786 RVA: 0x000468A4 File Offset: 0x00044AA4
		public double SizeInPt { get; }

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06000AE3 RID: 2787 RVA: 0x000468B8 File Offset: 0x00044AB8
		public bool IsBold { get; }

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000AE4 RID: 2788 RVA: 0x000468CC File Offset: 0x00044ACC
		public bool IsItalic { get; }

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000AE5 RID: 2789 RVA: 0x000468E0 File Offset: 0x00044AE0
		public bool IsUnderlined { get; }

		// Token: 0x06000AE6 RID: 2790 RVA: 0x000468F4 File Offset: 0x00044AF4
		public ExcelTextStyleInfo WithFontColor(Color fontColor)
		{
			int num = \u0001\u001E\u0004.\u000A(ref fontColor);
			Color color = \u0005\u001D\u0004.\u001D(this);
			if (num == \u0001\u001E\u0004.\u000A(ref color))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelTextStyleInfo.WithFontColor(Color)).MethodHandle;
				}
				return this;
			}
			return \u0015\u001A\u001D.\u000A(\u0016\u001D\u0004.\u001D(this), fontColor, \u001B\u0006\u0004.\u001D(this), \u0018\u001D\u0004.\u001D(this), \u0019\u001D\u0004.\u001D(this), \u001D\u001D\u0004.\u001D(this));
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x00046964 File Offset: 0x00044B64
		public bool Equals(ExcelTextStyleInfo other)
		{
			if (other == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelTextStyleInfo.Equals(ExcelTextStyleInfo)).MethodHandle;
				}
				return false;
			}
			if (this == other)
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
				return true;
			}
			if (\u001B\u0003\u0004.\u000A(\u0016\u001D\u0004.\u001D(this), \u0016\u001D\u0004.\u0007(other), StringComparison.OrdinalIgnoreCase))
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
				if (\u0005\u001D\u0004.\u001D(this).\u000A(\u0005\u001D\u0004.\u0007(other)))
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
					if (ExcelTextStyleInfo.\u0005(\u001B\u0006\u0004.\u001D(this)) == ExcelTextStyleInfo.\u0005(\u001B\u0006\u0004.\u0007(other)))
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
						if (\u0018\u001D\u0004.\u001D(this) == \u0018\u001D\u0004.\u0007(other))
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
							if (\u0019\u001D\u0004.\u001D(this) == \u0019\u001D\u0004.\u0007(other))
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
								return \u001D\u001D\u0004.\u001D(this) == \u001D\u001D\u0004.\u0007(other);
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x00046A5C File Offset: 0x00044C5C
		public override bool Equals(object obj)
		{
			return \u001D\u0020\u0004.\u0007(this, \u000A\u0018\u000E.\u001F(obj));
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x00046A7C File Offset: 0x00044C7C
		public override int GetHashCode()
		{
			int num = 17 * 31;
			string text = \u0016\u001D\u0004.\u001D(this);
			int num2;
			if (text == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelTextStyleInfo.GetHashCode()).MethodHandle;
				}
				num2 = 0;
			}
			else
			{
				num2 = \u001B\u0013\u000A.\u000A(\u000D\u0003\u0004.\u0007(text));
			}
			int num3 = (num + num2) * 31;
			Color color = \u0005\u001D\u0004.\u001D(this);
			byte b = \u0015\u0017\u001D.\u000A(ref color);
			int num4 = (num3 + \u000A\u0020\u0004.\u000A(ref b)) * 31;
			color = \u0005\u001D\u0004.\u001D(this);
			b = \u000C\u0017\u001D.\u000A(ref color);
			int num5 = (num4 + \u000A\u0020\u0004.\u000A(ref b)) * 31;
			color = \u0005\u001D\u0004.\u001D(this);
			b = \u0013\u0017\u001D.\u000A(ref color);
			int num6 = (num5 + \u000A\u0020\u0004.\u000A(ref b)) * 31;
			color = \u0005\u001D\u0004.\u001D(this);
			b = \u000D\u000C\u001D.\u000A(ref color);
			int num7 = (num6 + \u000A\u0020\u0004.\u000A(ref b)) * 31;
			long num8 = ExcelTextStyleInfo.\u0005(\u001B\u0006\u0004.\u001D(this));
			int num9 = (num7 + \u0007\u000A\u001D.\u000A(ref num8)) * 31;
			bool flag = \u0018\u001D\u0004.\u001D(this);
			int num10 = (num9 + \u0004\u0020\u0004.\u000A(ref flag)) * 31;
			flag = \u0019\u001D\u0004.\u001D(this);
			int num11 = (num10 + \u0004\u0020\u0004.\u000A(ref flag)) * 31;
			flag = \u001D\u001D\u0004.\u001D(this);
			return num11 + \u0004\u0020\u0004.\u000A(ref flag);
		}

		// Token: 0x0400045D RID: 1117
		private static double \u001F;

		// Token: 0x0400045E RID: 1118
		[CompilerGenerated]
		private readonly string \u000A;

		// Token: 0x0400045F RID: 1119
		[CompilerGenerated]
		private readonly Color \u0007;

		// Token: 0x04000460 RID: 1120
		[CompilerGenerated]
		private readonly double \u001D;

		// Token: 0x04000461 RID: 1121
		[CompilerGenerated]
		private readonly bool \u0004;

		// Token: 0x04000462 RID: 1122
		[CompilerGenerated]
		private readonly bool \u0019;

		// Token: 0x04000463 RID: 1123
		[CompilerGenerated]
		private readonly bool \u0018;
	}
}

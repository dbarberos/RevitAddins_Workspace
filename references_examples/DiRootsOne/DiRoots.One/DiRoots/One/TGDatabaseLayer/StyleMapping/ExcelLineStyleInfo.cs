using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using A;
using Newtonsoft.Json;
using Syncfusion.XlsIO;

namespace DiRoots.One.TGDatabaseLayer.StyleMapping
{
	// Token: 0x0200011E RID: 286
	public sealed class ExcelLineStyleInfo : IEquatable<ExcelLineStyleInfo>
	{
		// Token: 0x06000AC7 RID: 2759 RVA: 0x000462A8 File Offset: 0x000444A8
		public ExcelLineStyleInfo(ExcelLineStyle style, Color color)
		{
			this.Pattern = style;
			this.Color = color;
			\u000C\u0005 u001F = \u0002\u0005.\u0017(style);
			this.Name = \u001A\u001E\u0004.\u000A(u001F);
			this.LineWidth = \u0013\u001E\u0004.\u000A(u001F);
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x000462F0 File Offset: 0x000444F0
		[JsonConstructor]
		public ExcelLineStyleInfo(ExcelLineStyle pattern, string name, int lineWidth, int colorArgb)
		{
			this.Pattern = pattern;
			string text = name;
			if (name == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelLineStyleInfo..ctor(ExcelLineStyle, string, int, int)).MethodHandle;
				}
				text = string.Empty;
			}
			this.Name = text;
			this.LineWidth = lineWidth;
			this.Color = \u000C\u001E\u0004.\u000A(colorArgb);
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x00046344 File Offset: 0x00044544
		private ExcelLineStyleInfo(bool \u001F)
		{
			this.Pattern = 0;
			this.Name = "__TG_GRIDLINES__";
			this.LineWidth = 0;
			this.Color = \u000A\u0002\u0004.\u000A();
		}

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000ACB RID: 2763 RVA: 0x0004639C File Offset: 0x0004459C
		public ExcelLineStyle Pattern { get; }

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000ACC RID: 2764 RVA: 0x000463B0 File Offset: 0x000445B0
		public string Name { get; }

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000ACD RID: 2765 RVA: 0x000463C4 File Offset: 0x000445C4
		public int LineWidth { get; }

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000ACE RID: 2766 RVA: 0x000463D8 File Offset: 0x000445D8
		[JsonIgnore]
		public Color Color { get; }

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000ACF RID: 2767 RVA: 0x000463EC File Offset: 0x000445EC
		public int ColorArgb
		{
			get
			{
				Color color = \u0012\u0002\u0004.\u001D(this);
				return \u0001\u001E\u0004.\u000A(ref color);
			}
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x0004640C File Offset: 0x0004460C
		public ExcelLineStyleInfo WithColor(Color color)
		{
			int num = \u0001\u001E\u0004.\u000A(ref color);
			Color color2 = \u0012\u0002\u0004.\u001D(this);
			if (num == \u0001\u001E\u0004.\u000A(ref color2))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelLineStyleInfo.WithColor(Color)).MethodHandle;
				}
				return this;
			}
			return \u0009\u001E\u0004.\u000A(\u0015\u0002\u0004.\u001D(this), \u001F\u0020\u0004.\u0007(this), \u001C\u0002\u0004.\u001D(this), \u0001\u001E\u0004.\u000A(ref color));
		}

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000AD1 RID: 2769 RVA: 0x00046474 File Offset: 0x00044674
		public bool IsGridlines
		{
			get
			{
				if (\u0015\u0002\u0004.\u001D(this) != ExcelLineStyle.None)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelLineStyleInfo.get_IsGridlines()).MethodHandle;
					}
					return false;
				}
				if (\u0008\u0013\u000A.\u000A(\u001F\u0020\u0004.\u0007(this), "__TG_GRIDLINES__"))
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
					return true;
				}
				return false;
			}
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x000464C4 File Offset: 0x000446C4
		public bool Equals(ExcelLineStyleInfo other)
		{
			if (other == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelLineStyleInfo.Equals(ExcelLineStyleInfo)).MethodHandle;
				}
				return false;
			}
			if (this == other)
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
				return true;
			}
			if (!\u0017\u0001\u001D.\u0007(this))
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
				if (!\u0017\u0001\u001D.\u001D(other))
				{
					if (\u0015\u0002\u0004.\u001D(this).Equals(\u0015\u0002\u0004.\u0007(other)))
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
						if (\u000D\u001F\u001D.\u000A(\u001F\u0020\u0004.\u0007(this), \u001F\u0020\u0004.\u001D(other)))
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
							if (\u001C\u0002\u0004.\u001D(this) == \u001C\u0002\u0004.\u0007(other))
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
								return \u0012\u0002\u0004.\u001D(this).\u000A(\u0012\u0002\u0004.\u0007(other));
							}
						}
					}
					return false;
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
			if (\u0017\u0001\u001D.\u0007(this))
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
				return \u0017\u0001\u001D.\u001D(other);
			}
			return false;
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x000465CC File Offset: 0x000447CC
		public override bool Equals(object obj)
		{
			return \u000A\u0009\u001D.\u001D(this, \u001F\u0018\u000E.\u001F(obj));
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x000465EC File Offset: 0x000447EC
		public override int GetHashCode()
		{
			if (\u0017\u0001\u001D.\u0007(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelLineStyleInfo.GetHashCode()).MethodHandle;
				}
				return \u001B\u0013\u000A.\u000A("__TG_GRIDLINES__");
			}
			int num = ((17 * 31 + \u0015\u0002\u0004.\u001D(this).GetHashCode()) * 31 + \u001B\u0013\u000A.\u000A(\u001F\u0020\u0004.\u0007(this))) * 31;
			int num2 = \u001C\u0002\u0004.\u001D(this);
			int num3 = (num + \u001F\u000A\u001D.\u000A(ref num2)) * 31;
			Color color = \u0012\u0002\u0004.\u001D(this);
			byte b = \u0015\u0017\u001D.\u000A(ref color);
			int num4 = (num3 + \u000A\u0020\u0004.\u000A(ref b)) * 31;
			color = \u0012\u0002\u0004.\u001D(this);
			b = \u000C\u0017\u001D.\u000A(ref color);
			int num5 = (num4 + \u000A\u0020\u0004.\u000A(ref b)) * 31;
			color = \u0012\u0002\u0004.\u001D(this);
			b = \u0013\u0017\u001D.\u000A(ref color);
			int num6 = (num5 + \u000A\u0020\u0004.\u000A(ref b)) * 31;
			color = \u0012\u0002\u0004.\u001D(this);
			b = \u000D\u000C\u001D.\u000A(ref color);
			return num6 + \u000A\u0020\u0004.\u000A(ref b);
		}

		// Token: 0x04000454 RID: 1108
		private static string \u001F;

		// Token: 0x04000455 RID: 1109
		public static readonly ExcelLineStyleInfo Gridlines = \u0015\u001E\u0004.\u000A(true);

		// Token: 0x04000456 RID: 1110
		[CompilerGenerated]
		private readonly ExcelLineStyle \u000A;

		// Token: 0x04000457 RID: 1111
		[CompilerGenerated]
		private readonly string \u0007;

		// Token: 0x04000458 RID: 1112
		[CompilerGenerated]
		private readonly int \u001D;

		// Token: 0x04000459 RID: 1113
		[CompilerGenerated]
		private readonly Color \u0004;
	}
}

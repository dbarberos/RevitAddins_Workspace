using System;
using System.Runtime.CompilerServices;
using A;

namespace DiRoots.One.TGDatabaseLayer.StyleMapping
{
	// Token: 0x02000127 RID: 295
	public class TextStyleMapping
	{
		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000B1B RID: 2843 RVA: 0x00047428 File Offset: 0x00045628
		// (set) Token: 0x06000B1C RID: 2844 RVA: 0x0004743C File Offset: 0x0004563C
		public ExcelTextStyleInfo ExcelStyle { get; set; }

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000B1D RID: 2845 RVA: 0x00047450 File Offset: 0x00045650
		// (set) Token: 0x06000B1E RID: 2846 RVA: 0x00047464 File Offset: 0x00045664
		public string RevitLegendTextStyleName { get; set; }

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000B1F RID: 2847 RVA: 0x00047478 File Offset: 0x00045678
		// (set) Token: 0x06000B20 RID: 2848 RVA: 0x0004748C File Offset: 0x0004568C
		public string RevitLegendTextStyleElementUniqueId { get; set; }

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000B21 RID: 2849 RVA: 0x000474A0 File Offset: 0x000456A0
		// (set) Token: 0x06000B22 RID: 2850 RVA: 0x000474B4 File Offset: 0x000456B4
		public double MappedFontSize { get; set; }

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000B23 RID: 2851 RVA: 0x000474C8 File Offset: 0x000456C8
		// (set) Token: 0x06000B24 RID: 2852 RVA: 0x000474DC File Offset: 0x000456DC
		public bool IsNew { get; set; }

		// Token: 0x06000B25 RID: 2853 RVA: 0x000474F0 File Offset: 0x000456F0
		public bool EqualsByValue(TextStyleMapping other)
		{
			if (other == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TextStyleMapping.EqualsByValue(TextStyleMapping)).MethodHandle;
				}
				return false;
			}
			if (this == other)
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
				return true;
			}
			bool flag;
			if (\u0002\u000D\u0004.\u0007(this) != null)
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
				flag = \u001D\u0020\u0004.\u001D(\u0002\u000D\u0004.\u0007(this), \u0002\u000D\u0004.\u001D(other));
			}
			else
			{
				flag = (\u0002\u000D\u0004.\u001D(other) == \u0014\u0019\u000E.\u001F);
			}
			if (flag)
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
				if (\u001B\u0003\u0004.\u000A(\u000E\u0006\u0004.\u001D(this), \u000E\u0006\u0004.\u0007(other), StringComparison.Ordinal))
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
					return \u0008\u001F\u0007.\u000A(\u0011\u0006\u0004.\u001D(this) - \u0011\u0006\u0004.\u0007(other)) < 0.0001;
				}
			}
			return false;
		}

		// Token: 0x04000475 RID: 1141
		[CompilerGenerated]
		private ExcelTextStyleInfo \u001F;

		// Token: 0x04000476 RID: 1142
		[CompilerGenerated]
		private string \u000A;

		// Token: 0x04000477 RID: 1143
		[CompilerGenerated]
		private string \u0007;

		// Token: 0x04000478 RID: 1144
		[CompilerGenerated]
		private double \u001D;

		// Token: 0x04000479 RID: 1145
		[CompilerGenerated]
		private bool \u0004;
	}
}

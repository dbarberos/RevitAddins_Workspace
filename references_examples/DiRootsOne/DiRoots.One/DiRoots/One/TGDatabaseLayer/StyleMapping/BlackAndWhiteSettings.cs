using System;
using System.Runtime.CompilerServices;

namespace DiRoots.One.TGDatabaseLayer.StyleMapping
{
	// Token: 0x0200011D RID: 285
	public readonly struct BlackAndWhiteSettings
	{
		// Token: 0x06000AC4 RID: 2756 RVA: 0x00046264 File Offset: 0x00044464
		public BlackAndWhiteSettings(BlackAndWhiteTextLinesOption textLines, BlackAndWhiteBackgroundOption background)
		{
			this.TextLines = textLines;
			this.Background = background;
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06000AC5 RID: 2757 RVA: 0x00046280 File Offset: 0x00044480
		public BlackAndWhiteTextLinesOption TextLines { get; }

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06000AC6 RID: 2758 RVA: 0x00046294 File Offset: 0x00044494
		public BlackAndWhiteBackgroundOption Background { get; }

		// Token: 0x04000452 RID: 1106
		[CompilerGenerated]
		private readonly BlackAndWhiteTextLinesOption \u001F;

		// Token: 0x04000453 RID: 1107
		[CompilerGenerated]
		private readonly BlackAndWhiteBackgroundOption \u000A;
	}
}

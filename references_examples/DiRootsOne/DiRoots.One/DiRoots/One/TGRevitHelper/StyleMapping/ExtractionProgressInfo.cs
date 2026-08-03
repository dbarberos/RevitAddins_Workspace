using System;
using System.Runtime.CompilerServices;
using A;

namespace DiRoots.One.TGRevitHelper.StyleMapping
{
	// Token: 0x020000F7 RID: 247
	public readonly struct ExtractionProgressInfo
	{
		// Token: 0x060008F7 RID: 2295 RVA: 0x0003DDFC File Offset: 0x0003BFFC
		public ExtractionProgressInfo(int current, int total, string filePath, string sheet, string region)
		{
			this.Current = current;
			this.Total = total;
			string text = filePath;
			if (filePath == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExtractionProgressInfo..ctor(int, int, string, string, string)).MethodHandle;
				}
				text = string.Empty;
			}
			this.FilePath = text;
			string text2 = sheet;
			if (sheet == null)
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
				text2 = string.Empty;
			}
			this.Sheet = text2;
			string text3 = region;
			if (region == null)
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
				text3 = string.Empty;
			}
			this.Region = text3;
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x060008F8 RID: 2296 RVA: 0x0003DE70 File Offset: 0x0003C070
		public int Current { get; }

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x060008F9 RID: 2297 RVA: 0x0003DE84 File Offset: 0x0003C084
		public int Total { get; }

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x060008FA RID: 2298 RVA: 0x0003DE98 File Offset: 0x0003C098
		public string FilePath { get; }

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x060008FB RID: 2299 RVA: 0x0003DEAC File Offset: 0x0003C0AC
		public string Sheet { get; }

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x060008FC RID: 2300 RVA: 0x0003DEC0 File Offset: 0x0003C0C0
		public string Region { get; }

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x060008FD RID: 2301 RVA: 0x0003DED4 File Offset: 0x0003C0D4
		public string FileName
		{
			get
			{
				if (\u001A\u0006\u0007.\u000A(\u0006\u0003\u0004.\u000A(ref this)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ExtractionProgressInfo.get_FileName()).MethodHandle;
					}
					return string.Empty;
				}
				string result;
				try
				{
					result = \u000F\u000B\u001D.\u000A(\u0006\u0003\u0004.\u000A(ref this));
				}
				catch
				{
					result = \u0006\u0003\u0004.\u000A(ref this);
				}
				return result;
			}
		}

		// Token: 0x04000368 RID: 872
		[CompilerGenerated]
		private readonly int \u001F;

		// Token: 0x04000369 RID: 873
		[CompilerGenerated]
		private readonly int \u000A;

		// Token: 0x0400036A RID: 874
		[CompilerGenerated]
		private readonly string \u0007;

		// Token: 0x0400036B RID: 875
		[CompilerGenerated]
		private readonly string \u001D;

		// Token: 0x0400036C RID: 876
		[CompilerGenerated]
		private readonly string \u0004;
	}
}

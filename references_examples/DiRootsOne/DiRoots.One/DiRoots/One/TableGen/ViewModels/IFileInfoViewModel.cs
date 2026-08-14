using System;
using DiRoots.One.TGDatabaseLayer;

namespace DiRoots.One.TableGen.ViewModels
{
	// Token: 0x0200014C RID: 332
	public interface IFileInfoViewModel
	{
		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000C4D RID: 3149
		string Name { get; }

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06000C4E RID: 3150
		string Path { get; }

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06000C4F RID: 3151
		string DisplayPath { get; }

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06000C50 RID: 3152
		// (set) Token: 0x06000C51 RID: 3153
		string RelativePath { get; set; }

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06000C52 RID: 3154
		// (set) Token: 0x06000C53 RID: 3155
		bool ShowRelativePath { get; set; }

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06000C54 RID: 3156
		bool HasItems { get; }

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06000C55 RID: 3157
		int ViewsCount { get; }

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06000C56 RID: 3158
		SourceTypes SourceType { get; }

		// Token: 0x06000C57 RID: 3159
		void UpdateDisplayPath();
	}
}

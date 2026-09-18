using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002C0 RID: 704
	public class ViewData : ModelBase
	{
		// Token: 0x06001C67 RID: 7271 RVA: 0x000B5650 File Offset: 0x000B3850
		public ViewData()
		{
			\u0020\u0002\u0016.\u001D(this, "");
			this.KS = "";
			\u001B\u0002\u0016.\u001D(this, \u000A\u0012\u0016.\u000A());
		}

		// Token: 0x170007E9 RID: 2025
		// (get) Token: 0x06001C68 RID: 7272 RVA: 0x000B5688 File Offset: 0x000B3888
		// (set) Token: 0x06001C69 RID: 7273 RVA: 0x000B56D8 File Offset: 0x000B38D8
		public string DisplayName
		{
			get
			{
				string ks;
				if (\u001A\u0006\u0007.\u000A(\u0014\u0019\u0016.\u001D(this)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewData.get_DisplayName()).MethodHandle;
					}
					ks = \u000A\u0012\u0016.\u000A();
				}
				else
				{
					ks = \u0014\u0019\u0016.\u001D(this);
				}
				this.KS = ks;
				return this.KS;
			}
			set
			{
				this.KS = value;
				\u0007\u0013\u000A.\u000A(this, "DisplayName");
			}
		}

		// Token: 0x170007EA RID: 2026
		// (get) Token: 0x06001C6A RID: 7274 RVA: 0x000B56F8 File Offset: 0x000B38F8
		// (set) Token: 0x06001C6B RID: 7275 RVA: 0x000B570C File Offset: 0x000B390C
		public string Name { get; set; }

		// Token: 0x170007EB RID: 2027
		// (get) Token: 0x06001C6C RID: 7276 RVA: 0x000B5720 File Offset: 0x000B3920
		// (set) Token: 0x06001C6D RID: 7277 RVA: 0x000B5734 File Offset: 0x000B3934
		public long ViewId { get; set; }

		// Token: 0x170007EC RID: 2028
		// (get) Token: 0x06001C6E RID: 7278 RVA: 0x000B5748 File Offset: 0x000B3948
		// (set) Token: 0x06001C6F RID: 7279 RVA: 0x000B575C File Offset: 0x000B395C
		public string ViewTemplate { get; set; }

		// Token: 0x170007ED RID: 2029
		// (get) Token: 0x06001C70 RID: 7280 RVA: 0x000B5770 File Offset: 0x000B3970
		// (set) Token: 0x06001C71 RID: 7281 RVA: 0x000B5784 File Offset: 0x000B3984
		public ViewType Type { get; internal set; }

		// Token: 0x04000B68 RID: 2920
		private string KS;

		// Token: 0x04000B69 RID: 2921
		[CompilerGenerated]
		private string K;

		// Token: 0x04000B6A RID: 2922
		[CompilerGenerated]
		private long JS;

		// Token: 0x04000B6B RID: 2923
		[CompilerGenerated]
		private string ES;

		// Token: 0x04000B6C RID: 2924
		[CompilerGenerated]
		private ViewType NS;
	}
}

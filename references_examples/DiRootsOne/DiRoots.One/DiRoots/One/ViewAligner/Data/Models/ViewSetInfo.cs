using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.ViewAligner.Interfaces;

namespace DiRoots.One.ViewAligner.Data.Models
{
	// Token: 0x020000D5 RID: 213
	public class ViewSetInfo : ModelBase, IRevitElement, IComboxItemModel
	{
		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000817 RID: 2071 RVA: 0x0002E53C File Offset: 0x0002C73C
		// (set) Token: 0x06000818 RID: 2072 RVA: 0x0002E550 File Offset: 0x0002C750
		public string UniqueId { get; set; }

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x0002E564 File Offset: 0x0002C764
		// (set) Token: 0x0600081A RID: 2074 RVA: 0x0002E578 File Offset: 0x0002C778
		public long Id { get; set; }

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x0600081B RID: 2075 RVA: 0x0002E58C File Offset: 0x0002C78C
		// (set) Token: 0x0600081C RID: 2076 RVA: 0x0002E5A0 File Offset: 0x0002C7A0
		public string Name
		{
			get
			{
				return this.JR;
			}
			set
			{
				base.SetProperty<string>(ref this.JR, value, null, "Name");
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x0600081D RID: 2077 RVA: 0x0002E5C4 File Offset: 0x0002C7C4
		// (set) Token: 0x0600081E RID: 2078 RVA: 0x0002E5D8 File Offset: 0x0002C7D8
		public List<long> Views { get; set; }

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x0600081F RID: 2079 RVA: 0x0002E5EC File Offset: 0x0002C7EC
		// (set) Token: 0x06000820 RID: 2080 RVA: 0x0002E600 File Offset: 0x0002C800
		public bool? IsChecked
		{
			get
			{
				return this.WR;
			}
			set
			{
				base.SetProperty<bool?>(ref this.WR, value, null, "IsChecked");
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000821 RID: 2081 RVA: 0x0002E624 File Offset: 0x0002C824
		// (set) Token: 0x06000822 RID: 2082 RVA: 0x0002E638 File Offset: 0x0002C838
		public bool IsHidden
		{
			get
			{
				return this.KR;
			}
			set
			{
				base.SetProperty<bool>(ref this.KR, value, null, "IsHidden");
			}
		}

		// Token: 0x04000338 RID: 824
		private bool? WR = new bool?(false);

		// Token: 0x04000339 RID: 825
		private bool KR;

		// Token: 0x0400033A RID: 826
		private string JR;

		// Token: 0x0400033B RID: 827
		[CompilerGenerated]
		private string LR;

		// Token: 0x0400033C RID: 828
		[CompilerGenerated]
		private long W;

		// Token: 0x0400033D RID: 829
		[CompilerGenerated]
		private List<long> ER;
	}
}

using System;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.TGDatabaseLayer
{
	// Token: 0x02000116 RID: 278
	public class FormatOptions : ModelBase
	{
		// Token: 0x170002AB RID: 683
		// (get) Token: 0x060009F7 RID: 2551 RVA: 0x0004264C File Offset: 0x0004084C
		// (set) Token: 0x060009F8 RID: 2552 RVA: 0x00042660 File Offset: 0x00040860
		public bool BlackAndWhite
		{
			get
			{
				return this.NR;
			}
			set
			{
				base.SetProperty<bool>(ref this.NR, value, null, "BlackAndWhite");
			}
		}

		// Token: 0x04000410 RID: 1040
		private bool NR;
	}
}

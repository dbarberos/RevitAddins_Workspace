using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.ViewModels;

namespace DiRoots.One.TableGen.ViewModels
{
	// Token: 0x0200014E RID: 334
	public class WorksheetViewModel : ViewModelBase
	{
		// Token: 0x06000C6B RID: 3179 RVA: 0x0004E4A8 File Offset: 0x0004C6A8
		public WorksheetViewModel(string sheetName)
		{
			\u0017\u000A\u0019.\u000A(this, sheetName);
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000C6C RID: 3180 RVA: 0x0004E4CC File Offset: 0x0004C6CC
		// (set) Token: 0x06000C6D RID: 3181 RVA: 0x0004E4E0 File Offset: 0x0004C6E0
		public string Name { get; set; }

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000C6E RID: 3182 RVA: 0x0004E4F4 File Offset: 0x0004C6F4
		// (set) Token: 0x06000C6F RID: 3183 RVA: 0x0004E508 File Offset: 0x0004C708
		public bool IsChecked
		{
			get
			{
				return this.DS;
			}
			set
			{
				base.SetProperty<bool>(ref this.DS, value, null, "IsChecked");
			}
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06000C70 RID: 3184 RVA: 0x0004E52C File Offset: 0x0004C72C
		// (set) Token: 0x06000C71 RID: 3185 RVA: 0x0004E540 File Offset: 0x0004C740
		public SheetRegionViewModel SelectedRegion { get; set; }

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06000C72 RID: 3186 RVA: 0x0004E554 File Offset: 0x0004C754
		// (set) Token: 0x06000C73 RID: 3187 RVA: 0x0004E568 File Offset: 0x0004C768
		public List<SheetRegionViewModel> SheetRegions { get; set; }

		// Token: 0x040004E7 RID: 1255
		private bool DS = true;

		// Token: 0x040004E8 RID: 1256
		[CompilerGenerated]
		private string SS;

		// Token: 0x040004E9 RID: 1257
		[CompilerGenerated]
		private SheetRegionViewModel MS;

		// Token: 0x040004EA RID: 1258
		[CompilerGenerated]
		private List<SheetRegionViewModel> VS;
	}
}

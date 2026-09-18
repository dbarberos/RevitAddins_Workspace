using System;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000252 RID: 594
	public class BaseElement : ModelBase
	{
		// Token: 0x170006B7 RID: 1719
		// (get) Token: 0x06001824 RID: 6180 RVA: 0x0009C1D8 File Offset: 0x0009A3D8
		// (set) Token: 0x06001825 RID: 6181 RVA: 0x0009C1EC File Offset: 0x0009A3EC
		public string UniqueId { get; set; }

		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x06001826 RID: 6182 RVA: 0x0009C200 File Offset: 0x0009A400
		// (set) Token: 0x06001827 RID: 6183 RVA: 0x0009C214 File Offset: 0x0009A414
		public long Id { get; set; }

		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x06001828 RID: 6184 RVA: 0x0009C228 File Offset: 0x0009A428
		// (set) Token: 0x06001829 RID: 6185 RVA: 0x0009C23C File Offset: 0x0009A43C
		public string Name { get; set; }

		// Token: 0x04000982 RID: 2434
		[CompilerGenerated]
		private string LR;

		// Token: 0x04000983 RID: 2435
		[CompilerGenerated]
		private long W;

		// Token: 0x04000984 RID: 2436
		[CompilerGenerated]
		private string K;
	}
}

using System;
using System.IO.Packaging;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x020000B5 RID: 181
	internal abstract class \u001A\u0004 : \u0013\u0004
	{
		// Token: 0x06000709 RID: 1801 RVA: 0x000292F0 File Offset: 0x000274F0
		public \u001A\u0004(string \u001F, StorageInfo \u000A) : base(\u001F)
		{
			base.\u0002\u000A = \u001F;
			\u0017\u0002\u001D.\u000A(this, \u000A);
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x0600070A RID: 1802 RVA: 0x00029314 File Offset: 0x00027514
		// (set) Token: 0x0600070B RID: 1803 RVA: 0x00029328 File Offset: 0x00027528
		public StorageInfo Storage { get; set; }

		// Token: 0x040002D4 RID: 724
		[CompilerGenerated]
		private StorageInfo \u0003;
	}
}

using System;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.ViewRange.Model
{
	// Token: 0x02000296 RID: 662
	public class LevelInfo : ModelBase
	{
		// Token: 0x17000727 RID: 1831
		// (get) Token: 0x060019FF RID: 6655 RVA: 0x000A7938 File Offset: 0x000A5B38
		// (set) Token: 0x06001A00 RID: 6656 RVA: 0x000A794C File Offset: 0x000A5B4C
		public string Name
		{
			get
			{
				return this.JR;
			}
			set
			{
				this.JR = value;
				\u0007\u0013\u000A.\u000A(this, "Name");
			}
		}

		// Token: 0x17000728 RID: 1832
		// (get) Token: 0x06001A01 RID: 6657 RVA: 0x000A796C File Offset: 0x000A5B6C
		// (set) Token: 0x06001A02 RID: 6658 RVA: 0x000A7980 File Offset: 0x000A5B80
		public double Elevation { get; set; }

		// Token: 0x17000729 RID: 1833
		// (get) Token: 0x06001A03 RID: 6659 RVA: 0x000A7994 File Offset: 0x000A5B94
		// (set) Token: 0x06001A04 RID: 6660 RVA: 0x000A79A8 File Offset: 0x000A5BA8
		public long Id { get; set; }

		// Token: 0x04000A4F RID: 2639
		private string JR;

		// Token: 0x04000A50 RID: 2640
		[CompilerGenerated]
		private double LL;

		// Token: 0x04000A51 RID: 2641
		[CompilerGenerated]
		private long W;
	}
}

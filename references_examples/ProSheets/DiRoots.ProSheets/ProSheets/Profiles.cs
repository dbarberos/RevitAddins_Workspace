using System;
using System.Collections.Generic;

namespace ProSheets
{
	// Token: 0x02000075 RID: 117
	[Serializable]
	public class Profiles
	{
		// Token: 0x170002CF RID: 719
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00026C94 File Offset: 0x00024E94
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x00026CA8 File Offset: 0x00024EA8
		public List<Profile> List { get; set; } = new List<Profile>();
	}
}

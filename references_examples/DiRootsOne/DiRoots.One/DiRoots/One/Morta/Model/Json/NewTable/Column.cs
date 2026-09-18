using System;
using DiRoots.One.Morta.Model.Json.Column;

namespace DiRoots.One.Morta.Model.Json.NewTable
{
	// Token: 0x020001E1 RID: 481
	[Serializable]
	public class Column
	{
		// Token: 0x1700054D RID: 1357
		// (get) Token: 0x06001245 RID: 4677 RVA: 0x0006AEE0 File Offset: 0x000690E0
		// (set) Token: 0x06001246 RID: 4678 RVA: 0x0006AEF4 File Offset: 0x000690F4
		public string name { get; set; }

		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x06001247 RID: 4679 RVA: 0x0006AF08 File Offset: 0x00069108
		// (set) Token: 0x06001248 RID: 4680 RVA: 0x0006AF1C File Offset: 0x0006911C
		public int width { get; set; }

		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x06001249 RID: 4681 RVA: 0x0006AF30 File Offset: 0x00069130
		// (set) Token: 0x0600124A RID: 4682 RVA: 0x0006AF44 File Offset: 0x00069144
		public string kind { get; set; }

		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x0600124B RID: 4683 RVA: 0x0006AF58 File Offset: 0x00069158
		// (set) Token: 0x0600124C RID: 4684 RVA: 0x0006AF6C File Offset: 0x0006916C
		public Description description { get; set; }
	}
}

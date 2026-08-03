using System;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Interfaces;

namespace DiRoots.Prosheets.Commons.Models
{
	// Token: 0x02000058 RID: 88
	public class PluginInfo
	{
		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x00016974 File Offset: 0x00014B74
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x00016988 File Offset: 0x00014B88
		public string Name { get; set; }

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x0001699C File Offset: 0x00014B9C
		// (set) Token: 0x0600043C RID: 1084 RVA: 0x000169B0 File Offset: 0x00014BB0
		public ICustomLogger LoggerInstance { get; set; }

		// Token: 0x0400016C RID: 364
		[CompilerGenerated]
		private string \u000C;

		// Token: 0x0400016D RID: 365
		[CompilerGenerated]
		private ICustomLogger \u0018;
	}
}

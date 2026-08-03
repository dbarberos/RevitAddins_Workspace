using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using DiRoots.One.Commons.Attributes;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.SheetGen.TemplateTransfer.Model
{
	// Token: 0x020002E1 RID: 737
	public class TemplateTransferReport : Report
	{
		// Token: 0x1700086C RID: 2156
		// (get) Token: 0x06001E8C RID: 7820 RVA: 0x000C038C File Offset: 0x000BE58C
		// (set) Token: 0x06001E8D RID: 7821 RVA: 0x000C03A0 File Offset: 0x000BE5A0
		[Report("Report-ParameterName", 1.0, DataGridLengthUnitType.Star, false, false)]
		public string ParameterName { get; set; }

		// Token: 0x1700086D RID: 2157
		// (get) Token: 0x06001E8E RID: 7822 RVA: 0x000C03B4 File Offset: 0x000BE5B4
		// (set) Token: 0x06001E8F RID: 7823 RVA: 0x000C03C8 File Offset: 0x000BE5C8
		[Report("Report-Description", 3.0, DataGridLengthUnitType.Star, false, false)]
		public string Description { get; set; }

		// Token: 0x1700086E RID: 2158
		// (get) Token: 0x06001E90 RID: 7824 RVA: 0x000C03DC File Offset: 0x000BE5DC
		// (set) Token: 0x06001E91 RID: 7825 RVA: 0x000C03F0 File Offset: 0x000BE5F0
		public override ReportStates ReportState { get; set; }

		// Token: 0x04000C8B RID: 3211
		[CompilerGenerated]
		private string IB;

		// Token: 0x04000C8C RID: 3212
		[CompilerGenerated]
		private string CR;

		// Token: 0x04000C8D RID: 3213
		[CompilerGenerated]
		private ReportStates SL;
	}
}

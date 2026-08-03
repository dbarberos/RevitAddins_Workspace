using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using DiRoots.One.Commons.Attributes;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.ViewRange.Model
{
	// Token: 0x02000298 RID: 664
	public class ViewDetailReport : Report
	{
		// Token: 0x1700072A RID: 1834
		// (get) Token: 0x06001A06 RID: 6662 RVA: 0x000A79D0 File Offset: 0x000A5BD0
		// (set) Token: 0x06001A07 RID: 6663 RVA: 0x000A79E4 File Offset: 0x000A5BE4
		[Report("Report-ViewName", 1.0, DataGridLengthUnitType.Star, false, false)]
		public string ViewName { get; set; }

		// Token: 0x1700072B RID: 1835
		// (get) Token: 0x06001A08 RID: 6664 RVA: 0x000A79F8 File Offset: 0x000A5BF8
		// (set) Token: 0x06001A09 RID: 6665 RVA: 0x000A7A0C File Offset: 0x000A5C0C
		[Report("Report-Description", 3.0, DataGridLengthUnitType.Star, false, false)]
		public string Description { get; set; }

		// Token: 0x1700072C RID: 1836
		// (get) Token: 0x06001A0A RID: 6666 RVA: 0x000A7A20 File Offset: 0x000A5C20
		// (set) Token: 0x06001A0B RID: 6667 RVA: 0x000A7A34 File Offset: 0x000A5C34
		public override ReportStates ReportState { get; set; }

		// Token: 0x04000A56 RID: 2646
		[CompilerGenerated]
		private string YR;

		// Token: 0x04000A57 RID: 2647
		[CompilerGenerated]
		private string CR;

		// Token: 0x04000A58 RID: 2648
		[CompilerGenerated]
		private ReportStates SL;
	}
}

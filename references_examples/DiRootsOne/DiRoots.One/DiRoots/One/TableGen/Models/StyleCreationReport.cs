using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using A;
using DiRoots.One.Commons.Attributes;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.TableGen.Models
{
	// Token: 0x02000183 RID: 387
	public class StyleCreationReport : Report
	{
		// Token: 0x06000E67 RID: 3687 RVA: 0x0005BD58 File Offset: 0x00059F58
		public StyleCreationReport()
		{
			\u0020\u0014\u0007.\u000A(this, ReportStates.Successful);
		}

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06000E68 RID: 3688 RVA: 0x0005BD74 File Offset: 0x00059F74
		// (set) Token: 0x06000E69 RID: 3689 RVA: 0x0005BD88 File Offset: 0x00059F88
		[Report("TG-StyleType", 120.0, DataGridLengthUnitType.Pixel, false, false)]
		public string StyleType { get; set; }

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06000E6A RID: 3690 RVA: 0x0005BD9C File Offset: 0x00059F9C
		// (set) Token: 0x06000E6B RID: 3691 RVA: 0x0005BDB0 File Offset: 0x00059FB0
		[Report("TG-StyleName", 1.0, DataGridLengthUnitType.Star, false, false)]
		public string StyleName { get; set; }

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06000E6C RID: 3692 RVA: 0x0005BDC4 File Offset: 0x00059FC4
		// (set) Token: 0x06000E6D RID: 3693 RVA: 0x0005BDD8 File Offset: 0x00059FD8
		[Report("TG-Status", 100.0, DataGridLengthUnitType.Pixel, false, false)]
		public string Status { get; set; }

		// Token: 0x040005AF RID: 1455
		[CompilerGenerated]
		private string JH;

		// Token: 0x040005B0 RID: 1456
		[CompilerGenerated]
		private string EH;

		// Token: 0x040005B1 RID: 1457
		[CompilerGenerated]
		private string NH;
	}
}

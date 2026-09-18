using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using DiRoots.One.Commons.Attributes;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.TableGen.Models
{
	// Token: 0x02000181 RID: 385
	public class DragReportInfo : Report
	{
		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x06000E59 RID: 3673 RVA: 0x0005BBF8 File Offset: 0x00059DF8
		// (set) Token: 0x06000E58 RID: 3672 RVA: 0x0005BBE4 File Offset: 0x00059DE4
		[Report("TG-FilePath", 1.5, DataGridLengthUnitType.Star, false, false)]
		public string FilePath { get; set; }

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x06000E5B RID: 3675 RVA: 0x0005BC20 File Offset: 0x00059E20
		// (set) Token: 0x06000E5A RID: 3674 RVA: 0x0005BC0C File Offset: 0x00059E0C
		[Report("Report-Message", 1.0, DataGridLengthUnitType.Star, false, false, WrapText = true)]
		public string Message { get; set; }

		// Token: 0x040005A9 RID: 1449
		[CompilerGenerated]
		private string BH;

		// Token: 0x040005AA RID: 1450
		[CompilerGenerated]
		private string UH;
	}
}

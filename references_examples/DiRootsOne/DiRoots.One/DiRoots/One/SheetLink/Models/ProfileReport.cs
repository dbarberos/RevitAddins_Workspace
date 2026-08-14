using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using DiRoots.One.Commons.Attributes;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x0200024E RID: 590
	public class ProfileReport : Report
	{
		// Token: 0x170006A6 RID: 1702
		// (get) Token: 0x060017FC RID: 6140 RVA: 0x0009BDA8 File Offset: 0x00099FA8
		// (set) Token: 0x060017FD RID: 6141 RVA: 0x0009BDBC File Offset: 0x00099FBC
		[Report("Report-ParameterName", 120.0, DataGridLengthUnitType.Pixel, false, false)]
		public string Name { get; set; }

		// Token: 0x170006A7 RID: 1703
		// (get) Token: 0x060017FE RID: 6142 RVA: 0x0009BDD0 File Offset: 0x00099FD0
		// (set) Token: 0x060017FF RID: 6143 RVA: 0x0009BDE4 File Offset: 0x00099FE4
		[Report("Report-Message", 1.5, DataGridLengthUnitType.Star, false, false)]
		public string Message { get; set; }

		// Token: 0x04000971 RID: 2417
		[CompilerGenerated]
		private string K;

		// Token: 0x04000972 RID: 2418
		[CompilerGenerated]
		private string UH;
	}
}

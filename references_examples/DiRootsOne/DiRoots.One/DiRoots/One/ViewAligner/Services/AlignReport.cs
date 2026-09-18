using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using DiRoots.One.Commons.Attributes;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.ViewAligner.Services
{
	// Token: 0x020000C3 RID: 195
	public class AlignReport : Report
	{
		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000796 RID: 1942 RVA: 0x0002BD98 File Offset: 0x00029F98
		// (set) Token: 0x06000797 RID: 1943 RVA: 0x0002BDAC File Offset: 0x00029FAC
		[Report("Common-SheetNumber", 1.0, DataGridLengthUnitType.Star, false, false)]
		public string SheetNumber { get; set; }

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000798 RID: 1944 RVA: 0x0002BDC0 File Offset: 0x00029FC0
		// (set) Token: 0x06000799 RID: 1945 RVA: 0x0002BDD4 File Offset: 0x00029FD4
		[Report("Common-ViewName", 1.0, DataGridLengthUnitType.Star, false, false)]
		public string ViewName { get; set; }

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x0600079A RID: 1946 RVA: 0x0002BDE8 File Offset: 0x00029FE8
		// (set) Token: 0x0600079B RID: 1947 RVA: 0x0002BDFC File Offset: 0x00029FFC
		[Report("Common-Description", 3.0, DataGridLengthUnitType.Star, false, false)]
		public string Description { get; set; }

		// Token: 0x0400030E RID: 782
		[CompilerGenerated]
		private string HR;

		// Token: 0x0400030F RID: 783
		[CompilerGenerated]
		private string YR;

		// Token: 0x04000310 RID: 784
		[CompilerGenerated]
		private string CR;
	}
}

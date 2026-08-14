using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000239 RID: 569
	public class ControlExcelBase
	{
		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x06001693 RID: 5779 RVA: 0x00093BDC File Offset: 0x00091DDC
		// (set) Token: 0x06001694 RID: 5780 RVA: 0x00093BF0 File Offset: 0x00091DF0
		public bool CloseWorkbook { get; set; }

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x06001695 RID: 5781 RVA: 0x00093C04 File Offset: 0x00091E04
		// (set) Token: 0x06001696 RID: 5782 RVA: 0x00093C18 File Offset: 0x00091E18
		public List<Workbook> Workbooks { get; set; }

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x06001697 RID: 5783 RVA: 0x00093C2C File Offset: 0x00091E2C
		// (set) Token: 0x06001698 RID: 5784 RVA: 0x00093C40 File Offset: 0x00091E40
		public List<ParamValueInfo> ParamValues { get; set; }

		// Token: 0x040008F6 RID: 2294
		[CompilerGenerated]
		private bool \u001F;

		// Token: 0x040008F7 RID: 2295
		[CompilerGenerated]
		private List<Workbook> \u000A;

		// Token: 0x040008F8 RID: 2296
		[CompilerGenerated]
		private List<ParamValueInfo> \u0007;
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.PanelLink.Models;

namespace DiRoots.One.PanelLink
{
	// Token: 0x02000195 RID: 405
	public class PanelData
	{
		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x06000EFD RID: 3837 RVA: 0x0005F270 File Offset: 0x0005D470
		// (set) Token: 0x06000EFE RID: 3838 RVA: 0x0005F284 File Offset: 0x0005D484
		public List<ExcelSheetInfo> ExcelSheets { get; set; }

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06000EFF RID: 3839 RVA: 0x0005F298 File Offset: 0x0005D498
		// (set) Token: 0x06000F00 RID: 3840 RVA: 0x0005F2AC File Offset: 0x0005D4AC
		public Element RevitElement { get; set; }

		// Token: 0x040005E3 RID: 1507
		[CompilerGenerated]
		private List<ExcelSheetInfo> \u001F;

		// Token: 0x040005E4 RID: 1508
		[CompilerGenerated]
		private Element \u000A;
	}
}

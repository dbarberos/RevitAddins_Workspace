using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace DiRoots.One.PanelLink.Models
{
	// Token: 0x020001A7 RID: 423
	public class PanelParameters
	{
		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06000FB6 RID: 4022 RVA: 0x00062AD0 File Offset: 0x00060CD0
		// (set) Token: 0x06000FB7 RID: 4023 RVA: 0x00062AE4 File Offset: 0x00060CE4
		public ElementId TemplateId { get; set; }

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06000FB8 RID: 4024 RVA: 0x00062AF8 File Offset: 0x00060CF8
		// (set) Token: 0x06000FB9 RID: 4025 RVA: 0x00062B0C File Offset: 0x00060D0C
		public List<PanelParameter> CircuitParams { get; set; }

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06000FBA RID: 4026 RVA: 0x00062B20 File Offset: 0x00060D20
		// (set) Token: 0x06000FBB RID: 4027 RVA: 0x00062B34 File Offset: 0x00060D34
		public List<PanelParameter> EquipParameters { get; set; }

		// Token: 0x04000649 RID: 1609
		[CompilerGenerated]
		private ElementId \u001F;

		// Token: 0x0400064A RID: 1610
		[CompilerGenerated]
		private List<PanelParameter> \u000A;

		// Token: 0x0400064B RID: 1611
		[CompilerGenerated]
		private List<PanelParameter> \u0007;
	}
}

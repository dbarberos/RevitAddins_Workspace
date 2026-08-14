using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace DiRoots.One.PanelLink
{
	// Token: 0x02000192 RID: 402
	public class Equipment
	{
		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x06000EE5 RID: 3813 RVA: 0x0005EC6C File Offset: 0x0005CE6C
		// (set) Token: 0x06000EE6 RID: 3814 RVA: 0x0005EC80 File Offset: 0x0005CE80
		public string Name { get; set; }

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x06000EE7 RID: 3815 RVA: 0x0005EC94 File Offset: 0x0005CE94
		// (set) Token: 0x06000EE8 RID: 3816 RVA: 0x0005ECA8 File Offset: 0x0005CEA8
		public bool IsChecked { get; set; }

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06000EE9 RID: 3817 RVA: 0x0005ECBC File Offset: 0x0005CEBC
		// (set) Token: 0x06000EEA RID: 3818 RVA: 0x0005ECD0 File Offset: 0x0005CED0
		public ElementId Id { get; set; }

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06000EEB RID: 3819 RVA: 0x0005ECE4 File Offset: 0x0005CEE4
		// (set) Token: 0x06000EEC RID: 3820 RVA: 0x0005ECF8 File Offset: 0x0005CEF8
		public Element PanelElement { get; set; }

		// Token: 0x040005DA RID: 1498
		[CompilerGenerated]
		private string \u001F;

		// Token: 0x040005DB RID: 1499
		[CompilerGenerated]
		private bool \u000A;

		// Token: 0x040005DC RID: 1500
		[CompilerGenerated]
		private ElementId \u0007;

		// Token: 0x040005DD RID: 1501
		[CompilerGenerated]
		private Element \u001D;
	}
}

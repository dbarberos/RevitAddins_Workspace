using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;

namespace DiRoots.One.PanelLink
{
	// Token: 0x02000193 RID: 403
	public class PanelSectionPart
	{
		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06000EEE RID: 3822 RVA: 0x0005ED20 File Offset: 0x0005CF20
		// (set) Token: 0x06000EEF RID: 3823 RVA: 0x0005ED34 File Offset: 0x0005CF34
		public SectionType SectionType { get; set; }

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x0005ED5C File Offset: 0x0005CF5C
		// (set) Token: 0x06000EF0 RID: 3824 RVA: 0x0005ED48 File Offset: 0x0005CF48
		public string Name { get; set; }

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06000EF2 RID: 3826 RVA: 0x0005ED70 File Offset: 0x0005CF70
		// (set) Token: 0x06000EF3 RID: 3827 RVA: 0x0005ED84 File Offset: 0x0005CF84
		public int NumberOfRows { get; set; }

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x06000EF4 RID: 3828 RVA: 0x0005ED98 File Offset: 0x0005CF98
		// (set) Token: 0x06000EF5 RID: 3829 RVA: 0x0005EDAC File Offset: 0x0005CFAC
		public int NumberOfColumns { get; set; }

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x06000EF6 RID: 3830 RVA: 0x0005EDC0 File Offset: 0x0005CFC0
		// (set) Token: 0x06000EF7 RID: 3831 RVA: 0x0005EDD4 File Offset: 0x0005CFD4
		public PanelScheduleView ScheduleView { get; set; }

		// Token: 0x040005DE RID: 1502
		[CompilerGenerated]
		private SectionType \u001F;

		// Token: 0x040005DF RID: 1503
		[CompilerGenerated]
		private string \u000A;

		// Token: 0x040005E0 RID: 1504
		[CompilerGenerated]
		private int \u0007;

		// Token: 0x040005E1 RID: 1505
		[CompilerGenerated]
		private int \u001D;

		// Token: 0x040005E2 RID: 1506
		[CompilerGenerated]
		private PanelScheduleView \u0004;
	}
}

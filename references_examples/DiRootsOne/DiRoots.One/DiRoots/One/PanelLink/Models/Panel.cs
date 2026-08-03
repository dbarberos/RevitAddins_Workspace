using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.PanelLink.Models
{
	// Token: 0x020001A5 RID: 421
	public class Panel : ModelBase
	{
		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x06000F9F RID: 3999 RVA: 0x000628A8 File Offset: 0x00060AA8
		// (set) Token: 0x06000FA0 RID: 4000 RVA: 0x000628BC File Offset: 0x00060ABC
		public string Name { get; set; }

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06000FA1 RID: 4001 RVA: 0x000628D0 File Offset: 0x00060AD0
		// (set) Token: 0x06000FA2 RID: 4002 RVA: 0x000628E4 File Offset: 0x00060AE4
		public bool IsActiveView
		{
			get
			{
				return this.MH;
			}
			set
			{
				this.MH = value;
				\u0007\u0013\u000A.\u000A(this, "IsActiveView");
			}
		}

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06000FA3 RID: 4003 RVA: 0x00062904 File Offset: 0x00060B04
		// (set) Token: 0x06000FA4 RID: 4004 RVA: 0x00062918 File Offset: 0x00060B18
		public Element RevitElement { get; set; }

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06000FA5 RID: 4005 RVA: 0x0006292C File Offset: 0x00060B2C
		// (set) Token: 0x06000FA6 RID: 4006 RVA: 0x00062940 File Offset: 0x00060B40
		public PanelScheduleView PanelScheduleView { get; set; }

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06000FA7 RID: 4007 RVA: 0x00062954 File Offset: 0x00060B54
		// (set) Token: 0x06000FA8 RID: 4008 RVA: 0x00062968 File Offset: 0x00060B68
		public TableData TableData { get; set; }

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06000FAA RID: 4010 RVA: 0x00062990 File Offset: 0x00060B90
		// (set) Token: 0x06000FA9 RID: 4009 RVA: 0x0006297C File Offset: 0x00060B7C
		public List<PanelSectionPart> PanelSectionParts { get; set; }

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06000FAB RID: 4011 RVA: 0x000629A4 File Offset: 0x00060BA4
		// (set) Token: 0x06000FAC RID: 4012 RVA: 0x000629B8 File Offset: 0x00060BB8
		public bool FilterPassed { get; set; }

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06000FAD RID: 4013 RVA: 0x000629CC File Offset: 0x00060BCC
		// (set) Token: 0x06000FAE RID: 4014 RVA: 0x000629E0 File Offset: 0x00060BE0
		public bool IsSelected
		{
			get
			{
				return this.VH;
			}
			set
			{
				this.VH = value;
				\u0007\u0013\u000A.\u000A(this, "IsSelected");
			}
		}

		// Token: 0x0400063F RID: 1599
		private bool MH;

		// Token: 0x04000640 RID: 1600
		private bool VH;

		// Token: 0x04000641 RID: 1601
		[CompilerGenerated]
		private string K;

		// Token: 0x04000642 RID: 1602
		[CompilerGenerated]
		private Element ZH;

		// Token: 0x04000643 RID: 1603
		[CompilerGenerated]
		private PanelScheduleView XH;

		// Token: 0x04000644 RID: 1604
		[CompilerGenerated]
		private TableData PH;

		// Token: 0x04000645 RID: 1605
		[CompilerGenerated]
		private List<PanelSectionPart> OH;

		// Token: 0x04000646 RID: 1606
		[CompilerGenerated]
		private bool TH;
	}
}

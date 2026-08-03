using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;

namespace ProSheets.Models
{
	// Token: 0x02000100 RID: 256
	public class DataGridBrowserOrganization : ModelBase
	{
		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06000C83 RID: 3203 RVA: 0x0004A0C0 File Offset: 0x000482C0
		// (set) Token: 0x06000C84 RID: 3204 RVA: 0x0004A0D4 File Offset: 0x000482D4
		public List<BrowserOrganization> BrowserOrganizations { get; set; }

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06000C85 RID: 3205 RVA: 0x0004A0E8 File Offset: 0x000482E8
		// (set) Token: 0x06000C86 RID: 3206 RVA: 0x0004A0FC File Offset: 0x000482FC
		public List<PropertyGroupDescription> GroupDescriptions { get; set; }

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06000C87 RID: 3207 RVA: 0x0004A110 File Offset: 0x00048310
		// (set) Token: 0x06000C88 RID: 3208 RVA: 0x0004A124 File Offset: 0x00048324
		public BrowserOrganization SelectedBrowserOrganization
		{
			get
			{
				return this.WB;
			}
			set
			{
				this.WB = value;
				\u0007\u001B\u0018.\u0018(this, "SelectedBrowserOrganization");
			}
		}

		// Token: 0x040005BA RID: 1466
		private BrowserOrganization WB;

		// Token: 0x040005BB RID: 1467
		[CompilerGenerated]
		private List<BrowserOrganization> TB;

		// Token: 0x040005BC RID: 1468
		[CompilerGenerated]
		private List<PropertyGroupDescription> IB;
	}
}

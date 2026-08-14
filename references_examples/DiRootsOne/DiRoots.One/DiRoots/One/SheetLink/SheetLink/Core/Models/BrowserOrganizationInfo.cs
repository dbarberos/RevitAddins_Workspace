using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.SheetLink.SheetLink.Core.Models
{
	// Token: 0x02000263 RID: 611
	public class BrowserOrganizationInfo : EnumInfo
	{
		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x060018B8 RID: 6328 RVA: 0x000A0AA4 File Offset: 0x0009ECA4
		// (set) Token: 0x060018B9 RID: 6329 RVA: 0x000A0AB8 File Offset: 0x0009ECB8
		public BrowserOrganization BrowserOrg { get; set; }

		// Token: 0x040009A8 RID: 2472
		[CompilerGenerated]
		private BrowserOrganization VC;
	}
}

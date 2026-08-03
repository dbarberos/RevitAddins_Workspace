using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;

namespace ProSheets.DrawingRegister.Model
{
	// Token: 0x0200011C RID: 284
	public class LinkDocumentSheetCollector
	{
		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06000E58 RID: 3672 RVA: 0x0005411C File Offset: 0x0005231C
		// (set) Token: 0x06000E59 RID: 3673 RVA: 0x00054130 File Offset: 0x00052330
		public string DocName { get; set; }

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06000E5A RID: 3674 RVA: 0x00054144 File Offset: 0x00052344
		// (set) Token: 0x06000E5B RID: 3675 RVA: 0x00054158 File Offset: 0x00052358
		public Document Doc { get; set; }

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06000E5C RID: 3676 RVA: 0x0005416C File Offset: 0x0005236C
		// (set) Token: 0x06000E5D RID: 3677 RVA: 0x00054180 File Offset: 0x00052380
		public List<ViewSheet> AllSheets { get; set; }

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06000E5E RID: 3678 RVA: 0x00054194 File Offset: 0x00052394
		public Dictionary<string, object> BrowserOrganization
		{
			get
			{
				return \u0019\u0015\u0018.\u000C(\u0006\u000C\u000F.\u0003(this));
			}
		}

		// Token: 0x0400067A RID: 1658
		[CompilerGenerated]
		private string \u000C;

		// Token: 0x0400067B RID: 1659
		[CompilerGenerated]
		private Document \u0018;

		// Token: 0x0400067C RID: 1660
		[CompilerGenerated]
		private List<ViewSheet> \u0014;
	}
}

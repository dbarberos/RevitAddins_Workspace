using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x020000C6 RID: 198
	internal static class \u0006\u0020\u0018
	{
		// Token: 0x06000B0E RID: 2830 RVA: 0x00041618 File Offset: 0x0003F818
		internal static List<BrowserOrganization> \u000C(Document \u000C)
		{
			\u0006\u0020\u0018.\u0007\u0020\u0018 u0007_u0020_u = new \u0006\u0020\u0018.\u0007\u0020\u0018();
			u0007_u0020_u.\u000C = \u000C;
			return Enumerable.ToList<BrowserOrganization>(Enumerable.Cast<BrowserOrganization>(Enumerable.Select<ElementId, Element>(\u0017\u001C\u0016.\u0018(\u001E\u001C\u0016.\u0018(u0007_u0020_u.\u000C)), new Func<ElementId, Element>(u0007_u0020_u.\u0018))));
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x00041668 File Offset: 0x0003F868
		internal static List<BrowserOrganization> \u0018(Document \u000C)
		{
			\u0006\u0020\u0018.\u0010\u0020\u0018 u0010_u0020_u = new \u0006\u0020\u0018.\u0010\u0020\u0018();
			u0010_u0020_u.\u000C = \u000C;
			return Enumerable.ToList<BrowserOrganization>(Enumerable.Cast<BrowserOrganization>(Enumerable.Select<ElementId, Element>(\u0017\u001C\u0016.\u0018(\u0002\u001C\u0016.\u0018(u0010_u0020_u.\u000C)), new Func<ElementId, Element>(u0010_u0020_u.\u0018))));
		}

		// Token: 0x020001C8 RID: 456
		[CompilerGenerated]
		private sealed class \u0007\u0020\u0018
		{
			// Token: 0x060011E0 RID: 4576 RVA: 0x0005D64C File Offset: 0x0005B84C
			internal Element \u0018(ElementId \u000C)
			{
				return \u0003\u0004\u0018.\u0018(this.\u000C, \u000C);
			}

			// Token: 0x04000877 RID: 2167
			public Document \u000C;
		}

		// Token: 0x020001C9 RID: 457
		[CompilerGenerated]
		private sealed class \u0010\u0020\u0018
		{
			// Token: 0x060011E2 RID: 4578 RVA: 0x0005D67C File Offset: 0x0005B87C
			internal Element \u0018(ElementId \u000C)
			{
				return \u0003\u0004\u0018.\u0018(this.\u000C, \u000C);
			}

			// Token: 0x04000878 RID: 2168
			public Document \u000C;
		}
	}
}

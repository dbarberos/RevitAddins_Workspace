using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.SheetLink.SheetLink.Core.Models;

namespace A
{
	// Token: 0x02000265 RID: 613
	internal static class \u0018\u0010
	{
		// Token: 0x060018CC RID: 6348 RVA: 0x000A0DDC File Offset: 0x0009EFDC
		public static List<EnumInfo> \u001F(Document \u001F)
		{
			BrowserOrganization u000A = \u0015\u0013\u0005.\u000A(\u001F);
			return \u0018\u0010.\u000A(\u001F, u000A);
		}

		// Token: 0x060018CD RID: 6349 RVA: 0x000A0DFC File Offset: 0x0009EFFC
		private static List<EnumInfo> \u000A(Document \u001F, BrowserOrganization \u000A)
		{
			\u0018\u0010.\u0019\u0010 u0019_u = new \u0018\u0010.\u0019\u0010();
			u0019_u.\u001F = \u001F;
			List<EnumInfo> list = \u0019\u001A\u0005.\u000A();
			if (\u000A == null)
			{
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0010.\u000A(Document, BrowserOrganization)).MethodHandle;
				}
				return list;
			}
			List<BrowserOrganization>.Enumerator enumerator = \u001D\u001A\u0005.\u000A(Enumerable.ToList<BrowserOrganization>(Enumerable.Cast<BrowserOrganization>(Enumerable.Select<ElementId, Element>(\u0004\u001A\u0005.\u000A(\u000A), new Func<ElementId, Element>(u0019_u.\u000A)))));
			try
			{
				while (\u0001\u0013\u0005.\u000A(ref enumerator))
				{
					BrowserOrganization browserOrganization = \u0007\u001A\u0005.\u000A(ref enumerator);
					object u001F = list;
					BrowserOrganizationInfo browserOrganizationInfo = \u000A\u001A\u0005.\u000A();
					\u0009\u001B\u001D.\u000A(browserOrganizationInfo, (int)\u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(browserOrganization)));
					\u0001\u001B\u001D.\u000A(browserOrganizationInfo, \u0005\u001E\u000A.\u000A(browserOrganization));
					\u001E\u0014\u0004.\u000A(browserOrganizationInfo, \u0005\u001E\u000A.\u000A(browserOrganization));
					\u001F\u001A\u0005.\u000A(browserOrganizationInfo, browserOrganization);
					\u0009\u0013\u0005.\u000A(browserOrganizationInfo, new bool?(false));
					\u0008\u0014\u0004.\u000A(u001F, browserOrganizationInfo);
				}
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x0200093E RID: 2366
		[CompilerGenerated]
		private sealed class \u0019\u0010
		{
			// Token: 0x0600522F RID: 21039 RVA: 0x001EA134 File Offset: 0x001E8334
			internal Element \u000A(ElementId \u001F)
			{
				return \u0011\u0017\u000A.\u0007(this.\u001F, \u001F);
			}

			// Token: 0x0400243D RID: 9277
			public Document \u001F;
		}
	}
}

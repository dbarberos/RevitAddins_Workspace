using System;
using DiRoots.One.SheetLink.Morta.Enums;
using RestSharp;

namespace A
{
	// Token: 0x0200028B RID: 651
	internal static class \u0003\u000E
	{
		// Token: 0x0600195E RID: 6494 RVA: 0x000A40E8 File Offset: 0x000A22E8
		internal static Method \u001F(CustomRequestMethod \u001F)
		{
			switch (\u001F)
			{
			case CustomRequestMethod.Post:
				return Method.POST;
			case CustomRequestMethod.Delete:
				return Method.DELETE;
			case CustomRequestMethod.Put:
				return Method.PUT;
			default:
				return Method.GET;
			}
		}
	}
}

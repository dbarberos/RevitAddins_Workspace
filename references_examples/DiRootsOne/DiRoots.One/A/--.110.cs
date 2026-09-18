using System;
using RestSharp;

namespace A
{
	// Token: 0x020001F5 RID: 501
	internal static class \u0007\u000F
	{
		// Token: 0x060012C6 RID: 4806 RVA: 0x0006BFC0 File Offset: 0x0006A1C0
		internal static RestRequest \u001F(this RestRequest \u001F, string \u000A)
		{
			\u0016\u0016\u0018.\u000A(\u001F, "Accept", "application/json");
			\u0016\u0016\u0018.\u000A(\u001F, "Authorization", \u0004\u001E\u000A.\u000A("Bearer ", \u000A));
			return \u001F;
		}

		// Token: 0x060012C7 RID: 4807 RVA: 0x0006BFFC File Offset: 0x0006A1FC
		internal static RestRequest \u000A(this RestRequest \u001F)
		{
			\u0016\u0016\u0018.\u000A(\u001F, "Content-Type", "application/json");
			return \u001F;
		}
	}
}

using System;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x0200025C RID: 604
	internal class \u000C\u000D : \u001F\u0010
	{
		// Token: 0x06001891 RID: 6289 RVA: 0x0009EF1C File Offset: 0x0009D11C
		public \u000C\u000D()
		{
			\u0012\u0014\u0005.\u000A(this, "SheetLink_CreateRoom");
		}

		// Token: 0x06001892 RID: 6290 RVA: 0x0009EF3C File Offset: 0x0009D13C
		public override Element \u0018(Phase \u001F)
		{
			return \u0003\u0014\u0005.\u000A(\u000B\u0001\u001D.\u000A(\u001C\u0014\u0005.\u000A(this)), \u001F);
		}
	}
}

using System;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.SheetGen.Data;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002C4 RID: 708
	public class UserSelectionContext
	{
		// Token: 0x1700080B RID: 2059
		// (get) Token: 0x06001CC1 RID: 7361 RVA: 0x000B69D8 File Offset: 0x000B4BD8
		public Document CurrentDocument
		{
			get
			{
				return \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004);
			}
		}

		// Token: 0x06001CC2 RID: 7362 RVA: 0x000B69F4 File Offset: 0x000B4BF4
		public void Clear()
		{
		}
	}
}

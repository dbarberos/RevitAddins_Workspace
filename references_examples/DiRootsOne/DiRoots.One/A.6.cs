using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x0200004B RID: 75
	internal class \u0020\u000A : IEqualityComparer<XYZ>
	{
		// Token: 0x0600026B RID: 619 RVA: 0x0000CFA8 File Offset: 0x0000B1A8
		public bool Equals(XYZ dir1, XYZ dir2)
		{
			object u001F = \u0007\u000A\u0007.\u000A(dir1);
			XYZ u000A = \u0007\u000A\u0007.\u000A(dir2);
			double u = 0.001;
			return \u0011\u0007\u0007.\u000A(u001F, u000A, u);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000CFDC File Offset: 0x0000B1DC
		public int GetHashCode(XYZ dir)
		{
			XYZ u001F = \u0007\u000A\u0007.\u000A(dir);
			return \u001B\u0013\u000A.\u000A(\u001E\u0007\u0007.\u000A("{0},{1},{2}", \u000D\u001F\u0007.\u000A(u001F), \u001C\u001F\u0007.\u000A(u001F), \u0003\u000A\u0007.\u000A(u001F)));
		}
	}
}

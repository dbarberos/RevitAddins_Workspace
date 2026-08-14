using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000055 RID: 85
	internal class \u0008\u0007 : IEqualityComparer<XYZ>
	{
		// Token: 0x060002D6 RID: 726 RVA: 0x00012E64 File Offset: 0x00011064
		public bool Equals(XYZ p, XYZ q)
		{
			if (\u0008\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(p) - \u000D\u001F\u0007.\u000A(q)) <= 1E-05)
			{
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0007.Equals(XYZ, XYZ)).MethodHandle;
				}
				if (\u0008\u001F\u0007.\u000A(\u001C\u001F\u0007.\u000A(p) - \u001C\u001F\u0007.\u000A(q)) <= 1E-05)
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
					return \u0008\u001F\u0007.\u000A(\u0003\u000A\u0007.\u000A(p) - \u0003\u000A\u0007.\u000A(q)) <= 1E-05;
				}
			}
			return false;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00012EFC File Offset: 0x000110FC
		public int GetHashCode(XYZ obj)
		{
			return \u001B\u0013\u000A.\u000A(\u001A\u000C\u000A.\u000A(obj));
		}

		// Token: 0x0400010B RID: 267
		private static double \u001F;
	}
}

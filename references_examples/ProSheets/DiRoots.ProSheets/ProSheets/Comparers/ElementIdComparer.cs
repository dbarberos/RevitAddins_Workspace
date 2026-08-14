using System;
using System.Collections.Generic;
using A;
using ProSheets.Models;

namespace ProSheets.Comparers
{
	// Token: 0x02000136 RID: 310
	public class ElementIdComparer : IEqualityComparer<SheetInfo>
	{
		// Token: 0x06000F7F RID: 3967 RVA: 0x000581E8 File Offset: 0x000563E8
		public bool Equals(SheetInfo x, SheetInfo y)
		{
			if (x != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementIdComparer.Equals(SheetInfo, SheetInfo)).MethodHandle;
				}
				if (y != null)
				{
					return \u0016\u0008\u0014.\u0018(\u0015\u0005\u0018.\u0014(x), \u0015\u0005\u0018.\u0014(y));
				}
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x00058234 File Offset: 0x00056434
		public int GetHashCode(SheetInfo obj)
		{
			if (obj == null)
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementIdComparer.GetHashCode(SheetInfo)).MethodHandle;
				}
				return 0;
			}
			return \u0002\u001B\u0018.\u0018(\u0015\u0005\u0018.\u0014(obj));
		}
	}
}

using System;
using System.Collections.Generic;
using DiRoots.One.OneFilter.CommonLibrary.Models;

namespace A
{
	// Token: 0x02000029 RID: 41
	internal class \u0007\u000A : IEqualityComparer<SelectionInfo>
	{
		// Token: 0x06000165 RID: 357 RVA: 0x00007C90 File Offset: 0x00005E90
		public bool Equals(SelectionInfo p, SelectionInfo q)
		{
			if (p != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0007\u000A.Equals(SelectionInfo, SelectionInfo)).MethodHandle;
				}
				if (q == null)
				{
					for (;;)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				else
				{
					if (\u0006\u0017\u000A.\u000A(p) == \u0006\u0017\u000A.\u000A(q))
					{
						for (;;)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							break;
						}
						return \u0008\u0013\u000A.\u000A(\u0002\u0017\u000A.\u000A(p), \u0002\u0017\u000A.\u000A(q));
					}
					return false;
				}
			}
			return false;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00007CF8 File Offset: 0x00005EF8
		public int GetHashCode(SelectionInfo obj)
		{
			long num = \u0006\u0017\u000A.\u000A(obj);
			return \u001B\u0013\u000A.\u000A(\u0004\u001E\u000A.\u000A(\u0011\u0013\u000A.\u000A(ref num), \u0002\u0017\u000A.\u000A(obj)));
		}
	}
}

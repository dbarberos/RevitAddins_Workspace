using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x020000A8 RID: 168
	internal class \u000E\u0004 : IEqualityComparer<Parameter>
	{
		// Token: 0x060006C4 RID: 1732 RVA: 0x000271EC File Offset: 0x000253EC
		public bool Equals(Parameter x, Parameter y)
		{
			if (x != null)
			{
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u0004.Equals(Parameter, Parameter)).MethodHandle;
				}
				if (y != null)
				{
					if (\u0011\u0016\u001D.\u000A(\u0014\u001F\u001D.\u0007(x), \u0014\u001F\u001D.\u0007(y)))
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
						if (\u0008\u0013\u000A.\u000A(\u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(x)), \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(y))))
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
							return \u0011\u001F\u001D.\u0007(x) == \u0011\u001F\u001D.\u0007(y);
						}
					}
					return false;
				}
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
			return false;
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00027288 File Offset: 0x00025488
		public int GetHashCode(Parameter obj)
		{
			return \u001B\u0013\u000A.\u000A(\u0014\u001F\u001D.\u0007(obj));
		}
	}
}

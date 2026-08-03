using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000288 RID: 648
	internal class \u000F\u000E : IEqualityComparer<Parameter>
	{
		// Token: 0x06001951 RID: 6481 RVA: 0x000A3C48 File Offset: 0x000A1E48
		public bool Equals(Parameter rp1, Parameter rp2)
		{
			if (rp1 != null)
			{
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000E.Equals(Parameter, Parameter)).MethodHandle;
				}
				if (rp2 == null)
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
				}
				else
				{
					if (\u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(rp1)) == \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(rp2)))
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
						return true;
					}
					return false;
				}
			}
			return false;
		}

		// Token: 0x06001952 RID: 6482 RVA: 0x000A3CA8 File Offset: 0x000A1EA8
		public int GetHashCode(Parameter rp)
		{
			long num = \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(rp));
			return \u0007\u000A\u001D.\u000A(ref num);
		}
	}
}

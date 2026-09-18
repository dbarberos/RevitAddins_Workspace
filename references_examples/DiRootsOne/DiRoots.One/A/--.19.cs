using System;
using System.Collections.Generic;
using DiRoots.RoomPro.Models;

namespace A
{
	// Token: 0x020000A9 RID: 169
	internal class \u0008\u0004 : IEqualityComparer<ViewsReport>
	{
		// Token: 0x060006C7 RID: 1735 RVA: 0x000272B8 File Offset: 0x000254B8
		public bool Equals(ViewsReport p, ViewsReport q)
		{
			if (p != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0004.Equals(ViewsReport, ViewsReport)).MethodHandle;
				}
				if (q != null)
				{
					if (\u001A\u0016\u001D.\u000A(p) == \u001A\u0016\u001D.\u000A(q))
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
						if (\u0008\u0013\u000A.\u000A(\u0013\u0016\u001D.\u000A(p), \u0013\u0016\u001D.\u000A(q)))
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
							if (\u0008\u0013\u000A.\u000A(\u0014\u0016\u001D.\u000A(p), \u0014\u0016\u001D.\u000A(q)))
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
								if (\u0017\u0016\u001D.\u000A(p) == \u0017\u0016\u001D.\u000A(q))
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
									if (\u0008\u0013\u000A.\u000A(\u0020\u0016\u001D.\u000A(p), \u0020\u0016\u001D.\u000A(q)))
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
										return \u0008\u0013\u000A.\u000A(\u001E\u0016\u001D.\u000A(p), \u001E\u0016\u001D.\u000A(q));
									}
								}
							}
						}
					}
					return false;
				}
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x000273AC File Offset: 0x000255AC
		public int GetHashCode(ViewsReport obj)
		{
			long num = \u001A\u0016\u001D.\u000A(obj);
			return \u0007\u000A\u001D.\u000A(ref num);
		}
	}
}

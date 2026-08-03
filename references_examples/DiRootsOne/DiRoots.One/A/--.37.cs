using System;
using System.Drawing;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x020000DD RID: 221
	internal static class \u0015\u0019
	{
		// Token: 0x06000869 RID: 2153 RVA: 0x00032C0C File Offset: 0x00030E0C
		internal static Color \u001F(this Color \u001F)
		{
			if (\u0015\u0017\u001D.\u000A(ref \u001F) == 255)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(Color.\u001F()).MethodHandle;
				}
				if (\u000C\u0017\u001D.\u000A(ref \u001F) == 255)
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
					if (\u0013\u0017\u001D.\u000A(ref \u001F) == 255)
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
						return \u001C\u000C\u001D.\u000A(254, 254, 254);
					}
				}
			}
			return \u001C\u000C\u001D.\u000A(\u0015\u0017\u001D.\u000A(ref \u001F), \u000C\u0017\u001D.\u000A(ref \u001F), \u0013\u0017\u001D.\u000A(ref \u001F));
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x00032CAC File Offset: 0x00030EAC
		internal static bool \u000A(this Color \u001F, Color \u000A)
		{
			if (\u0015\u0017\u001D.\u000A(ref \u001F) == \u0015\u0017\u001D.\u000A(ref \u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Color.\u000A(Color)).MethodHandle;
				}
				if (\u000C\u0017\u001D.\u000A(ref \u001F) == \u000C\u0017\u001D.\u000A(ref \u000A))
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
					if (\u0013\u0017\u001D.\u000A(ref \u001F) == \u0013\u0017\u001D.\u000A(ref \u000A))
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
						if (\u000D\u000C\u001D.\u000A(ref \u001F) == \u000D\u000C\u001D.\u000A(ref \u000A))
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
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x00032D40 File Offset: 0x00030F40
		internal static int \u0007(this Color \u001F)
		{
			return (int)\u0015\u0017\u001D.\u000A(ref \u001F) + (int)\u000C\u0017\u001D.\u000A(ref \u001F) * (int)\u0013\u0007\u0007.\u000A(2.0, 8.0) + (int)\u0013\u0017\u001D.\u000A(ref \u001F) * (int)\u0013\u0007\u0007.\u000A(2.0, 16.0);
		}
	}
}

using System;
using System.Collections.Generic;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000289 RID: 649
	internal class \u0012\u000E : IEqualityComparer<RevitParameter>
	{
		// Token: 0x06001954 RID: 6484 RVA: 0x000A3CE4 File Offset: 0x000A1EE4
		public bool Equals(RevitParameter rp1, RevitParameter rp2)
		{
			return \u0012\u000E.\u001F(rp1, rp2);
		}

		// Token: 0x06001955 RID: 6485 RVA: 0x000A3CFC File Offset: 0x000A1EFC
		public int GetHashCode(RevitParameter rp)
		{
			if (\u0004\u001B\u0018.\u0007(rp) != OtherParamTypes.Schedule)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u000E.GetHashCode(RevitParameter)).MethodHandle;
				}
				if (\u0004\u001B\u0018.\u0007(rp) != OtherParamTypes.ScheduleInstanceOrType)
				{
					int num = \u001B\u0013\u000A.\u000A(\u0004\u001E\u0018.\u0007(rp));
					int num2 = \u0001\u001B\u0005.\u000A(rp);
					int num3 = num ^ \u001F\u000A\u001D.\u000A(ref num2);
					bool flag = \u0018\u000C\u0019.\u001D(rp);
					return num3 ^ \u0004\u0020\u0004.\u000A(ref flag) ^ \u001B\u0013\u000A.\u000A(\u001E\u0011\u0018.\u0007(rp));
				}
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			int result;
			if (\u0017\u000B\u0018.\u0007(rp) == -1L)
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
				result = (\u001B\u0013\u000A.\u000A(\u0004\u001E\u0018.\u0007(rp)) ^ \u001B\u0013\u000A.\u000A(\u001F\u001E\u0018.\u0007(rp)));
			}
			else
			{
				long num4 = \u0017\u000B\u0018.\u0007(rp);
				result = (\u0007\u000A\u001D.\u000A(ref num4) ^ \u001B\u0013\u000A.\u000A(\u001F\u001E\u0018.\u0007(rp)));
			}
			return result;
		}

		// Token: 0x06001956 RID: 6486 RVA: 0x000A3DE0 File Offset: 0x000A1FE0
		internal static bool \u001F(RevitParameter \u001F, RevitParameter \u000A)
		{
			if (\u0004\u001B\u0018.\u0007(\u001F) != OtherParamTypes.Schedule)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u000E.\u001F(RevitParameter, RevitParameter)).MethodHandle;
				}
				if (\u0004\u001B\u0018.\u0007(\u001F) == OtherParamTypes.ScheduleInstanceOrType)
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
					if (!\u0008\u0013\u000A.\u000A(\u0004\u001E\u0018.\u0007(\u001F), \u0004\u001E\u0018.\u0007(\u000A)))
					{
						return false;
					}
					for (;;)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					if (\u0001\u001B\u0005.\u000A(\u001F) != \u0001\u001B\u0005.\u000A(\u000A))
					{
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
					if (\u0018\u000C\u0019.\u001D(\u001F) != \u0018\u000C\u0019.\u001D(\u000A))
					{
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
					if (\u0008\u0013\u000A.\u000A(\u001E\u0011\u0018.\u0007(\u001F), \u001E\u0011\u0018.\u0007(\u000A)))
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
						return true;
					}
					return false;
				}
			}
			if (\u0017\u000B\u0018.\u0007(\u001F) != -1L)
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
				if (\u0017\u000B\u0018.\u0007(\u000A) == -1L)
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
					if (\u0017\u000B\u0018.\u0007(\u001F) != \u0017\u000B\u0018.\u0007(\u000A))
					{
						return false;
					}
					for (;;)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					if (\u0008\u0013\u000A.\u000A(\u001F\u001E\u0018.\u0007(\u001F), \u001F\u001E\u0018.\u0007(\u000A)))
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
						return true;
					}
					return false;
				}
			}
			if (\u0017\u000B\u0018.\u0007(\u001F) == -1L)
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
				if (\u0017\u000B\u0018.\u0007(\u000A) == -1L)
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
					if (\u0008\u0013\u000A.\u000A(\u0004\u001E\u0018.\u0007(\u001F), \u0004\u001E\u0018.\u0007(\u000A)))
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
						if (\u0008\u0013\u000A.\u000A(\u001F\u001E\u0018.\u0007(\u001F), \u001F\u001E\u0018.\u0007(\u000A)))
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
							return true;
						}
					}
				}
			}
			return false;
		}
	}
}

using System;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002AD RID: 685
	public static class UpdateStatesExtensions
	{
		// Token: 0x06001ADF RID: 6879 RVA: 0x000AF240 File Offset: 0x000AD440
		public static bool IsModifiedState(this UpdateStates state)
		{
			if (state != UpdateStates.Modified)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateStates.IsModifiedState()).MethodHandle;
				}
				if (state != UpdateStates.NameModified)
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
					return state == UpdateStates.NumberModified;
				}
			}
			return true;
		}

		// Token: 0x06001AE0 RID: 6880 RVA: 0x000AF278 File Offset: 0x000AD478
		public static bool IsNewState(this UpdateStates state)
		{
			if (state != UpdateStates.ToAdd)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateStates.IsNewState()).MethodHandle;
				}
				return state == UpdateStates.ToDuplicate;
			}
			return true;
		}
	}
}

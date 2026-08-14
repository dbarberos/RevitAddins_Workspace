using System;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000065 RID: 101
	internal static class \u0010\u0009\u0018
	{
		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000530 RID: 1328 RVA: 0x0001AA2C File Offset: 0x00018C2C
		// (set) Token: 0x06000531 RID: 1329 RVA: 0x0001AA40 File Offset: 0x00018C40
		public static string objSavePath { get; set; }

		// Token: 0x06000532 RID: 1330 RVA: 0x0001AA54 File Offset: 0x00018C54
		public static void \u0018()
		{
			try
			{
				string u000C = \u0010\u0009\u0018.\u0014();
				\u0012\u001D\u0014.\u0018(\u0003\u001A\u0018.\u0018(u000C, "DiRoots\\ProSheets"));
				\u000F\u000A\u0018.\u0001\u0018(\u001C\u001D\u0014.\u0018());
				try
				{
					if (!\u0012\u0006\u0018.\u0018(\u001C\u001D\u0014.\u0018()))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010\u0009\u0018.\u0018()).MethodHandle;
						}
						\u0012\u001D\u0014.\u0018(u000C);
					}
					else
					{
						\u000D\u001D\u0014.\u0018(\u001C\u001D\u0014.\u0018());
					}
				}
				catch (UnauthorizedAccessException)
				{
					\u0012\u001D\u0014.\u0018(u000C);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0001AAEC File Offset: 0x00018CEC
		public static string \u0014()
		{
			return \u000A\u0006\u0018.\u0018(Environment.SpecialFolder.Personal);
		}

		// Token: 0x040001DC RID: 476
		[CompilerGenerated]
		private static string \u000C;
	}
}

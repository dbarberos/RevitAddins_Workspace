using System;
using A;

namespace DiRoots.ProSheets.UI.DiProfiles
{
	// Token: 0x02000049 RID: 73
	public class ProfileMigrateUtil
	{
		// Token: 0x060002EF RID: 751 RVA: 0x00011CFC File Offset: 0x0000FEFC
		public static void Migrate()
		{
			string u000C = \u0003\u001A\u0018.\u0018(\u000A\u0006\u0018.\u0018(Environment.SpecialFolder.LocalApplicationData), "DiRoots\\ProSheets\\Profiles");
			if (!ProfileMigrateUtil.\u0018(u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileMigrateUtil.Migrate()).MethodHandle;
				}
				return;
			}
			if (!ProfileMigrateUtil.\u000C(u000C, ProfileMigrateUtil.\u0003()))
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
				ProfileMigrateUtil.\u000C(u000C, ProfileMigrateUtil.\u0014());
			}
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00011D68 File Offset: 0x0000FF68
		private static bool \u000C(string \u000C, string \u0018)
		{
			try
			{
				if (!\u0012\u0006\u0018.\u0018(\u000C))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileMigrateUtil.\u000C(string, string)).MethodHandle;
					}
					if (\u0012\u0006\u0018.\u0018(\u0018))
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
						if (\u0009\u001E\u0018.\u0018(\u000C, \u0018))
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
							\u000F\u0006\u0018.\u0018(\u000C);
							string[] array = \u001C\u0020\u0014.\u0018(\u0018);
							for (int i = 0; i < (int)\u0020\u001A\u000F.\u000C(array); i++)
							{
								string u000C = array[i];
								string u = \u000B\u001E\u0018.\u0018(u000C);
								string u2 = \u0003\u001A\u0018.\u0018(\u000C, u);
								\u000D\u0020\u0014.\u0018(u000C, u2, true);
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
							return true;
						}
					}
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00011E2C File Offset: 0x0001002C
		private static bool \u0018(string \u000C)
		{
			return !\u0012\u0006\u0018.\u0018(\u000C);
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00011E44 File Offset: 0x00010044
		private static string \u0014()
		{
			string u000C = \u0020\u0020\u0014.\u0018(\u0013\u0020\u0014.\u0018(\u000A\u0006\u0018.\u0018(Environment.SpecialFolder.ApplicationData)));
			if (\u0009\u0020\u0014.\u0018(\u000A\u0020\u0014.\u0018(\u0018\u001E\u0018.\u0018())) >= 6)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileMigrateUtil.\u0014()).MethodHandle;
				}
				u000C = \u0001\u0017\u0018.\u0018(\u0013\u0020\u0014.\u0018(u000C));
			}
			return \u0003\u001A\u0018.\u0018(u000C, "Documents\\DiRoots\\Profiles\\ProSheets");
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00011EB4 File Offset: 0x000100B4
		private static string \u0003()
		{
			return \u0003\u001A\u0018.\u0018(\u000A\u0006\u0018.\u0018(Environment.SpecialFolder.Personal), "DiRoots\\Profiles\\ProSheets");
		}
	}
}

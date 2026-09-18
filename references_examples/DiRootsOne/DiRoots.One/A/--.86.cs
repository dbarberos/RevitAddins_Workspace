using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.TableGen.TGRevitHelper.StyleMapping;
using DiRoots.One.TGDatabaseLayer.StyleMapping;
using Newtonsoft.Json;

namespace A
{
	// Token: 0x0200013B RID: 315
	internal static class \u0010\u0016
	{
		// Token: 0x06000BB3 RID: 2995 RVA: 0x0004A370 File Offset: 0x00048570
		public static \u0010\u0016.\u000D\u0016 \u0007(Document \u001F)
		{
			\u0010\u0016.\u000D\u0016 result;
			try
			{
				if (\u001F == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010\u0016.\u0007(Document)).MethodHandle;
					}
					result = null;
				}
				else
				{
					DataStorage dataStorage = \u0010\u0016.\u0004(\u001F);
					if (dataStorage == null)
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
						result = null;
					}
					else
					{
						StyleMappingSettings styleMappingSettings = \u0010\u000C\u0004.\u000A(dataStorage);
						if (styleMappingSettings == null)
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
							result = null;
						}
						else
						{
							StyleMappingDto styleMappingDto = \u0001\u0004\u000E.\u001F;
							if (!\u001A\u0006\u0007.\u000A(\u000D\u000C\u0004.\u000A(styleMappingSettings)))
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
								try
								{
									styleMappingDto = JsonConvert.DeserializeObject<StyleMappingDto>(\u000D\u000C\u0004.\u000A(styleMappingSettings));
								}
								catch (Exception u000A)
								{
									\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\StyleMappingSettingsStorage.cs", "Load");
								}
							}
							if (styleMappingDto == null)
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
								result = null;
							}
							else
							{
								\u0010\u0016.\u000D\u0016 u000D_u = new \u0010\u0016.\u000D\u0016();
								\u001C\u000C\u0004.\u000A(u000D_u, styleMappingDto);
								string u000A2;
								if ((u000A2 = \u0003\u000C\u0004.\u000A(styleMappingSettings)) == null)
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
									u000A2 = string.Empty;
								}
								\u0012\u000C\u0004.\u000A(u000D_u, u000A2);
								result = u000D_u;
							}
						}
					}
				}
			}
			catch (Exception u000A3)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\StyleMappingSettingsStorage.cs", "Load");
				result = null;
			}
			return result;
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x0004A4A0 File Offset: 0x000486A0
		public static void \u001D(Document \u001F, StyleMappingDto \u000A, string \u0007)
		{
			try
			{
				if (\u001F != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010\u0016.\u001D(Document, StyleMappingDto, string)).MethodHandle;
					}
					if (\u000A == null)
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
						StyleMappingSettings styleMappingSettings = \u001E\u000C\u0004.\u000A();
						string u000A = \u0007;
						if (\u0007 == null)
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
							u000A = string.Empty;
						}
						\u0011\u000C\u0004.\u000A(styleMappingSettings, u000A);
						\u001B\u000C\u0004.\u000A(styleMappingSettings, \u000E\u000D\u0004.\u000A(\u000A, Formatting.None));
						StyleMappingSettings u000A2 = styleMappingSettings;
						Transaction transaction = \u001D\u0014\u0007.\u000A(\u001F, "TableGen - Save style mapping settings");
						try
						{
							\u0007\u0014\u0007.\u000A(transaction);
							DataStorage dataStorage = \u0010\u0016.\u0004(\u001F);
							if (dataStorage == null)
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
								dataStorage = \u0008\u000C\u0004.\u000A(\u001F);
								\u0011\u0013\u0007.\u000A(dataStorage, "TableGenStyleMappingSettings");
							}
							\u000E\u000C\u0004.\u000A(dataStorage, u000A2);
							\u001B\u0001\u000A.\u000A(transaction);
						}
						finally
						{
							if (transaction != null)
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
								\u001F\u0017\u000A.\u000A(transaction);
							}
						}
					}
				}
			}
			catch (Exception u000A3)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\StyleMappingSettingsStorage.cs", "Save");
			}
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x0004A5A8 File Offset: 0x000487A8
		private static DataStorage \u0004(Document \u001F)
		{
			IEnumerable<DataStorage> enumerable = Enumerable.Cast<DataStorage>(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u001E\u0011\u000A.\u000A(\u000B\u0018\u000E.\u001F())));
			Func<DataStorage, bool> func;
			if ((func = \u0010\u0016.<>c.\u000A) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010\u0016.\u0004(Document)).MethodHandle;
				}
				func = (\u0010\u0016.<>c.\u000A = new Func<DataStorage, bool>(\u0010\u0016.<>c.\u001F.\u0007));
			}
			return Enumerable.FirstOrDefault<DataStorage>(enumerable, func);
		}

		// Token: 0x040004A7 RID: 1191
		private static string \u001F;

		// Token: 0x040004A8 RID: 1192
		private static string \u000A;

		// Token: 0x02000818 RID: 2072
		public class \u000D\u0016
		{
			// Token: 0x17001369 RID: 4969
			// (get) Token: 0x06004DB2 RID: 19890 RVA: 0x001DECD8 File Offset: 0x001DCED8
			// (set) Token: 0x06004DB3 RID: 19891 RVA: 0x001DECEC File Offset: 0x001DCEEC
			public StyleMappingDto Settings { get; set; }

			// Token: 0x1700136A RID: 4970
			// (get) Token: 0x06004DB4 RID: 19892 RVA: 0x001DED00 File Offset: 0x001DCF00
			// (set) Token: 0x06004DB5 RID: 19893 RVA: 0x001DED14 File Offset: 0x001DCF14
			public string ProfileName { get; set; }

			// Token: 0x0400206A RID: 8298
			[CompilerGenerated]
			private StyleMappingDto \u001F;

			// Token: 0x0400206B RID: 8299
			[CompilerGenerated]
			private string \u000A;
		}
	}
}

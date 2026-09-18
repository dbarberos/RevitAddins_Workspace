using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using DiRoots.One.Commons.Interfaces;

namespace A
{
	// Token: 0x020000FD RID: 253
	internal class \u000F\u0005
	{
		// Token: 0x17000258 RID: 600
		// (get) Token: 0x0600093A RID: 2362 RVA: 0x00040D40 File Offset: 0x0003EF40
		// (set) Token: 0x0600093B RID: 2363 RVA: 0x00040D54 File Offset: 0x0003EF54
		internal static List<\u000F\u0005> Cache { get; set; } = \u000F\u0010\u0004.\u000A();

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x0600093C RID: 2364 RVA: 0x00040D68 File Offset: 0x0003EF68
		// (set) Token: 0x0600093D RID: 2365 RVA: 0x00040D7C File Offset: 0x0003EF7C
		internal string DataSourceDefinitionId { get; set; }

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x0600093E RID: 2366 RVA: 0x00040D90 File Offset: 0x0003EF90
		// (set) Token: 0x0600093F RID: 2367 RVA: 0x00040DA4 File Offset: 0x0003EFA4
		public string InstanceName { get; set; }

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x00040DB8 File Offset: 0x0003EFB8
		// (set) Token: 0x06000941 RID: 2369 RVA: 0x00040DCC File Offset: 0x0003EFCC
		public string WorkspaceLocation { get; set; }

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x00040DE0 File Offset: 0x0003EFE0
		// (set) Token: 0x06000943 RID: 2371 RVA: 0x00040DF4 File Offset: 0x0003EFF4
		public string FilePath { get; set; }

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x00040E08 File Offset: 0x0003F008
		// (set) Token: 0x06000945 RID: 2373 RVA: 0x00040E1C File Offset: 0x0003F01C
		public bool IsNewVersion { get; set; }

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000946 RID: 2374 RVA: 0x00040E30 File Offset: 0x0003F030
		// (set) Token: 0x06000947 RID: 2375 RVA: 0x00040E44 File Offset: 0x0003F044
		private static \u000F\u0005 _newVersionInstance { get; set; }

		// Token: 0x06000948 RID: 2376 RVA: 0x00040E58 File Offset: 0x0003F058
		internal static List<\u000F\u0005> \u0005()
		{
			try
			{
				if (\u0001\u0010\u0004.\u000A(\u0012\u0010\u0004.\u000A()) == 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0005.\u0005()).MethodHandle;
					}
					\u000F\u0005.\u0016();
					string u001F = \u001B\u0015\u001D.\u000A(\u0015\u0010\u0004.\u000A("LocalAppData"), "Autodesk\\Desktop Connector");
					if (!\u000C\u0010\u0004.\u000A(u001F))
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
						return \u0012\u0010\u0004.\u000A();
					}
					string[] array = \u001A\u0010\u0004.\u000A(u001F, "instance.xml", 1);
					for (int i = 0; i < (int)\u000C\u0007\u000E.\u001F(array); i++)
					{
						string u001F2 = array[i];
						XmlDataDocument u001F3 = \u0013\u0010\u0004.\u000A();
						FileStream u000A = \u0014\u0010\u0004.\u000A(u001F2, FileMode.Open, FileAccess.ReadWrite);
						\u0017\u0010\u0004.\u000A(u001F3, u000A);
						XmlNode u001F4 = \u001E\u0010\u0004.\u000A(\u0020\u0010\u0004.\u000A(u001F3), 1);
						XmlAttribute xmlAttribute = \u001B\u0010\u0004.\u000A(\u0011\u0010\u0004.\u000A(u001F4), "InstanceName");
						if (xmlAttribute != null)
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
							XmlAttribute xmlAttribute2 = \u001B\u0010\u0004.\u000A(\u0011\u0010\u0004.\u000A(u001F4), "DataSourceDefinitionId");
							if (xmlAttribute2 != null)
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
								XmlAttribute xmlAttribute3 = \u001B\u0010\u0004.\u000A(\u0011\u0010\u0004.\u000A(u001F4), "WorkspaceLocation");
								if (xmlAttribute3 != null)
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
									\u000F\u0005 u000F_u = new \u000F\u0005();
									\u0008\u0010\u0004.\u000A(u000F_u, \u0010\u0010\u0004.\u000A(xmlAttribute));
									\u000E\u0010\u0004.\u000A(u000F_u, \u0010\u0010\u0004.\u000A(xmlAttribute2));
									\u000D\u0010\u0004.\u000A(u000F_u, \u001C\u000B\u001D.\u0007(\u0010\u0010\u0004.\u000A(xmlAttribute3), "/", "\\"));
									\u001C\u0010\u0004.\u000A(\u0012\u0010\u0004.\u000A(), u000F_u);
								}
							}
						}
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
					IEnumerable<\u000F\u0005> enumerable = \u0012\u0010\u0004.\u000A();
					Func<\u000F\u0005, int> func;
					if ((func = \u000F\u0005.<>c.\u000A) == null)
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
						func = (\u000F\u0005.<>c.\u000A = new Func<\u000F\u0005, int>(\u000F\u0005.<>c.\u001F.\u0007));
					}
					\u0003\u0010\u0004.\u000A(Enumerable.ToList<\u000F\u0005>(Enumerable.OrderByDescending<\u000F\u0005, int>(enumerable, func)));
				}
			}
			catch (Exception u000A2)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\DesktopConnectorInfo.cs", "GetBIM360Folders");
			}
			return \u0012\u0010\u0004.\u000A();
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x0004107C File Offset: 0x0003F27C
		private static void \u0016()
		{
			string u001F = \u001B\u0015\u001D.\u000A(\u0015\u0010\u0004.\u000A("USERPROFILE"), "DC\\ACCDocs");
			if (\u000C\u0010\u0004.\u000A(u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0005.\u0016()).MethodHandle;
				}
				\u000F\u0005 u000F_u = new \u000F\u0005();
				\u0008\u0010\u0004.\u000A(u000F_u, "ACCDocs");
				\u000E\u0010\u0004.\u000A(u000F_u, "-1");
				\u001F\u000E\u0004.\u000A(u000F_u, true);
				\u000D\u0010\u0004.\u000A(u000F_u, \u001C\u000B\u001D.\u0007(u001F, "/", "\\"));
				\u0009\u0010\u0004.\u000A(u000F_u);
				\u001C\u0010\u0004.\u000A(\u0012\u0010\u0004.\u000A(), u000F_u);
			}
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x00041110 File Offset: 0x0003F310
		internal static \u000F\u0005 \u000B(string \u001F, string \u000A, string \u0007 = null)
		{
			\u000F\u0005.\u0006\u0005 u0006_u = new \u000F\u0005.\u0006\u0005();
			u0006_u.\u001F = \u0007;
			\u000F\u0005.\u0005();
			\u000F\u0005 u000F_u = \u001D\u000E\u0004.\u000A();
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0005.\u000B(string, string, string)).MethodHandle;
				}
				return u000F_u;
			}
			\u001F = \u001C\u000B\u001D.\u0007(\u001F, "/", "\\");
			if (u000F_u != null)
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
				\u000A\u000E\u0004.\u000A(u000F_u, \u001C\u000B\u001D.\u0007(\u001F, \u0004\u001E\u000A.\u000A(\u0007\u000E\u0004.\u000A(\u001D\u000E\u0004.\u000A()), "\\"), \u000A));
			}
			else
			{
				try
				{
					\u000F\u0005 u000F_u2 = Enumerable.FirstOrDefault<\u000F\u0005>(\u0012\u0010\u0004.\u000A(), new Func<\u000F\u0005, bool>(u0006_u.\u000A));
					if (\u0014\u001E\u001D.\u000A(\u001F, \u0007\u000E\u0004.\u000A(u000F_u2)))
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
						u000F_u = u000F_u2;
						\u000A\u000E\u0004.\u000A(u000F_u2, \u001C\u000B\u001D.\u0007(\u001F, \u0004\u001E\u000A.\u000A(\u0007\u000E\u0004.\u000A(u000F_u2), "\\"), \u000A));
					}
				}
				catch (Exception u000A)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\DesktopConnectorInfo.cs", "GetDesktopConnectorInfo");
				}
			}
			return u000F_u;
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x0004122C File Offset: 0x0003F42C
		internal static string \u0002(string \u001F, string \u000A, bool \u0007)
		{
			string result = "";
			string u000A = \u0019\u000E\u0004.\u000A(\u0015\u0010\u0004.\u000A("USERPROFILE"));
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0005.\u0002(string, string, bool)).MethodHandle;
				}
				if (\u0014\u001E\u001D.\u000A(\u001F, u000A))
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
					if (\u001D\u000E\u0004.\u000A() == null)
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
						return \u001F;
					}
					if (!\u0007)
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
						if (!\u001A\u0006\u0007.\u000A(\u000A))
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
							if (\u0014\u001E\u001D.\u000A(\u001F, \u0007\u000E\u0004.\u000A(\u001D\u000E\u0004.\u000A())))
							{
								return result;
							}
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
					}
					if (\u000F\u000C\u001D.\u0007(\u001F, "\\DC\\ACCDoc"))
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
						char[] array = \u001C\u0007\u000E.\u001F(1);
						array[0] = '\\';
						string[] array2 = \u0004\u000E\u0004.\u000A(\u001F, array, 6, StringSplitOptions.None);
						result = \u001B\u0015\u001D.\u000A(\u0007\u000E\u0004.\u000A(\u001D\u000E\u0004.\u000A()), Enumerable.Last<string>(array2));
					}
					else if (\u000F\u000C\u001D.\u0007(\u001F, "\\ACCDocs"))
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
						char[] array3 = \u001C\u0007\u000E.\u001F(1);
						array3[0] = '\\';
						string[] array2 = \u0004\u000E\u0004.\u000A(\u001F, array3, 5, StringSplitOptions.None);
						result = \u001B\u0015\u001D.\u000A(\u0007\u000E\u0004.\u000A(\u001D\u000E\u0004.\u000A()), Enumerable.Last<string>(array2));
					}
					else
					{
						result = \u001F;
					}
				}
			}
			return result;
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x00041384 File Offset: 0x0003F584
		internal static bool \u0006(string \u001F)
		{
			\u001F = \u001C\u000B\u001D.\u0007(\u001F, "/", "\\");
			if (!\u0014\u001E\u001D.\u000A(\u001F, "BIM 360:\\"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0005.\u0006(string)).MethodHandle;
				}
				if (!\u0014\u001E\u001D.\u000A(\u001F, "Autodesk Docs:\\"))
				{
					\u000F\u0005.\u0005();
					List<\u000F\u0005>.Enumerator enumerator = \u0016\u000E\u0004.\u000A(\u0012\u0010\u0004.\u000A());
					try
					{
						while (\u0018\u000E\u0004.\u000A(ref enumerator))
						{
							\u000F\u0005 u001F = \u0005\u000E\u0004.\u000A(ref enumerator);
							if (\u0014\u001E\u001D.\u000A(\u001F, \u0007\u000E\u0004.\u000A(u001F)))
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
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
					return false;
				}
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
			return true;
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x00041460 File Offset: 0x0003F660
		internal static string \u000F(string \u001F, bool \u000A = true)
		{
			\u001F = \u001C\u000B\u001D.\u0007(\u001F, "/", "\\");
			string text;
			if (\u0014\u001E\u001D.\u000A(\u001F, "Autodesk Docs:\\"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0005.\u000F(string, bool)).MethodHandle;
				}
				text = "Autodesk Docs:";
			}
			else
			{
				text = "BIM 360:";
			}
			if (\u000A)
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
				text = \u0004\u001E\u000A.\u000A(text, "\\\\");
			}
			return text;
		}

		// Token: 0x04000380 RID: 896
		[CompilerGenerated]
		private static List<\u000F\u0005> \u001F;

		// Token: 0x04000381 RID: 897
		[CompilerGenerated]
		private string \u000A;

		// Token: 0x04000382 RID: 898
		[CompilerGenerated]
		private string \u0007;

		// Token: 0x04000383 RID: 899
		[CompilerGenerated]
		private string \u001D;

		// Token: 0x04000384 RID: 900
		[CompilerGenerated]
		private string \u0004;

		// Token: 0x04000385 RID: 901
		[CompilerGenerated]
		private bool \u0019;

		// Token: 0x04000386 RID: 902
		[CompilerGenerated]
		private static \u000F\u0005 \u0018;

		// Token: 0x02000804 RID: 2052
		[CompilerGenerated]
		private sealed class \u0006\u0005
		{
			// Token: 0x06004D66 RID: 19814 RVA: 0x001DE480 File Offset: 0x001DC680
			internal bool \u000A(\u000F\u0005 \u001F)
			{
				if (this.\u001F != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0005.\u0006\u0005.\u000A(\u000F\u0005)).MethodHandle;
					}
					return \u0008\u0013\u000A.\u000A(\u0013\u001B\u0004.\u000A(\u001F), this.\u001F);
				}
				return true;
			}

			// Token: 0x0400203B RID: 8251
			public string \u001F;
		}
	}
}

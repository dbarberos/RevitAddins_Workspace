using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Enums;
using ProSheets.Helpers;
using ProSheets.Models;

namespace A
{
	// Token: 0x020000F0 RID: 240
	internal static class \u0019\u0011\u0018
	{
		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06000BCF RID: 3023 RVA: 0x0004830C File Offset: 0x0004650C
		// (set) Token: 0x06000BD0 RID: 3024 RVA: 0x00048320 File Offset: 0x00046520
		public static List<SheetInfo> IFCLinks { get; private set; } = \u001D\u0017\u0014.\u0018();

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06000BD1 RID: 3025 RVA: 0x00048334 File Offset: 0x00046534
		// (set) Token: 0x06000BD2 RID: 3026 RVA: 0x00048348 File Offset: 0x00046548
		public static bool IFCLinksExported { get; set; }

		// Token: 0x06000BD3 RID: 3027 RVA: 0x0004835C File Offset: 0x0004655C
		public static void \u0014(Document \u000C, View \u0018, \u000F\u000A\u0018 \u0014)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\IFC\\LinkExporterUtility.cs", "Export");
			if (\u000E\u001E\u0016.\u0018())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0011\u0018.\u0014(Document, View, \u000F\u000A\u0018)).MethodHandle;
				}
				return;
			}
			List<string> u000C = \u0011\u0002\u0018.\u0018();
			List<RevitLinkType> u000C2 = \u0005\u001E\u0016.\u0018();
			IEnumerator<Element> enumerator = \u001B\u001E\u0016.\u0018(\u0010\u001D\u0014.\u0014(\u0020\u001D\u0018.\u0018(\u000C), \u000A\u001D\u0018.\u0018(\u001B\u0010\u000F.\u000C())));
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					RevitLinkType revitLinkType = \u0005\u0010\u000F.\u000C(\u0001\u001E\u0016.\u0018(enumerator));
					ExternalFileReference externalFileReference = \u0008\u001E\u0016.\u0018(revitLinkType);
					if (externalFileReference != null)
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
						if (\u0006\u001E\u0016.\u0018(externalFileReference) == null)
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
							if (\u0010\u001E\u0016.\u0018(externalFileReference) == 1)
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
								string u = \u0019\u001E\u0016.\u0018(\u0007\u001E\u0016.\u0018(externalFileReference));
								\u0019\u0017\u0014.\u0018(u000C, u);
								\u000B\u001E\u0016.\u0018(u000C2, revitLinkType);
								\u001A\u001E\u0016.\u0018(revitLinkType, \u000E\u0010\u000F.\u000C);
							}
						}
					}
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
			finally
			{
				if (enumerator != null)
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
					\u0020\u001E\u0018.\u0018(enumerator);
				}
			}
			List<string>.Enumerator enumerator2 = \u0008\u0015\u0014.\u0018(u000C);
			try
			{
				while (\u0010\u0015\u0014.\u0018(ref enumerator2))
				{
					string u2 = \u0006\u0015\u0014.\u0018(ref enumerator2);
					SheetInfo sheetInfo = \u0012\u0004\u0014.\u0018();
					\u0005\u000E\u0018.\u0018(sheetInfo, "IFC");
					\u0004\u001B\u0014.\u0018(true);
					Document u000C3 = \u0004\u001E\u0016.\u0018(\u001D\u001E\u0016.\u0018(\u000C), u2);
					if (\u0014.\u001B\u0018(u000C3, \u0018, \u0014\u001E\u0018.\u0018(\u0006\u0004\u0018.\u0018(\u000C), "-", \u0006\u0004\u0018.\u0018(u000C3)), sheetInfo, true, \u0004\u001A\u000F.\u000C))
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
						\u000C\u0017\u0014.\u0018(sheetInfo, PublishStatus.Success);
					}
					else
					{
						\u000C\u0017\u0014.\u0018(sheetInfo, PublishStatus.Failed);
					}
					\u0002\u001E\u0016.\u0018(u000C3, false);
					\u0007\u000E\u0018.\u0018(\u0006\u000A\u0016.\u0018(), sheetInfo);
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
				((IDisposable)enumerator2).Dispose();
			}
			List<RevitLinkType>.Enumerator enumerator3 = \u001E\u001E\u0016.\u0018(u000C2);
			try
			{
				while (\u0011\u001E\u0016.\u0018(ref enumerator3))
				{
					\u0015\u001E\u0016.\u0018(\u0017\u001E\u0016.\u0018(ref enumerator3));
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
			finally
			{
				((IDisposable)enumerator3).Dispose();
			}
			\u001F\u001E\u0016.\u0018(true);
			\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "End IFC exporting linked files", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\IFC\\LinkExporterUtility.cs", "Export");
		}

		// Token: 0x06000BD4 RID: 3028 RVA: 0x000485E4 File Offset: 0x000467E4
		internal static void \u0003()
		{
			\u001F\u001E\u0016.\u0018(false);
			\u000C\u0002\u0016.\u0018(\u0006\u000A\u0016.\u0018());
		}

		// Token: 0x04000572 RID: 1394
		[CompilerGenerated]
		private static List<SheetInfo> \u000C;

		// Token: 0x04000573 RID: 1395
		[CompilerGenerated]
		private static bool \u0018;
	}
}

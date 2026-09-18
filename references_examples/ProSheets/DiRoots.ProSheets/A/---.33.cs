using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Helpers;
using ProSheets.Models;

namespace A
{
	// Token: 0x020000E2 RID: 226
	internal class \u0001\u001F\u0018
	{
		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x06000B84 RID: 2948 RVA: 0x00046434 File Offset: 0x00044634
		// (set) Token: 0x06000B85 RID: 2949 RVA: 0x00046448 File Offset: 0x00044648
		public static List<ExportDGNSettings> DGNSettings { get; set; }

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x06000B86 RID: 2950 RVA: 0x0004645C File Offset: 0x0004465C
		// (set) Token: 0x06000B87 RID: 2951 RVA: 0x00046470 File Offset: 0x00044670
		public static List<string> DGNSettingNames { get; set; }

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x06000B88 RID: 2952 RVA: 0x00046484 File Offset: 0x00044684
		// (set) Token: 0x06000B89 RID: 2953 RVA: 0x00046498 File Offset: 0x00044698
		public static string SelectedSettingName { get; set; }

		// Token: 0x06000B8A RID: 2954 RVA: 0x000464AC File Offset: 0x000446AC
		public bool \u0016(Document \u000C, View \u0018, string \u0014, SheetInfo \u0003)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DngExporter.cs", "ExportDGN");
			bool result = false;
			try
			{
				string u000C = \u001F\u0010\u0014.\u0018(\u0003, \u0018, \u0015\u0010\u0014.\u0018(), "DGN", \u0014, ".dgn", \u0011\u0010\u0014.\u0018());
				if (!\u001F\u001A\u0018.\u0018(\u0014\u0017\u0014.\u0018(\u0003)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u001F\u0018.\u0016(Document, View, string, SheetInfo)).MethodHandle;
					}
					return false;
				}
				if (this.\u000C == null)
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
					\u001D\u0002\u0014.\u0018(\u000F\u000A\u0018.\u0016\u0018<ExportDGNSettings>(\u000C));
					List<ExportDGNSettings>.Enumerator enumerator = \u0002\u0002\u0014.\u0018(\u0004\u0002\u0014.\u0018());
					try
					{
						while (\u0017\u0002\u0014.\u0018(ref enumerator))
						{
							ExportDGNSettings u000C2 = \u001E\u0002\u0014.\u0018(ref enumerator);
							if (\u000F\u0002\u0018.\u0018(\u001E\u0016\u0014.\u0018(u000C2), \u000B\u0011\u0016.\u0018()))
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
								this.\u000C = \u001A\u0011\u0016.\u0018(u000C2);
								goto IL_FF;
							}
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
						((IDisposable)enumerator).Dispose();
					}
				}
				IL_FF:
				if (this.\u000C != null)
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
					ICollection<ElementId> collection = \u0007\u0004\u0018.\u0018();
					\u001F\u0004\u0018.\u0018(collection, \u0009\u0002\u0018.\u0018(\u0018));
					\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Start export - Single DGN", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DngExporter.cs", "ExportDGN");
					result = \u0004\u0011\u0016.\u0018(\u000C, \u0019\u001E\u0018.\u0018(u000C), \u0014, collection, \u001D\u0011\u0016.\u0018(this.\u000C));
					\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "End export - Single DGN", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DngExporter.cs", "ExportDGN");
				}
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DngExporter.cs", "ExportDGN");
			}
			catch (Exception ex)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\DngExporter.cs", "ExportDGN");
				\u0018\u0017\u0014.\u0014(\u0003, \u000A\u0001\u0018.\u0018(ex));
			}
			return result;
		}

		// Token: 0x04000558 RID: 1368
		private DGNExportOptions \u000C;

		// Token: 0x04000559 RID: 1369
		[CompilerGenerated]
		private static List<ExportDGNSettings> \u0018;

		// Token: 0x0400055A RID: 1370
		[CompilerGenerated]
		private static List<string> \u0014;

		// Token: 0x0400055B RID: 1371
		[CompilerGenerated]
		private static string \u0003;
	}
}

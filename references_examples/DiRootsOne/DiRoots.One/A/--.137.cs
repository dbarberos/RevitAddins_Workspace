using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Models;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000271 RID: 625
	internal sealed class \u001B\u0010 : \u0008\u0010
	{
		// Token: 0x060018F7 RID: 6391 RVA: 0x000A1C68 File Offset: 0x0009FE68
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\DriveExportEvent.cs", "Execute");
			Document u001D = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app));
			try
			{
				\u0019\u0013\u0019.\u000A(false);
				if (\u001C\u0001\u0018.\u000A(\u000A\u0015\u0018.\u001D(this)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001B\u0010.Execute(UIApplication)).MethodHandle;
					}
					\u0009\u0014\u0019.\u000A(\u0001\u001A\u0005.\u000A(this), \u0020\u0014\u0018.\u000A(\u0004\u000C\u0005.\u000A(this)), \u0018\u000E\u0007.\u000A(\u000C\u0013\u0019.\u000A(), 1, 1));
					\u001B\u0012.\u0007(\u0019\u000C\u0005.\u000A(this), \u0004\u000C\u0005.\u000A(this), \u000C\u000C\u0018.\u001D(this), u001D, \u000A\u0015\u0018.\u001D(this), \u0006\u000F\u0018.\u0007(\u0001\u001A\u0005.\u000A(this)));
				}
				else if (\u0018\u000C\u0005.\u000A(\u000A\u0015\u0018.\u001D(this)))
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
					\u0009\u0014\u0019.\u000A(\u0001\u001A\u0005.\u000A(this), \u0020\u0014\u0018.\u000A(\u0004\u000C\u0005.\u000A(this)), \u0018\u000E\u0007.\u000A(\u000C\u0013\u0019.\u000A(), 1, 1));
					\u0020\u0003.\u000A(\u0004\u000C\u0005.\u000A(this), \u0020\u001E\u0018.\u000A(\u000A\u0015\u0018.\u001D(this)), false, false, \u0006\u000F\u0018.\u0007(\u0001\u001A\u0005.\u000A(this)));
					\u0002\u0013\u0019.\u0007(\u0001\u001A\u0005.\u000A(this));
				}
				else
				{
					\u0009\u0014\u0019.\u000A(\u0001\u001A\u0005.\u000A(this), \u0020\u0014\u0018.\u000A(\u0004\u000C\u0005.\u000A(this)), \u0018\u000E\u0007.\u000A(\u001F\u0013\u0019.\u000A(), 1, 1));
					Tuple<Workbook, List<ParamValueInfo>, Dictionary<string, List<int>>> u001F = \u001B\u0012.\u000A(\u0019\u000C\u0005.\u000A(this), \u0004\u000C\u0005.\u000A(this), \u000C\u000C\u0018.\u001D(this), u001D, \u0001\u001A\u0005.\u000A(this), \u000A\u0015\u0018.\u001D(this));
					\u0009\u0014\u0019.\u000A(\u0001\u001A\u0005.\u000A(this), \u0003\u0019\u0018.\u000A(\u001E\u001D\u0018.\u000A(\u001D\u000C\u0005.\u000A(u001F))), \u0018\u000E\u0007.\u000A(\u000C\u0013\u0019.\u000A(), 2, 2));
					SheetLinkSyncfusionExcel u001F2 = \u0007\u000C\u0005.\u000A(\u001D\u000C\u0005.\u000A(u001F), true);
					\u001F\u000C\u0005.\u000A(u001F2, \u000A\u000C\u0005.\u000A(u001F));
					\u0015\u0012\u0005.\u001D(u001F2, \u0009\u001A\u0005.\u000A(u001F));
					\u0015\u001A\u0005.\u000A(u001F2, \u0006\u000F\u0018.\u0007(\u0001\u001A\u0005.\u000A(this)));
				}
				Delegate @delegate = \u000C\u001A\u0005.\u000A(this);
				if (@delegate == null)
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
				}
				else
				{
					object[] array = \u0004\u0015\u0010.\u001F(2);
					array[0] = \u0009\u000C\u0018.\u000A(\u000A\u0015\u0018.\u001D(this));
					array[1] = \u0020\u001E\u0018.\u000A(\u000A\u0015\u0018.\u001D(this));
					\u0010\u001F\u0018.\u000A(@delegate, array);
				}
			}
			catch (TaskCanceledException u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\DriveExportEvent.cs", "Execute");
			}
			catch (Exception u000A2)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\DriveExportEvent.cs", "Execute");
				\u000D\u0014\u0004.\u000A(\u001B\u0016\u0018.\u000A(), u000A2, true);
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\DriveExportEvent.cs", "Execute");
		}
	}
}

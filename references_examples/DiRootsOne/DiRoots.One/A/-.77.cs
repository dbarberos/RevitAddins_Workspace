using System;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Models;

namespace A
{
	// Token: 0x02000277 RID: 631
	internal sealed class \u000C\u0010 : \u0008\u0010
	{
		// Token: 0x06001917 RID: 6423 RVA: 0x000A2A20 File Offset: 0x000A0C20
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\MortaExportEvent.cs", "Execute");
			Document u001D = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app));
			try
			{
				\u0019\u0013\u0019.\u000A(false);
				\u0009\u0014\u0019.\u000A(\u0001\u001A\u0005.\u000A(this), \u0020\u0014\u0018.\u000A(\u0004\u000C\u0005.\u000A(this)), \u0018\u000E\u0007.\u000A(\u001F\u0013\u0019.\u000A(), 1, 1));
				Workbook u001F = \u0010\u0012\u000E.\u001F;
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0010.Execute(UIApplication)).MethodHandle;
					}
					\u0009\u0014\u0019.\u000A(\u0001\u001A\u0005.\u000A(this), \u0020\u0014\u0018.\u000A(\u0004\u000C\u0005.\u000A(this)), \u0018\u000E\u0007.\u000A(\u001F\u0013\u0019.\u000A(), 1, 1));
					u001F = \u001B\u0012.\u0004(\u0019\u000C\u0005.\u000A(this), \u0004\u000C\u0005.\u000A(this), \u000C\u000C\u0018.\u001D(this), u001D, \u000A\u0015\u0018.\u001D(this), \u0006\u000F\u0018.\u0007(\u0001\u001A\u0005.\u000A(this)));
				}
				else
				{
					u001F = \u001D\u000C\u0005.\u000A(\u001B\u0012.\u000A(\u0019\u000C\u0005.\u000A(this), \u0004\u000C\u0005.\u000A(this), \u000C\u000C\u0018.\u001D(this), u001D, \u0001\u001A\u0005.\u000A(this), \u000A\u0015\u0018.\u001D(this)));
				}
				\u000A\u000F.\u0007(u001F, \u0018\u000B\u0007.\u001D(\u0001\u001A\u0005.\u000A(this)), \u001C\u0001\u0018.\u000A(\u000A\u0015\u0018.\u001D(this)));
			}
			catch (TaskCanceledException)
			{
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\MortaExportEvent.cs", "Execute");
				\u000D\u0014\u0004.\u000A(\u001B\u0016\u0018.\u000A(), u000A, true);
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\MortaExportEvent.cs", "Execute");
		}
	}
}

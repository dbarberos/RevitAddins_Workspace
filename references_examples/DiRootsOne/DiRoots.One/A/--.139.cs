using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Models;
using DiRoots.One.SheetLink.Core;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000273 RID: 627
	internal sealed class \u0017\u0010 : \u0008\u0010
	{
		// Token: 0x14000024 RID: 36
		// (add) Token: 0x060018FF RID: 6399 RVA: 0x000A212C File Offset: 0x000A032C
		// (remove) Token: 0x06001900 RID: 6400 RVA: 0x000A2178 File Offset: 0x000A0378
		public event \u0017\u0010.\u0020\u0010 \u001F
		{
			[CompilerGenerated]
			add
			{
				\u0017\u0010.\u0020\u0010 u0020_u = this.\u001F;
				\u0017\u0010.\u0020\u0010 u0020_u2;
				do
				{
					u0020_u2 = u0020_u;
					\u0017\u0010.\u0020\u0010 value2 = (\u0017\u0010.\u0020\u0010)\u000F\u001E\u000A.\u000A(u0020_u2, value);
					u0020_u = Interlocked.CompareExchange<\u0017\u0010.\u0020\u0010>(ref this.\u001F, value2, u0020_u2);
				}
				while (u0020_u != u0020_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u0010.add_\u001F(\u0017\u0010.\u0020\u0010)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				\u0017\u0010.\u0020\u0010 u0020_u = this.\u001F;
				\u0017\u0010.\u0020\u0010 u0020_u2;
				do
				{
					u0020_u2 = u0020_u;
					\u0017\u0010.\u0020\u0010 value2 = (\u0017\u0010.\u0020\u0010)\u0012\u001E\u000A.\u000A(u0020_u2, value);
					u0020_u = Interlocked.CompareExchange<\u0017\u0010.\u0020\u0010>(ref this.\u001F, value2, u0020_u2);
				}
				while (u0020_u != u0020_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u0010.remove_\u001F(\u0017\u0010.\u0020\u0010)).MethodHandle;
				}
			}
		}

		// Token: 0x06001901 RID: 6401 RVA: 0x000A21C4 File Offset: 0x000A03C4
		public override void Execute(UIApplication app)
		{
			try
			{
				\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ExportEvent.cs", "Execute");
				\u0019\u0013\u0019.\u000A(false);
				Document u001D = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app));
				\u0009\u0014\u0019.\u000A(\u0001\u001A\u0005.\u000A(this), \u0020\u0014\u0018.\u000A(\u0004\u000C\u0005.\u000A(this)), \u0018\u000E\u0007.\u000A(\u001F\u0013\u0019.\u000A(), 1, 2));
				Tuple<Workbook, List<ParamValueInfo>, Dictionary<string, List<int>>> u001F = \u001B\u0012.\u000A(\u0019\u000C\u0005.\u000A(this), \u0004\u000C\u0005.\u000A(this), \u000C\u000C\u0018.\u001D(this), u001D, \u0001\u001A\u0005.\u000A(this), \u000A\u0015\u0018.\u001D(this));
				\u0009\u0014\u0019.\u000A(\u0001\u001A\u0005.\u000A(this), \u0003\u0019\u0018.\u000A(\u001E\u001D\u0018.\u000A(\u001D\u000C\u0005.\u000A(u001F))), \u0018\u000E\u0007.\u000A(\u000C\u0013\u0019.\u000A(), 2, 2));
				SheetLinkSyncfusionExcel u001F2 = \u0007\u000C\u0005.\u000A(\u001D\u000C\u0005.\u000A(u001F), true);
				\u001F\u000C\u0005.\u000A(u001F2, \u000A\u000C\u0005.\u000A(u001F));
				\u0015\u0012\u0005.\u001D(u001F2, \u0009\u001A\u0005.\u000A(u001F));
				\u0015\u001A\u0005.\u000A(u001F2, \u0006\u000F\u0018.\u0007(\u0001\u001A\u0005.\u000A(this)));
				List<string> u001F3 = \u0014\u000D\u0007.\u000A();
				\u001A\u0008\u0007.\u000A(u001F3, \u0020\u001E\u0018.\u000A(\u000A\u0015\u0018.\u001D(this)));
				ExportFilesTaskArgs exportFilesTaskArgs = \u0020\u0011\u0019.\u000A(u001F3, !\u0017\u0011\u0019.\u000A(\u000A\u0015\u0018.\u001D(this)));
				\u000E\u0011\u0019.\u000A(exportFilesTaskArgs, \u0008\u0011\u0019.\u000A(\u000A\u0015\u0018.\u001D(this)));
				\u0011\u0011\u0019.\u000A(exportFilesTaskArgs, \u0020\u001E\u0018.\u000A(\u000A\u0015\u0018.\u001D(this)));
				ITaskFinishedArgs u000A = exportFilesTaskArgs;
				\u0017\u0010.\u0020\u0010 u001F4 = this.\u001F;
				if (u001F4 == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u0010.Execute(UIApplication)).MethodHandle;
					}
				}
				else
				{
					\u0016\u000C\u0005.\u000A(u001F4, u000A);
				}
			}
			catch (TaskCanceledException u000A2)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ExportEvent.cs", "Execute");
			}
			catch (Exception u000A3)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ExportEvent.cs", "Execute");
				\u000D\u0014\u0004.\u000A(\u001B\u0016\u0018.\u000A(), u000A3, true);
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ExportEvent.cs", "Execute");
		}

		// Token: 0x0200094D RID: 2381
		// (Invoke) Token: 0x06005251 RID: 21073
		public delegate void \u0020\u0010(ITaskFinishedArgs taskFinished);
	}
}

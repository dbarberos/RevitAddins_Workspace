using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Models;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000274 RID: 628
	internal sealed class \u0014\u0010 : \u0008\u0010
	{
		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x06001903 RID: 6403 RVA: 0x000A2408 File Offset: 0x000A0608
		// (set) Token: 0x06001904 RID: 6404 RVA: 0x000A241C File Offset: 0x000A061C
		public ExportTypes ExportType { get; set; }

		// Token: 0x06001905 RID: 6405 RVA: 0x000A2430 File Offset: 0x000A0630
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ExtractDataEvent.cs", "Execute");
			Document u001D = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app));
			try
			{
				\u0019\u0013\u0019.\u000A(false);
				Tuple<Workbook, List<ParamValueInfo>, Dictionary<string, List<int>>> u001F = \u001B\u0012.\u000A(\u0019\u000C\u0005.\u000A(this), \u0004\u000C\u0005.\u000A(this), \u000C\u000C\u0018.\u001D(this), u001D, \u0001\u001A\u0005.\u000A(this), \u000A\u0015\u0018.\u001D(this));
				SyncfusionControlExcel syncfusionControlExcel = \u0012\u000C\u0005.\u000A(\u001D\u000C\u0005.\u000A(u001F), true);
				\u000F\u000C\u0005.\u000A(syncfusionControlExcel, \u000A\u000C\u0005.\u000A(u001F));
				\u0006\u000C\u0005.\u000A(syncfusionControlExcel, \u0009\u001A\u0005.\u000A(u001F));
				\u000B\u000C\u0005.\u000A(syncfusionControlExcel, \u0002\u000C\u0005.\u000A(this));
				ControlExcelBase controlExcelBase = syncfusionControlExcel;
				Delegate @delegate = \u000C\u001A\u0005.\u000A(this);
				if (@delegate == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u0010.Execute(UIApplication)).MethodHandle;
					}
				}
				else
				{
					object[] array = \u0004\u0015\u0010.\u001F(1);
					array[0] = controlExcelBase;
					\u0010\u001F\u0018.\u000A(@delegate, array);
				}
			}
			catch (TaskCanceledException u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ExtractDataEvent.cs", "Execute");
			}
			catch (Exception u000A2)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ExtractDataEvent.cs", "Execute");
				\u000D\u0014\u0004.\u000A(\u001B\u0016\u0018.\u000A(), u000A2, true);
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ExtractDataEvent.cs", "Execute");
		}

		// Token: 0x040009EF RID: 2543
		[CompilerGenerated]
		private ExportTypes \u000A\u000A;
	}
}

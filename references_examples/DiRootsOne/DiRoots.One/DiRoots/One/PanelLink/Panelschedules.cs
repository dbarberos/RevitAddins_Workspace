using System;
using System.Runtime.CompilerServices;
using System.Windows;
using A;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core.Base;
using DiRoots.One.Commons.Models;
using DiRoots.One.PanelLink.UI.Windows;

namespace DiRoots.One.PanelLink
{
	// Token: 0x0200018F RID: 399
	[Transaction(1)]
	public class Panelschedules : ExternalCommandBase
	{
		// Token: 0x06000EC6 RID: 3782 RVA: 0x0005E520 File Offset: 0x0005C720
		public Panelschedules()
		{
			PluginInfo pluginInfo = new PluginInfo();
			\u0015\u0001\u000A.\u000A(pluginInfo, \u000F\u0011\u0019.\u000A());
			\u001A\u0001\u000A.\u000A(pluginInfo, \u0010\u0011\u000A.\u000A());
			this._pluginInfo = pluginInfo;
		}

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x06000EC7 RID: 3783 RVA: 0x0005E558 File Offset: 0x0005C758
		// (set) Token: 0x06000EC8 RID: 3784 RVA: 0x0005E56C File Offset: 0x0005C76C
		internal static Window ActiveWindow { get; set; }

		// Token: 0x06000EC9 RID: 3785 RVA: 0x0005E580 File Offset: 0x0005C780
		public override Result Execute()
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Core\\ExternalCommands\\Panelschedules.cs", "Execute");
			UIDocument u001F = \u0020\u0013\u000A.\u000A(this._uiApp);
			\u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(this._uiApp));
			\u001E\u0002.\u000B();
			\u001C\u0011\u0019.\u000A(u001F);
			if (\u0012\u0011\u0019.\u000A() == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Panelschedules.Execute()).MethodHandle;
				}
				\u0018\u000D.\u0006(\u0020\u0013\u000A.\u000A(this._uiApp), \u000F\u0011\u0019.\u000A());
				PanelWindow panelWindow = \u0003\u0011\u0019.\u000A(u001F);
				\u0012\u0016\u001D.\u000A(this, panelWindow);
				\u0009\u0001\u0007.\u0007(panelWindow);
			}
			else
			{
				\u000F\u0016\u001D.\u000A(\u0013\u0005\u000E.\u001F(\u0012\u0011\u0019.\u000A()));
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Core\\ExternalCommands\\Panelschedules.cs", "Execute");
			return 0;
		}

		// Token: 0x06000ECA RID: 3786 RVA: 0x0005E648 File Offset: 0x0005C848
		public override void OnException()
		{
			\u000D\u0011\u0019.\u000A(\u000D\u0018\u000E.\u001F);
		}

		// Token: 0x040005D0 RID: 1488
		[CompilerGenerated]
		private static Window \u0018;
	}
}

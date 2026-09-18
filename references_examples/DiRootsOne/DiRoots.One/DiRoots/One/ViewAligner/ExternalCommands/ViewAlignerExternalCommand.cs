using System;
using System.Windows;
using A;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core.Base;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Progress;
using DiRoots.One.ViewAligner.Data.Services;
using DiRoots.One.ViewAligner.Services;
using DiRoots.One.ViewAligner.Wpf.ViewModels;
using DiRoots.One.ViewAligner.Wpf.Windows;

namespace DiRoots.One.ViewAligner.ExternalCommands
{
	// Token: 0x020000D0 RID: 208
	[Regeneration(0)]
	[Transaction(1)]
	public class ViewAlignerExternalCommand : ExternalCommandBase
	{
		// Token: 0x060007E6 RID: 2022 RVA: 0x0002D6C4 File Offset: 0x0002B8C4
		public ViewAlignerExternalCommand()
		{
			PluginInfo pluginInfo = new PluginInfo();
			\u0015\u0001\u000A.\u000A(pluginInfo, \u0007\u0008\u001D.\u000A());
			\u001A\u0001\u000A.\u000A(pluginInfo, ViewAlignerExternalCommand.\u0004);
			this._pluginInfo = pluginInfo;
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x0002D724 File Offset: 0x0002B924
		public override Result Execute()
		{
			if (!\u0010\u0016\u001D.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewAlignerExternalCommand.Execute()).MethodHandle;
				}
				return -1;
			}
			if (\u0019\u0008\u001D.\u000A() != null)
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
				\u000F\u0016\u001D.\u000A(\u0019\u0008\u001D.\u000A());
				return 0;
			}
			MainWindow mainWindow = \u0004\u0008\u001D.\u000A();
			\u001C\u000C\u0007.\u001D(mainWindow, \u001D\u0008\u001D.\u000A(this._pluginInfo));
			\u0017\u001A\u000A.\u001D(mainWindow, this.\u0003(mainWindow));
			\u0012\u0016\u001D.\u000A(this, mainWindow);
			\u0009\u0001\u0007.\u0007(mainWindow);
			return 0;
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x0002D7AC File Offset: 0x0002B9AC
		private MainViewModel \u0003(Window \u001F)
		{
			DocumentContext u001F = \u0012\u0008\u001D.\u000A(this._uiApp);
			DataService u001F2 = \u0006\u0008\u001D.\u000A(u001F, \u000F\u0008\u001D.\u000A(\u0016\u0010\u001D.\u000A(u001F)));
			ProgressWindowService progressWindowService = \u0002\u0008\u001D.\u000A();
			\u000B\u0008\u001D.\u000A(progressWindowService, \u001F);
			ProgressWindowService u000A = progressWindowService;
			string u = \u0016\u0010\u001D.\u000A(u001F).\u0007();
			ReportingService u2 = \u0016\u0008\u001D.\u000A(\u001F, "", u);
			ViewAlignProvider u000A2 = \u0005\u0008\u001D.\u000A(u001F, u000A, u2, \u001D\u0008\u001D.\u000A(this._pluginInfo));
			return \u0018\u0008\u001D.\u000A(u001F2, u000A2);
		}

		// Token: 0x04000328 RID: 808
		private static readonly ICustomLogger \u0004 = \u0008\u0007\u001D.\u000A("DiRootsOne", \u0007\u0008\u001D.\u000A());
	}
}

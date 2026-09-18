using System;
using System.Collections.Generic;
using A;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core.Base;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.Services;
using DiRoots.One.SheetGen.Data;
using DiRoots.One.SheetGen.Models.Interfaces;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002C8 RID: 712
	[Transaction(1)]
	public class MainCommand : ExternalCommandBase
	{
		// Token: 0x06001D05 RID: 7429 RVA: 0x000B77C8 File Offset: 0x000B59C8
		public MainCommand()
		{
			PluginInfo pluginInfo = new PluginInfo();
			\u0015\u0001\u000A.\u000A(pluginInfo, \u0013\u0007\u0016.\u000A());
			\u001A\u0001\u000A.\u000A(pluginInfo, \u0011\u0015\u0005.\u000A());
			this._pluginInfo = pluginInfo;
		}

		// Token: 0x06001D06 RID: 7430 RVA: 0x000B7800 File Offset: 0x000B5A00
		public override Result Execute()
		{
			try
			{
				\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\ExternalCommands\\MainCommand.cs", "Execute");
				if (\u001D\u0011\u0016.\u000A() == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainCommand.Execute()).MethodHandle;
					}
					\u0016\u0011\u0016.\u000A(\u001A\u0007\u001D.\u000A(this._uiApp), new EventHandler<FailuresProcessingEventArgs>(this.\u001C));
					\u0005\u0011\u0016.\u000A(DocumentAccessProvider.\u0004, this._uiApp);
					\u0019\u0011\u0016.\u000A(\u0018\u0011\u0016.\u000A());
					ICancellationManagerService service = \u000E\u001B\u000A.\u0004.GetService<ICancellationManagerService>(false);
					if (service == null)
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
					}
					else
					{
						\u0004\u0011\u0016.\u000A(service);
					}
					MainWindow mainWindow = \u0018\u001C\u000E.\u001F(\u000E\u001B\u000A.\u0004.GetService<IMainWindow>(false));
					\u0012\u0016\u001D.\u000A(this, mainWindow);
					\u0009\u0001\u0007.\u0007(mainWindow);
				}
				else
				{
					\u000F\u0016\u001D.\u000A(\u001D\u0011\u0016.\u000A());
				}
				if (\u0007\u0011\u0016.\u000A() != null)
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
					\u000A\u0011\u0016.\u000A(\u0007\u0011\u0016.\u000A(), true);
				}
			}
			finally
			{
				\u001F\u0011\u0016.\u000A(\u001A\u0007\u001D.\u000A(this._uiApp), new EventHandler<FailuresProcessingEventArgs>(this.\u001C));
			}
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\ExternalCommands\\MainCommand.cs", "Execute");
			return 0;
		}

		// Token: 0x06001D07 RID: 7431 RVA: 0x000B7938 File Offset: 0x000B5B38
		private void \u001C(object \u001F, FailuresProcessingEventArgs \u000A)
		{
			FailuresAccessor u001F = \u000F\u0011\u0016.\u000A(\u000A);
			IEnumerator<FailureMessageAccessor> enumerator = \u001B\u0005\u0004.\u000A(\u0013\u0017\u0007.\u000A(u001F));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					FailureMessageAccessor failureMessageAccessor = \u0008\u0005\u0004.\u000A(enumerator);
					if (\u000B\u0011\u0016.\u000A(\u0006\u0011\u0016.\u000A(failureMessageAccessor), \u0002\u0011\u0016.\u000A()))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(MainCommand.\u001C(object, FailuresProcessingEventArgs)).MethodHandle;
						}
						\u0010\u0005\u0004.\u000A(u001F, failureMessageAccessor);
					}
				}
				for (;;)
				{
					switch (6)
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
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}
	}
}

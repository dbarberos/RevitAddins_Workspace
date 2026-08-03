using System;
using A;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core.Base;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.TableGen.UI;

namespace DiRoots.One.TableGen.Core
{
	// Token: 0x02000188 RID: 392
	public class CommandAutoSync : ExternalCommandBase
	{
		// Token: 0x06000E82 RID: 3714 RVA: 0x0005C0D4 File Offset: 0x0005A2D4
		public CommandAutoSync()
		{
			\u0007\u0018.\u000A(\u0004\u0001\u001D.\u000A());
			PluginInfo pluginInfo = new PluginInfo();
			\u0015\u0001\u000A.\u000A(pluginInfo, \u0004\u0001\u001D.\u000A());
			\u001A\u0001\u000A.\u000A(pluginInfo, \u0007\u0018.\u0007<ICustomLogger>());
			this._pluginInfo = pluginInfo;
		}

		// Token: 0x06000E83 RID: 3715 RVA: 0x0005C118 File Offset: 0x0005A318
		public override Result Execute()
		{
			return this.\u0012(this._uiApp);
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x0005C134 File Offset: 0x0005A334
		internal Result \u0012(UIApplication \u001F)
		{
			try
			{
				if (\u0020\u0013\u000A.\u000A(\u001F) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(CommandAutoSync.\u0012(UIApplication)).MethodHandle;
					}
					return -1;
				}
				\u0007\u0018.\u000A(\u001F);
				\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Enter CommandAutoSync", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalCommands\\CommandAutoSync.cs", "Execute");
				\u0009\u000B\u0019.\u000A(\u0006\u0001\u001D.\u000A());
				\u001C\u0002.\u001E();
				UI_PleaseWait ui_PleaseWait = \u0017\u000E\u0019.\u000A(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()));
				\u0020\u000E\u0019.\u000A(\u001F, ui_PleaseWait);
				if (\u001E\u000E\u0019.\u000A(ui_PleaseWait))
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
					\u0009\u0001\u0007.\u0007(ui_PleaseWait);
					\u0011\u000E\u0019.\u0007(ui_PleaseWait);
				}
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalCommands\\CommandAutoSync.cs", "Execute");
				\u001B\u0002\u0019.\u000A(false);
			}
			\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Exit CommandAutoSync", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalCommands\\CommandAutoSync.cs", "Execute");
			return 0;
		}
	}
}

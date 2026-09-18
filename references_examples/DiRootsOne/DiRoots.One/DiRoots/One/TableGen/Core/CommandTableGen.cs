using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core.Base;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.TableGen.UI;

namespace DiRoots.One.TableGen.Core
{
	// Token: 0x02000189 RID: 393
	[Transaction(1)]
	public class CommandTableGen : ExternalCommandBase
	{
		// Token: 0x06000E85 RID: 3717 RVA: 0x0005C228 File Offset: 0x0005A428
		public CommandTableGen()
		{
			\u0007\u0018.\u000A(\u0004\u0001\u001D.\u000A());
			PluginInfo pluginInfo = new PluginInfo();
			\u0015\u0001\u000A.\u000A(pluginInfo, \u0004\u0001\u001D.\u000A());
			\u001A\u0001\u000A.\u000A(pluginInfo, \u0007\u0018.\u0007<ICustomLogger>());
			this._pluginInfo = pluginInfo;
		}

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x06000E86 RID: 3718 RVA: 0x0005C26C File Offset: 0x0005A46C
		// (set) Token: 0x06000E87 RID: 3719 RVA: 0x0005C280 File Offset: 0x0005A480
		internal static MainWindow MainWindowInstance { get; set; }

		// Token: 0x06000E88 RID: 3720 RVA: 0x0005C294 File Offset: 0x0005A494
		public override Result Execute()
		{
			if (!\u0010\u0016\u001D.\u000A(this))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(CommandTableGen.Execute()).MethodHandle;
				}
				return -1;
			}
			\u000D\u0016\u001D.\u000A(\u0009\u0009\u000A.\u000A());
			if (\u0015\u000E\u0019.\u000A())
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
				return 0;
			}
			\u0007\u0018.\u000A(this._uiApp);
			if (\u0014\u000E\u0019.\u000A() != null)
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
				if (!\u000C\u000E\u0019.\u000A())
				{
					\u000F\u0016\u001D.\u000A(\u0014\u000E\u0019.\u000A());
					goto IL_121;
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
			\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Enter CommandTableGen", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalCommands\\CommandTableGen.cs", "Execute");
			\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Enter GetGuid", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalCommands\\CommandTableGen.cs", "Execute");
			\u001A\u000E\u0019.\u000A().\u001D(\u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(this._uiApp)), true);
			\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Exit GetGuid", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalCommands\\CommandTableGen.cs", "Execute");
			\u001C\u0002.\u001E();
			\u001F\u0002\u0019.\u000A(\u0013\u000E\u0019.\u000A());
			\u0012\u0016\u001D.\u000A(this, \u0014\u000E\u0019.\u000A());
			\u0009\u0001\u0007.\u0007(\u0014\u000E\u0019.\u000A());
			IL_121:
			\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Exit CommandTableGen", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Core\\ExternalCommands\\CommandTableGen.cs", "Execute");
			return 0;
		}

		// Token: 0x040005BB RID: 1467
		[CompilerGenerated]
		private static MainWindow \u0019;
	}
}

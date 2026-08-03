using System;
using A;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core.Base;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.SheetLink
{
	// Token: 0x02000207 RID: 519
	[Transaction(1)]
	public class CommandSheetLink : ExternalCommandBase
	{
		// Token: 0x06001353 RID: 4947 RVA: 0x0007B5C8 File Offset: 0x000797C8
		public CommandSheetLink()
		{
			PluginInfo pluginInfo = new PluginInfo();
			\u0015\u0001\u000A.\u000A(pluginInfo, \u000F\u0011\u0019.\u000A());
			\u001A\u0001\u000A.\u000A(pluginInfo, \u0010\u0011\u000A.\u000A());
			this._pluginInfo = pluginInfo;
		}

		// Token: 0x06001354 RID: 4948 RVA: 0x0007B600 File Offset: 0x00079800
		public override Result Execute()
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\Core\\ExternalCommands\\CommandSheetLink.cs", "Execute");
			UIDocument u001F = \u0020\u0013\u000A.\u000A(this._uiApp);
			if (\u001F\u000C\u000A.\u001D(\u0011\u0020\u000A.\u0007(u001F)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CommandSheetLink.Execute()).MethodHandle;
				}
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
					return -1;
				}
			}
			if (\u0014\u0017\u0018.\u000A() == null)
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
				\u0018\u000D.\u0006(u001F, \u000F\u0011\u0019.\u000A());
				\u000B\u0012.\u0007();
				\u0013\u0017\u0018.\u000A(\u001A\u0017\u0018.\u000A(u001F));
				\u0012\u0016\u001D.\u000A(this, \u0014\u0017\u0018.\u000A());
				\u0009\u0001\u0007.\u0007(\u0014\u0017\u0018.\u000A());
			}
			else
			{
				\u000F\u0016\u001D.\u000A(\u0014\u0017\u0018.\u000A());
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\Core\\ExternalCommands\\CommandSheetLink.cs", "Execute");
			return 0;
		}

		// Token: 0x06001355 RID: 4949 RVA: 0x0007B6DC File Offset: 0x000798DC
		public override void OnException()
		{
			\u0013\u0017\u0018.\u000A(\u001B\u000B\u000E.\u001F);
		}
	}
}

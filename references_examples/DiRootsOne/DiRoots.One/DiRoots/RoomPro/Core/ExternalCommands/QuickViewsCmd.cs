using System;
using A;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core.Base;
using DiRoots.One.Commons.Models;

namespace DiRoots.RoomPro.Core.ExternalCommands
{
	// Token: 0x020000A4 RID: 164
	[Transaction(1)]
	public class QuickViewsCmd : ExternalCommandBase
	{
		// Token: 0x060006BB RID: 1723 RVA: 0x00026E90 File Offset: 0x00025090
		public QuickViewsCmd()
		{
			PluginInfo pluginInfo = new PluginInfo();
			\u0015\u0001\u000A.\u000A(pluginInfo, \u001B\u0007\u001D.\u000A());
			\u001A\u0001\u000A.\u000A(pluginInfo, \u001E\u000A\u0007.\u000A());
			this._pluginInfo = pluginInfo;
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x00026EC8 File Offset: 0x000250C8
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsCmd.Execute()).MethodHandle;
				}
				return -1;
			}
			\u000D\u0016\u001D.\u000A(\u0009\u0009\u000A.\u000A());
			UIDocument u001F = \u0020\u0013\u000A.\u000A(this._uiApp);
			\u0011\u0020\u000A.\u0007(u001F);
			\u001C\u0016\u001D.\u000A(this._uiApp);
			if (\u0019\u000A\u001D.\u000A() == null)
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
				\u0002\u0004.\u0016();
				\u0016\u001B\u000A.\u0018();
				\u0013\u000C\u0007.\u000A(\u0003\u0016\u001D.\u000A(u001F, this._uiApp));
				\u0012\u0016\u001D.\u000A(this, \u0019\u000A\u001D.\u000A());
				\u0009\u0001\u0007.\u0007(\u0019\u000A\u001D.\u000A());
			}
			else
			{
				\u000F\u0016\u001D.\u000A(\u0019\u000A\u001D.\u000A());
			}
			return 0;
		}
	}
}

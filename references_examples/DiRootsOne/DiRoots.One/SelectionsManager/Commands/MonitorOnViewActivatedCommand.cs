using System;
using A;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using DiRoots.One.Commons.Core.Base;
using DiRoots.One.Commons.Models;
using SelectionsManager.UI.Pages;

namespace SelectionsManager.Commands
{
	// Token: 0x0200003C RID: 60
	[Transaction(2)]
	public class MonitorOnViewActivatedCommand : ExternalCommandBase
	{
		// Token: 0x060001E6 RID: 486 RVA: 0x00009EA0 File Offset: 0x000080A0
		public MonitorOnViewActivatedCommand()
		{
			PluginInfo pluginInfo = new PluginInfo();
			\u0015\u0001\u000A.\u000A(pluginInfo, \u0001\u0001\u000A.\u000A());
			\u001A\u0001\u000A.\u000A(pluginInfo, \u000C\u0001\u000A.\u000A());
			this._pluginInfo = pluginInfo;
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x00009ED8 File Offset: 0x000080D8
		internal static \u0019\u000A \u000F
		{
			get
			{
				return MonitorOnViewActivatedCommand.\u0007;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x00009EEC File Offset: 0x000080EC
		public bool IsSubscribed
		{
			get
			{
				return MonitorOnViewActivatedCommand.\u000A;
			}
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00009F00 File Offset: 0x00008100
		public override Result Execute()
		{
			if (MonitorOnViewActivatedCommand.\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MonitorOnViewActivatedCommand.Execute()).MethodHandle;
				}
				\u0007\u0009\u000A.\u000A(this);
				MonitorOnViewActivatedCommand.\u000A = false;
			}
			else
			{
				\u000A\u0009\u000A.\u000A(this, \u000A\u0009\u0010.\u001F);
				MonitorOnViewActivatedCommand.\u000A = true;
			}
			return 0;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00009F48 File Offset: 0x00008148
		public void Subscribe(MainPage page = null)
		{
			if (MonitorOnViewActivatedCommand.\u0007 == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MonitorOnViewActivatedCommand.Subscribe(MainPage)).MethodHandle;
				}
				MonitorOnViewActivatedCommand.\u0007 = new \u0019\u000A();
			}
			if (page != null)
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
				MonitorOnViewActivatedCommand.\u0007.\u001F += \u0015\u0015\u0010.\u001F(\u0007\u000C\u000A.\u0007(page.R)).DKR;
			}
			\u001D\u0009\u000A.\u000A(\u0017\u0013\u000A.\u001D(\u0010\u0014\u000A.\u000A()), new EventHandler<ViewActivatedEventArgs>(MonitorOnViewActivatedCommand.\u0007.\u0007));
			MonitorOnViewActivatedCommand.\u000A = true;
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00009FD8 File Offset: 0x000081D8
		public void Unsubscribe()
		{
			\u0004\u0009\u000A.\u000A(\u0017\u0013\u000A.\u001D(\u0010\u0014\u000A.\u000A()), new EventHandler<ViewActivatedEventArgs>(MonitorOnViewActivatedCommand.\u0007.\u0007));
			MonitorOnViewActivatedCommand.\u000F.\u001D();
			MonitorOnViewActivatedCommand.\u000A = false;
		}

		// Token: 0x040000C8 RID: 200
		private static \u0019\u000A \u0007;

		// Token: 0x040000C9 RID: 201
		private static bool \u000A;
	}
}

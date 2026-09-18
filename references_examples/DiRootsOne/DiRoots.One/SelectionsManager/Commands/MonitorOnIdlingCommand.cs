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
	// Token: 0x0200003B RID: 59
	[Transaction(2)]
	public class MonitorOnIdlingCommand : ExternalCommandBase
	{
		// Token: 0x060001DF RID: 479 RVA: 0x00009CBC File Offset: 0x00007EBC
		static MonitorOnIdlingCommand()
		{
			if (MonitorOnIdlingCommand.\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MonitorOnIdlingCommand..cctor()).MethodHandle;
				}
				MonitorOnIdlingCommand.\u001F = new \u0004\u000A();
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00009CF0 File Offset: 0x00007EF0
		public MonitorOnIdlingCommand()
		{
			PluginInfo pluginInfo = new PluginInfo();
			\u0015\u0001\u000A.\u000A(pluginInfo, \u0001\u0001\u000A.\u000A());
			\u001A\u0001\u000A.\u000A(pluginInfo, \u000C\u0001\u000A.\u000A());
			this._pluginInfo = pluginInfo;
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00009D28 File Offset: 0x00007F28
		internal static \u0004\u000A \u0006
		{
			get
			{
				return MonitorOnIdlingCommand.\u001F;
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00009D3C File Offset: 0x00007F3C
		public override Result Execute()
		{
			if (MonitorOnIdlingCommand.\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MonitorOnIdlingCommand.Execute()).MethodHandle;
				}
				\u0002\u001A\u000A.\u001D(this);
				MonitorOnIdlingCommand.\u000A = false;
			}
			else
			{
				\u000A\u001A\u000A.\u001D(this, \u000A\u0009\u0010.\u001F);
				MonitorOnIdlingCommand.\u000A = true;
			}
			return 0;
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00009D84 File Offset: 0x00007F84
		public bool IsSubscribed
		{
			get
			{
				return MonitorOnIdlingCommand.\u000A;
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00009D98 File Offset: 0x00007F98
		public void Subscribe(MainPage page = null)
		{
			if (MonitorOnIdlingCommand.\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MonitorOnIdlingCommand.Subscribe(MainPage)).MethodHandle;
				}
				MonitorOnIdlingCommand.\u001F = new \u0004\u000A();
			}
			MonitorOnIdlingCommand.\u001F.\u0004();
			if (page != null)
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
				MonitorOnIdlingCommand.\u001F.\u001F += \u0001\u0015\u0010.\u001F(\u0007\u000C\u000A.\u0007(page.F)).BKR;
				MonitorOnIdlingCommand.\u001F.\u000A += \u0001\u0015\u0010.\u001F(\u0007\u000C\u000A.\u0007(page.F)).UKR;
			}
			\u0009\u0001\u000A.\u000A(\u0017\u0013\u000A.\u001D(\u0010\u0014\u000A.\u000A()), new EventHandler<IdlingEventArgs>(MonitorOnIdlingCommand.\u001F.\u001D));
			MonitorOnIdlingCommand.\u000A = true;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00009E5C File Offset: 0x0000805C
		public void Unsubscribe()
		{
			\u001F\u0009\u000A.\u000A(\u0017\u0013\u000A.\u001D(\u0010\u0014\u000A.\u000A()), new EventHandler<IdlingEventArgs>(MonitorOnIdlingCommand.\u001F.\u001D));
			MonitorOnIdlingCommand.\u0006.\u0004();
			MonitorOnIdlingCommand.\u000A = false;
		}

		// Token: 0x040000C6 RID: 198
		private static \u0004\u000A \u001F;

		// Token: 0x040000C7 RID: 199
		private static bool \u000A;
	}
}

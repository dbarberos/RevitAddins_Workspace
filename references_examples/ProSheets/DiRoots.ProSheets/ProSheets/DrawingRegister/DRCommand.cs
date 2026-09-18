using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using DiRoots.Prosheets.Commons.Core.Base;
using DiRoots.Prosheets.Commons.Models;

namespace ProSheets.DrawingRegister
{
	// Token: 0x02000106 RID: 262
	[Transaction(1)]
	public class DRCommand : ExternalCommandBase
	{
		// Token: 0x06000CB7 RID: 3255 RVA: 0x0004AB28 File Offset: 0x00048D28
		public DRCommand()
		{
			PluginInfo pluginInfo = new PluginInfo();
			\u001C\u0004\u0014.\u0018(pluginInfo, "DocRegister");
			\u000D\u0004\u0014.\u0018(pluginInfo, \u0002\u0002\u0016.\u0018());
			this._pluginInfo = pluginInfo;
		}

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06000CB9 RID: 3257 RVA: 0x0004AB74 File Offset: 0x00048D74
		// (set) Token: 0x06000CBA RID: 3258 RVA: 0x0004AB88 File Offset: 0x00048D88
		public static bool IsMainWindowClosed { get; set; } = true;

		// Token: 0x06000CBB RID: 3259 RVA: 0x0004AB9C File Offset: 0x00048D9C
		public override Result Execute()
		{
			if (!\u001F\u001D\u0016.\u0018(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DRCommand.Execute()).MethodHandle;
				}
				return -1;
			}
			\u0020\u001D\u0016.\u0018();
			\u0020\u0004\u0014.\u0018(this._uiApp);
			\u000A\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\DRCommand.cs", "Execute");
			if (\u001C\u001D\u0016.\u0018() == null)
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
				\u0013\u001D\u0016.\u0018(\u0009\u001D\u0016.\u0018());
				\u0009\u0004\u0014.\u0018(this, \u001C\u001D\u0016.\u0018());
				\u000F\u001E\u0014.\u0018(\u001C\u001D\u0016.\u0018());
			}
			else
			{
				\u0013\u0004\u0014.\u0018(\u001C\u001D\u0016.\u0018());
			}
			\u000D\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\DRCommand.cs", "Execute");
			return 0;
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x0004AC4C File Offset: 0x00048E4C
		public static void AddButton(UIControlledApplication application, string tabName)
		{
			IEnumerable<RibbonPanel> enumerable = \u0018\u001D\u0014.\u0018(application, tabName);
			Func<RibbonPanel, bool> func;
			if ((func = DRCommand.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DRCommand.AddButton(UIControlledApplication, string)).MethodHandle;
				}
				func = (DRCommand.<>c.\u0018 = new Func<RibbonPanel, bool>(DRCommand.<>c.\u000C.\u0014));
			}
			RibbonPanel ribbonPanel = Enumerable.FirstOrDefault<RibbonPanel>(enumerable, func);
			if (ribbonPanel == null)
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
				ribbonPanel = \u000C\u001D\u0014.\u0018(application, tabName, "Export", false);
			}
			else
			{
				\u000E\u0004\u0014.\u0018(ribbonPanel);
			}
			DRCommand.\u0014 = ribbonPanel;
			string u = \u001C\u0015\u0014.\u0018(\u0001\u0004\u0014.\u0018());
			PushButton u000C = \u0008\u0004\u0014.\u0018(ribbonPanel, "DocRegister", "DocRegister", \u000A\u001D\u0018.\u0018(\u0018\u0006\u000F.\u000C()), u);
			\u0006\u0004\u0014.\u0018(u000C, \u0002\u0009\u0014.\u0018(\u000A\u001D\u0018.\u0018(typeof(AppStartUp.AvailableIfOpenDoc).TypeHandle)));
			\u0007\u0004\u0014.\u0018(u000C, \u0004\u0004\u0014.\u0018(\u000B\u0004\u0014.\u0018(\u0017\u001D\u0016.\u0018()), IntPtr.Zero, \u001A\u0004\u0014.\u0018(), \u001D\u0004\u0014.\u0018()));
			\u0002\u0004\u0014.\u0018(u000C, \u0004\u0004\u0014.\u0018(\u000B\u0004\u0014.\u0018(\u0015\u001D\u0016.\u0018()), IntPtr.Zero, \u001A\u0004\u0014.\u0018(), \u001D\u0004\u0014.\u0018()));
			\u0017\u0004\u0014.\u0018(u000C, \u001E\u0004\u0014.\u0018(2, "https://diroots.com/plugins/prosheets-revit-addin/"));
			\u0015\u0004\u0014.\u0018(u000C, \u0011\u001D\u0016.\u0018());
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x0004AD8C File Offset: 0x00048F8C
		public static void UpdateColorTheme(int themeIndex)
		{
			\u000F\u001D\u0014.\u0018(DRCommand.\u0014, themeIndex, "#D6DCE4", "#5e84ad");
		}

		// Token: 0x040005D2 RID: 1490
		[CompilerGenerated]
		private static bool \u0018;

		// Token: 0x040005D3 RID: 1491
		private static RibbonPanel \u0014;
	}
}

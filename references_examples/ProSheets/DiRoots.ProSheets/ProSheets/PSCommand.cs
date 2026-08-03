using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using DiRoots.One.Commons.Interfaces;
using DiRoots.Prosheets.Commons.Core.Base;
using DiRoots.Prosheets.Commons.Models;
using ProSheets.Helpers;

namespace ProSheets
{
	// Token: 0x02000064 RID: 100
	[Transaction(1)]
	public class PSCommand : ExternalCommandBase
	{
		// Token: 0x06000527 RID: 1319 RVA: 0x0001A700 File Offset: 0x00018900
		public PSCommand()
		{
			PluginInfo pluginInfo = new PluginInfo();
			\u001C\u0004\u0014.\u0018(pluginInfo, "ProSheets");
			\u000D\u0004\u0014.\u0018(pluginInfo, IocContainer.GetService<ICustomLogger>());
			this._pluginInfo = pluginInfo;
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x0001A74C File Offset: 0x0001894C
		// (set) Token: 0x0600052A RID: 1322 RVA: 0x0001A760 File Offset: 0x00018960
		public static bool IsMainWindowClosed { get; set; } = true;

		// Token: 0x0600052B RID: 1323 RVA: 0x0001A774 File Offset: 0x00018974
		public override Result Execute()
		{
			UIDocument u000C = \u001F\u001F\u0014.\u0018(this._uiApp);
			\u0017\u0005\u0018.\u0014(u000C);
			\u001B\u0011\u0018.\u000C(u000C, IocContainer.GetService<ICustomLogger>());
			if (PSCommand.\u000C != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PSCommand.Execute()).MethodHandle;
				}
				if (!\u0011\u0004\u0014.\u0018())
				{
					\u0013\u0004\u0014.\u0018(PSCommand.\u000C);
					return 0;
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
			\u001F\u0004\u0014.\u0018();
			\u0005\u0020\u0018.\u0012();
			\u0020\u0004\u0014.\u0018(this._uiApp);
			\u0010\u0009\u0018.\u0018();
			PSCommand.objFlag = true;
			PSCommand.\u000C = \u000A\u0004\u0014.\u0018(u000C);
			\u0009\u0004\u0014.\u0018(this, PSCommand.\u000C);
			\u000F\u001E\u0014.\u0018(PSCommand.\u000C);
			return 0;
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0001A824 File Offset: 0x00018A24
		public static void addButton(UIControlledApplication application, string tabName)
		{
			\u0014\u001D\u0014.\u0018(application, tabName);
			IEnumerable<RibbonPanel> enumerable = \u0018\u001D\u0014.\u0018(application, tabName);
			Func<RibbonPanel, bool> func;
			if ((func = PSCommand.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PSCommand.addButton(UIControlledApplication, string)).MethodHandle;
				}
				func = (PSCommand.<>c.\u0018 = new Func<RibbonPanel, bool>(PSCommand.<>c.\u000C.\u0014));
			}
			RibbonPanel ribbonPanel = Enumerable.FirstOrDefault<RibbonPanel>(enumerable, func);
			if (ribbonPanel == null)
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
				ribbonPanel = \u000C\u001D\u0014.\u0018(application, tabName, "Export", false);
			}
			else
			{
				\u000E\u0004\u0014.\u0018(ribbonPanel);
			}
			PSCommand.\u0014 = ribbonPanel;
			EventHandler<ThemeChangedEventArgs> u;
			if ((u = PSCommand.\u0007\u0009\u0018.\u000C) == null)
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
				u = (PSCommand.\u0007\u0009\u0018.\u000C = new EventHandler<ThemeChangedEventArgs>(PSCommand.\u000F));
			}
			\u0005\u0004\u0014.\u0018(application, u);
			\u001B\u0004\u0014.\u0018(PSCommand.\u0012());
			string u2 = \u001C\u0015\u0014.\u0018(\u0001\u0004\u0014.\u0018());
			PushButton u000C = \u0008\u0004\u0014.\u0018(ribbonPanel, "ProSheets", "ProSheets", \u000A\u001D\u0018.\u0018(\u001B\u001A\u000F.\u000C()), u2);
			\u0006\u0004\u0014.\u0018(u000C, \u0002\u0009\u0014.\u0018(\u000A\u001D\u0018.\u0018(typeof(AppStartUp.AvailableIfOpenDoc).TypeHandle)));
			\u0007\u0004\u0014.\u0018(u000C, \u0004\u0004\u0014.\u0018(\u000B\u0004\u0014.\u0018(\u0010\u0004\u0014.\u0018()), IntPtr.Zero, \u001A\u0004\u0014.\u0018(), \u001D\u0004\u0014.\u0018()));
			\u0002\u0004\u0014.\u0018(u000C, \u0004\u0004\u0014.\u0018(\u000B\u0004\u0014.\u0018(\u0019\u0004\u0014.\u0018()), IntPtr.Zero, \u001A\u0004\u0014.\u0018(), \u001D\u0004\u0014.\u0018()));
			\u0017\u0004\u0014.\u0018(u000C, \u001E\u0004\u0014.\u0018(2, "https://diroots.com/plugins/prosheets-revit-addin/"));
			\u0015\u0004\u0014.\u0018(u000C, \u001C\u0009\u0018.\u0004\u0003);
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0001A9A4 File Offset: 0x00018BA4
		private static void \u000F(object \u000C, ThemeChangedEventArgs \u0018)
		{
			int u000C = PSCommand.\u0012();
			\u001B\u0004\u0014.\u0018(u000C);
			\u0003\u001D\u0014.\u0018(u000C);
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0001A9C4 File Offset: 0x00018BC4
		private static int \u0012()
		{
			int result = 1;
			UITheme uitheme = \u0016\u001D\u0014.\u0018();
			if (uitheme != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PSCommand.\u0012()).MethodHandle;
				}
				if (uitheme != 1)
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
					result = 1;
				}
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0001AA08 File Offset: 0x00018C08
		public static void UpdateColorTheme(int themeIndex)
		{
			\u000F\u001D\u0014.\u0018(PSCommand.\u0014, themeIndex, "#D6DCE4", "#5e84ad");
		}

		// Token: 0x040001D8 RID: 472
		public static bool objFlag;

		// Token: 0x040001D9 RID: 473
		private static UI_MainWindow \u000C;

		// Token: 0x040001DA RID: 474
		[CompilerGenerated]
		private static bool \u0018;

		// Token: 0x040001DB RID: 475
		private static RibbonPanel \u0014;

		// Token: 0x0200017C RID: 380
		[CompilerGenerated]
		private static class \u0007\u0009\u0018
		{
			// Token: 0x040007B1 RID: 1969
			public static EventHandler<ThemeChangedEventArgs> \u000C;
		}
	}
}

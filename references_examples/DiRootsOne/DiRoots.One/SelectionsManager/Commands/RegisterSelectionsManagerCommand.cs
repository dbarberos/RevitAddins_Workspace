using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core.Base;
using DiRoots.One.Commons.Models;
using SelectionsManager.UI.Pages;

namespace SelectionsManager.Commands
{
	// Token: 0x0200003D RID: 61
	[Transaction(1)]
	[Regeneration(0)]
	public class RegisterSelectionsManagerCommand : ExternalCommandBase
	{
		// Token: 0x060001EC RID: 492 RVA: 0x0000A01C File Offset: 0x0000821C
		public RegisterSelectionsManagerCommand()
		{
			PluginInfo pluginInfo = new PluginInfo();
			\u0015\u0001\u000A.\u000A(pluginInfo, \u0001\u0001\u000A.\u000A());
			\u001A\u0001\u000A.\u000A(pluginInfo, \u000C\u0001\u000A.\u000A());
			this._pluginInfo = pluginInfo;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0000A054 File Offset: 0x00008254
		public override Result Execute()
		{
			return this.\u0012(this._uiApp);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0000A070 File Offset: 0x00008270
		internal Result \u0012(UIApplication \u001F)
		{
			DockablePaneProviderData u000A = \u000B\u0009\u000A.\u000A();
			\u0005\u0009\u000A.\u000A(\u0016\u0009\u000A.\u000A());
			\u0018\u0009\u000A.\u000A(\u000D\u001A\u000A.\u000A(), u000A);
			DockablePaneId u000A2 = \u000F\u001A\u000A.\u000A(\u0012\u001A\u000A.\u000A());
			try
			{
				\u0019\u0009\u000A.\u000A(\u001F, u000A2, "Selections and Filters Manager", \u000D\u001A\u000A.\u000A());
			}
			catch (Exception u000A3)
			{
				\u000D\u0011\u000A.\u0007(\u000C\u0001\u000A.\u000A(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\OneFilter\\SelectionsManager\\Commands\\RegisterSelectionsManagerCommand.cs", "Execute");
			}
			return 0;
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001EF RID: 495 RVA: 0x0000A0F0 File Offset: 0x000082F0
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x0000A104 File Offset: 0x00008304
		public static MainPage MainPage { get; set; }

		// Token: 0x040000CA RID: 202
		[CompilerGenerated]
		private static MainPage \u001D;
	}
}

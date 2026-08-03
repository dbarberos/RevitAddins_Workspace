using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.UI;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Container;
using DiRoots.Tracker.Models;

namespace ProSheets.Commons.Helpers
{
	// Token: 0x0200013B RID: 315
	public static class IocHelper
	{
		// Token: 0x1700055C RID: 1372
		// (get) Token: 0x06000FAA RID: 4010 RVA: 0x0005899C File Offset: 0x00056B9C
		// (set) Token: 0x06000FAB RID: 4011 RVA: 0x000589B0 File Offset: 0x00056BB0
		public static IoC Instance { get; set; } = \u000A\u001F\u0016.\u0018();

		// Token: 0x06000FAC RID: 4012 RVA: 0x000589C4 File Offset: 0x00056BC4
		public static void Register(string pluginName, UIControlledApplication application)
		{
			ActiveDocumentHandler implementation = \u001D\u001C\u000F.\u0018(application);
			\u0004\u0005\u0018.\u0018().RegisterSingleton<ActiveDocumentHandler>(implementation);
			TrackerConfig implementation2 = \u0002\u001C\u000F.\u0018(pluginName, \u0004\u001C\u000F.\u0018(\u001E\u0011\u0014.\u0018(application)));
			\u0004\u0005\u0018.\u0018().RegisterSingleton<TrackerConfig>(implementation2);
		}

		// Token: 0x040006FD RID: 1789
		[CompilerGenerated]
		private static IoC \u000C;
	}
}

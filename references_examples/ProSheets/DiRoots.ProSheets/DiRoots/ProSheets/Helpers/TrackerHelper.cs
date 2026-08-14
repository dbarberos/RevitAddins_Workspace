using System;
using A;
using DiRoots.Tracker.Models;

namespace DiRoots.ProSheets.Helpers
{
	// Token: 0x02000053 RID: 83
	public static class TrackerHelper
	{
		// Token: 0x0600042C RID: 1068 RVA: 0x000165EC File Offset: 0x000147EC
		public static TrackerConfig Init(string parentPlugin, string revitVersion)
		{
			TrackerConfig trackerConfig = \u0016\u001F\u0014.\u0018();
			\u0003\u001F\u0014.\u0018(trackerConfig, "Revit");
			\u000E\u0020\u0014.\u0018(trackerConfig, \u0001\u0017\u0018.\u0018(\u000C\u001F\u0014.\u0018(\u0018\u001F\u0014.\u0018(\u0014\u001F\u0014.\u0018(\u000A\u001D\u0018.\u0018(\u001F\u001A\u000F.\u000C()))))));
			\u0005\u0020\u0014.\u0018(trackerConfig, parentPlugin);
			\u001B\u0020\u0014.\u0018(trackerConfig, revitVersion);
			return trackerConfig;
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0001664C File Offset: 0x0001484C
		public static void Track(string pluginName)
		{
			\u000F\u001F\u0014.\u0018(\u0012\u001F\u0014.\u0018(\u0004\u0005\u0018.\u0018().GetService<TrackerConfig>(false)), pluginName);
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00016678 File Offset: 0x00014878
		public static void Track(string pluginName, Exception ex, bool showErrorWindow = true)
		{
			\u001C\u001F\u0014.\u0018(\u0012\u001F\u0014.\u0018(\u0004\u0005\u0018.\u0018().GetService<TrackerConfig>(false)), pluginName, ex);
			if (showErrorWindow)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TrackerHelper.Track(string, Exception, bool)).MethodHandle;
				}
				\u000D\u001F\u0014.\u0018(ex, pluginName);
			}
		}
	}
}

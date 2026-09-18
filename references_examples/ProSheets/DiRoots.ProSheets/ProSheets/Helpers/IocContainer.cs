using System;
using A;
using DiRoots.One.Commons.Container;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Logs;

namespace ProSheets.Helpers
{
	// Token: 0x020000D8 RID: 216
	public static class IocContainer
	{
		// Token: 0x06000B54 RID: 2900 RVA: 0x00045908 File Offset: 0x00043B08
		public static void Register(string pluginName)
		{
			Logger implementation = \u0006\u001E\u0014.\u0018("DiRoots", pluginName);
			IocContainer.\u000C.RegisterSingleton<ICustomLogger, Logger>(implementation);
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x00045934 File Offset: 0x00043B34
		public static T GetService<T>()
		{
			return IocContainer.\u000C.GetService<T>(false);
		}

		// Token: 0x0400054D RID: 1357
		private static readonly IoC \u000C = \u000A\u001F\u0016.\u0018();
	}
}

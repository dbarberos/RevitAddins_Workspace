using System;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Commons.CustomNameManageWindow.Models;
using ProSheets.Helpers;

namespace A
{
	// Token: 0x020000C7 RID: 199
	internal static class \u0008\u0020\u0018
	{
		// Token: 0x06000B10 RID: 2832 RVA: 0x000416B8 File Offset: 0x0003F8B8
		public static string \u000C(Parameters \u000C, string \u0018, bool \u0014)
		{
			string text = string.Empty;
			if (\u0014)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0020\u0018.\u000C(Parameters, string, bool)).MethodHandle;
				}
				text = \u0018;
			}
			else if (\u000C != null)
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
				try
				{
					text = \u000C\u000A\u0018.\u000B(\u0013\u0019\u0014.\u0018(\u000C), null, \u000D\u0010\u000F.\u000C);
				}
				catch (Exception u)
				{
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\CustomParameterHelper.cs", "GetCombineFileName");
				}
			}
			if (\u001F\u001A\u0018.\u0018(text))
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
				text = \u0007\u0015\u0018.\u0003.\u000C();
			}
			return text;
		}
	}
}

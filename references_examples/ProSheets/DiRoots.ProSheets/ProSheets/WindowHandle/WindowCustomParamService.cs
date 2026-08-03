using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using A;

namespace ProSheets.WindowHandle
{
	// Token: 0x020000C4 RID: 196
	public class WindowCustomParamService
	{
		// Token: 0x06000AF9 RID: 2809 RVA: 0x000413BC File Offset: 0x0003F5BC
		private WindowCustomParamService()
		{
		}

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x06000AFA RID: 2810 RVA: 0x000413D0 File Offset: 0x0003F5D0
		public static WindowCustomParamService Instance
		{
			get
			{
				WindowCustomParamService result;
				if ((result = WindowCustomParamService.\u000C) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(WindowCustomParamService.get_Instance()).MethodHandle;
					}
					result = (WindowCustomParamService.\u000C = \u000D\u001C\u0016.\u0018());
				}
				return result;
			}
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x00041408 File Offset: 0x0003F608
		[Obsolete("Use the Instance Property instead")]
		public static WindowCustomParamService GetInstance()
		{
			return \u0001\u0018\u0003.\u0018();
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0004141C File Offset: 0x0003F61C
		public void SaveCustomParams(List<string> customParams)
		{
			try
			{
				this.\u0018(customParams);
			}
			catch
			{
			}
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x00041448 File Offset: 0x0003F648
		public List<string> GetCustomParams()
		{
			List<string> result = \u0011\u0002\u0018.\u0018();
			try
			{
				result = Enumerable.ToList<string>(Enumerable.Cast<string>(\u001C\u001C\u0016.\u0018(\u0013\u001C\u0016.\u0018())));
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x00041490 File Offset: 0x0003F690
		private void \u0018(List<string> \u000C)
		{
			StringCollection stringCollection = \u0015\u001C\u0016.\u0018();
			\u001F\u001C\u0016.\u0018(stringCollection, \u0011\u001C\u0016.\u0018(\u000C));
			\u0020\u001C\u0016.\u0018(\u0013\u001C\u0016.\u0018(), stringCollection);
			\u000A\u001C\u0016.\u0018(\u0013\u001C\u0016.\u0018());
			\u0009\u001C\u0016.\u0018(\u0013\u001C\u0016.\u0018());
		}

		// Token: 0x04000534 RID: 1332
		private static WindowCustomParamService \u000C;
	}
}

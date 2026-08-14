using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace A
{
	// Token: 0x02000057 RID: 87
	internal static class \u001F\u0009\u0018
	{
		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x000168AC File Offset: 0x00014AAC
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x000168C0 File Offset: 0x00014AC0
		public static UIApplication Application { get; set; }

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x000168D4 File Offset: 0x00014AD4
		public static UIDocument \u0018
		{
			get
			{
				return \u001F\u001F\u0014.\u0018(\u0011\u001F\u0014.\u0018());
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000436 RID: 1078 RVA: 0x000168F0 File Offset: 0x00014AF0
		public static Document \u0014
		{
			get
			{
				return \u0017\u0005\u0018.\u0014(\u001F\u0009\u0018.\u0018);
			}
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0001690C File Offset: 0x00014B0C
		public static void \u0003(UIControlledApplication \u000C)
		{
			FieldInfo fieldInfo = \u001E\u001F\u0014.\u0018(\u0004\u0017\u0018.\u0014(\u000C), "m_uiapplication", BindingFlags.Instance | BindingFlags.NonPublic);
			object u000C;
			if (fieldInfo == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0009\u0018.\u0003(UIControlledApplication)).MethodHandle;
				}
				u000C = null;
			}
			else
			{
				u000C = \u0017\u001F\u0014.\u0018(fieldInfo, \u000C);
			}
			\u0015\u001F\u0014.\u0018(\u0011\u001A\u000F.\u000C(u000C));
		}

		// Token: 0x0400016B RID: 363
		[CompilerGenerated]
		private static UIApplication \u000C;
	}
}

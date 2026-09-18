using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Logs;

namespace A
{
	// Token: 0x02000124 RID: 292
	internal static class \u0007\u0015\u0018
	{
		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x06000F05 RID: 3845 RVA: 0x000555C8 File Offset: 0x000537C8
		// (set) Token: 0x06000F06 RID: 3846 RVA: 0x000555DC File Offset: 0x000537DC
		public static UIApplication CurrentUIApplication { get; set; }

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06000F07 RID: 3847 RVA: 0x000555F0 File Offset: 0x000537F0
		public static Document \u0003
		{
			get
			{
				UIApplication uiapplication = \u0012\u0001\u0003.\u0018();
				if (uiapplication == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0007\u0015\u0018.get_\u0003()).MethodHandle;
					}
					return null;
				}
				return \u0017\u0005\u0018.\u0014(\u001F\u001F\u0014.\u0018(uiapplication));
			}
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06000F08 RID: 3848 RVA: 0x0005562C File Offset: 0x0005382C
		public static UIDocument \u0016
		{
			get
			{
				return \u001F\u001F\u0014.\u0018(\u0012\u0001\u0003.\u0018());
			}
		}

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x06000F09 RID: 3849 RVA: 0x00055648 File Offset: 0x00053848
		// (set) Token: 0x06000F0A RID: 3850 RVA: 0x0005565C File Offset: 0x0005385C
		public static List<Document> LinkDocuments { get; set; } = \u000F\u001A\u0016.\u0018();

		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x06000F0B RID: 3851 RVA: 0x00055670 File Offset: 0x00053870
		// (set) Token: 0x06000F0C RID: 3852 RVA: 0x00055684 File Offset: 0x00053884
		public static Logger LoggerInstance { get; set; } = \u0006\u001E\u0014.\u0018("DiRoots", "DocRegister");

		// Token: 0x040006C3 RID: 1731
		[CompilerGenerated]
		private static UIApplication \u000C;

		// Token: 0x040006C4 RID: 1732
		[CompilerGenerated]
		private static List<Document> \u0018;

		// Token: 0x040006C5 RID: 1733
		[CompilerGenerated]
		private static Logger \u0014;
	}
}

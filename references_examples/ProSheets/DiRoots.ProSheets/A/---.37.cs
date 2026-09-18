using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Helpers;

namespace A
{
	// Token: 0x020000E6 RID: 230
	internal static class \u0003\u0011\u0018
	{
		// Token: 0x06000BA5 RID: 2981 RVA: 0x0004730C File Offset: 0x0004550C
		public static void \u000C(PrintManager \u000C, ColorDepthType \u0018)
		{
			\u0003\u0011\u0018.\u0014\u0011\u0018 u0014_u0011_u = new \u0003\u0011\u0018.\u0014\u0011\u0018();
			u0014_u0011_u.\u000C = \u0018;
			try
			{
				List<ColorDepthType> list = \u001F\u0015\u0016.\u0018();
				\u0020\u0015\u0016.\u0018(list, 0);
				\u0020\u0015\u0016.\u0018(list, 1);
				\u0020\u0015\u0016.\u0018(list, 2);
				List<ColorDepthType> list2 = list;
				u0014_u0011_u.\u0018 = \u000A\u0015\u0016.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u000C))));
				\u0005\u0010\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u000C))), Enumerable.First<ColorDepthType>(list2, new Func<ColorDepthType, bool>(u0014_u0011_u.\u0014)));
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\PdfExporterUtility.cs", "ModifyPrintSetup");
			}
		}

		// Token: 0x020001E0 RID: 480
		[CompilerGenerated]
		private sealed class \u0014\u0011\u0018
		{
			// Token: 0x0600122B RID: 4651 RVA: 0x0005E60C File Offset: 0x0005C80C
			internal bool \u0014(ColorDepthType \u000C)
			{
				if (\u000C != this.\u0018)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0011\u0018.\u0014\u0011\u0018.\u0014(ColorDepthType)).MethodHandle;
					}
					return \u000C != this.\u000C;
				}
				return false;
			}

			// Token: 0x040008AC RID: 2220
			public ColorDepthType \u000C;

			// Token: 0x040008AD RID: 2221
			public ColorDepthType \u0018;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000052 RID: 82
	internal static class \u000D\u0007
	{
		// Token: 0x060002BE RID: 702 RVA: 0x000120C0 File Offset: 0x000102C0
		internal static void \u001F(this ViewSection \u001F, Document \u000A, double \u0007)
		{
			ViewCropRegionShapeManager u001F = \u0013\u0018\u0007.\u000A(\u001F);
			IEnumerable<CurveLoop> enumerable = \u000B\u0005\u0007.\u000A(u001F);
			Func<CurveLoop, IEnumerable<Curve>> func;
			if ((func = \u000D\u0007.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSection.\u001F(Document, double)).MethodHandle;
				}
				func = (\u000D\u0007.<>c.\u000A = new Func<CurveLoop, IEnumerable<Curve>>(\u000D\u0007.<>c.\u001F.\u001D));
			}
			\u0011\u000A u0011_u000A = new \u0011\u000A(Enumerable.Cast<Line>(Enumerable.ToList<Curve>(Enumerable.SelectMany<CurveLoop, Curve>(enumerable, func)))).\u0018(\u0007, \u0007, \u0007, \u0007);
			List<Curve> u001F2 = \u0013\u001D\u0007.\u000A();
			\u0014\u001D\u0007.\u000A(u001F2, \u0008\u0007\u0007.\u000A(u0011_u000A.\u0006, 0));
			\u0014\u001D\u0007.\u000A(u001F2, \u0008\u0007\u0007.\u000A(u0011_u000A.\u0006, 1));
			\u0014\u001D\u0007.\u000A(u001F2, \u0008\u0007\u0007.\u000A(u0011_u000A.\u0006, 2));
			\u0014\u001D\u0007.\u000A(u001F2, \u0008\u0007\u0007.\u000A(u0011_u000A.\u0006, 3));
			CurveLoop u000A = \u0017\u0018\u0007.\u000A(u001F2);
			\u0020\u0018\u0007.\u000A(u001F, u000A);
			\u001E\u0018\u0007.\u000A(\u000A);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x000121A8 File Offset: 0x000103A8
		internal static void \u001F(this ViewSection \u001F, Document \u000A, double \u0007, double \u001D, double \u0004, double \u0019)
		{
			ViewCropRegionShapeManager u001F = \u0013\u0018\u0007.\u000A(\u001F);
			IEnumerable<CurveLoop> enumerable = \u000B\u0005\u0007.\u000A(u001F);
			Func<CurveLoop, IEnumerable<Curve>> func;
			if ((func = \u000D\u0007.<>c.\u0007) == null)
			{
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSection.\u001F(Document, double, double, double, double)).MethodHandle;
				}
				func = (\u000D\u0007.<>c.\u0007 = new Func<CurveLoop, IEnumerable<Curve>>(\u000D\u0007.<>c.\u001F.\u0004));
			}
			\u0011\u000A u0011_u000A = new \u0011\u000A(Enumerable.Cast<Line>(Enumerable.ToList<Curve>(Enumerable.SelectMany<CurveLoop, Curve>(enumerable, func)))).\u0018(\u0019, \u0007, \u001D, \u0004);
			List<Curve> u001F2 = \u0013\u001D\u0007.\u000A();
			\u0014\u001D\u0007.\u000A(u001F2, \u0008\u0007\u0007.\u000A(u0011_u000A.\u0006, 0));
			\u0014\u001D\u0007.\u000A(u001F2, \u0008\u0007\u0007.\u000A(u0011_u000A.\u0006, 1));
			\u0014\u001D\u0007.\u000A(u001F2, \u0008\u0007\u0007.\u000A(u0011_u000A.\u0006, 2));
			\u0014\u001D\u0007.\u000A(u001F2, \u0008\u0007\u0007.\u000A(u0011_u000A.\u0006, 3));
			CurveLoop u000A = \u0017\u0018\u0007.\u000A(u001F2);
			\u0020\u0018\u0007.\u000A(u001F, u000A);
			\u001E\u0018\u0007.\u000A(\u000A);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00012294 File Offset: 0x00010494
		internal static void \u000A(this ViewSection \u001F, Document \u000A, int \u0007)
		{
			\u000D\u0007.\u0003\u0007 u0003_u = new \u000D\u0007.\u0003\u0007();
			u0003_u.\u001F = \u000A;
			u0003_u.\u000A = \u001F;
			OverrideGraphicSettings overrideGraphicSettings = \u000F\u0005\u0007.\u000A();
			\u0006\u0005\u0007.\u000A(overrideGraphicSettings, \u0007);
			ElementId u000A = Enumerable.FirstOrDefault<ElementId>(\u0012\u0018\u0007.\u000A(u0003_u.\u000A, \u0003\u0018\u0007.\u000A(-2000278L)), new Func<ElementId, bool>(u0003_u.\u0007));
			\u0002\u0005\u0007.\u000A(u0003_u.\u000A, u000A, overrideGraphicSettings);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00012304 File Offset: 0x00010504
		internal static void \u0007(this ViewSection \u001F, Document \u000A, OverrideGraphicSettings \u0007)
		{
			\u000D\u0007.\u001C\u0007 u001C_u = new \u000D\u0007.\u001C\u0007();
			u001C_u.\u001F = \u000A;
			u001C_u.\u000A = \u001F;
			ElementId u000A = Enumerable.FirstOrDefault<ElementId>(\u0012\u0018\u0007.\u000A(u001C_u.\u000A, \u0003\u0018\u0007.\u000A(-2000278L)), new Func<ElementId, bool>(u001C_u.\u0007));
			\u0002\u0005\u0007.\u000A(u001C_u.\u000A, u000A, \u0007);
		}

		// Token: 0x0200078C RID: 1932
		[CompilerGenerated]
		private sealed class \u0003\u0007
		{
			// Token: 0x06004B66 RID: 19302 RVA: 0x001D9F30 File Offset: 0x001D8130
			internal bool \u0007(ElementId \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u0011\u0017\u000A.\u0007(this.\u001F, \u001F)), \u0005\u001E\u000A.\u000A(this.\u000A));
			}

			// Token: 0x04001EB3 RID: 7859
			public Document \u001F;

			// Token: 0x04001EB4 RID: 7860
			public ViewSection \u000A;
		}

		// Token: 0x0200078D RID: 1933
		[CompilerGenerated]
		private sealed class \u001C\u0007
		{
			// Token: 0x06004B68 RID: 19304 RVA: 0x001D9F7C File Offset: 0x001D817C
			internal bool \u0007(ElementId \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u0011\u0017\u000A.\u0007(this.\u001F, \u001F)), \u0005\u001E\u000A.\u000A(this.\u000A));
			}

			// Token: 0x04001EB5 RID: 7861
			public Document \u001F;

			// Token: 0x04001EB6 RID: 7862
			public ViewSection \u000A;
		}
	}
}

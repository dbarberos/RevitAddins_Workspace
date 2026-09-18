using System;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x0200001C RID: 28
	internal static class \u000C
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x00004B30 File Offset: 0x00002D30
		internal static \u001F \u001F<\u001F>(this Document \u001F, string \u000A) where \u001F : Element
		{
			BuiltInParameter u000A = -1008000L;
			return \u001F.\u000A(u000A, \u000A, true);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00004B50 File Offset: 0x00002D50
		internal static \u001F \u000A<\u001F>(this Document \u001F, BuiltInParameter \u000A, string \u0007, bool \u001D = true) where \u001F : Element
		{
			return \u001B\u0011\u000A.\u000A(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u001E\u0011\u000A.\u000A(typeof(\u001F).TypeHandle)).\u0007(\u000A, \u0007, \u001D)) as \u001F;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00004B94 File Offset: 0x00002D94
		internal static \u001F \u000A<\u001F>(this Document \u001F, BuiltInCategory \u000A, BuiltInParameter \u0007, string \u001D, bool \u0004 = true) where \u001F : Element
		{
			return \u001B\u0011\u000A.\u000A(\u0011\u0011\u000A.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u000A), \u001E\u0011\u000A.\u000A(typeof(\u001F).TypeHandle)).\u0007(\u0007, \u001D, \u0004)) as \u001F;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004BE0 File Offset: 0x00002DE0
		internal static FilteredElementCollector \u0007(this FilteredElementCollector \u001F, BuiltInParameter \u000A, string \u0007, bool \u001D = true)
		{
			ElementParameterFilter u000A = \u0013\u0011\u000A.\u000A(\u001A\u0011\u000A.\u000A(\u0015\u0011\u000A.\u000A(\u0001\u0011\u000A.\u000A(\u000A)), \u000C\u0011\u000A.\u000A(), \u0007));
			return \u0014\u0011\u000A.\u0007(\u001F, u000A);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00004C1C File Offset: 0x00002E1C
		internal static FilteredElementCollector \u0007(this FilteredElementCollector \u001F, BuiltInParameter \u000A, int \u0007)
		{
			ElementParameterFilter u000A = \u0013\u0011\u000A.\u000A(\u0009\u0011\u000A.\u000A(\u0015\u0011\u000A.\u000A(\u0001\u0011\u000A.\u000A(\u000A)), \u001F\u001E\u000A.\u000A(), \u0007));
			return \u0014\u0011\u000A.\u0007(\u001F, u000A);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00004C58 File Offset: 0x00002E58
		internal static FilteredElementCollector \u0007(this FilteredElementCollector \u001F, BuiltInParameter \u000A, ElementId \u0007)
		{
			ElementParameterFilter u000A = \u0013\u0011\u000A.\u000A(\u000A\u001E\u000A.\u000A(\u0015\u0011\u000A.\u000A(\u0001\u0011\u000A.\u000A(\u000A)), \u001F\u001E\u000A.\u000A(), \u0007));
			return \u0014\u0011\u000A.\u0007(\u001F, u000A);
		}
	}
}

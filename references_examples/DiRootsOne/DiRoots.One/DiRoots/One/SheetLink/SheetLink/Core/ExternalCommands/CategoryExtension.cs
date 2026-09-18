using System;
using A;
using Autodesk.Revit.DB;

namespace DiRoots.One.SheetLink.SheetLink.Core.ExternalCommands
{
	// Token: 0x02000262 RID: 610
	public static class CategoryExtension
	{
		// Token: 0x060018B6 RID: 6326 RVA: 0x000A0A78 File Offset: 0x0009EC78
		public static BuiltInCategory ToBuiltInCategory(this Category cat)
		{
			return \u001C\u0013\u0005.\u000A(cat);
		}
	}
}

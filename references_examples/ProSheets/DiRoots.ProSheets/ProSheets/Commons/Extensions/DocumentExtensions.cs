using System;
using System.Collections.Generic;
using System.Linq;
using A;
using Autodesk.Revit.DB;

namespace ProSheets.Commons.Extensions
{
	// Token: 0x0200013C RID: 316
	public static class DocumentExtensions
	{
		// Token: 0x06000FAD RID: 4013 RVA: 0x00058A14 File Offset: 0x00056C14
		public static IEnumerable<T> GetElements<T>(this Document doc)
		{
			return Enumerable.Cast<T>(\u0010\u001D\u0014.\u0003(\u0020\u001D\u0018.\u0018(doc), \u000A\u001D\u0018.\u0018(typeof(T).TypeHandle)));
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x00058A44 File Offset: 0x00056C44
		public static IEnumerable<T> GetElements<T>(this Document doc, BuiltInCategory builtInCategory)
		{
			return Enumerable.Cast<T>(\u0013\u0015\u0016.\u0003(\u0006\u001D\u0014.\u0014(\u0020\u001D\u0018.\u0018(doc), builtInCategory)));
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x00058A70 File Offset: 0x00056C70
		public static IEnumerable<T> GetElements<T>(this Document doc, ElementId viewId, BuiltInCategory builtInCategory)
		{
			return Enumerable.Cast<T>(\u0013\u0015\u0016.\u0003(\u0006\u001D\u0014.\u0014(\u0009\u0015\u0016.\u0018(doc, viewId), builtInCategory)));
		}
	}
}

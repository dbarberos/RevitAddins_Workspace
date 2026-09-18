using System;
using System.Collections.Generic;
using System.Linq;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Revit.Extensions;

namespace DiRoots.One.TableGen.TGRevitHelper.StyleMapping
{
	// Token: 0x02000138 RID: 312
	public static class StyleMappingCollector
	{
		// Token: 0x06000BA9 RID: 2985 RVA: 0x0004A16C File Offset: 0x0004836C
		// Note: this type is marked as 'beforefieldinit'.
		static StyleMappingCollector()
		{
			HashSet<int> u001F = \u000C\u0010\u001D.\u000A();
			\u001A\u0010\u001D.\u000A(u001F, -2000831);
			\u001A\u0010\u001D.\u000A(u001F, -2000065);
			\u001A\u0010\u001D.\u000A(u001F, -2000077);
			\u001A\u0010\u001D.\u000A(u001F, -2009018);
			\u001A\u0010\u001D.\u000A(u001F, -2000079);
			\u001A\u0010\u001D.\u000A(u001F, -2001033);
			\u001A\u0010\u001D.\u000A(u001F, -2009019);
			\u001A\u0010\u001D.\u000A(u001F, -2000066);
			StyleMappingCollector.\u001F = u001F;
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x0004A1F8 File Offset: 0x000483F8
		public static List<Category> GetLineStylesCategories(Document doc)
		{
			IEnumerable<GraphicsStyle> elements = doc.GetElements<GraphicsStyle>();
			Func<GraphicsStyle, bool> func;
			if ((func = StyleMappingCollector.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingCollector.GetLineStylesCategories(Document)).MethodHandle;
				}
				func = (StyleMappingCollector.<>c.\u000A = new Func<GraphicsStyle, bool>(StyleMappingCollector.<>c.\u001F.\u001D));
			}
			IEnumerable<Category> enumerable = Enumerable.Cast<Category>(\u0008\u0001\u001D.\u000A(\u0016\u000C\u0004.\u000A(\u000B\u000C\u0004.\u000A(Enumerable.FirstOrDefault<GraphicsStyle>(elements, func)))));
			Func<Category, bool> func2;
			if ((func2 = StyleMappingCollector.<>c.\u0007) == null)
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
				func2 = (StyleMappingCollector.<>c.\u0007 = new Func<Category, bool>(StyleMappingCollector.<>c.\u001F.\u0004));
			}
			return Enumerable.ToList<Category>(Enumerable.Where<Category>(enumerable, func2));
		}

		// Token: 0x040004A4 RID: 1188
		private static readonly HashSet<int> \u001F;
	}
}

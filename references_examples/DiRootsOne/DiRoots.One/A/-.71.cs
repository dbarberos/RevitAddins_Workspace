using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExternalService;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000258 RID: 600
	internal static class \u0017\u000D
	{
		// Token: 0x0600185E RID: 6238 RVA: 0x0009C9D8 File Offset: 0x0009ABD8
		internal static List<string> \u000A(Document \u001F)
		{
			IEnumerable<Workset> enumerable = \u0015\u0020\u0005.\u000A(\u0001\u0020\u0005.\u0007(\u0009\u0020\u0005.\u000A(\u001F), 4));
			Func<Workset, string> func;
			if ((func = \u0017\u000D.<>c.\u000A) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u000A(Document)).MethodHandle;
				}
				func = (\u0017\u000D.<>c.\u000A = new Func<Workset, string>(\u0017\u000D.<>c.\u001F.\u001E));
			}
			return Enumerable.ToList<string>(Enumerable.Select<Workset, string>(enumerable, func));
		}

		// Token: 0x0600185F RID: 6239 RVA: 0x0009CA3C File Offset: 0x0009AC3C
		internal static List<string> \u0007(Document \u001F)
		{
			object u001F = \u0001\u001E\u000A.\u0007(\u0017\u0011\u000A.\u001D(\u0020\u0011\u000A.\u000A(\u001F), -2009014L));
			List<string> list = \u0014\u000D\u0007.\u000A();
			IEnumerator<Element> enumerator = \u001F\u0017\u0005.\u000A(u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Element u001F2 = \u0001\u000C\u0004.\u000A(enumerator);
					\u001A\u0008\u0007.\u000A(list, \u001E\u0020\u001D.\u000A(\u0005\u001E\u000A.\u000A(u001F2), " <", \u0017\u0013\u0007.\u001D(\u0016\u0018\u0007.\u0007(u001F2, -1013434L)), ">"));
				}
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0007(Document)).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
				{
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			\u0004\u000F\u0019.\u000A(list);
			return list;
		}

		// Token: 0x06001860 RID: 6240 RVA: 0x0009CB00 File Offset: 0x0009AD00
		internal static List<string> \u001D(Document \u001F, bool \u000A)
		{
			object u001F = \u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u001D(\u0020\u0011\u000A.\u000A(\u001F), -2000240L)));
			List<string> list = \u0014\u000D\u0007.\u000A();
			IEnumerator<Element> enumerator = \u001F\u0017\u0005.\u000A(u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Element u001F2 = \u0001\u000C\u0004.\u000A(enumerator);
					\u001A\u0008\u0007.\u000A(list, \u0005\u001E\u000A.\u000A(u001F2));
				}
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u001D(Document, bool)).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			\u0004\u000F\u0019.\u000A(list);
			if (\u000A)
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
				\u001A\u0008\u0007.\u000A(list, "None");
			}
			return list;
		}

		// Token: 0x06001861 RID: 6241 RVA: 0x0009CBBC File Offset: 0x0009ADBC
		internal static ElementId \u0004(Document \u001F, string \u000A)
		{
			\u0017\u000D.\u001B\u000D u001B_u000D = new \u0017\u000D.\u001B\u000D();
			u001B_u000D.\u001F = \u000A;
			GraphicsStyle graphicsStyle = Enumerable.FirstOrDefault<GraphicsStyle>(Enumerable.Cast<GraphicsStyle>(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u001E\u0011\u000A.\u000A(\u0016\u0012\u000E.\u001F()))), new Func<GraphicsStyle, bool>(u001B_u000D.\u000A));
			if (graphicsStyle != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0004(Document, string)).MethodHandle;
				}
				return \u0002\u001E\u000A.\u0007(graphicsStyle);
			}
			return Constants.InvalidElementId;
		}

		// Token: 0x06001862 RID: 6242 RVA: 0x0009CC34 File Offset: 0x0009AE34
		internal static List<string> \u0019(Document \u001F)
		{
			List<string> list = \u0014\u000D\u0007.\u000A();
			IEnumerator u001F = \u000E\u0001\u001D.\u000A(\u0008\u0001\u001D.\u000A(\u001B\u0001\u001D.\u000A(\u000D\u0001\u001D.\u000A(\u0010\u0001\u001D.\u000A(\u001F)), -2000051L)));
			try
			{
				while (\u000A\u0017\u000A.\u000A(u001F))
				{
					Category u001F2 = \u001E\u0004\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F));
					\u001A\u0008\u0007.\u000A(list, \u0009\u0014\u000A.\u001D(u001F2));
				}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0019(Document)).MethodHandle;
				}
			}
			finally
			{
				IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
				if (disposable != null)
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
					\u001F\u0017\u000A.\u000A(disposable);
				}
			}
			\u0004\u000F\u0019.\u000A(list);
			return list;
		}

		// Token: 0x06001863 RID: 6243 RVA: 0x0009CCE8 File Offset: 0x0009AEE8
		internal static ElementId \u0018(Document \u001F, string \u000A)
		{
			\u0017\u000D.\u0020\u000D u0020_u000D = new \u0017\u000D.\u0020\u000D();
			u0020_u000D.\u001F = \u000A;
			if (\u001D\u0017\u000A.\u000A(u0020_u000D.\u001F, "None"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0018(Document, string)).MethodHandle;
				}
				FillPatternElement fillPatternElement = Enumerable.FirstOrDefault<FillPatternElement>(Enumerable.Cast<FillPatternElement>(\u0001\u001E\u000A.\u0007(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u001E\u0011\u000A.\u000A(\u0006\u0012\u000E.\u001F())))), new Func<FillPatternElement, bool>(u0020_u000D.\u000A));
				if (fillPatternElement != null)
				{
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					return \u0002\u001E\u000A.\u0007(fillPatternElement);
				}
			}
			return Constants.InvalidElementId;
		}

		// Token: 0x06001864 RID: 6244 RVA: 0x0009CD84 File Offset: 0x0009AF84
		internal static List<string> \u0005(Document \u001F)
		{
			IEnumerable<FillPatternElement> enumerable = Enumerable.Cast<FillPatternElement>(\u0001\u001E\u000A.\u0007(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u001E\u0011\u000A.\u000A(\u0006\u0012\u000E.\u001F()))));
			Func<FillPatternElement, bool> func;
			if ((func = \u0017\u000D.<>c.\u0007) == null)
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0005(Document)).MethodHandle;
				}
				func = (\u0017\u000D.<>c.\u0007 = new Func<FillPatternElement, bool>(\u0017\u000D.<>c.\u001F.\u0020));
			}
			IEnumerable<FillPatternElement> enumerable2 = Enumerable.Where<FillPatternElement>(enumerable, func);
			Func<FillPatternElement, string> func2;
			if ((func2 = \u0017\u000D.<>c.\u001D) == null)
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
				func2 = (\u0017\u000D.<>c.\u001D = new Func<FillPatternElement, string>(\u0017\u000D.<>c.\u001F.\u0017));
			}
			List<string> list = Enumerable.ToList<string>(Enumerable.Select<FillPatternElement, string>(enumerable2, func2));
			\u0004\u000F\u0019.\u000A(list);
			return list;
		}

		// Token: 0x06001865 RID: 6245 RVA: 0x0009CE34 File Offset: 0x0009B034
		internal static List<string> \u0016(Document \u001F, bool \u000A, BuiltInCategory \u0007)
		{
			FilteredElementCollector u001F = \u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u0007);
			IList<Element> u001F2;
			if (\u000A)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0016(Document, bool, BuiltInCategory)).MethodHandle;
				}
				u001F2 = \u0001\u001E\u000A.\u0007(\u0020\u0008\u0018.\u001D(u001F));
			}
			else
			{
				u001F2 = \u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(u001F));
			}
			List<string> list = \u0014\u000D\u0007.\u000A();
			IEnumerator<Element> enumerator = \u001F\u0017\u0005.\u000A(u001F2);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Element u001F3 = \u0001\u000C\u0004.\u000A(enumerator);
					\u001A\u0008\u0007.\u000A(list, \u0005\u001E\u000A.\u000A(u001F3));
				}
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			\u0004\u000F\u0019.\u000A(list);
			return list;
		}

		// Token: 0x06001866 RID: 6246 RVA: 0x0009CEF8 File Offset: 0x0009B0F8
		internal static List<string> \u000B()
		{
			IEnumerable<\u0013\u000D> enumerable = \u0017\u000D.\u0008(\u000A\u0017\u0005.\u000A(), false);
			Func<\u0013\u000D, string> func;
			if ((func = \u0017\u000D.<>c.\u0004) == null)
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u000B()).MethodHandle;
				}
				func = (\u0017\u000D.<>c.\u0004 = new Func<\u0013\u000D, string>(\u0017\u000D.<>c.\u001F.\u0014));
			}
			return Enumerable.ToList<string>(Enumerable.Select<\u0013\u000D, string>(enumerable, func));
		}

		// Token: 0x06001867 RID: 6247 RVA: 0x0009CF54 File Offset: 0x0009B154
		internal static List<string> \u0002(Document \u001F)
		{
			List<string> list = \u0014\u000D\u0007.\u000A();
			IEnumerator<Element> enumerator = \u0009\u000C\u0004.\u000A(\u0020\u0008\u0018.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), -2008015L)));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Element u001F = \u0001\u000C\u0004.\u000A(enumerator);
					\u001A\u0008\u0007.\u000A(list, \u0005\u001E\u000A.\u000A(u001F));
				}
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0002(Document)).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
				{
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return list;
		}

		// Token: 0x06001868 RID: 6248 RVA: 0x0009CFEC File Offset: 0x0009B1EC
		internal static ElementId \u0006(Document \u001F, string \u000A)
		{
			\u0017\u000D.\u0005\u000D u0005_u000D = new \u0017\u000D.\u0005\u000D();
			u0005_u000D.\u001F = \u000A;
			Element element = Enumerable.FirstOrDefault<Element>(\u0001\u001E\u000A.\u0007(\u0020\u0008\u0018.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), -2008015L))), new Func<Element, bool>(u0005_u000D.\u000A));
			if (element != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0006(Document, string)).MethodHandle;
				}
				return \u0002\u001E\u000A.\u0007(element);
			}
			return Constants.InvalidElementId;
		}

		// Token: 0x06001869 RID: 6249 RVA: 0x0009D064 File Offset: 0x0009B264
		internal static List<string> \u000F(Document \u001F)
		{
			List<string> list = \u0014\u000D\u0007.\u000A();
			List<PipingSystemType>.Enumerator enumerator = \u0004\u0017\u0005.\u000A(Enumerable.ToList<PipingSystemType>(Enumerable.OfType<PipingSystemType>(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u001E\u0011\u000A.\u000A(\u0002\u0012\u000E.\u001F())))));
			try
			{
				while (\u0007\u0017\u0005.\u000A(ref enumerator))
				{
					PipingSystemType u001F = \u001D\u0017\u0005.\u000A(ref enumerator);
					\u001A\u0008\u0007.\u000A(list, \u0005\u001E\u000A.\u000A(u001F));
				}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u000F(Document)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x0600186A RID: 6250 RVA: 0x0009D108 File Offset: 0x0009B308
		internal static ElementId \u0012(Document \u001F, string \u000A)
		{
			\u0017\u000D.\u0016\u000D u0016_u000D = new \u0017\u000D.\u0016\u000D();
			u0016_u000D.\u001F = \u000A;
			Element element = Enumerable.FirstOrDefault<PipingSystemType>(Enumerable.ToList<PipingSystemType>(Enumerable.OfType<PipingSystemType>(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u001E\u0011\u000A.\u000A(\u0002\u0012\u000E.\u001F())))), new Func<PipingSystemType, bool>(u0016_u000D.\u000A));
			if (element != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0012(Document, string)).MethodHandle;
				}
				return \u0002\u001E\u000A.\u0007(element);
			}
			return Constants.InvalidElementId;
		}

		// Token: 0x0600186B RID: 6251 RVA: 0x0009D188 File Offset: 0x0009B388
		internal static string \u0003(string \u001F)
		{
			\u0017\u000D.\u000B\u000D u000B_u000D = new \u0017\u000D.\u000B\u000D();
			u000B_u000D.\u001F = \u001F;
			\u0013\u000D u0013_u000D = Enumerable.FirstOrDefault<\u0013\u000D>(\u0017\u000D.\u0008(\u000A\u0017\u0005.\u000A(), false), new Func<\u0013\u000D, bool>(u000B_u000D.\u000A));
			if (u0013_u000D != null)
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0003(string)).MethodHandle;
				}
				return u0013_u000D.\u000A;
			}
			return string.Empty;
		}

		// Token: 0x0600186C RID: 6252 RVA: 0x0009D1E8 File Offset: 0x0009B3E8
		internal static string \u001C(string \u001F)
		{
			\u0017\u000D.\u0002\u000D u0002_u000D = new \u0017\u000D.\u0002\u000D();
			u0002_u000D.\u001F = \u001F;
			\u0013\u000D u0013_u000D = Enumerable.FirstOrDefault<\u0013\u000D>(\u0017\u000D.\u0008(\u000A\u0017\u0005.\u000A(), false), new Func<\u0013\u000D, bool>(u0002_u000D.\u000A));
			if (u0013_u000D != null)
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u001C(string)).MethodHandle;
				}
				return u0013_u000D.\u001F;
			}
			return string.Empty;
		}

		// Token: 0x0600186D RID: 6253 RVA: 0x0009D248 File Offset: 0x0009B448
		internal static List<string> \u000D()
		{
			IEnumerable<\u0013\u000D> enumerable = \u0017\u000D.\u0008(\u0019\u0017\u0005.\u000A(), true);
			Func<\u0013\u000D, string> func;
			if ((func = \u0017\u000D.<>c.\u0019) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u000D()).MethodHandle;
				}
				func = (\u0017\u000D.<>c.\u0019 = new Func<\u0013\u000D, string>(\u0017\u000D.<>c.\u001F.\u0013));
			}
			return Enumerable.ToList<string>(Enumerable.Select<\u0013\u000D, string>(enumerable, func));
		}

		// Token: 0x0600186E RID: 6254 RVA: 0x0009D2A4 File Offset: 0x0009B4A4
		internal static string \u0010(string \u001F)
		{
			\u0017\u000D.\u0006\u000D u0006_u000D = new \u0017\u000D.\u0006\u000D();
			u0006_u000D.\u001F = \u001F;
			\u0013\u000D u0013_u000D = Enumerable.FirstOrDefault<\u0013\u000D>(\u0017\u000D.\u0008(\u0019\u0017\u0005.\u000A(), true), new Func<\u0013\u000D, bool>(u0006_u000D.\u000A));
			if (u0013_u000D != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0010(string)).MethodHandle;
				}
				return u0013_u000D.\u000A;
			}
			return string.Empty;
		}

		// Token: 0x0600186F RID: 6255 RVA: 0x0009D304 File Offset: 0x0009B504
		internal static string \u000E(string \u001F)
		{
			\u0017\u000D.\u000F\u000D u000F_u000D = new \u0017\u000D.\u000F\u000D();
			u000F_u000D.\u001F = \u001F;
			\u0013\u000D u0013_u000D = Enumerable.FirstOrDefault<\u0013\u000D>(\u0017\u000D.\u0008(\u0019\u0017\u0005.\u000A(), true), new Func<\u0013\u000D, bool>(u000F_u000D.\u000A));
			if (u0013_u000D != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u000E(string)).MethodHandle;
				}
				return u0013_u000D.\u001F;
			}
			return string.Empty;
		}

		// Token: 0x06001870 RID: 6256 RVA: 0x0009D364 File Offset: 0x0009B564
		private static List<\u0013\u000D> \u0008(ExternalServiceId \u001F, bool \u000A)
		{
			object u001F = \u000F\u0017\u0005.\u000A(\u000B\u0012\u000E.\u001F(\u0012\u0017\u0005.\u000A(\u001F)));
			List<\u0013\u000D> list = \u0006\u0017\u0005.\u000A();
			IEnumerator<Guid> enumerator = \u0002\u0017\u0005.\u000A(u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Guid u001F2 = \u000B\u0017\u0005.\u000A(enumerator);
					IExternalServer u001F3 = \u0017\u000D.\u001B(u001F2, \u001F);
					\u0018\u0017\u0005.\u000A(list, new \u0013\u000D
					{
						\u001F = u001F2.ToString(),
						\u000A = \u0016\u0017\u0005.\u000A(u001F3)
					});
				}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0008(ExternalServiceId, bool)).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			if (\u000A)
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
				\u0018\u0017\u0005.\u000A(list, new \u0013\u000D
				{
					\u001F = \u0005\u0017\u0005.\u000A().ToString(),
					\u000A = "Use Definition on Type"
				});
			}
			IEnumerable<\u0013\u000D> enumerable = list;
			Func<\u0013\u000D, string> func;
			if ((func = \u0017\u000D.<>c.\u0018) == null)
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
				func = (\u0017\u000D.<>c.\u0018 = new Func<\u0013\u000D, string>(\u0017\u000D.<>c.\u001F.\u001A));
			}
			list = Enumerable.ToList<\u0013\u000D>(Enumerable.OrderBy<\u0013\u000D, string>(enumerable, func));
			return list;
		}

		// Token: 0x06001871 RID: 6257 RVA: 0x0009D4A4 File Offset: 0x0009B6A4
		private static IExternalServer \u001B(Guid \u001F, ExternalServiceId \u000A)
		{
			MultiServerService multiServerService = \u000B\u0012\u000E.\u001F(\u0012\u0017\u0005.\u000A(\u000A));
			if (multiServerService != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u001B(Guid, ExternalServiceId)).MethodHandle;
				}
				IExternalServer externalServer = \u0003\u0017\u0005.\u000A(multiServerService, \u001F);
				if (externalServer != null)
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
					return externalServer;
				}
			}
			return null;
		}

		// Token: 0x06001872 RID: 6258 RVA: 0x0009D4F4 File Offset: 0x0009B6F4
		internal static int \u0011(Document \u001F, string \u000A)
		{
			\u0017\u000D.\u0012\u000D u0012_u000D = new \u0017\u000D.\u0012\u000D();
			u0012_u000D.\u001F = \u000A;
			FilteredWorksetCollector u001F = \u0009\u0020\u0005.\u000A(\u001F);
			\u0001\u0020\u0005.\u001D(u001F, 4);
			IList<Workset> list = \u0015\u0020\u0005.\u000A(u001F);
			int result;
			try
			{
				IEnumerable<Workset> enumerable = Enumerable.Where<Workset>(list, new Func<Workset, bool>(u0012_u000D.\u000A));
				Func<Workset, int> func;
				if ((func = \u0017\u000D.<>c.\u0005) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0011(Document, string)).MethodHandle;
					}
					func = (\u0017\u000D.<>c.\u0005 = new Func<Workset, int>(\u0017\u000D.<>c.\u001F.\u000C));
				}
				result = Enumerable.FirstOrDefault<int>(Enumerable.Select<Workset, int>(enumerable, func));
			}
			catch (Exception)
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06001873 RID: 6259 RVA: 0x0009D598 File Offset: 0x0009B798
		internal static ElementId \u001E(Document \u001F, string \u000A)
		{
			\u0017\u000D.\u0003\u000D u0003_u000D = new \u0017\u000D.\u0003\u000D();
			u0003_u000D.\u001F = \u000A;
			IList<Element> list = \u0001\u001E\u000A.\u0007(\u0017\u0011\u000A.\u001D(\u0020\u0011\u000A.\u000A(\u001F), -2009014L));
			ElementId elementId = Constants.InvalidElementId;
			try
			{
				int num = \u001C\u0017\u0005.\u000A(u0003_u000D.\u001F, '<');
				if (num > 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u001E(Document, string)).MethodHandle;
					}
					u0003_u000D.\u001F = \u0003\u000B\u001D.\u0007(\u000A\u000B\u001D.\u000A(u0003_u000D.\u001F, 0, num - 1));
				}
				if (\u0018\u001E\u0019.\u000A(list) > 0)
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
					IEnumerable<Element> enumerable = Enumerable.Where<Element>(list, new Func<Element, bool>(u0003_u000D.\u000A));
					Func<Element, ElementId> func;
					if ((func = \u0017\u000D.<>c.\u0016) == null)
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
						func = (\u0017\u000D.<>c.\u0016 = new Func<Element, ElementId>(\u0017\u000D.<>c.\u001F.\u0015));
					}
					elementId = Enumerable.FirstOrDefault<ElementId>(Enumerable.Select<Element, ElementId>(enumerable, func));
				}
				if (\u0011\u0016\u001D.\u000A(elementId, \u0012\u0015\u0010.\u001F))
				{
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					elementId = Constants.InvalidElementId;
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Helpers\\Dropdown\\HelperRevitDropdown.cs", "GetCoverTypeInfo");
			}
			return elementId;
		}

		// Token: 0x06001874 RID: 6260 RVA: 0x0009D6CC File Offset: 0x0009B8CC
		internal static ElementId \u0020(Document \u001F, string \u000A)
		{
			\u0017\u000D.\u001C\u000D u001C_u000D = new \u0017\u000D.\u001C\u000D();
			u001C_u000D.\u001F = \u000A;
			ElementId result = Constants.InvalidElementId;
			if (\u001D\u0017\u000A.\u000A(u001C_u000D.\u001F, "None"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0020(Document, string)).MethodHandle;
				}
				IList<Element> list = \u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u001D(\u0020\u0011\u000A.\u000A(\u001F), -2000240L)));
				try
				{
					IEnumerable<Element> enumerable = Enumerable.Where<Element>(list, new Func<Element, bool>(u001C_u000D.\u000A));
					Func<Element, ElementId> func;
					if ((func = \u0017\u000D.<>c.\u000B) == null)
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
						func = (\u0017\u000D.<>c.\u000B = new Func<Element, ElementId>(\u0017\u000D.<>c.\u001F.\u0001));
					}
					result = Enumerable.FirstOrDefault<ElementId>(Enumerable.Select<Element, ElementId>(enumerable, func));
				}
				catch (Exception)
				{
					result = \u0012\u0015\u0010.\u001F;
				}
			}
			return result;
		}

		// Token: 0x06001875 RID: 6261 RVA: 0x0009D7A4 File Offset: 0x0009B9A4
		internal static ElementId \u0017(Document \u001F, bool \u000A, BuiltInCategory \u0007, string \u001D)
		{
			\u0017\u000D.\u000D\u000D u000D_u000D = new \u0017\u000D.\u000D\u000D();
			u000D_u000D.\u001F = \u001D;
			ElementId result = Constants.InvalidElementId;
			if (\u001D\u0017\u000A.\u000A(u000D_u000D.\u001F, "None"))
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0017(Document, bool, BuiltInCategory, string)).MethodHandle;
				}
				FilteredElementCollector u001F = \u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u0007);
				IList<Element> list;
				if (\u000A)
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
					list = \u0001\u001E\u000A.\u0007(\u0020\u0008\u0018.\u001D(u001F));
				}
				else
				{
					list = \u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(u001F));
				}
				try
				{
					IEnumerable<Element> enumerable = Enumerable.Where<Element>(list, new Func<Element, bool>(u000D_u000D.\u000A));
					Func<Element, ElementId> func;
					if ((func = \u0017\u000D.<>c.\u0002) == null)
					{
						for (;;)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							break;
						}
						func = (\u0017\u000D.<>c.\u0002 = new Func<Element, ElementId>(\u0017\u000D.<>c.\u001F.\u0009));
					}
					result = Enumerable.FirstOrDefault<ElementId>(Enumerable.Select<Element, ElementId>(enumerable, func));
				}
				catch (Exception)
				{
					result = \u0012\u0015\u0010.\u001F;
				}
			}
			return result;
		}

		// Token: 0x06001876 RID: 6262 RVA: 0x0009D898 File Offset: 0x0009BA98
		internal static List<string> \u0014(Document \u001F)
		{
			List<string> list = \u0014\u000D\u0007.\u000A();
			IEnumerator<Element> enumerator = \u001F\u0017\u0005.\u000A(\u0001\u001E\u000A.\u0007(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u001E\u0011\u000A.\u000A(\u0005\u0019\u000E.\u001F()))));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Element u001F = \u0001\u000C\u0004.\u000A(enumerator);
					\u001A\u0008\u0007.\u000A(list, \u0005\u001E\u000A.\u000A(u001F));
				}
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0014(Document)).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			\u0004\u000F\u0019.\u000A(list);
			return list;
		}

		// Token: 0x06001877 RID: 6263 RVA: 0x0009D93C File Offset: 0x0009BB3C
		internal static ElementId \u0013(Document \u001F, string \u000A)
		{
			\u0017\u000D.\u0010\u000D u0010_u000D = new \u0017\u000D.\u0010\u000D();
			u0010_u000D.\u001F = \u000A;
			Element element = Enumerable.FirstOrDefault<Element>(\u0001\u001E\u000A.\u0007(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u001E\u0011\u000A.\u000A(\u0005\u0019\u000E.\u001F()))), new Func<Element, bool>(u0010_u000D.\u000A));
			if (element != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0013(Document, string)).MethodHandle;
				}
				return \u0002\u001E\u000A.\u0007(element);
			}
			return Constants.InvalidElementId;
		}

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x06001878 RID: 6264 RVA: 0x0009D9B4 File Offset: 0x0009BBB4
		// (set) Token: 0x06001879 RID: 6265 RVA: 0x0009D9C8 File Offset: 0x0009BBC8
		internal static bool RefreshWindow { get; set; }

		// Token: 0x0600187A RID: 6266 RVA: 0x0009D9DC File Offset: 0x0009BBDC
		internal static List<Element> \u001A(CategoryCollection \u001F, bool \u000A)
		{
			return \u0017\u000D.\u001A(\u0013\u000E\u0018.\u0007(\u001F), \u0017\u000D.\u0015(), \u000A);
		}

		// Token: 0x0600187B RID: 6267 RVA: 0x0009DA00 File Offset: 0x0009BC00
		private static List<Element> \u001A(BuiltInCategory \u001F, List<Document> \u000A, bool \u0007)
		{
			List<Element> list = \u0016\u0016\u0004.\u000A();
			List<BuiltInCategory> u001F = \u0017\u000D.\u000C(\u001F);
			List<Document>.Enumerator enumerator = \u000D\u001C\u0018.\u000A(\u000A);
			try
			{
				while (\u0005\u001C\u0018.\u000A(ref enumerator))
				{
					Document u001F2 = \u001C\u001C\u0018.\u000A(ref enumerator);
					List<BuiltInCategory>.Enumerator enumerator2 = \u000E\u0017\u0005.\u000A(u001F);
					try
					{
						while (\u000D\u0017\u0005.\u000A(ref enumerator2))
						{
							BuiltInCategory u000A = \u0010\u0017\u0005.\u000A(ref enumerator2);
							FilteredElementCollector u001F3 = \u0003\u000B\u000E.\u001F;
							if (!\u0007)
							{
								goto IL_95;
							}
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u001A(BuiltInCategory, List<Document>, bool)).MethodHandle;
							}
							if (\u0004\u0013\u000A.\u0007(u001F2) == null)
							{
								goto IL_95;
							}
							for (;;)
							{
								switch (3)
								{
								case 0:
									continue;
								}
								break;
							}
							u001F3 = \u001A\u0018\u0007.\u000A(u001F2, \u0002\u001E\u000A.\u0007(\u000F\u000B\u0004.\u0007(\u001F\u0011\u0018.\u000A())));
							IL_9F:
							\u0018\u0016\u0004.\u000A(list, Enumerable.ToList<Element>(\u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u001D(u001F3, u000A)))));
							continue;
							IL_95:
							u001F3 = \u0020\u0011\u000A.\u000A(u001F2);
							goto IL_9F;
						}
						for (;;)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x0600187C RID: 6268 RVA: 0x0009DB40 File Offset: 0x0009BD40
		private static List<BuiltInCategory> \u000C(BuiltInCategory \u001F)
		{
			List<BuiltInCategory> list = \u001B\u0017\u0005.\u000A();
			\u0008\u0017\u0005.\u000A(list, \u001F);
			if (\u001F == -2000032L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u000C(BuiltInCategory)).MethodHandle;
				}
				\u0008\u0017\u0005.\u000A(list, -2001392L);
				\u0008\u0017\u0005.\u000A(list, -2000898L);
			}
			else if (\u001F == -2000051L)
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
				\u0008\u0017\u0005.\u000A(list, -2000831L);
				\u0008\u0017\u0005.\u000A(list, -2000066L);
				\u0008\u0017\u0005.\u000A(list, -2000045L);
			}
			else if (\u001F == -2000175L)
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
				\u0008\u0017\u0005.\u000A(list, -2000947L);
				\u0008\u0017\u0005.\u000A(list, -2000948L);
				\u0008\u0017\u0005.\u000A(list, -2000949L);
				\u0008\u0017\u0005.\u000A(list, -2000946L);
			}
			else if (\u001F == -2000035L)
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
				\u0008\u0017\u0005.\u000A(list, -2001390L);
				\u0008\u0017\u0005.\u000A(list, -2001391L);
				\u0008\u0017\u0005.\u000A(list, -2001393L);
			}
			else if (\u001F == -2000120L)
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
				\u0008\u0017\u0005.\u000A(list, -2000920L);
				\u0008\u0017\u0005.\u000A(list, -2000919L);
				\u0008\u0017\u0005.\u000A(list, -2000952L);
			}
			else if (\u001F == -2001320L)
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
				\u0008\u0017\u0005.\u000A(list, -2000995L);
			}
			else if (\u001F == -2000011L)
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
				\u0008\u0017\u0005.\u000A(list, -2003500L);
				\u0008\u0017\u0005.\u000A(list, -2000181L);
				\u0008\u0017\u0005.\u000A(list, -2000182L);
				\u0008\u0017\u0005.\u000A(list, -2000997L);
			}
			else if (\u001F == -2005200L)
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
				\u0008\u0017\u0005.\u000A(list, -2005203L);
				\u0008\u0017\u0005.\u000A(list, -2005202L);
				\u0008\u0017\u0005.\u000A(list, -2005201L);
			}
			else if (\u001F == -2001260L)
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
				\u0008\u0017\u0005.\u000A(list, -2001263L);
				\u0008\u0017\u0005.\u000A(list, -2001265L);
			}
			else if (\u001F == -2005204L)
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
				\u0008\u0017\u0005.\u000A(list, -2005207L);
				\u0008\u0017\u0005.\u000A(list, -2005206L);
				\u0008\u0017\u0005.\u000A(list, -2005205L);
			}
			return list;
		}

		// Token: 0x0600187D RID: 6269 RVA: 0x0009DD9C File Offset: 0x0009BF9C
		private static List<Document> \u0015()
		{
			List<Document> list = \u0013\u0017\u0005.\u000A();
			\u0014\u0017\u0005.\u000A(list, \u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A()));
			if (\u0017\u0017\u0005.\u000A())
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0015()).MethodHandle;
				}
				if (!\u0020\u0017\u0005.\u000A())
				{
					goto IL_5E;
				}
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			if (!\u001E\u0017\u0005.\u000A())
			{
				return list;
			}
			for (;;)
			{
				switch (6)
				{
				case 0:
					continue;
				}
				break;
			}
			IL_5E:
			\u0011\u0017\u0005.\u000A(list, \u0017\u000D.\u0015(\u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A())));
			return list;
		}

		// Token: 0x0600187E RID: 6270 RVA: 0x0009DE24 File Offset: 0x0009C024
		internal static List<Document> \u0015(Document \u001F)
		{
			List<Document> list = \u0013\u0017\u0005.\u000A();
			IEnumerable<Element> enumerable = \u0001\u001E\u000A.\u0007(\u0011\u0011\u000A.\u001D(\u0017\u0011\u000A.\u001D(\u0020\u0011\u000A.\u000A(\u001F), -2001352L), \u001E\u0011\u000A.\u000A(\u0020\u0002\u000E.\u001F())));
			Func<Element, string> func;
			if ((func = \u0017\u000D.<>c.\u0006) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0015(Document)).MethodHandle;
				}
				func = (\u0017\u000D.<>c.\u0006 = new Func<Element, string>(\u0017\u000D.<>c.\u001F.\u001F\u000A));
			}
			List<string> u001F = Enumerable.ToList<string>(Enumerable.Select<Element, string>(enumerable, func));
			IEnumerator u001F2 = \u001B\u000A\u0005.\u000A(\u0011\u000A\u0005.\u000A(\u0017\u0005\u0004.\u0007(\u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A()))));
			try
			{
				while (\u000A\u0017\u000A.\u000A(u001F2))
				{
					Document document = \u0014\u0002\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F2));
					string text = \u0018\u0006\u001D.\u0007(\u0014\u0009\u0007.\u0007(document));
					if (!\u0001\u0016\u001D.\u000A(text, ".rvt"))
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
						text = \u0004\u001E\u000A.\u000A(text, ".rvt");
					}
					if (\u001F\u0020\u001D.\u000A(u001F, text))
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
						\u0014\u0017\u0005.\u000A(list, document);
					}
				}
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F2);
				if (disposable != null)
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
					\u001F\u0017\u000A.\u000A(disposable);
				}
			}
			return list;
		}

		// Token: 0x0600187F RID: 6271 RVA: 0x0009DF80 File Offset: 0x0009C180
		internal static string \u0001(Element \u001F)
		{
			string text = \u0005\u001E\u000A.\u000A(\u001F);
			FamilyInstance familyInstance = \u000D\u000B\u000E.\u001F(\u001F);
			if (familyInstance != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0001(Element)).MethodHandle;
				}
				if (!\u001A\u0006\u0007.\u000A(\u0001\u0015\u0018.\u0007(\u001C\u001B\u0018.\u001D(familyInstance))))
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
					if (\u001D\u0017\u000A.\u000A(\u0003\u000B\u001D.\u0007(\u0001\u0015\u0018.\u0007(\u001C\u001B\u0018.\u001D(familyInstance))), \u0003\u000B\u001D.\u0007(text)))
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
						text = \u0002\u0013\u000A.\u000A(\u0001\u0015\u0018.\u0007(\u001C\u001B\u0018.\u001D(familyInstance)), ":", \u0005\u001E\u000A.\u000A(\u001C\u001B\u0018.\u001D(familyInstance)));
					}
				}
			}
			else
			{
				if (\u000D\u0003\u0018.\u0007(\u001F) != null)
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
					if (\u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(\u001F))) == -2000220L)
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
						Element element = \u0011\u0017\u000A.\u0007(\u0008\u0019\u0007.\u000A(\u001F), \u0004\u0013\u0007.\u000A(\u001F));
						if (element == null)
						{
							return text;
						}
						for (;;)
						{
							switch (7)
							{
							case 0:
								continue;
							}
							break;
						}
						string text2 = \u0001\u0015\u0018.\u0007(\u000B\u0002\u000E.\u001F(element));
						string text3 = \u0005\u001E\u000A.\u000A(element);
						if (!\u001A\u0006\u0007.\u000A(text2))
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
							return text2;
						}
						if (!\u001A\u0006\u0007.\u000A(text3))
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
							return text3;
						}
						return text;
					}
				}
				if (\u000D\u0003\u0018.\u0007(\u001F) != null)
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
					if (\u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(\u001F))) == -2000279L)
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
						return \u001C\u001C\u0007.\u0007(\u0004\u0019\u000E.\u001F(\u001F)).ToString();
					}
				}
				if (\u000D\u0003\u0018.\u0007(\u001F) != null)
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
					if (\u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(\u001F))) == -2000700L)
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
						return \u0009\u0015\u0018.\u000A(\u0002\u0002\u000E.\u001F(\u001F));
					}
				}
				Element element2 = \u0011\u0017\u000A.\u0007(\u0008\u0019\u0007.\u000A(\u001F), \u0004\u0013\u0007.\u000A(\u001F));
				if (element2 != null)
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
					string u001F = \u0001\u0015\u0018.\u0007(\u000B\u0002\u000E.\u001F(element2));
					string text4 = \u0005\u001E\u000A.\u000A(element2);
					if (!\u001A\u0006\u0007.\u000A(u001F))
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
						if (\u001D\u0017\u000A.\u000A(\u0003\u000B\u001D.\u0007(u001F), \u0003\u000B\u001D.\u0007(text4)))
						{
							for (;;)
							{
								switch (4)
								{
								case 0:
									continue;
								}
								break;
							}
							return \u0002\u0013\u000A.\u000A(u001F, ":", text4);
						}
					}
					if (!\u001A\u0006\u0007.\u000A(text4))
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
						if (\u001D\u0017\u000A.\u000A(\u0003\u000B\u001D.\u0007(text4), \u0003\u000B\u001D.\u0007(text)))
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
							text = \u0002\u0013\u000A.\u000A(text4, ":", \u0005\u001E\u000A.\u000A(\u001F));
						}
					}
				}
				else if (\u001A\u0006\u0007.\u000A(text))
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
					if (\u000D\u0003\u0018.\u0007(\u001F) != null)
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
						text = \u0009\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(\u001F));
					}
				}
			}
			return text;
		}

		// Token: 0x06001880 RID: 6272 RVA: 0x0009E2D8 File Offset: 0x0009C4D8
		internal unsafe static List<Element> \u0009(List<CategoryCollection> \u001F, Document \u000A, bool \u0007, ref List<ScheduleData> \u001D)
		{
			List<Element> list = \u0016\u0016\u0004.\u000A();
			\u001D = \u0014\u000E\u0018.\u000A();
			List<CategoryCollection>.Enumerator enumerator = \u0014\u0016\u0018.\u000A(\u001F);
			try
			{
				while (\u001E\u0016\u0018.\u000A(ref enumerator))
				{
					CategoryCollection u001F = \u0017\u0016\u0018.\u000A(ref enumerator);
					ViewSchedule viewSchedule = \u001A\u0004\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u000A, \u001E\u0001\u000A.\u000A(\u0013\u000E\u0018.\u0007(u001F))));
					IEnumerable<Element> enumerable = \u0009\u001E\u000A.\u0007(\u001A\u0018\u0007.\u000A(\u000A, \u0002\u001E\u000A.\u0007(viewSchedule)));
					Func<Element, bool> func;
					if ((func = \u0017\u000D.<>c.\u000F) == null)
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
						if (!true)
						{
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0009(List<CategoryCollection>, Document, bool, List<ScheduleData>*)).MethodHandle;
						}
						func = (\u0017\u000D.<>c.\u000F = new Func<Element, bool>(\u0017\u000D.<>c.\u001F.\u000A\u000A));
					}
					List<Element> list2 = Enumerable.ToList<Element>(Enumerable.Where<Element>(enumerable, func));
					if (\u0019\u0016\u0004.\u0007(list2) == 0)
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
						return list2;
					}
					List<Element> list3 = list2;
					if (\u001B\u001B\u001D.\u000A(\u000E\u000E\u0005.\u000A(\u000B\u0007\u0004.\u000A(viewSchedule)), \u0012\u0015\u0010.\u001F))
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
						if (\u001B\u001B\u001D.\u000A(\u000E\u000E\u0005.\u000A(\u000B\u0007\u0004.\u000A(viewSchedule)), Constants.InvalidElementId))
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
							\u0018\u0016\u0004.\u000A(list, list2);
							continue;
						}
					}
					\u0017\u000D.\u000E\u000D u000E_u000D = new \u0017\u000D.\u000E\u000D();
					u000E_u000D.\u001F = \u001F\u0012.\u000A(viewSchedule);
					List<Element> list4 = Enumerable.ToList<Element>(Enumerable.Where<Element>(list2, new Func<Element, bool>(u000E_u000D.\u000A)));
					if (\u0019\u0016\u0004.\u0007(list4) != 0)
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
						list3 = list4;
					}
					if (\u0007\u0014\u0005.\u000A(viewSchedule, 0))
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
						\u001D = \u001F\u0012.\u0007(\u000A, viewSchedule, list3, \u0007);
						if (\u001D == null)
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
							return list4;
						}
					}
					if (\u0005\u001E\u0018.\u000A(\u001D) != 0)
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
						IEnumerable<Element> enumerable2 = list3;
						Func<Element, bool> func2;
						if ((func2 = \u0017\u000D.<>c.\u0012) == null)
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
							func2 = (\u0017\u000D.<>c.\u0012 = new Func<Element, bool>(\u0017\u000D.<>c.\u001F.\u0007\u000A));
						}
						IEnumerable<Element> enumerable3 = Enumerable.Where<Element>(enumerable2, func2);
						Func<Element, long> func3;
						if ((func3 = \u0017\u000D.<>c.\u0003) == null)
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
							func3 = (\u0017\u000D.<>c.\u0003 = new Func<Element, long>(\u0017\u000D.<>c.\u001F.\u001D\u000A));
						}
						IEnumerable<IGrouping<long, Element>> enumerable4 = Enumerable.GroupBy<Element, long>(enumerable3, func3);
						Func<IGrouping<long, Element>, long> func4;
						if ((func4 = \u0017\u000D.<>c.\u001C) == null)
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
							func4 = (\u0017\u000D.<>c.\u001C = new Func<IGrouping<long, Element>, long>(\u0017\u000D.<>c.\u001F.\u0004\u000A));
						}
						Func<IGrouping<long, Element>, Element> func5;
						if ((func5 = \u0017\u000D.<>c.\u000D) == null)
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
							func5 = (\u0017\u000D.<>c.\u000D = new Func<IGrouping<long, Element>, Element>(\u0017\u000D.<>c.\u001F.\u0019\u000A));
						}
						Dictionary<long, Element> u001F2 = Enumerable.ToDictionary<IGrouping<long, Element>, long, Element>(enumerable4, func4, func5);
						List<ScheduleData>.Enumerator enumerator2 = \u000A\u0014\u0005.\u000A(\u001D);
						try
						{
							while (\u001A\u0017\u0005.\u000A(ref enumerator2))
							{
								ScheduleData u001F3 = \u001F\u0014\u0005.\u000A(ref enumerator2);
								if (\u0009\u0017\u0005.\u000A(u001F2, \u0001\u0017\u0005.\u000A(u001F3)))
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
									\u000C\u0017\u0005.\u000A(u001F3, \u0015\u0017\u0005.\u000A(u001F2, \u0001\u0017\u0005.\u000A(u001F3)));
								}
							}
							for (;;)
							{
								switch (6)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator2).Dispose();
						}
						object u001F4 = list;
						IEnumerable<ScheduleData> enumerable5 = \u001D;
						Func<ScheduleData, bool> func6;
						if ((func6 = \u0017\u000D.<>c.\u0010) == null)
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
							func6 = (\u0017\u000D.<>c.\u0010 = new Func<ScheduleData, bool>(\u0017\u000D.<>c.\u001F.\u0018\u000A));
						}
						IEnumerable<ScheduleData> enumerable6 = Enumerable.Where<ScheduleData>(enumerable5, func6);
						Func<ScheduleData, Element> func7;
						if ((func7 = \u0017\u000D.<>c.\u000E) == null)
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
							func7 = (\u0017\u000D.<>c.\u000E = new Func<ScheduleData, Element>(\u0017\u000D.<>c.\u001F.\u0005\u000A));
						}
						\u0018\u0016\u0004.\u000A(u001F4, Enumerable.Select<ScheduleData, Element>(enumerable6, func7));
					}
					else
					{
						\u0018\u0016\u0004.\u000A(list, list2);
					}
				}
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x06001881 RID: 6273 RVA: 0x0009E6A8 File Offset: 0x0009C8A8
		internal static Element \u001F\u000A(long \u001F)
		{
			List<Document> u001F = \u0017\u000D.\u0015();
			Element element = \u0007\u000B\u000E.\u001F;
			if (\u001F > 0L)
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u001F\u000A(long)).MethodHandle;
				}
				List<Document>.Enumerator enumerator = \u000D\u001C\u0018.\u000A(u001F);
				try
				{
					while (\u0005\u001C\u0018.\u000A(ref enumerator))
					{
						element = \u0011\u0017\u000A.\u0007(\u001C\u001C\u0018.\u000A(ref enumerator), \u001E\u0001\u000A.\u000A(\u001F));
						if (element != null)
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
							return element;
						}
					}
					for (;;)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			return element;
		}

		// Token: 0x06001882 RID: 6274 RVA: 0x0009E744 File Offset: 0x0009C944
		internal static Element \u000A\u000A(string \u001F, List<Document> \u000A)
		{
			Element element = \u0007\u000B\u000E.\u001F;
			if (!\u001A\u0006\u0007.\u000A(\u001F))
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u000A\u000A(string, List<Document>)).MethodHandle;
				}
				List<Document>.Enumerator enumerator = \u000D\u001C\u0018.\u000A(\u000A);
				try
				{
					while (\u0005\u001C\u0018.\u000A(ref enumerator))
					{
						element = \u000C\u0008\u0007.\u000A(\u001C\u001C\u0018.\u000A(ref enumerator), \u001F);
						if (element != null)
						{
							for (;;)
							{
								switch (4)
								{
								case 0:
									continue;
								}
								break;
							}
							return element;
						}
					}
					for (;;)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			return element;
		}

		// Token: 0x06001883 RID: 6275 RVA: 0x0009E7D8 File Offset: 0x0009C9D8
		internal static void \u0007\u000A(Document \u001F, List<CategoryCollection> \u000A)
		{
			List<Category> list = Enumerable.ToList<Category>(Enumerable.Cast<Category>(\u000D\u0001\u001D.\u000A(\u0010\u0001\u001D.\u000A(\u001F))));
			List<CategoryCollection>.Enumerator enumerator = \u0014\u0016\u0018.\u000A(\u000A);
			try
			{
				while (\u001E\u0016\u0018.\u000A(ref enumerator))
				{
					\u0017\u000D.\u0008\u000D u0008_u000D = new \u0017\u000D.\u0008\u000D();
					u0008_u000D.\u001F = \u0017\u0016\u0018.\u000A(ref enumerator);
					Category category = Enumerable.FirstOrDefault<Category>(list, new Func<Category, bool>(u0008_u000D.\u000A));
					if (category != null)
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
						if (!true)
						{
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0007\u000A(Document, List<CategoryCollection>)).MethodHandle;
						}
						\u0015\u0015\u0018.\u0007(u0008_u000D.\u001F, \u0009\u0014\u000A.\u001D(category));
					}
					else
					{
						\u0015\u0015\u0018.\u0007(u0008_u000D.\u001F, \u0017\u000D.\u001D\u000A(\u001F, \u0013\u000E\u0018.\u0007(u0008_u000D.\u001F)));
					}
				}
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06001884 RID: 6276 RVA: 0x0009E8BC File Offset: 0x0009CABC
		private static string \u001D\u000A(Document \u001F, long \u000A)
		{
			string text = "";
			Element element = \u001B\u0011\u000A.\u000A(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u000A));
			if (element != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u001D\u000A(Document, long)).MethodHandle;
				}
				text = \u0009\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(element));
			}
			if (\u001A\u0006\u0007.\u000A(text))
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
				if (\u000A == -2000096L)
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
					text = "Detail Groups";
				}
			}
			return text;
		}

		// Token: 0x06001885 RID: 6277 RVA: 0x0009E93C File Offset: 0x0009CB3C
		internal static List<Element> \u0004\u000A(List<Element> \u001F, List<RevitParameter> \u000A)
		{
			List<Element> list = \u0016\u0016\u0004.\u000A();
			List<Element> list2 = \u0016\u0016\u0004.\u000A();
			if (Enumerable.Any<Element>(\u001F))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0004\u000A(List<Element>, List<RevitParameter>)).MethodHandle;
				}
				List<Element>.Enumerator enumerator = \u0001\u0010\u0007.\u000A(\u001F);
				try
				{
					while (\u000C\u0010\u0007.\u000A(ref enumerator))
					{
						Element element = \u0015\u0010\u0007.\u000A(ref enumerator);
						\u0017\u000D.\u0011\u000D u0011_u000D = new \u0017\u000D.\u0011\u000D();
						u0011_u000D.\u001F = \u0004\u0013\u0007.\u000A(element);
						if (\u001B\u001B\u001D.\u000A(u0011_u000D.\u001F, Constants.InvalidElementId))
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
							if (Enumerable.FirstOrDefault<Element>(list2, new Func<Element, bool>(u0011_u000D.\u000A)) == null)
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
								\u000C\u0017\u0019.\u000A(list2, \u0011\u0017\u000A.\u0007(\u0008\u0019\u0007.\u000A(element), u0011_u000D.\u001F));
								\u000C\u0017\u0019.\u000A(list, element);
							}
						}
					}
					for (;;)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			return list;
		}

		// Token: 0x06001886 RID: 6278 RVA: 0x0009EA44 File Offset: 0x0009CC44
		internal static List<ImageType> \u0019\u000A(Document \u001F)
		{
			return Enumerable.ToList<ImageType>(Enumerable.Cast<ImageType>(\u0020\u0008\u0018.\u001D(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), -2000560L))));
		}

		// Token: 0x06001887 RID: 6279 RVA: 0x0009EA7C File Offset: 0x0009CC7C
		internal static Image \u0018\u000A(ImageType \u001F)
		{
			return \u001D\u0014\u0005.\u000A(\u001F);
		}

		// Token: 0x06001888 RID: 6280 RVA: 0x0009EA94 File Offset: 0x0009CC94
		internal static Dictionary<long, Category> \u0005\u000A(Document \u001F)
		{
			IEnumerable<GraphicsStyle> enumerable = Enumerable.ToList<GraphicsStyle>(Enumerable.Cast<GraphicsStyle>(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u001E\u0011\u000A.\u000A(\u0016\u0012\u000E.\u001F()))));
			Func<GraphicsStyle, long> func;
			if ((func = \u0017\u000D.<>c.\u0008) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0005\u000A(Document)).MethodHandle;
				}
				func = (\u0017\u000D.<>c.\u0008 = new Func<GraphicsStyle, long>(\u0017\u000D.<>c.\u001F.\u0016\u000A));
			}
			IEnumerable<IGrouping<long, GraphicsStyle>> enumerable2 = Enumerable.GroupBy<GraphicsStyle, long>(enumerable, func);
			Func<IGrouping<long, GraphicsStyle>, long> func2;
			if ((func2 = \u0017\u000D.<>c.\u001B) == null)
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
				func2 = (\u0017\u000D.<>c.\u001B = new Func<IGrouping<long, GraphicsStyle>, long>(\u0017\u000D.<>c.\u001F.\u000B\u000A));
			}
			Func<IGrouping<long, GraphicsStyle>, Category> func3;
			if ((func3 = \u0017\u000D.<>c.\u0011) == null)
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
				func3 = (\u0017\u000D.<>c.\u0011 = new Func<IGrouping<long, GraphicsStyle>, Category>(\u0017\u000D.<>c.\u001F.\u0002\u000A));
			}
			Dictionary<long, Category> dictionary = Enumerable.ToDictionary<IGrouping<long, GraphicsStyle>, long, Category>(enumerable2, func2, func3);
			\u0004\u0014\u0005.\u000A(dictionary, -1L, \u0002\u0019\u000E.\u001F);
			return dictionary;
		}

		// Token: 0x06001889 RID: 6281 RVA: 0x0009EB6C File Offset: 0x0009CD6C
		internal static bool \u0016\u000A(UIDocument \u001F)
		{
			if (\u0018\u0014\u0005.\u000A(\u001F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u0016\u000A(UIDocument)).MethodHandle;
				}
				return false;
			}
			ViewType viewType = \u001C\u001C\u0007.\u0007(\u000F\u000B\u0004.\u0007(\u001F));
			if (viewType != 5)
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
				if (viewType != 123)
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
					if (viewType != 122)
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
						if (viewType != 8)
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
							if (viewType != 119)
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
								if (viewType != 120)
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
									if (!\u0019\u0014\u0005.\u000A(viewType))
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
										if (viewType != 11)
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
											if (viewType != 6)
											{
												return true;
											}
											for (;;)
											{
												switch (6)
												{
												case 0:
													continue;
												}
												break;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600188A RID: 6282 RVA: 0x0009EC3C File Offset: 0x0009CE3C
		internal static void \u000B\u000A(View \u001F, Window \u000A, List<ElementId> \u0007)
		{
			\u0017\u000D.\u001E\u000D u001E_u000D = new \u0017\u000D.\u001E\u000D();
			u001E_u000D.\u001F = \u001F;
			if (\u001D\u0013\u000A.\u000A(u001E_u000D.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u000B\u000A(View, Window, List<ElementId>)).MethodHandle;
				}
				\u000D\u0013\u000A.\u000A(u001E_u000D.\u001F, 2);
			}
			List<ElementId> list = Enumerable.ToList<ElementId>(Enumerable.Where<ElementId>(\u0007, new Func<ElementId, bool>(u001E_u000D.\u000A)));
			\u0007 = Enumerable.ToList<ElementId>(Enumerable.Except<ElementId>(\u0007, list));
			string u001F = "";
			if (\u001A\u0014\u000A.\u000A(list) > 0)
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
				u001F = \u0004\u001E\u000A.\u000A(u001F, \u000B\u0014\u0005.\u000A());
				if (\u001A\u0014\u000A.\u000A(\u0007) == 0)
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
					\u0007 = \u001B\u0015\u0010.\u001F;
				}
			}
			if (\u0007 != null)
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
				if (\u001A\u0014\u000A.\u000A(\u0007) > 0)
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
					if (\u001A\u0014\u000A.\u000A(list) > 0)
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
						\u0005\u0013\u0019.\u000A(u001F, \u000A, 250.0);
					}
					\u001F\u000E u001F_u000E = new \u001F\u000E();
					\u0016\u0014\u0005.\u000A(u001F_u000E, \u0007);
					\u001F\u000E u000A = u001F_u000E;
					\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000A);
					\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
					return;
				}
			}
			u001F = \u0002\u0013\u000A.\u000A(u001F, " ", \u0005\u0014\u0005.\u000A());
			\u0005\u0013\u0019.\u000A(u001F, \u000A, 250.0);
		}

		// Token: 0x0600188B RID: 6283 RVA: 0x0009ED98 File Offset: 0x0009CF98
		internal static void \u0002\u000A(View \u001F)
		{
			\u0001\u0010 u000A = new \u0001\u0010();
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000A);
			\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
		}

		// Token: 0x0400099F RID: 2463
		[CompilerGenerated]
		private static bool \u001F;

		// Token: 0x02000925 RID: 2341
		[CompilerGenerated]
		private sealed class \u0005\u000D
		{
			// Token: 0x060051F4 RID: 20980 RVA: 0x001E9A28 File Offset: 0x001E7C28
			internal bool \u000A(Element \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x04002417 RID: 9239
			public string \u001F;
		}

		// Token: 0x02000926 RID: 2342
		[CompilerGenerated]
		private sealed class \u0016\u000D
		{
			// Token: 0x060051F6 RID: 20982 RVA: 0x001E9A60 File Offset: 0x001E7C60
			internal bool \u000A(PipingSystemType \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x04002418 RID: 9240
			public string \u001F;
		}

		// Token: 0x02000927 RID: 2343
		[CompilerGenerated]
		private sealed class \u000B\u000D
		{
			// Token: 0x060051F8 RID: 20984 RVA: 0x001E9A98 File Offset: 0x001E7C98
			internal bool \u000A(\u0013\u000D \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001F.\u001F, this.\u001F);
			}

			// Token: 0x04002419 RID: 9241
			public string \u001F;
		}

		// Token: 0x02000928 RID: 2344
		[CompilerGenerated]
		private sealed class \u0002\u000D
		{
			// Token: 0x060051FA RID: 20986 RVA: 0x001E9ACC File Offset: 0x001E7CCC
			internal bool \u000A(\u0013\u000D \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001F.\u000A, this.\u001F);
			}

			// Token: 0x0400241A RID: 9242
			public string \u001F;
		}

		// Token: 0x02000929 RID: 2345
		[CompilerGenerated]
		private sealed class \u0006\u000D
		{
			// Token: 0x060051FC RID: 20988 RVA: 0x001E9B00 File Offset: 0x001E7D00
			internal bool \u000A(\u0013\u000D \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001F.\u001F, this.\u001F);
			}

			// Token: 0x0400241B RID: 9243
			public string \u001F;
		}

		// Token: 0x0200092A RID: 2346
		[CompilerGenerated]
		private sealed class \u000F\u000D
		{
			// Token: 0x060051FE RID: 20990 RVA: 0x001E9B34 File Offset: 0x001E7D34
			internal bool \u000A(\u0013\u000D \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001F.\u000A, this.\u001F);
			}

			// Token: 0x0400241C RID: 9244
			public string \u001F;
		}

		// Token: 0x0200092B RID: 2347
		[CompilerGenerated]
		private sealed class \u0012\u000D
		{
			// Token: 0x06005200 RID: 20992 RVA: 0x001E9B68 File Offset: 0x001E7D68
			internal bool \u000A(Workset \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0019\u000A\u000D.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x0400241D RID: 9245
			public string \u001F;
		}

		// Token: 0x0200092C RID: 2348
		[CompilerGenerated]
		private sealed class \u0003\u000D
		{
			// Token: 0x06005202 RID: 20994 RVA: 0x001E9BA0 File Offset: 0x001E7DA0
			internal bool \u000A(Element \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x0400241E RID: 9246
			public string \u001F;
		}

		// Token: 0x0200092D RID: 2349
		[CompilerGenerated]
		private sealed class \u001C\u000D
		{
			// Token: 0x06005204 RID: 20996 RVA: 0x001E9BD8 File Offset: 0x001E7DD8
			internal bool \u000A(Element \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x0400241F RID: 9247
			public string \u001F;
		}

		// Token: 0x0200092E RID: 2350
		[CompilerGenerated]
		private sealed class \u000D\u000D
		{
			// Token: 0x06005206 RID: 20998 RVA: 0x001E9C10 File Offset: 0x001E7E10
			internal bool \u000A(Element \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x04002420 RID: 9248
			public string \u001F;
		}

		// Token: 0x0200092F RID: 2351
		[CompilerGenerated]
		private sealed class \u0010\u000D
		{
			// Token: 0x06005208 RID: 21000 RVA: 0x001E9C48 File Offset: 0x001E7E48
			internal bool \u000A(Element \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x04002421 RID: 9249
			public string \u001F;
		}

		// Token: 0x02000930 RID: 2352
		[CompilerGenerated]
		private sealed class \u000E\u000D
		{
			// Token: 0x0600520A RID: 21002 RVA: 0x001E9C80 File Offset: 0x001E7E80
			internal bool \u000A(Element \u001F)
			{
				if (\u000D\u0003\u0018.\u0007(\u001F) != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000D.\u000E\u000D.\u000A(Element)).MethodHandle;
					}
					return \u001A\u0008\u0019.\u000A(this.\u001F, \u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(\u001F))));
				}
				return false;
			}

			// Token: 0x04002422 RID: 9250
			public List<long> \u001F;
		}

		// Token: 0x02000931 RID: 2353
		[CompilerGenerated]
		private sealed class \u0008\u000D
		{
			// Token: 0x0600520C RID: 21004 RVA: 0x001E9CE4 File Offset: 0x001E7EE4
			internal bool \u000A(Category \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u001F)) == \u0013\u000E\u0018.\u0007(this.\u001F);
			}

			// Token: 0x04002423 RID: 9251
			public CategoryCollection \u001F;
		}

		// Token: 0x02000932 RID: 2354
		[CompilerGenerated]
		private sealed class \u001B\u000D
		{
			// Token: 0x0600520E RID: 21006 RVA: 0x001E9D24 File Offset: 0x001E7F24
			internal bool \u000A(GraphicsStyle \u001F)
			{
				return \u000D\u001F\u001D.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x04002424 RID: 9252
			public string \u001F;
		}

		// Token: 0x02000933 RID: 2355
		[CompilerGenerated]
		private sealed class \u0011\u000D
		{
			// Token: 0x06005210 RID: 21008 RVA: 0x001E9D5C File Offset: 0x001E7F5C
			internal bool \u000A(Element \u001F)
			{
				return \u0011\u0016\u001D.\u000A(\u0002\u001E\u000A.\u0007(\u001F), this.\u001F);
			}

			// Token: 0x04002425 RID: 9253
			public ElementId \u001F;
		}

		// Token: 0x02000934 RID: 2356
		[CompilerGenerated]
		private sealed class \u001E\u000D
		{
			// Token: 0x06005212 RID: 21010 RVA: 0x001E9D94 File Offset: 0x001E7F94
			internal bool \u000A(ElementId \u001F)
			{
				return \u0003\u0015\u0010.\u001F(\u0011\u0017\u000A.\u0007(\u0008\u0019\u0007.\u000A(this.\u001F), \u001F)) != \u001C\u0015\u0010.\u001F;
			}

			// Token: 0x04002426 RID: 9254
			public View \u001F;
		}

		// Token: 0x02000935 RID: 2357
		[CompilerGenerated]
		private sealed class \u0020\u000D
		{
			// Token: 0x06005214 RID: 21012 RVA: 0x001E9DD8 File Offset: 0x001E7FD8
			internal bool \u000A(FillPatternElement \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0001\u000B\u0010.\u000A(\u0017\u0003\u000D.\u000A(\u001F)), this.\u001F);
			}

			// Token: 0x04002427 RID: 9255
			public string \u001F;
		}
	}
}

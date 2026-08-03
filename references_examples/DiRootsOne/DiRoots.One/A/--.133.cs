using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace A
{
	// Token: 0x02000260 RID: 608
	internal static class \u0004\u0010
	{
		// Token: 0x060018A9 RID: 6313 RVA: 0x0009F704 File Offset: 0x0009D904
		internal static ICollection<Element> \u001F(Document \u001F, BuiltInCategory \u000A)
		{
			return \u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(\u0017\u0011\u000A.\u001D(\u0020\u0011\u000A.\u000A(\u001F), \u000A)));
		}

		// Token: 0x060018AA RID: 6314 RVA: 0x0009F730 File Offset: 0x0009D930
		internal static IEnumerable<Element> \u000A(UIDocument \u001F)
		{
			\u0004\u0010.\u0007\u0010 u0007_u = new \u0004\u0010.\u0007\u0010();
			u0007_u.\u001F = \u001F;
			List<Element> list = \u0016\u0016\u0004.\u000A();
			try
			{
				IEnumerator<ElementId> enumerator = \u000B\u0013\u0007.\u000A(\u001C\u0014\u000A.\u000A(\u0010\u001E\u000A.\u0007(u0007_u.\u001F)));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						ElementId u000A = \u0016\u0013\u0007.\u000A(enumerator);
						Element element = \u0011\u0017\u000A.\u0007(\u0011\u0020\u000A.\u0007(u0007_u.\u001F), u000A);
						Group group = \u0003\u0012\u000E.\u001F(element);
						if (group != null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0010.\u000A(UIDocument)).MethodHandle;
							}
							object u001F = list;
							IEnumerable<ElementId> enumerable = \u001F\u0013\u0005.\u000A(group);
							Func<ElementId, Element> func;
							if ((func = u0007_u.\u000A) == null)
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
								func = (u0007_u.\u000A = new Func<ElementId, Element>(u0007_u.\u0007));
							}
							\u0018\u0016\u0004.\u000A(u001F, Enumerable.Select<ElementId, Element>(enumerable, func));
						}
						else
						{
							\u000C\u0017\u0019.\u000A(list, element);
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
			}
			catch (Exception u000A2)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Helpers\\RevitUtility.cs", "GetSelectedElements");
			}
			IEnumerable<Element> enumerable2 = list;
			Func<Element, bool> func2;
			if ((func2 = \u0004\u0010.<>c.\u000A) == null)
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
				func2 = (\u0004\u0010.<>c.\u000A = new Func<Element, bool>(\u0004\u0010.<>c.\u001F.\u0004));
			}
			return Enumerable.Where<Element>(enumerable2, func2);
		}

		// Token: 0x060018AB RID: 6315 RVA: 0x0009F898 File Offset: 0x0009DA98
		internal static List<Element> \u0007(Document \u001F)
		{
			IEnumerable<ViewSchedule> enumerable = Enumerable.Cast<ViewSchedule>(\u0009\u001E\u000A.\u001D(\u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u001E\u0011\u000A.\u000A(\u0012\u0012\u000E.\u001F()))));
			Func<ViewSchedule, bool> func;
			if ((func = \u0004\u0010.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0010.\u0007(Document)).MethodHandle;
				}
				func = (\u0004\u0010.<>c.\u0007 = new Func<ViewSchedule, bool>(\u0004\u0010.<>c.\u001F.\u0019));
			}
			return Enumerable.ToList<Element>(Enumerable.Cast<Element>(Enumerable.Where<ViewSchedule>(enumerable, func)));
		}

		// Token: 0x060018AC RID: 6316 RVA: 0x0009F918 File Offset: 0x0009DB18
		internal static List<Document> \u001D(Document \u001F, bool \u000A)
		{
			List<Document> list = \u0013\u0017\u0005.\u000A();
			\u0014\u0017\u0005.\u000A(list, \u001F);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0010.\u001D(Document, bool)).MethodHandle;
				}
				IEnumerable<Element> enumerable = \u0001\u001E\u000A.\u0007(\u0011\u0011\u000A.\u001D(\u0017\u0011\u000A.\u001D(\u0020\u0011\u000A.\u000A(\u001F), -2001352L), \u001E\u0011\u000A.\u000A(\u0020\u0002\u000E.\u001F())));
				Func<Element, string> func;
				if ((func = \u0004\u0010.<>c.\u001D) == null)
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
					func = (\u0004\u0010.<>c.\u001D = new Func<Element, string>(\u0004\u0010.<>c.\u001F.\u0018));
				}
				List<string> u001F = Enumerable.ToList<string>(Enumerable.Select<Element, string>(enumerable, func));
				IEnumerator u001F2 = \u001B\u000A\u0005.\u000A(\u0011\u000A\u0005.\u000A(\u0017\u0005\u0004.\u0007(\u001F)));
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
								switch (6)
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
								switch (4)
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
						switch (3)
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
							switch (7)
							{
							case 0:
								continue;
							}
							break;
						}
						\u001F\u0017\u000A.\u000A(disposable);
					}
				}
			}
			return list;
		}

		// Token: 0x060018AD RID: 6317 RVA: 0x0009FA80 File Offset: 0x0009DC80
		internal static bool \u0004(UIDocument \u001F, ViewType \u000A, string \u0007)
		{
			\u0004\u0010.\u001D\u0010 u001D_u = new \u0004\u0010.\u001D\u0010();
			u001D_u.\u001F = \u000A;
			u001D_u.\u000A = \u0007;
			Element element = Enumerable.FirstOrDefault<View>(Enumerable.Cast<View>(\u0004\u0010.\u0019(\u0011\u0020\u000A.\u0007(\u001F), u001D_u.\u001F)), new Func<View, bool>(u001D_u.\u0007));
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0010.\u0004(UIDocument, ViewType, string)).MethodHandle;
				}
				\u001D\u0010\u0007.\u0007(\u001F, \u0004\u0019\u000E.\u001F(element));
				return true;
			}
			return false;
		}

		// Token: 0x060018AE RID: 6318 RVA: 0x0009FAF8 File Offset: 0x0009DCF8
		internal static List<Element> \u0019(Document \u001F, ViewType \u000A)
		{
			FilteredElementCollector u001F = \u0020\u0011\u000A.\u000A(\u001F);
			if (\u000A == 123)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0010.\u0019(Document, ViewType)).MethodHandle;
				}
				u001F = \u0011\u0011\u000A.\u001D(u001F, \u001E\u0011\u000A.\u000A(\u001A\u0005\u000E.\u001F()));
			}
			else
			{
				u001F = \u0011\u0011\u000A.\u001D(u001F, \u001E\u0011\u000A.\u000A(\u0012\u0012\u000E.\u001F()));
			}
			return Enumerable.ToList<Element>(\u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(u001F)));
		}

		// Token: 0x0200093A RID: 2362
		[CompilerGenerated]
		private sealed class \u0007\u0010
		{
			// Token: 0x06005221 RID: 21025 RVA: 0x001E9F84 File Offset: 0x001E8184
			internal Element \u0007(ElementId \u001F)
			{
				return \u0011\u0017\u000A.\u0007(\u0011\u0020\u000A.\u0007(this.\u001F), \u001F);
			}

			// Token: 0x04002431 RID: 9265
			public UIDocument \u001F;

			// Token: 0x04002432 RID: 9266
			public Func<ElementId, Element> \u000A;
		}

		// Token: 0x0200093B RID: 2363
		[CompilerGenerated]
		private sealed class \u001D\u0010
		{
			// Token: 0x06005223 RID: 21027 RVA: 0x001E9FBC File Offset: 0x001E81BC
			internal bool \u0007(View \u001F)
			{
				if (\u001C\u001C\u0007.\u0007(\u001F) == this.\u001F)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0010.\u001D\u0010.\u0007(View)).MethodHandle;
					}
					return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u000A);
				}
				return false;
			}

			// Token: 0x04002433 RID: 9267
			public ViewType \u001F;

			// Token: 0x04002434 RID: 9268
			public string \u000A;
		}
	}
}

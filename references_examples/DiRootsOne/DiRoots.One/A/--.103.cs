using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000197 RID: 407
	internal class \u001A\u0002
	{
		// Token: 0x06000F03 RID: 3843 RVA: 0x0005F788 File Offset: 0x0005D988
		internal static CategoryCollection \u0007(Document \u001F, \u0015\u001C \u000A, List<Element> \u0007)
		{
			CategoryCollection categoryCollection = \u001A\u0017\u0019.\u000A();
			\u0013\u0017\u0019.\u0007(categoryCollection, -2008152L);
			List<string> list = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list, "4");
			\u0014\u0017\u0019.\u0007(categoryCollection, list);
			CategoryCollection categoryCollection2 = categoryCollection;
			List<CategoryCollection> list2 = \u0017\u0017\u0019.\u000A();
			\u0020\u0017\u0019.\u000A(list2, categoryCollection2);
			\u0017\u000D.\u0007\u000A(\u001F, list2);
			\u000A.\u0005(categoryCollection2);
			\u0011\u0017\u0019.\u0007(categoryCollection2, \u001A\u0002.\u001D(\u001E\u0017\u0019.\u0007(categoryCollection2), \u0007));
			return categoryCollection2;
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x0005F7F4 File Offset: 0x0005D9F4
		private static List<Element> \u001D(List<Element> \u001F, List<Element> \u000A)
		{
			IEnumerable<PanelScheduleView> enumerable = Enumerable.Cast<PanelScheduleView>(\u000A);
			Func<PanelScheduleView, long> func;
			if ((func = \u001A\u0002.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u0002.\u001D(List<Element>, List<Element>)).MethodHandle;
				}
				func = (\u001A\u0002.<>c.\u000A = new Func<PanelScheduleView, long>(\u001A\u0002.<>c.\u001F.\u0007));
			}
			List<long> u001F = Enumerable.ToList<long>(Enumerable.Select<PanelScheduleView, long>(enumerable, func));
			List<Element> list = \u0016\u0016\u0004.\u000A();
			List<Element>.Enumerator enumerator = \u0001\u0010\u0007.\u000A(\u001F);
			try
			{
				while (\u000C\u0010\u0007.\u000A(ref enumerator))
				{
					Element element = \u0015\u0010\u0007.\u000A(ref enumerator);
					ElectricalSystem electricalSystem = \u0015\u0005\u000E.\u001F(element);
					if (electricalSystem != null)
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
						if (\u0015\u0017\u0019.\u000A(electricalSystem) != null)
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
							if (\u001A\u0008\u0019.\u000A(u001F, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u0015\u0017\u0019.\u000A(electricalSystem)))))
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
								\u000C\u0017\u0019.\u000A(list, element);
							}
						}
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
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x040005E5 RID: 1509
		internal static int \u001F;

		// Token: 0x040005E6 RID: 1510
		internal static string \u000A;
	}
}

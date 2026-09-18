using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using DiRoots.One.PanelLink;
using DiRoots.One.PanelLink.Models;

namespace A
{
	// Token: 0x02000191 RID: 401
	internal static class \u0020\u0002
	{
		// Token: 0x06000EE1 RID: 3809 RVA: 0x0005EAE4 File Offset: 0x0005CCE4
		internal static List<PanelParameter> \u001F(Document \u001F)
		{
			List<PanelParameter> list = \u0007\u0011\u0019.\u000A();
			List<Equipment> u001F = \u0014\u0002.\u0007(\u001F);
			IList<Parameter> u000A = \u0003\u0007\u001D.\u000A(\u001D\u001E\u0019.\u000A(\u0004\u001E\u0019.\u000A(u001F, 0)), true);
			\u0020\u0002.\u001F(list, u000A, false);
			IList<Parameter> u000A2 = \u0003\u0007\u001D.\u000A(\u0011\u0017\u000A.\u0007(\u001F, \u0004\u0013\u0007.\u000A(\u001D\u001E\u0019.\u000A(\u0004\u001E\u0019.\u000A(u001F, 0)))), true);
			\u0020\u0002.\u001F(list, u000A2, false);
			return list;
		}

		// Token: 0x06000EE2 RID: 3810 RVA: 0x0005EB54 File Offset: 0x0005CD54
		private static void \u001F(List<PanelParameter> \u001F, IList<Parameter> \u000A, bool \u0007)
		{
			IEnumerator<Parameter> enumerator = \u0015\u001B\u0019.\u000A(\u000A);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Parameter parameter = \u000C\u001B\u0019.\u000A(enumerator);
					PanelParameter panelParameter = \u001A\u001B\u0019.\u000A();
					\u0014\u001B\u0019.\u000A(panelParameter, parameter);
					\u0017\u001B\u0019.\u0007(panelParameter, \u0007);
					\u0013\u001B\u0019.\u0007(panelParameter, \u0010\u0014\u0007.\u000A(parameter));
					\u000D\u001B\u0019.\u000A(\u001F, panelParameter);
				}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0002.\u001F(List<PanelParameter>, IList<Parameter>, bool)).MethodHandle;
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
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x0005EBE4 File Offset: 0x0005CDE4
		internal static IList<Parameter> \u000A(Document \u001F)
		{
			object u001F = \u0020\u0011\u000A.\u000A(\u001F);
			ElementCategoryFilter u000A = \u0003\u0018\u0007.\u000A(-2008037L);
			IList<Element> u001F2 = \u0001\u001E\u000A.\u0007(\u0009\u001E\u000A.\u001D(\u0014\u0011\u000A.\u0007(u001F, u000A)));
			IList<Parameter> result = \u001C\u0007\u001D.\u000A();
			if (\u0018\u001E\u0019.\u000A(u001F2) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0002.\u000A(Document)).MethodHandle;
				}
				result = \u0003\u0007\u001D.\u000A(\u0019\u001E\u0019.\u000A(u001F2, 0), true);
			}
			return result;
		}
	}
}

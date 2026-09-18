using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using DiRoots.One.PanelLink;
using DiRoots.One.PanelLink.Models;

namespace A
{
	// Token: 0x02000194 RID: 404
	internal static class \u0014\u0002
	{
		// Token: 0x06000EF8 RID: 3832 RVA: 0x0005EDE8 File Offset: 0x0005CFE8
		internal static List<Panel> \u001F(Document \u001F, long \u000A)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Models\\CollectPanels.cs", "GetPanels");
			List<Panel> list = \u0008\u001E\u0019.\u000A();
			FilteredElementCollector u001F = \u0011\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001F), \u001E\u0011\u000A.\u000A(\u001A\u0005\u000E.\u001F()));
			if (\u000E\u001E\u0019.\u000A(u001F) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u0002.\u001F(Document, long)).MethodHandle;
				}
				return list;
			}
			IEnumerator<Element> enumerator = \u0009\u000C\u0004.\u000A(u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Element element = \u0001\u000C\u0004.\u000A(enumerator);
					List<PanelSectionPart> list2 = \u0010\u001E\u0019.\u000A();
					Panel panel = \u000D\u001E\u0019.\u000A();
					\u001C\u001E\u0019.\u000A(panel, element);
					\u0003\u001E\u0019.\u000A(panel, \u0005\u001E\u000A.\u000A(element));
					PanelScheduleView panelScheduleView = \u000C\u0005\u000E.\u001F(element);
					\u0012\u001E\u0019.\u000A(panel, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(panelScheduleView)) == \u000A);
					\u000F\u001E\u0019.\u000A(panel, panelScheduleView);
					\u0002\u001E\u0019.\u000A(panel, \u0006\u001E\u0019.\u000A(panelScheduleView));
					\u000B\u001E\u0019.\u000A(list2, \u0014\u0002.\u001D(panelScheduleView, 0, "Header"));
					\u000B\u001E\u0019.\u000A(list2, \u0014\u0002.\u001D(panelScheduleView, 1, "Body"));
					\u000B\u001E\u0019.\u000A(list2, \u0014\u0002.\u001D(panelScheduleView, 2, "Summary"));
					\u000B\u001E\u0019.\u000A(list2, \u0014\u0002.\u001D(panelScheduleView, 3, "Footer"));
					\u0016\u001E\u0019.\u000A(panel, list2);
					\u0005\u001E\u0019.\u000A(list, panel);
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			IEnumerable<Panel> enumerable = list;
			Func<Panel, string> func;
			if ((func = \u0014\u0002.<>c.\u000A) == null)
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
				func = (\u0014\u0002.<>c.\u000A = new Func<Panel, string>(\u0014\u0002.<>c.\u001F.\u0007));
			}
			list = Enumerable.ToList<Panel>(Enumerable.OrderBy<Panel, string>(enumerable, func));
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Models\\CollectPanels.cs", "GetPanels");
			return list;
		}

		// Token: 0x06000EF9 RID: 3833 RVA: 0x0005EFC4 File Offset: 0x0005D1C4
		internal static List<Panel> \u000A(UIDocument \u001F, Document \u000A)
		{
			\u0014\u0002.\u0017\u0002 u0017_u = new \u0014\u0002.\u0017\u0002();
			List<Panel> list = \u0008\u001E\u0019.\u000A();
			ElementClassFilter u000A = \u000A\u0018\u001D.\u000A(\u001E\u0011\u000A.\u000A(\u001A\u0005\u000E.\u001F()));
			u0017_u.\u001F = \u000F\u000B\u0004.\u0007(\u001F);
			FilteredElementCollector u001F = \u0020\u0011\u000A.\u000A(\u000A);
			try
			{
				Element element = Enumerable.FirstOrDefault<Element>(\u0014\u0011\u000A.\u0007(u001F, u000A), new Func<Element, bool>(u0017_u.\u000A));
				if (element != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u0002.\u000A(UIDocument, Document)).MethodHandle;
					}
					Panel panel = \u000D\u001E\u0019.\u000A();
					\u001C\u001E\u0019.\u000A(panel, element);
					\u0003\u001E\u0019.\u000A(panel, \u0005\u001E\u000A.\u000A(element));
					\u001B\u001E\u0019.\u000A(panel, true);
					PanelScheduleView panelScheduleView = \u000C\u0005\u000E.\u001F(element);
					\u000F\u001E\u0019.\u000A(panel, panelScheduleView);
					\u0002\u001E\u0019.\u000A(panel, \u0006\u001E\u0019.\u000A(panelScheduleView));
					\u0005\u001E\u0019.\u000A(list, panel);
				}
			}
			catch (Exception u000A2)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Models\\CollectPanels.cs", "GetActivePanel");
			}
			return list;
		}

		// Token: 0x06000EFA RID: 3834 RVA: 0x0005F0C8 File Offset: 0x0005D2C8
		internal static List<Equipment> \u0007(Document \u001F)
		{
			List<Equipment> list = \u0015\u001E\u0019.\u000A();
			ElementClassFilter u000A = \u000A\u0018\u001D.\u000A(\u001E\u0011\u000A.\u000A(\u001A\u0005\u000E.\u001F()));
			FilteredElementCollector u001F = \u0020\u0011\u000A.\u000A(\u001F);
			\u0014\u0011\u000A.\u0007(u001F, u000A);
			List<Equipment> result;
			try
			{
				if (\u000E\u001E\u0019.\u000A(u001F) == 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u0002.\u0007(Document)).MethodHandle;
					}
					result = list;
				}
				else
				{
					IEnumerator<Element> enumerator = \u0009\u000C\u0004.\u000A(u001F);
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							object u001F2 = \u0001\u000C\u0004.\u000A(enumerator);
							Equipment equipment = \u000C\u001E\u0019.\u000A();
							\u001A\u001E\u0019.\u000A(equipment, false);
							PanelScheduleView u001F3 = \u000C\u0005\u000E.\u001F(u001F2);
							\u0014\u001E\u0019.\u000A(equipment, \u0013\u001E\u0019.\u000A(u001F3));
							\u0020\u001E\u0019.\u000A(equipment, \u0011\u0017\u000A.\u0007(\u001F, \u0017\u001E\u0019.\u000A(equipment)));
							\u001E\u001E\u0019.\u000A(equipment, \u0005\u001E\u000A.\u000A(\u001D\u001E\u0019.\u000A(equipment)));
							\u0011\u001E\u0019.\u000A(list, equipment);
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
					result = list;
				}
			}
			catch (Exception u000A2)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Models\\CollectPanels.cs", "GetPanelEquipName");
				result = list;
			}
			return result;
		}

		// Token: 0x06000EFB RID: 3835 RVA: 0x0005F20C File Offset: 0x0005D40C
		private static PanelSectionPart \u001D(PanelScheduleView \u001F, SectionType \u000A, string \u0007)
		{
			PanelSectionPart panelSectionPart = \u0004\u0020\u0019.\u000A();
			\u001D\u0020\u0019.\u000A(panelSectionPart, \u000A);
			\u0007\u0020\u0019.\u000A(panelSectionPart, \u001F);
			TableSectionData u001F = \u000A\u0020\u0019.\u000A(\u001F, \u000A);
			\u001F\u0020\u0019.\u000A(panelSectionPart, \u000F\u0004\u0004.\u000A(u001F));
			\u0009\u001E\u0019.\u000A(panelSectionPart, \u0002\u0004\u0004.\u000A(u001F));
			\u0001\u001E\u0019.\u000A(panelSectionPart, \u0007);
			return panelSectionPart;
		}

		// Token: 0x02000866 RID: 2150
		[CompilerGenerated]
		private sealed class \u0017\u0002
		{
			// Token: 0x06004ED7 RID: 20183 RVA: 0x001E1788 File Offset: 0x001DF988
			internal bool \u000A(Element \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), \u0005\u001E\u000A.\u000A(this.\u001F));
			}

			// Token: 0x0400214D RID: 8525
			public View \u001F;
		}
	}
}

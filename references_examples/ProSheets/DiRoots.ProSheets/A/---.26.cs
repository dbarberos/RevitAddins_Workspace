using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using ProSheets.Models;

namespace A
{
	// Token: 0x020000D3 RID: 211
	internal static class \u001F\u001F\u0018
	{
		// Token: 0x06000B47 RID: 2887 RVA: 0x00044E08 File Offset: 0x00043008
		internal unsafe static void \u000C(Document \u000C, ref string \u0018)
		{
			string text = "IssueDate";
			string text2 = "CurrentRevisionDate";
			List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
			try
			{
				while (\u0019\u000E\u0018.\u0018(ref enumerator))
				{
					SheetInfo sheetInfo = \u000C\u000C\u0014.\u0018(ref enumerator);
					\u0003\u001B\u0014.\u0018(sheetInfo, \u0018);
					View view = \u0018\u0002\u000F.\u000C(\u0003\u0004\u0018.\u0018(\u000C, \u0015\u0005\u0018.\u0014(sheetInfo)));
					if (\u000A\u0017\u0014.\u0018(\u000D\u000C\u0003.\u0014(sheetInfo), "%DrawingName%"))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u001F\u0018.\u000C(Document, string*)).MethodHandle;
						}
						\u0003\u001B\u0014.\u0018(sheetInfo, \u0010\u000B\u0014.\u0018(\u000D\u000C\u0003.\u0014(sheetInfo), "%DrawingName%", \u000C\u000A\u0018.\u001A(\u000C, sheetInfo, view)));
					}
					if (\u001D\u0020\u0016.\u0018(\u000D\u000C\u0003.\u0014(sheetInfo), text.\u0018()))
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
						string u = \u000C\u000A\u0018.\u0008(\u000C, view, -1006322L, true);
						\u0003\u001B\u0014.\u0018(sheetInfo, \u000E\u0020\u0018.\u0014(\u000D\u000C\u0003.\u0014(sheetInfo), text, u));
					}
					if (\u001D\u0020\u0016.\u0018(\u000D\u000C\u0003.\u0014(sheetInfo), text2.\u0018()))
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
						string u2 = \u000C\u000A\u0018.\u0008(\u000C, view, -1007415L, true);
						\u0003\u001B\u0014.\u0018(sheetInfo, \u000E\u0020\u0018.\u0014(\u000D\u000C\u0003.\u0014(sheetInfo), text2, u2));
					}
					if (\u000A\u0017\u0014.\u0018(\u000D\u000C\u0003.\u0014(sheetInfo), "%CurrentRevision%"))
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
						\u0003\u001B\u0014.\u0018(sheetInfo, \u0010\u000B\u0014.\u0018(\u000D\u000C\u0003.\u0014(sheetInfo), "%CurrentRevision%", \u000C\u000A\u0018.\u0008(\u000C, view, -1007412L, false)));
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
			\u0018 = \u0001\u0019\u0014.\u0018(\u0018, text.\u0018(), "");
			\u0018 = \u0001\u0019\u0014.\u0018(\u0018, text2.\u0018(), "");
			\u0018 = \u0010\u000B\u0014.\u0018(\u0018, "%CurrentRevision%", "");
		}
	}
}

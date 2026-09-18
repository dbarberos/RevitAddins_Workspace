using System;
using Autodesk.Revit.DB;
using DiRoots.One.ViewAligner.Data.Models;
using DiRoots.Revit.DataCollectors.Models;

namespace A
{
	// Token: 0x020000D2 RID: 210
	internal class \u000E\u0019
	{
		// Token: 0x060007F2 RID: 2034 RVA: 0x0002DF4C File Offset: 0x0002C14C
		public static ViewInfo \u001F(IBrowserNode \u001F)
		{
			FolderNode folderNode = \u0009\u001D\u000E.\u001F(\u001F);
			ViewInfo result;
			if (folderNode == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u0019.\u001F(IBrowserNode)).MethodHandle;
				}
				ViewElementNode<ViewSheet> viewElementNode = \u001F\u0004\u000E.\u001F(\u001F);
				if (viewElementNode == null)
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
					throw \u0020\u001B\u001D.\u000A(\u0002\u0013\u000A.\u000A(\u0017\u001B\u001D.\u000A(), " ", \u0003\u0012\u001D.\u000A(\u0003\u0011\u000A.\u0007(\u001F))));
				}
				result = \u000E\u0019.\u001F(viewElementNode);
			}
			else
			{
				result = \u000E\u0019.\u001F(folderNode);
			}
			return result;
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0002DFD4 File Offset: 0x0002C1D4
		public static ViewInfo \u001F(ViewElementNode<ViewSheet> \u001F)
		{
			ViewSheet u001F = \u0014\u001B\u001D.\u000A(\u001F);
			ViewInfo viewInfo = \u000E\u0019.\u001F(u001F);
			\u001E\u0008\u001D.\u000A(viewInfo, \u0020\u0008\u001D.\u000A(u001F));
			return viewInfo;
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0002E000 File Offset: 0x0002C200
		public static ViewInfo \u001F(View \u001F)
		{
			ViewType viewType = \u001C\u001C\u0007.\u0007(\u001F);
			ViewInfo viewInfo = \u001D\u0011\u001D.\u000A();
			\u0007\u0011\u001D.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)));
			\u000A\u0011\u001D.\u000A(viewInfo, \u0005\u001E\u000A.\u000A(\u001F));
			ViewTypeInfo viewTypeInfo = \u001F\u0011\u001D.\u000A();
			\u0009\u001B\u001D.\u000A(viewTypeInfo, viewType);
			\u0001\u001B\u001D.\u000A(viewTypeInfo, viewType.\u001F());
			\u0015\u001B\u001D.\u000A(viewInfo, viewTypeInfo);
			\u001A\u001B\u001D.\u000A(viewInfo, \u000C\u001B\u001D.\u000A(\u001F));
			\u0013\u001B\u001D.\u000A(viewInfo, \u0016\u001F\u000E.\u001F(\u001F) != \u000B\u001F\u000E.\u001F);
			return viewInfo;
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x0002E088 File Offset: 0x0002C288
		public static ViewInfo \u001F(Document \u001F, Viewport \u000A)
		{
			ViewInfo viewInfo = \u000E\u0019.\u001F(\u0005\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u001F, \u0019\u0011\u001D.\u000A(\u000A))));
			\u0004\u0011\u001D.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u000A)));
			return viewInfo;
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0002E0C8 File Offset: 0x0002C2C8
		public static ViewInfo \u001F(Document \u001F, ScheduleSheetInstance \u000A)
		{
			ViewInfo viewInfo = \u000E\u0019.\u001F(\u0001\u001D\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u001F, \u0018\u0011\u001D.\u000A(\u000A))));
			\u0004\u0011\u001D.\u000A(viewInfo, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u000A)));
			return viewInfo;
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0002E108 File Offset: 0x0002C308
		private static ViewInfo \u001F(FolderNode \u001F)
		{
			ViewInfo viewInfo = \u001D\u0011\u001D.\u000A();
			\u0007\u0011\u001D.\u000A(viewInfo, 1L);
			\u000A\u0011\u001D.\u000A(viewInfo, \u0005\u0011\u001D.\u000A(\u001F));
			return viewInfo;
		}
	}
}

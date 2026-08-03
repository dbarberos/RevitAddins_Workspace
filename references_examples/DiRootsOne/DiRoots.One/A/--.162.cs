using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;

namespace A
{
	// Token: 0x020002A2 RID: 674
	internal class \u0002\u0008 : ExternalEventInfo
	{
		// Token: 0x17000748 RID: 1864
		// (get) Token: 0x06001A76 RID: 6774 RVA: 0x000ABD94 File Offset: 0x000A9F94
		// (set) Token: 0x06001A77 RID: 6775 RVA: 0x000ABDA8 File Offset: 0x000A9FA8
		public Action<string> ActionToRun { get; set; }

		// Token: 0x17000749 RID: 1865
		// (get) Token: 0x06001A78 RID: 6776 RVA: 0x000ABDBC File Offset: 0x000A9FBC
		// (set) Token: 0x06001A79 RID: 6777 RVA: 0x000ABDD0 File Offset: 0x000A9FD0
		public string FilePath { get; set; }

		// Token: 0x06001A7A RID: 6778 RVA: 0x000ABDE4 File Offset: 0x000A9FE4
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\ImportFromExcelEvent.cs", "Execute");
			TransactionGroup transactionGroup = \u000E\u000E\u001D.\u000A(\u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app)));
			try
			{
				\u0010\u000E\u001D.\u000A(transactionGroup, "Transaction Group");
				Action<string> action = \u0002\u0016\u0016.\u000A(this);
				if (action == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0008.Execute(UIApplication)).MethodHandle;
					}
				}
				else
				{
					\u000B\u000C\u001D.\u000A(action, \u000B\u0016\u0016.\u000A(this));
				}
				\u001A\u0017\u0007.\u000A(transactionGroup);
			}
			finally
			{
				if (transactionGroup != null)
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
					\u001F\u0017\u000A.\u000A(transactionGroup);
				}
			}
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\ImportFromExcelEvent.cs", "Execute");
		}

		// Token: 0x06001A7B RID: 6779 RVA: 0x000ABEA0 File Offset: 0x000AA0A0
		public static void \u001C\u0005(ExternalEventInfo \u001F)
		{
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), \u001F);
			\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
		}

		// Token: 0x04000A90 RID: 2704
		[CompilerGenerated]
		private Action<string> \u0016\u0007;

		// Token: 0x04000A91 RID: 2705
		[CompilerGenerated]
		private string \u001F\u000A;
	}
}

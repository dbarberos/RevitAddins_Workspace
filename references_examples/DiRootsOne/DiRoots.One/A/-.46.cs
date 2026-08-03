using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using DiRoots.One.Commons.ExtensibleStorage;
using DiRoots.RoomPro.Models;

namespace A
{
	// Token: 0x020000A0 RID: 160
	internal class \u000B\u0004 : ExternalEventInfo
	{
		// Token: 0x06000683 RID: 1667 RVA: 0x00025710 File Offset: 0x00023910
		public \u000B\u0004(IRevitEntity \u001F)
		{
			this.\u0003 = \u001F;
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x0002572C File Offset: 0x0002392C
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Core\\ExternalEvents\\CustomActionEvent.cs", "Execute");
			Document u001F = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app));
			\u0013\u001D u0013_u001D = new \u0013\u001D(u001F);
			Transaction transaction = \u001D\u0014\u0007.\u000A(u001F, \u0014\u0001\u000A.\u000A(this));
			try
			{
				\u0007\u0014\u0007.\u000A(transaction);
				CalloutUserSettings calloutUserSettings = \u001B\u0007\u000E.\u001F(this.\u0003);
				if (calloutUserSettings != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B\u0004.Execute(UIApplication)).MethodHandle;
					}
					\u0015\u0019\u001D.\u000A(u0013_u001D.\u0017(), calloutUserSettings);
				}
				else
				{
					SectionAndElevationUserSettings sectionAndElevationUserSettings = \u0011\u0007\u000E.\u001F(this.\u0003);
					if (sectionAndElevationUserSettings != null)
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
						\u001A\u0019\u001D.\u000A(u0013_u001D.\u0017(), sectionAndElevationUserSettings);
					}
				}
				\u001B\u0001\u000A.\u000A(transaction);
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u001E\u000A\u0007.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Core\\ExternalEvents\\CustomActionEvent.cs", "Execute");
				\u001F\u0014\u0007.\u000A(transaction);
			}
			finally
			{
				if (transaction != null)
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
					\u001F\u0017\u000A.\u000A(transaction);
				}
			}
			\u000F\u0012\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Core\\ExternalEvents\\CustomActionEvent.cs", "Execute");
		}

		// Token: 0x04000296 RID: 662
		private readonly IRevitEntity \u0003;
	}
}

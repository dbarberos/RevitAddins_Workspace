using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using DiRoots.Licensing;
using DiRoots.Module.Resolver;
using DiRoots.One.Commons.Core;
using DiRoots.One.Commons.Licensing;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.One
{
	// Token: 0x020000BC RID: 188
	public class Main : DiRootsExternalApplication
	{
		// Token: 0x06000740 RID: 1856 RVA: 0x0002A3F8 File Offset: 0x000285F8
		public Main()
		{
			AssemblyResolverService assemblyResolverService = new AssemblyResolverService();
			\u001D\u000F\u001D.\u000A(assemblyResolverService, \u001E\u0011\u000A.\u000A(\u0010\u001D\u000E.\u001F()), "DiRoots.One");
			\u0007\u000F\u001D.\u000A().RegisterSingleton<IAssemblyResolverService, AssemblyResolverService>(assemblyResolverService);
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x0002A43C File Offset: 0x0002863C
		public override void OnShutdown()
		{
			\u0018\u000F\u001D.\u000A(this);
			\u001E\u0007\u000A.\u0008();
			\u001E\u0007\u000A.\u0011();
			\u0004\u000F\u001D.\u000A(\u0019\u000F\u001D.\u000A());
			\u0004\u000F\u001D.\u000A(\u0007\u000F\u001D.\u000A());
			\u0007\u0018.\u001D();
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x0002A478 File Offset: 0x00028678
		public override void OnStartup()
		{
			\u0007\u0012\u001D.\u000A(this, "DiRoots.One");
			\u000A\u0012\u001D.\u000A(this, "DiRootsOne");
			\u001F\u0012\u001D.\u000A("DiRoots.One");
			\u0009\u000F\u001D.\u000A("DiRoots.One");
			\u0001\u000F\u001D.\u000A("https://docs.dirootsone.diroots.com");
			\u0015\u000F\u001D.\u000A("https://diroots.com/revit-plugins/dirootsone/troubleshooting");
			LicenseEventHandler licenseEventHandler = \u000C\u000F\u001D.\u000A(\u0014\u000F\u001D.\u000A(this));
			\u0019\u000F\u001D.\u000A().RegisterSingleton<LicenseEventHandler>(licenseEventHandler);
			\u0013\u000F\u001D.\u000A(\u001A\u000F\u001D.\u000A(this));
			\u0017\u000F\u001D.\u000A(\u0014\u000F\u001D.\u000A(this), \u001E\u000F\u001D.\u000A(this));
			\u0020\u000F\u001D.\u000A(this);
			UIControlledApplication uicontrolledApplication = \u001E\u000F\u001D.\u000A(this);
			UIApplication u001F = \u0011\u000F\u001D.\u000A(this);
			Version version = \u0008\u000F\u001D.\u000A(\u001B\u000F\u001D.\u000A(\u000B\u000F\u001D.\u000A()));
			string text;
			if (version == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Main.OnStartup()).MethodHandle;
				}
				text = \u000F\u0015\u0010.\u001F;
			}
			else
			{
				text = \u001A\u000C\u000A.\u000A(version);
			}
			string productVersion = text;
			string revitVersion = \u001A\u000C\u000A.\u000A(\u000E\u000F\u001D.\u000A(\u001A\u0007\u001D.\u000A(u001F)));
			string userHostName = \u0010\u000F\u001D.\u000A(\u001A\u0007\u001D.\u000A(u001F));
			string userHostId = \u000D\u000F\u001D.\u000A(\u001A\u0007\u001D.\u000A(u001F));
			string languageCode = \u001C\u000F\u001D.\u000A();
			Startup.Initialize<MainWindow>("DiRoots.One", "DiRootsOne", productVersion, revitVersion, false, \u0003\u000F\u001D.\u000A(), delegate(Exception ex)
			{
				\u001D\u0012\u001D.\u000A(ex, \u0014\u000F\u001D.\u000A(this));
			}, userHostName, userHostId, languageCode, \u000F\u0015\u0010.\u001F);
			\u0012\u000F\u001D.\u000A(licenseEventHandler);
			\u000F\u000F\u001D.\u000A(true);
			string u000A = "DiRootsOne";
			int u = \u0006\u000F\u001D.\u000A();
			\u0002\u000F\u001D.\u000A(uicontrolledApplication, u000A);
			string u001D = \u0016\u000F\u001D.\u000A(\u000B\u000F\u001D.\u000A());
			new \u001D\u000F().\u0007(uicontrolledApplication, u000A, "Data IO", u001D, u);
			new \u001F\u0016().\u0007(uicontrolledApplication, u000A, "Data IO", u001D, u);
			new \u0014\u000E().\u0007(uicontrolledApplication, u000A, "Views and Sheets", u001D, u);
			new \u0003\u001C\u000A().\u0007(uicontrolledApplication, u000A, "Manage", u001D, u);
			new \u0008\u001D\u000A().\u0007(uicontrolledApplication, u000A, "Manage", u001D, u);
			new \u0001\u000B\u000A().\u0007(uicontrolledApplication, u000A, "Find", u001D, u);
			new \u0012\u0015().\u0007(uicontrolledApplication, u000A, "Utility", u001D, u);
			new \u001E\u0007\u000A().\u0016(uicontrolledApplication, u000A, " Point Cloud", u001D, u);
			new \u000E\u0016\u000A().\u0007(uicontrolledApplication, u000A, "Data IO", u001D, u);
			new \u0004\u0007\u000A().\u0007(uicontrolledApplication, u000A, "Views and Sheets", u001D, u);
			\u0004\u0015.\u001D(uicontrolledApplication, u000A, "Utility", u001D, u);
			\u0004\u0015.\u001D(uicontrolledApplication, "Modify", "Utility", u001D, u);
			\u0001\u0004.\u0007(uicontrolledApplication, u000A, "Views and Sheets", u001D, u);
			object u001F2 = uicontrolledApplication;
			EventHandler<ThemeChangedEventArgs> u000A2;
			if ((u000A2 = Main.<>O.<0>__UiControlledApp_ThemeChanged) == null)
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
				u000A2 = (Main.<>O.<0>__UiControlledApp_ThemeChanged = new EventHandler<ThemeChangedEventArgs>(Main.UiControlledApp_ThemeChanged));
			}
			\u0005\u000F\u001D.\u000A(u001F2, u000A2);
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x0002A73C File Offset: 0x0002893C
		private static void UiControlledApp_ThemeChanged(object sender, ThemeChangedEventArgs e)
		{
			int u001F = \u0006\u000F\u001D.\u000A();
			\u001D\u000F.\u001D(u001F);
			\u001F\u0016.\u0004(u001F);
			\u0014\u000E.\u001D(u001F);
			\u0003\u001C\u000A.\u001D(u001F);
			\u0008\u001D\u000A.\u001D(u001F);
			\u0001\u000B\u000A.\u001D(u001F);
			\u0012\u0015.\u001D(u001F);
			\u001E\u0007\u000A.\u001B(u001F);
			\u0004\u0015.\u0004(u001F);
		}

		// Token: 0x040002E9 RID: 745
		private static string _pluginName;

		// Token: 0x020007D1 RID: 2001
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04001FBC RID: 8124
			public static EventHandler<ThemeChangedEventArgs> <0>__UiControlledApp_ThemeChanged;
		}
	}
}

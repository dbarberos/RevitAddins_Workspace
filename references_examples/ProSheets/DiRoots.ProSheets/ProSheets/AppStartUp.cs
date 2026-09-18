using System;
using System.Threading;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using DiRoots.Module.Resolver;
using DiRoots.One.Commons.Core;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Helpers;

namespace ProSheets
{
	// Token: 0x0200005A RID: 90
	public sealed class AppStartUp : DiRootsExternalApplication
	{
		// Token: 0x06000446 RID: 1094 RVA: 0x00016CA4 File Offset: 0x00014EA4
		public override void OnShutdown()
		{
			\u000F\u0011\u0014.\u0018(this);
			\u0003\u0011\u0014.\u0018(\u0016\u0011\u0014.\u0018(this), new EventHandler<DialogBoxShowingEventArgs>(this.Application_DialogBoxShowing));
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00016CD0 File Offset: 0x00014ED0
		public override void OnStartup()
		{
			try
			{
				AppStartUp.<>c__DisplayClass1_0 CS$<>8__locals1 = \u000E\u0011\u0014.\u0018();
				\u0004\u0020\u0018.\u000C();
				\u0005\u0011\u0014.\u0018(this, "ProSheets");
				\u001B\u0011\u0014.\u0018(this, "ProSheets");
				\u0001\u0011\u0014.\u0018("DiRoots.ProSheets");
				\u0008\u0011\u0014.\u0018(\u001E\u0011\u0014.\u0018(\u0016\u0011\u0014.\u0018(this)), new EventHandler<DocumentOpenedEventArgs>(this.DocumentOpened));
				\u0006\u0011\u0014.\u0018("https://docs.prosheets.diroots.com");
				\u0010\u0011\u0014.\u0018("https://diroots.com/revit-plugins/prosheets/troubleshooting");
				AssemblyResolverService assemblyResolverService = \u0007\u0011\u0014.\u0018();
				\u0019\u0011\u0014.\u0018(assemblyResolverService, \u000A\u001D\u0018.\u0018(\u001E\u001A\u000F.\u000C()), \u0004\u0011\u0014.\u0018(this));
				\u0004\u0005\u0018.\u0018().RegisterSingleton<IAssemblyResolverService, AssemblyResolverService>(assemblyResolverService);
				\u000B\u0011\u0014.\u0018("DiRoots");
				\u001A\u0011\u0014.\u0018(\u0004\u0011\u0014.\u0018(this), \u0016\u0011\u0014.\u0018(this));
				\u001D\u0011\u0014.\u0018(this);
				\u0002\u0011\u0014.\u0018(\u0004\u0011\u0014.\u0018(this));
				CS$<>8__locals1.revitVersion = \u0017\u0011\u0014.\u0018(\u001E\u0011\u0014.\u0018(\u0016\u0011\u0014.\u0018(this)));
				\u001F\u0009\u0018.\u0003(\u0016\u0011\u0014.\u0018(this));
				\u0011\u0011\u0014.\u0018("ProSheets", "ProSheets", \u0015\u0011\u0014.\u0018(this));
				\u001F\u0011\u0014.\u0018(true);
				\u0020\u0011\u0014.\u0018();
				\u000A\u0011\u0014.\u0018(\u0016\u0011\u0014.\u0018(this), new EventHandler<DialogBoxShowingEventArgs>(this.Application_DialogBoxShowing));
				string u = "DiRootsOne";
				\u0009\u0011\u0014.\u0018(\u0016\u0011\u0014.\u0018(this), u);
				\u0011\u0009\u0018.\u0014();
				\u0013\u0011\u0014.\u0018(\u001A\u0009\u0018.\u0018);
				ParameterizedThreadStart u000C;
				if ((u000C = AppStartUp.<>c.<>9__1_0) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(AppStartUp.OnStartup()).MethodHandle;
					}
					u000C = (AppStartUp.<>c.<>9__1_0 = delegate(object un)
					{
						\u001C\u000A\u000F.\u0018();
					});
				}
				\u000D\u0011\u0014.\u0018(\u001C\u0011\u0014.\u0018(u000C));
				if (\u0014\u001F\u0018.\u0003())
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
					\u000D\u0011\u0014.\u0018(\u001C\u0011\u0014.\u0018(delegate(object unused)
					{
						\u001A\u0009\u0018.\u0014(CS$<>8__locals1.revitVersion);
					}));
				}
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(\u0012\u0011\u0014.\u0018().GetService<ICustomLogger>(false), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\AppStartUp.cs", "OnStartup");
				throw;
			}
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00016ED4 File Offset: 0x000150D4
		private void DocumentOpened(object sender, DocumentOpenedEventArgs e)
		{
			Document document = \u0014\u0015\u0014.\u0018(e);
			if (document != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AppStartUp.DocumentOpened(object, DocumentOpenedEventArgs)).MethodHandle;
				}
				if (!\u0018\u0015\u0014.\u0018())
				{
					\u000C\u0015\u0014.\u0018(\u001D\u0020\u0018.\u0003(document));
					return;
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
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00016F24 File Offset: 0x00015124
		private void Application_DialogBoxShowing(object sender, DialogBoxShowingEventArgs e)
		{
			try
			{
				if (\u0018\u0015\u0014.\u0018())
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(AppStartUp.Application_DialogBoxShowing(object, DialogBoxShowingEventArgs)).MethodHandle;
					}
					TaskDialogShowingEventArgs taskDialogShowingEventArgs = \u0017\u001A\u000F.\u000C(e);
					if (taskDialogShowingEventArgs != null)
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
						int num = -1;
						try
						{
							if (\u000D\u0015\u0014.\u0018() != null)
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
								num = \u0012\u0015\u0014.\u0018(\u000D\u0015\u0014.\u0018(), \u000F\u0015\u0014.\u0018(taskDialogShowingEventArgs), \u0016\u0015\u0014.\u0018(taskDialogShowingEventArgs));
							}
						}
						catch (Exception u)
						{
							\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\AppStartUp.cs", "Application_DialogBoxShowing");
						}
						if (num == -1)
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
							\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), \u000D\u001E\u0018.\u0018("DialogId:", \u000F\u0015\u0014.\u0018(taskDialogShowingEventArgs)), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\AppStartUp.cs", "Application_DialogBoxShowing");
							\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), \u0016\u0015\u0014.\u0018(taskDialogShowingEventArgs), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\AppStartUp.cs", "Application_DialogBoxShowing");
							\u0003\u0015\u0014.\u0018(e, 8);
						}
						else
						{
							\u0003\u0015\u0014.\u0018(e, num);
						}
					}
				}
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(\u0012\u0011\u0014.\u0018().GetService<ICustomLogger>(false), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\AppStartUp.cs", "Application_DialogBoxShowing");
			}
		}

		// Token: 0x0200016E RID: 366
		public class AvailableIfOpenDoc : IExternalCommandAvailability
		{
			// Token: 0x06001093 RID: 4243 RVA: 0x0005A97C File Offset: 0x00058B7C
			public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
			{
				UIDocument uidocument = \u001F\u001F\u0014.\u0018(applicationData);
				if (uidocument == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(AppStartUp.AvailableIfOpenDoc.IsCommandAvailable(UIApplication, CategorySet)).MethodHandle;
					}
					return false;
				}
				Document document = \u0017\u0005\u0018.\u0003(uidocument);
				bool? flag2;
				if (document == null)
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
					bool? flag;
					\u000B\u0004\u000F.\u000C(ref flag);
					flag2 = flag;
				}
				else
				{
					flag2 = new bool?(\u0012\u000A\u000F.\u0018(document));
				}
				bool? flag3 = flag2;
				bool flag4 = false;
				return \u000C\u0007\u0018.\u0018(ref flag3) == flag4 & \u0006\u0007\u0003.\u0018(ref flag3);
			}
		}
	}
}

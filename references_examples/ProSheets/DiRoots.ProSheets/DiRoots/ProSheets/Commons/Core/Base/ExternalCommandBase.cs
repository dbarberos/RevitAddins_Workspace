using System;
using System.Windows;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.Module.Resolver;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Interfaces;
using DiRoots.Prosheets.Commons.Models;

namespace DiRoots.Prosheets.Commons.Core.Base
{
	// Token: 0x02000059 RID: 89
	public abstract class ExternalCommandBase : IExternalCommand
	{
		// Token: 0x0600043E RID: 1086 RVA: 0x000169D8 File Offset: 0x00014BD8
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			return this.\u0003(commandData);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x000169F0 File Offset: 0x00014BF0
		private Result \u0003(ExternalCommandData \u000C)
		{
			Result result;
			try
			{
				\u0001\u001F\u0014.\u0018(\u0004\u0005\u0018.\u0018().GetService<IAssemblyResolverService>(false));
				\u0008\u0017\u0018.\u0018(\u001A\u001F\u0014.\u0018(this._pluginInfo), \u000D\u001E\u0018.\u0018("Version Build ", \u0008\u001F\u0014.\u0018()), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Commons\\Core\\Base\\ExternalCommandBase.cs", "Execute");
				\u0008\u0017\u0018.\u0018(\u001A\u001F\u0014.\u0018(this._pluginInfo), \u000D\u001E\u0018.\u0018("Revit Version ", \u0006\u001F\u0014.\u0018()), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Commons\\Core\\Base\\ExternalCommandBase.cs", "Execute");
				Version u = \u000C\u001F\u0014.\u0018(\u0018\u001F\u0014.\u0018(\u0014\u001F\u0014.\u0018(\u000A\u001D\u0018.\u0018(\u0015\u001A\u000F.\u000C()))));
				ICustomLogger customLogger = \u001A\u001F\u0014.\u0018(this._pluginInfo);
				if (customLogger == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ExternalCommandBase.\u0003(ExternalCommandData)).MethodHandle;
					}
				}
				else
				{
					\u0008\u0017\u0018.\u0018(customLogger, \u001C\u001E\u0018.\u0018("Plugin Version {0}", u), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Commons\\Core\\Base\\ExternalCommandBase.cs", "Execute");
				}
				if (!this.\u0016())
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
					result = -1;
				}
				else
				{
					this._uiDoc = \u001F\u001F\u0014.\u0018(\u0010\u001F\u0014.\u0018(\u000C));
					this._uiApp = \u0010\u001F\u0014.\u0018(\u000C);
					\u0007\u001F\u0014.\u0018(this._uiApp);
					\u0017\u001F\u0018.\u0014(this._uiApp);
					\u0019\u001F\u0014.\u0018();
					result = \u000B\u001F\u0014.\u0018(this);
				}
			}
			catch (Exception u2)
			{
				ICustomLogger customLogger2 = \u001A\u001F\u0014.\u0018(this._pluginInfo);
				if (customLogger2 == null)
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
				}
				else
				{
					\u001E\u001E\u0018.\u0018(customLogger2, u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Commons\\Core\\Base\\ExternalCommandBase.cs", "Execute");
				}
				\u001C\u000A\u0014.\u0018(\u0004\u001F\u0014.\u0018(this._pluginInfo), u2, true);
				\u001D\u001F\u0014.\u0018(this);
				result = -1;
			}
			finally
			{
				\u0002\u001F\u0014.\u0018(\u0004\u001F\u0014.\u0018(this._pluginInfo));
			}
			return result;
		}

		// Token: 0x06000440 RID: 1088
		public abstract Result Execute();

		// Token: 0x06000441 RID: 1089 RVA: 0x00016BCC File Offset: 0x00014DCC
		internal bool \u0016()
		{
			return \u001B\u001F\u0014.\u0018();
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00016BE0 File Offset: 0x00014DE0
		protected void SetWindowContext(Window window)
		{
			ActiveDocumentHandler service = \u0004\u0005\u0018.\u0018().GetService<ActiveDocumentHandler>(false);
			if (service == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExternalCommandBase.SetWindowContext(Window)).MethodHandle;
				}
			}
			else
			{
				\u000E\u001F\u0014.\u0018(service, this._uiApp, window, \u0017\u0005\u0018.\u0014(this._uiDoc));
			}
			\u0005\u001F\u0014.\u0018(this._uiApp, window);
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00016C3C File Offset: 0x00014E3C
		public bool IsLicenseValid()
		{
			if (!\u000C\u0011\u0014.\u0018())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExternalCommandBase.IsLicenseValid()).MethodHandle;
				}
				\u0018\u0011\u0014.\u0018(\u0014\u0011\u0014.\u0018(), \u001F\u0002\u000F.\u000C);
			}
			return \u000C\u0011\u0014.\u0018();
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00016C80 File Offset: 0x00014E80
		public virtual void OnException()
		{
		}

		// Token: 0x0400016E RID: 366
		protected UIDocument _uiDoc;

		// Token: 0x0400016F RID: 367
		protected UIApplication _uiApp;

		// Token: 0x04000170 RID: 368
		protected PluginInfo _pluginInfo;
	}
}

using System;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;

namespace TransferSingleApp
{
	// Token: 0x02000002 RID: 2
	[Transaction(1)]
	[Regeneration(0)]
	[Journaling(1)]
	internal class AdskApplication : IExternalApplication
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public Result OnStartup(UIControlledApplication application)
		{
			AdskApplication.RevitVersion = application.ControlledApplication.VersionNumber;
			this.config = SaveXMLConfigTab.Lee_Configuracion_de_XML();
			if (this.config.cf_sw_TabRevit)
			{
				AdskApplication.AddToDefault = true;
			}
			if (this.config.cf_sw_TabJOTools)
			{
				AdskApplication.ribon_name = "JOTools";
			}
			if (this.config.cf_sw_TabOtro)
			{
				AdskApplication.ribon_name = this.config.cf_TabOtro;
			}
			try
			{
				ControlledApplication controlledApplication = application.ControlledApplication;
			}
			catch (Exception)
			{
				return -1;
			}
			RibbonPanel ribbonPanel;
			if (AdskApplication.AddToDefault)
			{
				ribbonPanel = application.CreateRibbonPanel("TransferSingle");
			}
			else
			{
				try
				{
					application.CreateRibbonTab(AdskApplication.ribon_name);
				}
				catch
				{
				}
				ribbonPanel = application.CreateRibbonPanel(AdskApplication.ribon_name, "TransferSingle");
			}
			PushButton pushButton = ribbonPanel.AddItem(new PushButtonData(AdskApplication.applicationName2, AdskApplication.applicationName2, AdskApplication.ExecutingAssemblyPath, "TransferSingleApp.MassLoadFamilies")) as PushButton;
			pushButton.ToolTip = "Mass Load Families From Selected Folder";
			pushButton.LargeImage = this.BmpImageSource("TransferSingleApp.Resources.LoadFamily32x32.ico");
			pushButton.Image = this.BmpImageSource("TransferSingleApp.Resources.LoadFamily16x16.ico");
			PushButton pushButton2 = ribbonPanel.AddItem(new PushButtonData(AdskApplication.applicationName3, AdskApplication.applicationName3, AdskApplication.ExecutingAssemblyPath, "TransferSingleApp.MassSaveFamilies")) as PushButton;
			pushButton2.ToolTip = "Mass Save Families To Selected Folder";
			pushButton2.LargeImage = this.BmpImageSource("TransferSingleApp.Resources.SaveFamily32x32.ico");
			pushButton2.Image = this.BmpImageSource("TransferSingleApp.Resources.SaveFamily16x16.ico");
			PushButton pushButton3 = ribbonPanel.AddItem(new PushButtonData(AdskApplication.applicationName1, AdskApplication.applicationName1, AdskApplication.ExecutingAssemblyPath, "TransferSingleApp.TransferSingleCommand")) as PushButton;
			pushButton3.ToolTip = "Transfer Standards One by One";
			pushButton3.LargeImage = this.BmpImageSource("TransferSingleApp.Resources.TransferSingle32x32.ico");
			pushButton3.Image = this.BmpImageSource("TransferSingleApp.Resources.TransferSingle16x16.ico");
			ContextualHelp contextualHelp = new ContextualHelp(2, "https://apps.autodesk.com/RVT/en/Detail/HelpDoc?appId=8481526687890452659&appLang=en&os=Win64");
			pushButton.SetContextualHelp(contextualHelp);
			pushButton2.SetContextualHelp(contextualHelp);
			pushButton3.SetContextualHelp(contextualHelp);
			return 0;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002248 File Offset: 0x00000448
		public Result OnShutdown(UIControlledApplication application)
		{
			return 0;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000224B File Offset: 0x0000044B
		private ImageSource BmpImageSource(string embeddedPath)
		{
			return new IconBitmapDecoder(base.GetType().Assembly.GetManifestResourceStream(embeddedPath), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default).Frames[0];
		}

		// Token: 0x04000001 RID: 1
		public static string ExecutingAssemblyPath = Assembly.GetExecutingAssembly().Location;

		// Token: 0x04000002 RID: 2
		public static string ExecutingAssemblyDir = Path.GetDirectoryName(AdskApplication.ExecutingAssemblyPath);

		// Token: 0x04000003 RID: 3
		public static string RevitVersion = "NoVersion";

		// Token: 0x04000004 RID: 4
		public ConfiguracionTab config = new ConfiguracionTab();

		// Token: 0x04000005 RID: 5
		public static string camino_applicacion = "";

		// Token: 0x04000006 RID: 6
		public static string camino_imagenes = "";

		// Token: 0x04000007 RID: 7
		public static string applicationName1 = "Transfer\nSingle";

		// Token: 0x04000008 RID: 8
		public static string applicationName2 = "MassLoad\nFamilies";

		// Token: 0x04000009 RID: 9
		public static string applicationName3 = "MassSave\nFamilies";

		// Token: 0x0400000A RID: 10
		public static string ribon_name = "JOTools";

		// Token: 0x0400000B RID: 11
		public static bool AddToDefault = false;
	}
}

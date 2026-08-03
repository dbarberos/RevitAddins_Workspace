using System;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Container;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Services;
using DiRoots.One.SheetGen.Core.Services;
using DiRoots.One.SheetGen.DI.Interfaces;
using DiRoots.One.SheetGen.Models.Interfaces;
using DiRoots.One.SheetGen.Profiles;
using DiRoots.One.SheetGen.Services;
using DiRoots.One.SheetGen.UI.Windows;
using DiRoots.One.SheetGen.ViewModels;
using DiRoots.Revit.SheetsAndViews;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002D8 RID: 728
	public class StartUp
	{
		// Token: 0x06001E2C RID: 7724 RVA: 0x000BEA54 File Offset: 0x000BCC54
		public void ConfigureServices()
		{
			IoC u = \u000E\u001B\u000A.\u0004;
			Func<IoC, Document> factory;
			if ((factory = StartUp.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StartUp.ConfigureServices()).MethodHandle;
				}
				factory = (StartUp.<>c.\u000A = new Func<IoC, Document>(StartUp.<>c.\u001F.\u0004));
			}
			IoC ioC = u.RegisterTransient<Document>(factory);
			Func<IoC, ICustomLogger> factory2;
			if ((factory2 = StartUp.<>c.\u0007) == null)
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
				factory2 = (StartUp.<>c.\u0007 = new Func<IoC, ICustomLogger>(StartUp.<>c.\u001F.\u0019));
			}
			IoC ioC2 = \u000E\u001A\u0016.\u000A(\u000E\u001A\u0016.\u000A(\u000E\u001A\u0016.\u000A(\u000E\u001A\u0016.\u000A(ioC.RegisterTransient<ICustomLogger>(factory2).RegisterTransient<ILoadData, PleaseWait>().RegisterTransient<IYesNoDialog, YesNoWindow>().RegisterTransient<IDuplicateSheet, DuplicateSheet>().RegisterTransient<IDuplicateSheetBulk, DuplicateSheetBulk>().RegisterTransient<IExportFinished, ExportFinished>().RegisterTransient<ISheetsParameterManager, SheetsParameters>().RegisterTransient<IParameterManager, ManageParameters>().RegisterTransient<ISheetInfoParameterService, SheetInfoParameterService>().RegisterTransient<IPlaceholderSheetParameterService, PlaceholderSheetParameterService>().RegisterTransient<ISheetParameterValueProvider, \u0007\u0014>().RegisterTransient<ISheetParametersWindowService, \u000B\u0014>().RegisterTransient<IPlaceholderParametersWindowService, \u0002\u0014>().RegisterTransient<ICreateSheetWindowsService, CreateSheetWindowsService>().RegisterTransient<ICreatePlaceholderWindowsService, CreatePlaceholderWindowsService>(), \u001E\u0011\u000A.\u000A(\u0004\u000D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0019\u000D\u000E.\u001F())).RegisterTransient<IDialogsService, \u0005\u0014>(), \u001E\u0011\u000A.\u000A(\u0018\u000D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0005\u000D\u000E.\u001F())).RegisterTransient<IReportsWindowService, \u000F\u0014>().RegisterTransient<IRenameWindow, RenameSheetsWindow>().RegisterTransient<IBuilderWindow, BuilderWindow>().RegisterTransient<INewViewSheetSet, NewViewSheetSetWindow>().RegisterTransient<IAddToViewSheetSetWindow, AddToViewSheetSetWindow>().RegisterTransient<INewProfile, NewProfileDialog>().RegisterTransient<ISelectView, SelectView>().RegisterTransient<IDuplicateView, DuplicateView>().RegisterTransient<IConfirmClearCache, ConfirmClearCaching>().RegisterTransient<IViewManager, ViewManager>().RegisterTransient<\u000A\u0020, \u0018\u0020>().RegisterTransient<IExcelExportImportHandler, \u000B\u0020>().RegisterTransient<IPlaceholdersViewModel, LR>().RegisterTransient<ISheetParametersWindowViewModel, YR>().RegisterTransient<IPlaceholderParametersWindowViewModel, HR>(), \u001E\u0011\u000A.\u000A(\u0016\u000D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u000B\u000D\u000E.\u001F())), \u001E\u0011\u000A.\u000A(\u0002\u000D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0006\u000D\u000E.\u001F())).RegisterTransient<IMainWindow, MainWindow>().RegisterTransient<MainWindowViewModel>().RegisterTransient<ITitleBlockService, TitleBlockService>();
			Func<IoC, IDataGridColumnFactory> factory3;
			if ((factory3 = StartUp.<>c.\u001D) == null)
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
				factory3 = (StartUp.<>c.\u001D = new Func<IoC, IDataGridColumnFactory>(StartUp.<>c.\u001F.\u0018));
			}
			ioC2.RegisterTransient<IDataGridColumnFactory>(factory3).RegisterSingleton<UserSelectionContext>().RegisterTransient<ISheetInfoCreator, SheetInfoCreator>().RegisterTransient<IPlaceholderSheetCreator, PlaceholderSheetCreator>().RegisterTransient<\u0014\u001A, \u0013\u001A>().RegisterTransient<\u000B\u000C, \u0006\u000C>().RegisterTransient<IViewRenamingService, \u0018\u0014>().RegisterTransient<ISheetRenamingService, \u001D\u0014>().RegisterTransient<ISheetRenumberingService, \u0004\u0014>().RegisterTransient<ISheetFinalRenumberingService, \u000B\u0017>().RegisterSingleton<IPlaceholderRepository, \u000C\u0020>().RegisterTransient<\u0010\u000C>().RegisterTransient<IViewAuthorizingService, ViewAuthorizingService>().RegisterTransient<ISheetLayoutService, SheetLayoutService>().RegisterTransient<ISheetAuthoringService, SheetAuthoringService>().RegisterTransient<\u0015\u001A, \u0007\u000C>().RegisterTransient<\u0020\u001A, \u0017\u001A>().RegisterTransient<ISheetNumberValidationService, SheetNumberValidationService>().RegisterSingleton<ICancellationManagerService, CancellationManagerService>().RegisterTransient<\u001F\u001B<SheetInfo>, \u000A\u0008>().RegisterTransient<\u001F\u001B<PlaceholderSheet>, \u001A\u0008>().RegisterTransient<\u001D\u0008<PlaceholderSheet>, \u0004\u0008>();
		}
	}
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.Commons.WindowControl;
using DiRoots.ProSheets.UI;
using DiRoots.ProSheets.UI.DiProfiles;
using DiRoots.ProSheets.ViewModels;
using ProSheets.Commons.CustomNameManageWindow.Models;
using ProSheets.Commons.CustomNameManageWindow.Models.Interfaces;
using ProSheets.Commons.CustomNameManageWindow.UI.Windows;
using ProSheets.Helpers;
using ProSheets.Models;
using ProSheets.ScheduleAssistant.ViewModel;
using ProSheets.UI;
using ProSheets.UI.CommonData;

namespace ProSheets
{
	// Token: 0x0200006A RID: 106
	public class UI_MainWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x060005C9 RID: 1481 RVA: 0x00021E3C File Offset: 0x0002003C
		public UI_MainWindow(UIDocument uiDoc)
		{
			\u000F\u0018\u0003.\u0018(this);
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", ".ctor");
				\u0016\u0018\u0003.\u0018(uiDoc);
				this._viewModel = new MainWindowModel(this, \u0017\u0005\u0018.\u0014(uiDoc));
				\u001C\u000B\u0018.\u0003(this, this._viewModel);
				\u0003\u0018\u0003.\u0018(\u0016\u000E\u0018.\u0003(this._viewModel), new ViewSheetSetViewModel.CheckedChangedDelegate(this.SZ));
				\u0014\u0018\u0003.\u0018(\u001E\u000C\u0014.\u0003(this._viewModel), new ScheduleViewModel.GetProfileValuesHandler(this.GetProfileValues));
				\u0018\u0018\u0003.\u0018(false);
				\u000C\u0018\u0003.\u0018(\u0017\u0005\u0018.\u0014(uiDoc));
				\u000E\u000C\u0003.\u0018(new List<SheetInfo>());
				\u0005\u000C\u0003.\u0018(new List<SheetInfo>());
				\u001B\u000C\u0003.\u0018(new List<SheetInfo>());
				\u0001\u000C\u0003.\u0018(new List<SheetInfo>());
				this.YJ = new List<string>();
				\u0008\u000C\u0003.\u0018(this, string.Empty);
				\u0006\u000C\u0003.\u0018(this, \u000D\u0009\u0018.\u0015);
				\u0010\u000C\u0003.\u0018(this, new List<long>());
				CollectionsDataGridSelectionBehavior collectionsDataGridSelectionBehavior = new CollectionsDataGridSelectionBehavior();
				\u0007\u0001\u0018.\u0018(collectionsDataGridSelectionBehavior, DataGridSelectionBehavior<SheetInfo>.SelectedItemsProperty, new Binding("SheetsViewModels.SelectItems"));
				\u000B\u0001\u0018.\u0018(\u0019\u0001\u0018.\u0018(this.HF), collectionsDataGridSelectionBehavior);
				CollectionsDataGridSelectionBehavior collectionsDataGridSelectionBehavior2 = new CollectionsDataGridSelectionBehavior();
				\u0007\u0001\u0018.\u0018(collectionsDataGridSelectionBehavior2, DataGridSelectionBehavior<SheetInfo>.SelectedItemsProperty, new Binding("ViewsViewModels.SelectItems"));
				\u000B\u0001\u0018.\u0018(\u0019\u0001\u0018.\u0018(this.MF), collectionsDataGridSelectionBehavior2);
				IEnumerable<SheetInfo> enumerable = \u0010\u000E\u0018.\u0018();
				Func<SheetInfo, bool> func;
				if ((func = UI_MainWindow.<>c.\u0018) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow..ctor(UIDocument)).MethodHandle;
					}
					func = (UI_MainWindow.<>c.\u0018 = new Func<SheetInfo, bool>(UI_MainWindow.<>c.\u000C.\u0020));
				}
				int num = \u0002\u0005\u0018.\u0018(Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable, func)));
				int num2 = \u0002\u0005\u0018.\u0018(\u0010\u000E\u0018.\u0018()) - num;
				int num3 = \u0002\u0005\u0018.\u0018(\u0010\u000E\u0018.\u0018());
				\u0018\u0009\u0014.\u0018(this.QR, \u0007\u000C\u0003.\u0018(\u001C\u0009\u0018.\u0006, num, num2, num3));
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", ".ctor");
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", ".ctor");
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x060005CB RID: 1483 RVA: 0x000220EC File Offset: 0x000202EC
		// (set) Token: 0x060005CC RID: 1484 RVA: 0x00022100 File Offset: 0x00020300
		public static Document document { get; set; }

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x00022114 File Offset: 0x00020314
		// (set) Token: 0x060005CE RID: 1486 RVA: 0x00022128 File Offset: 0x00020328
		public static UIDocument uidocument { get; set; }

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x060005CF RID: 1487 RVA: 0x0002213C File Offset: 0x0002033C
		// (set) Token: 0x060005D0 RID: 1488 RVA: 0x00022150 File Offset: 0x00020350
		public static List<SheetInfo> lstOfSheets { get; set; }

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x060005D1 RID: 1489 RVA: 0x00022164 File Offset: 0x00020364
		// (set) Token: 0x060005D2 RID: 1490 RVA: 0x00022178 File Offset: 0x00020378
		public static List<SheetInfo> lstOfSheetsForSets { get; set; }

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x060005D3 RID: 1491 RVA: 0x0002218C File Offset: 0x0002038C
		// (set) Token: 0x060005D4 RID: 1492 RVA: 0x000221A0 File Offset: 0x000203A0
		public static List<SheetInfo> lstOfViews { get; set; }

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x060005D5 RID: 1493 RVA: 0x000221B4 File Offset: 0x000203B4
		// (set) Token: 0x060005D6 RID: 1494 RVA: 0x000221C8 File Offset: 0x000203C8
		public static List<SheetInfo> lstSelectedItems { get; set; } = \u001D\u0017\u0014.\u0018();

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x060005D7 RID: 1495 RVA: 0x000221DC File Offset: 0x000203DC
		// (set) Token: 0x060005D8 RID: 1496 RVA: 0x000221F0 File Offset: 0x000203F0
		public static bool IsExporting { get; set; }

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x060005D9 RID: 1497 RVA: 0x00022204 File Offset: 0x00020404
		// (set) Token: 0x060005DA RID: 1498 RVA: 0x00022218 File Offset: 0x00020418
		public string objCustomParam { get; set; }

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x060005DB RID: 1499 RVA: 0x0002222C File Offset: 0x0002042C
		// (set) Token: 0x060005DC RID: 1500 RVA: 0x00022240 File Offset: 0x00020440
		public string objCmbViewstype { get; set; }

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x060005DD RID: 1501 RVA: 0x00022254 File Offset: 0x00020454
		// (set) Token: 0x060005DE RID: 1502 RVA: 0x00022268 File Offset: 0x00020468
		public static List<PaperSize> lstNetPaperSizes { get; set; } = \u001A\u001A\u0014.\u0018();

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x060005DF RID: 1503 RVA: 0x0002227C File Offset: 0x0002047C
		// (set) Token: 0x060005E0 RID: 1504 RVA: 0x00022290 File Offset: 0x00020490
		public static bool ExportActive { get; set; }

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x060005E1 RID: 1505 RVA: 0x000222A4 File Offset: 0x000204A4
		// (set) Token: 0x060005E2 RID: 1506 RVA: 0x000222B8 File Offset: 0x000204B8
		public List<long> OpenViewIds { get; set; }

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x060005E3 RID: 1507 RVA: 0x000222CC File Offset: 0x000204CC
		// (set) Token: 0x060005E4 RID: 1508 RVA: 0x000222E0 File Offset: 0x000204E0
		public List<SelectionParameter> _default_unselected_parameters { get; set; } = new List<SelectionParameter>();

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x060005E5 RID: 1509 RVA: 0x000222F4 File Offset: 0x000204F4
		// (set) Token: 0x060005E6 RID: 1510 RVA: 0x00022308 File Offset: 0x00020508
		public List<SelectionParameter> _default_unselected_parameters_Views { get; set; } = new List<SelectionParameter>();

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x060005E7 RID: 1511 RVA: 0x0002231C File Offset: 0x0002051C
		// (set) Token: 0x060005E8 RID: 1512 RVA: 0x00022330 File Offset: 0x00020530
		public static bool IsLinkDoc { get; set; }

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x060005E9 RID: 1513 RVA: 0x00022344 File Offset: 0x00020544
		// (set) Token: 0x060005EA RID: 1514 RVA: 0x00022358 File Offset: 0x00020558
		public static ParameterBaseModel SheetParamModel { get; set; }

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x0002236C File Offset: 0x0002056C
		// (set) Token: 0x060005EC RID: 1516 RVA: 0x00022380 File Offset: 0x00020580
		public static ParameterBaseModel ViewParamModel { get; set; }

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x00022394 File Offset: 0x00020594
		// (set) Token: 0x060005EE RID: 1518 RVA: 0x000223A8 File Offset: 0x000205A8
		public static ParameterBaseModel ProjectParamModel { get; set; }

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x000223BC File Offset: 0x000205BC
		// (set) Token: 0x060005F0 RID: 1520 RVA: 0x000223D0 File Offset: 0x000205D0
		public static Parameters SelectedSheetParameter { get; set; }

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x000223E4 File Offset: 0x000205E4
		// (set) Token: 0x060005F2 RID: 1522 RVA: 0x000223F8 File Offset: 0x000205F8
		public static Parameters SelectedViewParameter { get; set; }

		// Token: 0x060005F3 RID: 1523 RVA: 0x0002240C File Offset: 0x0002060C
		public void RaiseUpdateTaskEvent()
		{
			this.SZ();
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x00022420 File Offset: 0x00020620
		private void Window_ContentRendered(object sender, EventArgs e)
		{
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "Window_ContentRendered");
				\u001B\u0018\u0003.\u0018("diroots.prosheets");
				this.UJ = \u0008\u0018\u0003.\u0018(\u0001\u0018\u0003.\u0018());
				\u0006\u0018\u0003.\u0018(this, "ProSheets");
				\u0008\u0013\u0014.\u0018(this.BR, Visibility.Collapsed);
				\u0014\u0019\u0018.\u0018(this.KF, false);
				UI_PleaseWait u000C = \u0010\u0018\u0003.\u0018(this);
				\u0012\u000A\u0014.\u0018(u000C, this);
				\u001E\u0007\u0018.\u0014(u000C);
				object u000C2 = \u0016\u000E\u0018.\u0003(this._viewModel);
				IEnumerable<SheetInfo> enumerable = \u0003\u0007\u0014.\u0018();
				Func<SheetInfo, ISetViewInfo> func;
				if ((func = UI_MainWindow.<>c.\u0014) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.Window_ContentRendered(object, EventArgs)).MethodHandle;
					}
					func = (UI_MainWindow.<>c.\u0014 = new Func<SheetInfo, ISetViewInfo>(UI_MainWindow.<>c.\u000C.\u001F));
				}
				\u001C\u000E\u0018.\u0018(u000C2, Enumerable.ToList<ISetViewInfo>(Enumerable.Select<SheetInfo, ISetViewInfo>(enumerable, func)));
				this.YJ = \u000C\u000A\u0018.\u0017(\u0017\u001B\u0014.\u0018());
				\u0007\u0018\u0003.\u0018(this.BF, new bool?(true));
				Profile u000C3 = \u0002\u000A\u0014.\u0018();
				\u000B\u0018\u0003.\u0018(this.IF, \u0017\u001B\u0014.\u0018(), \u0019\u0018\u0003.\u0018());
				\u001A\u0018\u0003.\u0018(this, \u0017\u000A\u0014.\u0018(u000C3));
				\u0011\u000A\u0014.\u0018(u000C3, "default_profile");
				\u001D\u0018\u0003.\u0018(u000C3);
				\u0004\u0018\u0003.\u0018();
				\u001E\u0018\u0003.\u0018(\u0008\u000A\u0014.\u0018(\u0002\u0018\u0003.\u0018()));
				\u0017\u0018\u0003.\u0018(this.DJ, new ProfileControl.LoadProfileHandler(this.WZ));
				\u0015\u0018\u0003.\u0018(this._viewModel, new MainWindowModel.LoadProfileHandler(this.WZ));
				\u0011\u0018\u0003.\u0018(this.DJ, new ProfileControl.GetProfileValuesHandler(this.GetProfileValues));
				\u0020\u0018\u0003.\u0018(\u001E\u000C\u0014.\u0003(this._viewModel), \u001F\u0018\u0003.\u0018() != \u000E\u000B\u000F.\u000C);
				\u000A\u0018\u0003.\u0018(this.DJ);
				\u0009\u0018\u0003.\u0014(\u001E\u000C\u0014.\u0003(this._viewModel));
				\u0013\u0018\u0003.\u0018(this._viewModel);
				this.RZ();
				this.ZZ();
				\u000F\u0020\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.HF));
				\u001C\u0018\u0003.\u0018(this._viewModel, \u0003\u0007\u0014.\u0018());
				if (!Enumerable.Any<SheetInfo>(\u0014\u0007\u0014.\u0018()))
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
					\u0005\u000C\u0003.\u0018(\u000C\u000A\u0018.\u0012(\u0017\u001B\u0014.\u0018(), \u0018\u000E\u0018.\u0018(\u000E\u0005\u0018.\u0003(this._viewModel)), \u0005\u0005\u0018.\u0018(\u000E\u0005\u0018.\u0003(this._viewModel))));
					\u000C\u000A\u0018.\u0001(\u0017\u001B\u0014.\u0018(), true);
				}
				object u000C4 = \u000B\u000E\u0018.\u0014(\u0016\u000E\u0018.\u0003(this._viewModel));
				IEnumerable<SheetInfo> enumerable2 = \u0014\u0007\u0014.\u0018();
				Func<SheetInfo, ISetViewInfo> func2;
				if ((func2 = UI_MainWindow.<>c.\u0003) == null)
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
					func2 = (UI_MainWindow.<>c.\u0003 = new Func<SheetInfo, ISetViewInfo>(UI_MainWindow.<>c.\u000C.\u0011));
				}
				\u001A\u000E\u0018.\u0018(u000C4, Enumerable.Select<SheetInfo, ISetViewInfo>(enumerable2, func2));
				\u000D\u0018\u0003.\u0018(this._viewModel, \u0014\u0007\u0014.\u0018());
				\u0012\u0018\u0003.\u0018(new SheetInfo.CheckedOrUncheckedHandler(this.IZ));
			}
			catch (Exception u)
			{
				\u0012\u0018\u0003.\u0018(new SheetInfo.CheckedOrUncheckedHandler(this.IZ));
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "Window_ContentRendered");
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "Window_ContentRendered");
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00022764 File Offset: 0x00020964
		private void RZ()
		{
			try
			{
				List<string> u000C = \u0011\u0002\u0018.\u0018();
				List<string>.Enumerator enumerator = \u0008\u0015\u0014.\u0018(this.UJ);
				try
				{
					while (\u0010\u0015\u0014.\u0018(ref enumerator))
					{
						UI_MainWindow.\u0013\u000A\u0018 u0013_u000A_u = new UI_MainWindow.\u0013\u000A\u0018();
						u0013_u000A_u.\u000C = \u0006\u0015\u0014.\u0018(ref enumerator);
						string text = \u000E\u0018\u0003.\u0018(this.YJ, new Predicate<string>(u0013_u000A_u.\u0018));
						if (text != null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.RZ()).MethodHandle;
							}
							\u0019\u0017\u0014.\u0018(u000C, text);
						}
					}
					for (;;)
					{
						switch (2)
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
				this.UJ = \u0005\u0018\u0003.\u0018(u000C);
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "RemoveNonExistingParamsFromLastRememberedSettings");
			}
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x00022840 File Offset: 0x00020A40
		private void Window_Unloaded(object sender, RoutedEventArgs e)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "Window_Unloaded");
			\u000C\u0014\u0003.\u0018(\u0001\u0018\u0003.\u0018(), this.UJ);
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x00022878 File Offset: 0x00020A78
		private void RdbViews_Checked(object sender, RoutedEventArgs e)
		{
			this.HZ();
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0002288C File Offset: 0x00020A8C
		private void HZ()
		{
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "SettingViews");
				if (!Enumerable.Any<SheetInfo>(\u0014\u0007\u0014.\u0018()))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.HZ()).MethodHandle;
					}
					\u0005\u000C\u0003.\u0018(\u000C\u000A\u0018.\u0012(\u0017\u001B\u0014.\u0018(), \u0018\u000E\u0018.\u0018(\u000E\u0005\u0018.\u0003(this._viewModel)), \u0005\u0005\u0018.\u0018(\u000E\u0005\u0018.\u0003(this._viewModel))));
					\u000C\u000A\u0018.\u0001(\u0017\u001B\u0014.\u0018(), true);
				}
				object u000C = \u000B\u000E\u0018.\u0014(\u0016\u000E\u0018.\u0003(this._viewModel));
				IEnumerable<SheetInfo> enumerable = \u0014\u0007\u0014.\u0018();
				Func<SheetInfo, ISetViewInfo> func;
				if ((func = UI_MainWindow.<>c.\u0016) == null)
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
					func = (UI_MainWindow.<>c.\u0016 = new Func<SheetInfo, ISetViewInfo>(UI_MainWindow.<>c.\u000C.\u0015));
				}
				\u001A\u000E\u0018.\u0018(u000C, Enumerable.Select<SheetInfo, ISetViewInfo>(enumerable, func));
				\u000D\u0018\u0003.\u0018(this._viewModel, \u0014\u0007\u0014.\u0018());
				\u0008\u0013\u0014.\u0018(this.MF, Visibility.Visible);
				this.EZ();
				this.SZ();
				\u0007\u0018\u0003.\u0018(this.BF, new bool?(false));
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "SettingViews");
			}
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x000229DC File Offset: 0x00020BDC
		private void BtnPopUp_Click(object sender, RoutedEventArgs e)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "BtnPopUp_Click");
			bool? flag = \u001B\u0001\u0018.\u0018(this.BF);
			object u000C;
			if (!\u000F\u0014\u0003.\u0018(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.BtnPopUp_Click(object, RoutedEventArgs)).MethodHandle;
				}
				u000C = \u0018\u0014\u0003.\u0018();
			}
			else
			{
				u000C = \u0014\u0014\u0003.\u0018();
			}
			List<IParameterModel> u = Enumerable.ToList<IParameterModel>(Enumerable.OfType<IParameterModel>(\u0012\u0018\u0014.\u0003(u000C)));
			List<IParameterModel> u2 = \u001C\u0014\u0003.\u0018();
			if (\u0009\u0019\u0014.\u0018() != null)
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
				flag = \u001B\u0001\u0018.\u0018(this.BF);
				if (\u000F\u0014\u0003.\u0018(ref flag))
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
					u2 = Enumerable.ToList<IParameterModel>(Enumerable.OfType<IParameterModel>(\u0013\u0019\u0014.\u0018(\u0009\u0019\u0014.\u0018())));
				}
			}
			if (\u000A\u0019\u0014.\u0018() != null)
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
				flag = \u001B\u0001\u0018.\u0018(this.BF);
				if (!\u000F\u0014\u0003.\u0018(ref flag))
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
					u2 = Enumerable.ToList<IParameterModel>(Enumerable.OfType<IParameterModel>(\u0013\u0019\u0014.\u0018(\u000A\u0019\u0014.\u0018())));
				}
			}
			CustomNameManager u000C2 = \u000D\u0014\u0003.\u0018(false, u, u2, null, false);
			\u0012\u000A\u0014.\u0018(u000C2, this);
			flag = \u001E\u0007\u0018.\u0014(u000C2);
			if (\u000C\u0007\u0018.\u0018(ref flag))
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
				Parameters u000C3 = \u0012\u0014\u0003.\u0018(\u0005\u000B\u000F.\u000C(\u0003\u0012\u0014.\u0014(u000C2)));
				flag = \u001B\u0001\u0018.\u0018(this.BF);
				if (\u000F\u0014\u0003.\u0018(ref flag))
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
					\u0016\u0014\u0003.\u0018(u000C3);
				}
				else
				{
					\u0003\u0014\u0003.\u0018(u000C3);
				}
				\u000C\u000A\u0018.\u0004(\u0017\u001B\u0014.\u0018(), \u0014\u0014\u0003.\u0018(), \u0018\u0014\u0003.\u0018(), false);
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "BtnPopUp_Click");
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00022BB0 File Offset: 0x00020DB0
		private void NZ()
		{
			bool? flag = \u001B\u0001\u0018.\u0018(this.BF);
			if (\u000C\u0007\u0018.\u0018(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.NZ()).MethodHandle;
				}
				this.LJ = Enumerable.ToList<SheetInfo>(Enumerable.Cast<SheetInfo>(\u000D\u000F\u0014.\u0018(this.HF)));
			}
			if (\u0002\u0005\u0018.\u0018(\u0003\u0007\u0014.\u0018()) > 0)
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
				if (\u000F\u0002\u0018.\u0018(\u0013\u0014\u0003.\u0018(this), "Orientation"))
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
					List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u0003\u0007\u0014.\u0018());
					try
					{
						while (\u0019\u000E\u0018.\u0018(ref enumerator))
						{
							SheetInfo u000C = \u000C\u000C\u0014.\u0018(ref enumerator);
							\u0007\u000B\u0014.\u0018(u000C, \u0011\u0017\u0014.\u0014(u000C));
							if (\u0019\u000B\u0014.\u0018(\u0015\u000E\u0018.\u0018(u000C), \u0013\u0014\u0003.\u0018(this)))
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
								\u000B\u000B\u0014.\u0018(\u0015\u000E\u0018.\u0018(u000C), \u0013\u0014\u0003.\u0018(this), \u001A\u000B\u0014.\u0018(u000C));
							}
							else
							{
								\u001D\u000B\u0014.\u0018(\u0015\u000E\u0018.\u0018(u000C), \u0013\u0014\u0003.\u0018(this), \u001A\u000B\u0014.\u0018(u000C));
							}
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
						return;
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				List<SheetInfo> list = \u000C\u000A\u0018.\u0002(\u0003\u0007\u0014.\u0018(), \u0013\u0014\u0003.\u0018(this));
				this.LJ = Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(list, new Func<SheetInfo, bool>(this.AZ)));
			}
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00022D44 File Offset: 0x00020F44
		private void ZZ()
		{
			UI_MainWindow.\u000A\u000A\u0018 u000A_u000A_u = new UI_MainWindow.\u000A\u000A\u0018();
			u000A_u000A_u.\u000C = \u001D\u0017\u0014.\u0018();
			if (\u0002\u0005\u0018.\u0018(\u0003\u0007\u0014.\u0018()) > 0)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.ZZ()).MethodHandle;
				}
				List<string> list = \u0011\u0002\u0018.\u0018();
				List<string>.Enumerator enumerator = \u0008\u0015\u0014.\u0018(this.UJ);
				try
				{
					while (\u0010\u0015\u0014.\u0018(ref enumerator))
					{
						UI_MainWindow.\u0020\u000A\u0018 u0020_u000A_u = new UI_MainWindow.\u0020\u000A\u0018();
						u0020_u000A_u.\u000C = \u0006\u0015\u0014.\u0018(ref enumerator);
						if (\u0008\u000B\u000F.\u000C(Enumerable.FirstOrDefault<DataGridColumn>(\u0002\u0014\u0003.\u0018(this.HF), new Func<DataGridColumn, bool>(u0020_u000A_u.\u0018))) == null)
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
							DataGridLength u = \u0004\u0014\u0003.\u0018();
							object u000C = \u0002\u0014\u0003.\u0018(this.HF);
							int u2 = \u001E\u0014\u0003.\u0018(\u0002\u0014\u0003.\u0018(this.HF)) - 1;
							DataGridTextColumn dataGridTextColumn = \u0017\u0014\u0003.\u0018();
							\u0015\u0014\u0003.\u0018(dataGridTextColumn, u0020_u000A_u.\u000C);
							\u0011\u0014\u0003.\u0018(dataGridTextColumn, u);
							\u0020\u0014\u0003.\u0018(dataGridTextColumn, \u001F\u0014\u0003.\u0018(\u0014\u001E\u0018.\u0018("CustomParamWithColumns[", u0020_u000A_u.\u000C, "]")));
							\u000A\u0014\u0003.\u0018(dataGridTextColumn, true);
							\u0009\u0014\u0003.\u0018(u000C, u2, dataGridTextColumn);
						}
						\u0019\u0017\u0014.\u0018(list, u0020_u000A_u.\u000C);
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
					((IDisposable)enumerator).Dispose();
				}
				if (Enumerable.Any<string>(list))
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
					List<SheetInfo> list2 = \u000C\u000A\u0018.\u0002(\u0003\u0007\u0014.\u0018(), list);
					u000A_u000A_u.\u000C = Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(list2, new Func<SheetInfo, bool>(u000A_u000A_u.\u0018)));
				}
			}
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00022EF4 File Offset: 0x000210F4
		private void RdbSheets_Checked(object sender, RoutedEventArgs e)
		{
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "RdbSheets_Checked");
				if (\u001D\u0014\u0003.\u0014(this.MF))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.RdbSheets_Checked(object, RoutedEventArgs)).MethodHandle;
					}
					\u0008\u0013\u0014.\u0018(this.MF, Visibility.Hidden);
				}
				\u0007\u0018\u0003.\u0018(this.QF, new bool?(false));
				if (\u000A\u000E\u0018.\u0003(this._viewModel))
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
					this.EZ();
				}
				this.SZ();
				\u001C\u000C\u0014.\u0018(\u0012\u000E\u0018.\u0003(this._viewModel));
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "RdbSheets_Checked");
			}
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00022FB8 File Offset: 0x000211B8
		private void BtnBack_Click(object sender, RoutedEventArgs e)
		{
			if (\u000B\u0014\u0003.\u0018(this.TF))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.BtnBack_Click(object, RoutedEventArgs)).MethodHandle;
				}
				\u001A\u0014\u0003.\u0018(this.PF, true);
				\u0014\u0019\u0018.\u0018(this.KF, false);
				return;
			}
			if (\u000B\u0014\u0003.\u0018(this.SF))
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
				\u001A\u0014\u0003.\u0018(this.TF, true);
			}
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00023028 File Offset: 0x00021228
		private void BtnNext_Click(object sender, RoutedEventArgs e)
		{
			if (\u0002\u0005\u0018.\u0018(\u0010\u000E\u0018.\u0018()) == 0)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.BtnNext_Click(object, RoutedEventArgs)).MethodHandle;
				}
				\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u0015);
				return;
			}
			if (\u000B\u0014\u0003.\u0018(this.PF))
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
				\u001A\u0014\u0003.\u0018(this.TF, true);
				return;
			}
			if (\u000B\u0014\u0003.\u0018(this.TF))
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
				\u0019\u0014\u0003.\u0018(this.IF);
				\u001A\u0014\u0003.\u0018(this.SF, true);
			}
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x000230C0 File Offset: 0x000212C0
		private string MZ(string P)
		{
			string text = \u0018\u001F\u0018.\u0018(P);
			List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
			try
			{
				while (\u0019\u000E\u0018.\u0018(ref enumerator))
				{
					\u0003\u001B\u0014.\u0018(\u000C\u000C\u0014.\u0018(ref enumerator), \u0005\u001E\u000F.\u000C);
				}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.MZ(string)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			if (\u000A\u0017\u0014.\u0018(text, "%"))
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
				\u001F\u001F\u0018.\u000C(\u0017\u001B\u0014.\u0018(), ref text);
			}
			return text;
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x00023160 File Offset: 0x00021360
		private void BtnCreate_Click(object sender, RoutedEventArgs e)
		{
			\u0007\u0014\u0003.\u0014(this, false);
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x00023178 File Offset: 0x00021378
		public Task ExportFiles(bool isTryAgain = false)
		{
			UI_MainWindow.\u0011\u000A\u0018 u0011_u000A_u;
			u0011_u000A_u.\u0018 = \u0006\u0014\u0003.\u0018();
			u0011_u000A_u.\u0014 = this;
			u0011_u000A_u.\u0003 = isTryAgain;
			u0011_u000A_u.\u000C = -1;
			u0011_u000A_u.\u0018.Start<UI_MainWindow.\u0011\u000A\u0018>(ref u0011_u000A_u);
			return \u0010\u0014\u0003.\u0018(ref u0011_u000A_u.\u0018);
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x000231C8 File Offset: 0x000213C8
		private void XZ()
		{
			\u000D\u0011\u0014.\u0018(\u001C\u0011\u0014.\u0018(new ParameterizedThreadStart(this.VZ)));
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x000231F0 File Offset: 0x000213F0
		private void YZ()
		{
			this.UF.WR();
			\u0001\u0014\u0003.\u0018(false);
			\u0008\u0014\u0003.\u0018(this.UF, new Create.ExportEndedHandler(this.YZ));
			\u0008\u0013\u0014.\u0018(this.DF, Visibility.Collapsed);
			\u0014\u0019\u0018.\u0018(this.BR, true);
			\u0014\u0019\u0018.\u0018(this.PF, true);
			\u0014\u0019\u0018.\u0018(this.TF, true);
			\u0014\u0019\u0018.\u0018(this.KF, true);
			\u0014\u0019\u0018.\u0018(this.DJ, true);
			\u000D\u0011\u0014.\u0018(\u001C\u0011\u0014.\u0018(new ParameterizedThreadStart(this.DZ)));
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x00023288 File Offset: 0x00021488
		private void OZ(int P)
		{
			\u0013\u0017\u0014.\u0018(P);
			\u000E\u0014\u0003.\u0018(\u0005\u0014\u0003.\u0014(this), new Action(this.KZ));
			object u000C = \u0005\u0014\u0003.\u0014(this);
			DispatcherPriority u = DispatcherPriority.Background;
			Action u2;
			if ((u2 = UI_MainWindow.<>c.\u000F) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.OZ(int)).MethodHandle;
				}
				u2 = (UI_MainWindow.<>c.\u000F = new Action(UI_MainWindow.<>c.\u000C.\u0017));
			}
			\u001B\u0014\u0003.\u0018(u000C, u, u2);
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x000232F8 File Offset: 0x000214F8
		private void CZ()
		{
			\u000C\u0003\u0003.\u0018(this, this.EJ);
			\u000A\u000B\u0018.\u0003(this);
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0002331C File Offset: 0x0002151C
		private void CmbViews_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.TJ)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.CmbViews_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				this.TJ = false;
				return;
			}
			\u0007\u0018\u0003.\u0018(this.QF, new bool?(true));
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x00023360 File Offset: 0x00021560
		private void UserControlExport_Loaded(object sender, RoutedEventArgs e)
		{
			if (\u000B\u0014\u0003.\u0018(this.TF))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.UserControlExport_Loaded(object, RoutedEventArgs)).MethodHandle;
				}
				if (\u0002\u0005\u0018.\u0018(\u0010\u000E\u0018.\u0018()) == 0)
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
					\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u0015);
					\u001A\u0014\u0003.\u0018(this.PF, true);
					return;
				}
				\u0014\u0019\u0018.\u0018(this.KF, true);
				\u0018\u0003\u0003.\u0018(true);
			}
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x000233D8 File Offset: 0x000215D8
		private void UserControlCreate_Loaded(object sender, RoutedEventArgs e)
		{
			UI_MainWindow.\u0015\u000A\u0018 u0015_u000A_u;
			u0015_u000A_u.\u0018 = \u0014\u0003\u0003.\u0018();
			u0015_u000A_u.\u0014 = this;
			u0015_u000A_u.\u000C = -1;
			u0015_u000A_u.\u0018.Start<UI_MainWindow.\u0015\u000A\u0018>(ref u0015_u000A_u);
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00023414 File Offset: 0x00021614
		private void UserControlCreate_Unloaded(object sender, RoutedEventArgs e)
		{
			\u0008\u0013\u0014.\u0018(this.BR, Visibility.Collapsed);
			\u0008\u0013\u0014.\u0018(this.PR, Visibility.Visible);
			if (\u000B\u0014\u0003.\u0018(this.PF))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.UserControlCreate_Unloaded(object, RoutedEventArgs)).MethodHandle;
				}
				\u0014\u0019\u0018.\u0018(this.KF, false);
			}
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x00023468 File Offset: 0x00021668
		private void BtnMainCancel_Click(object sender, RoutedEventArgs e)
		{
			\u0002\u0015\u0014.\u0018(true);
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x0002347C File Offset: 0x0002167C
		private void UserControlExport_Unloaded(object sender, RoutedEventArgs e)
		{
			\u0018\u0003\u0003.\u0018(false);
			if (\u000B\u0014\u0003.\u0018(this.PF))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.UserControlExport_Unloaded(object, RoutedEventArgs)).MethodHandle;
				}
				\u0014\u0019\u0018.\u0018(this.KF, false);
			}
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x000234C0 File Offset: 0x000216C0
		private void Window_Closing(object sender, CancelEventArgs e)
		{
			try
			{
				\u001D\u0020\u0018.\u000C();
				\u000F\u0003\u0003.\u0018();
				Window window = \u0016\u0003\u0003.\u0018(this);
				if (window == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.Window_Closing(object, CancelEventArgs)).MethodHandle;
					}
				}
				else
				{
					\u0003\u0003\u0003.\u0018(window);
				}
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "Window_Closing");
			}
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x00023530 File Offset: 0x00021730
		public void GetProfileValues(ExportTemPlateInfo templateInfo)
		{
			\u0020\u0003\u0003.\u0018(\u0017\u0003\u0003.\u0018(templateInfo), Enumerable.ToList<SelectionParameter>(\u0016\u0018\u0014.\u0003(\u0014\u0014\u0003.\u0018())));
			\u000A\u0003\u0003.\u0018(\u0017\u0003\u0003.\u0018(templateInfo), \u000C\u0014\u0014.\u0003(\u0014\u0014\u0003.\u0018()));
			\u001C\u0003\u0003.\u0018(\u0017\u0003\u0003.\u0018(templateInfo), \u0013\u0003\u0003.\u0018(\u000E\u0018\u0014.\u0003(\u0014\u0014\u0003.\u0018())));
			\u0015\u0003\u0003.\u0018(templateInfo, \u0009\u0019\u0014.\u0018());
			\u0020\u0003\u0003.\u0018(\u0011\u0003\u0003.\u0018(templateInfo), Enumerable.ToList<SelectionParameter>(\u0016\u0018\u0014.\u0003(\u0018\u0014\u0003.\u0018())));
			\u000A\u0003\u0003.\u0018(\u0011\u0003\u0003.\u0018(templateInfo), \u000C\u0014\u0014.\u0003(\u0018\u0014\u0003.\u0018()));
			\u001C\u0003\u0003.\u0018(\u0011\u0003\u0003.\u0018(templateInfo), \u0013\u0003\u0003.\u0018(\u000E\u0018\u0014.\u0003(\u0018\u0014\u0003.\u0018())));
			\u001F\u0003\u0003.\u0018(templateInfo, \u000A\u0019\u0014.\u0018());
			\u0020\u0003\u0003.\u0018(\u0009\u0003\u0003.\u0014(templateInfo), Enumerable.ToList<SelectionParameter>(\u0016\u0018\u0014.\u0003(\u0019\u0018\u0003.\u0018())));
			\u000A\u0003\u0003.\u0018(\u0009\u0003\u0003.\u0014(templateInfo), \u000C\u0014\u0014.\u0003(\u0019\u0018\u0003.\u0018()));
			\u001C\u0003\u0003.\u0018(\u0009\u0003\u0003.\u0014(templateInfo), \u0013\u0003\u0003.\u0018(\u000E\u0018\u0014.\u0003(\u0019\u0018\u0003.\u0018())));
			\u000D\u0003\u0003.\u0018(this.IF, templateInfo);
			\u0012\u0003\u0003.\u0018(this.UF, templateInfo);
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x0002368C File Offset: 0x0002188C
		private bool WZ(Profile P)
		{
			List<IParameterModel> list = Enumerable.ToList<IParameterModel>(Enumerable.OfType<IParameterModel>(\u0007\u0003\u0003.\u0018(\u0014\u0014\u0003.\u0018())));
			List<IParameterModel> list2 = Enumerable.ToList<IParameterModel>(Enumerable.OfType<IParameterModel>(\u0007\u0003\u0003.\u0018(\u0018\u0014\u0003.\u0018())));
			if (\u000B\u0003\u0003.\u0003(\u0017\u000A\u0014.\u0018(P)) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.WZ(Profile)).MethodHandle;
				}
				\u0015\u0003\u0003.\u0018(\u0017\u000A\u0014.\u0018(P), \u0019\u0003\u0003.\u0018(string.Empty, \u000D\u001F\u0018.\u0018(list, \u0017\u0003\u0003.\u0018(\u0017\u000A\u0014.\u0018(P)))));
			}
			if (\u001A\u0003\u0003.\u0003(\u0017\u000A\u0014.\u0018(P)) == null)
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
				\u001F\u0003\u0003.\u0018(\u0017\u000A\u0014.\u0018(P), \u0019\u0003\u0003.\u0018(string.Empty, \u000D\u001F\u0018.\u0018(list2, \u0011\u0003\u0003.\u0018(\u0017\u000A\u0014.\u0018(P)))));
			}
			List<IParameterModel> u000C = list;
			ExportTemPlateInfo exportTemPlateInfo = \u0017\u000A\u0014.\u0018(P);
			Parameters u;
			if (exportTemPlateInfo == null)
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
				u = \u001B\u000B\u000F.\u000C;
			}
			else
			{
				u = \u000B\u0003\u0003.\u0014(exportTemPlateInfo);
			}
			bool flag = \u000D\u001F\u0018.\u000C(u000C, u);
			ExportTemPlateInfo exportTemPlateInfo2 = \u0017\u000A\u0014.\u0018(P);
			Parameters u000C2;
			if (exportTemPlateInfo2 == null)
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
				u000C2 = \u001B\u000B\u000F.\u000C;
			}
			else
			{
				u000C2 = \u000B\u0003\u0003.\u0014(exportTemPlateInfo2);
			}
			\u0016\u0014\u0003.\u0018(u000C2);
			List<IParameterModel> u000C3 = list2;
			ExportTemPlateInfo exportTemPlateInfo3 = \u0017\u000A\u0014.\u0018(P);
			Parameters u2;
			if (exportTemPlateInfo3 == null)
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
				u2 = \u001B\u000B\u000F.\u000C;
			}
			else
			{
				u2 = \u001A\u0003\u0003.\u0014(exportTemPlateInfo3);
			}
			bool flag2 = \u000D\u001F\u0018.\u000C(u000C3, u2);
			ExportTemPlateInfo exportTemPlateInfo4 = \u0017\u000A\u0014.\u0018(P);
			Parameters u000C4;
			if (exportTemPlateInfo4 == null)
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
				u000C4 = \u001B\u000B\u000F.\u000C;
			}
			else
			{
				u000C4 = \u001A\u0003\u0003.\u0014(exportTemPlateInfo4);
			}
			\u0003\u0014\u0003.\u0018(u000C4);
			\u000C\u000A\u0018.\u0004(\u0017\u001B\u0014.\u0018(), \u0014\u0014\u0003.\u0018(), \u0018\u0014\u0003.\u0018(), false);
			\u001D\u0003\u0003.\u0018(this.IF, P);
			\u0004\u0003\u0003.\u0018(this.UF, \u0017\u000A\u0014.\u0018(P));
			if (flag || flag2)
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
				UnknownParameter u000C5 = \u0002\u0003\u0003.\u0018();
				\u0012\u000A\u0014.\u0018(u000C5, this);
				string text = "";
				bool flag3 = false;
				if (flag)
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
					text = \u000D\u001E\u0018.\u0018(text, \u001C\u0009\u0018.\u001A);
					flag3 = true;
				}
				if (flag2)
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
					if (flag3)
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
						text = \u000D\u001E\u0018.\u0018(text, \u001C\u0009\u0018.\u0007);
					}
					else
					{
						text = \u000D\u001E\u0018.\u0018(text, \u001C\u0009\u0018.\u0019);
					}
				}
				\u001E\u0003\u0003.\u0018(u000C5, \u001C\u001E\u0018.\u0018(\u001C\u0009\u0018.\u0010, text));
				\u001E\u0007\u0018.\u0014(u000C5);
			}
			ExportTemPlateInfo exportTemPlateInfo5 = \u0017\u000A\u0014.\u0018(P);
			SelectionTemPlateInfo p;
			if (exportTemPlateInfo5 == null)
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
				p = null;
			}
			else
			{
				p = \u0009\u0003\u0003.\u0003(exportTemPlateInfo5);
			}
			this.TZ(p, \u0019\u0018\u0003.\u0018());
			return true;
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00023934 File Offset: 0x00021B34
		private bool TZ(SelectionTemPlateInfo P, ParameterBaseModel Q)
		{
			bool result = false;
			SelectionTemPlateInfo selectionTemPlateInfo = P;
			if (P == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.TZ(SelectionTemPlateInfo, ParameterBaseModel)).MethodHandle;
				}
				selectionTemPlateInfo = \u000C\u0016\u0003.\u0018();
			}
			SelectionTemPlateInfo u000C = selectionTemPlateInfo;
			\u0005\u0003\u0003.\u0018(Q, \u000E\u0003\u0003.\u0018(u000C));
			if (\u001B\u0003\u0003.\u0018(u000C) != '\0')
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
				char c = \u001B\u0003\u0003.\u0018(u000C);
				\u0001\u0003\u0003.\u0018(Q, \u0006\u000B\u0014.\u0018(ref c));
			}
			else
			{
				\u0001\u0003\u0003.\u0018(Q, "-");
			}
			\u001B\u0018\u0014.\u0003(Q, \u0008\u0003\u0003.\u0018(\u0007\u0003\u0003.\u0018(Q)));
			\u0006\u0003\u0003.\u0018(\u0016\u0018\u0014.\u0003(Q));
			List<SelectionParameter>.Enumerator enumerator = \u001D\u0018\u0014.\u0018(\u0010\u0003\u0003.\u0018(u000C));
			try
			{
				while (\u0017\u0018\u0014.\u0018(ref enumerator))
				{
					UI_MainWindow.\u0012\u000A\u0018 u0012_u000A_u = new UI_MainWindow.\u0012\u000A\u0018();
					u0012_u000A_u.\u000C = \u0004\u0018\u0014.\u0018(ref enumerator);
					if (\u000B\u0020\u0014.\u0014(u0012_u000A_u.\u000C) != SelectionParameterType.Revit)
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
						if (\u000B\u0020\u0014.\u0014(u0012_u000A_u.\u000C) != SelectionParameterType.Variable)
						{
							if (\u000B\u0020\u0014.\u0014(u0012_u000A_u.\u000C) != SelectionParameterType.CustomText)
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
								if (\u000B\u0020\u0014.\u0014(u0012_u000A_u.\u000C) != SelectionParameterType.CustemSeparator)
								{
									continue;
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
							\u0009\u0018\u0014.\u0018(\u0016\u0018\u0014.\u0003(Q), u0012_u000A_u.\u000C);
							continue;
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
					SelectionParameter selectionParameter = Enumerable.FirstOrDefault<SelectionParameter>(\u0012\u0018\u0014.\u0003(Q), new Func<SelectionParameter, bool>(u0012_u000A_u.\u0018));
					if (selectionParameter != null)
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
						\u001C\u0018\u0014.\u0018(\u0012\u0018\u0014.\u0003(Q), selectionParameter);
						\u0009\u0018\u0014.\u0018(\u0016\u0018\u0014.\u0003(Q), selectionParameter);
					}
					else
					{
						result = true;
					}
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
				((IDisposable)enumerator).Dispose();
			}
			return result;
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x00023B10 File Offset: 0x00021D10
		private void IZ(SheetInfo P, bool Q)
		{
			try
			{
				bool flag = false;
				if (\u000B\u0014\u0003.\u0018(this.PF))
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.IZ(SheetInfo, bool)).MethodHandle;
					}
					flag = true;
				}
				if (!flag)
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
					if (Q)
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
						bool flag2 = false;
						List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(Enumerable.ToList<SheetInfo>(\u0010\u000E\u0018.\u0018()));
						try
						{
							while (\u0019\u000E\u0018.\u0018(ref enumerator))
							{
								if (\u000C\u000C\u0014.\u0018(ref enumerator) == P)
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
									flag2 = true;
									goto IL_A4;
								}
							}
							for (;;)
							{
								switch (2)
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
						IL_A4:
						if (!flag2)
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
							\u0007\u000E\u0018.\u0018(\u0010\u000E\u0018.\u0018(), P);
						}
					}
					else
					{
						\u0018\u0016\u0003.\u0018(\u0010\u000E\u0018.\u0018(), P);
					}
					IEnumerable<SheetInfo> enumerable = \u0010\u000E\u0018.\u0018();
					Func<SheetInfo, bool> func;
					if ((func = UI_MainWindow.<>c.\u0012) == null)
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
						func = (UI_MainWindow.<>c.\u0012 = new Func<SheetInfo, bool>(UI_MainWindow.<>c.\u000C.\u001E));
					}
					int num = \u0002\u0005\u0018.\u0018(Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable, func)));
					int num2 = \u0002\u0005\u0018.\u0018(\u0010\u000E\u0018.\u0018()) - num;
					int num3 = \u0002\u0005\u0018.\u0018(\u0010\u000E\u0018.\u0018());
					\u0018\u0009\u0014.\u0018(this.QR, \u0007\u000C\u0003.\u0018(\u001C\u0009\u0018.\u0006, num, num2, num3));
				}
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "SheetInfo_CheckedOrUnchecked");
			}
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x00023CD4 File Offset: 0x00021ED4
		public void UpdateLabelCount(List<SheetInfo> lstSheetInfo)
		{
			try
			{
				Func<SheetInfo, bool> func;
				if ((func = UI_MainWindow.<>c.\u000D) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.UpdateLabelCount(List<SheetInfo>)).MethodHandle;
					}
					func = (UI_MainWindow.<>c.\u000D = new Func<SheetInfo, bool>(UI_MainWindow.<>c.\u000C.\u0002));
				}
				int num = \u0002\u0005\u0018.\u0018(Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(lstSheetInfo, func)));
				int num2 = \u0002\u0005\u0018.\u0018(lstSheetInfo) - num;
				int num3 = \u0002\u0005\u0018.\u0018(lstSheetInfo);
				\u0018\u0009\u0014.\u0018(this.QR, \u0007\u000C\u0003.\u0018(\u001C\u0009\u0018.\u0006, num, num2, num3));
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "UpdateLabelCount");
			}
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00023D98 File Offset: 0x00021F98
		private void cmbSheetAndViewSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			\u0009\u0019\u0018.\u0018(this.JF, 0);
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x00023DB4 File Offset: 0x00021FB4
		private void SZ()
		{
			this.UZ();
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x00023DC8 File Offset: 0x00021FC8
		private void UZ()
		{
			if (\u0020\u000E\u0018.\u0003(this._viewModel) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.UZ()).MethodHandle;
				}
				\u0014\u0016\u0003.\u0018(this._viewModel, \u0003\u0016\u0003.\u0018(this._viewModel, Enumerable.ToList<ViewSheetSetInfo>(\u0001\u0014\u0014.\u0003(\u0016\u000E\u0018.\u0003(this._viewModel)))));
				return;
			}
			List<long> list = \u0003\u0016\u0003.\u0018(this._viewModel, Enumerable.ToList<ViewSheetSetInfo>(\u0001\u0014\u0014.\u0003(\u0016\u000E\u0018.\u0003(this._viewModel))));
			if (list != null)
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
				\u0009\u000C\u0014.\u0018(\u0020\u000E\u0018.\u0003(this._viewModel), list);
				return;
			}
			\u0014\u0016\u0003.\u0018(this._viewModel, \u0001\u000B\u000F.\u000C);
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x00023E88 File Offset: 0x00022088
		private void Window_Closed(object sender, EventArgs e)
		{
			\u0002\u0015\u0014.\u0018(true);
			\u0018\u0018\u0003.\u0018(true);
			\u0016\u0016\u0003.\u0018(new SheetInfo.CheckedOrUncheckedHandler(this.IZ));
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x00023EB4 File Offset: 0x000220B4
		private void CustomParam_MenuItem_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				UI_MainWindow.\u000D\u000A\u0018 u000D_u000A_u = new UI_MainWindow.\u000D\u000A\u0018();
				u000D_u000A_u.\u000C = \u0006\u000B\u000F.\u000C(sender);
				if (u000D_u000A_u.\u000C != null)
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.CustomParam_MenuItem_Click(object, RoutedEventArgs)).MethodHandle;
					}
					DataGridTextColumn dataGridTextColumn = \u0008\u000B\u000F.\u000C(Enumerable.FirstOrDefault<DataGridColumn>(\u0002\u0014\u0003.\u0018(this.HF), new Func<DataGridColumn, bool>(u000D_u000A_u.\u0018)));
					if (dataGridTextColumn != null)
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
						\u0013\u0016\u0003.\u0018(\u0002\u0014\u0003.\u0018(this.HF), dataGridTextColumn);
						\u001C\u0016\u0003.\u0018(this.UJ, \u0001\u0017\u0018.\u0018(\u000D\u0016\u0003.\u0018(u000D_u000A_u.\u000C)));
					}
					else
					{
						this.LZ(\u0001\u0017\u0018.\u0018(\u000D\u0016\u0003.\u0018(u000D_u000A_u.\u000C)));
						\u000F\u0016\u0003.\u0018(u000D_u000A_u.\u000C, \u0004\u0004\u0014.\u0018(\u000B\u0004\u0014.\u0018(\u0012\u0016\u0003.\u0018()), IntPtr.Zero, \u001A\u0004\u0014.\u0018(), \u001D\u0004\u0014.\u0018()));
					}
				}
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "CustomParam_MenuItem_Click");
			}
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x00023FDC File Offset: 0x000221DC
		private void LZ(string P)
		{
			DataGridLength u;
			\u0009\u0016\u0003.\u0018(ref u, 100.0);
			\u0019\u0017\u0014.\u0018(this.UJ, P);
			\u0008\u000C\u0003.\u0018(this, P);
			this.NZ();
			object u000C = \u0002\u0014\u0003.\u0018(this.HF);
			int u2 = \u001E\u0014\u0003.\u0018(\u0002\u0014\u0003.\u0018(this.HF)) - 1;
			DataGridTextColumn dataGridTextColumn = \u0017\u0014\u0003.\u0018();
			\u0015\u0014\u0003.\u0018(dataGridTextColumn, P);
			\u0011\u0014\u0003.\u0018(dataGridTextColumn, u);
			\u0020\u0014\u0003.\u0018(dataGridTextColumn, \u001F\u0014\u0003.\u0018(\u0014\u001E\u0018.\u0018("CustomParamWithColumns[", P, "]")));
			\u000A\u0014\u0003.\u0018(dataGridTextColumn, true);
			\u0009\u0014\u0003.\u0018(u000C, u2, dataGridTextColumn);
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00024078 File Offset: 0x00022278
		public System.Windows.Point GetMousePosition()
		{
			System.Drawing.Point point = \u001F\u0016\u0003.\u0018();
			return new System.Windows.Point((double)\u0020\u0016\u0003.\u0018(ref point), (double)\u000A\u0016\u0003.\u0018(ref point));
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x000240A8 File Offset: 0x000222A8
		public void Refresh()
		{
			\u0003\u000E\u0018.\u0003(this._viewModel, \u0015\u0016\u0003.\u0018(\u0017\u001B\u0014.\u0018()));
			List<ViewSheet> u = \u0014\u000E\u0018.\u0018(\u000E\u0005\u0018.\u0003(this._viewModel));
			\u001B\u000C\u0003.\u0018(\u000C\u000A\u0018.\u0014(\u0017\u001B\u0014.\u0018(), u));
			object u000C = \u0003\u0007\u0014.\u0018();
			Comparison<SheetInfo> u2;
			if ((u2 = UI_MainWindow.<>c.\u001C) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.Refresh()).MethodHandle;
				}
				u2 = (UI_MainWindow.<>c.\u001C = new Comparison<SheetInfo>(UI_MainWindow.<>c.\u000C.\u0004));
			}
			\u0011\u0016\u0003.\u0018(u000C, u2);
			\u001C\u0018\u0003.\u0018(this._viewModel, \u0003\u0007\u0014.\u0018());
			\u001C\u000C\u0014.\u0018(\u0012\u000E\u0018.\u0003(this._viewModel));
			\u0005\u000C\u0003.\u0018(\u000C\u000A\u0018.\u0012(\u0017\u001B\u0014.\u0018(), \u0018\u000E\u0018.\u0018(\u000E\u0005\u0018.\u0003(this._viewModel)), \u0005\u0005\u0018.\u0018(\u000E\u0005\u0018.\u0003(this._viewModel))));
			this.HZ();
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x0002419C File Offset: 0x0002239C
		private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (\u0010\u000B\u000F.\u000C(\u0017\u0016\u0003.\u0018(e)) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.TabControl_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				return;
			}
			\u0008\u0013\u0014.\u0018(this.VF, Visibility.Visible);
			if (\u000B\u0014\u0003.\u0018(this.PF))
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
				\u0008\u0013\u0014.\u0018(this.KF, Visibility.Visible);
				\u0014\u0019\u0018.\u0018(this.KF, false);
				\u0008\u0013\u0014.\u0018(this.GF, Visibility.Visible);
			}
			else
			{
				\u0008\u0013\u0014.\u0018(this.KF, Visibility.Visible);
				\u0008\u0013\u0014.\u0018(this.GF, Visibility.Collapsed);
			}
			\u000B\u0014\u0003.\u0018(this.SF);
			if (\u000D\u0007\u0018.\u0018(this.KJ) == 3)
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
				\u0008\u0013\u0014.\u0018(this.VF, Visibility.Hidden);
			}
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x00024268 File Offset: 0x00022468
		private void TabApp_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (\u0010\u000B\u000F.\u000C(sender) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.TabApp_PreviewMouseLeftButtonDown(object, MouseButtonEventArgs)).MethodHandle;
				}
				TabItem tabItem = \u0019\u000B\u000F.\u000C(\u0017\u0016\u0003.\u0018(e));
				if (tabItem != null)
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
					if (\u0002\u0005\u0018.\u0018(\u0010\u000E\u0018.\u0018()) == 0)
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
						\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u0015);
						\u001D\u000B\u0018.\u0018(e, true);
						return;
					}
					if (\u000F\u0002\u0018.\u0018(\u001E\u0016\u0003.\u0018(tabItem), "tabCreate"))
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
						\u0019\u0014\u0003.\u0018(this.IF);
						\u001A\u0014\u0003.\u0018(tabItem, true);
					}
				}
			}
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x00024318 File Offset: 0x00022518
		private void DgSheets_Sorting(object sender, DataGridSortingEventArgs e)
		{
			try
			{
				ListCollectionView u000C = \u0016\u001D\u000F.\u000C(\u0010\u0006\u0018.\u0018(\u0008\u0012\u0014.\u0018(this.HF)));
				if (\u001D\u0016\u0003.\u0018(e) != null)
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.DgSheets_Sorting(object, DataGridSortingEventArgs)).MethodHandle;
					}
					if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u0010\u0016\u0003.\u0018(\u001D\u0016\u0003.\u0018(e))), \u001C\u0009\u0018.\u0013))
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
						ListSortDirection? listSortDirection = \u0007\u0016\u0003.\u0018(\u001D\u0016\u0003.\u0018(e));
						ListSortDirection listSortDirection2 = ListSortDirection.Ascending;
						if (\u0019\u0016\u0003.\u0018(ref listSortDirection) == listSortDirection2 & \u000B\u0016\u0003.\u0018(ref listSortDirection))
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
							\u001A\u0016\u0003.\u0018(u000C, new \u0016\u0017\u0018(false));
							\u0004\u0016\u0003.\u0018(\u001D\u0016\u0003.\u0018(e), new ListSortDirection?(ListSortDirection.Descending));
						}
						else
						{
							\u001A\u0016\u0003.\u0018(u000C, new \u0016\u0017\u0018(true));
							\u0004\u0016\u0003.\u0018(\u001D\u0016\u0003.\u0018(e), new ListSortDirection?(ListSortDirection.Ascending));
						}
						\u0002\u0016\u0003.\u0018(e, true);
					}
				}
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "DgSheets_Sorting");
			}
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0002443C File Offset: 0x0002263C
		private void DgSheets_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				DependencyObject dependencyObject = \u0006\u001D\u000F.\u000C(\u000F\u0012\u0014.\u0018(e));
				while (dependencyObject != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.DgSheets_PreviewMouseRightButtonDown(object, MouseButtonEventArgs)).MethodHandle;
					}
					if (\u001D\u000B\u000F.\u000C(dependencyObject) != null)
					{
						break;
					}
					for (;;)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					if (\u001A\u000B\u000F.\u000C(dependencyObject) != null)
					{
						for (;;)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							goto IL_59;
						}
					}
					else
					{
						dependencyObject = \u0016\u001C\u0014.\u0018(dependencyObject);
					}
				}
				IL_59:
				if (dependencyObject == null)
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
				}
				else
				{
					if (\u001D\u000B\u000F.\u000C(dependencyObject) != null)
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
						\u0018\u000F\u0003.\u0018(this.HF, \u000B\u000B\u000F.\u000C(\u001A\u0009\u0014.\u0003(this.HF, "rowContextMenu")));
						\u0016\u000F\u0003.\u0018(\u0006\u0016\u0003.\u0018(this.HF), this.HF);
						\u0003\u000F\u0003.\u0018(\u0006\u0016\u0003.\u0018(this.HF), true);
						\u001D\u000B\u0018.\u0018(e, true);
					}
					if (\u001A\u000B\u000F.\u000C(dependencyObject) != null)
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
						if (Enumerable.Any<string>(this.YJ))
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
							\u0018\u000F\u0003.\u0018(this.HF, \u0014\u000F\u0003.\u0018());
							List<string>.Enumerator enumerator = \u0008\u0015\u0014.\u0018(this.YJ);
							try
							{
								while (\u0010\u0015\u0014.\u0018(ref enumerator))
								{
									string u = \u0006\u0015\u0014.\u0018(ref enumerator);
									MenuItem menuItem = \u000C\u000F\u0003.\u0018();
									\u000E\u0016\u0003.\u0018(menuItem, u);
									MenuItem menuItem2 = menuItem;
									if (\u0007\u0017\u0014.\u0018(this.UJ, u))
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
										object u000C = menuItem2;
										System.Windows.Controls.Image image = \u0005\u0016\u0003.\u0018();
										\u001B\u0016\u0003.\u0018(image, \u0004\u0004\u0014.\u0018(\u000B\u0004\u0014.\u0018(\u0012\u0016\u0003.\u0018()), IntPtr.Zero, \u001A\u0004\u0014.\u0018(), \u001D\u0004\u0014.\u0018()));
										\u000F\u0016\u0003.\u0018(u000C, image);
									}
									\u0001\u0016\u0003.\u0018(menuItem2, u);
									\u0008\u0016\u0003.\u0018(menuItem2, new RoutedEventHandler(this.CustomParam_MenuItem_Click));
									\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0006\u0016\u0003.\u0018(this.HF)), menuItem2);
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
								((IDisposable)enumerator).Dispose();
							}
						}
					}
				}
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "DgSheets_PreviewMouseRightButtonDown");
			}
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x00024694 File Offset: 0x00022894
		private void DgSheets_Loaded(object sender, RoutedEventArgs e)
		{
			if (\u000D\u000F\u0003.\u0018() != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.DgSheets_Loaded(object, RoutedEventArgs)).MethodHandle;
				}
				DataGrid dataGrid = \u0007\u000B\u000F.\u000C(sender);
				if (dataGrid != null)
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
					for (int i = 0; i < \u001E\u0014\u0003.\u0018(\u0002\u0014\u0003.\u0018(dataGrid)) - 1; i++)
					{
						\u0011\u0014\u0003.\u0018(\u001C\u000F\u0003.\u0018(\u0002\u0014\u0003.\u0018(dataGrid), i), \u000F\u000F\u0003.\u0018(\u0012\u000F\u0003.\u0018(\u000D\u000F\u0003.\u0018(), i)));
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
			}
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00024728 File Offset: 0x00022928
		private void DgSheets_Unloaded(object sender, RoutedEventArgs e)
		{
			DataGrid dataGrid = \u0007\u000B\u000F.\u000C(sender);
			if (dataGrid != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.DgSheets_Unloaded(object, RoutedEventArgs)).MethodHandle;
				}
				IEnumerable<DataGridColumn> enumerable = \u0002\u0014\u0003.\u0018(dataGrid);
				Func<DataGridColumn, double> func;
				if ((func = UI_MainWindow.<>c.\u0013) == null)
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
					func = (UI_MainWindow.<>c.\u0013 = new Func<DataGridColumn, double>(UI_MainWindow.<>c.\u000C.\u001D));
				}
				\u0013\u000F\u0003.\u0018(Enumerable.ToList<double>(Enumerable.Select<DataGridColumn, double>(enumerable, func)));
			}
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00024798 File Offset: 0x00022998
		private void DgViews_Loaded(object sender, RoutedEventArgs e)
		{
			if (\u0009\u000F\u0003.\u0018() != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.DgViews_Loaded(object, RoutedEventArgs)).MethodHandle;
				}
				DataGrid dataGrid = \u0007\u000B\u000F.\u000C(sender);
				if (dataGrid != null)
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
					for (int i = 0; i < \u001E\u0014\u0003.\u0018(\u0002\u0014\u0003.\u0018(dataGrid)) - 1; i++)
					{
						\u0011\u0014\u0003.\u0018(\u001C\u000F\u0003.\u0018(\u0002\u0014\u0003.\u0018(dataGrid), i), \u000F\u000F\u0003.\u0018(\u0012\u000F\u0003.\u0018(\u0009\u000F\u0003.\u0018(), i)));
					}
					for (;;)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
				}
			}
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0002482C File Offset: 0x00022A2C
		private void DgViews_Unloaded(object sender, RoutedEventArgs e)
		{
			DataGrid dataGrid = \u0007\u000B\u000F.\u000C(sender);
			if (dataGrid != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.DgViews_Unloaded(object, RoutedEventArgs)).MethodHandle;
				}
				IEnumerable<DataGridColumn> enumerable = \u0002\u0014\u0003.\u0018(dataGrid);
				Func<DataGridColumn, double> func;
				if ((func = UI_MainWindow.<>c.\u0009) == null)
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
					func = (UI_MainWindow.<>c.\u0009 = new Func<DataGridColumn, double>(UI_MainWindow.<>c.\u000C.\u001A));
				}
				\u000A\u000F\u0003.\u0018(Enumerable.ToList<double>(Enumerable.Select<DataGridColumn, double>(enumerable, func)));
			}
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x0002489C File Offset: 0x00022A9C
		private void BtnSettings_Click(object sender, RoutedEventArgs e)
		{
			if (\u000D\u0007\u0018.\u0018(this.KJ) != 3)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.BtnSettings_Click(object, RoutedEventArgs)).MethodHandle;
				}
				this.GJ = \u000D\u0007\u0018.\u0018(this.KJ);
				\u0009\u0019\u0018.\u0018(this.KJ, 3);
				for (int i = 0; i < 3; i++)
				{
					TabItem tabItem = \u0019\u000B\u000F.\u000C(\u0020\u000F\u0003.\u0018(\u000D\u000F\u0014.\u0018(this.KJ), i));
					if (tabItem != null)
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
						\u0014\u0019\u0018.\u0018(tabItem, false);
						\u0004\u001C\u0014.\u0018(tabItem, 0.5);
						\u0008\u0013\u0014.\u0018(this.VF, Visibility.Collapsed);
						\u0008\u0013\u0014.\u0018(this.EF, Visibility.Collapsed);
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
				return;
			}
			if (this.GJ != -1)
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
				\u0008\u0013\u0014.\u0018(this.VF, Visibility.Visible);
				\u0008\u0013\u0014.\u0018(this.EF, Visibility.Visible);
				for (int j = 0; j < 3; j++)
				{
					TabItem tabItem2 = \u0019\u000B\u000F.\u000C(\u0020\u000F\u0003.\u0018(\u000D\u000F\u0014.\u0018(this.KJ), j));
					if (tabItem2 != null)
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
						\u0014\u0019\u0018.\u0018(tabItem2, true);
						\u0004\u001C\u0014.\u0018(tabItem2, 1.0);
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
				if (this.GJ == 2)
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
					this.AJ = false;
				}
				\u0009\u0019\u0018.\u0018(this.KJ, this.GJ);
				this.GJ = -1;
			}
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00024A14 File Offset: 0x00022C14
		private void SettingUserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001F\u000F\u0003.\u0018(this.LF);
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00024A2C File Offset: 0x00022C2C
		private void EZ()
		{
			\u0010\u000C\u0003.\u0018(this, \u000D\u000C\u0014.\u0003(this._viewModel));
			bool? flag = \u001B\u0001\u0018.\u0018(this.BF);
			this.GZ(\u000F\u0014\u0003.\u0018(ref flag), \u0003\u0007\u0014.\u0018(), \u0014\u0007\u0014.\u0018(), \u0011\u000F\u0003.\u0018(this));
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x00024A80 File Offset: 0x00022C80
		private void GZ(bool P, IEnumerable<SheetInfo> Q, IEnumerable<SheetInfo> J, IEnumerable<long> F)
		{
			UI_MainWindow.\u001C\u000A\u0018 u001C_u000A_u = new UI_MainWindow.\u001C\u000A\u0018();
			u001C_u000A_u.\u000C = F;
			IEnumerable<SheetInfo> enumerable;
			if (!P)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.GZ(bool, IEnumerable<SheetInfo>, IEnumerable<SheetInfo>, IEnumerable<long>)).MethodHandle;
				}
				enumerable = J;
			}
			else
			{
				enumerable = Q;
			}
			IEnumerable<SheetInfo> enumerable2 = enumerable;
			bool? flag = \u001B\u0001\u0018.\u0018(this.CF);
			if (\u000F\u0014\u0003.\u0018(ref flag))
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
				\u0012\u000C\u0014.\u0003(this._viewModel, Enumerable.ToList<SheetInfo>(enumerable2), Enumerable.ToList<long>(u001C_u000A_u.\u000C));
				enumerable2 = Enumerable.Where<SheetInfo>(enumerable2, new Func<SheetInfo, bool>(u001C_u000A_u.\u0018));
			}
			object viewModel = this._viewModel;
			IEnumerable<SheetInfo> enumerable3 = enumerable2;
			Func<SheetInfo, long> func;
			if ((func = UI_MainWindow.<>c.\u000A) == null)
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
				func = (UI_MainWindow.<>c.\u000A = new Func<SheetInfo, long>(UI_MainWindow.<>c.\u000C.\u000B));
			}
			\u0001\u0005\u0018.\u0003(viewModel, Enumerable.ToList<long>(Enumerable.Select<SheetInfo, long>(enumerable3, func)));
			if (P)
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
				\u001C\u000C\u0014.\u0018(\u0012\u000E\u0018.\u0003(this._viewModel));
				return;
			}
			\u001C\u000C\u0014.\u0018(\u001D\u000E\u0018.\u0003(this._viewModel));
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x00024B84 File Offset: 0x00022D84
		private void BtnRefresh_Click(object sender, RoutedEventArgs e)
		{
			bool? flag = \u001B\u0001\u0018.\u0018(this.BF);
			bool flag2 = \u000F\u0014\u0003.\u0018(ref flag);
			\u0015\u000F\u0003.\u0018(this);
			\u0007\u0018\u0003.\u0018(this.BF, new bool?(flag2));
			\u0007\u0018\u0003.\u0018(this.QF, new bool?(!flag2));
			\u000E\u000C\u0003.\u0018(\u001D\u0017\u0014.\u0018());
			\u000C\u000A\u0018.\u0004(\u0017\u001B\u0014.\u0018(), \u0014\u0014\u0003.\u0018(), \u0018\u0014\u0003.\u0018(), false);
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x00024BFC File Offset: 0x00022DFC
		private void DgViews_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				DependencyObject dependencyObject = \u0006\u001D\u000F.\u000C(\u000F\u0012\u0014.\u0018(e));
				while (dependencyObject != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.DgViews_PreviewMouseRightButtonDown(object, MouseButtonEventArgs)).MethodHandle;
					}
					if (\u001D\u000B\u000F.\u000C(dependencyObject) != null)
					{
						break;
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
					if (\u001A\u000B\u000F.\u000C(dependencyObject) != null)
					{
						for (;;)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							goto IL_59;
						}
					}
					else
					{
						dependencyObject = \u0016\u001C\u0014.\u0018(dependencyObject);
					}
				}
				IL_59:
				if (dependencyObject == null)
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
				}
				else if (\u001D\u000B\u000F.\u000C(dependencyObject) != null)
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
					\u0018\u000F\u0003.\u0018(this.MF, \u000B\u000B\u000F.\u000C(\u001A\u0009\u0014.\u0003(this.MF, "rowViewContextMenu")));
					\u0016\u000F\u0003.\u0018(\u0006\u0016\u0003.\u0018(this.MF), this.HF);
					\u0003\u000F\u0003.\u0018(\u0006\u0016\u0003.\u0018(this.MF), true);
					\u001D\u000B\u0018.\u0018(e, true);
				}
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\UI_MainWindow.xaml.cs", "DgViews_PreviewMouseRightButtonDown");
			}
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x00024D0C File Offset: 0x00022F0C
		protected override void ApplyLicense(bool isLicenseValid)
		{
			\u0014\u0019\u0018.\u0018(this.CF, isLicenseValid);
			\u0014\u0019\u0018.\u0018(this.WF, isLicenseValid);
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x00024D34 File Offset: 0x00022F34
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		public void InitializeComponent()
		{
			if (this.Q)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UI_MainWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.Q = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/ui/ui_mainwindow.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x00024D7C File Offset: 0x00022F7C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		internal Delegate TN(Type P, string Q)
		{
			return \u000E\u000B\u0018.\u0018(P, this, Q);
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x00024D94 File Offset: 0x00022F94
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		void IComponentConnector.CN(int P, object Q)
		{
			switch (P)
			{
			case 1:
				this.VJ = \u000A\u000B\u000F.\u000C(Q);
				\u000C\u0009\u0014.\u0018(this.VJ, new EventHandler(this.Window_Closed));
				\u001D\u000F\u0003.\u0018(this.VJ, new CancelEventHandler(this.Window_Closing));
				\u0004\u000F\u0003.\u0018(this.VJ, new EventHandler(this.Window_ContentRendered));
				\u0017\u000F\u0003.\u0018(this.VJ, new RoutedEventHandler(this.Window_Unloaded));
				return;
			case 2:
				this.DJ = \u0013\u001A\u000F.\u000C(Q);
				return;
			case 3:
				this.KJ = \u0020\u000B\u000F.\u000C(Q);
				\u000C\u001B\u0018.\u0018(this.KJ, new MouseButtonEventHandler(this.TabApp_PreviewMouseLeftButtonDown));
				\u0013\u000F\u0014.\u0018(this.KJ, new SelectionChangedEventHandler(this.TabControl_SelectionChanged));
				return;
			case 4:
				this.PF = \u001F\u000B\u000F.\u000C(Q);
				return;
			case 5:
				this.BF = \u0001\u0004\u000F.\u000C(Q);
				\u0018\u001B\u0018.\u0018(this.BF, new RoutedEventHandler(this.RdbSheets_Checked));
				return;
			case 6:
				this.QF = \u0001\u0004\u000F.\u000C(Q);
				\u0018\u001B\u0018.\u0018(this.QF, new RoutedEventHandler(this.RdbViews_Checked));
				return;
			case 7:
				this.JF = \u000F\u0004\u000F.\u000C(Q);
				return;
			case 8:
				this.FF = \u000F\u0004\u000F.\u000C(Q);
				return;
			case 9:
				this.RF = \u0011\u000B\u000F.\u000C(Q);
				return;
			case 10:
				this.HF = \u000E\u0004\u000F.\u000C(Q);
				\u0018\u0019\u0018.\u0018(this.HF, new RoutedEventHandler(this.DgSheets_Loaded));
				\u001E\u000F\u0003.\u0018(this.HF, new MouseButtonEventHandler(this.DgSheets_PreviewMouseRightButtonDown));
				\u0002\u000F\u0003.\u0018(this.HF, new DataGridSortingEventHandler(this.DgSheets_Sorting));
				\u0017\u000F\u0003.\u0018(this.HF, new RoutedEventHandler(this.DgSheets_Unloaded));
				return;
			case 11:
				this.NF = \u000F\u001A\u000F.\u000C(Q);
				return;
			case 12:
				this.ZF = \u0015\u000B\u000F.\u000C(Q);
				return;
			case 13:
				\u000C\u0019\u0018.\u0018(\u000E\u0002\u000F.\u000C(Q), new RoutedEventHandler(this.BtnPopUp_Click));
				return;
			case 14:
				this.MF = \u000E\u0004\u000F.\u000C(Q);
				\u0018\u0019\u0018.\u0018(this.MF, new RoutedEventHandler(this.DgViews_Loaded));
				\u001E\u000F\u0003.\u0018(this.MF, new MouseButtonEventHandler(this.DgViews_PreviewMouseRightButtonDown));
				\u0017\u000F\u0003.\u0018(this.MF, new RoutedEventHandler(this.DgViews_Unloaded));
				return;
			case 15:
				this.XF = \u000F\u001A\u000F.\u000C(Q);
				return;
			case 16:
				this.YF = \u000F\u0004\u000F.\u000C(Q);
				return;
			case 17:
				this.OF = \u0015\u000B\u000F.\u000C(Q);
				return;
			case 18:
				\u000C\u0019\u0018.\u0018(\u000E\u0002\u000F.\u000C(Q), new RoutedEventHandler(this.BtnPopUp_Click));
				return;
			case 19:
				this.CF = \u000F\u001A\u000F.\u000C(Q);
				return;
			case 20:
				this.WF = \u001B\u0002\u000F.\u000C(Q);
				return;
			case 21:
				this.TF = \u001F\u000B\u000F.\u000C(Q);
				return;
			case 22:
				this.IF = \u0017\u000B\u000F.\u000C(Q);
				return;
			case 23:
				this.SF = \u001F\u000B\u000F.\u000C(Q);
				return;
			case 24:
				this.UF = \u001E\u000B\u000F.\u000C(Q);
				return;
			case 25:
				this.LF = \u0002\u000B\u000F.\u000C(Q);
				return;
			case 26:
				this.EF = \u0004\u000B\u000F.\u000C(Q);
				return;
			case 27:
				this.GF = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.GF, new RoutedEventHandler(this.BtnRefresh_Click));
				return;
			case 28:
				this.AF = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.AF, new RoutedEventHandler(this.BtnSettings_Click));
				return;
			case 29:
				this.VF = \u0004\u000B\u000F.\u000C(Q);
				return;
			case 30:
				this.DF = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.DF, new RoutedEventHandler(this.BtnMainCancel_Click));
				return;
			case 31:
				this.KF = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.KF, new RoutedEventHandler(this.BtnBack_Click));
				return;
			case 32:
				this.PR = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.PR, new RoutedEventHandler(this.BtnNext_Click));
				return;
			case 33:
				this.BR = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.BR, new RoutedEventHandler(this.BtnCreate_Click));
				return;
			case 34:
				this.QR = \u001B\u0002\u000F.\u000C(Q);
				return;
			default:
				this.Q = true;
				return;
			}
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x00025234 File Offset: 0x00023434
		[CompilerGenerated]
		private bool AZ(SheetInfo P)
		{
			UI_MainWindow.\u0009\u000A\u0018 u0009_u000A_u = new UI_MainWindow.\u0009\u000A\u0018();
			u0009_u000A_u.\u000C = P;
			return \u0007\u000F\u0014.\u0018(this.LJ, new Predicate<SheetInfo>(u0009_u000A_u.\u0018));
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x00025268 File Offset: 0x00023468
		[CompilerGenerated]
		private void VZ(object P)
		{
			this.OZ(1);
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0002527C File Offset: 0x0002347C
		[CompilerGenerated]
		private void DZ(object P)
		{
			this.OZ(500);
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x00025294 File Offset: 0x00023494
		[CompilerGenerated]
		private void KZ()
		{
			this.CZ();
		}

		// Token: 0x0400020F RID: 527
		private List<string> YJ;

		// Token: 0x04000210 RID: 528
		[CompilerGenerated]
		private string OJ;

		// Token: 0x04000211 RID: 529
		[CompilerGenerated]
		private string CJ;

		// Token: 0x04000214 RID: 532
		[CompilerGenerated]
		private List<long> WJ;

		// Token: 0x04000215 RID: 533
		private bool TJ = true;

		// Token: 0x04000216 RID: 534
		[CompilerGenerated]
		private List<SelectionParameter> IJ;

		// Token: 0x04000217 RID: 535
		[CompilerGenerated]
		private List<SelectionParameter> SJ;

		// Token: 0x04000219 RID: 537
		private List<string> UJ = new List<string>();

		// Token: 0x0400021F RID: 543
		public MainWindowModel _viewModel;

		// Token: 0x04000220 RID: 544
		private List<SheetInfo> LJ = new List<SheetInfo>();

		// Token: 0x04000221 RID: 545
		private WindowState EJ;

		// Token: 0x04000222 RID: 546
		private int GJ = -1;

		// Token: 0x04000223 RID: 547
		private bool AJ = true;

		// Token: 0x04000224 RID: 548
		internal UI_MainWindow VJ;

		// Token: 0x04000225 RID: 549
		internal ProfileControl DJ;

		// Token: 0x04000226 RID: 550
		internal TabControl KJ;

		// Token: 0x04000227 RID: 551
		internal TabItem PF;

		// Token: 0x04000228 RID: 552
		internal RadioButton BF;

		// Token: 0x04000229 RID: 553
		internal RadioButton QF;

		// Token: 0x0400022A RID: 554
		internal ComboBox JF;

		// Token: 0x0400022B RID: 555
		internal ComboBox FF;

		// Token: 0x0400022C RID: 556
		internal WatermarkTextBox RF;

		// Token: 0x0400022D RID: 557
		internal DataGrid HF;

		// Token: 0x0400022E RID: 558
		internal CheckBox NF;

		// Token: 0x0400022F RID: 559
		internal DataGridTextColumn ZF;

		// Token: 0x04000230 RID: 560
		internal DataGrid MF;

		// Token: 0x04000231 RID: 561
		internal CheckBox XF;

		// Token: 0x04000232 RID: 562
		internal ComboBox YF;

		// Token: 0x04000233 RID: 563
		internal DataGridTextColumn OF;

		// Token: 0x04000234 RID: 564
		internal CheckBox CF;

		// Token: 0x04000235 RID: 565
		internal Label WF;

		// Token: 0x04000236 RID: 566
		internal TabItem TF;

		// Token: 0x04000237 RID: 567
		internal Export IF;

		// Token: 0x04000238 RID: 568
		internal TabItem SF;

		// Token: 0x04000239 RID: 569
		internal Create UF;

		// Token: 0x0400023A RID: 570
		internal SettingUserControl LF;

		// Token: 0x0400023B RID: 571
		internal StackPanel EF;

		// Token: 0x0400023C RID: 572
		internal Button GF;

		// Token: 0x0400023D RID: 573
		internal Button AF;

		// Token: 0x0400023E RID: 574
		internal StackPanel VF;

		// Token: 0x0400023F RID: 575
		internal Button DF;

		// Token: 0x04000240 RID: 576
		internal Button KF;

		// Token: 0x04000241 RID: 577
		internal Button PR;

		// Token: 0x04000242 RID: 578
		internal Button BR;

		// Token: 0x04000243 RID: 579
		internal Label QR;

		// Token: 0x04000244 RID: 580
		private bool Q;

		// Token: 0x0200018B RID: 395
		[CompilerGenerated]
		private sealed class \u0012\u000A\u0018
		{
			// Token: 0x0600110A RID: 4362 RVA: 0x0005B304 File Offset: 0x00059504
			internal bool \u0018(SelectionParameter \u000C)
			{
				return \u001D\u000A\u000F.\u0018(\u000C, this.\u000C);
			}

			// Token: 0x040007E7 RID: 2023
			public SelectionParameter \u000C;
		}

		// Token: 0x0200018C RID: 396
		[CompilerGenerated]
		private sealed class \u000D\u000A\u0018
		{
			// Token: 0x0600110C RID: 4364 RVA: 0x0005B334 File Offset: 0x00059534
			internal bool \u0018(DataGridColumn \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u0010\u0016\u0003.\u0018(\u000C)), \u0001\u0017\u0018.\u0018(\u000D\u0016\u0003.\u0018(this.\u000C)));
			}

			// Token: 0x040007E8 RID: 2024
			public MenuItem \u000C;
		}

		// Token: 0x0200018D RID: 397
		[CompilerGenerated]
		private sealed class \u001C\u000A\u0018
		{
			// Token: 0x0600110E RID: 4366 RVA: 0x0005B380 File Offset: 0x00059580
			internal bool \u0018(SheetInfo \u000C)
			{
				return Enumerable.Contains<long>(this.\u000C, \u0015\u0005\u0018.\u0014(\u000C).\u000C());
			}

			// Token: 0x040007E9 RID: 2025
			public IEnumerable<long> \u000C;
		}

		// Token: 0x0200018E RID: 398
		[CompilerGenerated]
		private sealed class \u0013\u000A\u0018
		{
			// Token: 0x06001110 RID: 4368 RVA: 0x0005B3C0 File Offset: 0x000595C0
			internal bool \u0018(string \u000C)
			{
				return \u001B\u0013\u0018.\u0018(\u000C, this.\u000C, true);
			}

			// Token: 0x040007EA RID: 2026
			public string \u000C;
		}

		// Token: 0x0200018F RID: 399
		[CompilerGenerated]
		private sealed class \u0009\u000A\u0018
		{
			// Token: 0x06001112 RID: 4370 RVA: 0x0005B3F0 File Offset: 0x000595F0
			internal bool \u0018(SheetInfo \u000C)
			{
				return this.\u000C == \u000C;
			}

			// Token: 0x040007EB RID: 2027
			public SheetInfo \u000C;
		}

		// Token: 0x02000190 RID: 400
		[CompilerGenerated]
		private sealed class \u000A\u000A\u0018
		{
			// Token: 0x06001114 RID: 4372 RVA: 0x0005B41C File Offset: 0x0005961C
			internal bool \u0018(SheetInfo \u000C)
			{
				UI_MainWindow.\u001F\u000A\u0018 u001F_u000A_u = new UI_MainWindow.\u001F\u000A\u0018();
				u001F_u000A_u.\u000C = \u000C;
				return \u0007\u000F\u0014.\u0018(this.\u000C, new Predicate<SheetInfo>(u001F_u000A_u.\u0018));
			}

			// Token: 0x040007EC RID: 2028
			public List<SheetInfo> \u000C;
		}

		// Token: 0x02000191 RID: 401
		[CompilerGenerated]
		private sealed class \u0020\u000A\u0018
		{
			// Token: 0x06001116 RID: 4374 RVA: 0x0005B464 File Offset: 0x00059664
			internal bool \u0018(DataGridColumn \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u0010\u0016\u0003.\u0018(\u000C)), this.\u000C);
			}

			// Token: 0x040007ED RID: 2029
			public string \u000C;
		}

		// Token: 0x02000192 RID: 402
		[CompilerGenerated]
		private sealed class \u001F\u000A\u0018
		{
			// Token: 0x06001118 RID: 4376 RVA: 0x0005B4A4 File Offset: 0x000596A4
			internal bool \u0018(SheetInfo \u000C)
			{
				return this.\u000C == \u000C;
			}

			// Token: 0x040007EE RID: 2030
			public SheetInfo \u000C;
		}
	}
}

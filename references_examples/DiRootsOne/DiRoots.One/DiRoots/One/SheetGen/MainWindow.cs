using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.Services;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetGen.Data;
using DiRoots.One.SheetGen.Messaging;
using DiRoots.One.SheetGen.Models.Interfaces;
using DiRoots.One.SheetGen.Profiles;
using DiRoots.One.SheetGen.Services;
using DiRoots.One.SheetGen.UI.Controls;
using DiRoots.One.SheetGen.ViewModels;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002D1 RID: 721
	public class MainWindow : DiRootsWindow, IMainWindow, IProgressBarReporter, IExecutable, IComponentConnector, IStyleConnector
	{
		// Token: 0x06001D63 RID: 7523 RVA: 0x000B9280 File Offset: 0x000B7480
		public MainWindow()
		{
			\u001C\u000C\u0007.\u0007(this, \u0011\u0015\u0005.\u000A());
			\u0008\u000E\u001D.\u000A(\u0009\u0007\u0018.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\MainWindow.xaml.cs", ".ctor");
			this.CS = \u0009\u001E\u0016.\u000A(DocumentAccessProvider.\u0004);
			this.ID = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(\u0009\u001E\u0016.\u000A(DocumentAccessProvider.\u0004)));
			\u0001\u001E\u0016.\u000A(this);
			\u0005\u001B\u000A.\u0018.\u001D<object>(this, new Action<object>(this.ProfileLoaded), Context.ProfileLoaded);
			\u0015\u001E\u0016.\u000A(new List<SheetInfo>());
			this.LS = \u000E\u001B\u000A.\u0004.GetService<\u0015\u0020<SheetInfo>>(false);
			this.XYR();
			\u000C\u001E\u0016.\u000A(this);
			\u0017\u001A\u000A.\u0007(this, \u000E\u001B\u000A.\u0004.GetService<MainWindowViewModel>(false));
			\u0014\u001A\u000A.\u000A(this.TS, new ViewListControl(this));
			\u0014\u001A\u000A.\u000A(this.IS, new RevisionControl(this));
			\u0005\u001B\u000A.\u0018.\u001D<object>(\u0012\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)), new Action<object>(\u0012\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)).RefreshSheets), Context.RefreshSheets);
			if (\u0007\u0011\u0016.\u000A() != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow..ctor()).MethodHandle;
				}
				\u0005\u001B\u000A.\u0018.\u001D<object>(\u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u0007(\u0007\u0011\u0016.\u000A())), new Action<object>(\u0010\u001C\u000E.\u001F(\u0007\u000C\u000A.\u0007(\u0007\u0011\u0016.\u000A())).RefreshViews), Context.RefreshViews);
			}
			\u0005\u001B\u000A.\u0018.\u001D<\u001B\u0014>(this, new Action<\u001B\u0014>(this.TYR));
			\u0005\u001B\u000A.\u0018.\u001D<\u001E\u0014>(this, new Action<\u001E\u0014>(this.OYR));
			\u0016\u000C\u0007.\u000A(this, "");
			\u000D\u0005\u0016.\u000A(\u000E\u001C\u000E.\u001F);
			\u0004\u000C\u000A.\u000A(this.ZS, 0);
			\u0005\u000E\u001D.\u000A(\u0009\u0007\u0018.\u000A(this), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\MainWindow.xaml.cs", ".ctor");
		}

		// Token: 0x1700082F RID: 2095
		// (get) Token: 0x06001D64 RID: 7524 RVA: 0x000B947C File Offset: 0x000B767C
		// (set) Token: 0x06001D65 RID: 7525 RVA: 0x000B9490 File Offset: 0x000B7690
		public static MainWindow CurrentMainWindow { get; set; }

		// Token: 0x17000830 RID: 2096
		// (get) Token: 0x06001D66 RID: 7526 RVA: 0x000B94A4 File Offset: 0x000B76A4
		private MainWindowViewModel ViewModel
		{
			get
			{
				MainWindowViewModel result;
				if ((result = this.C) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.get_ViewModel()).MethodHandle;
					}
					result = (this.C = \u0012\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)));
				}
				return result;
			}
		}

		// Token: 0x06001D67 RID: 7527 RVA: 0x000B94E8 File Offset: 0x000B76E8
		private void XYR()
		{
			\u001D\u0020\u0016.\u000A(ParametersManagerService.\u0008, this.ID);
			\u000A\u0020\u0016.\u000A(\u0007\u0020\u0016.\u000A());
			PleaseWait pleaseWait = \u001F\u0020\u0016.\u000A();
			\u0020\u000E\u0019.\u000A(this.CS, pleaseWait);
			\u0018\u0020\u000A.\u0007(pleaseWait);
			object u001F = \u0014\u0007\u0016.\u000A();
			Comparison<SheetInfo> u000A;
			if ((u000A = MainWindow.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.XYR()).MethodHandle;
				}
				u000A = (MainWindow.<>c.\u000A = new Comparison<SheetInfo>(MainWindow.<>c.\u001F.\u0019));
			}
			\u000D\u0016\u0016.\u000A(u001F, u000A);
		}

		// Token: 0x06001D68 RID: 7528 RVA: 0x000B9570 File Offset: 0x000B7770
		public void ProfileLoaded(object o)
		{
			\u001D\u0020\u0016.\u000A(ParametersManagerService.\u0008, this.ID);
			if (Enumerable.Any<Report>(\u001A\u001C\u001D.\u001D(\u0007\u0020\u0016.\u000A())))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.ProfileLoaded(object)).MethodHandle;
				}
				ReportsWindow u001F = \u0003\u0018\u001D.\u000A(\u0007\u0020\u0016.\u000A(), false);
				\u0015\u000D\u001D.\u000A(u001F, this);
				EventHandler u000A;
				if ((u000A = MainWindow.<>c.\u0007) == null)
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
					u000A = (MainWindow.<>c.\u0007 = new EventHandler(MainWindow.<>c.\u001F.\u0018));
				}
				\u0016\u0015\u0007.\u0007(u001F, u000A);
				\u0009\u0001\u0007.\u0007(u001F);
			}
			\u0005\u001B\u000A.\u0018.\u0019<object>(\u001C\u0016\u0016.\u000A(), Context.BuildColumns);
			\u0005\u001B\u000A.\u0018.\u0019<object>(\u001C\u0016\u0016.\u000A(), Context.UpdateOtherTabs);
		}

		// Token: 0x06001D69 RID: 7529 RVA: 0x000B9638 File Offset: 0x000B7838
		public void ExecutionFinished(bool isDelete = false)
		{
			this.PYR(100.0);
			\u0015\u0009\u000A.\u000A(this.ZD, true);
			if (!isDelete)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.ExecutionFinished(bool)).MethodHandle;
				}
				\u0005\u0013\u0019.\u000A(\u001A\u000E\u001D.\u000A(), this, 250.0);
			}
			this.PYR(0.0);
		}

		// Token: 0x06001D6A RID: 7530 RVA: 0x000B96A0 File Offset: 0x000B78A0
		public void ExcutionFailed()
		{
			this.PYR(0.0);
		}

		// Token: 0x06001D6B RID: 7531 RVA: 0x000B96BC File Offset: 0x000B78BC
		private void PYR(double F)
		{
			\u000E\u0015\u0007.\u000A(this.JR, \u0008\u0015\u0007.\u000A(F));
			\u0014\u001A\u000A.\u000A(this.NR, \u0004\u001E\u000A.\u000A(\u0007\u0018\u0019.\u000A(), \u0017\u0006\u0007.\u000A(" {0}%", F)));
		}

		// Token: 0x06001D6C RID: 7532 RVA: 0x000B9708 File Offset: 0x000B7908
		public void ReportProgress(int percent, string currentName, UpdateStates status)
		{
			\u000E\u0015\u0007.\u000A(this.JR, \u000E\u0016\u0019.\u000A(percent));
			object nr = this.NR;
			string[] array = \u001B\u001F\u000E.\u001F(5);
			array[0] = \u0007\u0018\u0019.\u000A();
			array[1] = " ";
			array[2] = \u000C\u0013\u0007.\u000A(ref percent);
			array[3] = "% - ";
			array[4] = currentName;
			\u0014\u001A\u000A.\u000A(nr, \u0014\u0006\u001D.\u000A(array));
		}

		// Token: 0x06001D6D RID: 7533 RVA: 0x000B976C File Offset: 0x000B796C
		private void OYR(\u001E\u0014 F)
		{
			MainWindow.\u0009\u001B u0009_u001B = new MainWindow.\u0009\u001B();
			u0009_u001B.\u001F = this;
			u0009_u001B.\u000A = F;
			if (!\u0004\u0020\u0016.\u000A(u0009_u001B.\u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.OYR(\u001E\u0014)).MethodHandle;
				}
				\u000C\u0018\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(this.ExcutionFailed));
			}
			else
			{
				\u000C\u0018\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(u0009_u001B.\u0007));
			}
			object u001F = \u001C\u0015\u0007.\u0007(this);
			DispatcherPriority u000A = DispatcherPriority.Background;
			Action u;
			if ((u = MainWindow.<>c.\u001D) == null)
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
				u = (MainWindow.<>c.\u001D = new Action(MainWindow.<>c.\u001F.\u0005));
			}
			\u0003\u0015\u0007.\u000A(u001F, u000A, u);
		}

		// Token: 0x06001D6E RID: 7534 RVA: 0x000B9820 File Offset: 0x000B7A20
		private void TYR(\u001B\u0014 F)
		{
			MainWindow.\u001F\u0011 u001F_u = new MainWindow.\u001F\u0011();
			u001F_u.\u001F = this;
			u001F_u.\u000A = F;
			\u000C\u0018\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(u001F_u.\u0007));
			object u001F = \u001C\u0015\u0007.\u0007(this);
			DispatcherPriority u000A = DispatcherPriority.Background;
			Action u;
			if ((u = MainWindow.<>c.\u0004) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.TYR(\u001B\u0014)).MethodHandle;
				}
				u = (MainWindow.<>c.\u0004 = new Action(MainWindow.<>c.\u001F.\u0016));
			}
			\u0003\u0015\u0007.\u000A(u001F, u000A, u);
		}

		// Token: 0x06001D6F RID: 7535 RVA: 0x000B98A0 File Offset: 0x000B7AA0
		private void dgSheets_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
		{
			\u0020\u0014 u = this.LS.\u000A(this.GL, e, new Func<IEnumerable<ISheetModel>>(this.QYR));
			\u000A\u0017.\u001F(this.GL, new EventHandler<DataGridCellEditEndingEventArgs>(this.dgSheets_CellEditEnding), u);
			\u0019\u0020\u0016.\u000A(\u0018\u0020\u0016.\u000A(this), false);
		}

		// Token: 0x06001D70 RID: 7536 RVA: 0x000B98F4 File Offset: 0x000B7AF4
		private void DataGrid_Unloaded(object sender, RoutedEventArgs e)
		{
			\u0014\u0016\u0019.\u000A(this.GL, DataGridEditingUnit.Row, true);
		}

		// Token: 0x06001D71 RID: 7537 RVA: 0x000B9914 File Offset: 0x000B7B14
		private void SelectAllSheets(object sender, RoutedEventArgs e)
		{
			CheckBox checkBox = \u0011\u000A\u000E.\u001F(sender);
			if (checkBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.SelectAllSheets(object, RoutedEventArgs)).MethodHandle;
				}
				object u001F = \u0012\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this));
				bool? flag = \u0003\u0015\u000A.\u000A(checkBox);
				\u0005\u0020\u0016.\u000A(u001F, \u0012\u0015\u000A.\u000A(ref flag));
			}
		}

		// Token: 0x06001D72 RID: 7538 RVA: 0x000B9968 File Offset: 0x000B7B68
		internal void IYR()
		{
			\u0005\u001B\u000A.\u0018.\u0004<object>(this, Context.ProfileLoaded);
			\u0005\u001B\u000A.\u0018.\u0004<object>(\u0007\u000C\u000A.\u001D(this), Context.RefreshSheets);
			\u0016\u0020\u0016.\u000A(\u0007\u0020\u0016.\u000A());
		}

		// Token: 0x06001D73 RID: 7539 RVA: 0x000B99B0 File Offset: 0x000B7BB0
		private void tabApp_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (\u0018\u0001\u0007.\u000A(e) == sender)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.tabApp_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				if (this.SS)
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
					this.SS = false;
					if (!\u0012\u0020\u0016.\u000A(\u0012\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this))))
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
						\u000F\u0020\u0016.\u000A(this.KS, new SelectionChangedEventHandler(this.tabApp_SelectionChanged));
						\u0004\u000C\u000A.\u000A(this.KS, 0);
						\u001B\u000C\u000A.\u0007(this.KS, new SelectionChangedEventHandler(this.tabApp_SelectionChanged));
						\u0005\u0013\u0019.\u000A(\u0006\u0020\u0016.\u000A(), this, 250.0);
						return;
					}
					return;
				}
			}
			if (\u0002\u0020\u0016.\u000A(\u0012\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this))))
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
				\u000B\u0020\u0016.\u0007(\u0012\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)), false);
				return;
			}
			if (\u0018\u0001\u0007.\u000A(e) == sender)
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
				if (!this.SS)
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
					\u0004\u000C\u000A.\u000A(this.KS, 0);
				}
			}
		}

		// Token: 0x06001D74 RID: 7540 RVA: 0x000B9AE0 File Offset: 0x000B7CE0
		private void tabApp_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			this.SS = true;
		}

		// Token: 0x06001D75 RID: 7541 RVA: 0x000B9AF4 File Offset: 0x000B7CF4
		private void wndMain_Closed(object sender, EventArgs e)
		{
			\u0013\u0020\u0016.\u000A(\u000E\u001B\u000A.\u0004.GetService<ICancellationManagerService>(false), true);
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\MainWindow.xaml.cs", "wndMain_Closed");
			if (\u0007\u0011\u0016.\u000A() != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.wndMain_Closed(object, EventArgs)).MethodHandle;
				}
				\u000A\u0011\u0016.\u000A(\u0007\u0011\u0016.\u000A(), false);
			}
			else
			{
				\u0014\u0020\u0016.\u000A(\u001E\u0020\u0016.\u000A());
			}
			\u001D\u0011\u0016.\u000A().IYR();
			\u0020\u0020\u0016.\u000A(\u0017\u0020\u0016.\u000A());
			\u000C\u001E\u0016.\u000A(\u001C\u001C\u000E.\u001F);
			\u000F\u0006\u0016.\u000A(true);
			\u0005\u001B\u000A.\u0018.\u0004<\u001B\u0014>(this);
			\u0005\u001B\u000A.\u0018.\u0004<\u001E\u0014>(this);
			\u0011\u0020\u0016.\u000A(\u001E\u0020\u0016.\u000A());
			\u000E\u001B\u000A.\u0004.Unregister<IMainWindow>();
			\u000E\u001B\u000A.\u0004.Unregister<UserSelectionContext>();
			\u000E\u001B\u000A.\u0004.Unregister<IPlaceholderRepository>();
			if (\u0007\u0011\u0016.\u000A() == null)
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
				\u001B\u0020\u0016.\u000A(ParametersManagerService.\u0008);
				\u0008\u0020\u0016.\u000A(\u0007\u0005\u0016.\u000A());
				\u000E\u0020\u0016.\u000A(Collector.\u0004);
				\u0010\u0020\u0016.\u000A(DocumentAccessProvider.\u0004);
				\u0004\u000F\u001D.\u000A(\u000E\u001B\u000A.\u0004);
				\u000E\u001B\u000A.\u0004 = \u000D\u001C\u000E.\u001F;
				\u001C\u0020\u0016.\u000A(\u000D\u0020\u0016.\u000A());
				\u0003\u0020\u0016.\u000A(\u0005\u001B\u000A.\u0018);
			}
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\MainWindow.xaml.cs", "wndMain_Closed");
		}

		// Token: 0x06001D76 RID: 7542 RVA: 0x000B9C5C File Offset: 0x000B7E5C
		private void wndMain_Closing(object sender, CancelEventArgs e)
		{
			if (\u0007\u0011\u0016.\u000A() != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.wndMain_Closing(object, CancelEventArgs)).MethodHandle;
				}
				if (\u001A\u0020\u0016.\u000A(\u0007\u0011\u0016.\u000A()))
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
					\u0019\u000B\u0007.\u001D(\u0007\u0011\u0016.\u000A());
				}
			}
		}

		// Token: 0x06001D77 RID: 7543 RVA: 0x000B9CAC File Offset: 0x000B7EAC
		private void dgSheets_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.BS = \u0003\u001C\u000E.\u001F;
		}

		// Token: 0x06001D78 RID: 7544 RVA: 0x000B9CC4 File Offset: 0x000B7EC4
		private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DataGridCell dataGridCell = \u001E\u0012\u000E.\u001F(sender);
			if (dataGridCell != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.DataGridCell_PreviewMouseLeftButtonDown(object, MouseButtonEventArgs)).MethodHandle;
				}
				object u001F = \u001A\u0001\u0018.\u000A(dataGridCell);
				if (\u0009\u0015\u0010.\u001F(u001F) != null)
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
					if (!\u001F\u0001\u0010.\u001F(u001F))
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
						this.BS = dataGridCell;
					}
				}
			}
		}

		// Token: 0x06001D79 RID: 7545 RVA: 0x000B9D2C File Offset: 0x000B7F2C
		private void dgSheets_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
		{
			bool flag = false;
			if (this.BS != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.dgSheets_BeginningEdit(object, DataGridBeginningEditEventArgs)).MethodHandle;
				}
				flag = true;
			}
			if (\u0001\u0020\u0016.\u000A(\u0012\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this))))
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
				\u0015\u0020\u0016.\u0007(\u0012\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)), false);
			}
			if (flag)
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
				\u000C\u0020\u0016.\u000A(e, true);
				\u0008\u000B\u0019.\u000A(this.GL);
				\u0008\u000B\u0019.\u000A(this.GL);
				return;
			}
			\u0019\u0020\u0016.\u000A(\u0012\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)), true);
		}

		// Token: 0x06001D7A RID: 7546 RVA: 0x000B9DD8 File Offset: 0x000B7FD8
		private void cmbSheetAndViewSet_DropDownClosed(object sender, EventArgs e)
		{
			\u0004\u000C\u000A.\u000A(this.ZS, 0);
		}

		// Token: 0x06001D7B RID: 7547 RVA: 0x000B9DF4 File Offset: 0x000B7FF4
		private void wndMain_Loaded(object sender, RoutedEventArgs e)
		{
			\u0014\u001A\u000A.\u000A(this.NR, \u0004\u001E\u000A.\u000A(\u0007\u0018\u0019.\u000A(), " 0%"));
		}

		// Token: 0x06001D7C RID: 7548 RVA: 0x000B9E20 File Offset: 0x000B8020
		private void dgSheets_Sorting(object sender, DataGridSortingEventArgs e)
		{
			try
			{
				ListCollectionView u001F = \u000F\u0009\u0010.\u001F(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.GL)));
				if (\u000D\u0009\u000A.\u000A(e) != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.dgSheets_Sorting(object, DataGridSortingEventArgs)).MethodHandle;
					}
					if (\u0008\u0013\u000A.\u000A(\u0010\u000B\u0019.\u001D(\u000D\u0009\u000A.\u000A(e)), "Sheet Number"))
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
						ListSortDirection? listSortDirection = \u001B\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e));
						ListSortDirection listSortDirection2 = ListSortDirection.Ascending;
						if (\u0008\u0009\u000A.\u000A(ref listSortDirection) == listSortDirection2 & \u000E\u0009\u000A.\u000A(ref listSortDirection))
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
							\u0010\u0009\u000A.\u000A(u001F, new \u0020\u0011(false));
							\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Descending));
						}
						else
						{
							\u0010\u0009\u000A.\u000A(u001F, new \u0020\u0011(true));
							\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Ascending));
						}
						\u0003\u0009\u000A.\u000A(e, true);
					}
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\MainWindow.xaml.cs", "dgSheets_Sorting");
			}
		}

		// Token: 0x06001D7D RID: 7549 RVA: 0x000B9F3C File Offset: 0x000B813C
		private IEnumerable<ISheetModel> QYR()
		{
			MainWindowViewModel mainWindowViewModel = \u0018\u0020\u0016.\u000A(this);
			ISheetModel[] array;
			if (mainWindowViewModel == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.QYR()).MethodHandle;
				}
				array = null;
			}
			else
			{
				IPlaceholdersViewModel placeholdersViewModel = \u001F\u0017\u0016.\u000A(mainWindowViewModel);
				if (placeholdersViewModel == null)
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
					array = null;
				}
				else
				{
					array = Enumerable.Cast<ISheetModel>(\u0009\u0020\u0016.\u000A(placeholdersViewModel));
				}
			}
			ISheetModel[] array2;
			if ((array2 = array) == null)
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
				array2 = Array.Empty<ISheetModel>();
			}
			List<SheetInfo> list = \u0014\u0007\u0016.\u000A();
			ISheetModel[] array3;
			if (list == null)
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
				array3 = null;
			}
			else
			{
				array3 = Enumerable.Cast<ISheetModel>(list);
			}
			ISheetModel[] array4;
			if ((array4 = array3) == null)
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
				array4 = Array.Empty<ISheetModel>();
			}
			IEnumerable<ISheetModel> enumerable = array4;
			return Enumerable.Concat<ISheetModel>(array2, enumerable);
		}

		// Token: 0x06001D7E RID: 7550 RVA: 0x000B9FE4 File Offset: 0x000B81E4
		protected override void ApplyLicense(bool isLicenseValid)
		{
			if (\u000A\u0017\u0016.\u0007(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.ApplyLicense(bool)).MethodHandle;
				}
				\u0015\u0009\u000A.\u000A(this.QS, isLicenseValid);
			}
		}

		// Token: 0x06001D7F RID: 7551 RVA: 0x000BA01C File Offset: 0x000B821C
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/mainwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001D80 RID: 7552 RVA: 0x000BA064 File Offset: 0x000B8264
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06001D81 RID: 7553 RVA: 0x000BA07C File Offset: 0x000B827C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.U = \u0006\u001C\u000E.\u001F(R);
				\u0016\u0015\u0007.\u0007(this.U, new EventHandler(this.wndMain_Closed));
				\u0017\u0015\u0007.\u0007(this.U, new CancelEventHandler(this.wndMain_Closing));
				\u0011\u000C\u000A.\u0007(this.U, new RoutedEventHandler(this.wndMain_Loaded));
				return;
			case 3:
				this.W = \u000F\u001C\u000E.\u001F(R);
				return;
			case 4:
				this.JR = \u0013\u000A\u000E.\u001F(R);
				return;
			case 5:
				this.NR = \u001A\u000A\u000E.\u001F(R);
				return;
			case 6:
				this.KR = \u001A\u000A\u000E.\u001F(R);
				return;
			case 7:
				this.US = \u001E\u0001\u0010.\u001F(R);
				return;
			case 8:
				this.WS = \u001E\u0001\u0010.\u001F(R);
				return;
			case 9:
				this.ZD = \u001E\u0001\u0010.\u001F(R);
				return;
			case 10:
				this.KS = \u001A\u0015\u0010.\u001F(R);
				\u0007\u0017\u0016.\u0007(this.KS, new MouseButtonEventHandler(this.tabApp_PreviewMouseDown));
				\u001B\u000C\u000A.\u0007(this.KS, new SelectionChangedEventHandler(this.tabApp_SelectionChanged));
				return;
			case 11:
				this.JS = \u000C\u0015\u0010.\u001F(R);
				return;
			case 12:
				this.KD = \u000B\u000A\u000E.\u001F(R);
				return;
			case 13:
				this.ES = \u000B\u000A\u000E.\u001F(R);
				return;
			case 14:
				this.NS = \u000B\u000A\u000E.\u001F(R);
				return;
			case 15:
				this.MS = \u000B\u000A\u000E.\u001F(R);
				return;
			case 16:
				this.VS = \u0019\u0009\u0010.\u001F(R);
				return;
			case 17:
				this.ZS = \u000B\u000A\u000E.\u001F(R);
				\u001C\u0018\u0005.\u000A(this.ZS, new EventHandler(this.cmbSheetAndViewSet_DropDownClosed));
				return;
			case 18:
				this.JD = \u001E\u0001\u0010.\u001F(R);
				return;
			case 19:
				this.XS = \u001E\u0001\u0010.\u001F(R);
				return;
			case 20:
				this.UD = \u0005\u0009\u0010.\u001F(R);
				return;
			case 21:
				this.GL = \u0020\u0001\u0010.\u001F(R);
				\u0004\u0002\u0019.\u000A(this.GL, new EventHandler<DataGridBeginningEditEventArgs>(this.dgSheets_BeginningEdit));
				\u0017\u0016\u0019.\u000A(this.GL, new EventHandler<DataGridCellEditEndingEventArgs>(this.dgSheets_CellEditEnding));
				\u0003\u0001\u0007.\u000A(this.GL, new MouseButtonEventHandler(this.dgSheets_PreviewMouseLeftButtonDown));
				\u001F\u001F\u0007.\u000A(this.GL, new DataGridSortingEventHandler(this.dgSheets_Sorting));
				\u001E\u0004\u0005.\u000A(this.GL, new RoutedEventHandler(this.DataGrid_Unloaded));
				return;
			case 22:
				\u0010\u0015\u000A.\u000A(\u0016\u0009\u0010.\u001F(R), new RoutedEventHandler(this.SelectAllSheets));
				return;
			case 23:
				this.PS = \u0010\u000A\u000E.\u001F(R);
				return;
			case 24:
				this.OS = \u0010\u000A\u000E.\u001F(R);
				return;
			case 25:
				this.TS = \u000C\u0015\u0010.\u001F(R);
				return;
			case 26:
				this.IS = \u000C\u0015\u0010.\u001F(R);
				return;
			case 27:
				this.QS = \u000C\u0015\u0010.\u001F(R);
				return;
			}
			this.R = true;
		}

		// Token: 0x06001D82 RID: 7554 RVA: 0x000BA398 File Offset: 0x000B8598
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IStyleConnector.AQ(int F, object R)
		{
			if (F == 2)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.AQ(int, object)).MethodHandle;
				}
				EventSetter eventSetter = \u001B\u0001\u0007.\u000A();
				\u0008\u0001\u0007.\u000A(eventSetter, UIElement.PreviewMouseLeftButtonDownEvent);
				\u000E\u0001\u0007.\u000A(eventSetter, new MouseButtonEventHandler(this.DataGridCell_PreviewMouseLeftButtonDown));
				\u000D\u0001\u0007.\u000A(\u0010\u0001\u0007.\u000A(\u000C\u000A\u000E.\u001F(R)), eventSetter);
			}
		}

		// Token: 0x06001D83 RID: 7555 RVA: 0x000BA3F8 File Offset: 0x000B85F8
		void IMainWindow.FG()
		{
			\u0009\u0001\u0007.\u001D(this);
		}

		// Token: 0x06001D84 RID: 7556 RVA: 0x000BA40C File Offset: 0x000B860C
		void IMainWindow.RG(EventHandler F)
		{
			\u0016\u0015\u0007.\u001D(this, F);
		}

		// Token: 0x06001D85 RID: 7557 RVA: 0x000BA420 File Offset: 0x000B8620
		void IMainWindow.DG(EventHandler F)
		{
			\u0012\u001E\u0016.\u000A(this, F);
		}

		// Token: 0x06001D86 RID: 7558 RVA: 0x000BA434 File Offset: 0x000B8634
		Window IMainWindow.HG()
		{
			return \u000D\u0011\u0016.\u0007(this);
		}

		// Token: 0x06001D87 RID: 7559 RVA: 0x000BA44C File Offset: 0x000B864C
		void IMainWindow.YG(Window F)
		{
			\u000C\u000E\u0007.\u001D(this, F);
		}

		// Token: 0x06001D88 RID: 7560 RVA: 0x000BA460 File Offset: 0x000B8660
		WindowState IMainWindow.CG()
		{
			return \u0011\u0004\u0005.\u0007(this);
		}

		// Token: 0x06001D89 RID: 7561 RVA: 0x000BA478 File Offset: 0x000B8678
		void IMainWindow.LG(WindowState F)
		{
			\u0019\u0005\u001D.\u001D(this, F);
		}

		// Token: 0x04000BD0 RID: 3024
		private readonly Document ID;

		// Token: 0x04000BD1 RID: 3025
		private readonly UIApplication CS;

		// Token: 0x04000BD2 RID: 3026
		private readonly \u0015\u0020<SheetInfo> LS;

		// Token: 0x04000BD3 RID: 3027
		private bool SS;

		// Token: 0x04000BD4 RID: 3028
		private MainWindowViewModel C;

		// Token: 0x04000BD6 RID: 3030
		private DataGridCell BS;

		// Token: 0x04000BD7 RID: 3031
		internal MainWindow U;

		// Token: 0x04000BD8 RID: 3032
		internal ProfileUserControl W;

		// Token: 0x04000BD9 RID: 3033
		internal ProgressBar JR;

		// Token: 0x04000BDA RID: 3034
		internal Label NR;

		// Token: 0x04000BDB RID: 3035
		internal Label KR;

		// Token: 0x04000BDC RID: 3036
		internal Button US;

		// Token: 0x04000BDD RID: 3037
		internal Button WS;

		// Token: 0x04000BDE RID: 3038
		internal Button ZD;

		// Token: 0x04000BDF RID: 3039
		internal TabControl KS;

		// Token: 0x04000BE0 RID: 3040
		internal TabItem JS;

		// Token: 0x04000BE1 RID: 3041
		internal ComboBox KD;

		// Token: 0x04000BE2 RID: 3042
		internal ComboBox ES;

		// Token: 0x04000BE3 RID: 3043
		internal ComboBox NS;

		// Token: 0x04000BE4 RID: 3044
		internal ComboBox MS;

		// Token: 0x04000BE5 RID: 3045
		internal LeftStripButton VS;

		// Token: 0x04000BE6 RID: 3046
		internal ComboBox ZS;

		// Token: 0x04000BE7 RID: 3047
		internal Button JD;

		// Token: 0x04000BE8 RID: 3048
		internal Button XS;

		// Token: 0x04000BE9 RID: 3049
		internal WatermarkTextBox UD;

		// Token: 0x04000BEA RID: 3050
		internal DataGrid GL;

		// Token: 0x04000BEB RID: 3051
		internal DataGridTextColumn PS;

		// Token: 0x04000BEC RID: 3052
		internal DataGridTextColumn OS;

		// Token: 0x04000BED RID: 3053
		internal TabItem TS;

		// Token: 0x04000BEE RID: 3054
		internal TabItem IS;

		// Token: 0x04000BEF RID: 3055
		internal TabItem QS;

		// Token: 0x04000BF0 RID: 3056
		private bool R;

		// Token: 0x020009A7 RID: 2471
		[CompilerGenerated]
		private sealed class \u0009\u001B
		{
			// Token: 0x06005371 RID: 21361 RVA: 0x001EC8B0 File Offset: 0x001EAAB0
			internal void \u0007()
			{
				\u0016\u0006\u0010.\u000A(this.\u001F, \u000B\u0006\u0010.\u000A(this.\u000A));
			}

			// Token: 0x04002510 RID: 9488
			public MainWindow \u001F;

			// Token: 0x04002511 RID: 9489
			public \u001E\u0014 \u000A;
		}

		// Token: 0x020009A8 RID: 2472
		[CompilerGenerated]
		private sealed class \u001F\u0011
		{
			// Token: 0x06005373 RID: 21363 RVA: 0x001EC8EC File Offset: 0x001EAAEC
			internal void \u0007()
			{
				\u0002\u0006\u0010.\u000A(this.\u001F, \u000F\u0006\u0010.\u000A(this.\u000A), \u0006\u0006\u0010.\u000A(this.\u000A), UpdateStates.Updated);
			}

			// Token: 0x04002512 RID: 9490
			public MainWindow \u001F;

			// Token: 0x04002513 RID: 9491
			public \u001B\u0014 \u000A;
		}
	}
}

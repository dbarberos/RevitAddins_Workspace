using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using A;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Excel;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.Profile;
using DiRoots.One.SheetLink.UI.Controls;
using DiRoots.One.SheetLink.ViewModels;

namespace DiRoots.One.SheetLink.UI.Windows
{
	// Token: 0x0200021D RID: 541
	public class MainWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x060014C2 RID: 5314 RVA: 0x00087338 File Offset: 0x00085538
		public MainWindow(UIDocument uiDoc)
		{
			\u001C\u000C\u0007.\u0007(this, \u0010\u0011\u000A.\u000A());
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\UI\\Windows\\MainWindow.xaml.cs", ".ctor");
			this.JY = uiDoc;
			\u0017\u001D\u0005.\u000A(this, new MainWindowModel());
			\u0020\u001D\u0005.\u000A(this);
			\u0013\u0017\u0018.\u000A(this);
			if (\u001F\u000C\u000A.\u001D(\u0011\u0020\u000A.\u0007(uiDoc)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow..ctor(UIDocument)).MethodHandle;
				}
				\u001D\u000C\u000A.\u0007(this.RC, Visibility.Collapsed);
				\u001D\u000C\u000A.\u0007(this.HC, Visibility.Collapsed);
			}
			\u0016\u000C\u0007.\u000A(this, "");
			\u0014\u000F.\u000F(\u0011\u0020\u000A.\u0007(uiDoc));
			\u0019\u0013\u0019.\u000A(false);
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\UI\\Windows\\MainWindow.xaml.cs", ".ctor");
		}

		// Token: 0x170005DC RID: 1500
		// (get) Token: 0x060014C3 RID: 5315 RVA: 0x000873FC File Offset: 0x000855FC
		// (set) Token: 0x060014C4 RID: 5316 RVA: 0x00087410 File Offset: 0x00085610
		internal static MainWindow CurrentMainWindow { get; set; }

		// Token: 0x170005DD RID: 1501
		// (get) Token: 0x060014C5 RID: 5317 RVA: 0x00087424 File Offset: 0x00085624
		// (set) Token: 0x060014C6 RID: 5318 RVA: 0x00087438 File Offset: 0x00085638
		internal static bool IsImportCancelled { get; set; }

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x060014C7 RID: 5319 RVA: 0x0008744C File Offset: 0x0008564C
		// (set) Token: 0x060014C8 RID: 5320 RVA: 0x00087460 File Offset: 0x00085660
		public MainWindowModel ActiveModel { get; set; }

		// Token: 0x060014C9 RID: 5321 RVA: 0x00087474 File Offset: 0x00085674
		public void EnableWarningOnClosing()
		{
			\u0017\u0015\u0007.\u001D(this, new CancelEventHandler(this.ProcessTerminateWarn));
		}

		// Token: 0x060014CA RID: 5322 RVA: 0x00087494 File Offset: 0x00085694
		public void DisableWarningOnClosing()
		{
			\u0014\u001D\u0005.\u000A(this, new CancelEventHandler(this.ProcessTerminateWarn));
		}

		// Token: 0x060014CB RID: 5323 RVA: 0x000874B4 File Offset: 0x000856B4
		private void MainWindow_OnActivated(object sender, EventArgs e)
		{
			if (\u0012\u000C\u000A.\u000A(this.OY) > -1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.MainWindow_OnActivated(object, EventArgs)).MethodHandle;
				}
				if (\u0012\u000C\u000A.\u000A(this.OY) < 4)
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
					this.KYR();
				}
			}
		}

		// Token: 0x060014CC RID: 5324 RVA: 0x00087504 File Offset: 0x00085704
		private void DiRootsWindow_Unloaded(object sender, RoutedEventArgs e)
		{
			\u0004\u001A\u0019.\u000A(\u0019\u001A\u0019.\u000A());
			\u0007\u001A\u0019.\u000A(\u001D\u001A\u0019.\u000A());
			\u000B\u0012.\u001D();
			\u0013\u0017\u0018.\u000A(\u001B\u000B\u000E.\u001F);
		}

		// Token: 0x060014CD RID: 5325 RVA: 0x00087538 File Offset: 0x00085738
		private void ProcessTerminateWarn(object sender, CancelEventArgs e)
		{
			bool flag = \u001E\u000E\u0007.\u000A(\u0013\u001D\u0005.\u000A(), \u0012\u0006\u000E.\u001F(sender), 350.0, MessageBoxButtons.YesNo);
			\u0020\u000B\u0019.\u000A(e, !flag);
			\u0019\u0013\u0019.\u000A(flag);
		}

		// Token: 0x060014CE RID: 5326 RVA: 0x00087578 File Offset: 0x00085778
		private void ModelCategoryControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001A\u001D\u0005.\u000A(this.IY, this.JY, this);
		}

		// Token: 0x060014CF RID: 5327 RVA: 0x00087598 File Offset: 0x00085798
		private void mainControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (\u0001\u001F\u000E.\u001F(\u0015\u001D\u0005.\u000A(e)) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.mainControl_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\UI\\Windows\\MainWindow.xaml.cs", "mainControl_SelectionChanged");
				if (this.EY == 5)
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
					\u0019\u0013\u0019.\u000A(true);
				}
				if (\u0012\u000C\u000A.\u000A(this.OY) != 5)
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
					this.WYR(\u0012\u000C\u000A.\u000A(this.OY));
					\u0002\u0013\u0019.\u0007(\u0010\u0014\u0019.\u0007(this.RH));
					\u000C\u001D\u0005.\u000A(this.LC);
					this.KYR();
					this.EY = \u0012\u000C\u000A.\u000A(this.OY);
				}
				else
				{
					this.JYR(this.EY);
					this.EY = \u0012\u000C\u000A.\u000A(this.OY);
				}
				\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\UI\\Windows\\MainWindow.xaml.cs", "mainControl_SelectionChanged");
			}
		}

		// Token: 0x060014D0 RID: 5328 RVA: 0x00087698 File Offset: 0x00085898
		private void WYR(int F)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\UI\\Windows\\MainWindow.xaml.cs", "LoadUserControl");
			if (F == 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.WYR(int)).MethodHandle;
				}
				\u000A\u0004\u0005.\u000A(this.AY, this.JY, this);
			}
			else if (F == 2)
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
				\u001F\u0004\u0005.\u000A(this.FC, this.JY, this);
			}
			else if (F == 3)
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
				\u0009\u001D\u0005.\u000A(this.DC, this.JY, this);
			}
			else if (F == 4)
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
				\u0001\u001D\u0005.\u000A(this.YC, this.JY, this);
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\UI\\Windows\\MainWindow.xaml.cs", "LoadUserControl");
		}

		// Token: 0x060014D1 RID: 5329 RVA: 0x00087760 File Offset: 0x00085960
		private void KYR()
		{
			switch (\u0012\u000C\u000A.\u000A(this.OY))
			{
			case 0:
			{
				CategoryBaseModel categoryBaseModel = \u000F\u0006\u000E.\u001F(\u0007\u000C\u000A.\u0007(this.IY));
				if (categoryBaseModel == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.KYR()).MethodHandle;
					}
					return;
				}
				\u0007\u0004\u0005.\u000A(categoryBaseModel);
				return;
			}
			case 1:
			{
				CategoryBaseModel categoryBaseModel2 = \u000F\u0006\u000E.\u001F(\u0007\u000C\u000A.\u0007(this.AY));
				if (categoryBaseModel2 == null)
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
					return;
				}
				\u0007\u0004\u0005.\u000A(categoryBaseModel2);
				return;
			}
			case 2:
			{
				CategoryBaseModel categoryBaseModel3 = \u000F\u0006\u000E.\u001F(\u0007\u000C\u000A.\u0007(this.FC));
				if (categoryBaseModel3 == null)
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
					return;
				}
				\u0007\u0004\u0005.\u000A(categoryBaseModel3);
				return;
			}
			case 3:
			{
				CategoryBaseModel categoryBaseModel4 = \u000F\u0006\u000E.\u001F(\u0007\u000C\u000A.\u0007(this.DC));
				if (categoryBaseModel4 == null)
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
					return;
				}
				\u0007\u0004\u0005.\u000A(categoryBaseModel4);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x060014D2 RID: 5330 RVA: 0x00087840 File Offset: 0x00085A40
		private void btnPreviewEdit_Click(object sender, RoutedEventArgs e)
		{
			this.EY = \u0012\u000C\u000A.\u000A(this.OY);
			\u0004\u000C\u000A.\u000A(this.OY, 5);
		}

		// Token: 0x060014D3 RID: 5331 RVA: 0x0008786C File Offset: 0x00085A6C
		private void JYR(int F)
		{
			switch (F)
			{
			case 0:
				\u0005\u0004\u0005.\u000A(\u0005\u0006\u000E.\u001F(\u0007\u000C\u000A.\u0007(this.IY)), new Action<ControlExcelBase>(this.EYR));
				return;
			case 1:
				\u0018\u0004\u0005.\u000A(\u0016\u0006\u000E.\u001F(\u0007\u000C\u000A.\u0007(this.AY)), new Action<ControlExcelBase>(this.EYR));
				return;
			case 2:
				\u0019\u0004\u0005.\u000A(\u000B\u0006\u000E.\u001F(\u0007\u000C\u000A.\u0007(this.FC)), new Action<ControlExcelBase>(this.EYR));
				return;
			case 3:
				\u0004\u0004\u0005.\u000A(\u0002\u0006\u000E.\u001F(\u0007\u000C\u000A.\u0007(this.DC)), new Action<ControlExcelBase>(this.EYR));
				return;
			case 4:
				\u001D\u0004\u0005.\u000A(\u0006\u0006\u000E.\u001F(\u0007\u000C\u000A.\u0007(this.YC)), new Action<ControlExcelBase>(this.EYR));
				return;
			default:
				return;
			}
		}

		// Token: 0x060014D4 RID: 5332 RVA: 0x00087954 File Offset: 0x00085B54
		private void EYR(ControlExcelBase F)
		{
			MainWindow.\u0017\u0003 u0017_u = new MainWindow.\u0017\u0003();
			u0017_u.\u001F = this;
			u0017_u.\u000A = F;
			if (u0017_u.\u000A != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.EYR(ControlExcelBase)).MethodHandle;
				}
				\u0004\u000C\u000A.\u000A(this.OY, 5);
				\u000C\u0018\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(u0017_u.\u0007));
			}
		}

		// Token: 0x060014D5 RID: 5333 RVA: 0x000879B8 File Offset: 0x00085BB8
		private void btnImportFromExcel_Click(object sender, RoutedEventArgs e)
		{
			\u0020\u0003.\u0019(\u0004\u000F.\u0005(), this, \u0010\u0014\u0019.\u0007(this.RH), false);
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x000879E0 File Offset: 0x00085BE0
		private void BtnPreviewImport_OnClick(object sender, RoutedEventArgs e)
		{
			string text = \u0004\u000F.\u0005();
			if (!\u001A\u0006\u0007.\u000A(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.BtnPreviewImport_OnClick(object, RoutedEventArgs)).MethodHandle;
				}
				try
				{
					\u0004\u000C\u000A.\u000A(this.OY, 5);
					\u001E\u0010 u001E_u = new \u001E\u0010();
					\u0016\u0004\u0005.\u000A(u001E_u, text);
					u001E_u.\u001F += this.NYR;
					\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u001E_u);
					\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
				}
				catch (Exception ex)
				{
					\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), ex, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\UI\\Windows\\MainWindow.xaml.cs", "BtnPreviewImport_OnClick");
					\u0004\u000F.\u0016(ex);
				}
			}
		}

		// Token: 0x060014D7 RID: 5335 RVA: 0x00087A8C File Offset: 0x00085C8C
		private void NYR(string F)
		{
			MainWindow.\u0014\u0003 u0014_u = new MainWindow.\u0014\u0003();
			u0014_u.\u001F = this;
			u0014_u.\u000A = F;
			\u0018\u000B\u0019.\u000A(\u001C\u0015\u0007.\u0007(this), new Action(u0014_u.\u0007), DispatcherPriority.Normal);
		}

		// Token: 0x060014D8 RID: 5336 RVA: 0x00087AC8 File Offset: 0x00085CC8
		private void BtnImportFromGoogle_OnClick(object sender, RoutedEventArgs e)
		{
			if (!DriveSelection.ASR())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.BtnImportFromGoogle_OnClick(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			try
			{
				DriveSelection u001F = \u001F\u001A\u0019.\u000A(\u000F\u0013\u0019.\u000A(), true);
				\u0015\u000D\u001D.\u000A(u001F, this);
				bool? flag = \u0018\u0020\u000A.\u0007(u001F);
				if (\u0012\u0015\u000A.\u000A(ref flag))
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
					InteropUtility.\u001F(\u0009\u0013\u0019.\u000A(u001F), \u0010\u0011\u000A.\u000A());
					\u0020\u0003.\u0019(\u0009\u0013\u0019.\u000A(u001F), this, \u0010\u0014\u0019.\u0007(this.RH), true);
				}
			}
			catch (Exception u001F2)
			{
				\u0004\u000F.\u0016(u001F2);
			}
		}

		// Token: 0x060014D9 RID: 5337 RVA: 0x00087B74 File Offset: 0x00085D74
		private void BtnImportFromMorta_OnClick(object sender, RoutedEventArgs e)
		{
			if (!DriveSelection.ASR())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.BtnImportFromMorta_OnClick(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			Dictionary<DataTable, List<ParamExportInfo>> dictionary = \u000A\u000F.\u0007(this);
			if (dictionary != null)
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
				IEnumerable<List<ParamExportInfo>> enumerable = \u000B\u0004\u0005.\u000A(dictionary);
				Func<List<ParamExportInfo>, bool> func;
				if ((func = MainWindow.<>c.\u0007) == null)
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
					func = (MainWindow.<>c.\u0007 = new Func<List<ParamExportInfo>, bool>(MainWindow.<>c.\u001F.\u001D));
				}
				if (Enumerable.All<List<ParamExportInfo>>(enumerable, func))
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
					\u0008\u0011\u001D.\u000A(\u001F\u000F.\u0006);
					return;
				}
				\u0020\u0003.\u0019(dictionary, this, \u0010\u0014\u0019.\u0007(this.RH), false);
			}
		}

		// Token: 0x060014DA RID: 5338 RVA: 0x00087C20 File Offset: 0x00085E20
		private void btnImport_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBox comboBox = \u000F\u001F\u000E.\u001F(sender);
			if (comboBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.btnImport_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				\u0004\u000C\u000A.\u000A(comboBox, 0);
			}
		}

		// Token: 0x060014DB RID: 5339 RVA: 0x00087C54 File Offset: 0x00085E54
		private void DiRootsWindow_Loaded(object sender, RoutedEventArgs e)
		{
			\u0018\u001A\u0019.\u000A(\u0010\u0014\u0019.\u0007(this.RH), this);
			\u0006\u0004\u0005.\u000A(\u000D\u0016\u0018.\u000A());
			\u0015\u0009\u000A.\u000A(this.MY, true);
			\u0002\u0004\u0005.\u000A(this.MY);
			\u0015\u0009\u000A.\u000A(this.VY, true);
			\u0002\u0004\u0005.\u000A(this.VY);
			\u0015\u0009\u000A.\u000A(this.ZY, true);
			\u0002\u0004\u0005.\u000A(this.ZY);
			\u0015\u0009\u000A.\u000A(this.XY, true);
			\u0002\u0004\u0005.\u000A(this.XY);
			\u0015\u0009\u000A.\u000A(this.PY, true);
			\u0002\u0004\u0005.\u000A(this.PY);
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x00087CF4 File Offset: 0x00085EF4
		private void DiRootsWindow_Closed(object sender, EventArgs e)
		{
			\u0019\u0013\u0019.\u000A(true);
			\u001B\u0004\u0005.\u000A(this.IY);
			\u0008\u0004\u0005.\u000A(this.AY);
			\u000E\u0004\u0005.\u000A(this.FC);
			\u0010\u0004\u0005.\u000A(this.DC);
			\u000D\u0004\u0005.\u000A(this.YC);
			\u001C\u0004\u0005.\u000A(this.LC);
			\u0003\u0004\u0005.\u000A(\u001E\u001E\u000A.\u000A());
			\u0012\u0004\u0005.\u000A(\u0019\u0006\u000E.\u001F);
			\u000F\u0004\u0005.\u000A(\u0018\u0006\u000E.\u001F);
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x00087D6C File Offset: 0x00085F6C
		private void DiRootsWindow_StateChanged(object sender, EventArgs e)
		{
			if (\u0011\u0004\u0005.\u0007(this) == WindowState.Minimized)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.DiRootsWindow_StateChanged(object, EventArgs)).MethodHandle;
				}
				\u000C\u001D\u0005.\u000A(this.LC);
			}
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x00087DA4 File Offset: 0x00085FA4
		private void MainWindow_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (\u0010\u000F\u0019.\u001D(this) < 100.0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.MainWindow_OnMouseDoubleClick(object, MouseButtonEventArgs)).MethodHandle;
				}
				\u000C\u001D\u0005.\u000A(this.LC);
			}
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x00087DE4 File Offset: 0x00085FE4
		protected override void ApplyLicense(bool isLicenseValid)
		{
			\u0015\u0009\u000A.\u000A(this.WC, true);
			\u0015\u0009\u000A.\u000A(this.EC, true);
			\u0015\u0009\u000A.\u000A(this.KC, true);
			\u0015\u0009\u000A.\u000A(this.SC, true);
			if (isLicenseValid)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.ApplyLicense(bool)).MethodHandle;
				}
				\u0004\u000C\u000A.\u000A(this.OY, 0);
			}
			else
			{
				\u0004\u000C\u000A.\u000A(this.OY, 3);
				\u0015\u0009\u000A.\u000A(this.WC, false);
				\u0015\u0009\u000A.\u000A(this.EC, false);
				\u0015\u0009\u000A.\u000A(this.KC, false);
				\u0015\u0009\u000A.\u000A(this.SC, false);
			}
			\u0015\u0009\u000A.\u000A(this.TY, isLicenseValid);
			\u0015\u0009\u000A.\u000A(this.QY, isLicenseValid);
			\u0015\u0009\u000A.\u000A(this.GY, isLicenseValid);
			\u0015\u0009\u000A.\u000A(this.HC, isLicenseValid);
		}

		// Token: 0x060014E0 RID: 5344 RVA: 0x00087EB4 File Offset: 0x000860B4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink/ui/windows/mainwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060014E1 RID: 5345 RVA: 0x00087EFC File Offset: 0x000860FC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x060014E2 RID: 5346 RVA: 0x00087F14 File Offset: 0x00086114
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0016\u0002\u0019.\u000A(\u0005\u0002\u000E.\u001F(R), new EventHandler(this.MainWindow_OnActivated));
				\u0016\u0015\u0007.\u0007(\u0005\u0002\u000E.\u001F(R), new EventHandler(this.DiRootsWindow_Closed));
				\u0011\u000C\u000A.\u0007(\u0005\u0002\u000E.\u001F(R), new RoutedEventHandler(this.DiRootsWindow_Loaded));
				\u0017\u0004\u0005.\u000A(\u0005\u0002\u000E.\u001F(R), new MouseButtonEventHandler(this.MainWindow_OnMouseDoubleClick));
				\u0020\u0004\u0005.\u000A(\u0005\u0002\u000E.\u001F(R), new EventHandler(this.DiRootsWindow_StateChanged));
				\u001E\u0004\u0005.\u000A(\u0005\u0002\u000E.\u001F(R), new RoutedEventHandler(this.DiRootsWindow_Unloaded));
				return;
			case 2:
				this.MY = \u0001\u0002\u000E.\u001F(R);
				return;
			case 3:
				this.VY = \u0001\u0002\u000E.\u001F(R);
				return;
			case 4:
				this.ZY = \u0001\u0002\u000E.\u001F(R);
				return;
			case 5:
				this.XY = \u0001\u0002\u000E.\u001F(R);
				return;
			case 6:
				this.PY = \u0001\u0002\u000E.\u001F(R);
				return;
			case 7:
				this.RH = \u001F\u0016\u000E.\u001F(R);
				return;
			case 8:
				this.OY = \u001A\u0015\u0010.\u001F(R);
				\u001B\u000C\u000A.\u0007(this.OY, new SelectionChangedEventHandler(this.mainControl_SelectionChanged));
				return;
			case 9:
				this.TY = \u000C\u0015\u0010.\u001F(R);
				return;
			case 10:
				this.IY = \u0009\u0002\u000E.\u001F(R);
				return;
			case 11:
				this.QY = \u000C\u0015\u0010.\u001F(R);
				return;
			case 12:
				this.AY = \u001F\u0006\u000E.\u001F(R);
				return;
			case 13:
				this.GY = \u000C\u0015\u0010.\u001F(R);
				return;
			case 14:
				this.FC = \u000A\u0006\u000E.\u001F(R);
				return;
			case 15:
				this.RC = \u000C\u0015\u0010.\u001F(R);
				return;
			case 16:
				this.DC = \u0007\u0006\u000E.\u001F(R);
				return;
			case 17:
				this.HC = \u000C\u0015\u0010.\u001F(R);
				return;
			case 18:
				this.YC = \u001D\u0006\u000E.\u001F(R);
				return;
			case 19:
				this.CC = \u000C\u0015\u0010.\u001F(R);
				return;
			case 20:
				this.LC = \u0004\u0006\u000E.\u001F(R);
				return;
			case 21:
				this.KR = \u001A\u000A\u000E.\u001F(R);
				return;
			case 22:
				this.HH = \u001E\u0001\u0010.\u001F(R);
				return;
			case 23:
				this.SC = \u001E\u0001\u0010.\u001F(R);
				return;
			case 24:
				this.BC = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.BC, new RoutedEventHandler(this.btnPreviewEdit_Click));
				return;
			case 25:
				this.UC = \u000B\u000A\u000E.\u001F(R);
				\u001B\u000C\u000A.\u0007(this.UC, new SelectionChangedEventHandler(this.btnImport_SelectionChanged));
				return;
			case 26:
				this.WC = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.WC, new RoutedEventHandler(this.btnImportFromExcel_Click));
				return;
			case 27:
				this.KC = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.KC, new RoutedEventHandler(this.BtnImportFromGoogle_OnClick));
				return;
			case 28:
				this.JC = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.JC, new RoutedEventHandler(this.BtnImportFromMorta_OnClick));
				return;
			case 29:
				this.EC = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.EC, new RoutedEventHandler(this.BtnPreviewImport_OnClick));
				return;
			case 30:
				this.LH = \u001E\u0001\u0010.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x040007F7 RID: 2039
		private readonly UIDocument JY;

		// Token: 0x040007F8 RID: 2040
		private int EY;

		// Token: 0x040007FB RID: 2043
		[CompilerGenerated]
		private MainWindowModel NY;

		// Token: 0x040007FC RID: 2044
		internal ProfileUserControl MY;

		// Token: 0x040007FD RID: 2045
		internal ProfileUserControl VY;

		// Token: 0x040007FE RID: 2046
		internal ProfileUserControl ZY;

		// Token: 0x040007FF RID: 2047
		internal ProfileUserControl XY;

		// Token: 0x04000800 RID: 2048
		internal ProfileUserControl PY;

		// Token: 0x04000801 RID: 2049
		internal CustomProgressBar RH;

		// Token: 0x04000802 RID: 2050
		internal TabControl OY;

		// Token: 0x04000803 RID: 2051
		internal TabItem TY;

		// Token: 0x04000804 RID: 2052
		internal ModelCategories IY;

		// Token: 0x04000805 RID: 2053
		internal TabItem QY;

		// Token: 0x04000806 RID: 2054
		internal AnnotationCategories AY;

		// Token: 0x04000807 RID: 2055
		internal TabItem GY;

		// Token: 0x04000808 RID: 2056
		internal ElementsWindow FC;

		// Token: 0x04000809 RID: 2057
		internal TabItem RC;

		// Token: 0x0400080A RID: 2058
		internal ScheduleWindow DC;

		// Token: 0x0400080B RID: 2059
		internal TabItem HC;

		// Token: 0x0400080C RID: 2060
		internal SpatialControl YC;

		// Token: 0x0400080D RID: 2061
		internal TabItem CC;

		// Token: 0x0400080E RID: 2062
		internal PreviewTabControl LC;

		// Token: 0x0400080F RID: 2063
		internal Label KR;

		// Token: 0x04000810 RID: 2064
		internal Button HH;

		// Token: 0x04000811 RID: 2065
		internal Button SC;

		// Token: 0x04000812 RID: 2066
		internal Button BC;

		// Token: 0x04000813 RID: 2067
		internal ComboBox UC;

		// Token: 0x04000814 RID: 2068
		internal Button WC;

		// Token: 0x04000815 RID: 2069
		internal Button KC;

		// Token: 0x04000816 RID: 2070
		internal Button JC;

		// Token: 0x04000817 RID: 2071
		internal Button EC;

		// Token: 0x04000818 RID: 2072
		internal Button LH;

		// Token: 0x04000819 RID: 2073
		private bool R;

		// Token: 0x020008E7 RID: 2279
		[CompilerGenerated]
		private sealed class \u0017\u0003
		{
			// Token: 0x060050EA RID: 20714 RVA: 0x001E7D4C File Offset: 0x001E5F4C
			internal void \u0007()
			{
				\u000A\u000B\u0010.\u000A(this.\u001F.LC, this.\u000A, this.\u001F, \u0010\u0014\u0019.\u0007(this.\u001F.RH));
			}

			// Token: 0x04002356 RID: 9046
			public MainWindow \u001F;

			// Token: 0x04002357 RID: 9047
			public ControlExcelBase \u000A;
		}

		// Token: 0x020008E8 RID: 2280
		[CompilerGenerated]
		private sealed class \u0014\u0003
		{
			// Token: 0x060050EC RID: 20716 RVA: 0x001E7D9C File Offset: 0x001E5F9C
			internal void \u0007()
			{
				\u0007\u000B\u0010.\u000A(this.\u001F.LC, this.\u000A, this.\u001F, \u0010\u0014\u0019.\u0007(this.\u001F.RH));
			}

			// Token: 0x04002358 RID: 9048
			public MainWindow \u001F;

			// Token: 0x04002359 RID: 9049
			public string \u000A;
		}
	}
}

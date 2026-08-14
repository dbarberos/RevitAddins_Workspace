using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.TreeGrid;
using DiRoots.One.Commons.ViewModels;
using ProSheets.Commons.CustomNameManageWindow.Enums;
using ProSheets.DrawingRegister.Enums;
using ProSheets.DrawingRegister.Model;
using ProSheets.DrawingRegister.Model.TreeViewModel;
using ProSheets.DrawingRegister.UI.Windows;
using ProSheets.Extensions;
using ProSheets.Models;
using ProSheets.Services;

namespace ProSheets.DrawingRegister.ViewModels
{
	// Token: 0x0200010D RID: 269
	public class SheetsViewModel : ViewModelBase
	{
		// Token: 0x06000DA7 RID: 3495 RVA: 0x00050578 File Offset: 0x0004E778
		public SheetsViewModel()
		{
			\u000A\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\SheetsViewModel.cs", ".ctor");
			this.\u0004\u0018 = \u0007\u0015\u0018.\u0003;
			\u001B\u000E\u0016.\u0018(this, BrowserOption.SheetList);
			this.\u0008\u0009();
			this.\u0007\u0009();
			\u000F\u0010\u0016.\u0003(this);
			\u0001\u000E\u0016.\u0018(this);
			if (Enumerable.Any<SheetInformation>(\u0015\u0007\u0016.\u0003(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel..ctor()).MethodHandle;
				}
				IEnumerable<SheetInformation> enumerable = \u0015\u0007\u0016.\u0003(this);
				Func<SheetInformation, bool> func;
				if ((func = SheetsViewModel.<>c.\u0018) == null)
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
					func = (SheetsViewModel.<>c.\u0018 = new Func<SheetInformation, bool>(SheetsViewModel.<>c.\u000C.\u0004));
				}
				\u0008\u001A\u0016.\u0018(\u0008\u000E\u0016.\u0018(this, Enumerable.First<SheetInformation>(enumerable, func)));
			}
			\u0006\u000E\u0016.\u0018(this);
			this.\u0001\u0009();
			\u001C\u0010\u0016.\u0003(this, false);
			\u0009\u0007\u0016.\u0003(this);
			\u0010\u000E\u0016.\u0018(this, new CommandBase(new Action(this.UndoParameterName), new Predicate<object>(this.CanUndoParameterName)));
			\u000D\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\SheetsViewModel.cs", ".ctor");
		}

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06000DA8 RID: 3496 RVA: 0x000506BC File Offset: 0x0004E8BC
		// (set) Token: 0x06000DA9 RID: 3497 RVA: 0x000506D0 File Offset: 0x0004E8D0
		public Dictionary<string, object> BrowserOptions { get; set; }

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06000DAA RID: 3498 RVA: 0x000506E4 File Offset: 0x0004E8E4
		// (set) Token: 0x06000DAB RID: 3499 RVA: 0x000506F8 File Offset: 0x0004E8F8
		public bool IsSheetList
		{
			get
			{
				return this.\u0004\u000F;
			}
			set
			{
				this.\u0004\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "IsSheetList");
			}
		}

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06000DAC RID: 3500 RVA: 0x00050718 File Offset: 0x0004E918
		// (set) Token: 0x06000DAD RID: 3501 RVA: 0x0005072C File Offset: 0x0004E92C
		public Dictionary<string, object> SelectBrowserOption
		{
			get
			{
				return this.\u001D\u000F;
			}
			set
			{
				this.\u001D\u000F = value;
				BrowserOption u;
				if (!Enumerable.Any<object>(\u0005\u000E\u0016.\u0003(\u000E\u000E\u0016.\u0018(this))))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.set_SelectBrowserOption(Dictionary<string, object>)).MethodHandle;
					}
					u = BrowserOption.BrowserOrganization;
				}
				else
				{
					Dictionary<string, object> dictionary = \u000E\u000E\u0016.\u0018(this);
					object u000C;
					if (dictionary == null)
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
						u000C = null;
					}
					else
					{
						u000C = Enumerable.First<object>(\u0005\u000E\u0016.\u0014(dictionary));
					}
					u = \u0014\u0006\u000F.\u000C(u000C);
				}
				\u0012\u0010\u0016.\u0003(this, u);
				\u0011\u0010\u0018.\u0018(this, "SelectBrowserOption");
			}
		}

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06000DAE RID: 3502 RVA: 0x000507B0 File Offset: 0x0004E9B0
		// (set) Token: 0x06000DAF RID: 3503 RVA: 0x000507C4 File Offset: 0x0004E9C4
		public BrowserOption BrowserOption { get; set; }

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x06000DB0 RID: 3504 RVA: 0x000507D8 File Offset: 0x0004E9D8
		// (set) Token: 0x06000DB1 RID: 3505 RVA: 0x000507EC File Offset: 0x0004E9EC
		public string ColName
		{
			get
			{
				return this.\u0002\u000F;
			}
			set
			{
				this.\u0002\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "ColName");
			}
		}

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x06000DB2 RID: 3506 RVA: 0x0005080C File Offset: 0x0004EA0C
		// (set) Token: 0x06000DB3 RID: 3507 RVA: 0x00050820 File Offset: 0x0004EA20
		public string Status
		{
			get
			{
				return this.\u000E\u0003;
			}
			set
			{
				this.\u000E\u0003 = value;
				\u0011\u0010\u0018.\u0018(this, "Status");
			}
		}

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x06000DB4 RID: 3508 RVA: 0x00050840 File Offset: 0x0004EA40
		// (set) Token: 0x06000DB5 RID: 3509 RVA: 0x00050854 File Offset: 0x0004EA54
		public bool IsLinkFile
		{
			get
			{
				return this.\u001E\u000F;
			}
			set
			{
				this.\u001E\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "IsLinkFile");
			}
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06000DB6 RID: 3510 RVA: 0x00050874 File Offset: 0x0004EA74
		// (set) Token: 0x06000DB7 RID: 3511 RVA: 0x00050888 File Offset: 0x0004EA88
		public bool HideUnchecked
		{
			get
			{
				return this.\u0013;
			}
			set
			{
				this.\u0013 = value;
				\u001D\u0008\u0018.\u0018(\u000C\u000C\u000F.\u0018(this));
				\u0011\u0010\u0018.\u0018(this, "HideUnchecked");
			}
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06000DB8 RID: 3512 RVA: 0x000508B4 File Offset: 0x0004EAB4
		// (set) Token: 0x06000DB9 RID: 3513 RVA: 0x000508C8 File Offset: 0x0004EAC8
		public bool? IsCheckAll
		{
			get
			{
				return this.\u0015\u000F;
			}
			set
			{
				this.\u0015\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "IsCheckAll");
			}
		}

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x06000DBA RID: 3514 RVA: 0x000508E8 File Offset: 0x0004EAE8
		// (set) Token: 0x06000DBB RID: 3515 RVA: 0x000508FC File Offset: 0x0004EAFC
		public string SearchSheetText
		{
			get
			{
				return this.\u0017\u000F;
			}
			set
			{
				this.\u0017\u000F = value;
				\u001D\u0008\u0018.\u0018(\u000C\u000C\u000F.\u0018(this));
				\u0011\u0010\u0018.\u0018(this, "SearchSheetText");
			}
		}

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x06000DBC RID: 3516 RVA: 0x00050928 File Offset: 0x0004EB28
		// (set) Token: 0x06000DBD RID: 3517 RVA: 0x0005093C File Offset: 0x0004EB3C
		public Dictionary<string, object> BrowserOrg
		{
			get
			{
				return this.\u0020\u000F;
			}
			set
			{
				this.\u0020\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "BrowserOrg");
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x06000DBE RID: 3518 RVA: 0x0005095C File Offset: 0x0004EB5C
		// (set) Token: 0x06000DBF RID: 3519 RVA: 0x00050970 File Offset: 0x0004EB70
		public Dictionary<string, object> SelectBrowserOrg
		{
			get
			{
				return this.\u001F\u000F;
			}
			set
			{
				this.\u001F\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "SelectBrowserOrg");
			}
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x06000DC0 RID: 3520 RVA: 0x00050990 File Offset: 0x0004EB90
		// (set) Token: 0x06000DC1 RID: 3521 RVA: 0x000509A4 File Offset: 0x0004EBA4
		public List<ParameterInformation> ProjectParameter { get; set; }

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06000DC2 RID: 3522 RVA: 0x000509B8 File Offset: 0x0004EBB8
		// (set) Token: 0x06000DC3 RID: 3523 RVA: 0x000509CC File Offset: 0x0004EBCC
		public List<ParameterInformation> SelectedParameters
		{
			get
			{
				return this.\u0013\u000F;
			}
			set
			{
				this.\u0013\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "SelectedParameters");
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x06000DC4 RID: 3524 RVA: 0x000509EC File Offset: 0x0004EBEC
		// (set) Token: 0x06000DC5 RID: 3525 RVA: 0x00050A00 File Offset: 0x0004EC00
		public List<ViewInfo> FlattenViewInfo { get; set; }

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06000DC6 RID: 3526 RVA: 0x00050A14 File Offset: 0x0004EC14
		// (set) Token: 0x06000DC7 RID: 3527 RVA: 0x00050A28 File Offset: 0x0004EC28
		public List<SheetInformation> AllSheetInformation { get; set; }

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06000DC8 RID: 3528 RVA: 0x00050A3C File Offset: 0x0004EC3C
		// (set) Token: 0x06000DC9 RID: 3529 RVA: 0x00050A50 File Offset: 0x0004EC50
		public List<SheetInformation> CheckedSheetInformation
		{
			get
			{
				return this.\u0009\u000F;
			}
			set
			{
				this.\u0009\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "CheckedSheetInformation");
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06000DCA RID: 3530 RVA: 0x00050A70 File Offset: 0x0004EC70
		// (set) Token: 0x06000DCB RID: 3531 RVA: 0x00050A84 File Offset: 0x0004EC84
		public ViewsSheetsCollector ViewsSheetsCollector { get; set; }

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06000DCC RID: 3532 RVA: 0x00050A98 File Offset: 0x0004EC98
		// (set) Token: 0x06000DCD RID: 3533 RVA: 0x00050AAC File Offset: 0x0004ECAC
		public List<LinkDocumentSheetCollector> LinkSheetCollector { get; set; } = new List<LinkDocumentSheetCollector>();

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06000DCE RID: 3534 RVA: 0x00050AC0 File Offset: 0x0004ECC0
		// (set) Token: 0x06000DCF RID: 3535 RVA: 0x00050AD4 File Offset: 0x0004ECD4
		public ObservableCollection<DataGridColumn> ColumnCollection
		{
			get
			{
				return this.\u000A\u000F;
			}
			set
			{
				this.\u000A\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "ColumnCollection");
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06000DD0 RID: 3536 RVA: 0x00050AF4 File Offset: 0x0004ECF4
		// (set) Token: 0x06000DD1 RID: 3537 RVA: 0x00050B08 File Offset: 0x0004ED08
		public List<ViewInfo> ViewInfo
		{
			get
			{
				return this.\u0011\u000F;
			}
			set
			{
				this.\u0011\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "ViewInfo");
			}
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06000DD2 RID: 3538 RVA: 0x00050B28 File Offset: 0x0004ED28
		// (set) Token: 0x06000DD3 RID: 3539 RVA: 0x00050B3C File Offset: 0x0004ED3C
		public ICollectionView ViewInfoView { get; set; }

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06000DD4 RID: 3540 RVA: 0x00050B50 File Offset: 0x0004ED50
		// (set) Token: 0x06000DD5 RID: 3541 RVA: 0x00050B64 File Offset: 0x0004ED64
		public ParameterInformation ChangeNameParameter { get; set; }

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06000DD6 RID: 3542 RVA: 0x00050B78 File Offset: 0x0004ED78
		// (set) Token: 0x06000DD7 RID: 3543 RVA: 0x00050B8C File Offset: 0x0004ED8C
		public BrowserOrganization CurrentBrowserOrganization { get; set; }

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06000DD8 RID: 3544 RVA: 0x00050BA0 File Offset: 0x0004EDA0
		// (set) Token: 0x06000DD9 RID: 3545 RVA: 0x00050BB4 File Offset: 0x0004EDB4
		public BrowserOption CurrentBrowserOption { get; set; }

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06000DDA RID: 3546 RVA: 0x00050BC8 File Offset: 0x0004EDC8
		// (set) Token: 0x06000DDB RID: 3547 RVA: 0x00050BDC File Offset: 0x0004EDDC
		public TreeManager TreeManager
		{
			get
			{
				return this.\u001A\u000F;
			}
			set
			{
				this.\u001A\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "TreeManager");
			}
		}

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06000DDC RID: 3548 RVA: 0x00050BFC File Offset: 0x0004EDFC
		// (set) Token: 0x06000DDD RID: 3549 RVA: 0x00050C10 File Offset: 0x0004EE10
		public CommandBase UndoParaNameCommand { get; set; }

		// Token: 0x06000DDE RID: 3550 RVA: 0x00050C24 File Offset: 0x0004EE24
		[BindableMethod("GetBrowserOrg")]
		public void GetBrowserOrg()
		{
			if (\u0012\u000C\u000F.\u0018(this) == \u0004\u0019\u0016.\u0003(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.GetBrowserOrg()).MethodHandle;
				}
				return;
			}
			\u001B\u000E\u0016.\u0018(this, \u0004\u0019\u0016.\u0003(this));
			\u000F\u000C\u000F.\u0018(this, \u0019\u0015\u0018.\u0003(this.\u0004\u0018, \u0004\u0019\u0016.\u0003(this)));
			Dictionary<string, object> dictionary = \u0018\u0010\u0016.\u0018();
			\u0005\u0007\u0016.\u0018(dictionary, Enumerable.First<string>(\u0017\u0019\u0016.\u0018(\u0016\u000C\u000F.\u0018(this))), Enumerable.First<object>(\u0005\u000E\u0016.\u0003(\u0016\u000C\u000F.\u0018(this))));
			\u0003\u000C\u000F.\u0018(this, dictionary);
			BrowserOrganization browserOrganization = \u001E\u0006\u000F.\u000C(Enumerable.First<object>(\u0005\u000E\u0016.\u0003(\u001E\u0019\u0016.\u0003(this))));
			if (\u0014\u000C\u000F.\u0018(this) != null)
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
				if (!\u0003\u001D\u0018.\u0018(\u0009\u0002\u0018.\u0018(\u0014\u000C\u000F.\u0018(this)), \u0009\u0002\u0018.\u0018(browserOrganization)))
				{
					goto IL_F7;
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
			\u0001\u000E\u0016.\u0018(this);
			\u0018\u000C\u000F.\u0018(this, browserOrganization);
			IL_F7:
			\u0009\u0007\u0016.\u0003(this);
		}

		// Token: 0x06000DDF RID: 3551 RVA: 0x00050D30 File Offset: 0x0004EF30
		[BindableMethod("Refresh")]
		public void Refresh()
		{
			BrowserOrganization browserOrganization = \u001E\u0006\u000F.\u000C(Enumerable.First<object>(\u0005\u000E\u0016.\u0003(\u001E\u0019\u0016.\u0003(this))));
			if (\u0014\u000C\u000F.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.Refresh()).MethodHandle;
				}
				if (\u0003\u001D\u0018.\u0018(\u0009\u0002\u0018.\u0018(\u0014\u000C\u000F.\u0018(this)), \u0009\u0002\u0018.\u0018(browserOrganization)))
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
					this.\u0010\u0009();
					\u0018\u000C\u000F.\u0018(this, browserOrganization);
					\u000A\u000C\u000F.\u0018(this, false);
					if (\u001F\u001A\u0016.\u0003(this))
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
						\u0008\u0007\u0016.\u0003(this);
					}
				}
			}
			\u0013\u000C\u000F.\u0018(this, \u0009\u000C\u000F.\u0018(\u0009\u0019\u0016.\u0003(this), new Predicate<ITreeItem>(this.\u0006\u0009)));
			\u001C\u000C\u000F.\u0018(this, \u0010\u0006\u0018.\u0018(\u0009\u0019\u0016.\u0003(this)));
			\u0005\u0006\u0018.\u0018(\u000C\u000C\u000F.\u0018(this), new Predicate<object>(this.FilterView));
			\u000D\u000C\u000F.\u0018(this);
		}

		// Token: 0x06000DE0 RID: 3552 RVA: 0x00050E28 File Offset: 0x0004F028
		[BindableMethod("AddLinkSheet")]
		public void AddLinkSheet()
		{
			if (Enumerable.Any<LinkDocumentSheetCollector>(\u001D\u000C\u000F.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.AddLinkSheet()).MethodHandle;
				}
				if (\u001F\u001A\u0016.\u0003(this))
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
					List<LinkDocumentSheetCollector>.Enumerator enumerator = \u0004\u000C\u000F.\u0018(\u001D\u000C\u000F.\u0018(this));
					try
					{
						while (\u0015\u000C\u000F.\u0018(ref enumerator))
						{
							LinkDocumentSheetCollector u000C = \u0002\u000C\u000F.\u0018(ref enumerator);
							SheetsViewModel.\u0020\u0015\u0018 u0020_u0015_u = new SheetsViewModel.\u0020\u0015\u0018();
							string u = Enumerable.First<string>(\u0017\u0019\u0016.\u0018(\u001E\u0019\u0016.\u0003(this)));
							BrowserOrganization browserOrganization = \u001E\u0006\u000F.\u000C(Enumerable.First<object>(\u0005\u000E\u0016.\u0003(\u0005\u000C\u000F.\u0018(u000C))));
							if (\u000E\u000C\u000F.\u0018(\u0005\u000C\u000F.\u0018(u000C), u))
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
								browserOrganization = \u001E\u0006\u000F.\u000C(\u001B\u000C\u000F.\u0018(\u0005\u000C\u000F.\u0018(u000C), u));
							}
							u0020_u0015_u.\u000C = \u0001\u000C\u000F.\u0018();
							if (\u0004\u0019\u0016.\u0003(this) == BrowserOption.BrowserOrganization)
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
								u0020_u0015_u.\u000C = \u000C\u0017\u0018.\u000C(\u0008\u000C\u000F.\u0018(u000C), \u0006\u000C\u000F.\u0014(u000C), browserOrganization);
							}
							else
							{
								u0020_u0015_u.\u000C = \u001B\u0015\u0018.\u0014(\u0006\u000C\u000F.\u0014(u000C), browserOrganization);
							}
							if (!\u0010\u000C\u000F.\u0018(\u0009\u0019\u0016.\u0003(this), new Predicate<ViewInfo>(u0020_u0015_u.\u0018)))
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
								\u0007\u000C\u000F.\u0018(\u0009\u0019\u0016.\u0003(this), u0020_u0015_u.\u000C);
							}
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
					\u000B\u000C\u000F.\u0018(\u0015\u0007\u0016.\u0003(this), \u0019\u000C\u000F.\u0018());
					IEnumerable<SheetInformation> enumerable = \u0015\u0007\u0016.\u0003(this);
					Func<SheetInformation, string> func;
					if ((func = SheetsViewModel.<>c.\u0014) == null)
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
						func = (SheetsViewModel.<>c.\u0014 = new Func<SheetInformation, string>(SheetsViewModel.<>c.\u000C.\u001D));
					}
					IEnumerable<IGrouping<string, SheetInformation>> enumerable2 = Enumerable.GroupBy<SheetInformation, string>(enumerable, func);
					Func<IGrouping<string, SheetInformation>, SheetInformation> func2;
					if ((func2 = SheetsViewModel.<>c.\u0003) == null)
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
						func2 = (SheetsViewModel.<>c.\u0003 = new Func<IGrouping<string, SheetInformation>, SheetInformation>(SheetsViewModel.<>c.\u000C.\u001A));
					}
					\u001A\u000C\u000F.\u0018(this, Enumerable.ToList<SheetInformation>(Enumerable.Select<IGrouping<string, SheetInformation>, SheetInformation>(enumerable2, func2)));
					IEnumerable<SheetInformation> enumerable3 = \u0015\u0007\u0016.\u0003(this);
					Func<SheetInformation, bool> func3;
					if ((func3 = SheetsViewModel.<>c.\u0016) == null)
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
						func3 = (SheetsViewModel.<>c.\u0016 = new Func<SheetInformation, bool>(SheetsViewModel.<>c.\u000C.\u000B));
					}
					\u0007\u0007\u0016.\u0018(\u0008\u000E\u0016.\u0018(this, Enumerable.First<SheetInformation>(enumerable3, func3)));
				}
				else
				{
					List<LinkDocumentSheetCollector>.Enumerator enumerator = \u0004\u000C\u000F.\u0018(\u001D\u000C\u000F.\u0018(this));
					try
					{
						while (\u0015\u000C\u000F.\u0018(ref enumerator))
						{
							SheetsViewModel.\u0011\u0015\u0018 u0011_u0015_u = new SheetsViewModel.\u0011\u0015\u0018();
							u0011_u0015_u.\u000C = \u0002\u000C\u000F.\u0018(ref enumerator);
							ViewInfo u2 = \u001E\u000C\u000F.\u0014(\u0009\u0019\u0016.\u0003(this), new Predicate<ViewInfo>(u0011_u0015_u.\u0018));
							\u0017\u000C\u000F.\u0018(\u0009\u0019\u0016.\u0003(this), u2);
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
					object u000C2 = \u0015\u0007\u0016.\u0003(this);
					Predicate<SheetInformation> u3;
					if ((u3 = SheetsViewModel.<>c.\u000F) == null)
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
						u3 = (SheetsViewModel.<>c.\u000F = new Predicate<SheetInformation>(SheetsViewModel.<>c.\u000C.\u0019));
					}
					\u0011\u000C\u000F.\u0018(u000C2, u3);
					\u0007\u0007\u0016.\u0018(\u0001\u001A\u0016.\u0018());
				}
				\u001C\u000C\u000F.\u0018(this, \u0010\u0006\u0018.\u0018(\u0009\u0019\u0016.\u0003(this)));
				\u0005\u0006\u0018.\u0018(\u000C\u000C\u000F.\u0018(this), new Predicate<object>(this.FilterView));
				\u0013\u000C\u000F.\u0018(this, \u0009\u000C\u000F.\u0018(\u0009\u0019\u0016.\u0003(this), new Predicate<ITreeItem>(this.\u0006\u0009)));
				\u0020\u000C\u000F.\u0018(\u001F\u000C\u000F.\u0018(this), false);
				List<long> u000C3 = this.\u0005\u0009();
				this.\u000E\u0009(u000C3);
			}
		}

		// Token: 0x06000DE1 RID: 3553 RVA: 0x000511F8 File Offset: 0x0004F3F8
		[BindableMethod("BrowserOptionChange")]
		public void BrowserOptionChange(object sender)
		{
			SheetsViewModel.\u0015\u0015\u0018 u0015_u0015_u = new SheetsViewModel.\u0015\u0015\u0018();
			u0015_u0015_u.\u000C = \u0015\u0019\u000F.\u000C(sender);
			if (u0015_u0015_u.\u000C == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.BrowserOptionChange(object)).MethodHandle;
				}
				return;
			}
			IEnumerable<KeyValuePair<string, object>> enumerable = Enumerable.Where<KeyValuePair<string, object>>(\u0016\u0010\u0016.\u0003(this), new Func<KeyValuePair<string, object>, bool>(u0015_u0015_u.\u0018));
			Func<KeyValuePair<string, object>, string> func;
			if ((func = SheetsViewModel.<>c.\u0012) == null)
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
				func = (SheetsViewModel.<>c.\u0012 = new Func<KeyValuePair<string, object>, string>(SheetsViewModel.<>c.\u000C.\u0007));
			}
			Func<KeyValuePair<string, object>, object> func2;
			if ((func2 = SheetsViewModel.<>c.\u000D) == null)
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
				func2 = (SheetsViewModel.<>c.\u000D = new Func<KeyValuePair<string, object>, object>(SheetsViewModel.<>c.\u000C.\u0010));
			}
			Dictionary<string, object> u000C = Enumerable.ToDictionary<KeyValuePair<string, object>, string, object>(enumerable, func, func2);
			\u001B\u0007\u0016.\u0003(this, \u0010\u0001\u0016.\u0018(u000C));
		}

		// Token: 0x06000DE2 RID: 3554 RVA: 0x000512B8 File Offset: 0x0004F4B8
		[BindableMethod("BrowserOrgChange")]
		public void BrowserOrgChange(object sender)
		{
			SheetsViewModel.\u0017\u0015\u0018 u0017_u0015_u = new SheetsViewModel.\u0017\u0015\u0018();
			u0017_u0015_u.\u000C = \u0015\u0019\u000F.\u000C(sender);
			if (u0017_u0015_u.\u000C == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.BrowserOrgChange(object)).MethodHandle;
				}
				return;
			}
			IEnumerable<KeyValuePair<string, object>> enumerable = Enumerable.Where<KeyValuePair<string, object>>(\u0016\u000C\u000F.\u0018(this), new Func<KeyValuePair<string, object>, bool>(u0017_u0015_u.\u0018));
			Func<KeyValuePair<string, object>, string> func;
			if ((func = SheetsViewModel.<>c.\u001C) == null)
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
				func = (SheetsViewModel.<>c.\u001C = new Func<KeyValuePair<string, object>, string>(SheetsViewModel.<>c.\u000C.\u0006));
			}
			Func<KeyValuePair<string, object>, object> func2;
			if ((func2 = SheetsViewModel.<>c.\u0013) == null)
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
				func2 = (SheetsViewModel.<>c.\u0013 = new Func<KeyValuePair<string, object>, object>(SheetsViewModel.<>c.\u000C.\u0008));
			}
			Dictionary<string, object> u000C = Enumerable.ToDictionary<KeyValuePair<string, object>, string, object>(enumerable, func, func2);
			\u0003\u000C\u000F.\u0018(this, \u0010\u0001\u0016.\u0018(u000C));
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x00051378 File Offset: 0x0004F578
		[BindableMethod("Reload")]
		public void Reload()
		{
			\u001C\u0010\u0016.\u0003(this, false);
			\u0003\u0018\u000F.\u0018(this, string.Empty);
			\u001D\u0008\u0018.\u0018(\u000C\u000C\u000F.\u0018(this));
			\u0008\u0007\u0016.\u0003(this);
			\u000C\u0017\u0018.\u0016(\u0009\u0019\u0016.\u0003(this), false);
			\u001C\u000C\u000F.\u0018(this, \u0010\u0006\u0018.\u0018(\u0009\u0019\u0016.\u0003(this)));
			\u0005\u0006\u0018.\u0018(\u000C\u000C\u000F.\u0018(this), new Predicate<object>(this.FilterView));
			\u0014\u0018\u000F.\u0018(this, false);
			\u0018\u0018\u000F.\u0018(this, new bool?(false));
			\u0011\u0007\u0016.\u0003(this, \u000C\u0018\u000F.\u0018());
			\u0020\u0007\u0016.\u0003(this, \u000B\u0007\u0016.\u0018());
			\u000A\u0007\u0016.\u0003(this);
			\u0009\u0007\u0016.\u0003(this);
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x00051420 File Offset: 0x0004F620
		[BindableMethod("SheetInfoChecked")]
		public void SheetInfoChecked(object sender)
		{
			CheckBox checkBox = \u0015\u0019\u000F.\u000C(sender);
			if (checkBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.SheetInfoChecked(object)).MethodHandle;
				}
				ViewInfo viewInfo = \u0017\u0006\u000F.\u000C(\u0003\u0012\u0014.\u0014(checkBox));
				if (viewInfo != null)
				{
					List<long> u000C = this.\u0005\u0009();
					if (\u0004\u0019\u0016.\u0003(this) == BrowserOption.SheetList)
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
						\u000C\u0017\u0018.\u0012(\u0009\u0019\u0016.\u0003(this), viewInfo);
						\u0015\u0010\u0016.\u0018(viewInfo, \u001B\u0001\u0018.\u0018(checkBox));
						bool? flag = \u0019\u0019\u0016.\u0018(viewInfo);
						if (\u000C\u0007\u0018.\u0018(ref flag))
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
							u000C = \u001B\u0015\u0018.\u0018(\u0016\u0018\u000F.\u0018(viewInfo), \u0017\u0010\u0016.\u0018(viewInfo));
						}
					}
					this.\u000E\u0009(u000C);
					return;
				}
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
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x000514E4 File Offset: 0x0004F6E4
		[BindableMethod("RefreshSheetInfo")]
		public void RefreshSheetInfo()
		{
			\u001D\u0008\u0018.\u0018(\u000C\u000C\u000F.\u0018(this));
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x00051500 File Offset: 0x0004F700
		[BindableMethod("CheckAllSheetInfo")]
		public void CheckAllSheetInfo(bool isChecked)
		{
			\u0020\u000C\u000F.\u0018(\u001F\u000C\u000F.\u0018(this), isChecked);
			List<long> u000C = this.\u0005\u0009();
			this.\u000E\u0009(u000C);
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x0005152C File Offset: 0x0004F72C
		[BindableMethod("ParameterTransfer")]
		public void ParameterTransfer()
		{
			ParameterTransfer u000C = \u000F\u0018\u000F.\u0018(\u0017\u000B\u0016.\u0003(this), \u001F\u001A\u0016.\u0003(this));
			\u001B\u0007\u0018.\u0018(u000C, \u0001\u000C\u0014.\u0018(this));
			bool? flag = \u001E\u0007\u0018.\u0014(u000C);
			if (\u000C\u0007\u0018.\u0018(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.ParameterTransfer()).MethodHandle;
				}
				\u0020\u0007\u0016.\u0003(this, Enumerable.ToList<ParameterInformation>(\u0004\u000B\u0016.\u0014(\u0002\u0006\u000F.\u000C(\u0003\u0012\u0014.\u0014(u000C)))));
				\u000A\u0007\u0016.\u0003(this);
			}
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x000515B0 File Offset: 0x0004F7B0
		private void \u0007\u0009()
		{
			\u001C\u0018\u000F.\u0018(this, \u0018\u0010\u0016.\u0018());
			\u0005\u0007\u0016.\u0018(\u0016\u0010\u0016.\u0003(this), \u000D\u0018\u000F.\u0018(), BrowserOption.BrowserOrganization);
			\u0005\u0007\u0016.\u0018(\u0016\u0010\u0016.\u0003(this), \u0012\u0018\u000F.\u0018(), BrowserOption.SheetList);
			\u001B\u0007\u0016.\u0003(this, \u0018\u0010\u0016.\u0018());
			\u0005\u0007\u0016.\u0018(\u000E\u000E\u0016.\u0018(this), Enumerable.First<string>(\u0017\u0019\u0016.\u0018(\u0016\u0010\u0016.\u0003(this))), Enumerable.First<object>(\u0005\u000E\u0016.\u0003(\u0016\u0010\u0016.\u0003(this))));
		}

		// Token: 0x06000DE9 RID: 3561 RVA: 0x00051644 File Offset: 0x0004F844
		public void GetBrowserOptionSheets()
		{
			\u0013\u0018\u000F.\u0018(this, \u0001\u000C\u000F.\u0018());
			this.\u0010\u0009();
			if (\u001F\u001A\u0016.\u0003(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.GetBrowserOptionSheets()).MethodHandle;
				}
				\u0008\u0007\u0016.\u0003(this);
			}
			\u0013\u000C\u000F.\u0018(this, \u0009\u000C\u000F.\u0018(\u0009\u0019\u0016.\u0003(this), new Predicate<ITreeItem>(this.\u0006\u0009)));
			\u000A\u000C\u000F.\u0018(this, false);
			\u001C\u000C\u000F.\u0018(this, \u0010\u0006\u0018.\u0018(\u0009\u0019\u0016.\u0003(this)));
			\u0005\u0006\u0018.\u0018(\u000C\u000C\u000F.\u0018(this), new Predicate<object>(this.FilterView));
		}

		// Token: 0x06000DEA RID: 3562 RVA: 0x000516E0 File Offset: 0x0004F8E0
		private void \u0010\u0009()
		{
			BrowserOrganization browserOrganization = \u001E\u0006\u000F.\u000C(Enumerable.First<object>(\u0005\u000E\u0016.\u0003(\u001E\u0019\u0016.\u0003(this))));
			if (\u0004\u0019\u0016.\u0003(this) == BrowserOption.BrowserOrganization)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.\u0010\u0009()).MethodHandle;
				}
				\u0013\u0018\u000F.\u0018(this, \u000C\u0017\u0018.\u000C(\u0014\u000E\u0018.\u0018(\u000A\u0018\u000F.\u0018(this)), this.\u0004\u0018, browserOrganization));
				\u0009\u0018\u000F.\u0018(this, true);
				return;
			}
			\u0013\u0018\u000F.\u0018(this, \u001B\u0015\u0018.\u0014(this.\u0004\u0018, browserOrganization));
			\u0009\u0018\u000F.\u0018(this, false);
		}

		// Token: 0x06000DEB RID: 3563 RVA: 0x00051770 File Offset: 0x0004F970
		private bool \u0006\u0009(ITreeItem \u000C)
		{
			bool flag = false;
			ViewInfo viewInfo = \u0017\u0006\u000F.\u000C(\u000C);
			if (viewInfo != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.\u0006\u0009(ITreeItem)).MethodHandle;
				}
				flag = \u001B\u0013\u0018.\u000C(\u001F\u0018\u000F.\u0018(viewInfo), \u0020\u0018\u000F.\u0018(this));
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
					bool flag2 = false;
					\u000C\u0017\u0018.\u000F(viewInfo, ref flag2);
					flag = flag2;
				}
			}
			return flag;
		}

		// Token: 0x06000DEC RID: 3564 RVA: 0x000517D0 File Offset: 0x0004F9D0
		private void \u0008\u0009()
		{
			\u0002\u0018\u000F.\u0018(this, \u0015\u0016\u0003.\u0018(this.\u0004\u0018));
			object u000C = \u0014\u000E\u0018.\u0018(\u000A\u0018\u000F.\u0018(this));
			\u001A\u000C\u000F.\u0018(this, \u000C\u0018\u000F.\u0018());
			List<ViewSheet>.Enumerator enumerator = \u001F\u001D\u0014.\u0018(u000C);
			try
			{
				while (\u0013\u001D\u0014.\u0018(ref enumerator))
				{
					SheetInformation sheetInformation = \u001E\u0018\u000F.\u0018(\u0020\u001D\u0014.\u0018(ref enumerator));
					\u0017\u0018\u000F.\u0018(sheetInformation, false);
					SheetInformation u = sheetInformation;
					\u0015\u0018\u000F.\u0018(\u0015\u0007\u0016.\u0003(this), u);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.\u0008\u0009()).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			object u000C2 = \u0015\u0007\u0016.\u0003(this);
			Comparison<SheetInformation> u2;
			if ((u2 = SheetsViewModel.<>c.\u0009) == null)
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
				u2 = (SheetsViewModel.<>c.\u0009 = new Comparison<SheetInformation>(SheetsViewModel.<>c.\u000C.\u0001));
			}
			\u0011\u0018\u000F.\u0018(u000C2, u2);
		}

		// Token: 0x06000DED RID: 3565 RVA: 0x000518B0 File Offset: 0x0004FAB0
		private void \u0001\u0009()
		{
			object u000C = \u0006\u0018\u000F.\u0018();
			List<SheetInformation> u000C2 = \u000C\u0018\u000F.\u0018();
			List<Document>.Enumerator enumerator = \u0014\u001A\u0016.\u0018(u000C);
			try
			{
				while (\u0001\u001D\u0016.\u0018(ref enumerator))
				{
					Document document = \u0018\u001A\u0016.\u0018(ref enumerator);
					LinkDocumentSheetCollector linkDocumentSheetCollector = \u0010\u0018\u000F.\u0018();
					\u0007\u0018\u000F.\u0018(linkDocumentSheetCollector, \u0006\u0004\u0018.\u0018(document));
					\u0019\u0018\u000F.\u0018(linkDocumentSheetCollector, document);
					List<ViewSheet> list = \u0014\u000E\u0018.\u0018(\u0015\u0016\u0003.\u0018(document));
					\u000B\u0018\u000F.\u0018(linkDocumentSheetCollector, list);
					List<SheetInformation> list2 = \u000C\u0018\u000F.\u0018();
					List<ViewSheet>.Enumerator enumerator2 = \u001F\u001D\u0014.\u0018(list);
					try
					{
						while (\u0013\u001D\u0014.\u0018(ref enumerator2))
						{
							SheetInformation sheetInformation = \u001E\u0018\u000F.\u0018(\u0020\u001D\u0014.\u0018(ref enumerator2));
							\u0017\u0018\u000F.\u0018(sheetInformation, true);
							SheetInformation u = sheetInformation;
							\u0015\u0018\u000F.\u0018(list2, u);
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
						if (!true)
						{
							RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.\u0001\u0009()).MethodHandle;
						}
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
					object u000C3 = list2;
					Comparison<SheetInformation> u2;
					if ((u2 = SheetsViewModel.<>c.\u000A) == null)
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
						u2 = (SheetsViewModel.<>c.\u000A = new Comparison<SheetInformation>(SheetsViewModel.<>c.\u000C.\u001B));
					}
					\u0011\u0018\u000F.\u0018(u000C3, u2);
					\u000B\u000C\u000F.\u0018(u000C2, list2);
					\u001A\u0018\u000F.\u0018(\u001D\u000C\u000F.\u0018(this), linkDocumentSheetCollector);
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
			\u0004\u0018\u000F.\u0018(\u001D\u0018\u000F.\u0018(u000C2));
		}

		// Token: 0x06000DEE RID: 3566 RVA: 0x00051A30 File Offset: 0x0004FC30
		public List<ParameterInformation> UpdateParameter(SheetInformation sheetInformation)
		{
			List<ParameterInformation> list = \u0001\u001A\u0016.\u0018();
			IEnumerable<Parameter> enumerable = Enumerable.Cast<Parameter>(\u000E\u0018\u000F.\u0018(\u000B\u0002\u0016.\u0003(sheetInformation)));
			Func<Parameter, bool> func;
			if ((func = SheetsViewModel.\u000A\u0015\u0018.\u000C) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.UpdateParameter(SheetInformation)).MethodHandle;
				}
				func = (SheetsViewModel.\u000A\u0015\u0018.\u000C = new Func<Parameter, bool>(SheetsViewModel.\u001B\u0009));
			}
			IEnumerator<Parameter> enumerator = \u0005\u0018\u000F.\u0018(Enumerable.Where<Parameter>(enumerable, func));
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					Parameter u000C = \u001B\u0018\u000F.\u0018(enumerator);
					ParameterInformation parameterInformation = \u0016\u000B\u0016.\u0018();
					\u0003\u000B\u0016.\u0014(parameterInformation, \u0003\u000B\u0014.\u0018(\u0018\u000B\u0014.\u0018(u000C)));
					\u0014\u000B\u0016.\u0018(parameterInformation, \u0003\u000B\u0014.\u0018(\u0018\u000B\u0014.\u0018(u000C)));
					\u0018\u000B\u0016.\u0014(parameterInformation, \u0005\u001A\u0014.\u0018(u000C).\u000C());
					\u000C\u000B\u0016.\u0014(parameterInformation, \u001B\u0002\u0018.\u0018(u000C));
					\u000E\u001A\u0016.\u0014(parameterInformation, ParameterType.InstnaceParameter);
					\u0008\u0018\u000F.\u0018(parameterInformation, false);
					if (\u0001\u0018\u000F.\u0018(sheetInformation))
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
						\u0008\u0018\u000F.\u0018(parameterInformation, true);
					}
					\u0005\u001A\u0016.\u0018(list, parameterInformation);
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
			}
			finally
			{
				if (enumerator != null)
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
					\u0020\u001E\u0018.\u0018(enumerator);
				}
			}
			return list;
		}

		// Token: 0x06000DEF RID: 3567 RVA: 0x00051B6C File Offset: 0x0004FD6C
		public void GetSheetNameAndNumber()
		{
			\u0020\u0007\u0016.\u0003(this, \u0001\u001A\u0016.\u0018());
			IEnumerable<ParameterInformation> enumerable = \u0010\u0007\u0016.\u0018();
			Func<ParameterInformation, bool> func;
			if ((func = SheetsViewModel.<>c.\u0020) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.GetSheetNameAndNumber()).MethodHandle;
				}
				func = (SheetsViewModel.<>c.\u0020 = new Func<ParameterInformation, bool>(SheetsViewModel.<>c.\u000C.\u0005));
			}
			\u0020\u0007\u0016.\u0003(this, Enumerable.ToList<ParameterInformation>(Enumerable.Where<ParameterInformation>(enumerable, func)));
			\u0008\u001A\u0016.\u0018(Enumerable.ToList<ParameterInformation>(Enumerable.Except<ParameterInformation>(\u0010\u0007\u0016.\u0018(), \u0017\u000B\u0016.\u0003(this))));
			\u000C\u0014\u000F.\u0018(\u001F\u0007\u0016.\u0018(\u0017\u000B\u0016.\u0003(this)));
		}

		// Token: 0x06000DF0 RID: 3568 RVA: 0x00051C0C File Offset: 0x0004FE0C
		private static bool \u001B\u0009(Parameter \u000C)
		{
			if (\u0018\u000B\u0014.\u0018(\u000C) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.\u001B\u0009(Parameter)).MethodHandle;
				}
				if (\u001B\u0002\u0018.\u0018(\u000C) != null)
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
					if (\u001B\u0002\u0018.\u0018(\u000C) != 4)
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
						return \u0005\u001A\u0014.\u0018(\u000C).\u000C() != -1006601L;
					}
				}
			}
			return false;
		}

		// Token: 0x06000DF1 RID: 3569 RVA: 0x00051C7C File Offset: 0x0004FE7C
		private List<long> \u0005\u0009()
		{
			\u0003\u0014\u000F.\u0018(this, this.\u0018\u000A(\u0009\u0019\u0016.\u0003(this)));
			object u000C = \u0018\u0014\u000F.\u0018(this);
			Predicate<ViewInfo> u;
			if ((u = SheetsViewModel.<>c.\u001F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.\u0005\u0009()).MethodHandle;
				}
				u = (SheetsViewModel.<>c.\u001F = new Predicate<ViewInfo>(SheetsViewModel.<>c.\u000C.\u000E));
			}
			bool flag = \u0014\u0014\u000F.\u0018(u000C, u);
			if (!flag)
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
				object u000C2 = \u0018\u0014\u000F.\u0018(this);
				Predicate<ViewInfo> u2;
				if ((u2 = SheetsViewModel.<>c.\u0011) == null)
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
					u2 = (SheetsViewModel.<>c.\u0011 = new Predicate<ViewInfo>(SheetsViewModel.<>c.\u000C.\u000C\u0018));
				}
				if (\u0010\u000C\u000F.\u0018(u000C2, u2))
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
					bool? u3;
					\u000B\u0004\u000F.\u000C(ref u3);
					\u0018\u0018\u000F.\u0018(this, u3);
					goto IL_C5;
				}
			}
			\u0018\u0018\u000F.\u0018(this, new bool?(flag));
			IL_C5:
			IEnumerable<ViewInfo> enumerable = \u0018\u0014\u000F.\u0018(this);
			Func<ViewInfo, bool> func;
			if ((func = SheetsViewModel.<>c.\u0015) == null)
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
				func = (SheetsViewModel.<>c.\u0015 = new Func<ViewInfo, bool>(SheetsViewModel.<>c.\u000C.\u0018\u0018));
			}
			IEnumerable<ViewInfo> enumerable2 = Enumerable.Where<ViewInfo>(enumerable, func);
			Func<ViewInfo, long> func2;
			if ((func2 = SheetsViewModel.<>c.\u0017) == null)
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
				func2 = (SheetsViewModel.<>c.\u0017 = new Func<ViewInfo, long>(SheetsViewModel.<>c.\u000C.\u0014\u0018));
			}
			return Enumerable.ToList<long>(Enumerable.Select<ViewInfo, long>(enumerable2, func2));
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x00051DC0 File Offset: 0x0004FFC0
		private void \u000E\u0009(List<long> \u000C)
		{
			SheetsViewModel.\u001E\u0015\u0018 u001E_u0015_u = new SheetsViewModel.\u001E\u0015\u0018();
			u001E_u0015_u.\u000C = \u000C;
			List<SheetInformation> u000C = Enumerable.ToList<SheetInformation>(Enumerable.Where<SheetInformation>(\u0015\u0007\u0016.\u0003(this), new Func<SheetInformation, bool>(u001E_u0015_u.\u0018)));
			\u0011\u0007\u0016.\u0003(this, \u001D\u0018\u000F.\u0018(u000C));
			\u000A\u0007\u0016.\u0003(this);
			\u0009\u0007\u0016.\u0003(this);
		}

		// Token: 0x06000DF3 RID: 3571 RVA: 0x00051E18 File Offset: 0x00050018
		public bool FilterView(object obj)
		{
			ViewInfo viewInfo = \u0017\u0006\u000F.\u000C(obj);
			if (viewInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.FilterView(object)).MethodHandle;
				}
				return false;
			}
			this.\u000C\u000A(viewInfo);
			return true;
		}

		// Token: 0x06000DF4 RID: 3572 RVA: 0x00051E54 File Offset: 0x00050054
		private bool \u000C\u000A(ViewInfo \u000C)
		{
			\u0016\u0014\u000F.\u0018(\u000C, false);
			bool flag;
			if (!\u001F\u001A\u0018.\u0018(\u0020\u0018\u000F.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.\u000C\u000A(ProSheets.DrawingRegister.Model.TreeViewModel.ViewInfo)).MethodHandle;
				}
				flag = \u001B\u0013\u0018.\u000C(\u001F\u0018\u000F.\u0018(\u000C), \u0020\u0018\u000F.\u0018(this));
			}
			else
			{
				flag = true;
			}
			if (\u0012\u0014\u000F.\u0018(this))
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
				bool flag3;
				if (flag)
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
					bool? flag2 = \u0019\u0019\u0016.\u0018(\u000C);
					flag3 = \u000C\u0007\u0018.\u0018(ref flag2);
				}
				else
				{
					flag3 = false;
				}
				flag = flag3;
			}
			List<ViewInfo>.Enumerator enumerator = \u0008\u0019\u0016.\u0018(\u0007\u0019\u0016.\u0014(\u000C));
			try
			{
				while (\u000B\u0019\u0016.\u0018(ref enumerator))
				{
					ViewInfo u000C = \u0006\u0019\u0016.\u0018(ref enumerator);
					if (this.\u000C\u000A(u000C))
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
						flag = true;
					}
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u000F\u0014\u000F.\u0018(\u000C, new bool?(flag));
			if (!\u001F\u001A\u0018.\u0018(\u0020\u0018\u000F.\u0018(this)))
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
				\u0016\u0014\u000F.\u0018(\u000C, flag);
			}
			return flag;
		}

		// Token: 0x06000DF5 RID: 3573 RVA: 0x00051F78 File Offset: 0x00050178
		private List<ViewInfo> \u0018\u000A(List<ViewInfo> \u000C)
		{
			List<ViewInfo> list = \u0001\u000C\u000F.\u0018();
			List<ViewInfo>.Enumerator enumerator = \u0008\u0019\u0016.\u0018(\u000C);
			try
			{
				while (\u000B\u0019\u0016.\u0018(ref enumerator))
				{
					ViewInfo viewInfo = \u0006\u0019\u0016.\u0018(ref enumerator);
					if (!Enumerable.Any<ViewInfo>(\u0007\u0019\u0016.\u0014(viewInfo)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.\u0018\u000A(List<ProSheets.DrawingRegister.Model.TreeViewModel.ViewInfo>)).MethodHandle;
						}
						\u000D\u0014\u000F.\u0018(list, viewInfo);
					}
					if (Enumerable.Any<ViewInfo>(\u0007\u0019\u0016.\u0014(viewInfo)))
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
						\u0007\u000C\u000F.\u0018(list, this.\u0018\u000A(Enumerable.ToList<ViewInfo>(\u0007\u0019\u0016.\u0014(viewInfo))));
					}
				}
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x06000DF6 RID: 3574 RVA: 0x0005203C File Offset: 0x0005023C
		public DataGridTextColumn PopulateColumns(ParameterInformation parameterInformation, int index)
		{
			DataGridTextColumn dataGridTextColumn = \u0017\u0014\u0003.\u0018();
			\u0015\u0014\u0003.\u0018(dataGridTextColumn, \u001F\u0001\u0016.\u0018(parameterInformation).\u000C());
			HorizontalAlignment horizontalAlignment = \u0011\u0014\u000F.\u0018(parameterInformation);
			string u = "Parameters";
			string u000C = \u001F\u0014\u000F.\u0018(\u0007\u000C\u0003.\u0018("{0}[{1}].{2}", u, index, "ParameterValue"), Array.Empty<object>());
			\u0020\u0014\u0003.\u0018(dataGridTextColumn, \u001F\u0014\u0003.\u0018(u000C));
			System.Windows.Style style = \u0020\u0014\u000F.\u0018(\u000A\u001D\u0018.\u0018(\u001F\u0006\u000F.\u000C()));
			\u0003\u001B\u0018.\u0018(\u0016\u001B\u0018.\u0018(style), \u0013\u0014\u000F.\u0018(FrameworkElement.HorizontalAlignmentProperty, horizontalAlignment));
			\u000A\u0014\u000F.\u0018(dataGridTextColumn, style);
			System.Windows.Style u2 = \u0011\u0006\u000F.\u000C(\u001A\u0009\u0014.\u0003(\u0001\u000C\u0014.\u0018(this), "DataGridColumnHeaderStyle"));
			System.Windows.Style style2 = \u0009\u0014\u000F.\u0018(\u000A\u001D\u0018.\u0018(\u0015\u0006\u000F.\u000C()), u2);
			\u0003\u001B\u0018.\u0018(\u0016\u001B\u0018.\u0018(style2), \u0013\u0014\u000F.\u0018(Control.HorizontalContentAlignmentProperty, horizontalAlignment));
			\u001C\u0014\u000F.\u0018(dataGridTextColumn, style2);
			\u000A\u0014\u0003.\u0018(dataGridTextColumn, true);
			return dataGridTextColumn;
		}

		// Token: 0x06000DF7 RID: 3575 RVA: 0x00052150 File Offset: 0x00050350
		public void GeneratingColumns()
		{
			\u000A\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\SheetsViewModel.cs", "GeneratingColumns");
			if (\u0017\u000B\u0016.\u0003(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.GeneratingColumns()).MethodHandle;
				}
				List<SheetInformation>.Enumerator enumerator = \u001D\u0014\u000F.\u0018(\u001D\u001A\u0016.\u0003(this));
				try
				{
					while (\u0017\u0014\u000F.\u0018(ref enumerator))
					{
						SheetInformation u000C = \u0004\u0014\u000F.\u0018(ref enumerator);
						\u001D\u0002\u0016.\u0003(u000C, \u0001\u001A\u0016.\u0018());
						List<ParameterInformation>.Enumerator enumerator2 = \u0020\u0004\u0016.\u0018(\u0017\u000B\u0016.\u0003(this));
						try
						{
							while (\u000F\u0004\u0016.\u0018(ref enumerator2))
							{
								ParameterInformation u000C2 = \u000A\u0004\u0016.\u0018(ref enumerator2);
								\u0005\u001A\u0016.\u0018(\u001F\u0004\u0016.\u0003(u000C), \u0002\u0014\u000F.\u0018(u000C2));
							}
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
						finally
						{
							((IDisposable)enumerator2).Dispose();
						}
						\u001E\u0014\u000F.\u0018(u000C);
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
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			\u0015\u0014\u000F.\u0018(this);
			\u000D\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\SheetsViewModel.cs", "GeneratingColumns");
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x00052278 File Offset: 0x00050478
		public void RefreshDataGridColumns()
		{
			int num = 0;
			ObservableCollection<DataGridColumn> observableCollection = \u0007\u0014\u000F.\u0018();
			if (\u0017\u000B\u0016.\u0003(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.RefreshDataGridColumns()).MethodHandle;
				}
				List<ParameterInformation>.Enumerator enumerator = \u0020\u0004\u0016.\u0018(\u0017\u000B\u0016.\u0003(this));
				try
				{
					while (\u000F\u0004\u0016.\u0018(ref enumerator))
					{
						ParameterInformation u = \u000A\u0004\u0016.\u0018(ref enumerator);
						DataGridTextColumn u2 = \u0019\u0014\u000F.\u0018(this, u, num);
						\u000B\u0014\u000F.\u0018(observableCollection, u2);
						num++;
					}
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
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			\u001A\u0014\u000F.\u0018(this, observableCollection);
		}

		// Token: 0x06000DF9 RID: 3577 RVA: 0x0005231C File Offset: 0x0005051C
		public void UpdateStatus()
		{
			\u0003\u0014\u000F.\u0018(this, this.\u0018\u000A(\u0009\u0019\u0016.\u0003(this)));
			string u = string.Empty;
			if (\u0004\u0019\u0016.\u0003(this) == BrowserOption.BrowserOrganization)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.UpdateStatus()).MethodHandle;
				}
				string u000C = \u0001\u0014\u000F.\u0018();
				object u2 = \u0006\u0014\u000F.\u0018(\u0018\u0014\u000F.\u0018(this));
				IEnumerable<ViewInfo> enumerable = \u0018\u0014\u000F.\u0018(this);
				Func<ViewInfo, bool> func;
				if ((func = SheetsViewModel.<>c.\u001E) == null)
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
					func = (SheetsViewModel.<>c.\u001E = new Func<ViewInfo, bool>(SheetsViewModel.<>c.\u000C.\u0003\u0018));
				}
				u = \u001A\u001E\u0018.\u0018(u000C, u2, Enumerable.Count<ViewInfo>(enumerable, func));
			}
			else
			{
				string u000C2 = \u0008\u0014\u000F.\u0018();
				object u3 = \u0006\u0014\u000F.\u0018(\u0018\u0014\u000F.\u0018(this));
				IEnumerable<ViewInfo> enumerable2 = \u0018\u0014\u000F.\u0018(this);
				Func<ViewInfo, bool> func2;
				if ((func2 = SheetsViewModel.<>c.\u0002) == null)
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
					func2 = (SheetsViewModel.<>c.\u0002 = new Func<ViewInfo, bool>(SheetsViewModel.<>c.\u000C.\u0016\u0018));
				}
				u = \u001A\u001E\u0018.\u0018(u000C2, u3, Enumerable.Count<ViewInfo>(enumerable2, func2));
			}
			\u0010\u0014\u000F.\u0018(this, u);
		}

		// Token: 0x06000DFA RID: 3578 RVA: 0x0005242C File Offset: 0x0005062C
		[BindableMethod("EditParameterName")]
		public void EditParameterName()
		{
			try
			{
				SheetsViewModel.\u0002\u0015\u0018 u0002_u0015_u = new SheetsViewModel.\u0002\u0015\u0018();
				u0002_u0015_u.\u0018 = this;
				\u0005\u0014\u000F.\u0018(this, \u0011\u0010\u0016.\u0018(\u0017\u000B\u0016.\u0003(this), new Predicate<ParameterInformation>(this.\u0014\u000A)));
				u0002_u0015_u.\u000C = \u0020\u0001\u0016.\u0018(\u001B\u0014\u000F.\u0018(this));
				\u000A\u0001\u0016.\u0018(u0002_u0015_u.\u000C, new Action(u0002_u0015_u.\u0014));
				ParameterNameChange u000C = \u0009\u0001\u0016.\u0018(u0002_u0015_u.\u000C);
				\u001B\u0007\u0018.\u0018(u000C, \u0001\u000C\u0014.\u0018(this));
				\u001E\u0007\u0018.\u0014(u000C);
			}
			catch (Exception u)
			{
				\u0017\u001E\u0014.\u0018(\u0002\u0002\u0016.\u0018(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\SheetsViewModel.cs", "EditParameterName");
			}
		}

		// Token: 0x06000DFB RID: 3579 RVA: 0x000524E4 File Offset: 0x000506E4
		public bool CanUndoParameterName(object o)
		{
			ParameterInformation parameterInformation = \u0011\u0010\u0016.\u0018(\u0017\u000B\u0016.\u0003(this), new Predicate<ParameterInformation>(this.\u000F\u000A));
			if (parameterInformation != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsViewModel.CanUndoParameterName(object)).MethodHandle;
				}
				return \u0009\u001E\u0018.\u0018(\u001F\u0001\u0016.\u0018(parameterInformation), \u0010\u0008\u0016.\u0014(parameterInformation));
			}
			return false;
		}

		// Token: 0x06000DFC RID: 3580 RVA: 0x0005253C File Offset: 0x0005073C
		public void UndoParameterName()
		{
			try
			{
				\u0005\u0014\u000F.\u0018(this, \u0011\u0010\u0016.\u0018(\u0017\u000B\u0016.\u0003(this), new Predicate<ParameterInformation>(this.\u0012\u000A)));
				\u0015\u0014\u0003.\u0018(Enumerable.FirstOrDefault<DataGridColumn>(\u000C\u0003\u000F.\u0018(this), new Func<DataGridColumn, bool>(this.\u000D\u000A)), \u0010\u0008\u0016.\u0014(\u000E\u0014\u000F.\u0018(this)).\u000C());
				\u0014\u000B\u0016.\u0018(\u0011\u0010\u0016.\u0018(\u0017\u000B\u0016.\u0003(this), new Predicate<ParameterInformation>(this.\u001C\u000A)), \u0010\u0008\u0016.\u0014(\u000E\u0014\u000F.\u0018(this)));
			}
			catch (Exception u)
			{
				\u0017\u001E\u0014.\u0018(\u0002\u0002\u0016.\u0018(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\SheetsViewModel.cs", "UndoParameterName");
			}
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x000525FC File Offset: 0x000507FC
		[BindableMethod("ParameterLeftAlign")]
		public void ParameterLeftAlign()
		{
			this.\u001C\u0009(HorizontalAlignment.Left);
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x00052610 File Offset: 0x00050810
		[BindableMethod("ParameterRightAlign")]
		public void ParameterRightAlign()
		{
			this.\u001C\u0009(HorizontalAlignment.Right);
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x00052624 File Offset: 0x00050824
		[BindableMethod("ParameterCenterAlign")]
		public void ParameterCenterAlign()
		{
			this.\u001C\u0009(HorizontalAlignment.Center);
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x00052638 File Offset: 0x00050838
		private void \u001C\u0009(HorizontalAlignment \u000C)
		{
			SheetsViewModel.\u0004\u0015\u0018 u0004_u0015_u = new SheetsViewModel.\u0004\u0015\u0018();
			u0004_u0015_u.\u000C = this;
			u0004_u0015_u.\u0018 = \u0011\u0010\u0016.\u0018(\u0017\u000B\u0016.\u0003(this), new Predicate<ParameterInformation>(u0004_u0015_u.\u0014));
			object u = u0004_u0015_u.\u0018;
			\u0015\u0001\u0016.\u0018(\u0011\u0010\u0016.\u0018(\u0017\u000B\u0016.\u0003(this), new Predicate<ParameterInformation>(u0004_u0015_u.\u0003)), \u000C);
			\u0015\u0001\u0016.\u0018(u, \u000C);
			DataGridColumn u2 = Enumerable.FirstOrDefault<DataGridColumn>(\u000C\u0003\u000F.\u0018(this), new Func<DataGridColumn, bool>(u0004_u0015_u.\u0016));
			int num = \u0014\u0003\u000F.\u0018(\u000C\u0003\u000F.\u0018(this), u2);
			\u0018\u0003\u000F.\u0018(\u000C\u0003\u000F.\u0018(this), num, \u0019\u0014\u000F.\u0018(this, u0004_u0015_u.\u0018, num));
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x000526EC File Offset: 0x000508EC
		[CompilerGenerated]
		private bool \u0014\u000A(ParameterInformation \u000C)
		{
			return \u000F\u0002\u0018.\u0018(\u001F\u0001\u0016.\u0018(\u000C), \u001B\u0014\u000F.\u0018(this));
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x00052710 File Offset: 0x00050910
		[CompilerGenerated]
		private bool \u0003\u000A(DataGridColumn \u000C)
		{
			return \u000F\u0002\u0018.\u0018(\u0003\u0003\u000F.\u0018(\u000C), \u001F\u0001\u0016.\u0018(\u000E\u0014\u000F.\u0018(this)));
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x0005273C File Offset: 0x0005093C
		[CompilerGenerated]
		private bool \u0016\u000A(ParameterInformation \u000C)
		{
			return \u000D\u0004\u0016.\u0018(\u000C) == \u000D\u0004\u0016.\u0018(\u000E\u0014\u000F.\u0018(this));
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x00052764 File Offset: 0x00050964
		[CompilerGenerated]
		private bool \u000F\u000A(ParameterInformation \u000C)
		{
			return \u000F\u0002\u0018.\u0018(\u001F\u0001\u0016.\u0018(\u000C), \u001B\u0014\u000F.\u0018(this));
		}

		// Token: 0x06000E05 RID: 3589 RVA: 0x00052788 File Offset: 0x00050988
		[CompilerGenerated]
		private bool \u0012\u000A(ParameterInformation \u000C)
		{
			return \u000F\u0002\u0018.\u0018(\u001F\u0001\u0016.\u0018(\u000C), \u001B\u0014\u000F.\u0018(this));
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x000527AC File Offset: 0x000509AC
		[CompilerGenerated]
		private bool \u000D\u000A(DataGridColumn \u000C)
		{
			return \u000F\u0002\u0018.\u0018(\u0003\u0003\u000F.\u0018(\u000C), \u001F\u0001\u0016.\u0018(\u000E\u0014\u000F.\u0018(this)));
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x000527D8 File Offset: 0x000509D8
		[CompilerGenerated]
		private bool \u001C\u000A(ParameterInformation \u000C)
		{
			return \u000D\u0004\u0016.\u0018(\u000C) == \u000D\u0004\u0016.\u0018(\u000E\u0014\u000F.\u0018(this));
		}

		// Token: 0x04000614 RID: 1556
		private readonly Document \u0004\u0018;

		// Token: 0x04000615 RID: 1557
		private List<ParameterInformation> \u0013\u000F;

		// Token: 0x04000616 RID: 1558
		private List<SheetInformation> \u0009\u000F = new List<SheetInformation>();

		// Token: 0x04000617 RID: 1559
		private ObservableCollection<DataGridColumn> \u000A\u000F;

		// Token: 0x04000618 RID: 1560
		private Dictionary<string, object> \u0020\u000F;

		// Token: 0x04000619 RID: 1561
		private Dictionary<string, object> \u001F\u000F;

		// Token: 0x0400061A RID: 1562
		private List<ViewInfo> \u0011\u000F;

		// Token: 0x0400061B RID: 1563
		private bool? \u0015\u000F = new bool?(false);

		// Token: 0x0400061C RID: 1564
		private bool \u0013;

		// Token: 0x0400061D RID: 1565
		private string \u0017\u000F = string.Empty;

		// Token: 0x0400061E RID: 1566
		private bool \u001E\u000F;

		// Token: 0x0400061F RID: 1567
		private string \u000E\u0003;

		// Token: 0x04000620 RID: 1568
		private string \u0002\u000F;

		// Token: 0x04000621 RID: 1569
		private bool \u0004\u000F = true;

		// Token: 0x04000622 RID: 1570
		private Dictionary<string, object> \u001D\u000F;

		// Token: 0x04000623 RID: 1571
		private TreeManager \u001A\u000F;

		// Token: 0x04000624 RID: 1572
		[CompilerGenerated]
		private Dictionary<string, object> \u000B\u000F;

		// Token: 0x04000625 RID: 1573
		[CompilerGenerated]
		private BrowserOption \u0019\u000F;

		// Token: 0x04000626 RID: 1574
		[CompilerGenerated]
		private List<ParameterInformation> \u0007\u000F;

		// Token: 0x04000627 RID: 1575
		[CompilerGenerated]
		private List<ViewInfo> \u0010\u000F;

		// Token: 0x04000628 RID: 1576
		[CompilerGenerated]
		private List<SheetInformation> \u0006\u000F;

		// Token: 0x04000629 RID: 1577
		[CompilerGenerated]
		private ViewsSheetsCollector \u000E\u0018;

		// Token: 0x0400062A RID: 1578
		[CompilerGenerated]
		private List<LinkDocumentSheetCollector> \u0008\u000F;

		// Token: 0x0400062B RID: 1579
		[CompilerGenerated]
		private ICollectionView \u0001\u000F;

		// Token: 0x0400062C RID: 1580
		[CompilerGenerated]
		private ParameterInformation \u001B\u000F;

		// Token: 0x0400062D RID: 1581
		[CompilerGenerated]
		private BrowserOrganization \u0005\u000F;

		// Token: 0x0400062E RID: 1582
		[CompilerGenerated]
		private BrowserOption \u000E\u000F;

		// Token: 0x0400062F RID: 1583
		[CompilerGenerated]
		private CommandBase \u000C\u0012;

		// Token: 0x02000206 RID: 518
		[CompilerGenerated]
		private static class \u000A\u0015\u0018
		{
			// Token: 0x04000940 RID: 2368
			public static Func<Parameter, bool> \u000C;
		}

		// Token: 0x02000208 RID: 520
		[CompilerGenerated]
		private sealed class \u0020\u0015\u0018
		{
			// Token: 0x060012E3 RID: 4835 RVA: 0x00061058 File Offset: 0x0005F258
			internal bool \u0018(ViewInfo \u000C)
			{
				SheetsViewModel.\u001F\u0015\u0018 u001F_u0015_u = new SheetsViewModel.\u001F\u0015\u0018();
				u001F_u0015_u.\u000C = \u000C;
				return \u0010\u000C\u000F.\u0018(this.\u000C, new Predicate<ViewInfo>(u001F_u0015_u.\u0018));
			}

			// Token: 0x04000954 RID: 2388
			public List<ViewInfo> \u000C;
		}

		// Token: 0x02000209 RID: 521
		[CompilerGenerated]
		private sealed class \u001F\u0015\u0018
		{
			// Token: 0x060012E5 RID: 4837 RVA: 0x000610A0 File Offset: 0x0005F2A0
			internal bool \u0018(ViewInfo \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001F\u0018\u000F.\u0018(\u000C), \u001F\u0018\u000F.\u0018(this.\u000C));
			}

			// Token: 0x04000955 RID: 2389
			public ViewInfo \u000C;
		}

		// Token: 0x0200020A RID: 522
		[CompilerGenerated]
		private sealed class \u0011\u0015\u0018
		{
			// Token: 0x060012E7 RID: 4839 RVA: 0x000610E0 File Offset: 0x0005F2E0
			internal bool \u0018(ViewInfo \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001F\u0018\u000F.\u0018(\u000C), \u0013\u001E\u000F.\u0018(this.\u000C));
			}

			// Token: 0x04000956 RID: 2390
			public LinkDocumentSheetCollector \u000C;
		}

		// Token: 0x0200020B RID: 523
		[CompilerGenerated]
		private sealed class \u0015\u0015\u0018
		{
			// Token: 0x060012E9 RID: 4841 RVA: 0x00061120 File Offset: 0x0005F320
			internal bool \u0018(KeyValuePair<string, object> \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u000C\u0010\u0016.\u0018(ref \u000C), \u0001\u0017\u0018.\u0018(\u0002\u000B\u0018.\u0018(this.\u000C)));
			}

			// Token: 0x04000957 RID: 2391
			public CheckBox \u000C;
		}

		// Token: 0x0200020C RID: 524
		[CompilerGenerated]
		private sealed class \u0017\u0015\u0018
		{
			// Token: 0x060012EB RID: 4843 RVA: 0x00061168 File Offset: 0x0005F368
			internal bool \u0018(KeyValuePair<string, object> \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u000C\u0010\u0016.\u0018(ref \u000C), \u0001\u0017\u0018.\u0018(\u0002\u000B\u0018.\u0018(this.\u000C)));
			}

			// Token: 0x04000958 RID: 2392
			public CheckBox \u000C;
		}

		// Token: 0x0200020D RID: 525
		[CompilerGenerated]
		private sealed class \u001E\u0015\u0018
		{
			// Token: 0x060012ED RID: 4845 RVA: 0x000611B0 File Offset: 0x0005F3B0
			internal bool \u0018(SheetInformation \u000C)
			{
				return \u0013\u000E\u0018.\u0018(this.\u000C, \u0009\u001E\u000F.\u0018(\u000C));
			}

			// Token: 0x04000959 RID: 2393
			public List<long> \u000C;
		}

		// Token: 0x0200020E RID: 526
		[CompilerGenerated]
		private sealed class \u0002\u0015\u0018
		{
			// Token: 0x060012EF RID: 4847 RVA: 0x000611E8 File Offset: 0x0005F3E8
			internal void \u0014()
			{
				\u0015\u0014\u0003.\u0018(Enumerable.FirstOrDefault<DataGridColumn>(\u000C\u0003\u000F.\u0018(this.\u0018), new Func<DataGridColumn, bool>(this.\u0018.\u0003\u000A)), \u0002\u0001\u0016.\u0003(this.\u000C).\u000C());
				\u0014\u000B\u0016.\u0018(\u0011\u0010\u0016.\u0018(\u0017\u000B\u0016.\u0003(this.\u0018), new Predicate<ParameterInformation>(this.\u0018.\u0016\u000A)), \u0002\u0001\u0016.\u0003(this.\u000C));
			}

			// Token: 0x0400095A RID: 2394
			public ParameterChangeViewModel \u000C;

			// Token: 0x0400095B RID: 2395
			public SheetsViewModel \u0018;
		}

		// Token: 0x0200020F RID: 527
		[CompilerGenerated]
		private sealed class \u0004\u0015\u0018
		{
			// Token: 0x060012F1 RID: 4849 RVA: 0x00061280 File Offset: 0x0005F480
			internal bool \u0014(ParameterInformation \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001F\u0001\u0016.\u0018(\u000C), \u001B\u0014\u000F.\u0018(this.\u000C));
			}

			// Token: 0x060012F2 RID: 4850 RVA: 0x000612AC File Offset: 0x0005F4AC
			internal bool \u0003(ParameterInformation \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001F\u0001\u0016.\u0018(\u000C), \u001B\u0014\u000F.\u0018(this.\u000C));
			}

			// Token: 0x060012F3 RID: 4851 RVA: 0x000612D8 File Offset: 0x0005F4D8
			internal bool \u0016(DataGridColumn \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u0003\u0003\u000F.\u0018(\u000C), \u001F\u0001\u0016.\u0018(this.\u0018));
			}

			// Token: 0x0400095C RID: 2396
			public SheetsViewModel \u000C;

			// Token: 0x0400095D RID: 2397
			public ParameterInformation \u0018;
		}
	}
}

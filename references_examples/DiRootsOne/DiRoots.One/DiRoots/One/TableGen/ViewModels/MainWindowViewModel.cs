using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.Profiles;
using DiRoots.One.Commons.Services;
using DiRoots.One.Commons.UI.Progress;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.TableGen.Models;
using DiRoots.One.TableGen.Services;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.StyleMapping;
using DiRoots.One.TGRevitHelper.StyleMapping;
using DiRoots.One.UIBehaviours.Extensions;
using DiRoots.One.UIBehaviours.Models;
using Newtonsoft.Json;

namespace DiRoots.One.TableGen.ViewModels
{
	// Token: 0x02000150 RID: 336
	public class MainWindowViewModel : ViewModelBase
	{
		// Token: 0x06000C78 RID: 3192 RVA: 0x0004E5D8 File Offset: 0x0004C7D8
		public MainWindowViewModel()
		{
			\u000A\u0007\u0019.\u000A(this, this.INR(false));
			\u001F\u0007\u0019.\u000A(this, 0);
			List<IComboxItemModel> list = Enumerable.ToList<IComboxItemModel>(\u001D\u0016.\u0019());
			object u001F = list;
			int u000A = 0;
			EnumInfo enumInfo = new EnumInfo();
			\u0009\u001B\u001D.\u000A(enumInfo, -1);
			\u001E\u0014\u0004.\u000A(enumInfo, \u0009\u000A\u0019.\u000A());
			\u0001\u001B\u001D.\u000A(enumInfo, "Source");
			\u000B\u001F\u0019.\u000A(enumInfo, true);
			\u000C\u000A\u0019.\u000A(u001F, u000A, enumInfo);
			this.SourceTypeViewModel = new ComboBoxViewModel(list);
			\u0013\u000A\u0019.\u000A(\u0001\u000A\u0019.\u000A(this), new ComboBoxViewModel.OnDropDownClosedEventHandler(this.DMR));
			List<IComboxItemModel> list2 = Enumerable.ToList<IComboxItemModel>(\u001D\u0016.\u0004());
			object u001F2 = list2;
			int u000A2 = 0;
			EnumInfo enumInfo2 = new EnumInfo();
			\u0009\u001B\u001D.\u000A(enumInfo2, -1);
			\u001E\u0014\u0004.\u000A(enumInfo2, \u0015\u000A\u0019.\u000A());
			\u0001\u001B\u001D.\u000A(enumInfo2, "Import");
			\u000B\u001F\u0019.\u000A(enumInfo2, true);
			\u000C\u000A\u0019.\u000A(u001F2, u000A2, enumInfo2);
			this.ImportTypeViewModel = new ComboBoxViewModel(list2);
			\u0013\u000A\u0019.\u000A(\u001A\u000A\u0019.\u000A(this), new ComboBoxViewModel.OnDropDownClosedEventHandler(this.DMR));
			this.ChangeBlackWhiteCmd = new CommandBase<SelectedExcel>(new Action<SelectedExcel>(this.HMR), null);
			this.BrowseClickedCmd = new CommandBase(new Action(this.QNR), \u0002\u0015\u0010.\u001F);
			this.XS = new \u001E\u000B();
			this.ZS = new WorksheetSelectionWindowService(new ProgressWindowService(), new FileInfoExtractionService(), new FileInfoViewModelFactory(), new \u001E\u000B(), new Func<Window>(this.SMR));
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000C79 RID: 3193 RVA: 0x0004E758 File Offset: 0x0004C958
		// (set) Token: 0x06000C7A RID: 3194 RVA: 0x0004E76C File Offset: 0x0004C96C
		public List<SelectedExcel> Items
		{
			get
			{
				return this.LC;
			}
			set
			{
				this.LC = value;
				\u000D\u0020\u000A.\u000A(this, "Items");
			}
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000C7B RID: 3195 RVA: 0x0004E78C File Offset: 0x0004C98C
		// (set) Token: 0x06000C7C RID: 3196 RVA: 0x0004E7A0 File Offset: 0x0004C9A0
		public string SearchText
		{
			get
			{
				return this.MC;
			}
			set
			{
				base.SetProperty<string>(ref this.MC, value, new Action(this.HKR), "SearchText");
			}
		}

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000C7D RID: 3197 RVA: 0x0004E7D0 File Offset: 0x0004C9D0
		// (set) Token: 0x06000C7E RID: 3198 RVA: 0x0004E7E4 File Offset: 0x0004C9E4
		public List<BatchAction> BactchActions
		{
			get
			{
				return this.TS;
			}
			private set
			{
				base.SetProperty<List<BatchAction>>(ref this.TS, value, null, "BactchActions");
			}
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000C7F RID: 3199 RVA: 0x0004E808 File Offset: 0x0004CA08
		// (set) Token: 0x06000C80 RID: 3200 RVA: 0x0004E81C File Offset: 0x0004CA1C
		public int SelectedBatchActionIndex
		{
			get
			{
				return this.IS;
			}
			set
			{
				base.SetProperty<int>(ref this.IS, value, null, "SelectedBatchActionIndex");
			}
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000C81 RID: 3201 RVA: 0x0004E840 File Offset: 0x0004CA40
		public ComboBoxViewModel SourceTypeViewModel { get; }

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000C82 RID: 3202 RVA: 0x0004E854 File Offset: 0x0004CA54
		public ComboBoxViewModel ImportTypeViewModel { get; }

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000C83 RID: 3203 RVA: 0x0004E868 File Offset: 0x0004CA68
		public ICommand BrowseClickedCmd { get; }

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000C84 RID: 3204 RVA: 0x0004E87C File Offset: 0x0004CA7C
		public ICommand ChangeBlackWhiteCmd { get; }

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000C85 RID: 3205 RVA: 0x0004E890 File Offset: 0x0004CA90
		public ExcelStylesAggregator StyleCache
		{
			get
			{
				return this.PS;
			}
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000C86 RID: 3206 RVA: 0x0004E8A4 File Offset: 0x0004CAA4
		public StyleMappingDto DefaultProfile
		{
			get
			{
				return this.OS;
			}
		}

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000C87 RID: 3207 RVA: 0x0004E8B8 File Offset: 0x0004CAB8
		// (set) Token: 0x06000C88 RID: 3208 RVA: 0x0004E8CC File Offset: 0x0004CACC
		public Func<StyleMappingDto> MappingSettingsGetter { get; set; }

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000C89 RID: 3209 RVA: 0x0004E8E0 File Offset: 0x0004CAE0
		// (set) Token: 0x06000C8A RID: 3210 RVA: 0x0004E8F4 File Offset: 0x0004CAF4
		public Func<Profile> ActiveProfileGetter { get; set; }

		// Token: 0x06000C8B RID: 3211 RVA: 0x0004E908 File Offset: 0x0004CB08
		public void Init()
		{
			\u0005\u0008\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001C\u001B\u0004.\u000A()), new Predicate<object>(this.SearchTextFilter));
			\u0007\u0007\u0019.\u000A(this, \u001C\u001B\u0004.\u000A());
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x0004E944 File Offset: 0x0004CB44
		public void RefreshBatchActions(bool isDataOnly)
		{
			\u000A\u0007\u0019.\u000A(this, this.INR(isDataOnly));
			\u001F\u0007\u0019.\u000A(this, 0);
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x0004E968 File Offset: 0x0004CB68
		private List<BatchAction> INR(bool F)
		{
			string u001F = "/DiRoots.One;component/TableGen/TableGen/Resources/Images/";
			List<BatchAction> list = \u0020\u0007\u0019.\u000A();
			BatchAction batchAction = \u0002\u0007\u0019.\u000A();
			\u0016\u0007\u0019.\u000A(batchAction, \u001E\u0007\u0019.\u000A());
			\u0005\u0007\u0019.\u000A(batchAction, 0);
			\u0011\u0007\u0019.\u000A(batchAction, true);
			\u0006\u0007\u0019.\u000A(list, batchAction);
			BatchAction batchAction2 = \u0002\u0007\u0019.\u000A();
			string u000A;
			if (!F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.INR(bool)).MethodHandle;
				}
				u000A = \u001B\u0007\u0019.\u000A();
			}
			else
			{
				u000A = \u0008\u0007\u0019.\u000A();
			}
			\u0016\u0007\u0019.\u000A(batchAction2, u000A);
			\u0005\u0007\u0019.\u000A(batchAction2, 16);
			\u0004\u0007\u0019.\u000A(batchAction2, \u0019\u0007\u0019.\u000A(\u0008\u000C\u000A.\u000A(\u0004\u001E\u000A.\u000A(u001F, "updatetable.png"), UriKind.Relative)));
			\u0018\u0007\u0019.\u000A(batchAction2, 1.0);
			\u0006\u0007\u0019.\u000A(list, batchAction2);
			BatchAction batchAction3 = \u0002\u0007\u0019.\u000A();
			\u0016\u0007\u0019.\u000A(batchAction3, \u000E\u0007\u0019.\u000A());
			\u0005\u0007\u0019.\u000A(batchAction3, 16);
			\u0018\u0007\u0019.\u000A(batchAction3, 0.7);
			\u0004\u0007\u0019.\u000A(batchAction3, \u0019\u0007\u0019.\u000A(\u0008\u000C\u000A.\u000A(\u0004\u001E\u000A.\u000A(u001F, "duplicate.png"), UriKind.Relative)));
			\u0006\u0007\u0019.\u000A(list, batchAction3);
			BatchAction batchAction4 = \u0002\u0007\u0019.\u000A();
			\u0016\u0007\u0019.\u000A(batchAction4, \u0010\u0007\u0019.\u000A());
			\u0005\u0007\u0019.\u000A(batchAction4, 16);
			\u0018\u0007\u0019.\u000A(batchAction4, 1.0);
			\u0004\u0007\u0019.\u000A(batchAction4, \u0019\u0007\u0019.\u000A(\u0008\u000C\u000A.\u000A(\u0004\u001E\u000A.\u000A(u001F, "switch.png"), UriKind.Relative)));
			\u0006\u0007\u0019.\u000A(list, batchAction4);
			BatchAction batchAction5 = \u0002\u0007\u0019.\u000A();
			\u0016\u0007\u0019.\u000A(batchAction5, \u000D\u0007\u0019.\u000A());
			\u0005\u0007\u0019.\u000A(batchAction5, 16);
			\u0018\u0007\u0019.\u000A(batchAction5, 0.7);
			\u0004\u0007\u0019.\u000A(batchAction5, \u0019\u0007\u0019.\u000A(\u0008\u000C\u000A.\u000A(\u0004\u001E\u000A.\u000A(u001F, "changefolder.png"), UriKind.Relative)));
			\u0006\u0007\u0019.\u000A(list, batchAction5);
			BatchAction batchAction6 = \u0002\u0007\u0019.\u000A();
			\u0016\u0007\u0019.\u000A(batchAction6, \u001C\u0007\u0019.\u000A());
			\u0005\u0007\u0019.\u000A(batchAction6, 16);
			\u0018\u0007\u0019.\u000A(batchAction6, 1.0);
			\u0004\u0007\u0019.\u000A(batchAction6, \u0019\u0007\u0019.\u000A(\u0008\u000C\u000A.\u000A(\u0004\u001E\u000A.\u000A(u001F, "openfile.png"), UriKind.Relative)));
			\u0006\u0007\u0019.\u000A(list, batchAction6);
			BatchAction batchAction7 = \u0002\u0007\u0019.\u000A();
			\u0016\u0007\u0019.\u000A(batchAction7, \u0003\u0007\u0019.\u000A());
			\u0005\u0007\u0019.\u000A(batchAction7, 16);
			\u0018\u0007\u0019.\u000A(batchAction7, 1.0);
			\u0004\u0007\u0019.\u000A(batchAction7, \u0019\u0007\u0019.\u000A(\u0008\u000C\u000A.\u000A(\u0004\u001E\u000A.\u000A(u001F, "openfolder.png"), UriKind.Relative)));
			\u0006\u0007\u0019.\u000A(list, batchAction7);
			BatchAction batchAction8 = \u0002\u0007\u0019.\u000A();
			\u0016\u0007\u0019.\u000A(batchAction8, \u0012\u0007\u0019.\u000A());
			\u0005\u0007\u0019.\u000A(batchAction8, 16);
			\u0018\u0007\u0019.\u000A(batchAction8, 1.0);
			\u0004\u0007\u0019.\u000A(batchAction8, \u0019\u0007\u0019.\u000A(\u0008\u000C\u000A.\u000A(\u0004\u001E\u000A.\u000A(u001F, "deletetable.png"), UriKind.Relative)));
			\u0006\u0007\u0019.\u000A(list, batchAction8);
			BatchAction batchAction9 = \u0002\u0007\u0019.\u000A();
			\u0016\u0007\u0019.\u000A(batchAction9, \u000F\u0007\u0019.\u000A());
			\u0005\u0007\u0019.\u000A(batchAction9, 16);
			\u0018\u0007\u0019.\u000A(batchAction9, 1.0);
			\u0004\u0007\u0019.\u000A(batchAction9, \u0019\u0007\u0019.\u000A(\u0008\u000C\u000A.\u000A(\u0004\u001E\u000A.\u000A(u001F, "unlink.png"), UriKind.Relative)));
			\u0006\u0007\u0019.\u000A(list, batchAction9);
			List<BatchAction> list2 = list;
			if (F)
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
				object u001F2 = list2;
				int u000A2 = 2;
				BatchAction batchAction10 = \u0002\u0007\u0019.\u000A();
				\u0016\u0007\u0019.\u000A(batchAction10, \u000B\u0007\u0019.\u000A());
				\u0005\u0007\u0019.\u000A(batchAction10, 16);
				\u0018\u0007\u0019.\u000A(batchAction10, 1.0);
				\u0004\u0007\u0019.\u000A(batchAction10, \u0019\u0007\u0019.\u000A(\u0008\u000C\u000A.\u000A(\u0004\u001E\u000A.\u000A(u001F, "Status/pen.png"), UriKind.Relative)));
				\u001D\u0007\u0019.\u000A(u001F2, u000A2, batchAction10);
			}
			return list2;
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x0004ECC4 File Offset: 0x0004CEC4
		public void ReloadItemsFrom(List<SelectedExcel> selectedExcels)
		{
			try
			{
				SelectedExcel u001F = \u0013\u0005\u0004.\u000A(selectedExcels, 0);
				EnumInfo u001F2 = \u0002\u0003\u0004.\u0007(u001F);
				string u000A = string.Empty;
				string u001F3 = \u0011\u0020\u001D.\u0007(u001F);
				if (!\u0010\u0010\u001D.\u000A(u001F3))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.ReloadItemsFrom(List<SelectedExcel>)).MethodHandle;
					}
					if (\u0010\u0002\u001D.\u000A(u001F3))
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
						string text = \u0019\u000E\u0004.\u000A(u001F3);
						if (!\u0010\u0010\u001D.\u000A(text))
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
							if (\u000C\u0010\u0004.\u000A(text))
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
								u000A = text;
							}
						}
					}
				}
				string u000A2 = FilePathHelper.\u001F(u001F2, u000A);
				List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(selectedExcels);
				try
				{
					while (\u0001\u0005\u0004.\u000A(ref enumerator))
					{
						\u0014\u0011\u0004.\u001D(\u001F\u0016\u0004.\u000A(ref enumerator), u000A2);
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
			catch (Exception u001F4)
			{
				\u000A\u0016.\u001F(u001F4);
			}
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x0004EDC8 File Offset: 0x0004CFC8
		public bool SearchTextFilter(object o)
		{
			SelectedExcel u001F = \u0011\u0018\u000E.\u001F(o);
			IEnumerable<IComboxItemModel> enumerable = Enumerable.Skip<IComboxItemModel>(\u0005\u000A\u0019.\u001D(\u0001\u000A\u0019.\u000A(this)), 1);
			Func<IComboxItemModel, bool> func;
			if ((func = MainWindowViewModel.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.SearchTextFilter(object)).MethodHandle;
				}
				func = (MainWindowViewModel.<>c.\u000A = new Func<IComboxItemModel, bool>(MainWindowViewModel.<>c.\u001F.\u0018));
			}
			List<IComboxItemModel> u001F2 = Enumerable.ToList<IComboxItemModel>(Enumerable.Where<IComboxItemModel>(enumerable, func));
			IEnumerable<IComboxItemModel> enumerable2 = Enumerable.Skip<IComboxItemModel>(\u0005\u000A\u0019.\u001D(\u001A\u000A\u0019.\u000A(this)), 1);
			Func<IComboxItemModel, bool> func2;
			if ((func2 = MainWindowViewModel.<>c.\u0007) == null)
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
				func2 = (MainWindowViewModel.<>c.\u0007 = new Func<IComboxItemModel, bool>(MainWindowViewModel.<>c.\u001F.\u0005));
			}
			List<IComboxItemModel> u001F3 = Enumerable.ToList<IComboxItemModel>(Enumerable.Where<IComboxItemModel>(enumerable2, func2));
			bool flag;
			if (\u0013\u0007\u0019.\u000A(u001F2) > 0)
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
				flag = (\u0013\u0007\u0019.\u000A(u001F3) > 0);
			}
			else
			{
				flag = false;
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
				if (\u0014\u0007\u0019.\u000A(u001F2, \u0002\u0003\u0004.\u0007(u001F)))
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
					if (\u0014\u0007\u0019.\u000A(u001F3, \u0015\u0016\u0004.\u0007(u001F)))
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
						if (!\u001A\u0006\u0007.\u000A(\u0017\u0007\u0019.\u000A(this)))
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
							return \u000D\u0008\u000A.\u001F(\u0014\u0005\u0004.\u0007(u001F), \u0017\u0007\u0019.\u000A(this));
						}
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000C90 RID: 3216 RVA: 0x0004EF28 File Offset: 0x0004D128
		internal void HKR()
		{
			try
			{
				if (\u001A\u0007\u0019.\u000A(this) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.HKR()).MethodHandle;
					}
				}
				else
				{
					\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001A\u0007\u0019.\u000A(this)));
				}
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\ViewModels\\MainWindowViewModel.cs", "Refresh");
			}
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x0004EF94 File Offset: 0x0004D194
		[BindableMethod("DropOnGrid")]
		public void DropOnGrid(DragEventArgs e)
		{
			if (!\u000B\u0001\u0007.\u000A(\u0002\u0001\u0007.\u000A(e), DataFormats.FileDrop))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.DropOnGrid(DragEventArgs)).MethodHandle;
				}
				return;
			}
			List<string> f = Enumerable.ToList<string>(\u001B\u0018\u000E.\u001F(\u000C\u0007\u0019.\u000A(\u0002\u0001\u0007.\u000A(e), DataFormats.FileDrop)));
			this.ANR(f);
		}

		// Token: 0x06000C92 RID: 3218 RVA: 0x0004EFF8 File Offset: 0x0004D1F8
		private void QNR()
		{
			List<string> list = Enumerable.ToList<string>(FilePathHelper.\u0007());
			if (\u0015\u0007\u0019.\u000A(list) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.QNR()).MethodHandle;
				}
				this.ANR(list);
			}
		}

		// Token: 0x06000C93 RID: 3219 RVA: 0x0004F03C File Offset: 0x0004D23C
		private void ANR(List<string> F)
		{
			if (this.HB)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.ANR(List<string>)).MethodHandle;
				}
				return;
			}
			this.HB = true;
			try
			{
				bool? flag = \u001F\u001D\u0019.\u000A(this.ZS, F);
				if (\u0012\u0015\u000A.\u000A(ref flag))
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
					List<SelectedExcel> list = \u0009\u0007\u0019.\u000A(this.ZS);
					if (\u000C\u001B\u0004.\u000A(list) > 0)
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
						\u0001\u0007\u0019.\u000A(\u001C\u001B\u0004.\u000A(), list);
						this.HKR();
					}
				}
			}
			finally
			{
				this.HB = false;
			}
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x0004F0E0 File Offset: 0x0004D2E0
		private static List<SheetAndNamedRange> GNR(string F)
		{
			IEnumerable<KeyValuePair<string, List<NamedRangeInfo>>> enumerable = \u0013\u0019.\u001F(F);
			Func<KeyValuePair<string, List<NamedRangeInfo>>, WorkSheetNamedRegion> func;
			if ((func = MainWindowViewModel.<>c.\u001D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.GNR(string)).MethodHandle;
				}
				func = (MainWindowViewModel.<>c.\u001D = new Func<KeyValuePair<string, List<NamedRangeInfo>>, WorkSheetNamedRegion>(MainWindowViewModel.<>c.\u001F.\u0016));
			}
			object u001F = Enumerable.ToList<WorkSheetNamedRegion>(Enumerable.Select<KeyValuePair<string, List<NamedRangeInfo>>, WorkSheetNamedRegion>(enumerable, func));
			List<SheetAndNamedRange> list = \u001B\u0009\u0004.\u000A();
			List<WorkSheetNamedRegion>.Enumerator enumerator = \u001A\u0009\u0004.\u000A(u001F);
			try
			{
				while (\u0014\u0009\u0004.\u000A(ref enumerator))
				{
					WorkSheetNamedRegion u001F2 = \u0013\u0009\u0004.\u000A(ref enumerator);
					SheetAndNamedRange sheetAndNamedRange = \u0018\u0008\u0004.\u000A();
					\u0019\u0008\u0004.\u000A(sheetAndNamedRange, \u0017\u0009\u0004.\u000A(u001F2));
					\u001D\u0008\u0004.\u000A(sheetAndNamedRange, \u001F\u0009\u0004.\u001D(u001F2));
					SheetAndNamedRange u000A = sheetAndNamedRange;
					\u0008\u0009\u0004.\u000A(list, u000A);
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
			return list;
		}

		// Token: 0x06000C95 RID: 3221 RVA: 0x0004F1B4 File Offset: 0x0004D3B4
		public void UpdateFolderPath(List<SelectedExcel> selectedExcels, ICustomLogger logger)
		{
			MainWindowViewModel.\u0015\u0016 u0015_u = new MainWindowViewModel.\u0015\u0016();
			u0015_u.\u001F = this;
			u0015_u.\u000A = selectedExcels;
			u0015_u.\u0007 = logger;
			try
			{
				string u000A = \u0019\u000E\u0004.\u000A(\u0011\u0020\u001D.\u0007(\u0013\u0005\u0004.\u000A(u0015_u.\u000A, 0)));
				MainWindowViewModel.\u0015\u0016 u0015_u2 = u0015_u;
				FolderDiaglogOptions u001F = \u0016\u001D\u0019.\u000A();
				\u0005\u001D\u0019.\u000A(u001F, \u0018\u000B\u0007.\u0007(this));
				\u0018\u001D\u0019.\u000A(u001F, u000A);
				u0015_u2.\u001D = \u0019\u001D\u0019.\u000A(u001F, u0015_u.\u0007);
				if (\u001A\u0006\u0007.\u000A(u0015_u.\u001D))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.UpdateFolderPath(List<SelectedExcel>, ICustomLogger)).MethodHandle;
					}
				}
				else
				{
					MainWindowViewModel.\u0015\u0016 u0015_u3 = u0015_u;
					ProgressWindowService progressWindowService = \u0002\u0008\u001D.\u000A();
					\u000B\u0008\u001D.\u000A(progressWindowService, \u0018\u000B\u0007.\u0007(this));
					u0015_u3.\u0004 = progressWindowService;
					ProgressWindowService u = u0015_u.\u0004;
					\u001D\u001D\u0019.\u000A(u, \u001A\u001D\u000E.\u001F(\u000F\u001E\u000A.\u000A(\u0004\u001D\u0019.\u0007(u), new ContentRenderedDelegate(u0015_u.\u0019))));
					\u000A\u001D\u0019.\u000A(u0015_u.\u0004, \u0007\u001D\u0019.\u000A(), \u000C\u001B\u0004.\u000A(u0015_u.\u000A));
				}
			}
			catch (Exception ex)
			{
				\u000F\u000E\u001D.\u000A(u0015_u.\u0007, ex, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\ViewModels\\MainWindowViewModel.cs", "UpdateFolderPath");
				\u001D\u0012\u001D.\u000A(ex, \u0004\u0001\u001D.\u000A());
			}
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x0004F2F0 File Offset: 0x0004D4F0
		private void FMR(List<SelectedExcel> F, string R, ProgressWindowService D, ICustomLogger H)
		{
			List<ReportInfo> list = \u0010\u001D\u0019.\u000A();
			int num = 1;
			int num2 = \u000C\u001B\u0004.\u000A(F);
			List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(F);
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					SelectedExcel selectedExcel = \u001F\u0016\u0004.\u000A(ref enumerator);
					string text = string.Empty;
					try
					{
						if (\u0004\u0013\u001D.\u0007(\u000D\u001D\u0019.\u0007(D)))
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.FMR(List<SelectedExcel>, string, ProgressWindowService, ICustomLogger)).MethodHandle;
							}
							\u001C\u001D\u0019.\u000A(list);
							goto IL_1A9;
						}
						bool flag = true;
						if (\u0008\u0013\u000A.\u000A(\u0019\u000E\u0004.\u000A(\u0011\u0020\u001D.\u0007(selectedExcel)), R))
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
							flag = false;
						}
						text = \u001B\u0015\u001D.\u000A(R, \u000F\u000B\u001D.\u000A(\u0011\u0020\u001D.\u0007(selectedExcel)));
						if (!\u0010\u0002\u001D.\u000A(text))
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
							\u0006\u001D\u0019.\u000A(list, \u000F\u001D\u0019.\u000A(selectedExcel, \u0003\u001D\u0019.\u000A(), text));
							flag = false;
						}
						if (flag)
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
							if (\u000C\u0008\u0004.\u000A(\u0002\u0003\u0004.\u0007(selectedExcel), SourceTypes.Excel))
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
								MainWindowViewModel.RMR(selectedExcel, text, list);
							}
							else
							{
								\u000C\u0011\u0004.\u001D(selectedExcel, text);
							}
						}
						\u0013\u0011\u0004.\u001D(selectedExcel);
						\u0012\u001D\u0019.\u0007(D, num, \u001E\u0007\u0007.\u000A("[{0}/{1}] {2}", num, num2, \u000F\u000B\u001D.\u000A(text)));
						num++;
					}
					catch (Exception ex)
					{
						\u000F\u000E\u001D.\u000A(H, ex, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\ViewModels\\MainWindowViewModel.cs", "UpdateFolderPath");
						\u0006\u001D\u0019.\u000A(list, \u000F\u001D\u0019.\u000A(selectedExcel, \u0003\u001A\u000A.\u000A(ex), text));
					}
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			IL_1A9:
			this.HKR();
			\u0002\u001D\u0019.\u0007(D);
			\u000B\u001D\u0019.\u000A(this.XS, list, \u001E\u0011\u000A.\u000A(\u0008\u0018\u000E.\u001F()), \u0018\u000B\u0007.\u0007(this));
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x0004F508 File Offset: 0x0004D708
		private static void RMR(SelectedExcel F, string R, List<ReportInfo> D)
		{
			MainWindowViewModel.\u0001\u0016 u0001_u = new MainWindowViewModel.\u0001\u0016();
			u0001_u.\u001F = \u0020\u0020\u001D.\u0007(F);
			NamedRangeInfo namedRangeInfo = \u0014\u0020\u001D.\u0007(F);
			MainWindowViewModel.\u0001\u0016 u0001_u2 = u0001_u;
			string text;
			if (namedRangeInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.RMR(SelectedExcel, string, List<ReportInfo>)).MethodHandle;
				}
				text = null;
			}
			else
			{
				text = \u0017\u0020\u001D.\u001D(namedRangeInfo);
			}
			string u000A;
			if ((u000A = text) == null)
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
				u000A = string.Empty;
			}
			u0001_u2.\u000A = u000A;
			\u001E\u001B\u0004.\u001D(F, MainWindowViewModel.GNR(R));
			\u000C\u0011\u0004.\u001D(F, R);
			List<string> list = \u0014\u000D\u0007.\u000A();
			\u001B\u001B\u0004.\u001D(F, Enumerable.FirstOrDefault<string>(\u0011\u001B\u0004.\u001D(F), new Func<string, bool>(u0001_u.\u0007)));
			if (\u0020\u0020\u001D.\u0007(F) == null)
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
				\u001B\u001B\u0004.\u001D(F, Enumerable.FirstOrDefault<string>(\u0011\u001B\u0004.\u001D(F)));
				\u001A\u0008\u0007.\u000A(list, \u0017\u0006\u0007.\u000A(\u001B\u001D\u0019.\u000A(), u0001_u.\u001F));
			}
			\u001F\u001B\u0004.\u001D(F, Enumerable.FirstOrDefault<NamedRangeInfo>(\u000A\u001B\u0004.\u001D(F), new Func<NamedRangeInfo, bool>(u0001_u.\u001D)));
			if (\u0014\u0020\u001D.\u0007(F) == null)
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
				\u001F\u001B\u0004.\u001D(F, NamedRangeInfo.\u000A(\u000A\u001B\u0004.\u001D(F)));
				if (!\u001A\u0006\u0007.\u000A(u0001_u.\u000A))
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
					\u001A\u0008\u0007.\u000A(list, \u0017\u0006\u0007.\u000A(\u0008\u001D\u0019.\u000A(), u0001_u.\u000A));
				}
			}
			if (Enumerable.Any<string>(list))
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
				\u0006\u001D\u0019.\u000A(D, \u000F\u001D\u0019.\u000A(F, \u000E\u001D\u0019.\u000A(\u0009\u000B\u001D.\u000A(), list), R));
			}
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x0004F69C File Offset: 0x0004D89C
		private void DMR()
		{
			this.HKR();
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x0004F6B0 File Offset: 0x0004D8B0
		private void HMR(SelectedExcel F)
		{
			if (F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.HMR(SelectedExcel)).MethodHandle;
				}
				return;
			}
			\u0012\u0008\u0004.\u001D(F);
			IEnumerable<SelectedExcel> enumerable = \u001C\u001B\u0004.\u000A();
			Func<SelectedExcel, bool> func;
			if ((func = MainWindowViewModel.<>c.\u0004) == null)
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
				func = (MainWindowViewModel.<>c.\u0004 = new Func<SelectedExcel, bool>(MainWindowViewModel.<>c.\u001F.\u000B));
			}
			object u001F = Enumerable.ToList<SelectedExcel>(Enumerable.Where<SelectedExcel>(enumerable, func));
			bool u000A = \u001F\u000B\u0004.\u0007(\u000A\u000B\u0004.\u0007(F));
			List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(u001F);
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					SelectedExcel u001F2 = \u001F\u0016\u0004.\u000A(ref enumerator);
					if (\u000C\u0008\u0004.\u000A(\u0015\u0016\u0004.\u0007(u001F2), ImportTypes.Table))
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
						\u001A\u0008\u0004.\u000A(\u000A\u000B\u0004.\u0007(u001F2), u000A);
					}
					\u0012\u0008\u0004.\u001D(u001F2);
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

		// Token: 0x06000C9A RID: 3226 RVA: 0x0004F7A8 File Offset: 0x0004D9A8
		public void ResyncStyleCache(BlackAndWhiteTextLinesOption? bwOverride = null)
		{
			try
			{
				BlackAndWhiteTextLinesOption? blackAndWhiteTextLinesOption = bwOverride;
				BlackAndWhiteTextLinesOption blackAndWhiteTextLinesOption2;
				if (!\u0020\u001D\u0019.\u000A(ref blackAndWhiteTextLinesOption))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.ResyncStyleCache(BlackAndWhiteTextLinesOption?)).MethodHandle;
					}
					blackAndWhiteTextLinesOption2 = this.LMR();
				}
				else
				{
					blackAndWhiteTextLinesOption2 = \u001E\u001D\u0019.\u000A(ref blackAndWhiteTextLinesOption);
				}
				BlackAndWhiteTextLinesOption u = blackAndWhiteTextLinesOption2;
				\u0011\u001D\u0019.\u000A(this.PS, \u001C\u001B\u0004.\u000A(), u);
				this.CMR();
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\ViewModels\\MainWindowViewModel.cs", "ResyncStyleCache");
			}
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x0004F830 File Offset: 0x0004DA30
		public void RunStyleExtraction(IEnumerable<SelectedExcel> excels, bool forceReload, Action postExtract = null, BlackAndWhiteTextLinesOption? bwOverride = null)
		{
			MainWindowViewModel.\u0009\u0016 u0009_u = new MainWindowViewModel.\u0009\u0016();
			u0009_u.\u001F = this;
			u0009_u.\u0007 = forceReload;
			u0009_u.\u0019 = postExtract;
			MainWindowViewModel.\u0009\u0016 u0009_u2 = u0009_u;
			BlackAndWhiteTextLinesOption? blackAndWhiteTextLinesOption = bwOverride;
			BlackAndWhiteTextLinesOption u;
			if (!\u0020\u001D\u0019.\u000A(ref blackAndWhiteTextLinesOption))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.RunStyleExtraction(IEnumerable<SelectedExcel>, bool, Action, BlackAndWhiteTextLinesOption?)).MethodHandle;
				}
				u = this.LMR();
			}
			else
			{
				u = \u001E\u001D\u0019.\u000A(ref blackAndWhiteTextLinesOption);
			}
			u0009_u2.\u0004 = u;
			MainWindowViewModel.\u0009\u0016 u0009_u3 = u0009_u;
			List<SelectedExcel> u001D;
			if (excels != null)
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
				Func<SelectedExcel, bool> func;
				if ((func = MainWindowViewModel.<>c.\u0019) == null)
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
					func = (MainWindowViewModel.<>c.\u0019 = new Func<SelectedExcel, bool>(MainWindowViewModel.<>c.\u001F.\u0002));
				}
				u001D = Enumerable.ToList<SelectedExcel>(Enumerable.Where<SelectedExcel>(excels, func));
			}
			else
			{
				u001D = \u0003\u000B\u0004.\u000A();
			}
			u0009_u3.\u001D = u001D;
			int num;
			if (!u0009_u.\u0007)
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
				num = \u0013\u001D\u0019.\u000A(this.PS, u0009_u.\u001D);
			}
			else
			{
				num = MainWindowViewModel.YMR(u0009_u.\u001D);
			}
			int num2 = num;
			if (num2 != 0)
			{
				MainWindowViewModel.\u0009\u0016 u0009_u4 = u0009_u;
				ProgressWindowService progressWindowService = \u0002\u0008\u001D.\u000A();
				\u000B\u0008\u001D.\u000A(progressWindowService, \u0018\u000B\u0007.\u0007(this));
				\u0014\u001D\u0019.\u000A(progressWindowService, new double?((double)500));
				u0009_u4.\u000A = progressWindowService;
				ProgressWindowService u000A = u0009_u.\u000A;
				\u001D\u001D\u0019.\u000A(u000A, \u001A\u001D\u000E.\u001F(\u000F\u001E\u000A.\u000A(\u0004\u001D\u0019.\u0007(u000A), new ContentRenderedDelegate(u0009_u.\u0016))));
				\u000A\u001D\u0019.\u000A(u0009_u.\u000A, \u0017\u001D\u0019.\u000A(), num2);
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
			\u0011\u001D\u0019.\u000A(this.PS, \u001C\u001B\u0004.\u000A(), u0009_u.\u0004);
			this.CMR();
			Action u2 = u0009_u.\u0019;
			if (u2 == null)
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
			\u001B\u0015\u0007.\u000A(u2);
		}

		// Token: 0x06000C9C RID: 3228 RVA: 0x0004F9D0 File Offset: 0x0004DBD0
		public void SyncMappingSettingsFromAggregator(Document doc)
		{
			Func<StyleMappingDto> func = \u001F\u0004\u0019.\u000A(this);
			StyleMappingDto styleMappingDto;
			if (func == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.SyncMappingSettingsFromAggregator(Document)).MethodHandle;
				}
				styleMappingDto = \u0001\u0004\u000E.\u001F;
			}
			else
			{
				styleMappingDto = \u0009\u001D\u0019.\u000A(func);
			}
			StyleMappingDto styleMappingDto2 = styleMappingDto;
			if (styleMappingDto2 == null)
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
				return;
			}
			StyleMappingDto u001F = styleMappingDto2;
			IReadOnlyCollection<ExcelLineStyleInfo> readOnlyCollection = \u0001\u001D\u0019.\u0007(this.PS);
			List<ExcelLineStyleInfo> list;
			if (readOnlyCollection == null)
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
				list = null;
			}
			else
			{
				list = Enumerable.ToList<ExcelLineStyleInfo>(readOnlyCollection);
			}
			List<ExcelLineStyleInfo> u000A;
			if ((u000A = list) == null)
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
				u000A = \u0015\u001D\u0019.\u000A();
			}
			IReadOnlyCollection<ExcelTextStyleInfo> readOnlyCollection2 = \u000C\u001D\u0019.\u0007(this.PS);
			List<ExcelTextStyleInfo> list2;
			if (readOnlyCollection2 == null)
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
				list2 = null;
			}
			else
			{
				list2 = Enumerable.ToList<ExcelTextStyleInfo>(readOnlyCollection2);
			}
			List<ExcelTextStyleInfo> u;
			if ((u = list2) == null)
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
				u = \u001A\u001D\u0019.\u000A();
			}
			\u0002\u0005.\u0006(u001F, u000A, u, doc);
		}

		// Token: 0x06000C9D RID: 3229 RVA: 0x0004FA94 File Offset: 0x0004DC94
		private static int YMR(IEnumerable<SelectedExcel> F)
		{
			if (F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.YMR(IEnumerable<SelectedExcel>)).MethodHandle;
				}
				return 0;
			}
			int num = 0;
			IEnumerator<SelectedExcel> enumerator = \u001E\u000F\u0004.\u000A(F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SelectedExcel selectedExcel = \u0011\u000F\u0004.\u000A(enumerator);
					bool flag;
					if (selectedExcel == null)
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
						flag = true;
					}
					else
					{
						EnumInfo enumInfo = \u0002\u0003\u0004.\u001D(selectedExcel);
						int? num3;
						if (enumInfo == null)
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
							int? num2;
							\u000B\u0007\u000E.\u001F(ref num2);
							num3 = num2;
						}
						else
						{
							num3 = new int?(\u000D\u001B\u001D.\u001D(enumInfo));
						}
						int? num4 = num3;
						int num5 = 0;
						flag = !(\u0009\u001F\u001D.\u000A(ref num4) == num5 & \u000A\u000A\u001D.\u000A(ref num4));
					}
					if (!flag)
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
						EnumInfo enumInfo2 = \u0015\u0016\u0004.\u0007(selectedExcel);
						bool flag2;
						if (enumInfo2 == null)
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
							flag2 = true;
						}
						else
						{
							flag2 = (\u000D\u001B\u001D.\u001D(enumInfo2) != 0);
						}
						if (!flag2)
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
							if (!\u001A\u0006\u0007.\u000A(\u0011\u0020\u001D.\u0007(selectedExcel)))
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
								if (\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u0007(selectedExcel)))
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
									num++;
								}
							}
						}
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return num;
		}

		// Token: 0x06000C9E RID: 3230 RVA: 0x0004FBE4 File Offset: 0x0004DDE4
		private void CMR()
		{
			Document u = \u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>());
			this.OS = \u0002\u0005.\u000B(\u0001\u001D\u0019.\u0007(this.PS), \u000C\u001D\u0019.\u0007(this.PS), u);
		}

		// Token: 0x06000C9F RID: 3231 RVA: 0x0004FC28 File Offset: 0x0004DE28
		public StyleMappingDto CloneDefaultProfile()
		{
			if (this.OS == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.CloneDefaultProfile()).MethodHandle;
				}
				return \u001F\u000D\u0004.\u000A();
			}
			StyleMappingDto result;
			try
			{
				StyleMappingDto styleMappingDto;
				if ((styleMappingDto = JsonConvert.DeserializeObject<StyleMappingDto>(\u000E\u000D\u0004.\u000A(this.OS, Formatting.None))) == null)
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
					styleMappingDto = \u001F\u000D\u0004.\u000A();
				}
				result = styleMappingDto;
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\ViewModels\\MainWindowViewModel.cs", "CloneDefaultProfile");
				result = \u001F\u000D\u0004.\u000A();
			}
			return result;
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x0004FCBC File Offset: 0x0004DEBC
		private BlackAndWhiteTextLinesOption LMR()
		{
			Func<StyleMappingDto> func = \u001F\u0004\u0019.\u000A(this);
			BlackAndWhiteTextLinesOption? blackAndWhiteTextLinesOption;
			BlackAndWhiteTextLinesOption? blackAndWhiteTextLinesOption2;
			if (func == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.LMR()).MethodHandle;
				}
				\u000E\u0018\u000E.\u001F(ref blackAndWhiteTextLinesOption);
				blackAndWhiteTextLinesOption2 = blackAndWhiteTextLinesOption;
			}
			else
			{
				StyleMappingDto styleMappingDto = \u0009\u001D\u0019.\u000A(func);
				if (styleMappingDto == null)
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
					\u000E\u0018\u000E.\u001F(ref blackAndWhiteTextLinesOption);
					blackAndWhiteTextLinesOption2 = blackAndWhiteTextLinesOption;
				}
				else
				{
					GeneralMappingSetting generalMappingSetting = \u0009\u0004\u0004.\u001D(styleMappingDto);
					if (generalMappingSetting == null)
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
						\u000E\u0018\u000E.\u001F(ref blackAndWhiteTextLinesOption);
						blackAndWhiteTextLinesOption2 = blackAndWhiteTextLinesOption;
					}
					else
					{
						blackAndWhiteTextLinesOption2 = new BlackAndWhiteTextLinesOption?(\u0005\u0010\u0004.\u001D(generalMappingSetting));
					}
				}
			}
			blackAndWhiteTextLinesOption = blackAndWhiteTextLinesOption2;
			return \u001E\u001D\u0019.\u000A(ref blackAndWhiteTextLinesOption);
		}

		// Token: 0x06000CA1 RID: 3233 RVA: 0x0004FD48 File Offset: 0x0004DF48
		[CompilerGenerated]
		private Window SMR()
		{
			return \u0018\u000B\u0007.\u0007(this);
		}

		// Token: 0x040004EC RID: 1260
		private List<SelectedExcel> LC;

		// Token: 0x040004ED RID: 1261
		private string MC = string.Empty;

		// Token: 0x040004EE RID: 1262
		private readonly IWorksheetSelectionWindowService ZS;

		// Token: 0x040004EF RID: 1263
		private readonly IReportWindowService XS;

		// Token: 0x040004F0 RID: 1264
		private readonly ExcelStylesAggregator PS = new ExcelStylesAggregator();

		// Token: 0x040004F1 RID: 1265
		private StyleMappingDto OS = new StyleMappingDto();

		// Token: 0x040004F2 RID: 1266
		private List<BatchAction> TS;

		// Token: 0x040004F3 RID: 1267
		private int IS;

		// Token: 0x040004F4 RID: 1268
		[CompilerGenerated]
		private readonly ComboBoxViewModel QS;

		// Token: 0x040004F5 RID: 1269
		[CompilerGenerated]
		private readonly ComboBoxViewModel AS;

		// Token: 0x040004F6 RID: 1270
		[CompilerGenerated]
		private readonly ICommand GS;

		// Token: 0x040004F7 RID: 1271
		[CompilerGenerated]
		private readonly ICommand FB;

		// Token: 0x040004F8 RID: 1272
		[CompilerGenerated]
		private Func<StyleMappingDto> RB;

		// Token: 0x040004F9 RID: 1273
		[CompilerGenerated]
		private Func<Profile> DB;

		// Token: 0x040004FA RID: 1274
		private bool HB;

		// Token: 0x02000828 RID: 2088
		[CompilerGenerated]
		private sealed class \u0015\u0016
		{
			// Token: 0x06004DF0 RID: 19952 RVA: 0x001DF504 File Offset: 0x001DD704
			internal void \u0019()
			{
				this.\u001F.FMR(this.\u000A, this.\u001D, this.\u0004, this.\u0007);
			}

			// Token: 0x04002098 RID: 8344
			public MainWindowViewModel \u001F;

			// Token: 0x04002099 RID: 8345
			public List<SelectedExcel> \u000A;

			// Token: 0x0400209A RID: 8346
			public ICustomLogger \u0007;

			// Token: 0x0400209B RID: 8347
			public string \u001D;

			// Token: 0x0400209C RID: 8348
			public ProgressWindowService \u0004;
		}

		// Token: 0x02000829 RID: 2089
		[CompilerGenerated]
		private sealed class \u0001\u0016
		{
			// Token: 0x06004DF2 RID: 19954 RVA: 0x001DF548 File Offset: 0x001DD748
			internal bool \u0007(string \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001F, this.\u001F);
			}

			// Token: 0x06004DF3 RID: 19955 RVA: 0x001DF564 File Offset: 0x001DD764
			internal bool \u001D(NamedRangeInfo \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0017\u0020\u001D.\u0007(\u001F), this.\u000A);
			}

			// Token: 0x0400209D RID: 8349
			public string \u001F;

			// Token: 0x0400209E RID: 8350
			public string \u000A;
		}

		// Token: 0x0200082A RID: 2090
		[CompilerGenerated]
		private sealed class \u0009\u0016
		{
			// Token: 0x06004DF5 RID: 19957 RVA: 0x001DF59C File Offset: 0x001DD79C
			internal void \u0016()
			{
				Action u001F;
				if ((u001F = this.\u0005) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.\u0009\u0016.\u0016()).MethodHandle;
					}
					u001F = (this.\u0005 = new Action(this.\u000B));
				}
				\u000D\u000A\u0010.\u000A(u001F);
			}

			// Token: 0x06004DF6 RID: 19958 RVA: 0x001DF5E4 File Offset: 0x001DD7E4
			internal void \u000B()
			{
				if (this.\u0007)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.\u0009\u0016.\u000B()).MethodHandle;
					}
					\u000E\u000A\u0010.\u000A(this.\u001F.PS, this.\u001D, this.\u0004, new Action<ExtractionProgressInfo>(this.\u0002));
				}
				else
				{
					\u0010\u000A\u0010.\u000A(this.\u001F.PS, this.\u001D, this.\u0004, new Action<ExtractionProgressInfo>(this.\u0002));
				}
				object u001F = \u001C\u0015\u0007.\u001D(\u0018\u000B\u0007.\u0007(this.\u001F));
				Action u000A;
				if ((u000A = this.\u0018) == null)
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
					u000A = (this.\u0018 = new Action(this.\u0006));
				}
				\u000C\u0018\u0019.\u000A(u001F, u000A);
			}

			// Token: 0x06004DF7 RID: 19959 RVA: 0x001DF6A8 File Offset: 0x001DD8A8
			internal void \u0002(ExtractionProgressInfo \u001F)
			{
				MainWindowViewModel.\u001F\u000B u001F_u000B = new MainWindowViewModel.\u001F\u000B();
				u001F_u000B.\u0019 = this;
				u001F_u000B.\u0007 = \u0020\u000A\u0010.\u000A(ref \u001F);
				u001F_u000B.\u001D = \u001E\u000A\u0010.\u000A(ref \u001F);
				u001F_u000B.\u0004 = \u0011\u000A\u0010.\u000A(ref \u001F);
				u001F_u000B.\u001F = \u001B\u000A\u0010.\u000A(ref \u001F);
				u001F_u000B.\u000A = \u0008\u000A\u0010.\u000A(ref \u001F);
				\u000C\u0018\u0019.\u000A(\u001C\u0015\u0007.\u001D(\u0018\u000B\u0007.\u0007(this.\u001F)), new Action(u001F_u000B.\u0018));
			}

			// Token: 0x06004DF8 RID: 19960 RVA: 0x001DF734 File Offset: 0x001DD934
			internal void \u0006()
			{
				\u0011\u001D\u0019.\u000A(this.\u001F.PS, \u001C\u001B\u0004.\u000A(), this.\u0004);
				this.\u001F.CMR();
				\u0002\u001D\u0019.\u0007(this.\u000A);
				Action u = this.\u0019;
				if (u == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowViewModel.\u0009\u0016.\u0006()).MethodHandle;
					}
					return;
				}
				\u001B\u0015\u0007.\u000A(u);
			}

			// Token: 0x0400209F RID: 8351
			public MainWindowViewModel \u001F;

			// Token: 0x040020A0 RID: 8352
			public ProgressWindowService \u000A;

			// Token: 0x040020A1 RID: 8353
			public bool \u0007;

			// Token: 0x040020A2 RID: 8354
			public List<SelectedExcel> \u001D;

			// Token: 0x040020A3 RID: 8355
			public BlackAndWhiteTextLinesOption \u0004;

			// Token: 0x040020A4 RID: 8356
			public Action \u0019;

			// Token: 0x040020A5 RID: 8357
			public Action \u0018;

			// Token: 0x040020A6 RID: 8358
			public Action \u0005;
		}

		// Token: 0x0200082B RID: 2091
		[CompilerGenerated]
		private sealed class \u001F\u000B
		{
			// Token: 0x06004DFA RID: 19962 RVA: 0x001DF7AC File Offset: 0x001DD9AC
			internal void \u0018()
			{
				string u001F = "[{0}/{1}] {2} → {3} → {4}";
				object[] array = \u0004\u0015\u0010.\u001F(5);
				array[0] = this.\u001F;
				array[1] = this.\u000A;
				array[2] = this.\u0007;
				array[3] = this.\u001D;
				array[4] = this.\u0004;
				string u = \u001C\u0015\u001D.\u000A(u001F, array);
				\u0012\u001D\u0019.\u0007(this.\u0019.\u000A, this.\u001F, u);
			}

			// Token: 0x040020A7 RID: 8359
			public int \u001F;

			// Token: 0x040020A8 RID: 8360
			public int \u000A;

			// Token: 0x040020A9 RID: 8361
			public string \u0007;

			// Token: 0x040020AA RID: 8362
			public string \u001D;

			// Token: 0x040020AB RID: 8363
			public string \u0004;

			// Token: 0x040020AC RID: 8364
			public MainWindowViewModel.\u0009\u0016 \u0019;
		}
	}
}

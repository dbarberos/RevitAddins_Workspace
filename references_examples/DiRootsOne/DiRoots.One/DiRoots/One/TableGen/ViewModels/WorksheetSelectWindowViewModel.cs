using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.TableGen.TableGen.Models;
using DiRoots.One.TGDatabaseLayer;

namespace DiRoots.One.TableGen.ViewModels
{
	// Token: 0x02000152 RID: 338
	public class WorksheetSelectWindowViewModel : ViewModelBase
	{
		// Token: 0x06000CA4 RID: 3236 RVA: 0x0004FE10 File Offset: 0x0004E010
		public WorksheetSelectWindowViewModel()
		{
			List<SheetRegionViewModel> list = new List<SheetRegionViewModel>();
			SheetRegionViewModel sheetRegionViewModel = new SheetRegionViewModel();
			\u0005\u0004\u0019.\u000A(sheetRegionViewModel, "<Used Region>");
			\u0018\u0004\u0019.\u000A(list, sheetRegionViewModel);
			List<SheetRegionViewModel> list2 = list;
			List<SheetRegionViewModel> list3 = new List<SheetRegionViewModel>();
			SheetRegionViewModel sheetRegionViewModel2 = new SheetRegionViewModel();
			\u0005\u0004\u0019.\u000A(sheetRegionViewModel2, "Region 2");
			\u0018\u0004\u0019.\u000A(list3, sheetRegionViewModel2);
			List<SheetRegionViewModel> list4 = list3;
			List<IFileInfoViewModel> list5 = new List<IFileInfoViewModel>();
			string filePath = "Test Excel";
			List<WorksheetViewModel> list6 = new List<WorksheetViewModel>();
			WorksheetViewModel worksheetViewModel = new WorksheetViewModel("Sample WorkSheet 1");
			\u0019\u0004\u0019.\u000A(worksheetViewModel, list2);
			\u0004\u0004\u0019.\u000A(worksheetViewModel, Enumerable.First<SheetRegionViewModel>(list2));
			\u001D\u0004\u0019.\u000A(list6, worksheetViewModel);
			WorksheetViewModel worksheetViewModel2 = new WorksheetViewModel("Sample WorkSheet 2");
			\u0019\u0004\u0019.\u000A(worksheetViewModel2, list4);
			\u0004\u0004\u0019.\u000A(worksheetViewModel2, Enumerable.First<SheetRegionViewModel>(list4));
			\u001D\u0004\u0019.\u000A(list6, worksheetViewModel2);
			ExcelFileInfoViewModel excelFileInfoViewModel = new ExcelFileInfoViewModel(filePath, list6);
			\u0010\u000A\u0019.\u001D(excelFileInfoViewModel, SourceTypes.Excel);
			\u0007\u0004\u0019.\u000A(excelFileInfoViewModel, true);
			\u000A\u0004\u0019.\u000A(list5, excelFileInfoViewModel);
			\u000A\u0004\u0019.\u000A(list5, new FileInfoViewModel("Test"));
			this.LB = list5;
			this.ImportedFilesCollection = \u0011\u0009\u000A.\u000A(this.LB);
		}

		// Token: 0x06000CA5 RID: 3237 RVA: 0x0004FF08 File Offset: 0x0004E108
		public WorksheetSelectWindowViewModel(IEnumerable<IFileInfoViewModel> filesToImport, WorksheetSelectionDto worksheetSelectionDto)
		{
			this.SB = \u0007\u0018.\u0007<DocumentContext>();
			List<IFileInfoViewModel> list = new List<IFileInfoViewModel>();
			\u000F\u0004\u0019.\u000A(list, filesToImport);
			this.LB = list;
			this.ImportedFilesCollection = \u0011\u0009\u000A.\u000A(this.LB);
			\u0005\u0008\u0007.\u000A(\u0006\u0004\u0019.\u000A(this), new Predicate<object>(this.UMR));
			this.YB = \u001D\u0016.\u0004();
			IEnumerable<IFileInfoViewModel> lb = this.LB;
			Func<IFileInfoViewModel, bool> func;
			if ((func = WorksheetSelectWindowViewModel.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectWindowViewModel..ctor(IEnumerable<IFileInfoViewModel>, WorksheetSelectionDto)).MethodHandle;
				}
				func = (WorksheetSelectWindowViewModel.<>c.\u000A = new Func<IFileInfoViewModel, bool>(WorksheetSelectWindowViewModel.<>c.\u001F.\u0018));
			}
			if (!Enumerable.Any<IFileInfoViewModel>(lb, func))
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
				IEnumerable<EnumInfo> yb = this.YB;
				Func<EnumInfo, bool> func2;
				if ((func2 = WorksheetSelectWindowViewModel.<>c.\u0007) == null)
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
					func2 = (WorksheetSelectWindowViewModel.<>c.\u0007 = new Func<EnumInfo, bool>(WorksheetSelectWindowViewModel.<>c.\u001F.\u0005));
				}
				this.YB = Enumerable.ToList<EnumInfo>(Enumerable.Where<EnumInfo>(yb, func2));
			}
			if (\u001E\u0011\u0004.\u000A(this.YB) > 0)
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
				\u0002\u0004\u0019.\u000A(this, \u0016\u0008\u0004.\u000A(this.YB, 0));
			}
			this.ImportTypesCollection = \u0011\u0009\u000A.\u000A(this.YB);
			this.CB = \u001D\u0016.\u001D();
			\u000B\u0004\u0019.\u000A(this, \u0016\u0008\u0004.\u000A(this.CB, 0));
			this.ViewTypesCollection = \u0011\u0009\u000A.\u000A(this.CB);
			\u0005\u0008\u0007.\u000A(\u0016\u0004\u0019.\u000A(this), new Predicate<object>(this.WMR));
			this.ChangeDisplayPathCmd = new CommandBase(new Action(this.KMR), \u0002\u0015\u0010.\u001F);
			this.BMR(worksheetSelectionDto);
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x000500C4 File Offset: 0x0004E2C4
		private void BMR(WorksheetSelectionDto F)
		{
			WorksheetSelectWindowViewModel.\u000A\u000B u000A_u000B = new WorksheetSelectWindowViewModel.\u000A\u000B();
			u000A_u000B.\u001F = F;
			if (u000A_u000B.\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectWindowViewModel.BMR(WorksheetSelectionDto)).MethodHandle;
				}
				EnumInfo u000A;
				if ((u000A = Enumerable.FirstOrDefault<EnumInfo>(this.YB, new Func<EnumInfo, bool>(u000A_u000B.\u000A))) == null)
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
					u000A = \u000E\u0004\u0019.\u0007(this);
				}
				\u0002\u0004\u0019.\u000A(this, u000A);
				EnumInfo u000A2;
				if ((u000A2 = Enumerable.FirstOrDefault<EnumInfo>(this.CB, new Func<EnumInfo, bool>(u000A_u000B.\u0007))) == null)
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
					u000A2 = \u0010\u0004\u0019.\u0007(this);
				}
				\u000B\u0004\u0019.\u000A(this, u000A2);
				if (\u000D\u0004\u0019.\u000A(u000A_u000B.\u001F) >= 1)
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
					if (\u000D\u0004\u0019.\u000A(u000A_u000B.\u001F) <= 24000)
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
						\u001C\u0004\u0019.\u000A(this, \u000D\u0004\u0019.\u000A(u000A_u000B.\u001F));
					}
				}
				\u0012\u0004\u0019.\u000A(this, \u0003\u0004\u0019.\u000A(u000A_u000B.\u001F));
				\u000D\u0020\u000A.\u000A(this, "BlackAndWhite");
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000CA7 RID: 3239 RVA: 0x000501D0 File Offset: 0x0004E3D0
		// (set) Token: 0x06000CA8 RID: 3240 RVA: 0x000501E4 File Offset: 0x0004E3E4
		public string SearchText
		{
			get
			{
				return this.MC;
			}
			set
			{
				base.SetProperty<string>(ref this.MC, value, new Action(this.MMR), "SearchText");
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x00050214 File Offset: 0x0004E414
		// (set) Token: 0x06000CAA RID: 3242 RVA: 0x00050228 File Offset: 0x0004E428
		public IList<IFileInfoViewModel> SelectedItems { get; set; } = new List<IFileInfoViewModel>();

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06000CAB RID: 3243 RVA: 0x0005023C File Offset: 0x0004E43C
		public ICollectionView ImportedFilesCollection { get; }

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000CAC RID: 3244 RVA: 0x00050250 File Offset: 0x0004E450
		public ICollectionView ImportTypesCollection { get; }

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000CAD RID: 3245 RVA: 0x00050264 File Offset: 0x0004E464
		public ICollectionView ViewTypesCollection { get; }

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000CAE RID: 3246 RVA: 0x00050278 File Offset: 0x0004E478
		public bool IsBlackAndWhiteEnabled
		{
			get
			{
				return !this.NMR();
			}
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000CAF RID: 3247 RVA: 0x00050290 File Offset: 0x0004E490
		// (set) Token: 0x06000CB0 RID: 3248 RVA: 0x000502A4 File Offset: 0x0004E4A4
		public EnumInfo SelectedImportType
		{
			get
			{
				return this.SL;
			}
			set
			{
				if (base.SetProperty<EnumInfo>(ref this.SL, value, null, "SelectedImportType"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectWindowViewModel.set_SelectedImportType(EnumInfo)).MethodHandle;
					}
					if (this.NMR())
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
						\u0012\u0004\u0019.\u000A(this, false);
						\u000D\u0020\u000A.\u000A(this, "BlackAndWhite");
						if (this.EMR())
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
							\u000B\u0004\u0019.\u000A(this, \u0016\u0008\u0004.\u000A(this.CB, 0));
						}
					}
					ICollectionView collectionView = \u0016\u0004\u0019.\u000A(this);
					if (collectionView == null)
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
						\u0014\u0003\u0007.\u000A(collectionView);
					}
					\u000D\u0020\u000A.\u000A(this, "IsBlackAndWhiteEnabled");
				}
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x00050354 File Offset: 0x0004E554
		// (set) Token: 0x06000CB2 RID: 3250 RVA: 0x00050368 File Offset: 0x0004E568
		public EnumInfo SelectedViewType
		{
			get
			{
				return this.CL;
			}
			set
			{
				if (base.SetProperty<EnumInfo>(ref this.CL, value, null, "SelectedViewType"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectWindowViewModel.set_SelectedViewType(EnumInfo)).MethodHandle;
					}
					if (this.EMR())
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
						\u001C\u0004\u0019.\u000A(this, 1);
					}
				}
			}
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06000CB3 RID: 3251 RVA: 0x000503BC File Offset: 0x0004E5BC
		// (set) Token: 0x06000CB4 RID: 3252 RVA: 0x000503D0 File Offset: 0x0004E5D0
		public int ViewScale
		{
			get
			{
				return this.KL;
			}
			set
			{
				base.SetProperty<int>(ref this.KL, value, null, "ViewScale");
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06000CB5 RID: 3253 RVA: 0x000503F4 File Offset: 0x0004E5F4
		// (set) Token: 0x06000CB6 RID: 3254 RVA: 0x00050408 File Offset: 0x0004E608
		public bool BlackAndWhite { get; set; }

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000CB7 RID: 3255 RVA: 0x0005041C File Offset: 0x0004E61C
		public ICommand ChangeDisplayPathCmd { get; }

		// Token: 0x06000CB8 RID: 3256 RVA: 0x00050430 File Offset: 0x0004E630
		private bool UMR(object F)
		{
			bool result = false;
			IFileInfoViewModel fileInfoViewModel = \u0020\u0018\u000E.\u001F(F);
			if (fileInfoViewModel != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectWindowViewModel.UMR(object)).MethodHandle;
				}
				bool flag;
				if (!\u0010\u0010\u001D.\u000A(\u0008\u0004\u0019.\u000A(this)))
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
					if (!\u000D\u0008\u000A.\u001F(\u0011\u0004\u0019.\u000A(fileInfoViewModel), \u0008\u0004\u0019.\u000A(this)))
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
						flag = \u000D\u0008\u000A.\u001F(\u001B\u0004\u0019.\u000A(fileInfoViewModel), \u0008\u0004\u0019.\u000A(this));
						goto IL_79;
					}
				}
				flag = true;
				IL_79:
				result = flag;
			}
			return result;
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x000504B8 File Offset: 0x0004E6B8
		private bool WMR(object F)
		{
			EnumInfo enumInfo = \u001E\u0018\u000E.\u001F(F);
			if (enumInfo != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectWindowViewModel.WMR(object)).MethodHandle;
				}
				if (\u000D\u001B\u001D.\u0007(enumInfo) == 5)
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
					IEnumerable<IFileInfoViewModel> lb = this.LB;
					Func<IFileInfoViewModel, bool> func;
					if ((func = WorksheetSelectWindowViewModel.<>c.\u001D) == null)
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
						func = (WorksheetSelectWindowViewModel.<>c.\u001D = new Func<IFileInfoViewModel, bool>(WorksheetSelectWindowViewModel.<>c.\u001F.\u0016));
					}
					if (Enumerable.Any<IFileInfoViewModel>(lb, func))
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
						return !this.NMR();
					}
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x00050550 File Offset: 0x0004E750
		private void KMR()
		{
			IEnumerator<IFileInfoViewModel> enumerator = \u0017\u0004\u0019.\u000A(\u0014\u0004\u0019.\u000A(this));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					IFileInfoViewModel u001F = \u0020\u0004\u0019.\u000A(enumerator);
					\u0015\u0004\u0019.\u000A(u001F, !\u0001\u0004\u0019.\u000A(u001F));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectWindowViewModel.KMR()).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			IEnumerable<IFileInfoViewModel> enumerable = \u0014\u0004\u0019.\u000A(this);
			Func<IFileInfoViewModel, bool> func;
			if ((func = WorksheetSelectWindowViewModel.<>c.\u0004) == null)
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
				func = (WorksheetSelectWindowViewModel.<>c.\u0004 = new Func<IFileInfoViewModel, bool>(WorksheetSelectWindowViewModel.<>c.\u001F.\u000B));
			}
			if (Enumerable.Any<IFileInfoViewModel>(enumerable, func))
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
				WorksheetSelectWindowViewModel.\u0007\u000B u0007_u000B = new WorksheetSelectWindowViewModel.\u0007\u000B();
				WorksheetSelectWindowViewModel.\u0007\u000B u0007_u000B2 = u0007_u000B;
				Document document = \u0016\u0010\u001D.\u000A(this.SB);
				string u001F2;
				if (document == null)
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
					u001F2 = \u000F\u0015\u0010.\u001F;
				}
				else
				{
					u001F2 = \u0005\u001A\u000A.\u001D(document);
				}
				u0007_u000B2.\u001F = u001F2;
				if (\u0010\u0010\u001D.\u000A(u0007_u000B.\u001F))
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
					\u0011\u001F\u0019.\u000A(\u000C\u0004\u0019.\u000A(), MessageBoxButtons.OK);
					return;
				}
				u0007_u000B.\u000A = \u0019\u000E\u0004.\u000A(u0007_u000B.\u001F);
				Func<string, string> func2;
				if (!\u000F\u0005.\u0006(u0007_u000B.\u001F))
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
					func2 = new Func<string, string>(u0007_u000B.\u001D);
				}
				else
				{
					func2 = new Func<string, string>(u0007_u000B.\u0007);
				}
				Func<string, string> u001F3 = func2;
				IEnumerable<IFileInfoViewModel> enumerable2 = \u0014\u0004\u0019.\u000A(this);
				Func<IFileInfoViewModel, bool> func3;
				if ((func3 = WorksheetSelectWindowViewModel.<>c.\u0019) == null)
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
					func3 = (WorksheetSelectWindowViewModel.<>c.\u0019 = new Func<IFileInfoViewModel, bool>(WorksheetSelectWindowViewModel.<>c.\u001F.\u0002));
				}
				enumerator = \u0017\u0004\u0019.\u000A(Enumerable.Where<IFileInfoViewModel>(enumerable2, func3));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						IFileInfoViewModel u001F4 = \u0020\u0004\u0019.\u000A(enumerator);
						\u0013\u0004\u0019.\u000A(u001F4, \u001A\u0004\u0019.\u000A(u001F3, \u001B\u0004\u0019.\u000A(u001F4)));
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
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
			}
			enumerator = \u0017\u0004\u0019.\u000A(\u0014\u0004\u0019.\u000A(this));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u001E\u0004\u0019.\u000A(\u0020\u0004\u0019.\u000A(enumerator));
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x000507A4 File Offset: 0x0004E9A4
		private static string JMR(string F, string R)
		{
			\u000F\u0005 u000F_u = \u000F\u0005.\u000B(F, \u000F\u0005.\u000F(R, true), \u000F\u0015\u0010.\u001F);
			string text;
			if (u000F_u == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectWindowViewModel.JMR(string, string)).MethodHandle;
				}
				text = null;
			}
			else
			{
				text = \u0005\u001B\u0004.\u001D(u000F_u);
			}
			string result;
			if ((result = text) == null)
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
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x000507FC File Offset: 0x0004E9FC
		private bool EMR()
		{
			EnumInfo enumInfo = \u0010\u0004\u0019.\u0007(this);
			if (enumInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectWindowViewModel.EMR()).MethodHandle;
				}
				return false;
			}
			return \u000D\u001B\u001D.\u001D(enumInfo) == 5;
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x00050834 File Offset: 0x0004EA34
		private bool NMR()
		{
			EnumInfo enumInfo = \u000E\u0004\u0019.\u0007(this);
			if (enumInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectWindowViewModel.NMR()).MethodHandle;
				}
				return false;
			}
			return \u000D\u001B\u001D.\u001D(enumInfo) == 1;
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x0005086C File Offset: 0x0004EA6C
		[CompilerGenerated]
		private void MMR()
		{
			ICollectionView collectionView = \u0006\u0004\u0019.\u000A(this);
			if (collectionView == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectWindowViewModel.MMR()).MethodHandle;
				}
				return;
			}
			\u0014\u0003\u0007.\u000A(collectionView);
		}

		// Token: 0x040004FB RID: 1275
		private string MC;

		// Token: 0x040004FC RID: 1276
		private readonly List<EnumInfo> YB;

		// Token: 0x040004FD RID: 1277
		private readonly List<EnumInfo> CB;

		// Token: 0x040004FE RID: 1278
		private readonly IList<IFileInfoViewModel> LB;

		// Token: 0x040004FF RID: 1279
		private readonly DocumentContext SB;

		// Token: 0x04000500 RID: 1280
		private EnumInfo CL;

		// Token: 0x04000501 RID: 1281
		private EnumInfo SL;

		// Token: 0x04000502 RID: 1282
		private int KL = 1;

		// Token: 0x04000503 RID: 1283
		[CompilerGenerated]
		private IList<IFileInfoViewModel> BB;

		// Token: 0x04000504 RID: 1284
		[CompilerGenerated]
		private readonly ICollectionView UB;

		// Token: 0x04000505 RID: 1285
		[CompilerGenerated]
		private readonly ICollectionView WB;

		// Token: 0x04000506 RID: 1286
		[CompilerGenerated]
		private readonly ICollectionView KB;

		// Token: 0x04000507 RID: 1287
		[CompilerGenerated]
		private bool JB;

		// Token: 0x04000508 RID: 1288
		[CompilerGenerated]
		private readonly ICommand EB;

		// Token: 0x0200082D RID: 2093
		[CompilerGenerated]
		private sealed class \u000A\u000B
		{
			// Token: 0x06004E03 RID: 19971 RVA: 0x001DF8D8 File Offset: 0x001DDAD8
			internal bool \u000A(EnumInfo \u001F)
			{
				return \u000D\u001B\u001D.\u0007(\u001F) == \u0013\u000A\u0010.\u000A(this.\u001F);
			}

			// Token: 0x06004E04 RID: 19972 RVA: 0x001DF8FC File Offset: 0x001DDAFC
			internal bool \u0007(EnumInfo \u001F)
			{
				return \u000D\u001B\u001D.\u0007(\u001F) == \u001A\u000A\u0010.\u000A(this.\u001F);
			}

			// Token: 0x040020B3 RID: 8371
			public WorksheetSelectionDto \u001F;
		}

		// Token: 0x0200082E RID: 2094
		[CompilerGenerated]
		private sealed class \u0007\u000B
		{
			// Token: 0x06004E06 RID: 19974 RVA: 0x001DF934 File Offset: 0x001DDB34
			internal string \u0007(string \u001F)
			{
				return WorksheetSelectWindowViewModel.JMR(\u001F, this.\u001F);
			}

			// Token: 0x06004E07 RID: 19975 RVA: 0x001DF950 File Offset: 0x001DDB50
			internal string \u001D(string \u001F)
			{
				return FilePathHelper.\u0004(\u001F, this.\u000A);
			}

			// Token: 0x040020B4 RID: 8372
			public string \u001F;

			// Token: 0x040020B5 RID: 8373
			public string \u000A;
		}
	}
}

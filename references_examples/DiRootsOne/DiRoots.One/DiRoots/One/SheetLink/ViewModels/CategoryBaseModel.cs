using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.SectionBox.Models.Enums;
using DiRoots.One.SheetLink.Core;
using DiRoots.One.SheetLink.Core.Enums;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.UI.Controls;
using DiRoots.One.SheetLink.UI.Windows;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.SheetLink.ViewModels
{
	// Token: 0x0200020F RID: 527
	public abstract class CategoryBaseModel : ViewModelBase
	{
		// Token: 0x06001378 RID: 4984 RVA: 0x0007C794 File Offset: 0x0007A994
		protected CategoryBaseModel(UIDocument uidoc, Window parent)
		{
			this.ActiveDocument = uidoc;
			\u0019\u0013\u0018.\u000A(this, 1);
			\u001A\u001A\u0018.\u000A(this, new \u001F\u000D());
			\u000A\u000C\u0007.\u001D(this, parent);
			this.ActiveProgressBar = \u0005\u0002\u000E.\u001F(parent).RH;
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x0007C7DC File Offset: 0x0007A9DC
		protected CategoryBaseModel(UIDocument uidoc, Window parent, List<CategoryCollection> collections)
		{
			this.ActiveDocument = uidoc;
			this.YW = new \u0014\u000F(\u0011\u0020\u000A.\u0007(uidoc), collections);
			\u0019\u0013\u0018.\u000A(this, 1);
			this.AWR();
			\u001A\u001A\u0018.\u000A(this, new \u0015\u001C());
			\u000A\u000C\u0007.\u001D(this, parent);
			this.ActiveProgressBar = \u0005\u0002\u000E.\u001F(parent).RH;
		}

		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x0600137A RID: 4986 RVA: 0x0007C83C File Offset: 0x0007AA3C
		// (set) Token: 0x0600137B RID: 4987 RVA: 0x0007C850 File Offset: 0x0007AA50
		internal \u0015\u001C ParamCollector { get; set; }

		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x0600137C RID: 4988 RVA: 0x0007C864 File Offset: 0x0007AA64
		// (set) Token: 0x0600137D RID: 4989 RVA: 0x0007C878 File Offset: 0x0007AA78
		public ObservableCollection<ICategoryModel> Categories
		{
			get
			{
				return this.IU;
			}
			set
			{
				this.IU = value;
				this.OnPropertyChanged<ObservableCollection<ICategoryModel>>(new Func<ObservableCollection<ICategoryModel>>(this.ZVR), "Categories");
			}
		}

		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x0600137E RID: 4990 RVA: 0x0007C8A4 File Offset: 0x0007AAA4
		// (set) Token: 0x0600137F RID: 4991 RVA: 0x0007C8B8 File Offset: 0x0007AAB8
		public int ElementsOption
		{
			get
			{
				return this.SD;
			}
			set
			{
				this.SD = value;
				\u000D\u0020\u000A.\u000A(this, "ElementsOption");
			}
		}

		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x06001380 RID: 4992 RVA: 0x0007C8D8 File Offset: 0x0007AAD8
		// (set) Token: 0x06001381 RID: 4993 RVA: 0x0007C8EC File Offset: 0x0007AAEC
		public bool IsLinkedFileChecked
		{
			get
			{
				return this.GU;
			}
			set
			{
				this.GU = value;
				\u000D\u0020\u000A.\u000A(this, "IsLinkedFileChecked");
			}
		}

		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x06001382 RID: 4994 RVA: 0x0007C90C File Offset: 0x0007AB0C
		// (set) Token: 0x06001383 RID: 4995 RVA: 0x0007C920 File Offset: 0x0007AB20
		public bool ExportByType
		{
			get
			{
				return this.FW;
			}
			set
			{
				this.FW = value;
				if (\u0015\u001A\u0018.\u000A(this) != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.set_ExportByType(bool)).MethodHandle;
					}
					\u000C\u001A\u0018.\u000A(\u0015\u001A\u0018.\u000A(this), this.FW);
				}
				\u000D\u0020\u000A.\u000A(this, "ExportByType");
			}
		}

		// Token: 0x1700059D RID: 1437
		// (get) Token: 0x06001384 RID: 4996 RVA: 0x0007C970 File Offset: 0x0007AB70
		// (set) Token: 0x06001385 RID: 4997 RVA: 0x0007C984 File Offset: 0x0007AB84
		public string StatusText
		{
			get
			{
				return this.PB;
			}
			set
			{
				this.PB = value;
				\u000D\u0020\u000A.\u000A(this, "StatusText");
			}
		}

		// Token: 0x1700059E RID: 1438
		// (get) Token: 0x06001386 RID: 4998 RVA: 0x0007C9A4 File Offset: 0x0007ABA4
		// (set) Token: 0x06001387 RID: 4999 RVA: 0x0007C9B8 File Offset: 0x0007ABB8
		public bool IsExportable
		{
			get
			{
				return this.OB;
			}
			set
			{
				this.OB = value;
				\u000D\u0020\u000A.\u000A(this, "IsExportable");
			}
		}

		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x06001388 RID: 5000 RVA: 0x0007C9D8 File Offset: 0x0007ABD8
		// (set) Token: 0x06001389 RID: 5001 RVA: 0x0007C9EC File Offset: 0x0007ABEC
		public bool IsolateEnabled
		{
			get
			{
				return this.DW;
			}
			set
			{
				this.DW = value;
				this.OnPropertyChanged<bool>(new Func<bool>(this.XVR), "IsolateEnabled");
			}
		}

		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x0600138A RID: 5002 RVA: 0x0007CA18 File Offset: 0x0007AC18
		// (set) Token: 0x0600138B RID: 5003 RVA: 0x0007CA2C File Offset: 0x0007AC2C
		public bool IsolateChecked
		{
			get
			{
				return this.HW;
			}
			set
			{
				this.HW = value;
				this.OnPropertyChanged<bool>(new Func<bool>(this.PVR), "IsolateChecked");
			}
		}

		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x0600138C RID: 5004 RVA: 0x0007CA58 File Offset: 0x0007AC58
		public string ExportContent
		{
			get
			{
				return \u0001\u001A\u0018.\u000A();
			}
		}

		// Token: 0x170005A2 RID: 1442
		// (get) Token: 0x0600138D RID: 5005 RVA: 0x0007CA6C File Offset: 0x0007AC6C
		public double ExportWidth
		{
			get
			{
				return 100.0;
			}
		}

		// Token: 0x170005A3 RID: 1443
		// (get) Token: 0x0600138E RID: 5006 RVA: 0x0007CA84 File Offset: 0x0007AC84
		public CommandBase ElementsOptionChangedCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.ElementsOptionChanged), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005A4 RID: 1444
		// (get) Token: 0x0600138F RID: 5007 RVA: 0x0007CAAC File Offset: 0x0007ACAC
		public CommandBase StandardExportCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.ExportProjectStandards), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005A5 RID: 1445
		// (get) Token: 0x06001390 RID: 5008 RVA: 0x0007CAD4 File Offset: 0x0007ACD4
		public CommandBase ExportCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.OnExportClicked), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005A6 RID: 1446
		// (get) Token: 0x06001391 RID: 5009 RVA: 0x0007CAFC File Offset: 0x0007ACFC
		public CommandBase ExportToDriveCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.OnExportToDriveClicked), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005A7 RID: 1447
		// (get) Token: 0x06001392 RID: 5010 RVA: 0x0007CB24 File Offset: 0x0007AD24
		public CommandBase ResetCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.OnResetClicked), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005A8 RID: 1448
		// (get) Token: 0x06001393 RID: 5011 RVA: 0x0007CB4C File Offset: 0x0007AD4C
		public CommandBase IsolateCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.Isolate), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x170005A9 RID: 1449
		// (get) Token: 0x06001394 RID: 5012 RVA: 0x0007CB74 File Offset: 0x0007AD74
		public CommandBase SectionBoxCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.SectionBox), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x06001395 RID: 5013 RVA: 0x0007CB9C File Offset: 0x0007AD9C
		public virtual void ElementsOptionChanged()
		{
			if (!\u0018\u000C\u0018.\u000A(this.ActiveDocument))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.ElementsOptionChanged()).MethodHandle;
				}
				return;
			}
			List<ICategoryModel> u001F = \u001E\u0003\u0018.\u000A();
			if (\u001A\u0013\u0018.\u000A(this) != null)
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
				u001F = \u0019\u000C\u0018.\u000A(\u001A\u0013\u0018.\u000A(this));
			}
			List<ICategoryModel> list2;
			if (\u0004\u000C\u0018.\u000A(this) == 1)
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
				List<ICategoryModel> list;
				if (!\u0019\u001A\u0018.\u000A(this))
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
					list = Enumerable.ToList<ICategoryModel>(this.YW.\u001C());
				}
				else
				{
					list = Enumerable.ToList<ICategoryModel>(this.YW.\u0010());
				}
				list2 = list;
			}
			else if (\u0004\u000C\u0018.\u000A(this) == 2)
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
				list2 = Enumerable.ToList<ICategoryModel>(this.YW.\u000E(false));
				\u001D\u0013\u0018.\u000A(this, false);
			}
			else
			{
				this.RW = Enumerable.ToList<Element>(\u0004\u0010.\u000A(this.ActiveDocument));
				list2 = Enumerable.ToList<ICategoryModel>(this.YW.\u0008(this.RW));
				\u001D\u0013\u0018.\u000A(this, false);
			}
			List<ICategoryModel>.Enumerator enumerator = \u001D\u001C\u0018.\u000A(u001F);
			try
			{
				while (\u000A\u001C\u0018.\u000A(ref enumerator))
				{
					CategoryBaseModel.\u001A\u0012 u001A_u = new CategoryBaseModel.\u001A\u0012();
					u001A_u.\u001F = \u0007\u001C\u0018.\u000A(ref enumerator);
					ICategoryModel categoryModel = Enumerable.FirstOrDefault<ICategoryModel>(list2, new Func<ICategoryModel, bool>(u001A_u.\u000A));
					if (categoryModel != null)
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
						\u0013\u0013\u0018.\u000A(categoryModel, \u001D\u000C\u0018.\u000A(u001A_u.\u001F));
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
			IEnumerable<ICategoryModel> enumerable = list2;
			Func<ICategoryModel, string> func;
			if ((func = CategoryBaseModel.<>c.\u000A) == null)
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
				func = (CategoryBaseModel.<>c.\u000A = new Func<ICategoryModel, string>(CategoryBaseModel.<>c.\u001F.\u0006));
			}
			\u000A\u000C\u0018.\u000A(this, \u0007\u000C\u0018.\u000A(Enumerable.OrderBy<ICategoryModel, string>(enumerable, func)));
			ElementsWindowModel elementsWindowModel = \u0018\u0002\u000E.\u001F(this);
			if (elementsWindowModel != null)
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
				\u001F\u000C\u0018.\u0007(elementsWindowModel);
				\u0009\u001A\u0018.\u000A(elementsWindowModel);
			}
			else
			{
				\u0001\u0014\u0018.\u000A(this, \u001A\u0013\u0018.\u000A(this));
			}
			\u0010\u001C\u0018.\u001D(this.YW, false);
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x0007CDCC File Offset: 0x0007AFCC
		public virtual void ExportProjectStandards()
		{
			StandardExportOptions u001F = \u0012\u000C\u0018.\u000A();
			\u0015\u000D\u001D.\u000A(u001F, \u0018\u000B\u0007.\u0007(this));
			bool? flag = \u0018\u0020\u000A.\u0007(u001F);
			if (\u0012\u0015\u000A.\u000A(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.ExportProjectStandards()).MethodHandle;
				}
				CategoryBaseModel.\u000C\u0012 u000C_u = new CategoryBaseModel.\u000C\u0012();
				u000C_u.\u001F = \u000F\u000C\u0018.\u0007(u001F);
				List<CategoryCollection> list = CategoryCollection.QP();
				list = Enumerable.ToList<CategoryCollection>(Enumerable.Where<CategoryCollection>(list, new Func<CategoryCollection, bool>(u000C_u.\u000A)));
				string text = \u001F\u0011\u0018.\u000A().\u001F();
				if (\u0006\u000C\u0018.\u000A(u001F))
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
					string text2 = \u0004\u000F.\u0018(text, true, true);
					if (!\u001A\u0006\u0007.\u000A(text2))
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
						\u0009\u0014\u0019.\u000A(\u0010\u0014\u0019.\u0007(this.ActiveProgressBar), \u0020\u0014\u0018.\u000A(list), \u0018\u000E\u0007.\u000A(\u000C\u0013\u0019.\u000A(), 1, 1));
						\u0020\u0003.\u000A(list, text2, \u0002\u000C\u0018.\u000A(u001F), true, \u0006\u000F\u0018.\u0007(\u0010\u0014\u0019.\u0007(this.ActiveProgressBar)));
						\u0002\u0013\u0019.\u0007(\u0010\u0014\u0019.\u0007(this.ActiveProgressBar));
						return;
					}
				}
				else
				{
					List<CategoryCollection> u000A = list;
					ExportOption exportOption = \u000B\u000C\u0018.\u000A();
					\u0016\u000C\u0018.\u000A(exportOption, text);
					\u0005\u000C\u0018.\u000A(exportOption, true);
					\u0008\u001A\u0018.\u000A(this, u000A, exportOption);
				}
			}
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x0007CF2C File Offset: 0x0007B12C
		public void OnResetClicked()
		{
			\u0019\u0013\u0018.\u000A(this, 1);
			\u001D\u0013\u0018.\u000A(this, false);
			\u000A\u0013\u0018.\u000A(this, false);
			\u0005\u0013\u0018.\u000A(this);
			\u0017\u0014\u0018.\u000A(this);
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x0007CF5C File Offset: 0x0007B15C
		[BindableMethod("LinkedOptionChanged")]
		public void LinkedOptionChanged()
		{
			\u0003\u000C\u0018.\u000A(this);
		}

		// Token: 0x06001399 RID: 5017 RVA: 0x0007CF70 File Offset: 0x0007B170
		private void AWR()
		{
			\u0003\u000C\u0018.\u000A(this);
		}

		// Token: 0x0600139A RID: 5018
		public abstract void SetStatus();

		// Token: 0x0600139B RID: 5019
		public abstract void ExportToExcel(IExportOption exportOption);

		// Token: 0x0600139C RID: 5020
		public abstract void ExportToDrive(IExportOption exportOption);

		// Token: 0x0600139D RID: 5021
		public abstract void ExportToMorta(IExportOption exportOption);

		// Token: 0x0600139E RID: 5022
		public abstract void Reset();

		// Token: 0x0600139F RID: 5023
		public abstract void EnableIsolateElements();

		// Token: 0x060013A0 RID: 5024
		public abstract void Isolate();

		// Token: 0x060013A1 RID: 5025
		public abstract void SectionBox();

		// Token: 0x060013A2 RID: 5026 RVA: 0x0007CF84 File Offset: 0x0007B184
		public void RefreshTab()
		{
			if (!\u0018\u000C\u0018.\u000A(this.ActiveDocument))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.RefreshTab()).MethodHandle;
				}
				return;
			}
			if (this.YW != null)
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
				if (\u0004\u000C\u0018.\u000A(this) != 2)
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
					if (\u0004\u000C\u0018.\u000A(this) != 3)
					{
						goto IL_161;
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
				List<ICategoryModel> list = \u0014\u000B\u000E.\u001F;
				if (\u0004\u000C\u0018.\u000A(this) == 2)
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
					list = Enumerable.ToList<ICategoryModel>(this.YW.\u000E(false));
					\u001D\u0013\u0018.\u000A(this, false);
				}
				else if (\u0004\u000C\u0018.\u000A(this) == 3)
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
					this.RW = Enumerable.ToList<Element>(\u0004\u0010.\u000A(this.ActiveDocument));
					list = Enumerable.ToList<ICategoryModel>(this.YW.\u0008(this.RW));
					\u001D\u0013\u0018.\u000A(this, false);
				}
				if (\u000D\u000C\u0018.\u000A(this.YW))
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
					IEnumerable<ICategoryModel> enumerable = list;
					Func<ICategoryModel, string> func;
					if ((func = CategoryBaseModel.<>c.\u0007) == null)
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
						func = (CategoryBaseModel.<>c.\u0007 = new Func<ICategoryModel, string>(CategoryBaseModel.<>c.\u001F.\u000F));
					}
					\u000A\u000C\u0018.\u000A(this, \u0007\u000C\u0018.\u000A(Enumerable.OrderBy<ICategoryModel, string>(enumerable, func)));
					\u0001\u0014\u0018.\u000A(this, \u001A\u0013\u0018.\u000A(this));
					\u0010\u001C\u0018.\u001D(this.YW, false);
				}
			}
			IL_161:
			\u001C\u000C\u0018.\u000A(this);
		}

		// Token: 0x060013A3 RID: 5027 RVA: 0x0007D0F8 File Offset: 0x0007B2F8
		protected void SelectionChanged(ObservableCollection<ICategoryModel> categoryCollections)
		{
			List<ICategoryModel> u000A;
			if (categoryCollections == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.SelectionChanged(ObservableCollection<ICategoryModel>)).MethodHandle;
				}
				u000A = \u0014\u000B\u000E.\u001F;
			}
			else
			{
				u000A = Enumerable.ToList<ICategoryModel>(categoryCollections);
			}
			\u000C\u0014\u0018.\u000A(this, u000A);
			if (categoryCollections != null)
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
				if (this.ParametersModel != null)
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
					List<CategoryCollection> list = Enumerable.ToList<CategoryCollection>(Enumerable.Cast<CategoryCollection>(categoryCollections));
					\u0011\u000C\u0018.\u000A(\u001B\u0014\u0019.\u0007(\u0015\u001A\u0018.\u000A(this)));
					IEnumerable<CategoryCollection> enumerable = list;
					Func<CategoryCollection, bool> func;
					if ((func = CategoryBaseModel.<>c.\u001D) == null)
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
						func = (CategoryBaseModel.<>c.\u001D = new Func<CategoryCollection, bool>(CategoryBaseModel.<>c.\u001F.\u0012));
					}
					if (Enumerable.Any<CategoryCollection>(enumerable, func))
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
						Document u001F = \u0011\u0020\u000A.\u0007(this.ActiveDocument);
						\u0015\u001C u000A2 = \u0015\u001A\u0018.\u000A(this);
						IEnumerable<CategoryCollection> enumerable2 = list;
						Func<CategoryCollection, bool> func2;
						if ((func2 = CategoryBaseModel.<>c.\u0004) == null)
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
							func2 = (CategoryBaseModel.<>c.\u0004 = new Func<CategoryCollection, bool>(CategoryBaseModel.<>c.\u001F.\u0003));
						}
						ProgressWindow u001F2 = \u0008\u000C\u0018.\u000A(\u001B\u000C\u0018.\u000A(u001F, u000A2, Enumerable.ToList<CategoryCollection>(Enumerable.Where<CategoryCollection>(enumerable2, func2))));
						\u0015\u000D\u001D.\u000A(u001F2, \u0018\u000B\u0007.\u0007(this));
						\u0018\u0020\u000A.\u0007(u001F2);
					}
					if (this.YW != null)
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
						CategoryBaseModel.\u0015\u0012 u0015_u = new CategoryBaseModel.\u0015\u0012();
						CategoryBaseModel.\u0015\u0012 u0015_u2 = u0015_u;
						ObservableCollection<BaseParameter> observableCollection = \u001B\u0013\u0018.\u000A(this.ParametersModel);
						List<long> u001F3;
						if (observableCollection == null)
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
							u001F3 = \u001A\u000B\u000E.\u001F;
						}
						else
						{
							Func<BaseParameter, long> func3;
							if ((func3 = CategoryBaseModel.<>c.\u0019) == null)
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
								func3 = (CategoryBaseModel.<>c.\u0019 = new Func<BaseParameter, long>(CategoryBaseModel.<>c.\u001F.\u001C));
							}
							u001F3 = Enumerable.ToList<long>(Enumerable.Select<BaseParameter, long>(observableCollection, func3));
						}
						u0015_u2.\u001F = u001F3;
						if (u0015_u.\u001F == null)
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
							u0015_u.\u001F = \u001F\u001B\u0019.\u000A();
						}
						\u000E\u000C\u0018.\u000A(this.ParametersModel, \u0018\u0014\u0019.\u000A(Enumerable.Where<RevitParameter>(\u001B\u0014\u0019.\u0007(\u0015\u001A\u0018.\u000A(this)), new Func<RevitParameter, bool>(u0015_u.\u000A))));
						IOrderedEnumerable<RevitParameter> u001F4 = Enumerable.OrderBy<RevitParameter, int>(Enumerable.Where<RevitParameter>(\u001B\u0014\u0019.\u0007(\u0015\u001A\u0018.\u000A(this)), new Func<RevitParameter, bool>(u0015_u.\u0007)), new Func<RevitParameter, int>(u0015_u.\u001D));
						\u0010\u000C\u0018.\u000A(this.ParametersModel, \u0018\u0014\u0019.\u000A(u001F4));
					}
					else
					{
						\u000E\u000C\u0018.\u000A(this.ParametersModel, \u0018\u0014\u0019.\u000A(\u001B\u0014\u0019.\u0007(\u0015\u001A\u0018.\u000A(this))));
						\u0010\u000C\u0018.\u000A(this.ParametersModel, \u0018\u0014\u0019.\u000A(\u000E\u0013\u0018.\u0007(this.ParametersModel)));
					}
					\u0017\u0014\u0018.\u000A(this);
				}
			}
		}

		// Token: 0x060013A4 RID: 5028 RVA: 0x0007D388 File Offset: 0x0007B588
		public virtual void OnExportClicked()
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\CategoryBaseModel.cs", "OnExportClicked");
			ExportOptions u001F = \u0013\u000C\u0018.\u000A(this.YW == \u001F\u0002\u000E.\u001F, false);
			\u0015\u000D\u001D.\u000A(u001F, \u0018\u000B\u0007.\u0007(this));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.OnExportClicked()).MethodHandle;
				}
				ExportOption exportOption = \u001D\u0013\u0019.\u000A(u001F);
				if (\u0020\u000C\u0018.\u0007(exportOption) == ExportOutputTypes.Excel)
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
					\u0014\u000C\u0018.\u000A(this, exportOption);
				}
				else if (\u0020\u000C\u0018.\u0007(exportOption) == ExportOutputTypes.GoogleDrive)
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
					\u0017\u000C\u0018.\u000A(this, exportOption);
				}
				else if (\u0020\u000C\u0018.\u0007(exportOption) == ExportOutputTypes.Morta)
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
					\u001E\u000C\u0018.\u000A(this, exportOption);
				}
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\CategoryBaseModel.cs", "OnExportClicked");
		}

		// Token: 0x060013A5 RID: 5029 RVA: 0x0007D470 File Offset: 0x0007B670
		public void OnExportToDriveClicked()
		{
			\u0017\u000C\u0018.\u000A(this, \u000B\u000C\u0018.\u000A());
		}

		// Token: 0x060013A6 RID: 5030 RVA: 0x0007D48C File Offset: 0x0007B68C
		public void ExportToExcel(List<CategoryCollection> catCollections, IExportOption exportOption)
		{
			if (\u0015\u000C\u0018.\u000A(this, catCollections, exportOption))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.ExportToExcel(List<CategoryCollection>, IExportOption)).MethodHandle;
				}
				\u0017\u0010 u0017_u = new \u0017\u0010();
				\u001E\u0014\u0019.\u000A(u0017_u, \u0015\u001A\u0018.\u000A(this));
				\u0011\u0014\u0019.\u000A(u0017_u, catCollections);
				\u0008\u0014\u0019.\u000A(u0017_u, Enumerable.ToList<RevitParameter>(Enumerable.Cast<RevitParameter>(\u001B\u0013\u0018.\u000A(this.ParametersModel))));
				if (\u001D\u001A\u0018.\u000A(this))
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
					object u001F = u0017_u;
					IEnumerable<RevitParameter> enumerable = \u000C\u000C\u0018.\u0007(u0017_u);
					Func<RevitParameter, bool> func;
					if ((func = CategoryBaseModel.<>c.\u0018) == null)
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
						func = (CategoryBaseModel.<>c.\u0018 = new Func<RevitParameter, bool>(CategoryBaseModel.<>c.\u001F.\u000D));
					}
					\u0008\u0014\u0019.\u000A(u001F, Enumerable.ToList<RevitParameter>(Enumerable.Where<RevitParameter>(enumerable, func)));
				}
				\u001A\u000C\u0018.\u000A(exportOption, \u001D\u001A\u0018.\u000A(this));
				\u000E\u0014\u0019.\u000A(u0017_u, exportOption);
				u0017_u.\u001F += this.TaskFinished;
				\u000D\u0014\u0019.\u000A(u0017_u, \u0010\u0014\u0019.\u0007(this.ActiveProgressBar));
				\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u0017_u);
				\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
			}
		}

		// Token: 0x060013A7 RID: 5031 RVA: 0x0007D5A4 File Offset: 0x0007B7A4
		public void ExportToDrive(List<CategoryCollection> catCollections, IExportOption exportOption)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\CategoryBaseModel.cs", "ExportToDrive");
			\u0010\u001A\u0018.\u000A(exportOption, \u001B\u0015\u001D.\u000A(\u0004\u000F.\u0019(), \u0004\u001E\u000A.\u000A(\u0009\u000C\u0018.\u000A(exportOption), ".xlsx")));
			\u001A\u000C\u0018.\u000A(exportOption, \u001D\u001A\u0018.\u000A(this));
			\u001B\u0010 u001B_u = new \u001B\u0010();
			\u001E\u0014\u0019.\u000A(u001B_u, \u0015\u001A\u0018.\u000A(this));
			\u0011\u0014\u0019.\u000A(u001B_u, catCollections);
			\u0008\u0014\u0019.\u000A(u001B_u, Enumerable.ToList<RevitParameter>(Enumerable.Cast<RevitParameter>(\u001B\u0013\u0018.\u000A(this.ParametersModel))));
			if (\u001D\u001A\u0018.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.ExportToDrive(List<CategoryCollection>, IExportOption)).MethodHandle;
				}
				object u001F = u001B_u;
				IEnumerable<RevitParameter> enumerable = \u000C\u000C\u0018.\u0007(u001B_u);
				Func<RevitParameter, bool> func;
				if ((func = CategoryBaseModel.<>c.\u0005) == null)
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
					func = (CategoryBaseModel.<>c.\u0005 = new Func<RevitParameter, bool>(CategoryBaseModel.<>c.\u001F.\u0010));
				}
				\u0008\u0014\u0019.\u000A(u001F, Enumerable.ToList<RevitParameter>(Enumerable.Where<RevitParameter>(enumerable, func)));
			}
			\u0001\u000C\u0018.\u000A(u001B_u, new Action<string, string>(this.OMR));
			\u000D\u0014\u0019.\u000A(u001B_u, \u0010\u0014\u0019.\u0007(this.ActiveProgressBar));
			\u000E\u0014\u0019.\u000A(u001B_u, exportOption);
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u001B_u);
			\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\CategoryBaseModel.cs", "ExportToDrive");
		}

		// Token: 0x060013A8 RID: 5032 RVA: 0x0007D6F8 File Offset: 0x0007B8F8
		public void ExportToMorta(List<CategoryCollection> catCollections, IExportOption exportOption)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\CategoryBaseModel.cs", "ExportToMorta");
			\u000C\u0010 u000C_u = new \u000C\u0010();
			\u001E\u0014\u0019.\u000A(u000C_u, \u0015\u001A\u0018.\u000A(this));
			\u0011\u0014\u0019.\u000A(u000C_u, catCollections);
			\u0008\u0014\u0019.\u000A(u000C_u, Enumerable.ToList<RevitParameter>(Enumerable.Cast<RevitParameter>(\u001B\u0013\u0018.\u000A(this.ParametersModel))));
			if (\u001D\u001A\u0018.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.ExportToMorta(List<CategoryCollection>, IExportOption)).MethodHandle;
				}
				object u001F = u000C_u;
				IEnumerable<RevitParameter> enumerable = \u000C\u000C\u0018.\u0007(u000C_u);
				Func<RevitParameter, bool> func;
				if ((func = CategoryBaseModel.<>c.\u0016) == null)
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
					func = (CategoryBaseModel.<>c.\u0016 = new Func<RevitParameter, bool>(CategoryBaseModel.<>c.\u001F.\u000E));
				}
				\u0008\u0014\u0019.\u000A(u001F, Enumerable.ToList<RevitParameter>(Enumerable.Where<RevitParameter>(enumerable, func)));
			}
			\u000D\u0014\u0019.\u000A(u000C_u, \u0010\u0014\u0019.\u0007(this.ActiveProgressBar));
			\u001A\u000C\u0018.\u000A(exportOption, \u001D\u001A\u0018.\u000A(this));
			\u000E\u0014\u0019.\u000A(u000C_u, exportOption);
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000C_u);
			\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\CategoryBaseModel.cs", "ExportToMorta");
		}

		// Token: 0x060013A9 RID: 5033 RVA: 0x0007D810 File Offset: 0x0007BA10
		private void OMR(string F, string R)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\CategoryBaseModel.cs", "ShowDriveWindow");
			PluginInfo u001F = \u000F\u0013\u0019.\u000A();
			List<string> list = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list, R);
			DriveSelection u001F2 = \u0006\u0013\u0019.\u000A(u001F, list, true);
			\u0015\u000D\u001D.\u000A(u001F2, \u0018\u000B\u0007.\u0007(this));
			\u0018\u0020\u000A.\u0007(u001F2);
			\u0020\u0008\u000A.\u001F(R);
			\u0002\u0013\u0019.\u0007(\u0010\u0014\u0019.\u0007(this.ActiveProgressBar));
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\CategoryBaseModel.cs", "ShowDriveWindow");
		}

		// Token: 0x060013AA RID: 5034 RVA: 0x0007D898 File Offset: 0x0007BA98
		protected bool VerifyExportPath(List<CategoryCollection> catCollections, IExportOption exportOption)
		{
			string text = \u0020\u001E\u0018.\u000A(exportOption);
			if (!\u001A\u0006\u0007.\u000A(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.VerifyExportPath(List<CategoryCollection>, IExportOption)).MethodHandle;
				}
				try
				{
					string text2 = text;
					while (!\u001B\u0012.\u0019(catCollections, \u0018\u000B\u0007.\u0007(this), ref text2))
					{
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
					if (\u001A\u0006\u0007.\u000A(text2))
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
						return false;
					}
					\u0010\u001A\u0018.\u000A(exportOption, text2);
					return true;
				}
				catch (Exception ex)
				{
					\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), ex, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\CategoryBaseModel.cs", "VerifyExportPath");
					\u0004\u000F.\u0016(ex);
					return false;
				}
				return false;
			}
			return false;
		}

		// Token: 0x060013AB RID: 5035 RVA: 0x0007D948 File Offset: 0x0007BB48
		public void TaskFinished(ITaskFinishedArgs taskFinished)
		{
			ExportTaskArgs u001F = \u0019\u0002\u000E.\u001F(taskFinished);
			\u001F\u0015\u0018.\u000A(this, \u001A\u0013\u0019.\u000A(u001F), \u0017\u0013\u0019.\u000A(u001F));
			CustomProgressBar activeProgressBar = this.ActiveProgressBar;
			if (activeProgressBar == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.TaskFinished(ITaskFinishedArgs)).MethodHandle;
				}
				return;
			}
			ProgressModel progressModel = \u0010\u0014\u0019.\u001D(activeProgressBar);
			if (progressModel == null)
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
				return;
			}
			\u0002\u0013\u0019.\u001D(progressModel);
		}

		// Token: 0x060013AC RID: 5036 RVA: 0x0007D9B0 File Offset: 0x0007BBB0
		protected void OpenFile(string filePath, bool openSpreadSheet)
		{
			if (openSpreadSheet)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.OpenFile(string, bool)).MethodHandle;
				}
				\u0004\u0019\u0019.\u000A(filePath);
				return;
			}
			\u000F\u0005\u0019.\u000A(\u0001\u0013\u0019.\u000A(), \u0018\u000B\u0007.\u0007(this), MessageBoxButtons.OK);
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x0007D9F4 File Offset: 0x0007BBF4
		public void GetData(List<CategoryCollection> catCollections, Delegate showPreview, string filePath = "")
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\CategoryBaseModel.cs", "GetData");
			List<string> u001F = \u001B\u0012.\u0005(catCollections);
			\u0009\u0014\u0019.\u000A(\u0010\u0014\u0019.\u0007(this.ActiveProgressBar), \u0015\u0007\u0019.\u000A(u001F), \u0018\u000E\u0007.\u000A(\u001F\u0013\u0019.\u000A(), 1, 1));
			\u0014\u0010 u0014_u = new \u0014\u0010();
			\u001E\u0014\u0019.\u000A(u0014_u, \u0015\u001A\u0018.\u000A(this));
			\u0011\u0014\u0019.\u000A(u0014_u, catCollections);
			\u0008\u0014\u0019.\u000A(u0014_u, Enumerable.ToList<RevitParameter>(Enumerable.Cast<RevitParameter>(\u001B\u0013\u0018.\u000A(this.ParametersModel))));
			if (\u001D\u001A\u0018.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.GetData(List<CategoryCollection>, Delegate, string)).MethodHandle;
				}
				object u001F2 = u0014_u;
				IEnumerable<RevitParameter> enumerable = \u000C\u000C\u0018.\u0007(u0014_u);
				Func<RevitParameter, bool> func;
				if ((func = CategoryBaseModel.<>c.\u000B) == null)
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
					func = (CategoryBaseModel.<>c.\u000B = new Func<RevitParameter, bool>(CategoryBaseModel.<>c.\u001F.\u0008));
				}
				\u0008\u0014\u0019.\u000A(u001F2, Enumerable.ToList<RevitParameter>(Enumerable.Where<RevitParameter>(enumerable, func)));
			}
			\u000E\u0014\u0019.\u000A(u0014_u, \u000B\u000C\u0018.\u000A());
			\u001A\u000C\u0018.\u000A(\u000A\u0015\u0018.\u0007(u0014_u), \u001D\u001A\u0018.\u000A(this));
			\u0010\u001A\u0018.\u000A(\u000A\u0015\u0018.\u0007(u0014_u), filePath);
			\u000D\u0014\u0019.\u000A(u0014_u, \u0010\u0014\u0019.\u0007(this.ActiveProgressBar));
			\u0001\u000C\u0018.\u000A(u0014_u, showPreview);
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u0014_u);
			\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\ViewModels\\Category\\CategoryBaseModel.cs", "GetData");
		}

		// Token: 0x060013AE RID: 5038 RVA: 0x0007DB6C File Offset: 0x0007BD6C
		protected void ShowReport(List<ProfileReport> reports)
		{
			if (\u001D\u0015\u0018.\u000A(reports) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.ShowReport(List<ProfileReport>)).MethodHandle;
				}
				ReportsWindow u001F = \u0003\u0018\u001D.\u000A(\u0007\u0015\u0018.\u000A(Enumerable.ToList<Report>(Enumerable.Cast<Report>(reports)), \u001E\u0011\u000A.\u000A(\u0004\u0002\u000E.\u001F()), 700), false);
				\u000C\u000E\u0007.\u0007(u001F, \u0018\u000B\u0007.\u0007(this));
				\u0018\u0020\u000A.\u0007(u001F);
			}
		}

		// Token: 0x060013AF RID: 5039 RVA: 0x0007DBE0 File Offset: 0x0007BDE0
		public void EnableIsolateElements(List<ICategoryModel> categories)
		{
			bool flag = false;
			bool flag2 = false;
			if (!\u0017\u000D.\u0016\u000A(this.ActiveDocument))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.EnableIsolateElements(List<ICategoryModel>)).MethodHandle;
				}
				\u0004\u0015\u0018.\u000A(this, false);
			}
			else
			{
				if (\u001D\u0013\u000A.\u000A(\u000F\u000B\u0004.\u0007(this.ActiveDocument)))
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
					flag2 = true;
				}
				else
				{
					flag2 = false;
				}
				if (categories != null)
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
					Func<ICategoryModel, bool> func;
					if ((func = CategoryBaseModel.<>c.\u0002) == null)
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
						func = (CategoryBaseModel.<>c.\u0002 = new Func<ICategoryModel, bool>(CategoryBaseModel.<>c.\u001F.\u001B));
					}
					if (Enumerable.Any<ICategoryModel>(categories, func))
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
						goto IL_A8;
					}
				}
				flag = false;
			}
			IL_A8:
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
				\u0004\u0015\u0018.\u000A(this, true);
				if (flag2)
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
					if (!\u0018\u0015\u0018.\u000A(this))
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
						\u0019\u0015\u0018.\u000A(this, true);
						return;
					}
				}
				if (!flag2)
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
					if (\u0018\u0015\u0018.\u000A(this))
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
						\u0019\u0015\u0018.\u000A(this, false);
						return;
					}
				}
			}
			else
			{
				\u0004\u0015\u0018.\u000A(this, false);
			}
		}

		// Token: 0x060013B0 RID: 5040 RVA: 0x0007DD04 File Offset: 0x0007BF04
		public void Isolate(View view, Window owner, List<ElementId> elementIds)
		{
			if (\u0018\u0015\u0018.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.Isolate(View, Window, List<ElementId>)).MethodHandle;
				}
				\u0017\u000D.\u000B\u000A(view, owner, elementIds);
				return;
			}
			\u0017\u000D.\u0002\u000A(view);
		}

		// Token: 0x060013B1 RID: 5041 RVA: 0x0007DD40 File Offset: 0x0007BF40
		public void SectionBox(List<Element> instances)
		{
			UIDocument u000A = \u001F\u0011\u0018.\u000A();
			if (!Enumerable.Any<Element>(instances))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.SectionBox(List<Element>)).MethodHandle;
				}
				\u0008\u0011\u001D.\u000A(\u0016\u0015\u0018.\u000A());
				return;
			}
			\u0005\u0015\u0018.\u000A("SheetLink", u000A, SectionBoxPluginOpened.FromPlugin, \u0010\u0011\u000A.\u000A(), instances, \u0018\u000B\u0007.\u0007(this));
		}

		// Token: 0x060013B2 RID: 5042 RVA: 0x0007DDA0 File Offset: 0x0007BFA0
		protected string GetFileName(List<ICategoryModel> categoryCollections)
		{
			string text2;
			try
			{
				string text;
				if (\u0006\u0015\u0018.\u000A(categoryCollections) <= 1)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.GetFileName(List<ICategoryModel>)).MethodHandle;
					}
					text = \u000B\u0015\u0018.\u000A(\u0002\u0015\u0018.\u000A(categoryCollections, 0));
				}
				else
				{
					text = this.ActiveDocument.\u001F();
				}
				text2 = text;
			}
			catch (Exception)
			{
				text2 = this.ActiveDocument.\u001F();
			}
			char[] array = \u0017\u0001\u0007.\u000A();
			for (int i = 0; i < (int)\u0014\u0007\u000E.\u001F(array); i++)
			{
				char c = array[i];
				string text3;
				if (text2 == null)
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
					text3 = \u000F\u0015\u0010.\u001F;
				}
				else
				{
					text3 = \u001C\u000B\u001D.\u001D(text2, \u001E\u000E\u0004.\u000A(ref c), "");
				}
				text2 = text3;
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
			return text2;
		}

		// Token: 0x060013B3 RID: 5043 RVA: 0x0007DE64 File Offset: 0x0007C064
		public virtual void CustomDispose()
		{
			\u000A\u000C\u0018.\u000A(this, \u0001\u000B\u000E.\u001F);
			this.ActiveDocument = \u0009\u000B\u000E.\u001F;
			\u0014\u000F yw = this.YW;
			if (yw == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryBaseModel.CustomDispose()).MethodHandle;
				}
			}
			else
			{
				yw.\u0003();
			}
			this.YW = \u001F\u0002\u000E.\u001F;
			\u001A\u001A\u0018.\u000A(this, \u000A\u0002\u000E.\u001F);
			this.ParametersModel = \u0007\u0002\u000E.\u001F;
			CustomProgressBar activeProgressBar = this.ActiveProgressBar;
			if (activeProgressBar == null)
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
			else
			{
				\u0018\u001A\u0019.\u000A(\u0010\u0014\u0019.\u001D(activeProgressBar), \u000D\u0018\u000E.\u001F);
			}
			this.ActiveProgressBar = \u001D\u0002\u000E.\u001F;
			\u000A\u000C\u0007.\u001D(this, \u000D\u0018\u000E.\u001F);
		}

		// Token: 0x060013B4 RID: 5044 RVA: 0x0007DF0C File Offset: 0x0007C10C
		[CompilerGenerated]
		private ObservableCollection<ICategoryModel> ZVR()
		{
			return \u001A\u0013\u0018.\u000A(this);
		}

		// Token: 0x060013B5 RID: 5045 RVA: 0x0007DF24 File Offset: 0x0007C124
		[CompilerGenerated]
		private bool XVR()
		{
			return \u000F\u0015\u0018.\u000A(this);
		}

		// Token: 0x060013B6 RID: 5046 RVA: 0x0007DF3C File Offset: 0x0007C13C
		[CompilerGenerated]
		private bool PVR()
		{
			return \u0018\u0015\u0018.\u000A(this);
		}

		// Token: 0x040007AC RID: 1964
		private ObservableCollection<ICategoryModel> IU;

		// Token: 0x040007AD RID: 1965
		private int SD;

		// Token: 0x040007AE RID: 1966
		private bool GU;

		// Token: 0x040007AF RID: 1967
		private bool FW;

		// Token: 0x040007B0 RID: 1968
		private string PB;

		// Token: 0x040007B1 RID: 1969
		private List<Element> RW;

		// Token: 0x040007B2 RID: 1970
		private bool OB;

		// Token: 0x040007B3 RID: 1971
		private bool DW;

		// Token: 0x040007B4 RID: 1972
		private bool HW;

		// Token: 0x040007B5 RID: 1973
		protected UIDocument ActiveDocument;

		// Token: 0x040007B6 RID: 1974
		internal \u0014\u000F YW;

		// Token: 0x040007B7 RID: 1975
		protected CustomProgressBar ActiveProgressBar;

		// Token: 0x040007B8 RID: 1976
		protected RevitParametersModel ParametersModel;

		// Token: 0x040007B9 RID: 1977
		[CompilerGenerated]
		private \u0015\u001C CW;

		// Token: 0x020008C1 RID: 2241
		[CompilerGenerated]
		private sealed class \u001A\u0012
		{
			// Token: 0x06005037 RID: 20535 RVA: 0x001E6914 File Offset: 0x001E4B14
			internal bool \u000A(ICategoryModel \u001F)
			{
				return \u0017\u001C\u0018.\u000A(\u001F) == \u0017\u001C\u0018.\u000A(this.\u001F);
			}

			// Token: 0x040022CB RID: 8907
			public ICategoryModel \u001F;
		}

		// Token: 0x020008C2 RID: 2242
		[CompilerGenerated]
		private sealed class \u000C\u0012
		{
			// Token: 0x06005039 RID: 20537 RVA: 0x001E694C File Offset: 0x001E4B4C
			internal bool \u000A(CategoryCollection \u001F)
			{
				return \u001F\u0020\u001D.\u000A(this.\u001F, \u0012\u001E\u0018.\u000A(\u001F));
			}

			// Token: 0x040022CC RID: 8908
			public List<string> \u001F;
		}

		// Token: 0x020008C3 RID: 2243
		[CompilerGenerated]
		private sealed class \u0015\u0012
		{
			// Token: 0x0600503B RID: 20539 RVA: 0x001E6984 File Offset: 0x001E4B84
			internal bool \u000A(RevitParameter \u001F)
			{
				return !\u001A\u0008\u0019.\u000A(this.\u001F, \u0017\u000B\u0018.\u0007(\u001F));
			}

			// Token: 0x0600503C RID: 20540 RVA: 0x001E69AC File Offset: 0x001E4BAC
			internal bool \u0007(RevitParameter \u001F)
			{
				return \u001A\u0008\u0019.\u000A(this.\u001F, \u0017\u000B\u0018.\u0007(\u001F));
			}

			// Token: 0x0600503D RID: 20541 RVA: 0x001E69D0 File Offset: 0x001E4BD0
			internal int \u001D(RevitParameter \u001F)
			{
				return \u0006\u0020\u000B.\u000A(this.\u001F, \u0017\u000B\u0018.\u0007(\u001F));
			}

			// Token: 0x040022CD RID: 8909
			public List<long> \u001F;
		}
	}
}

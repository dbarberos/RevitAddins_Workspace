using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.OneFilter.CommonLibrary.Messaging;
using DiRoots.One.OneFilter.CommonLibrary.Models;
using DiRoots.One.OneFilter.CommonLibrary.UI.Windows;
using SelectionsManager.Commands;
using SelectionsManager.ViewModels.Interfaces;

namespace SelectionsManager.ViewModels
{
	// Token: 0x02000023 RID: 35
	public class SavedSelectionsViewModel : ViewModelBase
	{
		// Token: 0x0600011B RID: 283 RVA: 0x0000686C File Offset: 0x00004A6C
		protected override void Finalize()
		{
			try
			{
				MonitorOnIdlingCommand.\u0006.\u001F -= this.BKR;
				MonitorOnIdlingCommand.\u0006.\u000A -= this.UKR;
			}
			finally
			{
				\u001E\u0017\u000A.\u000A(this);
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600011C RID: 284 RVA: 0x000068C0 File Offset: 0x00004AC0
		public CommandBase TopButtonCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.WKR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000068E8 File Offset: 0x00004AE8
		internal void AWR(UIDocument F)
		{
			this.R = \u0011\u0020\u000A.\u0007(F);
			this.D = F;
			IEnumerable<SavedSelectionItemViewModel> u001F = Enumerable.Select<SelectionFilterElement, SavedSelectionItemViewModel>(Enumerable.Cast<SelectionFilterElement>(\u0018\u000A.\u001F<SelectionFilterElement>(this.R)), new Func<SelectionFilterElement, SavedSelectionItemViewModel>(this.KKR));
			ObservableCollection<ISelectionItem> observableCollection = \u001B\u0020\u000A.\u000A(u001F);
			\u000E\u0020\u000A.\u000A(observableCollection, \u0001\u0017\u000A.\u000A());
			\u0015\u0017\u000A.\u000A(this, observableCollection);
			SavedSelectionItemViewModel.WZ();
			SavedSelectionItemViewModel.R += this.DeleteSelection;
			SelectionInfo.\u0004();
			List<SelectionInfo>.Enumerator enumerator = \u000C\u0017\u000A.\u000A(this.SKR(this.R));
			try
			{
				while (\u0017\u0017\u000A.\u000A(ref enumerator))
				{
					SelectionInfo selectionInfo = \u001A\u0017\u000A.\u000A(ref enumerator);
					if (!Enumerable.Contains<SelectionInfo>(\u0013\u0017\u000A.\u000A(), selectionInfo, new \u0007\u000A()))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionsViewModel.AWR(UIDocument)).MethodHandle;
						}
						\u0014\u0017\u000A.\u000A(\u0013\u0017\u000A.\u000A(), selectionInfo);
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
			\u0020\u0017\u000A.\u0007(this);
			MonitorOnIdlingCommand.\u0006.\u001F += this.BKR;
			MonitorOnIdlingCommand.\u0006.\u000A += this.UKR;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00006A2C File Offset: 0x00004C2C
		public void SubscribeToNewSelectionNotifiers()
		{
			\u0005\u001B\u000A.\u0018.\u001D<SelectionInfo>(this, new Action<SelectionInfo>(this.LKR), Context.NewSavedSelectionCreated);
			\u0005\u001B\u000A.\u0018.\u001D<SelectionInfo>(this, new Action<SelectionInfo>(this.CKR), Context.SavedSelectionUpdated);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00006A7C File Offset: 0x00004C7C
		private void CKR(SelectionInfo F)
		{
			SavedSelectionsViewModel.\u001F\u000A u001F_u000A = new SavedSelectionsViewModel.\u001F\u000A();
			u001F_u000A.\u001F = F;
			ISelectionItem selectionItem = Enumerable.FirstOrDefault<ISelectionItem>(\u001F\u0014\u000A.\u000A(this), new Func<ISelectionItem, bool>(u001F_u000A.\u000A));
			if (selectionItem != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionsViewModel.CKR(SelectionInfo)).MethodHandle;
				}
				int u000A = \u000A\u0014\u000A.\u000A(\u001F\u0014\u000A.\u000A(this), selectionItem);
				\u0013\u0020\u000A.\u000A(\u001F\u0014\u000A.\u000A(this), selectionItem);
				\u0019\u0017\u000A.\u000A(\u001F\u0014\u000A.\u000A(this), u000A, \u0009\u0017\u000A.\u000A(this.D, u001F_u000A.\u001F));
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00006B0C File Offset: 0x00004D0C
		private void LKR(SelectionInfo F)
		{
			if (F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionsViewModel.LKR(SelectionInfo)).MethodHandle;
				}
				\u0017\u0020\u000A.\u000A(\u001F\u0014\u000A.\u000A(this), \u0014\u0020\u000A.\u000A(\u001F\u0014\u000A.\u000A(this)) - 1);
				\u000E\u0020\u000A.\u000A(\u001F\u0014\u000A.\u000A(this), \u0009\u0017\u000A.\u000A(this.D, F));
				\u000E\u0020\u000A.\u000A(\u001F\u0014\u000A.\u000A(this), \u0001\u0017\u000A.\u000A());
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00006B7C File Offset: 0x00004D7C
		internal void HKR()
		{
			if (\u001F\u0014\u000A.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionsViewModel.HKR()).MethodHandle;
				}
				IEnumerator<SelectionFilterElement> enumerator = \u0004\u0014\u000A.\u000A(Enumerable.Cast<SelectionFilterElement>(\u0018\u000A.\u001F<SelectionFilterElement>(this.R)));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						SavedSelectionsViewModel.\u000A\u000A u000A_u000A = new SavedSelectionsViewModel.\u000A\u000A();
						u000A_u000A.\u001F = \u001D\u0014\u000A.\u000A(enumerator);
						ISelectionItem u001F = \u0006\u0015\u0010.\u001F;
						if (!Enumerable.Any<ISelectionItem>(\u001F\u0014\u000A.\u000A(this), new Func<ISelectionItem, bool>(u000A_u000A.\u000A)))
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
							\u0019\u0017\u000A.\u000A(\u001F\u0014\u000A.\u000A(this), \u0014\u0020\u000A.\u000A(\u001F\u0014\u000A.\u000A(this)) - 1, \u0007\u0014\u000A.\u000A(this.D, u000A_u000A.\u001F));
						}
						else if ((u001F = Enumerable.FirstOrDefault<ISelectionItem>(\u001F\u0014\u000A.\u000A(this), new Func<ISelectionItem, bool>(u000A_u000A.\u0007))) != null)
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
							if (\u001D\u0017\u000A.\u000A(\u0004\u0017\u000A.\u000A(u001F), \u0005\u001E\u000A.\u000A(u000A_u000A.\u001F)))
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
								\u0007\u0017\u000A.\u000A(u001F, \u0005\u001E\u000A.\u000A(u000A_u000A.\u001F));
							}
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
					if (enumerator != null)
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
				List<ISelectionItem>.Enumerator enumerator2 = \u0009\u0020\u000A.\u000A(Enumerable.ToList<ISelectionItem>(\u001F\u0014\u000A.\u000A(this)));
				try
				{
					while (\u001A\u0020\u000A.\u000A(ref enumerator2))
					{
						ISelectionItem selectionItem = \u0001\u0020\u000A.\u000A(ref enumerator2);
						if (\u0015\u0020\u000A.\u000A(selectionItem) != null)
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
							if (!\u000C\u0020\u000A.\u0007(\u0015\u0020\u000A.\u000A(selectionItem)))
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
								\u0013\u0020\u000A.\u000A(\u001F\u0014\u000A.\u000A(this), selectionItem);
							}
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
					((IDisposable)enumerator2).Dispose();
				}
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00006D78 File Offset: 0x00004F78
		private List<SelectionInfo> SKR(Document F)
		{
			List<SelectionInfo> list = \u000F\u0014\u000A.\u000A();
			IEnumerator<SavedSelectionItemViewModel> enumerator = \u0006\u0014\u000A.\u000A(Enumerable.OfType<SavedSelectionItemViewModel>(\u001F\u0014\u000A.\u000A(this)));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SavedSelectionItemViewModel u001F = \u0002\u0014\u000A.\u000A(enumerator);
					SelectionInfo selectionInfo = \u000B\u0014\u000A.\u000A();
					\u0016\u0014\u000A.\u000A(selectionInfo, \u0012\u0020\u000A.\u001D(u001F));
					\u0018\u0014\u000A.\u000A(selectionInfo, \u0005\u0014\u000A.\u000A(u001F));
					SelectionInfo u000A = selectionInfo;
					\u0019\u0014\u000A.\u000A(list, u000A);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionsViewModel.SKR(Document)).MethodHandle;
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return list;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00006E20 File Offset: 0x00005020
		public void DeleteSelection(ISelectionItem item)
		{
			if (item != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionsViewModel.DeleteSelection(ISelectionItem)).MethodHandle;
				}
				if (\u001F\u0014\u000A.\u000A(this) != null)
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
					\u0013\u0020\u000A.\u000A(\u001F\u0014\u000A.\u000A(this), item);
				}
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00006E68 File Offset: 0x00005068
		internal void BKR(object F, EventArgs R)
		{
			\u0012\u0014\u000A.\u000A(this, true);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00006E7C File Offset: 0x0000507C
		internal void UKR(object F, EventArgs R)
		{
			\u0012\u0014\u000A.\u000A(this, false);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00006E90 File Offset: 0x00005090
		private void WKR()
		{
			this.R = \u0011\u0020\u000A.\u0007(this.D);
			IEnumerable<ISelectionItem> enumerable = \u001F\u0014\u000A.\u000A(this);
			Func<ISelectionItem, bool> func;
			if ((func = SavedSelectionsViewModel.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionsViewModel.WKR()).MethodHandle;
				}
				func = (SavedSelectionsViewModel.<>c.\u000A = new Func<ISelectionItem, bool>(SavedSelectionsViewModel.<>c.\u001F.\u001D));
			}
			IEnumerable<ISelectionItem> enumerable2 = Enumerable.Where<ISelectionItem>(enumerable, func);
			Func<ISelectionItem, string> func2;
			if ((func2 = SavedSelectionsViewModel.<>c.\u0007) == null)
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
				func2 = (SavedSelectionsViewModel.<>c.\u0007 = new Func<ISelectionItem, string>(SavedSelectionsViewModel.<>c.\u001F.\u0004));
			}
			List<string> u000A = Enumerable.ToList<string>(Enumerable.Select<ISelectionItem, string>(enumerable2, func2));
			UI_NewName ui_NewName = \u0017\u0014\u000A.\u000A(this.R, u000A);
			\u0020\u0014\u000A.\u0007(ui_NewName, WindowStartupLocation.CenterScreen);
			UI_NewName u001F = ui_NewName;
			bool? flag = \u0018\u0020\u000A.\u0007(u001F);
			if (\u0019\u0020\u000A.\u000A(ref flag))
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
				SelectionInfo selectionInfo = \u000B\u0014\u000A.\u000A();
				\u0018\u0014\u000A.\u000A(selectionInfo, \u001E\u0014\u000A.\u0007(u001F));
				SelectionInfo u000A2 = selectionInfo;
				if (\u0008\u0014\u000A.\u000A(u001F) == SavingMode.Save)
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
					\u0007\u001C\u000A u0007_u001C_u000A = new \u0007\u001C\u000A();
					\u0011\u0014\u000A.\u000A(u0007_u001C_u000A, u000A2);
					\u001B\u0014\u000A.\u000A(u0007_u001C_u000A, Enumerable.ToList<ElementId>(\u001C\u0014\u000A.\u000A(\u0010\u001E\u000A.\u0007(\u000D\u0014\u000A.\u0007(\u0010\u0014\u000A.\u000A())))));
					\u0007\u001C\u000A u000A3 = u0007_u001C_u000A;
					\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000A3);
					\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
				}
				else if (\u0008\u0014\u000A.\u000A(u001F) == SavingMode.Update)
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
					\u001D\u001C\u000A u001D_u001C_u000A = new \u001D\u001C\u000A();
					\u000E\u0014\u000A.\u000A(u001D_u001C_u000A, u000A2);
					\u0003\u0014\u000A.\u000A(u001D_u001C_u000A, Enumerable.ToList<ElementId>(\u001C\u0014\u000A.\u000A(\u0010\u001E\u000A.\u0007(\u000D\u0014\u000A.\u0007(\u0010\u0014\u000A.\u000A())))));
					\u001D\u001C\u000A u000A4 = u001D_u001C_u000A;
					\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000A4);
					\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
				}
				\u000B\u0020\u000A.\u000A(\u0002\u0020\u000A.\u000A());
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00007058 File Offset: 0x00005258
		// (set) Token: 0x06000128 RID: 296 RVA: 0x0000706C File Offset: 0x0000526C
		public ObservableCollection<ISelectionItem> Items
		{
			get
			{
				return this.C;
			}
			set
			{
				this.C = value;
				\u000D\u0020\u000A.\u000A(this, "Items");
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000129 RID: 297 RVA: 0x0000708C File Offset: 0x0000528C
		// (set) Token: 0x0600012A RID: 298 RVA: 0x000070A0 File Offset: 0x000052A0
		public bool NewSelectionEnabled
		{
			get
			{
				return this.L;
			}
			set
			{
				this.L = value;
				\u000D\u0020\u000A.\u000A(this, "NewSelectionEnabled");
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600012B RID: 299 RVA: 0x000070C0 File Offset: 0x000052C0
		// (set) Token: 0x0600012C RID: 300 RVA: 0x000070D4 File Offset: 0x000052D4
		public bool IsButtonVisible
		{
			get
			{
				return this.H;
			}
			set
			{
				this.H = value;
				\u000D\u0020\u000A.\u000A(this, "IsButtonVisible");
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x000070F4 File Offset: 0x000052F4
		[CompilerGenerated]
		private SavedSelectionItemViewModel KKR(SelectionFilterElement F)
		{
			return \u0007\u0014\u000A.\u000A(this.D, F);
		}

		// Token: 0x04000066 RID: 102
		private ObservableCollection<ISelectionItem> C;

		// Token: 0x04000067 RID: 103
		private Document R;

		// Token: 0x04000068 RID: 104
		private UIDocument D;

		// Token: 0x04000069 RID: 105
		private bool L;

		// Token: 0x0400006A RID: 106
		private bool H;

		// Token: 0x0200076D RID: 1901
		[CompilerGenerated]
		private sealed class \u001F\u000A
		{
			// Token: 0x06004AB1 RID: 19121 RVA: 0x001D7828 File Offset: 0x001D5A28
			internal bool \u000A(ISelectionItem \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0004\u0017\u000A.\u000A(\u001F), \u0002\u0017\u000A.\u000A(this.\u001F));
			}

			// Token: 0x04001DE5 RID: 7653
			public SelectionInfo \u001F;
		}

		// Token: 0x0200076E RID: 1902
		[CompilerGenerated]
		private sealed class \u000A\u000A
		{
			// Token: 0x06004AB3 RID: 19123 RVA: 0x001D7868 File Offset: 0x001D5A68
			internal bool \u000A(ISelectionItem \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(this.\u001F)) == \u0020\u0001\u000A.\u000A(\u001F);
			}

			// Token: 0x06004AB4 RID: 19124 RVA: 0x001D7894 File Offset: 0x001D5A94
			internal bool \u0007(ISelectionItem \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(this.\u001F)) == \u0020\u0001\u000A.\u000A(\u001F);
			}

			// Token: 0x04001DE6 RID: 7654
			public SelectionFilterElement \u001F;
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.ViewModels;
using ProSheets.Extensions;
using ProSheets.Models;

namespace DiRoots.ProSheets.ViewModels
{
	// Token: 0x0200002E RID: 46
	public class BaseViewModel : ViewModelBase
	{
		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00009A80 File Offset: 0x00007C80
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x00009A94 File Offset: 0x00007C94
		public Predicate<SheetInfo> Filter { get; set; }

		// Token: 0x060001A4 RID: 420 RVA: 0x00009AA8 File Offset: 0x00007CA8
		public void Initialize(List<SheetInfo> sheetInfo, Predicate<object> filter = null)
		{
			\u0016\u0005\u0018.\u0018(this, \u0010\u0006\u0018.\u0018(sheetInfo));
			ICollectionView u000C = \u0003\u0005\u0018.\u0014(this);
			\u0005\u0006\u0018.\u0018(u000C, \u0007\u0004\u000F.\u000C(\u001C\u0019\u0018.\u0018(\u000E\u0006\u0018.\u0018(u000C), filter)));
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00009AE8 File Offset: 0x00007CE8
		[BindableMethod("OpenSheetViews")]
		public void OpenSheet()
		{
			if (\u0012\u0005\u0018.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BaseViewModel.OpenSheet()).MethodHandle;
				}
				if (Enumerable.Any<SheetInfo>(\u0012\u0005\u0018.\u0018(this)))
				{
					\u000F\u0005\u0018.\u0018(this, \u0012\u0005\u0018.\u0018(this));
					return;
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
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00009B3C File Offset: 0x00007D3C
		[BindableMethod("SelectSheetViews")]
		public void SelectSheet(bool isChecked)
		{
			if (Enumerable.Any<SheetInfo>(\u0012\u0005\u0018.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BaseViewModel.SelectSheet(bool)).MethodHandle;
				}
				IEnumerator<SheetInfo> enumerator = \u0009\u0005\u0018.\u0018(\u0012\u0005\u0018.\u0018(this));
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						\u001C\u0005\u0018.\u0018(\u0013\u0005\u0018.\u0018(enumerator), isChecked);
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
							switch (7)
							{
							case 0:
								continue;
							}
							break;
						}
						\u0020\u001E\u0018.\u0018(enumerator);
					}
				}
			}
			\u000D\u0005\u0018.\u0014(this);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00009BD0 File Offset: 0x00007DD0
		[BindableMethod("SelectingAllSheetsViews")]
		public void SelectingAllSheets(bool isAllChecked)
		{
			List<SheetInfo> u = Enumerable.ToList<SheetInfo>(Enumerable.Cast<SheetInfo>(\u0003\u0005\u0018.\u0014(this)));
			\u000A\u0005\u0018.\u0018(this, u, isAllChecked);
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00009BFC File Offset: 0x00007DFC
		public void SelectAll(List<SheetInfo> item, bool isChecked)
		{
			BaseViewModel.\u0018\u0009\u0018 u0018_u0009_u = new BaseViewModel.\u0018\u0009\u0018();
			u0018_u0009_u.\u000C = isChecked;
			\u0020\u0005\u0018.\u0018(Enumerable.ToList<SheetInfo>(item), new Action<SheetInfo>(u0018_u0009_u.\u0018));
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00009C30 File Offset: 0x00007E30
		[BindableMethod("RefreshItems")]
		public void RefreshItems()
		{
			if (\u0003\u0005\u0018.\u0014(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BaseViewModel.RefreshItems()).MethodHandle;
				}
				\u001D\u0008\u0018.\u0018(\u0003\u0005\u0018.\u0014(this));
				\u000D\u0005\u0018.\u0014(this);
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00009C70 File Offset: 0x00007E70
		public void OpenViewSheet(IList<SheetInfo> info)
		{
			IEnumerator<SheetInfo> enumerator = \u0009\u0005\u0018.\u0018(info);
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					SheetInfo u000C = \u0013\u0005\u0018.\u0018(enumerator);
					Element element = \u000F\u000A\u0018.\u001F\u0018(\u0017\u0005\u0018.\u0014(\u0011\u0005\u0018.\u0018()), \u0015\u0005\u0018.\u0014(u000C).\u000C());
					if (element != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(BaseViewModel.OpenViewSheet(IList<SheetInfo>)).MethodHandle;
						}
						\u001F\u0005\u0018.\u0018(\u0011\u0005\u0018.\u0018(), \u0018\u0002\u000F.\u000C(element));
					}
					else
					{
						\u0002\u001D\u0018.\u0018(\u001C\u001E\u0018.\u0018(\u001C\u0009\u0018.\u0005, "Sheet"), 350.0);
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
					\u0020\u001E\u0018.\u0018(enumerator);
				}
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00009D48 File Offset: 0x00007F48
		public void CheckAllSelect()
		{
			List<SheetInfo> list = Enumerable.ToList<SheetInfo>(Enumerable.Cast<SheetInfo>(\u0003\u0005\u0018.\u0014(this)));
			if (\u0002\u0005\u0018.\u0018(list) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BaseViewModel.CheckAllSelect()).MethodHandle;
				}
				\u001E\u0005\u0018.\u0014(this, new bool?(false));
				return;
			}
			IEnumerable<SheetInfo> enumerable = list;
			Func<SheetInfo, bool> func;
			if ((func = BaseViewModel.<>c.\u0018) == null)
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
				func = (BaseViewModel.<>c.\u0018 = new Func<SheetInfo, bool>(BaseViewModel.<>c.\u000C.\u0003));
			}
			if (Enumerable.All<SheetInfo>(enumerable, func))
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
				\u001E\u0005\u0018.\u0014(this, new bool?(true));
				return;
			}
			IEnumerable<SheetInfo> enumerable2 = list;
			Func<SheetInfo, bool> func2;
			if ((func2 = BaseViewModel.<>c.\u0014) == null)
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
				func2 = (BaseViewModel.<>c.\u0014 = new Func<SheetInfo, bool>(BaseViewModel.<>c.\u000C.\u0016));
			}
			bool? u;
			if (!Enumerable.Any<SheetInfo>(enumerable2, func2))
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
				u = new bool?(false);
			}
			else
			{
				bool? flag;
				\u000B\u0004\u000F.\u000C(ref flag);
				u = flag;
			}
			\u001E\u0005\u0018.\u0014(this, u);
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001AC RID: 428 RVA: 0x00009E34 File Offset: 0x00008034
		// (set) Token: 0x060001AD RID: 429 RVA: 0x00009E48 File Offset: 0x00008048
		public IList<SheetInfo> SelectItems
		{
			get
			{
				return this.\u0002\u0018;
			}
			set
			{
				this.\u0002\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectItems");
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00009E68 File Offset: 0x00008068
		public bool IsContains(string inputValue, string searchText)
		{
			if (!\u001F\u001A\u0018.\u0018(inputValue))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BaseViewModel.IsContains(string, string)).MethodHandle;
				}
				if (\u001B\u0013\u0018.\u000C(inputValue, searchText))
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
					return true;
				}
			}
			return false;
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001AF RID: 431 RVA: 0x00009EAC File Offset: 0x000080AC
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x00009EC0 File Offset: 0x000080C0
		public ICollectionView Items
		{
			get
			{
				return this.\u000F\u0018;
			}
			set
			{
				this.\u000F\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "Items");
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00009EE0 File Offset: 0x000080E0
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x00009EF4 File Offset: 0x000080F4
		public bool? IsAllChecked
		{
			get
			{
				return this.\u001E\u0018;
			}
			set
			{
				this.\u001E\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "IsAllChecked");
			}
		}

		// Token: 0x040000DC RID: 220
		private bool? \u001E\u0018 = new bool?(false);

		// Token: 0x040000DD RID: 221
		private ICollectionView \u000F\u0018;

		// Token: 0x040000DE RID: 222
		private IList<SheetInfo> \u0002\u0018;

		// Token: 0x040000DF RID: 223
		[CompilerGenerated]
		private Predicate<SheetInfo> \u0006;

		// Token: 0x0200015E RID: 350
		[CompilerGenerated]
		private sealed class \u0018\u0009\u0018
		{
			// Token: 0x06001050 RID: 4176 RVA: 0x0005A504 File Offset: 0x00058704
			internal void \u0018(SheetInfo \u000C)
			{
				\u001C\u0005\u0018.\u0018(\u000C, this.\u000C);
			}

			// Token: 0x0400077E RID: 1918
			public bool \u000C;
		}
	}
}

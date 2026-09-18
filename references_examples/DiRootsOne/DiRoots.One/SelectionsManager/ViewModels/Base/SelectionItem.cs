using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Models;
using DiRoots.One.UIBehaviours.Extensions;
using SelectionsManager.ViewModels.Interfaces;

namespace SelectionsManager.ViewModels.Base
{
	// Token: 0x02000027 RID: 39
	public class SelectionItem : ModelBase, ISelectionItem
	{
		// Token: 0x0600013F RID: 319 RVA: 0x0000752C File Offset: 0x0000572C
		public SelectionItem()
		{
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00007554 File Offset: 0x00005754
		public SelectionItem(UIDocument uidoc)
		{
			this._doc = \u0011\u0020\u000A.\u0007(uidoc);
			this._uidoc = uidoc;
			\u001F\u0013\u000A.\u000A(this, \u000A\u0013\u000A.\u000A());
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000141 RID: 321 RVA: 0x000075A0 File Offset: 0x000057A0
		// (set) Token: 0x06000142 RID: 322 RVA: 0x000075B4 File Offset: 0x000057B4
		public bool IsIsolate
		{
			get
			{
				return this.S;
			}
			set
			{
				this.S = value;
				\u0007\u0013\u000A.\u000A(this, "IsIsolate");
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000143 RID: 323 RVA: 0x000075D4 File Offset: 0x000057D4
		// (set) Token: 0x06000144 RID: 324 RVA: 0x000075E8 File Offset: 0x000057E8
		public bool IsHide
		{
			get
			{
				return this.B;
			}
			set
			{
				this.B = value;
				\u0007\u0013\u000A.\u000A(this, "IsHide");
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00007608 File Offset: 0x00005808
		// (set) Token: 0x06000146 RID: 326 RVA: 0x0000761C File Offset: 0x0000581C
		public string IsolateMenuItemLabel
		{
			get
			{
				return this._isolateMenuItemLabel;
			}
			set
			{
				this._isolateMenuItemLabel = value;
				\u0007\u0013\u000A.\u000A(this, "IsolateMenuItemLabel");
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000147 RID: 327 RVA: 0x0000763C File Offset: 0x0000583C
		// (set) Token: 0x06000148 RID: 328 RVA: 0x00007650 File Offset: 0x00005850
		public string ItemLabel { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00007664 File Offset: 0x00005864
		// (set) Token: 0x0600014A RID: 330 RVA: 0x00007678 File Offset: 0x00005878
		public long Id { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600014B RID: 331 RVA: 0x0000768C File Offset: 0x0000588C
		// (set) Token: 0x0600014C RID: 332 RVA: 0x000076A0 File Offset: 0x000058A0
		public string Name { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600014D RID: 333 RVA: 0x000076B4 File Offset: 0x000058B4
		// (set) Token: 0x0600014E RID: 334 RVA: 0x000076C8 File Offset: 0x000058C8
		public bool ArrowChecked
		{
			get
			{
				return this._arrowChecked;
			}
			set
			{
				this._arrowChecked = value;
				\u0007\u0013\u000A.\u000A(this, "ArrowChecked");
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600014F RID: 335 RVA: 0x000076E8 File Offset: 0x000058E8
		// (set) Token: 0x06000150 RID: 336 RVA: 0x000076FC File Offset: 0x000058FC
		public bool IsVisible
		{
			get
			{
				return this._isVisible;
			}
			set
			{
				this._isVisible = value;
				\u0007\u0013\u000A.\u000A(this, "ArrowChecked");
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000151 RID: 337 RVA: 0x0000771C File Offset: 0x0000591C
		// (set) Token: 0x06000152 RID: 338 RVA: 0x00007730 File Offset: 0x00005930
		public List<SelectedElementsBagViewModel> SelectedElements
		{
			get
			{
				return this._selectedElements;
			}
			set
			{
				this._selectedElements = value;
				\u0007\u0013\u000A.\u000A(this, "SelectedElements");
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000153 RID: 339 RVA: 0x00007750 File Offset: 0x00005950
		// (set) Token: 0x06000154 RID: 340 RVA: 0x00007764 File Offset: 0x00005964
		public Element Element { get; set; }

		// Token: 0x06000155 RID: 341 RVA: 0x00007778 File Offset: 0x00005978
		[BindableMethod("ContextMenuOpening")]
		public void ContextMenuOpening(object selectedItems, ContextMenuEventArgs e)
		{
			IList u001F = \u000D\u0015\u0010.\u001F(selectedItems);
			if (this._isMouseRightBouttonDown)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionItem.ContextMenuOpening(object, ContextMenuEventArgs)).MethodHandle;
				}
				if (\u0018\u0013\u000A.\u000A(u001F) != 0)
				{
					goto IL_3F;
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
			\u0019\u0013\u000A.\u000A(e, true);
			IL_3F:
			this._isMouseRightBouttonDown = false;
			if (!\u001D\u0013\u000A.\u000A(\u0004\u0013\u000A.\u0007(this._doc)))
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
				this.toggleMenuIsolation = true;
				\u001F\u0013\u000A.\u000A(this, \u000A\u0013\u000A.\u000A());
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00007800 File Offset: 0x00005A00
		[BindableMethod("MouseRightDown")]
		public void MouseRightDown()
		{
			this._isMouseRightBouttonDown = true;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00007814 File Offset: 0x00005A14
		[BindableMethod("IsolateHighlightedItems")]
		public void IsolateHighlightedItems(object selectedItems)
		{
			if (this.toggleMenuIsolation)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionItem.IsolateHighlightedItems(object)).MethodHandle;
				}
				if (\u001D\u0013\u000A.\u000A(\u0004\u0013\u000A.\u0007(this._doc)))
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
					\u000D\u0013\u000A.\u000A(\u0004\u0013\u000A.\u0007(this._doc), 2);
				}
				object u001F = \u000D\u0015\u0010.\u001F(selectedItems);
				List<ElementId> list = \u001C\u0013\u000A.\u000A();
				IEnumerator u001F2 = \u001D\u0011\u000A.\u000A(u001F);
				try
				{
					while (\u000A\u0017\u000A.\u000A(u001F2))
					{
						object u001F3 = \u0003\u0013\u000A.\u000A(u001F2);
						\u000F\u0013\u000A.\u000A(list, \u0012\u0013\u000A.\u000A(\u0008\u0015\u0010.\u001F(u001F3)));
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
					IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F2);
					if (disposable != null)
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
						\u001F\u0017\u000A.\u000A(disposable);
					}
				}
				List<ElementId> list2 = Enumerable.ToList<ElementId>(Enumerable.Where<ElementId>(list, new Func<ElementId, bool>(this.TZ)));
				list = Enumerable.ToList<ElementId>(Enumerable.Except<ElementId>(list, list2));
				string u001F4 = "";
				if (\u001A\u0014\u000A.\u000A(list2) > 0)
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
					u001F4 = \u0002\u0013\u000A.\u000A(u001F4, \u0006\u0013\u000A.\u000A(), " ");
					if (\u001A\u0014\u000A.\u000A(list) == 0)
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
						list = \u001B\u0015\u0010.\u001F;
					}
				}
				if (list != null)
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
					if (\u001A\u0014\u000A.\u000A(list) > 0)
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
						if (\u001A\u0014\u000A.\u000A(list2) > 0)
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
							\u0005\u0013\u000A.\u000A(u001F4, 250.0);
						}
						\u0005\u001C\u000A u0005_u001C_u000A = new \u0005\u001C\u000A();
						\u000B\u0013\u000A.\u000A(u0005_u001C_u000A, list);
						\u0005\u001C\u000A u0005_u001C_u000A2 = u0005_u001C_u000A;
						\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u0005_u001C_u000A2);
						u0005_u001C_u000A2.\u001F += this.IsolteHighlightedFinished;
						\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
						return;
					}
				}
				u001F4 = \u0004\u001E\u000A.\u000A(u001F4, \u0016\u0013\u000A.\u000A());
				\u0005\u0013\u000A.\u000A(u001F4, 250.0);
				return;
			}
			\u0019\u001C\u000A u0019_u001C_u000A = new \u0019\u001C\u000A();
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u0019_u001C_u000A);
			u0019_u001C_u000A.\u001F += this.IsolteHighlightedFinished;
			\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00007A50 File Offset: 0x00005C50
		public void IsolteHighlightedFinished()
		{
			this.toggleMenuIsolation = !this.toggleMenuIsolation;
			if (this.toggleMenuIsolation)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionItem.IsolteHighlightedFinished()).MethodHandle;
				}
				\u001F\u0013\u000A.\u000A(this, \u000A\u0013\u000A.\u000A());
				return;
			}
			\u001F\u0013\u000A.\u000A(this, \u0010\u0013\u000A.\u000A());
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00007AA4 File Offset: 0x00005CA4
		[BindableMethod("SelectHighlightedItems")]
		public void SelectHighlightedItems(object selectedItems)
		{
			List<ElementId> list = \u001C\u0013\u000A.\u000A();
			IEnumerator u001F = \u001D\u0011\u000A.\u000A(\u000D\u0015\u0010.\u001F(selectedItems));
			try
			{
				while (\u000A\u0017\u000A.\u000A(u001F))
				{
					SelectedElementsBagViewModel u001F2 = \u0010\u0015\u0010.\u001F(\u0003\u0013\u000A.\u000A(u001F));
					\u000F\u0013\u000A.\u000A(list, \u0012\u0013\u000A.\u000A(u001F2));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionItem.SelectHighlightedItems(object)).MethodHandle;
				}
			}
			finally
			{
				IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
				if (disposable != null)
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
					\u001F\u0017\u000A.\u000A(disposable);
				}
			}
			try
			{
				if (\u001A\u0014\u000A.\u000A(list) > 0)
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
					\u000D\u001E\u000A.\u000A(\u0010\u001E\u000A.\u0007(this._uidoc), list);
				}
			}
			catch (Exception u001F3)
			{
				\u000A\u0006\u000A.\u001F(u001F3);
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00007B74 File Offset: 0x00005D74
		[BindableMethod("ShowHighlightedItems")]
		public void ShowHighlightedItems(object selectedItems)
		{
			List<ElementId> list = \u001C\u0013\u000A.\u000A();
			IEnumerator u001F = \u001D\u0011\u000A.\u000A(\u000D\u0015\u0010.\u001F(selectedItems));
			try
			{
				while (\u000A\u0017\u000A.\u000A(u001F))
				{
					SelectedElementsBagViewModel u001F2 = \u0010\u0015\u0010.\u001F(\u0003\u0013\u000A.\u000A(u001F));
					\u000F\u0013\u000A.\u000A(list, \u0012\u0013\u000A.\u000A(u001F2));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionItem.ShowHighlightedItems(object)).MethodHandle;
				}
			}
			finally
			{
				IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
				if (disposable != null)
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
					\u001F\u0017\u000A.\u000A(disposable);
				}
			}
			try
			{
				if (\u001A\u0014\u000A.\u000A(list) > 0)
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
					\u000D\u001E\u000A.\u000A(\u0010\u001E\u000A.\u0007(this._uidoc), list);
					\u000E\u0013\u000A.\u000A(this._uidoc, list);
				}
			}
			catch (Exception u001F3)
			{
				\u000A\u0006\u000A.\u001F(u001F3);
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00007C50 File Offset: 0x00005E50
		[CompilerGenerated]
		private bool TZ(ElementId F)
		{
			return \u0003\u0015\u0010.\u001F(\u0011\u0017\u000A.\u0007(this._doc, F)) != \u001C\u0015\u0010.\u001F;
		}

		// Token: 0x04000086 RID: 134
		protected bool _arrowChecked;

		// Token: 0x04000087 RID: 135
		protected List<SelectedElementsBagViewModel> _selectedElements;

		// Token: 0x04000088 RID: 136
		protected bool _isVisible;

		// Token: 0x04000089 RID: 137
		protected bool toggleMenuIsolation = true;

		// Token: 0x0400008A RID: 138
		protected string _isolateMenuItemLabel;

		// Token: 0x0400008B RID: 139
		protected bool _isMouseRightBouttonDown;

		// Token: 0x0400008C RID: 140
		protected Document _doc;

		// Token: 0x0400008D RID: 141
		protected UIDocument _uidoc;

		// Token: 0x0400008E RID: 142
		private bool S = true;

		// Token: 0x0400008F RID: 143
		private bool B = true;

		// Token: 0x04000090 RID: 144
		[CompilerGenerated]
		private string U;

		// Token: 0x04000091 RID: 145
		[CompilerGenerated]
		private long W;

		// Token: 0x04000092 RID: 146
		[CompilerGenerated]
		private string K;

		// Token: 0x04000093 RID: 147
		[CompilerGenerated]
		private Element J;
	}
}

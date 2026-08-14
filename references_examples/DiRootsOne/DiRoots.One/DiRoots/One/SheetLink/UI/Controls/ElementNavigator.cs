using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.SheetLink.Enums;

namespace DiRoots.One.SheetLink.UI.Controls
{
	// Token: 0x02000220 RID: 544
	public class ElementNavigator : UserControl, IComponentConnector, IStyleConnector
	{
		// Token: 0x06001507 RID: 5383 RVA: 0x000891D4 File Offset: 0x000873D4
		public ElementNavigator()
		{
			\u000B\u0019\u0005.\u000A(this);
			\u0016\u0019\u0005.\u000A(this, new ObservableCollection<ICategoryModel>());
		}

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06001509 RID: 5385 RVA: 0x00089248 File Offset: 0x00087448
		// (remove) Token: 0x0600150A RID: 5386 RVA: 0x00089298 File Offset: 0x00087498
		public event EventHandler CheckedChangedEvent
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.F;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = \u0017\u0015\u0010.\u001F(\u000F\u001E\u000A.\u000A(eventHandler2, value));
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.F, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.add_CheckedChangedEvent(EventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.F;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = \u0017\u0015\u0010.\u001F(\u0012\u001E\u000A.\u000A(eventHandler2, value));
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.F, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.remove_CheckedChangedEvent(EventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x0600150B RID: 5387 RVA: 0x000892E8 File Offset: 0x000874E8
		// (set) Token: 0x0600150C RID: 5388 RVA: 0x000892FC File Offset: 0x000874FC
		public ElementNavigator.ContextMenuDelegate ContextMenuHandler { get; set; }

		// Token: 0x170005E4 RID: 1508
		// (get) Token: 0x0600150D RID: 5389 RVA: 0x00089310 File Offset: 0x00087510
		// (set) Token: 0x0600150E RID: 5390 RVA: 0x00089324 File Offset: 0x00087524
		public UIDocument ActiveDocument { get; set; }

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x0600150F RID: 5391 RVA: 0x00089338 File Offset: 0x00087538
		// (set) Token: 0x06001510 RID: 5392 RVA: 0x0008935C File Offset: 0x0008755C
		public ObservableCollection<ICategoryModel> ItemSource
		{
			get
			{
				return \u0010\u0006\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, ElementNavigator.ItemSourceProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, ElementNavigator.ItemSourceProperty, value);
			}
		}

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x06001511 RID: 5393 RVA: 0x00089378 File Offset: 0x00087578
		// (set) Token: 0x06001512 RID: 5394 RVA: 0x0008938C File Offset: 0x0008758C
		public ObservableCollection<ICategoryModel> SelectedItems { get; set; }

		// Token: 0x06001513 RID: 5395 RVA: 0x000893A0 File Offset: 0x000875A0
		private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ElementNavigator elementNavigator = \u0011\u0006\u000E.\u001F(d);
			if (elementNavigator != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.OnSourceChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				if (\u0002\u0019\u0005.\u0007(elementNavigator) != null)
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
					ICollectionView collectionView = \u0011\u0009\u000A.\u000A(\u0002\u0019\u0005.\u0007(elementNavigator));
					\u0005\u0008\u0007.\u000A(collectionView, new Predicate<object>(elementNavigator.E));
					\u0018\u000C\u0007.\u000A(elementNavigator.B, collectionView);
					elementNavigator.M();
				}
			}
		}

		// Token: 0x06001514 RID: 5396 RVA: 0x00089414 File Offset: 0x00087614
		private void CheckBox_Click(object sender, RoutedEventArgs e)
		{
			this.N(sender);
		}

		// Token: 0x06001515 RID: 5397 RVA: 0x00089428 File Offset: 0x00087628
		private void txtSearchFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (\u001E\u0009\u000A.\u0007(this.B) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.txtSearchFilter_TextChanged(object, TextChangedEventArgs)).MethodHandle;
				}
				return;
			}
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.B)));
			this.M();
		}

		// Token: 0x06001516 RID: 5398 RVA: 0x00089478 File Offset: 0x00087678
		private void chkSelectAll_Click(object sender, RoutedEventArgs e)
		{
			if (\u001E\u0009\u000A.\u0007(this.B) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.chkSelectAll_Click(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			CheckBox checkBox = \u0011\u000A\u000E.\u001F(sender);
			if (checkBox != null)
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
				bool? flag = \u0003\u0015\u000A.\u000A(checkBox);
				bool u000A = \u0012\u0015\u000A.\u000A(ref flag);
				IEnumerator u001F = \u001D\u0011\u000A.\u000A(\u0010\u000C\u0007.\u000A(this.B));
				try
				{
					while (\u000A\u0017\u000A.\u000A(u001F))
					{
						ICategoryModel categoryModel = \u001C\u0006\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F));
						if (categoryModel != null)
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
							\u0013\u0013\u0018.\u000A(categoryModel, u000A);
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
					IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
					if (disposable != null)
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
						\u001F\u0017\u000A.\u000A(disposable);
					}
				}
				IEnumerable<ICategoryModel> enumerable = \u0002\u0019\u0005.\u001D(this);
				Func<ICategoryModel, bool> func;
				if ((func = ElementNavigator.<>c.\u000A) == null)
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
					func = (ElementNavigator.<>c.\u000A = new Func<ICategoryModel, bool>(ElementNavigator.<>c.\u001F.\u0004));
				}
				\u0016\u0019\u0005.\u000A(this, \u0007\u000C\u0018.\u000A(Enumerable.Where<ICategoryModel>(enumerable, func)));
				EventHandler f = this.F;
				if (f == null)
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
				\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
			}
		}

		// Token: 0x06001517 RID: 5399 RVA: 0x000895C0 File Offset: 0x000877C0
		private void chkHideUnCheckedItems_Click(object sender, RoutedEventArgs e)
		{
			if (\u001E\u0009\u000A.\u0007(this.B) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.chkHideUnCheckedItems_Click(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.B)));
			this.M();
		}

		// Token: 0x06001518 RID: 5400 RVA: 0x00089610 File Offset: 0x00087810
		public void Reset()
		{
			\u000D\u000C\u0007.\u000A(this.C, new bool?(false));
			\u000D\u000C\u0007.\u000A(this.U, new bool?(false));
			\u001C\u001A\u0019.\u000A(this.S, "");
			if (\u0002\u0019\u0005.\u001D(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.Reset()).MethodHandle;
				}
				IEnumerator<ICategoryModel> enumerator = \u0009\u0004\u0005.\u000A(\u0002\u0019\u0005.\u001D(this));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						\u0013\u0013\u0018.\u000A(\u0014\u001C\u0018.\u000A(enumerator), false);
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
					if (enumerator != null)
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
			}
		}

		// Token: 0x06001519 RID: 5401 RVA: 0x000896C8 File Offset: 0x000878C8
		internal bool E(object F)
		{
			ICategoryModel categoryModel = \u001C\u0006\u000E.\u001F(F);
			if (categoryModel == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.E(object)).MethodHandle;
				}
				return false;
			}
			bool flag = true;
			if (!\u001A\u0006\u0007.\u000A(\u0010\u001A\u0019.\u000A(this.S)))
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
				flag = \u000D\u0008\u000A.\u001F(\u000B\u0015\u0018.\u000A(categoryModel), \u0010\u001A\u0019.\u000A(this.S));
			}
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
				bool? flag2 = \u0003\u0015\u000A.\u000A(this.U);
				if (\u0012\u0015\u000A.\u000A(ref flag2))
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
					flag = \u001D\u000C\u0018.\u000A(categoryModel);
				}
			}
			\u001F\u0019\u0005.\u000A(categoryModel, flag);
			return flag;
		}

		// Token: 0x0600151A RID: 5402 RVA: 0x00089778 File Offset: 0x00087978
		private void N(object F)
		{
			ElementNavigator.\u000C\u0003 u000C_u = new ElementNavigator.\u000C\u0003();
			CheckBox checkBox = \u0011\u000A\u000E.\u001F(F);
			if (checkBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.N(object)).MethodHandle;
				}
				object u001F = \u0007\u000C\u000A.\u0007(checkBox);
				u000C_u.\u001F = \u001C\u0006\u000E.\u001F(u001F);
				if (u000C_u.\u001F != null)
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
					List<ICategoryModel> u001F2 = Enumerable.ToList<ICategoryModel>(Enumerable.Cast<ICategoryModel>(\u0011\u001A\u0019.\u0007(this.B)));
					if (\u0019\u0019\u0005.\u000A(u001F2, u000C_u.\u001F))
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
						\u001B\u0015\u0018.\u000A(u001F2, new Action<ICategoryModel>(u000C_u.\u000A));
					}
					IEnumerable<ICategoryModel> enumerable = \u0002\u0019\u0005.\u001D(this);
					Func<ICategoryModel, bool> func;
					if ((func = ElementNavigator.<>c.\u0007) == null)
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
						func = (ElementNavigator.<>c.\u0007 = new Func<ICategoryModel, bool>(ElementNavigator.<>c.\u001F.\u0019));
					}
					\u0016\u0019\u0005.\u000A(this, \u0007\u000C\u0018.\u000A(Enumerable.Where<ICategoryModel>(enumerable, func)));
					EventHandler f = this.F;
					if (f == null)
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
						\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
					}
					this.M();
				}
			}
		}

		// Token: 0x0600151B RID: 5403 RVA: 0x00089890 File Offset: 0x00087A90
		private void ChkList_OnKeyUp(object sender, KeyEventArgs e)
		{
			if (\u001A\u001A\u0019.\u000A(e) == Key.Space)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.ChkList_OnKeyUp(object, KeyEventArgs)).MethodHandle;
				}
				if (\u0019\u000C\u0007.\u001D(this.B) != null)
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
					ICategoryModel categoryModel = \u001C\u0006\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.B));
					if (categoryModel != null)
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
						\u0013\u0013\u0018.\u000A(categoryModel, !\u001D\u000C\u0018.\u000A(categoryModel));
					}
					IEnumerable<ICategoryModel> enumerable = \u0002\u0019\u0005.\u001D(this);
					Func<ICategoryModel, bool> func;
					if ((func = ElementNavigator.<>c.\u001D) == null)
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
						func = (ElementNavigator.<>c.\u001D = new Func<ICategoryModel, bool>(ElementNavigator.<>c.\u001F.\u0018));
					}
					\u0016\u0019\u0005.\u000A(this, \u0007\u000C\u0018.\u000A(Enumerable.Where<ICategoryModel>(enumerable, func)));
					EventHandler f = this.F;
					if (f == null)
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
					}
					else
					{
						\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
					}
					this.M();
				}
			}
		}

		// Token: 0x0600151C RID: 5404 RVA: 0x0008997C File Offset: 0x00087B7C
		internal void M()
		{
			\u000D\u000C\u0007.\u000A(this.C, \u0001\u0003.\u001F(\u001E\u0009\u000A.\u0007(this.B)));
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x000899A8 File Offset: 0x00087BA8
		private void ChkList_OnPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			string u000A = "/diroots.one;component/SheetLink/Resources/Images/";
			\u000A\u0016\u0019.\u000A(this.B, \u0007\u0016\u0019.\u000A());
			MenuItem menuItem = \u0002\u0016\u0019.\u000A();
			\u000B\u0016\u0019.\u000A(menuItem, \u0013\u0009\u0018.\u000A());
			\u0005\u0016\u0019.\u000A(menuItem, \u0016\u0016\u0019.\u000A("Search.png", u000A, \u0010\u0011\u000A.\u000A()));
			\u0018\u0016\u0019.\u000A(menuItem, new RoutedEventHandler(this.SelectMenuItem_Click));
			\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u001F\u0016\u0019.\u000A(this.B)), menuItem);
			menuItem = \u0002\u0016\u0019.\u000A();
			\u000B\u0016\u0019.\u000A(menuItem, \u0017\u0009\u0018.\u000A());
			\u0005\u0016\u0019.\u000A(menuItem, \u0016\u0016\u0019.\u000A("Search.png", u000A, \u0010\u0011\u000A.\u000A()));
			\u0018\u0016\u0019.\u000A(menuItem, new RoutedEventHandler(this.ShowMenuItem_Click));
			\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u001F\u0016\u0019.\u000A(this.B)), menuItem);
			if (\u0017\u000D.\u0016\u000A(\u0006\u0019\u0005.\u000A(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.ChkList_OnPreviewMouseRightButtonDown(object, MouseButtonEventArgs)).MethodHandle;
				}
				if (\u001D\u0013\u000A.\u000A(\u000F\u000B\u0004.\u0007(\u0006\u0019\u0005.\u000A(this))))
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
					menuItem = \u0002\u0016\u0019.\u000A();
					\u000B\u0016\u0019.\u000A(menuItem, \u0010\u0013\u000A.\u000A());
					\u0005\u0016\u0019.\u000A(menuItem, \u0016\u0016\u0019.\u000A("Search.png", u000A, \u0010\u0011\u000A.\u000A()));
					\u0018\u0016\u0019.\u000A(menuItem, new RoutedEventHandler(this.UnisolateMenuItem_Click));
					\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u001F\u0016\u0019.\u000A(this.B)), menuItem);
					return;
				}
				menuItem = \u0002\u0016\u0019.\u000A();
				\u000B\u0016\u0019.\u000A(menuItem, \u000A\u0013\u000A.\u000A());
				\u0005\u0016\u0019.\u000A(menuItem, \u0016\u0016\u0019.\u000A("Search.png", u000A, \u0010\u0011\u000A.\u000A()));
				\u0018\u0016\u0019.\u000A(menuItem, new RoutedEventHandler(this.IsolateMenuItem_Click));
				\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u001F\u0016\u0019.\u000A(this.B)), menuItem);
			}
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x00089B90 File Offset: 0x00087D90
		private void SelectMenuItem_Click(object sender, RoutedEventArgs e)
		{
			ElementNavigator.ContextMenuDelegate contextMenuDelegate = \u0003\u0015\u0018.\u001D(this);
			if (contextMenuDelegate == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.SelectMenuItem_Click(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			\u000F\u0019\u0005.\u000A(contextMenuDelegate, Enumerable.ToList<ICategoryModel>(Enumerable.Cast<ICategoryModel>(\u0011\u001A\u0019.\u0007(this.B))), MenuContext.Select);
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x00089BE0 File Offset: 0x00087DE0
		private void ShowMenuItem_Click(object sender, RoutedEventArgs e)
		{
			ElementNavigator.ContextMenuDelegate contextMenuDelegate = \u0003\u0015\u0018.\u001D(this);
			if (contextMenuDelegate == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.ShowMenuItem_Click(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			\u000F\u0019\u0005.\u000A(contextMenuDelegate, Enumerable.ToList<ICategoryModel>(Enumerable.Cast<ICategoryModel>(\u0011\u001A\u0019.\u0007(this.B))), MenuContext.Show);
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x00089C30 File Offset: 0x00087E30
		private void UnisolateMenuItem_Click(object sender, RoutedEventArgs e)
		{
			ElementNavigator.ContextMenuDelegate contextMenuDelegate = \u0003\u0015\u0018.\u001D(this);
			if (contextMenuDelegate == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.UnisolateMenuItem_Click(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			\u000F\u0019\u0005.\u000A(contextMenuDelegate, Enumerable.ToList<ICategoryModel>(Enumerable.Cast<ICategoryModel>(\u0011\u001A\u0019.\u0007(this.B))), MenuContext.Unisolate);
		}

		// Token: 0x06001521 RID: 5409 RVA: 0x00089C80 File Offset: 0x00087E80
		private void IsolateMenuItem_Click(object sender, RoutedEventArgs e)
		{
			ElementNavigator.ContextMenuDelegate contextMenuDelegate = \u0003\u0015\u0018.\u001D(this);
			if (contextMenuDelegate == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.IsolateMenuItem_Click(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			\u000F\u0019\u0005.\u000A(contextMenuDelegate, Enumerable.ToList<ICategoryModel>(Enumerable.Cast<ICategoryModel>(\u0011\u001A\u0019.\u0007(this.B))), MenuContext.Isolate);
		}

		// Token: 0x06001522 RID: 5410 RVA: 0x00089CD0 File Offset: 0x00087ED0
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x06001523 RID: 5411 RVA: 0x00089CF8 File Offset: 0x00087EF8
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.W)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.W = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink.core/ui/usercontrols/categorynavigator/elements/elementnavigator.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001524 RID: 5412 RVA: 0x00089D40 File Offset: 0x00087F40
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.K(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u001B\u0006\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.C = \u0016\u0009\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.C, new RoutedEventHandler(this.chkSelectAll_Click));
				return;
			case 3:
				this.L = \u001A\u000A\u000E.\u001F(R);
				return;
			case 4:
				this.S = \u0005\u0009\u0010.\u001F(R);
				\u0007\u000C\u0019.\u000A(this.S, new TextChangedEventHandler(this.txtSearchFilter_TextChanged));
				return;
			case 5:
				this.B = \u0007\u0016\u000E.\u001F(R);
				\u000A\u000C\u0019.\u000A(this.B, new KeyEventHandler(this.ChkList_OnKeyUp));
				\u0012\u0019\u0005.\u000A(this.B, new MouseButtonEventHandler(this.ChkList_OnPreviewMouseRightButtonDown));
				return;
			case 7:
				this.U = \u0016\u0009\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.U, new RoutedEventHandler(this.chkHideUnCheckedItems_Click));
				return;
			}
			this.W = true;
		}

		// Token: 0x06001525 RID: 5413 RVA: 0x00089E58 File Offset: 0x00088058
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IStyleConnector.J(int F, object R)
		{
			if (F == 6)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementNavigator.J(int, object)).MethodHandle;
				}
				\u0010\u0015\u000A.\u000A(\u0016\u0009\u0010.\u001F(R), new RoutedEventHandler(this.CheckBox_Click));
			}
		}

		// Token: 0x0400082F RID: 2095
		[CompilerGenerated]
		private EventHandler F;

		// Token: 0x04000830 RID: 2096
		[CompilerGenerated]
		private ElementNavigator.ContextMenuDelegate R;

		// Token: 0x04000831 RID: 2097
		[CompilerGenerated]
		private UIDocument D;

		// Token: 0x04000832 RID: 2098
		[CompilerGenerated]
		private ObservableCollection<ICategoryModel> H;

		// Token: 0x04000833 RID: 2099
		public static readonly DependencyProperty ItemSourceProperty = \u000F\u0006\u001D.\u000A("ItemSource", \u001E\u0011\u000A.\u000A(\u000E\u0006\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u001E\u0006\u000E.\u001F()), \u0002\u001A\u0019.\u000A(new PropertyChangedCallback(ElementNavigator.OnSourceChanged)));

		// Token: 0x04000834 RID: 2100
		internal CheckBox C;

		// Token: 0x04000835 RID: 2101
		internal Label L;

		// Token: 0x04000836 RID: 2102
		internal WatermarkTextBox S;

		// Token: 0x04000837 RID: 2103
		internal ListBox B;

		// Token: 0x04000838 RID: 2104
		internal CheckBox U;

		// Token: 0x04000839 RID: 2105
		private bool W;

		// Token: 0x020008EC RID: 2284
		// (Invoke) Token: 0x060050F8 RID: 20728
		public delegate void ContextMenuDelegate(List<ICategoryModel> category, MenuContext menuContext);

		// Token: 0x020008EE RID: 2286
		[CompilerGenerated]
		private sealed class \u000C\u0003
		{
			// Token: 0x06005101 RID: 20737 RVA: 0x001E8000 File Offset: 0x001E6200
			internal void \u000A(ICategoryModel \u001F)
			{
				\u0013\u0013\u0018.\u000A(\u001F, \u001D\u000C\u0018.\u000A(this.\u001F));
			}

			// Token: 0x04002365 RID: 9061
			public ICategoryModel \u001F;
		}
	}
}

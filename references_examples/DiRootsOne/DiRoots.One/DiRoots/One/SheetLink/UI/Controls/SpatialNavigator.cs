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
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;

namespace DiRoots.One.SheetLink.UI.Controls
{
	// Token: 0x0200022F RID: 559
	public class SpatialNavigator : UserControl, IComponentConnector, IStyleConnector
	{
		// Token: 0x060015E1 RID: 5601 RVA: 0x0008DD18 File Offset: 0x0008BF18
		public SpatialNavigator()
		{
			\u0008\u0016\u0005.\u000A(this);
			\u000E\u0016\u0005.\u000A(this, new ObservableCollection<SpatialBaseElement>());
		}

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x060015E3 RID: 5603 RVA: 0x0008DD8C File Offset: 0x0008BF8C
		// (remove) Token: 0x060015E4 RID: 5604 RVA: 0x0008DDDC File Offset: 0x0008BFDC
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.add_CheckedChangedEvent(EventHandler)).MethodHandle;
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.remove_CheckedChangedEvent(EventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x060015E5 RID: 5605 RVA: 0x0008DE2C File Offset: 0x0008C02C
		// (set) Token: 0x060015E6 RID: 5606 RVA: 0x0008DE40 File Offset: 0x0008C040
		public SpatialNavigator.ContextMenuDelegate ContextMenuHandler { get; set; }

		// Token: 0x17000600 RID: 1536
		// (get) Token: 0x060015E7 RID: 5607 RVA: 0x0008DE54 File Offset: 0x0008C054
		// (set) Token: 0x060015E8 RID: 5608 RVA: 0x0008DE78 File Offset: 0x0008C078
		public ObservableCollection<SpatialBaseElement> ItemSource
		{
			get
			{
				return \u0017\u000F\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, SpatialNavigator.ItemSourceProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, SpatialNavigator.ItemSourceProperty, value);
			}
		}

		// Token: 0x17000601 RID: 1537
		// (get) Token: 0x060015E9 RID: 5609 RVA: 0x0008DE94 File Offset: 0x0008C094
		// (set) Token: 0x060015EA RID: 5610 RVA: 0x0008DEA8 File Offset: 0x0008C0A8
		public ObservableCollection<SpatialBaseElement> SelectedItems { get; set; }

		// Token: 0x17000602 RID: 1538
		// (get) Token: 0x060015EB RID: 5611 RVA: 0x0008DEBC File Offset: 0x0008C0BC
		// (set) Token: 0x060015EC RID: 5612 RVA: 0x0008DEE0 File Offset: 0x0008C0E0
		public string Title
		{
			get
			{
				return \u001A\u000C\u000A.\u000A(\u0004\u000C\u0007.\u000A(this.H));
			}
			set
			{
				\u0014\u001A\u000A.\u000A(this.H, value);
			}
		}

		// Token: 0x060015ED RID: 5613 RVA: 0x0008DEFC File Offset: 0x0008C0FC
		private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			SpatialNavigator spatialNavigator = \u0020\u000F\u000E.\u001F(d);
			if (spatialNavigator != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.OnSourceChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				if (\u000B\u000A\u0005.\u0007(spatialNavigator) != null)
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
					ICollectionView collectionView = \u0011\u0009\u000A.\u000A(\u000B\u000A\u0005.\u0007(spatialNavigator));
					\u0005\u0008\u0007.\u000A(collectionView, new Predicate<object>(spatialNavigator.J));
					\u0018\u000C\u0007.\u000A(spatialNavigator.L, collectionView);
					spatialNavigator.N();
				}
			}
		}

		// Token: 0x060015EE RID: 5614 RVA: 0x0008DF70 File Offset: 0x0008C170
		private void txtSearchFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.L)));
			this.N();
		}

		// Token: 0x060015EF RID: 5615 RVA: 0x0008DF9C File Offset: 0x0008C19C
		private void chkSelectAll_Click(object sender, RoutedEventArgs e)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.chkSelectAll_Click(object, RoutedEventArgs)).MethodHandle;
				}
				bool? flag = \u0003\u0015\u000A.\u000A(checkBox);
				IEnumerator u001F;
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
					u001F = \u001D\u0011\u000A.\u000A(\u0010\u000C\u0007.\u000A(this.L));
					try
					{
						while (\u000A\u0017\u000A.\u000A(u001F))
						{
							\u0019\u000A\u0005.\u000A(\u001E\u000F\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F)), true);
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
						goto IL_101;
					}
					finally
					{
						IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
						if (disposable != null)
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
							\u001F\u0017\u000A.\u000A(disposable);
						}
					}
				}
				u001F = \u001D\u0011\u000A.\u000A(\u0010\u000C\u0007.\u000A(this.L));
				try
				{
					while (\u000A\u0017\u000A.\u000A(u001F))
					{
						\u0019\u000A\u0005.\u000A(\u001E\u000F\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F)), false);
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
				IL_101:
				IEnumerable<SpatialBaseElement> enumerable = \u000B\u000A\u0005.\u001D(this);
				Func<SpatialBaseElement, bool> func;
				if ((func = SpatialNavigator.<>c.\u000A) == null)
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
					func = (SpatialNavigator.<>c.\u000A = new Func<SpatialBaseElement, bool>(SpatialNavigator.<>c.\u001F.\u0019));
				}
				\u000E\u0016\u0005.\u000A(this, \u001B\u0016\u0005.\u000A(Enumerable.Where<SpatialBaseElement>(enumerable, func)));
				EventHandler f = this.F;
				if (f == null)
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
				\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
			}
		}

		// Token: 0x060015F0 RID: 5616 RVA: 0x0008E12C File Offset: 0x0008C32C
		private void chkHideUnCheckedItems_Click(object sender, RoutedEventArgs e)
		{
			if (\u001E\u0009\u000A.\u0007(this.L) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.chkHideUnCheckedItems_Click(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.L)));
			this.N();
		}

		// Token: 0x060015F1 RID: 5617 RVA: 0x0008E17C File Offset: 0x0008C37C
		private void CheckBox_Click(object sender, RoutedEventArgs e)
		{
			this.E(sender, false);
		}

		// Token: 0x060015F2 RID: 5618 RVA: 0x0008E194 File Offset: 0x0008C394
		public void Reset()
		{
			\u000D\u000C\u0007.\u000A(this.S, new bool?(false));
			\u000D\u000C\u0007.\u000A(this.B, new bool?(false));
			\u001C\u001A\u0019.\u000A(this.C, "");
			IEnumerator<SpatialBaseElement> enumerator = \u001E\u0016\u0005.\u000A(\u000B\u000A\u0005.\u001D(this));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u0019\u000A\u0005.\u000A(\u0011\u0016\u0005.\u000A(enumerator), false);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.Reset()).MethodHandle;
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
			ObservableCollection<SpatialBaseElement> observableCollection = \u0004\u000A\u0005.\u001D(this);
			if (observableCollection == null)
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
			}
			else
			{
				\u0005\u000A\u0005.\u001D(observableCollection);
			}
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.L)));
		}

		// Token: 0x060015F3 RID: 5619 RVA: 0x0008E26C File Offset: 0x0008C46C
		internal bool J(object F)
		{
			SpatialBaseElement spatialBaseElement = \u001E\u000F\u000E.\u001F(F);
			if (spatialBaseElement == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.J(object)).MethodHandle;
				}
				return false;
			}
			bool flag;
			if (!\u001A\u0006\u0007.\u000A(\u0010\u001A\u0019.\u000A(this.C)))
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
				if (!\u000D\u0008\u000A.\u001F(\u0013\u0016\u0005.\u0007(spatialBaseElement), \u0010\u001A\u0019.\u000A(this.C)))
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
					flag = \u000D\u0008\u000A.\u001F(\u0014\u0016\u0005.\u000A(spatialBaseElement), \u0010\u001A\u0019.\u000A(this.C));
					goto IL_88;
				}
			}
			flag = true;
			IL_88:
			bool flag2 = flag;
			if (flag2)
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
				bool? flag3 = \u0003\u0015\u000A.\u000A(this.B);
				if (\u0012\u0015\u000A.\u000A(ref flag3))
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
					flag2 = \u0017\u0016\u0005.\u000A(spatialBaseElement);
				}
				else
				{
					flag2 = true;
				}
			}
			\u0020\u0016\u0005.\u000A(spatialBaseElement, flag2);
			return flag2;
		}

		// Token: 0x060015F4 RID: 5620 RVA: 0x0008E348 File Offset: 0x0008C548
		private void E(object F, bool R)
		{
			SpatialNavigator.\u001D\u001C u001D_u001C = new SpatialNavigator.\u001D\u001C();
			u001D_u001C.\u001F = R;
			CheckBox checkBox = \u0011\u000A\u000E.\u001F(F);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.E(object, bool)).MethodHandle;
				}
				SpatialBaseElement spatialBaseElement = \u001E\u000F\u000E.\u001F(\u0007\u000C\u000A.\u0007(checkBox));
				if (spatialBaseElement != null)
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
					u001D_u001C.\u001F = \u0017\u0016\u0005.\u000A(spatialBaseElement);
					List<SpatialBaseElement> u001F = Enumerable.ToList<SpatialBaseElement>(Enumerable.Cast<SpatialBaseElement>(\u0009\u0006\u0007.\u0007(this.L)));
					if (\u001A\u0016\u0005.\u000A(u001F, spatialBaseElement))
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
						\u0016\u000A\u0005.\u000A(u001F, new Action<SpatialBaseElement>(u001D_u001C.\u000A));
					}
					IEnumerable<SpatialBaseElement> enumerable = \u000B\u000A\u0005.\u001D(this);
					Func<SpatialBaseElement, bool> func;
					if ((func = SpatialNavigator.<>c.\u0007) == null)
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
						func = (SpatialNavigator.<>c.\u0007 = new Func<SpatialBaseElement, bool>(SpatialNavigator.<>c.\u001F.\u0018));
					}
					\u000E\u0016\u0005.\u000A(this, \u001B\u0016\u0005.\u000A(Enumerable.Where<SpatialBaseElement>(enumerable, func)));
					EventHandler f = this.F;
					if (f == null)
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
						\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
					}
					this.N();
				}
			}
		}

		// Token: 0x060015F5 RID: 5621 RVA: 0x0008E464 File Offset: 0x0008C664
		private void ChkList_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			string u000A = "/diroots.one;component/SheetLink/Resources/Images/";
			\u000A\u0016\u0019.\u000A(this.L, \u0007\u0016\u0019.\u000A());
			MenuItem menuItem = \u0002\u0016\u0019.\u000A();
			\u000B\u0016\u0019.\u000A(menuItem, \u0013\u0009\u0018.\u000A());
			\u0005\u0016\u0019.\u000A(menuItem, \u0016\u0016\u0019.\u000A("Search.png", u000A, \u0010\u0011\u000A.\u000A()));
			\u0018\u0016\u0019.\u000A(menuItem, new RoutedEventHandler(this.SelectMenuItem_Click));
			\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u001F\u0016\u0019.\u000A(this.L)), menuItem);
			menuItem = \u0002\u0016\u0019.\u000A();
			\u000B\u0016\u0019.\u000A(menuItem, \u0017\u0009\u0018.\u000A());
			\u0005\u0016\u0019.\u000A(menuItem, \u0016\u0016\u0019.\u000A("Search.png", u000A, \u0010\u0011\u000A.\u000A()));
			\u0018\u0016\u0019.\u000A(menuItem, new RoutedEventHandler(this.ShowMenuItem_Click));
			\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u001F\u0016\u0019.\u000A(this.L)), menuItem);
		}

		// Token: 0x060015F6 RID: 5622 RVA: 0x0008E548 File Offset: 0x0008C748
		private void SelectMenuItem_Click(object sender, RoutedEventArgs e)
		{
			SpatialNavigator.ContextMenuDelegate contextMenuDelegate = \u0012\u001F\u0005.\u001D(this);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.SelectMenuItem_Click(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			\u000C\u0016\u0005.\u000A(contextMenuDelegate, Enumerable.ToList<SpatialBaseElement>(Enumerable.Cast<SpatialBaseElement>(\u0009\u0006\u0007.\u0007(this.L))), MenuContext.Select);
		}

		// Token: 0x060015F7 RID: 5623 RVA: 0x0008E598 File Offset: 0x0008C798
		private void ShowMenuItem_Click(object sender, RoutedEventArgs e)
		{
			SpatialNavigator.ContextMenuDelegate contextMenuDelegate = \u0012\u001F\u0005.\u001D(this);
			if (contextMenuDelegate == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.ShowMenuItem_Click(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			\u000C\u0016\u0005.\u000A(contextMenuDelegate, Enumerable.ToList<SpatialBaseElement>(Enumerable.Cast<SpatialBaseElement>(\u0009\u0006\u0007.\u0007(this.L))), MenuContext.Show);
		}

		// Token: 0x060015F8 RID: 5624 RVA: 0x0008E5E8 File Offset: 0x0008C7E8
		private void ChkList_ContextMenuOpening(object sender, ContextMenuEventArgs e)
		{
			if (\u0018\u0013\u000A.\u000A(\u0009\u0006\u0007.\u0007(this.L)) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.ChkList_ContextMenuOpening(object, ContextMenuEventArgs)).MethodHandle;
				}
				\u0019\u0013\u000A.\u000A(e, true);
			}
		}

		// Token: 0x060015F9 RID: 5625 RVA: 0x0008E628 File Offset: 0x0008C828
		private void ChkList_OnKeyUp(object sender, KeyEventArgs e)
		{
			if (\u001A\u001A\u0019.\u000A(e) == Key.Space)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.ChkList_OnKeyUp(object, KeyEventArgs)).MethodHandle;
				}
				if (\u0019\u000C\u0007.\u001D(this.L) != null)
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
					SpatialBaseElement u001F = \u0011\u000F\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.L));
					\u0019\u000A\u0005.\u000A(u001F, !\u0017\u0016\u0005.\u000A(u001F));
					IEnumerable<SpatialBaseElement> enumerable = \u000B\u000A\u0005.\u001D(this);
					Func<SpatialBaseElement, bool> func;
					if ((func = SpatialNavigator.<>c.\u001D) == null)
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
						func = (SpatialNavigator.<>c.\u001D = new Func<SpatialBaseElement, bool>(SpatialNavigator.<>c.\u001F.\u0005));
					}
					\u000E\u0016\u0005.\u000A(this, \u001B\u0016\u0005.\u000A(Enumerable.Where<SpatialBaseElement>(enumerable, func)));
					EventHandler f = this.F;
					if (f == null)
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
					}
					else
					{
						\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
					}
					this.N();
				}
			}
		}

		// Token: 0x060015FA RID: 5626 RVA: 0x0008E704 File Offset: 0x0008C904
		private void ChkList_Sorting(object sender, DataGridSortingEventArgs e)
		{
			ListCollectionView u001F = \u000F\u0009\u0010.\u001F(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.L)));
			if (\u000D\u0009\u000A.\u000A(e) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.ChkList_Sorting(object, DataGridSortingEventArgs)).MethodHandle;
				}
				if (\u0014\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e)))
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
					if (\u0008\u0013\u000A.\u000A(\u001A\u000C\u000A.\u000A(\u0017\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e))), \u0015\u0016\u0005.\u000A()))
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
								switch (4)
								{
								case 0:
									continue;
								}
								break;
							}
							\u0010\u0009\u000A.\u000A(u001F, new \u0002\u000E(false));
							\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Descending));
						}
						else
						{
							\u0010\u0009\u000A.\u000A(u001F, new \u0002\u000E(true));
							\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Ascending));
						}
					}
					else
					{
						ListSortDirection? listSortDirection = \u001B\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e));
						ListSortDirection listSortDirection2 = ListSortDirection.Ascending;
						if (\u0008\u0009\u000A.\u000A(ref listSortDirection) == listSortDirection2 & \u000E\u0009\u000A.\u000A(ref listSortDirection))
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
							\u0010\u0009\u000A.\u000A(u001F, new \u000B\u000E(false));
							\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Descending));
						}
						else
						{
							\u0010\u0009\u000A.\u000A(u001F, new \u000B\u000E(true));
							\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Ascending));
						}
					}
					\u0003\u0009\u000A.\u000A(e, true);
				}
			}
		}

		// Token: 0x060015FB RID: 5627 RVA: 0x0008E894 File Offset: 0x0008CA94
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x060015FC RID: 5628 RVA: 0x0008E8BC File Offset: 0x0008CABC
		internal void N()
		{
			object s = this.S;
			IEnumerable u001F = \u001E\u0009\u000A.\u0007(this.L);
			Func<SpatialBaseElement, bool> u000A;
			if ((u000A = SpatialNavigator.<>c.\u0004) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.N()).MethodHandle;
				}
				u000A = (SpatialNavigator.<>c.\u0004 = new Func<SpatialBaseElement, bool>(SpatialNavigator.<>c.\u001F.\u0016));
			}
			\u000D\u000C\u0007.\u000A(s, \u0001\u0003.\u001F<SpatialBaseElement>(u001F, u000A));
		}

		// Token: 0x060015FD RID: 5629 RVA: 0x0008E91C File Offset: 0x0008CB1C
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.U)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.U = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink/ui/usercontrols/spatial/spatialnavigator.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060015FE RID: 5630 RVA: 0x0008E964 File Offset: 0x0008CB64
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.W(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u0008\u000F\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.H = \u001A\u000A\u000E.\u001F(R);
				return;
			case 3:
				this.C = \u0005\u0009\u0010.\u001F(R);
				\u0007\u000C\u0019.\u000A(this.C, new TextChangedEventHandler(this.txtSearchFilter_TextChanged));
				return;
			case 4:
				this.L = \u0020\u0001\u0010.\u001F(R);
				\u001D\u0002\u0019.\u000A(this.L, new ContextMenuEventHandler(this.ChkList_ContextMenuOpening));
				\u000A\u000C\u0019.\u000A(this.L, new KeyEventHandler(this.ChkList_OnKeyUp));
				\u0012\u0019\u0005.\u000A(this.L, new MouseButtonEventHandler(this.ChkList_PreviewMouseRightButtonDown));
				\u001F\u001F\u0007.\u000A(this.L, new DataGridSortingEventHandler(this.ChkList_Sorting));
				return;
			case 5:
				this.S = \u0016\u0009\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.S, new RoutedEventHandler(this.chkSelectAll_Click));
				return;
			case 7:
				this.B = \u0016\u0009\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.B, new RoutedEventHandler(this.chkHideUnCheckedItems_Click));
				return;
			}
			this.U = true;
		}

		// Token: 0x060015FF RID: 5631 RVA: 0x0008EAA8 File Offset: 0x0008CCA8
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IStyleConnector.K(int F, object R)
		{
			if (F == 6)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialNavigator.K(int, object)).MethodHandle;
				}
				\u0010\u0015\u000A.\u000A(\u0016\u0009\u0010.\u001F(R), new RoutedEventHandler(this.CheckBox_Click));
			}
		}

		// Token: 0x040008B7 RID: 2231
		[CompilerGenerated]
		private EventHandler F;

		// Token: 0x040008B8 RID: 2232
		[CompilerGenerated]
		private SpatialNavigator.ContextMenuDelegate R;

		// Token: 0x040008B9 RID: 2233
		public static readonly DependencyProperty ItemSourceProperty = \u000F\u0006\u001D.\u000A("ItemSource", \u001E\u0011\u000A.\u000A(\u0014\u000F\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0013\u000F\u000E.\u001F()), \u0002\u001A\u0019.\u000A(new PropertyChangedCallback(SpatialNavigator.OnSourceChanged)));

		// Token: 0x040008BA RID: 2234
		[CompilerGenerated]
		private ObservableCollection<SpatialBaseElement> D;

		// Token: 0x040008BB RID: 2235
		internal Label H;

		// Token: 0x040008BC RID: 2236
		internal WatermarkTextBox C;

		// Token: 0x040008BD RID: 2237
		internal DataGrid L;

		// Token: 0x040008BE RID: 2238
		internal CheckBox S;

		// Token: 0x040008BF RID: 2239
		internal CheckBox B;

		// Token: 0x040008C0 RID: 2240
		private bool U;

		// Token: 0x020008F9 RID: 2297
		// (Invoke) Token: 0x06005130 RID: 20784
		public delegate void ContextMenuDelegate(List<SpatialBaseElement> category, MenuContext menuContext);

		// Token: 0x020008FB RID: 2299
		[CompilerGenerated]
		private sealed class \u001D\u001C
		{
			// Token: 0x0600513A RID: 20794 RVA: 0x001E859C File Offset: 0x001E679C
			internal void \u000A(SpatialBaseElement \u001F)
			{
				\u0019\u000A\u0005.\u000A(\u001F, this.\u001F);
			}

			// Token: 0x0400238C RID: 9100
			public bool \u001F;
		}
	}
}

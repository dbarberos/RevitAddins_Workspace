using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using A;
using Microsoft.Xaml.Behaviors;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x02000034 RID: 52
	public class ListBoxSelectionBehavior<T> : Behavior<ListBox>
	{
		// Token: 0x06000263 RID: 611 RVA: 0x0000D910 File Offset: 0x0000BB10
		private static void OnSelectedItemsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			ListBoxSelectionBehavior<T> listBoxSelectionBehavior = (ListBoxSelectionBehavior<T>)sender;
			if (listBoxSelectionBehavior.\u0018)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ListBoxSelectionBehavior.OnSelectedItemsChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			if (\u0011\u000F\u0014.\u0014(listBoxSelectionBehavior) == null)
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
				return;
			}
			listBoxSelectionBehavior.\u0018 = true;
			listBoxSelectionBehavior.\u0014();
			listBoxSelectionBehavior.\u0018 = false;
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000264 RID: 612 RVA: 0x0000D96C File Offset: 0x0000BB6C
		// (set) Token: 0x06000265 RID: 613 RVA: 0x0000D990 File Offset: 0x0000BB90
		public IList SelectedItems
		{
			get
			{
				return \u001C\u001D\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, ListBoxSelectionBehavior<T>.SelectedItemsProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, ListBoxSelectionBehavior<T>.SelectedItemsProperty, value);
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000D9AC File Offset: 0x0000BBAC
		private void \u0014()
		{
			this.\u000C = true;
			\u000F\u000F\u0014.\u0018(\u0015\u000F\u0014.\u0018(\u0011\u000F\u0014.\u0003(this)));
			if (this.SelectedItems != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ListBoxSelectionBehavior.\u0014()).MethodHandle;
				}
				IEnumerator u000C = \u0016\u000F\u0014.\u0018(this.SelectedItems);
				try
				{
					while (\u001F\u001E\u0018.\u0018(u000C))
					{
						object u = \u0003\u000F\u0014.\u0018(u000C);
						\u0018\u000F\u0014.\u0018(\u0015\u000F\u0014.\u0018(\u0011\u000F\u0014.\u0003(this)), u);
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
					IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C);
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
						\u0020\u001E\u0018.\u0018(disposable);
					}
				}
			}
			this.\u000C = false;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000DA74 File Offset: 0x0000BC74
		private void OnListBoxSelectionChanged(object sender, SelectionChangedEventArgs args)
		{
			if (this.\u000C)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ListBoxSelectionBehavior.OnListBoxSelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				return;
			}
			if (\u0012\u000F\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0011\u000F\u0014.\u0003(this))) == null)
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
				return;
			}
			this.SelectedItems = Enumerable.ToArray<T>(Enumerable.Cast<T>(\u0015\u000F\u0014.\u0018(\u0011\u000F\u0014.\u0003(this))));
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000DAE4 File Offset: 0x0000BCE4
		private void OnListBoxItemsChanged(object sender, NotifyCollectionChangedEventArgs args)
		{
			if (this.\u000C)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ListBoxSelectionBehavior.OnListBoxItemsChanged(object, NotifyCollectionChangedEventArgs)).MethodHandle;
				}
				return;
			}
			if (\u0012\u000F\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0011\u000F\u0014.\u0003(this))) == null)
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
				return;
			}
			this.\u0014();
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000DB38 File Offset: 0x0000BD38
		protected override void OnAttached()
		{
			\u0009\u000F\u0014.\u0018(this);
			\u0013\u000F\u0014.\u0018(\u0011\u000F\u0014.\u0003(this), new SelectionChangedEventHandler(this.OnListBoxSelectionChanged));
			\u001C\u000F\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0011\u000F\u0014.\u0003(this)), new NotifyCollectionChangedEventHandler(this.OnListBoxItemsChanged));
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000DB84 File Offset: 0x0000BD84
		protected override void OnDetaching()
		{
			\u001F\u000F\u0014.\u0018(this);
			if (\u0011\u000F\u0014.\u0003(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ListBoxSelectionBehavior.OnDetaching()).MethodHandle;
				}
				\u0020\u000F\u0014.\u0018(\u0011\u000F\u0014.\u0003(this), new SelectionChangedEventHandler(this.OnListBoxSelectionChanged));
				\u000A\u000F\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0011\u000F\u0014.\u0003(this)), new NotifyCollectionChangedEventHandler(this.OnListBoxItemsChanged));
			}
		}

		// Token: 0x0400010F RID: 271
		public static readonly DependencyProperty SelectedItemsProperty = \u001D\u001A\u0018.\u0018("SelectedItems", \u000A\u001D\u0018.\u0018(\u0013\u001D\u000F.\u000C()), \u000A\u001D\u0018.\u0018(typeof(ListBoxSelectionBehavior<T>).TypeHandle), \u000E\u0016\u0014.\u0018(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(ListBoxSelectionBehavior<T>.OnSelectedItemsChanged)));

		// Token: 0x04000110 RID: 272
		private bool \u000C;

		// Token: 0x04000111 RID: 273
		private bool \u0018;
	}
}

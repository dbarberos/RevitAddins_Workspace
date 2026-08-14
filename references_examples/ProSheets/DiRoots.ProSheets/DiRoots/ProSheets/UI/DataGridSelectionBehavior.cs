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
	// Token: 0x02000033 RID: 51
	public class DataGridSelectionBehavior<T> : Behavior<DataGrid>
	{
		// Token: 0x06000259 RID: 601 RVA: 0x0000D5C8 File Offset: 0x0000B7C8
		private static void OnSelectedItemsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			DataGridSelectionBehavior<T> dataGridSelectionBehavior = (DataGridSelectionBehavior<T>)sender;
			if (dataGridSelectionBehavior.\u0018)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridSelectionBehavior.OnSelectedItemsChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			if (\u000C\u000F\u0014.\u0014(dataGridSelectionBehavior) == null)
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
			dataGridSelectionBehavior.\u0018 = true;
			dataGridSelectionBehavior.\u0014();
			dataGridSelectionBehavior.\u0018 = false;
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600025A RID: 602 RVA: 0x0000D624 File Offset: 0x0000B824
		// (set) Token: 0x0600025B RID: 603 RVA: 0x0000D648 File Offset: 0x0000B848
		public IList SelectedItems
		{
			get
			{
				return \u001C\u001D\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, DataGridSelectionBehavior<T>.SelectedItemsProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, DataGridSelectionBehavior<T>.SelectedItemsProperty, value);
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000D664 File Offset: 0x0000B864
		private void \u0014()
		{
			this.\u000C = true;
			\u000F\u000F\u0014.\u0018(\u0014\u000F\u0014.\u0018(\u000C\u000F\u0014.\u0003(this)));
			if (this.SelectedItems != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridSelectionBehavior.\u0014()).MethodHandle;
				}
				IEnumerator u000C = \u0016\u000F\u0014.\u0018(this.SelectedItems);
				try
				{
					while (\u001F\u001E\u0018.\u0018(u000C))
					{
						object u = \u0003\u000F\u0014.\u0018(u000C);
						\u0018\u000F\u0014.\u0018(\u0014\u000F\u0014.\u0018(\u000C\u000F\u0014.\u0003(this)), u);
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
							switch (2)
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

		// Token: 0x0600025D RID: 605 RVA: 0x0000D72C File Offset: 0x0000B92C
		private void OnDataGridSelectionChanged(object sender, SelectionChangedEventArgs args)
		{
			if (this.\u000C)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridSelectionBehavior.OnDataGridSelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				return;
			}
			if (\u0012\u000F\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u000C\u000F\u0014.\u0003(this))) == null)
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
			this.SelectedItems = Enumerable.ToArray<T>(Enumerable.Cast<T>(\u0014\u000F\u0014.\u0018(\u000C\u000F\u0014.\u0003(this))));
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000D79C File Offset: 0x0000B99C
		private void OnDataGridItemsChanged(object sender, NotifyCollectionChangedEventArgs args)
		{
			if (this.\u000C)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridSelectionBehavior.OnDataGridItemsChanged(object, NotifyCollectionChangedEventArgs)).MethodHandle;
				}
				return;
			}
			if (\u0012\u000F\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u000C\u000F\u0014.\u0003(this))) == null)
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

		// Token: 0x0600025F RID: 607 RVA: 0x0000D7F0 File Offset: 0x0000B9F0
		protected override void OnAttached()
		{
			\u0009\u000F\u0014.\u0018(this);
			\u0013\u000F\u0014.\u0018(\u000C\u000F\u0014.\u0003(this), new SelectionChangedEventHandler(this.OnDataGridSelectionChanged));
			\u001C\u000F\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u000C\u000F\u0014.\u0003(this)), new NotifyCollectionChangedEventHandler(this.OnDataGridItemsChanged));
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000D83C File Offset: 0x0000BA3C
		protected override void OnDetaching()
		{
			\u001F\u000F\u0014.\u0018(this);
			if (\u000C\u000F\u0014.\u0003(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridSelectionBehavior.OnDetaching()).MethodHandle;
				}
				\u0020\u000F\u0014.\u0018(\u000C\u000F\u0014.\u0003(this), new SelectionChangedEventHandler(this.OnDataGridSelectionChanged));
				\u000A\u000F\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u000C\u000F\u0014.\u0003(this)), new NotifyCollectionChangedEventHandler(this.OnDataGridItemsChanged));
			}
		}

		// Token: 0x0400010C RID: 268
		public static readonly DependencyProperty SelectedItemsProperty = \u001D\u001A\u0018.\u0018("SelectedItems", \u000A\u001D\u0018.\u0018(\u0013\u001D\u000F.\u000C()), \u000A\u001D\u0018.\u0018(typeof(DataGridSelectionBehavior<T>).TypeHandle), \u000E\u0016\u0014.\u0018(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(DataGridSelectionBehavior<T>.OnSelectedItemsChanged)));

		// Token: 0x0400010D RID: 269
		private bool \u000C;

		// Token: 0x0400010E RID: 270
		private bool \u0018;
	}
}

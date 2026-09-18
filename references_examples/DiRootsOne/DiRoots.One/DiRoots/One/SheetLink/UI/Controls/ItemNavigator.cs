using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.SheetLink.ViewModels;

namespace DiRoots.One.SheetLink.UI.Controls
{
	// Token: 0x02000221 RID: 545
	public class ItemNavigator : UserControl, IComponentConnector
	{
		// Token: 0x06001526 RID: 5414 RVA: 0x00089E98 File Offset: 0x00088098
		public ItemNavigator()
		{
			\u001C\u0019\u0005.\u000A(this);
			\u0003\u0019\u0005.\u000A(this, new ObservableCollection<ICategoryModel>());
			ItemNavigatorModel.EVR(this.D);
		}

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06001528 RID: 5416 RVA: 0x00089F18 File Offset: 0x00088118
		// (remove) Token: 0x06001529 RID: 5417 RVA: 0x00089F68 File Offset: 0x00088168
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
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ItemNavigator.add_CheckedChangedEvent(EventHandler)).MethodHandle;
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
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ItemNavigator.remove_CheckedChangedEvent(EventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x0600152A RID: 5418 RVA: 0x00089FB8 File Offset: 0x000881B8
		// (set) Token: 0x0600152B RID: 5419 RVA: 0x00089FDC File Offset: 0x000881DC
		public ObservableCollection<ICategoryModel> ItemSource
		{
			get
			{
				return \u0010\u0006\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, ItemNavigator.ItemSourceProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, ItemNavigator.ItemSourceProperty, value);
			}
		}

		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x0600152C RID: 5420 RVA: 0x00089FF8 File Offset: 0x000881F8
		// (set) Token: 0x0600152D RID: 5421 RVA: 0x0008A00C File Offset: 0x0008820C
		public ObservableCollection<ICategoryModel> SelectedItems { get; set; }

		// Token: 0x0600152E RID: 5422 RVA: 0x0008A020 File Offset: 0x00088220
		private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ItemNavigator itemNavigator = \u0017\u0006\u000E.\u001F(d);
			if (itemNavigator != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ItemNavigator.OnSourceChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				if (\u0008\u0015\u0018.\u0007(itemNavigator) != null)
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
					ICollectionView collectionView = \u0011\u0009\u000A.\u000A(\u0008\u0015\u0018.\u0007(itemNavigator));
					\u0005\u0008\u0007.\u000A(collectionView, new Predicate<object>(itemNavigator.U));
					\u0018\u000C\u0007.\u000A(itemNavigator.C, collectionView);
				}
			}
		}

		// Token: 0x0600152F RID: 5423 RVA: 0x0008A090 File Offset: 0x00088290
		private void txtSearchFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.C)));
		}

		// Token: 0x06001530 RID: 5424 RVA: 0x0008A0B8 File Offset: 0x000882B8
		private void CmbFilter_DropDownClosed(object sender, EventArgs e)
		{
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.C)));
		}

		// Token: 0x06001531 RID: 5425 RVA: 0x0008A0E0 File Offset: 0x000882E0
		private void ChkList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.B(sender, true);
		}

		// Token: 0x06001532 RID: 5426 RVA: 0x0008A0F8 File Offset: 0x000882F8
		private void B(object F, bool R)
		{
			if (\u0008\u0015\u0018.\u001D(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ItemNavigator.B(object, bool)).MethodHandle;
				}
				return;
			}
			object u001F = Enumerable.ToList<ICategoryModel>(\u0008\u0015\u0018.\u001D(this));
			Action<ICategoryModel> u000A;
			if ((u000A = ItemNavigator.<>c.\u000A) == null)
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
				u000A = (ItemNavigator.<>c.\u000A = new Action<ICategoryModel>(ItemNavigator.<>c.\u001F.\u001D));
			}
			\u001B\u0015\u0018.\u000A(u001F, u000A);
			ICategoryModel categoryModel = \u001C\u0006\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.C));
			if (categoryModel != null)
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
				\u0013\u0013\u0018.\u000A(categoryModel, true);
			}
			IEnumerable<ICategoryModel> enumerable = \u0008\u0015\u0018.\u001D(this);
			Func<ICategoryModel, bool> func;
			if ((func = ItemNavigator.<>c.\u0007) == null)
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
				func = (ItemNavigator.<>c.\u0007 = new Func<ICategoryModel, bool>(ItemNavigator.<>c.\u001F.\u0004));
			}
			\u0003\u0019\u0005.\u000A(this, \u0007\u000C\u0018.\u000A(Enumerable.Where<ICategoryModel>(enumerable, func)));
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
				return;
			}
			\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
		}

		// Token: 0x06001533 RID: 5427 RVA: 0x0008A1F0 File Offset: 0x000883F0
		public void Reset()
		{
			\u001C\u001A\u0019.\u000A(this.H, "");
			IEnumerator<ICategoryModel> enumerator = \u0009\u0004\u0005.\u000A(\u0008\u0015\u0018.\u001D(this));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u0013\u0013\u0018.\u000A(\u0014\u001C\u0018.\u000A(enumerator), false);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ItemNavigator.Reset()).MethodHandle;
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
			\u000D\u0019\u0005.\u000A(this.C);
		}

		// Token: 0x06001534 RID: 5428 RVA: 0x0008A27C File Offset: 0x0008847C
		internal bool U(object F)
		{
			ItemNavigator.\u0015\u0003 u0015_u = new ItemNavigator.\u0015\u0003();
			ICategoryModel categoryModel = \u001C\u0006\u000E.\u001F(F);
			if (categoryModel == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ItemNavigator.U(object)).MethodHandle;
				}
				return false;
			}
			u0015_u.\u001F = \u0014\u000D\u0007.\u000A();
			List<object> u001F = Enumerable.ToList<object>(\u001D\u0019\u0005.\u000A(\u0004\u0019\u0005.\u000A(this.D)));
			if (\u0007\u0019\u0005.\u000A(u001F, "All"))
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
				\u000A\u0019\u0005.\u000A(u001F, "All");
			}
			List<object>.Enumerator enumerator = \u0017\u0015\u0019.\u000A(u001F);
			try
			{
				while (\u0011\u0015\u0019.\u000A(ref enumerator))
				{
					int num = \u0005\u0005\u000E.\u001F(\u0020\u0015\u0019.\u000A(ref enumerator));
					\u001A\u0008\u0007.\u000A(u0015_u.\u001F, \u000C\u0013\u0007.\u000A(ref num));
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
				((IDisposable)enumerator).Dispose();
			}
			bool flag = Enumerable.Any<string>(\u000F\u001C\u0018.\u000A(categoryModel), new Func<string, bool>(u0015_u.\u000A));
			if (flag)
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
				if (!\u001A\u0006\u0007.\u000A(\u0010\u001A\u0019.\u000A(this.H)))
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
					flag = \u000D\u0008\u000A.\u001F(\u000B\u0015\u0018.\u000A(categoryModel), \u0010\u001A\u0019.\u000A(this.H));
				}
			}
			\u001F\u0019\u0005.\u000A(categoryModel, flag);
			return flag;
		}

		// Token: 0x06001535 RID: 5429 RVA: 0x0008A3D8 File Offset: 0x000885D8
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x06001536 RID: 5430 RVA: 0x0008A400 File Offset: 0x00088600
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ItemNavigator.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.L = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink.core/ui/usercontrols/categorynavigator/elements/itemnavigator.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001537 RID: 5431 RVA: 0x0008A448 File Offset: 0x00088648
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.S(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u0020\u0006\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.D = \u000B\u0009\u0010.\u001F(R);
				\u0005\u0019\u0005.\u000A(this.D, new EventHandler(this.CmbFilter_DropDownClosed));
				return;
			case 3:
				this.H = \u0005\u0009\u0010.\u001F(R);
				\u0007\u000C\u0019.\u000A(this.H, new TextChangedEventHandler(this.txtSearchFilter_TextChanged));
				return;
			case 4:
				this.C = \u0007\u0016\u000E.\u001F(R);
				\u001B\u000C\u000A.\u0007(this.C, new SelectionChangedEventHandler(this.ChkList_SelectionChanged));
				return;
			default:
				this.L = true;
				return;
			}
		}

		// Token: 0x0400083A RID: 2106
		[CompilerGenerated]
		private EventHandler F;

		// Token: 0x0400083B RID: 2107
		[CompilerGenerated]
		private ObservableCollection<ICategoryModel> R;

		// Token: 0x0400083C RID: 2108
		public static readonly DependencyProperty ItemSourceProperty = \u000F\u0006\u001D.\u000A("ItemSource", \u001E\u0011\u000A.\u000A(\u000E\u0006\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0014\u0006\u000E.\u001F()), \u0002\u001A\u0019.\u000A(new PropertyChangedCallback(ItemNavigator.OnSourceChanged)));

		// Token: 0x0400083D RID: 2109
		internal MultiSelectComboBox D;

		// Token: 0x0400083E RID: 2110
		internal WatermarkTextBox H;

		// Token: 0x0400083F RID: 2111
		internal ListBox C;

		// Token: 0x04000840 RID: 2112
		private bool L;

		// Token: 0x020008F0 RID: 2288
		[CompilerGenerated]
		private sealed class \u0015\u0003
		{
			// Token: 0x06005107 RID: 20743 RVA: 0x001E80AC File Offset: 0x001E62AC
			internal bool \u000A(string \u001F)
			{
				return \u001F\u0020\u001D.\u000A(this.\u001F, \u001F);
			}

			// Token: 0x04002369 RID: 9065
			public List<string> \u001F;
		}
	}
}

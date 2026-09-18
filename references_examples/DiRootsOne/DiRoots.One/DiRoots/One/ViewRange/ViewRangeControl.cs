using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.UIBehaviours.Behaviors;

namespace DiRoots.One.ViewRange
{
	// Token: 0x02000291 RID: 657
	public class ViewRangeControl : UserControl, IComponentConnector
	{
		// Token: 0x06001993 RID: 6547 RVA: 0x000A50BC File Offset: 0x000A32BC
		public ViewRangeControl(Window owner)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\ViewRange\\UI\\Control\\ViewRangeDetailerUI.xaml.cs", ".ctor");
			ViewRangeViewModel viewRangeViewModel = new ViewRangeViewModel();
			\u000A\u000C\u0007.\u0007(viewRangeViewModel, owner);
			\u0018\u0009\u0005.\u000A(this, viewRangeViewModel);
			\u0017\u001A\u000A.\u0007(this, \u0004\u0009\u0005.\u000A(this));
			\u0019\u0009\u0005.\u000A(this);
			CollectionsDataGridSelectionBehavior collectionsDataGridSelectionBehavior = new CollectionsDataGridSelectionBehavior();
			\u000F\u0009\u000A.\u000A(collectionsDataGridSelectionBehavior, DataGridSelectionBehavior<ViewInformation>.SelectedItemsProperty, new Binding("SelectViewInformation"));
			\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.D), collectionsDataGridSelectionBehavior);
			\u001D\u0009\u0005.\u000A(\u0004\u0009\u0005.\u000A(this));
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\ViewRange\\UI\\Control\\ViewRangeDetailerUI.xaml.cs", ".ctor");
		}

		// Token: 0x17000708 RID: 1800
		// (get) Token: 0x06001994 RID: 6548 RVA: 0x000A5160 File Offset: 0x000A3360
		// (set) Token: 0x06001995 RID: 6549 RVA: 0x000A5174 File Offset: 0x000A3374
		public ViewRangeViewModel ViewRangeControlViewModel { get; set; }

		// Token: 0x06001996 RID: 6550 RVA: 0x000A5188 File Offset: 0x000A3388
		private string B(DataGridColumn F)
		{
			DataGridTemplateColumn dataGridTemplateColumn = \u0012\u000A\u000E.\u001F(F);
			if (dataGridTemplateColumn == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeControl.B(DataGridColumn)).MethodHandle;
				}
				return string.Empty;
			}
			DependencyObject u001F = \u0011\u000C\u0007.\u000A(\u001E\u000C\u0007.\u000A(dataGridTemplateColumn));
			string text = this.U(\u000F\u001F\u000E.\u001F(u001F), Selector.SelectedItemProperty);
			if (text != null)
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
				return text;
			}
			string text2 = this.U(\u0008\u000A\u000E.\u001F(u001F), TextBox.TextProperty);
			if (text2 != null)
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
				return text2;
			}
			string text3 = this.U(\u0017\u0012\u000E.\u001F(u001F), TextBlock.TextProperty);
			if (text3 != null)
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
				return text3;
			}
			return string.Empty;
		}

		// Token: 0x06001997 RID: 6551 RVA: 0x000A5244 File Offset: 0x000A3444
		private string U(FrameworkElement F, DependencyProperty R)
		{
			if (F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeControl.U(FrameworkElement, DependencyProperty)).MethodHandle;
				}
				BindingExpression bindingExpression = \u0017\u000C\u0007.\u001D(F, R);
				if (bindingExpression != null)
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
					return \u000E\u000C\u0007.\u0007(\u0008\u000C\u0007.\u000A(\u0020\u000C\u0007.\u0007(bindingExpression)));
				}
			}
			return null;
		}

		// Token: 0x06001998 RID: 6552 RVA: 0x000A5298 File Offset: 0x000A3498
		private void DrgView_Sorting(object sender, DataGridSortingEventArgs e)
		{
			if (\u000D\u0009\u000A.\u000A(e) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeControl.DrgView_Sorting(object, DataGridSortingEventArgs)).MethodHandle;
				}
				return;
			}
			string u001F = this.B(\u000D\u0009\u000A.\u000A(e));
			if (\u001A\u0006\u0007.\u000A(u001F))
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
			ListCollectionView u001F2 = \u000F\u0009\u0010.\u001F(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.D)));
			ListSortDirection? listSortDirection = \u001B\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e));
			ListSortDirection listSortDirection2 = ListSortDirection.Ascending;
			if (\u0008\u0009\u000A.\u000A(ref listSortDirection) == listSortDirection2 & \u000E\u0009\u000A.\u000A(ref listSortDirection))
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
				\u0010\u0009\u000A.\u000A(u001F2, new \u0012\u0011(u001F, false));
				\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Descending));
			}
			else
			{
				\u0010\u0009\u000A.\u000A(u001F2, new \u0012\u0011(u001F, true));
				\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Ascending));
			}
			\u0003\u0009\u000A.\u000A(e, true);
		}

		// Token: 0x06001999 RID: 6553 RVA: 0x000A5384 File Offset: 0x000A3584
		private void DrgView_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				DependencyObject dependencyObject = \u000A\u0007\u000E.\u001F(\u0018\u0001\u0007.\u000A(e));
				while (dependencyObject != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeControl.DrgView_MouseRightButtonDown(object, MouseButtonEventArgs)).MethodHandle;
					}
					if (\u001E\u0012\u000E.\u001F(dependencyObject) != null)
					{
						break;
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
					if (\u0020\u0012\u000E.\u001F(dependencyObject) != null)
					{
						for (;;)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							goto IL_59;
						}
					}
					else
					{
						dependencyObject = \u0019\u0001\u0007.\u000A(dependencyObject);
					}
				}
				IL_59:
				if (\u001E\u0012\u000E.\u001F(dependencyObject) != null)
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
					\u000A\u0016\u0019.\u000A(this.D, \u0005\u000A\u000E.\u001F(\u0009\u0018\u0005.\u001D(this.D, "rowContextMenu")));
					\u0005\u0009\u0005.\u000A(\u001F\u0016\u0019.\u000A(this.D), this.D);
					\u0009\u001A\u0019.\u000A(\u001F\u0016\u0019.\u000A(this.D), true);
					\u0019\u0013\u000A.\u000A(e, true);
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\ViewRange\\UI\\Control\\ViewRangeDetailerUI.xaml.cs", "DrgView_MouseRightButtonDown");
			}
		}

		// Token: 0x0600199A RID: 6554 RVA: 0x000A5480 File Offset: 0x000A3680
		private void ViewRange_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x0600199B RID: 6555 RVA: 0x000A54A8 File Offset: 0x000A36A8
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewRangeControl.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.L = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/viewrange/ui/control/viewrangedetailerui.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x0600199C RID: 6556 RVA: 0x000A54F0 File Offset: 0x000A36F0
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.S(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u0011\u0012\u000E.\u001F(R), new RoutedEventHandler(this.ViewRange_Loaded));
				return;
			case 2:
				this.R = \u0019\u0009\u0010.\u001F(R);
				return;
			case 3:
				this.D = \u0020\u0001\u0010.\u001F(R);
				\u0007\u0002\u0019.\u000A(this.D, new MouseButtonEventHandler(this.DrgView_MouseRightButtonDown));
				\u001F\u001F\u0007.\u000A(this.D, new DataGridSortingEventHandler(this.DrgView_Sorting));
				return;
			case 4:
				this.H = \u000B\u000A\u000E.\u001F(R);
				return;
			case 5:
				this.C = \u001A\u000A\u000E.\u001F(R);
				return;
			default:
				this.L = true;
				return;
			}
		}

		// Token: 0x04000A24 RID: 2596
		[CompilerGenerated]
		private ViewRangeViewModel F;

		// Token: 0x04000A25 RID: 2597
		internal LeftStripButton R;

		// Token: 0x04000A26 RID: 2598
		internal DataGrid D;

		// Token: 0x04000A27 RID: 2599
		internal ComboBox H;

		// Token: 0x04000A28 RID: 2600
		internal Label C;

		// Token: 0x04000A29 RID: 2601
		private bool L;
	}
}

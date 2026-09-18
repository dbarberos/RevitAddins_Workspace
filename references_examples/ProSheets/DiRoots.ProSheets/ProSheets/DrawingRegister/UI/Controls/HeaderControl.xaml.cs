using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.ProSheets.UI;
using ProSheets.DrawingRegister.Behaviors;
using ProSheets.DrawingRegister.Model;

namespace ProSheets.DrawingRegister.UI.Controls
{
	// Token: 0x02000115 RID: 277
	public partial class HeaderControl : UserControl
	{
		// Token: 0x06000E2D RID: 3629 RVA: 0x00053304 File Offset: 0x00051504
		public HeaderControl()
		{
			\u0019\u0003\u000F.\u0018(this);
			HeaderParameterListBoxSelectionBehavior headerParameterListBoxSelectionBehavior = new HeaderParameterListBoxSelectionBehavior();
			\u0007\u0001\u0018.\u0018(headerParameterListBoxSelectionBehavior, ListBoxSelectionBehavior<ParameterInformation>.SelectedItemsProperty, new Binding("SelectedProjectParameters"));
			\u000B\u0001\u0018.\u0018(\u0019\u0001\u0018.\u0018(this.F), headerParameterListBoxSelectionBehavior);
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x00053350 File Offset: 0x00051550
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x00053378 File Offset: 0x00051578
		private void dgHeader_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				DependencyObject dependencyObject = \u0006\u001D\u000F.\u000C(\u000F\u0012\u0014.\u0018(e));
				while (dependencyObject != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(HeaderControl.dgHeader_PreviewMouseRightButtonDown(object, MouseButtonEventArgs)).MethodHandle;
					}
					if (\u000E\u0006\u000F.\u000C(dependencyObject) != null)
					{
						for (;;)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							goto IL_45;
						}
					}
					else
					{
						dependencyObject = \u0016\u001C\u0014.\u0018(dependencyObject);
					}
				}
				IL_45:
				DataGridRow dataGridRow = \u000E\u0006\u000F.\u000C(dependencyObject);
				if (dataGridRow != null)
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
					\u0018\u000F\u0003.\u0018(this.M, \u000B\u000B\u000F.\u000C(\u001A\u0009\u0014.\u0003(this.M, "headerContextMenu")));
					\u0008\u0013\u0014.\u0018(\u0006\u0016\u0003.\u0018(this.M), Visibility.Visible);
					\u0016\u000F\u0003.\u0018(\u0006\u0016\u0003.\u0018(this.M), this.M);
					\u0003\u000F\u0003.\u0018(\u0006\u0016\u0003.\u0018(this.M), true);
					ParameterInformation parameterInformation;
					\u0008\u0003\u000F.\u0018(\u000C\u0008\u000F.\u000C(\u0003\u0012\u0014.\u0003(this)), parameterInformation = \u0012\u0006\u000F.\u000C(\u0003\u0012\u0014.\u0014(dataGridRow)));
					ParameterInformation u000C = parameterInformation;
					IEnumerator u000C2 = \u0016\u000F\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0006\u0016\u0003.\u0018(this.M)));
					try
					{
						while (\u001F\u001E\u0018.\u0018(u000C2))
						{
							MenuItem menuItem = \u0006\u000B\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C2));
							if (menuItem != null)
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
								if (\u0010\u0003\u000F.\u0018(\u0006\u0003\u000F.\u0018(menuItem)) == 1L)
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
									\u000E\u0016\u0003.\u0018(menuItem, \u001C\u001E\u0018.\u0018(\u0007\u0003\u000F.\u0018(), \u0010\u0008\u0016.\u0014(u000C)));
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
						IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C2);
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
							\u0020\u001E\u0018.\u0018(disposable);
						}
					}
					\u001D\u000B\u0018.\u0018(e, true);
				}
			}
			catch (Exception u)
			{
				\u0017\u001E\u0014.\u0018(\u0002\u0002\u0016.\u0018(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\UI\\Controls\\HeaderControl.xaml.cs", "dgHeader_PreviewMouseRightButtonDown");
			}
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x00053578 File Offset: 0x00051778
		private void ContextMenu_Closed(object sender, RoutedEventArgs e)
		{
			ContextMenu contextMenu = \u0008\u0006\u000F.\u000C(sender);
			if (contextMenu != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(HeaderControl.ContextMenu_Closed(object, RoutedEventArgs)).MethodHandle;
				}
				\u0008\u0013\u0014.\u0018(contextMenu, Visibility.Collapsed);
			}
		}
	}
}

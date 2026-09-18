using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;
using ProSheets.DrawingRegister.Model;

namespace ProSheets.DrawingRegister.UI.Controls
{
	// Token: 0x02000118 RID: 280
	public partial class SheetsControl : UserControl
	{
		// Token: 0x06000E3E RID: 3646 RVA: 0x00053A94 File Offset: 0x00051C94
		public SheetsControl()
		{
			\u0003\u0016\u000F.\u0018(this);
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x00053AB0 File Offset: 0x00051CB0
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}

		// Token: 0x06000E40 RID: 3648 RVA: 0x00053AD8 File Offset: 0x00051CD8
		private void dgSheets_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				SheetsControl.\u001A\u0015\u0018 u001A_u0015_u = new SheetsControl.\u001A\u0015\u0018();
				DependencyObject dependencyObject = \u0006\u001D\u000F.\u000C(\u000F\u0012\u0014.\u0018(e));
				while (dependencyObject != null)
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
					if (\u001A\u000B\u000F.\u000C(dependencyObject) != null)
					{
						for (;;)
						{
							switch (5)
							{
							case 0:
								continue;
							}
							goto IL_73;
						}
					}
					else
					{
						if (\u000E\u001D\u000F.\u000C(dependencyObject) == null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsControl.dgSheets_MouseRightButtonDown(object, MouseButtonEventArgs)).MethodHandle;
							}
							if (\u0012\u0008\u000F.\u000C(dependencyObject) == null)
							{
								continue;
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
						dependencyObject = \u0016\u001C\u0014.\u0018(dependencyObject);
					}
				}
				IL_73:
				u001A_u0015_u.\u000C = \u001A\u000B\u000F.\u000C(dependencyObject);
				if (u001A_u0015_u.\u000C == null)
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
					\u0018\u000F\u0003.\u0018(this.H, \u0011\u0019\u000F.\u000C);
				}
				else
				{
					\u0018\u000F\u0003.\u0018(this.H, \u000B\u000B\u000F.\u000C(\u001A\u0009\u0014.\u0003(this.H, "headerContextMenu")));
					\u0008\u0013\u0014.\u0018(\u0006\u0016\u0003.\u0018(this.H), Visibility.Visible);
					\u0016\u000F\u0003.\u0018(\u0006\u0016\u0003.\u0018(this.H), this.H);
					\u0003\u000F\u0003.\u0018(\u0006\u0016\u0003.\u0018(this.H), true);
					\u000F\u0016\u000F.\u0018(\u000D\u0008\u000F.\u000C(\u0003\u0012\u0014.\u0003(this)), \u0012\u0016\u000F.\u0018(u001A_u0015_u.\u000C));
					int num = 0;
					IEnumerator u000C = \u0016\u000F\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0006\u0016\u0003.\u0018(this.H)));
					try
					{
						while (\u001F\u001E\u0018.\u0018(u000C))
						{
							MenuItem menuItem = \u0006\u000B\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C));
							if (menuItem != null)
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
								if (\u0010\u0003\u000F.\u0018(\u0006\u0003\u000F.\u0018(menuItem)) == 1L)
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
									object u000C2 = \u0017\u000B\u0016.\u0014(\u000D\u0008\u000F.\u000C(\u0003\u0012\u0014.\u0003(this)));
									Predicate<ParameterInformation> u;
									if ((u = u001A_u0015_u.\u0018) == null)
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
										u = (u001A_u0015_u.\u0018 = new Predicate<ParameterInformation>(u001A_u0015_u.\u0014));
									}
									ParameterInformation u000C3 = \u0011\u0010\u0016.\u0018(u000C2, u);
									\u000E\u0016\u0003.\u0018(menuItem, \u001C\u001E\u0018.\u0018(\u0007\u0003\u000F.\u0018(), \u0010\u0008\u0016.\u0014(u000C3)).\u000C());
									num = \u0020\u001C\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0006\u0016\u0003.\u0018(this.H)), menuItem);
								}
							}
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
					finally
					{
						IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C);
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
							\u0020\u001E\u0018.\u0018(disposable);
						}
					}
					if (\u0002\u000D\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0006\u0016\u0003.\u0018(this.H))) == 5)
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
						Separator u2 = \u0016\u0016\u000F.\u0018();
						\u001C\u001C\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u0006\u0016\u0003.\u0018(this.H)), num + 1, u2);
					}
				}
			}
			catch (Exception u3)
			{
				\u0017\u001E\u0014.\u0018(\u0002\u0002\u0016.\u0018(), u3, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\UI\\Controls\\SheetsControl.xaml.cs", "dgSheets_MouseRightButtonDown");
			}
			finally
			{
				\u001D\u000B\u0018.\u0018(e, true);
			}
		}

		// Token: 0x06000E41 RID: 3649 RVA: 0x00053E00 File Offset: 0x00052000
		private void ContextMenu_Closed(object sender, RoutedEventArgs e)
		{
			ContextMenu contextMenu = \u0008\u0006\u000F.\u000C(sender);
			if (contextMenu != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsControl.ContextMenu_Closed(object, RoutedEventArgs)).MethodHandle;
				}
				\u0008\u0013\u0014.\u0018(contextMenu, Visibility.Collapsed);
			}
		}

		// Token: 0x06000E43 RID: 3651 RVA: 0x00053E7C File Offset: 0x0005207C
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		internal Delegate M(Type P, string Q)
		{
			return \u000E\u000B\u0018.\u0018(P, this, Q);
		}

		// Token: 0x02000211 RID: 529
		[CompilerGenerated]
		private sealed class \u001A\u0015\u0018
		{
			// Token: 0x060012F7 RID: 4855 RVA: 0x00061388 File Offset: 0x0005F588
			internal bool \u0014(ParameterInformation \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001F\u0001\u0016.\u0018(\u000C), \u0012\u0016\u000F.\u0018(this.\u000C));
			}

			// Token: 0x0400095F RID: 2399
			public DataGridColumnHeader \u000C;

			// Token: 0x04000960 RID: 2400
			public Predicate<ParameterInformation> \u0018;
		}
	}
}

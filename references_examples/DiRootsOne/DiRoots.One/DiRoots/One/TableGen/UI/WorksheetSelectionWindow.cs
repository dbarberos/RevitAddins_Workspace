using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Navigation;
using A;
using DiRoots.One.Commons.Extensions;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.One.TableGen.UI
{
	// Token: 0x0200015D RID: 349
	public class WorksheetSelectionWindow : DiRootsWindow, IComponentConnector, IStyleConnector
	{
		// Token: 0x06000D30 RID: 3376 RVA: 0x00055C38 File Offset: 0x00053E38
		public WorksheetSelectionWindow()
		{
			\u0017\u0002\u0019.\u000A(this);
			this.SYR();
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x00055C58 File Offset: 0x00053E58
		private void BtnOK_Click(object sender, RoutedEventArgs e)
		{
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x00055C78 File Offset: 0x00053E78
		private void OnValidationError(object sender, ValidationErrorEventArgs e)
		{
			if (\u0014\u0002\u0019.\u000A(e) == ValidationErrorEventAction.Added)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectionWindow.OnValidationError(object, ValidationErrorEventArgs)).MethodHandle;
				}
				this.AD++;
			}
			else if (\u0014\u0002\u0019.\u000A(e) == ValidationErrorEventAction.Removed)
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
				this.AD--;
			}
			this.SYR();
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x00055CDC File Offset: 0x00053EDC
		private void SYR()
		{
			\u0015\u0009\u000A.\u000A(this.FH, this.AD == 0);
		}

		// Token: 0x06000D34 RID: 3380 RVA: 0x00055D00 File Offset: 0x00053F00
		private void RowDetailsGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			DataGrid dataGrid = \u001D\u001F\u000E.\u001F(sender);
			if (dataGrid == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectionWindow.RowDetailsGrid_PreviewMouseWheel(object, MouseWheelEventArgs)).MethodHandle;
				}
				return;
			}
			ScrollViewer scrollViewer = dataGrid.FindVisualChild<ScrollViewer>();
			if (scrollViewer == null)
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
				return;
			}
			bool flag;
			if (\u001A\u0015\u000A.\u000A(e) > 0)
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
				flag = (\u000C\u0015\u000A.\u000A(scrollViewer) > 0.0);
			}
			else
			{
				flag = false;
			}
			bool flag2;
			if (\u001A\u0015\u000A.\u000A(e) < 0)
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
				flag2 = (\u000C\u0015\u000A.\u000A(scrollViewer) < \u001F\u0006\u0019.\u000A(scrollViewer));
			}
			else
			{
				flag2 = false;
			}
			bool flag3 = flag2;
			if (flag || flag3)
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
				return;
			}
			ScrollViewer scrollViewer2 = this.GD.FindVisualChild<ScrollViewer>();
			if (scrollViewer2 == null)
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
			\u0019\u0013\u000A.\u000A(e, true);
			MouseWheelEventArgs mouseWheelEventArgs = \u0015\u0002\u0019.\u000A(\u0009\u0002\u0019.\u000A(e), \u0001\u0002\u0019.\u000A(e), \u001A\u0015\u000A.\u000A(e));
			\u000C\u0002\u0019.\u000A(mouseWheelEventArgs, UIElement.MouseWheelEvent);
			\u001A\u0002\u0019.\u000A(mouseWheelEventArgs, sender);
			MouseWheelEventArgs u000A = mouseWheelEventArgs;
			\u0013\u0002\u0019.\u000A(scrollViewer2, u000A);
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x00055E08 File Offset: 0x00054008
		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			\u0004\u0019\u0019.\u000A(\u0019\u0019\u0019.\u000A(\u0018\u0019\u0019.\u000A(e)));
			\u0019\u0013\u000A.\u000A(e, true);
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x00055E30 File Offset: 0x00054030
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectionWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/tablegen/tablegen/ui/windows/worksheetselectionwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06000D37 RID: 3383 RVA: 0x00055E78 File Offset: 0x00054078
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x00055E90 File Offset: 0x00054090
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u000A\u0006\u0019.\u000A(\u0019\u0005\u000E.\u001F(R), Validation.ErrorEvent, new EventHandler<ValidationErrorEventArgs>(this.OnValidationError));
				return;
			case 2:
				this.GD = \u0020\u0001\u0010.\u001F(R);
				return;
			case 4:
				\u0005\u0019\u0019.\u000A(\u0017\u0018\u000E.\u001F(R), new RequestNavigateEventHandler(this.Hyperlink_RequestNavigate));
				return;
			case 5:
				this.GR = \u001E\u0001\u0010.\u001F(R);
				return;
			case 6:
				this.FH = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.FH, new RoutedEventHandler(this.BtnOK_Click));
				return;
			}
			this.R = true;
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x00055F44 File Offset: 0x00054144
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IStyleConnector.AQ(int F, object R)
		{
			if (F == 3)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectionWindow.AQ(int, object)).MethodHandle;
				}
				\u0015\u0015\u000A.\u000A(\u0020\u0001\u0010.\u001F(R), new MouseWheelEventHandler(this.RowDetailsGrid_PreviewMouseWheel));
			}
		}

		// Token: 0x0400053F RID: 1343
		private int AD;

		// Token: 0x04000540 RID: 1344
		internal DataGrid GD;

		// Token: 0x04000541 RID: 1345
		internal Button GR;

		// Token: 0x04000542 RID: 1346
		internal Button FH;

		// Token: 0x04000543 RID: 1347
		private bool R;
	}
}

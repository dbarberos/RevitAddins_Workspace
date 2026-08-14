using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002CC RID: 716
	public class DuplicatePlaceholderWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x06001D20 RID: 7456 RVA: 0x000B7F4C File Offset: 0x000B614C
		public DuplicatePlaceholderWindow()
		{
			\u0011\u0011\u0016.\u000A(this);
		}

		// Token: 0x06001D21 RID: 7457 RVA: 0x000B7F68 File Offset: 0x000B6168
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001D22 RID: 7458 RVA: 0x000B7F7C File Offset: 0x000B617C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicatePlaceholderWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/duplicationwindows/duplicateplaceholderwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001D23 RID: 7459 RVA: 0x000B7FC4 File Offset: 0x000B61C4
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.ML = \u0001\u000A\u000E.\u001F(R);
				return;
			case 2:
				\u0010\u0015\u000A.\u000A(\u001E\u0001\u0010.\u001F(R), new RoutedEventHandler(this.Button_Click));
				return;
			case 3:
				\u0010\u0015\u000A.\u000A(\u001E\u0001\u0010.\u001F(R), new RoutedEventHandler(this.Button_Click));
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x04000BAA RID: 2986
		internal TextBox ML;

		// Token: 0x04000BAB RID: 2987
		private bool R;
	}
}

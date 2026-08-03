using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using DiRoots.RoomPro.UI.Controls;
using DiRoots.RoomPro.ViewModels;

namespace DiRoots.RoomPro.UI.Windows
{
	// Token: 0x02000064 RID: 100
	public class CalloutSettingsWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x0600047A RID: 1146 RVA: 0x0001CA34 File Offset: 0x0001AC34
		public CalloutSettingsWindow(CalloutsSettingsViewModel viewModel)
		{
			\u0017\u001A\u000A.\u0007(this, viewModel);
			\u000A\u000C\u0007.\u0007(viewModel, this);
			\u001F\u000C\u0007.\u000A(this);
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0001CA5C File Offset: 0x0001AC5C
		private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			TabControl tabControl = \u0001\u001F\u000E.\u001F(sender);
			object u001F;
			if (tabControl == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutSettingsWindow.TabControl_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				u001F = null;
			}
			else
			{
				u001F = \u0019\u000C\u0007.\u0007(tabControl);
			}
			TabItem tabItem = \u0009\u001F\u000E.\u001F(u001F);
			if (tabItem == null)
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
			SettingsTab u001F2 = \u001F\u000A\u000E.\u001F(\u0004\u000C\u0007.\u000A(tabItem));
			UserControl u001F3 = \u000A\u000A\u000E.\u001F(\u0004\u000C\u0007.\u000A(tabItem));
			if (\u0007\u000A\u000E.\u001F(u001F2) != null)
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
				\u0007\u000C\u0007.\u0007(this, 480.0);
				return;
			}
			if (\u001D\u000A\u000E.\u001F(u001F3) != null)
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
				\u0007\u000C\u0007.\u0007(this, 600.0);
				return;
			}
			if (\u0004\u000A\u000E.\u001F(u001F2) != null)
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
				\u0007\u000C\u0007.\u0007(this, \u001D\u000C\u0007.\u000A(this));
			}
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0001CB34 File Offset: 0x0001AD34
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutSettingsWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/quickviews/ui/window/calloutsettingswindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0001CB7C File Offset: 0x0001AD7C
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0001CB94 File Offset: 0x0001AD94
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			if (F == 1)
			{
				this.F = \u0015\u001F\u000E.\u001F(R);
				return;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutSettingsWindow.QQ(int, object)).MethodHandle;
			}
			if (F != 2)
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
				this.R = true;
				return;
			}
			\u001B\u000C\u000A.\u0007(\u001A\u0015\u0010.\u001F(R), new SelectionChangedEventHandler(this.TabControl_SelectionChanged));
		}

		// Token: 0x0400019A RID: 410
		internal CalloutSettingsWindow F;

		// Token: 0x0400019B RID: 411
		private bool R;
	}
}

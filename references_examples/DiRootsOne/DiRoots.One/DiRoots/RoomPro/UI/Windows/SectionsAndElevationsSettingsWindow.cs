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
	// Token: 0x02000067 RID: 103
	public class SectionsAndElevationsSettingsWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x0600049E RID: 1182 RVA: 0x0001D948 File Offset: 0x0001BB48
		public SectionsAndElevationsSettingsWindow(SectionsSettingsViewModel viewModel)
		{
			\u0017\u001A\u000A.\u0007(this, viewModel);
			\u000A\u000C\u0007.\u0007(viewModel, this);
			\u000B\u0015\u0007.\u000A(this);
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0001D970 File Offset: 0x0001BB70
		private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			TabControl tabControl = \u0001\u001F\u000E.\u001F(sender);
			object u001F;
			if (tabControl == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionsAndElevationsSettingsWindow.TabControl_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
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
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				return;
			}
			SettingsTab u001F2 = \u001F\u000A\u000E.\u001F(\u0004\u000C\u0007.\u000A(tabItem));
			if (\u0020\u000A\u000E.\u001F(u001F2) != null)
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
				\u0007\u000C\u0007.\u0007(this, 652.0);
				return;
			}
			if (\u0017\u000A\u000E.\u001F(u001F2) != null)
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
				\u0007\u000C\u0007.\u0007(this, 800.0);
				return;
			}
			if (\u0004\u000A\u000E.\u001F(u001F2) != null)
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
				\u0007\u000C\u0007.\u0007(this, \u001D\u000C\u0007.\u000A(this));
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0001DA38 File Offset: 0x0001BC38
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionsAndElevationsSettingsWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/quickviews/ui/window/sectionsandelevationssettingswindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x0001DA80 File Offset: 0x0001BC80
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0001DA98 File Offset: 0x0001BC98
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.QQ(int F, object R)
		{
			if (F == 1)
			{
				this.CR = \u001E\u000A\u000E.\u001F(R);
				return;
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(SectionsAndElevationsSettingsWindow.QQ(int, object)).MethodHandle;
			}
			if (F != 2)
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
				this.R = true;
				return;
			}
			\u001B\u000C\u000A.\u0007(\u001A\u0015\u0010.\u001F(R), new SelectionChangedEventHandler(this.TabControl_SelectionChanged));
		}

		// Token: 0x040001BA RID: 442
		internal SectionsAndElevationsSettingsWindow CR;

		// Token: 0x040001BB RID: 443
		private bool R;
	}
}

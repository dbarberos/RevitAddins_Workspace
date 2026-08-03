using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;

namespace DiRoots.RoomPro.UI.Controls
{
	// Token: 0x0200006B RID: 107
	public class CalloutsViewTab : SettingsTab, IComponentConnector
	{
		// Token: 0x060004B6 RID: 1206 RVA: 0x0001DEE8 File Offset: 0x0001C0E8
		public CalloutsViewTab()
		{
			\u0014\u0015\u0007.\u000A(this);
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0001DF04 File Offset: 0x0001C104
		private void CallOutViewTab_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x0001DF2C File Offset: 0x0001C12C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutsViewTab.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/quickviews/ui/controls/calloutsviewtab.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0001DF74 File Offset: 0x0001C174
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate U(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0001DF8C File Offset: 0x0001C18C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.B(int F, object R)
		{
			if (F == 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutsViewTab.B(int, object)).MethodHandle;
				}
				this.F = \u000B\u000A\u000E.\u001F(R);
				return;
			}
			this.R = true;
		}

		// Token: 0x040001C7 RID: 455
		internal ComboBox F;

		// Token: 0x040001C8 RID: 456
		private bool R;
	}
}

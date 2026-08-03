using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using A;

namespace DiRoots.RoomPro.UI.Controls
{
	// Token: 0x0200006D RID: 109
	public class ParametersTab : SettingsTab, IComponentConnector
	{
		// Token: 0x060004CA RID: 1226 RVA: 0x0001E54C File Offset: 0x0001C74C
		public ParametersTab()
		{
			\u0011\u0001\u0007.\u000A(this);
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0001E568 File Offset: 0x0001C768
		private void ParameterTab_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x0001E590 File Offset: 0x0001C790
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersTab.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/quickviews/ui/controls/parameterstab.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0001E5D8 File Offset: 0x0001C7D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate U(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0001E5F0 File Offset: 0x0001C7F0
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.B(int F, object R)
		{
			this.R = true;
		}

		// Token: 0x040001D1 RID: 465
		private bool R;
	}
}

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
	// Token: 0x0200006F RID: 111
	public class SectionsViewTab : SettingsTab, IComponentConnector
	{
		// Token: 0x060004D6 RID: 1238 RVA: 0x0001E818 File Offset: 0x0001CA18
		public SectionsViewTab()
		{
			\u0013\u0001\u0007.\u000A(this);
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x0001E834 File Offset: 0x0001CA34
		private void SectioView_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x0001E85C File Offset: 0x0001CA5C
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionsViewTab.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/quickviews/ui/controls/sectionsviewtab.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x0001E8A4 File Offset: 0x0001CAA4
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate U(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0001E8BC File Offset: 0x0001CABC
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.B(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.C = \u000B\u000A\u000E.\u001F(R);
				return;
			case 2:
				this.L = \u0001\u000A\u000E.\u001F(R);
				return;
			case 3:
				this.S = \u0001\u000A\u000E.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x040001D5 RID: 469
		internal ComboBox C;

		// Token: 0x040001D6 RID: 470
		internal TextBox L;

		// Token: 0x040001D7 RID: 471
		internal TextBox S;

		// Token: 0x040001D8 RID: 472
		private bool R;
	}
}

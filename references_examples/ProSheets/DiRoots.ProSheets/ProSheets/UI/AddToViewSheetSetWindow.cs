using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace ProSheets.UI
{
	// Token: 0x0200008F RID: 143
	public class AddToViewSheetSetWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x060008EA RID: 2282 RVA: 0x00037A44 File Offset: 0x00035C44
		public AddToViewSheetSetWindow()
		{
			\u000C\u0008\u0003.\u0018(this);
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x060008EB RID: 2283 RVA: 0x00037A60 File Offset: 0x00035C60
		// (set) Token: 0x060008EC RID: 2284 RVA: 0x00037A74 File Offset: 0x00035C74
		public bool IsSaved { get; set; }

		// Token: 0x060008ED RID: 2285 RVA: 0x00037A88 File Offset: 0x00035C88
		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			\u0018\u0008\u0003.\u0018(this, true);
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x00037AA4 File Offset: 0x00035CA4
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00037AB8 File Offset: 0x00035CB8
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.Q)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddToViewSheetSetWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.Q = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/ui/sets/addtoviewsheetsetwindow.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x00037B00 File Offset: 0x00035D00
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.CN(int P, object Q)
		{
			switch (P)
			{
			case 1:
				this.DB = \u000C\u0004\u000F.\u000C(Q);
				return;
			case 2:
				this.NR = \u000F\u0004\u000F.\u000C(Q);
				return;
			case 3:
				this.DQ = \u000C\u0004\u000F.\u000C(Q);
				return;
			case 4:
				this.PB = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.PB, new RoutedEventHandler(this.btnCancel_Click));
				return;
			case 5:
				this.JB = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.JB, new RoutedEventHandler(this.btnOk_Click));
				return;
			default:
				this.Q = true;
				return;
			}
		}

		// Token: 0x0400041A RID: 1050
		[CompilerGenerated]
		private bool HR;

		// Token: 0x0400041B RID: 1051
		internal TextBlock DB;

		// Token: 0x0400041C RID: 1052
		internal ComboBox NR;

		// Token: 0x0400041D RID: 1053
		internal TextBlock DQ;

		// Token: 0x0400041E RID: 1054
		internal Button PB;

		// Token: 0x0400041F RID: 1055
		internal Button JB;

		// Token: 0x04000420 RID: 1056
		private bool Q;
	}
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.One.ViewRange
{
	// Token: 0x02000290 RID: 656
	public class BatchViewRangeUI : DiRootsWindow, IComponentConnector
	{
		// Token: 0x0600198D RID: 6541 RVA: 0x000A4F44 File Offset: 0x000A3144
		public BatchViewRangeUI(List<ViewInformation> viewInformation)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\ViewRange\\UI\\Control\\BatchViewRangeUI.xaml.cs", ".ctor");
			\u0007\u0009\u0005.\u000A(this);
			BatchViewRangeViewModel batchViewRangeViewModel = new BatchViewRangeViewModel(viewInformation);
			\u000A\u000C\u0007.\u0007(batchViewRangeViewModel, this);
			\u000A\u0009\u0005.\u000A(this, batchViewRangeViewModel);
			\u0017\u001A\u000A.\u0007(this, \u001F\u0009\u0005.\u0007(this));
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\ViewRange\\UI\\Control\\BatchViewRangeUI.xaml.cs", ".ctor");
		}

		// Token: 0x17000707 RID: 1799
		// (get) Token: 0x0600198E RID: 6542 RVA: 0x000A4FAC File Offset: 0x000A31AC
		// (set) Token: 0x0600198F RID: 6543 RVA: 0x000A4FC0 File Offset: 0x000A31C0
		public BatchViewRangeViewModel BatchViewRangeViewModel { get; set; }

		// Token: 0x06001990 RID: 6544 RVA: 0x000A4FD4 File Offset: 0x000A31D4
		private void BatchViewRange_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x06001991 RID: 6545 RVA: 0x000A4FFC File Offset: 0x000A31FC
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BatchViewRangeUI.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/viewrange/ui/control/batchviewrangeui.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001992 RID: 6546 RVA: 0x000A5044 File Offset: 0x000A3244
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u001B\u0012\u000E.\u001F(R), new RoutedEventHandler(this.BatchViewRange_Loaded));
				return;
			case 2:
				this.LL = \u000B\u000A\u000E.\u001F(R);
				return;
			case 3:
				this.SL = \u000B\u000A\u000E.\u001F(R);
				return;
			case 4:
				this.BL = \u000B\u000A\u000E.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x04000A1F RID: 2591
		[CompilerGenerated]
		private BatchViewRangeViewModel CL;

		// Token: 0x04000A20 RID: 2592
		internal ComboBox LL;

		// Token: 0x04000A21 RID: 2593
		internal ComboBox SL;

		// Token: 0x04000A22 RID: 2594
		internal ComboBox BL;

		// Token: 0x04000A23 RID: 2595
		private bool R;
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetGen.Delegates;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002D6 RID: 726
	public class SheetsNew : DiRootsWindow, IComponentConnector
	{
		// Token: 0x06001DF9 RID: 7673 RVA: 0x000BCBE8 File Offset: 0x000BADE8
		public SheetsNew()
		{
			\u0012\u0013\u0016.\u000A(this);
			\u0005\u001B\u000A.\u0018.\u001D<\u001C\u0014>(this, new Action<\u001C\u0014>(this.PCR));
		}

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x06001DFA RID: 7674 RVA: 0x000BCC1C File Offset: 0x000BAE1C
		// (remove) Token: 0x06001DFB RID: 7675 RVA: 0x000BCC6C File Offset: 0x000BAE6C
		public event TaskFinishedHandler TaskFinished
		{
			[CompilerGenerated]
			add
			{
				TaskFinishedHandler taskFinishedHandler = this.VL;
				TaskFinishedHandler taskFinishedHandler2;
				do
				{
					taskFinishedHandler2 = taskFinishedHandler;
					TaskFinishedHandler value2 = \u000A\u0003\u000E.\u001F(\u000F\u001E\u000A.\u000A(taskFinishedHandler2, value));
					taskFinishedHandler = Interlocked.CompareExchange<TaskFinishedHandler>(ref this.VL, value2, taskFinishedHandler2);
				}
				while (taskFinishedHandler != taskFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsNew.add_TaskFinished(TaskFinishedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				TaskFinishedHandler taskFinishedHandler = this.VL;
				TaskFinishedHandler taskFinishedHandler2;
				do
				{
					taskFinishedHandler2 = taskFinishedHandler;
					TaskFinishedHandler value2 = \u000A\u0003\u000E.\u001F(\u0012\u001E\u000A.\u000A(taskFinishedHandler2, value));
					taskFinishedHandler = Interlocked.CompareExchange<TaskFinishedHandler>(ref this.VL, value2, taskFinishedHandler2);
				}
				while (taskFinishedHandler != taskFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsNew.remove_TaskFinished(TaskFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x06001DFC RID: 7676 RVA: 0x000BCCBC File Offset: 0x000BAEBC
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001DFD RID: 7677 RVA: 0x000BCCD0 File Offset: 0x000BAED0
		private void Window_ContentRendered(object sender, EventArgs e)
		{
			if (\u0019\u000C\u0007.\u001D(this.GL) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsNew.Window_ContentRendered(object, EventArgs)).MethodHandle;
				}
				return;
			}
			\u0006\u001E\u0016.\u000A(this.GL, \u0019\u000C\u0007.\u001D(this.GL));
			\u0005\u001E\u0016.\u000A(\u001D\u0007\u000E.\u001F(\u000B\u001E\u0016.\u000A(\u0002\u001E\u0016.\u000A(this.GL), \u0019\u000C\u0007.\u001D(this.GL))), \u0016\u001E\u0016.\u000A(FocusNavigationDirection.Next));
			\u0003\u000C\u000A.\u001D(this.GL);
		}

		// Token: 0x06001DFE RID: 7678 RVA: 0x000BCD5C File Offset: 0x000BAF5C
		private void PCR(\u001C\u0014 F)
		{
			\u0019\u000B\u0007.\u0007(this);
			\u0005\u001B\u000A.\u0018.\u0004<\u001C\u0014>(this);
		}

		// Token: 0x06001DFF RID: 7679 RVA: 0x000BCD7C File Offset: 0x000BAF7C
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsNew.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/sheetsnew.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001E00 RID: 7680 RVA: 0x000BCDC4 File Offset: 0x000BAFC4
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0020\u0002\u0019.\u000A(\u000C\u001C\u000E.\u001F(R), new EventHandler(this.Window_ContentRendered));
				return;
			case 2:
				this.ML = \u0001\u000A\u000E.\u001F(R);
				return;
			case 3:
				this.UD = \u0005\u0009\u0010.\u001F(R);
				return;
			case 4:
				this.VU = \u0016\u0009\u0010.\u001F(R);
				return;
			case 5:
				this.OL = \u0016\u0009\u0010.\u001F(R);
				return;
			case 6:
				this.TL = \u0016\u0009\u0010.\u001F(R);
				return;
			case 7:
				this.GL = \u0020\u0001\u0010.\u001F(R);
				return;
			case 8:
				this.KR = \u001B\u0001\u0010.\u001F(R);
				return;
			case 9:
				this.YL = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.YL, new RoutedEventHandler(this.btnCancel_Click));
				return;
			case 10:
				this.FS = \u001E\u0001\u0010.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x04000C37 RID: 3127
		[CompilerGenerated]
		private TaskFinishedHandler VL;

		// Token: 0x04000C38 RID: 3128
		internal TextBox ML;

		// Token: 0x04000C39 RID: 3129
		internal WatermarkTextBox UD;

		// Token: 0x04000C3A RID: 3130
		internal CheckBox VU;

		// Token: 0x04000C3B RID: 3131
		internal CheckBox OL;

		// Token: 0x04000C3C RID: 3132
		internal CheckBox TL;

		// Token: 0x04000C3D RID: 3133
		internal DataGrid GL;

		// Token: 0x04000C3E RID: 3134
		internal TextBlock KR;

		// Token: 0x04000C3F RID: 3135
		internal Button YL;

		// Token: 0x04000C40 RID: 3136
		internal Button FS;

		// Token: 0x04000C41 RID: 3137
		private bool R;
	}
}

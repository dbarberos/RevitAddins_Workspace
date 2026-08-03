using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetGen.Delegates;
using DiRoots.One.SheetGen.DI.Interfaces;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002CD RID: 717
	public class DuplicateSheet : DiRootsWindow, IDuplicateSheet, IComponentConnector
	{
		// Token: 0x06001D24 RID: 7460 RVA: 0x000B8034 File Offset: 0x000B6234
		public DuplicateSheet()
		{
			\u001E\u0011\u0016.\u000A(this);
		}

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x06001D25 RID: 7461 RVA: 0x000B8050 File Offset: 0x000B6250
		// (remove) Token: 0x06001D26 RID: 7462 RVA: 0x000B80A0 File Offset: 0x000B62A0
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
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateSheet.add_TaskFinished(TaskFinishedHandler)).MethodHandle;
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateSheet.remove_TaskFinished(TaskFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x1700082A RID: 2090
		// (get) Token: 0x06001D27 RID: 7463 RVA: 0x000B80F0 File Offset: 0x000B62F0
		// (set) Token: 0x06001D28 RID: 7464 RVA: 0x000B8104 File Offset: 0x000B6304
		public SheetInfo SelectedSheet { get; set; }

		// Token: 0x06001D29 RID: 7465 RVA: 0x000B8118 File Offset: 0x000B6318
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\DuplicationWindows\\DuplicateSheet.xaml.cs", "Window_Loaded");
			\u0014\u001A\u000A.\u000A(this.KR, \u0004\u001E\u000A.\u000A(\u0014\u0011\u0016.\u000A(), " 0"));
			\u0015\u0009\u000A.\u000A(this.GL, false);
			object kr = this.KR;
			string u001F = \u0014\u0011\u0016.\u000A();
			string u000A = " ";
			int num = \u001D\u001D\u0016.\u000A(\u0014\u0007\u0016.\u000A());
			\u0014\u001A\u000A.\u000A(kr, \u0002\u0013\u000A.\u000A(u001F, u000A, \u0017\u0011\u0016.\u000A(ref num, \u001F\u0015\u000A.\u000A())));
			ICollectionView u000A2 = \u0011\u0009\u000A.\u000A(\u0014\u0007\u0016.\u000A());
			\u0018\u000C\u0007.\u000A(this.GL, u000A2);
			\u0012\u0002\u0019.\u000A(this.GL, \u0020\u0011\u0016.\u000A(this));
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\DuplicationWindows\\DuplicateSheet.xaml.cs", "Window_Loaded");
		}

		// Token: 0x06001D2A RID: 7466 RVA: 0x000B81E8 File Offset: 0x000B63E8
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001D2B RID: 7467 RVA: 0x000B81FC File Offset: 0x000B63FC
		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex u001F = \u0015\u000F\u0007.\u000A("[^0-9]+");
			\u0019\u0013\u000A.\u000A(e, \u000C\u000F\u0007.\u001D(u001F, \u0001\u0015\u0007.\u000A(e)));
		}

		// Token: 0x06001D2C RID: 7468 RVA: 0x000B822C File Offset: 0x000B642C
		private void txtNumberOfSheets_LostFocus(object sender, RoutedEventArgs e)
		{
			if (!\u001A\u0006\u0007.\u000A(\u0003\u000B\u0019.\u0007(this.ML)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateSheet.txtNumberOfSheets_LostFocus(object, RoutedEventArgs)).MethodHandle;
				}
				if (\u0013\u0011\u0016.\u000A(\u0003\u000B\u0019.\u0007(this.ML), \u001F\u0015\u000A.\u000A()) != 0)
				{
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
			}
			\u001A\u0015\u0007.\u000A(this.ML, "1");
		}

		// Token: 0x06001D2D RID: 7469 RVA: 0x000B829C File Offset: 0x000B649C
		private void btnSelect_Click(object sender, RoutedEventArgs e)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\DuplicationWindows\\DuplicateSheet.xaml.cs", "btnSelect_Click");
			\u000B\u0008 u000B_u = new \u000B\u0008();
			\u0018\u001E\u0016.\u000A(u000B_u, \u0001\u0011\u0016.\u000A(\u0003\u0015\u000A.\u000A(this.QL), \u001F\u0015\u000A.\u000A()));
			\u0019\u001E\u0016.\u000A(u000B_u, \u0019\u0003\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.GL)));
			\u0004\u001E\u0016.\u000A(u000B_u, \u0020\u0011\u0016.\u000A(this));
			\u001D\u001E\u0016.\u000A(u000B_u, \u0013\u0011\u0016.\u000A(\u0003\u000B\u0019.\u0007(this.ML), \u001F\u0015\u000A.\u000A()));
			\u0007\u001E\u0016.\u000A(u000B_u, \u0001\u0011\u0016.\u000A(\u0003\u0015\u000A.\u000A(this.XL), \u001F\u0015\u000A.\u000A()));
			\u000A\u001E\u0016.\u000A(u000B_u, \u0001\u0011\u0016.\u000A(\u0003\u0015\u000A.\u000A(this.OL), \u001F\u0015\u000A.\u000A()));
			\u001F\u001E\u0016.\u000A(u000B_u, \u0001\u0011\u0016.\u000A(\u0003\u0015\u000A.\u000A(this.TL), \u001F\u0015\u000A.\u000A()));
			\u0009\u0011\u0016.\u000A(u000B_u, \u0001\u0011\u0016.\u000A(\u0003\u0015\u000A.\u000A(this.IL), \u001F\u0015\u000A.\u000A()));
			\u0015\u0011\u0016.\u000A(u000B_u, \u0001\u0011\u0016.\u000A(\u0003\u0015\u000A.\u000A(this.AL), \u001F\u0015\u000A.\u000A()));
			\u001A\u0011\u0016.\u000A(u000B_u, \u000C\u0011\u0016.\u000A(\u0012\u000C\u000A.\u000A(this.PL), \u001F\u0015\u000A.\u000A()));
			\u000B\u0008 u000B_u2 = u000B_u;
			u000B_u2.\u001F += this.ZYR;
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000B_u2);
			\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\DuplicationWindows\\DuplicateSheet.xaml.cs", "btnSelect_Click");
		}

		// Token: 0x06001D2E RID: 7470 RVA: 0x000B845C File Offset: 0x000B665C
		private void ZYR()
		{
			TaskFinishedHandler vl = this.VL;
			if (vl == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateSheet.ZYR()).MethodHandle;
				}
			}
			else
			{
				\u001C\u0007\u0016.\u000A(vl);
			}
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001D2F RID: 7471 RVA: 0x000B8494 File Offset: 0x000B6694
		private void Window_ContentRendered(object sender, EventArgs e)
		{
			if (\u0019\u000C\u0007.\u001D(this.GL) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateSheet.Window_ContentRendered(object, EventArgs)).MethodHandle;
				}
				\u0006\u001E\u0016.\u000A(this.GL, \u0019\u000C\u0007.\u001D(this.GL));
				\u0005\u001E\u0016.\u000A(\u001D\u0007\u000E.\u001F(\u000B\u001E\u0016.\u000A(\u0002\u001E\u0016.\u000A(this.GL), \u0019\u000C\u0007.\u001D(this.GL))), \u0016\u001E\u0016.\u000A(FocusNavigationDirection.Next));
				\u0003\u000C\u000A.\u001D(this.GL);
			}
		}

		// Token: 0x06001D30 RID: 7472 RVA: 0x000B8520 File Offset: 0x000B6720
		private void chkDuplicateViews_Click(object sender, RoutedEventArgs e)
		{
			bool? flag = \u0003\u0015\u000A.\u000A(this.XL);
			bool flag2 = false;
			if (\u0012\u0015\u000A.\u000A(ref flag) == flag2 & \u000D\u0003\u001D.\u000A(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateSheet.chkDuplicateViews_Click(object, RoutedEventArgs)).MethodHandle;
				}
				flag = \u0003\u0015\u000A.\u000A(this.QL);
				flag2 = false;
				if (\u0012\u0015\u000A.\u000A(ref flag) == flag2 & \u000D\u0003\u001D.\u000A(ref flag))
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
					\u0015\u0009\u000A.\u000A(this.GL, true);
					return;
				}
			}
			\u0015\u0009\u000A.\u000A(this.GL, false);
			\u0012\u0002\u0019.\u000A(this.GL, \u0020\u0011\u0016.\u000A(this));
		}

		// Token: 0x06001D31 RID: 7473 RVA: 0x000B85C8 File Offset: 0x000B67C8
		private void chkChangeTemplate_Checked(object sender, RoutedEventArgs e)
		{
			\u0015\u0009\u000A.\u000A(this.GL, true);
			\u000D\u000C\u0007.\u000A(this.XL, new bool?(false));
			\u0015\u0009\u000A.\u000A(this.XL, false);
			\u000D\u000C\u0007.\u000A(this.OL, new bool?(false));
			\u0015\u0009\u000A.\u000A(this.OL, false);
			\u000D\u000C\u0007.\u000A(this.TL, new bool?(false));
			\u0015\u0009\u000A.\u000A(this.TL, false);
		}

		// Token: 0x06001D32 RID: 7474 RVA: 0x000B8638 File Offset: 0x000B6838
		private void chkChangeTemplate_Unchecked(object sender, RoutedEventArgs e)
		{
			\u0015\u0009\u000A.\u000A(this.XL, true);
			\u000D\u000C\u0007.\u000A(this.XL, new bool?(true));
			\u000D\u000C\u0007.\u000A(this.OL, new bool?(true));
			\u0015\u0009\u000A.\u000A(this.OL, true);
			\u000D\u000C\u0007.\u000A(this.TL, new bool?(true));
			\u0015\u0009\u000A.\u000A(this.TL, true);
			\u0015\u0009\u000A.\u000A(this.GL, false);
			\u0012\u0002\u0019.\u000A(this.GL, \u0020\u0011\u0016.\u000A(this));
		}

		// Token: 0x06001D33 RID: 7475 RVA: 0x000B86BC File Offset: 0x000B68BC
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateSheet.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/duplicationwindows/duplicatesheet.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001D34 RID: 7476 RVA: 0x000B8704 File Offset: 0x000B6904
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0020\u0002\u0019.\u000A(\u000B\u001C\u000E.\u001F(R), new EventHandler(this.Window_ContentRendered));
				\u0011\u000C\u000A.\u0007(\u000B\u001C\u000E.\u001F(R), new RoutedEventHandler(this.Window_Loaded));
				return;
			case 2:
				this.ML = \u0001\u000A\u000E.\u001F(R);
				\u000F\u001E\u0016.\u000A(this.ML, new RoutedEventHandler(this.txtNumberOfSheets_LostFocus));
				\u000F\u0001\u0007.\u000A(this.ML, new TextCompositionEventHandler(this.NumberValidationTextBox));
				return;
			case 3:
				this.XL = \u0016\u0009\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.XL, new RoutedEventHandler(this.chkDuplicateViews_Click));
				return;
			case 4:
				this.PL = \u000B\u000A\u000E.\u001F(R);
				return;
			case 5:
				this.OL = \u0016\u0009\u0010.\u001F(R);
				return;
			case 6:
				this.TL = \u0016\u0009\u0010.\u001F(R);
				return;
			case 7:
				this.IL = \u0016\u0009\u0010.\u001F(R);
				return;
			case 8:
				this.QL = \u0016\u0009\u0010.\u001F(R);
				\u000E\u0015\u000A.\u000A(this.QL, new RoutedEventHandler(this.chkChangeTemplate_Checked));
				\u000D\u0015\u000A.\u000A(this.QL, new RoutedEventHandler(this.chkChangeTemplate_Unchecked));
				return;
			case 9:
				this.AL = \u0016\u0009\u0010.\u001F(R);
				return;
			case 10:
				this.GL = \u0020\u0001\u0010.\u001F(R);
				return;
			case 11:
				this.KR = \u001A\u000A\u000E.\u001F(R);
				return;
			case 12:
				this.YL = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.YL, new RoutedEventHandler(this.btnCancel_Click));
				return;
			case 13:
				this.FS = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.FS, new RoutedEventHandler(this.btnSelect_Click));
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x06001D35 RID: 7477 RVA: 0x000B88E4 File Offset: 0x000B6AE4
		void IDuplicateSheet.SA(EventHandler F)
		{
			\u0016\u0015\u0007.\u001D(this, F);
		}

		// Token: 0x06001D36 RID: 7478 RVA: 0x000B88F8 File Offset: 0x000B6AF8
		void IDuplicateSheet.BA(EventHandler F)
		{
			\u0012\u001E\u0016.\u000A(this, F);
		}

		// Token: 0x06001D37 RID: 7479 RVA: 0x000B890C File Offset: 0x000B6B0C
		void IDuplicateSheet.UA()
		{
			\u0009\u0001\u0007.\u001D(this);
		}

		// Token: 0x04000BAC RID: 2988
		[CompilerGenerated]
		private TaskFinishedHandler VL;

		// Token: 0x04000BAD RID: 2989
		[CompilerGenerated]
		private SheetInfo ZL;

		// Token: 0x04000BAE RID: 2990
		internal TextBox ML;

		// Token: 0x04000BAF RID: 2991
		internal CheckBox XL;

		// Token: 0x04000BB0 RID: 2992
		internal ComboBox PL;

		// Token: 0x04000BB1 RID: 2993
		internal CheckBox OL;

		// Token: 0x04000BB2 RID: 2994
		internal CheckBox TL;

		// Token: 0x04000BB3 RID: 2995
		internal CheckBox IL;

		// Token: 0x04000BB4 RID: 2996
		internal CheckBox QL;

		// Token: 0x04000BB5 RID: 2997
		internal CheckBox AL;

		// Token: 0x04000BB6 RID: 2998
		internal DataGrid GL;

		// Token: 0x04000BB7 RID: 2999
		internal Label KR;

		// Token: 0x04000BB8 RID: 3000
		internal Button YL;

		// Token: 0x04000BB9 RID: 3001
		internal Button FS;

		// Token: 0x04000BBA RID: 3002
		private bool R;
	}
}

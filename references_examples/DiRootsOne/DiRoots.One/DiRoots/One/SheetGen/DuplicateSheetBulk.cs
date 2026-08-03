using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
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
	// Token: 0x020002CE RID: 718
	public class DuplicateSheetBulk : DiRootsWindow, IDuplicateSheetBulk, IComponentConnector
	{
		// Token: 0x06001D38 RID: 7480 RVA: 0x000B8920 File Offset: 0x000B6B20
		public DuplicateSheetBulk()
		{
			\u0003\u001E\u0016.\u000A(this);
		}

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x06001D39 RID: 7481 RVA: 0x000B893C File Offset: 0x000B6B3C
		// (remove) Token: 0x06001D3A RID: 7482 RVA: 0x000B898C File Offset: 0x000B6B8C
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
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateSheetBulk.add_TaskFinished(TaskFinishedHandler)).MethodHandle;
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
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateSheetBulk.remove_TaskFinished(TaskFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x1700082B RID: 2091
		// (get) Token: 0x06001D3B RID: 7483 RVA: 0x000B89DC File Offset: 0x000B6BDC
		// (set) Token: 0x06001D3C RID: 7484 RVA: 0x000B89F0 File Offset: 0x000B6BF0
		public List<SheetInfo> TargetSheets { get; set; }

		// Token: 0x06001D3D RID: 7485 RVA: 0x000B8A04 File Offset: 0x000B6C04
		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex u001F = \u0015\u000F\u0007.\u000A("[^0-9]+");
			\u0019\u0013\u000A.\u000A(e, \u000C\u000F\u0007.\u001D(u001F, \u0001\u0015\u0007.\u000A(e)));
		}

		// Token: 0x06001D3E RID: 7486 RVA: 0x000B8A34 File Offset: 0x000B6C34
		private void txtNumberOfSheets_LostFocus(object sender, RoutedEventArgs e)
		{
			if (!\u001A\u0006\u0007.\u000A(\u0003\u000B\u0019.\u0007(this.ML)))
			{
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateSheetBulk.txtNumberOfSheets_LostFocus(object, RoutedEventArgs)).MethodHandle;
				}
				if (\u0013\u0011\u0016.\u000A(\u0003\u000B\u0019.\u0007(this.ML), \u001F\u0015\u000A.\u000A()) != 0)
				{
					return;
				}
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			\u001A\u0015\u0007.\u000A(this.ML, "1");
		}

		// Token: 0x06001D3F RID: 7487 RVA: 0x000B8AA4 File Offset: 0x000B6CA4
		private void btnSelect_Click(object sender, RoutedEventArgs e)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\DuplicationWindows\\DuplicateSheetBulk.xaml.cs", "btnSelect_Click");
			\u0018\u0008 u0018_u = new \u0018\u0008();
			\u001E\u001E\u0016.\u000A(u0018_u, \u0020\u001E\u0016.\u000A(this));
			\u0011\u001E\u0016.\u000A(u0018_u, \u0013\u0011\u0016.\u000A(\u0003\u000B\u0019.\u0007(this.ML), \u001F\u0015\u000A.\u000A()));
			\u001B\u001E\u0016.\u000A(u0018_u, \u0001\u0011\u0016.\u000A(\u0003\u0015\u000A.\u000A(this.XL), \u001F\u0015\u000A.\u000A()));
			\u0008\u001E\u0016.\u000A(u0018_u, \u0001\u0011\u0016.\u000A(\u0003\u0015\u000A.\u000A(this.OL), \u001F\u0015\u000A.\u000A()));
			\u000E\u001E\u0016.\u000A(u0018_u, \u0001\u0011\u0016.\u000A(\u0003\u0015\u000A.\u000A(this.TL), \u001F\u0015\u000A.\u000A()));
			\u0010\u001E\u0016.\u000A(u0018_u, \u0001\u0011\u0016.\u000A(\u0003\u0015\u000A.\u000A(this.IL), \u001F\u0015\u000A.\u000A()));
			bool? flag = \u0003\u0015\u000A.\u000A(this.AL);
			\u000D\u001E\u0016.\u000A(u0018_u, \u0019\u0020\u000A.\u000A(ref flag));
			\u001C\u001E\u0016.\u000A(u0018_u, \u000C\u0011\u0016.\u000A(\u0012\u000C\u000A.\u000A(this.PL), \u001F\u0015\u000A.\u000A()));
			\u0018\u0008 u0018_u2 = u0018_u;
			u0018_u2.\u001F += this.ZYR;
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u0018_u2);
			\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\DuplicationWindows\\DuplicateSheetBulk.xaml.cs", "btnSelect_Click");
		}

		// Token: 0x06001D40 RID: 7488 RVA: 0x000B8C1C File Offset: 0x000B6E1C
		private void ZYR()
		{
			TaskFinishedHandler vl = this.VL;
			if (vl == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateSheetBulk.ZYR()).MethodHandle;
				}
			}
			else
			{
				\u001C\u0007\u0016.\u000A(vl);
			}
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001D41 RID: 7489 RVA: 0x000B8C54 File Offset: 0x000B6E54
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateSheetBulk.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/duplicationwindows/duplicatesheetbulk.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001D42 RID: 7490 RVA: 0x000B8C9C File Offset: 0x000B6E9C
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.ML = \u0001\u000A\u000E.\u001F(R);
				\u000F\u001E\u0016.\u000A(this.ML, new RoutedEventHandler(this.txtNumberOfSheets_LostFocus));
				\u000F\u0001\u0007.\u000A(this.ML, new TextCompositionEventHandler(this.NumberValidationTextBox));
				return;
			case 2:
				this.XL = \u0016\u0009\u0010.\u001F(R);
				return;
			case 3:
				this.PL = \u000B\u000A\u000E.\u001F(R);
				return;
			case 4:
				this.OL = \u0016\u0009\u0010.\u001F(R);
				return;
			case 5:
				this.TL = \u0016\u0009\u0010.\u001F(R);
				return;
			case 6:
				this.IL = \u0016\u0009\u0010.\u001F(R);
				return;
			case 7:
				this.AL = \u0016\u0009\u0010.\u001F(R);
				return;
			case 8:
				this.FS = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.FS, new RoutedEventHandler(this.btnSelect_Click));
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x06001D43 RID: 7491 RVA: 0x000B8D9C File Offset: 0x000B6F9C
		void IDuplicateSheetBulk.WA(EventHandler F)
		{
			\u0016\u0015\u0007.\u001D(this, F);
		}

		// Token: 0x06001D44 RID: 7492 RVA: 0x000B8DB0 File Offset: 0x000B6FB0
		void IDuplicateSheetBulk.KA(EventHandler F)
		{
			\u0012\u001E\u0016.\u000A(this, F);
		}

		// Token: 0x06001D45 RID: 7493 RVA: 0x000B8DC4 File Offset: 0x000B6FC4
		void IDuplicateSheetBulk.JA()
		{
			\u0009\u0001\u0007.\u001D(this);
		}

		// Token: 0x04000BBB RID: 3003
		[CompilerGenerated]
		private TaskFinishedHandler VL;

		// Token: 0x04000BBC RID: 3004
		[CompilerGenerated]
		private List<SheetInfo> RS;

		// Token: 0x04000BBD RID: 3005
		internal TextBox ML;

		// Token: 0x04000BBE RID: 3006
		internal CheckBox XL;

		// Token: 0x04000BBF RID: 3007
		internal ComboBox PL;

		// Token: 0x04000BC0 RID: 3008
		internal CheckBox OL;

		// Token: 0x04000BC1 RID: 3009
		internal CheckBox TL;

		// Token: 0x04000BC2 RID: 3010
		internal CheckBox IL;

		// Token: 0x04000BC3 RID: 3011
		internal CheckBox AL;

		// Token: 0x04000BC4 RID: 3012
		internal Button FS;

		// Token: 0x04000BC5 RID: 3013
		private bool R;
	}
}

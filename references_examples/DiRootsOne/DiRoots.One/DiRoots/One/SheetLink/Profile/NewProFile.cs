using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.One.SheetLink.Profile
{
	// Token: 0x02000234 RID: 564
	public class NewProFile : DiRootsWindow, IComponentConnector
	{
		// Token: 0x0600162A RID: 5674 RVA: 0x00091CEC File Offset: 0x0008FEEC
		public NewProFile(string currentDirectory, List<string> existingNames)
		{
			\u0014\u0006\u0005.\u000A(this);
			\u0017\u001A\u000A.\u001D(this.H, this);
			this.TC = currentDirectory;
			this.OC = existingNames;
			\u001A\u0015\u0007.\u000A(this.RL, this.TC);
		}

		// Token: 0x1700060A RID: 1546
		// (get) Token: 0x0600162B RID: 5675 RVA: 0x00091D30 File Offset: 0x0008FF30
		public CommandBase SaveCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.MYR), new Predicate<object>(this.CanSaveMethod));
			}
		}

		// Token: 0x1700060B RID: 1547
		// (get) Token: 0x0600162C RID: 5676 RVA: 0x00091D5C File Offset: 0x0008FF5C
		// (set) Token: 0x0600162D RID: 5677 RVA: 0x00091D70 File Offset: 0x0008FF70
		public Profile NewProfile { get; set; }

		// Token: 0x1700060C RID: 1548
		// (get) Token: 0x0600162E RID: 5678 RVA: 0x00091D84 File Offset: 0x0008FF84
		// (set) Token: 0x0600162F RID: 5679 RVA: 0x00091D98 File Offset: 0x0008FF98
		public bool IsImportedFromFile { get; set; }

		// Token: 0x06001630 RID: 5680 RVA: 0x00091DAC File Offset: 0x0008FFAC
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			\u0011\u000E\u0019.\u0007(this.GC);
		}

		// Token: 0x06001631 RID: 5681 RVA: 0x00091DC8 File Offset: 0x0008FFC8
		private void btnCreateClick(object sender, RoutedEventArgs e)
		{
			this.MYR();
		}

		// Token: 0x06001632 RID: 5682 RVA: 0x00091DDC File Offset: 0x0008FFDC
		private void txtName_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (\u001A\u001A\u0019.\u000A(e) == Key.Return)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewProFile.txtName_KeyUp(object, System.Windows.Input.KeyEventArgs)).MethodHandle;
				}
				if (\u0013\u0006\u0005.\u000A(this, \u0019\u001D\u000E.\u001F))
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
					this.MYR();
				}
			}
		}

		// Token: 0x06001633 RID: 5683 RVA: 0x00091E28 File Offset: 0x00090028
		private void MYR()
		{
			string text = \u001B\u0015\u001D.\u000A(\u0003\u000B\u0019.\u0007(this.RL), \u0004\u001E\u000A.\u000A(\u0003\u000B\u0019.\u0007(this.GC), ".xml"));
			if (!\u001A\u0006\u0007.\u000A(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewProFile.MYR()).MethodHandle;
				}
				\u001F\u000F\u0005.\u000A(this, false);
				\u0001\u0006\u0005.\u000A(this, \u0009\u0006\u0005.\u000A());
				\u0015\u0006\u0005.\u000A(\u000C\u0006\u0005.\u0007(this), \u0003\u000B\u0019.\u0007(this.GC));
				\u001A\u0006\u0005.\u000A(\u000C\u0006\u0005.\u0007(this), text);
				\u0006\u0015\u0007.\u0007(this, new bool?(true));
			}
		}

		// Token: 0x06001634 RID: 5684 RVA: 0x00091EC8 File Offset: 0x000900C8
		private void rdbImportFromFile_Checked(object sender, RoutedEventArgs e)
		{
			\u0015\u0009\u000A.\u000A(this.GC, false);
		}

		// Token: 0x06001635 RID: 5685 RVA: 0x00091EE4 File Offset: 0x000900E4
		private void rdbImportFromFile_Unchecked(object sender, RoutedEventArgs e)
		{
			\u0015\u0009\u000A.\u000A(this.GC, true);
		}

		// Token: 0x06001636 RID: 5686 RVA: 0x00091F00 File Offset: 0x00090100
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001637 RID: 5687 RVA: 0x00091F14 File Offset: 0x00090114
		public bool CanSaveMethod(object o = null)
		{
			\u000F\u0015\u0007.\u000A(this.HL, "");
			string text = \u0018\u0006\u001D.\u0007(\u0003\u000B\u001D.\u0007(\u0003\u000B\u0019.\u0007(this.GC)));
			if (\u001A\u0006\u0007.\u000A(\u0003\u000B\u0019.\u0007(this.RL)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewProFile.CanSaveMethod(object)).MethodHandle;
				}
				\u000F\u0015\u0007.\u000A(this.HL, \u001D\u000F\u0005.\u000A());
				return false;
			}
			if (this.VYR(\u0003\u000B\u0019.\u0007(this.GC), false))
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
				\u000F\u0015\u0007.\u000A(this.KR, \u0007\u000F\u0005.\u000A());
				return false;
			}
			if (!\u001A\u0006\u0007.\u000A(text))
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
				if (!\u001F\u0020\u001D.\u000A(this.OC, text))
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
					\u000F\u0015\u0007.\u000A(this.KR, "");
					return true;
				}
			}
			if (!\u001A\u0006\u0007.\u000A(text))
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
				\u000F\u0015\u0007.\u000A(this.KR, \u000A\u000F\u0005.\u000A());
			}
			return false;
		}

		// Token: 0x06001638 RID: 5688 RVA: 0x00092028 File Offset: 0x00090228
		private void chkImportFromFile_Unchecked(object sender, RoutedEventArgs e)
		{
			\u0014\u001A\u000A.\u000A(this.H, \u0004\u000F\u0005.\u000A());
		}

		// Token: 0x06001639 RID: 5689 RVA: 0x00092048 File Offset: 0x00090248
		private void chkImportFromFile_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u001A\u000A.\u000A(this.H, \u0019\u000F\u0005.\u000A());
		}

		// Token: 0x0600163A RID: 5690 RVA: 0x00092068 File Offset: 0x00090268
		private void btnBrowse_Click(object sender, RoutedEventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = \u000B\u000F\u0005.\u000A();
			\u0016\u000F\u0005.\u000A(folderBrowserDialog, this.TC);
			FolderBrowserDialog folderBrowserDialog2 = folderBrowserDialog;
			try
			{
				if (\u0005\u000F\u0005.\u000A(folderBrowserDialog2) == System.Windows.Forms.DialogResult.OK)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(NewProFile.btnBrowse_Click(object, RoutedEventArgs)).MethodHandle;
					}
					if (!\u0010\u0010\u001D.\u000A(\u0018\u000F\u0005.\u000A(folderBrowserDialog2)))
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
						\u001A\u0015\u0007.\u000A(this.RL, \u0018\u000F\u0005.\u000A(folderBrowserDialog2));
					}
				}
			}
			finally
			{
				if (folderBrowserDialog2 != null)
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
					\u001F\u0017\u000A.\u000A(folderBrowserDialog2);
				}
			}
		}

		// Token: 0x0600163B RID: 5691 RVA: 0x000920FC File Offset: 0x000902FC
		private void txtName_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (this.VYR(\u0001\u0015\u0007.\u000A(e), false))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewProFile.txtName_PreviewTextInput(object, TextCompositionEventArgs)).MethodHandle;
				}
				\u0019\u0013\u000A.\u000A(e, true);
			}
		}

		// Token: 0x0600163C RID: 5692 RVA: 0x00092138 File Offset: 0x00090338
		private bool VYR(string F, bool R = false)
		{
			bool flag = false;
			char[] array = \u0017\u0001\u0007.\u000A();
			for (int i = 0; i < (int)\u0014\u0007\u000E.\u001F(array); i++)
			{
				char c = array[i];
				if (\u000F\u000C\u001D.\u0007(F, \u001E\u000E\u0004.\u000A(ref c)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(NewProFile.VYR(string, bool)).MethodHandle;
					}
					flag = true;
					IL_56:
					if (flag && R)
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
						\u0008\u0011\u001D.\u000A(\u0007\u000F\u0005.\u000A());
					}
					return flag;
				}
			}
			for (;;)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				goto IL_56;
			}
		}

		// Token: 0x0600163D RID: 5693 RVA: 0x000921BC File Offset: 0x000903BC
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewProFile.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink.core/profile/newprofile.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x0600163E RID: 5694 RVA: 0x00092204 File Offset: 0x00090404
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u0001\u000F\u000E.\u001F(R), new RoutedEventHandler(this.Window_Loaded));
				return;
			case 2:
				this.AC = \u001A\u000A\u000E.\u001F(R);
				return;
			case 3:
				this.GC = \u0001\u000A\u000E.\u001F(R);
				\u000A\u000C\u0019.\u000A(this.GC, new System.Windows.Input.KeyEventHandler(this.txtName_KeyUp));
				\u000F\u0001\u0007.\u000A(this.GC, new TextCompositionEventHandler(this.txtName_PreviewTextInput));
				return;
			case 4:
				this.KR = \u001B\u0001\u0010.\u001F(R);
				return;
			case 5:
				this.FL = \u001A\u000A\u000E.\u001F(R);
				return;
			case 6:
				this.RL = \u0001\u000A\u000E.\u001F(R);
				return;
			case 7:
				this.DL = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.DL, new RoutedEventHandler(this.btnBrowse_Click));
				return;
			case 8:
				this.HL = \u001B\u0001\u0010.\u001F(R);
				return;
			case 9:
				this.YL = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.YL, new RoutedEventHandler(this.btnCancel_Click));
				return;
			case 10:
				this.H = \u001E\u0001\u0010.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x040008C8 RID: 2248
		private readonly List<string> OC;

		// Token: 0x040008C9 RID: 2249
		private readonly string TC;

		// Token: 0x040008CA RID: 2250
		[CompilerGenerated]
		private Profile IC;

		// Token: 0x040008CB RID: 2251
		[CompilerGenerated]
		private bool QC;

		// Token: 0x040008CC RID: 2252
		internal System.Windows.Controls.Label AC;

		// Token: 0x040008CD RID: 2253
		internal System.Windows.Controls.TextBox GC;

		// Token: 0x040008CE RID: 2254
		internal TextBlock KR;

		// Token: 0x040008CF RID: 2255
		internal System.Windows.Controls.Label FL;

		// Token: 0x040008D0 RID: 2256
		internal System.Windows.Controls.TextBox RL;

		// Token: 0x040008D1 RID: 2257
		internal System.Windows.Controls.Button DL;

		// Token: 0x040008D2 RID: 2258
		internal TextBlock HL;

		// Token: 0x040008D3 RID: 2259
		internal System.Windows.Controls.Button YL;

		// Token: 0x040008D4 RID: 2260
		internal System.Windows.Controls.Button H;

		// Token: 0x040008D5 RID: 2261
		private bool R;
	}
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using DiRoots.ProfileControl.ValidationRules;
using ProSheets.Extensions;

namespace DiRoots.ProfileControl.UI
{
	// Token: 0x02000013 RID: 19
	public class NewProFile : DiRootsWindow, INewName, IComponentConnector
	{
		// Token: 0x06000079 RID: 121 RVA: 0x00004D28 File Offset: 0x00002F28
		public NewProFile(string currentDirectory, List<string> existingNames)
		{
			\u0013\u000B\u0018.\u0018(this);
			\u001C\u000B\u0018.\u0014(this.JB, this);
			this.UB = currentDirectory;
			\u000D\u000B\u0018.InvokeStub(this, Enumerable.ToList<object>(Enumerable.Cast<object>(existingNames)));
			\u0012\u000B\u0018.\u0018(this.BQ, this.UB);
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00004D7C File Offset: 0x00002F7C
		// (set) Token: 0x0600007B RID: 123 RVA: 0x00004D90 File Offset: 0x00002F90
		public Profile NewProfile { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00004DA4 File Offset: 0x00002FA4
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00004DB8 File Offset: 0x00002FB8
		public bool IsImportedFromFile { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00004DCC File Offset: 0x00002FCC
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00004DE0 File Offset: 0x00002FE0
		[Dynamic(new bool[]
		{
			false,
			true
		})]
		public List<dynamic> ProfileNames
		{
			[return: Dynamic(new bool[]
			{
				false,
				true
			})]
			get
			{
				return this.SB;
			}
			[param: Dynamic(new bool[]
			{
				false,
				true
			})]
			set
			{
				this.SB = value;
				\u0009\u000B\u0018.\u0018(this, "ProfileNames");
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00004E00 File Offset: 0x00003000
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00004E14 File Offset: 0x00003014
		public string NewName
		{
			get
			{
				return this.LB;
			}
			set
			{
				this.LB = value;
				\u0009\u000B\u0018.\u0018(this, "NewName");
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00004E34 File Offset: 0x00003034
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00004E48 File Offset: 0x00003048
		public string SaveMode { get; private set; }

		// Token: 0x06000084 RID: 132 RVA: 0x00004E5C File Offset: 0x0000305C
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			\u000A\u000B\u0018.\u0014(this.KB);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00004E78 File Offset: 0x00003078
		private void btnBrowse_Click(object sender, RoutedEventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = \u0017\u000B\u0018.\u0018();
			\u0015\u000B\u0018.\u0018(folderBrowserDialog, this.UB);
			FolderBrowserDialog folderBrowserDialog2 = folderBrowserDialog;
			try
			{
				if (\u0011\u000B\u0018.\u0018(folderBrowserDialog2) == System.Windows.Forms.DialogResult.OK)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(NewProFile.btnBrowse_Click(object, RoutedEventArgs)).MethodHandle;
					}
					if (!\u001F\u000B\u0018.\u0018(\u0020\u000B\u0018.\u0018(folderBrowserDialog2)))
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
						\u0012\u000B\u0018.\u0018(this.BQ, \u0020\u000B\u0018.\u0018(folderBrowserDialog2));
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
					\u0020\u001E\u0018.\u0018(folderBrowserDialog2);
				}
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00004F0C File Offset: 0x0000310C
		[BindableMethod("OnKeyDown")]
		public void OnKeyDown(object sender, System.Windows.Input.KeyEventArgs args, bool isEnabled)
		{
			if (!isEnabled)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewProFile.OnKeyDown(object, System.Windows.Input.KeyEventArgs, bool)).MethodHandle;
				}
				return;
			}
			if (\u0018\u0004\u000F.\u000C(sender) != null)
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
				if (\u001A\u000B\u0018.\u0018(args) == Key.Return)
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
					\u001D\u000B\u0018.\u0018(args, true);
					if (!\u001F\u001A\u0018.\u0018(\u0004\u000B\u0018.\u0014(this)))
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
						\u001E\u000B\u0018.\u0018(this, this, \u0014\u0004\u000F.\u000C(\u0002\u000B\u0018.\u0018(this.JB)));
					}
				}
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00004F98 File Offset: 0x00003198
		[BindableMethod("Apply")]
		public void Apply(Window wnd, string saveOrUpdate)
		{
			\u0019\u000B\u0018.\u0018(this, saveOrUpdate);
			this.QZ();
			\u000B\u000B\u0018.\u0014(wnd);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00004FB8 File Offset: 0x000031B8
		private void QZ()
		{
			string text = \u0003\u001A\u0018.\u0018(\u0001\u000B\u0018.\u0018(this.BQ), \u000D\u001E\u0018.\u0018(\u0004\u000B\u0018.\u0014(this), ".xml"));
			if (!\u001F\u001A\u0018.\u0018(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewProFile.QZ()).MethodHandle;
				}
				\u0008\u000B\u0018.\u0018(this, false);
				Profile profile = \u001E\u001D\u0018.\u0018();
				\u0017\u001D\u0018.\u0018(profile, \u0004\u000B\u0018.\u0014(this));
				\u0006\u000B\u0018.\u0018(profile, text);
				\u0010\u000B\u0018.\u0018(this, profile);
				\u0007\u000B\u0018.\u0014(this, new bool?(true));
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005040 File Offset: 0x00003240
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00005054 File Offset: 0x00003254
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.Q)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewProFile.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.Q = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/drawingregister/profiles/newprofile.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000509C File Offset: 0x0000329C
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		internal Delegate TN(Type P, string Q)
		{
			return \u000E\u000B\u0018.\u0018(P, this, Q);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000050B4 File Offset: 0x000032B4
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		void IComponentConnector.CN(int P, object Q)
		{
			switch (P)
			{
			case 1:
				this.VB = \u0001\u0002\u000F.\u000C(Q);
				\u0018\u0019\u0018.\u0018(this.VB, new RoutedEventHandler(this.Window_Loaded));
				return;
			case 2:
				this.DB = \u001B\u0002\u000F.\u000C(Q);
				return;
			case 3:
				this.KB = \u0005\u0002\u000F.\u000C(Q);
				return;
			case 4:
				this.PQ = \u001B\u0002\u000F.\u000C(Q);
				return;
			case 5:
				this.BQ = \u0005\u0002\u000F.\u000C(Q);
				return;
			case 6:
				this.QQ = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.QQ, new RoutedEventHandler(this.btnBrowse_Click));
				return;
			case 7:
				this.JQ = \u000C\u0004\u000F.\u000C(Q);
				return;
			case 8:
				this.PB = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.PB, new RoutedEventHandler(this.btnCancel_Click));
				return;
			case 9:
				this.JB = \u000E\u0002\u000F.\u000C(Q);
				return;
			default:
				this.Q = true;
				return;
			}
		}

		// Token: 0x0400002E RID: 46
		[Dynamic(new bool[]
		{
			false,
			true
		})]
		private List<dynamic> SB;

		// Token: 0x0400002F RID: 47
		private readonly string UB;

		// Token: 0x04000030 RID: 48
		private string LB;

		// Token: 0x04000031 RID: 49
		[CompilerGenerated]
		private Profile EB;

		// Token: 0x04000032 RID: 50
		[CompilerGenerated]
		private bool GB;

		// Token: 0x04000033 RID: 51
		[CompilerGenerated]
		private string AB;

		// Token: 0x04000034 RID: 52
		internal NewProFile VB;

		// Token: 0x04000035 RID: 53
		internal System.Windows.Controls.Label DB;

		// Token: 0x04000036 RID: 54
		internal System.Windows.Controls.TextBox KB;

		// Token: 0x04000037 RID: 55
		internal System.Windows.Controls.Label PQ;

		// Token: 0x04000038 RID: 56
		internal System.Windows.Controls.TextBox BQ;

		// Token: 0x04000039 RID: 57
		internal System.Windows.Controls.Button QQ;

		// Token: 0x0400003A RID: 58
		internal TextBlock JQ;

		// Token: 0x0400003B RID: 59
		internal System.Windows.Controls.Button PB;

		// Token: 0x0400003C RID: 60
		internal System.Windows.Controls.Button JB;

		// Token: 0x0400003D RID: 61
		private bool Q;
	}
}

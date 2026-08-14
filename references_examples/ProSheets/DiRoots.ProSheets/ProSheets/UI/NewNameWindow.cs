using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using ProSheets.CommonData;
using ProSheets.Enums;
using ProSheets.Helper.Enums;
using ProSheets.UI.CommonData;

namespace ProSheets.UI
{
	// Token: 0x02000090 RID: 144
	public class NewNameWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x060008F1 RID: 2289 RVA: 0x00037BAC File Offset: 0x00035DAC
		public NewNameWindow()
		{
			\u0014\u0008\u0003.\u0018(this);
			\u0014\u0019\u0018.\u0018(this.JB, false);
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x060008F2 RID: 2290 RVA: 0x00037BD4 File Offset: 0x00035DD4
		// (set) Token: 0x060008F3 RID: 2291 RVA: 0x00037BE8 File Offset: 0x00035DE8
		public bool IsSaved { get; set; }

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x060008F4 RID: 2292 RVA: 0x00037BFC File Offset: 0x00035DFC
		// (set) Token: 0x060008F5 RID: 2293 RVA: 0x00037C10 File Offset: 0x00035E10
		public string CurrentTextName { get; set; }

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x060008F6 RID: 2294 RVA: 0x00037C24 File Offset: 0x00035E24
		// (set) Token: 0x060008F7 RID: 2295 RVA: 0x00037C38 File Offset: 0x00035E38
		public SavingMode Mode { get; set; }

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x060008F8 RID: 2296 RVA: 0x00037C4C File Offset: 0x00035E4C
		public CommandBase SaveCommand
		{
			get
			{
				return \u0003\u0008\u0003.\u0018(new Action(this.FZ), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x00037C74 File Offset: 0x00035E74
		private void FZ()
		{
			string text = \u0001\u000B\u0018.\u0018(this.KB);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewNameWindow.FZ()).MethodHandle;
				}
				\u000F\u0008\u0003.\u0018(this, true);
				\u0016\u0008\u0003.\u0018(this, text);
				\u000B\u000B\u0018.\u0003(this);
			}
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x060008FA RID: 2298 RVA: 0x00037CC0 File Offset: 0x00035EC0
		// (set) Token: 0x060008FB RID: 2299 RVA: 0x00037CD4 File Offset: 0x00035ED4
		public string NewName
		{
			get
			{
				return this.ZR;
			}
			set
			{
				this.ZR = value;
				\u0009\u000B\u0018.\u0018(this, "NewName");
			}
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x060008FC RID: 2300 RVA: 0x00037CF4 File Offset: 0x00035EF4
		// (set) Token: 0x060008FD RID: 2301 RVA: 0x00037D08 File Offset: 0x00035F08
		public ObservableCollection<ViewSheetSetInfo> Sets { get; set; }

		// Token: 0x060008FE RID: 2302 RVA: 0x00037D1C File Offset: 0x00035F1C
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x00037D30 File Offset: 0x00035F30
		private void txtName_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			TextBox textBox = \u0018\u0004\u000F.\u000C(sender);
			if (textBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewNameWindow.txtName_PreviewKeyDown(object, KeyEventArgs)).MethodHandle;
				}
				ValidationError validationError = Enumerable.FirstOrDefault<ValidationError>(\u000A\u0008\u0003.\u0018(textBox));
				object u000C;
				if (validationError == null)
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
					u000C = null;
				}
				else
				{
					u000C = \u0009\u0008\u0003.\u0018(validationError);
				}
				SaveSetValidationRule saveSetValidationRule = \u0013\u0007\u000F.\u000C(u000C);
				ErrorType? errorType2;
				if (saveSetValidationRule == null)
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
					ErrorType? errorType;
					\u0009\u0007\u000F.\u000C(ref errorType);
					errorType2 = errorType;
				}
				else
				{
					errorType2 = new ErrorType?(\u001C\u0008\u0003.\u0018(\u0013\u0008\u0003.\u0018(saveSetValidationRule)));
				}
				ErrorType? errorType3 = errorType2;
				if (\u001A\u000B\u0018.\u0018(e) == Key.Return)
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
					\u001D\u000B\u0018.\u0018(e, true);
					if (\u0012\u0008\u0003.\u0018(textBox))
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
						if (\u000D\u0008\u0003.\u0018(ref errorType3) == ErrorType.Warning)
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
							this.FZ();
							return;
						}
					}
					if (!\u0012\u0008\u0003.\u0018(textBox))
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
						if (\u0020\u0003\u0014.\u0003(this) != null)
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
							if (\u0009\u001E\u0018.\u0018(\u0020\u0003\u0014.\u0003(this), ""))
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
								this.FZ();
							}
						}
					}
				}
			}
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00037E58 File Offset: 0x00036058
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewNameWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.Q = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/ui/sets/newnamewindow.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x00037EA0 File Offset: 0x000360A0
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		internal Delegate TN(Type P, string Q)
		{
			return \u000E\u000B\u0018.\u0018(P, this, Q);
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x00037EB8 File Offset: 0x000360B8
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.CN(int P, object Q)
		{
			switch (P)
			{
			case 1:
				this.OR = \u001C\u0007\u000F.\u000C(Q);
				return;
			case 2:
				this.DB = \u000C\u0004\u000F.\u000C(Q);
				return;
			case 3:
				this.KB = \u0005\u0002\u000F.\u000C(Q);
				\u0020\u0008\u0003.\u0018(this.KB, new KeyEventHandler(this.txtName_PreviewKeyDown));
				return;
			case 4:
				this.DQ = \u000C\u0004\u000F.\u000C(Q);
				return;
			case 5:
				this.PB = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.PB, new RoutedEventHandler(this.btnCancel_Click));
				return;
			case 6:
				this.JB = \u000E\u0002\u000F.\u000C(Q);
				return;
			default:
				this.Q = true;
				return;
			}
		}

		// Token: 0x04000421 RID: 1057
		private string ZR;

		// Token: 0x04000422 RID: 1058
		[CompilerGenerated]
		private bool HR;

		// Token: 0x04000423 RID: 1059
		[CompilerGenerated]
		private string MR;

		// Token: 0x04000424 RID: 1060
		[CompilerGenerated]
		private SavingMode XR;

		// Token: 0x04000425 RID: 1061
		[CompilerGenerated]
		private ObservableCollection<ViewSheetSetInfo> YR;

		// Token: 0x04000426 RID: 1062
		internal NewNameWindow OR;

		// Token: 0x04000427 RID: 1063
		internal TextBlock DB;

		// Token: 0x04000428 RID: 1064
		internal TextBox KB;

		// Token: 0x04000429 RID: 1065
		internal TextBlock DQ;

		// Token: 0x0400042A RID: 1066
		internal Button PB;

		// Token: 0x0400042B RID: 1067
		internal Button JB;

		// Token: 0x0400042C RID: 1068
		private bool Q;
	}
}

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
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetGen.DI.Interfaces;
using DiRoots.One.SheetGen.Models;
using DiRoots.One.SheetGen.Models.Enums;
using DiRoots.One.SheetGen.UI.ValidationRules;

namespace DiRoots.One.SheetGen.UI.Windows
{
	// Token: 0x02000392 RID: 914
	public class NewViewSheetSetWindow : DiRootsWindow, INewViewSheetSet, IComponentConnector
	{
		// Token: 0x06002519 RID: 9497 RVA: 0x000E06C0 File Offset: 0x000DE8C0
		public NewViewSheetSetWindow()
		{
			\u0001\u0009\u000B.\u000A(this);
		}

		// Token: 0x17000A68 RID: 2664
		// (get) Token: 0x0600251A RID: 9498 RVA: 0x000E06DC File Offset: 0x000DE8DC
		public CommandBase SaveCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.SaveProfile), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000A69 RID: 2665
		// (get) Token: 0x0600251B RID: 9499 RVA: 0x000E0704 File Offset: 0x000DE904
		// (set) Token: 0x0600251C RID: 9500 RVA: 0x000E0718 File Offset: 0x000DE918
		public string NewName
		{
			get
			{
				return this.TW;
			}
			set
			{
				this.TW = value;
				\u0008\u0011\u0016.\u000A(this, "NewName");
			}
		}

		// Token: 0x17000A6A RID: 2666
		// (get) Token: 0x0600251D RID: 9501 RVA: 0x000E0738 File Offset: 0x000DE938
		// (set) Token: 0x0600251E RID: 9502 RVA: 0x000E074C File Offset: 0x000DE94C
		public SavingMode Mode { get; set; }

		// Token: 0x17000A6B RID: 2667
		// (get) Token: 0x0600251F RID: 9503 RVA: 0x000E0760 File Offset: 0x000DE960
		// (set) Token: 0x06002520 RID: 9504 RVA: 0x000E0774 File Offset: 0x000DE974
		public ObservableCollection<ViewSheetSetInfo> Sets
		{
			get
			{
				return this.IW;
			}
			set
			{
				this.IW = value;
				\u0008\u0011\u0016.\u000A(this, "Sets");
			}
		}

		// Token: 0x06002521 RID: 9505 RVA: 0x000E0794 File Offset: 0x000DE994
		public void SaveProfile()
		{
			if (\u0008\u0013\u000A.\u000A(\u001A\u000C\u000A.\u000A(\u0004\u000C\u0007.\u000A(this.H)), \u0015\u0002\u001D.\u000A()))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewViewSheetSetWindow.SaveProfile()).MethodHandle;
				}
				\u0009\u0009\u000B.\u000A(this, SavingMode.Save);
			}
			else
			{
				\u0009\u0009\u000B.\u000A(this, SavingMode.Update);
			}
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06002522 RID: 9506 RVA: 0x000E07FC File Offset: 0x000DE9FC
		private void OnCancel(object sender, RoutedEventArgs e)
		{
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06002523 RID: 9507 RVA: 0x000E0810 File Offset: 0x000DEA10
		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			TextBox textBox = \u0008\u000A\u000E.\u001F(sender);
			if (textBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewViewSheetSetWindow.OnKeyDown(object, KeyEventArgs)).MethodHandle;
				}
				ValidationError validationError = Enumerable.FirstOrDefault<ValidationError>(\u0018\u001F\u0002.\u000A(textBox));
				object u001F;
				if (validationError == null)
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
					u001F = null;
				}
				else
				{
					u001F = \u0019\u001F\u0002.\u000A(validationError);
				}
				CanSaveSheetSetValidationRule canSaveSheetSetValidationRule = \u000E\u000E\u000E.\u001F(u001F);
				ErrorType? errorType2;
				if (canSaveSheetSetValidationRule == null)
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
					ErrorType? errorType;
					\u0008\u000E\u000E.\u001F(ref errorType);
					errorType2 = errorType;
				}
				else
				{
					errorType2 = new ErrorType?(\u001D\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(canSaveSheetSetValidationRule)));
				}
				ErrorType? errorType3 = errorType2;
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
					\u0019\u0013\u000A.\u000A(e, true);
					if (\u0001\u0001\u0007.\u000A(textBox))
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
						if (\u0007\u001F\u0002.\u000A(ref errorType3) == ErrorType.Warning)
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
							\u001F\u001F\u0002.\u000A(this);
							return;
						}
					}
					if (!\u0001\u0001\u0007.\u000A(textBox))
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
						if (\u000A\u001F\u0002.\u0007(this) != null)
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
							if (\u001D\u0017\u000A.\u000A(\u000A\u001F\u0002.\u0007(this), ""))
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
								\u001F\u001F\u0002.\u000A(this);
							}
						}
					}
				}
			}
		}

		// Token: 0x06002524 RID: 9508 RVA: 0x000E0938 File Offset: 0x000DEB38
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewViewSheetSetWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/newviewsheetsetwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06002525 RID: 9509 RVA: 0x000E0980 File Offset: 0x000DEB80
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06002526 RID: 9510 RVA: 0x000E0998 File Offset: 0x000DEB98
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.PW = \u0010\u000E\u000E.\u001F(R);
				return;
			case 2:
				this.AC = \u001B\u0001\u0010.\u001F(R);
				return;
			case 3:
				this.GC = \u0001\u000A\u000E.\u001F(R);
				\u000B\u0017\u0016.\u0007(this.GC, new KeyEventHandler(this.OnKeyDown));
				return;
			case 4:
				this.YL = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.YL, new RoutedEventHandler(this.OnCancel));
				return;
			case 5:
				this.H = \u001E\u0001\u0010.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x06002527 RID: 9511 RVA: 0x000E0A44 File Offset: 0x000DEC44
		Window INewViewSheetSet.JFR()
		{
			return \u000D\u0011\u0016.\u0007(this);
		}

		// Token: 0x06002528 RID: 9512 RVA: 0x000E0A5C File Offset: 0x000DEC5C
		void INewViewSheetSet.EFR(Window F)
		{
			\u000C\u000E\u0007.\u001D(this, F);
		}

		// Token: 0x06002529 RID: 9513 RVA: 0x000E0A70 File Offset: 0x000DEC70
		bool? INewViewSheetSet.NFR()
		{
			return \u0018\u0020\u000A.\u001D(this);
		}

		// Token: 0x04000EAE RID: 3758
		private string TW;

		// Token: 0x04000EAF RID: 3759
		private ObservableCollection<ViewSheetSetInfo> IW;

		// Token: 0x04000EB0 RID: 3760
		[CompilerGenerated]
		private SavingMode QW;

		// Token: 0x04000EB1 RID: 3761
		internal NewViewSheetSetWindow PW;

		// Token: 0x04000EB2 RID: 3762
		internal TextBlock AC;

		// Token: 0x04000EB3 RID: 3763
		internal TextBox GC;

		// Token: 0x04000EB4 RID: 3764
		internal Button YL;

		// Token: 0x04000EB5 RID: 3765
		internal Button H;

		// Token: 0x04000EB6 RID: 3766
		private bool R;
	}
}

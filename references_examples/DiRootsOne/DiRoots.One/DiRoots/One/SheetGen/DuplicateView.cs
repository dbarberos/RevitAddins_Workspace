using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetGen.DI.Interfaces;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002CF RID: 719
	public class DuplicateView : DiRootsWindow, IDuplicateView, IComponentConnector
	{
		// Token: 0x06001D46 RID: 7494 RVA: 0x000B8DD8 File Offset: 0x000B6FD8
		public DuplicateView()
		{
			\u0017\u001E\u0016.\u000A(this);
		}

		// Token: 0x1700082C RID: 2092
		// (get) Token: 0x06001D47 RID: 7495 RVA: 0x000B8DF8 File Offset: 0x000B6FF8
		// (set) Token: 0x06001D48 RID: 7496 RVA: 0x000B8E0C File Offset: 0x000B700C
		public int NumberOfCopies { get; set; } = 1;

		// Token: 0x06001D49 RID: 7497 RVA: 0x000B8E20 File Offset: 0x000B7020
		private void btnSelect_Click(object sender, RoutedEventArgs e)
		{
			TextBox ml = this.ML;
			string u001F;
			if (ml == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateView.btnSelect_Click(object, RoutedEventArgs)).MethodHandle;
				}
				u001F = null;
			}
			else
			{
				u001F = \u0003\u000B\u0019.\u001D(ml);
			}
			\u0014\u001E\u0016.\u000A(this, \u0013\u0011\u0016.\u000A(u001F, \u001F\u0015\u000A.\u000A()));
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
		}

		// Token: 0x06001D4A RID: 7498 RVA: 0x000B8E74 File Offset: 0x000B7074
		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex u001F = \u0015\u000F\u0007.\u000A("[^0-9]+");
			\u0019\u0013\u000A.\u000A(e, \u000C\u000F\u0007.\u001D(u001F, \u0001\u0015\u0007.\u000A(e)));
		}

		// Token: 0x06001D4B RID: 7499 RVA: 0x000B8EA4 File Offset: 0x000B70A4
		private void txtNumberOfSheets_LostFocus(object sender, RoutedEventArgs e)
		{
			if (\u0003\u000B\u0019.\u0007(this.ML) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateView.txtNumberOfSheets_LostFocus(object, RoutedEventArgs)).MethodHandle;
				}
				if (\u001A\u0006\u0007.\u000A(\u0003\u000B\u0019.\u0007(this.ML)))
				{
					goto IL_6A;
				}
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			if (\u0013\u0011\u0016.\u000A(\u0003\u000B\u0019.\u0007(this.ML), \u001F\u0015\u000A.\u000A()) > 0)
			{
				return;
			}
			for (;;)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			IL_6A:
			\u001A\u0015\u0007.\u000A(this.ML, "1");
		}

		// Token: 0x06001D4C RID: 7500 RVA: 0x000B8F2C File Offset: 0x000B712C
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateView.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/duplicationwindows/duplicateview.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001D4D RID: 7501 RVA: 0x000B8F74 File Offset: 0x000B7174
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.QQ(int F, object R)
		{
			if (F == 1)
			{
				this.ML = \u0001\u000A\u000E.\u001F(R);
				\u000F\u001E\u0016.\u000A(this.ML, new RoutedEventHandler(this.txtNumberOfSheets_LostFocus));
				\u000F\u0001\u0007.\u000A(this.ML, new TextCompositionEventHandler(this.NumberValidationTextBox));
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(DuplicateView.QQ(int, object)).MethodHandle;
			}
			if (F != 2)
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
				this.R = true;
				return;
			}
			this.FS = \u001E\u0001\u0010.\u001F(R);
			\u0010\u0015\u000A.\u000A(this.FS, new RoutedEventHandler(this.btnSelect_Click));
		}

		// Token: 0x06001D4E RID: 7502 RVA: 0x000B9014 File Offset: 0x000B7214
		void IDuplicateView.EA(EventHandler F)
		{
			\u0016\u0015\u0007.\u001D(this, F);
		}

		// Token: 0x06001D4F RID: 7503 RVA: 0x000B9028 File Offset: 0x000B7228
		void IDuplicateView.MA(EventHandler F)
		{
			\u0012\u001E\u0016.\u000A(this, F);
		}

		// Token: 0x06001D50 RID: 7504 RVA: 0x000B903C File Offset: 0x000B723C
		bool? IDuplicateView.VA()
		{
			return \u0018\u0020\u000A.\u001D(this);
		}

		// Token: 0x06001D51 RID: 7505 RVA: 0x000B9054 File Offset: 0x000B7254
		object IDuplicateView.ZA()
		{
			return \u0007\u000C\u000A.\u001D(this);
		}

		// Token: 0x06001D52 RID: 7506 RVA: 0x000B906C File Offset: 0x000B726C
		void IDuplicateView.XA(object F)
		{
			\u0017\u001A\u000A.\u0007(this, F);
		}

		// Token: 0x06001D53 RID: 7507 RVA: 0x000B9080 File Offset: 0x000B7280
		Window IDuplicateView.PA()
		{
			return \u000D\u0011\u0016.\u0007(this);
		}

		// Token: 0x06001D54 RID: 7508 RVA: 0x000B9098 File Offset: 0x000B7298
		void IDuplicateView.OA(Window F)
		{
			\u000C\u000E\u0007.\u001D(this, F);
		}

		// Token: 0x04000BC6 RID: 3014
		[CompilerGenerated]
		private int DS;

		// Token: 0x04000BC7 RID: 3015
		internal TextBox ML;

		// Token: 0x04000BC8 RID: 3016
		internal Button FS;

		// Token: 0x04000BC9 RID: 3017
		private bool R;
	}
}

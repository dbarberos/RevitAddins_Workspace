using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace ProSheets.DrawingRegister.UI.Windows
{
	// Token: 0x0200010F RID: 271
	public partial class ExcelOpen : DiRootsWindow
	{
		// Token: 0x06000E15 RID: 3605 RVA: 0x00052C88 File Offset: 0x00050E88
		public ExcelOpen(string filePath)
		{
			\u001E\u0003\u000F.\u0018(this);
			this.BB = filePath;
			\u0017\u0003\u000F.\u0018(this, string.Empty);
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x00052CB4 File Offset: 0x00050EB4
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			\u0007\u000B\u0018.\u0014(this, new bool?(false));
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x06000E17 RID: 3607 RVA: 0x00052CD4 File Offset: 0x00050ED4
		private void Button_Click_Open(object sender, RoutedEventArgs e)
		{
			\u0007\u000B\u0018.\u0014(this, new bool?(true));
			\u0006\u000F\u0003.\u0018(this.BB);
		}

		// Token: 0x04000643 RID: 1603
		private string BB;
	}
}

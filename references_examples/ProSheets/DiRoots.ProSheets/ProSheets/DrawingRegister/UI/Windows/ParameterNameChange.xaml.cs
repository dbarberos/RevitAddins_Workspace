using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using ProSheets.DrawingRegister.ViewModels;

namespace ProSheets.DrawingRegister.UI.Windows
{
	// Token: 0x02000110 RID: 272
	public partial class ParameterNameChange : DiRootsWindow
	{
		// Token: 0x06000E1A RID: 3610 RVA: 0x00052DB0 File Offset: 0x00050FB0
		public ParameterNameChange(ParameterChangeViewModel viewModel)
		{
			\u001C\u000B\u0018.\u0003(this, viewModel);
			\u0002\u0003\u000F.\u0018(this);
			\u000B\u0005\u0018.\u0014(viewModel, this);
			\u0002\u0014\u0014.\u0003(this, WindowStartupLocation.CenterScreen);
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x00052DE0 File Offset: 0x00050FE0
		private void Button_CancelClick(object sender, RoutedEventArgs e)
		{
			\u000B\u000B\u0018.\u0003(this);
		}
	}
}

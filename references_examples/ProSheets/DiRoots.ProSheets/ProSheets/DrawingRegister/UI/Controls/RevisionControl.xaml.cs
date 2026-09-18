using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.ProSheets.UI;
using ProSheets.DrawingRegister.Behaviors;
using ProSheets.Models;

namespace ProSheets.DrawingRegister.UI.Controls
{
	// Token: 0x02000117 RID: 279
	public partial class RevisionControl : UserControl
	{
		// Token: 0x06000E3A RID: 3642 RVA: 0x00053868 File Offset: 0x00051A68
		public RevisionControl()
		{
			\u0014\u0016\u000F.\u0018(this);
			RevisionListBoxSelectionBehavior revisionListBoxSelectionBehavior = new RevisionListBoxSelectionBehavior();
			\u0007\u0001\u0018.\u0018(revisionListBoxSelectionBehavior, ListBoxSelectionBehavior<RevisionInformation>.SelectedItemsProperty, new Binding("SelectedRevisionData"));
			\u000B\u0001\u0018.\u0018(\u0019\u0001\u0018.\u0018(this.H), revisionListBoxSelectionBehavior);
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x000538B4 File Offset: 0x00051AB4
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}
	}
}

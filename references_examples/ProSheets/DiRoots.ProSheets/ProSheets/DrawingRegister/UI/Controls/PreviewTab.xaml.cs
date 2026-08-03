using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;
using A;
using Syncfusion.UI.Xaml.Grid.Utility;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.UI.Xaml.Spreadsheet.Helpers;
using Syncfusion.Windows.Tools.Controls;

namespace ProSheets.DrawingRegister.UI.Controls
{
	// Token: 0x02000116 RID: 278
	public partial class PreviewTab : UserControl
	{
		// Token: 0x06000E33 RID: 3635 RVA: 0x00053700 File Offset: 0x00051900
		public PreviewTab()
		{
			\u0005\u0003\u000F.\u0018(this);
			\u001B\u0003\u000F.\u0018(this);
			\u0001\u0003\u000F.\u0018(this.P, new DependencyPropertyChangedEventHandler(this.SpreadsheetRibbon_IsVisibleChanged));
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06000E34 RID: 3636 RVA: 0x00053738 File Offset: 0x00051938
		// (set) Token: 0x06000E35 RID: 3637 RVA: 0x0005374C File Offset: 0x0005194C
		public static PreviewTab Instance { get; set; }

		// Token: 0x06000E36 RID: 3638 RVA: 0x00053760 File Offset: 0x00051960
		private void SpreadsheetRibbon_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			PreviewTab.\u001D\u0015\u0018 u001D_u0015_u = new PreviewTab.\u001D\u0015\u0018();
			u001D_u0015_u.\u000C = sender;
			\u000E\u0003\u000F.\u0018(\u0005\u0014\u0003.\u0003(this.P), DispatcherPriority.ApplicationIdle, new Action(u001D_u0015_u.\u0018));
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x0005379C File Offset: 0x0005199C
		private void spreadsheetControl_WorksheetAdding(object sender, WorksheetAddingEventArgs args)
		{
			\u000C\u0016\u000F.\u0018(args, true);
		}

		// Token: 0x02000210 RID: 528
		[CompilerGenerated]
		private sealed class \u001D\u0015\u0018
		{
			// Token: 0x060012F5 RID: 4853 RVA: 0x00061318 File Offset: 0x0005F518
			internal void \u0018()
			{
				Ribbon visualChild = GridUtil.GetVisualChild<Ribbon>(\u0010\u001D\u000F.\u000C(this.\u000C));
				if (visualChild != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewTab.\u001D\u0015\u0018.\u0018()).MethodHandle;
					}
					if (\u000A\u001E\u000F.\u0018(visualChild) != null)
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
						\u0008\u0013\u0014.\u0018(\u000A\u001E\u000F.\u0018(visualChild), Visibility.Collapsed);
					}
				}
			}

			// Token: 0x0400095E RID: 2398
			public object \u000C;
		}
	}
}

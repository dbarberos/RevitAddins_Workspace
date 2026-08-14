using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using DiRoots.ProSheets.ViewModels;
using Microsoft.Xaml.Behaviors;
using ProSheets;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x02000042 RID: 66
	public partial class ManageParameters : DiRootsWindow
	{
		// Token: 0x060002C1 RID: 705 RVA: 0x0000FEE0 File Offset: 0x0000E0E0
		public ManageParameters(ParameterBaseModel model, bool onlyProjectParameters = false)
		{
			\u0005\u0013\u0014.\u0018(this);
			\u000B\u0005\u0018.\u0014(model, this);
			\u001C\u000B\u0018.\u0003(this, model);
			\u0001\u0013\u0014.\u0018(\u001B\u0013\u0014.\u0018(model), \u001F\u0002\u000F.\u000C);
			ListBoxSelectionBehavior<SelectionParameter> listBoxSelectionBehavior = new ListBoxSelectionBehavior<SelectionParameter>();
			ListBoxSelectionBehavior<SelectionParameter> listBoxSelectionBehavior2 = new ListBoxSelectionBehavior<SelectionParameter>();
			\u0007\u0001\u0018.\u0018(listBoxSelectionBehavior, ListBoxSelectionBehavior<SelectionParameter>.SelectedItemsProperty, new Binding("SelectedUsedParams"));
			\u0007\u0001\u0018.\u0018(listBoxSelectionBehavior2, ListBoxSelectionBehavior<SelectionParameter>.SelectedItemsProperty, new Binding("SelectedAvailableParams"));
			\u000B\u0001\u0018.\u0018(\u0019\u0001\u0018.\u0018(this.RQ), listBoxSelectionBehavior2);
			\u000B\u0001\u0018.\u0018(\u0019\u0001\u0018.\u0018(this.TQ), listBoxSelectionBehavior);
			if (onlyProjectParameters)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ManageParameters..ctor(ParameterBaseModel, bool)).MethodHandle;
				}
				\u0008\u0013\u0014.\u0018(this.FQ, Visibility.Collapsed);
			}
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000FFA0 File Offset: 0x0000E1A0
		private void DiRootsWindow_Closed(object sender, EventArgs e)
		{
			\u000E\u0013\u0014.\u0018(\u0019\u0001\u0018.\u0018(this.RQ));
			\u000E\u0013\u0014.\u0018(\u0019\u0001\u0018.\u0018(this.TQ));
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0001001C File Offset: 0x0000E21C
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		internal Delegate TN(Type P, string Q)
		{
			return \u000E\u000B\u0018.\u0018(P, this, Q);
		}
	}
}

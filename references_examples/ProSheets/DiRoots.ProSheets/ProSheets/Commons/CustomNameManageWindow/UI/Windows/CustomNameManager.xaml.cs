using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.Commons.WindowControl;
using DiRoots.ProSheets.UI;
using ProSheets.Commons.CustomNameManageWindow.Models;
using ProSheets.Commons.CustomNameManageWindow.Models.Interfaces;
using ProSheets.Commons.CustomNameManageWindow.UI.Behaviours;
using ProSheets.Commons.CustomNameManageWindow.ViewModels;

namespace ProSheets.Commons.CustomNameManageWindow.UI.Windows
{
	// Token: 0x0200013F RID: 319
	public partial class CustomNameManager : DiRootsWindow
	{
		// Token: 0x06000FEA RID: 4074 RVA: 0x00059AD4 File Offset: 0x00057CD4
		public CustomNameManager(bool isCombine, List<IParameterModel> parameterInfo, List<IParameterModel> preSelectedElements = null, string fileText = null, bool isFileTextBox = false)
		{
			\u0013\u0009\u000F.\u0018(this);
			List<IParameterModel> list;
			if ((list = preSelectedElements) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomNameManager..ctor(bool, List<IParameterModel>, List<IParameterModel>, string, bool)).MethodHandle;
				}
				list = new List<IParameterModel>();
			}
			preSelectedElements = list;
			CustomNameManagerVM customNameManagerVM = new CustomNameManagerVM(isCombine, isFileTextBox, parameterInfo, preSelectedElements, fileText);
			\u000B\u0005\u0018.\u0014(customNameManagerVM, this);
			CustomNameManagerVM u = customNameManagerVM;
			this.FB = customNameManagerVM;
			\u001C\u000B\u0018.\u0003(this, u);
			ListBoxSelectionBehaviours listBoxSelectionBehaviours = new ListBoxSelectionBehaviours();
			\u0007\u0001\u0018.\u0018(listBoxSelectionBehaviours, ListBoxSelectionBehavior<IParameterModel>.SelectedItemsProperty, new Binding("SelectAvailableParameter"));
			\u000B\u0001\u0018.\u0018(\u0019\u0001\u0018.\u0018(this.YN), listBoxSelectionBehaviours);
			DataGridSelectionBehaviours dataGridSelectionBehaviours = new DataGridSelectionBehaviours();
			\u0007\u0001\u0018.\u0018(dataGridSelectionBehaviours, DataGridSelectionBehavior<ParameterModel>.SelectedItemsProperty, new Binding("SelectSelectedParameter"));
			\u000B\u0001\u0018.\u0018(\u0019\u0001\u0018.\u0018(this.ON), dataGridSelectionBehaviours);
		}

		// Token: 0x06000FEC RID: 4076 RVA: 0x00059BDC File Offset: 0x00057DDC
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		internal Delegate TN(Type P, string Q)
		{
			return \u000E\u000B\u0018.\u0018(P, this, Q);
		}

		// Token: 0x0400070F RID: 1807
		private CustomNameManagerVM FB;
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.ProSheets.UI;
using DiRoots.ProSheets.Xml.Interfaces;
using DiRoots.ProSheets.Xml.ViewModels;
using Syncfusion.Windows.Controls.Input;

namespace DiRoots.ProSheets.Xml.UI.UserControls
{
	// Token: 0x02000026 RID: 38
	public partial class XmlParameterManager : BaseUserControl, IStyleConnector
	{
		// Token: 0x06000160 RID: 352 RVA: 0x00008D9C File Offset: 0x00006F9C
		public XmlParameterManager()
		{
			\u0010\u0001\u0018.\u0018(this);
			ListBoxSelectionBehavior<IParameterInfo> listBoxSelectionBehavior = new ListBoxSelectionBehavior<IParameterInfo>();
			\u0007\u0001\u0018.\u0018(listBoxSelectionBehavior, ListBoxSelectionBehavior<IParameterInfo>.SelectedItemsProperty, new Binding("SelectedAvailableParams"));
			\u000B\u0001\u0018.\u0018(\u0019\u0001\u0018.\u0018(this.M), listBoxSelectionBehavior);
			DataGridSelectionBehavior<IParameterInfo> dataGridSelectionBehavior = new DataGridSelectionBehavior<IParameterInfo>();
			\u0007\u0001\u0018.\u0018(dataGridSelectionBehavior, DataGridSelectionBehavior<IParameterInfo>.SelectedItemsProperty, new Binding("SelectedUsedParams"));
			\u000B\u0001\u0018.\u0018(\u0019\u0001\u0018.\u0018(this.C), dataGridSelectionBehavior);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00008E18 File Offset: 0x00007018
		public void Init(XmlParameterBaseModel sheetModel, XmlParameterBaseModel viewModel)
		{
			this.P = sheetModel;
			this.Q = viewModel;
			\u001C\u000B\u0018.\u0003(this, sheetModel);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00008E3C File Offset: 0x0000703C
		private void BtnCustomParameter_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			BindingExpression bindingExpression = \u0008\u0001\u0018.\u0018(this.X, TextBox.TextProperty);
			if (bindingExpression == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(XmlParameterManager.BtnCustomParameter_PreviewMouseLeftButtonDown(object, MouseButtonEventArgs)).MethodHandle;
				}
			}
			else
			{
				\u0010\u001A\u0018.\u0018(bindingExpression);
			}
			BindingExpression bindingExpression2 = \u0008\u0001\u0018.\u0018(this.Y, TextBox.TextProperty);
			if (bindingExpression2 == null)
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
			}
			else
			{
				\u0010\u001A\u0018.\u0018(bindingExpression2);
			}
			if (!\u0006\u0001\u0018.\u0018(this.O))
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
				\u001D\u000B\u0018.\u0018(e, true);
			}
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00008EC0 File Offset: 0x000070C0
		private void DataGridRow_DoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (\u0005\u0001\u0018.\u0018(e) != MouseButton.Left)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(XmlParameterManager.DataGridRow_DoubleClick(object, MouseButtonEventArgs)).MethodHandle;
				}
				return;
			}
			bool? flag = \u001B\u0001\u0018.\u0018(this.J);
			if (\u000C\u0007\u0018.\u0018(ref flag))
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
				\u0001\u0001\u0018.\u0018(this.P);
				return;
			}
			\u0001\u0001\u0018.\u0018(this.Q);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00008F28 File Offset: 0x00007128
		private void RadioButtonChanged(object sender, RoutedEventArgs e)
		{
			bool? flag = \u001B\u0001\u0018.\u0018(this.J);
			object u;
			if (!\u000C\u0007\u0018.\u0018(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(XmlParameterManager.RadioButtonChanged(object, RoutedEventArgs)).MethodHandle;
				}
				u = this.Q;
			}
			else
			{
				u = this.P;
			}
			\u001C\u000B\u0018.\u0003(this, u);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00008F78 File Offset: 0x00007178
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00008FA0 File Offset: 0x000071A0
		private void TextBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (\u0005\u0001\u0018.\u0018(e) != MouseButton.Left)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(XmlParameterManager.TextBox_PreviewMouseDoubleClick(object, MouseButtonEventArgs)).MethodHandle;
				}
				return;
			}
			TextBox textBox = \u0018\u0004\u000F.\u000C(sender);
			if (textBox != null)
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
				\u000E\u0001\u0018.\u0018(textBox);
			}
			\u001D\u000B\u0018.\u0018(e, true);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000917C File Offset: 0x0000737C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		void IStyleConnector.BR(int P, object Q)
		{
			if (P == 12)
			{
				EventSetter eventSetter = \u000D\u001B\u0018.\u0018();
				\u0012\u001B\u0018.\u0018(eventSetter, Control.MouseDoubleClickEvent);
				\u000F\u001B\u0018.\u0018(eventSetter, new MouseButtonEventHandler(this.DataGridRow_DoubleClick));
				\u0003\u001B\u0018.\u0018(\u0016\u001B\u0018.\u0018(\u0006\u0004\u000F.\u000C(Q)), eventSetter);
				return;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(XmlParameterManager.BR(int, object)).MethodHandle;
			}
			if (P != 13)
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
				return;
			}
			\u0014\u001B\u0018.\u0018(\u0005\u0002\u000F.\u000C(Q), new MouseButtonEventHandler(this.TextBox_PreviewMouseDoubleClick));
		}

		// Token: 0x040000BD RID: 189
		private XmlParameterBaseModel P;

		// Token: 0x040000BE RID: 190
		private XmlParameterBaseModel Q;
	}
}

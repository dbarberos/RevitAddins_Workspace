using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.RoomPro.Models;
using DiRoots.RoomPro.ViewModels;

namespace DiRoots.RoomPro.UI.Controls
{
	// Token: 0x0200006C RID: 108
	public class NamingConfigurationControl : UserControl, IComponentConnector, IStyleConnector
	{
		// Token: 0x060004BB RID: 1211 RVA: 0x0001DFC8 File Offset: 0x0001C1C8
		public NamingConfigurationControl()
		{
			\u0013\u0015\u0007.\u000A(this);
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0001DFE4 File Offset: 0x0001C1E4
		private void TxtSeparator_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			char u000A = \u0015\u0015\u0007.\u000A(\u0001\u0015\u0007.\u000A(e));
			if (\u000C\u0015\u0007.\u000A(\u000C\u001D.\u000B, u000A))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationControl.TxtSeparator_PreviewTextInput(object, TextCompositionEventArgs)).MethodHandle;
				}
				\u0019\u0013\u000A.\u000A(e, true);
				return;
			}
			\u001A\u0015\u0007.\u000A(this.L, "");
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0001E03C File Offset: 0x0001C23C
		private void TxtFieldSeparator_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			char u000A = \u0015\u0015\u0007.\u000A(\u0001\u0015\u0007.\u000A(e));
			if (\u000C\u0015\u0007.\u000A(\u000C\u001D.\u000B, u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationControl.TxtFieldSeparator_PreviewTextInput(object, TextCompositionEventArgs)).MethodHandle;
				}
				\u0019\u0013\u000A.\u000A(e, true);
				return;
			}
			\u001A\u0015\u0007.\u000A(this.H, "");
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0001E094 File Offset: 0x0001C294
		private void CustomFieldTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			\u0004\u000C\u000A.\u000A(this.D, -1);
			\u000A\u0001\u0007.\u000A(\u0009\u0006\u0007.\u0007(this.D));
			NamingConfigurationViewModel u001F = this.K();
			\u001F\u0001\u0007.\u000A(u001F, true);
			\u0009\u0015\u0007.\u000A(u001F, false);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0001E0D4 File Offset: 0x0001C2D4
		private void CustomFieldSeparatorTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			\u0004\u000C\u000A.\u000A(this.D, -1);
			\u000A\u0001\u0007.\u000A(\u0009\u0006\u0007.\u0007(this.D));
			NamingConfigurationViewModel u001F = this.K();
			\u0009\u0015\u0007.\u000A(u001F, true);
			\u001F\u0001\u0007.\u000A(u001F, false);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0001E114 File Offset: 0x0001C314
		private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			\u0007\u0001\u0007.\u000A(this.K());
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0001E130 File Offset: 0x0001C330
		private void DataGridRow_MouseDoubleClick_Back(object sender, MouseButtonEventArgs e)
		{
			\u001D\u0001\u0007.\u000A(this.K());
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0001E14C File Offset: 0x0001C34C
		private void dataGrid1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DependencyObject dependencyObject = \u000A\u0007\u000E.\u001F(\u0018\u0001\u0007.\u000A(e));
			while (dependencyObject != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationControl.dataGrid1_PreviewMouseLeftButtonDown(object, MouseButtonEventArgs)).MethodHandle;
				}
				if (\u0007\u0007\u000E.\u001F(dependencyObject) != null)
				{
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						goto IL_45;
					}
				}
				else
				{
					dependencyObject = \u0019\u0001\u0007.\u000A(dependencyObject);
				}
			}
			IL_45:
			if (dependencyObject == null)
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
				return;
			}
			DataGridRow u001F = \u001D\u0007\u000E.\u001F(dependencyObject);
			if (\u0004\u0001\u0007.\u0007(u001F) == null)
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
				return;
			}
			this.R = \u0004\u0007\u000E.\u001F(\u0004\u0001\u0007.\u0007(u001F));
			this.F = true;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0001E1E8 File Offset: 0x0001C3E8
		private void dataGrid1_PreviewMouseMove(object sender, MouseEventArgs e)
		{
			if (!this.F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationControl.dataGrid1_PreviewMouseMove(object, MouseEventArgs)).MethodHandle;
				}
				return;
			}
			DataObject u000A = \u0016\u0001\u0007.\u000A("yourDataFormat", this.R);
			\u0005\u0001\u0007.\u000A(this.D, u000A, DragDropEffects.Move);
			this.F = false;
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x0001E23C File Offset: 0x0001C43C
		private void dataGrid2_Drop(object sender, DragEventArgs e)
		{
			if (!\u000B\u0001\u0007.\u000A(\u0002\u0001\u0007.\u000A(e), "yourDataFormat"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationControl.dataGrid2_Drop(object, DragEventArgs)).MethodHandle;
				}
				return;
			}
			\u0007\u0001\u0007.\u000A(this.K());
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0001E280 File Offset: 0x0001C480
		private NamingConfigurationViewModel K()
		{
			CalloutNamingConfigurationTabViewModel calloutNamingConfigurationTabViewModel = \u0009\u000A\u000E.\u001F(\u0007\u000C\u000A.\u001D(this));
			if (calloutNamingConfigurationTabViewModel != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationControl.K()).MethodHandle;
				}
				return \u0015\u0005\u0007.\u001D(calloutNamingConfigurationTabViewModel);
			}
			SectionNamingConfigurationTabViewModel sectionNamingConfigurationTabViewModel = \u001F\u0007\u000E.\u001F(\u0007\u000C\u000A.\u001D(this));
			if (sectionNamingConfigurationTabViewModel != null)
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
				return \u001D\u0011\u0007.\u001D(sectionNamingConfigurationTabViewModel);
			}
			return null;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0001E2E4 File Offset: 0x0001C4E4
		private void NameingConfig_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0001E30C File Offset: 0x0001C50C
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.B)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationControl.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.B = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/quickviews/ui/controls/namingconfigurationcontrol.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0001E354 File Offset: 0x0001C554
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.U(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u0015\u000A\u000E.\u001F(R), new RoutedEventHandler(this.NameingConfig_Loaded));
				return;
			case 2:
				this.D = \u0020\u0001\u0010.\u001F(R);
				\u001C\u0001\u0007.\u000A(this.D, new MouseEventHandler(this.dataGrid1_PreviewMouseMove));
				\u0003\u0001\u0007.\u000A(this.D, new MouseButtonEventHandler(this.dataGrid1_PreviewMouseLeftButtonDown));
				return;
			case 4:
				\u0012\u0001\u0007.\u0007(\u0001\u000A\u000E.\u001F(R), new RoutedEventHandler(this.CustomFieldTextBox_GotFocus));
				return;
			case 5:
				this.H = \u0001\u000A\u000E.\u001F(R);
				\u0012\u0001\u0007.\u0007(this.H, new RoutedEventHandler(this.CustomFieldSeparatorTextBox_GotFocus));
				\u000F\u0001\u0007.\u000A(this.H, new TextCompositionEventHandler(this.TxtFieldSeparator_PreviewTextInput));
				return;
			case 6:
				this.C = \u0016\u0009\u0010.\u001F(R);
				return;
			case 7:
				this.L = \u0001\u000A\u000E.\u001F(R);
				\u000F\u0001\u0007.\u000A(this.L, new TextCompositionEventHandler(this.TxtSeparator_PreviewTextInput));
				return;
			case 8:
				this.S = \u0020\u0001\u0010.\u001F(R);
				\u0006\u0001\u0007.\u000A(this.S, new DragEventHandler(this.dataGrid2_Drop));
				return;
			}
			this.B = true;
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0001E4A0 File Offset: 0x0001C6A0
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IStyleConnector.W(int F, object R)
		{
			EventSetter eventSetter;
			if (F == 3)
			{
				eventSetter = \u001B\u0001\u0007.\u000A();
				\u0008\u0001\u0007.\u000A(eventSetter, Control.MouseDoubleClickEvent);
				\u000E\u0001\u0007.\u000A(eventSetter, new MouseButtonEventHandler(this.DataGridRow_MouseDoubleClick));
				\u000D\u0001\u0007.\u000A(\u0010\u0001\u0007.\u000A(\u000C\u000A\u000E.\u001F(R)), eventSetter);
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationControl.W(int, object)).MethodHandle;
			}
			if (F != 9)
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
				return;
			}
			eventSetter = \u001B\u0001\u0007.\u000A();
			\u0008\u0001\u0007.\u000A(eventSetter, Control.MouseDoubleClickEvent);
			\u000E\u0001\u0007.\u000A(eventSetter, new MouseButtonEventHandler(this.DataGridRow_MouseDoubleClick_Back));
			\u000D\u0001\u0007.\u000A(\u0010\u0001\u0007.\u000A(\u000C\u000A\u000E.\u001F(R)), eventSetter);
		}

		// Token: 0x040001C9 RID: 457
		private bool F;

		// Token: 0x040001CA RID: 458
		private NamingParameter R;

		// Token: 0x040001CB RID: 459
		internal DataGrid D;

		// Token: 0x040001CC RID: 460
		internal TextBox H;

		// Token: 0x040001CD RID: 461
		internal CheckBox C;

		// Token: 0x040001CE RID: 462
		internal TextBox L;

		// Token: 0x040001CF RID: 463
		internal DataGrid S;

		// Token: 0x040001D0 RID: 464
		private bool B;
	}
}

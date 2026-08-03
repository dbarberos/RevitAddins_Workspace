using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.RoomPro.Enums;

namespace DiRoots.RoomPro.UI.Controls
{
	// Token: 0x0200006E RID: 110
	public class SectionNamingConfigurationTab : SettingsTab, IComponentConnector
	{
		// Token: 0x060004CF RID: 1231 RVA: 0x0001E604 File Offset: 0x0001C804
		public SectionNamingConfigurationTab()
		{
			\u001E\u0001\u0007.\u000A(this);
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0001E620 File Offset: 0x0001C820
		private void TxtstartVal_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			object u001F = Enumerable.ToList<char>(\u0017\u0001\u0007.\u000A());
			char u000A = \u0015\u0015\u0007.\u000A(\u0001\u0015\u0007.\u000A(e));
			if (\u0020\u0001\u0007.\u000A(u001F, u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionNamingConfigurationTab.TxtstartVal_PreviewTextInput(object, TextCompositionEventArgs)).MethodHandle;
				}
				\u0019\u0013\u000A.\u000A(e, true);
				return;
			}
			if (\u0019\u0007\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.D)) == CountStyle.Alphabet)
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
				\u001A\u0015\u0007.\u000A(this.H, "");
			}
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x0001E6A4 File Offset: 0x0001C8A4
		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CountStyle countStyle = \u0019\u0007\u000E.\u001F(\u0019\u000C\u0007.\u001D(\u000F\u001F\u000E.\u001F(sender)));
			if (countStyle != CountStyle.Number)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionNamingConfigurationTab.ComboBox_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				if (countStyle == CountStyle.Alphabet)
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
					\u0014\u0001\u0007.\u000A(this.H, 1);
					return;
				}
			}
			else
			{
				\u0014\u0001\u0007.\u000A(this.H, 10);
			}
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0001E708 File Offset: 0x0001C908
		private void SectionNameConfig_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0001E730 File Offset: 0x0001C930
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionNamingConfigurationTab.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/quickviews/ui/controls/sectionnamingconfigurationtab.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0001E778 File Offset: 0x0001C978
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate U(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x0001E790 File Offset: 0x0001C990
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.B(int F, object R)
		{
			if (F == 1)
			{
				this.D = \u000B\u000A\u000E.\u001F(R);
				\u001B\u000C\u000A.\u0007(this.D, new SelectionChangedEventHandler(this.ComboBox_SelectionChanged));
				return;
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(SectionNamingConfigurationTab.B(int, object)).MethodHandle;
			}
			if (F != 2)
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
				this.R = true;
				return;
			}
			this.H = \u0001\u000A\u000E.\u001F(R);
			\u000F\u0001\u0007.\u000A(this.H, new TextCompositionEventHandler(this.TxtstartVal_PreviewTextInput));
		}

		// Token: 0x040001D2 RID: 466
		internal ComboBox D;

		// Token: 0x040001D3 RID: 467
		internal TextBox H;

		// Token: 0x040001D4 RID: 468
		private bool R;
	}
}

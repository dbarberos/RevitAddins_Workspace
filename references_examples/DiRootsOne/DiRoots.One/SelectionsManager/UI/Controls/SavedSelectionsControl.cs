using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;

namespace SelectionsManager.UI.Controls
{
	// Token: 0x02000037 RID: 55
	public class SavedSelectionsControl : UserControl, IComponentConnector
	{
		// Token: 0x060001C7 RID: 455 RVA: 0x00009634 File Offset: 0x00007834
		public SavedSelectionsControl()
		{
			\u0014\u0015\u000A.\u000A(this);
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x0000968C File Offset: 0x0000788C
		// (set) Token: 0x060001CA RID: 458 RVA: 0x000096B0 File Offset: 0x000078B0
		public string Text
		{
			get
			{
				return \u0013\u0001\u0010.\u001F(\u0004\u0015\u000A.\u0007(this, SavedSelectionsControl.TextProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, SavedSelectionsControl.TextProperty, value);
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x000096CC File Offset: 0x000078CC
		private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			ScrollViewer u001F = \u0017\u0001\u0010.\u001F(sender);
			\u0013\u0015\u000A.\u000A(u001F, \u000C\u0015\u000A.\u000A(u001F) - (double)\u001A\u0015\u000A.\u000A(e));
			\u0019\u0013\u000A.\u000A(e, true);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00009700 File Offset: 0x00007900
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionsControl.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/onefilter/selectionsmanager/ui/controls/savedselections/savedselectionscontrol.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00009748 File Offset: 0x00007948
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.D(int F, object R)
		{
			if (F == 1)
			{
				\u0015\u0015\u000A.\u000A(\u0017\u0001\u0010.\u001F(R), new MouseWheelEventHandler(this.ScrollViewer_PreviewMouseWheel));
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(SavedSelectionsControl.D(int, object)).MethodHandle;
			}
			if (F != 2)
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
				this.R = true;
				return;
			}
			this.F = \u0014\u0001\u0010.\u001F(R);
		}

		// Token: 0x040000BB RID: 187
		public static readonly DependencyProperty TextProperty = \u001D\u0015\u000A.\u000A("Text", \u001E\u0011\u000A.\u000A(\u001A\u0001\u0010.\u001F()), \u001E\u0011\u000A.\u000A(\u000C\u0001\u0010.\u001F()));

		// Token: 0x040000BC RID: 188
		internal Grid F;

		// Token: 0x040000BD RID: 189
		private bool R;
	}
}

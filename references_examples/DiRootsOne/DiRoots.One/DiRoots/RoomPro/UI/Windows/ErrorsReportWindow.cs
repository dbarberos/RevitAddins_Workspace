using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.RoomPro.UI.Windows
{
	// Token: 0x02000065 RID: 101
	public class ErrorsReportWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x0600047F RID: 1151 RVA: 0x0001CBF8 File Offset: 0x0001ADF8
		public ErrorsReportWindow(List<Tuple<string, string>> reportItems)
		{
			Func<Tuple<string, string>, F> func;
			if ((func = ErrorsReportWindow.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ErrorsReportWindow..ctor(List<Tuple<string, string>>)).MethodHandle;
				}
				func = (ErrorsReportWindow.<>c.\u000A = new Func<Tuple<string, string>, F>(ErrorsReportWindow.<>c.\u001F.\u0007));
			}
			ObservableCollection<F> u000A = new ObservableCollection<F>(Enumerable.Select<Tuple<string, string>, F>(reportItems, func));
			\u0017\u001A\u000A.\u0007(this, this);
			\u0005\u000C\u0007.\u000A(this);
			\u0018\u000C\u0007.\u000A(this.D, u000A);
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0001CC64 File Offset: 0x0001AE64
		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0001CC78 File Offset: 0x0001AE78
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ErrorsReportWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/quickviews/ui/window/errorsreportwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0001CCC0 File Offset: 0x0001AEC0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.QQ(int F, object R)
		{
			if (F == 1)
			{
				this.D = \u0020\u0001\u0010.\u001F(R);
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(ErrorsReportWindow.QQ(int, object)).MethodHandle;
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
			this.H = \u001E\u0001\u0010.\u001F(R);
			\u0010\u0015\u000A.\u000A(this.H, new RoutedEventHandler(this.btnOk_Click));
		}

		// Token: 0x0400019C RID: 412
		internal DataGrid D;

		// Token: 0x0400019D RID: 413
		internal Button H;

		// Token: 0x0400019E RID: 414
		private bool R;
	}
}

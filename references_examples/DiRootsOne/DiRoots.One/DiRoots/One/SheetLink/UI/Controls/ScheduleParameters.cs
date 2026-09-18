using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.SheetLink.ViewModels;

namespace DiRoots.One.SheetLink.UI.Controls
{
	// Token: 0x0200022B RID: 555
	public class ScheduleParameters : UserControl, IComponentConnector
	{
		// Token: 0x060015BD RID: 5565 RVA: 0x0008D1A4 File Offset: 0x0008B3A4
		public ScheduleParameters()
		{
			\u001E\u0005\u0005.\u000A(this, new RevitParametersModel());
			\u0017\u001A\u000A.\u0007(this, \u0018\u0001\u0018.\u001D(this));
			\u0011\u0005\u0005.\u000A(this);
			this.D.J("EventFromAvailableList");
		}

		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x060015BE RID: 5566 RVA: 0x0008D1E8 File Offset: 0x0008B3E8
		// (set) Token: 0x060015BF RID: 5567 RVA: 0x0008D1FC File Offset: 0x0008B3FC
		public RevitParametersModel ParametersModel { get; set; }

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x060015C0 RID: 5568 RVA: 0x0008D210 File Offset: 0x0008B410
		// (set) Token: 0x060015C1 RID: 5569 RVA: 0x0008D224 File Offset: 0x0008B424
		public bool ExportedByType
		{
			get
			{
				return this.F;
			}
			set
			{
				this.F = value;
				\u0019\u0005\u0005.\u000A(this.D, value);
			}
		}

		// Token: 0x060015C2 RID: 5570 RVA: 0x0008D244 File Offset: 0x0008B444
		public void Reset()
		{
			\u0012\u001A\u0019.\u000A(this.D);
			\u0005\u0005\u0005.\u000A(\u0018\u0001\u0018.\u001D(this));
		}

		// Token: 0x060015C3 RID: 5571 RVA: 0x0008D26C File Offset: 0x0008B46C
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u0016\u0005\u0005.\u0007(this.D, ParameterControl.TitleProperty, "Common-Parameters");
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x060015C4 RID: 5572 RVA: 0x0008D2A8 File Offset: 0x0008B4A8
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.H)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleParameters.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.H = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink/ui/usercontrols/parameters/scheduleparameters.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060015C5 RID: 5573 RVA: 0x0008D2F0 File Offset: 0x0008B4F0
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate L(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x060015C6 RID: 5574 RVA: 0x0008D308 File Offset: 0x0008B508
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.C(int F, object R)
		{
			if (F == 1)
			{
				\u0011\u000C\u000A.\u0007(\u001C\u000F\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleParameters.C(int, object)).MethodHandle;
			}
			if (F != 2)
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
				this.H = true;
				return;
			}
			this.D = \u001D\u0016\u000E.\u001F(R);
		}

		// Token: 0x0400089B RID: 2203
		private bool F;

		// Token: 0x0400089C RID: 2204
		[CompilerGenerated]
		private RevitParametersModel R;

		// Token: 0x0400089D RID: 2205
		internal ParameterControl D;

		// Token: 0x0400089E RID: 2206
		private bool H;
	}
}

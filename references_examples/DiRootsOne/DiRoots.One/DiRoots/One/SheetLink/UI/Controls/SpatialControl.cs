using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using Autodesk.Revit.UI;
using DiRoots.One.SheetLink.ViewModels;
using Microsoft.Xaml.Behaviors;

namespace DiRoots.One.SheetLink.UI.Controls
{
	// Token: 0x0200022E RID: 558
	public class SpatialControl : UserControl, IComponentConnector
	{
		// Token: 0x060015DA RID: 5594 RVA: 0x0008DB20 File Offset: 0x0008BD20
		public SpatialControl()
		{
			\u001C\u0016\u0005.\u000A(this);
		}

		// Token: 0x060015DB RID: 5595 RVA: 0x0008DB3C File Offset: 0x0008BD3C
		public void Initialize(UIDocument uidoc, Window parent)
		{
			if (!this.F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialControl.Initialize(UIDocument, Window)).MethodHandle;
				}
				if (!\u001F\u000C\u000A.\u001D(\u0011\u0020\u000A.\u0007(uidoc)))
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
					this.R = \u000D\u0016\u0005.\u000A(uidoc, parent, this);
					\u0017\u001A\u000A.\u0007(this, this.R);
					this.F = true;
				}
			}
		}

		// Token: 0x060015DC RID: 5596 RVA: 0x0008DBA4 File Offset: 0x0008BDA4
		public void CustomDispose()
		{
			SpatialModel r = this.R;
			if (r == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialControl.CustomDispose()).MethodHandle;
				}
			}
			else
			{
				\u0010\u0016\u0005.\u000A(r);
			}
			this.R = \u001B\u000F\u000E.\u001F;
		}

		// Token: 0x060015DD RID: 5597 RVA: 0x0008DBE0 File Offset: 0x0008BDE0
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x060015DE RID: 5598 RVA: 0x0008DC08 File Offset: 0x0008BE08
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.U)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialControl.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.U = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink/ui/usercontrols/spatialcontrol.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060015DF RID: 5599 RVA: 0x0008DC50 File Offset: 0x0008BE50
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate K(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x060015E0 RID: 5600 RVA: 0x0008DC68 File Offset: 0x0008BE68
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.W(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u001D\u0006\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.D = \u000B\u000A\u000E.\u001F(R);
				return;
			case 3:
				this.H = \u0007\u000F\u000E.\u001F(R);
				return;
			case 4:
				this.C = \u001E\u0001\u0010.\u001F(R);
				return;
			case 5:
				this.L = \u0008\u000F\u000E.\u001F(R);
				return;
			case 6:
				this.S = \u0016\u0009\u0010.\u001F(R);
				return;
			case 7:
				this.B = \u001D\u000F\u000E.\u001F(R);
				return;
			default:
				this.U = true;
				return;
			}
		}

		// Token: 0x040008AE RID: 2222
		private bool F;

		// Token: 0x040008AF RID: 2223
		private SpatialModel R;

		// Token: 0x040008B0 RID: 2224
		internal ComboBox D;

		// Token: 0x040008B1 RID: 2225
		internal InvokeCommandAction H;

		// Token: 0x040008B2 RID: 2226
		internal Button C;

		// Token: 0x040008B3 RID: 2227
		internal SpatialNavigator L;

		// Token: 0x040008B4 RID: 2228
		internal CheckBox S;

		// Token: 0x040008B5 RID: 2229
		internal ManageParameters B;

		// Token: 0x040008B6 RID: 2230
		private bool U;
	}
}

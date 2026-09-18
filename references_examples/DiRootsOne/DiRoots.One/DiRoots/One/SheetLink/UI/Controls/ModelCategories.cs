using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.SheetLink.ViewModels;
using Microsoft.Xaml.Behaviors;

namespace DiRoots.One.SheetLink.UI.Controls
{
	// Token: 0x02000228 RID: 552
	public class ModelCategories : UserControl, IComponentConnector
	{
		// Token: 0x06001583 RID: 5507 RVA: 0x0008BC6C File Offset: 0x00089E6C
		public ModelCategories()
		{
			\u0014\u0018\u0005.\u000A(this);
		}

		// Token: 0x06001584 RID: 5508 RVA: 0x0008BC88 File Offset: 0x00089E88
		public void Initialize(UIDocument uidoc, Window parent)
		{
			if (!this.F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ModelCategories.Initialize(UIDocument, Window)).MethodHandle;
				}
				this.R = \u0013\u0018\u0005.\u000A(uidoc, parent, this);
				\u0017\u001A\u000A.\u0007(this, this.R);
				this.F = true;
			}
		}

		// Token: 0x06001585 RID: 5509 RVA: 0x0008BCD4 File Offset: 0x00089ED4
		private void chkTypeId_Checked(object sender, RoutedEventArgs e)
		{
			\u001B\u0018\u0005.\u000A(this.E, true);
		}

		// Token: 0x06001586 RID: 5510 RVA: 0x0008BCF0 File Offset: 0x00089EF0
		private void chkTypeId_Unchecked(object sender, RoutedEventArgs e)
		{
			\u001B\u0018\u0005.\u000A(this.E, false);
		}

		// Token: 0x06001587 RID: 5511 RVA: 0x0008BD0C File Offset: 0x00089F0C
		public void CustomDispose()
		{
			\u0011\u0018\u0005.\u000A(this.E);
			\u0014\u001A\u0018.\u001D(this.R);
			this.R = \u0018\u000F\u000E.\u001F;
		}

		// Token: 0x06001588 RID: 5512 RVA: 0x0008BD3C File Offset: 0x00089F3C
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x06001589 RID: 5513 RVA: 0x0008BD64 File Offset: 0x00089F64
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.N)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ModelCategories.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.N = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink/ui/usercontrols/modelcategories.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x0600158A RID: 5514 RVA: 0x0008BDAC File Offset: 0x00089FAC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate V(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x0600158B RID: 5515 RVA: 0x0008BDC4 File Offset: 0x00089FC4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.M(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u0009\u0002\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.D = \u001D\u0009\u0010.\u001F(R);
				return;
			case 3:
				this.H = \u0007\u000F\u000E.\u001F(R);
				return;
			case 4:
				this.C = \u001D\u0009\u0010.\u001F(R);
				return;
			case 5:
				this.L = \u001D\u0009\u0010.\u001F(R);
				return;
			case 6:
				this.S = \u0004\u0009\u0010.\u001F(R);
				return;
			case 7:
				this.B = \u0018\u0009\u0010.\u001F(R);
				return;
			case 8:
				this.U = \u001E\u0001\u0010.\u001F(R);
				return;
			case 9:
				this.W = \u0003\u0006\u000E.\u001F(R);
				return;
			case 10:
				this.K = \u0016\u0009\u0010.\u001F(R);
				return;
			case 11:
				this.J = \u0016\u0009\u0010.\u001F(R);
				\u000E\u0015\u000A.\u000A(this.J, new RoutedEventHandler(this.chkTypeId_Checked));
				\u000D\u0015\u000A.\u000A(this.J, new RoutedEventHandler(this.chkTypeId_Unchecked));
				return;
			case 12:
				this.E = \u001D\u000F\u000E.\u001F(R);
				return;
			default:
				this.N = true;
				return;
			}
		}

		// Token: 0x04000870 RID: 2160
		private bool F;

		// Token: 0x04000871 RID: 2161
		private ModelCategoryModel R;

		// Token: 0x04000872 RID: 2162
		internal RadioButton D;

		// Token: 0x04000873 RID: 2163
		internal InvokeCommandAction H;

		// Token: 0x04000874 RID: 2164
		internal RadioButton C;

		// Token: 0x04000875 RID: 2165
		internal RadioButton L;

		// Token: 0x04000876 RID: 2166
		internal LeftImageButton S;

		// Token: 0x04000877 RID: 2167
		internal LeftStripToggleButton B;

		// Token: 0x04000878 RID: 2168
		internal Button U;

		// Token: 0x04000879 RID: 2169
		internal CategoryNavigator W;

		// Token: 0x0400087A RID: 2170
		internal CheckBox K;

		// Token: 0x0400087B RID: 2171
		internal CheckBox J;

		// Token: 0x0400087C RID: 2172
		internal ManageParameters E;

		// Token: 0x0400087D RID: 2173
		private bool N;
	}
}

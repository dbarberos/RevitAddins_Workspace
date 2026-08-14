using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetGen.DI.Interfaces;
using DiRoots.One.SheetGen.UI.Behaviors;
using DiRoots.One.UIBehaviours.Behaviors;
using Microsoft.Xaml.Behaviors;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002D2 RID: 722
	public class ManageParameters : DiRootsWindow, IParameterManager, IComponentConnector
	{
		// Token: 0x06001D8A RID: 7562 RVA: 0x000BA48C File Offset: 0x000B868C
		public ManageParameters()
		{
			\u001D\u0017\u0016.\u000A(this);
		}

		// Token: 0x06001D8B RID: 7563 RVA: 0x000BA4A8 File Offset: 0x000B86A8
		public void Init()
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\ParametersLists\\ManageParameters.xaml.cs", "Init");
			if (\u0011\u001C\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ManageParameters.Init()).MethodHandle;
				}
				ParametersListBoxSelectionBehavior<RevisionParameter> parametersListBoxSelectionBehavior = \u0018\u0017\u0016.\u000A();
				ParametersListBoxSelectionBehavior<RevisionParameter> parametersListBoxSelectionBehavior2 = \u0018\u0017\u0016.\u000A();
				\u000F\u0009\u000A.\u000A(parametersListBoxSelectionBehavior, ListBoxSelectionBehavior<RevisionParameter>.SelectedItemsProperty, \u0004\u0017\u0016.\u000A("SelectedUsedParams"));
				\u000F\u0009\u000A.\u000A(parametersListBoxSelectionBehavior2, ListBoxSelectionBehavior<RevisionParameter>.SelectedItemsProperty, \u0004\u0017\u0016.\u000A("SelectedAvailableParams"));
				\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.GS), parametersListBoxSelectionBehavior2);
				\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.YB), parametersListBoxSelectionBehavior);
			}
			else
			{
				ParametersListBoxSelectionBehavior<SelectionParameter> parametersListBoxSelectionBehavior3 = \u0019\u0017\u0016.\u000A();
				ParametersListBoxSelectionBehavior<SelectionParameter> parametersListBoxSelectionBehavior4 = \u0019\u0017\u0016.\u000A();
				\u000F\u0009\u000A.\u000A(parametersListBoxSelectionBehavior3, ListBoxSelectionBehavior<SelectionParameter>.SelectedItemsProperty, \u0004\u0017\u0016.\u000A("SelectedUsedParams"));
				\u000F\u0009\u000A.\u000A(parametersListBoxSelectionBehavior4, ListBoxSelectionBehavior<SelectionParameter>.SelectedItemsProperty, \u0004\u0017\u0016.\u000A("SelectedAvailableParams"));
				\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.GS), parametersListBoxSelectionBehavior4);
				\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.YB), parametersListBoxSelectionBehavior3);
			}
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\ParametersLists\\ManageParameters.xaml.cs", "Init");
		}

		// Token: 0x06001D8C RID: 7564 RVA: 0x000BA5E0 File Offset: 0x000B87E0
		private void BtnPopUpOk_Click(object sender, RoutedEventArgs e)
		{
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
		}

		// Token: 0x06001D8D RID: 7565 RVA: 0x000BA5FC File Offset: 0x000B87FC
		private void BtnPopUpCancel_Click(object sender, RoutedEventArgs e)
		{
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001D8E RID: 7566 RVA: 0x000BA610 File Offset: 0x000B8810
		private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			ScrollViewer u001F = \u0017\u0001\u0010.\u001F(sender);
			\u0013\u0015\u000A.\u000A(u001F, \u000C\u0015\u000A.\u000A(u001F) - (double)\u001A\u0015\u000A.\u000A(e));
			\u0019\u0013\u000A.\u000A(e, true);
		}

		// Token: 0x06001D8F RID: 7567 RVA: 0x000BA644 File Offset: 0x000B8844
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ManageParameters.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/parameterslists/manageparameters.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001D90 RID: 7568 RVA: 0x000BA68C File Offset: 0x000B888C
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.AS = \u0008\u001C\u000E.\u001F(R);
				return;
			case 2:
				this.GS = \u0007\u0016\u000E.\u001F(R);
				return;
			case 3:
				this.FB = \u001B\u001C\u000E.\u001F(R);
				return;
			case 4:
				this.RB = \u0016\u0009\u0010.\u001F(R);
				return;
			case 5:
				this.DB = \u0015\u0002\u000E.\u001F(R);
				return;
			case 6:
				this.HB = \u0015\u0002\u000E.\u001F(R);
				return;
			case 7:
				this.YB = \u0007\u0016\u000E.\u001F(R);
				return;
			case 8:
				this.CB = \u0015\u0002\u000E.\u001F(R);
				return;
			case 9:
				this.LB = \u0015\u0002\u000E.\u001F(R);
				return;
			case 10:
				this.SB = \u0015\u0002\u000E.\u001F(R);
				return;
			case 11:
				this.BB = \u0015\u0002\u000E.\u001F(R);
				return;
			case 12:
				this.UB = \u0015\u0002\u000E.\u001F(R);
				return;
			case 13:
				this.WB = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.WB, new RoutedEventHandler(this.BtnPopUpCancel_Click));
				return;
			case 14:
				this.KB = \u001E\u0001\u0010.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x06001D91 RID: 7569 RVA: 0x000BA7D0 File Offset: 0x000B89D0
		bool? IParameterManager.SG()
		{
			return \u0018\u0020\u000A.\u001D(this);
		}

		// Token: 0x06001D92 RID: 7570 RVA: 0x000BA7E8 File Offset: 0x000B89E8
		object IParameterManager.BG()
		{
			return \u0007\u000C\u000A.\u001D(this);
		}

		// Token: 0x06001D93 RID: 7571 RVA: 0x000BA800 File Offset: 0x000B8A00
		void IParameterManager.UG(object F)
		{
			\u0017\u001A\u000A.\u0007(this, F);
		}

		// Token: 0x06001D94 RID: 7572 RVA: 0x000BA814 File Offset: 0x000B8A14
		Window IParameterManager.WG()
		{
			return \u000D\u0011\u0016.\u0007(this);
		}

		// Token: 0x06001D95 RID: 7573 RVA: 0x000BA82C File Offset: 0x000B8A2C
		void IParameterManager.KG(Window F)
		{
			\u000C\u000E\u0007.\u001D(this, F);
		}

		// Token: 0x04000BF1 RID: 3057
		internal ManageParameters AS;

		// Token: 0x04000BF2 RID: 3058
		internal ListBox GS;

		// Token: 0x04000BF3 RID: 3059
		internal Microsoft.Xaml.Behaviors.EventTrigger FB;

		// Token: 0x04000BF4 RID: 3060
		internal CheckBox RB;

		// Token: 0x04000BF5 RID: 3061
		internal Image DB;

		// Token: 0x04000BF6 RID: 3062
		internal Image HB;

		// Token: 0x04000BF7 RID: 3063
		internal ListBox YB;

		// Token: 0x04000BF8 RID: 3064
		internal Image CB;

		// Token: 0x04000BF9 RID: 3065
		internal Image LB;

		// Token: 0x04000BFA RID: 3066
		internal Image SB;

		// Token: 0x04000BFB RID: 3067
		internal Image BB;

		// Token: 0x04000BFC RID: 3068
		internal Image UB;

		// Token: 0x04000BFD RID: 3069
		internal Button WB;

		// Token: 0x04000BFE RID: 3070
		internal Button KB;

		// Token: 0x04000BFF RID: 3071
		private bool R;
	}
}

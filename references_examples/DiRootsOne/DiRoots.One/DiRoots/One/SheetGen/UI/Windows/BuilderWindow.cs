using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetGen.DI.Interfaces;
using DiRoots.One.SheetGen.UI.Behaviors;
using DiRoots.One.UIBehaviours.Behaviors;
using Microsoft.Xaml.Behaviors;

namespace DiRoots.One.SheetGen.UI.Windows
{
	// Token: 0x02000393 RID: 915
	public class BuilderWindow : DiRootsWindow, IBuilderWindow, IComponentConnector
	{
		// Token: 0x0600252A RID: 9514 RVA: 0x000E0A88 File Offset: 0x000DEC88
		public BuilderWindow()
		{
			\u0005\u001F\u0002.\u000A(this);
			ParametersListBoxSelectionBehavior<SelectionParameter> parametersListBoxSelectionBehavior = new ParametersListBoxSelectionBehavior<SelectionParameter>();
			ParametersListBoxSelectionBehavior<SelectionParameter> parametersListBoxSelectionBehavior2 = new ParametersListBoxSelectionBehavior<SelectionParameter>();
			\u000F\u0009\u000A.\u000A(parametersListBoxSelectionBehavior, ListBoxSelectionBehavior<SelectionParameter>.SelectedItemsProperty, new Binding("SelectedUsedParams"));
			\u000F\u0009\u000A.\u000A(parametersListBoxSelectionBehavior2, ListBoxSelectionBehavior<SelectionParameter>.SelectedItemsProperty, new Binding("SelectedAvailableParams"));
			\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.JK), parametersListBoxSelectionBehavior);
			\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.RK), parametersListBoxSelectionBehavior2);
		}

		// Token: 0x17000A6C RID: 2668
		// (get) Token: 0x0600252B RID: 9515 RVA: 0x000E0B04 File Offset: 0x000DED04
		// (set) Token: 0x0600252C RID: 9516 RVA: 0x000E0B18 File Offset: 0x000DED18
		public bool IsBuildNumber { get; set; }

		// Token: 0x0600252D RID: 9517 RVA: 0x000E0B2C File Offset: 0x000DED2C
		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex u001F = \u0015\u000F\u0007.\u000A("[^0-9]+");
			\u0019\u0013\u000A.\u000A(e, \u000C\u000F\u0007.\u001D(u001F, \u0001\u0015\u0007.\u000A(e)));
		}

		// Token: 0x0600252E RID: 9518 RVA: 0x000E0B5C File Offset: 0x000DED5C
		private void wndValueBuilder_Loaded(object sender, RoutedEventArgs e)
		{
			object dk = this.DK;
			object u000A;
			if (!\u0016\u001F\u0002.\u000A(this))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(BuilderWindow.wndValueBuilder_Loaded(object, RoutedEventArgs)).MethodHandle;
				}
				u000A = \u0004\u001E\u000A.\u000A(\u0002\u001F\u0002.\u000A(), " ");
			}
			else
			{
				u000A = \u0004\u001E\u000A.\u000A(\u000B\u001F\u0002.\u000A(), " ");
			}
			\u0014\u001A\u000A.\u000A(dk, u000A);
			if (!\u0016\u001F\u0002.\u000A(this))
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
				object yk = this.YK;
				Visibility u000A2;
				\u001D\u000C\u000A.\u0007(this.UK, u000A2 = Visibility.Collapsed);
				\u001D\u000C\u000A.\u0007(yk, u000A2);
			}
		}

		// Token: 0x0600252F RID: 9519 RVA: 0x000E0BE8 File Offset: 0x000DEDE8
		private void btnApply_Click(object sender, RoutedEventArgs e)
		{
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06002530 RID: 9520 RVA: 0x000E0C08 File Offset: 0x000DEE08
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.R)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(BuilderWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/parameterslists/builderwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06002531 RID: 9521 RVA: 0x000E0C50 File Offset: 0x000DEE50
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06002532 RID: 9522 RVA: 0x000E0C68 File Offset: 0x000DEE68
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.GW = \u001B\u000E\u000E.\u001F(R);
				\u0011\u000C\u000A.\u0007(this.GW, new RoutedEventHandler(this.wndValueBuilder_Loaded));
				return;
			case 2:
				this.FK = \u0008\u0001\u0010.\u001F(R);
				return;
			case 3:
				this.RK = \u0007\u0016\u000E.\u001F(R);
				return;
			case 4:
				this.FB = \u001B\u001C\u000E.\u001F(R);
				return;
			case 5:
				this.RB = \u0016\u0009\u0010.\u001F(R);
				return;
			case 6:
				this.DK = \u001A\u000A\u000E.\u001F(R);
				return;
			case 7:
				this.HK = \u0016\u0009\u0010.\u001F(R);
				return;
			case 8:
				this.YK = \u001B\u0001\u0010.\u001F(R);
				return;
			case 9:
				this.CK = \u0001\u000A\u000E.\u001F(R);
				return;
			case 10:
				this.LK = \u0004\u0009\u0010.\u001F(R);
				return;
			case 11:
				this.SK = \u0001\u000A\u000E.\u001F(R);
				return;
			case 12:
				this.BK = \u0004\u0009\u0010.\u001F(R);
				return;
			case 13:
				this.UK = \u0011\u0001\u0010.\u001F(R);
				return;
			case 14:
				this.WK = \u0001\u000A\u000E.\u001F(R);
				\u000F\u0001\u0007.\u000A(this.WK, new TextCompositionEventHandler(this.NumberValidationTextBox));
				return;
			case 15:
				this.KK = \u0004\u0009\u0010.\u001F(R);
				return;
			case 16:
				this.JK = \u0007\u0016\u000E.\u001F(R);
				return;
			case 17:
				this.DB = \u0015\u0002\u000E.\u001F(R);
				return;
			case 18:
				this.HB = \u0015\u0002\u000E.\u001F(R);
				return;
			case 19:
				this.CB = \u0015\u0002\u000E.\u001F(R);
				return;
			case 20:
				this.LB = \u0015\u0002\u000E.\u001F(R);
				return;
			case 21:
				this.SB = \u0015\u0002\u000E.\u001F(R);
				return;
			case 22:
				this.BB = \u0015\u0002\u000E.\u001F(R);
				return;
			case 23:
				this.UB = \u0015\u0002\u000E.\u001F(R);
				return;
			case 24:
				this.EK = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.EK, new RoutedEventHandler(this.btnApply_Click));
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x06002533 RID: 9523 RVA: 0x000E0E98 File Offset: 0x000DF098
		bool? IBuilderWindow.MFR()
		{
			return \u0018\u0020\u000A.\u001D(this);
		}

		// Token: 0x06002534 RID: 9524 RVA: 0x000E0EB0 File Offset: 0x000DF0B0
		object IBuilderWindow.VFR()
		{
			return \u0007\u000C\u000A.\u001D(this);
		}

		// Token: 0x06002535 RID: 9525 RVA: 0x000E0EC8 File Offset: 0x000DF0C8
		void IBuilderWindow.ZFR(object F)
		{
			\u0017\u001A\u000A.\u0007(this, F);
		}

		// Token: 0x06002536 RID: 9526 RVA: 0x000E0EDC File Offset: 0x000DF0DC
		Window IBuilderWindow.XFR()
		{
			return \u000D\u0011\u0016.\u0007(this);
		}

		// Token: 0x06002537 RID: 9527 RVA: 0x000E0EF4 File Offset: 0x000DF0F4
		void IBuilderWindow.PFR(Window F)
		{
			\u000C\u000E\u0007.\u001D(this, F);
		}

		// Token: 0x04000EB7 RID: 3767
		[CompilerGenerated]
		private bool AW;

		// Token: 0x04000EB8 RID: 3768
		internal BuilderWindow GW;

		// Token: 0x04000EB9 RID: 3769
		internal Border FK;

		// Token: 0x04000EBA RID: 3770
		internal ListBox RK;

		// Token: 0x04000EBB RID: 3771
		internal Microsoft.Xaml.Behaviors.EventTrigger FB;

		// Token: 0x04000EBC RID: 3772
		internal CheckBox RB;

		// Token: 0x04000EBD RID: 3773
		internal Label DK;

		// Token: 0x04000EBE RID: 3774
		internal CheckBox HK;

		// Token: 0x04000EBF RID: 3775
		internal TextBlock YK;

		// Token: 0x04000EC0 RID: 3776
		internal TextBox CK;

		// Token: 0x04000EC1 RID: 3777
		internal LeftImageButton LK;

		// Token: 0x04000EC2 RID: 3778
		internal TextBox SK;

		// Token: 0x04000EC3 RID: 3779
		internal LeftImageButton BK;

		// Token: 0x04000EC4 RID: 3780
		internal StackPanel UK;

		// Token: 0x04000EC5 RID: 3781
		internal TextBox WK;

		// Token: 0x04000EC6 RID: 3782
		internal LeftImageButton KK;

		// Token: 0x04000EC7 RID: 3783
		internal ListBox JK;

		// Token: 0x04000EC8 RID: 3784
		internal Image DB;

		// Token: 0x04000EC9 RID: 3785
		internal Image HB;

		// Token: 0x04000ECA RID: 3786
		internal Image CB;

		// Token: 0x04000ECB RID: 3787
		internal Image LB;

		// Token: 0x04000ECC RID: 3788
		internal Image SB;

		// Token: 0x04000ECD RID: 3789
		internal Image BB;

		// Token: 0x04000ECE RID: 3790
		internal Image UB;

		// Token: 0x04000ECF RID: 3791
		internal Button EK;

		// Token: 0x04000ED0 RID: 3792
		private bool R;
	}
}

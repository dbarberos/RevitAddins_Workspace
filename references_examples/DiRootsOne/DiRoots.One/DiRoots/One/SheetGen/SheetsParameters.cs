using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetGen.DI.Interfaces;
using DiRoots.One.SheetGen.UI.Behaviors;
using DiRoots.One.SheetGen.ViewModels;
using DiRoots.One.UIBehaviours.Behaviors;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002D3 RID: 723
	public class SheetsParameters : DiRootsWindow, ISheetsParameterManager, IComponentConnector
	{
		// Token: 0x06001D96 RID: 7574 RVA: 0x000BA840 File Offset: 0x000B8A40
		public SheetsParameters()
		{
			\u0016\u0017\u0016.\u000A(this);
			\u0005\u0017\u0016.\u000A(this);
		}

		// Token: 0x06001D97 RID: 7575 RVA: 0x000BA860 File Offset: 0x000B8A60
		public SheetsParameters(IParametersWindowViewModel viewModel)
		{
			\u0016\u0017\u0016.\u000A(this);
			\u0017\u001A\u000A.\u0007(this, viewModel);
			\u0005\u0017\u0016.\u000A(this);
		}

		// Token: 0x06001D98 RID: 7576 RVA: 0x000BA888 File Offset: 0x000B8A88
		public void Init()
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\ParametersLists\\SheetsParameters.xaml.cs", "Init");
			ParametersListBoxSelectionBehavior<SelectionParameter> parametersListBoxSelectionBehavior = \u0019\u0017\u0016.\u000A();
			ParametersListBoxSelectionBehavior<SelectionParameter> parametersListBoxSelectionBehavior2 = \u0019\u0017\u0016.\u000A();
			\u000F\u0009\u000A.\u000A(parametersListBoxSelectionBehavior, ListBoxSelectionBehavior<SelectionParameter>.SelectedItemsProperty, \u0004\u0017\u0016.\u000A("SelectedUsedParams"));
			\u000F\u0009\u000A.\u000A(parametersListBoxSelectionBehavior2, ListBoxSelectionBehavior<SelectionParameter>.SelectedItemsProperty, \u0004\u0017\u0016.\u000A("SelectedAvailableParams"));
			\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.GS), parametersListBoxSelectionBehavior2);
			\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.YB), parametersListBoxSelectionBehavior);
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\ParametersLists\\SheetsParameters.xaml.cs", "Init");
		}

		// Token: 0x06001D99 RID: 7577 RVA: 0x000BA92C File Offset: 0x000B8B2C
		private void lstParams_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			SheetsParameters.\u000A\u0011 u000A_u;
			u000A_u.\u000A = \u0018\u000A\u0018.\u000A();
			u000A_u.\u0007 = this;
			u000A_u.\u001D = sender;
			u000A_u.\u0004 = e;
			u000A_u.\u001F = -1;
			u000A_u.\u000A.Start<SheetsParameters.\u000A\u0011>(ref u000A_u);
		}

		// Token: 0x06001D9A RID: 7578 RVA: 0x000BA978 File Offset: 0x000B8B78
		private void btnPopUpCancel_Click(object sender, RoutedEventArgs e)
		{
			\u0006\u0015\u0007.\u0007(this, new bool?(false));
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001D9B RID: 7579 RVA: 0x000BA998 File Offset: 0x000B8B98
		private void btnPopUpOk_Click(object sender, RoutedEventArgs e)
		{
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001D9C RID: 7580 RVA: 0x000BA9B8 File Offset: 0x000B8BB8
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetsParameters.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/parameterslists/sheetsparameters.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001D9D RID: 7581 RVA: 0x000BAA00 File Offset: 0x000B8C00
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.ZB = \u001E\u001C\u000E.\u001F(R);
				return;
			case 2:
				this.XB = \u000B\u000A\u000E.\u001F(R);
				return;
			case 3:
				this.GS = \u0007\u0016\u000E.\u001F(R);
				\u000B\u0017\u0016.\u0007(this.GS, new KeyEventHandler(this.lstParams_PreviewKeyDown));
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
				\u000B\u0017\u0016.\u0007(this.YB, new KeyEventHandler(this.lstParams_PreviewKeyDown));
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
				\u0010\u0015\u000A.\u000A(this.WB, new RoutedEventHandler(this.btnPopUpCancel_Click));
				return;
			case 14:
				this.KB = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.KB, new RoutedEventHandler(this.btnPopUpOk_Click));
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x06001D9E RID: 7582 RVA: 0x000BAB88 File Offset: 0x000B8D88
		bool? ISheetsParameterManager.JG()
		{
			return \u0018\u0020\u000A.\u001D(this);
		}

		// Token: 0x06001D9F RID: 7583 RVA: 0x000BABA0 File Offset: 0x000B8DA0
		object ISheetsParameterManager.EG()
		{
			return \u0007\u000C\u000A.\u001D(this);
		}

		// Token: 0x06001DA0 RID: 7584 RVA: 0x000BABB8 File Offset: 0x000B8DB8
		void ISheetsParameterManager.NG(object F)
		{
			\u0017\u001A\u000A.\u0007(this, F);
		}

		// Token: 0x06001DA1 RID: 7585 RVA: 0x000BABCC File Offset: 0x000B8DCC
		Window ISheetsParameterManager.MG()
		{
			return \u000D\u0011\u0016.\u0007(this);
		}

		// Token: 0x06001DA2 RID: 7586 RVA: 0x000BABE4 File Offset: 0x000B8DE4
		void ISheetsParameterManager.VG(Window F)
		{
			\u000C\u000E\u0007.\u001D(this, F);
		}

		// Token: 0x06001DA3 RID: 7587 RVA: 0x000BABF8 File Offset: 0x000B8DF8
		[CompilerGenerated]
		private bool AYR(SelectionParameter F)
		{
			return \u000F\u0015\u0004.\u000A(\u001F\u0016\u0016.\u0007(F), this.EB, StringComparison.InvariantCultureIgnoreCase);
		}

		// Token: 0x04000C00 RID: 3072
		private DateTime JB;

		// Token: 0x04000C01 RID: 3073
		private string EB;

		// Token: 0x04000C02 RID: 3074
		private Key NB;

		// Token: 0x04000C03 RID: 3075
		private ListBox MB;

		// Token: 0x04000C04 RID: 3076
		private List<SelectionParameter> VB;

		// Token: 0x04000C05 RID: 3077
		internal SheetsParameters ZB;

		// Token: 0x04000C06 RID: 3078
		internal ComboBox XB;

		// Token: 0x04000C07 RID: 3079
		internal ListBox GS;

		// Token: 0x04000C08 RID: 3080
		internal CheckBox RB;

		// Token: 0x04000C09 RID: 3081
		internal Image DB;

		// Token: 0x04000C0A RID: 3082
		internal Image HB;

		// Token: 0x04000C0B RID: 3083
		internal ListBox YB;

		// Token: 0x04000C0C RID: 3084
		internal Image CB;

		// Token: 0x04000C0D RID: 3085
		internal Image LB;

		// Token: 0x04000C0E RID: 3086
		internal Image SB;

		// Token: 0x04000C0F RID: 3087
		internal Image BB;

		// Token: 0x04000C10 RID: 3088
		internal Image UB;

		// Token: 0x04000C11 RID: 3089
		internal Button WB;

		// Token: 0x04000C12 RID: 3090
		internal Button KB;

		// Token: 0x04000C13 RID: 3091
		private bool R;
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.SheetGen;
using DiRoots.One.SheetGen.TemplateTransfer;
using DiRoots.One.SheetGen.TemplateTransfer.UI.Behaviors;
using DiRoots.One.UIBehaviours.Behaviors;

namespace DiRoots.One.TemplateTransfer
{
	// Token: 0x02000299 RID: 665
	public class TemplateTransfers : UserControl, IComponentConnector
	{
		// Token: 0x06001A0C RID: 6668 RVA: 0x000A7A48 File Offset: 0x000A5C48
		public TemplateTransfers(Window owner)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\TemplateTransfer\\UI\\Controls\\TemplateTransfer.xaml.cs", ".ctor");
			TemplateTransferViewModel templateTransferViewModel = new TemplateTransferViewModel();
			\u000A\u000C\u0007.\u0007(templateTransferViewModel, owner);
			this.F = templateTransferViewModel;
			\u0016\u0007\u0016.\u000A(this);
			\u0017\u001A\u000A.\u0007(this, this.F);
			CollectionListBoxSelectionParameterBehavior collectionListBoxSelectionParameterBehavior = new CollectionListBoxSelectionParameterBehavior();
			\u000F\u0009\u000A.\u000A(collectionListBoxSelectionParameterBehavior, ListBoxSelectionBehavior<DiRoots.One.SheetGen.TemplateTransfer.ParameterInfo>.SelectedItemsProperty, new Binding("SelectedParameterInfo"));
			\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.B), collectionListBoxSelectionParameterBehavior);
			CollectionListBoxSelectionTemplateBehavior collectionListBoxSelectionTemplateBehavior = new CollectionListBoxSelectionTemplateBehavior();
			\u000F\u0009\u000A.\u000A(collectionListBoxSelectionTemplateBehavior, ListBoxSelectionBehavior<ViewManagerView>.SelectedItemsProperty, new Binding("SelectedDestinationViewTemplates"));
			\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.E), collectionListBoxSelectionTemplateBehavior);
			\u0005\u0007\u0016.\u000A(this.F);
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\TemplateTransfer\\UI\\Controls\\TemplateTransfer.xaml.cs", ".ctor");
		}

		// Token: 0x06001A0D RID: 6669 RVA: 0x000A7B18 File Offset: 0x000A5D18
		private void TemplateTransfer_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x06001A0E RID: 6670 RVA: 0x000A7B40 File Offset: 0x000A5D40
		private void ListBox_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (\u000C\u0012\u000E.\u001F(\u000A\u0007\u000E.\u001F(\u0018\u0001\u0007.\u000A(e))) != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransfers.ListBox_MouseRightButtonDown(object, MouseButtonEventArgs)).MethodHandle;
					}
					\u0005\u0009\u0005.\u000A(\u001F\u0016\u0019.\u000A(this.C), this.C);
					\u0009\u001A\u0019.\u000A(\u001F\u0016\u0019.\u000A(this.C), true);
					\u0019\u0013\u000A.\u000A(e, true);
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\TemplateTransfer\\UI\\Controls\\TemplateTransfer.xaml.cs", "ListBox_MouseRightButtonDown");
			}
		}

		// Token: 0x06001A0F RID: 6671 RVA: 0x000A7BD8 File Offset: 0x000A5DD8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.M)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TemplateTransfers.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.M = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/templatetransfer/ui/controls/templatetransfer.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001A10 RID: 6672 RVA: 0x000A7C20 File Offset: 0x000A5E20
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.V(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u001A\u0012\u000E.\u001F(R), new RoutedEventHandler(this.TemplateTransfer_Loaded));
				return;
			case 2:
				this.R = \u000B\u0009\u0010.\u001F(R);
				return;
			case 3:
				this.D = \u000B\u0009\u0010.\u001F(R);
				return;
			case 4:
				this.H = \u0005\u0009\u0010.\u001F(R);
				return;
			case 5:
				this.C = \u0007\u0016\u000E.\u001F(R);
				\u0007\u0002\u0019.\u000A(this.C, new MouseButtonEventHandler(this.ListBox_MouseRightButtonDown));
				return;
			case 6:
				this.L = \u0016\u0009\u0010.\u001F(R);
				return;
			case 7:
				this.S = \u0005\u0009\u0010.\u001F(R);
				return;
			case 8:
				this.B = \u0007\u0016\u000E.\u001F(R);
				return;
			case 9:
				this.U = \u0016\u0009\u0010.\u001F(R);
				return;
			case 10:
				this.W = \u000B\u0009\u0010.\u001F(R);
				return;
			case 11:
				this.K = \u000B\u0009\u0010.\u001F(R);
				return;
			case 12:
				this.J = \u0005\u0009\u0010.\u001F(R);
				return;
			case 13:
				this.E = \u0007\u0016\u000E.\u001F(R);
				return;
			case 14:
				this.N = \u001A\u000A\u000E.\u001F(R);
				return;
			default:
				this.M = true;
				return;
			}
		}

		// Token: 0x04000A59 RID: 2649
		private TemplateTransferViewModel F;

		// Token: 0x04000A5A RID: 2650
		internal MultiSelectComboBox R;

		// Token: 0x04000A5B RID: 2651
		internal MultiSelectComboBox D;

		// Token: 0x04000A5C RID: 2652
		internal WatermarkTextBox H;

		// Token: 0x04000A5D RID: 2653
		internal ListBox C;

		// Token: 0x04000A5E RID: 2654
		internal CheckBox L;

		// Token: 0x04000A5F RID: 2655
		internal WatermarkTextBox S;

		// Token: 0x04000A60 RID: 2656
		internal ListBox B;

		// Token: 0x04000A61 RID: 2657
		internal CheckBox U;

		// Token: 0x04000A62 RID: 2658
		internal MultiSelectComboBox W;

		// Token: 0x04000A63 RID: 2659
		internal MultiSelectComboBox K;

		// Token: 0x04000A64 RID: 2660
		internal WatermarkTextBox J;

		// Token: 0x04000A65 RID: 2661
		internal ListBox E;

		// Token: 0x04000A66 RID: 2662
		internal Label N;

		// Token: 0x04000A67 RID: 2663
		private bool M;
	}
}

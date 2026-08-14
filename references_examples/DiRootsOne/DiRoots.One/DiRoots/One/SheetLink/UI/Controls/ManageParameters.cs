using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using A;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.UI.Behaviors;
using DiRoots.One.SheetLink.ViewModels;
using DiRoots.One.UIBehaviours.Behaviors;
using Microsoft.Xaml.Behaviors;

namespace DiRoots.One.SheetLink.UI.Controls
{
	// Token: 0x02000229 RID: 553
	public class ManageParameters : UserControl, IComponentConnector
	{
		// Token: 0x0600158C RID: 5516 RVA: 0x0008BF04 File Offset: 0x0008A104
		public ManageParameters()
		{
			\u0007\u0005\u0005.\u000A(this, new RevitParametersModel());
			\u0017\u001A\u000A.\u0007(this, \u001A\u0014\u0018.\u001D(this));
			\u000A\u0005\u0005.\u000A(this);
			ParameterSelectionBehavior parameterSelectionBehavior = new ParameterSelectionBehavior();
			ParameterSelectionBehavior parameterSelectionBehavior2 = new ParameterSelectionBehavior();
			\u000F\u0009\u000A.\u000A(parameterSelectionBehavior, ListBoxSelectionBehavior<RevitParameter>.SelectedItemsProperty, new Binding("SelectedUsedParams"));
			\u000F\u0009\u000A.\u000A(parameterSelectionBehavior2, ListBoxSelectionBehavior<RevitParameter>.SelectedItemsProperty, new Binding("SelectedAvailableParams"));
			\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.H.B), parameterSelectionBehavior2);
			\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.K.B), parameterSelectionBehavior);
			\u0001\u0018\u0005.\u000A(this.H.B, \u0005\u000F\u000E.\u001F(\u0009\u0018\u0005.\u0007(this, "DragTemplate")));
			\u0015\u0018\u0005.\u000A(this.H.B, true);
			\u001F\u0005\u0005.\u000A(this.H.B, true);
			\u000C\u0018\u0005.\u000A(this.H.B, false);
			\u0001\u0018\u0005.\u000A(this.K.B, \u0005\u000F\u000E.\u001F(\u0009\u0018\u0005.\u0007(this, "DragTemplate")));
			\u0015\u0018\u0005.\u000A(this.K.B, true);
			\u000C\u0018\u0005.\u000A(this.K.B, true);
			\u001A\u0018\u0005.\u000A(\u0010\u000C\u0007.\u000A(this.K.B), new NotifyCollectionChangedEventHandler(this.ListView_CollectionChanged));
			this.H.J("EventFromAvailableList");
		}

		// Token: 0x0600158D RID: 5517 RVA: 0x0008C074 File Offset: 0x0008A274
		private void ListView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (\u0004\u0005\u0005.\u000A(e) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ManageParameters.ListView_CollectionChanged(object, NotifyCollectionChangedEventArgs)).MethodHandle;
				}
				ParameterBaseModel<BaseParameter>.CollectionChangedDelegate collectionChangedDelegate = \u0013\u0014\u0018.\u0007(\u001A\u0014\u0018.\u001D(this));
				if (collectionChangedDelegate == null)
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
					return;
				}
				\u001D\u0005\u0005.\u000A(collectionChangedDelegate);
			}
		}

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x0600158E RID: 5518 RVA: 0x0008C0C4 File Offset: 0x0008A2C4
		// (set) Token: 0x0600158F RID: 5519 RVA: 0x0008C0D8 File Offset: 0x0008A2D8
		public RevitParametersModel ParametersModel { get; set; }

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x06001590 RID: 5520 RVA: 0x0008C0EC File Offset: 0x0008A2EC
		// (set) Token: 0x06001591 RID: 5521 RVA: 0x0008C100 File Offset: 0x0008A300
		public bool ExportedByType
		{
			get
			{
				return this.F;
			}
			set
			{
				this.F = value;
				\u0019\u0005\u0005.\u000A(this.H, value);
				\u0019\u0005\u0005.\u000A(this.K, value);
			}
		}

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x06001592 RID: 5522 RVA: 0x0008C12C File Offset: 0x0008A32C
		// (set) Token: 0x06001593 RID: 5523 RVA: 0x0008C140 File Offset: 0x0008A340
		public bool RemoveType
		{
			get
			{
				return this.R;
			}
			set
			{
				this.R = value;
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ManageParameters.set_RemoveType(bool)).MethodHandle;
					}
					\u001D\u000C\u000A.\u0007(this.S, Visibility.Visible);
					\u001D\u000C\u000A.\u0007(this.C, Visibility.Collapsed);
				}
				else
				{
					\u001D\u000C\u000A.\u0007(this.S, Visibility.Collapsed);
					\u001D\u000C\u000A.\u0007(this.C, Visibility.Visible);
				}
				\u0018\u0005\u0005.\u000A(this.H, value);
				\u0018\u0005\u0005.\u000A(this.K, value);
			}
		}

		// Token: 0x06001594 RID: 5524 RVA: 0x0008C1BC File Offset: 0x0008A3BC
		public void Reset()
		{
			\u0012\u001A\u0019.\u000A(this.H);
			\u0012\u001A\u0019.\u000A(this.K);
			\u0005\u0005\u0005.\u000A(\u001A\u0014\u0018.\u001D(this));
		}

		// Token: 0x06001595 RID: 5525 RVA: 0x0008C1EC File Offset: 0x0008A3EC
		public void CustomDispose()
		{
			\u0007\u0005\u0005.\u000A(this, \u0007\u0002\u000E.\u001F);
		}

		// Token: 0x06001596 RID: 5526 RVA: 0x0008C204 File Offset: 0x0008A404
		private void sourceParameters_ItemSourceChanged(object sender, EventArgs e)
		{
			RevitParametersModel revitParametersModel = \u001A\u0014\u0018.\u001D(this);
			if (revitParametersModel == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ManageParameters.sourceParameters_ItemSourceChanged(object, EventArgs)).MethodHandle;
				}
				return;
			}
			ParameterBaseModel<BaseParameter>.CollectionChangedDelegate collectionChangedDelegate = \u0013\u0014\u0018.\u001D(revitParametersModel);
			if (collectionChangedDelegate == null)
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
				return;
			}
			\u001D\u0005\u0005.\u000A(collectionChangedDelegate);
		}

		// Token: 0x06001597 RID: 5527 RVA: 0x0008C24C File Offset: 0x0008A44C
		private void destinationParameters_ItemSourceChanged(object sender, EventArgs e)
		{
			RevitParametersModel revitParametersModel = \u001A\u0014\u0018.\u001D(this);
			if (revitParametersModel == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ManageParameters.destinationParameters_ItemSourceChanged(object, EventArgs)).MethodHandle;
				}
				return;
			}
			ParameterBaseModel<BaseParameter>.CollectionChangedDelegate collectionChangedDelegate = \u0013\u0014\u0018.\u001D(revitParametersModel);
			if (collectionChangedDelegate == null)
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
				return;
			}
			\u001D\u0005\u0005.\u000A(collectionChangedDelegate);
		}

		// Token: 0x06001598 RID: 5528 RVA: 0x0008C294 File Offset: 0x0008A494
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u0016\u0005\u0005.\u0007(this.H, ParameterControl.TitleProperty, "Common-AvailableParameters");
			\u0016\u0005\u0005.\u0007(this.K, ParameterControl.TitleProperty, "Common-SelectedParameters");
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x06001599 RID: 5529 RVA: 0x0008C2E8 File Offset: 0x0008A4E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.P)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ManageParameters.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.P = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink/ui/usercontrols/parameters/manageparameters.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x0600159A RID: 5530 RVA: 0x0008C330 File Offset: 0x0008A530
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate T(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x0600159B RID: 5531 RVA: 0x0008C348 File Offset: 0x0008A548
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.O(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u001D\u000F\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.H = \u001D\u0016\u000E.\u001F(R);
				return;
			case 3:
				this.C = \u0014\u0001\u0010.\u001F(R);
				return;
			case 4:
				this.L = \u001A\u000A\u000E.\u001F(R);
				return;
			case 5:
				this.S = \u0014\u0001\u0010.\u001F(R);
				return;
			case 6:
				this.B = \u0015\u0002\u000E.\u001F(R);
				return;
			case 7:
				this.U = \u0007\u000F\u000E.\u001F(R);
				return;
			case 8:
				this.W = \u0015\u0002\u000E.\u001F(R);
				return;
			case 9:
				this.K = \u001D\u0016\u000E.\u001F(R);
				return;
			case 10:
				this.J = \u0015\u0002\u000E.\u001F(R);
				return;
			case 11:
				this.E = \u0015\u0002\u000E.\u001F(R);
				return;
			case 12:
				this.N = \u0015\u0002\u000E.\u001F(R);
				return;
			case 13:
				this.M = \u0015\u0002\u000E.\u001F(R);
				return;
			case 14:
				this.V = \u0015\u0002\u000E.\u001F(R);
				return;
			default:
				this.P = true;
				return;
			}
		}

		// Token: 0x0400087E RID: 2174
		private bool F;

		// Token: 0x0400087F RID: 2175
		private bool R;

		// Token: 0x04000880 RID: 2176
		[CompilerGenerated]
		private RevitParametersModel D;

		// Token: 0x04000881 RID: 2177
		internal ParameterControl H;

		// Token: 0x04000882 RID: 2178
		internal Grid C;

		// Token: 0x04000883 RID: 2179
		internal Label L;

		// Token: 0x04000884 RID: 2180
		internal Grid S;

		// Token: 0x04000885 RID: 2181
		internal Image B;

		// Token: 0x04000886 RID: 2182
		internal InvokeCommandAction U;

		// Token: 0x04000887 RID: 2183
		internal Image W;

		// Token: 0x04000888 RID: 2184
		internal ParameterControl K;

		// Token: 0x04000889 RID: 2185
		internal Image J;

		// Token: 0x0400088A RID: 2186
		internal Image E;

		// Token: 0x0400088B RID: 2187
		internal Image N;

		// Token: 0x0400088C RID: 2188
		internal Image M;

		// Token: 0x0400088D RID: 2189
		internal Image V;

		// Token: 0x0400088E RID: 2190
		private bool P;
	}
}

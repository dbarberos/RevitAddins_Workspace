using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using A;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Profiles;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.OneFilter.LevelsFeature.Model;
using DiRoots.One.OneFilter.LevelsFeature.ViewModels;
using DiRoots.One.OneFilter.VisualizeFeature.Models;
using DiRoots.One.OneFilter.VisualizeFeature.UI.Behaviours;
using DiRoots.One.UIBehaviours.Behaviors;

namespace TwoLevel
{
	// Token: 0x0200003E RID: 62
	public class TwoLevelUI : UserControl, IComponentConnector
	{
		// Token: 0x060001F1 RID: 497 RVA: 0x0000A118 File Offset: 0x00008318
		public TwoLevelUI(UIDocument uiDoc, Window wnd)
		{
			\u0012\u0009\u000A.\u000A(this);
			this.F = new LevelsFeatureViewModel(uiDoc, wnd, this.M);
			\u0017\u001A\u000A.\u0007(this, this.F);
			FilterSetViewModel.VI(null, this.M);
			CollectionsDataGridSelectionBehavior collectionsDataGridSelectionBehavior = new CollectionsDataGridSelectionBehavior();
			\u000F\u0009\u000A.\u000A(collectionsDataGridSelectionBehavior, DataGridSelectionBehavior<ElementsCollection>.SelectedItemsProperty, new Binding("SelectedCollections"));
			\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.T), collectionsDataGridSelectionBehavior);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0000A190 File Offset: 0x00008390
		private void dgSelectedFamilies_Sorting(object sender, DataGridSortingEventArgs e)
		{
			if (\u000D\u0009\u000A.\u000A(e) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TwoLevelUI.dgSelectedFamilies_Sorting(object, DataGridSortingEventArgs)).MethodHandle;
				}
				if (\u0014\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e)))
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
					if (!\u001D\u0017\u000A.\u000A(\u001A\u000C\u000A.\u000A(\u0017\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e))), \u0020\u0009\u000A.\u000A()))
					{
						ListCollectionView u001F = \u000F\u0009\u0010.\u001F(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.T)));
						ListSortDirection? listSortDirection = \u001B\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e));
						ListSortDirection listSortDirection2 = ListSortDirection.Ascending;
						if (\u0008\u0009\u000A.\u000A(ref listSortDirection) == listSortDirection2 & \u000E\u0009\u000A.\u000A(ref listSortDirection))
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
							\u0010\u0009\u000A.\u000A(u001F, new \u001F\u0006\u000A(false));
							\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Descending));
						}
						else
						{
							\u0010\u0009\u000A.\u000A(u001F, new \u001F\u0006\u000A(true));
							\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Ascending));
						}
						\u0003\u0009\u000A.\u000A(e, true);
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
				}
			}
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000A2A0 File Offset: 0x000084A0
		public LevelControlTemplateInfo AddProfile()
		{
			return \u0013\u0009\u000A.\u000A(this.F);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0000A2BC File Offset: 0x000084BC
		public LevelControlTemplateInfo SaveProfile()
		{
			return \u001A\u0009\u000A.\u000A(this.F);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0000A2D8 File Offset: 0x000084D8
		public void ProfileChanged(ProfileTemplate profileInfo)
		{
			\u000C\u0009\u000A.\u000A(this.F, profileInfo);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0000A2F4 File Offset: 0x000084F4
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			bool u000A = \u0001\u0009\u000A.\u000A(\u0009\u0009\u000A.\u000A());
			\u0015\u0009\u000A.\u000A(this.H, u000A);
			\u0015\u0009\u000A.\u000A(this.L, u000A);
			\u0015\u0009\u000A.\u000A(this.C, u000A);
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000A350 File Offset: 0x00008550
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.FR)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TwoLevelUI.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.FR = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/onefilter/levelsfeature/ui/controls/twolevelui.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000A398 File Offset: 0x00008598
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.RR(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u0007\u0009\u0010.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.R = \u001D\u0009\u0010.\u001F(R);
				return;
			case 3:
				this.D = \u001D\u0009\u0010.\u001F(R);
				return;
			case 4:
				this.H = \u0004\u0009\u0010.\u001F(R);
				return;
			case 5:
				this.C = \u0019\u0009\u0010.\u001F(R);
				return;
			case 6:
				this.L = \u0018\u0009\u0010.\u001F(R);
				return;
			case 7:
				this.S = \u0005\u0009\u0010.\u001F(R);
				return;
			case 8:
				this.B = \u0016\u0009\u0010.\u001F(R);
				return;
			case 9:
				this.U = \u000B\u0009\u0010.\u001F(R);
				return;
			case 10:
				this.W = \u0005\u0009\u0010.\u001F(R);
				return;
			case 11:
				this.K = \u0002\u0009\u0010.\u001F(R);
				return;
			case 12:
				this.J = \u0016\u0009\u0010.\u001F(R);
				return;
			case 13:
				this.E = \u0017\u0001\u0010.\u001F(R);
				return;
			case 14:
				this.N = \u0014\u0001\u0010.\u001F(R);
				return;
			case 15:
				this.M = \u0011\u0001\u0010.\u001F(R);
				return;
			case 16:
				this.V = \u001E\u0001\u0010.\u001F(R);
				return;
			case 17:
				this.P = \u001E\u0001\u0010.\u001F(R);
				return;
			case 18:
				this.O = \u0014\u0001\u0010.\u001F(R);
				return;
			case 19:
				this.T = \u0020\u0001\u0010.\u001F(R);
				\u001F\u001F\u0007.\u000A(this.T, new DataGridSortingEventHandler(this.dgSelectedFamilies_Sorting));
				return;
			case 20:
				this.I = \u0006\u0009\u0010.\u001F(R);
				return;
			case 21:
				this.Q = \u0006\u0009\u0010.\u001F(R);
				return;
			case 22:
				this.A = \u0006\u0009\u0010.\u001F(R);
				return;
			case 23:
				this.G = \u0016\u0009\u0010.\u001F(R);
				return;
			default:
				this.FR = true;
				return;
			}
		}

		// Token: 0x040000CB RID: 203
		private readonly LevelsFeatureViewModel F;

		// Token: 0x040000CC RID: 204
		internal RadioButton R;

		// Token: 0x040000CD RID: 205
		internal RadioButton D;

		// Token: 0x040000CE RID: 206
		internal LeftImageButton H;

		// Token: 0x040000CF RID: 207
		internal LeftStripButton C;

		// Token: 0x040000D0 RID: 208
		internal LeftStripToggleButton L;

		// Token: 0x040000D1 RID: 209
		internal WatermarkTextBox S;

		// Token: 0x040000D2 RID: 210
		internal CheckBox B;

		// Token: 0x040000D3 RID: 211
		internal MultiSelectComboBox U;

		// Token: 0x040000D4 RID: 212
		internal WatermarkTextBox W;

		// Token: 0x040000D5 RID: 213
		internal TreeView K;

		// Token: 0x040000D6 RID: 214
		internal CheckBox J;

		// Token: 0x040000D7 RID: 215
		internal ScrollViewer E;

		// Token: 0x040000D8 RID: 216
		internal Grid N;

		// Token: 0x040000D9 RID: 217
		internal StackPanel M;

		// Token: 0x040000DA RID: 218
		internal Button V;

		// Token: 0x040000DB RID: 219
		internal Button P;

		// Token: 0x040000DC RID: 220
		internal Grid O;

		// Token: 0x040000DD RID: 221
		internal DataGrid T;

		// Token: 0x040000DE RID: 222
		internal MenuItem I;

		// Token: 0x040000DF RID: 223
		internal MenuItem Q;

		// Token: 0x040000E0 RID: 224
		internal MenuItem A;

		// Token: 0x040000E1 RID: 225
		internal CheckBox G;

		// Token: 0x040000E2 RID: 226
		private bool FR;
	}
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Threading;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Profiles;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.UIBehaviours.Behaviors;
using DiRoots.RoomPro.Interfaces;
using DiRoots.RoomPro.Models;
using DiRoots.RoomPro.ViewModels;

namespace DiRoots.RoomPro.UI.Windows
{
	// Token: 0x02000066 RID: 102
	public class QuickViewsWindow : DiRootsWindow, IComponentConnector, IStyleConnector
	{
		// Token: 0x06000483 RID: 1155 RVA: 0x0001CD30 File Offset: 0x0001AF30
		public QuickViewsWindow(UIDocument uiDoc, UIApplication uiapp)
		{
			\u001C\u000C\u0007.\u0007(this, \u001E\u000A\u0007.\u000A());
			\u0011\u0003\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\UI\\Window\\QuickViewsWindow.xaml.cs", ".ctor");
			\u0003\u000C\u0007.\u000A(this, uiDoc);
			\u0012\u000C\u0007.\u000A(this, \u0011\u0020\u000A.\u0007(uiDoc));
			\u000F\u000C\u0007.\u000A(this, uiapp);
			QuickViewsViewModel quickViewsViewModel = new QuickViewsViewModel(\u0006\u000C\u0007.\u000A(this));
			\u000A\u000C\u0007.\u0007(quickViewsViewModel, this);
			QuickViewsViewModel u000A = quickViewsViewModel;
			this.C = quickViewsViewModel;
			\u0017\u001A\u000A.\u0007(this, u000A);
			\u0002\u000C\u0007.\u000A(this);
			\u0017\u001A\u000A.\u001D(this.DR, this.C);
			\u0017\u001A\u000A.\u001D(this.HR, this.C);
			\u0017\u001A\u000A.\u001D(this.YR, this.C);
			MR mr = new MR();
			\u000F\u0009\u000A.\u000A(mr, DataGridSelectionBehavior<ModelSpatialElement>.SelectedItemsProperty, new Binding("SelectModelElements"));
			\u0002\u0009\u000A.\u000A(\u0006\u0009\u000A.\u000A(this.D), mr);
			\u000B\u000C\u0007.\u000A(this, "QuickViews");
			\u0016\u000C\u0007.\u000A(this, "QuickViews");
			\u000F\u0012\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\UI\\Window\\QuickViewsWindow.xaml.cs", ".ctor");
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x0001CE3C File Offset: 0x0001B03C
		// (set) Token: 0x06000485 RID: 1157 RVA: 0x0001CE50 File Offset: 0x0001B050
		public static QuickViewsWindow CurrentMainWindow { get; internal set; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x0001CE64 File Offset: 0x0001B064
		// (set) Token: 0x06000487 RID: 1159 RVA: 0x0001CE78 File Offset: 0x0001B078
		public UIApplication UiApp { get; set; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000488 RID: 1160 RVA: 0x0001CE8C File Offset: 0x0001B08C
		// (set) Token: 0x06000489 RID: 1161 RVA: 0x0001CEA0 File Offset: 0x0001B0A0
		public Document _document { get; set; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600048A RID: 1162 RVA: 0x0001CEB4 File Offset: 0x0001B0B4
		// (set) Token: 0x0600048B RID: 1163 RVA: 0x0001CEC8 File Offset: 0x0001B0C8
		public UIDocument _uidocument { get; set; }

		// Token: 0x0600048C RID: 1164 RVA: 0x0001CEDC File Offset: 0x0001B0DC
		private void PropagateHeaderCheckStateForRooms(object sender, RoutedEventArgs e)
		{
			QuickViewsWindow.\u001B\u001D u001B_u001D = new QuickViewsWindow.\u001B\u001D();
			QuickViewsWindow.\u001B\u001D u001B_u001D2 = u001B_u001D;
			bool? u000A = \u0003\u0015\u000A.\u000A(\u0011\u000A\u000E.\u001F(sender));
			u001B_u001D2.\u001F = \u0019\u0020\u000A.\u000A(ref u000A);
			\u000C\u0003\u0007.\u000A(Enumerable.ToList<IModelElement>(Enumerable.Cast<IModelElement>(\u0009\u0006\u0007.\u0007(this.D))), new Action<IModelElement>(u001B_u001D.\u000A));
			IEnumerable<IModelElement> enumerable = Enumerable.Cast<IModelElement>(\u0010\u000C\u0007.\u000A(this.D));
			IEnumerable<IModelElement> enumerable2 = enumerable;
			Func<IModelElement, bool> func;
			if ((func = QuickViewsWindow.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsWindow.PropagateHeaderCheckStateForRooms(object, RoutedEventArgs)).MethodHandle;
				}
				func = (QuickViewsWindow.<>c.\u000A = new Func<IModelElement, bool>(QuickViewsWindow.<>c.\u001F.\u0005));
			}
			if (Enumerable.All<IModelElement>(enumerable2, func))
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
				\u000D\u000C\u0007.\u000A(this.FR, new bool?(true));
			}
			else
			{
				IEnumerable<IModelElement> enumerable3 = enumerable;
				Func<IModelElement, bool> func2;
				if ((func2 = QuickViewsWindow.<>c.\u0007) == null)
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
					func2 = (QuickViewsWindow.<>c.\u0007 = new Func<IModelElement, bool>(QuickViewsWindow.<>c.\u001F.\u0016));
				}
				if (Enumerable.Any<IModelElement>(enumerable3, func2))
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
					object fr = this.FR;
					\u001B\u000A\u000E.\u001F(ref u000A);
					\u000D\u000C\u0007.\u000A(fr, u000A);
				}
				else
				{
					\u000D\u000C\u0007.\u000A(this.FR, new bool?(false));
				}
			}
			\u0017\u0003\u0007.\u001D(this.C);
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x0001D018 File Offset: 0x0001B218
		private void LinkedFilesCheckBox_Click(object sender, RoutedEventArgs e)
		{
			IEnumerable<IModelElement> enumerable = Enumerable.Cast<IModelElement>(\u0010\u000C\u0007.\u000A(this.D));
			if (Enumerable.Any<IModelElement>(enumerable))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsWindow.LinkedFilesCheckBox_Click(object, RoutedEventArgs)).MethodHandle;
				}
				IEnumerable<IModelElement> enumerable2 = enumerable;
				Func<IModelElement, bool> func;
				if ((func = QuickViewsWindow.<>c.\u001D) == null)
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
					func = (QuickViewsWindow.<>c.\u001D = new Func<IModelElement, bool>(QuickViewsWindow.<>c.\u001F.\u000B));
				}
				if (Enumerable.All<IModelElement>(enumerable2, func))
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
					\u000D\u000C\u0007.\u000A(this.FR, new bool?(true));
					return;
				}
			}
			if (Enumerable.Any<IModelElement>(enumerable))
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
				IEnumerable<IModelElement> enumerable3 = enumerable;
				Func<IModelElement, bool> func2;
				if ((func2 = QuickViewsWindow.<>c.\u0004) == null)
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
					func2 = (QuickViewsWindow.<>c.\u0004 = new Func<IModelElement, bool>(QuickViewsWindow.<>c.\u001F.\u0002));
				}
				if (Enumerable.Any<IModelElement>(enumerable3, func2))
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
					object fr = this.FR;
					bool? u000A;
					\u001B\u000A\u000E.\u001F(ref u000A);
					\u000D\u000C\u0007.\u000A(fr, u000A);
					return;
				}
			}
			\u000D\u000C\u0007.\u000A(this.FR, new bool?(false));
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0001D11C File Offset: 0x0001B31C
		private void RadioButton_Checked(object sender, RoutedEventArgs e)
		{
			if (this.D == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsWindow.RadioButton_Checked(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			IEnumerable<IModelElement> enumerable = Enumerable.Cast<IModelElement>(\u0010\u000C\u0007.\u000A(this.D));
			if (Enumerable.Any<IModelElement>(enumerable))
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
				IEnumerable<IModelElement> enumerable2 = enumerable;
				Func<IModelElement, bool> func;
				if ((func = QuickViewsWindow.<>c.\u0019) == null)
				{
					for (;;)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					func = (QuickViewsWindow.<>c.\u0019 = new Func<IModelElement, bool>(QuickViewsWindow.<>c.\u001F.\u0006));
				}
				if (Enumerable.All<IModelElement>(enumerable2, func))
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
					\u000D\u000C\u0007.\u000A(this.FR, new bool?(true));
					return;
				}
			}
			if (Enumerable.Any<IModelElement>(enumerable))
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
				IEnumerable<IModelElement> enumerable3 = enumerable;
				Func<IModelElement, bool> func2;
				if ((func2 = QuickViewsWindow.<>c.\u0018) == null)
				{
					for (;;)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					func2 = (QuickViewsWindow.<>c.\u0018 = new Func<IModelElement, bool>(QuickViewsWindow.<>c.\u001F.\u000F));
				}
				if (Enumerable.Any<IModelElement>(enumerable3, func2))
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
					object fr = this.FR;
					bool? u000A;
					\u001B\u000A\u000E.\u001F(ref u000A);
					\u000D\u000C\u0007.\u000A(fr, u000A);
					return;
				}
			}
			\u000D\u000C\u0007.\u000A(this.FR, new bool?(false));
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0001D234 File Offset: 0x0001B434
		private string IDR(DataGridColumn F, bool R = true)
		{
			if (!R)
			{
				return \u000E\u000C\u0007.\u0007(\u0008\u000C\u0007.\u000A(\u000E\u000A\u000E.\u001F(\u001B\u000C\u0007.\u000A(\u0010\u000A\u000E.\u001F(F)))));
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsWindow.IDR(DataGridColumn, bool)).MethodHandle;
			}
			Control u001F = \u000D\u000A\u000E.\u001F(\u0011\u000C\u0007.\u000A(\u001E\u000C\u0007.\u000A(\u0016\u000A\u000E.\u001F(F))));
			string text = this.QDR(\u000F\u001F\u000E.\u001F(u001F), Selector.SelectedItemProperty);
			if (text != null)
			{
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				return text;
			}
			string text2 = this.QDR(\u0008\u000A\u000E.\u001F(u001F), TextBox.TextProperty);
			if (text2 != null)
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
				return text2;
			}
			return string.Empty;
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0001D2EC File Offset: 0x0001B4EC
		private string QDR(FrameworkElement F, DependencyProperty R)
		{
			BindingExpression bindingExpression;
			if (F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsWindow.QDR(FrameworkElement, DependencyProperty)).MethodHandle;
				}
				bindingExpression = \u001C\u000A\u000E.\u001F;
			}
			else
			{
				bindingExpression = \u0017\u000C\u0007.\u0007(F, R);
			}
			BindingExpression bindingExpression2 = bindingExpression;
			if (bindingExpression2 != null)
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
				return \u000E\u000C\u0007.\u0007(\u0008\u000C\u0007.\u000A(\u0020\u000C\u0007.\u0007(bindingExpression2)));
			}
			return null;
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0001D348 File Offset: 0x0001B548
		private void DrgView_Sorting(object sender, DataGridSortingEventArgs e)
		{
			if (\u000D\u0009\u000A.\u000A(e) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsWindow.DrgView_Sorting(object, DataGridSortingEventArgs)).MethodHandle;
				}
				return;
			}
			bool r = \u0012\u000A\u000E.\u001F(\u000D\u0009\u000A.\u000A(e)) != \u0003\u000A\u000E.\u001F;
			string u001F = this.IDR(\u000D\u0009\u000A.\u000A(e), r);
			if (\u001A\u0006\u0007.\u000A(u001F))
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
			ListCollectionView u001F2 = \u000F\u0009\u0010.\u001F(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.D)));
			ListSortDirection? listSortDirection = \u001B\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e));
			ListSortDirection listSortDirection2 = ListSortDirection.Ascending;
			if (\u0008\u0009\u000A.\u000A(ref listSortDirection) == listSortDirection2 & \u000E\u0009\u000A.\u000A(ref listSortDirection))
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
				\u0010\u0009\u000A.\u000A(u001F2, new \u0019\u0007\u000A(u001F, false));
				\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Descending));
			}
			else
			{
				\u0010\u0009\u000A.\u000A(u001F2, new \u0019\u0007\u000A(u001F, true));
				\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Ascending));
			}
			\u0003\u0009\u000A.\u000A(e, true);
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0001D44C File Offset: 0x0001B64C
		private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			\u000D\u0011\u000A.\u0007(\u001E\u000A\u0007.\u000A(), \u0014\u000C\u0007.\u000A(e), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\UI\\Window\\QuickViewsWindow.xaml.cs", "Dispatcher_UnhandledException");
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0001D478 File Offset: 0x0001B678
		private void wndMain_Closed(object sender, EventArgs e)
		{
			\u0013\u000C\u0007.\u000A(\u000F\u000A\u000E.\u001F);
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0001D490 File Offset: 0x0001B690
		private void prfUserControl_AddProfile(object sender, RoutedEventArgs e)
		{
			\u001A\u000C\u0007.\u0007(this.W, \u000C\u000C\u0007.\u000A(this.C));
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0001D4B8 File Offset: 0x0001B6B8
		private void prfUserControl_ProfileChanged(object sender, RoutedEventArgs e)
		{
			\u0015\u000C\u0007.\u000A(this.C, \u0001\u000C\u0007.\u0007(this.W));
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0001D4E0 File Offset: 0x0001B6E0
		private void prfUserControl_SaveProfile(object sender, RoutedEventArgs e)
		{
			\u001A\u000C\u0007.\u0007(this.W, \u0009\u000C\u0007.\u000A(this.C));
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0001D508 File Offset: 0x0001B708
		private void DiRootsWindow_Loaded(object sender, RoutedEventArgs e)
		{
			\u0004\u0015\u0007.\u000A(new \u000E\u000E\u000A("DiRootsOne", \u0019\u0015\u0007.\u000A(this), \u001E\u000A\u0007.\u000A()));
			\u001D\u0015\u0007.\u000A(this.W, "SelectionsSettings");
			\u000A\u0015\u0007.\u000A(\u0007\u0015\u0007.\u0007(this.W), \u001E\u0011\u000A.\u000A(\u0006\u000A\u000E.\u001F()));
			\u001F\u0015\u0007.\u000A(this.W);
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0001D570 File Offset: 0x0001B770
		private void ContextMenu_Opened(object sender, RoutedEventArgs e)
		{
			\u0018\u0015\u0007.\u000A(\u0002\u000A\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)));
			\u0018\u000C\u0007.\u000A(this.V, \u0001\u000D\u0007.\u0007(\u001B\u000D\u0007.\u001D(\u0002\u000A\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)))));
			\u0018\u000C\u0007.\u000A(this.O, \u0001\u000D\u0007.\u0007(\u001E\u000D\u0007.\u001D(\u0002\u000A\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)))));
			\u0018\u000C\u0007.\u000A(this.I, \u0001\u000D\u0007.\u0007(\u0008\u000D\u0007.\u001D(\u0002\u000A\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)))));
			\u0018\u000C\u0007.\u000A(this.A, \u0001\u000D\u0007.\u0007(\u0011\u000D\u0007.\u001D(\u0002\u000A\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)))));
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0001D634 File Offset: 0x0001B834
		protected override void ApplyLicense(bool isLicenseValid)
		{
			if (!isLicenseValid)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsWindow.ApplyLicense(bool)).MethodHandle;
				}
				\u0019\u000B\u0007.\u0007(this);
			}
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0001D660 File Offset: 0x0001B860
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/quickviews/ui/window/quickviewswindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0001D6A8 File Offset: 0x0001B8A8
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0001D6C0 File Offset: 0x0001B8C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.U = \u0019\u000A\u000E.\u001F(R);
				\u0016\u0015\u0007.\u0007(this.U, new EventHandler(this.wndMain_Closed));
				\u0011\u000C\u000A.\u0007(this.U, new RoutedEventHandler(this.DiRootsWindow_Loaded));
				return;
			case 2:
				this.W = \u0018\u000A\u000E.\u001F(R);
				return;
			case 3:
				this.K = \u001D\u0009\u0010.\u001F(R);
				\u000E\u0015\u000A.\u000A(this.K, new RoutedEventHandler(this.RadioButton_Checked));
				return;
			case 4:
				this.J = \u001D\u0009\u0010.\u001F(R);
				\u000E\u0015\u000A.\u000A(this.J, new RoutedEventHandler(this.RadioButton_Checked));
				return;
			case 5:
				this.E = \u0016\u0009\u0010.\u001F(R);
				return;
			case 6:
				this.N = \u0016\u0009\u0010.\u001F(R);
				return;
			case 7:
				this.M = \u0005\u0009\u0010.\u001F(R);
				return;
			case 8:
				this.D = \u0020\u0001\u0010.\u001F(R);
				\u001F\u001F\u0007.\u000A(this.D, new DataGridSortingEventHandler(this.DrgView_Sorting));
				return;
			case 9:
				\u0005\u0015\u0007.\u000A(\u0005\u000A\u000E.\u001F(R), new RoutedEventHandler(this.ContextMenu_Opened));
				return;
			case 10:
				this.V = \u0006\u0009\u0010.\u001F(R);
				return;
			case 11:
				this.P = \u001B\u0001\u0010.\u001F(R);
				return;
			case 12:
				this.O = \u0006\u0009\u0010.\u001F(R);
				return;
			case 13:
				this.T = \u001B\u0001\u0010.\u001F(R);
				return;
			case 14:
				this.I = \u0006\u0009\u0010.\u001F(R);
				return;
			case 15:
				this.Q = \u001B\u0001\u0010.\u001F(R);
				return;
			case 16:
				this.A = \u0006\u0009\u0010.\u001F(R);
				return;
			case 17:
				this.G = \u001B\u0001\u0010.\u001F(R);
				return;
			case 18:
				this.FR = \u0016\u0009\u0010.\u001F(R);
				return;
			case 20:
				this.RR = \u0016\u000A\u000E.\u001F(R);
				return;
			case 21:
				this.DR = \u000B\u000A\u000E.\u001F(R);
				return;
			case 22:
				this.HR = \u000B\u000A\u000E.\u001F(R);
				return;
			case 23:
				this.YR = \u000B\u000A\u000E.\u001F(R);
				return;
			}
			this.R = true;
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x0001D908 File Offset: 0x0001BB08
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.AQ(int F, object R)
		{
			if (F == 19)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(QuickViewsWindow.AQ(int, object)).MethodHandle;
				}
				\u0010\u0015\u000A.\u000A(\u0016\u0009\u0010.\u001F(R), new RoutedEventHandler(this.PropagateHeaderCheckStateForRooms));
			}
		}

		// Token: 0x0400019F RID: 415
		private readonly QuickViewsViewModel C;

		// Token: 0x040001A1 RID: 417
		[CompilerGenerated]
		private UIApplication L;

		// Token: 0x040001A2 RID: 418
		[CompilerGenerated]
		private Document S;

		// Token: 0x040001A3 RID: 419
		[CompilerGenerated]
		private UIDocument B;

		// Token: 0x040001A4 RID: 420
		internal QuickViewsWindow U;

		// Token: 0x040001A5 RID: 421
		internal ProfileUserControl W;

		// Token: 0x040001A6 RID: 422
		internal RadioButton K;

		// Token: 0x040001A7 RID: 423
		internal RadioButton J;

		// Token: 0x040001A8 RID: 424
		internal CheckBox E;

		// Token: 0x040001A9 RID: 425
		internal CheckBox N;

		// Token: 0x040001AA RID: 426
		internal WatermarkTextBox M;

		// Token: 0x040001AB RID: 427
		internal DataGrid D;

		// Token: 0x040001AC RID: 428
		internal MenuItem V;

		// Token: 0x040001AD RID: 429
		internal TextBlock P;

		// Token: 0x040001AE RID: 430
		internal MenuItem O;

		// Token: 0x040001AF RID: 431
		internal TextBlock T;

		// Token: 0x040001B0 RID: 432
		internal MenuItem I;

		// Token: 0x040001B1 RID: 433
		internal TextBlock Q;

		// Token: 0x040001B2 RID: 434
		internal MenuItem A;

		// Token: 0x040001B3 RID: 435
		internal TextBlock G;

		// Token: 0x040001B4 RID: 436
		internal CheckBox FR;

		// Token: 0x040001B5 RID: 437
		internal DataGridTemplateColumn RR;

		// Token: 0x040001B6 RID: 438
		internal ComboBox DR;

		// Token: 0x040001B7 RID: 439
		internal ComboBox HR;

		// Token: 0x040001B8 RID: 440
		internal ComboBox YR;

		// Token: 0x040001B9 RID: 441
		private bool R;

		// Token: 0x020007B4 RID: 1972
		[CompilerGenerated]
		private sealed class \u001B\u001D
		{
			// Token: 0x06004C17 RID: 19479 RVA: 0x001DB958 File Offset: 0x001D9B58
			internal void \u000A(IModelElement \u001F)
			{
				\u0005\u0001\u000D.\u000A(\u001F, this.\u001F);
			}

			// Token: 0x04001F39 RID: 7993
			public bool \u001F;
		}
	}
}

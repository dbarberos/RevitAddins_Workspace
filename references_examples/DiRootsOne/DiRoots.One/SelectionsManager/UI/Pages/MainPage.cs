using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using SelectionsManager.UI.Controls;
using SelectionsManager.ViewModels;

namespace SelectionsManager.UI.Pages
{
	// Token: 0x0200002E RID: 46
	public class MainPage : Page, IDockablePaneProvider, IComponentConnector
	{
		// Token: 0x0600018D RID: 397 RVA: 0x00008844 File Offset: 0x00006A44
		public MainPage()
		{
			\u0009\u001A\u000A.\u000A(this);
			object c = this.C;
			SavedSelectionsControl savedSelectionsControl = new SavedSelectionsControl();
			SavedSelectionsViewModel savedSelectionsViewModel = new SavedSelectionsViewModel();
			\u0001\u001A\u000A.\u000A(savedSelectionsViewModel, true);
			\u0017\u001A\u000A.\u001D(savedSelectionsControl, savedSelectionsViewModel);
			\u0013\u001A\u000A.\u000A(savedSelectionsControl, \u0015\u001A\u000A.\u000A());
			UserControl u000A = savedSelectionsControl;
			this.F = savedSelectionsControl;
			\u0014\u001A\u000A.\u000A(c, u000A);
			object l = this.L;
			SavedSelectionsControl savedSelectionsControl2 = new SavedSelectionsControl();
			RuleBasedFiltersViewModel ruleBasedFiltersViewModel = new RuleBasedFiltersViewModel();
			\u000C\u001A\u000A.\u000A(ruleBasedFiltersViewModel, false);
			\u0017\u001A\u000A.\u001D(savedSelectionsControl2, ruleBasedFiltersViewModel);
			\u0013\u001A\u000A.\u000A(savedSelectionsControl2, \u001A\u001A\u000A.\u000A());
			u000A = savedSelectionsControl2;
			this.R = savedSelectionsControl2;
			\u0014\u001A\u000A.\u000A(l, u000A);
			\u0017\u001A\u000A.\u0007(this, new MainPageViewModel());
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600018E RID: 398 RVA: 0x000088D8 File Offset: 0x00006AD8
		// (set) Token: 0x0600018F RID: 399 RVA: 0x000088EC File Offset: 0x00006AEC
		private Document Document { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000190 RID: 400 RVA: 0x00008900 File Offset: 0x00006B00
		public bool IsFamilyDocument
		{
			get
			{
				Document document = \u000A\u000C\u000A.\u000A(this);
				if (document == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(MainPage.get_IsFamilyDocument()).MethodHandle;
					}
					return false;
				}
				return \u001F\u000C\u000A.\u0007(document);
			}
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00008938 File Offset: 0x00006B38
		public void Init(UIDocument uidoc)
		{
			\u0018\u000C\u000A.\u000A(this, \u0011\u0020\u000A.\u0007(uidoc));
			if (\u0019\u000C\u000A.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainPage.Init(UIDocument)).MethodHandle;
				}
				\u001D\u000C\u000A.\u0007(this.C, Visibility.Collapsed);
				\u001D\u000C\u000A.\u0007(this.L, Visibility.Collapsed);
				\u0004\u000C\u000A.\u000A(this.H, 0);
			}
			else
			{
				\u001D\u000C\u000A.\u0007(this.C, Visibility.Visible);
				\u001D\u000C\u000A.\u0007(this.L, Visibility.Visible);
			}
			\u0001\u0015\u0010.\u001F(\u0007\u000C\u000A.\u0007(this.F)).AWR(uidoc);
			\u0015\u0015\u0010.\u001F(\u0007\u000C\u000A.\u0007(this.R)).AWR(uidoc);
		}

		// Token: 0x06000192 RID: 402 RVA: 0x000089E4 File Offset: 0x00006BE4
		public void SubscribeNewSelectionNotifiers()
		{
			\u0020\u0017\u000A.\u001D(\u0001\u0015\u0010.\u001F(\u0007\u000C\u000A.\u0007(this.F)));
			\u0015\u0015\u0010.\u001F(\u0007\u000C\u000A.\u0007(this.R)).GWR();
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00008A24 File Offset: 0x00006C24
		public void SetupDockablePane(DockablePaneProviderData data)
		{
			\u000F\u000C\u000A.\u000A(data, this);
			DockablePaneState dockablePaneState = \u0006\u000C\u000A.\u000A();
			\u0002\u000C\u000A.\u000A(dockablePaneState, 59421);
			\u000B\u000C\u000A.\u000A(dockablePaneState, 300);
			\u0016\u000C\u000A.\u000A(dockablePaneState, 300);
			DockablePaneState u000A = dockablePaneState;
			\u0005\u000C\u000A.\u000A(data, u000A);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00008A68 File Offset: 0x00006C68
		private void tctrlParentTabCtrl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (\u0012\u000C\u000A.\u000A(this.H) == 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainPage.tctrlParentTabCtrl_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				\u0015\u0015\u0010.\u001F(\u0007\u000C\u000A.\u0007(this.R)).HKR();
				return;
			}
			if (\u0012\u000C\u000A.\u000A(this.H) == 0)
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
				\u0001\u0015\u0010.\u001F(\u0007\u000C\u000A.\u0007(this.F)).HKR();
			}
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00008AE4 File Offset: 0x00006CE4
		public static Guid GetPaneIdentifier()
		{
			return new Guid("32F4DF52-6A09-4ED9-BD93-107C876F1201");
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00008AFC File Offset: 0x00006CFC
		private void pgMainPage_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00008B24 File Offset: 0x00006D24
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.S)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainPage.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.S = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/onefilter/selectionsmanager/ui/pages/mainpage.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00008B6C File Offset: 0x00006D6C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.B(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u0013\u0015\u0010.\u001F(R), new RoutedEventHandler(this.pgMainPage_Loaded));
				return;
			case 2:
				this.H = \u001A\u0015\u0010.\u001F(R);
				\u001B\u000C\u000A.\u0007(this.H, new SelectionChangedEventHandler(this.tctrlParentTabCtrl_SelectionChanged));
				return;
			case 3:
				this.C = \u000C\u0015\u0010.\u001F(R);
				return;
			case 4:
				this.L = \u000C\u0015\u0010.\u001F(R);
				return;
			default:
				this.S = true;
				return;
			}
		}

		// Token: 0x040000A2 RID: 162
		internal UserControl F;

		// Token: 0x040000A3 RID: 163
		internal UserControl R;

		// Token: 0x040000A4 RID: 164
		[CompilerGenerated]
		private Document D;

		// Token: 0x040000A5 RID: 165
		internal TabControl H;

		// Token: 0x040000A6 RID: 166
		internal TabItem C;

		// Token: 0x040000A7 RID: 167
		internal TabItem L;

		// Token: 0x040000A8 RID: 168
		private bool S;
	}
}

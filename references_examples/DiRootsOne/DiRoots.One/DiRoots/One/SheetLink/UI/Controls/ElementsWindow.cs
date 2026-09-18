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
	// Token: 0x02000227 RID: 551
	public class ElementsWindow : UserControl, IComponentConnector
	{
		// Token: 0x0600157A RID: 5498 RVA: 0x0008B99C File Offset: 0x00089B9C
		public ElementsWindow()
		{
			\u001E\u0018\u0005.\u000A(this);
		}

		// Token: 0x0600157B RID: 5499 RVA: 0x0008B9B8 File Offset: 0x00089BB8
		public void Initialize(UIDocument uidoc, Window parent)
		{
			if (!this.F)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindow.Initialize(UIDocument, Window)).MethodHandle;
				}
				\u0017\u0018\u0005.\u000A(this.K, uidoc);
				this.R = \u0020\u0018\u0005.\u000A(uidoc, parent, this);
				\u0017\u001A\u000A.\u0007(this, this.R);
				this.F = true;
			}
		}

		// Token: 0x0600157C RID: 5500 RVA: 0x0008BA10 File Offset: 0x00089C10
		private void chkTypeId_Checked(object sender, RoutedEventArgs e)
		{
			\u001B\u0018\u0005.\u000A(this.N, true);
		}

		// Token: 0x0600157D RID: 5501 RVA: 0x0008BA2C File Offset: 0x00089C2C
		private void chkTypeId_Unchecked(object sender, RoutedEventArgs e)
		{
			\u001B\u0018\u0005.\u000A(this.N, false);
		}

		// Token: 0x0600157E RID: 5502 RVA: 0x0008BA48 File Offset: 0x00089C48
		public void CustomDispose()
		{
			\u0011\u0018\u0005.\u000A(this.N);
			ElementsWindowModel r = this.R;
			if (r == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindow.CustomDispose()).MethodHandle;
				}
			}
			else
			{
				\u0014\u001A\u0018.\u001D(r);
			}
			this.R = \u0019\u000F\u000E.\u001F;
		}

		// Token: 0x0600157F RID: 5503 RVA: 0x0008BA90 File Offset: 0x00089C90
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x06001580 RID: 5504 RVA: 0x0008BAB8 File Offset: 0x00089CB8
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.M)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ElementsWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.M = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink/ui/usercontrols/elementswindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001581 RID: 5505 RVA: 0x0008BB00 File Offset: 0x00089D00
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate P(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06001582 RID: 5506 RVA: 0x0008BB18 File Offset: 0x00089D18
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.V(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u000A\u0006\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
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
				this.W = \u0020\u0006\u000E.\u001F(R);
				return;
			case 10:
				this.K = \u001B\u0006\u000E.\u001F(R);
				return;
			case 11:
				this.J = \u0016\u0009\u0010.\u001F(R);
				return;
			case 12:
				this.E = \u0016\u0009\u0010.\u001F(R);
				\u000E\u0015\u000A.\u000A(this.E, new RoutedEventHandler(this.chkTypeId_Checked));
				\u000D\u0015\u000A.\u000A(this.E, new RoutedEventHandler(this.chkTypeId_Unchecked));
				return;
			case 13:
				this.N = \u001D\u000F\u000E.\u001F(R);
				return;
			default:
				this.M = true;
				return;
			}
		}

		// Token: 0x04000861 RID: 2145
		private bool F;

		// Token: 0x04000862 RID: 2146
		private ElementsWindowModel R;

		// Token: 0x04000863 RID: 2147
		internal RadioButton D;

		// Token: 0x04000864 RID: 2148
		internal InvokeCommandAction H;

		// Token: 0x04000865 RID: 2149
		internal RadioButton C;

		// Token: 0x04000866 RID: 2150
		internal RadioButton L;

		// Token: 0x04000867 RID: 2151
		internal LeftImageButton S;

		// Token: 0x04000868 RID: 2152
		internal LeftStripToggleButton B;

		// Token: 0x04000869 RID: 2153
		internal Button U;

		// Token: 0x0400086A RID: 2154
		internal ItemNavigator W;

		// Token: 0x0400086B RID: 2155
		internal ElementNavigator K;

		// Token: 0x0400086C RID: 2156
		internal CheckBox J;

		// Token: 0x0400086D RID: 2157
		internal CheckBox E;

		// Token: 0x0400086E RID: 2158
		internal ManageParameters N;

		// Token: 0x0400086F RID: 2159
		private bool M;
	}
}

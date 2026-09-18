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
	// Token: 0x02000226 RID: 550
	public class AnnotationCategories : UserControl, IComponentConnector
	{
		// Token: 0x06001571 RID: 5489 RVA: 0x0008B6D4 File Offset: 0x000898D4
		public AnnotationCategories()
		{
			\u000E\u0018\u0005.\u000A(this);
		}

		// Token: 0x06001572 RID: 5490 RVA: 0x0008B6F0 File Offset: 0x000898F0
		public void Initialize(UIDocument uidoc, Window parent)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\UI\\UserControls\\AnnotationCategories.xaml.cs", "Initialize");
			if (!this.F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AnnotationCategories.Initialize(UIDocument, Window)).MethodHandle;
				}
				this.R = \u0008\u0018\u0005.\u000A(uidoc, parent, this);
				\u0017\u001A\u000A.\u0007(this, this.R);
				this.F = true;
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\UI\\UserControls\\AnnotationCategories.xaml.cs", "Initialize");
		}

		// Token: 0x06001573 RID: 5491 RVA: 0x0008B768 File Offset: 0x00089968
		private void chkTypeId_Checked(object sender, RoutedEventArgs e)
		{
			\u001B\u0018\u0005.\u000A(this.J, true);
		}

		// Token: 0x06001574 RID: 5492 RVA: 0x0008B784 File Offset: 0x00089984
		private void chkTypeId_Unchecked(object sender, RoutedEventArgs e)
		{
			\u001B\u0018\u0005.\u000A(this.J, false);
		}

		// Token: 0x06001575 RID: 5493 RVA: 0x0008B7A0 File Offset: 0x000899A0
		public void CustomDispose()
		{
			\u0011\u0018\u0005.\u000A(this.J);
			AnnotationCategoryModel r = this.R;
			if (r == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AnnotationCategories.CustomDispose()).MethodHandle;
				}
			}
			else
			{
				\u0014\u001A\u0018.\u001D(r);
			}
			this.R = \u0004\u000F\u000E.\u001F;
		}

		// Token: 0x06001576 RID: 5494 RVA: 0x0008B7E8 File Offset: 0x000899E8
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x06001577 RID: 5495 RVA: 0x0008B810 File Offset: 0x00089A10
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.E)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AnnotationCategories.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.E = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink/ui/usercontrols/annotationcategories.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001578 RID: 5496 RVA: 0x0008B858 File Offset: 0x00089A58
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate M(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06001579 RID: 5497 RVA: 0x0008B870 File Offset: 0x00089A70
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.N(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u001F\u0006\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
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
				this.S = \u0018\u0009\u0010.\u001F(R);
				return;
			case 7:
				this.B = \u001E\u0001\u0010.\u001F(R);
				return;
			case 8:
				this.U = \u0003\u0006\u000E.\u001F(R);
				return;
			case 9:
				this.W = \u0016\u0009\u0010.\u001F(R);
				return;
			case 10:
				this.K = \u0016\u0009\u0010.\u001F(R);
				\u000E\u0015\u000A.\u000A(this.K, new RoutedEventHandler(this.chkTypeId_Checked));
				\u000D\u0015\u000A.\u000A(this.K, new RoutedEventHandler(this.chkTypeId_Unchecked));
				return;
			case 11:
				this.J = \u001D\u000F\u000E.\u001F(R);
				return;
			default:
				this.E = true;
				return;
			}
		}

		// Token: 0x04000854 RID: 2132
		private bool F;

		// Token: 0x04000855 RID: 2133
		private AnnotationCategoryModel R;

		// Token: 0x04000856 RID: 2134
		internal RadioButton D;

		// Token: 0x04000857 RID: 2135
		internal InvokeCommandAction H;

		// Token: 0x04000858 RID: 2136
		internal RadioButton C;

		// Token: 0x04000859 RID: 2137
		internal RadioButton L;

		// Token: 0x0400085A RID: 2138
		internal LeftStripToggleButton S;

		// Token: 0x0400085B RID: 2139
		internal Button B;

		// Token: 0x0400085C RID: 2140
		internal CategoryNavigator U;

		// Token: 0x0400085D RID: 2141
		internal CheckBox W;

		// Token: 0x0400085E RID: 2142
		internal CheckBox K;

		// Token: 0x0400085F RID: 2143
		internal ManageParameters J;

		// Token: 0x04000860 RID: 2144
		private bool E;
	}
}

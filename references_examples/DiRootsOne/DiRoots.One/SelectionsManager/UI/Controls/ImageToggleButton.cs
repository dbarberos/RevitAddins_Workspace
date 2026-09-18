using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using A;

namespace SelectionsManager.UI.Controls
{
	// Token: 0x02000035 RID: 53
	public class ImageToggleButton : UserControl, IComponentConnector
	{
		// Token: 0x060001AC RID: 428 RVA: 0x00008FD8 File Offset: 0x000071D8
		public ImageToggleButton()
		{
			\u0007\u0015\u000A.\u000A(this);
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060001AE RID: 430 RVA: 0x000090B8 File Offset: 0x000072B8
		// (remove) Token: 0x060001AF RID: 431 RVA: 0x00009108 File Offset: 0x00007308
		public event RoutedEventHandler Click
		{
			[CompilerGenerated]
			add
			{
				RoutedEventHandler routedEventHandler = this.R;
				RoutedEventHandler routedEventHandler2;
				do
				{
					routedEventHandler2 = routedEventHandler;
					RoutedEventHandler value2 = \u0006\u0001\u0010.\u001F(\u000F\u001E\u000A.\u000A(routedEventHandler2, value));
					routedEventHandler = Interlocked.CompareExchange<RoutedEventHandler>(ref this.R, value2, routedEventHandler2);
				}
				while (routedEventHandler != routedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ImageToggleButton.add_Click(RoutedEventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				RoutedEventHandler routedEventHandler = this.R;
				RoutedEventHandler routedEventHandler2;
				do
				{
					routedEventHandler2 = routedEventHandler;
					RoutedEventHandler value2 = \u0006\u0001\u0010.\u001F(\u0012\u001E\u000A.\u000A(routedEventHandler2, value));
					routedEventHandler = Interlocked.CompareExchange<RoutedEventHandler>(ref this.R, value2, routedEventHandler2);
				}
				while (routedEventHandler != routedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ImageToggleButton.remove_Click(RoutedEventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x00009158 File Offset: 0x00007358
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x0000917C File Offset: 0x0000737C
		public ICommand Command
		{
			get
			{
				return \u0002\u0001\u0010.\u001F(\u0004\u0015\u000A.\u0007(this, ImageToggleButton.CommandProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, ImageToggleButton.CommandProperty, value);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x00009198 File Offset: 0x00007398
		// (set) Token: 0x060001B3 RID: 435 RVA: 0x000091B4 File Offset: 0x000073B4
		public object CommandParameter
		{
			get
			{
				return \u0004\u0015\u000A.\u0007(this, ImageToggleButton.CommandParameterProperty);
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, ImageToggleButton.CommandParameterProperty, value);
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x000091D0 File Offset: 0x000073D0
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x000091F4 File Offset: 0x000073F4
		public ImageSource ImageSource
		{
			get
			{
				return \u000B\u0001\u0010.\u001F(\u0004\u0015\u000A.\u0007(this, ImageToggleButton.ImageSourceProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, ImageToggleButton.ImageSourceProperty, value);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x00009210 File Offset: 0x00007410
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x00009224 File Offset: 0x00007424
		public ImageSource ToggleSource { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x00009238 File Offset: 0x00007438
		// (set) Token: 0x060001B9 RID: 441 RVA: 0x0000925C File Offset: 0x0000745C
		public bool? IsChecked
		{
			get
			{
				return \u0016\u0001\u0010.\u001F(\u0004\u0015\u000A.\u0007(this, ImageToggleButton.IsCheckedProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, ImageToggleButton.IsCheckedProperty, value);
			}
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0000927C File Offset: 0x0000747C
		private void btnWithImage_Click(object sender, RoutedEventArgs e)
		{
			RoutedEventHandler r = this.R;
			if (r == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ImageToggleButton.btnWithImage_Click(object, RoutedEventArgs)).MethodHandle;
				}
			}
			else
			{
				\u000B\u0015\u000A.\u000A(r, this, \u0002\u0015\u000A.\u000A());
			}
			ICommand command = \u0016\u0015\u000A.\u000A(this);
			if (command == null)
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
				return;
			}
			\u0018\u0015\u000A.\u000A(command, \u0005\u0015\u000A.\u000A(this));
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000092DC File Offset: 0x000074DC
		private void btnWithImage_Checked(object sender, RoutedEventArgs e)
		{
			this.S();
		}

		// Token: 0x060001BC RID: 444 RVA: 0x000092F0 File Offset: 0x000074F0
		private void btnWithImage_Unchecked(object sender, RoutedEventArgs e)
		{
			this.S();
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00009304 File Offset: 0x00007504
		private void S()
		{
			if (this.F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ImageToggleButton.S()).MethodHandle;
				}
				this.F = \u001C\u0015\u000A.\u000A(this);
			}
			bool? flag = \u0003\u0015\u000A.\u000A(this.H);
			if (\u0012\u0015\u000A.\u000A(ref flag))
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
				\u0006\u0015\u000A.\u000A(this, \u000F\u0015\u000A.\u000A(this));
				return;
			}
			\u0006\u0015\u000A.\u000A(this, this.F);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00009378 File Offset: 0x00007578
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.C)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ImageToggleButton.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.C = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/onefilter/selectionsmanager/ui/controls/imagetogglebutton.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060001BF RID: 447 RVA: 0x000093C0 File Offset: 0x000075C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.L(int F, object R)
		{
			if (F == 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ImageToggleButton.L(int, object)).MethodHandle;
				}
				this.H = \u0005\u0001\u0010.\u001F(R);
				\u000E\u0015\u000A.\u000A(this.H, new RoutedEventHandler(this.btnWithImage_Checked));
				\u0010\u0015\u000A.\u000A(this.H, new RoutedEventHandler(this.btnWithImage_Click));
				\u000D\u0015\u000A.\u000A(this.H, new RoutedEventHandler(this.btnWithImage_Unchecked));
				return;
			}
			this.C = true;
		}

		// Token: 0x040000AA RID: 170
		private ImageSource F;

		// Token: 0x040000AB RID: 171
		[CompilerGenerated]
		private RoutedEventHandler R;

		// Token: 0x040000AC RID: 172
		public static readonly DependencyProperty ImageSourceProperty = \u001D\u0015\u000A.\u000A("ImageSource", \u001E\u0011\u000A.\u000A(\u000F\u0001\u0010.\u001F()), \u001E\u0011\u000A.\u000A(\u0012\u0001\u0010.\u001F()));

		// Token: 0x040000AD RID: 173
		public static readonly DependencyProperty IsCheckedProperty = \u001D\u0015\u000A.\u000A("IsChecked", \u001E\u0011\u000A.\u000A(\u0003\u0001\u0010.\u001F()), \u001E\u0011\u000A.\u000A(\u0012\u0001\u0010.\u001F()));

		// Token: 0x040000AE RID: 174
		public static readonly DependencyProperty CommandProperty = \u001D\u0015\u000A.\u000A("Command", \u001E\u0011\u000A.\u000A(\u001C\u0001\u0010.\u001F()), \u001E\u0011\u000A.\u000A(\u0012\u0001\u0010.\u001F()));

		// Token: 0x040000AF RID: 175
		public static readonly DependencyProperty CommandParameterProperty = \u001D\u0015\u000A.\u000A("CommandParameter", \u001E\u0011\u000A.\u000A(\u000D\u0001\u0010.\u001F()), \u001E\u0011\u000A.\u000A(\u0012\u0001\u0010.\u001F()));

		// Token: 0x040000B0 RID: 176
		[CompilerGenerated]
		private ImageSource D;

		// Token: 0x040000B1 RID: 177
		internal ToggleButton H;

		// Token: 0x040000B2 RID: 178
		private bool C;
	}
}

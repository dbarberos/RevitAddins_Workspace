using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace A
{
	// Token: 0x02000166 RID: 358
	internal class L : Behavior<TextBox>
	{
		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06000D5E RID: 3422 RVA: 0x00056528 File Offset: 0x00054728
		// (set) Token: 0x06000D5F RID: 3423 RVA: 0x0005654C File Offset: 0x0005474C
		public int Minimum
		{
			get
			{
				return \u0005\u0005\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, L.MinimumProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, L.MinimumProperty, value);
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06000D60 RID: 3424 RVA: 0x0005656C File Offset: 0x0005476C
		// (set) Token: 0x06000D61 RID: 3425 RVA: 0x00056590 File Offset: 0x00054790
		public int Maximum
		{
			get
			{
				return \u0005\u0005\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, L.MaximumProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, L.MaximumProperty, value);
			}
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x000565B0 File Offset: 0x000547B0
		protected override void OnAttached()
		{
			\u0003\u0006\u0019.\u000A(this);
			\u000F\u0006\u0019.\u0007(\u0012\u0006\u0019.\u000A(this), new TextChangedEventHandler(this.AssociatedObject_TextChanged));
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x000565DC File Offset: 0x000547DC
		protected override void OnDetaching()
		{
			\u000D\u0006\u0019.\u000A(this);
			\u001C\u0006\u0019.\u000A(\u0012\u0006\u0019.\u000A(this), new TextChangedEventHandler(this.AssociatedObject_TextChanged));
		}

		// Token: 0x06000D64 RID: 3428 RVA: 0x00056608 File Offset: 0x00054808
		private void AssociatedObject_TextChanged(object sender, TextChangedEventArgs e)
		{
			int num;
			if (\u001C\u0015\u0004.\u000A(\u0003\u000B\u0019.\u0007(\u0012\u0006\u0019.\u000A(this)), ref num))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(L.AssociatedObject_TextChanged(object, TextChangedEventArgs)).MethodHandle;
				}
				if (num >= \u0010\u0006\u0019.\u000A(this))
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
					if (num <= \u000E\u0006\u0019.\u000A(this))
					{
						return;
					}
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
				}
			}
			object u001F = \u0012\u0006\u0019.\u000A(this);
			string u000A;
			if (num >= \u0010\u0006\u0019.\u000A(this))
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
				int num2 = \u000E\u0006\u0019.\u000A(this);
				u000A = \u000C\u0013\u0007.\u000A(ref num2);
			}
			else
			{
				int num2 = \u0010\u0006\u0019.\u000A(this);
				u000A = \u000C\u0013\u0007.\u000A(ref num2);
			}
			\u001A\u0015\u0007.\u000A(u001F, u000A);
		}

		// Token: 0x0400054C RID: 1356
		public static readonly DependencyProperty MinimumProperty = \u000F\u0006\u001D.\u000A("Minimum", \u001E\u0011\u000A.\u000A(\u0016\u0005\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u000B\u0005\u000E.\u001F()), \u0006\u0006\u0019.\u000A(0));

		// Token: 0x0400054D RID: 1357
		public static readonly DependencyProperty MaximumProperty = \u000F\u0006\u001D.\u000A("Maximum", \u001E\u0011\u000A.\u000A(\u0016\u0005\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u000B\u0005\u000E.\u001F()), \u0006\u0006\u0019.\u000A(0));
	}
}

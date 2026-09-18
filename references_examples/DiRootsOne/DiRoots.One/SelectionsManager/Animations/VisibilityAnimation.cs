using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Animation;
using A;

namespace SelectionsManager.Animations
{
	// Token: 0x02000038 RID: 56
	public class VisibilityAnimation
	{
		// Token: 0x060001CE RID: 462 RVA: 0x000097AC File Offset: 0x000079AC
		static VisibilityAnimation()
		{
			\u0001\u0015\u000A.\u000A(UIElement.VisibilityProperty, \u001E\u0011\u000A.\u000A(\u001F\u0009\u0010.\u001F()), \u0009\u0015\u000A.\u000A(Visibility.Visible, new PropertyChangedCallback(VisibilityAnimation.\u0019), new CoerceValueCallback(VisibilityAnimation.\u0018)));
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00009860 File Offset: 0x00007A60
		public static VisibilityAnimation.AnimationType GetAnimationType(DependencyObject obj)
		{
			return (VisibilityAnimation.AnimationType)\u0004\u0015\u000A.\u001D(obj, VisibilityAnimation.AnimationTypeProperty);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00009880 File Offset: 0x00007A80
		public static void SetAnimationType(DependencyObject obj, VisibilityAnimation.AnimationType value)
		{
			\u0019\u0015\u000A.\u001D(obj, VisibilityAnimation.AnimationTypeProperty, value);
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x000098A0 File Offset: 0x00007AA0
		private static void \u0007(DependencyObject \u001F, DependencyPropertyChangedEventArgs \u000A)
		{
			FrameworkElement frameworkElement = \u0015\u0001\u0010.\u001F(\u001F);
			if (frameworkElement == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(VisibilityAnimation.\u0007(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			if (\u001D\u0001\u000A.\u000A(frameworkElement) != VisibilityAnimation.AnimationType.None)
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
				VisibilityAnimation.\u001D(frameworkElement);
				return;
			}
			VisibilityAnimation.\u0004(frameworkElement);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x000098F0 File Offset: 0x00007AF0
		private static void \u001D(FrameworkElement \u001F)
		{
			\u0004\u0001\u000A.\u000A(VisibilityAnimation.\u000A, \u001F, false);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000990C File Offset: 0x00007B0C
		private static void \u0004(FrameworkElement \u001F)
		{
			if (\u0018\u0001\u000A.\u000A(VisibilityAnimation.\u000A, \u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(VisibilityAnimation.\u0004(FrameworkElement)).MethodHandle;
				}
				\u0019\u0001\u000A.\u000A(VisibilityAnimation.\u000A, \u001F);
			}
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000994C File Offset: 0x00007B4C
		private static void \u0019(DependencyObject \u001F, DependencyPropertyChangedEventArgs \u000A)
		{
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000995C File Offset: 0x00007B5C
		private static object \u0018(DependencyObject \u001F, object \u000A)
		{
			VisibilityAnimation.\u0005\u000A u0005_u000A = new VisibilityAnimation.\u0005\u000A();
			u0005_u000A.\u000A = \u0015\u0001\u0010.\u001F(\u001F);
			if (u0005_u000A.\u000A == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(VisibilityAnimation.\u0018(DependencyObject, object)).MethodHandle;
				}
				return \u000A;
			}
			u0005_u000A.\u001F = \u0001\u0001\u0010.\u001F(\u000A);
			if (u0005_u000A.\u001F == \u0012\u0001\u000A.\u000A(u0005_u000A.\u000A))
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
				return \u000A;
			}
			if (!VisibilityAnimation.\u0005(u0005_u000A.\u000A))
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
				return \u000A;
			}
			if (VisibilityAnimation.\u0016(u0005_u000A.\u000A))
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
				return \u000A;
			}
			DoubleAnimation doubleAnimation = \u000F\u0001\u000A.\u000A();
			\u0002\u0001\u000A.\u000A(doubleAnimation, new Duration(\u0006\u0001\u000A.\u000A(500.0)));
			DoubleAnimation doubleAnimation2 = doubleAnimation;
			\u0017\u0015\u000A.\u000A(doubleAnimation2, new EventHandler(u0005_u000A.\u0007));
			if (u0005_u000A.\u001F != Visibility.Collapsed)
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
				if (u0005_u000A.\u001F != Visibility.Hidden)
				{
					\u000B\u0001\u000A.\u000A(doubleAnimation2, new double?(0.0));
					\u0016\u0001\u000A.\u000A(doubleAnimation2, new double?(1.0));
					goto IL_143;
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
			}
			\u000B\u0001\u000A.\u000A(doubleAnimation2, new double?(1.0));
			\u0016\u0001\u000A.\u000A(doubleAnimation2, new double?(0.0));
			IL_143:
			\u0005\u0001\u000A.\u000A(u0005_u000A.\u000A, UIElement.OpacityProperty, doubleAnimation2);
			return Visibility.Visible;
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00009AC4 File Offset: 0x00007CC4
		private static bool \u0005(FrameworkElement \u001F)
		{
			return \u0018\u0001\u000A.\u000A(VisibilityAnimation.\u000A, \u001F);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00009AE0 File Offset: 0x00007CE0
		private static bool \u0016(FrameworkElement \u001F)
		{
			bool flag = \u001C\u0001\u000A.\u000A(VisibilityAnimation.\u000A, \u001F);
			\u0003\u0001\u000A.\u000A(VisibilityAnimation.\u000A, \u001F, !flag);
			return flag;
		}

		// Token: 0x040000BE RID: 190
		private static int \u001F;

		// Token: 0x040000BF RID: 191
		private static readonly Dictionary<FrameworkElement, bool> \u000A = \u0007\u0001\u000A.\u000A();

		// Token: 0x040000C0 RID: 192
		public static readonly DependencyProperty AnimationTypeProperty = \u001F\u0001\u000A.\u000A("AnimationType", \u001E\u0011\u000A.\u000A(typeof(VisibilityAnimation.AnimationType).TypeHandle), \u001E\u0011\u000A.\u000A(\u0009\u0001\u0010.\u001F()), \u000A\u0001\u000A.\u000A(VisibilityAnimation.AnimationType.None, new PropertyChangedCallback(VisibilityAnimation.\u0007)));

		// Token: 0x02000770 RID: 1904
		public enum AnimationType
		{
			// Token: 0x04001DEA RID: 7658
			None,
			// Token: 0x04001DEB RID: 7659
			Fade
		}

		// Token: 0x02000771 RID: 1905
		[CompilerGenerated]
		private sealed class \u0005\u000A
		{
			// Token: 0x06004AB9 RID: 19129 RVA: 0x001D79A4 File Offset: 0x001D5BA4
			internal void \u0007(object \u001F, EventArgs \u000A)
			{
				if (this.\u001F == Visibility.Visible)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(VisibilityAnimation.\u0005\u000A.\u0007(object, EventArgs)).MethodHandle;
					}
					VisibilityAnimation.\u0016(this.\u000A);
					return;
				}
				if (\u0007\u0015\u000D.\u000A(this.\u000A, UIElement.VisibilityProperty))
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
					Binding u = \u000A\u0015\u000D.\u000A(this.\u000A, UIElement.VisibilityProperty);
					\u000F\u0009\u000A.\u000A(this.\u000A, UIElement.VisibilityProperty, u);
					return;
				}
				\u001D\u000C\u000A.\u0007(this.\u000A, this.\u001F);
			}

			// Token: 0x04001DEC RID: 7660
			public Visibility \u001F;

			// Token: 0x04001DED RID: 7661
			public FrameworkElement \u000A;
		}
	}
}

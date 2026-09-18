using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using A;
using Microsoft.Xaml.Behaviors;

namespace ProSheets.Behaviours
{
	// Token: 0x0200009F RID: 159
	public class RepositionPopupBehavior : Behavior<Popup>
	{
		// Token: 0x0600096A RID: 2410 RVA: 0x0003A1A8 File Offset: 0x000383A8
		protected override void OnAttached()
		{
			\u0009\u000F\u0014.\u0018(this);
			Window window = \u0005\u0007\u0018.\u0018(\u001E\u0005\u0003.\u0018(\u0011\u0005\u0003.\u0018(this)));
			if (window == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RepositionPopupBehavior.OnAttached()).MethodHandle;
				}
				return;
			}
			\u0017\u0005\u0003.\u0018(window, new EventHandler(this.OnLocationChanged));
			\u0015\u0005\u0003.\u0018(window, new SizeChangedEventHandler(this.OnSizeChanged));
			\u0018\u0019\u0018.\u0018(\u0011\u0005\u0003.\u0018(this), new RoutedEventHandler(this.AssociatedObject_Loaded));
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0003A228 File Offset: 0x00038428
		private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x0003A238 File Offset: 0x00038438
		protected override void OnDetaching()
		{
			\u001F\u000F\u0014.\u0018(this);
			Window window = \u0005\u0007\u0018.\u0018(\u001E\u0005\u0003.\u0018(\u0011\u0005\u0003.\u0018(this)));
			if (window == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RepositionPopupBehavior.OnDetaching()).MethodHandle;
				}
				return;
			}
			\u001D\u0005\u0003.\u0018(window, new EventHandler(this.OnLocationChanged));
			\u0004\u0005\u0003.\u0018(window, new SizeChangedEventHandler(this.OnSizeChanged));
			\u0002\u0005\u0003.\u0018(\u0011\u0005\u0003.\u0018(this), new RoutedEventHandler(this.AssociatedObject_Loaded));
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0003A2B8 File Offset: 0x000384B8
		private void OnLocationChanged(object sender, EventArgs e)
		{
			double num = \u000B\u0005\u0003.\u0018(\u0011\u0005\u0003.\u0018(this));
			\u001A\u0005\u0003.\u0018(\u0011\u0005\u0003.\u0018(this), num + 1.0);
			\u001A\u0005\u0003.\u0018(\u0011\u0005\u0003.\u0018(this), num);
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0003A2FC File Offset: 0x000384FC
		private void OnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			double num = \u000B\u0005\u0003.\u0018(\u0011\u0005\u0003.\u0018(this));
			\u001A\u0005\u0003.\u0018(\u0011\u0005\u0003.\u0018(this), num + 1.0);
			\u001A\u0005\u0003.\u0018(\u0011\u0005\u0003.\u0018(this), num);
		}
	}
}

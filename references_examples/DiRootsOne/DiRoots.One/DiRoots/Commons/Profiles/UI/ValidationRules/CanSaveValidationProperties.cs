using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.Commons.Profiles.UI.ValidationRules
{
	// Token: 0x020000BB RID: 187
	public class CanSaveValidationProperties : DependencyObject
	{
		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000734 RID: 1844 RVA: 0x0002A230 File Offset: 0x00028430
		// (set) Token: 0x06000735 RID: 1845 RVA: 0x0002A254 File Offset: 0x00028454
		public ErrorType ErrorType
		{
			get
			{
				return \u0016\u001D\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveValidationProperties.ErrorTypeProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveValidationProperties.ErrorTypeProperty, value);
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x0002A274 File Offset: 0x00028474
		// (set) Token: 0x06000737 RID: 1847 RVA: 0x0002A298 File Offset: 0x00028498
		public string ItemName
		{
			get
			{
				return \u0013\u0001\u0010.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveValidationProperties.ItemNameProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveValidationProperties.ItemNameProperty, value);
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000738 RID: 1848 RVA: 0x0002A2B4 File Offset: 0x000284B4
		// (set) Token: 0x06000739 RID: 1849 RVA: 0x0002A2D8 File Offset: 0x000284D8
		public string ButtonContent
		{
			get
			{
				return \u0013\u0001\u0010.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveValidationProperties.ButtonContentProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveValidationProperties.ButtonContentProperty, value);
			}
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x0002A2F4 File Offset: 0x000284F4
		private static void CallBackOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BindingExpressionBase bindingExpressionBase = \u000D\u0006\u001D.\u000A(\u0003\u001D\u000E.\u001F(d), CanSaveValidationProperties.ButtonContentProperty);
			if (bindingExpressionBase == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveValidationProperties.CallBackOnChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			\u001C\u0006\u001D.\u000A(bindingExpressionBase);
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x0600073B RID: 1851 RVA: 0x0002A334 File Offset: 0x00028534
		// (set) Token: 0x0600073C RID: 1852 RVA: 0x0002A358 File Offset: 0x00028558
		public bool ButtonIsEnabled
		{
			get
			{
				return \u001F\u0001\u0010.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveValidationProperties.ButtonIsEnabledProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveValidationProperties.ButtonIsEnabledProperty, value);
			}
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x0002A378 File Offset: 0x00028578
		private static void IsEnabledCallBackOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BindingExpressionBase bindingExpressionBase = \u000D\u0006\u001D.\u000A(\u0003\u001D\u000E.\u001F(d), CanSaveValidationProperties.ButtonIsEnabledProperty);
			if (bindingExpressionBase == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveValidationProperties.IsEnabledCallBackOnChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			\u001C\u0006\u001D.\u000A(bindingExpressionBase);
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x0002A3B8 File Offset: 0x000285B8
		// (set) Token: 0x0600073F RID: 1855 RVA: 0x0002A3DC File Offset: 0x000285DC
		[Dynamic(new bool[]
		{
			false,
			true
		})]
		public List<dynamic> Items
		{
			get
			{
				return \u0012\u001D\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveValidationProperties.ItemsProperty));
			}
			[param: Dynamic(new bool[]
			{
				false,
				true
			})]
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveValidationProperties.ItemsProperty, value);
			}
		}

		// Token: 0x040002E4 RID: 740
		public static readonly DependencyProperty ErrorTypeProperty = \u000F\u0006\u001D.\u000A("ErrorType", \u001E\u0011\u000A.\u000A(\u000B\u001D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u001C\u001D\u000E.\u001F()), \u0012\u0006\u001D.\u000A(ErrorType.Error, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x040002E5 RID: 741
		public static readonly DependencyProperty ItemNameProperty = \u000F\u0006\u001D.\u000A("ItemName", \u001E\u0011\u000A.\u000A(\u001A\u0001\u0010.\u001F()), \u001E\u0011\u000A.\u000A(\u001C\u001D\u000E.\u001F()), \u0012\u0006\u001D.\u000A("Item", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x040002E6 RID: 742
		public static readonly DependencyProperty ButtonContentProperty = \u000F\u0006\u001D.\u000A("ButtonContent", \u001E\u0011\u000A.\u000A(\u001A\u0001\u0010.\u001F()), \u001E\u0011\u000A.\u000A(\u001C\u001D\u000E.\u001F()), \u0003\u0006\u001D.\u000A(\u0015\u0002\u001D.\u000A(), new PropertyChangedCallback(CanSaveValidationProperties.CallBackOnChanged)));

		// Token: 0x040002E7 RID: 743
		public static readonly DependencyProperty ButtonIsEnabledProperty = \u000F\u0006\u001D.\u000A("ButtonIsEnabled", \u001E\u0011\u000A.\u000A(\u0006\u001D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u001C\u001D\u000E.\u001F()), \u0003\u0006\u001D.\u000A(false, new PropertyChangedCallback(CanSaveValidationProperties.IsEnabledCallBackOnChanged)));

		// Token: 0x040002E8 RID: 744
		public static readonly DependencyProperty ItemsProperty = \u000F\u0006\u001D.\u000A("Items", \u001E\u0011\u000A.\u000A(\u000D\u001D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u001C\u001D\u000E.\u001F()), \u0012\u0006\u001D.\u000A(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
	}
}

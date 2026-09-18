using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.ProfileControl.ValidationRules
{
	// Token: 0x02000011 RID: 17
	public class CanSaveValidationProperties : DependencyObject
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00004B60 File Offset: 0x00002D60
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00004B84 File Offset: 0x00002D84
		public ErrorType ErrorType
		{
			get
			{
				return \u0002\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, CanSaveValidationProperties.ErrorTypeProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, CanSaveValidationProperties.ErrorTypeProperty, value);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00004BA4 File Offset: 0x00002DA4
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00004BC8 File Offset: 0x00002DC8
		public string ItemName
		{
			get
			{
				return \u001E\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, CanSaveValidationProperties.ItemNameProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, CanSaveValidationProperties.ItemNameProperty, value);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00004BE4 File Offset: 0x00002DE4
		// (set) Token: 0x06000072 RID: 114 RVA: 0x00004C08 File Offset: 0x00002E08
		public string ButtonContent
		{
			get
			{
				return \u001E\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, CanSaveValidationProperties.ButtonContentProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, CanSaveValidationProperties.ButtonContentProperty, value);
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00004C24 File Offset: 0x00002E24
		private static void CallBackOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BindingExpressionBase bindingExpressionBase = \u0006\u001A\u0018.\u0018(\u0010\u0002\u000F.\u000C(d), CanSaveValidationProperties.ButtonContentProperty);
			if (bindingExpressionBase == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveValidationProperties.CallBackOnChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			\u0010\u001A\u0018.\u0018(bindingExpressionBase);
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00004C64 File Offset: 0x00002E64
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00004C88 File Offset: 0x00002E88
		public bool ButtonIsEnabled
		{
			get
			{
				return \u0017\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, CanSaveValidationProperties.ButtonIsEnabledProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, CanSaveValidationProperties.ButtonIsEnabledProperty, value);
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00004CA8 File Offset: 0x00002EA8
		private static void IsEnabledCallBackOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BindingExpressionBase bindingExpressionBase = \u0006\u001A\u0018.\u0018(\u0010\u0002\u000F.\u000C(d), CanSaveValidationProperties.ButtonIsEnabledProperty);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveValidationProperties.IsEnabledCallBackOnChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			\u0010\u001A\u0018.\u0018(bindingExpressionBase);
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00004CE8 File Offset: 0x00002EE8
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00004D0C File Offset: 0x00002F0C
		[Dynamic(new bool[]
		{
			false,
			true
		})]
		public List<dynamic> Items
		{
			get
			{
				return \u0007\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, CanSaveValidationProperties.ItemsProperty));
			}
			[param: Dynamic(new bool[]
			{
				false,
				true
			})]
			set
			{
				\u0007\u001A\u0018.\u0014(this, CanSaveValidationProperties.ItemsProperty, value);
			}
		}

		// Token: 0x04000026 RID: 38
		public static readonly DependencyProperty ErrorTypeProperty = \u001D\u001A\u0018.\u0018("ErrorType", \u000A\u001D\u0018.\u0018(\u0004\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0006\u0002\u000F.\u000C()), \u001A\u001A\u0018.\u0018(ErrorType.Error, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x04000027 RID: 39
		public static readonly DependencyProperty ItemNameProperty = \u001D\u001A\u0018.\u0018("ItemName", \u000A\u001D\u0018.\u0018(\u001A\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0006\u0002\u000F.\u000C()), \u001A\u001A\u0018.\u0018("Item", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x04000028 RID: 40
		public static readonly DependencyProperty ButtonContentProperty = \u001D\u001A\u0018.\u0018("ButtonContent", \u000A\u001D\u0018.\u0018(\u001A\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0006\u0002\u000F.\u000C()), \u000B\u001A\u0018.\u0018(\u000D\u0009\u0018.\u000F\u0014, new PropertyChangedCallback(CanSaveValidationProperties.CallBackOnChanged)));

		// Token: 0x04000029 RID: 41
		public static readonly DependencyProperty ButtonIsEnabledProperty = \u001D\u001A\u0018.\u0018("ButtonIsEnabled", \u000A\u001D\u0018.\u0018(\u000B\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0006\u0002\u000F.\u000C()), \u000B\u001A\u0018.\u0018(false, new PropertyChangedCallback(CanSaveValidationProperties.IsEnabledCallBackOnChanged)));

		// Token: 0x0400002A RID: 42
		public static readonly DependencyProperty ItemsProperty = \u001D\u001A\u0018.\u0018("Items", \u000A\u001D\u0018.\u0018(\u0008\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0006\u0002\u000F.\u000C()), \u001A\u001A\u0018.\u0018(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
	}
}

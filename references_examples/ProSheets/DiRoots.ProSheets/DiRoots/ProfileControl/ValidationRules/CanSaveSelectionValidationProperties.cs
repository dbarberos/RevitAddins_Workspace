using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.ProfileControl.ValidationRules
{
	// Token: 0x0200000D RID: 13
	public class CanSaveSelectionValidationProperties : DependencyObject
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000050 RID: 80 RVA: 0x000042EC File Offset: 0x000024EC
		// (set) Token: 0x06000051 RID: 81 RVA: 0x00004310 File Offset: 0x00002510
		public ErrorType ErrorType
		{
			get
			{
				return \u0002\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, CanSaveSelectionValidationProperties.ErrorTypeProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, CanSaveSelectionValidationProperties.ErrorTypeProperty, value);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00004330 File Offset: 0x00002530
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00004354 File Offset: 0x00002554
		public string ItemName
		{
			get
			{
				return \u001E\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, CanSaveSelectionValidationProperties.ItemNameProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, CanSaveSelectionValidationProperties.ItemNameProperty, value);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00004370 File Offset: 0x00002570
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00004394 File Offset: 0x00002594
		public string ButtonContent
		{
			get
			{
				return \u001E\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, CanSaveSelectionValidationProperties.ButtonContentProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, CanSaveSelectionValidationProperties.ButtonContentProperty, value);
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000043B0 File Offset: 0x000025B0
		private static void CallBackOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BindingExpressionBase bindingExpressionBase = \u0006\u001A\u0018.\u0018(\u0015\u0002\u000F.\u000C(d), CanSaveSelectionValidationProperties.ButtonContentProperty);
			if (bindingExpressionBase == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveSelectionValidationProperties.CallBackOnChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			\u0010\u001A\u0018.\u0018(bindingExpressionBase);
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000057 RID: 87 RVA: 0x000043F0 File Offset: 0x000025F0
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00004414 File Offset: 0x00002614
		public bool ButtonIsEnabled
		{
			get
			{
				return \u0017\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, CanSaveSelectionValidationProperties.ButtonIsEnabledProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, CanSaveSelectionValidationProperties.ButtonIsEnabledProperty, value);
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004434 File Offset: 0x00002634
		private static void IsEnabledCallBackOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BindingExpressionBase bindingExpressionBase = \u0006\u001A\u0018.\u0018(\u0015\u0002\u000F.\u000C(d), CanSaveSelectionValidationProperties.ButtonIsEnabledProperty);
			if (bindingExpressionBase == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveSelectionValidationProperties.IsEnabledCallBackOnChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			\u0010\u001A\u0018.\u0018(bindingExpressionBase);
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00004474 File Offset: 0x00002674
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00004498 File Offset: 0x00002698
		public List<string> Items
		{
			get
			{
				return \u0011\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, CanSaveSelectionValidationProperties.ItemsProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, CanSaveSelectionValidationProperties.ItemsProperty, value);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600005C RID: 92 RVA: 0x000044B4 File Offset: 0x000026B4
		// (set) Token: 0x0600005D RID: 93 RVA: 0x000044D8 File Offset: 0x000026D8
		public List<string> FilterItems
		{
			get
			{
				return \u0011\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, CanSaveSelectionValidationProperties.FilterItemsProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, CanSaveSelectionValidationProperties.FilterItemsProperty, value);
			}
		}

		// Token: 0x0400001A RID: 26
		public static readonly DependencyProperty ErrorTypeProperty = \u001D\u001A\u0018.\u0018("ErrorType", \u000A\u001D\u0018.\u0018(\u0004\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u001D\u0002\u000F.\u000C()), \u001A\u001A\u0018.\u0018(ErrorType.Error, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x0400001B RID: 27
		public static readonly DependencyProperty ItemNameProperty = \u001D\u001A\u0018.\u0018("ItemName", \u000A\u001D\u0018.\u0018(\u001A\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u001D\u0002\u000F.\u000C()), \u001A\u001A\u0018.\u0018("Item", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x0400001C RID: 28
		public static readonly DependencyProperty ButtonContentProperty = \u001D\u001A\u0018.\u0018("ButtonContent", \u000A\u001D\u0018.\u0018(\u001A\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u001D\u0002\u000F.\u000C()), \u000B\u001A\u0018.\u0018(\u000D\u0009\u0018.\u000F\u0014, new PropertyChangedCallback(CanSaveSelectionValidationProperties.CallBackOnChanged)));

		// Token: 0x0400001D RID: 29
		public static readonly DependencyProperty ButtonIsEnabledProperty = \u001D\u001A\u0018.\u0018("ButtonIsEnabled", \u000A\u001D\u0018.\u0018(\u000B\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u001D\u0002\u000F.\u000C()), \u000B\u001A\u0018.\u0018(false, new PropertyChangedCallback(CanSaveSelectionValidationProperties.IsEnabledCallBackOnChanged)));

		// Token: 0x0400001E RID: 30
		public static readonly DependencyProperty ItemsProperty = \u001D\u001A\u0018.\u0018("Items", \u000A\u001D\u0018.\u0018(\u0019\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u001D\u0002\u000F.\u000C()), \u001A\u001A\u0018.\u0018(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x0400001F RID: 31
		public static readonly DependencyProperty FilterItemsProperty = \u001D\u001A\u0018.\u0018("FilterItems", \u000A\u001D\u0018.\u0018(\u0019\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u001D\u0002\u000F.\u000C()), \u001A\u001A\u0018.\u0018(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
	}
}

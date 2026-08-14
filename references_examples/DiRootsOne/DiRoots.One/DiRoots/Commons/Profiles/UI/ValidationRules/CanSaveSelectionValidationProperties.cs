using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.Commons.Profiles.UI.ValidationRules
{
	// Token: 0x020000B7 RID: 183
	public class CanSaveSelectionValidationProperties : DependencyObject
	{
		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x000299DC File Offset: 0x00027BDC
		// (set) Token: 0x06000718 RID: 1816 RVA: 0x00029A00 File Offset: 0x00027C00
		public ErrorType ErrorType
		{
			get
			{
				return \u0016\u001D\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveSelectionValidationProperties.ErrorTypeProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveSelectionValidationProperties.ErrorTypeProperty, value);
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000719 RID: 1817 RVA: 0x00029A20 File Offset: 0x00027C20
		// (set) Token: 0x0600071A RID: 1818 RVA: 0x00029A44 File Offset: 0x00027C44
		public string ItemName
		{
			get
			{
				return \u0013\u0001\u0010.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveSelectionValidationProperties.ItemNameProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveSelectionValidationProperties.ItemNameProperty, value);
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x0600071B RID: 1819 RVA: 0x00029A60 File Offset: 0x00027C60
		// (set) Token: 0x0600071C RID: 1820 RVA: 0x00029A84 File Offset: 0x00027C84
		public string ButtonContent
		{
			get
			{
				return \u0013\u0001\u0010.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveSelectionValidationProperties.ButtonContentProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveSelectionValidationProperties.ButtonContentProperty, value);
			}
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x00029AA0 File Offset: 0x00027CA0
		private static void CallBackOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BindingExpressionBase bindingExpressionBase = \u000D\u0006\u001D.\u000A(\u0005\u001D\u000E.\u001F(d), CanSaveSelectionValidationProperties.ButtonContentProperty);
			if (bindingExpressionBase == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveSelectionValidationProperties.CallBackOnChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			\u001C\u0006\u001D.\u000A(bindingExpressionBase);
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x00029AE0 File Offset: 0x00027CE0
		// (set) Token: 0x0600071F RID: 1823 RVA: 0x00029B04 File Offset: 0x00027D04
		public bool ButtonIsEnabled
		{
			get
			{
				return \u001F\u0001\u0010.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveSelectionValidationProperties.ButtonIsEnabledProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveSelectionValidationProperties.ButtonIsEnabledProperty, value);
			}
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x00029B24 File Offset: 0x00027D24
		private static void IsEnabledCallBackOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BindingExpressionBase bindingExpressionBase = \u000D\u0006\u001D.\u000A(\u0005\u001D\u000E.\u001F(d), CanSaveSelectionValidationProperties.ButtonIsEnabledProperty);
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
			\u001C\u0006\u001D.\u000A(bindingExpressionBase);
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000721 RID: 1825 RVA: 0x00029B64 File Offset: 0x00027D64
		// (set) Token: 0x06000722 RID: 1826 RVA: 0x00029B88 File Offset: 0x00027D88
		public List<string> Items
		{
			get
			{
				return \u0018\u001D\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveSelectionValidationProperties.ItemsProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveSelectionValidationProperties.ItemsProperty, value);
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000723 RID: 1827 RVA: 0x00029BA4 File Offset: 0x00027DA4
		// (set) Token: 0x06000724 RID: 1828 RVA: 0x00029BC8 File Offset: 0x00027DC8
		public List<string> FilterItems
		{
			get
			{
				return \u0018\u001D\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, CanSaveSelectionValidationProperties.FilterItemsProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CanSaveSelectionValidationProperties.FilterItemsProperty, value);
			}
		}

		// Token: 0x040002D8 RID: 728
		public static readonly DependencyProperty ErrorTypeProperty = \u000F\u0006\u001D.\u000A("ErrorType", \u001E\u0011\u000A.\u000A(\u000B\u001D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0002\u001D\u000E.\u001F()), \u0012\u0006\u001D.\u000A(ErrorType.Error, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x040002D9 RID: 729
		public static readonly DependencyProperty ItemNameProperty = \u000F\u0006\u001D.\u000A("ItemName", \u001E\u0011\u000A.\u000A(\u001A\u0001\u0010.\u001F()), \u001E\u0011\u000A.\u000A(\u0002\u001D\u000E.\u001F()), \u0012\u0006\u001D.\u000A("Item", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x040002DA RID: 730
		public static readonly DependencyProperty ButtonContentProperty = \u000F\u0006\u001D.\u000A("ButtonContent", \u001E\u0011\u000A.\u000A(\u001A\u0001\u0010.\u001F()), \u001E\u0011\u000A.\u000A(\u0002\u001D\u000E.\u001F()), \u0003\u0006\u001D.\u000A(\u0015\u0002\u001D.\u000A(), new PropertyChangedCallback(CanSaveSelectionValidationProperties.CallBackOnChanged)));

		// Token: 0x040002DB RID: 731
		public static readonly DependencyProperty ButtonIsEnabledProperty = \u000F\u0006\u001D.\u000A("ButtonIsEnabled", \u001E\u0011\u000A.\u000A(\u0006\u001D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0002\u001D\u000E.\u001F()), \u0003\u0006\u001D.\u000A(false, new PropertyChangedCallback(CanSaveSelectionValidationProperties.IsEnabledCallBackOnChanged)));

		// Token: 0x040002DC RID: 732
		public static readonly DependencyProperty ItemsProperty = \u000F\u0006\u001D.\u000A("Items", \u001E\u0011\u000A.\u000A(\u000F\u001D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0002\u001D\u000E.\u001F()), \u0012\u0006\u001D.\u000A(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x040002DD RID: 733
		public static readonly DependencyProperty FilterItemsProperty = \u000F\u0006\u001D.\u000A("FilterItems", \u001E\u0011\u000A.\u000A(\u000F\u001D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0002\u001D\u000E.\u001F()), \u0012\u0006\u001D.\u000A(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
	}
}

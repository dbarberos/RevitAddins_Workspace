using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using A;
using ProSheets.Enums;
using ProSheets.UI.CommonData;

namespace ProSheets.CommonData
{
	// Token: 0x0200009C RID: 156
	public class CanSaveValidationProperties : DependencyObject
	{
		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x00039AE0 File Offset: 0x00037CE0
		// (set) Token: 0x06000953 RID: 2387 RVA: 0x00039B04 File Offset: 0x00037D04
		public ErrorType ErrorType
		{
			get
			{
				return \u0004\u0007\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, CanSaveValidationProperties.ErrorTypeProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, CanSaveValidationProperties.ErrorTypeProperty, value);
			}
		}

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x00039B24 File Offset: 0x00037D24
		// (set) Token: 0x06000955 RID: 2389 RVA: 0x00039B48 File Offset: 0x00037D48
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

		// Token: 0x06000956 RID: 2390 RVA: 0x00039B64 File Offset: 0x00037D64
		private static void CallBackOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BindingExpressionBase bindingExpressionBase = \u0006\u001A\u0018.\u0018(\u0002\u0007\u000F.\u000C(d), CanSaveValidationProperties.ButtonContentProperty);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveValidationProperties.CallBackOnChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			\u0010\u001A\u0018.\u0018(bindingExpressionBase);
		}

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000957 RID: 2391 RVA: 0x00039BA4 File Offset: 0x00037DA4
		// (set) Token: 0x06000958 RID: 2392 RVA: 0x00039BC8 File Offset: 0x00037DC8
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

		// Token: 0x06000959 RID: 2393 RVA: 0x00039BE8 File Offset: 0x00037DE8
		private static void IsEnabledCallBackOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BindingExpressionBase bindingExpressionBase = \u0006\u001A\u0018.\u0018(\u0002\u0007\u000F.\u000C(d), CanSaveValidationProperties.ButtonIsEnabledProperty);
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

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x0600095A RID: 2394 RVA: 0x00039C28 File Offset: 0x00037E28
		// (set) Token: 0x0600095B RID: 2395 RVA: 0x00039C4C File Offset: 0x00037E4C
		public ObservableCollection<ViewSheetSetInfo> Sets
		{
			get
			{
				return \u001E\u0007\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, CanSaveValidationProperties.SetsProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, CanSaveValidationProperties.SetsProperty, value);
			}
		}

		// Token: 0x04000461 RID: 1121
		public static readonly DependencyProperty ErrorTypeProperty = \u001D\u001A\u0018.\u0018("ErrorType", \u000A\u001D\u0018.\u0018(\u001D\u0007\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u001A\u0007\u000F.\u000C()), \u001A\u001A\u0018.\u0018(ErrorType.Error, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x04000462 RID: 1122
		public static readonly DependencyProperty ButtonContentProperty = \u001D\u001A\u0018.\u0018("ButtonContent", \u000A\u001D\u0018.\u0018(\u001A\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u001A\u0007\u000F.\u000C()), \u000B\u001A\u0018.\u0018("Save", new PropertyChangedCallback(CanSaveValidationProperties.CallBackOnChanged)));

		// Token: 0x04000463 RID: 1123
		public static readonly DependencyProperty ButtonIsEnabledProperty = \u001D\u001A\u0018.\u0018("ButtonIsEnabled", \u000A\u001D\u0018.\u0018(\u000B\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u001A\u0007\u000F.\u000C()), \u000B\u001A\u0018.\u0018(false, new PropertyChangedCallback(CanSaveValidationProperties.IsEnabledCallBackOnChanged)));

		// Token: 0x04000464 RID: 1124
		public static readonly DependencyProperty SetsProperty = \u001D\u001A\u0018.\u0018("Sets", \u000A\u001D\u0018.\u0018(\u000B\u0007\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u001A\u0007\u000F.\u000C()), \u001A\u001A\u0018.\u0018(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
	}
}

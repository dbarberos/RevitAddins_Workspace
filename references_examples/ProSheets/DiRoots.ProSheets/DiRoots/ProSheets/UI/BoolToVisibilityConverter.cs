using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x02000036 RID: 54
	public class BoolToVisibilityConverter : DependencyObject, IValueConverter
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000270 RID: 624 RVA: 0x0000DCB0 File Offset: 0x0000BEB0
		// (set) Token: 0x06000271 RID: 625 RVA: 0x0000DCD4 File Offset: 0x0000BED4
		public bool Inverse
		{
			get
			{
				return \u0017\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0014(this, BoolToVisibilityConverter.InverseProperty));
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, BoolToVisibilityConverter.InverseProperty, value);
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000DCF4 File Offset: 0x0000BEF4
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag = false;
			if (\u000C\u001D\u000F.\u000C(value) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BoolToVisibilityConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				bool flag2 = \u0017\u0002\u000F.\u000C(value);
				flag = flag2;
			}
			if (\u001E\u000F\u0014.\u0018(this))
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
				flag = !flag;
			}
			if (flag)
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
				return Visibility.Visible;
			}
			return Visibility.Collapsed;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000DD60 File Offset: 0x0000BF60
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return parameter;
		}

		// Token: 0x04000112 RID: 274
		public static readonly DependencyProperty InverseProperty = \u0017\u000F\u0014.\u0018("Inverse", \u000A\u001D\u0018.\u0018(\u000B\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0009\u001D\u000F.\u000C()));
	}
}

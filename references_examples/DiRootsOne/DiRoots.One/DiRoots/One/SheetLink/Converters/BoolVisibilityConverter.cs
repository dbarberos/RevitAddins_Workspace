using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.One.SheetLink.Converters
{
	// Token: 0x02000208 RID: 520
	public class BoolVisibilityConverter : IValueConverter
	{
		// Token: 0x06001357 RID: 4951 RVA: 0x0007B708 File Offset: 0x00079908
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (\u0009\u0015\u0010.\u001F(value) == null)
			{
				return Visibility.Collapsed;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(BoolVisibilityConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
			}
			bool flag = \u001F\u0001\u0010.\u001F(value);
			if (flag)
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
				return Visibility.Visible;
			}
			return Visibility.Collapsed;
		}

		// Token: 0x06001358 RID: 4952 RVA: 0x0007B75C File Offset: 0x0007995C
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
	}
}

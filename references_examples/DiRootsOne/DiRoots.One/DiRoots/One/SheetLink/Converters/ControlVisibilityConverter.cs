using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.One.SheetLink.Converters
{
	// Token: 0x02000209 RID: 521
	public class ControlVisibilityConverter : IValueConverter
	{
		// Token: 0x0600135A RID: 4954 RVA: 0x0007B780 File Offset: 0x00079980
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (\u001D\u0001\u0010.\u001F(value) == null)
			{
				return Visibility.Visible;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(ControlVisibilityConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
			}
			int num = \u0005\u0005\u000E.\u001F(value);
			if (parameter == null)
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
				if (num != 5)
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
					return Visibility.Visible;
				}
				return Visibility.Collapsed;
			}
			else
			{
				if (num == 5)
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
					return Visibility.Visible;
				}
				return Visibility.Collapsed;
			}
		}

		// Token: 0x0600135B RID: 4955 RVA: 0x0007B800 File Offset: 0x00079A00
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
	}
}

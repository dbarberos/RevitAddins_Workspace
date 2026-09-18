using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.One.SheetGen.ViewRange.UI.Converter
{
	// Token: 0x020002DB RID: 731
	public class IntToVisibilityConverter : IValueConverter
	{
		// Token: 0x06001E39 RID: 7737 RVA: 0x000BEFB8 File Offset: 0x000BD1B8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (\u001D\u0001\u0010.\u001F(value) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IntToVisibilityConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				int num = \u0005\u0005\u000E.\u001F(value);
				if (num != 2)
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
					if (num != 3)
					{
						return Visibility.Visible;
					}
					for (;;)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				return Visibility.Hidden;
			}
			return DependencyProperty.UnsetValue;
		}

		// Token: 0x06001E3A RID: 7738 RVA: 0x000BF01C File Offset: 0x000BD21C
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw \u000C\u000C\u000A.\u000A();
		}
	}
}

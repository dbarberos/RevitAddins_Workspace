using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.One.TableGen.UI.Converters
{
	// Token: 0x02000162 RID: 354
	[ValueConversion(typeof(bool), typeof(GridLength))]
	public class BoolToGridRowHeightConverter : IValueConverter
	{
		// Token: 0x06000D53 RID: 3411 RVA: 0x000562BC File Offset: 0x000544BC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag;
			bool flag2;
			if (\u0009\u0015\u0010.\u001F(value) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BoolToGridRowHeightConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				flag = \u001F\u0001\u0010.\u001F(value);
				flag2 = true;
			}
			else
			{
				flag2 = false;
			}
			GridLength gridLength;
			if (!flag2 || !flag)
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
				gridLength = new GridLength(0.0);
			}
			else
			{
				gridLength = new GridLength(1.0, GridUnitType.Star);
			}
			return gridLength;
		}

		// Token: 0x06000D54 RID: 3412 RVA: 0x00056328 File Offset: 0x00054528
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}

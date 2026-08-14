using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using A;

namespace SelectionsManager.UI.Converters
{
	// Token: 0x02000032 RID: 50
	public class MultiMarginConverter : IMultiValueConverter
	{
		// Token: 0x060001A3 RID: 419 RVA: 0x00008E24 File Offset: 0x00007024
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return new Thickness(\u0015\u000C\u000A.\u000A(values[0]), \u0015\u000C\u000A.\u000A(values[1]), \u0015\u000C\u000A.\u000A(values[2]), \u0015\u000C\u000A.\u000A(values[3]));
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00008E64 File Offset: 0x00007064
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}

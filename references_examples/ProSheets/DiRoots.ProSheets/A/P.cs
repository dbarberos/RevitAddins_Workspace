using System;
using System.Globalization;
using System.Windows.Data;

namespace A
{
	// Token: 0x02000096 RID: 150
	internal class P : IValueConverter
	{
		// Token: 0x06000932 RID: 2354 RVA: 0x00039500 File Offset: 0x00037700
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (\u0011\u0004\u000F.\u000C(value) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(P.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				double num = \u0015\u0004\u000F.\u000C(value);
				return num - 150.0;
			}
			return 150;
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x00039550 File Offset: 0x00037750
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

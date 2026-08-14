using System;
using System.Globalization;
using System.Windows.Data;
using A;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x0200003C RID: 60
	public sealed class InverseBoolConverter : IValueConverter
	{
		// Token: 0x06000284 RID: 644 RVA: 0x0000E2B0 File Offset: 0x0000C4B0
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(InverseBoolConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				return false;
			}
			return !\u0017\u0002\u000F.\u000C(value);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

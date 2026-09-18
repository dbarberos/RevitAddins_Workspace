using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x02000035 RID: 53
	public class BooleanAndConverter : IMultiValueConverter
	{
		// Token: 0x0600026C RID: 620 RVA: 0x0000DC04 File Offset: 0x0000BE04
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			Func<object, bool> func;
			if ((func = BooleanAndConverter.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BooleanAndConverter.Convert(object[], Type, object, CultureInfo)).MethodHandle;
				}
				func = (BooleanAndConverter.<>c.\u0018 = new Func<object, bool>(BooleanAndConverter.<>c.\u000C.\u0014));
			}
			return Enumerable.All<object>(values, func);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000DC50 File Offset: 0x0000BE50
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}

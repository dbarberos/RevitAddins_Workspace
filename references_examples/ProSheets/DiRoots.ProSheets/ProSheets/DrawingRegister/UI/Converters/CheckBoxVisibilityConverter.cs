using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using A;

namespace ProSheets.DrawingRegister.UI.Converters
{
	// Token: 0x02000113 RID: 275
	public class CheckBoxVisibilityConverter : IMultiValueConverter
	{
		// Token: 0x06000E28 RID: 3624 RVA: 0x000531EC File Offset: 0x000513EC
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag = false;
			bool flag2 = false;
			object u000C = values[0];
			if (\u000C\u001D\u000F.\u000C(u000C) != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(CheckBoxVisibilityConverter.Convert(object[], Type, object, CultureInfo)).MethodHandle;
				}
				bool flag3 = \u0017\u0002\u000F.\u000C(u000C);
				flag = flag3;
			}
			u000C = values[1];
			if (\u000C\u001D\u000F.\u000C(u000C) != null)
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
				bool flag4 = \u0017\u0002\u000F.\u000C(u000C);
				flag2 = flag4;
			}
			Visibility visibility;
			if (!flag && !flag2)
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
				visibility = Visibility.Collapsed;
			}
			else
			{
				visibility = Visibility.Visible;
			}
			return visibility;
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x0005326C File Offset: 0x0005146C
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw \u0020\u0006\u0018.\u0018();
		}
	}
}

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.One.SheetLink.Converters
{
	// Token: 0x0200020A RID: 522
	public class ProfileVisibilityConverter : IValueConverter
	{
		// Token: 0x0600135D RID: 4957 RVA: 0x0007B824 File Offset: 0x00079A24
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (\u001D\u0001\u0010.\u001F(value) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProfileVisibilityConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				int num = \u0005\u0005\u000E.\u001F(value);
				int num2 = -1;
				if (parameter != null)
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
					\u001C\u0015\u0004.\u000A(\u001A\u000C\u000A.\u000A(parameter), ref num2);
				}
				if (num != num2)
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
					return Visibility.Hidden;
				}
			}
			return Visibility.Visible;
		}

		// Token: 0x0600135E RID: 4958 RVA: 0x0007B894 File Offset: 0x00079A94
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return parameter;
		}
	}
}

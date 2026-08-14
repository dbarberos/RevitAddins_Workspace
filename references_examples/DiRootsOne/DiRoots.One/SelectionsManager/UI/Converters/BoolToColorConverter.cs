using System;
using System.Globalization;
using System.Windows.Data;
using A;

namespace SelectionsManager.UI.Converters
{
	// Token: 0x0200002F RID: 47
	public class BoolToColorConverter : IValueConverter
	{
		// Token: 0x0600019A RID: 410 RVA: 0x00008C0C File Offset: 0x00006E0C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag = false;
			if (\u0009\u0015\u0010.\u001F(value) != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(BoolToColorConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				bool flag2 = \u001F\u0001\u0010.\u001F(value);
				flag = flag2;
			}
			if (!flag)
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
				return \u0017\u000C\u000A.\u000A();
			}
			return \u001E\u000C\u000A.\u000A(\u000A\u0001\u0010.\u001F(\u0020\u000C\u000A.\u000A("#FDF2B9")));
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00008C74 File Offset: 0x00006E74
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

using System;
using System.Globalization;
using System.Windows.Data;
using A;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x0200003B RID: 59
	public class IntToBoolConverter : IValueConverter
	{
		// Token: 0x06000281 RID: 641 RVA: 0x0000E1FC File Offset: 0x0000C3FC
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int num = \u0001\u000F\u0014.\u0018(parameter);
			if (\u0017\u0004\u000F.\u000C(value) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IntToBoolConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				int num2 = \u001F\u001D\u000F.\u000C(value);
				int num3 = num;
				if (num2 == num3)
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
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000E258 File Offset: 0x0000C458
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IntToBoolConverter.ConvertBack(object, Type, object, CultureInfo)).MethodHandle;
				}
				if (\u001B\u000F\u0014.\u0018(value, true))
				{
					return parameter;
				}
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return Binding.DoNothing;
		}
	}
}

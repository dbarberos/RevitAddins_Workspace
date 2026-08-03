using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using A;

namespace SelectionsManager.UI.Converters
{
	// Token: 0x02000031 RID: 49
	public class IsLessThanToVisibilityConverter : IValueConverter
	{
		// Token: 0x060001A0 RID: 416 RVA: 0x00008D58 File Offset: 0x00006F58
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IsLessThanToVisibilityConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				if (parameter == null)
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
				}
				else
				{
					double num;
					if (!\u0013\u000C\u000A.\u000A(\u001A\u000C\u000A.\u000A(value), ref num))
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
						throw \u0014\u000C\u000A.\u000A("The value could not be converted to an integer");
					}
					double num2;
					if (!\u0013\u000C\u000A.\u000A(\u001A\u000C\u000A.\u000A(parameter), ref num2))
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
						throw \u0014\u000C\u000A.\u000A("The parameter could not be converted to an integer");
					}
					Visibility visibility;
					if (num >= num2)
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
						visibility = Visibility.Visible;
					}
					else
					{
						visibility = Visibility.Collapsed;
					}
					return visibility;
				}
			}
			return false;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00008DFC File Offset: 0x00006FFC
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw \u000C\u000C\u000A.\u000A();
		}
	}
}

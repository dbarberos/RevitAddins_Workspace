using System;
using System.Globalization;
using System.Windows.Data;
using A;

namespace SelectionsManager.UI.Converters
{
	// Token: 0x02000030 RID: 48
	public class IsLessThanConverter : IValueConverter
	{
		// Token: 0x0600019D RID: 413 RVA: 0x00008C9C File Offset: 0x00006E9C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IsLessThanConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				if (parameter == null)
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
				}
				else
				{
					double num;
					if (!\u0013\u000C\u000A.\u000A(\u001A\u000C\u000A.\u000A(value), ref num))
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
					return num < num2;
				}
			}
			return false;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00008D30 File Offset: 0x00006F30
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw \u000C\u000C\u000A.\u000A();
		}
	}
}

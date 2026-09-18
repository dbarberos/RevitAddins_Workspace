using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using A;

namespace SelectionsManager.UI.Converters
{
	// Token: 0x02000033 RID: 51
	public class MultiplyConverter : IMultiValueConverter
	{
		// Token: 0x060001A6 RID: 422 RVA: 0x00008E88 File Offset: 0x00007088
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			double num = 1.0;
			int i = 0;
			while (i < (int)\u0018\u0001\u0010.\u001F(values))
			{
				if (\u0007\u0001\u0010.\u001F(values[i]) != null)
				{
					goto IL_43;
				}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MultiplyConverter.Convert(object[], Type, object, CultureInfo)).MethodHandle;
				}
				if (\u001D\u0001\u0010.\u001F(values[i]) != null)
				{
					for (;;)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						goto IL_43;
					}
				}
				else
				{
					ItemCollection itemCollection = \u0019\u0001\u0010.\u001F(values[i]);
					if (itemCollection != null)
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
						num *= (double)(\u0001\u000C\u000A.\u000A(itemCollection) + 1);
					}
				}
				IL_78:
				i++;
				continue;
				IL_43:
				num *= \u0004\u0001\u0010.\u001F(values[i]);
				goto IL_78;
			}
			for (;;)
			{
				switch (4)
				{
				case 0:
					continue;
				}
				break;
			}
			return num;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00008F30 File Offset: 0x00007130
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw \u000C\u000C\u000A.\u000A();
		}
	}
}

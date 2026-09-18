using System;
using System.Globalization;
using System.Windows.Data;
using A;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x02000037 RID: 55
	public class BorderColorConverter : IValueConverter
	{
		// Token: 0x06000275 RID: 629 RVA: 0x0000DD84 File Offset: 0x0000BF84
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				Type type = \u000A\u001D\u000F.\u000C(parameter);
				if (type != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(BorderColorConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
					}
					Type u000C;
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
						u000C = null;
					}
					else
					{
						u000C = \u0004\u0017\u0018.\u0003(value);
					}
					if (\u001A\u000F\u0014.\u0018(u000C, type))
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
						return \u0020\u001D\u000F.\u000C(\u0004\u000F\u0014.\u0018(\u001D\u000F\u0014.\u0018(), "#E6AE46"));
					}
				}
			}
			catch (Exception)
			{
			}
			return \u0002\u000F\u0014.\u0018();
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000DE18 File Offset: 0x0000C018
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw \u0020\u0006\u0018.\u0018();
		}
	}
}

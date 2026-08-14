using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using A;

namespace SelectionsManager.UI.Converters
{
	// Token: 0x02000034 RID: 52
	public class PercentageConverter : MarkupExtension, IValueConverter
	{
		// Token: 0x060001A9 RID: 425 RVA: 0x00008F58 File Offset: 0x00007158
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return \u0009\u000C\u000A.\u000A(value, \u001F\u0015\u000A.\u000A()) * \u0009\u000C\u000A.\u000A(parameter, \u001F\u0015\u000A.\u000A());
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00008F8C File Offset: 0x0000718C
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw \u000C\u000C\u000A.\u000A();
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00008FA0 File Offset: 0x000071A0
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			PercentageConverter result;
			if ((result = PercentageConverter._instance) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(PercentageConverter.ProvideValue(IServiceProvider)).MethodHandle;
				}
				result = (PercentageConverter._instance = \u000A\u0015\u000A.\u000A());
			}
			return result;
		}

		// Token: 0x040000A9 RID: 169
		private static PercentageConverter _instance;
	}
}

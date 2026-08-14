using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.One.SheetGen.UI.Converters
{
	// Token: 0x020003B5 RID: 949
	public class SelectionParameterTypeToFontWeightConverter : IValueConverter
	{
		// Token: 0x060025E5 RID: 9701 RVA: 0x000E443C File Offset: 0x000E263C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			FontWeight fontWeight;
			if (\u0009\u0008\u000E.\u001F(value) == SelectionParameterType.ProjectInformation)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParameterTypeToFontWeightConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				fontWeight = \u0020\u0007\u0002.\u000A();
			}
			else
			{
				fontWeight = \u001E\u0007\u0002.\u000A();
			}
			return fontWeight;
		}

		// Token: 0x060025E6 RID: 9702 RVA: 0x000E4480 File Offset: 0x000E2680
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

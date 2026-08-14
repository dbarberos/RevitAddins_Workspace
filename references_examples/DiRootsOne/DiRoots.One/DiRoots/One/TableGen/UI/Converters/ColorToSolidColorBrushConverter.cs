using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using A;
using DiRoots.One.ReOrdering.UI.Base;

namespace DiRoots.One.TableGen.UI.Converters
{
	// Token: 0x02000163 RID: 355
	public class ColorToSolidColorBrushConverter : BaseValueConverter<ColorToSolidColorBrushConverter>
	{
		// Token: 0x06000D56 RID: 3414 RVA: 0x0005634C File Offset: 0x0005454C
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ColorToSolidColorBrushConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				return null;
			}
			if (\u0018\u0005\u000E.\u001F(value) != null)
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
				Color u001F = \u000A\u0001\u0010.\u001F(value);
				return \u001E\u000C\u000A.\u000A(u001F);
			}
			Type u001F2 = \u0003\u0011\u000A.\u0007(value);
			throw \u0014\u000C\u000A.\u000A(\u0002\u0013\u000A.\u000A("Unsupported type [", \u000A\u0010\u001D.\u000A(u001F2), "]"));
		}

		// Token: 0x06000D57 RID: 3415 RVA: 0x000563C0 File Offset: 0x000545C0
		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

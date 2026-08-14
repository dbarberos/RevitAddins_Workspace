using System;
using System.Globalization;
using System.Windows.Data;
using A;

namespace DiRoots.One.SheetGen.UI.Converters
{
	// Token: 0x020003BB RID: 955
	public sealed class TextToBoolConverter : IValueConverter
	{
		// Token: 0x060025F7 RID: 9719 RVA: 0x000E481C File Offset: 0x000E2A1C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string u001F;
			if (value == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(TextToBoolConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				u001F = \u000F\u0015\u0010.\u001F;
			}
			else
			{
				u001F = \u001A\u000C\u000A.\u000A(value);
			}
			return !\u001A\u0006\u0007.\u000A(u001F);
		}

		// Token: 0x060025F8 RID: 9720 RVA: 0x000E4860 File Offset: 0x000E2A60
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

using System;
using System.Globalization;
using System.Windows.Data;
using A;

namespace DiRoots.One.SheetGen.UI.Converters
{
	// Token: 0x020003BA RID: 954
	public class StatusToTooltipTextConverter : IValueConverter
	{
		// Token: 0x060025F4 RID: 9716 RVA: 0x000E4790 File Offset: 0x000E2990
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (\u001F\u001B\u000E.\u001F(value) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StatusToTooltipTextConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				UpdateStates updateStates = \u000A\u001B\u000E.\u001F(value);
				if (updateStates == UpdateStates.Modified)
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
					return \u001F\u001D\u0002.\u000A();
				}
				if (updateStates == UpdateStates.Updated)
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
					return \u0009\u0007\u0002.\u000A();
				}
			}
			return "";
		}

		// Token: 0x060025F5 RID: 9717 RVA: 0x000E47F4 File Offset: 0x000E29F4
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

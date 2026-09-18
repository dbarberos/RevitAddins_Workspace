using System;
using System.Globalization;
using System.Windows.Data;
using A;

namespace DiRoots.One.TableGen.UI.Converters
{
	// Token: 0x02000164 RID: 356
	public class LengthConverter : IValueConverter
	{
		// Token: 0x06000D59 RID: 3417 RVA: 0x000563E8 File Offset: 0x000545E8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (\u0007\u0001\u0010.\u001F(value) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(LengthConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				double u001F = \u0004\u0001\u0010.\u001F(value);
				return \u0011\u0018.\u000A(u001F);
			}
			return "";
		}

		// Token: 0x06000D5A RID: 3418 RVA: 0x0005642C File Offset: 0x0005462C
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string text = \u0007\u001F\u000E.\u001F(value);
			if (text == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(LengthConverter.ConvertBack(object, Type, object, CultureInfo)).MethodHandle;
				}
				return null;
			}
			double num;
			if (\u0011\u0018.\u0004(text, out num))
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
				return num;
			}
			return Binding.DoNothing;
		}
	}
}

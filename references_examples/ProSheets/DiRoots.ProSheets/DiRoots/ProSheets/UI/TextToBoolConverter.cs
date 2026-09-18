using System;
using System.Globalization;
using System.Windows.Data;
using A;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x0200003D RID: 61
	public sealed class TextToBoolConverter : IValueConverter
	{
		// Token: 0x06000287 RID: 647 RVA: 0x0000E314 File Offset: 0x0000C514
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TextToBoolConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				if (\u000F\u0002\u0018.\u0018(\u001E\u0002\u000F.\u000C(value), ""))
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
				}
				else
				{
					string text = \u001E\u0002\u000F.\u000C(value);
					bool flag;
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
						flag = false;
					}
					else
					{
						flag = (\u001C\u0002\u0018.\u0003(text) == 0);
					}
					if (flag)
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
						return false;
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000E39C File Offset: 0x0000C59C
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

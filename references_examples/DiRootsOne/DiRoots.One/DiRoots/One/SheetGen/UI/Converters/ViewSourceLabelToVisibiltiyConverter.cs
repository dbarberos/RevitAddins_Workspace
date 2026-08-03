using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.One.SheetGen.UI.Converters
{
	// Token: 0x020003BC RID: 956
	public sealed class ViewSourceLabelToVisibiltiyConverter : IValueConverter
	{
		// Token: 0x060025FA RID: 9722 RVA: 0x000E4888 File Offset: 0x000E2A88
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSourceLabelToVisibiltiyConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				if (!\u0008\u0013\u000A.\u000A(\u0013\u0001\u0010.\u001F(value), ""))
				{
					if (!\u0008\u0013\u000A.\u000A(\u0013\u0001\u0010.\u001F(value), "View Parameters"))
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
						if (!\u0008\u0013\u000A.\u000A(\u0013\u0001\u0010.\u001F(value), \u0020\u0009\u0016.\u000A()))
						{
							return Visibility.Collapsed;
						}
						for (;;)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					return Visibility.Visible;
				}
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return Visibility.Collapsed;
		}

		// Token: 0x060025FB RID: 9723 RVA: 0x000E4924 File Offset: 0x000E2B24
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.One.SheetGen.UI.Converters
{
	// Token: 0x020003B7 RID: 951
	public sealed class SourceLabelToVisibiltiyConverter : IValueConverter
	{
		// Token: 0x060025EB RID: 9707 RVA: 0x000E4568 File Offset: 0x000E2768
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SourceLabelToVisibiltiyConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				if (!\u0008\u0013\u000A.\u000A(\u0013\u0001\u0010.\u001F(value), ""))
				{
					if (!\u0008\u0013\u000A.\u000A(\u0013\u0001\u0010.\u001F(value), "Sheet Parameters"))
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
						if (!\u0008\u0013\u000A.\u000A(\u0013\u0001\u0010.\u001F(value), \u001F\u0014\u0016.\u000A()))
						{
							return Visibility.Collapsed;
						}
						for (;;)
						{
							switch (6)
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
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return Visibility.Collapsed;
		}

		// Token: 0x060025EC RID: 9708 RVA: 0x000E4604 File Offset: 0x000E2804
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

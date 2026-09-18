using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.One.SheetGen.UI.Converters
{
	// Token: 0x020003B4 RID: 948
	public class SelectionParameterTypeToFontStyleConverter : IValueConverter
	{
		// Token: 0x060025E2 RID: 9698 RVA: 0x000E4374 File Offset: 0x000E2574
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (\u0001\u0008\u000E.\u001F(value) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParameterTypeToFontStyleConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				SelectionParameterType selectionParameterType = \u0009\u0008\u000E.\u001F(value);
				FontStyle fontStyle;
				if (selectionParameterType != SelectionParameterType.DummyField)
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
					if (selectionParameterType != SelectionParameterType.Name)
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
						if (selectionParameterType != SelectionParameterType.Number)
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
							if (selectionParameterType != SelectionParameterType.Counter)
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
								if (selectionParameterType != SelectionParameterType.DummySeparator)
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
									fontStyle = \u001B\u0007\u0002.\u000A();
									goto IL_81;
								}
							}
						}
					}
				}
				fontStyle = \u0011\u0007\u0002.\u000A();
				IL_81:
				return fontStyle;
			}
			return \u001B\u0007\u0002.\u000A();
		}

		// Token: 0x060025E3 RID: 9699 RVA: 0x000E4414 File Offset: 0x000E2614
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

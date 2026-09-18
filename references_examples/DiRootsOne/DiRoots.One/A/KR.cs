using System;
using System.Globalization;
using System.Windows.Data;
using DiRoots.One.SheetGen;

namespace A
{
	// Token: 0x020003B8 RID: 952
	internal class KR : IValueConverter
	{
		// Token: 0x060025EE RID: 9710 RVA: 0x000E462C File Offset: 0x000E282C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (\u001F\u001B\u000E.\u001F(value) != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(KR.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				string result;
				switch (\u000A\u001B\u000E.\u001F(value))
				{
				case UpdateStates.Updated:
					result = "#9FDC7F";
					break;
				case UpdateStates.Modified:
				case UpdateStates.NameModified:
				case UpdateStates.NumberModified:
					result = "#FFECD861";
					break;
				case UpdateStates.ToTrash:
					result = "#FFDCD7D7";
					break;
				case UpdateStates.ToAdd:
				case UpdateStates.ToDuplicate:
					result = "#FFFFD6D6";
					break;
				default:
					result = string.Empty;
					break;
				}
				return result;
			}
			return string.Empty;
		}

		// Token: 0x060025EF RID: 9711 RVA: 0x000E46B4 File Offset: 0x000E28B4
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

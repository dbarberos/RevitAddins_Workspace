using System;
using System.Globalization;
using System.Windows.Data;
using DiRoots.One.SheetGen;

namespace A
{
	// Token: 0x020003B6 RID: 950
	internal class WR : IValueConverter
	{
		// Token: 0x060025E8 RID: 9704 RVA: 0x000E44A8 File Offset: 0x000E26A8
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (\u001F\u001B\u000E.\u001F(value) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WR.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				string result;
				switch (\u000A\u001B\u000E.\u001F(value))
				{
				case UpdateStates.Updated:
					result = \u0017\u0007\u0002.\u000A();
					break;
				case UpdateStates.Modified:
				case UpdateStates.NameModified:
				case UpdateStates.NumberModified:
					result = \u000C\u0007\u0002.\u000A();
					break;
				case UpdateStates.ToTrash:
					result = \u0014\u0007\u0002.\u000A();
					break;
				case UpdateStates.ToAdd:
					result = \u001A\u0007\u0002.\u000A();
					break;
				case UpdateStates.ToDuplicate:
					result = \u0013\u0007\u0002.\u000A();
					break;
				default:
					result = string.Empty;
					break;
				}
				return result;
			}
			return string.Empty;
		}

		// Token: 0x060025E9 RID: 9705 RVA: 0x000E4540 File Offset: 0x000E2740
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

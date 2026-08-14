using System;
using System.Globalization;
using System.Windows.Data;
using DiRoots.One.SheetGen;

namespace A
{
	// Token: 0x020003BD RID: 957
	internal class JR : IValueConverter
	{
		// Token: 0x060025FD RID: 9725 RVA: 0x000E494C File Offset: 0x000E2B4C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (\u001F\u001B\u000E.\u001F(value) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(JR.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				string result;
				switch (\u000A\u001B\u000E.\u001F(value))
				{
				case UpdateStates.Updated:
					result = \u000A\u001D\u0002.\u000A();
					break;
				case UpdateStates.Modified:
				case UpdateStates.NameModified:
					result = \u0019\u001D\u0002.\u000A();
					break;
				case UpdateStates.ToTrash:
					result = \u0007\u001D\u0002.\u000A();
					break;
				case UpdateStates.ToAdd:
					result = \u0004\u001D\u0002.\u000A();
					break;
				case UpdateStates.ToDuplicate:
					result = \u001D\u001D\u0002.\u000A();
					break;
				default:
					result = string.Empty;
					break;
				}
				return result;
			}
			return string.Empty;
		}

		// Token: 0x060025FE RID: 9726 RVA: 0x000E49E0 File Offset: 0x000E2BE0
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

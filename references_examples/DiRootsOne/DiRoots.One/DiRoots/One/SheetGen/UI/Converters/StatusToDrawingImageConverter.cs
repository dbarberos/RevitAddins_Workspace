using System;
using System.Globalization;
using System.Windows.Data;
using A;

namespace DiRoots.One.SheetGen.UI.Converters
{
	// Token: 0x020003B9 RID: 953
	public class StatusToDrawingImageConverter : IValueConverter
	{
		// Token: 0x060025F1 RID: 9713 RVA: 0x000E46DC File Offset: 0x000E28DC
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StatusToDrawingImageConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				UpdateStates updateStates = \u000A\u001B\u000E.\u001F(value);
				if (updateStates == UpdateStates.Updated)
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
					return \u0015\u0007\u0002.\u000A(\u0001\u0007\u0002.\u000A(), "ProjectInfoParameterImage");
				}
				if (updateStates == UpdateStates.Modified)
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
					return \u0015\u0007\u0002.\u000A(\u0001\u0007\u0002.\u000A(), "ModProjectInfoParameterImage");
				}
			}
			return \u0015\u0007\u0002.\u000A(\u0001\u0007\u0002.\u000A(), "ProjectInfoParameterImage");
		}

		// Token: 0x060025F2 RID: 9714 RVA: 0x000E4768 File Offset: 0x000E2968
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

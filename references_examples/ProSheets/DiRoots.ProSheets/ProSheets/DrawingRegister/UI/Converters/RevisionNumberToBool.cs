using System;
using System.Globalization;
using System.Windows.Data;
using A;
using Autodesk.Revit.DB;

namespace ProSheets.DrawingRegister.UI.Converters
{
	// Token: 0x02000114 RID: 276
	public class RevisionNumberToBool : IValueConverter
	{
		// Token: 0x06000E2B RID: 3627 RVA: 0x00053294 File Offset: 0x00051494
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag = false;
			if (\u001B\u0006\u000F.\u000C(value) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionNumberToBool.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				RevisionNumbering revisionNumbering = \u0005\u0006\u000F.\u000C(value);
				if (revisionNumbering != null)
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
					if (revisionNumbering != 1)
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
						flag = false;
					}
				}
				else
				{
					flag = true;
				}
			}
			return flag;
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x000532F4 File Offset: 0x000514F4
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}

using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using A;

namespace DiRoots.ProfileControl.Converter
{
	// Token: 0x0200001C RID: 28
	public class SubtractConverter : IMultiValueConverter
	{
		// Token: 0x06000106 RID: 262 RVA: 0x00006F8C File Offset: 0x0000518C
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			double num = 0.0;
			object u000C = Enumerable.FirstOrDefault<object>(values);
			if (\u0011\u0004\u000F.\u000C(u000C) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SubtractConverter.Convert(object[], Type, object, CultureInfo)).MethodHandle;
				}
				double num2 = \u0015\u0004\u000F.\u000C(u000C);
				num = num2;
			}
			int i = 1;
			while (i < (int)\u001E\u0004\u000F.\u000C(values))
			{
				if (\u0011\u0004\u000F.\u000C(values[i]) != null)
				{
					goto IL_6B;
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
				if (\u0017\u0004\u000F.\u000C(values[i]) != null)
				{
					for (;;)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						goto IL_6B;
					}
				}
				IL_78:
				i++;
				continue;
				IL_6B:
				num -= \u0015\u0004\u000F.\u000C(values[i]);
				goto IL_78;
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
			return num;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00007034 File Offset: 0x00005234
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw \u0020\u0006\u0018.\u0018();
		}
	}
}

using System;
using System.Globalization;
using System.Windows.Data;
using A;

namespace DiRoots.ProSheets.Xml.Converters
{
	// Token: 0x02000027 RID: 39
	public class EnumToBooleanConverter : IValueConverter
	{
		// Token: 0x0600016B RID: 363 RVA: 0x0000921C File Offset: 0x0000741C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(EnumToBooleanConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				if (parameter != null)
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
					if (\u0013\u001B\u0018.\u0018(\u0004\u0017\u0018.\u0014(value)))
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
						if (\u0013\u001B\u0018.\u0018(\u0004\u0017\u0018.\u0014(parameter)))
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
							return \u001C\u001B\u0018.\u0018(value, parameter);
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00009298 File Offset: 0x00007498
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag;
			bool flag2;
			if (\u000C\u001D\u000F.\u000C(value) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(EnumToBooleanConverter.ConvertBack(object, Type, object, CultureInfo)).MethodHandle;
				}
				flag = \u0017\u0002\u000F.\u000C(value);
				flag2 = true;
			}
			else
			{
				flag2 = false;
			}
			if (flag2 && flag)
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
				if (parameter != null)
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
					if (\u0013\u001B\u0018.\u0018(targetType))
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
						return parameter;
					}
				}
			}
			return Binding.DoNothing;
		}
	}
}

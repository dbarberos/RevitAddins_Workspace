using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using A;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x02000039 RID: 57
	public class ControlVisibilityConverter : IValueConverter
	{
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000278 RID: 632 RVA: 0x0000DE40 File Offset: 0x0000C040
		// (set) Token: 0x06000279 RID: 633 RVA: 0x0000DE54 File Offset: 0x0000C054
		public ConditionTypes ConditionType { get; set; }

		// Token: 0x0600027A RID: 634 RVA: 0x0000DE68 File Offset: 0x0000C068
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (\u0017\u0004\u000F.\u000C(value) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ControlVisibilityConverter.Convert(object, Type, object, CultureInfo)).MethodHandle;
				}
				int num = \u001F\u001D\u000F.\u000C(value);
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
					int num2;
					if (\u0019\u000F\u0014.\u0018(\u0001\u0017\u0018.\u0018(parameter), ref num2))
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
						if (\u000B\u000F\u0014.\u0018(this) == ConditionTypes.NotEqual)
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
							if (num != num2)
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
								return Visibility.Visible;
							}
							return Visibility.Collapsed;
						}
						else
						{
							if (num == num2)
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
								return Visibility.Visible;
							}
							return Visibility.Collapsed;
						}
					}
				}
			}
			return Visibility.Visible;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000DF20 File Offset: 0x0000C120
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}

		// Token: 0x04000116 RID: 278
		[CompilerGenerated]
		private ConditionTypes P;
	}
}

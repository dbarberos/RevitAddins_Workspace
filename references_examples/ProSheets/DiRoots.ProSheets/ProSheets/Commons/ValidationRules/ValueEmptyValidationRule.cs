using System;
using System.Globalization;
using System.Windows.Controls;
using A;

namespace ProSheets.Commons.ValidationRules
{
	// Token: 0x02000138 RID: 312
	public class ValueEmptyValidationRule : ValidationRule
	{
		// Token: 0x06000FA2 RID: 4002 RVA: 0x000587DC File Offset: 0x000569DC
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			object u000C = value;
			if (value == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ValueEmptyValidationRule.Validate(object, CultureInfo)).MethodHandle;
				}
				u000C = "";
			}
			if (\u001F\u001A\u0018.\u0018(\u000F\u0009\u0014.\u0018(u000C)))
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
				return \u0012\u001A\u0018.\u0018(false, \u000D\u0009\u0018.\u0012\u0003);
			}
			return \u0012\u001A\u0018.\u0018(true, \u001F\u0002\u000F.\u000C);
		}
	}
}

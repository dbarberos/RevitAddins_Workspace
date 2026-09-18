using System;
using System.Globalization;
using System.Windows.Controls;
using A;

namespace ProSheets.DrawingRegister.UI.ValidationRules
{
	// Token: 0x02000112 RID: 274
	public class ValueEmptyOrZeroValidationRule : ValidationRule
	{
		// Token: 0x06000E26 RID: 3622 RVA: 0x00053170 File Offset: 0x00051370
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			object u000C = value;
			if (value == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ValueEmptyOrZeroValidationRule.Validate(object, CultureInfo)).MethodHandle;
				}
				u000C = "";
			}
			int num;
			\u0019\u000F\u0014.\u0018(\u000F\u0009\u0014.\u0018(u000C), ref num);
			if (num <= 0)
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
				return \u0012\u001A\u0018.\u0018(false, \u000D\u0009\u0018.\u001D\u0014);
			}
			return \u0012\u001A\u0018.\u0018(true, \u001F\u0002\u000F.\u000C);
		}
	}
}

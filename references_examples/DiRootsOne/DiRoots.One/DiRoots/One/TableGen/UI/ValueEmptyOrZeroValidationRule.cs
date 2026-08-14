using System;
using System.Globalization;
using System.Windows.Controls;
using A;

namespace DiRoots.One.TableGen.UI
{
	// Token: 0x02000157 RID: 343
	public class ValueEmptyOrZeroValidationRule : ValidationRule
	{
		// Token: 0x06000CCD RID: 3277 RVA: 0x00050A54 File Offset: 0x0004EC54
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			object u001F = value;
			if (value == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ValueEmptyOrZeroValidationRule.Validate(object, CultureInfo)).MethodHandle;
				}
				u001F = "";
			}
			int num;
			\u001C\u0015\u0004.\u000A(\u0009\u0004\u0019.\u000A(u001F), ref num);
			if (num <= 0)
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
				return \u0014\u0002\u001D.\u000A(false, \u001F\u0019\u0019.\u000A());
			}
			return \u0014\u0002\u001D.\u000A(true, \u0019\u001D\u000E.\u001F);
		}
	}
}

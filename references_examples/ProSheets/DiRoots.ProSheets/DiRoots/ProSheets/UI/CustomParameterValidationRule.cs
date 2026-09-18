using System;
using System.Globalization;
using System.Windows.Controls;
using A;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x02000044 RID: 68
	public class CustomParameterValidationRule : ValidationRule
	{
		// Token: 0x060002CB RID: 715 RVA: 0x00010380 File Offset: 0x0000E580
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string text = \u000F\u0009\u0014.\u0018(value);
			if (text == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomParameterValidationRule.Validate(object, CultureInfo)).MethodHandle;
				}
				return \u0012\u001A\u0018.\u0018(false, \u001C\u0009\u0018.\u0002\u0016);
			}
			object u000C = text;
			char[] array = \u0020\u0002\u000F.\u000C(9);
			\u0017\u001A\u0018.\u0018(array, fieldof(\u0009\u0017\u0018.\u0018).FieldHandle);
			if (\u0015\u001A\u0018.\u0018(u000C, array) != -1)
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
				return \u0012\u001A\u0018.\u0018(false, \u000D\u001E\u0018.\u0018(\u001C\u0009\u0018.\u001E\u0016, " \\ / : * ? \" < > |"));
			}
			return \u0012\u001A\u0018.\u0018(true, \u001F\u0002\u000F.\u000C);
		}
	}
}

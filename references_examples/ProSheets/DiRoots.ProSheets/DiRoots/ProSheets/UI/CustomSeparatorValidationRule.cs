using System;
using System.Globalization;
using System.Windows.Controls;
using A;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x02000045 RID: 69
	public class CustomSeparatorValidationRule : ValidationRule
	{
		// Token: 0x060002CD RID: 717 RVA: 0x00010424 File Offset: 0x0000E624
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string text = \u000F\u0009\u0014.\u0018(value);
			if (text == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomSeparatorValidationRule.Validate(object, CultureInfo)).MethodHandle;
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
			if (!\u001F\u000B\u0018.\u0018(text))
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
				if (this.P(text))
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
					return \u0012\u001A\u0018.\u0018(false, \u001C\u0009\u0018.\u000F);
				}
			}
			return \u0012\u001A\u0018.\u0018(true, \u001F\u0002\u000F.\u000C);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x000104EC File Offset: 0x0000E6EC
		private bool P(string P)
		{
			return \u0012\u0009\u0014.\u0018(\u000D\u0009\u0014.\u0018("^[a-zA-Z0-9\\s,]*$"), P);
		}
	}
}

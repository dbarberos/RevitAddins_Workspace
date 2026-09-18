using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Xml;
using A;

namespace DiRoots.ProSheets.Xml.ValidationRules
{
	// Token: 0x02000025 RID: 37
	public class XmlNameValidationRule : ValidationRule
	{
		// Token: 0x0600015F RID: 351 RVA: 0x00008BF0 File Offset: 0x00006DF0
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string text = \u0014\u0004\u000F.\u000C(value);
			if (\u001F\u001A\u0018.\u0018(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(XmlNameValidationRule.Validate(object, CultureInfo)).MethodHandle;
				}
				return \u0012\u001A\u0018.\u0018(false, \u0019\u0020\u0018.\u0016);
			}
			if (\u001A\u0001\u0018.\u0018(text, "xml", StringComparison.OrdinalIgnoreCase))
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
				return \u0012\u001A\u0018.\u0018(false, \u0019\u0020\u0018.\u000F);
			}
			if (!\u001D\u0001\u0018.\u0018(\u0002\u0001\u0018.\u0014(text, 0)))
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
				return \u0012\u001A\u0018.\u0018(false, \u0019\u0020\u0018.\u0012);
			}
			List<char> list = \u0004\u0001\u0018.\u0018();
			string u000C = text;
			for (int i = 0; i < \u001C\u0002\u0018.\u0014(u000C); i++)
			{
				char c = \u0002\u0001\u0018.\u0014(u000C, i);
				if (!\u001E\u0001\u0018.\u0018(c))
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
					\u0017\u0001\u0018.\u0018(list, c);
				}
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
			if (\u0015\u0001\u0018.\u0018(list) > 0)
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
				string u000C2 = ", ";
				IEnumerable<char> enumerable = list;
				Func<char, string> func;
				if ((func = XmlNameValidationRule.<>c.\u0018) == null)
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
					func = (XmlNameValidationRule.<>c.\u0018 = new Func<char, string>(XmlNameValidationRule.<>c.\u000C.\u0014));
				}
				string u = \u0011\u0001\u0018.\u0018(u000C2, Enumerable.Select<char, string>(enumerable, func));
				return \u0012\u001A\u0018.\u0018(false, \u0014\u001E\u0018.\u0018(\u0019\u0020\u0018.\u000D, " ", u));
			}
			ValidationResult result;
			try
			{
				\u001F\u0001\u0018.\u0018(text);
				result = \u0020\u0001\u0018.\u0018();
			}
			catch (XmlException u000C3)
			{
				result = \u0012\u001A\u0018.\u0018(false, \u0014\u001E\u0018.\u0018(\u0019\u0020\u0018.\u001C, " ", \u000A\u0001\u0018.\u0018(u000C3)));
			}
			return result;
		}
	}
}

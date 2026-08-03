using System;
using System.Globalization;
using System.Windows.Controls;
using A;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.TableGen.TableGen.UI.ValidationRules
{
	// Token: 0x0200017B RID: 379
	public class FontSizeValidationRule : ValidationRule
	{
		// Token: 0x06000E39 RID: 3641 RVA: 0x0005B17C File Offset: 0x0005937C
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>());
			double num = 0.0;
			string text = \u0007\u001F\u000E.\u001F(value);
			if (text != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FontSizeValidationRule.Validate(object, CultureInfo)).MethodHandle;
				}
				if (!\u0011\u0018.\u0004(text, out num))
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
					return \u0014\u0002\u001D.\u000A(false, \u000C\u0010\u0019.\u000A());
				}
			}
			else
			{
				double num2;
				if (value != null)
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
					num2 = \u0015\u000C\u000A.\u000A(value);
				}
				else
				{
					num2 = 0.0;
				}
				num = num2;
			}
			if (num < 0.0)
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
				return \u0014\u0002\u001D.\u000A(false, \u0016\u0006\u0007.\u000A());
			}
			if (num == 0.0)
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
				return \u0014\u0002\u001D.\u000A(false, \u0013\u001E\u0007.\u000A());
			}
			return \u0014\u0002\u001D.\u000A(true, \u0019\u001D\u000E.\u001F);
		}
	}
}

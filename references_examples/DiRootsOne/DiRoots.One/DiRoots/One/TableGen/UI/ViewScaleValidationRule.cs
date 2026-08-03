using System;
using System.Globalization;
using System.Windows.Controls;
using A;

namespace DiRoots.One.TableGen.UI
{
	// Token: 0x02000158 RID: 344
	public class ViewScaleValidationRule : ValidationRule
	{
		// Token: 0x06000CCF RID: 3279 RVA: 0x00050AD0 File Offset: 0x0004ECD0
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			object u001F = value;
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewScaleValidationRule.Validate(object, CultureInfo)).MethodHandle;
				}
				u001F = "";
			}
			string u001F2 = \u0009\u0004\u0019.\u000A(u001F);
			if (\u001A\u0006\u0007.\u000A(u001F2))
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
				return \u0014\u0002\u001D.\u000A(false, \u0007\u0019\u0019.\u000A());
			}
			int num;
			if (\u001C\u0015\u0004.\u000A(u001F2, ref num))
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
				if (num >= 1)
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
					if (num <= 24000)
					{
						goto IL_8F;
					}
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				return \u0014\u0002\u001D.\u000A(false, \u000A\u0019\u0019.\u000A());
			}
			IL_8F:
			return \u0014\u0002\u001D.\u000A(true, \u0019\u001D\u000E.\u001F);
		}
	}
}

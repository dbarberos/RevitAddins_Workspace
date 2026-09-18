using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.SheetGen.Models;

namespace DiRoots.One.SheetGen.UI.ValidationRules
{
	// Token: 0x02000395 RID: 917
	[ContentProperty("Properties")]
	public class CanSaveProfileValidationRule : ValidationRule
	{
		// Token: 0x17000A6E RID: 2670
		// (get) Token: 0x06002546 RID: 9542 RVA: 0x000E1114 File Offset: 0x000DF314
		// (set) Token: 0x06002547 RID: 9543 RVA: 0x000E1128 File Offset: 0x000DF328
		public CanSaveValidationProperties Properties { get; set; }

		// Token: 0x06002548 RID: 9544 RVA: 0x000E113C File Offset: 0x000DF33C
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string text = \u0020\u0006\u001D.\u000A(\u0005\u0011\u000B.\u001D(\u0020\u000E\u000E.\u001F(\u0002\u0006\u001D.\u000A(\u0007\u001D\u000E.\u001F(value)))));
			if (text == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveProfileValidationRule.Validate(object, CultureInfo)).MethodHandle;
				}
				\u000D\u001F\u0002.\u000A(\u0010\u001F\u0002.\u000A(this), false);
				\u000E\u001F\u0002.\u000A(\u0010\u001F\u0002.\u000A(this), \u0015\u0002\u001D.\u000A());
				\u001B\u001F\u0002.\u000A(\u0010\u001F\u0002.\u000A(this), ErrorType.Error);
				return \u0014\u0002\u001D.\u000A(false, \u0016\u0006\u001D.\u000A());
			}
			if (\u0008\u0013\u000A.\u000A(text, ""))
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
				\u000D\u001F\u0002.\u000A(\u0010\u001F\u0002.\u000A(this), false);
				\u000E\u001F\u0002.\u000A(\u0010\u001F\u0002.\u000A(this), \u0015\u0002\u001D.\u000A());
				\u001B\u001F\u0002.\u000A(\u0010\u001F\u0002.\u000A(this), ErrorType.Error);
				return \u0014\u0002\u001D.\u000A(false, \u001E\u001F\u0002.\u000A());
			}
			if (!\u001A\u0006\u0007.\u000A(\u0018\u0006\u001D.\u0007(text)))
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
				IEnumerable<Profile> enumerable = \u0011\u001F\u0002.\u000A(\u0010\u001F\u0002.\u000A(this));
				Func<Profile, string> func;
				if ((func = CanSaveProfileValidationRule.<>c.\u000A) == null)
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
					func = (CanSaveProfileValidationRule.<>c.\u000A = new Func<Profile, string>(CanSaveProfileValidationRule.<>c.\u001F.\u0007));
				}
				if (Enumerable.Contains<string>(Enumerable.Select<Profile, string>(enumerable, func), \u0018\u0006\u001D.\u0007(text)))
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
					\u000E\u001F\u0002.\u000A(\u0010\u001F\u0002.\u000A(this), \u0007\u0006\u001D.\u000A());
					\u000D\u001F\u0002.\u000A(\u0010\u001F\u0002.\u000A(this), true);
					\u001B\u001F\u0002.\u000A(\u0010\u001F\u0002.\u000A(this), ErrorType.Warning);
					return \u0014\u0002\u001D.\u000A(false, \u0008\u001F\u0002.\u000A());
				}
			}
			\u000E\u001F\u0002.\u000A(\u0010\u001F\u0002.\u000A(this), \u0015\u0002\u001D.\u000A());
			\u000D\u001F\u0002.\u000A(\u0010\u001F\u0002.\u000A(this), true);
			return \u0014\u0002\u001D.\u000A(true, \u0019\u001D\u000E.\u001F);
		}

		// Token: 0x04000ED6 RID: 3798
		[CompilerGenerated]
		private CanSaveValidationProperties F;
	}
}

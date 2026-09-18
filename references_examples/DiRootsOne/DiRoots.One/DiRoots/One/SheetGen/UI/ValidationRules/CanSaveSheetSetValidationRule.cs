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
	// Token: 0x02000397 RID: 919
	[ContentProperty("Properties")]
	public class CanSaveSheetSetValidationRule : ValidationRule
	{
		// Token: 0x17000A6F RID: 2671
		// (get) Token: 0x0600254A RID: 9546 RVA: 0x000E1318 File Offset: 0x000DF518
		// (set) Token: 0x0600254B RID: 9547 RVA: 0x000E132C File Offset: 0x000DF52C
		public CanSaveValidationProperties Properties { get; set; }

		// Token: 0x0600254C RID: 9548 RVA: 0x000E1340 File Offset: 0x000DF540
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string text = \u0020\u0006\u001D.\u000A(\u000A\u001F\u0002.\u001D(\u0017\u000E\u000E.\u001F(\u0002\u0006\u001D.\u000A(\u0007\u001D\u000E.\u001F(value)))));
			if (text == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveSheetSetValidationRule.Validate(object, CultureInfo)).MethodHandle;
				}
				return \u0014\u0002\u001D.\u000A(false, \u0016\u0006\u001D.\u000A());
			}
			if (\u0008\u0013\u000A.\u000A(text, ""))
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
				\u000D\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this), false);
				\u000E\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this), \u0015\u0002\u001D.\u000A());
				\u001B\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this), ErrorType.Error);
				return \u0014\u0002\u001D.\u000A(false, \u0013\u001F\u0002.\u000A());
			}
			object u001F = \u0018\u0006\u001D.\u0007(text);
			char[] array = \u001C\u0007\u000E.\u001F(13);
			\u001B\u000B\u001D.\u000A(array, fieldof(\u0001\u001B\u000A.\u0016).FieldHandle);
			if (\u0013\u000F\u0007.\u0007(u001F, array) != -1)
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
				\u000E\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this), \u0015\u0002\u001D.\u000A());
				\u001B\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this), ErrorType.Error);
				\u000D\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this), false);
				return \u0014\u0002\u001D.\u000A(false, \u0014\u001F\u0002.\u000A());
			}
			if (!\u001A\u0006\u0007.\u000A(\u0018\u0006\u001D.\u0007(text)))
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
				IEnumerable<ViewSheetSetInfo> enumerable = \u0017\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this));
				Func<ViewSheetSetInfo, string> func;
				if ((func = CanSaveSheetSetValidationRule.<>c.\u000A) == null)
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
					func = (CanSaveSheetSetValidationRule.<>c.\u000A = new Func<ViewSheetSetInfo, string>(CanSaveSheetSetValidationRule.<>c.\u001F.\u001D));
				}
				if (!Enumerable.Contains<string>(Enumerable.Select<ViewSheetSetInfo, string>(enumerable, func), \u0018\u0006\u001D.\u0007(text)))
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
					\u000E\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this), \u0015\u0002\u001D.\u000A());
					\u000D\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this), true);
					return \u0014\u0002\u001D.\u000A(true, \u0019\u001D\u000E.\u001F);
				}
			}
			if (!\u001A\u0006\u0007.\u000A(\u0018\u0006\u001D.\u0007(text)))
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
				IEnumerable<ViewSheetSetInfo> enumerable2 = \u0017\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this));
				Func<ViewSheetSetInfo, string> func2;
				if ((func2 = CanSaveSheetSetValidationRule.<>c.\u0007) == null)
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
					func2 = (CanSaveSheetSetValidationRule.<>c.\u0007 = new Func<ViewSheetSetInfo, string>(CanSaveSheetSetValidationRule.<>c.\u001F.\u0004));
				}
				if (Enumerable.Contains<string>(Enumerable.Select<ViewSheetSetInfo, string>(enumerable2, func2), \u0018\u0006\u001D.\u0007(text)))
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
					\u000E\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this), \u0007\u0006\u001D.\u000A());
					\u000D\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this), true);
					\u001B\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this), ErrorType.Warning);
					return \u0014\u0002\u001D.\u000A(false, \u0020\u001F\u0002.\u000A());
				}
			}
			\u000E\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this), \u0015\u0002\u001D.\u000A());
			\u000D\u001F\u0002.\u000A(\u0004\u001F\u0002.\u000A(this), false);
			return \u0014\u0002\u001D.\u000A(true, \u0019\u001D\u000E.\u001F);
		}

		// Token: 0x04000EDA RID: 3802
		[CompilerGenerated]
		private CanSaveValidationProperties F;
	}
}

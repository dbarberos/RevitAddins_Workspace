using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using A;
using DiRoots.One.ReOrdering.Core.ViewModels;

namespace DiRoots.Commons.Profiles.UI.ValidationRules
{
	// Token: 0x020000B6 RID: 182
	[ContentProperty("Properties")]
	public class CanSaveSelectionValidationRule : ValidationRule
	{
		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x00029350 File Offset: 0x00027550
		// (set) Token: 0x0600070E RID: 1806 RVA: 0x00029364 File Offset: 0x00027564
		public CanSaveSelectionValidationProperties Properties { get; set; }

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00029378 File Offset: 0x00027578
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x0002938C File Offset: 0x0002758C
		public bool CheckInvalidCharacters { get; set; }

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x000293A0 File Offset: 0x000275A0
		// (set) Token: 0x06000712 RID: 1810 RVA: 0x000293B4 File Offset: 0x000275B4
		public bool CheckInvalidPathCharacters { get; set; }

		// Token: 0x06000713 RID: 1811 RVA: 0x000293C8 File Offset: 0x000275C8
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string text = CanSaveSelectionValidationRule.H(value);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveSelectionValidationRule.Validate(object, CultureInfo)).MethodHandle;
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
				\u0013\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), false);
				\u000C\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), \u0015\u0002\u001D.\u000A());
				\u0009\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), ErrorType.Error);
				return \u0014\u0002\u001D.\u000A(false, \u0005\u0006\u001D.\u000A());
			}
			text = \u0018\u0006\u001D.\u0007(text);
			object u001F = text;
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
				if (\u0019\u0006\u001D.\u000A(this))
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
					\u000C\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), \u0015\u0002\u001D.\u000A());
					\u0009\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), ErrorType.Error);
					\u0013\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), false);
					return \u0014\u0002\u001D.\u000A(false, \u0004\u0006\u001D.\u000A());
				}
			}
			if (\u001D\u0006\u001D.\u000A(\u001A\u0002\u001D.\u000A(this)) != null)
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
				if (\u001F\u0006\u001D.\u000A(\u001A\u0002\u001D.\u000A(this)) != null)
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
					if (!\u001A\u0006\u0007.\u000A(text))
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
						IEnumerable<string> enumerable = \u001D\u0006\u001D.\u000A(\u001A\u0002\u001D.\u000A(this));
						Func<string, string> func;
						if ((func = CanSaveSelectionValidationRule.<>c.\u000A) == null)
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
							func = (CanSaveSelectionValidationRule.<>c.\u000A = new Func<string, string>(CanSaveSelectionValidationRule.<>c.\u001F.\u0019));
						}
						if (!Enumerable.Contains<string>(Enumerable.Select<string, string>(enumerable, func), text))
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
							IEnumerable<string> enumerable2 = \u001F\u0006\u001D.\u000A(\u001A\u0002\u001D.\u000A(this));
							Func<string, string> func2;
							if ((func2 = CanSaveSelectionValidationRule.<>c.\u0007) == null)
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
								func2 = (CanSaveSelectionValidationRule.<>c.\u0007 = new Func<string, string>(CanSaveSelectionValidationRule.<>c.\u001F.\u0018));
							}
							if (!Enumerable.Contains<string>(Enumerable.Select<string, string>(enumerable2, func2), text))
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
								\u000C\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), \u0015\u0002\u001D.\u000A());
								\u0013\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), true);
								return \u0014\u0002\u001D.\u000A(true, \u0019\u001D\u000E.\u001F);
							}
						}
					}
				}
			}
			if (!\u001A\u0006\u0007.\u000A(text))
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
				if (\u001D\u0006\u001D.\u000A(\u001A\u0002\u001D.\u000A(this)) != null)
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
					IEnumerable<string> enumerable3 = \u001D\u0006\u001D.\u000A(\u001A\u0002\u001D.\u000A(this));
					Func<string, string> func3;
					if ((func3 = CanSaveSelectionValidationRule.<>c.\u001D) == null)
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
						func3 = (CanSaveSelectionValidationRule.<>c.\u001D = new Func<string, string>(CanSaveSelectionValidationRule.<>c.\u001F.\u0005));
					}
					if (Enumerable.Contains<string>(Enumerable.Select<string, string>(enumerable3, func3), text))
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
						\u000C\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), \u0007\u0006\u001D.\u000A());
						\u0013\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), true);
						\u0009\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), ErrorType.Warning);
						return \u0014\u0002\u001D.\u000A(false, \u000A\u0006\u001D.\u000A());
					}
				}
				if (\u001F\u0006\u001D.\u000A(\u001A\u0002\u001D.\u000A(this)) != null)
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
					IEnumerable<string> enumerable4 = \u001F\u0006\u001D.\u000A(\u001A\u0002\u001D.\u000A(this));
					Func<string, string> func4;
					if ((func4 = CanSaveSelectionValidationRule.<>c.\u0004) == null)
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
						func4 = (CanSaveSelectionValidationRule.<>c.\u0004 = new Func<string, string>(CanSaveSelectionValidationRule.<>c.\u001F.\u0016));
					}
					if (Enumerable.Contains<string>(Enumerable.Select<string, string>(enumerable4, func4), text))
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
						\u000C\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), "Save");
						\u0013\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), false);
						\u0009\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), ErrorType.Error);
						return \u0014\u0002\u001D.\u000A(false, \u0001\u0002\u001D.\u000A());
					}
				}
			}
			\u000C\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), \u0015\u0002\u001D.\u000A());
			\u0013\u0002\u001D.\u000A(\u001A\u0002\u001D.\u000A(this), true);
			return \u0014\u0002\u001D.\u000A(true, \u0019\u001D\u000E.\u001F);
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x000297B8 File Offset: 0x000279B8
		private static string H(object F)
		{
			string result = \u000F\u0015\u0010.\u001F;
			BindingExpression bindingExpression = \u0007\u001D\u000E.\u001F(F);
			if (bindingExpression != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveSelectionValidationRule.H(object)).MethodHandle;
				}
				NewNameViewModel newNameViewModel = \u001D\u001D\u000E.\u001F(\u0002\u0006\u001D.\u000A(bindingExpression));
				if (newNameViewModel != null)
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
					result = \u0006\u0006\u001D.\u0007(newNameViewModel);
				}
				else
				{
					INewName newName = \u0004\u001D\u000E.\u001F(\u0002\u0006\u001D.\u000A(bindingExpression));
					if (newName != null)
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
						result = \u000B\u0006\u001D.\u000A(newName);
					}
				}
			}
			return result;
		}

		// Token: 0x040002D5 RID: 725
		[CompilerGenerated]
		private CanSaveSelectionValidationProperties F;

		// Token: 0x040002D6 RID: 726
		[CompilerGenerated]
		private bool R;

		// Token: 0x040002D7 RID: 727
		[CompilerGenerated]
		private bool D;
	}
}

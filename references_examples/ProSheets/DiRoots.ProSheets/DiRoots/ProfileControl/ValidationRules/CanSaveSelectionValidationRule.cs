using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using A;
using DiRoots.ProfileControl.Helpers;

namespace DiRoots.ProfileControl.ValidationRules
{
	// Token: 0x0200000C RID: 12
	[ContentProperty("Properties")]
	public class CanSaveSelectionValidationRule : ValidationRule
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00003C38 File Offset: 0x00001E38
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00003C4C File Offset: 0x00001E4C
		public CanSaveSelectionValidationProperties Properties { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00003C60 File Offset: 0x00001E60
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00003C74 File Offset: 0x00001E74
		public bool CheckInvalidCharacters { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00003C88 File Offset: 0x00001E88
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00003C9C File Offset: 0x00001E9C
		public bool CheckInvalidPathCharacters { get; set; }

		// Token: 0x0600004C RID: 76 RVA: 0x00003CB0 File Offset: 0x00001EB0
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string text = CanSaveSelectionValidationRule.\u0003(value);
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
				return \u0012\u001A\u0018.\u0018(false, \u000D\u0009\u0018.\u0007\u0018);
			}
			if (\u000F\u0002\u0018.\u0018(text, ""))
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
				\u000D\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), false);
				\u0013\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), \u000D\u0009\u0018.\u000F\u0014);
				\u0009\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), ErrorType.Error);
				return \u0012\u001A\u0018.\u0018(false, \u000D\u0009\u0018.\u0013\u0014);
			}
			object u000C = \u0012\u0002\u0018.\u0018(text);
			char[] array = \u0020\u0002\u000F.\u000C(13);
			\u0017\u001A\u0018.\u0018(array, fieldof(\u0009\u0017\u0018.\u0014).FieldHandle);
			if (\u0015\u001A\u0018.\u0018(u000C, array) != -1)
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
				if (\u0011\u001A\u0018.\u0018(this))
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
					\u0013\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), \u000D\u0009\u0018.\u000F\u0014);
					\u0009\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), ErrorType.Error);
					\u000D\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), false);
					return \u0012\u001A\u0018.\u0018(false, \u000D\u0009\u0018.\u0020\u0014);
				}
			}
			if (\u0020\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this)) != null)
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
				if (\u000A\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this)) != null)
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
					if (!\u001F\u001A\u0018.\u0018(\u0012\u0002\u0018.\u0018(text)))
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
						IEnumerable<string> enumerable = \u0020\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this));
						Func<string, string> func;
						if ((func = CanSaveSelectionValidationRule.<>c.\u0018) == null)
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
							func = (CanSaveSelectionValidationRule.<>c.\u0018 = new Func<string, string>(CanSaveSelectionValidationRule.<>c.\u000C.\u000F));
						}
						if (!Enumerable.Contains<string>(Enumerable.Select<string, string>(enumerable, func), \u0012\u0002\u0018.\u0018(text)))
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
							IEnumerable<string> enumerable2 = \u000A\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this));
							Func<string, string> func2;
							if ((func2 = CanSaveSelectionValidationRule.<>c.\u0014) == null)
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
								func2 = (CanSaveSelectionValidationRule.<>c.\u0014 = new Func<string, string>(CanSaveSelectionValidationRule.<>c.\u000C.\u0012));
							}
							if (!Enumerable.Contains<string>(Enumerable.Select<string, string>(enumerable2, func2), \u0012\u0002\u0018.\u0018(text)))
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
								\u0013\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), \u000D\u0009\u0018.\u000F\u0014);
								\u000D\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), true);
								return \u0012\u001A\u0018.\u0018(true, \u001F\u0002\u000F.\u000C);
							}
						}
					}
				}
			}
			if (!\u001F\u001A\u0018.\u0018(\u0012\u0002\u0018.\u0018(text)))
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
				if (\u0020\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this)) != null)
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
					IEnumerable<string> enumerable3 = \u0020\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this));
					Func<string, string> func3;
					if ((func3 = CanSaveSelectionValidationRule.<>c.\u0003) == null)
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
						func3 = (CanSaveSelectionValidationRule.<>c.\u0003 = new Func<string, string>(CanSaveSelectionValidationRule.<>c.\u000C.\u000D));
					}
					if (Enumerable.Contains<string>(Enumerable.Select<string, string>(enumerable3, func3), \u0012\u0002\u0018.\u0018(text)))
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
						\u0013\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), \u000D\u0009\u0018.\u001F\u0014);
						\u000D\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), true);
						\u0009\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), ErrorType.Warning);
						return \u0012\u001A\u0018.\u0018(false, \u000D\u0009\u0018.\u0009\u0014);
					}
				}
				if (\u000A\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this)) != null)
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
					IEnumerable<string> enumerable4 = \u000A\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this));
					Func<string, string> func4;
					if ((func4 = CanSaveSelectionValidationRule.<>c.\u0016) == null)
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
						func4 = (CanSaveSelectionValidationRule.<>c.\u0016 = new Func<string, string>(CanSaveSelectionValidationRule.<>c.\u000C.\u001C));
					}
					if (Enumerable.Contains<string>(Enumerable.Select<string, string>(enumerable4, func4), \u0012\u0002\u0018.\u0018(text)))
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
						\u0013\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), \u000D\u0009\u0018.\u000F\u0014);
						\u000D\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), false);
						\u0009\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), ErrorType.Error);
						return \u0012\u001A\u0018.\u0018(false, \u000D\u0009\u0018.\u000A\u0014);
					}
				}
			}
			\u0013\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), \u000D\u0009\u0018.\u000F\u0014);
			\u000D\u001A\u0018.\u0018(\u001C\u001A\u0018.\u0018(this), true);
			return \u0012\u001A\u0018.\u0018(true, \u001F\u0002\u000F.\u000C);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000040C8 File Offset: 0x000022C8
		private static string \u0003(object \u000C)
		{
			string result = \u0005\u001E\u000F.\u000C;
			BindingExpression bindingExpression = \u0013\u0002\u000F.\u000C(\u000C);
			if (bindingExpression != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CanSaveSelectionValidationRule.\u0003(object)).MethodHandle;
				}
				NewNameViewModel newNameViewModel = \u0009\u0002\u000F.\u000C(\u0002\u001A\u0018.\u0018(bindingExpression));
				if (newNameViewModel != null)
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
					result = \u0004\u001A\u0018.\u0014(newNameViewModel);
				}
				else
				{
					INewName newName = \u000A\u0002\u000F.\u000C(\u0002\u001A\u0018.\u0018(bindingExpression));
					if (newName != null)
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
						result = \u001E\u001A\u0018.\u0018(newName);
					}
				}
			}
			return result;
		}

		// Token: 0x04000017 RID: 23
		[CompilerGenerated]
		private CanSaveSelectionValidationProperties \u000C;

		// Token: 0x04000018 RID: 24
		[CompilerGenerated]
		private bool \u0018;

		// Token: 0x04000019 RID: 25
		[CompilerGenerated]
		private bool \u0014;
	}
}

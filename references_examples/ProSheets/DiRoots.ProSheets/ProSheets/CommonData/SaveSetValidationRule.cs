using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using A;
using ProSheets.Enums;
using ProSheets.UI;
using ProSheets.UI.CommonData;

namespace ProSheets.CommonData
{
	// Token: 0x0200009E RID: 158
	[ContentProperty("Properties")]
	public class SaveSetValidationRule : ValidationRule
	{
		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000962 RID: 2402 RVA: 0x00039D54 File Offset: 0x00037F54
		// (set) Token: 0x06000963 RID: 2403 RVA: 0x00039D68 File Offset: 0x00037F68
		public CanSaveValidationProperties Properties { get; set; }

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x00039D7C File Offset: 0x00037F7C
		// (set) Token: 0x06000965 RID: 2405 RVA: 0x00039D90 File Offset: 0x00037F90
		public bool CheckInvalidCharacters { get; set; }

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000966 RID: 2406 RVA: 0x00039DA4 File Offset: 0x00037FA4
		// (set) Token: 0x06000967 RID: 2407 RVA: 0x00039DB8 File Offset: 0x00037FB8
		public bool CheckInvalidPathCharacters { get; set; }

		// Token: 0x06000968 RID: 2408 RVA: 0x00039DCC File Offset: 0x00037FCC
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			try
			{
				BindingExpression bindingExpression = \u0013\u0002\u000F.\u000C(value);
				if (bindingExpression != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SaveSetValidationRule.Validate(object, CultureInfo)).MethodHandle;
					}
					NewNameWindow newNameWindow = \u0019\u0007\u000F.\u000C(\u0002\u001A\u0018.\u0018(bindingExpression));
					if (newNameWindow != null)
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
						string text = \u001F\u0005\u0003.\u0018(newNameWindow);
						List<ViewSheetSetInfo> list = Enumerable.ToList<ViewSheetSetInfo>(\u0020\u0005\u0003.\u0018(newNameWindow));
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
							return \u0012\u001A\u0018.\u0018(false, \u000D\u0009\u0018.\u0007\u0018);
						}
						if (\u000F\u0002\u0018.\u0018(text, ""))
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
							\u0009\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), false);
							\u0013\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), \u000D\u0009\u0018.\u000F\u0014);
							\u001C\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), ErrorType.Error);
							return \u0012\u001A\u0018.\u0018(false, \u000D\u0009\u0018.\u0010\u0018);
						}
						object u000C = \u0012\u0002\u0018.\u0018(text);
						char[] array = \u0020\u0002\u000F.\u000C(13);
						\u0017\u001A\u0018.\u0018(array, fieldof(\u0009\u0017\u0018.\u0014).FieldHandle);
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
							\u0013\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), \u000D\u0009\u0018.\u000F\u0014);
							\u001C\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), ErrorType.Error);
							bool u000C2;
							\u0009\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), u000C2 = false);
							return \u0012\u001A\u0018.\u0018(u000C2, \u000D\u0009\u0018.\u0006\u0018);
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
							if (\u000A\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this)) != null)
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
								IEnumerable<ViewSheetSetInfo> enumerable = list;
								Func<ViewSheetSetInfo, bool> func;
								if ((func = SaveSetValidationRule.<>c.\u0018) == null)
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
									func = (SaveSetValidationRule.<>c.\u0018 = new Func<ViewSheetSetInfo, bool>(SaveSetValidationRule.<>c.\u000C.\u000F));
								}
								IEnumerable<ViewSheetSetInfo> enumerable2 = Enumerable.Where<ViewSheetSetInfo>(enumerable, func);
								Func<ViewSheetSetInfo, string> func2;
								if ((func2 = SaveSetValidationRule.<>c.\u0014) == null)
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
									func2 = (SaveSetValidationRule.<>c.\u0014 = new Func<ViewSheetSetInfo, string>(SaveSetValidationRule.<>c.\u000C.\u0012));
								}
								if (!Enumerable.Contains<string>(Enumerable.Select<ViewSheetSetInfo, string>(enumerable2, func2), \u0012\u0002\u0018.\u0018(text)))
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
									\u0013\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), \u000D\u0009\u0018.\u000F\u0014);
									bool u000C2;
									\u0009\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), u000C2 = true);
									return \u0012\u001A\u0018.\u0018(u000C2, \u001F\u0002\u000F.\u000C);
								}
							}
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
							IEnumerable<ViewSheetSetInfo> enumerable3 = list;
							Func<ViewSheetSetInfo, bool> func3;
							if ((func3 = SaveSetValidationRule.<>c.\u0003) == null)
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
								func3 = (SaveSetValidationRule.<>c.\u0003 = new Func<ViewSheetSetInfo, bool>(SaveSetValidationRule.<>c.\u000C.\u000D));
							}
							IEnumerable<ViewSheetSetInfo> enumerable4 = Enumerable.Where<ViewSheetSetInfo>(enumerable3, func3);
							Func<ViewSheetSetInfo, string> func4;
							if ((func4 = SaveSetValidationRule.<>c.\u0016) == null)
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
								func4 = (SaveSetValidationRule.<>c.\u0016 = new Func<ViewSheetSetInfo, string>(SaveSetValidationRule.<>c.\u000C.\u001C));
							}
							if (Enumerable.Contains<string>(Enumerable.Select<ViewSheetSetInfo, string>(enumerable4, func4), \u0012\u0002\u0018.\u0018(text)))
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
								\u0013\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), \u000D\u0009\u0018.\u001F\u0014);
								\u0009\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), true);
								\u001C\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), ErrorType.Warning);
								return \u0012\u001A\u0018.\u0018(false, \u000D\u0009\u0018.\u0008\u0018);
							}
						}
						\u0013\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), \u000D\u0009\u0018.\u000F\u0014);
						\u0009\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), true);
						return \u0012\u001A\u0018.\u0018(true, \u001F\u0002\u000F.\u000C);
					}
				}
			}
			catch (Exception)
			{
			}
			\u0009\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), false);
			\u0013\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), \u000D\u0009\u0018.\u000F\u0014);
			\u001C\u0005\u0003.\u0018(\u0013\u0008\u0003.\u0018(this), ErrorType.None);
			return \u0012\u001A\u0018.\u0018(true, \u001F\u0002\u000F.\u000C);
		}

		// Token: 0x04000467 RID: 1127
		[CompilerGenerated]
		private CanSaveValidationProperties P;

		// Token: 0x04000468 RID: 1128
		[CompilerGenerated]
		private bool Q;

		// Token: 0x04000469 RID: 1129
		[CompilerGenerated]
		private bool J;
	}
}

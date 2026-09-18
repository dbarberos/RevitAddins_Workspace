using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace A
{
	// Token: 0x020000CA RID: 202
	internal static class \u000E\u0020\u0018
	{
		// Token: 0x06000B24 RID: 2852 RVA: 0x00041D5C File Offset: 0x0003FF5C
		public static IEnumerable<string> \u000C(string \u000C)
		{
			IEnumerable<Match> enumerable = Enumerable.Cast<Match>(\u0018\u0013\u0016.\u0018(\u000D\u0009\u0014.\u0018("%([^%]+)%"), \u000C));
			Func<Match, string> func;
			if ((func = \u000E\u0020\u0018.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u0020\u0018.\u000C(string)).MethodHandle;
				}
				func = (\u000E\u0020\u0018.<>c.\u0018 = new Func<Match, string>(\u000E\u0020\u0018.<>c.\u000C.\u0014));
			}
			return Enumerable.Select<Match, string>(enumerable, func);
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x00041DC0 File Offset: 0x0003FFC0
		public static string \u0018(this string \u000C)
		{
			return \u0014\u001E\u0018.\u0018("%", \u000C, "\\(?.*%");
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x00041DE0 File Offset: 0x0003FFE0
		public static string \u0014(string \u000C, string \u0018, string \u0014)
		{
			List<Tuple<string, string>> u000C = \u0020\u0013\u0016.\u0018();
			try
			{
				string u = "%([^%]+)%";
				IEnumerator u000C2 = \u000C\u0007\u0014.\u0018(\u000A\u0013\u0016.\u0018(\u000C, u, 64));
				try
				{
					while (\u001F\u001E\u0018.\u0018(u000C2))
					{
						string text = \u0005\u0019\u0014.\u0018(\u000C\u000B\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C2)));
						object u000C3 = text;
						char[] array = \u0020\u0002\u000F.\u000C(1);
						array[0] = '(';
						if (!\u0009\u001E\u0018.\u0018(\u0010\u000B\u0014.\u0018(\u0011\u001C\u0003.\u0018(u000C3, array)[0], "%", ""), \u0018))
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u000E\u0020\u0018.\u0014(string, string, string)).MethodHandle;
							}
							string u000C4 = text;
							string u2 = \u0014;
							if (!\u001F\u001A\u0018.\u0018(u000C4))
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
								if (\u000A\u0017\u0014.\u0018(u000C4, ","))
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
									object u000C5 = \u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(u000C4, \u0018, ""), "%", ""), "(", ""), ")", "");
									char[] array2 = \u0020\u0002\u000F.\u000C(1);
									array2[0] = ',';
									string[] array3 = \u0011\u001C\u0003.\u0018(u000C5, array2);
									if ((int)\u0020\u001A\u000F.\u000C(array3) > 1)
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
										DateTime dateTime;
										if (\u0009\u0013\u0016.\u0018(\u0014, \u000E\u000D\u0003.\u0003(array3[0]), null, DateTimeStyles.None, ref dateTime))
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
											u2 = \u0013\u0013\u0016.\u0018(ref dateTime, \u000E\u000D\u0003.\u0003(array3[1]));
										}
									}
								}
							}
							\u000D\u0013\u0016.\u0018(u000C, \u001C\u0013\u0016.\u0018(text, u2));
						}
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
				finally
				{
					IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C2);
					if (disposable != null)
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
						\u0020\u001E\u0018.\u0018(disposable);
					}
				}
			}
			catch (Exception)
			{
			}
			List<Tuple<string, string>>.Enumerator enumerator = \u0012\u0013\u0016.\u0018(u000C);
			try
			{
				while (\u0014\u0013\u0016.\u0018(ref enumerator))
				{
					Tuple<string, string> u000C6 = \u000F\u0013\u0016.\u0018(ref enumerator);
					string text2 = \u0016\u0013\u0016.\u0018(u000C6);
					char[] array4 = \u0008\u001A\u0018.\u0018();
					for (int i = 0; i < (int)\u0018\u000B\u000F.\u000C(array4); i++)
					{
						char c = array4[i];
						text2 = \u0010\u000B\u0014.\u0018(text2, \u0006\u000B\u0014.\u0018(ref c), "-");
					}
					for (;;)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					\u000C = \u0010\u000B\u0014.\u0018(\u000C, \u0003\u0013\u0016.\u0018(u000C6), text2);
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return \u000C;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace A
{
	// Token: 0x020000CB RID: 203
	internal static class \u0018\u001F\u0018
	{
		// Token: 0x06000B27 RID: 2855 RVA: 0x000420A0 File Offset: 0x000402A0
		private static Dictionary<string, string> \u000C()
		{
			Dictionary<string, string> dictionary = \u0011\u0013\u0016.\u0018();
			string u = "%dd";
			DateTime dateTime = \u0019\u0015\u0014.\u0018();
			\u001D\u000B\u0014.\u0018(dictionary, u, \u0013\u0013\u0016.\u0018(ref dateTime, "dd"));
			string u2 = "%d";
			dateTime = \u0019\u0015\u0014.\u0018();
			int num = \u0004\u000C\u0016.\u0018(ref dateTime);
			\u001D\u000B\u0014.\u0018(dictionary, u2, \u0010\u001E\u0018.\u0018(ref num));
			string u3 = "%mm";
			dateTime = \u0019\u0015\u0014.\u0018();
			\u001D\u000B\u0014.\u0018(dictionary, u3, \u0013\u0013\u0016.\u0018(ref dateTime, "MM"));
			string u4 = "%m";
			dateTime = \u0019\u0015\u0014.\u0018();
			num = \u0002\u000C\u0016.\u0018(ref dateTime);
			\u001D\u000B\u0014.\u0018(dictionary, u4, \u0010\u001E\u0018.\u0018(ref num));
			string u5 = "%YYYY";
			dateTime = \u0019\u0015\u0014.\u0018();
			\u001D\u000B\u0014.\u0018(dictionary, u5, \u0013\u0013\u0016.\u0018(ref dateTime, "yyyy"));
			string u6 = "%yy";
			dateTime = \u0019\u0015\u0014.\u0018();
			\u001D\u000B\u0014.\u0018(dictionary, u6, \u0013\u0013\u0016.\u0018(ref dateTime, "yy"));
			string u7 = "%YY";
			dateTime = \u0019\u0015\u0014.\u0018();
			\u001D\u000B\u0014.\u0018(dictionary, u7, \u0013\u0013\u0016.\u0018(ref dateTime, "yy"));
			string u8 = "%Y";
			dateTime = \u0019\u0015\u0014.\u0018();
			num = \u0017\u000C\u0016.\u0018(ref dateTime);
			\u001D\u000B\u0014.\u0018(dictionary, u8, \u0010\u001E\u0018.\u0018(ref num));
			string u9 = "%HH";
			dateTime = \u0019\u0015\u0014.\u0018();
			\u001D\u000B\u0014.\u0018(dictionary, u9, \u0013\u0013\u0016.\u0018(ref dateTime, "HH"));
			string u10 = "%H";
			dateTime = \u0019\u0015\u0014.\u0018();
			num = \u000A\u0018\u0016.\u0018(ref dateTime);
			\u001D\u000B\u0014.\u0018(dictionary, u10, \u0010\u001E\u0018.\u0018(ref num));
			string u11 = "%MM";
			dateTime = \u0019\u0015\u0014.\u0018();
			\u001D\u000B\u0014.\u0018(dictionary, u11, \u0013\u0013\u0016.\u0018(ref dateTime, "mm"));
			string u12 = "%M";
			dateTime = \u0019\u0015\u0014.\u0018();
			num = \u0013\u0018\u0016.\u0018(ref dateTime);
			\u001D\u000B\u0014.\u0018(dictionary, u12, \u0010\u001E\u0018.\u0018(ref num));
			string u13 = "%S";
			dateTime = \u0019\u0015\u0014.\u0018();
			num = \u001F\u0013\u0016.\u0018(ref dateTime);
			\u001D\u000B\u0014.\u0018(dictionary, u13, \u0010\u001E\u0018.\u0018(ref num));
			string u14 = "%SS";
			dateTime = \u0019\u0015\u0014.\u0018();
			\u001D\u000B\u0014.\u0018(dictionary, u14, \u0013\u0013\u0016.\u0018(ref dateTime, "ss"));
			return dictionary;
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x000422A0 File Offset: 0x000404A0
		internal static string \u0018(string \u000C)
		{
			\u0018\u001F\u0018.\u000C\u001F\u0018 u000C_u001F_u = new \u0018\u001F\u0018.\u000C\u001F\u0018();
			u000C_u001F_u.\u0018 = \u0018\u001F\u0018.\u000C();
			u000C_u001F_u.\u000C = "%[A-Za-z]+%?";
			u000C_u001F_u.\u0014 = \u0008\u001A\u0018.\u0018();
			char[] array = \u0020\u0002\u000F.\u000C(1);
			array[0] = '\\';
			IEnumerable<string> u = Enumerable.Select<string, string>(\u0011\u001C\u0003.\u0018(\u000C, array), new Func<string, string>(u000C_u001F_u.\u0016));
			string text = \u0011\u0001\u0018.\u0018("\\", u);
			object u000C = \u000D\u0009\u0014.\u0018("%[A-Za-z0-9_\\-\\(\\)]+%");
			string u2 = text;
			MatchEvaluator u3;
			if ((u3 = \u0018\u001F\u0018.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u001F\u0018.\u0018(string)).MethodHandle;
				}
				u3 = (\u0018\u001F\u0018.<>c.\u0018 = new MatchEvaluator(\u0018\u001F\u0018.<>c.\u000C.\u0014));
			}
			text = \u0017\u0013\u0016.\u0018(u000C, u2, u3);
			object u000C2 = text;
			char[] array2 = \u0020\u0002\u000F.\u000C(1);
			array2[0] = '\\';
			string[] array3 = \u0011\u001C\u0003.\u0018(u000C2, array2);
			object obj;
			if (!\u000E\u0019\u0014.\u0018(text, "\\\\"))
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
				if (\u0020\u001A\u000F.\u000C(array3) != 0)
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
					obj = \u0015\u0013\u0016.\u0018(array3[0], ":");
					goto IL_FE;
				}
			}
			obj = 0;
			IL_FE:
			object obj2 = obj;
			int num = (obj2 != 0) ? 1 : 0;
			IEnumerable<string> enumerable = Enumerable.Select<string, string>(Enumerable.Skip<string>(array3, num), new Func<string, string>(u000C_u001F_u.\u000F));
			if (obj2 != null)
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
				string[] array4 = \u000C\u0002\u000F.\u000C(1);
				array4[0] = array3[0];
				enumerable = Enumerable.Concat<string>(array4, enumerable);
			}
			return \u0011\u0001\u0018.\u0018("\\", enumerable);
		}

		// Token: 0x020001CD RID: 461
		[CompilerGenerated]
		private sealed class \u000C\u001F\u0018
		{
			// Token: 0x060011EC RID: 4588 RVA: 0x0005D7F4 File Offset: 0x0005B9F4
			internal string \u0016(string \u000C)
			{
				IEnumerator<Match> enumerator = \u0012\u0011\u000F.\u0018(Enumerable.Cast<Match>(\u000A\u0013\u0016.\u0018(\u000C, this.\u000C, 64)));
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						Match u000C = \u000F\u0011\u000F.\u0018(enumerator);
						string u = \u0005\u0019\u0014.\u0018(u000C);
						string u2;
						if (\u0016\u0011\u000F.\u0018(this.\u0018, u, ref u2))
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u001F\u0018.\u000C\u001F\u0018.\u0016(string)).MethodHandle;
							}
							\u000C = \u0014\u001E\u0018.\u0018(\u0003\u0002\u0018.\u0018(\u000C, 0, \u0003\u0011\u000F.\u0018(u000C)), u2, \u000D\u0002\u0018.\u0018(\u000C, \u0003\u0011\u000F.\u0018(u000C) + \u0014\u0011\u000F.\u0018(u000C)));
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
					if (enumerator != null)
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
						\u0020\u001E\u0018.\u0018(enumerator);
					}
				}
				return \u000C;
			}

			// Token: 0x060011ED RID: 4589 RVA: 0x0005D8CC File Offset: 0x0005BACC
			internal string \u000F(string \u000C)
			{
				Func<char, bool> func;
				if ((func = this.\u0003) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u001F\u0018.\u000C\u001F\u0018.\u000F(string)).MethodHandle;
					}
					func = (this.\u0003 = new Func<char, bool>(this.\u0012));
				}
				return \u0003\u000B\u0018.\u0018(Enumerable.ToArray<char>(Enumerable.Where<char>(\u000C, func)));
			}

			// Token: 0x060011EE RID: 4590 RVA: 0x0005D924 File Offset: 0x0005BB24
			internal bool \u0012(char \u000C)
			{
				return !Enumerable.Contains<char>(this.\u0014, \u000C);
			}

			// Token: 0x0400087E RID: 2174
			public string \u000C;

			// Token: 0x0400087F RID: 2175
			public Dictionary<string, string> \u0018;

			// Token: 0x04000880 RID: 2176
			public char[] \u0014;

			// Token: 0x04000881 RID: 2177
			public Func<char, bool> \u0003;
		}
	}
}

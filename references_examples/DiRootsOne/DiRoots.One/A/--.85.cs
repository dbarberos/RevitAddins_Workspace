using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Autodesk.Revit.DB;
using DiRoots.One.TGDatabaseLayer;

namespace A
{
	// Token: 0x02000137 RID: 311
	internal sealed class \u001C\u0016
	{
		// Token: 0x06000B9F RID: 2975 RVA: 0x00049D04 File Offset: 0x00047F04
		private \u001C\u0016(bool \u001F, string \u000A, string \u0007, string \u001D, string \u0004, Regex \u0019)
		{
			this.\u000A = \u001F;
			this.\u0007 = \u000A;
			this.\u001D = \u0007;
			this.\u0004 = \u001D;
			this.\u0019 = \u0004;
			this.\u0018 = \u0019;
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x00049D68 File Offset: 0x00047F68
		public static \u001C\u0016 \u0005(Document \u001F, DecimalSymbolOption \u000A)
		{
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0016.\u0005(Document, DecimalSymbolOption)).MethodHandle;
				}
				if (\u000A == DecimalSymbolOption.UseDocumentSettings)
				{
					\u001C\u0016 result;
					try
					{
						NumberFormatInfo u001F = \u001F\u000C\u0004.\u000A(\u000A\u000C\u0004.\u000A());
						string text;
						if ((text = \u0009\u001A\u0004.\u000A(u001F)) == null)
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
							text = string.Empty;
						}
						string text2 = text;
						string text3;
						if ((text3 = \u0001\u001A\u0004.\u000A(u001F)) == null)
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
							text3 = string.Empty;
						}
						string text4 = text3;
						string text5 = \u001C\u0016.\u000F(\u001F);
						string text6 = \u001C\u0016.\u0012(\u001F);
						bool flag = \u001B\u0003\u0004.\u000A(text2, text5, StringComparison.Ordinal);
						bool flag2 = \u001B\u0003\u0004.\u000A(text4, text6, StringComparison.Ordinal);
						if (flag && flag2)
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
							result = \u001C\u0016.\u001F;
						}
						else
						{
							Regex regex = \u001C\u0016.\u0006(text2, text4);
							if (regex == null)
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
								result = \u001C\u0016.\u001F;
							}
							else
							{
								result = new \u001C\u0016(true, text2, text4, text5, text6, regex);
							}
						}
					}
					catch
					{
						result = \u001C\u0016.\u001F;
					}
					return result;
				}
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return \u001C\u0016.\u001F;
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000BA2 RID: 2978 RVA: 0x00049E74 File Offset: 0x00048074
		public bool \u0016
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x00049E88 File Offset: 0x00048088
		public string \u000B(string \u001F)
		{
			if (this.\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0016.\u000B(string)).MethodHandle;
				}
				if (!\u001A\u0006\u0007.\u000A(\u001F))
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
					if (this.\u0018 != null)
					{
						return \u0007\u000C\u0004.\u000A(this.\u0018, \u001F, new MatchEvaluator(this.\u0003));
					}
					for (;;)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
				}
			}
			return \u001F;
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x00049EF4 File Offset: 0x000480F4
		private string \u0002(string \u001F)
		{
			string u001F = \u001F;
			if (!\u001A\u0006\u0007.\u000A(this.\u001D))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0016.\u0002(string)).MethodHandle;
				}
				u001F = \u001C\u000B\u001D.\u0007(u001F, this.\u001D, "\u0001");
			}
			if (!\u001A\u0006\u0007.\u000A(this.\u0007))
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
				u001F = \u001C\u000B\u001D.\u0007(u001F, this.\u0007, this.\u0004);
			}
			return \u001C\u000B\u001D.\u0007(u001F, "\u0001", this.\u0019);
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x00049F7C File Offset: 0x0004817C
		private static Regex \u0006(string \u001F, string \u000A)
		{
			string text;
			if (!\u001A\u0006\u0007.\u000A(\u001F))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0016.\u0006(string, string)).MethodHandle;
				}
				text = \u0004\u000C\u0004.\u000A(\u001F);
			}
			else
			{
				text = \u000F\u0015\u0010.\u001F;
			}
			string text2 = text;
			string text3;
			if (!\u001A\u0006\u0007.\u000A(\u000A))
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
				text3 = \u0004\u000C\u0004.\u000A(\u000A);
			}
			else
			{
				text3 = \u000F\u0015\u0010.\u001F;
			}
			string text4 = text3;
			string u000A;
			if (text2 != null)
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
				if (text4 != null)
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
					if (!\u001B\u0003\u0004.\u000A(text2, text4, StringComparison.Ordinal))
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
						string[] array = \u001B\u001F\u000E.\u001F(5);
						array[0] = "(?:";
						array[1] = text2;
						array[2] = "|";
						array[3] = text4;
						array[4] = ")";
						u000A = \u0014\u0006\u001D.\u000A(array);
						goto IL_D7;
					}
				}
			}
			if (text2 != null)
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
				u000A = text2;
			}
			else
			{
				if (text4 == null)
				{
					return null;
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
				u000A = text4;
			}
			IL_D7:
			string text5 = \u0002\u0013\u000A.\u000A("\\d+(?:", u000A, "\\d+)+");
			string u001F;
			if (text2 == null)
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
				u001F = text5;
			}
			else
			{
				string[] array2 = \u001B\u001F\u000E.\u001F(5);
				array2[0] = "(?:";
				array2[1] = text5;
				array2[2] = "|";
				array2[3] = text2;
				array2[4] = "\\d+)";
				u001F = \u0014\u0006\u001D.\u000A(array2);
			}
			return \u001D\u000C\u0004.\u000A(u001F, 520);
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x0004A0C0 File Offset: 0x000482C0
		private static string \u000F(Document \u001F)
		{
			if (\u0019\u000C\u0004.\u000A(\u0006\u0006\u0007.\u000A(\u001F)) == 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u0016.\u000F(Document)).MethodHandle;
				}
				return ",";
			}
			return ".";
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x0004A100 File Offset: 0x00048300
		private static string \u0012(Document \u001F)
		{
			switch (\u0018\u000C\u0004.\u000A(\u0006\u0006\u0007.\u000A(\u001F)))
			{
			case 1:
				return ",";
			case 2:
				return " ";
			case 3:
				return "'";
			default:
				return ".";
			}
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x0004A14C File Offset: 0x0004834C
		[CompilerGenerated]
		private string \u0003(Match \u001F)
		{
			return this.\u0002(\u0005\u000C\u0004.\u000A(\u001F));
		}

		// Token: 0x0400049D RID: 1181
		private static readonly \u001C\u0016 \u001F = new \u001C\u0016(false, null, null, null, null, \u0016\u0018\u000E.\u001F);

		// Token: 0x0400049E RID: 1182
		private readonly bool \u000A;

		// Token: 0x0400049F RID: 1183
		private readonly string \u0007;

		// Token: 0x040004A0 RID: 1184
		private readonly string \u001D;

		// Token: 0x040004A1 RID: 1185
		private readonly string \u0004;

		// Token: 0x040004A2 RID: 1186
		private readonly string \u0019;

		// Token: 0x040004A3 RID: 1187
		private readonly Regex \u0018;
	}
}

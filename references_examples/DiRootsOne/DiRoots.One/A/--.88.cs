using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using DiRoots.One.TableGen.TGRevitHelper.Script;

namespace A
{
	// Token: 0x02000141 RID: 321
	internal static class \u0011\u0016
	{
		// Token: 0x06000BC1 RID: 3009 RVA: 0x0004A8BC File Offset: 0x00048ABC
		public static bool \u001F(string \u001F)
		{
			if (\u0010\u0010\u001D.\u000A(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0016.\u001F(string)).MethodHandle;
				}
				return false;
			}
			if (\u001C\u0010\u001D.\u001D(\u001F, "<sup", StringComparison.OrdinalIgnoreCase) < 0)
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
				return \u001C\u0010\u001D.\u001D(\u001F, "<sub", StringComparison.OrdinalIgnoreCase) >= 0;
			}
			return true;
		}

		// Token: 0x06000BC2 RID: 3010 RVA: 0x0004A91C File Offset: 0x00048B1C
		public static \u001E\u0016 \u000A(string \u001F)
		{
			if (\u001F == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0016.\u000A(string)).MethodHandle;
				}
				throw \u0009\u0016\u001D.\u000A("html");
			}
			\u0011\u0016.\u001B\u0016 u001B_u;
			u001B_u.\u0007 = \u001A\u0013\u0007.\u000A();
			u001B_u.\u001D = \u0012\u0015\u0004.\u000A();
			int i = 0;
			u001B_u.\u0004 = 0;
			u001B_u.\u0019 = 0;
			\u000B\u0007\u000E.\u001F(ref u001B_u.\u001F);
			\u0006\u0018\u000E.\u001F(ref u001B_u.\u000A);
			while (i < \u001C\u000F\u0007.\u0007(\u001F))
			{
				char c = \u001E\u001E\u0007.\u001D(\u001F, i);
				if (c == '<')
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
					int num = \u0005\u0015\u0004.\u000A(\u001F, '>', i);
					if (num < 0)
					{
						IL_36A:
						\u0011\u0016.\u001D(ref u001B_u);
						\u001E\u0016 u001E_u = new \u001E\u0016(\u001A\u000C\u000A.\u000A(u001B_u.\u0007));
						IEnumerable<\u0020\u0016> u001D = u001B_u.\u001D;
						Func<\u0020\u0016, int> func;
						if ((func = \u0011\u0016.<>c.\u000A) == null)
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
							func = (\u0011\u0016.<>c.\u000A = new Func<\u0020\u0016, int>(\u0011\u0016.<>c.\u001F.\u0007));
						}
						IEnumerator<\u0020\u0016> enumerator = \u0018\u0015\u0004.\u000A(Enumerable.OrderBy<\u0020\u0016, int>(u001D, func));
						try
						{
							while (\u000A\u0017\u000A.\u000A(enumerator))
							{
								\u0020\u0016 u001F = \u0019\u0015\u0004.\u000A(enumerator);
								if (\u0004\u0015\u0004.\u000A(u001F) == ScriptType.Superscript)
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
									u001E_u.\u0004(\u001D\u0015\u0004.\u000A(u001F), \u0007\u0015\u0004.\u000A(u001F));
								}
								else
								{
									u001E_u.\u0019(\u001D\u0015\u0004.\u000A(u001F), \u0007\u0015\u0004.\u000A(u001F));
								}
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
						finally
						{
							if (enumerator != null)
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
								\u001F\u0017\u000A.\u000A(enumerator);
							}
						}
						return u001E_u;
					}
					for (;;)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
					string text = \u0003\u000B\u001D.\u0007(\u000A\u000B\u001D.\u000A(\u001F, i + 1, num - i - 1));
					bool flag = \u000F\u0015\u0004.\u000A(text, "/", StringComparison.Ordinal);
					string text2;
					if (!flag)
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
						text2 = text;
					}
					else
					{
						text2 = \u0003\u000B\u001D.\u0007(\u0010\u000B\u001D.\u000A(text, 1));
					}
					string text3 = text2;
					object u001F2 = text3;
					char[] array = \u001C\u0007\u000E.\u001F(4);
					\u001B\u000B\u001D.\u000A(array, fieldof(\u0001\u001B\u000A.\u0018).FieldHandle);
					int num2 = \u0013\u000F\u0007.\u0007(u001F2, array);
					if (num2 >= 0)
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
						text3 = \u000A\u000B\u001D.\u000A(text3, 0, num2);
					}
					if (!flag)
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
						if (\u0002\u0015\u0004.\u000A(text3, "sup", StringComparison.OrdinalIgnoreCase))
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
							int num3 = u001B_u.\u0004;
							u001B_u.\u0004 = num3 + 1;
							\u0011\u0016.\u0004(ScriptType.Superscript, ref u001B_u);
						}
						else if (\u0002\u0015\u0004.\u000A(text3, "sub", StringComparison.OrdinalIgnoreCase))
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
							int num3 = u001B_u.\u0019;
							u001B_u.\u0019 = num3 + 1;
							\u0011\u0016.\u0004(ScriptType.Subscript, ref u001B_u);
						}
						else if (\u0002\u0015\u0004.\u000A(text3, "br", StringComparison.OrdinalIgnoreCase))
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
							\u0011\u0016.\u0019("\n", ref u001B_u);
						}
					}
					else if (\u0002\u0015\u0004.\u000A(text3, "sup", StringComparison.OrdinalIgnoreCase))
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
						u001B_u.\u0004 = \u000B\u0015\u0004.\u000A(0, u001B_u.\u0004 - 1);
						if (u001B_u.\u0004 == 0)
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
							ScriptType? u000A = u001B_u.\u000A;
							ScriptType scriptType = ScriptType.Superscript;
							if (\u0016\u0015\u0004.\u000A(ref u000A) == scriptType & \u0006\u0015\u0004.\u000A(ref u000A))
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
								\u0011\u0016.\u001D(ref u001B_u);
							}
						}
					}
					else if (\u0002\u0015\u0004.\u000A(text3, "sub", StringComparison.OrdinalIgnoreCase))
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
						u001B_u.\u0019 = \u000B\u0015\u0004.\u000A(0, u001B_u.\u0019 - 1);
						if (u001B_u.\u0019 == 0)
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
							if (\u0016\u0015\u0004.\u000A(ref u001B_u.\u000A) == ScriptType.Subscript)
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
								\u0011\u0016.\u001D(ref u001B_u);
							}
						}
					}
					i = num + 1;
				}
				else
				{
					if (c == '&')
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
						int num4 = \u0005\u0015\u0004.\u000A(\u001F, ';', i);
						if (num4 > i)
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
							string text4 = \u0011\u0016.\u0007(\u000A\u000B\u001D.\u000A(\u001F, i + 1, num4 - i - 1));
							if (text4 != null)
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
								\u0011\u0016.\u0019(text4, ref u001B_u);
								i = num4 + 1;
								continue;
							}
						}
					}
					\u0011\u0016.\u0019(\u001E\u000E\u0004.\u000A(ref c), ref u001B_u);
					i++;
				}
			}
			for (;;)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				goto IL_36A;
			}
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x0004AD84 File Offset: 0x00048F84
		private static string \u0007(string \u001F)
		{
			if (\u0002\u0015\u0004.\u000A(\u001F, "nbsp", StringComparison.OrdinalIgnoreCase))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0016.\u0007(string)).MethodHandle;
				}
				return " ";
			}
			if (\u0002\u0015\u0004.\u000A(\u001F, "lt", StringComparison.OrdinalIgnoreCase))
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
				return "<";
			}
			if (\u0002\u0015\u0004.\u000A(\u001F, "gt", StringComparison.OrdinalIgnoreCase))
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
				return ">";
			}
			if (\u0002\u0015\u0004.\u000A(\u001F, "amp", StringComparison.OrdinalIgnoreCase))
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
				return "&";
			}
			if (\u0002\u0015\u0004.\u000A(\u001F, "quot", StringComparison.OrdinalIgnoreCase))
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
				return "\"";
			}
			if (\u000F\u0015\u0004.\u000A(\u001F, "#", StringComparison.Ordinal))
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
				int u001F2;
				if (\u000F\u0015\u0004.\u000A(\u001F, "#x", StringComparison.OrdinalIgnoreCase))
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
					int u001F;
					if (\u000D\u0015\u0004.\u000A(\u0010\u000B\u001D.\u000A(\u001F, 2), NumberStyles.HexNumber, null, ref u001F))
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
						return \u0003\u0015\u0004.\u000A(u001F);
					}
				}
				else if (\u001C\u0015\u0004.\u000A(\u0010\u000B\u001D.\u000A(\u001F, 1), ref u001F2))
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
					return \u0003\u0015\u0004.\u000A(u001F2);
				}
			}
			return null;
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x0004AEC8 File Offset: 0x000490C8
		[CompilerGenerated]
		internal unsafe static void \u001D(ref \u0011\u0016.\u001B\u0016 \u001F)
		{
			if (\u000A\u000A\u001D.\u000A(ref \u001F.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0016.\u001D(\u0011\u0016.\u001B\u0016*)).MethodHandle;
				}
				if (\u0006\u0015\u0004.\u000A(ref \u001F.\u000A))
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
					int num = \u001B\u0015\u0004.\u000A(ref \u001F.\u001F);
					int num2 = \u0008\u0015\u0004.\u000A(\u001F.\u0007) - num;
					if (num2 > 0)
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
						\u0010\u0015\u0004.\u000A(\u001F.\u001D, new \u0020\u0016(num, num2, \u000E\u0015\u0004.\u000A(ref \u001F.\u000A)));
					}
				}
			}
			\u000B\u0007\u000E.\u001F(ref \u001F.\u001F);
			\u0006\u0018\u000E.\u001F(ref \u001F.\u000A);
		}

		// Token: 0x06000BC5 RID: 3013 RVA: 0x0004AF74 File Offset: 0x00049174
		[CompilerGenerated]
		internal unsafe static void \u0004(ScriptType \u001F, ref \u0011\u0016.\u001B\u0016 \u000A)
		{
			if (\u0006\u0015\u0004.\u000A(ref \u000A.\u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0016.\u0004(ScriptType, \u0011\u0016.\u001B\u0016*)).MethodHandle;
				}
				if (\u000E\u0015\u0004.\u000A(ref \u000A.\u000A) != \u001F)
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
					\u0011\u0016.\u001D(ref \u000A);
				}
			}
			if (!\u000A\u000A\u001D.\u000A(ref \u000A.\u001F))
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
				\u000A.\u001F = new int?(\u0008\u0015\u0004.\u000A(\u000A.\u0007));
				\u000A.\u000A = new ScriptType?(\u001F);
			}
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x0004B000 File Offset: 0x00049200
		[CompilerGenerated]
		internal unsafe static void \u0019(string \u001F, ref \u0011\u0016.\u001B\u0016 \u000A)
		{
			if (\u001A\u0006\u0007.\u000A(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0016.\u0019(string, \u0011\u0016.\u001B\u0016*)).MethodHandle;
				}
				return;
			}
			if (\u000A.\u0004 > 0)
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
				if (\u000A.\u0019 > 0)
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
					\u000A.\u0019 = 0;
				}
			}
			if (\u000A.\u0004 > 0)
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
				\u0011\u0016.\u0004(ScriptType.Superscript, ref \u000A);
			}
			else if (\u000A.\u0019 > 0)
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
				\u0011\u0016.\u0004(ScriptType.Subscript, ref \u000A);
			}
			else
			{
				\u0011\u0016.\u001D(ref \u000A);
			}
			\u001E\u0013\u0007.\u000A(\u000A.\u0007, \u001F);
		}

		// Token: 0x0200081C RID: 2076
		[CompilerGenerated]
		[StructLayout(LayoutKind.Auto)]
		private struct \u001B\u0016
		{
			// Token: 0x04002075 RID: 8309
			public int? \u001F;

			// Token: 0x04002076 RID: 8310
			public ScriptType? \u000A;

			// Token: 0x04002077 RID: 8311
			public StringBuilder \u0007;

			// Token: 0x04002078 RID: 8312
			public List<\u0020\u0016> \u001D;

			// Token: 0x04002079 RID: 8313
			public int \u0004;

			// Token: 0x0400207A RID: 8314
			public int \u0019;
		}
	}
}

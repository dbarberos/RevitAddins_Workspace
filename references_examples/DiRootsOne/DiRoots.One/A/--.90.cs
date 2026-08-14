using System;
using DiRoots.One.Commons.Interfaces;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x02000144 RID: 324
	internal static class \u0017\u0016
	{
		// Token: 0x06000BD5 RID: 3029 RVA: 0x0004B3E4 File Offset: 0x000495E4
		public static \u001E\u0016 \u001F(IRange \u001F, \u001C\u0016 \u000A = null)
		{
			string text = \u0017\u0016.\u0018(\u001F);
			try
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u0016.\u001F(IRange, \u001C\u0016)).MethodHandle;
					}
					throw \u0009\u0016\u001D.\u000A("cell");
				}
				bool flag;
				if (\u000A != null)
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
					if (\u000A.\u0016)
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
						flag = \u0017\u0016.\u000A(\u001F);
						goto IL_58;
					}
				}
				flag = false;
				IL_58:
				if (flag)
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
					text = \u000A.\u000B(text);
				}
				if (\u001A\u0006\u0007.\u000A(text))
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
					return new \u001E\u0016(string.Empty);
				}
				IRichTextString richTextString = \u0014\u0015\u0004.\u000A(\u001F);
				if (richTextString != null)
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
					if (\u0017\u0016.\u0007(richTextString))
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
						return \u0017\u0016.\u001D(\u001F);
					}
				}
				string u001F;
				if (\u0017\u0016.\u0004(\u001F, out u001F))
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
					if (\u0011\u0016.\u001F(u001F))
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
						return \u0011\u0016.\u000A(u001F);
					}
				}
				return \u0017\u0016.\u0019(\u001F, text);
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u001F.GetService<ICustomLogger>(false), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Script\\ScriptedTextReader.cs", "ReadScriptedText");
			}
			return new \u001E\u0016(text);
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x0004B534 File Offset: 0x00049734
		private static bool \u000A(IRange \u001F)
		{
			bool result;
			try
			{
				bool flag;
				if (!\u001A\u0015\u0004.\u000A(\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u0016.\u000A(IRange)).MethodHandle;
					}
					flag = \u0013\u0015\u0004.\u000A(\u001F);
				}
				else
				{
					flag = true;
				}
				result = flag;
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Script\\ScriptedTextReader.cs", "IsNumericCell");
				result = false;
			}
			return result;
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x0004B59C File Offset: 0x0004979C
		private static bool \u0007(IRichTextString \u001F)
		{
			try
			{
				\u0015\u0015\u0004.\u000A(\u001F);
				return \u000C\u0015\u0004.\u000A(\u001F);
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Script\\ScriptedTextReader.cs", "GetRichTextIsFormattedSafe");
			}
			return false;
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x0004B5EC File Offset: 0x000497EC
		private static \u001E\u0016 \u001D(IRange \u001F)
		{
			string text;
			if ((text = \u0015\u0015\u0004.\u000A(\u0014\u0015\u0004.\u000A(\u001F))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u0016.\u001D(IRange)).MethodHandle;
				}
				text = string.Empty;
			}
			string u001F = text;
			\u001E\u0016 u001E_u = new \u001E\u0016(u001F);
			int num = \u001C\u000F\u0007.\u0007(u001F);
			int i = 0;
			IL_194:
			while (i < num)
			{
				IFont font = \u001F\u0001\u0004.\u000A(\u0014\u0015\u0004.\u000A(\u001F), i);
				bool flag;
				if (font == null)
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
					flag = false;
				}
				else
				{
					flag = \u0009\u0015\u0004.\u000A(font);
				}
				bool flag2 = flag;
				bool flag3;
				if (font == null)
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
					flag3 = false;
				}
				else
				{
					flag3 = \u0001\u0015\u0004.\u000A(font);
				}
				bool flag4 = flag3;
				if (!flag2)
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
					if (!flag4)
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
						i++;
						continue;
					}
				}
				if (flag2 && flag4)
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
					flag4 = false;
				}
				int num2 = i;
				i++;
				while (i < num)
				{
					IFont font2 = \u001F\u0001\u0004.\u000A(\u0014\u0015\u0004.\u000A(\u001F), i);
					bool flag5;
					if (font2 == null)
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
						flag5 = false;
					}
					else
					{
						flag5 = \u0009\u0015\u0004.\u000A(font2);
					}
					bool flag6 = flag5;
					bool flag7;
					if (font2 == null)
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
						flag7 = false;
					}
					else
					{
						flag7 = \u0001\u0015\u0004.\u000A(font2);
					}
					bool flag8 = flag7;
					if (flag2 && flag6)
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
						if (!flag8)
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
							i++;
							continue;
						}
					}
					if (flag4 && flag8)
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
						if (!flag6)
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
							i++;
							continue;
						}
					}
					IL_165:
					int u000A = i - num2;
					if (flag2)
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
						u001E_u.\u0004(num2, u000A);
						goto IL_194;
					}
					u001E_u.\u0019(num2, u000A);
					goto IL_194;
				}
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					goto IL_165;
				}
			}
			for (;;)
			{
				switch (5)
				{
				case 0:
					continue;
				}
				break;
			}
			return u001E_u;
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x0004B7A0 File Offset: 0x000499A0
		private static bool \u0004(IRange \u001F, out string \u000A)
		{
			\u000A = null;
			try
			{
				\u000A = \u0001\u0017\u001D.\u000A(\u001F);
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Script\\ScriptedTextReader.cs", "TryGetHtmlString");
			}
			return !\u001A\u0006\u0007.\u000A(\u000A);
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x0004B7F4 File Offset: 0x000499F4
		private static \u001E\u0016 \u0019(IRange \u001F, string \u000A)
		{
			\u001E\u0016 u001E_u = new \u001E\u0016(\u000A);
			IStyle style = \u001F\u0014\u001D.\u000A(\u001F);
			IFont font;
			if (style == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u0016.\u0019(IRange, string)).MethodHandle;
				}
				font = \u0012\u0018\u000E.\u001F;
			}
			else
			{
				font = \u0009\u0017\u001D.\u000A(style);
			}
			IFont font2 = font;
			if (!\u001A\u0006\u0007.\u000A(\u000A))
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
				if (font2 != null)
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
					if (\u0009\u0015\u0004.\u000A(font2))
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
						u001E_u.\u0004(0, \u001C\u000F\u0007.\u0007(\u000A));
					}
					else if (\u0001\u0015\u0004.\u000A(font2))
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
						u001E_u.\u0019(0, \u001C\u000F\u0007.\u0007(\u000A));
					}
				}
			}
			return u001E_u;
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x0004B8A8 File Offset: 0x00049AA8
		private static string \u0018(IRange \u001F)
		{
			string result = string.Empty;
			try
			{
				result = \u0007\u000C\u001D.\u000A(\u001F);
			}
			catch (Exception u000A)
			{
				result = \u0012\u000A\u0004.\u000A(\u001F);
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Script\\ScriptedTextReader.cs", "TryGetDisplayText");
			}
			return result;
		}
	}
}

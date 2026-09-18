using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.TableGen.TGRevitHelper.Script;

namespace A
{
	// Token: 0x02000145 RID: 325
	internal static class \u0014\u0016
	{
		// Token: 0x06000BDC RID: 3036 RVA: 0x0004B8FC File Offset: 0x00049AFC
		// Note: this type is marked as 'beforefieldinit'.
		static \u0014\u0016()
		{
			Dictionary<char, char> dictionary = \u0007\u0001\u0004.\u000A();
			\u000A\u0001\u0004.\u000A(dictionary, '0', '⁰');
			\u000A\u0001\u0004.\u000A(dictionary, '1', '¹');
			\u000A\u0001\u0004.\u000A(dictionary, '2', '²');
			\u000A\u0001\u0004.\u000A(dictionary, '3', '³');
			\u000A\u0001\u0004.\u000A(dictionary, '4', '⁴');
			\u000A\u0001\u0004.\u000A(dictionary, '5', '⁵');
			\u000A\u0001\u0004.\u000A(dictionary, '6', '⁶');
			\u000A\u0001\u0004.\u000A(dictionary, '7', '⁷');
			\u000A\u0001\u0004.\u000A(dictionary, '8', '⁸');
			\u000A\u0001\u0004.\u000A(dictionary, '9', '⁹');
			\u000A\u0001\u0004.\u000A(dictionary, 'a', 'ᵃ');
			\u000A\u0001\u0004.\u000A(dictionary, 'b', 'ᵇ');
			\u000A\u0001\u0004.\u000A(dictionary, 'c', 'ᶜ');
			\u000A\u0001\u0004.\u000A(dictionary, 'd', 'ᵈ');
			\u000A\u0001\u0004.\u000A(dictionary, 'e', 'ᵉ');
			\u000A\u0001\u0004.\u000A(dictionary, 'f', 'ᶠ');
			\u000A\u0001\u0004.\u000A(dictionary, 'g', 'ᵍ');
			\u000A\u0001\u0004.\u000A(dictionary, 'h', 'ʰ');
			\u000A\u0001\u0004.\u000A(dictionary, 'i', 'ⁱ');
			\u000A\u0001\u0004.\u000A(dictionary, 'j', 'ʲ');
			\u000A\u0001\u0004.\u000A(dictionary, 'k', 'ᵏ');
			\u000A\u0001\u0004.\u000A(dictionary, 'l', 'ˡ');
			\u000A\u0001\u0004.\u000A(dictionary, 'm', 'ᵐ');
			\u000A\u0001\u0004.\u000A(dictionary, 'n', 'ⁿ');
			\u000A\u0001\u0004.\u000A(dictionary, 'o', 'ᵒ');
			\u000A\u0001\u0004.\u000A(dictionary, 'p', 'ᵖ');
			\u000A\u0001\u0004.\u000A(dictionary, 'r', 'ʳ');
			\u000A\u0001\u0004.\u000A(dictionary, 's', 'ˢ');
			\u000A\u0001\u0004.\u000A(dictionary, 't', 'ᵗ');
			\u000A\u0001\u0004.\u000A(dictionary, 'u', 'ᵘ');
			\u000A\u0001\u0004.\u000A(dictionary, 'v', 'ᵛ');
			\u000A\u0001\u0004.\u000A(dictionary, 'w', 'ʷ');
			\u000A\u0001\u0004.\u000A(dictionary, 'x', 'ˣ');
			\u000A\u0001\u0004.\u000A(dictionary, 'y', 'ʸ');
			\u000A\u0001\u0004.\u000A(dictionary, 'z', 'ᶻ');
			\u000A\u0001\u0004.\u000A(dictionary, 'A', 'ᴬ');
			\u000A\u0001\u0004.\u000A(dictionary, 'B', 'ᴮ');
			\u000A\u0001\u0004.\u000A(dictionary, 'D', 'ᴰ');
			\u000A\u0001\u0004.\u000A(dictionary, 'E', 'ᴱ');
			\u000A\u0001\u0004.\u000A(dictionary, 'G', 'ᴳ');
			\u000A\u0001\u0004.\u000A(dictionary, 'H', 'ᴴ');
			\u000A\u0001\u0004.\u000A(dictionary, 'I', 'ᴵ');
			\u000A\u0001\u0004.\u000A(dictionary, 'J', 'ᴶ');
			\u000A\u0001\u0004.\u000A(dictionary, 'K', 'ᴷ');
			\u000A\u0001\u0004.\u000A(dictionary, 'L', 'ᴸ');
			\u000A\u0001\u0004.\u000A(dictionary, 'M', 'ᴹ');
			\u000A\u0001\u0004.\u000A(dictionary, 'N', 'ᴺ');
			\u000A\u0001\u0004.\u000A(dictionary, 'O', 'ᴼ');
			\u000A\u0001\u0004.\u000A(dictionary, 'P', 'ᴾ');
			\u000A\u0001\u0004.\u000A(dictionary, 'R', 'ᴿ');
			\u000A\u0001\u0004.\u000A(dictionary, 'T', 'ᵀ');
			\u000A\u0001\u0004.\u000A(dictionary, 'U', 'ᵁ');
			\u000A\u0001\u0004.\u000A(dictionary, 'V', 'ᵛ');
			\u000A\u0001\u0004.\u000A(dictionary, 'W', 'ᵂ');
			\u000A\u0001\u0004.\u000A(dictionary, '+', '⁺');
			\u000A\u0001\u0004.\u000A(dictionary, '-', '⁻');
			\u000A\u0001\u0004.\u000A(dictionary, '=', '⁼');
			\u000A\u0001\u0004.\u000A(dictionary, '(', '⁽');
			\u000A\u0001\u0004.\u000A(dictionary, ')', '⁾');
			\u0014\u0016.\u000A = dictionary;
			Dictionary<char, char> dictionary2 = \u0007\u0001\u0004.\u000A();
			\u000A\u0001\u0004.\u000A(dictionary2, '0', '₀');
			\u000A\u0001\u0004.\u000A(dictionary2, '1', '₁');
			\u000A\u0001\u0004.\u000A(dictionary2, '2', '₂');
			\u000A\u0001\u0004.\u000A(dictionary2, '3', '₃');
			\u000A\u0001\u0004.\u000A(dictionary2, '4', '₄');
			\u000A\u0001\u0004.\u000A(dictionary2, '5', '₅');
			\u000A\u0001\u0004.\u000A(dictionary2, '6', '₆');
			\u000A\u0001\u0004.\u000A(dictionary2, '7', '₇');
			\u000A\u0001\u0004.\u000A(dictionary2, '8', '₈');
			\u000A\u0001\u0004.\u000A(dictionary2, '9', '₉');
			\u000A\u0001\u0004.\u000A(dictionary2, 'a', 'ₐ');
			\u000A\u0001\u0004.\u000A(dictionary2, 'e', 'ₑ');
			\u000A\u0001\u0004.\u000A(dictionary2, 'h', 'ₕ');
			\u000A\u0001\u0004.\u000A(dictionary2, 'i', 'ᵢ');
			\u000A\u0001\u0004.\u000A(dictionary2, 'j', 'ⱼ');
			\u000A\u0001\u0004.\u000A(dictionary2, 'k', 'ₖ');
			\u000A\u0001\u0004.\u000A(dictionary2, 'l', 'ₗ');
			\u000A\u0001\u0004.\u000A(dictionary2, 'm', 'ₘ');
			\u000A\u0001\u0004.\u000A(dictionary2, 'n', 'ₙ');
			\u000A\u0001\u0004.\u000A(dictionary2, 'o', 'ₒ');
			\u000A\u0001\u0004.\u000A(dictionary2, 'p', 'ₚ');
			\u000A\u0001\u0004.\u000A(dictionary2, 'r', 'ᵣ');
			\u000A\u0001\u0004.\u000A(dictionary2, 's', 'ₛ');
			\u000A\u0001\u0004.\u000A(dictionary2, 't', 'ₜ');
			\u000A\u0001\u0004.\u000A(dictionary2, 'u', 'ᵤ');
			\u000A\u0001\u0004.\u000A(dictionary2, 'v', 'ᵥ');
			\u000A\u0001\u0004.\u000A(dictionary2, 'x', 'ₓ');
			\u000A\u0001\u0004.\u000A(dictionary2, '+', '₊');
			\u000A\u0001\u0004.\u000A(dictionary2, '-', '₋');
			\u000A\u0001\u0004.\u000A(dictionary2, '=', '₌');
			\u000A\u0001\u0004.\u000A(dictionary2, '(', '₍');
			\u000A\u0001\u0004.\u000A(dictionary2, ')', '₎');
			\u0014\u0016.\u0007 = dictionary2;
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x0004BDC0 File Offset: 0x00049FC0
		public static void \u001D(TextNote \u001F, \u001E\u0016 \u000A, ScriptRenderMode \u0007)
		{
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u0016.\u001D(TextNote, \u001E\u0016, ScriptRenderMode)).MethodHandle;
				}
				throw \u0009\u0016\u001D.\u000A("note");
			}
			if (\u000A == null)
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
				throw \u0009\u0016\u001D.\u000A("scripted");
			}
			try
			{
				if (\u0007 == ScriptRenderMode.Supported)
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
					\u0014\u0016.\u0019(\u001F, \u000A);
					return;
				}
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u001F.GetService<ICustomLogger>(false), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Script\\ScriptedTextRenderer.cs", "ApplyToTextNote");
			}
			\u001D\u0001\u0004.\u000A(\u001F, \u000A\u0014\u001D.\u001D(\u000A));
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x0004BE64 File Offset: 0x0004A064
		public static string \u0004(\u001E\u0016 \u001F, ScriptRenderMode \u000A)
		{
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u0016.\u0004(\u001E\u0016, ScriptRenderMode)).MethodHandle;
				}
				throw \u0009\u0016\u001D.\u000A("scripted");
			}
			string u000A = \u000A\u0014\u001D.\u001D(\u001F);
			if (\u000A == ScriptRenderMode.FallbackUnicode)
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
				try
				{
					u000A = \u0014\u0016.\u0018(\u001F);
				}
				catch (Exception u000A2)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u001F.GetService<ICustomLogger>(false), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Script\\ScriptedTextRenderer.cs", "ApplyUnicodeToText");
				}
			}
			return \u0004\u001E\u000A.\u000A("‌", u000A);
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x0004BEF4 File Offset: 0x0004A0F4
		private static void \u0019(TextNote \u001F, \u001E\u0016 \u000A)
		{
			\u001D\u0001\u0004.\u000A(\u001F, \u000A\u0014\u001D.\u001D(\u000A));
			FormattedText formattedText = \u0016\u0001\u0004.\u000A(\u001F);
			IEnumerator<\u0020\u0016> enumerator = \u0018\u0015\u0004.\u000A(\u000A.\u0018());
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u0020\u0016 u001F = \u0019\u0015\u0004.\u000A(enumerator);
					TextRange u000A = \u0005\u0001\u0004.\u000A(\u001D\u0015\u0004.\u000A(u001F), \u0007\u0015\u0004.\u000A(u001F));
					if (\u0004\u0015\u0004.\u000A(u001F) == ScriptType.Superscript)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u0016.\u0019(TextNote, \u001E\u0016)).MethodHandle;
						}
						\u0019\u0001\u0004.\u000A(formattedText, u000A, false);
						\u0018\u0001\u0004.\u000A(formattedText, u000A, true);
					}
					else
					{
						\u0018\u0001\u0004.\u000A(formattedText, u000A, false);
						\u0019\u0001\u0004.\u000A(formattedText, u000A, true);
					}
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			\u0004\u0001\u0004.\u000A(\u001F, formattedText);
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x0004BFCC File Offset: 0x0004A1CC
		private static string \u0018(\u001E\u0016 \u001F)
		{
			char[] array = \u001A\u000F\u0007.\u001D(\u000A\u0014\u001D.\u001D(\u001F));
			IEnumerator<\u0020\u0016> enumerator = \u0018\u0015\u0004.\u000A(\u001F.\u0018());
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u0020\u0016 u001F = \u0019\u0015\u0004.\u000A(enumerator);
					Dictionary<char, char> dictionary;
					if (\u0004\u0015\u0004.\u000A(u001F) != ScriptType.Superscript)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0014\u0016.\u0018(\u001E\u0016)).MethodHandle;
						}
						dictionary = \u0014\u0016.\u0007;
					}
					else
					{
						dictionary = \u0014\u0016.\u000A;
					}
					Dictionary<char, char> u001F2 = dictionary;
					int num = \u001D\u0015\u0004.\u000A(u001F) + \u0007\u0015\u0004.\u000A(u001F);
					for (int i = \u001D\u0015\u0004.\u000A(u001F); i < num; i++)
					{
						if (!\u0003\u0001\u0004.\u000A(u001F2, array[i]))
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
							char c;
							if (\u0012\u0001\u0004.\u000A(u001F2, array[i], ref c))
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
								array[i] = c;
							}
							else
							{
								\u0006\u0001\u0004.\u000A(\u000F\u0001\u0004.\u000A(u001F), array[i]);
							}
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
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			object u001F3 = \u0002\u0001\u0004.\u000A(\u001F);
			IEnumerable<\u0020\u0016> u001D = \u001F.\u001D;
			Func<\u0020\u0016, bool> func;
			if ((func = \u0014\u0016.<>c.\u000A) == null)
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
				func = (\u0014\u0016.<>c.\u000A = new Func<\u0020\u0016, bool>(\u0014\u0016.<>c.\u001F.\u0007));
			}
			\u000B\u0001\u0004.\u000A(u001F3, Enumerable.Where<\u0020\u0016>(u001D, func));
			return \u0013\u0006\u001D.\u000A(array);
		}

		// Token: 0x040004BB RID: 1211
		internal static string \u001F;

		// Token: 0x040004BC RID: 1212
		private static readonly Dictionary<char, char> \u000A;

		// Token: 0x040004BD RID: 1213
		private static readonly Dictionary<char, char> \u0007;
	}
}

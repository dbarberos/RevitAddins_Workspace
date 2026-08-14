using System;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace A
{
	// Token: 0x020000E8 RID: 232
	internal static class \u000F\u0011\u0018
	{
		// Token: 0x06000BA7 RID: 2983 RVA: 0x00047438 File Offset: 0x00045638
		internal static string \u000C()
		{
			string text = \u000F\u0011\u0018.\u0018();
			if (\u001F\u001A\u0018.\u0018(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0011\u0018.\u000C()).MethodHandle;
				}
				text = \u000F\u0011\u0018.\u000F();
			}
			return text;
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x00047474 File Offset: 0x00045674
		private static string \u0018()
		{
			return \u001E\u0015\u0016.\u0018(\u0009\u0015\u0014.\u0018(\u0011\u001F\u0014.\u0018()));
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x00047498 File Offset: 0x00045698
		internal static string \u0014()
		{
			string u000C = \u0002\u0015\u0016.\u0018(\u0009\u0015\u0014.\u0018(\u0011\u001F\u0014.\u0018()));
			if (\u001F\u001A\u0018.\u0018(u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0011\u0018.\u0014()).MethodHandle;
				}
				u000C = \u000F\u0011\u0018.\u0016();
			}
			return \u000F\u0011\u0018.\u0003(u000C);
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x000474E8 File Offset: 0x000456E8
		private static string \u0003(string \u000C)
		{
			byte[] u = \u0019\u0015\u0016.\u0018(\u001D\u0012\u0003.\u0018(), \u000C);
			SHA512 sha = \u000B\u0015\u0016.\u0018();
			string result;
			try
			{
				byte[] array = \u001A\u0015\u0016.\u0018(sha, u);
				StringBuilder u000C = \u001D\u0015\u0016.\u0018(128);
				byte[] array2 = array;
				for (int i = 0; i < (int)\u0010\u0010\u000F.\u000C(array2); i++)
				{
					byte b = array2[i];
					\u0017\u0020\u0014.\u0018(u000C, \u0004\u0015\u0016.\u0018(ref b, "X2"));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0011\u0018.\u0003(string)).MethodHandle;
				}
				result = \u0001\u0017\u0018.\u0018(u000C);
			}
			finally
			{
				if (sha != null)
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
					\u0020\u001E\u0018.\u0018(sha);
				}
			}
			return result;
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x000475A0 File Offset: 0x000457A0
		private static string \u0016()
		{
			string result = "";
			NetworkInterface[] array = \u0008\u0015\u0016.\u0018();
			for (int i = 0; i < (int)\u0007\u0010\u000F.\u000C(array); i++)
			{
				NetworkInterface u000C = array[i];
				if (\u0006\u0015\u0016.\u0018(u000C) == 1)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0011\u0018.\u0016()).MethodHandle;
					}
					if (!\u000A\u0017\u0014.\u0018(\u0010\u0015\u0016.\u0018(u000C), "Virtual"))
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
						if (!\u000A\u0017\u0014.\u0018(\u0010\u0015\u0016.\u0018(u000C), "Pseudo"))
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
							if (\u0009\u001E\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u0007\u0015\u0016.\u0018(u000C)), ""))
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
								return \u0001\u0017\u0018.\u0018(\u0007\u0015\u0016.\u0018(u000C));
							}
						}
					}
				}
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
			return result;
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x00047680 File Offset: 0x00045880
		private static string \u000F()
		{
			string u000C = \u000F\u0011\u0018.\u0016();
			if (\u001F\u001A\u0018.\u0018(u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0011\u0018.\u000F()).MethodHandle;
				}
				return string.Empty;
			}
			return \u000F\u0011\u0018.\u0003(u000C);
		}
	}
}

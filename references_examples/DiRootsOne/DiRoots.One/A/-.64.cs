using System;
using System.IO;
using System.Security.Cryptography;

namespace A
{
	// Token: 0x020001F2 RID: 498
	internal static class \u0009\u0006
	{
		// Token: 0x060012AB RID: 4779 RVA: 0x0006B940 File Offset: 0x00069B40
		internal static string \u001F(string \u001F, string \u000A)
		{
			byte[] u001F = \u0020\u0005\u0018.\u000A(\u0002\u000B\u001D.\u000A(), \u001F);
			byte[] array = \u0019\u0015\u0010.\u001F(13);
			\u001B\u000B\u001D.\u000A(array, fieldof(\u0001\u001B\u000A.\u0007).FieldHandle);
			PasswordDeriveBytes u001F2 = \u001E\u0005\u0018.\u000A(\u000A, array);
			return \u001B\u0005\u0018.\u000A(\u0009\u0006.\u001F(u001F, \u0011\u0005\u0018.\u000A(u001F2, 32), \u0011\u0005\u0018.\u000A(u001F2, 16)));
		}

		// Token: 0x060012AC RID: 4780 RVA: 0x0006B9A0 File Offset: 0x00069BA0
		internal static string \u000A(string \u001F, string \u000A)
		{
			byte[] u001F = \u0017\u0005\u0018.\u000A(\u001F);
			byte[] array = \u0019\u0015\u0010.\u001F(13);
			\u001B\u000B\u001D.\u000A(array, fieldof(\u0001\u001B\u000A.\u0007).FieldHandle);
			PasswordDeriveBytes u001F2 = \u001E\u0005\u0018.\u000A(\u000A, array);
			byte[] u000A = \u0009\u0006.\u000A(u001F, \u0011\u0005\u0018.\u000A(u001F2, 32), \u0011\u0005\u0018.\u000A(u001F2, 16));
			return \u0018\u000B\u001D.\u000A(\u0002\u000B\u001D.\u000A(), u000A);
		}

		// Token: 0x060012AD RID: 4781 RVA: 0x0006BA00 File Offset: 0x00069C00
		private static byte[] \u001F(byte[] \u001F, byte[] \u000A, byte[] \u0007)
		{
			MemoryStream memoryStream = \u0003\u0002\u001D.\u000A();
			byte[] result;
			try
			{
				Rijndael rijndael = \u0001\u0005\u0018.\u000A();
				try
				{
					\u0015\u0005\u0018.\u000A(rijndael, \u000A);
					\u000C\u0005\u0018.\u000A(rijndael, \u0007);
					CryptoStream cryptoStream = \u0013\u0005\u0018.\u000A(memoryStream, \u001A\u0005\u0018.\u000A(rijndael), 1);
					try
					{
						\u0014\u0005\u0018.\u000A(cryptoStream, \u001F, 0, (int)\u0017\u0007\u000E.\u001F(\u001F));
					}
					finally
					{
						if (cryptoStream != null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u0006.\u001F(byte[], byte[], byte[])).MethodHandle;
							}
							\u001F\u0017\u000A.\u000A(cryptoStream);
						}
					}
					result = \u000B\u0002\u001D.\u000A(memoryStream);
				}
				finally
				{
					if (rijndael != null)
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
						\u001F\u0017\u000A.\u000A(rijndael);
					}
				}
			}
			finally
			{
				if (memoryStream != null)
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
					\u001F\u0017\u000A.\u000A(memoryStream);
				}
			}
			return result;
		}

		// Token: 0x060012AE RID: 4782 RVA: 0x0006BAC8 File Offset: 0x00069CC8
		private static byte[] \u000A(byte[] \u001F, byte[] \u000A, byte[] \u0007)
		{
			MemoryStream memoryStream = \u0003\u0002\u001D.\u000A();
			byte[] result;
			try
			{
				Rijndael rijndael = \u0001\u0005\u0018.\u000A();
				try
				{
					\u0015\u0005\u0018.\u000A(rijndael, \u000A);
					\u000C\u0005\u0018.\u000A(rijndael, \u0007);
					CryptoStream cryptoStream = \u0013\u0005\u0018.\u000A(memoryStream, \u0009\u0005\u0018.\u000A(rijndael), 1);
					try
					{
						\u0014\u0005\u0018.\u000A(cryptoStream, \u001F, 0, (int)\u0017\u0007\u000E.\u001F(\u001F));
					}
					finally
					{
						if (cryptoStream != null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u0006.\u000A(byte[], byte[], byte[])).MethodHandle;
							}
							\u001F\u0017\u000A.\u000A(cryptoStream);
						}
					}
					result = \u000B\u0002\u001D.\u000A(memoryStream);
				}
				finally
				{
					if (rijndael != null)
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
						\u001F\u0017\u000A.\u000A(rijndael);
					}
				}
			}
			finally
			{
				if (memoryStream != null)
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
					\u001F\u0017\u000A.\u000A(memoryStream);
				}
			}
			return result;
		}
	}
}

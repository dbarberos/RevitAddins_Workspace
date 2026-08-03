using System;
using System.IO;
using System.IO.Packaging;
using System.Text;

namespace A
{
	// Token: 0x020000AF RID: 175
	internal sealed class \u001E\u0004
	{
		// Token: 0x060006CC RID: 1740 RVA: 0x00027440 File Offset: 0x00025640
		private \u001E\u0004()
		{
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x00027454 File Offset: 0x00025654
		internal static string \u001F(string \u001F)
		{
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0004.\u001F(string)).MethodHandle;
				}
				throw \u0009\u0016\u001D.\u000A("path");
			}
			if (\u001C\u000F\u0007.\u0007(\u001F) == 0)
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
				return \u001F;
			}
			if (!\u0001\u0016\u001D.\u000A(\u001F, "\\"))
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
				return \u0017\u0006\u0007.\u000A("{0}\\", \u001F);
			}
			return \u001F;
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x000274C4 File Offset: 0x000256C4
		internal static int \u000A(string \u001F, char \u000A)
		{
			int num = 0;
			for (int i = 0; i < \u001C\u000F\u0007.\u0007(\u001F); i++)
			{
				char c = \u001E\u001E\u0007.\u001D(\u001F, i);
				if (\u001F\u000B\u001D.\u000A(ref c, \u000A))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0004.\u000A(string, char)).MethodHandle;
					}
					num++;
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
			return num;
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x00027520 File Offset: 0x00025720
		internal static string \u0007(string \u001F, int \u000A, int \u0007, char \u001D, int \u0004)
		{
			if (\u0004 == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0004.\u0007(string, int, int, char, int)).MethodHandle;
				}
				return \u001F;
			}
			if (\u001E\u0004.\u000A(\u001F, \u001D) < \u0004)
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
				return \u001F;
			}
			int num = 0;
			for (int i = \u000A; i < \u0007; i++)
			{
				char c = \u001E\u001E\u0007.\u001D(\u001F, i);
				if (\u001F\u000B\u001D.\u000A(ref c, \u001D))
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
					num++;
				}
				if (num == \u0004)
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
					return \u000A\u000B\u001D.\u000A(\u001F, \u000A, i + 1);
				}
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
			return \u001F;
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x000275B8 File Offset: 0x000257B8
		internal static string \u0007(string \u001F, char \u000A, int \u0007)
		{
			int u000A = 0;
			int u = \u001C\u000F\u0007.\u0007(\u001F) - 1;
			return \u001E\u0004.\u0007(\u001F, u000A, u, \u000A, \u0007);
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x000275E0 File Offset: 0x000257E0
		internal static string \u001D(string \u001F)
		{
			StringBuilder u001F = \u001A\u0013\u0007.\u000A();
			char[] array = \u001A\u000F\u0007.\u001D(\u001F);
			for (int i = 0; i < (int)\u0014\u0007\u000E.\u001F(array); i++)
			{
				char c = array[i];
				int num = (int)c;
				if (num >= 32)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0004.\u001D(string)).MethodHandle;
					}
					if (num <= 126)
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
						\u0007\u000B\u001D.\u000A(u001F, c);
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
			return \u001A\u000C\u000A.\u000A(u001F);
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x00027660 File Offset: 0x00025860
		internal static string \u0004(StreamInfo \u001F)
		{
			Stream stream = \u0019\u000B\u001D.\u000A(\u001F, FileMode.Open, FileAccess.Read);
			string result;
			try
			{
				StringBuilder u001F = \u001A\u0013\u0007.\u000A();
				int num;
				while ((num = \u001D\u000B\u001D.\u000A(stream)) >= 0)
				{
					byte b = (byte)num;
					\u0004\u000B\u001D.\u000A(u001F, "{0:X2}", b);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0004.\u0004(StreamInfo)).MethodHandle;
				}
				result = \u001A\u000C\u000A.\u000A(u001F);
			}
			finally
			{
				if (stream != null)
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
					\u001F\u0017\u000A.\u000A(stream);
				}
			}
			return result;
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x000276EC File Offset: 0x000258EC
		internal static string \u0019(StreamInfo \u001F)
		{
			Stream stream = \u0019\u000B\u001D.\u000A(\u001F, FileMode.Open, FileAccess.Read);
			string result;
			try
			{
				byte[] array = \u0019\u0015\u0010.\u001F((int)(checked((IntPtr)\u000B\u000B\u001D.\u000A(stream))));
				\u0016\u000B\u001D.\u000A(stream, array, 0, (int)\u0017\u0007\u000E.\u001F(array));
				result = \u0018\u000B\u001D.\u000A(\u0005\u000B\u001D.\u000A(), array);
			}
			finally
			{
				if (stream != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0004.\u0019(StreamInfo)).MethodHandle;
					}
					\u001F\u0017\u000A.\u000A(stream);
				}
			}
			return result;
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x0002776C File Offset: 0x0002596C
		internal static string \u0018(StreamInfo \u001F)
		{
			Stream stream = \u0019\u000B\u001D.\u000A(\u001F, FileMode.Open, FileAccess.Read);
			string result;
			try
			{
				byte[] array = \u0019\u0015\u0010.\u001F((int)(checked((IntPtr)\u000B\u000B\u001D.\u000A(stream))));
				\u0016\u000B\u001D.\u000A(stream, array, 0, (int)\u0017\u0007\u000E.\u001F(array));
				result = \u0018\u000B\u001D.\u000A(\u0002\u000B\u001D.\u000A(), array);
			}
			finally
			{
				if (stream != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0004.\u0018(StreamInfo)).MethodHandle;
					}
					\u001F\u0017\u000A.\u000A(stream);
				}
			}
			return result;
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x000277EC File Offset: 0x000259EC
		internal static byte[] \u0005(StreamInfo \u001F)
		{
			Stream stream = \u0019\u000B\u001D.\u000A(\u001F, FileMode.Open, FileAccess.Read);
			byte[] result;
			try
			{
				byte[] array = \u0019\u0015\u0010.\u001F((int)(checked((IntPtr)\u000B\u000B\u001D.\u000A(stream))));
				\u0016\u000B\u001D.\u000A(stream, array, 0, (int)\u0017\u0007\u000E.\u001F(array));
				result = array;
			}
			finally
			{
				if (stream != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0004.\u0005(StreamInfo)).MethodHandle;
					}
					\u001F\u0017\u000A.\u000A(stream);
				}
			}
			return result;
		}
	}
}

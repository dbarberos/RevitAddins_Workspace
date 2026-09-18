using System;
using System.IO;

namespace A
{
	// Token: 0x02000206 RID: 518
	internal static class \u0011\u0012
	{
		// Token: 0x06001350 RID: 4944 RVA: 0x0007B3FC File Offset: 0x000795FC
		internal static void \u0007(string \u001F)
		{
			try
			{
				StreamWriter streamWriter = \u0011\u0017\u0018.\u000A(\u0004\u001E\u000A.\u000A(\u0004\u000F.\u0004(), "//path.txt"));
				try
				{
					\u001B\u0017\u0018.\u000A(streamWriter, \u001F);
					\u0008\u0017\u0018.\u000A(streamWriter);
				}
				finally
				{
					if (streamWriter != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0012.\u0007(string)).MethodHandle;
						}
						\u001F\u0017\u000A.\u000A(streamWriter);
					}
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UtilityLogWritter.cs", "WritePath");
			}
		}

		// Token: 0x06001351 RID: 4945 RVA: 0x0007B488 File Offset: 0x00079688
		internal static string \u001D()
		{
			return \u0011\u0012.\u001D("ExportFiles", "path.txt");
		}

		// Token: 0x06001352 RID: 4946 RVA: 0x0007B4A8 File Offset: 0x000796A8
		internal static string \u001D(string \u001F, string \u000A)
		{
			bool flag = false;
			string text = string.Empty;
			try
			{
				StreamReader streamReader = \u0017\u0017\u0018.\u000A(\u001B\u0015\u001D.\u000A(\u0004\u000F.\u0004(), \u000A));
				try
				{
					text = \u0010\u000D\u0018.\u000A(streamReader);
				}
				finally
				{
					if (streamReader != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0012.\u001D(string, string)).MethodHandle;
						}
						\u001F\u0017\u000A.\u000A(streamReader);
					}
				}
				if (!\u001A\u0006\u0007.\u000A(text))
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
					if (!\u001E\u0017\u0018.\u000A(\u0020\u0017\u0018.\u000A(text)))
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
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
			}
			catch (Exception)
			{
				flag = true;
			}
			if (flag)
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
				flag = false;
				text = \u001B\u0015\u001D.\u000A(\u0008\u0005\u0018.\u000A(Environment.SpecialFolder.Personal), \u0004\u001E\u000A.\u000A("DiRoots\\SheetLink\\", \u001F));
				try
				{
					if (!\u001E\u0017\u0018.\u000A(\u0020\u0017\u0018.\u000A(text)))
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
						flag = true;
					}
				}
				catch (Exception)
				{
					flag = true;
				}
			}
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
				text = \u0008\u0005\u0018.\u000A(Environment.SpecialFolder.Personal);
			}
			return text;
		}

		// Token: 0x040007A5 RID: 1957
		public static string \u001F;

		// Token: 0x040007A6 RID: 1958
		public static string \u000A;
	}
}

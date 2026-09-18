using System;
using System.IO;

namespace A
{
	// Token: 0x0200006D RID: 109
	internal static class \u0017\u000A\u0018
	{
		// Token: 0x0600063C RID: 1596 RVA: 0x00025528 File Offset: 0x00023728
		public static void \u0003(string \u000C, bool \u0018)
		{
			try
			{
				string u000C;
				if (\u0018)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000A\u0018.\u0003(string, bool)).MethodHandle;
					}
					u000C = \u0014\u001E\u0018.\u0018(\u0011\u0009\u0018.\u0018(), "//", \u0017\u000A\u0018.\u0018);
				}
				else
				{
					u000C = \u0014\u001E\u0018.\u0018(\u0011\u0009\u0018.\u0018(), "//", \u0017\u000A\u0018.\u0014);
				}
				StreamWriter streamWriter = \u001A\u001D\u0018.\u0018(u000C);
				try
				{
					\u0008\u000F\u0003.\u0018(streamWriter, \u000C);
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
						\u0020\u001E\u0018.\u0018(streamWriter);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x000255CC File Offset: 0x000237CC
		public static string \u0016(bool \u000C)
		{
			string result;
			try
			{
				string u000C;
				if (\u000C)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u000A\u0018.\u0016(bool)).MethodHandle;
					}
					u000C = \u0014\u001E\u0018.\u0018(\u0011\u0009\u0018.\u0018(), "//", \u0017\u000A\u0018.\u0018);
				}
				else
				{
					u000C = \u0014\u001E\u0018.\u0018(\u0011\u0009\u0018.\u0018(), "//", \u0017\u000A\u0018.\u0014);
				}
				string text = string.Empty;
				StreamReader streamReader = \u000E\u001D\u0018.\u0018(u000C);
				try
				{
					text = \u0001\u000F\u0003.\u0018(streamReader);
				}
				finally
				{
					if (streamReader != null)
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
						\u0020\u001E\u0018.\u0018(streamReader);
					}
				}
				result = text;
			}
			catch (Exception)
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x0400024C RID: 588
		public static string \u000C = "DiLog.txt";

		// Token: 0x0400024D RID: 589
		public static string \u0018 = "SelectionPath.txt";

		// Token: 0x0400024E RID: 590
		public static string \u0014 = "FormatsPathName.txt";
	}
}

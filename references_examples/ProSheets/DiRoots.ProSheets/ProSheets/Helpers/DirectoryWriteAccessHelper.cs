using System;
using System.IO;
using A;

namespace ProSheets.Helpers
{
	// Token: 0x020000D7 RID: 215
	public static class DirectoryWriteAccessHelper
	{
		// Token: 0x06000B52 RID: 2898 RVA: 0x00045874 File Offset: 0x00043A74
		public static void EnsureDirectoryWritable(string filePath)
		{
			\u000F\u0006\u0018.\u0018(\u0019\u001E\u0018.\u0018(filePath));
			if (\u000C\u001A\u0018.\u0018(filePath))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DirectoryWriteAccessHelper.EnsureDirectoryWritable(string)).MethodHandle;
				}
				\u000C\u0020\u0014.\u0018(filePath);
			}
			FileStream fileStream = \u0009\u001F\u0016.\u0018(filePath, FileMode.CreateNew, FileAccess.Write, FileShare.None, 1, FileOptions.DeleteOnClose);
			try
			{
			}
			finally
			{
				if (fileStream != null)
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
					\u0020\u001E\u0018.\u0018(fileStream);
				}
			}
		}
	}
}

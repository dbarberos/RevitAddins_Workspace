using System;
using System.IO;
using A;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.TGDatabaseLayer
{
	// Token: 0x02000115 RID: 277
	public static class FilePathHelper
	{
		// Token: 0x060009F0 RID: 2544 RVA: 0x000423C4 File Offset: 0x000405C4
		internal static string \u001F(EnumInfo \u001F, string \u000A = "")
		{
			return FilePathHelper.\u000A(\u001F, \u000A);
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x000423DC File Offset: 0x000405DC
		private static string \u000A(EnumInfo \u001F, string \u000A = "")
		{
			if (\u000D\u001B\u001D.\u0007(\u001F) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FilePathHelper.\u000A(EnumInfo, string)).MethodHandle;
				}
				\u001D\u001B\u000A u001D_u001B_u000A = new \u001D\u001B\u000A();
				\u001C\u000E\u0004.\u000A(u001D_u001B_u000A, true);
				return \u000D\u001B\u000A.\u0007(\u000A, u001D_u001B_u000A);
			}
			string u001F;
			if (\u000D\u001B\u001D.\u0007(\u001F) != 1)
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
				u001F = \u0004\u001E\u000A.\u000A(\u0003\u000E\u0004.\u000A(), " (*.pdf)|*.pdf");
			}
			else
			{
				u001F = \u0004\u001E\u000A.\u000A(\u0012\u000E\u0004.\u000A(), " (*.docx)|*.docx");
			}
			return \u000F\u000E\u0004.\u000A(u001F, \u000A);
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x00042460 File Offset: 0x00040660
		internal static string[] \u0007()
		{
			string[] array = \u001B\u001F\u000E.\u001F(8);
			array[0] = \u000E\u000E\u0004.\u000A();
			array[1] = " (*.xlsx;*.xlsm;*.docx;*.pdf)|*.xlsx;*.xlsm;*.docx;*.pdf|";
			array[2] = \u0010\u000E\u0004.\u000A();
			array[3] = " (*.xlsx;*.xlsm)|*.xlsx;*.xlsm|";
			array[4] = \u0012\u000E\u0004.\u000A();
			array[5] = " (*.docx)|*.docx|";
			array[6] = \u0003\u000E\u0004.\u000A();
			array[7] = " (*.pdf)|*.pdf";
			return \u000D\u000E\u0004.\u000A(\u0014\u0006\u001D.\u000A(array));
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x000424CC File Offset: 0x000406CC
		internal static bool \u001D(string \u001F)
		{
			return \u0008\u0013\u000A.\u000A(\u0018\u0006\u001D.\u0007(\u001B\u0002\u001D.\u000A(\u001F)), ".pdf");
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x000424F4 File Offset: 0x000406F4
		internal static string \u0004(string \u001F, string \u000A)
		{
			try
			{
				Uri u000A = \u0011\u000E\u0004.\u000A(\u001F);
				string text = \u001C\u000B\u001D.\u0007(\u000A, "/", "\\");
				object u001F = text;
				char directorySeparatorChar = Path.DirectorySeparatorChar;
				if (!\u0001\u0016\u001D.\u000A(u001F, \u001E\u000E\u0004.\u000A(ref directorySeparatorChar)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FilePathHelper.\u0004(string, string)).MethodHandle;
					}
					string u001F2 = text;
					directorySeparatorChar = Path.DirectorySeparatorChar;
					text = \u0004\u001E\u000A.\u000A(u001F2, \u001E\u000E\u0004.\u000A(ref directorySeparatorChar));
				}
				return \u0008\u000E\u0004.\u000A(\u000C\u0003\u0004.\u000A(\u001A\u000C\u000A.\u000A(\u001B\u000E\u0004.\u000A(\u0011\u000E\u0004.\u000A(text), u000A)), '/', Path.DirectorySeparatorChar));
			}
			catch (Exception u000A2)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\FilePathHelper.cs", "GetRelativePath");
			}
			return "";
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x000425C4 File Offset: 0x000407C4
		internal static string \u0019(string \u001F, string \u000A)
		{
			object u001F = \u000A;
			char directorySeparatorChar = Path.DirectorySeparatorChar;
			if (!\u0001\u0016\u001D.\u000A(u001F, \u001E\u000E\u0004.\u000A(ref directorySeparatorChar)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FilePathHelper.\u0019(string, string)).MethodHandle;
				}
				string u001F2 = \u000A;
				directorySeparatorChar = Path.DirectorySeparatorChar;
				\u000A = \u0004\u001E\u000A.\u000A(u001F2, \u001E\u000E\u0004.\u000A(ref directorySeparatorChar));
			}
			return \u0020\u000E\u0004.\u000A(\u0017\u000E\u0004.\u000A(\u0011\u000E\u0004.\u000A(\u001B\u0015\u001D.\u000A(\u000A, \u001F))));
		}
	}
}

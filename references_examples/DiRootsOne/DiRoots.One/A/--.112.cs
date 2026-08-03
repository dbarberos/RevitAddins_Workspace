using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x020001F8 RID: 504
	internal static class \u0004\u000F
	{
		// Token: 0x17000585 RID: 1413
		// (get) Token: 0x060012CF RID: 4815 RVA: 0x0006C1C4 File Offset: 0x0006A3C4
		// (set) Token: 0x060012D0 RID: 4816 RVA: 0x0006C1D8 File Offset: 0x0006A3D8
		internal static bool IsLinkedFileChecked { get; set; }

		// Token: 0x17000586 RID: 1414
		// (get) Token: 0x060012D1 RID: 4817 RVA: 0x0006C1EC File Offset: 0x0006A3EC
		// (set) Token: 0x060012D2 RID: 4818 RVA: 0x0006C200 File Offset: 0x0006A400
		internal static bool IsImportingFromFile { get; set; }

		// Token: 0x17000587 RID: 1415
		// (get) Token: 0x060012D3 RID: 4819 RVA: 0x0006C214 File Offset: 0x0006A414
		// (set) Token: 0x060012D4 RID: 4820 RVA: 0x0006C228 File Offset: 0x0006A428
		internal static bool IsWarningSupress { get; set; } = true;

		// Token: 0x17000588 RID: 1416
		// (get) Token: 0x060012D5 RID: 4821 RVA: 0x0006C23C File Offset: 0x0006A43C
		// (set) Token: 0x060012D6 RID: 4822 RVA: 0x0006C250 File Offset: 0x0006A450
		internal static bool IsActiveView { get; set; }

		// Token: 0x060012D7 RID: 4823 RVA: 0x0006C264 File Offset: 0x0006A464
		internal static string \u0004()
		{
			return \u000D\u0016\u0018.\u000A().\u0008;
		}

		// Token: 0x060012D8 RID: 4824 RVA: 0x0006C280 File Offset: 0x0006A480
		internal static string \u0019()
		{
			try
			{
				string text = \u001B\u0015\u001D.\u000A(\u000D\u0016\u0018.\u000A().\u0008, \u0006\u0013\u0004.\u000A());
				\u0011\u0015\u001D.\u000A(text);
				return text;
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Common.cs", "GetTempDirectoryWithTempFolder");
			}
			return \u000D\u0016\u0018.\u000A().\u0008;
		}

		// Token: 0x060012D9 RID: 4825 RVA: 0x0006C2EC File Offset: 0x0006A4EC
		internal static string \u0018(string \u001F = "", bool \u000A = false, bool \u0007 = false)
		{
			string u001F = \u0011\u0012.\u001D();
			\u001D\u001B\u000A u001D_u001B_u000A = new \u001D\u001B\u000A();
			\u0008\u0016\u0018.\u000A(u001D_u001B_u000A, \u000A);
			\u001C\u000E\u0004.\u000A(u001D_u001B_u000A, \u0007);
			string text = \u000D\u001B\u000A.\u001F(u001F, \u001F, u001D_u001B_u000A);
			if (!\u001A\u0006\u0007.\u000A(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u000F.\u0018(string, bool, bool)).MethodHandle;
				}
				\u0011\u0012.\u0007(\u0010\u0016\u0018.\u000A(\u000E\u0016\u0018.\u000A(text)));
			}
			return text;
		}

		// Token: 0x060012DA RID: 4826 RVA: 0x0006C350 File Offset: 0x0006A550
		internal static string \u0005()
		{
			string u001F = \u0011\u0012.\u001D();
			\u001D\u001B\u000A u001D_u001B_u000A = new \u001D\u001B\u000A();
			\u001C\u000E\u0004.\u000A(u001D_u001B_u000A, true);
			string text = \u000D\u001B\u000A.\u0007(u001F, u001D_u001B_u000A);
			if (!\u001A\u0006\u0007.\u000A(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u000F.\u0005()).MethodHandle;
				}
				\u0011\u0012.\u0007(\u0010\u0016\u0018.\u000A(\u000E\u0016\u0018.\u000A(text)));
				return text;
			}
			return string.Empty;
		}

		// Token: 0x060012DB RID: 4827 RVA: 0x0006C3B0 File Offset: 0x0006A5B0
		internal static void \u0016(Exception \u001F)
		{
			\u000D\u0014\u0004.\u000A(\u001B\u0016\u0018.\u000A(), \u001F, true);
		}

		// Token: 0x060012DC RID: 4828 RVA: 0x0006C3CC File Offset: 0x0006A5CC
		internal static void \u000B(List<CategoryCollection> \u001F)
		{
			Dictionary<string, int> dictionary = \u000A\u000B\u0018.\u000A(\u001C\u0012\u0004.\u000A());
			Func<CategoryCollection, string> func;
			if ((func = \u0004\u000F.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u000F.\u000B(List<CategoryCollection>)).MethodHandle;
				}
				func = (\u0004\u000F.<>c.\u000A = new Func<CategoryCollection, string>(\u0004\u000F.<>c.\u001F.\u0004));
			}
			IEnumerable<IGrouping<string, CategoryCollection>> enumerable = Enumerable.GroupBy<CategoryCollection, string>(\u001F, func);
			Func<IGrouping<string, CategoryCollection>, string> func2;
			if ((func2 = \u0004\u000F.<>c.\u0007) == null)
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
				func2 = (\u0004\u000F.<>c.\u0007 = new Func<IGrouping<string, CategoryCollection>, string>(\u0004\u000F.<>c.\u001F.\u0019));
			}
			Func<IGrouping<string, CategoryCollection>, List<CategoryCollection>> func3;
			if ((func3 = \u0004\u000F.<>c.\u001D) == null)
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
				func3 = (\u0004\u000F.<>c.\u001D = new Func<IGrouping<string, CategoryCollection>, List<CategoryCollection>>(\u0004\u000F.<>c.\u001F.\u0018));
			}
			Dictionary<string, List<CategoryCollection>>.Enumerator enumerator = \u001F\u000B\u0018.\u000A(Enumerable.ToDictionary<IGrouping<string, CategoryCollection>, string, List<CategoryCollection>>(enumerable, func2, func3));
			try
			{
				while (\u0011\u0016\u0018.\u000A(ref enumerator))
				{
					KeyValuePair<string, List<CategoryCollection>> keyValuePair = \u0009\u0016\u0018.\u000A(ref enumerator);
					string text = \u0001\u0016\u0018.\u000A(Enumerable.First<CategoryCollection>(\u0013\u0016\u0018.\u000A(ref keyValuePair)));
					string text2 = "\\/?*[]:'";
					for (int i = 0; i < \u001C\u000F\u0007.\u0007(text2); i++)
					{
						char c = \u001E\u001E\u0007.\u001D(text2, i);
						text = \u001C\u000B\u001D.\u0007(text, \u001E\u000E\u0004.\u000A(ref c), "");
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
					if (\u0015\u0016\u0018.\u000A(dictionary, text))
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
						Dictionary<string, int> u001F = dictionary;
						text2 = text;
						int i = \u001A\u0016\u0018.\u000A(u001F, text2);
						\u000C\u0016\u0018.\u000A(u001F, text2, i + 1);
					}
					else
					{
						\u001D\u001D\u001D.\u000A(dictionary, text, 0);
					}
					string text3 = text;
					if (\u001A\u0016\u0018.\u000A(dictionary, text3) > 0)
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
						string u001F2 = text3;
						int i = \u001A\u0016\u0018.\u000A(dictionary, text3);
						string text4 = \u0004\u001E\u000A.\u000A(u001F2, \u000C\u0013\u0007.\u000A(ref i));
						string text5 = text3;
						while (\u001C\u000F\u0007.\u0007(text4) > 31)
						{
							text5 = \u000A\u000B\u001D.\u000A(text5, 0, \u001C\u000F\u0007.\u0007(text5) - 1);
							string u001F3 = text5;
							i = \u001A\u0016\u0018.\u000A(dictionary, text3);
							text4 = \u0004\u001E\u000A.\u000A(u001F3, \u000C\u0013\u0007.\u000A(ref i));
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
						text = text4;
					}
					List<CategoryCollection>.Enumerator enumerator2 = \u0014\u0016\u0018.\u000A(\u0013\u0016\u0018.\u000A(ref keyValuePair));
					try
					{
						while (\u001E\u0016\u0018.\u000A(ref enumerator2))
						{
							\u0020\u0016\u0018.\u000A(\u0017\u0016\u0018.\u000A(ref enumerator2), text);
						}
						for (;;)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
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
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060012DD RID: 4829 RVA: 0x0006C66C File Offset: 0x0006A86C
		internal static string \u0002(int \u001F)
		{
			int i = \u001F;
			string text = string.Empty;
			while (i > 0)
			{
				int num = (i - 1) % 26;
				char c = (char)(65 + num);
				text = \u0004\u001E\u000A.\u000A(\u001E\u000E\u0004.\u000A(ref c), text);
				i = (i - num) / 26;
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u000F.\u0002(int)).MethodHandle;
			}
			return text;
		}

		// Token: 0x04000782 RID: 1922
		[CompilerGenerated]
		private static bool \u001F;

		// Token: 0x04000783 RID: 1923
		[CompilerGenerated]
		private static bool \u000A;

		// Token: 0x04000784 RID: 1924
		[CompilerGenerated]
		private static bool \u0007;

		// Token: 0x04000785 RID: 1925
		[CompilerGenerated]
		private static bool \u001D;
	}
}

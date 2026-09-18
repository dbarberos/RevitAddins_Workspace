using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Interfaces;
using Microsoft.Win32;

namespace A
{
	// Token: 0x020000D2 RID: 210
	internal static class \u0020\u001F\u0018
	{
		// Token: 0x06000B43 RID: 2883 RVA: 0x00044838 File Offset: 0x00042A38
		public static bool \u000C(ICustomLogger \u000C)
		{
			\u001B\u0018\u0003.\u0018("diroots.prosheets");
			if (!\u0020\u001F\u0018.\u0018("PDF24"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u001F\u0018.\u000C(ICustomLogger)).MethodHandle;
				}
				\u0008\u0017\u0018.\u0018(\u000C, \u000D\u0009\u0018.\u0018\u0003, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\Utility.cs", "VerifyPrinter");
				return false;
			}
			bool flag;
			bool flag2;
			\u0020\u001F\u0018.\u0014(out flag, out flag2);
			if (!flag)
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
				if (!flag2)
				{
					\u0008\u0017\u0018.\u0018(\u000C, \u000D\u0009\u0018.\u0018\u0003, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Helper\\Utility.cs", "VerifyPrinter");
					return false;
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
				\u001B\u0018\u0003.\u0018("PDF24");
			}
			return true;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x000448D4 File Offset: 0x00042AD4
		private static bool \u0018(string \u000C)
		{
			\u0020\u001F\u0018.\u000A\u001F\u0018 u000A_u001F_u = new \u0020\u001F\u0018.\u000A\u001F\u0018();
			string u = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
			u000A_u001F_u.\u000C = \u0020\u0020\u0016.\u0018(Registry.LocalMachine, u);
			if (u000A_u001F_u.\u000C != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u001F\u0018.\u0018(string)).MethodHandle;
				}
				IEnumerable<string> enumerable = \u000A\u0020\u0016.\u0018(u000A_u001F_u.\u000C);
				Func<string, RegistryKey> func;
				if ((func = u000A_u001F_u.\u0018) == null)
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
					func = (u000A_u001F_u.\u0018 = new Func<string, RegistryKey>(u000A_u001F_u.\u0003));
				}
				IEnumerator<RegistryKey> enumerator = \u0009\u0020\u0016.\u0018(Enumerable.Select<string, RegistryKey>(enumerable, func));
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						string text = \u0014\u0004\u000F.\u000C(\u0018\u000A\u0016.\u0018(\u0013\u0020\u0016.\u0018(enumerator), "DisplayName"));
						if (text != null)
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
							if (\u001B\u0013\u0018.\u000C(text, \u000C))
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
								return true;
							}
						}
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
					if (enumerator != null)
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
						\u0020\u001E\u0018.\u0018(enumerator);
					}
				}
				\u0001\u0009\u0016.\u0018(u000A_u001F_u.\u000C);
			}
			u = "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
			u000A_u001F_u.\u000C = \u0020\u0020\u0016.\u0018(Registry.LocalMachine, u);
			if (u000A_u001F_u.\u000C != null)
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
				IEnumerable<string> enumerable2 = \u000A\u0020\u0016.\u0018(u000A_u001F_u.\u000C);
				Func<string, RegistryKey> func2;
				if ((func2 = u000A_u001F_u.\u0014) == null)
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
					func2 = (u000A_u001F_u.\u0014 = new Func<string, RegistryKey>(u000A_u001F_u.\u0016));
				}
				IEnumerator<RegistryKey> enumerator = \u0009\u0020\u0016.\u0018(Enumerable.Select<string, RegistryKey>(enumerable2, func2));
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						string text = \u0014\u0004\u000F.\u000C(\u0018\u000A\u0016.\u0018(\u0013\u0020\u0016.\u0018(enumerator), "DisplayName"));
						if (text != null)
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
							if (\u001B\u0013\u0018.\u000C(text, \u000C))
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
								return true;
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
				finally
				{
					if (enumerator != null)
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
						\u0020\u001E\u0018.\u0018(enumerator);
					}
				}
				\u0001\u0009\u0016.\u0018(u000A_u001F_u.\u000C);
			}
			return false;
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x00044AF4 File Offset: 0x00042CF4
		private unsafe static void \u0014(out bool \u000C, out bool \u0018)
		{
			\u000C = false;
			\u0018 = false;
			IEnumerator u000C = \u0017\u0020\u0016.\u0018(\u001E\u0020\u0016.\u0018());
			try
			{
				while (\u001F\u001E\u0018.\u0018(u000C))
				{
					string text = \u001E\u0002\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C));
					if (\u000F\u0002\u0018.\u0018(text, \u0002\u001A\u0014.\u0018()))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u001F\u0018.\u0014(bool*, bool*)).MethodHandle;
						}
						PrinterSettings u000C2 = \u0015\u0020\u0016.\u0018();
						\u0011\u0020\u0016.\u0018(u000C2, text);
						if (\u001F\u0020\u0016.\u0018(u000C2))
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
							\u000C = true;
						}
					}
					if (\u000F\u0002\u0018.\u0018(text, "PDF24"))
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
						PrinterSettings u000C3 = \u0015\u0020\u0016.\u0018();
						\u0011\u0020\u0016.\u0018(u000C3, text);
						if (\u001F\u0020\u0016.\u0018(u000C3))
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
							\u0018 = true;
						}
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
				IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C);
				if (disposable != null)
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
					\u0020\u001E\u0018.\u0018(disposable);
				}
			}
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x00044BF8 File Offset: 0x00042DF8
		public static List<PaperSize> \u0003()
		{
			List<PaperSize> list = \u001A\u001A\u0014.\u0018();
			PrintDocument u000C = \u0010\u0017\u0018.\u0018();
			IEnumerator u000C2 = \u0017\u0020\u0016.\u0018(\u001E\u0020\u0016.\u0018());
			try
			{
				while (\u001F\u001E\u0018.\u0018(u000C2))
				{
					string text = \u001E\u0002\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C2));
					if (\u000F\u0002\u0018.\u0018(text, \u0002\u001A\u0014.\u0018()))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u001F\u0018.\u0003()).MethodHandle;
						}
						\u0011\u0020\u0016.\u0018(\u0007\u0017\u0018.\u0018(u000C), text);
						IEnumerable<PaperSize> enumerable = Enumerable.Cast<PaperSize>(\u0004\u0020\u0016.\u0018(\u0007\u0017\u0018.\u0018(u000C)));
						Func<PaperSize, int> func;
						if ((func = \u0020\u001F\u0018.<>c.\u0018) == null)
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
							func = (\u0020\u001F\u0018.<>c.\u0018 = new Func<PaperSize, int>(\u0020\u001F\u0018.<>c.\u000C.\u000F));
						}
						IOrderedEnumerable<PaperSize> orderedEnumerable = Enumerable.OrderBy<PaperSize, int>(enumerable, func);
						Func<PaperSize, int> func2;
						if ((func2 = \u0020\u001F\u0018.<>c.\u0014) == null)
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
							func2 = (\u0020\u001F\u0018.<>c.\u0014 = new Func<PaperSize, int>(\u0020\u001F\u0018.<>c.\u000C.\u0012));
						}
						List<PaperSize>.Enumerator enumerator = \u0010\u0002\u0014.\u0018(Enumerable.ToList<PaperSize>(Enumerable.ThenBy<PaperSize, int>(orderedEnumerable, func2)));
						try
						{
							while (\u000B\u0002\u0014.\u0018(ref enumerator))
							{
								PaperSize u = \u0007\u0002\u0014.\u0018(ref enumerator);
								\u0002\u0020\u0016.\u0018(list, u);
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
							goto IL_162;
						}
						finally
						{
							((IDisposable)enumerator).Dispose();
						}
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
			}
			finally
			{
				IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C2);
				if (disposable != null)
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
					\u0020\u001E\u0018.\u0018(disposable);
				}
			}
			IL_162:
			IEnumerable<PaperSize> enumerable2 = list;
			Func<PaperSize, int> func3;
			if ((func3 = \u0020\u001F\u0018.<>c.\u0003) == null)
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
				func3 = (\u0020\u001F\u0018.<>c.\u0003 = new Func<PaperSize, int>(\u0020\u001F\u0018.<>c.\u000C.\u000D));
			}
			IOrderedEnumerable<PaperSize> orderedEnumerable2 = Enumerable.OrderBy<PaperSize, int>(enumerable2, func3);
			Func<PaperSize, string> func4;
			if ((func4 = \u0020\u001F\u0018.<>c.\u0016) == null)
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
				func4 = (\u0020\u001F\u0018.<>c.\u0016 = new Func<PaperSize, string>(\u0020\u001F\u0018.<>c.\u000C.\u001C));
			}
			return Enumerable.ToList<PaperSize>(Enumerable.ThenBy<PaperSize, string>(orderedEnumerable2, func4, new \u0014\u0017\u0018()));
		}

		// Token: 0x020001D4 RID: 468
		[CompilerGenerated]
		private sealed class \u000A\u001F\u0018
		{
			// Token: 0x06001208 RID: 4616 RVA: 0x0005DC48 File Offset: 0x0005BE48
			internal RegistryKey \u0003(string \u000C)
			{
				return \u0020\u0020\u0016.\u0018(this.\u000C, \u000C);
			}

			// Token: 0x06001209 RID: 4617 RVA: 0x0005DC64 File Offset: 0x0005BE64
			internal RegistryKey \u0016(string \u000C)
			{
				return \u0020\u0020\u0016.\u0018(this.\u000C, \u000C);
			}

			// Token: 0x04000894 RID: 2196
			public RegistryKey \u000C;

			// Token: 0x04000895 RID: 2197
			public Func<string, RegistryKey> \u0018;

			// Token: 0x04000896 RID: 2198
			public Func<string, RegistryKey> \u0014;
		}
	}
}

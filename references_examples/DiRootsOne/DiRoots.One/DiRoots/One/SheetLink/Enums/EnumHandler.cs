using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;

namespace DiRoots.One.SheetLink.Enums
{
	// Token: 0x02000268 RID: 616
	public class EnumHandler
	{
		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x060018D4 RID: 6356 RVA: 0x000A1424 File Offset: 0x0009F624
		// (set) Token: 0x060018D5 RID: 6357 RVA: 0x000A1438 File Offset: 0x0009F638
		public string DisplayName { get; set; }

		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x060018D6 RID: 6358 RVA: 0x000A144C File Offset: 0x0009F64C
		// (set) Token: 0x060018D7 RID: 6359 RVA: 0x000A1460 File Offset: 0x0009F660
		public string OriginalName { get; set; }

		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x060018D8 RID: 6360 RVA: 0x000A1474 File Offset: 0x0009F674
		// (set) Token: 0x060018D9 RID: 6361 RVA: 0x000A1488 File Offset: 0x0009F688
		public int EnumIndex { get; set; }

		// Token: 0x060018DA RID: 6362 RVA: 0x000A149C File Offset: 0x0009F69C
		internal static List<EnumHandler> \u001D()
		{
			List<EnumHandler> list = \u0017\u001A\u0005.\u000A();
			EnumHandler enumHandler = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler, "Wall Centerline");
			\u0011\u001A\u0005.\u000A(enumHandler, "WallCenterline");
			\u001B\u001A\u0005.\u000A(enumHandler, 0);
			\u0008\u001A\u0005.\u000A(list, enumHandler);
			EnumHandler enumHandler2 = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler2, "Core Centerline");
			\u0011\u001A\u0005.\u000A(enumHandler2, "CoreCenterline");
			\u001B\u001A\u0005.\u000A(enumHandler2, 1);
			\u0008\u001A\u0005.\u000A(list, enumHandler2);
			EnumHandler enumHandler3 = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler3, "Finish Face: Exterior");
			\u0011\u001A\u0005.\u000A(enumHandler3, "FinishFaceExterior");
			\u001B\u001A\u0005.\u000A(enumHandler3, 2);
			\u0008\u001A\u0005.\u000A(list, enumHandler3);
			EnumHandler enumHandler4 = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler4, "Finish Face: Interior");
			\u0011\u001A\u0005.\u000A(enumHandler4, "FinishFaceInterior");
			\u001B\u001A\u0005.\u000A(enumHandler4, 3);
			\u0008\u001A\u0005.\u000A(list, enumHandler4);
			EnumHandler enumHandler5 = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler5, "Core Face: Exterior");
			\u0011\u001A\u0005.\u000A(enumHandler5, "CoreExterior");
			\u001B\u001A\u0005.\u000A(enumHandler5, 4);
			\u0008\u001A\u0005.\u000A(list, enumHandler5);
			EnumHandler enumHandler6 = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler6, "Core Face: Interior");
			\u0011\u001A\u0005.\u000A(enumHandler6, "CoreInterior");
			\u001B\u001A\u0005.\u000A(enumHandler6, 5);
			\u0008\u001A\u0005.\u000A(list, enumHandler6);
			return list;
		}

		// Token: 0x060018DB RID: 6363 RVA: 0x000A15AC File Offset: 0x0009F7AC
		internal static List<EnumHandler> \u0004()
		{
			List<EnumHandler> list = \u0017\u001A\u0005.\u000A();
			EnumHandler enumHandler = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler, "Wireframe");
			\u0011\u001A\u0005.\u000A(enumHandler, 1.ToString());
			\u001B\u001A\u0005.\u000A(enumHandler, 1);
			\u0008\u001A\u0005.\u000A(list, enumHandler);
			EnumHandler enumHandler2 = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler2, "Hidden Line");
			\u0011\u001A\u0005.\u000A(enumHandler2, 2.ToString());
			\u001B\u001A\u0005.\u000A(enumHandler2, 2);
			\u0008\u001A\u0005.\u000A(list, enumHandler2);
			return list;
		}

		// Token: 0x060018DC RID: 6364 RVA: 0x000A162C File Offset: 0x0009F82C
		internal static List<EnumHandler> \u0019()
		{
			List<EnumHandler> list = \u0017\u001A\u0005.\u000A();
			EnumHandler enumHandler = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler, "None");
			\u0011\u001A\u0005.\u000A(enumHandler, "None");
			\u001B\u001A\u0005.\u000A(enumHandler, 0);
			\u0008\u001A\u0005.\u000A(list, enumHandler);
			EnumHandler enumHandler2 = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler2, "Flow only");
			\u0011\u001A\u0005.\u000A(enumHandler2, "Flow only");
			\u001B\u001A\u0005.\u000A(enumHandler2, 1);
			\u0008\u001A\u0005.\u000A(list, enumHandler2);
			EnumHandler enumHandler3 = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler3, "All");
			\u0011\u001A\u0005.\u000A(enumHandler3, "All");
			\u001B\u001A\u0005.\u000A(enumHandler3, -1);
			\u0008\u001A\u0005.\u000A(list, enumHandler3);
			EnumHandler enumHandler4 = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler4, "Performance");
			\u0011\u001A\u0005.\u000A(enumHandler4, "Performance");
			\u001B\u001A\u0005.\u000A(enumHandler4, 4);
			\u0008\u001A\u0005.\u000A(list, enumHandler4);
			return list;
		}

		// Token: 0x060018DD RID: 6365 RVA: 0x000A16E8 File Offset: 0x0009F8E8
		internal static List<EnumHandler> \u0018()
		{
			List<EnumHandler> list = \u0017\u001A\u0005.\u000A();
			EnumHandler enumHandler = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler, "Interior");
			\u0011\u001A\u0005.\u000A(enumHandler, "Interior");
			\u001B\u001A\u0005.\u000A(enumHandler, 0);
			\u0008\u001A\u0005.\u000A(list, enumHandler);
			EnumHandler enumHandler2 = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler2, "Exterior");
			\u0011\u001A\u0005.\u000A(enumHandler2, "Exterior");
			\u001B\u001A\u0005.\u000A(enumHandler2, 1);
			\u0008\u001A\u0005.\u000A(list, enumHandler2);
			EnumHandler enumHandler3 = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler3, "Foundation");
			\u0011\u001A\u0005.\u000A(enumHandler3, "Foundation");
			\u001B\u001A\u0005.\u000A(enumHandler3, 2);
			\u0008\u001A\u0005.\u000A(list, enumHandler3);
			EnumHandler enumHandler4 = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler4, "Retaining");
			\u0011\u001A\u0005.\u000A(enumHandler4, "Retaining");
			\u001B\u001A\u0005.\u000A(enumHandler4, 3);
			\u0008\u001A\u0005.\u000A(list, enumHandler4);
			EnumHandler enumHandler5 = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler5, "Soffit");
			\u0011\u001A\u0005.\u000A(enumHandler5, "Soffit");
			\u001B\u001A\u0005.\u000A(enumHandler5, 4);
			\u0008\u001A\u0005.\u000A(list, enumHandler5);
			EnumHandler enumHandler6 = \u0020\u001A\u0005.\u000A();
			\u001E\u001A\u0005.\u000A(enumHandler6, "Coreshaft");
			\u0011\u001A\u0005.\u000A(enumHandler6, "Coreshaft");
			\u001B\u001A\u0005.\u000A(enumHandler6, 5);
			\u0008\u001A\u0005.\u000A(list, enumHandler6);
			return list;
		}

		// Token: 0x060018DE RID: 6366 RVA: 0x000A17F8 File Offset: 0x0009F9F8
		internal static string \u0005(int \u001F)
		{
			EnumHandler.\u0006\u0010 u0006_u = new EnumHandler.\u0006\u0010();
			u0006_u.\u001F = \u001F;
			return \u0014\u001A\u0005.\u000A(Enumerable.FirstOrDefault<EnumHandler>(EnumHandler.\u001D(), new Func<EnumHandler, bool>(u0006_u.\u000A)));
		}

		// Token: 0x060018DF RID: 6367 RVA: 0x000A1834 File Offset: 0x0009FA34
		internal static int \u0016(string \u001F)
		{
			EnumHandler.\u000F\u0010 u000F_u = new EnumHandler.\u000F\u0010();
			u000F_u.\u001F = \u001F;
			EnumHandler enumHandler = Enumerable.FirstOrDefault<EnumHandler>(EnumHandler.\u001D(), new Func<EnumHandler, bool>(u000F_u.\u000A));
			if (enumHandler != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(EnumHandler.\u0016(string)).MethodHandle;
				}
				return \u0013\u001A\u0005.\u000A(enumHandler);
			}
			return -1;
		}

		// Token: 0x060018E0 RID: 6368 RVA: 0x000A188C File Offset: 0x0009FA8C
		internal static string \u000B(int \u001F)
		{
			EnumHandler.\u0012\u0010 u0012_u = new EnumHandler.\u0012\u0010();
			u0012_u.\u001F = \u001F;
			return \u0014\u001A\u0005.\u000A(Enumerable.FirstOrDefault<EnumHandler>(EnumHandler.\u0004(), new Func<EnumHandler, bool>(u0012_u.\u000A)));
		}

		// Token: 0x060018E1 RID: 6369 RVA: 0x000A18C8 File Offset: 0x0009FAC8
		internal static int \u0002(string \u001F)
		{
			EnumHandler.\u0003\u0010 u0003_u = new EnumHandler.\u0003\u0010();
			u0003_u.\u001F = \u001F;
			EnumHandler enumHandler = Enumerable.FirstOrDefault<EnumHandler>(EnumHandler.\u0004(), new Func<EnumHandler, bool>(u0003_u.\u000A));
			if (enumHandler != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(EnumHandler.\u0002(string)).MethodHandle;
				}
				return \u0013\u001A\u0005.\u000A(enumHandler);
			}
			return -1;
		}

		// Token: 0x060018E2 RID: 6370 RVA: 0x000A1920 File Offset: 0x0009FB20
		internal static string \u0006(int \u001F)
		{
			EnumHandler.\u001C\u0010 u001C_u = new EnumHandler.\u001C\u0010();
			u001C_u.\u001F = \u001F;
			return \u0014\u001A\u0005.\u000A(Enumerable.FirstOrDefault<EnumHandler>(EnumHandler.\u0019(), new Func<EnumHandler, bool>(u001C_u.\u000A)));
		}

		// Token: 0x060018E3 RID: 6371 RVA: 0x000A195C File Offset: 0x0009FB5C
		internal static int \u000F(string \u001F)
		{
			EnumHandler.\u000D\u0010 u000D_u = new EnumHandler.\u000D\u0010();
			u000D_u.\u001F = \u001F;
			EnumHandler enumHandler = Enumerable.FirstOrDefault<EnumHandler>(EnumHandler.\u0019(), new Func<EnumHandler, bool>(u000D_u.\u000A));
			if (enumHandler != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(EnumHandler.\u000F(string)).MethodHandle;
				}
				return \u0013\u001A\u0005.\u000A(enumHandler);
			}
			return -2;
		}

		// Token: 0x060018E4 RID: 6372 RVA: 0x000A19B4 File Offset: 0x0009FBB4
		internal static string \u0012(int \u001F)
		{
			EnumHandler.\u0010\u0010 u0010_u = new EnumHandler.\u0010\u0010();
			u0010_u.\u001F = \u001F;
			return \u0014\u001A\u0005.\u000A(Enumerable.FirstOrDefault<EnumHandler>(EnumHandler.\u0018(), new Func<EnumHandler, bool>(u0010_u.\u000A)));
		}

		// Token: 0x060018E5 RID: 6373 RVA: 0x000A19F0 File Offset: 0x0009FBF0
		internal static int \u0003(string \u001F)
		{
			EnumHandler.\u000E\u0010 u000E_u = new EnumHandler.\u000E\u0010();
			u000E_u.\u001F = \u001F;
			EnumHandler enumHandler = Enumerable.FirstOrDefault<EnumHandler>(EnumHandler.\u0018(), new Func<EnumHandler, bool>(u000E_u.\u000A));
			if (enumHandler != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(EnumHandler.\u0003(string)).MethodHandle;
				}
				return \u0013\u001A\u0005.\u000A(enumHandler);
			}
			return -1;
		}

		// Token: 0x060018E6 RID: 6374 RVA: 0x000A1A48 File Offset: 0x0009FC48
		internal static List<string> \u001C<\u001F>()
		{
			IEnumerable<Enum> enumerable = Enumerable.Cast<Enum>(\u000D\u0011\u001D.\u000A(\u001E\u0011\u000A.\u000A(typeof(\u001F).TypeHandle)));
			Func<Enum, string> func;
			if ((func = EnumHandler.<>c__24<\u001F>.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(EnumHandler.\u001C()).MethodHandle;
				}
				func = (EnumHandler.<>c__24<\u001F>.\u000A = new Func<Enum, string>(EnumHandler.<>c__24<\u001F>.\u001F.\u0007));
			}
			return Enumerable.ToList<string>(Enumerable.Select<Enum, string>(enumerable, func));
		}

		// Token: 0x060018E7 RID: 6375 RVA: 0x000A1AB0 File Offset: 0x0009FCB0
		internal unsafe static \u001F \u000D<\u001F>(string \u001F, ref bool \u000A) where \u001F : struct
		{
			\u001F u001F = default(\u001F);
			try
			{
				u001F = (\u001F)((object)\u0015\u0004\u001D.\u000A(\u001E\u0011\u000A.\u000A(typeof(\u001F).TypeHandle), \u001F));
				if (\u001A\u001A\u0005.\u000A(\u001E\u0011\u000A.\u000A(typeof(\u001F).TypeHandle), u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(EnumHandler.\u000D(string, bool*)).MethodHandle;
					}
					\u000A = true;
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Enums\\EnumHandler.cs", "GetEnumValueFromString");
			}
			return u001F;
		}

		// Token: 0x040009B8 RID: 2488
		[CompilerGenerated]
		private string \u001F;

		// Token: 0x040009B9 RID: 2489
		[CompilerGenerated]
		private string \u000A;

		// Token: 0x040009BA RID: 2490
		[CompilerGenerated]
		private int \u0007;

		// Token: 0x02000944 RID: 2372
		[CompilerGenerated]
		private sealed class \u0006\u0010
		{
			// Token: 0x0600523D RID: 21053 RVA: 0x001EA2A0 File Offset: 0x001E84A0
			internal bool \u000A(EnumHandler \u001F)
			{
				return \u0013\u001A\u0005.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x04002445 RID: 9285
			public int \u001F;
		}

		// Token: 0x02000945 RID: 2373
		[CompilerGenerated]
		private sealed class \u000F\u0010
		{
			// Token: 0x0600523F RID: 21055 RVA: 0x001EA2D4 File Offset: 0x001E84D4
			internal bool \u000A(EnumHandler \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0014\u001A\u0005.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x04002446 RID: 9286
			public string \u001F;
		}

		// Token: 0x02000946 RID: 2374
		[CompilerGenerated]
		private sealed class \u0012\u0010
		{
			// Token: 0x06005241 RID: 21057 RVA: 0x001EA30C File Offset: 0x001E850C
			internal bool \u000A(EnumHandler \u001F)
			{
				return \u0013\u001A\u0005.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x04002447 RID: 9287
			public int \u001F;
		}

		// Token: 0x02000947 RID: 2375
		[CompilerGenerated]
		private sealed class \u0003\u0010
		{
			// Token: 0x06005243 RID: 21059 RVA: 0x001EA340 File Offset: 0x001E8540
			internal bool \u000A(EnumHandler \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0014\u001A\u0005.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x04002448 RID: 9288
			public string \u001F;
		}

		// Token: 0x02000948 RID: 2376
		[CompilerGenerated]
		private sealed class \u001C\u0010
		{
			// Token: 0x06005245 RID: 21061 RVA: 0x001EA378 File Offset: 0x001E8578
			internal bool \u000A(EnumHandler \u001F)
			{
				return \u0013\u001A\u0005.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x04002449 RID: 9289
			public int \u001F;
		}

		// Token: 0x02000949 RID: 2377
		[CompilerGenerated]
		private sealed class \u000D\u0010
		{
			// Token: 0x06005247 RID: 21063 RVA: 0x001EA3AC File Offset: 0x001E85AC
			internal bool \u000A(EnumHandler \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0014\u001A\u0005.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x0400244A RID: 9290
			public string \u001F;
		}

		// Token: 0x0200094A RID: 2378
		[CompilerGenerated]
		private sealed class \u0010\u0010
		{
			// Token: 0x06005249 RID: 21065 RVA: 0x001EA3E4 File Offset: 0x001E85E4
			internal bool \u000A(EnumHandler \u001F)
			{
				return \u0013\u001A\u0005.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x0400244B RID: 9291
			public int \u001F;
		}

		// Token: 0x0200094B RID: 2379
		[CompilerGenerated]
		private sealed class \u000E\u0010
		{
			// Token: 0x0600524B RID: 21067 RVA: 0x001EA418 File Offset: 0x001E8618
			internal bool \u000A(EnumHandler \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0014\u001A\u0005.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x0400244C RID: 9292
			public string \u001F;
		}
	}
}

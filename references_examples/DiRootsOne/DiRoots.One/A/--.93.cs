using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Models;
using DiRoots.One.TableGen.TGRevitHelper;
using DiRoots.One.TGDatabaseLayer;

namespace A
{
	// Token: 0x02000186 RID: 390
	internal static class \u0004\u0002
	{
		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06000E79 RID: 3705 RVA: 0x0005BF5C File Offset: 0x0005A15C
		// (set) Token: 0x06000E7A RID: 3706 RVA: 0x0005BF70 File Offset: 0x0005A170
		internal static bool CheckForTableGen { get; set; }

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06000E7B RID: 3707 RVA: 0x0005BF84 File Offset: 0x0005A184
		// (set) Token: 0x06000E7C RID: 3708 RVA: 0x0005BF98 File Offset: 0x0005A198
		internal static string TableGuidStorage { get; set; }

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06000E7D RID: 3709 RVA: 0x0005BFAC File Offset: 0x0005A1AC
		internal static string \u0018
		{
			get
			{
				if (\u0008\u000E\u0019.\u000A())
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0002.get_\u0018()).MethodHandle;
					}
					return "9C2829C0-B2D4-430F-82D5-9BAAC4EF0D1B";
				}
				return "341A7FE1-11ED-471B-B031-11C77B5EFE43";
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06000E7E RID: 3710 RVA: 0x0005BFE0 File Offset: 0x0005A1E0
		internal static string \u0005
		{
			get
			{
				if (\u0008\u000E\u0019.\u000A())
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0002.get_\u0005()).MethodHandle;
					}
					return "TableGen_SelectedExcel";
				}
				return "DiRootsOneTableGen_SelectedExcel";
			}
		}

		// Token: 0x06000E7F RID: 3711 RVA: 0x0005C014 File Offset: 0x0005A214
		internal static List<SelectedExcel> \u0016(List<SelectedExcel> \u001F)
		{
			\u0004\u0002.\u0007\u0002 u0007_u = new \u0004\u0002.\u0007\u0002();
			u0007_u.\u001F = \u001F;
			\u001B\u000E\u0019.\u000A(true);
			List<SelectedExcel> list = \u0003\u000B\u0004.\u000A();
			\u0001\u0007\u0019.\u000A(list, SchemaUtil.\u001D(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>())));
			List<SelectedExcel> list2 = Enumerable.ToList<SelectedExcel>(Enumerable.Where<SelectedExcel>(list, new Func<SelectedExcel, bool>(u0007_u.\u000A)));
			Action<SelectedExcel> u000A;
			if ((u000A = \u0004\u0002.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0002.\u0016(List<SelectedExcel>)).MethodHandle;
				}
				u000A = (\u0004\u0002.<>c.\u000A = new Action<SelectedExcel>(\u0004\u0002.<>c.\u001F.\u0007));
			}
			\u0009\u0019\u0019.\u000A(list2, u000A);
			\u001B\u000E\u0019.\u000A(false);
			return list2;
		}

		// Token: 0x040005B5 RID: 1461
		private static string \u001F;

		// Token: 0x040005B6 RID: 1462
		private static string \u000A;

		// Token: 0x040005B7 RID: 1463
		private static string \u0007;

		// Token: 0x040005B8 RID: 1464
		private static string \u001D;

		// Token: 0x040005B9 RID: 1465
		[CompilerGenerated]
		private static bool \u0004;

		// Token: 0x040005BA RID: 1466
		[CompilerGenerated]
		private static string \u0019;

		// Token: 0x02000857 RID: 2135
		[CompilerGenerated]
		private sealed class \u0007\u0002
		{
			// Token: 0x06004EAA RID: 20138 RVA: 0x001E1474 File Offset: 0x001DF674
			internal bool \u000A(SelectedExcel \u001F)
			{
				\u0004\u0002.\u001D\u0002 u001D_u = new \u0004\u0002.\u001D\u0002();
				u001D_u.\u001F = \u001F;
				return !Enumerable.Any<SelectedExcel>(this.\u001F, new Func<SelectedExcel, bool>(u001D_u.\u000A));
			}

			// Token: 0x0400213E RID: 8510
			public List<SelectedExcel> \u001F;
		}

		// Token: 0x02000858 RID: 2136
		[CompilerGenerated]
		private sealed class \u001D\u0002
		{
			// Token: 0x06004EAC RID: 20140 RVA: 0x001E14C0 File Offset: 0x001DF6C0
			internal bool \u000A(SelectedExcel \u001F)
			{
				if (\u0009\u0005\u0004.\u000A(\u001F) == \u0009\u0005\u0004.\u000A(this.\u001F))
				{
					return true;
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0002.\u001D\u0002.\u000A(SelectedExcel)).MethodHandle;
				}
				if (\u0008\u0013\u000A.\u000A(\u0003\u000B\u001D.\u0007(\u0014\u0005\u0004.\u0007(\u001F)), \u0003\u000B\u001D.\u0007(\u0014\u0005\u0004.\u0007(this.\u001F))))
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
					return \u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(\u001F)) == \u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(this.\u001F));
				}
				return false;
			}

			// Token: 0x0400213F RID: 8511
			public SelectedExcel \u001F;
		}
	}
}

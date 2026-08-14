using System;
using System.Collections.Generic;
using System.Linq;
using DiRoots.One.Commons.Models;
using DiRoots.One.TGDatabaseLayer;

namespace A
{
	// Token: 0x0200012D RID: 301
	internal static class \u001D\u0016
	{
		// Token: 0x06000B7C RID: 2940 RVA: 0x000484FC File Offset: 0x000466FC
		internal static List<EnumInfo> \u001F()
		{
			List<EnumInfo> list = \u001A\u0014\u0004.\u000A(2);
			EnumInfo enumInfo = \u0017\u0014\u0004.\u000A();
			\u0009\u001B\u001D.\u000A(enumInfo, 0);
			\u0001\u001B\u001D.\u000A(enumInfo, "Recreate view");
			\u001E\u0014\u0004.\u000A(enumInfo, \u0013\u0014\u0004.\u000A());
			\u001B\u0014\u0004.\u000A(enumInfo, \u0014\u0014\u0004.\u000A());
			\u0008\u0014\u0004.\u000A(list, enumInfo);
			EnumInfo enumInfo2 = \u0017\u0014\u0004.\u000A();
			\u0009\u001B\u001D.\u000A(enumInfo2, 2);
			\u0001\u001B\u001D.\u000A(enumInfo2, "Data only");
			\u001E\u0014\u0004.\u000A(enumInfo2, \u0020\u0014\u0004.\u000A());
			\u001B\u0014\u0004.\u000A(enumInfo2, \u0011\u0014\u0004.\u000A());
			\u0008\u0014\u0004.\u000A(list, enumInfo2);
			return list;
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x00048584 File Offset: 0x00046784
		internal static List<EnumInfo> \u000A()
		{
			List<EnumInfo> list = \u001A\u0014\u0004.\u000A(3);
			EnumInfo enumInfo = \u0017\u0014\u0004.\u000A();
			\u0009\u001B\u001D.\u000A(enumInfo, 0);
			\u0001\u001B\u001D.\u000A(enumInfo, "Convert all colors to black");
			\u001E\u0014\u0004.\u000A(enumInfo, \u0001\u0014\u0004.\u000A());
			\u0008\u0014\u0004.\u000A(list, enumInfo);
			EnumInfo enumInfo2 = \u0017\u0014\u0004.\u000A();
			\u0009\u001B\u001D.\u000A(enumInfo2, 1);
			\u0001\u001B\u001D.\u000A(enumInfo2, "Keep white and grays");
			\u001E\u0014\u0004.\u000A(enumInfo2, \u0015\u0014\u0004.\u000A());
			\u0008\u0014\u0004.\u000A(list, enumInfo2);
			EnumInfo enumInfo3 = \u0017\u0014\u0004.\u000A();
			\u0009\u001B\u001D.\u000A(enumInfo3, 2);
			\u0001\u001B\u001D.\u000A(enumInfo3, "Convert colors to grayscale");
			\u001E\u0014\u0004.\u000A(enumInfo3, \u000C\u0014\u0004.\u000A());
			\u0008\u0014\u0004.\u000A(list, enumInfo3);
			return list;
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x00048620 File Offset: 0x00046820
		internal static List<EnumInfo> \u0007()
		{
			List<EnumInfo> list = \u001A\u0014\u0004.\u000A(3);
			EnumInfo enumInfo = \u0017\u0014\u0004.\u000A();
			\u0009\u001B\u001D.\u000A(enumInfo, 0);
			\u0001\u001B\u001D.\u000A(enumInfo, "Remove all backgrounds");
			\u001E\u0014\u0004.\u000A(enumInfo, \u000A\u0013\u0004.\u000A());
			\u0008\u0014\u0004.\u000A(list, enumInfo);
			EnumInfo enumInfo2 = \u0017\u0014\u0004.\u000A();
			\u0009\u001B\u001D.\u000A(enumInfo2, 1);
			\u0001\u001B\u001D.\u000A(enumInfo2, "Keep grays, remove colors");
			\u001E\u0014\u0004.\u000A(enumInfo2, \u001F\u0013\u0004.\u000A());
			\u0008\u0014\u0004.\u000A(list, enumInfo2);
			EnumInfo enumInfo3 = \u0017\u0014\u0004.\u000A();
			\u0009\u001B\u001D.\u000A(enumInfo3, 2);
			\u0001\u001B\u001D.\u000A(enumInfo3, "Convert to grayscale");
			\u001E\u0014\u0004.\u000A(enumInfo3, \u0009\u0014\u0004.\u000A());
			\u0008\u0014\u0004.\u000A(list, enumInfo3);
			return list;
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x000486BC File Offset: 0x000468BC
		internal static List<EnumInfo> \u001D()
		{
			List<EnumInfo> list = \u001A\u0014\u0004.\u000A(3);
			EnumInfo enumInfo = \u0017\u0014\u0004.\u000A();
			\u0009\u001B\u001D.\u000A(enumInfo, 11);
			\u0001\u001B\u001D.\u000A(enumInfo, "Legend View");
			\u001E\u0014\u0004.\u000A(enumInfo, \u0004\u0013\u0004.\u000A());
			\u0008\u0014\u0004.\u000A(list, enumInfo);
			EnumInfo enumInfo2 = \u0017\u0014\u0004.\u000A();
			\u0009\u001B\u001D.\u000A(enumInfo2, 5);
			\u0001\u001B\u001D.\u000A(enumInfo2, "Schedule View");
			\u001E\u0014\u0004.\u000A(enumInfo2, \u001D\u0013\u0004.\u000A());
			\u0008\u0014\u0004.\u000A(list, enumInfo2);
			EnumInfo enumInfo3 = \u0017\u0014\u0004.\u000A();
			\u0009\u001B\u001D.\u000A(enumInfo3, 10);
			\u0001\u001B\u001D.\u000A(enumInfo3, "Drafting View");
			\u001E\u0014\u0004.\u000A(enumInfo3, \u0007\u0013\u0004.\u000A());
			\u0008\u0014\u0004.\u000A(list, enumInfo3);
			return list;
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x00048758 File Offset: 0x00046958
		internal static List<EnumInfo> \u0004()
		{
			return \u001D\u0016.\u0018<ImportTypes>();
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x0004876C File Offset: 0x0004696C
		internal static List<EnumInfo> \u0019()
		{
			return \u001D\u0016.\u0018<SourceTypes>();
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x00048780 File Offset: 0x00046980
		internal static List<EnumInfo> \u0018<\u001F>() where \u001F : Enum
		{
			IEnumerable<\u001F> enumerable = Enumerable.Cast<\u001F>(\u000D\u0011\u001D.\u000A(\u001E\u0011\u000A.\u000A(typeof(\u001F).TypeHandle)));
			Func<\u001F, EnumInfo> func;
			if ((func = \u001D\u0016.<>c__6<\u001F>.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0016.\u0018()).MethodHandle;
				}
				func = (\u001D\u0016.<>c__6<\u001F>.\u000A = new Func<\u001F, EnumInfo>(\u001D\u0016.<>c__6<\u001F>.\u001F.\u0007));
			}
			return Enumerable.ToList<EnumInfo>(Enumerable.Select<\u001F, EnumInfo>(enumerable, func));
		}
	}
}

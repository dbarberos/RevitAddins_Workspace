using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace A
{
	// Token: 0x020000F8 RID: 248
	internal sealed class \u0007\u0005
	{
		// Token: 0x060008FE RID: 2302 RVA: 0x0003DF3C File Offset: 0x0003C13C
		public \u0007\u0005(HashSet<ExcelLineStyleInfo> \u001F, HashSet<ExcelTextStyleInfo> \u000A)
		{
			HashSet<ExcelLineStyleInfo> hashSet = \u001F;
			if (\u001F == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0007\u0005..ctor(HashSet<ExcelLineStyleInfo>, HashSet<ExcelTextStyleInfo>)).MethodHandle;
				}
				hashSet = new HashSet<ExcelLineStyleInfo>();
			}
			this.Lines = hashSet;
			HashSet<ExcelTextStyleInfo> hashSet2 = \u000A;
			if (\u000A == null)
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
				hashSet2 = new HashSet<ExcelTextStyleInfo>();
			}
			this.Texts = hashSet2;
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x060008FF RID: 2303 RVA: 0x0003DF8C File Offset: 0x0003C18C
		public HashSet<ExcelLineStyleInfo> Lines { get; }

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x0003DFA0 File Offset: 0x0003C1A0
		public HashSet<ExcelTextStyleInfo> Texts { get; }

		// Token: 0x0400036D RID: 877
		[CompilerGenerated]
		private readonly HashSet<ExcelLineStyleInfo> \u001F;

		// Token: 0x0400036E RID: 878
		[CompilerGenerated]
		private readonly HashSet<ExcelTextStyleInfo> \u000A;
	}
}

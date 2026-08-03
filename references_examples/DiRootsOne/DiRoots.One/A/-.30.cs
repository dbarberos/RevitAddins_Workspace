using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000042 RID: 66
	internal class \u0006\u000A
	{
		// Token: 0x06000221 RID: 545 RVA: 0x0000AF24 File Offset: 0x00009124
		public \u0006\u000A(Line \u001F)
		{
			\u0004\u000A\u0007.\u000A(this, \u001F);
			\u000A\u000A\u0007.\u000A(this, \u0007\u000A\u0007.\u000A(\u001D\u000A\u0007.\u000A(\u001F)));
			\u0001\u001F\u0007.\u000A(this, new \u0002\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0), \u0015\u001F\u0007.\u0007(this), true));
			\u000C\u001F\u0007.\u000A(this, new \u0002\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1), \u0015\u001F\u0007.\u0007(this), true));
			\u001A\u001F\u0007.\u000A(this, \u0013\u001F\u0007.\u0007(\u001F, 0));
			\u0014\u001F\u0007.\u000A(this, \u0013\u001F\u0007.\u0007(\u001F, 1));
			if (\u000B\u001F\u0007.\u001D(\u001F\u000A\u0007.\u0007(this)) > \u000B\u001F\u0007.\u001D(\u0009\u001F\u0007.\u000A(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0006\u000A..ctor(Line)).MethodHandle;
				}
				\u0001\u001F\u0007.\u000A(this, new \u0002\u000A(\u0013\u001F\u0007.\u0007(\u001F, 1), \u0015\u001F\u0007.\u0007(this), true));
				\u000C\u001F\u0007.\u000A(this, new \u0002\u000A(\u0013\u001F\u0007.\u0007(\u001F, 0), \u0015\u001F\u0007.\u0007(this), true));
				\u001A\u001F\u0007.\u000A(this, \u0013\u001F\u0007.\u0007(\u001F, 1));
				\u0014\u001F\u0007.\u000A(this, \u0013\u001F\u0007.\u0007(\u001F, 0));
			}
			\u001E\u001F\u0007.\u000A(this, new \u0002\u000A(\u0017\u001F\u0007.\u0007(this), \u0020\u001F\u0007.\u0007(this), false));
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000222 RID: 546 RVA: 0x0000B054 File Offset: 0x00009254
		// (set) Token: 0x06000223 RID: 547 RVA: 0x0000B068 File Offset: 0x00009268
		public Line Line { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000224 RID: 548 RVA: 0x0000B07C File Offset: 0x0000927C
		// (set) Token: 0x06000225 RID: 549 RVA: 0x0000B090 File Offset: 0x00009290
		public \u0002\u000A StartBoundary { get; set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000226 RID: 550 RVA: 0x0000B0A4 File Offset: 0x000092A4
		// (set) Token: 0x06000227 RID: 551 RVA: 0x0000B0B8 File Offset: 0x000092B8
		public \u0002\u000A EndBoundary { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000228 RID: 552 RVA: 0x0000B0CC File Offset: 0x000092CC
		// (set) Token: 0x06000229 RID: 553 RVA: 0x0000B0E0 File Offset: 0x000092E0
		public \u0002\u000A LongBoundary { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600022A RID: 554 RVA: 0x0000B0F4 File Offset: 0x000092F4
		// (set) Token: 0x0600022B RID: 555 RVA: 0x0000B108 File Offset: 0x00009308
		public XYZ Direction { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600022C RID: 556 RVA: 0x0000B11C File Offset: 0x0000931C
		// (set) Token: 0x0600022D RID: 557 RVA: 0x0000B130 File Offset: 0x00009330
		public XYZ StartPoint { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600022E RID: 558 RVA: 0x0000B144 File Offset: 0x00009344
		// (set) Token: 0x0600022F RID: 559 RVA: 0x0000B158 File Offset: 0x00009358
		public XYZ EndPoint { get; set; }

		// Token: 0x06000230 RID: 560 RVA: 0x0000B16C File Offset: 0x0000936C
		internal static List<\u0006\u000A> \u0005(List<\u0006\u000A> \u001F)
		{
			IEnumerable<\u0006\u000A> enumerable = \u001F;
			Func<\u0006\u000A, bool> func;
			if ((func = \u0006\u000A.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0006\u000A.\u0005(List<\u0006\u000A>)).MethodHandle;
				}
				func = (\u0006\u000A.<>c.\u000A = new Func<\u0006\u000A, bool>(\u0006\u000A.<>c.\u001F.\u001D));
			}
			\u001F = Enumerable.ToList<\u0006\u000A>(Enumerable.Where<\u0006\u000A>(enumerable, func));
			object u001F = \u001F;
			Comparison<\u0006\u000A> u000A;
			if ((u000A = \u0006\u000A.<>c.\u0007) == null)
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
				u000A = (\u0006\u000A.<>c.\u0007 = new Comparison<\u0006\u000A>(\u0006\u000A.<>c.\u001F.\u0004));
			}
			\u0019\u000A\u0007.\u000A(u001F, u000A);
			return \u001F;
		}

		// Token: 0x040000F0 RID: 240
		[CompilerGenerated]
		private Line \u001F;

		// Token: 0x040000F1 RID: 241
		[CompilerGenerated]
		private \u0002\u000A \u000A;

		// Token: 0x040000F2 RID: 242
		[CompilerGenerated]
		private \u0002\u000A \u0007;

		// Token: 0x040000F3 RID: 243
		[CompilerGenerated]
		private \u0002\u000A \u001D;

		// Token: 0x040000F4 RID: 244
		[CompilerGenerated]
		private XYZ \u0004;

		// Token: 0x040000F5 RID: 245
		[CompilerGenerated]
		private XYZ \u0019;

		// Token: 0x040000F6 RID: 246
		[CompilerGenerated]
		private XYZ \u0018;
	}
}

using System;
using System.Runtime.CompilerServices;
using A;

namespace DiRoots.One.TGDatabaseLayer.StyleMapping
{
	// Token: 0x02000121 RID: 289
	public class LineStyleMapping
	{
		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000AEB RID: 2795 RVA: 0x00046BB4 File Offset: 0x00044DB4
		// (set) Token: 0x06000AEC RID: 2796 RVA: 0x00046BC8 File Offset: 0x00044DC8
		public ExcelLineStyleInfo ExcelStyle { get; set; }

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06000AED RID: 2797 RVA: 0x00046BDC File Offset: 0x00044DDC
		// (set) Token: 0x06000AEE RID: 2798 RVA: 0x00046BF0 File Offset: 0x00044DF0
		public string RevitStyleName { get; set; }

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06000AEF RID: 2799 RVA: 0x00046C04 File Offset: 0x00044E04
		// (set) Token: 0x06000AF0 RID: 2800 RVA: 0x00046C18 File Offset: 0x00044E18
		public long? RevitStyleElementId { get; set; }

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06000AF1 RID: 2801 RVA: 0x00046C2C File Offset: 0x00044E2C
		// (set) Token: 0x06000AF2 RID: 2802 RVA: 0x00046C40 File Offset: 0x00044E40
		public bool IsNew { get; set; }

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06000AF3 RID: 2803 RVA: 0x00046C54 File Offset: 0x00044E54
		// (set) Token: 0x06000AF4 RID: 2804 RVA: 0x00046C68 File Offset: 0x00044E68
		public bool IsNone { get; set; }

		// Token: 0x06000AF5 RID: 2805 RVA: 0x00046C7C File Offset: 0x00044E7C
		public bool EqualsByValue(LineStyleMapping other)
		{
			if (other == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(LineStyleMapping.EqualsByValue(LineStyleMapping)).MethodHandle;
				}
				return false;
			}
			if (this == other)
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
			bool flag;
			if (\u000D\u0002\u0004.\u001D(this) != null)
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
				flag = \u000A\u0009\u001D.\u0007(\u000D\u0002\u0004.\u001D(this), \u000D\u0002\u0004.\u0007(other));
			}
			else
			{
				flag = (\u000D\u0002\u0004.\u0007(other) == \u0005\u0004\u000E.\u001F);
			}
			if (flag)
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
				if (\u001B\u0003\u0004.\u000A(\u0010\u0002\u0004.\u001D(this), \u0010\u0002\u0004.\u0007(other), StringComparison.Ordinal))
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
					return \u001B\u0002\u0004.\u001D(this) == \u001B\u0002\u0004.\u0007(other);
				}
			}
			return false;
		}

		// Token: 0x04000464 RID: 1124
		[CompilerGenerated]
		private ExcelLineStyleInfo \u001F;

		// Token: 0x04000465 RID: 1125
		[CompilerGenerated]
		private string \u000A;

		// Token: 0x04000466 RID: 1126
		[CompilerGenerated]
		private long? \u0007;

		// Token: 0x04000467 RID: 1127
		[CompilerGenerated]
		private bool \u001D;

		// Token: 0x04000468 RID: 1128
		[CompilerGenerated]
		private bool \u0004;
	}
}

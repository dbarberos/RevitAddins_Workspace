using System;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000015 RID: 21
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	[\u000E]
	[CompilerGenerated]
	internal sealed class \u0008 : Attribute
	{
		// Token: 0x060000C4 RID: 196 RVA: 0x0000482C File Offset: 0x00002A2C
		public \u0008(byte \u001F)
		{
			byte[] array = \u0019\u0015\u0010.\u001F(1);
			array[0] = \u001F;
			this.NullableFlags = array;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004854 File Offset: 0x00002A54
		public \u0008(byte[] \u001F)
		{
			this.NullableFlags = \u001F;
		}

		// Token: 0x0400002D RID: 45
		public readonly byte[] NullableFlags;
	}
}

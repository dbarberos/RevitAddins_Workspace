using System;
using System.Collections.Generic;
using A;

namespace DiRoots.One.TGDatabaseLayer.StyleMapping
{
	// Token: 0x02000122 RID: 290
	public sealed class LineStyleMappingComparer : IEqualityComparer<LineStyleMapping>
	{
		// Token: 0x06000AF8 RID: 2808 RVA: 0x00046D64 File Offset: 0x00044F64
		public bool Equals(LineStyleMapping x, LineStyleMapping y)
		{
			return \u000A\u0009\u001D.\u0007(\u000D\u0002\u0004.\u0007(x), \u000D\u0002\u0004.\u0007(y));
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x00046D88 File Offset: 0x00044F88
		public int GetHashCode(LineStyleMapping obj)
		{
			return \u001B\u0013\u000A.\u000A(\u000D\u0002\u0004.\u0007(obj));
		}

		// Token: 0x04000469 RID: 1129
		public static readonly LineStyleMappingComparer Instance = \u0019\u0020\u0004.\u000A();
	}
}

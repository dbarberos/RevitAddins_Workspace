using System;
using System.Collections.Generic;
using A;

namespace DiRoots.One.TGDatabaseLayer.StyleMapping
{
	// Token: 0x02000128 RID: 296
	public sealed class TextStyleMappingComparer : IEqualityComparer<TextStyleMapping>
	{
		// Token: 0x06000B28 RID: 2856 RVA: 0x000475E8 File Offset: 0x000457E8
		public bool Equals(TextStyleMapping x, TextStyleMapping y)
		{
			return \u001D\u0020\u0004.\u001D(\u0002\u000D\u0004.\u001D(x), \u0002\u000D\u0004.\u001D(y));
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0004760C File Offset: 0x0004580C
		public int GetHashCode(TextStyleMapping obj)
		{
			return \u001B\u0013\u000A.\u000A(\u0002\u000D\u0004.\u001D(obj));
		}

		// Token: 0x0400047A RID: 1146
		public static readonly TextStyleMappingComparer Instance = \u0006\u0020\u0004.\u000A();
	}
}

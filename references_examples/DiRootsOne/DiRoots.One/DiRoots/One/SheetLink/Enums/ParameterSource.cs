using System;
using System.ComponentModel.DataAnnotations;

namespace DiRoots.One.SheetLink.Enums
{
	// Token: 0x0200026D RID: 621
	public enum ParameterSource
	{
		// Token: 0x040009D7 RID: 2519
		[Display(Name = "Instance")]
		Instance = 1,
		// Token: 0x040009D8 RID: 2520
		[Display(Name = "Type")]
		Type,
		// Token: 0x040009D9 RID: 2521
		[Display(Name = "Read-only")]
		ReadOnly
	}
}

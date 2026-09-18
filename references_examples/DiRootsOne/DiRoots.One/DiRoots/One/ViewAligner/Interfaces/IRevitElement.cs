using System;

namespace DiRoots.One.ViewAligner.Interfaces
{
	// Token: 0x020000CB RID: 203
	public interface IRevitElement
	{
		// Token: 0x17000214 RID: 532
		// (get) Token: 0x060007C9 RID: 1993
		string UniqueId { get; }

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x060007CA RID: 1994
		long Id { get; }

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x060007CB RID: 1995
		string Name { get; }
	}
}

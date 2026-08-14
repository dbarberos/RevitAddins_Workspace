using System;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.ExtensibleStorage;

namespace DiRoots.One.SheetGen.Models
{
	// Token: 0x0200037C RID: 892
	[Schema("82646460-EFA9-4770-B828-A2F259CF02FF", "SheetStoredData", Documentation = "Data to be stored in view ports.")]
	public class ViewportStoredData : IRevitEntity
	{
		// Token: 0x06002494 RID: 9364 RVA: 0x000DF23C File Offset: 0x000DD43C
		public ViewportStoredData()
		{
		}

		// Token: 0x06002495 RID: 9365 RVA: 0x000DF250 File Offset: 0x000DD450
		public ViewportStoredData(string guid)
		{
			\u0011\u0019\u0016.\u001D(this, guid);
		}

		// Token: 0x17000A59 RID: 2649
		// (get) Token: 0x06002496 RID: 9366 RVA: 0x000DF26C File Offset: 0x000DD46C
		// (set) Token: 0x06002497 RID: 9367 RVA: 0x000DF280 File Offset: 0x000DD480
		[Field]
		public string GUID { get; set; }

		// Token: 0x04000E81 RID: 3713
		[CompilerGenerated]
		private string JL;
	}
}

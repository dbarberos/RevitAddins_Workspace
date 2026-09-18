using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.ExtensibleStorage;

namespace DiRoots.One.SheetGen.Models
{
	// Token: 0x0200037B RID: 891
	[Schema("FD7B9AF9-C7B3-459B-BFBA-117199F1197D", "SheetStoredData", Documentation = "Data to be stored in sheets.")]
	public class SheetStoredData : IRevitEntity
	{
		// Token: 0x06002491 RID: 9361 RVA: 0x000DF1F4 File Offset: 0x000DD3F4
		public SheetStoredData()
		{
			\u000C\u0015\u000B.\u000A(this, new List<string>());
		}

		// Token: 0x17000A58 RID: 2648
		// (get) Token: 0x06002492 RID: 9362 RVA: 0x000DF214 File Offset: 0x000DD414
		// (set) Token: 0x06002493 RID: 9363 RVA: 0x000DF228 File Offset: 0x000DD428
		[Field]
		public List<string> OrderedViewsGuid { get; set; }

		// Token: 0x04000E80 RID: 3712
		[CompilerGenerated]
		private List<string> WU;
	}
}

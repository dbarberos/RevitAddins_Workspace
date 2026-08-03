using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using A;

namespace DiRoots.One.SheetGen.Models
{
	// Token: 0x0200037A RID: 890
	[XmlInclude(typeof(ParameterModel))]
	[XmlInclude(typeof(SelectionParameter))]
	[XmlInclude(typeof(RevisionParameter))]
	[XmlInclude(typeof(ParameterIdValue))]
	[XmlInclude(typeof(ParameterStringValue))]
	[XmlInclude(typeof(ParameterIntegerValue))]
	[Serializable]
	public class VMProfile : Profile
	{
		// Token: 0x06002488 RID: 9352 RVA: 0x000DF138 File Offset: 0x000DD338
		public VMProfile()
		{
			\u001A\u0015\u000B.\u000A(this, true);
		}

		// Token: 0x17000A54 RID: 2644
		// (get) Token: 0x06002489 RID: 9353 RVA: 0x000DF154 File Offset: 0x000DD354
		// (set) Token: 0x0600248A RID: 9354 RVA: 0x000DF168 File Offset: 0x000DD368
		public override string Name { get; set; }

		// Token: 0x17000A55 RID: 2645
		// (get) Token: 0x0600248B RID: 9355 RVA: 0x000DF17C File Offset: 0x000DD37C
		// (set) Token: 0x0600248C RID: 9356 RVA: 0x000DF190 File Offset: 0x000DD390
		public override bool IsValid { get; set; }

		// Token: 0x17000A56 RID: 2646
		// (get) Token: 0x0600248D RID: 9357 RVA: 0x000DF1A4 File Offset: 0x000DD3A4
		// (set) Token: 0x0600248E RID: 9358 RVA: 0x000DF1B8 File Offset: 0x000DD3B8
		public override string FilePath { get; set; }

		// Token: 0x17000A57 RID: 2647
		// (get) Token: 0x0600248F RID: 9359 RVA: 0x000DF1CC File Offset: 0x000DD3CC
		// (set) Token: 0x06002490 RID: 9360 RVA: 0x000DF1E0 File Offset: 0x000DD3E0
		public List<List<SelectionParameter>> ViewManagerParameters { get; set; }
	}
}

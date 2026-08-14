using System;
using DiRoots.One.Commons.ExtensibleStorage;
using DiRoots.RoomPro.Interfaces;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000083 RID: 131
	[Schema("3FA59EEE-C602-409F-A5F7-59D786D50D30", "SectionNamingConfigurationSettings")]
	[Serializable]
	public class SectionNamingConfigurationSettings : IModelSettings, IRevitEntity
	{
		// Token: 0x17000174 RID: 372
		// (get) Token: 0x0600059F RID: 1439 RVA: 0x00020554 File Offset: 0x0001E754
		// (set) Token: 0x060005A0 RID: 1440 RVA: 0x00020568 File Offset: 0x0001E768
		[Field]
		public NamingConfigurationSettings NamingConfigurationSettings { get; set; }

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060005A1 RID: 1441 RVA: 0x0002057C File Offset: 0x0001E77C
		// (set) Token: 0x060005A2 RID: 1442 RVA: 0x00020590 File Offset: 0x0001E790
		[Field]
		public int ClockOrder { get; set; }

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060005A3 RID: 1443 RVA: 0x000205A4 File Offset: 0x0001E7A4
		// (set) Token: 0x060005A4 RID: 1444 RVA: 0x000205B8 File Offset: 0x0001E7B8
		[Field]
		public int Direction { get; set; }

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x000205CC File Offset: 0x0001E7CC
		// (set) Token: 0x060005A6 RID: 1446 RVA: 0x000205E0 File Offset: 0x0001E7E0
		[Field]
		public int CountStyle { get; set; }

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060005A7 RID: 1447 RVA: 0x000205F4 File Offset: 0x0001E7F4
		// (set) Token: 0x060005A8 RID: 1448 RVA: 0x00020608 File Offset: 0x0001E808
		[Field]
		public string StartValue { get; set; }
	}
}

using System;
using System.Collections.Generic;
using DiRoots.One.Commons.ExtensibleStorage;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000086 RID: 134
	[Schema("AD9F9658-15ED-49C1-AFD6-A10FC0BE04D0", "SpatialElementSchema", Documentation = "stored spatial elements with configurations")]
	public class SpatialElementsSchema : IRevitEntity
	{
		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060005DD RID: 1501 RVA: 0x00020CAC File Offset: 0x0001EEAC
		// (set) Token: 0x060005DE RID: 1502 RVA: 0x00020CC0 File Offset: 0x0001EEC0
		[Field]
		public List<ModelRoom> ModelRooms { get; set; }

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060005DF RID: 1503 RVA: 0x00020CD4 File Offset: 0x0001EED4
		// (set) Token: 0x060005E0 RID: 1504 RVA: 0x00020CE8 File Offset: 0x0001EEE8
		[Field]
		public List<ModelSpace> ModelSpaces { get; set; }
	}
}

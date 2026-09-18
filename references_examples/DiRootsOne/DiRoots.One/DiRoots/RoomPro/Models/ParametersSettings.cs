using System;
using System.Collections.Generic;
using DiRoots.One.Commons.ExtensibleStorage;
using DiRoots.RoomPro.Interfaces;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x0200007E RID: 126
	[Schema("2B039630-E1BB-4CC4-AD19-C89CDBAEB8FF", "StoredParametersSettingsData")]
	public class ParametersSettings : IModelSettings, IRevitEntity
	{
		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x0002011C File Offset: 0x0001E31C
		// (set) Token: 0x06000577 RID: 1399 RVA: 0x00020130 File Offset: 0x0001E330
		[Field]
		public List<SpatialElementParameter> SpatialElementParameters { get; set; } = new List<SpatialElementParameter>();
	}
}

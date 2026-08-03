using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Autodesk.Revit.DB;

namespace ProSheets.Commons.CustomNameManageWindow.Models.Interfaces
{
	// Token: 0x02000144 RID: 324
	public interface IParameterModel
	{
		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x0600100D RID: 4109
		// (set) Token: 0x0600100E RID: 4110
		bool IsProjectParameter { get; set; }

		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x0600100F RID: 4111
		// (set) Token: 0x06001010 RID: 4112
		bool IsCustomParameter { get; set; }

		// Token: 0x1700057C RID: 1404
		// (get) Token: 0x06001011 RID: 4113
		// (set) Token: 0x06001012 RID: 4114
		string ParameterName { get; set; }

		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x06001013 RID: 4115
		[XmlIgnore]
		string DisplayName { get; }

		// Token: 0x1700057E RID: 1406
		// (get) Token: 0x06001014 RID: 4116
		// (set) Token: 0x06001015 RID: 4117
		long ParameterId { get; set; }

		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x06001016 RID: 4118
		// (set) Token: 0x06001017 RID: 4119
		StorageType StorageType { get; set; }

		// Token: 0x17000580 RID: 1408
		// (get) Token: 0x06001018 RID: 4120
		// (set) Token: 0x06001019 RID: 4121
		List<ParameterModel> ParameterModels { get; set; }
	}
}

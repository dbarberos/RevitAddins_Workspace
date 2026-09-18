using System;
using DiRoots.One.Commons.ExtensibleStorage;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000071 RID: 113
	[Schema("17109CAF-864E-4703-99A3-72BF5A00233E", "StoredCalloutUserSettingsData", Documentation = "CalloutUserSettings Data to be stored.")]
	public class CalloutUserSettings : IRevitEntity
	{
		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060004E0 RID: 1248 RVA: 0x0001E9FC File Offset: 0x0001CBFC
		// (set) Token: 0x060004E1 RID: 1249 RVA: 0x0001EA10 File Offset: 0x0001CC10
		[Field]
		public CalloutViewSettings CalloutViewSettings { get; set; } = new CalloutViewSettings();

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x0001EA24 File Offset: 0x0001CC24
		// (set) Token: 0x060004E3 RID: 1251 RVA: 0x0001EA38 File Offset: 0x0001CC38
		[Field]
		public NamingConfigurationSettings NamingConfigurationSettings { get; set; } = new NamingConfigurationSettings();

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060004E4 RID: 1252 RVA: 0x0001EA4C File Offset: 0x0001CC4C
		// (set) Token: 0x060004E5 RID: 1253 RVA: 0x0001EA60 File Offset: 0x0001CC60
		[Field]
		public ParametersSettings ParametersSettings { get; set; } = new ParametersSettings();
	}
}

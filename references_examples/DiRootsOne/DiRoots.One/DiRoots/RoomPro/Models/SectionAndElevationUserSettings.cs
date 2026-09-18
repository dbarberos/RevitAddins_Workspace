using System;
using DiRoots.One.Commons.ExtensibleStorage;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000081 RID: 129
	[Schema("7BF762DB-72A5-4ABC-95C5-F5F6EF776BBF", "StoredSectionAndElevationUserSettingsData", Documentation = "SectionAndElevationUserSettings Data to be stored.")]
	public class SectionAndElevationUserSettings : IRevitEntity
	{
		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000587 RID: 1415 RVA: 0x0002036C File Offset: 0x0001E56C
		// (set) Token: 0x06000588 RID: 1416 RVA: 0x00020380 File Offset: 0x0001E580
		[Field]
		public SectionViewSettings SectionViewSettings { get; set; } = new SectionViewSettings();

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x00020394 File Offset: 0x0001E594
		// (set) Token: 0x0600058A RID: 1418 RVA: 0x000203A8 File Offset: 0x0001E5A8
		[Field]
		public SectionNamingConfigurationSettings NamingConfigurationSettings { get; set; } = new SectionNamingConfigurationSettings();

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x000203BC File Offset: 0x0001E5BC
		// (set) Token: 0x0600058C RID: 1420 RVA: 0x000203D0 File Offset: 0x0001E5D0
		[Field]
		public ParametersSettings ParametersSettings { get; set; } = new ParametersSettings();
	}
}

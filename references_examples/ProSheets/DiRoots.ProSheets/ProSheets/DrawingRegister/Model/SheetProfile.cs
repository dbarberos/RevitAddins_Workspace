using System;
using System.Collections.Generic;
using ProSheets.DrawingRegister.Enums;
using ProSheets.DrawingRegister.Model.TreeViewModel;

namespace ProSheets.DrawingRegister.Model
{
	// Token: 0x02000121 RID: 289
	[Serializable]
	public class SheetProfile
	{
		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06000EA8 RID: 3752 RVA: 0x00054934 File Offset: 0x00052B34
		// (set) Token: 0x06000EA9 RID: 3753 RVA: 0x00054948 File Offset: 0x00052B48
		public List<ViewInfo> SelectViewInfo { get; set; }

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06000EAA RID: 3754 RVA: 0x0005495C File Offset: 0x00052B5C
		// (set) Token: 0x06000EAB RID: 3755 RVA: 0x00054970 File Offset: 0x00052B70
		public List<ParameterInformation> SelectedParameter { get; set; }

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06000EAC RID: 3756 RVA: 0x00054984 File Offset: 0x00052B84
		// (set) Token: 0x06000EAD RID: 3757 RVA: 0x00054998 File Offset: 0x00052B98
		public string SelectedBrowserOrganizationKey { get; set; }

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x06000EAE RID: 3758 RVA: 0x000549AC File Offset: 0x00052BAC
		// (set) Token: 0x06000EAF RID: 3759 RVA: 0x000549C0 File Offset: 0x00052BC0
		public bool IsLinkedFile { get; set; }

		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x06000EB0 RID: 3760 RVA: 0x000549D4 File Offset: 0x00052BD4
		// (set) Token: 0x06000EB1 RID: 3761 RVA: 0x000549E8 File Offset: 0x00052BE8
		public BrowserOption SelectBrowserOption { get; set; }

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06000EB2 RID: 3762 RVA: 0x000549FC File Offset: 0x00052BFC
		// (set) Token: 0x06000EB3 RID: 3763 RVA: 0x00054A10 File Offset: 0x00052C10
		public List<string> SelectedSheetsUniqueIds { get; set; }

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x06000EB4 RID: 3764 RVA: 0x00054A24 File Offset: 0x00052C24
		// (set) Token: 0x06000EB5 RID: 3765 RVA: 0x00054A38 File Offset: 0x00052C38
		public string SelectSheetList { get; set; }
	}
}

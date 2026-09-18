using System;
using System.Collections.Generic;

namespace ProSheets.DrawingRegister.Model
{
	// Token: 0x0200011F RID: 287
	[Serializable]
	public class RevisionProfile
	{
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06000E94 RID: 3732 RVA: 0x00054798 File Offset: 0x00052998
		// (set) Token: 0x06000E95 RID: 3733 RVA: 0x000547AC File Offset: 0x000529AC
		public List<RevisionData> SelectRevisionData { get; set; }

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06000E96 RID: 3734 RVA: 0x000547C0 File Offset: 0x000529C0
		// (set) Token: 0x06000E97 RID: 3735 RVA: 0x000547D4 File Offset: 0x000529D4
		public int MaxRevisionCount { get; set; }

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06000E98 RID: 3736 RVA: 0x000547E8 File Offset: 0x000529E8
		// (set) Token: 0x06000E99 RID: 3737 RVA: 0x000547FC File Offset: 0x000529FC
		public bool IsRevisionEnable { get; set; }

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06000E9A RID: 3738 RVA: 0x00054810 File Offset: 0x00052A10
		// (set) Token: 0x06000E9B RID: 3739 RVA: 0x00054824 File Offset: 0x00052A24
		public bool IsLinkedFile { get; set; }

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06000E9C RID: 3740 RVA: 0x00054838 File Offset: 0x00052A38
		// (set) Token: 0x06000E9D RID: 3741 RVA: 0x0005484C File Offset: 0x00052A4C
		public List<string> CheckedRevisionUniqueIds { get; set; } = new List<string>();

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06000E9E RID: 3742 RVA: 0x00054860 File Offset: 0x00052A60
		// (set) Token: 0x06000E9F RID: 3743 RVA: 0x00054874 File Offset: 0x00052A74
		public string RevisionMark { get; set; }

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06000EA0 RID: 3744 RVA: 0x00054888 File Offset: 0x00052A88
		// (set) Token: 0x06000EA1 RID: 3745 RVA: 0x0005489C File Offset: 0x00052A9C
		public int RevisionNumbering { get; set; }
	}
}

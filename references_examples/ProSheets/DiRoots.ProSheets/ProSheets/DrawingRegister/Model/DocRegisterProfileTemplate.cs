using System;
using System.IO;
using System.Xml.Serialization;
using A;
using DiRoots.ProfileControl;

namespace ProSheets.DrawingRegister.Model
{
	// Token: 0x0200011A RID: 282
	[Serializable]
	public class DocRegisterProfileTemplate : ProfileTemplate
	{
		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06000E4B RID: 3659 RVA: 0x00053FE0 File Offset: 0x000521E0
		// (set) Token: 0x06000E4C RID: 3660 RVA: 0x00053FF4 File Offset: 0x000521F4
		public HeaderProfile HeaderProfiles { get; set; }

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06000E4D RID: 3661 RVA: 0x00054008 File Offset: 0x00052208
		// (set) Token: 0x06000E4E RID: 3662 RVA: 0x0005401C File Offset: 0x0005221C
		public RevisionProfile RevisionProfiles { get; set; }

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06000E4F RID: 3663 RVA: 0x00054030 File Offset: 0x00052230
		// (set) Token: 0x06000E50 RID: 3664 RVA: 0x00054044 File Offset: 0x00052244
		public SheetProfile SheetProfiles { get; set; }

		// Token: 0x06000E51 RID: 3665 RVA: 0x00054058 File Offset: 0x00052258
		public override ProfileTemplate Clone()
		{
			XmlSerializer u000C = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u0007\u0006\u000F.\u000C()));
			MemoryStream memoryStream = \u0009\u0016\u000F.\u0018();
			\u0013\u0016\u000F.\u0018(u000C, memoryStream, this);
			\u001C\u0016\u000F.\u0018(memoryStream, 0L);
			return \u001C\u0008\u000F.\u000C(\u000D\u0016\u000F.\u0018(u000C, memoryStream));
		}
	}
}

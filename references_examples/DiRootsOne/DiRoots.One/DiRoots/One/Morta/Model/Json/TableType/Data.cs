using System;
using System.Collections.Generic;

namespace DiRoots.One.Morta.Model.Json.TableType
{
	// Token: 0x020001C8 RID: 456
	[Serializable]
	public class Data
	{
		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x0600110C RID: 4364 RVA: 0x0006966C File Offset: 0x0006786C
		// (set) Token: 0x0600110D RID: 4365 RVA: 0x00069680 File Offset: 0x00067880
		public int adminLimit { get; set; }

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x0600110E RID: 4366 RVA: 0x00069694 File Offset: 0x00067894
		// (set) Token: 0x0600110F RID: 4367 RVA: 0x000696A8 File Offset: 0x000678A8
		public int automationLimit { get; set; }

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06001110 RID: 4368 RVA: 0x000696BC File Offset: 0x000678BC
		// (set) Token: 0x06001111 RID: 4369 RVA: 0x000696D0 File Offset: 0x000678D0
		public DateTime createdAt { get; set; }

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06001112 RID: 4370 RVA: 0x000696E4 File Offset: 0x000678E4
		// (set) Token: 0x06001113 RID: 4371 RVA: 0x000696F8 File Offset: 0x000678F8
		public string defaultProcessId { get; set; }

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06001114 RID: 4372 RVA: 0x0006970C File Offset: 0x0006790C
		// (set) Token: 0x06001115 RID: 4373 RVA: 0x00069720 File Offset: 0x00067920
		public object deletedAt { get; set; }

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06001116 RID: 4374 RVA: 0x00069734 File Offset: 0x00067934
		// (set) Token: 0x06001117 RID: 4375 RVA: 0x00069748 File Offset: 0x00067948
		public List<Folder> folders { get; set; }

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06001118 RID: 4376 RVA: 0x0006975C File Offset: 0x0006795C
		// (set) Token: 0x06001119 RID: 4377 RVA: 0x00069770 File Offset: 0x00067970
		public List<object> headingStyles { get; set; }

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x0600111A RID: 4378 RVA: 0x00069784 File Offset: 0x00067984
		// (set) Token: 0x0600111B RID: 4379 RVA: 0x00069798 File Offset: 0x00067998
		public bool hideProcessCreated { get; set; }

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x0600111C RID: 4380 RVA: 0x000697AC File Offset: 0x000679AC
		// (set) Token: 0x0600111D RID: 4381 RVA: 0x000697C0 File Offset: 0x000679C0
		public bool isDeleted { get; set; }

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x0600111E RID: 4382 RVA: 0x000697D4 File Offset: 0x000679D4
		// (set) Token: 0x0600111F RID: 4383 RVA: 0x000697E8 File Offset: 0x000679E8
		public object logo { get; set; }

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06001120 RID: 4384 RVA: 0x000697FC File Offset: 0x000679FC
		// (set) Token: 0x06001121 RID: 4385 RVA: 0x00069810 File Offset: 0x00067A10
		public bool mfaRequired { get; set; }

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06001122 RID: 4386 RVA: 0x00069824 File Offset: 0x00067A24
		// (set) Token: 0x06001123 RID: 4387 RVA: 0x00069838 File Offset: 0x00067A38
		public string name { get; set; }

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x06001124 RID: 4388 RVA: 0x0006984C File Offset: 0x00067A4C
		// (set) Token: 0x06001125 RID: 4389 RVA: 0x00069860 File Offset: 0x00067A60
		public int noOfAdmins { get; set; }

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x06001126 RID: 4390 RVA: 0x00069874 File Offset: 0x00067A74
		// (set) Token: 0x06001127 RID: 4391 RVA: 0x00069888 File Offset: 0x00067A88
		public string primaryColour { get; set; }

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x06001128 RID: 4392 RVA: 0x0006989C File Offset: 0x00067A9C
		// (set) Token: 0x06001129 RID: 4393 RVA: 0x000698B0 File Offset: 0x00067AB0
		public bool processTitleBold { get; set; }

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x0600112A RID: 4394 RVA: 0x000698C4 File Offset: 0x00067AC4
		// (set) Token: 0x0600112B RID: 4395 RVA: 0x000698D8 File Offset: 0x00067AD8
		public string processTitleColour { get; set; }

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x0600112C RID: 4396 RVA: 0x000698EC File Offset: 0x00067AEC
		// (set) Token: 0x0600112D RID: 4397 RVA: 0x00069900 File Offset: 0x00067B00
		public double processTitleFontSize { get; set; }

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x0600112E RID: 4398 RVA: 0x00069914 File Offset: 0x00067B14
		// (set) Token: 0x0600112F RID: 4399 RVA: 0x00069928 File Offset: 0x00067B28
		public bool processTitleItalic { get; set; }

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06001130 RID: 4400 RVA: 0x0006993C File Offset: 0x00067B3C
		// (set) Token: 0x06001131 RID: 4401 RVA: 0x00069950 File Offset: 0x00067B50
		public bool processTitleUnderline { get; set; }

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06001132 RID: 4402 RVA: 0x00069964 File Offset: 0x00067B64
		// (set) Token: 0x06001133 RID: 4403 RVA: 0x00069978 File Offset: 0x00067B78
		public List<ProjectList> projectList { get; set; }

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06001134 RID: 4404 RVA: 0x0006998C File Offset: 0x00067B8C
		// (set) Token: 0x06001135 RID: 4405 RVA: 0x000699A0 File Offset: 0x00067BA0
		public bool @public { get; set; }

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06001136 RID: 4406 RVA: 0x000699B4 File Offset: 0x00067BB4
		// (set) Token: 0x06001137 RID: 4407 RVA: 0x000699C8 File Offset: 0x00067BC8
		public string publicId { get; set; }

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06001138 RID: 4408 RVA: 0x000699DC File Offset: 0x00067BDC
		// (set) Token: 0x06001139 RID: 4409 RVA: 0x000699F0 File Offset: 0x00067BF0
		public string role { get; set; }

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x0600113A RID: 4410 RVA: 0x00069A04 File Offset: 0x00067C04
		// (set) Token: 0x0600113B RID: 4411 RVA: 0x00069A18 File Offset: 0x00067C18
		public DateTime updatedAt { get; set; }
	}
}

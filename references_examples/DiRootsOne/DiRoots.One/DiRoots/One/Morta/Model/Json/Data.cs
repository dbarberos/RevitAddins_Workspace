using System;

namespace DiRoots.One.Morta.Model.Json
{
	// Token: 0x020001C0 RID: 448
	[Serializable]
	public class Data
	{
		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x060010AE RID: 4270 RVA: 0x00068F14 File Offset: 0x00067114
		// (set) Token: 0x060010AF RID: 4271 RVA: 0x00068F28 File Offset: 0x00067128
		public Apikey[] apiKeys { get; set; }

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x060010B0 RID: 4272 RVA: 0x00068F3C File Offset: 0x0006713C
		// (set) Token: 0x060010B1 RID: 4273 RVA: 0x00068F50 File Offset: 0x00067150
		public string authToken { get; set; }

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x060010B2 RID: 4274 RVA: 0x00068F64 File Offset: 0x00067164
		// (set) Token: 0x060010B3 RID: 4275 RVA: 0x00068F78 File Offset: 0x00067178
		public object autodeskConnected { get; set; }

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x060010B4 RID: 4276 RVA: 0x00068F8C File Offset: 0x0006718C
		// (set) Token: 0x060010B5 RID: 4277 RVA: 0x00068FA0 File Offset: 0x000671A0
		public object bio { get; set; }

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x060010B6 RID: 4278 RVA: 0x00068FB4 File Offset: 0x000671B4
		// (set) Token: 0x060010B7 RID: 4279 RVA: 0x00068FC8 File Offset: 0x000671C8
		public object[] constructionSoftware { get; set; }

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x060010B8 RID: 4280 RVA: 0x00068FDC File Offset: 0x000671DC
		// (set) Token: 0x060010B9 RID: 4281 RVA: 0x00068FF0 File Offset: 0x000671F0
		public string email { get; set; }

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x060010BA RID: 4282 RVA: 0x00069004 File Offset: 0x00067204
		// (set) Token: 0x060010BB RID: 4283 RVA: 0x00069018 File Offset: 0x00067218
		public object[] favourites { get; set; }

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x060010BC RID: 4284 RVA: 0x0006902C File Offset: 0x0006722C
		// (set) Token: 0x060010BD RID: 4285 RVA: 0x00069040 File Offset: 0x00067240
		public string firebaseUserId { get; set; }

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x060010BE RID: 4286 RVA: 0x00069054 File Offset: 0x00067254
		// (set) Token: 0x060010BF RID: 4287 RVA: 0x00069068 File Offset: 0x00067268
		public bool hasPassword { get; set; }

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x060010C0 RID: 4288 RVA: 0x0006907C File Offset: 0x0006727C
		// (set) Token: 0x060010C1 RID: 4289 RVA: 0x00069090 File Offset: 0x00067290
		public int id { get; set; }

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x060010C2 RID: 4290 RVA: 0x000690A4 File Offset: 0x000672A4
		// (set) Token: 0x060010C3 RID: 4291 RVA: 0x000690B8 File Offset: 0x000672B8
		public bool is2FaEnabled { get; set; }

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x060010C4 RID: 4292 RVA: 0x000690CC File Offset: 0x000672CC
		// (set) Token: 0x060010C5 RID: 4293 RVA: 0x000690E0 File Offset: 0x000672E0
		public object lastLoginAt { get; set; }

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x060010C6 RID: 4294 RVA: 0x000690F4 File Offset: 0x000672F4
		// (set) Token: 0x060010C7 RID: 4295 RVA: 0x00069108 File Offset: 0x00067308
		public object linkedin { get; set; }

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x060010C8 RID: 4296 RVA: 0x0006911C File Offset: 0x0006731C
		// (set) Token: 0x060010C9 RID: 4297 RVA: 0x00069130 File Offset: 0x00067330
		public object location { get; set; }

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x060010CA RID: 4298 RVA: 0x00069144 File Offset: 0x00067344
		// (set) Token: 0x060010CB RID: 4299 RVA: 0x00069158 File Offset: 0x00067358
		public string name { get; set; }

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x060010CC RID: 4300 RVA: 0x0006916C File Offset: 0x0006736C
		// (set) Token: 0x060010CD RID: 4301 RVA: 0x00069180 File Offset: 0x00067380
		public object organisation { get; set; }

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x060010CE RID: 4302 RVA: 0x00069194 File Offset: 0x00067394
		// (set) Token: 0x060010CF RID: 4303 RVA: 0x000691A8 File Offset: 0x000673A8
		public object phone { get; set; }

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x060010D0 RID: 4304 RVA: 0x000691BC File Offset: 0x000673BC
		// (set) Token: 0x060010D1 RID: 4305 RVA: 0x000691D0 File Offset: 0x000673D0
		public object profilePicture { get; set; }

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x060010D2 RID: 4306 RVA: 0x000691E4 File Offset: 0x000673E4
		// (set) Token: 0x060010D3 RID: 4307 RVA: 0x000691F8 File Offset: 0x000673F8
		public object[] projectsWorkedOn { get; set; }

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x060010D4 RID: 4308 RVA: 0x0006920C File Offset: 0x0006740C
		// (set) Token: 0x060010D5 RID: 4309 RVA: 0x00069220 File Offset: 0x00067420
		public string publicId { get; set; }

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x060010D6 RID: 4310 RVA: 0x00069234 File Offset: 0x00067434
		// (set) Token: 0x060010D7 RID: 4311 RVA: 0x00069248 File Offset: 0x00067448
		public object signature { get; set; }

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x060010D8 RID: 4312 RVA: 0x0006925C File Offset: 0x0006745C
		// (set) Token: 0x060010D9 RID: 4313 RVA: 0x00069270 File Offset: 0x00067470
		public object[] specialisms { get; set; }

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x060010DA RID: 4314 RVA: 0x00069284 File Offset: 0x00067484
		// (set) Token: 0x060010DB RID: 4315 RVA: 0x00069298 File Offset: 0x00067498
		public Tag[] tags { get; set; }

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x060010DC RID: 4316 RVA: 0x000692AC File Offset: 0x000674AC
		// (set) Token: 0x060010DD RID: 4317 RVA: 0x000692C0 File Offset: 0x000674C0
		public object twitter { get; set; }

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x060010DE RID: 4318 RVA: 0x000692D4 File Offset: 0x000674D4
		// (set) Token: 0x060010DF RID: 4319 RVA: 0x000692E8 File Offset: 0x000674E8
		public object university { get; set; }

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x060010E0 RID: 4320 RVA: 0x000692FC File Offset: 0x000674FC
		// (set) Token: 0x060010E1 RID: 4321 RVA: 0x00069310 File Offset: 0x00067510
		public object universityDegree { get; set; }

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x060010E2 RID: 4322 RVA: 0x00069324 File Offset: 0x00067524
		// (set) Token: 0x060010E3 RID: 4323 RVA: 0x00069338 File Offset: 0x00067538
		public object viewpointConnected { get; set; }

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x060010E4 RID: 4324 RVA: 0x0006934C File Offset: 0x0006754C
		// (set) Token: 0x060010E5 RID: 4325 RVA: 0x00069360 File Offset: 0x00067560
		public object website { get; set; }
	}
}

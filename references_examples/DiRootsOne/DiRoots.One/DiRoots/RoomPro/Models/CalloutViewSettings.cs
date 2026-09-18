using System;
using DiRoots.One.Commons.ExtensibleStorage;
using DiRoots.RoomPro.Interfaces;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000072 RID: 114
	[Schema("F8DB62DF-706B-4343-9EB8-FE63283DD647", "StoredCalloutViewSettingsData")]
	[Serializable]
	public class CalloutViewSettings : IModelSettings, IRevitEntity
	{
		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060004E7 RID: 1255 RVA: 0x0001EA88 File Offset: 0x0001CC88
		// (set) Token: 0x060004E8 RID: 1256 RVA: 0x0001EA9C File Offset: 0x0001CC9C
		[Field]
		public ModelViewType CalloutType { get; set; }

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x0001EAB0 File Offset: 0x0001CCB0
		// (set) Token: 0x060004EA RID: 1258 RVA: 0x0001EAC4 File Offset: 0x0001CCC4
		[Field]
		public int Scale { get; set; }

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x0001EAD8 File Offset: 0x0001CCD8
		// (set) Token: 0x060004EC RID: 1260 RVA: 0x0001EAEC File Offset: 0x0001CCEC
		[Field]
		public int ViewDetailLevel { get; set; }

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x0001EB00 File Offset: 0x0001CD00
		// (set) Token: 0x060004EE RID: 1262 RVA: 0x0001EB14 File Offset: 0x0001CD14
		[Field]
		public ModelPhase Phase { get; set; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x0001EB28 File Offset: 0x0001CD28
		// (set) Token: 0x060004F0 RID: 1264 RVA: 0x0001EB3C File Offset: 0x0001CD3C
		[Field]
		public ViewTemplate ViewTemplate { get; set; }

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0001EB50 File Offset: 0x0001CD50
		// (set) Token: 0x060004F2 RID: 1266 RVA: 0x0001EB64 File Offset: 0x0001CD64
		[Field]
		public double OffsetFromBoundary { get; set; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x0001EB78 File Offset: 0x0001CD78
		// (set) Token: 0x060004F4 RID: 1268 RVA: 0x0001EB8C File Offset: 0x0001CD8C
		[Field]
		public int SelectedCalloutShape { get; set; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060004F5 RID: 1269 RVA: 0x0001EBA0 File Offset: 0x0001CDA0
		// (set) Token: 0x060004F6 RID: 1270 RVA: 0x0001EBB4 File Offset: 0x0001CDB4
		[Field]
		public bool IsCallOutDependent { get; set; }
	}
}

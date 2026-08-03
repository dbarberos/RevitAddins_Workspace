using System;

namespace DiRoots.One.TGDatabaseLayer
{
	// Token: 0x02000109 RID: 265
	[Serializable]
	public enum UpdateStates
	{
		// Token: 0x040003BE RID: 958
		Updated,
		// Token: 0x040003BF RID: 959
		Modified,
		// Token: 0x040003C0 RID: 960
		ToTrash,
		// Token: 0x040003C1 RID: 961
		ToAdd,
		// Token: 0x040003C2 RID: 962
		ToDuplicate,
		// Token: 0x040003C3 RID: 963
		ToUnlink,
		// Token: 0x040003C4 RID: 964
		Recreate
	}
}

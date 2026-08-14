using System;
using System.ComponentModel;
using DiRoots.One.EnumHelpers;
using DiRoots.One.LanguageDictionary;
using DiRoots.One.UIBehaviours.Converters;

namespace DiRoots.RoomPro.Enums
{
	// Token: 0x0200009D RID: 157
	[TypeConverter(typeof(EnumDescriptionToCBConverter))]
	public enum SpatialElementStatus
	{
		// Token: 0x04000283 RID: 643
		[LocalizedDescription(typeof(LangDictQV), "Created")]
		Created,
		// Token: 0x04000284 RID: 644
		[LocalizedDescription(typeof(LangDictQV), "NotCreated")]
		NotCreated,
		// Token: 0x04000285 RID: 645
		[LocalizedDescription(typeof(LangDictQV), "Changed")]
		Changed
	}
}

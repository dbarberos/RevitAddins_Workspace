using System;
using System.ComponentModel;
using DiRoots.One.EnumHelpers;
using DiRoots.One.LanguageDictionary;
using DiRoots.One.UIBehaviours.Converters;

namespace DiRoots.RoomPro.Enums
{
	// Token: 0x0200009E RID: 158
	[TypeConverter(typeof(EnumDescriptionToCBConverter))]
	public enum SpatialStatus
	{
		// Token: 0x04000287 RID: 647
		[LocalizedDescription(typeof(LangDictQV), "Created")]
		Created,
		// Token: 0x04000288 RID: 648
		[LocalizedDescription(typeof(LangDictQV), "NotCreated")]
		NotCreated,
		// Token: 0x04000289 RID: 649
		[LocalizedDescription(typeof(LangDictQV), "Changed")]
		Changed
	}
}

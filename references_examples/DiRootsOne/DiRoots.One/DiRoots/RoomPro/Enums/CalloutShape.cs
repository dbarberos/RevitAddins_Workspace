using System;
using System.ComponentModel;
using DiRoots.One.EnumHelpers;
using DiRoots.One.LanguageDictionary;
using DiRoots.One.UIBehaviours.Converters;

namespace DiRoots.RoomPro.Enums
{
	// Token: 0x02000094 RID: 148
	[TypeConverter(typeof(EnumDescriptionToCBConverter))]
	public enum CalloutShape
	{
		// Token: 0x04000266 RID: 614
		[LocalizedDescription(typeof(LangDictQV), "Rectangle")]
		Rectangle,
		// Token: 0x04000267 RID: 615
		[LocalizedDescription(typeof(LangDictQV), "AlignedWithRoomBoundary")]
		AlignedWithRoomBoundary
	}
}

using System;
using System.ComponentModel;
using DiRoots.One.EnumHelpers;
using DiRoots.One.LanguageDictionary;
using DiRoots.One.UIBehaviours.Converters;

namespace DiRoots.RoomPro.Enums
{
	// Token: 0x0200009A RID: 154
	[TypeConverter(typeof(EnumDescriptionToCBConverter))]
	public enum SpatialType
	{
		// Token: 0x04000278 RID: 632
		[Description("Space")]
		[LocalizedDescription(typeof(LangDictQV), "Spaces")]
		Space,
		// Token: 0x04000279 RID: 633
		[LocalizedDescription(typeof(LangDictQV), "Rooms")]
		[Description("Room")]
		Room
	}
}

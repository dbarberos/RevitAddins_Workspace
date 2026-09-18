using System;
using System.ComponentModel;
using DiRoots.One.EnumHelpers;
using DiRoots.One.LanguageDictionary;
using DiRoots.One.UIBehaviours.Converters;

namespace DiRoots.RoomPro.Enums
{
	// Token: 0x02000099 RID: 153
	[TypeConverter(typeof(EnumDescriptionToCBConverter))]
	public enum ModelSpatialElementType
	{
		// Token: 0x04000273 RID: 627
		[Description("Spaces & Rooms")]
		All,
		// Token: 0x04000274 RID: 628
		[Description("Spaces")]
		[LocalizedDescription(typeof(LangDictQV), "Spaces")]
		Spaces,
		// Token: 0x04000275 RID: 629
		[Description("Rooms")]
		[LocalizedDescription(typeof(LangDictQV), "Rooms")]
		Rooms,
		// Token: 0x04000276 RID: 630
		[Description("None")]
		[LocalizedDescription(typeof(LangDictQV), "None")]
		None
	}
}

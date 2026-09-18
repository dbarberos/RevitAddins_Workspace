using System;
using System.ComponentModel;
using DiRoots.One.EnumHelpers;
using DiRoots.One.LanguageDictionary;
using DiRoots.One.UIBehaviours.Converters;

namespace DiRoots.RoomPro.Enums
{
	// Token: 0x02000098 RID: 152
	[TypeConverter(typeof(EnumDescriptionToCBConverter))]
	internal enum HeightReference
	{
		// Token: 0x04000270 RID: 624
		[LocalizedDescription(typeof(LangDictQV), "Absolute")]
		Absolute,
		// Token: 0x04000271 RID: 625
		[LocalizedDescription(typeof(LangDictQV), "FromInstance")]
		Relative
	}
}

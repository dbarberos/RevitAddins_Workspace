using System;
using System.ComponentModel;
using DiRoots.One.EnumHelpers;
using DiRoots.One.LanguageDictionary;
using DiRoots.One.UIBehaviours.Converters;

namespace DiRoots.RoomPro.Enums
{
	// Token: 0x02000096 RID: 150
	[TypeConverter(typeof(EnumDescriptionToCBConverter))]
	public enum CountStyle
	{
		// Token: 0x0400026C RID: 620
		[LocalizedDescription(typeof(LangDictQV), "Number")]
		Number,
		// Token: 0x0400026D RID: 621
		[LocalizedDescription(typeof(LangDictQV), "Alphabet")]
		Alphabet
	}
}

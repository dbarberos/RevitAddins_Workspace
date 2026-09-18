using System;
using System.ComponentModel;
using DiRoots.One.EnumHelpers;
using DiRoots.One.LanguageDictionary;
using DiRoots.One.UIBehaviours.Converters;

namespace DiRoots.RoomPro.Enums
{
	// Token: 0x0200009C RID: 156
	[TypeConverter(typeof(EnumDescriptionToCBConverter))]
	public enum SortingDirections
	{
		// Token: 0x0400027E RID: 638
		[LocalizedDescription(typeof(LangDictQV), "North")]
		North,
		// Token: 0x0400027F RID: 639
		[LocalizedDescription(typeof(LangDictQV), "East")]
		East,
		// Token: 0x04000280 RID: 640
		[LocalizedDescription(typeof(LangDictQV), "South")]
		South,
		// Token: 0x04000281 RID: 641
		[LocalizedDescription(typeof(LangDictQV), "West")]
		West
	}
}

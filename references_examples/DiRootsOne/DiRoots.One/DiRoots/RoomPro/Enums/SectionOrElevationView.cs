using System;
using System.ComponentModel;
using DiRoots.One.EnumHelpers;
using DiRoots.One.LanguageDictionary;
using DiRoots.One.UIBehaviours.Converters;

namespace DiRoots.RoomPro.Enums
{
	// Token: 0x0200009B RID: 155
	[TypeConverter(typeof(EnumDescriptionToCBConverter))]
	public enum SectionOrElevationView
	{
		// Token: 0x0400027B RID: 635
		[LocalizedDescription(typeof(LangDictQV), "ElevationViews")]
		Elevation,
		// Token: 0x0400027C RID: 636
		[LocalizedDescription(typeof(LangDictQV), "SectionViews")]
		Section
	}
}

using System;
using System.ComponentModel;
using DiRoots.One.EnumHelpers;
using DiRoots.One.LanguageDictionary;
using DiRoots.One.UIBehaviours.Converters;

namespace DiRoots.RoomPro.Enums
{
	// Token: 0x02000095 RID: 149
	[TypeConverter(typeof(EnumDescriptionToCBConverter))]
	public enum ClockOrder
	{
		// Token: 0x04000269 RID: 617
		[LocalizedDescription(typeof(LangDictQV), "Clockwise")]
		Clockwise,
		// Token: 0x0400026A RID: 618
		[LocalizedDescription(typeof(LangDictQV), "Anticlockwise")]
		Anticlockwise
	}
}

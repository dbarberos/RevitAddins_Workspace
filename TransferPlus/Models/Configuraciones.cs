using System;

namespace TransferPlus.Models
{
	// Token: 0x02000016 RID: 22
	public class Configuraciones
	{
		// Token: 0x04000075 RID: 117
		public static double METERS_IN_FEET = 0.3048;

		// Token: 0x04000076 RID: 118
		public static double convertfactor = 1.0 / Configuraciones.METERS_IN_FEET;

		// Token: 0x04000077 RID: 119
		public static double convertareafactor = 1.0 / Math.Pow(Configuraciones.METERS_IN_FEET, 2.0);

		// Token: 0x04000078 RID: 120
		public bool cf_rbKeepOriginal = true;

		// Token: 0x04000079 RID: 121
		public bool cf_rbAbortTransaction;

		// Token: 0x0400007A RID: 122
		public bool cf_rbAppendSuffix;

		public string cf_suffixText = "_Copy";

		// Token: 0x0400007B RID: 123
		public bool cf_chk_Callout;

		// Token: 0x0400007C RID: 124
		public bool cf_chk_ViewElements;

		// Token: 0x0400008D RID: 141
		public bool cf_chk_SheetWithViews;

		public bool cf_chk_UseLegendIfExists = true;

		public bool cf_chk_UseScheduleIfExists = true;

		public bool cf_chk_UseAssemblyViewsIfExists = true;

		public bool cf_chk_ForceLevelInLevelBaseViews;

		// Token: 0x0400007E RID: 126
		public bool cf_chk_Links = true;

		// Token: 0x0400007F RID: 127
		public bool cf_chk_GetTransformNone = true;

		// Token: 0x04000080 RID: 128
		public bool cf_chk_GetTransformLink;

		// Token: 0x04000081 RID: 129
		public bool cf_chk_GetTransformShared;

		// Token: 0x04000082 RID: 130
		public bool cf_chk_AcceptAll;

		// Token: 0x04000083 RID: 131
		public int cf_rcSheetNumber = 60;

		// Token: 0x04000084 RID: 132
		public string cf_textBusca = "";

		// Token: 0x04000088 RID: 136
		public double g_offsetinferiorN = 0.1;
	}
}

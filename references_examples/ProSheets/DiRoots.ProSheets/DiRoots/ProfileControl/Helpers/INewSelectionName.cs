using System;
using System.Collections.Generic;
using ProSheets.Helper.Enums;

namespace DiRoots.ProfileControl.Helpers
{
	// Token: 0x02000017 RID: 23
	public interface INewSelectionName
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000BE RID: 190
		// (set) Token: 0x060000BF RID: 191
		List<string> ItemsNames { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000C0 RID: 192
		// (set) Token: 0x060000C1 RID: 193
		List<string> FilterItemsNames { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000C2 RID: 194
		// (set) Token: 0x060000C3 RID: 195
		bool Result { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000C4 RID: 196
		Action OnClose { get; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000C5 RID: 197
		// (set) Token: 0x060000C6 RID: 198
		SavingMode Mode { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000C7 RID: 199
		// (set) Token: 0x060000C8 RID: 200
		string SelectionName { get; set; }

		// Token: 0x060000C9 RID: 201
		void SaveSelection(string modeName);
	}
}

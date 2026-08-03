using System;
using Autodesk.Revit.DB;

namespace ProSheets.Models
{
	// Token: 0x020000FD RID: 253
	public interface ISetViewInfo
	{
		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06000C1D RID: 3101
		// (set) Token: 0x06000C1E RID: 3102
		ElementId Id { get; set; }

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06000C1F RID: 3103
		// (set) Token: 0x06000C20 RID: 3104
		string Name { get; set; }

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06000C21 RID: 3105
		// (set) Token: 0x06000C22 RID: 3106
		bool IsChecked { get; set; }
	}
}

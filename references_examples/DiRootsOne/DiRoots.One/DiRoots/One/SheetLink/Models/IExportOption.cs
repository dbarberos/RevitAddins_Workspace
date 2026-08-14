using System;
using DiRoots.One.SheetLink.Core.Enums;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x0200023E RID: 574
	public interface IExportOption
	{
		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x060016CB RID: 5835
		// (set) Token: 0x060016CC RID: 5836
		bool KeepFormatting { get; set; }

		// Token: 0x17000630 RID: 1584
		// (get) Token: 0x060016CD RID: 5837
		// (set) Token: 0x060016CE RID: 5838
		bool RemoveUnitSymbol { get; set; }

		// Token: 0x17000631 RID: 1585
		// (get) Token: 0x060016CF RID: 5839
		// (set) Token: 0x060016D0 RID: 5840
		bool OpenFile { get; set; }

		// Token: 0x17000632 RID: 1586
		// (get) Token: 0x060016D1 RID: 5841
		// (set) Token: 0x060016D2 RID: 5842
		bool IsExportProjectStandards { get; set; }

		// Token: 0x17000633 RID: 1587
		// (get) Token: 0x060016D3 RID: 5843
		// (set) Token: 0x060016D4 RID: 5844
		ExportOutputTypes ExportOutputType { get; set; }

		// Token: 0x17000634 RID: 1588
		// (get) Token: 0x060016D5 RID: 5845
		// (set) Token: 0x060016D6 RID: 5846
		string FileName { get; set; }

		// Token: 0x17000635 RID: 1589
		// (get) Token: 0x060016D7 RID: 5847
		// (set) Token: 0x060016D8 RID: 5848
		string FilePath { get; set; }

		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x060016D9 RID: 5849
		// (set) Token: 0x060016DA RID: 5850
		bool ExportByType { get; set; }

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x060016DB RID: 5851
		bool ToExcel { get; }
	}
}

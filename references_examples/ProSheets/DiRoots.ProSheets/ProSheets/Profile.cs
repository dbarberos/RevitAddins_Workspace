using System;
using A;

namespace ProSheets
{
	// Token: 0x02000076 RID: 118
	[Serializable]
	public class Profile
	{
		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000712 RID: 1810 RVA: 0x00026CDC File Offset: 0x00024EDC
		// (set) Token: 0x06000713 RID: 1811 RVA: 0x00026CF0 File Offset: 0x00024EF0
		public string Name { get; set; }

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000714 RID: 1812 RVA: 0x00026D04 File Offset: 0x00024F04
		// (set) Token: 0x06000715 RID: 1813 RVA: 0x00026D18 File Offset: 0x00024F18
		public bool IsCurrent { get; set; }

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000716 RID: 1814 RVA: 0x00026D2C File Offset: 0x00024F2C
		// (set) Token: 0x06000717 RID: 1815 RVA: 0x00026D40 File Offset: 0x00024F40
		public string FilePath { get; set; }

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000718 RID: 1816 RVA: 0x00026D54 File Offset: 0x00024F54
		// (set) Token: 0x06000719 RID: 1817 RVA: 0x00026D68 File Offset: 0x00024F68
		public int Version { get; set; }

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x0600071A RID: 1818 RVA: 0x00026D7C File Offset: 0x00024F7C
		// (set) Token: 0x0600071B RID: 1819 RVA: 0x00026D90 File Offset: 0x00024F90
		public ExportTemPlateInfo TemplateInfo { get; set; } = new ExportTemPlateInfo();

		// Token: 0x0600071C RID: 1820 RVA: 0x00026DA4 File Offset: 0x00024FA4
		public object Clone()
		{
			return \u0014\u0012\u0003.\u0018(this);
		}
	}
}

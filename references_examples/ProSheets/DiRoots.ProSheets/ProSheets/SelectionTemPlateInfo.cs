using System;
using System.Collections.Generic;
using A;

namespace ProSheets
{
	// Token: 0x0200007C RID: 124
	[Serializable]
	public class SelectionTemPlateInfo
	{
		// Token: 0x060007B1 RID: 1969 RVA: 0x00027B18 File Offset: 0x00025D18
		public SelectionTemPlateInfo()
		{
			\u000D\u0012\u0003.\u0018(this, new List<int>());
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x060007B3 RID: 1971 RVA: 0x00027B70 File Offset: 0x00025D70
		// (set) Token: 0x060007B2 RID: 1970 RVA: 0x00027B5C File Offset: 0x00025D5C
		public SelectionTypes SelectionType { get; set; }

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x060007B5 RID: 1973 RVA: 0x00027B98 File Offset: 0x00025D98
		// (set) Token: 0x060007B4 RID: 1972 RVA: 0x00027B84 File Offset: 0x00025D84
		public string SheetSetName { get; set; }

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x060007B7 RID: 1975 RVA: 0x00027BC0 File Offset: 0x00025DC0
		// (set) Token: 0x060007B6 RID: 1974 RVA: 0x00027BAC File Offset: 0x00025DAC
		public string CurrentViewType { get; set; }

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x060007B9 RID: 1977 RVA: 0x00027BE8 File Offset: 0x00025DE8
		// (set) Token: 0x060007B8 RID: 1976 RVA: 0x00027BD4 File Offset: 0x00025DD4
		public string SearchKey { get; set; }

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x060007BB RID: 1979 RVA: 0x00027C10 File Offset: 0x00025E10
		// (set) Token: 0x060007BA RID: 1978 RVA: 0x00027BFC File Offset: 0x00025DFC
		public bool IsLableCheked { get; set; }

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x060007BD RID: 1981 RVA: 0x00027C38 File Offset: 0x00025E38
		// (set) Token: 0x060007BC RID: 1980 RVA: 0x00027C24 File Offset: 0x00025E24
		public string LableSelectedValue { get; set; }

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x060007BE RID: 1982 RVA: 0x00027C4C File Offset: 0x00025E4C
		// (set) Token: 0x060007BF RID: 1983 RVA: 0x00027C60 File Offset: 0x00025E60
		public bool IsFieldSeparatorChecked { get; set; } = true;

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x060007C1 RID: 1985 RVA: 0x00027C88 File Offset: 0x00025E88
		// (set) Token: 0x060007C0 RID: 1984 RVA: 0x00027C74 File Offset: 0x00025E74
		public char FieldSeparator { get; set; } = '-';

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x060007C3 RID: 1987 RVA: 0x00027CB0 File Offset: 0x00025EB0
		// (set) Token: 0x060007C2 RID: 1986 RVA: 0x00027C9C File Offset: 0x00025E9C
		public List<int> ViewIds { get; set; }

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x060007C4 RID: 1988 RVA: 0x00027CC4 File Offset: 0x00025EC4
		// (set) Token: 0x060007C5 RID: 1989 RVA: 0x00027CD8 File Offset: 0x00025ED8
		public List<string> SelectedParams { get; set; } = new List<string>();

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x060007C7 RID: 1991 RVA: 0x00027D00 File Offset: 0x00025F00
		// (set) Token: 0x060007C6 RID: 1990 RVA: 0x00027CEC File Offset: 0x00025EEC
		public List<SelectionParameter> SelectedParams_Virtual { get; set; } = new List<SelectionParameter>();
	}
}

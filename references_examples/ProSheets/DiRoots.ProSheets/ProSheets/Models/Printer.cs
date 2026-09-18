using System;

namespace ProSheets.Models
{
	// Token: 0x02000104 RID: 260
	[Serializable]
	public class Printer
	{
		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06000CA8 RID: 3240 RVA: 0x0004A5B8 File Offset: 0x000487B8
		// (set) Token: 0x06000CA9 RID: 3241 RVA: 0x0004A5CC File Offset: 0x000487CC
		public string Name { get; set; }

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x06000CAA RID: 3242 RVA: 0x0004A5E0 File Offset: 0x000487E0
		// (set) Token: 0x06000CAB RID: 3243 RVA: 0x0004A5F4 File Offset: 0x000487F4
		public bool Enabled { get; set; }
	}
}

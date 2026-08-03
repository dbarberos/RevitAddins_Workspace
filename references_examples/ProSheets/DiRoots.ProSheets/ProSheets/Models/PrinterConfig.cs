using System;
using System.Collections.Generic;

namespace ProSheets.Models
{
	// Token: 0x02000103 RID: 259
	[Serializable]
	public class PrinterConfig
	{
		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x0004A57C File Offset: 0x0004877C
		// (set) Token: 0x06000CA6 RID: 3238 RVA: 0x0004A590 File Offset: 0x00048790
		public List<Printer> Printers { get; set; }
	}
}

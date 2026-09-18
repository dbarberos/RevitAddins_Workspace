using System;
using System.Runtime.CompilerServices;
using DiRoots.One.SheetLink.Core;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000255 RID: 597
	public class ExportTaskArgs : ITaskFinishedArgs
	{
		// Token: 0x170006C1 RID: 1729
		// (get) Token: 0x0600183C RID: 6204 RVA: 0x0009C5F8 File Offset: 0x0009A7F8
		// (set) Token: 0x0600183D RID: 6205 RVA: 0x0009C60C File Offset: 0x0009A80C
		public string FilePath { get; set; }

		// Token: 0x170006C2 RID: 1730
		// (get) Token: 0x0600183E RID: 6206 RVA: 0x0009C620 File Offset: 0x0009A820
		// (set) Token: 0x0600183F RID: 6207 RVA: 0x0009C634 File Offset: 0x0009A834
		public bool OpenFile { get; set; }

		// Token: 0x0400098C RID: 2444
		[CompilerGenerated]
		private string \u0007;

		// Token: 0x0400098D RID: 2445
		[CompilerGenerated]
		private bool \u001D;
	}
}

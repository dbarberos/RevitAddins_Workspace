using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000254 RID: 596
	public class ExportFilesTaskArgs : ExportTaskArgs
	{
		// Token: 0x06001836 RID: 6198 RVA: 0x0009C570 File Offset: 0x0009A770
		public ExportFilesTaskArgs(List<string> filesPaths, bool uploadToDrive = false)
		{
			\u001B\u0020\u0005.\u000A(this, filesPaths);
			\u0008\u0020\u0005.\u000A(this, uploadToDrive);
		}

		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x06001837 RID: 6199 RVA: 0x0009C594 File Offset: 0x0009A794
		// (set) Token: 0x06001838 RID: 6200 RVA: 0x0009C5A8 File Offset: 0x0009A7A8
		public List<string> FilesPaths { get; set; }

		// Token: 0x170006C0 RID: 1728
		// (get) Token: 0x06001839 RID: 6201 RVA: 0x0009C5BC File Offset: 0x0009A7BC
		// (set) Token: 0x0600183A RID: 6202 RVA: 0x0009C5D0 File Offset: 0x0009A7D0
		public bool UploadToDrive { get; set; }

		// Token: 0x0400098A RID: 2442
		[CompilerGenerated]
		private List<string> \u001F;

		// Token: 0x0400098B RID: 2443
		[CompilerGenerated]
		private bool \u000A;
	}
}

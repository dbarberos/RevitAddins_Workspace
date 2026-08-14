using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.UI;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Core;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000270 RID: 624
	internal class \u0008\u0010 : ExternalEventInfo
	{
		// Token: 0x170006E1 RID: 1761
		// (get) Token: 0x060018E9 RID: 6377 RVA: 0x000A1B54 File Offset: 0x0009FD54
		// (set) Token: 0x060018EA RID: 6378 RVA: 0x000A1B68 File Offset: 0x0009FD68
		public \u0015\u001C Collector { get; set; }

		// Token: 0x170006E2 RID: 1762
		// (get) Token: 0x060018EB RID: 6379 RVA: 0x000A1B7C File Offset: 0x0009FD7C
		// (set) Token: 0x060018EC RID: 6380 RVA: 0x000A1B90 File Offset: 0x0009FD90
		public List<CategoryCollection> Categories { get; set; }

		// Token: 0x170006E3 RID: 1763
		// (get) Token: 0x060018ED RID: 6381 RVA: 0x000A1BA4 File Offset: 0x0009FDA4
		// (set) Token: 0x060018EE RID: 6382 RVA: 0x000A1BB8 File Offset: 0x0009FDB8
		public List<RevitParameter> Parameters { get; set; }

		// Token: 0x170006E4 RID: 1764
		// (get) Token: 0x060018EF RID: 6383 RVA: 0x000A1BCC File Offset: 0x0009FDCC
		// (set) Token: 0x060018F0 RID: 6384 RVA: 0x000A1BE0 File Offset: 0x0009FDE0
		public IExportOption ExportOption { get; set; }

		// Token: 0x170006E5 RID: 1765
		// (get) Token: 0x060018F1 RID: 6385 RVA: 0x000A1BF4 File Offset: 0x0009FDF4
		// (set) Token: 0x060018F2 RID: 6386 RVA: 0x000A1C08 File Offset: 0x0009FE08
		public ProgressModel ActiveProgressModel { get; set; }

		// Token: 0x170006E6 RID: 1766
		// (get) Token: 0x060018F3 RID: 6387 RVA: 0x000A1C1C File Offset: 0x0009FE1C
		// (set) Token: 0x060018F4 RID: 6388 RVA: 0x000A1C30 File Offset: 0x0009FE30
		public Delegate TaskFinished { get; set; }

		// Token: 0x060018F5 RID: 6389 RVA: 0x000A1C44 File Offset: 0x0009FE44
		public override void Execute(UIApplication app)
		{
		}

		// Token: 0x040009E6 RID: 2534
		[CompilerGenerated]
		private \u0015\u001C \u0013;

		// Token: 0x040009E7 RID: 2535
		[CompilerGenerated]
		private List<CategoryCollection> \u001A;

		// Token: 0x040009E8 RID: 2536
		[CompilerGenerated]
		private List<RevitParameter> \u000C;

		// Token: 0x040009E9 RID: 2537
		[CompilerGenerated]
		private IExportOption \u0015;

		// Token: 0x040009EA RID: 2538
		[CompilerGenerated]
		private ProgressModel \u0001;

		// Token: 0x040009EB RID: 2539
		[CompilerGenerated]
		private Delegate \u0009;
	}
}

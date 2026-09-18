using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using DiRoots.One.Commons.Attributes;
using DiRoots.One.Commons.Models;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000080 RID: 128
	public class ViewsReport : Report
	{
		// Token: 0x17000164 RID: 356
		// (get) Token: 0x0600057C RID: 1404 RVA: 0x00020270 File Offset: 0x0001E470
		// (set) Token: 0x0600057D RID: 1405 RVA: 0x00020284 File Offset: 0x0001E484
		[Report("Element Id", 150.0, DataGridLengthUnitType.Pixel, false, false)]
		public long Id { get; set; }

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x00020298 File Offset: 0x0001E498
		// (set) Token: 0x0600057F RID: 1407 RVA: 0x000202AC File Offset: 0x0001E4AC
		[Report("View Type", 150.0, DataGridLengthUnitType.Pixel, false, false)]
		public string ViewType { get; set; }

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000580 RID: 1408 RVA: 0x000202C0 File Offset: 0x0001E4C0
		// (set) Token: 0x06000581 RID: 1409 RVA: 0x000202D4 File Offset: 0x0001E4D4
		[Report("Element Name", 150.0, DataGridLengthUnitType.Pixel, false, false)]
		public string ElementName { get; set; }

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000582 RID: 1410 RVA: 0x000202E8 File Offset: 0x0001E4E8
		// (set) Token: 0x06000583 RID: 1411 RVA: 0x000202FC File Offset: 0x0001E4FC
		[Report("Element Number", 150.0, DataGridLengthUnitType.Pixel, false, false)]
		public string ElementNumber { get; set; }

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000584 RID: 1412 RVA: 0x00020310 File Offset: 0x0001E510
		// (set) Token: 0x06000585 RID: 1413 RVA: 0x00020324 File Offset: 0x0001E524
		[Report("Error Message", 1.0, DataGridLengthUnitType.Star, false, false)]
		public string Warning { get; set; }

		// Token: 0x04000218 RID: 536
		[CompilerGenerated]
		private long W;

		// Token: 0x04000219 RID: 537
		[CompilerGenerated]
		private string M;

		// Token: 0x0400021A RID: 538
		[CompilerGenerated]
		private string V;

		// Token: 0x0400021B RID: 539
		[CompilerGenerated]
		private string P;

		// Token: 0x0400021C RID: 540
		[CompilerGenerated]
		private string O;
	}
}

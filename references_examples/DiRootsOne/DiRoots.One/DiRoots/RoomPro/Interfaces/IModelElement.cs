using System;
using Autodesk.Revit.DB;
using DiRoots.RoomPro.Models;

namespace DiRoots.RoomPro.Interfaces
{
	// Token: 0x02000089 RID: 137
	public interface IModelElement
	{
		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060005FE RID: 1534
		// (set) Token: 0x060005FF RID: 1535
		long Id { get; set; }

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000600 RID: 1536
		// (set) Token: 0x06000601 RID: 1537
		string Name { get; set; }

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000602 RID: 1538
		// (set) Token: 0x06000603 RID: 1539
		string Number { get; set; }

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000604 RID: 1540
		// (set) Token: 0x06000605 RID: 1541
		bool IsFromLinkedFile { get; set; }

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000606 RID: 1542
		// (set) Token: 0x06000607 RID: 1543
		bool IsCreated { get; set; }

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000608 RID: 1544
		// (set) Token: 0x06000609 RID: 1545
		bool IsChecked { get; set; }

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x0600060A RID: 1546
		// (set) Token: 0x0600060B RID: 1547
		Element Element { get; set; }

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x0600060C RID: 1548
		// (set) Token: 0x0600060D RID: 1549
		SpatialElementStoredData SpatialElementStoredData { get; set; }
	}
}

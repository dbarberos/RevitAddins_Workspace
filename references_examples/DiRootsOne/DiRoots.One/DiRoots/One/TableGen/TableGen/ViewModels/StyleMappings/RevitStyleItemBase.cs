using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using A;

namespace DiRoots.One.TableGen.TableGen.ViewModels.StyleMappings
{
	// Token: 0x02000172 RID: 370
	public abstract class RevitStyleItemBase
	{
		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06000DCB RID: 3531 RVA: 0x0005928C File Offset: 0x0005748C
		// (set) Token: 0x06000DCC RID: 3532 RVA: 0x000592A0 File Offset: 0x000574A0
		public string Name { get; set; }

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06000DCD RID: 3533 RVA: 0x000592B4 File Offset: 0x000574B4
		// (set) Token: 0x06000DCE RID: 3534 RVA: 0x000592C8 File Offset: 0x000574C8
		public long? ElementId { get; set; }

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06000DCF RID: 3535 RVA: 0x000592DC File Offset: 0x000574DC
		// (set) Token: 0x06000DD0 RID: 3536 RVA: 0x000592F0 File Offset: 0x000574F0
		public bool IsNew { get; set; }

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x06000DD1 RID: 3537 RVA: 0x00059304 File Offset: 0x00057504
		// (set) Token: 0x06000DD2 RID: 3538 RVA: 0x00059318 File Offset: 0x00057518
		public string GroupName { get; set; }

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x0005932C File Offset: 0x0005752C
		// (set) Token: 0x06000DD4 RID: 3540 RVA: 0x00059340 File Offset: 0x00057540
		public double Size { get; set; }

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x06000DD5 RID: 3541 RVA: 0x00059354 File Offset: 0x00057554
		// (set) Token: 0x06000DD6 RID: 3542 RVA: 0x00059368 File Offset: 0x00057568
		public Color Color { get; set; }

		// Token: 0x06000DD7 RID: 3543 RVA: 0x0005937C File Offset: 0x0005757C
		public override string ToString()
		{
			return \u0004\u0003\u0019.\u001D(this);
		}

		// Token: 0x04000571 RID: 1393
		[CompilerGenerated]
		private string \u001F;

		// Token: 0x04000572 RID: 1394
		[CompilerGenerated]
		private long? \u000A;

		// Token: 0x04000573 RID: 1395
		[CompilerGenerated]
		private bool \u0007;

		// Token: 0x04000574 RID: 1396
		[CompilerGenerated]
		private string \u001D;

		// Token: 0x04000575 RID: 1397
		[CompilerGenerated]
		private double \u0004;

		// Token: 0x04000576 RID: 1398
		[CompilerGenerated]
		private Color \u0019;
	}
}

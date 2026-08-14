using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using A;
using DiRoots.One.Commons.Models;

namespace ProSheets.Helper
{
	// Token: 0x020000C5 RID: 197
	public class BatchAction : ModelBase
	{
		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06000B00 RID: 2816 RVA: 0x000414F4 File Offset: 0x0003F6F4
		// (set) Token: 0x06000B01 RID: 2817 RVA: 0x00041508 File Offset: 0x0003F708
		public ImageSource Image { get; set; }

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06000B02 RID: 2818 RVA: 0x0004151C File Offset: 0x0003F71C
		// (set) Token: 0x06000B03 RID: 2819 RVA: 0x00041530 File Offset: 0x0003F730
		public string Name { get; set; }

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06000B04 RID: 2820 RVA: 0x00041544 File Offset: 0x0003F744
		// (set) Token: 0x06000B05 RID: 2821 RVA: 0x00041558 File Offset: 0x0003F758
		public int ImageWidth { get; set; }

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06000B06 RID: 2822 RVA: 0x0004156C File Offset: 0x0003F76C
		// (set) Token: 0x06000B07 RID: 2823 RVA: 0x00041580 File Offset: 0x0003F780
		public double Opacity { get; set; }

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06000B08 RID: 2824 RVA: 0x00041594 File Offset: 0x0003F794
		// (set) Token: 0x06000B09 RID: 2825 RVA: 0x000415A8 File Offset: 0x0003F7A8
		public bool IsHidden { get; set; }

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06000B0A RID: 2826 RVA: 0x000415BC File Offset: 0x0003F7BC
		// (set) Token: 0x06000B0B RID: 2827 RVA: 0x000415D0 File Offset: 0x0003F7D0
		public bool IsEnable
		{
			get
			{
				return this.JB;
			}
			set
			{
				this.JB = value;
				\u0007\u001B\u0018.\u0018(this, "IsEnable");
			}
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06000B0C RID: 2828 RVA: 0x000415F0 File Offset: 0x0003F7F0
		// (set) Token: 0x06000B0D RID: 2829 RVA: 0x00041604 File Offset: 0x0003F804
		public object Owner { get; set; }

		// Token: 0x04000535 RID: 1333
		private bool JB = true;

		// Token: 0x04000536 RID: 1334
		[CompilerGenerated]
		private ImageSource FB;

		// Token: 0x04000537 RID: 1335
		[CompilerGenerated]
		private string F;

		// Token: 0x04000538 RID: 1336
		[CompilerGenerated]
		private int RB;

		// Token: 0x04000539 RID: 1337
		[CompilerGenerated]
		private double HB;

		// Token: 0x0400053A RID: 1338
		[CompilerGenerated]
		private bool BB;

		// Token: 0x0400053B RID: 1339
		[CompilerGenerated]
		private object NB;
	}
}

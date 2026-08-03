using System;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.SheetLink.Enums;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000241 RID: 577
	public class BaseParameter : ModelBase
	{
		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x060016F5 RID: 5877 RVA: 0x00096C9C File Offset: 0x00094E9C
		// (set) Token: 0x060016F4 RID: 5876 RVA: 0x00096C88 File Offset: 0x00094E88
		public string UniqueId { get; set; }

		// Token: 0x17000643 RID: 1603
		// (get) Token: 0x060016F7 RID: 5879 RVA: 0x00096CC4 File Offset: 0x00094EC4
		// (set) Token: 0x060016F6 RID: 5878 RVA: 0x00096CB0 File Offset: 0x00094EB0
		public long Id { get; set; }

		// Token: 0x17000644 RID: 1604
		// (get) Token: 0x060016F9 RID: 5881 RVA: 0x00096CEC File Offset: 0x00094EEC
		// (set) Token: 0x060016F8 RID: 5880 RVA: 0x00096CD8 File Offset: 0x00094ED8
		public string Name { get; set; }

		// Token: 0x17000645 RID: 1605
		// (get) Token: 0x060016FB RID: 5883 RVA: 0x00096D14 File Offset: 0x00094F14
		// (set) Token: 0x060016FA RID: 5882 RVA: 0x00096D00 File Offset: 0x00094F00
		public bool IsReadOnly { get; set; }

		// Token: 0x17000646 RID: 1606
		// (get) Token: 0x060016FD RID: 5885 RVA: 0x00096D3C File Offset: 0x00094F3C
		// (set) Token: 0x060016FC RID: 5884 RVA: 0x00096D28 File Offset: 0x00094F28
		public string StorageType { get; set; }

		// Token: 0x17000647 RID: 1607
		// (get) Token: 0x060016FF RID: 5887 RVA: 0x00096D64 File Offset: 0x00094F64
		// (set) Token: 0x060016FE RID: 5886 RVA: 0x00096D50 File Offset: 0x00094F50
		public bool IsType { get; set; }

		// Token: 0x17000648 RID: 1608
		// (get) Token: 0x06001701 RID: 5889 RVA: 0x00096D8C File Offset: 0x00094F8C
		// (set) Token: 0x06001700 RID: 5888 RVA: 0x00096D78 File Offset: 0x00094F78
		public bool IsShared { get; set; }

		// Token: 0x17000649 RID: 1609
		// (get) Token: 0x06001703 RID: 5891 RVA: 0x00096DB4 File Offset: 0x00094FB4
		// (set) Token: 0x06001702 RID: 5890 RVA: 0x00096DA0 File Offset: 0x00094FA0
		public string SharedGuid { get; set; }

		// Token: 0x1700064A RID: 1610
		// (get) Token: 0x06001705 RID: 5893 RVA: 0x00096DDC File Offset: 0x00094FDC
		// (set) Token: 0x06001704 RID: 5892 RVA: 0x00096DC8 File Offset: 0x00094FC8
		public int OrderIndex { get; set; }

		// Token: 0x1700064B RID: 1611
		// (get) Token: 0x06001707 RID: 5895 RVA: 0x00096E04 File Offset: 0x00095004
		// (set) Token: 0x06001706 RID: 5894 RVA: 0x00096DF0 File Offset: 0x00094FF0
		public bool FilterPassed { get; set; }

		// Token: 0x1700064C RID: 1612
		// (get) Token: 0x06001708 RID: 5896 RVA: 0x00096E18 File Offset: 0x00095018
		// (set) Token: 0x06001709 RID: 5897 RVA: 0x00096E2C File Offset: 0x0009502C
		public bool IsSelected
		{
			get
			{
				return this.VH;
			}
			set
			{
				this.VH = value;
				\u0007\u0013\u000A.\u000A(this, "IsSelected");
			}
		}

		// Token: 0x1700064D RID: 1613
		// (get) Token: 0x0600170A RID: 5898 RVA: 0x00096E4C File Offset: 0x0009504C
		public ParameterSource ParameterSourceType
		{
			get
			{
				if (\u0005\u000C\u0019.\u0007(this))
				{
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(BaseParameter.get_ParameterSourceType()).MethodHandle;
					}
					return ParameterSource.ReadOnly;
				}
				if (\u0018\u000C\u0019.\u0007(this))
				{
					for (;;)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					return ParameterSource.Type;
				}
				return ParameterSource.Instance;
			}
		}

		// Token: 0x0400090D RID: 2317
		private bool VH;

		// Token: 0x0400090E RID: 2318
		[CompilerGenerated]
		private string LR;

		// Token: 0x0400090F RID: 2319
		[CompilerGenerated]
		private long W;

		// Token: 0x04000910 RID: 2320
		[CompilerGenerated]
		private string K;

		// Token: 0x04000911 RID: 2321
		[CompilerGenerated]
		private bool WY;

		// Token: 0x04000912 RID: 2322
		[CompilerGenerated]
		private string KY;

		// Token: 0x04000913 RID: 2323
		[CompilerGenerated]
		private bool JY;

		// Token: 0x04000914 RID: 2324
		[CompilerGenerated]
		private bool EY;

		// Token: 0x04000915 RID: 2325
		[CompilerGenerated]
		private string NY;

		// Token: 0x04000916 RID: 2326
		[CompilerGenerated]
		private int MY;

		// Token: 0x04000917 RID: 2327
		[CompilerGenerated]
		private bool TH;
	}
}

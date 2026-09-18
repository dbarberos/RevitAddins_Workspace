using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;
using ProSheets.DrawingRegister.Enums;

namespace ProSheets.DrawingRegister.Model
{
	// Token: 0x0200011E RID: 286
	[Serializable]
	public class RevisionData : ModelBase
	{
		// Token: 0x06000E7C RID: 3708 RVA: 0x000544AC File Offset: 0x000526AC
		public RevisionData()
		{
			\u0011\u0016\u000F.\u0014(this, 0);
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06000E7D RID: 3709 RVA: 0x000544DC File Offset: 0x000526DC
		// (set) Token: 0x06000E7E RID: 3710 RVA: 0x000544F0 File Offset: 0x000526F0
		public List<long> RevisionId { get; set; } = new List<long>();

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x06000E7F RID: 3711 RVA: 0x00054504 File Offset: 0x00052704
		// (set) Token: 0x06000E80 RID: 3712 RVA: 0x00054518 File Offset: 0x00052718
		public List<string> RevisionUniqueIds { get; set; } = new List<string>();

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x06000E81 RID: 3713 RVA: 0x0005452C File Offset: 0x0005272C
		// (set) Token: 0x06000E82 RID: 3714 RVA: 0x00054540 File Offset: 0x00052740
		public bool IsChecked
		{
			get
			{
				return this._isChecked;
			}
			set
			{
				this._isChecked = value;
				\u0007\u001B\u0018.\u0018(this, "IsChecked");
			}
		}

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x06000E83 RID: 3715 RVA: 0x00054560 File Offset: 0x00052760
		// (set) Token: 0x06000E84 RID: 3716 RVA: 0x00054574 File Offset: 0x00052774
		public string DisplayName
		{
			get
			{
				return this._displayName;
			}
			set
			{
				this._displayName = value;
				\u0007\u001B\u0018.\u0018(this, "DisplayName");
			}
		}

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x06000E85 RID: 3717 RVA: 0x00054594 File Offset: 0x00052794
		// (set) Token: 0x06000E86 RID: 3718 RVA: 0x000545A8 File Offset: 0x000527A8
		public string PropertyName { get; set; }

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x06000E87 RID: 3719 RVA: 0x000545BC File Offset: 0x000527BC
		// (set) Token: 0x06000E88 RID: 3720 RVA: 0x000545D0 File Offset: 0x000527D0
		public int PlacementType
		{
			get
			{
				return this._placementType;
			}
			set
			{
				this._placementType = value;
				this.RQ();
				this.HQ();
				\u0007\u001B\u0018.\u0018(this, "PlacementType");
			}
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x000545FC File Offset: 0x000527FC
		private void RQ()
		{
			if (\u0017\u0016\u000F.\u0014(this) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionData.RQ()).MethodHandle;
				}
				\u0015\u0016\u000F.\u0018(this, 20);
				return;
			}
			\u0015\u0016\u000F.\u0018(this, 85);
		}

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06000E8A RID: 3722 RVA: 0x00054638 File Offset: 0x00052838
		// (set) Token: 0x06000E8B RID: 3723 RVA: 0x0005464C File Offset: 0x0005284C
		public RevisionDataProperty RevisionDataProperty { get; set; }

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x06000E8C RID: 3724 RVA: 0x00054660 File Offset: 0x00052860
		// (set) Token: 0x06000E8D RID: 3725 RVA: 0x00054674 File Offset: 0x00052874
		public int RowHeight
		{
			get
			{
				return this._rowHeight;
			}
			set
			{
				this._rowHeight = value;
				\u0007\u001B\u0018.\u0018(this, "RowHeight");
			}
		}

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x06000E8E RID: 3726 RVA: 0x00054694 File Offset: 0x00052894
		// (set) Token: 0x06000E8F RID: 3727 RVA: 0x000546A8 File Offset: 0x000528A8
		public List<RevisionValue> RevisionValue { get; set; }

		// Token: 0x06000E90 RID: 3728 RVA: 0x000546BC File Offset: 0x000528BC
		private void HQ()
		{
			if (\u0003\u000E\u0016.\u0003(this) != null)
			{
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionData.HQ()).MethodHandle;
				}
				if (Enumerable.Any<RevisionValue>(\u0003\u000E\u0016.\u0003(this)))
				{
					for (;;)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					\u001E\u0016\u000F.\u0018(\u0003\u000E\u0016.\u0003(this), new Action<RevisionValue>(this.ZQ));
				}
			}
		}

		// Token: 0x06000E91 RID: 3729 RVA: 0x0005471C File Offset: 0x0005291C
		private void NQ()
		{
			if (\u001F\u001A\u0018.\u0018(\u0020\u000E\u0016.\u0003(this)))
			{
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionData.NQ()).MethodHandle;
				}
				\u000A\u000E\u0016.\u0003(this, \u001F\u000E\u0016.\u0003(this));
			}
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x0005475C File Offset: 0x0005295C
		[CompilerGenerated]
		private void ZQ(RevisionValue P)
		{
			\u0002\u0016\u000F.\u0018(P, \u0017\u0016\u000F.\u0014(this));
		}

		// Token: 0x0400068A RID: 1674
		private bool _isChecked;

		// Token: 0x0400068B RID: 1675
		private string _displayName;

		// Token: 0x0400068C RID: 1676
		private int _placementType;

		// Token: 0x0400068D RID: 1677
		private int _rowHeight;
	}
}

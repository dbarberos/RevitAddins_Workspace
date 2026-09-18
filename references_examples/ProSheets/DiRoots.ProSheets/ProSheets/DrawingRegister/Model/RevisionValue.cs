using System;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;

namespace ProSheets.DrawingRegister.Model
{
	// Token: 0x02000120 RID: 288
	public class RevisionValue : ModelBase
	{
		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06000EA3 RID: 3747 RVA: 0x000548C4 File Offset: 0x00052AC4
		// (set) Token: 0x06000EA4 RID: 3748 RVA: 0x000548D8 File Offset: 0x00052AD8
		public string PropertyValue { get; set; }

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x06000EA5 RID: 3749 RVA: 0x000548EC File Offset: 0x00052AEC
		// (set) Token: 0x06000EA6 RID: 3750 RVA: 0x00054900 File Offset: 0x00052B00
		public int PlacementType
		{
			get
			{
				return this.VB;
			}
			set
			{
				this.VB = value;
				\u0007\u001B\u0018.\u0018(this, "PlacementType");
			}
		}

		// Token: 0x0400069A RID: 1690
		private int VB;

		// Token: 0x0400069B RID: 1691
		[CompilerGenerated]
		private string DB;
	}
}

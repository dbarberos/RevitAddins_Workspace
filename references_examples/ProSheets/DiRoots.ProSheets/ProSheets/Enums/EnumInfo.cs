using System;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;

namespace ProSheets.Enums
{
	// Token: 0x020000F3 RID: 243
	public class EnumInfo : ModelBase
	{
		// Token: 0x06000BDD RID: 3037 RVA: 0x00048850 File Offset: 0x00046A50
		public EnumInfo()
		{
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x0004886C File Offset: 0x00046A6C
		public EnumInfo(string displayName, string originalName, bool isPremium = false)
		{
			\u000F\u0002\u0016.\u0018(this, originalName);
			\u0016\u0002\u0016.\u0018(this, displayName);
			\u0003\u0002\u0016.\u0018(this, isPremium);
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x0004889C File Offset: 0x00046A9C
		public EnumInfo(string displayName, string originalName, int enumIndex, bool isPremium = false)
		{
			\u000F\u0002\u0016.\u0018(this, originalName);
			\u0016\u0002\u0016.\u0018(this, displayName);
			\u0012\u0002\u0016.\u0018(this, enumIndex);
			\u0003\u0002\u0016.\u0018(this, isPremium);
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06000BE0 RID: 3040 RVA: 0x000488D4 File Offset: 0x00046AD4
		// (set) Token: 0x06000BE1 RID: 3041 RVA: 0x000488E8 File Offset: 0x00046AE8
		public string DisplayName { get; set; }

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06000BE2 RID: 3042 RVA: 0x000488FC File Offset: 0x00046AFC
		// (set) Token: 0x06000BE3 RID: 3043 RVA: 0x00048910 File Offset: 0x00046B10
		public string OriginalName { get; set; }

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x00048924 File Offset: 0x00046B24
		// (set) Token: 0x06000BE5 RID: 3045 RVA: 0x00048938 File Offset: 0x00046B38
		public int Index { get; set; }

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06000BE6 RID: 3046 RVA: 0x0004894C File Offset: 0x00046B4C
		// (set) Token: 0x06000BE7 RID: 3047 RVA: 0x00048960 File Offset: 0x00046B60
		public bool IsPremium { get; set; }

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06000BE8 RID: 3048 RVA: 0x00048974 File Offset: 0x00046B74
		// (set) Token: 0x06000BE9 RID: 3049 RVA: 0x00048988 File Offset: 0x00046B88
		public bool IsLicensed
		{
			get
			{
				return this.ZB;
			}
			set
			{
				this.ZB = value;
				\u0007\u001B\u0018.\u0018(this, "IsLicensed");
			}
		}

		// Token: 0x04000574 RID: 1396
		private bool ZB = true;

		// Token: 0x04000575 RID: 1397
		[CompilerGenerated]
		private string H;

		// Token: 0x04000576 RID: 1398
		[CompilerGenerated]
		private string MB;

		// Token: 0x04000577 RID: 1399
		[CompilerGenerated]
		private int XB;

		// Token: 0x04000578 RID: 1400
		[CompilerGenerated]
		private bool YB;
	}
}

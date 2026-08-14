using System;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;

namespace ProSheets.ScheduleAssistant.Model.UpdateWindowModels
{
	// Token: 0x020000B4 RID: 180
	public class BaseFilter : ModelBase
	{
		// Token: 0x06000A4C RID: 2636 RVA: 0x0003E8A4 File Offset: 0x0003CAA4
		public BaseFilter(string name, int enumIndex)
		{
			\u0009\u0012\u0016.\u0003(this, true);
			\u001E\u0012\u0016.\u0018(this, name);
			\u0017\u0012\u0016.\u0018(this, enumIndex);
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000A4D RID: 2637 RVA: 0x0003E8CC File Offset: 0x0003CACC
		// (set) Token: 0x06000A4E RID: 2638 RVA: 0x0003E8E0 File Offset: 0x0003CAE0
		public bool IsHidden { get; set; }

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06000A4F RID: 2639 RVA: 0x0003E8F4 File Offset: 0x0003CAF4
		// (set) Token: 0x06000A50 RID: 2640 RVA: 0x0003E908 File Offset: 0x0003CB08
		public bool IsChecked
		{
			get
			{
				return this.Q;
			}
			set
			{
				this.Q = value;
				\u0007\u001B\u0018.\u0018(this, "IsChecked");
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06000A51 RID: 2641 RVA: 0x0003E928 File Offset: 0x0003CB28
		// (set) Token: 0x06000A52 RID: 2642 RVA: 0x0003E93C File Offset: 0x0003CB3C
		public string Name { get; set; }

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000A53 RID: 2643 RVA: 0x0003E950 File Offset: 0x0003CB50
		// (set) Token: 0x06000A54 RID: 2644 RVA: 0x0003E964 File Offset: 0x0003CB64
		public int EnumIndex { get; set; }

		// Token: 0x040004D6 RID: 1238
		private bool Q;

		// Token: 0x040004D7 RID: 1239
		[CompilerGenerated]
		private bool BB;

		// Token: 0x040004D8 RID: 1240
		[CompilerGenerated]
		private string F;

		// Token: 0x040004D9 RID: 1241
		[CompilerGenerated]
		private int QB;
	}
}

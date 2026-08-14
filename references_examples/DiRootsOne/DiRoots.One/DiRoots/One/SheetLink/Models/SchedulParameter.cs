using System;
using System.Runtime.CompilerServices;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000251 RID: 593
	public class SchedulParameter
	{
		// Token: 0x170006B5 RID: 1717
		// (get) Token: 0x0600181F RID: 6175 RVA: 0x0009C174 File Offset: 0x0009A374
		// (set) Token: 0x06001820 RID: 6176 RVA: 0x0009C188 File Offset: 0x0009A388
		public RevitParameter Parameter { get; set; }

		// Token: 0x170006B6 RID: 1718
		// (get) Token: 0x06001821 RID: 6177 RVA: 0x0009C19C File Offset: 0x0009A39C
		// (set) Token: 0x06001822 RID: 6178 RVA: 0x0009C1B0 File Offset: 0x0009A3B0
		public string Value { get; set; }

		// Token: 0x04000980 RID: 2432
		[CompilerGenerated]
		private RevitParameter \u001F;

		// Token: 0x04000981 RID: 2433
		[CompilerGenerated]
		private string \u000A;
	}
}

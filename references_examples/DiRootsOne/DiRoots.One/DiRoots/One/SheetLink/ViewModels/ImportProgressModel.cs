using System;
using A;
using DiRoots.One.Commons;

namespace DiRoots.One.SheetLink.ViewModels
{
	// Token: 0x0200020C RID: 524
	public class ImportProgressModel : ProgressModel
	{
		// Token: 0x06001361 RID: 4961 RVA: 0x0007BA34 File Offset: 0x00079C34
		internal ImportProgressModel(\u001A\u0010 F)
		{
			this.TU = F;
			\u000F\u0014\u0018.\u000A(this, \u0012\u0014\u0018.\u000A());
		}

		// Token: 0x06001362 RID: 4962 RVA: 0x0007BA5C File Offset: 0x00079C5C
		public override void RunProcess()
		{
			\u0010\u0014\u0018.\u000A(this.TU, true);
			\u000D\u0014\u0018.\u000A(this.TU, this);
			\u0003\u0014\u0018.\u000A(\u001C\u0014\u0018.\u0007(this.TU), new Action(base.TaskMethod));
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), this.TU);
			\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
		}

		// Token: 0x040007A7 RID: 1959
		private readonly \u001A\u0010 TU;
	}
}

using System;

namespace DiRoots.One.SheetGen.Models.Interfaces
{
	// Token: 0x02000380 RID: 896
	public interface IExecutable
	{
		// Token: 0x060024A9 RID: 9385
		void ExecutionFinished(bool isDelete = false);

		// Token: 0x060024AA RID: 9386
		void ExcutionFailed();
	}
}

using System;

namespace DiRoots.One.SheetGen.Models.Interfaces
{
	// Token: 0x02000382 RID: 898
	public interface IProgressBarReporter
	{
		// Token: 0x060024B3 RID: 9395
		void ReportProgress(int percent, string currentName, UpdateStates status);
	}
}

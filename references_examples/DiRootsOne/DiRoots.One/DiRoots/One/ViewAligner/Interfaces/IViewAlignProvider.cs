using System;
using DiRoots.One.ViewAligner.Data.Models;

namespace DiRoots.One.ViewAligner.Interfaces
{
	// Token: 0x020000CD RID: 205
	public interface IViewAlignProvider
	{
		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060007D0 RID: 2000
		// (remove) Token: 0x060007D1 RID: 2001
		event TaskFinishedDelegate TaskFinished;

		// Token: 0x060007D2 RID: 2002
		void Align(AlignSettings alignSettings);
	}
}

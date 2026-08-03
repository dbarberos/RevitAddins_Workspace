using System;
using System.Collections.Generic;
using DiRoots.One.ViewAligner.Services;

namespace DiRoots.One.ViewAligner.Interfaces
{
	// Token: 0x020000CA RID: 202
	public interface IReportingService
	{
		// Token: 0x060007C6 RID: 1990
		void Report(string message);

		// Token: 0x060007C7 RID: 1991
		void Report(Exception ex);

		// Token: 0x060007C8 RID: 1992
		void Report(List<AlignReport> reports, string title);
	}
}

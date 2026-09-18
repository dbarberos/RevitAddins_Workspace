using System;
using System.Collections.Generic;
using System.Windows;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.TableGen.Services
{
	// Token: 0x0200016B RID: 363
	public interface IReportWindowService
	{
		// Token: 0x06000D7A RID: 3450
		void ShowReportWindow(IEnumerable<Report> reports, Type reportType, Window ownerWindow);
	}
}

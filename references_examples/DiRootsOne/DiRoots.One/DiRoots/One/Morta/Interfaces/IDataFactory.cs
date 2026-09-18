using System;
using System.Collections.Generic;
using DiRoots.One.Morta.Model.CustomTable;

namespace DiRoots.One.Morta.Interfaces
{
	// Token: 0x020001EF RID: 495
	public interface IDataFactory
	{
		// Token: 0x060012A1 RID: 4769
		TableInfo GetTable();

		// Token: 0x060012A2 RID: 4770
		List<TableInfo> GetTables();
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using A;
using DiRoots.One.Commons.Attributes;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.Morta.Model.CustomTable;

namespace DiRoots.One.Morta.Model
{
	// Token: 0x020001B9 RID: 441
	public class ReportInfo : Report
	{
		// Token: 0x06001078 RID: 4216 RVA: 0x00068804 File Offset: 0x00066A04
		public ReportInfo(TableInfo tableInfo)
		{
			\u0007\u0004\u0018.\u001D(this, \u0003\u000A\u0018.\u0007(tableInfo));
			\u000A\u0004\u0018.\u001D(this, \u0009\u0018\u0018.\u000A(tableInfo));
			ReportStates u000A;
			if (!\u0001\u0018\u0018.\u000A(tableInfo))
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReportInfo..ctor(TableInfo)).MethodHandle;
				}
				u000A = ReportStates.Error;
			}
			else
			{
				u000A = ReportStates.Successful;
			}
			\u0020\u0014\u0007.\u000A(this, u000A);
		}

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x0600107A RID: 4218 RVA: 0x00068870 File Offset: 0x00066A70
		// (set) Token: 0x06001079 RID: 4217 RVA: 0x0006885C File Offset: 0x00066A5C
		[Report("Report-Morta-ColumnTableName", 1.0, DataGridLengthUnitType.Star, false, false)]
		public string Name { get; set; }

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x0600107C RID: 4220 RVA: 0x00068898 File Offset: 0x00066A98
		// (set) Token: 0x0600107B RID: 4219 RVA: 0x00068884 File Offset: 0x00066A84
		[Report("Report-Morta-ColumnMessage", 2.0, DataGridLengthUnitType.Star, false, false, WrapText = true)]
		public string Message { get; set; }

		// Token: 0x04000684 RID: 1668
		[CompilerGenerated]
		private string K;

		// Token: 0x04000685 RID: 1669
		[CompilerGenerated]
		private string UH;
	}
}

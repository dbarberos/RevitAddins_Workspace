using System;
using System.Collections.Generic;
using A;

namespace ProSheets.Commons.CustomNameManageWindow.Models
{
	// Token: 0x02000143 RID: 323
	[Serializable]
	public class Parameters
	{
		// Token: 0x06001007 RID: 4103 RVA: 0x00059F6C File Offset: 0x0005816C
		public Parameters(string cParaName, List<ParameterModel> paras)
		{
			\u0011\u0009\u000F.\u0018(this, cParaName);
			\u001F\u0009\u000F.\u0018(this, paras);
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x00059F90 File Offset: 0x00058190
		public Parameters()
		{
		}

		// Token: 0x17000578 RID: 1400
		// (get) Token: 0x06001009 RID: 4105 RVA: 0x00059FA4 File Offset: 0x000581A4
		// (set) Token: 0x0600100A RID: 4106 RVA: 0x00059FB8 File Offset: 0x000581B8
		public string CombineParameterName { get; set; }

		// Token: 0x17000579 RID: 1401
		// (get) Token: 0x0600100B RID: 4107 RVA: 0x00059FCC File Offset: 0x000581CC
		// (set) Token: 0x0600100C RID: 4108 RVA: 0x00059FE0 File Offset: 0x000581E0
		public List<ParameterModel> CombineParameters { get; set; }
	}
}

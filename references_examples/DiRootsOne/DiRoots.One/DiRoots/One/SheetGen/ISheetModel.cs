using System;
using System.Collections.Generic;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002B7 RID: 695
	public interface ISheetModel
	{
		// Token: 0x1700078F RID: 1935
		// (get) Token: 0x06001B76 RID: 7030
		string GUID { get; }

		// Token: 0x17000790 RID: 1936
		// (get) Token: 0x06001B77 RID: 7031
		long SheetId { get; }

		// Token: 0x17000791 RID: 1937
		// (get) Token: 0x06001B78 RID: 7032
		long TemplateSheetId { get; }

		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x06001B79 RID: 7033
		// (set) Token: 0x06001B7A RID: 7034
		string SheetName { get; set; }

		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x06001B7B RID: 7035
		// (set) Token: 0x06001B7C RID: 7036
		string SheetNumber { get; set; }

		// Token: 0x17000794 RID: 1940
		// (get) Token: 0x06001B7D RID: 7037
		string NumberNameDisplay { get; }

		// Token: 0x17000795 RID: 1941
		// (get) Token: 0x06001B7E RID: 7038
		// (set) Token: 0x06001B7F RID: 7039
		string TempSheetNumberHolder { get; set; }

		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x06001B80 RID: 7040
		// (set) Token: 0x06001B81 RID: 7041
		string CommittedName { get; set; }

		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x06001B82 RID: 7042
		// (set) Token: 0x06001B83 RID: 7043
		string CommittedNumber { get; set; }

		// Token: 0x17000798 RID: 1944
		// (get) Token: 0x06001B84 RID: 7044
		string TemplateSheetNumber { get; }

		// Token: 0x17000799 RID: 1945
		// (get) Token: 0x06001B85 RID: 7045
		// (set) Token: 0x06001B86 RID: 7046
		string TitleBlockName { get; set; }

		// Token: 0x1700079A RID: 1946
		// (get) Token: 0x06001B87 RID: 7047
		// (set) Token: 0x06001B88 RID: 7048
		IList<ParameterModel> Parameters { get; set; }

		// Token: 0x1700079B RID: 1947
		// (get) Token: 0x06001B89 RID: 7049
		// (set) Token: 0x06001B8A RID: 7050
		bool IsChecked { get; set; }

		// Token: 0x1700079C RID: 1948
		// (get) Token: 0x06001B8B RID: 7051
		// (set) Token: 0x06001B8C RID: 7052
		UpdateStates UpdateState { get; set; }

		// Token: 0x1700079D RID: 1949
		// (get) Token: 0x06001B8D RID: 7053
		// (set) Token: 0x06001B8E RID: 7054
		UpdateStates PreviousStatus { get; set; }

		// Token: 0x06001B8F RID: 7055
		void AddParameter(ParameterModel paramModel);
	}
}

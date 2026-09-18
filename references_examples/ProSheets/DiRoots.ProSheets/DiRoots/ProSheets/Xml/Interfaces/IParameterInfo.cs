using System;
using DiRoots.ProSheets.Xml.Enums;

namespace DiRoots.ProSheets.Xml.Interfaces
{
	// Token: 0x0200002C RID: 44
	public interface IParameterInfo
	{
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000197 RID: 407
		// (set) Token: 0x06000198 RID: 408
		long Id { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000199 RID: 409
		// (set) Token: 0x0600019A RID: 410
		string Name { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600019B RID: 411
		string DisplayName { get; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600019C RID: 412
		// (set) Token: 0x0600019D RID: 413
		string Value { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600019E RID: 414
		// (set) Token: 0x0600019F RID: 415
		ParameterType Type { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001A0 RID: 416
		bool IgnoreOnRemove { get; }
	}
}

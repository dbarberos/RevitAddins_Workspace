using System;
using A;

namespace ProSheets.Extensions
{
	// Token: 0x020000D9 RID: 217
	[AttributeUsage(AttributeTargets.Method)]
	public class BindableMethod : Attribute
	{
		// Token: 0x06000B56 RID: 2902 RVA: 0x00045950 File Offset: 0x00043B50
		public BindableMethod(string name)
		{
			\u0020\u001F\u0016.\u0018(this, name);
		}

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x06000B57 RID: 2903 RVA: 0x0004596C File Offset: 0x00043B6C
		// (set) Token: 0x06000B58 RID: 2904 RVA: 0x00045980 File Offset: 0x00043B80
		public string Name { get; set; }
	}
}

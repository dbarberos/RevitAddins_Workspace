using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000045 RID: 69
	internal class \u0003\u000A
	{
		// Token: 0x06000239 RID: 569 RVA: 0x0000B728 File Offset: 0x00009928
		internal \u0003\u000A()
		{
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600023A RID: 570 RVA: 0x0000B73C File Offset: 0x0000993C
		// (set) Token: 0x0600023B RID: 571 RVA: 0x0000B750 File Offset: 0x00009950
		public XYZ North { get; set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600023C RID: 572 RVA: 0x0000B764 File Offset: 0x00009964
		// (set) Token: 0x0600023D RID: 573 RVA: 0x0000B778 File Offset: 0x00009978
		public XYZ South { get; set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x0600023E RID: 574 RVA: 0x0000B78C File Offset: 0x0000998C
		// (set) Token: 0x0600023F RID: 575 RVA: 0x0000B7A0 File Offset: 0x000099A0
		public XYZ East { get; set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000240 RID: 576 RVA: 0x0000B7B4 File Offset: 0x000099B4
		// (set) Token: 0x06000241 RID: 577 RVA: 0x0000B7C8 File Offset: 0x000099C8
		public XYZ West { get; set; }

		// Token: 0x06000242 RID: 578 RVA: 0x0000B7DC File Offset: 0x000099DC
		public List<XYZ> \u0004()
		{
			List<XYZ> list = \u000B\u000A\u0007.\u000A();
			\u0005\u000A\u0007.\u000A(list, \u000E\u000A\u0007.\u000A(this));
			\u0005\u000A\u0007.\u000A(list, \u0010\u000A\u0007.\u000A(this));
			\u0005\u000A\u0007.\u000A(list, \u000D\u000A\u0007.\u000A(this));
			\u0005\u000A\u0007.\u000A(list, \u001C\u000A\u0007.\u000A(this));
			return list;
		}

		// Token: 0x040000F8 RID: 248
		[CompilerGenerated]
		private XYZ \u001F;

		// Token: 0x040000F9 RID: 249
		[CompilerGenerated]
		private XYZ \u000A;

		// Token: 0x040000FA RID: 250
		[CompilerGenerated]
		private XYZ \u0007;

		// Token: 0x040000FB RID: 251
		[CompilerGenerated]
		private XYZ \u001D;
	}
}

using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000422 RID: 1058
	internal sealed class \u0005\u0011\u0016 : MulticastDelegate
	{
		// Token: 0x06001AB8 RID: 6840
		public extern \u0005\u0011\u0016(object, IntPtr);

		// Token: 0x06001AB9 RID: 6841 RVA: 0x000663BC File Offset: 0x000645BC
		static \u0005\u0011\u0016()
		{
			\u000A\u0017\u0018.\u0007(33555490, 167772420, 16777215);
		}

		// Token: 0x06001ABA RID: 6842
		public extern bool Invoke(object, string, string, ICollection<ElementId>, DWGExportOptions);

		// Token: 0x06001ABB RID: 6843 RVA: 0x000663D4 File Offset: 0x000645D4
		public static bool \u0018(object \u000C, string \u0018, string \u0014, ICollection<ElementId> \u0003, DWGExportOptions \u0016)
		{
			return \u0005\u0011\u0016.\u000C(\u000C, \u0018, \u0014, \u0003, \u0016);
		}

		// Token: 0x04000B6F RID: 2927
		protected internal static readonly \u0005\u0011\u0016 \u000C;
	}
}

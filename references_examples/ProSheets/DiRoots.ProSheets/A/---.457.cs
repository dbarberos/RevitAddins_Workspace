using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x020003AF RID: 943
	internal sealed class \u0004\u0011\u0016 : MulticastDelegate
	{
		// Token: 0x060018FF RID: 6399
		public extern \u0004\u0011\u0016(object, IntPtr);

		// Token: 0x06001900 RID: 6400 RVA: 0x00065294 File Offset: 0x00063494
		static \u0004\u0011\u0016()
		{
			\u000A\u0017\u0018.\u0007(33555375, 167772368, 16777215);
		}

		// Token: 0x06001901 RID: 6401
		public extern bool Invoke(object, string, string, ICollection<ElementId>, DGNExportOptions);

		// Token: 0x06001902 RID: 6402 RVA: 0x000652AC File Offset: 0x000634AC
		public static bool \u0018(object \u000C, string \u0018, string \u0014, ICollection<ElementId> \u0003, DGNExportOptions \u0016)
		{
			return \u0004\u0011\u0016.\u000C(\u000C, \u0018, \u0014, \u0003, \u0016);
		}

		// Token: 0x04000AFB RID: 2811
		protected internal static readonly \u0004\u0011\u0016 \u000C;
	}
}

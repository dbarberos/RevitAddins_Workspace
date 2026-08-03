using System;
using Autodesk.Revit.DB;
using ProSheets.Models;

namespace A
{
	// Token: 0x02000228 RID: 552
	internal sealed class \u0001\u0002\u0016 : MulticastDelegate
	{
		// Token: 0x0600133B RID: 4923
		public extern \u0001\u0002\u0016(object, IntPtr);

		// Token: 0x0600133C RID: 4924 RVA: 0x00061994 File Offset: 0x0005FB94
		static \u0001\u0002\u0016()
		{
			\u0020\u0017\u0018.\u0019(33554984, 100666346, 16777215);
		}

		// Token: 0x0600133D RID: 4925
		public extern RevisionInformation Invoke(Revision revision);

		// Token: 0x0600133E RID: 4926 RVA: 0x000619AC File Offset: 0x0005FBAC
		public static RevisionInformation \u0018(Revision \u000C)
		{
			return \u0001\u0002\u0016.\u000C(\u000C);
		}

		// Token: 0x04000985 RID: 2437
		internal static readonly \u0001\u0002\u0016 \u000C;
	}
}

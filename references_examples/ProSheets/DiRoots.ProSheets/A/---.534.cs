using System;
using Autodesk.Revit.UI.Events;

namespace A
{
	// Token: 0x020003FC RID: 1020
	internal sealed class \u0005\u0004\u0014 : MulticastDelegate
	{
		// Token: 0x06001A29 RID: 6697
		public extern \u0005\u0004\u0014(object, IntPtr);

		// Token: 0x06001A2A RID: 6698 RVA: 0x00065E30 File Offset: 0x00064030
		static \u0005\u0004\u0014()
		{
			\u000A\u0017\u0018.\u0007(33555452, 167772402, 16777215);
		}

		// Token: 0x06001A2B RID: 6699
		public extern void Invoke(object, EventHandler<ThemeChangedEventArgs>);

		// Token: 0x06001A2C RID: 6700 RVA: 0x00065E48 File Offset: 0x00064048
		public static void \u0018(object \u000C, EventHandler<ThemeChangedEventArgs> \u0018)
		{
			\u0005\u0004\u0014.\u000C(\u000C, \u0018);
		}

		// Token: 0x04000B49 RID: 2889
		protected internal static readonly \u0005\u0004\u0014 \u000C;
	}
}

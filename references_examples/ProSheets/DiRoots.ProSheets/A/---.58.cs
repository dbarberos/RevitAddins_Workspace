using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;

namespace A
{
	// Token: 0x0200013A RID: 314
	internal class \u0012\u0017\u0018 : ExternalEventInfo
	{
		// Token: 0x06000FA5 RID: 4005 RVA: 0x00058904 File Offset: 0x00056B04
		public \u0012\u0017\u0018(string \u000C, bool \u0018 = false)
		{
			this.\u0015 = \u000C;
			\u0017\u001C\u000F.\u0018(this, \u0018);
		}

		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x06000FA6 RID: 4006 RVA: 0x00058928 File Offset: 0x00056B28
		// (set) Token: 0x06000FA7 RID: 4007 RVA: 0x0005893C File Offset: 0x00056B3C
		private bool _isScheduleData { get; set; }

		// Token: 0x06000FA8 RID: 4008 RVA: 0x00058950 File Offset: 0x00056B50
		public override void Execute(UIApplication app)
		{
			\u001B\u0020\u0018.\u0016(\u0017\u0005\u0018.\u0014(\u001F\u001F\u0014.\u0018(app)), this.\u0015, \u001E\u001C\u000F.\u0018(this));
		}

		// Token: 0x040006FB RID: 1787
		private string \u0015;

		// Token: 0x040006FC RID: 1788
		[CompilerGenerated]
		private bool \u0017;
	}
}

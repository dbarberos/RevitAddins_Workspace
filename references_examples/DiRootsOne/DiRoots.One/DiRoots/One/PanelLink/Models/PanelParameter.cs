using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.SheetLink.Models;

namespace DiRoots.One.PanelLink.Models
{
	// Token: 0x020001A6 RID: 422
	public class PanelParameter : BaseParameter
	{
		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06000FB0 RID: 4016 RVA: 0x00062A14 File Offset: 0x00060C14
		// (set) Token: 0x06000FB1 RID: 4017 RVA: 0x00062A28 File Offset: 0x00060C28
		public int ImageIndicator { get; set; }

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06000FB2 RID: 4018 RVA: 0x00062A3C File Offset: 0x00060C3C
		// (set) Token: 0x06000FB3 RID: 4019 RVA: 0x00062A50 File Offset: 0x00060C50
		public Parameter Param { get; set; }

		// Token: 0x06000FB4 RID: 4020 RVA: 0x00062A64 File Offset: 0x00060C64
		public void SetImageIndicator()
		{
			if (\u0005\u000C\u0019.\u0007(this))
			{
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelParameter.SetImageIndicator()).MethodHandle;
				}
				\u0019\u000C\u0019.\u000A(this, 1);
				return;
			}
			if (\u0018\u000C\u0019.\u0007(this))
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				\u0019\u000C\u0019.\u000A(this, 3);
				return;
			}
			\u0019\u000C\u0019.\u000A(this, 2);
		}

		// Token: 0x04000647 RID: 1607
		[CompilerGenerated]
		private int IH;

		// Token: 0x04000648 RID: 1608
		[CompilerGenerated]
		private Parameter QH;
	}
}

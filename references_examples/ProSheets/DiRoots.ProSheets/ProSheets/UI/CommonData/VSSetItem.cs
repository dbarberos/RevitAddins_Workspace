using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;

namespace ProSheets.UI.CommonData
{
	// Token: 0x0200009A RID: 154
	public class VSSetItem
	{
		// Token: 0x06000946 RID: 2374 RVA: 0x00039878 File Offset: 0x00037A78
		public VSSetItem(View v)
		{
			\u0014\u0005\u0003.\u0018(this, v);
			if (\u000E\u001A\u000F.\u000C(v) != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(VSSetItem..ctor(View)).MethodHandle;
				}
				\u0018\u0005\u0003.\u0018(this, ViewSheetSetItemType.Sheet);
				return;
			}
			\u0018\u0005\u0003.\u0018(this, ViewSheetSetItemType.View);
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06000947 RID: 2375 RVA: 0x000398C0 File Offset: 0x00037AC0
		// (set) Token: 0x06000948 RID: 2376 RVA: 0x000398D4 File Offset: 0x00037AD4
		public ViewSheetSetItemType Type { get; set; }

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06000949 RID: 2377 RVA: 0x000398E8 File Offset: 0x00037AE8
		// (set) Token: 0x0600094A RID: 2378 RVA: 0x000398FC File Offset: 0x00037AFC
		public View Item { get; set; }

		// Token: 0x0400045E RID: 1118
		[CompilerGenerated]
		private ViewSheetSetItemType \u000C;

		// Token: 0x0400045F RID: 1119
		[CompilerGenerated]
		private View \u0018;
	}
}

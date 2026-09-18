using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;

namespace DiRoots.One.SheetGen.Models
{
	// Token: 0x0200037F RID: 895
	public class VSSetItem
	{
		// Token: 0x060024A4 RID: 9380 RVA: 0x000DF470 File Offset: 0x000DD670
		public VSSetItem(View v)
		{
			\u000A\u0001\u000B.\u000A(this, v);
			if (\u0015\u001D\u000E.\u001F(v) != null)
			{
				for (;;)
				{
					switch (2)
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
				\u001F\u0001\u000B.\u000A(this, ViewSheetSetItemType.Sheet);
				return;
			}
			\u001F\u0001\u000B.\u000A(this, ViewSheetSetItemType.View);
		}

		// Token: 0x17000A5F RID: 2655
		// (get) Token: 0x060024A5 RID: 9381 RVA: 0x000DF4B8 File Offset: 0x000DD6B8
		// (set) Token: 0x060024A6 RID: 9382 RVA: 0x000DF4CC File Offset: 0x000DD6CC
		public ViewSheetSetItemType Type { get; set; }

		// Token: 0x17000A60 RID: 2656
		// (get) Token: 0x060024A7 RID: 9383 RVA: 0x000DF4E0 File Offset: 0x000DD6E0
		// (set) Token: 0x060024A8 RID: 9384 RVA: 0x000DF4F4 File Offset: 0x000DD6F4
		public View Item { get; set; }

		// Token: 0x04000E8A RID: 3722
		[CompilerGenerated]
		private ViewSheetSetItemType \u001F;

		// Token: 0x04000E8B RID: 3723
		[CompilerGenerated]
		private View \u000A;
	}
}

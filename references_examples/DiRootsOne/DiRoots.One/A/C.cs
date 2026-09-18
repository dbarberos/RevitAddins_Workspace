using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using DiRoots.One.TGDatabaseLayer;

namespace A
{
	// Token: 0x02000161 RID: 353
	internal class C : DataTemplateSelector
	{
		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06000D4D RID: 3405 RVA: 0x00056200 File Offset: 0x00054400
		// (set) Token: 0x06000D4E RID: 3406 RVA: 0x00056214 File Offset: 0x00054414
		public DataTemplate RegionTemplate { get; set; }

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06000D4F RID: 3407 RVA: 0x00056228 File Offset: 0x00054428
		// (set) Token: 0x06000D50 RID: 3408 RVA: 0x0005623C File Offset: 0x0005443C
		public DataTemplate PageTemplate { get; set; }

		// Token: 0x06000D51 RID: 3409 RVA: 0x00056250 File Offset: 0x00054450
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			SelectedExcel selectedExcel = \u0011\u0018\u000E.\u001F(item);
			if (selectedExcel != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(C.SelectTemplate(object, DependencyObject)).MethodHandle;
				}
				if (\u000D\u001B\u001D.\u0007(\u0002\u0003\u0004.\u0007(selectedExcel)) == 0)
				{
					for (;;)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					return \u0002\u0006\u0019.\u000A(this);
				}
			}
			return \u000B\u0006\u0019.\u000A(this);
		}

		// Token: 0x0400054A RID: 1354
		[CompilerGenerated]
		private DataTemplate F;

		// Token: 0x0400054B RID: 1355
		[CompilerGenerated]
		private DataTemplate R;
	}
}

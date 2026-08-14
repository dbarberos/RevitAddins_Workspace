using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using DiRoots.One.TGDatabaseLayer;

namespace A
{
	// Token: 0x0200015E RID: 350
	internal class R : DataTemplateSelector
	{
		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06000D3B RID: 3387 RVA: 0x00055F98 File Offset: 0x00054198
		// (set) Token: 0x06000D3C RID: 3388 RVA: 0x00055FAC File Offset: 0x000541AC
		public DataTemplate ComboBoxTemplate { get; set; }

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06000D3D RID: 3389 RVA: 0x00055FC0 File Offset: 0x000541C0
		// (set) Token: 0x06000D3E RID: 3390 RVA: 0x00055FD4 File Offset: 0x000541D4
		public DataTemplate EmptyTemplate { get; set; }

		// Token: 0x06000D3F RID: 3391 RVA: 0x00055FE8 File Offset: 0x000541E8
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			SelectedExcel selectedExcel = \u0011\u0018\u000E.\u001F(item);
			if (selectedExcel != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(A.R.SelectTemplate(object, DependencyObject)).MethodHandle;
				}
				if (\u000D\u001B\u001D.\u0007(\u0002\u0003\u0004.\u0007(selectedExcel)) == 0)
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
					if (\u000D\u001B\u001D.\u0007(\u0015\u0016\u0004.\u0007(selectedExcel)) == 0)
					{
						for (;;)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						return \u001D\u0006\u0019.\u000A(this);
					}
				}
			}
			return \u0007\u0006\u0019.\u000A(this);
		}

		// Token: 0x04000544 RID: 1348
		[CompilerGenerated]
		private DataTemplate F;

		// Token: 0x04000545 RID: 1349
		[CompilerGenerated]
		private DataTemplate R;
	}
}

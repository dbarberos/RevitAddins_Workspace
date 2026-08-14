using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using DiRoots.One.TGDatabaseLayer;

namespace A
{
	// Token: 0x02000160 RID: 352
	internal class H : DataTemplateSelector
	{
		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000D47 RID: 3399 RVA: 0x00056128 File Offset: 0x00054328
		// (set) Token: 0x06000D48 RID: 3400 RVA: 0x0005613C File Offset: 0x0005433C
		public DataTemplate ComboBoxTemplate { get; set; }

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06000D49 RID: 3401 RVA: 0x00056150 File Offset: 0x00054350
		// (set) Token: 0x06000D4A RID: 3402 RVA: 0x00056164 File Offset: 0x00054364
		public DataTemplate TextBoxTemplate { get; set; }

		// Token: 0x06000D4B RID: 3403 RVA: 0x00056178 File Offset: 0x00054378
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			SelectedExcel selectedExcel = \u0011\u0018\u000E.\u001F(item);
			if (selectedExcel != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(H.SelectTemplate(object, DependencyObject)).MethodHandle;
				}
				if (\u000D\u001B\u001D.\u0007(\u0002\u0003\u0004.\u0007(selectedExcel)) == 0)
				{
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					if (\u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(selectedExcel)) != 5)
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
						return \u0016\u0006\u0019.\u000A(this);
					}
				}
			}
			return \u0005\u0006\u0019.\u000A(this);
		}

		// Token: 0x04000548 RID: 1352
		[CompilerGenerated]
		private DataTemplate F;

		// Token: 0x04000549 RID: 1353
		[CompilerGenerated]
		private DataTemplate R;
	}
}

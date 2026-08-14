using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using DiRoots.One.TableGen.ViewModels;

namespace A
{
	// Token: 0x0200015F RID: 351
	internal class D : DataTemplateSelector
	{
		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06000D41 RID: 3393 RVA: 0x00056070 File Offset: 0x00054270
		// (set) Token: 0x06000D42 RID: 3394 RVA: 0x00056084 File Offset: 0x00054284
		public DataTemplate ExcelViewsCountTemplate { get; set; }

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06000D43 RID: 3395 RVA: 0x00056098 File Offset: 0x00054298
		// (set) Token: 0x06000D44 RID: 3396 RVA: 0x000560AC File Offset: 0x000542AC
		public DataTemplate DefaultViewsCountTemplate { get; set; }

		// Token: 0x06000D45 RID: 3397 RVA: 0x000560C0 File Offset: 0x000542C0
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			IFileInfoViewModel fileInfoViewModel = \u0020\u0018\u000E.\u001F(item);
			if (fileInfoViewModel == null)
			{
				return null;
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(D.SelectTemplate(object, DependencyObject)).MethodHandle;
			}
			if (!\u0018\u0006\u0019.\u000A(fileInfoViewModel))
			{
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				return \u0019\u0006\u0019.\u000A(this);
			}
			return \u0004\u0006\u0019.\u000A(this);
		}

		// Token: 0x04000546 RID: 1350
		[CompilerGenerated]
		private DataTemplate F;

		// Token: 0x04000547 RID: 1351
		[CompilerGenerated]
		private DataTemplate R;
	}
}

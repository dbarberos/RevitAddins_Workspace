using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DiRoots.One.TableGen.UI
{
	// Token: 0x02000153 RID: 339
	public abstract class ConditionalTemplateSelector<T> : DataTemplateSelector
	{
		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06000CC0 RID: 3264 RVA: 0x000508B4 File Offset: 0x0004EAB4
		// (set) Token: 0x06000CC1 RID: 3265 RVA: 0x000508C8 File Offset: 0x0004EAC8
		public DataTemplate NullTemplate { get; set; }

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06000CC2 RID: 3266 RVA: 0x000508DC File Offset: 0x0004EADC
		// (set) Token: 0x06000CC3 RID: 3267 RVA: 0x000508F0 File Offset: 0x0004EAF0
		public DataTemplate DefaultTemplate { get; set; }

		// Token: 0x06000CC4 RID: 3268 RVA: 0x00050904 File Offset: 0x0004EB04
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (!(item is T))
			{
				return this.DefaultTemplate;
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(ConditionalTemplateSelector.SelectTemplate(object, DependencyObject)).MethodHandle;
			}
			T item2 = (T)((object)item);
			if (!this.UseFallback(item2))
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
				return this.DefaultTemplate;
			}
			return this.NullTemplate;
		}

		// Token: 0x06000CC5 RID: 3269
		protected abstract bool UseFallback(T item);

		// Token: 0x04000509 RID: 1289
		[CompilerGenerated]
		private DataTemplate F;

		// Token: 0x0400050A RID: 1290
		[CompilerGenerated]
		private DataTemplate R;
	}
}

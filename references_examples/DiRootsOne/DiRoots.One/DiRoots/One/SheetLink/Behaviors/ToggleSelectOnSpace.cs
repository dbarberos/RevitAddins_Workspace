using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using A;
using DiRoots.One.SheetLink.UI.Controls;
using Microsoft.Xaml.Behaviors;

namespace DiRoots.One.SheetLink.Behaviors
{
	// Token: 0x0200028A RID: 650
	public class ToggleSelectOnSpace : Behavior<Selector>
	{
		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x06001959 RID: 6489 RVA: 0x000A3FEC File Offset: 0x000A21EC
		// (set) Token: 0x0600195A RID: 6490 RVA: 0x000A4010 File Offset: 0x000A2210
		public ICommand ToggleSelectCommand
		{
			get
			{
				return \u000E\u0012\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, ToggleSelectOnSpace.toggleSelectCommand));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, ToggleSelectOnSpace.toggleSelectCommand, value);
			}
		}

		// Token: 0x0600195B RID: 6491 RVA: 0x000A402C File Offset: 0x000A222C
		protected override void OnAttached()
		{
			\u0003\u0006\u0019.\u000A(this);
			\u0003\u0015\u0005.\u000A(\u001C\u0015\u0005.\u000A(this), new KeyEventHandler(this.PreviewKeyUp));
		}

		// Token: 0x0600195C RID: 6492 RVA: 0x000A4058 File Offset: 0x000A2258
		protected override void OnDetaching()
		{
			\u000D\u0015\u0005.\u000A(\u001C\u0015\u0005.\u000A(this), new KeyEventHandler(this.PreviewKeyUp));
			\u000D\u0006\u0019.\u000A(this);
		}

		// Token: 0x0600195D RID: 6493 RVA: 0x000A4084 File Offset: 0x000A2284
		private void PreviewKeyUp(object sender, KeyEventArgs e)
		{
			if (\u001A\u001A\u0019.\u000A(e) == Key.Space)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ToggleSelectOnSpace.PreviewKeyUp(object, KeyEventArgs)).MethodHandle;
				}
				ICategoryModel categoryModel = \u001C\u0006\u000E.\u001F(\u0019\u000C\u0007.\u001D(\u001C\u0015\u0005.\u000A(this)));
				if (categoryModel != null)
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
					\u0013\u0013\u0018.\u000A(categoryModel, !\u001D\u000C\u0018.\u000A(categoryModel));
				}
			}
		}

		// Token: 0x04000A0A RID: 2570
		public static readonly DependencyProperty toggleSelectCommand = \u001D\u0015\u000A.\u000A("ToggleSelectCommand", \u001E\u0011\u000A.\u000A(\u001C\u0001\u0010.\u001F()), \u001E\u0011\u000A.\u000A(\u0008\u0012\u000E.\u001F()));
	}
}

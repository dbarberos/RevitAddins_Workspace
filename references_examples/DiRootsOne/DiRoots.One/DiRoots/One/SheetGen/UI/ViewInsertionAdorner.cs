using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using A;

namespace DiRoots.One.SheetGen.UI
{
	// Token: 0x0200038D RID: 909
	public class ViewInsertionAdorner : Adorner
	{
		// Token: 0x060024E0 RID: 9440 RVA: 0x000DF508 File Offset: 0x000DD708
		static ViewInsertionAdorner()
		{
			Pen pen = \u0019\u0001\u000B.\u000A();
			\u0004\u0001\u000B.\u000A(pen, \u001E\u000C\u000A.\u000A(\u0014\u0012\u0019.\u000A(241, 199, 120)));
			\u001D\u0001\u000B.\u000A(pen, 2.0);
			ViewInsertionAdorner.\u000A = pen;
			\u0007\u0001\u000B.\u000A(ViewInsertionAdorner.\u000A);
		}

		// Token: 0x060024E1 RID: 9441 RVA: 0x000DF55C File Offset: 0x000DD75C
		public ViewInsertionAdorner(UIElement adornedElement, AdornerLayer adornerLayer) : base(adornedElement)
		{
			this.\u001F = adornerLayer;
			\u0011\u0015\u000A.\u001D(this, false);
			\u0018\u0001\u000B.\u000A(this.\u001F, this);
		}

		// Token: 0x060024E2 RID: 9442 RVA: 0x000DF58C File Offset: 0x000DD78C
		protected override void OnRender(DrawingContext drawingContext)
		{
			Rect rect;
			\u0003\u0001\u000B.\u000A(ref rect, \u001C\u0001\u000B.\u000A(\u000D\u0001\u000B.\u000A(this)));
			Vector vector = \u000F\u0001\u000B.\u000A(\u0012\u0001\u000B.\u000A(ref rect), new Point(-1.0, 3.0));
			Rect u001D;
			\u0016\u0001\u000B.\u000A(ref u001D, new Point(\u0006\u0001\u000B.\u000A(ref vector), \u0002\u0001\u000B.\u000A(ref vector)), \u000B\u0001\u000B.\u000A(ref rect));
			\u0005\u0001\u000B.\u000A(drawingContext, null, ViewInsertionAdorner.\u000A, u001D, 3.0, 3.0);
		}

		// Token: 0x060024E3 RID: 9443 RVA: 0x000DF620 File Offset: 0x000DD820
		public void Detach()
		{
			\u0010\u0001\u000B.\u000A(this.\u001F, this);
		}

		// Token: 0x04000E8F RID: 3727
		private readonly AdornerLayer \u001F;

		// Token: 0x04000E90 RID: 3728
		private static readonly Pen \u000A;
	}
}

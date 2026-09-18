using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using A;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x02000040 RID: 64
	public class DraggedAdorner : Adorner
	{
		// Token: 0x060002B1 RID: 689 RVA: 0x0000FA28 File Offset: 0x0000DC28
		public DraggedAdorner(object dragDropData, DataTemplate dragDropTemplate, UIElement adornedElement, AdornerLayer adornerLayer) : base(adornedElement)
		{
			this.\u0003 = adornerLayer;
			ContentPresenter u000C = new ContentPresenter();
			\u001A\u001C\u0014.\u0018(u000C, dragDropData);
			\u001D\u001C\u0014.\u0018(u000C, dragDropTemplate);
			\u0004\u001C\u0014.\u0018(u000C, 0.7);
			this.\u000C = u000C;
			\u0002\u001C\u0014.\u0018(this.\u0003, this);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000FA78 File Offset: 0x0000DC78
		public void SetPosition(double left, double top)
		{
			this.\u0018 = left - 1.0;
			this.\u0014 = top + 13.0;
			if (this.\u0003 != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(DraggedAdorner.SetPosition(double, double)).MethodHandle;
				}
				try
				{
					\u000B\u001C\u0014.\u0018(this.\u0003, \u0019\u001C\u0014.\u0018(this));
				}
				catch
				{
				}
			}
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000FAEC File Offset: 0x0000DCEC
		protected override Size MeasureOverride(Size constraint)
		{
			\u0010\u001C\u0014.\u0018(this.\u000C, constraint);
			return \u0007\u001C\u0014.\u0018(this.\u000C);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000FB14 File Offset: 0x0000DD14
		protected override Size ArrangeOverride(Size finalSize)
		{
			\u0006\u001C\u0014.\u0018(this.\u000C, new Rect(finalSize));
			return finalSize;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000FB34 File Offset: 0x0000DD34
		protected override Visual GetVisualChild(int index)
		{
			return this.\u000C;
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x0000FB48 File Offset: 0x0000DD48
		protected override int VisualChildrenCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000FB58 File Offset: 0x0000DD58
		public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
		{
			GeneralTransformGroup generalTransformGroup = \u000E\u001C\u0014.\u0018();
			\u0008\u001C\u0014.\u0018(\u001B\u001C\u0014.\u0018(generalTransformGroup), \u0005\u001C\u0014.\u0018(this, transform));
			\u0008\u001C\u0014.\u0018(\u001B\u001C\u0014.\u0018(generalTransformGroup), \u0001\u001C\u0014.\u0018(this.\u0018, this.\u0014));
			return generalTransformGroup;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000FBA4 File Offset: 0x0000DDA4
		public void Detach()
		{
			\u000C\u0013\u0014.\u0018(this.\u0003, this);
		}

		// Token: 0x0400012B RID: 299
		private readonly ContentPresenter \u000C;

		// Token: 0x0400012C RID: 300
		private double \u0018;

		// Token: 0x0400012D RID: 301
		private double \u0014;

		// Token: 0x0400012E RID: 302
		private readonly AdornerLayer \u0003;
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using A;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x02000041 RID: 65
	public class InsertionAdorner : Adorner
	{
		// Token: 0x060002B9 RID: 697 RVA: 0x0000FBC0 File Offset: 0x0000DDC0
		static InsertionAdorner()
		{
			Pen pen = \u001F\u0013\u0014.\u0018();
			\u000A\u0013\u0014.\u0018(pen, \u0020\u0013\u0014.\u0018());
			\u0009\u0013\u0014.\u0018(pen, 2.0);
			InsertionAdorner.\u0014 = pen;
			\u0018\u0013\u0014.\u0018(InsertionAdorner.\u0014);
			LineSegment lineSegment = \u0013\u0013\u0014.\u0018(new Point(0.0, -5.0), false);
			\u0018\u0013\u0014.\u0018(lineSegment);
			LineSegment lineSegment2 = \u0013\u0013\u0014.\u0018(new Point(0.0, 5.0), false);
			\u0018\u0013\u0014.\u0018(lineSegment2);
			PathFigure pathFigure = \u001C\u0013\u0014.\u0018();
			\u000D\u0013\u0014.\u0018(pathFigure, new Point(5.0, 0.0));
			PathFigure pathFigure2 = pathFigure;
			\u000F\u0013\u0014.\u0018(\u0012\u0013\u0014.\u0018(pathFigure2), lineSegment);
			\u000F\u0013\u0014.\u0018(\u0012\u0013\u0014.\u0018(pathFigure2), lineSegment2);
			\u0018\u0013\u0014.\u0018(pathFigure2);
			InsertionAdorner.\u0003 = \u0016\u0013\u0014.\u0018();
			\u0014\u0013\u0014.\u0018(\u0003\u0013\u0014.\u0018(InsertionAdorner.\u0003), pathFigure2);
			\u0018\u0013\u0014.\u0018(InsertionAdorner.\u0003);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000FCBC File Offset: 0x0000DEBC
		public InsertionAdorner(bool isSeparatorHorizontal, bool isInFirstHalf, UIElement adornedElement, AdornerLayer adornerLayer) : base(adornedElement)
		{
			this.\u000C = isSeparatorHorizontal;
			\u000C\u001C\u0014.\u0003(this, isInFirstHalf);
			this.\u0018 = adornerLayer;
			\u0011\u0013\u0014.\u0018(this, false);
			\u0002\u001C\u0014.\u0018(this.\u0018, this);
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002BB RID: 699 RVA: 0x0000FCFC File Offset: 0x0000DEFC
		// (set) Token: 0x060002BC RID: 700 RVA: 0x0000FD10 File Offset: 0x0000DF10
		public bool IsInFirstHalf { get; set; }

		// Token: 0x060002BD RID: 701 RVA: 0x0000FD24 File Offset: 0x0000DF24
		protected override void OnRender(DrawingContext drawingContext)
		{
			Point point;
			Point point2;
			this.\u0012(out point, out point2);
			\u0015\u0013\u0014.\u0018(drawingContext, InsertionAdorner.\u0014, point, point2);
			if (this.\u000C)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(InsertionAdorner.OnRender(DrawingContext)).MethodHandle;
				}
				this.\u000F(drawingContext, point, 0.0);
				this.\u000F(drawingContext, point2, 180.0);
				return;
			}
			this.\u000F(drawingContext, point, 90.0);
			this.\u000F(drawingContext, point2, -90.0);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000FDA8 File Offset: 0x0000DFA8
		private void \u000F(DrawingContext \u000C, Point \u0018, double \u0014)
		{
			\u0004\u0013\u0014.\u0018(\u000C, \u0001\u001C\u0014.\u0018(\u0010\u000D\u0014.\u0018(ref \u0018), \u0019\u000D\u0014.\u0018(ref \u0018)));
			\u0004\u0013\u0014.\u0018(\u000C, \u001D\u0013\u0014.\u0018(\u0014));
			\u001E\u0013\u0014.\u0018(\u000C, \u0002\u0013\u0014.\u0018(InsertionAdorner.\u0014), null, InsertionAdorner.\u0003);
			\u0017\u0013\u0014.\u0018(\u000C);
			\u0017\u0013\u0014.\u0018(\u000C);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000FE08 File Offset: 0x0000E008
		private unsafe void \u0012(out Point \u000C, out Point \u0018)
		{
			\u0003\u001A\u000F.\u000C(ref \u000C);
			\u0003\u001A\u000F.\u000C(ref \u0018);
			Size size = \u0010\u0013\u0014.\u0018(\u0019\u001C\u0014.\u0018(this));
			double u = \u0006\u0013\u0014.\u0018(ref size);
			size = \u0010\u0013\u0014.\u0018(\u0019\u001C\u0014.\u0018(this));
			double u2 = \u0007\u0013\u0014.\u0018(ref size);
			if (this.\u000C)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(InsertionAdorner.\u0012(Point*, Point*)).MethodHandle;
				}
				\u001A\u0013\u0014.\u0018(ref \u0018, u);
				if (!\u000B\u0013\u0014.\u0018(this))
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
					\u0019\u0013\u0014.\u0018(ref \u000C, u2);
					\u0019\u0013\u0014.\u0018(ref \u0018, u2);
					return;
				}
			}
			else
			{
				\u0019\u0013\u0014.\u0018(ref \u0018, u2);
				if (!\u000B\u0013\u0014.\u0018(this))
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
					\u001A\u0013\u0014.\u0018(ref \u000C, u);
					\u001A\u0013\u0014.\u0018(ref \u0018, u);
				}
			}
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000FEC4 File Offset: 0x0000E0C4
		public void Detach()
		{
			\u000C\u0013\u0014.\u0018(this.\u0018, this);
		}

		// Token: 0x0400012F RID: 303
		private readonly bool \u000C;

		// Token: 0x04000130 RID: 304
		private readonly AdornerLayer \u0018;

		// Token: 0x04000131 RID: 305
		private static readonly Pen \u0014;

		// Token: 0x04000132 RID: 306
		private static readonly PathGeometry \u0003;

		// Token: 0x04000133 RID: 307
		[CompilerGenerated]
		private bool \u0016;
	}
}

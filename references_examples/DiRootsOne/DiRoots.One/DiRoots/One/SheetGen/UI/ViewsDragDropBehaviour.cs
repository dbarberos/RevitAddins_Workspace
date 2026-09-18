using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using A;
using DiRoots.One.SheetGen.Data;
using DiRoots.One.UIBehaviours.DragDrop;

namespace DiRoots.One.SheetGen.UI
{
	// Token: 0x0200038E RID: 910
	public class ViewsDragDropBehaviour
	{
		// Token: 0x17000A67 RID: 2663
		// (get) Token: 0x060024E6 RID: 9446 RVA: 0x000DF7A8 File Offset: 0x000DD9A8
		private static ViewsDragDropBehaviour Instance
		{
			get
			{
				ViewsDragDropBehaviour result;
				if ((result = ViewsDragDropBehaviour._instance) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.get_Instance()).MethodHandle;
					}
					result = (ViewsDragDropBehaviour._instance = \u001B\u0001\u000B.\u000A());
				}
				return result;
			}
		}

		// Token: 0x060024E7 RID: 9447 RVA: 0x000DF7E0 File Offset: 0x000DD9E0
		public static bool GetIsDropRejectFromOthers(DependencyObject obj)
		{
			return \u001F\u0001\u0010.\u001F(\u0004\u0015\u000A.\u001D(obj, ViewsDragDropBehaviour.IsDropRejectFromOthersProperty));
		}

		// Token: 0x060024E8 RID: 9448 RVA: 0x000DF804 File Offset: 0x000DDA04
		public static void SetIsDropRejectFromOthers(DependencyObject obj, bool value)
		{
			\u0019\u0015\u000A.\u001D(obj, ViewsDragDropBehaviour.IsDropRejectFromOthersProperty, value);
		}

		// Token: 0x060024E9 RID: 9449 RVA: 0x000DF824 File Offset: 0x000DDA24
		public static bool GetIsDropRejectFromSelf(DependencyObject obj)
		{
			return \u001F\u0001\u0010.\u001F(\u0004\u0015\u000A.\u001D(obj, ViewsDragDropBehaviour.IsDropRejectFromSelfProperty));
		}

		// Token: 0x060024EA RID: 9450 RVA: 0x000DF848 File Offset: 0x000DDA48
		public static void SetIsDropRejectFromSelf(DependencyObject obj, bool value)
		{
			\u0019\u0015\u000A.\u001D(obj, ViewsDragDropBehaviour.IsDropRejectFromSelfProperty, value);
		}

		// Token: 0x060024EB RID: 9451 RVA: 0x000DF868 File Offset: 0x000DDA68
		public static bool GetIsDragSource(DependencyObject obj)
		{
			return \u001F\u0001\u0010.\u001F(\u0004\u0015\u000A.\u001D(obj, ViewsDragDropBehaviour.IsDragSourceProperty));
		}

		// Token: 0x060024EC RID: 9452 RVA: 0x000DF88C File Offset: 0x000DDA8C
		public static void SetIsDragSource(DependencyObject obj, bool value)
		{
			\u0019\u0015\u000A.\u001D(obj, ViewsDragDropBehaviour.IsDragSourceProperty, value);
		}

		// Token: 0x060024ED RID: 9453 RVA: 0x000DF8AC File Offset: 0x000DDAAC
		public static bool GetIsDropTarget(DependencyObject obj)
		{
			return \u001F\u0001\u0010.\u001F(\u0004\u0015\u000A.\u001D(obj, ViewsDragDropBehaviour.IsDropTargetProperty));
		}

		// Token: 0x060024EE RID: 9454 RVA: 0x000DF8D0 File Offset: 0x000DDAD0
		public static void SetIsDropTarget(DependencyObject obj, bool value)
		{
			\u0019\u0015\u000A.\u001D(obj, ViewsDragDropBehaviour.IsDropTargetProperty, value);
		}

		// Token: 0x060024EF RID: 9455 RVA: 0x000DF8F0 File Offset: 0x000DDAF0
		public static DataTemplate GetDragDropTemplate(DependencyObject obj)
		{
			return \u000F\u000E\u000E.\u001F(\u0004\u0015\u000A.\u001D(obj, ViewsDragDropBehaviour.DragDropTemplateProperty));
		}

		// Token: 0x060024F0 RID: 9456 RVA: 0x000DF914 File Offset: 0x000DDB14
		public static void SetDragDropTemplate(DependencyObject obj, DataTemplate value)
		{
			\u0019\u0015\u000A.\u001D(obj, ViewsDragDropBehaviour.DragDropTemplateProperty, value);
		}

		// Token: 0x060024F1 RID: 9457 RVA: 0x000DF930 File Offset: 0x000DDB30
		private void W(object F, MouseButtonEventArgs R)
		{
			this.B = \u000D\u000A\u000E.\u001F(F);
			this.S = \u0020\u0012\u0005.\u000A(this.B);
			this.R = \u0011\u0001\u000B.\u000A(R, this.S);
			this.H = \u0007\u000C\u000A.\u0007(this.B);
		}

		// Token: 0x060024F2 RID: 9458 RVA: 0x000DF988 File Offset: 0x000DDB88
		private void K(object F, MouseEventArgs R)
		{
			if (this.H != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.K(object, MouseEventArgs)).MethodHandle;
				}
				if (ViewsDragDropBehaviour.CR(this.R, \u0011\u0001\u000B.\u000A(R, this.S)))
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
					this.D = \u000F\u0001\u000B.\u000A(this.R, \u0009\u0001\u000B.\u000A(this.B, new Point(0.0, 0.0), this.S));
					DataObject u000A = \u0016\u0001\u0007.\u000A(\u0001\u0001\u000B.\u000A(this.F), this.H);
					bool u000A2 = \u0015\u0001\u000B.\u000A(this.S);
					\u0014\u0001\u000B.\u000A(this.S, true);
					\u000C\u0001\u000B.\u000A(this.S, new DragEventHandler(this.P));
					\u001A\u0001\u000B.\u000A(this.S, new DragEventHandler(this.O));
					\u0013\u0001\u000B.\u000A(this.S, new DragEventHandler(this.T));
					\u0005\u0001\u0007.\u000A(\u000A\u0007\u000E.\u001F(F), u000A, DragDropEffects.Move);
					this.RR();
					\u0014\u0001\u000B.\u000A(this.S, u000A2);
					\u0017\u0001\u000B.\u000A(this.S, new DragEventHandler(this.P));
					\u0020\u0001\u000B.\u000A(this.S, new DragEventHandler(this.O));
					\u001E\u0001\u000B.\u000A(this.S, new DragEventHandler(this.T));
					this.H = \u0019\u001D\u000E.\u001F;
				}
			}
		}

		// Token: 0x060024F3 RID: 9459 RVA: 0x000DFB08 File Offset: 0x000DDD08
		private void J(object F, MouseButtonEventArgs R)
		{
			this.H = \u0019\u001D\u000E.\u001F;
		}

		// Token: 0x060024F4 RID: 9460 RVA: 0x000DFB20 File Offset: 0x000DDD20
		private void E(object F, DragEventArgs R)
		{
			this.U = \u000D\u000A\u000E.\u001F(F);
			bool flag = \u000C\u0007\u0019.\u000A(\u0002\u0001\u0007.\u000A(R), \u0001\u0001\u000B.\u000A(this.F)) != null;
			this.A(R);
			if (flag)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.E(object, DragEventArgs)).MethodHandle;
				}
				Point f = \u001F\u0009\u000B.\u000A(R, this.S);
				this.FR(f);
				this.DR();
			}
			\u0019\u0013\u000A.\u000A(R, true);
		}

		// Token: 0x060024F5 RID: 9461 RVA: 0x000DFB98 File Offset: 0x000DDD98
		private void N(object F, DragEventArgs R)
		{
			bool flag = \u000C\u0007\u0019.\u000A(\u0002\u0001\u0007.\u000A(R), \u0001\u0001\u000B.\u000A(this.F)) != null;
			this.A(R);
			if (flag)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.N(object, DragEventArgs)).MethodHandle;
				}
				Point f = \u001F\u0009\u000B.\u000A(R, this.S);
				this.FR(f);
				this.HR();
			}
			\u0019\u0013\u000A.\u000A(R, true);
		}

		// Token: 0x060024F6 RID: 9462 RVA: 0x000DFC00 File Offset: 0x000DDE00
		private void M(object F, DragEventArgs R)
		{
			if (\u0007\u0009\u000B.\u000A(this.U))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.M(object, DragEventArgs)).MethodHandle;
				}
				this.U = \u000B\u000E\u000E.\u001F;
				\u0007\u0005\u0019.\u000A(R, DragDropEffects.None);
				return;
			}
			object obj = \u000C\u0007\u0019.\u000A(\u0002\u0001\u0007.\u000A(R), \u0001\u0001\u000B.\u000A(this.F));
			if (obj != null)
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
				if (!\u000A\u0009\u000B.\u000A(this.U))
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
					ViewsDragDropBehaviour.\u0017\u0014 u0017_u = new ViewsDragDropBehaviour.\u0017\u0014();
					ViewInfo viewInfo = \u0006\u000E\u000E.\u001F(\u0007\u000C\u000A.\u0007(this.U));
					if (viewInfo != null)
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
						u0017_u.\u001F = \u0006\u000E\u000E.\u001F(obj);
						if (u0017_u.\u001F != null)
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
							\u0019\u0008\u0016.\u001D(viewInfo, \u001D\u0019\u0016.\u0007(u0017_u.\u001F));
							\u000A\u0008\u0016.\u001D(viewInfo, \u0010\u0002\u0016.\u000A(\u000E\u0002\u0016.\u0007(Collector.\u0004), \u001D\u0019\u0016.\u0007(viewInfo)));
							\u0002\u0010\u0016.\u0007(viewInfo, Enumerable.FirstOrDefault<ViewData>(\u0006\u0010\u0016.\u0007(u0017_u.\u001F), new Func<ViewData, bool>(u0017_u.\u000A)));
						}
					}
				}
				else
				{
					\u001B\u001F\u0018.\u000A(\u0003\u0011\u000A.\u0007(obj));
				}
				this.RR();
				this.YR();
			}
			\u0019\u0013\u000A.\u000A(R, true);
		}

		// Token: 0x060024F7 RID: 9463 RVA: 0x000DFD58 File Offset: 0x000DDF58
		private void V(object F, DragEventArgs R)
		{
			if (\u000C\u0007\u0019.\u000A(\u0002\u0001\u0007.\u000A(R), \u0001\u0001\u000B.\u000A(this.F)) != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.V(object, DragEventArgs)).MethodHandle;
				}
				this.YR();
			}
			\u0019\u0013\u000A.\u000A(R, true);
		}

		// Token: 0x060024F8 RID: 9464 RVA: 0x000DFDA4 File Offset: 0x000DDFA4
		private void P(object F, DragEventArgs R)
		{
			this.FR(\u001F\u0009\u000B.\u000A(R, this.S));
			\u0007\u0005\u0019.\u000A(R, DragDropEffects.None);
			\u0019\u0013\u000A.\u000A(R, true);
		}

		// Token: 0x060024F9 RID: 9465 RVA: 0x000DFDD4 File Offset: 0x000DDFD4
		private void O(object F, DragEventArgs R)
		{
			this.FR(\u001F\u0009\u000B.\u000A(R, this.S));
			\u0007\u0005\u0019.\u000A(R, DragDropEffects.None);
			\u0019\u0013\u000A.\u000A(R, true);
		}

		// Token: 0x060024FA RID: 9466 RVA: 0x000DFE04 File Offset: 0x000DE004
		private void T(object F, DragEventArgs R)
		{
			this.RR();
			\u0019\u0013\u000A.\u000A(R, true);
		}

		// Token: 0x060024FB RID: 9467 RVA: 0x000DFE20 File Offset: 0x000DE020
		private static void I(DependencyObject F, DependencyPropertyChangedEventArgs R)
		{
			Control control = \u0002\u000E\u000E.\u001F(F);
			if (control != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.I(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				if (\u000B\u0009\u000B.\u000A(\u001D\u0014\u000B.\u000A(ref R), true))
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
					\u0003\u0001\u0007.\u000A(control, new MouseButtonEventHandler(\u0004\u0009\u000B.\u000A().W));
					\u0016\u0009\u000B.\u000A(control, new MouseButtonEventHandler(\u0004\u0009\u000B.\u000A().J));
					\u0005\u0009\u000B.\u000A(control, new MouseEventHandler(\u0004\u0009\u000B.\u000A().K));
					return;
				}
				\u0018\u0009\u000B.\u000A(control, new MouseButtonEventHandler(\u0004\u0009\u000B.\u000A().W));
				\u0019\u0009\u000B.\u000A(control, new MouseButtonEventHandler(\u0004\u0009\u000B.\u000A().J));
				\u001D\u0009\u000B.\u000A(control, new MouseEventHandler(\u0004\u0009\u000B.\u000A().K));
			}
		}

		// Token: 0x060024FC RID: 9468 RVA: 0x000DFF04 File Offset: 0x000DE104
		private static void Q(DependencyObject F, DependencyPropertyChangedEventArgs R)
		{
			Control control = \u0002\u000E\u000E.\u001F(F);
			if (control != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.Q(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				if (\u000B\u0009\u000B.\u000A(\u001D\u0014\u000B.\u000A(ref R), true))
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
					\u0014\u0001\u000B.\u000A(control, true);
					\u0019\u0002\u0019.\u000A(control, new DragEventHandler(\u0004\u0009\u000B.\u000A().M));
					\u0005\u0002\u0019.\u000A(control, new DragEventHandler(\u0004\u0009\u000B.\u000A().E));
					\u0018\u0002\u0019.\u000A(control, new DragEventHandler(\u0004\u0009\u000B.\u000A().N));
					\u0003\u0009\u000B.\u000A(control, new DragEventHandler(\u0004\u0009\u000B.\u000A().V));
					return;
				}
				\u0014\u0001\u000B.\u000A(control, false);
				\u0012\u0009\u000B.\u000A(control, new DragEventHandler(\u0004\u0009\u000B.\u000A().M));
				\u000F\u0009\u000B.\u000A(control, new DragEventHandler(\u0004\u0009\u000B.\u000A().E));
				\u0006\u0009\u000B.\u000A(control, new DragEventHandler(\u0004\u0009\u000B.\u000A().N));
				\u0002\u0009\u000B.\u000A(control, new DragEventHandler(\u0004\u0009\u000B.\u000A().V));
			}
		}

		// Token: 0x060024FD RID: 9469 RVA: 0x000E0024 File Offset: 0x000DE224
		private void A(DragEventArgs F)
		{
			object f = \u000C\u0007\u0019.\u000A(\u0002\u0001\u0007.\u000A(F), \u0001\u0001\u000B.\u000A(this.F));
			if (!this.G(f))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.A(DragEventArgs)).MethodHandle;
				}
				this.U = \u000B\u000E\u000E.\u001F;
				\u0007\u0005\u0019.\u000A(F, DragDropEffects.None);
			}
		}

		// Token: 0x060024FE RID: 9470 RVA: 0x000E0080 File Offset: 0x000DE280
		private bool G(object F)
		{
			bool result;
			if (F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.G(object)).MethodHandle;
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060024FF RID: 9471 RVA: 0x000E00AC File Offset: 0x000DE2AC
		private void FR(Point F)
		{
			if (this.C == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.FR(Point)).MethodHandle;
				}
				AdornerLayer u001D = \u001B\u0009\u000B.\u000A(this.B);
				this.C = \u000E\u0009\u000B.\u000A(this.H, \u0008\u0009\u000B.\u000A(this.B), this.B, u001D);
			}
			double u000A = \u0010\u0009\u000B.\u000A(ref F) - \u0010\u0009\u000B.\u000A(ref this.R) + \u0006\u0001\u000B.\u000A(ref this.D);
			double u = \u000D\u0009\u000B.\u000A(ref F) - \u000D\u0009\u000B.\u000A(ref this.R) + \u0002\u0001\u000B.\u000A(ref this.D);
			\u001C\u0009\u000B.\u000A(this.C, u000A, u);
		}

		// Token: 0x06002500 RID: 9472 RVA: 0x000E0164 File Offset: 0x000DE364
		private void RR()
		{
			if (this.C != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.RR()).MethodHandle;
				}
				\u0011\u0009\u000B.\u000A(this.C);
				this.C = \u0016\u000E\u000E.\u001F;
			}
		}

		// Token: 0x06002501 RID: 9473 RVA: 0x000E01A4 File Offset: 0x000DE3A4
		private void DR()
		{
			if (this.U != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.DR()).MethodHandle;
				}
				AdornerLayer u000A = \u001B\u0009\u000B.\u000A(this.U);
				this.L = \u001E\u0009\u000B.\u000A(this.U, u000A);
			}
		}

		// Token: 0x06002502 RID: 9474 RVA: 0x000E01F0 File Offset: 0x000DE3F0
		private void HR()
		{
			if (this.L != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.HR()).MethodHandle;
				}
				\u0020\u0009\u000B.\u000A(this.L);
			}
		}

		// Token: 0x06002503 RID: 9475 RVA: 0x000E0224 File Offset: 0x000DE424
		private void YR()
		{
			if (this.L != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.YR()).MethodHandle;
				}
				\u0017\u0009\u000B.\u000A(this.L);
				this.L = \u0005\u000E\u000E.\u001F;
			}
		}

		// Token: 0x06002504 RID: 9476 RVA: 0x000E0264 File Offset: 0x000DE464
		private static bool CR(Point F, Point R)
		{
			if (\u0008\u001F\u0007.\u000A(\u0010\u0009\u000B.\u000A(ref R) - \u0010\u0009\u000B.\u000A(ref F)) < \u0013\u0009\u000B.\u000A())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsDragDropBehaviour.CR(Point, Point)).MethodHandle;
				}
				return \u0008\u001F\u0007.\u000A(\u000D\u0009\u000B.\u000A(ref R) - \u000D\u0009\u000B.\u000A(ref F)) >= \u0014\u0009\u000B.\u000A();
			}
			return true;
		}

		// Token: 0x04000E91 RID: 3729
		private readonly DataFormat F = \u000E\u0001\u000B.\u000A("DragDropControl");

		// Token: 0x04000E92 RID: 3730
		private Point R;

		// Token: 0x04000E93 RID: 3731
		private Vector D;

		// Token: 0x04000E94 RID: 3732
		private object H;

		// Token: 0x04000E95 RID: 3733
		private DraggedAdorner C;

		// Token: 0x04000E96 RID: 3734
		private ViewInsertionAdorner L;

		// Token: 0x04000E97 RID: 3735
		private Window S;

		// Token: 0x04000E98 RID: 3736
		private Control B;

		// Token: 0x04000E99 RID: 3737
		private Control U;

		// Token: 0x04000E9A RID: 3738
		private static ViewsDragDropBehaviour _instance;

		// Token: 0x04000E9B RID: 3739
		public static readonly DependencyProperty IsDropRejectFromOthersProperty = \u001F\u0001\u000A.\u000A("IsDropRejectFromOthers", \u001E\u0011\u000A.\u000A(\u0006\u001D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0012\u000E\u000E.\u001F()), \u0008\u0001\u000B.\u000A(\u0003\u000E\u000E.\u001F));

		// Token: 0x04000E9C RID: 3740
		public static readonly DependencyProperty IsDropRejectFromSelfProperty = \u001F\u0001\u000A.\u000A("IsDropRejectFromSelf", \u001E\u0011\u000A.\u000A(\u0006\u001D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0012\u000E\u000E.\u001F()), \u0008\u0001\u000B.\u000A(\u0003\u000E\u000E.\u001F));

		// Token: 0x04000E9D RID: 3741
		public static readonly DependencyProperty IsDragSourceProperty = \u001F\u0001\u000A.\u000A("IsDragSource", \u001E\u0011\u000A.\u000A(\u0006\u001D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0012\u000E\u000E.\u001F()), \u0013\u0017\u000B.\u000A(false, new PropertyChangedCallback(ViewsDragDropBehaviour.I)));

		// Token: 0x04000E9E RID: 3742
		public static readonly DependencyProperty IsDropTargetProperty = \u001F\u0001\u000A.\u000A("IsDropTarget", \u001E\u0011\u000A.\u000A(\u0006\u001D\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0012\u000E\u000E.\u001F()), \u0013\u0017\u000B.\u000A(false, new PropertyChangedCallback(ViewsDragDropBehaviour.Q)));

		// Token: 0x04000E9F RID: 3743
		public static readonly DependencyProperty DragDropTemplateProperty = \u001F\u0001\u000A.\u000A("DragDropTemplate", \u001E\u0011\u000A.\u000A(\u001C\u000E\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0012\u000E\u000E.\u001F()), \u0008\u0001\u000B.\u000A(\u0003\u000E\u000E.\u001F));

		// Token: 0x02000A46 RID: 2630
		[CompilerGenerated]
		private sealed class \u0017\u0014
		{
			// Token: 0x060055F1 RID: 22001 RVA: 0x001F2470 File Offset: 0x001F0670
			internal bool \u000A(ViewData \u001F)
			{
				return \u000B\u0019\u0016.\u0007(\u001F) == \u000B\u0019\u0016.\u0007(\u0002\u0019\u0016.\u0007(this.\u001F));
			}

			// Token: 0x04002713 RID: 10003
			public ViewInfo \u001F;
		}
	}
}

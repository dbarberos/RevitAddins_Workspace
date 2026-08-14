using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using A;

namespace DiRoots.ProSheets.UI
{
	// Token: 0x0200003E RID: 62
	public class DragDropBehaviour
	{
		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600028B RID: 651 RVA: 0x0000E51C File Offset: 0x0000C71C
		private static DragDropBehaviour Instance
		{
			get
			{
				DragDropBehaviour result;
				if ((result = DragDropBehaviour._instance) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.get_Instance()).MethodHandle;
					}
					result = (DragDropBehaviour._instance = \u0018\u0012\u0014.\u0018());
				}
				return result;
			}
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000E554 File Offset: 0x0000C754
		public static bool GetIsDropRejectFromOthers(DependencyObject obj)
		{
			return \u0017\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0003(obj, DragDropBehaviour.IsDropRejectFromOthersProperty));
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000E578 File Offset: 0x0000C778
		public static void SetIsDropRejectFromOthers(DependencyObject obj, bool value)
		{
			\u0007\u001A\u0018.\u0003(obj, DragDropBehaviour.IsDropRejectFromOthersProperty, value);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000E598 File Offset: 0x0000C798
		public static bool GetIsDropRejectFromSelf(DependencyObject obj)
		{
			return \u0017\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0003(obj, DragDropBehaviour.IsDropRejectFromSelfProperty));
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000E5BC File Offset: 0x0000C7BC
		public static void SetIsDropRejectFromSelf(DependencyObject obj, bool value)
		{
			\u0007\u001A\u0018.\u0003(obj, DragDropBehaviour.IsDropRejectFromSelfProperty, value);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000E5DC File Offset: 0x0000C7DC
		public static bool GetIsDragSource(DependencyObject obj)
		{
			return \u0017\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0003(obj, DragDropBehaviour.IsDragSourceProperty));
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000E600 File Offset: 0x0000C800
		public static void SetIsDragSource(DependencyObject obj, bool value)
		{
			\u0007\u001A\u0018.\u0003(obj, DragDropBehaviour.IsDragSourceProperty, value);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000E620 File Offset: 0x0000C820
		public static bool GetIsDropTarget(DependencyObject obj)
		{
			return \u0017\u0002\u000F.\u000C(\u0019\u001A\u0018.\u0003(obj, DragDropBehaviour.IsDropTargetProperty));
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000E644 File Offset: 0x0000C844
		public static void SetIsDropTarget(DependencyObject obj, bool value)
		{
			\u0007\u001A\u0018.\u0003(obj, DragDropBehaviour.IsDropTargetProperty, value);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000E664 File Offset: 0x0000C864
		public static DataTemplate GetDragDropTemplate(DependencyObject obj)
		{
			return \u000C\u001A\u000F.\u000C(\u0019\u001A\u0018.\u0003(obj, DragDropBehaviour.DragDropTemplateProperty));
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000E688 File Offset: 0x0000C888
		public static void SetDragDropTemplate(DependencyObject obj, DataTemplate value)
		{
			\u0007\u001A\u0018.\u0003(obj, DragDropBehaviour.DragDropTemplateProperty, value);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000E6A4 File Offset: 0x0000C8A4
		private void I(object P, MouseButtonEventArgs Q)
		{
			this.M = \u0005\u001D\u000F.\u000C(P);
			Visual u = \u000E\u001D\u000F.\u000C(\u000F\u0012\u0014.\u0018(Q));
			this.X = \u0010\u001D\u000F.\u000C(\u0016\u0012\u0014.\u0018(this.M, u));
			if (this.X != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.I(object, MouseButtonEventArgs)).MethodHandle;
				}
				this.F = \u0003\u0012\u0014.\u0014(this.X);
			}
			int j = DragDropBehaviour.CB(this.M, this.F);
			object q = \u0014\u0012\u0014.\u0018(\u0004\u0017\u0018.\u0014(this.F));
			DragDropBehaviour.OB(this.M, q, j);
			\u001D\u000B\u0018.\u0018(Q, true);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000E758 File Offset: 0x0000C958
		private void S(object P, MouseButtonEventArgs Q)
		{
			this.M = \u0005\u001D\u000F.\u000C(P);
			Visual u = \u000E\u001D\u000F.\u000C(\u000F\u0012\u0014.\u0018(Q));
			this.Z = \u0005\u0007\u0018.\u0018(this.M);
			this.Q = \u0012\u0012\u0014.\u0018(Q, this.Z);
			this.X = \u0010\u001D\u000F.\u000C(\u0016\u0012\u0014.\u0018(this.M, u));
			if (this.X != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.S(object, MouseButtonEventArgs)).MethodHandle;
				}
				this.F = \u0003\u0012\u0014.\u0014(this.X);
			}
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000E7F4 File Offset: 0x0000C9F4
		private void U(object P, MouseEventArgs Q)
		{
			if (this.F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.U(object, MouseEventArgs)).MethodHandle;
				}
				if (DragDropBehaviour.IB(this.Q, \u0012\u0012\u0014.\u0018(Q, this.Z)))
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
					this.J = \u0002\u0012\u0014.\u0018(this.Q, \u0004\u0012\u0014.\u0018(this.X, new Point(0.0, 0.0), this.Z));
					DataObject u = \u0017\u0012\u0014.\u0018(\u001E\u0012\u0014.\u0018(this.P), this.F);
					bool u2 = \u0015\u0012\u0014.\u0018(this.Z);
					\u0009\u0012\u0014.\u0018(this.Z, true);
					\u0011\u0012\u0014.\u0018(this.Z, new DragEventHandler(this.K));
					\u001F\u0012\u0014.\u0018(this.Z, new DragEventHandler(this.PB));
					\u0020\u0012\u0014.\u0018(this.Z, new DragEventHandler(this.BB));
					\u000A\u0012\u0014.\u0018(\u0006\u001D\u000F.\u000C(P), u, DragDropEffects.Move);
					this.NB();
					\u0009\u0012\u0014.\u0018(this.Z, u2);
					\u0013\u0012\u0014.\u0018(this.Z, new DragEventHandler(this.K));
					\u001C\u0012\u0014.\u0018(this.Z, new DragEventHandler(this.PB));
					\u000D\u0012\u0014.\u0018(this.Z, new DragEventHandler(this.BB));
					this.F = \u001F\u0002\u000F.\u000C;
				}
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000E974 File Offset: 0x0000CB74
		private void L(object P, MouseButtonEventArgs Q)
		{
			this.F = \u001F\u0002\u000F.\u000C;
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000E98C File Offset: 0x0000CB8C
		private void E(object P, DragEventArgs Q)
		{
			this.Y = \u0005\u001D\u000F.\u000C(P);
			bool flag = \u001A\u0012\u0014.\u0018(\u000B\u0012\u0014.\u0018(Q), \u001E\u0012\u0014.\u0018(this.P)) != null;
			this.FB(Q);
			if (flag)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.E(object, DragEventArgs)).MethodHandle;
				}
				Point p = \u001D\u0012\u0014.\u0018(Q, this.Z);
				this.HB(p);
				this.ZB();
			}
			\u001D\u000B\u0018.\u0018(Q, true);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000EA04 File Offset: 0x0000CC04
		private void A(object P, DragEventArgs Q)
		{
			bool flag = \u001A\u0012\u0014.\u0018(\u000B\u0012\u0014.\u0018(Q), \u001E\u0012\u0014.\u0018(this.P)) != null;
			this.FB(Q);
			if (flag)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.A(object, DragEventArgs)).MethodHandle;
				}
				Point p = \u001D\u0012\u0014.\u0018(Q, this.Z);
				this.HB(p);
				this.MB();
			}
			\u001D\u000B\u0018.\u0018(Q, true);
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000EA6C File Offset: 0x0000CC6C
		private void V(object P, DragEventArgs Q)
		{
			if (\u000E\u0012\u0014.\u0018(this.Y))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.V(object, DragEventArgs)).MethodHandle;
				}
				this.O = \u0008\u001D\u000F.\u000C;
				this.W = -1;
				\u0005\u0012\u0014.\u0018(Q, DragDropEffects.None);
				return;
			}
			object obj = \u001A\u0012\u0014.\u0018(\u000B\u0012\u0014.\u0018(Q), \u001E\u0012\u0014.\u0018(this.P));
			int num = -1;
			if (obj != null)
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
				if ((\u001B\u0012\u0014.\u0018(Q) & DragDropEffects.Move) != DragDropEffects.None)
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
					num = DragDropBehaviour.CB(this.M, obj);
				}
				if (num != -1)
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
					if (this.M == this.Y)
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
						if (num < this.W)
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
							this.W--;
						}
					}
				}
				if (!\u0001\u0012\u0014.\u0018(this.Y))
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
					IEnumerable enumerable = \u0008\u0012\u0014.\u0018(this.Y);
					Type u000C = \u0004\u0017\u0018.\u0014(enumerable);
					int num2;
					if (\u0010\u0012\u0014.\u0018(\u0006\u0012\u0014.\u0018(u000C, "IList`1"), \u0017\u001D\u000F.\u000C))
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
						num2 = \u001F\u001D\u000F.\u000C(\u0019\u0012\u0014.\u0018(\u0007\u0012\u0014.\u0018(u000C, "Count"), enumerable, \u001B\u001D\u000F.\u000C));
					}
					else
					{
						num2 = enumerable.\u000C();
					}
					if (num2 >= this.W)
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
						DragDropBehaviour.OB(this.Y, obj, this.W);
					}
				}
				else
				{
					object q = \u0014\u0012\u0014.\u0018(\u0004\u0017\u0018.\u0014(obj));
					DragDropBehaviour.OB(this.M, q, num);
				}
				this.NB();
				this.XB();
			}
			\u001D\u000B\u0018.\u0018(Q, true);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000EC34 File Offset: 0x0000CE34
		private void D(object P, DragEventArgs Q)
		{
			if (\u001A\u0012\u0014.\u0018(\u000B\u0012\u0014.\u0018(Q), \u001E\u0012\u0014.\u0018(this.P)) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.D(object, DragEventArgs)).MethodHandle;
				}
				this.XB();
			}
			\u001D\u000B\u0018.\u0018(Q, true);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000EC80 File Offset: 0x0000CE80
		private void K(object P, DragEventArgs Q)
		{
			this.HB(\u001D\u0012\u0014.\u0018(Q, this.Z));
			\u0005\u0012\u0014.\u0018(Q, DragDropEffects.None);
			\u001D\u000B\u0018.\u0018(Q, true);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000ECB0 File Offset: 0x0000CEB0
		private void PB(object P, DragEventArgs Q)
		{
			this.HB(\u001D\u0012\u0014.\u0018(Q, this.Z));
			\u0005\u0012\u0014.\u0018(Q, DragDropEffects.None);
			\u001D\u000B\u0018.\u0018(Q, true);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000ECE0 File Offset: 0x0000CEE0
		private void BB(object P, DragEventArgs Q)
		{
			this.NB();
			\u001D\u000B\u0018.\u0018(Q, true);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000ECFC File Offset: 0x0000CEFC
		private static void QB(DependencyObject P, DependencyPropertyChangedEventArgs Q)
		{
			ItemsControl itemsControl = \u0001\u001D\u000F.\u000C(P);
			if (itemsControl != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.QB(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				if (\u001C\u001B\u0018.\u0018(\u0012\u000D\u0014.\u0018(ref Q), true))
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
					\u000C\u001B\u0018.\u0018(itemsControl, new MouseButtonEventHandler(\u0018\u000D\u0014.\u0018().S));
					\u000F\u000D\u0014.\u0018(itemsControl, new MouseButtonEventHandler(\u0018\u000D\u0014.\u0018().L));
					\u0016\u000D\u0014.\u0018(itemsControl, new MouseEventHandler(\u0018\u000D\u0014.\u0018().U));
					return;
				}
				\u0003\u000D\u0014.\u0018(itemsControl, new MouseButtonEventHandler(\u0018\u000D\u0014.\u0018().S));
				\u0014\u000D\u0014.\u0018(itemsControl, new MouseButtonEventHandler(\u0018\u000D\u0014.\u0018().L));
				\u000C\u000D\u0014.\u0018(itemsControl, new MouseEventHandler(\u0018\u000D\u0014.\u0018().U));
			}
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000EDE0 File Offset: 0x0000CFE0
		private static void JB(DependencyObject P, DependencyPropertyChangedEventArgs Q)
		{
			ItemsControl itemsControl = \u0001\u001D\u000F.\u000C(P);
			if (itemsControl != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.JB(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				if (\u001C\u001B\u0018.\u0018(\u0012\u000D\u0014.\u0018(ref Q), true))
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
					\u0009\u0012\u0014.\u0018(itemsControl, true);
					\u0011\u000D\u0014.\u0018(itemsControl, new DragEventHandler(\u0018\u000D\u0014.\u0018().V));
					\u001F\u000D\u0014.\u0018(itemsControl, new DragEventHandler(\u0018\u000D\u0014.\u0018().E));
					\u0020\u000D\u0014.\u0018(itemsControl, new DragEventHandler(\u0018\u000D\u0014.\u0018().A));
					\u000A\u000D\u0014.\u0018(itemsControl, new DragEventHandler(\u0018\u000D\u0014.\u0018().D));
					return;
				}
				\u0009\u0012\u0014.\u0018(itemsControl, false);
				\u0009\u000D\u0014.\u0018(itemsControl, new DragEventHandler(\u0018\u000D\u0014.\u0018().V));
				\u0013\u000D\u0014.\u0018(itemsControl, new DragEventHandler(\u0018\u000D\u0014.\u0018().E));
				\u001C\u000D\u0014.\u0018(itemsControl, new DragEventHandler(\u0018\u000D\u0014.\u0018().A));
				\u000D\u000D\u0014.\u0018(itemsControl, new DragEventHandler(\u0018\u000D\u0014.\u0018().D));
			}
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000EF00 File Offset: 0x0000D100
		private void FB(DragEventArgs P)
		{
			int num = \u0002\u000D\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.Y));
			object p = \u001A\u0012\u0014.\u0018(\u000B\u0012\u0014.\u0018(P), \u001E\u0012\u0014.\u0018(this.P));
			if (this.RB(p))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.FB(DragEventArgs)).MethodHandle;
				}
				if (num <= 0)
				{
					this.O = \u0008\u001D\u000F.\u000C;
					this.W = 0;
					return;
				}
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				this.C = DragDropBehaviour.YB(\u0010\u001D\u000F.\u000C(\u0015\u000D\u0014.\u0018(\u0017\u000D\u0014.\u0018(this.Y), 0)));
				this.O = \u0010\u001D\u000F.\u000C(\u0016\u0012\u0014.\u0018(this.Y, \u0006\u001D\u000F.\u000C(\u000F\u0012\u0014.\u0018(P))));
				if (this.O == null)
				{
					this.O = \u0010\u001D\u000F.\u000C(\u0015\u000D\u0014.\u0018(\u0017\u000D\u0014.\u0018(this.Y), num - 1));
					this.T = false;
					this.W = num;
					return;
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
				Point q = \u001D\u0012\u0014.\u0018(P, this.O);
				this.T = DragDropBehaviour.TB(this.O, q, this.C);
				this.W = \u001E\u000D\u0014.\u0018(\u0017\u000D\u0014.\u0018(this.Y), this.O);
				if (!this.T)
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
					this.W++;
					return;
				}
			}
			else
			{
				this.O = \u0008\u001D\u000F.\u000C;
				this.W = -1;
				\u0005\u0012\u0014.\u0018(P, DragDropEffects.None);
			}
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000F0A0 File Offset: 0x0000D2A0
		private bool RB(object P)
		{
			IEnumerable enumerable = \u0008\u0012\u0014.\u0018(this.Y);
			bool result;
			if (P != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.RB(object)).MethodHandle;
				}
				if (enumerable != null)
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
					Type u = \u0004\u0017\u0018.\u0014(P);
					Type type = \u0004\u0017\u0018.\u0014(enumerable);
					Type u000C = \u0006\u0012\u0014.\u0018(type, "IList`1");
					if (\u0010\u0012\u0014.\u0018(u000C, \u0017\u001D\u000F.\u000C))
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
						result = \u0004\u000D\u0014.\u0018(\u001D\u000D\u0014.\u0018(u000C)[0], u);
					}
					else if (\u001A\u000F\u0014.\u0018(type, \u000A\u001D\u0018.\u0018(\u0019\u001D\u000F.\u000C())))
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
						ICollectionView u000C2 = \u0015\u001D\u000F.\u000C(enumerable);
						if (\u0004\u000D\u0014.\u0018(\u000A\u001D\u0018.\u0018(\u0013\u001D\u000F.\u000C()), \u0004\u0017\u0018.\u0014(\u000F\u000C\u0014.\u0018(u000C2))))
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
							result = true;
						}
						else
						{
							type = \u0004\u0017\u0018.\u0014(\u000F\u000C\u0014.\u0018(u000C2));
							u000C = \u0006\u0012\u0014.\u0018(type, "IList`1");
							result = \u0004\u000D\u0014.\u0018(\u001D\u000D\u0014.\u0018(u000C)[0], u);
						}
					}
					else if (\u0004\u000D\u0014.\u0018(\u000A\u001D\u0018.\u0018(\u0013\u001D\u000F.\u000C()), type))
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
						result = true;
					}
					else if (\u0004\u000D\u0014.\u0018(\u000A\u001D\u0018.\u0018(\u0007\u001D\u000F.\u000C()), type))
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
						result = true;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					result = true;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000F22C File Offset: 0x0000D42C
		private void HB(Point P)
		{
			if (this.H == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.HB(Point)).MethodHandle;
				}
				AdornerLayer u = \u0001\u000D\u0014.\u0018(this.M);
				this.H = \u0006\u000D\u0014.\u0018(this.F, \u0008\u000D\u0014.\u0018(this.M), this.X, u);
			}
			double u2 = \u0010\u000D\u0014.\u0018(ref P) - \u0010\u000D\u0014.\u0018(ref this.Q) + \u0007\u000D\u0014.\u0018(ref this.J);
			double u3 = \u0019\u000D\u0014.\u0018(ref P) - \u0019\u000D\u0014.\u0018(ref this.Q) + \u000B\u000D\u0014.\u0018(ref this.J);
			\u001A\u000D\u0014.\u0018(this.H, u2, u3);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000F2E4 File Offset: 0x0000D4E4
		private void NB()
		{
			if (this.H != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.NB()).MethodHandle;
				}
				\u001B\u000D\u0014.\u0018(this.H);
				this.H = \u000B\u001D\u000F.\u000C;
			}
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000F324 File Offset: 0x0000D524
		private void ZB()
		{
			if (this.O != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.ZB()).MethodHandle;
				}
				AdornerLayer u = \u0001\u000D\u0014.\u0018(this.O);
				this.N = \u0005\u000D\u0014.\u0018(this.C, this.T, this.O, u);
			}
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000F37C File Offset: 0x0000D57C
		private void MB()
		{
			if (this.N != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.MB()).MethodHandle;
				}
				\u000C\u001C\u0014.\u0014(this.N, this.T);
				\u000E\u000D\u0014.\u0018(this.N);
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000F3C0 File Offset: 0x0000D5C0
		private void XB()
		{
			if (this.N != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.XB()).MethodHandle;
				}
				\u0018\u001C\u0014.\u0018(this.N);
				this.N = \u001A\u001D\u000F.\u000C;
			}
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000F400 File Offset: 0x0000D600
		private static bool YB(FrameworkElement P)
		{
			bool result = true;
			if (P != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.YB(FrameworkElement)).MethodHandle;
				}
				Panel u000C = \u0002\u001D\u000F.\u000C(\u0016\u001C\u0014.\u0018(P));
				StackPanel stackPanel = \u0004\u001D\u000F.\u000C(u000C);
				if (stackPanel != null)
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
					result = (\u0003\u001C\u0014.\u0018(stackPanel) == Orientation.Vertical);
				}
				else
				{
					WrapPanel wrapPanel = \u001D\u001D\u000F.\u000C(u000C);
					if (wrapPanel != null)
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
						result = (\u0014\u001C\u0014.\u0018(wrapPanel) == Orientation.Vertical);
					}
				}
			}
			return result;
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000F47C File Offset: 0x0000D67C
		private static void OB(ItemsControl P, object Q, int J)
		{
			if (Q != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.OB(ItemsControl, object, int)).MethodHandle;
				}
				IEnumerable enumerable = \u0008\u0012\u0014.\u0018(P);
				if (enumerable == null)
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
					\u001C\u001C\u0014.\u0018(\u000D\u000F\u0014.\u0018(P), J, Q);
					return;
				}
				IList list = \u001E\u001D\u000F.\u000C(enumerable);
				if (list != null)
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
					\u000D\u001C\u0014.\u0018(list, J, Q);
					return;
				}
				ICollectionView collectionView = \u0015\u001D\u000F.\u000C(enumerable);
				if (collectionView != null)
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
					IList list2 = \u001E\u001D\u000F.\u000C(\u000F\u000C\u0014.\u0018(collectionView));
					if (list2 != null)
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
						\u000D\u001C\u0014.\u0018(list2, J, Q);
						return;
					}
					Type u000C = \u0004\u0017\u0018.\u0014(\u000F\u000C\u0014.\u0018(collectionView));
					if (\u0010\u0012\u0014.\u0018(\u0006\u0012\u0014.\u0018(u000C, "IList`1"), \u0017\u001D\u000F.\u000C))
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
						object u000C2 = \u0012\u001C\u0014.\u0018(u000C, "Insert");
						object u = \u000F\u000C\u0014.\u0018(collectionView);
						object[] array = \u0008\u001E\u000F.\u000C(2);
						array[0] = J;
						array[1] = Q;
						\u000F\u001C\u0014.\u0014(u000C2, u, array);
						return;
					}
				}
				else
				{
					Type u000C3 = \u0004\u0017\u0018.\u0014(enumerable);
					if (\u0010\u0012\u0014.\u0018(\u0006\u0012\u0014.\u0018(u000C3, "IList`1"), \u0017\u001D\u000F.\u000C))
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
						object u000C4 = \u0012\u001C\u0014.\u0018(u000C3, "Insert");
						object u2 = enumerable;
						object[] array2 = \u0008\u001E\u000F.\u000C(2);
						array2[0] = J;
						array2[1] = Q;
						\u000F\u001C\u0014.\u0014(u000C4, u2, array2);
					}
				}
			}
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000F5F0 File Offset: 0x0000D7F0
		private static int CB(ItemsControl P, object Q)
		{
			int num = -1;
			if (Q != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.CB(ItemsControl, object)).MethodHandle;
				}
				num = \u0020\u001C\u0014.\u0018(\u000D\u000F\u0014.\u0018(P), Q);
				if (num != -1)
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
					IEnumerable enumerable = \u0008\u0012\u0014.\u0018(P);
					if (enumerable == null)
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
						if (num >= 0)
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
							if (num < \u0002\u000D\u0014.\u0018(\u000D\u000F\u0014.\u0018(P)))
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
								\u000A\u001C\u0014.\u0018(\u000D\u000F\u0014.\u0018(P), Q);
							}
						}
					}
					else
					{
						IList list = \u001E\u001D\u000F.\u000C(enumerable);
						if (list != null)
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
							if (num >= 0)
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
								if (num < \u0009\u001C\u0014.\u0018(list))
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
									\u0013\u001C\u0014.\u0018(list, Q);
								}
							}
						}
						else
						{
							ICollectionView collectionView = \u0015\u001D\u000F.\u000C(enumerable);
							if (collectionView != null)
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
								IList list2 = \u001E\u001D\u000F.\u000C(\u000F\u000C\u0014.\u0018(collectionView));
								if (list2 != null)
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
									if (num >= 0)
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
										if (num < \u0009\u001C\u0014.\u0018(list2))
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
											\u0013\u001C\u0014.\u0018(list2, Q);
										}
									}
								}
								else
								{
									Type u000C = \u0004\u0017\u0018.\u0014(\u000F\u000C\u0014.\u0018(collectionView));
									if (\u0010\u0012\u0014.\u0018(\u0006\u0012\u0014.\u0018(u000C, "IList`1"), \u0017\u001D\u000F.\u000C))
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
										MethodInfo methodInfo = \u0012\u001C\u0014.\u0018(u000C, "Remove");
										if (methodInfo == null)
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
										}
										else
										{
											object u = \u000F\u000C\u0014.\u0018(collectionView);
											object[] array = \u0008\u001E\u000F.\u000C(1);
											array[0] = Q;
											\u000F\u001C\u0014.\u0003(methodInfo, u, array);
										}
									}
								}
							}
							else
							{
								Type u000C2 = \u0004\u0017\u0018.\u0014(enumerable);
								if (\u0010\u0012\u0014.\u0018(\u0006\u0012\u0014.\u0018(u000C2, "IList`1"), \u0017\u001D\u000F.\u000C))
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
									MethodInfo methodInfo2 = \u0012\u001C\u0014.\u0018(u000C2, "Remove");
									if (methodInfo2 == null)
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
									}
									else
									{
										object u2 = enumerable;
										object[] array2 = \u0008\u001E\u000F.\u000C(1);
										array2[0] = Q;
										\u000F\u001C\u0014.\u0003(methodInfo2, u2, array2);
									}
								}
							}
						}
					}
				}
			}
			return num;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000F82C File Offset: 0x0000DA2C
		private static void WB(ItemsControl P, int Q)
		{
			IEnumerable enumerable = \u0008\u0012\u0014.\u0018(P);
			ICollectionView collectionView = \u0015\u001D\u000F.\u000C(enumerable);
			if (collectionView != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.WB(ItemsControl, int)).MethodHandle;
				}
				Type u000C = \u0004\u0017\u0018.\u0014(\u000F\u000C\u0014.\u0018(collectionView));
				if (\u0010\u0012\u0014.\u0018(\u0006\u0012\u0014.\u0018(u000C, "IList`1"), \u0017\u001D\u000F.\u000C))
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
					object u000C2 = \u0012\u001C\u0014.\u0018(u000C, "RemoveAt");
					object u = \u000F\u000C\u0014.\u0018(collectionView);
					object[] array = \u0008\u001E\u000F.\u000C(1);
					array[0] = Q;
					\u000F\u001C\u0014.\u0014(u000C2, u, array);
					return;
				}
			}
			else
			{
				Type u000C3 = \u0004\u0017\u0018.\u0014(enumerable);
				if (\u0010\u0012\u0014.\u0018(\u0006\u0012\u0014.\u0018(u000C3, "IList`1"), \u0017\u001D\u000F.\u000C))
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
					object u000C4 = \u0012\u001C\u0014.\u0018(u000C3, "RemoveAt");
					object u2 = enumerable;
					object[] array2 = \u0008\u001E\u000F.\u000C(1);
					array2[0] = Q;
					\u000F\u001C\u0014.\u0014(u000C4, u2, array2);
				}
			}
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000F920 File Offset: 0x0000DB20
		private static bool TB(FrameworkElement P, Point Q, bool J)
		{
			if (J)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.TB(FrameworkElement, Point, bool)).MethodHandle;
				}
				return \u0019\u000D\u0014.\u0018(ref Q) < \u0011\u001C\u0014.\u0018(P) / 2.0;
			}
			return \u0010\u000D\u0014.\u0018(ref Q) < \u001F\u001C\u0014.\u0018(P) / 2.0;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000F980 File Offset: 0x0000DB80
		private static bool IB(Point P, Point Q)
		{
			if (\u0017\u001C\u0014.\u0018(\u0010\u000D\u0014.\u0018(ref Q) - \u0010\u000D\u0014.\u0018(ref P)) < \u001E\u001C\u0014.\u0018())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DragDropBehaviour.IB(Point, Point)).MethodHandle;
				}
				return \u0017\u001C\u0014.\u0018(\u0019\u000D\u0014.\u0018(ref Q) - \u0019\u000D\u0014.\u0018(ref P)) >= \u0015\u001C\u0014.\u0018();
			}
			return true;
		}

		// Token: 0x04000117 RID: 279
		private readonly DataFormat P = \u0005\u000F\u0014.\u0018("DragDropItemsControl");

		// Token: 0x04000118 RID: 280
		private Point Q;

		// Token: 0x04000119 RID: 281
		private Vector J;

		// Token: 0x0400011A RID: 282
		private object F;

		// Token: 0x0400011B RID: 283
		private DraggedAdorner H;

		// Token: 0x0400011C RID: 284
		private InsertionAdorner N;

		// Token: 0x0400011D RID: 285
		private Window Z;

		// Token: 0x0400011E RID: 286
		private ItemsControl M;

		// Token: 0x0400011F RID: 287
		private FrameworkElement X;

		// Token: 0x04000120 RID: 288
		private ItemsControl Y;

		// Token: 0x04000121 RID: 289
		private FrameworkElement O;

		// Token: 0x04000122 RID: 290
		private bool C;

		// Token: 0x04000123 RID: 291
		private int W;

		// Token: 0x04000124 RID: 292
		private bool T;

		// Token: 0x04000125 RID: 293
		private static DragDropBehaviour _instance;

		// Token: 0x04000126 RID: 294
		public static readonly DependencyProperty IsDropRejectFromOthersProperty = \u000E\u000F\u0014.\u0018("IsDropRejectFromOthers", \u000A\u001D\u0018.\u0018(\u000B\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0018\u001A\u000F.\u000C()), \u001F\u0006\u0018.\u0018(\u001D\u0004\u000F.\u000C));

		// Token: 0x04000127 RID: 295
		public static readonly DependencyProperty IsDropRejectFromSelfProperty = \u000E\u000F\u0014.\u0018("IsDropRejectFromSelf", \u000A\u001D\u0018.\u0018(\u000B\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0018\u001A\u000F.\u000C()), \u001F\u0006\u0018.\u0018(\u001D\u0004\u000F.\u000C));

		// Token: 0x04000128 RID: 296
		public static readonly DependencyProperty IsDragSourceProperty = \u000E\u000F\u0014.\u0018("IsDragSource", \u000A\u001D\u0018.\u0018(\u000B\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0018\u001A\u000F.\u000C()), \u000C\u0012\u0014.\u0018(false, new PropertyChangedCallback(DragDropBehaviour.QB)));

		// Token: 0x04000129 RID: 297
		public static readonly DependencyProperty IsDropTargetProperty = \u000E\u000F\u0014.\u0018("IsDropTarget", \u000A\u001D\u0018.\u0018(\u000B\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0018\u001A\u000F.\u000C()), \u000C\u0012\u0014.\u0018(false, new PropertyChangedCallback(DragDropBehaviour.JB)));

		// Token: 0x0400012A RID: 298
		public static readonly DependencyProperty DragDropTemplateProperty = \u000E\u000F\u0014.\u0018("DragDropTemplate", \u000A\u001D\u0018.\u0018(\u0014\u001A\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0018\u001A\u000F.\u000C()), \u001F\u0006\u0018.\u0018(\u001D\u0004\u000F.\u000C));
	}
}

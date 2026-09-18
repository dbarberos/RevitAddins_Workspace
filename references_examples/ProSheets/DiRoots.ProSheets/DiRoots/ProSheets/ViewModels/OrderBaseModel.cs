using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;

namespace DiRoots.ProSheets.ViewModels
{
	// Token: 0x02000030 RID: 48
	public class OrderBaseModel<T> : ViewModelBase
	{
		// Token: 0x060001E5 RID: 485 RVA: 0x0000AE94 File Offset: 0x00009094
		public OrderBaseModel(List<T> availableItems)
		{
			this.\u0003\u0014 = new ObservableCollection<T>(availableItems);
			this.\u000F\u0018 = new ObservableCollection<T>(availableItems);
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x0000AEC0 File Offset: 0x000090C0
		// (set) Token: 0x060001E7 RID: 487 RVA: 0x0000AED4 File Offset: 0x000090D4
		public ObservableCollection<T> TempItems
		{
			get
			{
				return this.\u0003\u0014;
			}
			set
			{
				this.\u0003\u0014 = value;
				\u0011\u0010\u0018.\u0018(this, "TempItems");
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x0000AEF4 File Offset: 0x000090F4
		// (set) Token: 0x060001E9 RID: 489 RVA: 0x0000AF08 File Offset: 0x00009108
		public ObservableCollection<T> Items
		{
			get
			{
				return this.\u000F\u0018;
			}
			set
			{
				this.\u000F\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "Items");
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001EA RID: 490 RVA: 0x0000AF28 File Offset: 0x00009128
		// (set) Token: 0x060001EB RID: 491 RVA: 0x0000AF3C File Offset: 0x0000913C
		public IList<T> SelectedItems
		{
			get
			{
				return this.\u0011;
			}
			set
			{
				this.\u0011 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectedItems");
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001EC RID: 492 RVA: 0x0000AF5C File Offset: 0x0000915C
		public CommandBase MoveToBeginningCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u000D\u001C), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001ED RID: 493 RVA: 0x0000AF84 File Offset: 0x00009184
		public CommandBase MoveUpCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u001C\u001C), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001EE RID: 494 RVA: 0x0000AFAC File Offset: 0x000091AC
		public CommandBase MoveDownCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u0013\u001C), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001EF RID: 495 RVA: 0x0000AFD4 File Offset: 0x000091D4
		public CommandBase MoveToEndCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u0007\u000D), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x0000AFFC File Offset: 0x000091FC
		public CommandBase ReloadCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u0012\u001C), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x0000B024 File Offset: 0x00009224
		public CommandBase OnApplyCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.ApplyCommand), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0000B04C File Offset: 0x0000924C
		private void \u0012\u001C()
		{
			this.\u0008\u000D(this.Items);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000B068 File Offset: 0x00009268
		private void \u0008\u000D(ObservableCollection<T> \u000C)
		{
			this.TempItems = null;
			this.TempItems = new ObservableCollection<T>(\u000C);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0000B088 File Offset: 0x00009288
		private void \u000D\u001C()
		{
			if (this.SelectedItems == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(OrderBaseModel.\u000D\u001C()).MethodHandle;
				}
				return;
			}
			ObservableCollection<T> observableCollection = this.\u0009\u001C();
			List<T> list = Enumerable.ToList<T>(Enumerable.OrderBy<T, int>(this.SelectedItems, new Func<T, int>(observableCollection.IndexOf)));
			int num = 0;
			using (List<T>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T item = enumerator.Current;
					observableCollection.Move(observableCollection.IndexOf(item), num++);
				}
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			this.\u0008\u000D(observableCollection);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0000B148 File Offset: 0x00009348
		private void \u001C\u001C()
		{
			if (this.SelectedItems == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(OrderBaseModel.\u001C\u001C()).MethodHandle;
				}
				return;
			}
			ObservableCollection<T> observableCollection = this.\u0009\u001C();
			using (List<T>.Enumerator enumerator = Enumerable.ToList<T>(Enumerable.OrderBy<T, int>(this.SelectedItems, new Func<T, int>(observableCollection.IndexOf))).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T item = enumerator.Current;
					int num = observableCollection.IndexOf(item);
					int num2 = num - 1;
					if (num2 < 0)
					{
						goto IL_AA;
					}
					for (;;)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					observableCollection.Move(num, num2);
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
			}
			IL_AA:
			this.\u0008\u000D(observableCollection);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0000B218 File Offset: 0x00009418
		private void \u0013\u001C()
		{
			if (this.SelectedItems == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(OrderBaseModel.\u0013\u001C()).MethodHandle;
				}
				return;
			}
			ObservableCollection<T> observableCollection = this.\u0009\u001C();
			using (List<T>.Enumerator enumerator = Enumerable.ToList<T>(Enumerable.OrderByDescending<T, int>(this.SelectedItems, new Func<T, int>(observableCollection.IndexOf))).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T item = enumerator.Current;
					int num = observableCollection.IndexOf(item);
					int num2 = num + 1;
					if (num2 >= observableCollection.Count)
					{
						goto IL_B1;
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
					observableCollection.Move(num, num2);
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
			}
			IL_B1:
			this.\u0008\u000D(observableCollection);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000B2F0 File Offset: 0x000094F0
		private void \u0007\u000D()
		{
			if (this.SelectedItems == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(OrderBaseModel.\u0007\u000D()).MethodHandle;
				}
				return;
			}
			ObservableCollection<T> observableCollection = this.\u0009\u001C();
			List<T> list = Enumerable.ToList<T>(Enumerable.OrderByDescending<T, int>(this.SelectedItems, new Func<T, int>(observableCollection.IndexOf)));
			int num = observableCollection.Count - 1;
			using (List<T>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T item = enumerator.Current;
					observableCollection.Move(observableCollection.IndexOf(item), num--);
				}
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			this.\u0008\u000D(observableCollection);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000B3B8 File Offset: 0x000095B8
		private ObservableCollection<T> \u0009\u001C()
		{
			return new ObservableCollection<T>(Enumerable.Cast<T>(\u0016\u001D\u000F.\u000C(\u0010\u0006\u0018.\u0018(this.TempItems))));
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000B3E8 File Offset: 0x000095E8
		public void ApplyCommand()
		{
			this.Items = this.\u0009\u001C();
			\u0007\u000B\u0018.\u0003(\u0001\u000C\u0014.\u0018(this), new bool?(true));
			\u000B\u000B\u0018.\u0014(\u0001\u000C\u0014.\u0018(this));
		}

		// Token: 0x040000F1 RID: 241
		private ObservableCollection<T> \u0003\u0014;

		// Token: 0x040000F2 RID: 242
		private ObservableCollection<T> \u000F\u0018;

		// Token: 0x040000F3 RID: 243
		private IList<T> \u0011;
	}
}

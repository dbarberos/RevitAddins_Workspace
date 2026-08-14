using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using A;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.ViewAligner.Wpf.ViewModels
{
	// Token: 0x020000BF RID: 191
	public class ComboBoxViewModel<T> : ViewModelBase where T : IComboxItemModel
	{
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000752 RID: 1874 RVA: 0x0002AA38 File Offset: 0x00028C38
		// (remove) Token: 0x06000753 RID: 1875 RVA: 0x0002AA84 File Offset: 0x00028C84
		internal event ComboBoxViewModel<T>.\u0009\u0004 HC
		{
			[CompilerGenerated]
			add
			{
				ComboBoxViewModel<T>.\u0009\u0004 u0009_u = this.HC;
				ComboBoxViewModel<T>.\u0009\u0004 u0009_u2;
				do
				{
					u0009_u2 = u0009_u;
					ComboBoxViewModel<T>.\u0009\u0004 value2 = (ComboBoxViewModel<T>.\u0009\u0004)\u000F\u001E\u000A.\u000A(u0009_u2, value);
					u0009_u = Interlocked.CompareExchange<ComboBoxViewModel<T>.\u0009\u0004>(ref this.HC, value2, u0009_u2);
				}
				while (u0009_u != u0009_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.add_HC(ComboBoxViewModel<T>.\u0009\u0004)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ComboBoxViewModel<T>.\u0009\u0004 u0009_u = this.HC;
				ComboBoxViewModel<T>.\u0009\u0004 u0009_u2;
				do
				{
					u0009_u2 = u0009_u;
					ComboBoxViewModel<T>.\u0009\u0004 value2 = (ComboBoxViewModel<T>.\u0009\u0004)\u0012\u001E\u000A.\u000A(u0009_u2, value);
					u0009_u = Interlocked.CompareExchange<ComboBoxViewModel<T>.\u0009\u0004>(ref this.HC, value2, u0009_u2);
				}
				while (u0009_u != u0009_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.remove_HC(ComboBoxViewModel<T>.\u0009\u0004)).MethodHandle;
				}
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000754 RID: 1876 RVA: 0x0002AAD0 File Offset: 0x00028CD0
		// (remove) Token: 0x06000755 RID: 1877 RVA: 0x0002AB1C File Offset: 0x00028D1C
		internal event ComboBoxViewModel<T>.\u001F\u0019 YC
		{
			[CompilerGenerated]
			add
			{
				ComboBoxViewModel<T>.\u001F\u0019 u001F_u = this.YC;
				ComboBoxViewModel<T>.\u001F\u0019 u001F_u2;
				do
				{
					u001F_u2 = u001F_u;
					ComboBoxViewModel<T>.\u001F\u0019 value2 = (ComboBoxViewModel<T>.\u001F\u0019)\u000F\u001E\u000A.\u000A(u001F_u2, value);
					u001F_u = Interlocked.CompareExchange<ComboBoxViewModel<T>.\u001F\u0019>(ref this.YC, value2, u001F_u2);
				}
				while (u001F_u != u001F_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.add_YC(ComboBoxViewModel<T>.\u001F\u0019)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ComboBoxViewModel<T>.\u001F\u0019 u001F_u = this.YC;
				ComboBoxViewModel<T>.\u001F\u0019 u001F_u2;
				do
				{
					u001F_u2 = u001F_u;
					ComboBoxViewModel<T>.\u001F\u0019 value2 = (ComboBoxViewModel<T>.\u001F\u0019)\u0012\u001E\u000A.\u000A(u001F_u2, value);
					u001F_u = Interlocked.CompareExchange<ComboBoxViewModel<T>.\u001F\u0019>(ref this.YC, value2, u001F_u2);
				}
				while (u001F_u != u001F_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.remove_YC(ComboBoxViewModel<T>.\u001F\u0019)).MethodHandle;
				}
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000756 RID: 1878 RVA: 0x0002AB68 File Offset: 0x00028D68
		// (set) Token: 0x06000757 RID: 1879 RVA: 0x0002AB7C File Offset: 0x00028D7C
		public IList<T> Items
		{
			get
			{
				return this.LC;
			}
			set
			{
				base.SetProperty<IList<T>>(ref this.LC, value, null, "Items");
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000758 RID: 1880 RVA: 0x0002ABA0 File Offset: 0x00028DA0
		public IList<T> CheckedItems
		{
			get
			{
				return this.SC;
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x0002ABB4 File Offset: 0x00028DB4
		// (set) Token: 0x0600075A RID: 1882 RVA: 0x0002ABC8 File Offset: 0x00028DC8
		public int SelectedIndex
		{
			get
			{
				return this.CC;
			}
			set
			{
				base.SetProperty<int>(ref this.CC, value, null, "SelectedIndex");
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x0002ABEC File Offset: 0x00028DEC
		// (set) Token: 0x0600075C RID: 1884 RVA: 0x0002AC00 File Offset: 0x00028E00
		public bool? IsAllChecked { get; private set; } = new bool?(false);

		// Token: 0x0600075D RID: 1885 RVA: 0x0002AC14 File Offset: 0x00028E14
		[BindableMethod("OnSelectedIndexChanged")]
		public void OnSelectedIndexChanged()
		{
			this.SelectedIndex = 0;
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x0002AC28 File Offset: 0x00028E28
		[BindableMethod("OnCheckboxClick")]
		public void OnCheckboxClick(object sender)
		{
			ComboBoxViewModel<T>.\u000A\u0019 u000A_u = new ComboBoxViewModel<T>.\u000A\u0019();
			if (this.Items.Count < 2)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.OnCheckboxClick(object)).MethodHandle;
				}
				return;
			}
			u000A_u.\u001F = this.Items[1];
			if (u000A_u.\u001F == sender)
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
				Enumerable.ToList<T>(Enumerable.Skip<T>(this.Items, 2)).ForEach(new Action<T>(u000A_u.\u000A));
			}
			this.HKR();
			ComboBoxViewModel<T>.\u0009\u0004 hc = this.HC;
			if (hc == null)
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
				return;
			}
			hc(sender);
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0002ACD8 File Offset: 0x00028ED8
		[BindableMethod("DropDownClosed")]
		public void DropDownClosed()
		{
			ComboBoxViewModel<T>.\u001F\u0019 yc = this.YC;
			if (yc == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.DropDownClosed()).MethodHandle;
				}
				return;
			}
			yc();
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x0002AD08 File Offset: 0x00028F08
		public IList<T> GetCheckedItems()
		{
			return this.SC;
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0002AD1C File Offset: 0x00028F1C
		private void HKR()
		{
			T t = this.Items[1];
			List<T> list = Enumerable.ToList<T>(Enumerable.Skip<T>(this.Items, 2));
			IEnumerable<T> enumerable = list;
			Func<T, bool> func;
			if ((func = ComboBoxViewModel<T>.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.HKR()).MethodHandle;
				}
				func = (ComboBoxViewModel<T>.<>c.\u000A = new Func<T, bool>(ComboBoxViewModel<T>.<>c.\u001F.\u0004));
			}
			if (Enumerable.Any<T>(enumerable, func))
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
				ref T ptr = ref t;
				T t2 = default(T);
				if (t2 == null)
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
					t2 = t;
					ptr = ref t2;
				}
				IEnumerable<T> enumerable2 = list;
				Func<T, bool> func2;
				if ((func2 = ComboBoxViewModel<T>.<>c.\u0007) == null)
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
					func2 = (ComboBoxViewModel<T>.<>c.\u0007 = new Func<T, bool>(ComboBoxViewModel<T>.<>c.\u001F.\u0019));
				}
				bool? isChecked2;
				if (!Enumerable.All<T>(enumerable2, func2))
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
					bool? isChecked;
					\u001B\u000A\u000E.\u001F(ref isChecked);
					isChecked2 = isChecked;
				}
				else
				{
					isChecked2 = new bool?(true);
				}
				ptr.IsChecked = isChecked2;
			}
			else
			{
				ref T ptr2 = ref t;
				T t2 = default(T);
				if (t2 == null)
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
					t2 = t;
					ptr2 = ref t2;
				}
				ptr2.IsChecked = new bool?(false);
			}
			T t3 = this.Items[0];
			IEnumerable<T> enumerable3 = list;
			Func<T, bool> func3;
			if ((func3 = ComboBoxViewModel<T>.<>c.\u001D) == null)
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
				func3 = (ComboBoxViewModel<T>.<>c.\u001D = new Func<T, bool>(ComboBoxViewModel<T>.<>c.\u001F.\u0018));
			}
			this.SC = Enumerable.ToList<T>(Enumerable.Where<T>(enumerable3, func3));
			int count = this.SC.Count;
			if (count != 0)
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
				if (count != 1)
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
					ref T ptr3 = ref t3;
					T t2 = default(T);
					if (t2 == null)
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
						t2 = t3;
						ptr3 = ref t2;
					}
					bool? isChecked = t.IsChecked;
					string name;
					if (!\u0012\u0015\u000A.\u000A(ref isChecked))
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
						name = \u0011\u0012\u001D.\u000A();
					}
					else
					{
						name = \u001B\u0012\u001D.\u000A();
					}
					ptr3.Name = name;
					ref T ptr4 = ref t3;
					t2 = default(T);
					if (t2 == null)
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
						t2 = t3;
						ptr4 = ref t2;
					}
					ptr4.IsChecked = t.IsChecked;
				}
				else
				{
					ref T ptr5 = ref t3;
					T t2 = default(T);
					if (t2 == null)
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
						t2 = t3;
						ptr5 = ref t2;
					}
					T t4 = this.SC[0];
					ptr5.Name = t4.Name;
					ref T ptr6 = ref t3;
					t2 = default(T);
					if (t2 == null)
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
						t2 = t3;
						ptr6 = ref t2;
					}
					ptr6.IsChecked = new bool?(true);
				}
			}
			else
			{
				ref T ptr7 = ref t3;
				T t2 = default(T);
				if (t2 == null)
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
					t2 = t3;
					ptr7 = ref t2;
				}
				ptr7.Name = \u001E\u0012\u001D.\u000A();
				ref T ptr8 = ref t3;
				t2 = default(T);
				if (t2 == null)
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
					t2 = t3;
					ptr8 = ref t2;
				}
				ptr8.IsChecked = new bool?(false);
			}
			this.IsAllChecked = t.IsChecked;
		}

		// Token: 0x040002F1 RID: 753
		private int CC;

		// Token: 0x040002F2 RID: 754
		private IList<T> LC = new List<T>();

		// Token: 0x040002F3 RID: 755
		private IList<T> SC = new List<T>();

		// Token: 0x040002F4 RID: 756
		[CompilerGenerated]
		private bool? BC;

		// Token: 0x020007D3 RID: 2003
		// (Invoke) Token: 0x06004CBE RID: 19646
		internal delegate void \u0009\u0004(object sender);

		// Token: 0x020007D4 RID: 2004
		// (Invoke) Token: 0x06004CC2 RID: 19650
		internal delegate void \u001F\u0019();

		// Token: 0x020007D6 RID: 2006
		[CompilerGenerated]
		private sealed class \u000A\u0019
		{
			// Token: 0x06004CCB RID: 19659 RVA: 0x001DCE54 File Offset: 0x001DB054
			internal void \u000A(\u0007 \u001F)
			{
				ref \u0007 ptr = ref \u001F;
				if (default(\u0007) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.\u000A\u0019.\u000A(\u0007)).MethodHandle;
					}
					\u0007 u = \u001F;
					ptr = ref u;
				}
				ptr.IsChecked = this.\u001F.IsChecked;
			}

			// Token: 0x04001FC3 RID: 8131
			public \u0007 \u001F;
		}
	}
}

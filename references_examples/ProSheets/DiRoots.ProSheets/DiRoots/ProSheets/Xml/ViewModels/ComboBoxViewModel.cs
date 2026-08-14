using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using A;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.ViewModels;
using ProSheets.Extensions;

namespace DiRoots.ProSheets.Xml.ViewModels
{
	// Token: 0x02000020 RID: 32
	public class ComboBoxViewModel : ViewModelBase
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000114 RID: 276 RVA: 0x000074C0 File Offset: 0x000056C0
		// (remove) Token: 0x06000115 RID: 277 RVA: 0x0000750C File Offset: 0x0000570C
		internal event ComboBoxViewModel.\u0005\u0013\u0018 \u0014\u0018
		{
			[CompilerGenerated]
			add
			{
				ComboBoxViewModel.\u0005\u0013\u0018 u0005_u0013_u = this.\u0014\u0018;
				ComboBoxViewModel.\u0005\u0013\u0018 u0005_u0013_u2;
				do
				{
					u0005_u0013_u2 = u0005_u0013_u;
					ComboBoxViewModel.\u0005\u0013\u0018 value2 = (ComboBoxViewModel.\u0005\u0013\u0018)\u001C\u0019\u0018.\u0018(u0005_u0013_u2, value);
					u0005_u0013_u = Interlocked.CompareExchange<ComboBoxViewModel.\u0005\u0013\u0018>(ref this.\u0014\u0018, value2, u0005_u0013_u2);
				}
				while (u0005_u0013_u != u0005_u0013_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.add_\u0014\u0018(ComboBoxViewModel.\u0005\u0013\u0018)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ComboBoxViewModel.\u0005\u0013\u0018 u0005_u0013_u = this.\u0014\u0018;
				ComboBoxViewModel.\u0005\u0013\u0018 u0005_u0013_u2;
				do
				{
					u0005_u0013_u2 = u0005_u0013_u;
					ComboBoxViewModel.\u0005\u0013\u0018 value2 = (ComboBoxViewModel.\u0005\u0013\u0018)\u0013\u0019\u0018.\u0018(u0005_u0013_u2, value);
					u0005_u0013_u = Interlocked.CompareExchange<ComboBoxViewModel.\u0005\u0013\u0018>(ref this.\u0014\u0018, value2, u0005_u0013_u2);
				}
				while (u0005_u0013_u != u0005_u0013_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.remove_\u0014\u0018(ComboBoxViewModel.\u0005\u0013\u0018)).MethodHandle;
				}
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000116 RID: 278 RVA: 0x00007558 File Offset: 0x00005758
		// (remove) Token: 0x06000117 RID: 279 RVA: 0x000075A4 File Offset: 0x000057A4
		internal event ComboBoxViewModel.\u000E\u0013\u0018 \u0003\u0018
		{
			[CompilerGenerated]
			add
			{
				ComboBoxViewModel.\u000E\u0013\u0018 u000E_u0013_u = this.\u0003\u0018;
				ComboBoxViewModel.\u000E\u0013\u0018 u000E_u0013_u2;
				do
				{
					u000E_u0013_u2 = u000E_u0013_u;
					ComboBoxViewModel.\u000E\u0013\u0018 value2 = (ComboBoxViewModel.\u000E\u0013\u0018)\u001C\u0019\u0018.\u0018(u000E_u0013_u2, value);
					u000E_u0013_u = Interlocked.CompareExchange<ComboBoxViewModel.\u000E\u0013\u0018>(ref this.\u0003\u0018, value2, u000E_u0013_u2);
				}
				while (u000E_u0013_u != u000E_u0013_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.add_\u0003\u0018(ComboBoxViewModel.\u000E\u0013\u0018)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ComboBoxViewModel.\u000E\u0013\u0018 u000E_u0013_u = this.\u0003\u0018;
				ComboBoxViewModel.\u000E\u0013\u0018 u000E_u0013_u2;
				do
				{
					u000E_u0013_u2 = u000E_u0013_u;
					ComboBoxViewModel.\u000E\u0013\u0018 value2 = (ComboBoxViewModel.\u000E\u0013\u0018)\u0013\u0019\u0018.\u0018(u000E_u0013_u2, value);
					u000E_u0013_u = Interlocked.CompareExchange<ComboBoxViewModel.\u000E\u0013\u0018>(ref this.\u0003\u0018, value2, u000E_u0013_u2);
				}
				while (u000E_u0013_u != u000E_u0013_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.remove_\u0003\u0018(ComboBoxViewModel.\u000E\u0013\u0018)).MethodHandle;
				}
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000118 RID: 280 RVA: 0x000075F0 File Offset: 0x000057F0
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00007604 File Offset: 0x00005804
		public IList<IComboxItemModel> Items
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

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00007624 File Offset: 0x00005824
		// (set) Token: 0x0600011B RID: 283 RVA: 0x00007638 File Offset: 0x00005838
		public int SelectedIndex
		{
			get
			{
				return this.\u0016\u0018;
			}
			set
			{
				this.\u0016\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectedIndex");
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00007658 File Offset: 0x00005858
		[BindableMethod("OnSelectedIndexChanged")]
		public void OnSelectedIndexChanged()
		{
			\u001E\u0006\u0018.\u0018(this, 0);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000766C File Offset: 0x0000586C
		[BindableMethod("OnCheckboxClick")]
		public void OnCheckboxClick(object sender)
		{
			ComboBoxViewModel.\u000C\u0009\u0018 u000C_u0009_u = new ComboBoxViewModel.\u000C\u0009\u0018();
			u000C_u0009_u.\u000C = \u0019\u0006\u0018.\u0018(this);
			if (\u000B\u0006\u0018.\u0018(u000C_u0009_u.\u000C, 0) == sender)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.OnCheckboxClick(object)).MethodHandle;
				}
				\u001D\u0006\u0018.\u0018(Enumerable.ToList<IComboxItemModel>(\u001A\u0006\u0018.\u0018(this, \u001A\u0004\u000F.\u000C)), new Action<IComboxItemModel>(u000C_u0009_u.\u0018));
			}
			\u0004\u0006\u0018.\u0018(this);
			ComboBoxViewModel.\u0005\u0013\u0018 u0014_u = this.\u0014\u0018;
			if (u0014_u == null)
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
				return;
			}
			\u0002\u0006\u0018.\u0018(u0014_u, sender);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000076F8 File Offset: 0x000058F8
		public void Refresh()
		{
			List<IComboxItemModel> list = \u0019\u0006\u0018.\u0018(this);
			List<IComboxItemModel> list2 = \u001A\u0006\u0018.\u0018(this, list);
			IEnumerable<IComboxItemModel> enumerable = list2;
			Func<IComboxItemModel, bool> func;
			if ((func = ComboBoxViewModel.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.Refresh()).MethodHandle;
				}
				func = (ComboBoxViewModel.<>c.\u0018 = new Func<IComboxItemModel, bool>(ComboBoxViewModel.<>c.\u000C.\u000F));
			}
			if (!Enumerable.Any<IComboxItemModel>(enumerable, func))
			{
				\u0007\u0006\u0018.\u0018(\u000B\u0006\u0018.\u0018(list, 0), new bool?(false));
				return;
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
			IEnumerable<IComboxItemModel> enumerable2 = list2;
			Func<IComboxItemModel, bool> func2;
			if ((func2 = ComboBoxViewModel.<>c.\u0014) == null)
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
				func2 = (ComboBoxViewModel.<>c.\u0014 = new Func<IComboxItemModel, bool>(ComboBoxViewModel.<>c.\u000C.\u0012));
			}
			if (Enumerable.All<IComboxItemModel>(enumerable2, func2))
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
				\u0007\u0006\u0018.\u0018(\u000B\u0006\u0018.\u0018(list, 0), new bool?(true));
				return;
			}
			object u000C = \u000B\u0006\u0018.\u0018(list, 0);
			bool? u;
			\u000B\u0004\u000F.\u000C(ref u);
			\u0007\u0006\u0018.\u0018(u000C, u);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000077DC File Offset: 0x000059DC
		public List<IComboxItemModel> GetAllItems()
		{
			return Enumerable.ToList<IComboxItemModel>(Enumerable.Cast<IComboxItemModel>(\u0010\u0006\u0018.\u0018(\u0006\u0006\u0018.\u0018(this))));
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00007808 File Offset: 0x00005A08
		public List<IComboxItemModel> GetFilteredItems(List<IComboxItemModel> items = null)
		{
			List<IComboxItemModel> list;
			if ((list = items) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.GetFilteredItems(List<IComboxItemModel>)).MethodHandle;
				}
				list = \u0019\u0006\u0018.\u0018(this);
			}
			items = list;
			return Enumerable.ToList<IComboxItemModel>(Enumerable.Skip<IComboxItemModel>(items, 1));
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000784C File Offset: 0x00005A4C
		public List<IComboxItemModel> GetCheckedItems(List<IComboxItemModel> items = null)
		{
			List<IComboxItemModel> list;
			if ((list = items) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.GetCheckedItems(List<IComboxItemModel>)).MethodHandle;
				}
				list = \u001A\u0006\u0018.\u0018(this, \u001A\u0004\u000F.\u000C);
			}
			items = list;
			IEnumerable<IComboxItemModel> enumerable = items;
			Func<IComboxItemModel, bool> func;
			if ((func = ComboBoxViewModel.<>c.\u0003) == null)
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
				func = (ComboBoxViewModel.<>c.\u0003 = new Func<IComboxItemModel, bool>(ComboBoxViewModel.<>c.\u000C.\u000D));
			}
			return Enumerable.ToList<IComboxItemModel>(Enumerable.Where<IComboxItemModel>(enumerable, func));
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000078BC File Offset: 0x00005ABC
		public bool IsAllChecked()
		{
			bool? flag = \u0008\u0006\u0018.\u0018(\u0001\u0006\u0018.\u0018(\u0006\u0006\u0018.\u0018(this), 0));
			return \u000C\u0007\u0018.\u0018(ref flag);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000078EC File Offset: 0x00005AEC
		public void CheckAll()
		{
			object u000C = Enumerable.ToList<IComboxItemModel>(\u0006\u0006\u0018.\u0018(this));
			Action<IComboxItemModel> u;
			if ((u = ComboBoxViewModel.<>c.\u0016) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.CheckAll()).MethodHandle;
				}
				u = (ComboBoxViewModel.<>c.\u0016 = new Action<IComboxItemModel>(ComboBoxViewModel.<>c.\u000C.\u001C));
			}
			\u001D\u0006\u0018.\u0018(u000C, u);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00007940 File Offset: 0x00005B40
		[BindableMethod("DropDownClosed")]
		public void DropDownClosed()
		{
			\u0004\u0006\u0018.\u0018(this);
			ComboBoxViewModel.\u000E\u0013\u0018 u0003_u = this.\u0003\u0018;
			if (u0003_u == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.DropDownClosed()).MethodHandle;
				}
				return;
			}
			\u001B\u0006\u0018.\u0018(u0003_u);
		}

		// Token: 0x04000082 RID: 130
		private int \u0016\u0018;

		// Token: 0x04000083 RID: 131
		private IList<IComboxItemModel> \u000F\u0018 = new List<IComboxItemModel>();

		// Token: 0x02000157 RID: 343
		// (Invoke) Token: 0x06001035 RID: 4149
		internal delegate void \u0005\u0013\u0018(object sender);

		// Token: 0x02000158 RID: 344
		// (Invoke) Token: 0x06001039 RID: 4153
		internal delegate void \u000E\u0013\u0018();

		// Token: 0x0200015A RID: 346
		[CompilerGenerated]
		private sealed class \u000C\u0009\u0018
		{
			// Token: 0x06001043 RID: 4163 RVA: 0x0005A3B4 File Offset: 0x000585B4
			internal void \u0018(IComboxItemModel \u000C)
			{
				\u0007\u0006\u0018.\u0018(\u000C, \u0008\u0006\u0018.\u0018(\u000B\u0006\u0018.\u0018(this.\u000C, 0)));
			}

			// Token: 0x04000775 RID: 1909
			public List<IComboxItemModel> \u000C;
		}
	}
}

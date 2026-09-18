using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using A;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.TableGen.ViewModels
{
	// Token: 0x0200014A RID: 330
	public class ComboBoxViewModel : ViewModelBase
	{
		// Token: 0x06000C37 RID: 3127 RVA: 0x0004DE4C File Offset: 0x0004C04C
		public ComboBoxViewModel(List<IComboxItemModel> items)
		{
			\u001D\u000A\u0019.\u000A(this, items);
			\u0007\u000A\u0019.\u000A(this, 0);
		}

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000C38 RID: 3128 RVA: 0x0004DE70 File Offset: 0x0004C070
		// (remove) Token: 0x06000C39 RID: 3129 RVA: 0x0004DEBC File Offset: 0x0004C0BC
		public event ComboBoxViewModel.OnDropDownClosedEventHandler OnDropDownClosedEvent
		{
			[CompilerGenerated]
			add
			{
				ComboBoxViewModel.OnDropDownClosedEventHandler onDropDownClosedEventHandler = this.FS;
				ComboBoxViewModel.OnDropDownClosedEventHandler onDropDownClosedEventHandler2;
				do
				{
					onDropDownClosedEventHandler2 = onDropDownClosedEventHandler;
					ComboBoxViewModel.OnDropDownClosedEventHandler value2 = (ComboBoxViewModel.OnDropDownClosedEventHandler)\u000F\u001E\u000A.\u000A(onDropDownClosedEventHandler2, value);
					onDropDownClosedEventHandler = Interlocked.CompareExchange<ComboBoxViewModel.OnDropDownClosedEventHandler>(ref this.FS, value2, onDropDownClosedEventHandler2);
				}
				while (onDropDownClosedEventHandler != onDropDownClosedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.add_OnDropDownClosedEvent(ComboBoxViewModel.OnDropDownClosedEventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ComboBoxViewModel.OnDropDownClosedEventHandler onDropDownClosedEventHandler = this.FS;
				ComboBoxViewModel.OnDropDownClosedEventHandler onDropDownClosedEventHandler2;
				do
				{
					onDropDownClosedEventHandler2 = onDropDownClosedEventHandler;
					ComboBoxViewModel.OnDropDownClosedEventHandler value2 = (ComboBoxViewModel.OnDropDownClosedEventHandler)\u0012\u001E\u000A.\u000A(onDropDownClosedEventHandler2, value);
					onDropDownClosedEventHandler = Interlocked.CompareExchange<ComboBoxViewModel.OnDropDownClosedEventHandler>(ref this.FS, value2, onDropDownClosedEventHandler2);
				}
				while (onDropDownClosedEventHandler != onDropDownClosedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.remove_OnDropDownClosedEvent(ComboBoxViewModel.OnDropDownClosedEventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000C3A RID: 3130 RVA: 0x0004DF08 File Offset: 0x0004C108
		// (set) Token: 0x06000C3B RID: 3131 RVA: 0x0004DF1C File Offset: 0x0004C11C
		public int SelectedIndex
		{
			get
			{
				return this.CC;
			}
			set
			{
				this.CC = value;
				\u000D\u0020\u000A.\u000A(this, "SelectedIndex");
			}
		}

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000C3C RID: 3132 RVA: 0x0004DF3C File Offset: 0x0004C13C
		// (set) Token: 0x06000C3D RID: 3133 RVA: 0x0004DF50 File Offset: 0x0004C150
		public List<IComboxItemModel> Items { get; set; }

		// Token: 0x06000C3E RID: 3134 RVA: 0x0004DF64 File Offset: 0x0004C164
		[BindableMethod("OnDropDownClosed")]
		public void OnDropDownClosed()
		{
			\u0007\u000A\u0019.\u000A(this, 0);
			IEnumerable<IComboxItemModel> enumerable = Enumerable.Skip<IComboxItemModel>(\u0005\u000A\u0019.\u0007(this), 1);
			Func<IComboxItemModel, bool> func;
			if ((func = ComboBoxViewModel.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ComboBoxViewModel.OnDropDownClosed()).MethodHandle;
				}
				func = (ComboBoxViewModel.<>c.\u000A = new Func<IComboxItemModel, bool>(ComboBoxViewModel.<>c.\u001F.\u0007));
			}
			if (Enumerable.All<IComboxItemModel>(enumerable, func))
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
				\u0019\u000A\u0019.\u000A(\u0018\u000A\u0019.\u000A(\u0005\u000A\u0019.\u0007(this), 0), new bool?(true));
			}
			else
			{
				object u001F = \u0018\u000A\u0019.\u000A(\u0005\u000A\u0019.\u0007(this), 0);
				bool? u000A;
				\u001B\u000A\u000E.\u001F(ref u000A);
				\u0019\u000A\u0019.\u000A(u001F, u000A);
			}
			ComboBoxViewModel.OnDropDownClosedEventHandler fs = this.FS;
			if (fs == null)
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
				return;
			}
			\u0004\u000A\u0019.\u000A(fs);
		}

		// Token: 0x040004D7 RID: 1239
		[CompilerGenerated]
		private ComboBoxViewModel.OnDropDownClosedEventHandler FS;

		// Token: 0x040004D8 RID: 1240
		private int CC;

		// Token: 0x040004D9 RID: 1241
		[CompilerGenerated]
		private List<IComboxItemModel> RS;

		// Token: 0x02000823 RID: 2083
		// (Invoke) Token: 0x06004DDD RID: 19933
		public delegate void OnDropDownClosedEventHandler();
	}
}

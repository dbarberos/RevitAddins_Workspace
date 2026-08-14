using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.TreeGrid;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.SheetLink.SheetLink.Core.Models;
using DiRoots.One.SheetLink.SheetLink.Core.Models.ScheduleTreeView;

namespace DiRoots.One.SheetLink.UI.Controls
{
	// Token: 0x02000224 RID: 548
	public class ScheduleNavigator : UserControl, IComponentConnector, IStyleConnector
	{
		// Token: 0x06001544 RID: 5444 RVA: 0x0008A5BC File Offset: 0x000887BC
		public ScheduleNavigator()
		{
			\u001E\u0019\u0005.\u000A(this);
			\u0011\u0019\u0005.\u000A(this, new ObservableCollection<ICategoryModel>());
			this.G();
			Document u001F = \u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A());
			\u001B\u0019\u0005.\u000A(this, \u0018\u0010.\u001F(u001F));
			\u0018\u000C\u0007.\u000A(this.W, \u0008\u0019\u0005.\u000A(this));
			\u0004\u000C\u000A.\u000A(this.W, 0);
			if (\u001E\u0011\u0004.\u000A(\u0008\u0019\u0005.\u000A(this)) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator..ctor()).MethodHandle;
				}
				this.D = \u000E\u0019\u0005.\u000A(\u000A\u000F\u000E.\u001F(\u0016\u0008\u0004.\u000A(\u0008\u0019\u0005.\u000A(this), 0)));
			}
		}

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06001546 RID: 5446 RVA: 0x0008A6BC File Offset: 0x000888BC
		// (remove) Token: 0x06001547 RID: 5447 RVA: 0x0008A70C File Offset: 0x0008890C
		public event EventHandler CheckedChangedEvent
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.F;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = \u0017\u0015\u0010.\u001F(\u000F\u001E\u000A.\u000A(eventHandler2, value));
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.F, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.add_CheckedChangedEvent(EventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.F;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = \u0017\u0015\u0010.\u001F(\u0012\u001E\u000A.\u000A(eventHandler2, value));
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.F, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.remove_CheckedChangedEvent(EventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x06001548 RID: 5448 RVA: 0x0008A75C File Offset: 0x0008895C
		// (set) Token: 0x06001549 RID: 5449 RVA: 0x0008A770 File Offset: 0x00088970
		public ScheduleNavigator.ContextMenuDelegate OpenView { get; set; }

		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x0600154A RID: 5450 RVA: 0x0008A784 File Offset: 0x00088984
		// (set) Token: 0x0600154B RID: 5451 RVA: 0x0008A798 File Offset: 0x00088998
		public List<ScheduleInfo> SchedulerInfo { get; set; }

		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x0600154C RID: 5452 RVA: 0x0008A7AC File Offset: 0x000889AC
		// (set) Token: 0x0600154D RID: 5453 RVA: 0x0008A7C0 File Offset: 0x000889C0
		public TreeManager TreeManager { get; set; }

		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x0600154E RID: 5454 RVA: 0x0008A7D4 File Offset: 0x000889D4
		// (set) Token: 0x0600154F RID: 5455 RVA: 0x0008A7F8 File Offset: 0x000889F8
		public ObservableCollection<ICategoryModel> ItemSource
		{
			get
			{
				return \u0010\u0006\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, ScheduleNavigator.ItemSourceProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, ScheduleNavigator.ItemSourceProperty, value);
			}
		}

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x06001550 RID: 5456 RVA: 0x0008A814 File Offset: 0x00088A14
		// (set) Token: 0x06001551 RID: 5457 RVA: 0x0008A828 File Offset: 0x00088A28
		public List<EnumInfo> BrowserOrg { get; set; }

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x06001552 RID: 5458 RVA: 0x0008A83C File Offset: 0x00088A3C
		// (set) Token: 0x06001553 RID: 5459 RVA: 0x0008A850 File Offset: 0x00088A50
		public ObservableCollection<ICategoryModel> SelectedItems { get; set; }

		// Token: 0x06001554 RID: 5460 RVA: 0x0008A864 File Offset: 0x00088A64
		private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ScheduleNavigator scheduleNavigator = \u0009\u0006\u000E.\u001F(d);
			if (scheduleNavigator != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.OnSourceChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				if (\u0020\u0019\u0005.\u0007(scheduleNavigator) != null)
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
					scheduleNavigator.FR();
					scheduleNavigator.Q();
				}
			}
		}

		// Token: 0x06001555 RID: 5461 RVA: 0x0008A8B0 File Offset: 0x00088AB0
		private void CheckBox_Click(object sender, RoutedEventArgs e)
		{
			CheckBox checkBox = \u0011\u000A\u000E.\u001F(sender);
			if (checkBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.CheckBox_Click(object, RoutedEventArgs)).MethodHandle;
				}
				ScheduleInfo scheduleInfo = \u0001\u0006\u000E.\u001F(\u0007\u000C\u000A.\u0007(checkBox));
				if (scheduleInfo != null)
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
					List<ScheduleInfo> list = Enumerable.ToList<ScheduleInfo>(Enumerable.OfType<ScheduleInfo>(\u000C\u0019\u0005.\u000A(this.J)));
					IEnumerable<ScheduleInfo> enumerable = list;
					Func<ScheduleInfo, long> func;
					if ((func = ScheduleNavigator.<>c.\u000A) == null)
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
						func = (ScheduleNavigator.<>c.\u000A = new Func<ScheduleInfo, long>(ScheduleNavigator.<>c.\u001F.\u000B));
					}
					if (\u001A\u0008\u0019.\u000A(Enumerable.ToList<long>(Enumerable.Select<ScheduleInfo, long>(enumerable, func)), \u001A\u0019\u0005.\u000A(scheduleInfo)))
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
						IEnumerable<ScheduleInfo> enumerable2 = list;
						Func<ScheduleInfo, bool> func2;
						if ((func2 = ScheduleNavigator.<>c.\u0007) == null)
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
							func2 = (ScheduleNavigator.<>c.\u0007 = new Func<ScheduleInfo, bool>(ScheduleNavigator.<>c.\u001F.\u0002));
						}
						IEnumerator<ScheduleInfo> enumerator = \u0013\u0019\u0005.\u000A(Enumerable.Where<ScheduleInfo>(enumerable2, func2));
						try
						{
							while (\u000A\u0017\u000A.\u000A(enumerator))
							{
								\u0017\u0019\u0005.\u000A(\u0014\u0019\u0005.\u000A(enumerator), \u0003\u0015\u000A.\u000A(checkBox));
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
						finally
						{
							if (enumerator != null)
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
								\u001F\u0017\u000A.\u000A(enumerator);
							}
						}
					}
					this.I();
				}
			}
		}

		// Token: 0x06001556 RID: 5462 RVA: 0x0008AA04 File Offset: 0x00088C04
		private void txtSearchFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.J)));
			this.Q();
		}

		// Token: 0x06001557 RID: 5463 RVA: 0x0008AA30 File Offset: 0x00088C30
		public void SetProfileToScheduleItem(ICategoryModel categoryModel)
		{
			List<ScheduleInfo>.Enumerator enumerator = \u0009\u0019\u0005.\u000A(\u001F\u0018\u0005.\u000A(this));
			try
			{
				while (\u0015\u0019\u0005.\u000A(ref enumerator))
				{
					\u0002\u0010.\u0007(\u0001\u0019\u0005.\u000A(ref enumerator), categoryModel);
				}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.SetProfileToScheduleItem(ICategoryModel)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06001558 RID: 5464 RVA: 0x0008AA9C File Offset: 0x00088C9C
		private void chkSelectAll_Click(object sender, RoutedEventArgs e)
		{
			CheckBox checkBox = \u0011\u000A\u000E.\u001F(sender);
			if (checkBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.chkSelectAll_Click(object, RoutedEventArgs)).MethodHandle;
				}
				bool? flag = \u0003\u0015\u000A.\u000A(checkBox);
				bool u000A = \u0012\u0015\u000A.\u000A(ref flag);
				\u000A\u0018\u0005.\u000A(\u0007\u0018\u0005.\u000A(this), u000A);
				this.I();
			}
		}

		// Token: 0x06001559 RID: 5465 RVA: 0x0008AAF0 File Offset: 0x00088CF0
		private void chkHideUnCheckedItems_Click(object sender, RoutedEventArgs e)
		{
			if (\u001E\u0009\u000A.\u0007(this.J) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.chkHideUnCheckedItems_Click(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.J)));
			this.Q();
		}

		// Token: 0x0600155A RID: 5466 RVA: 0x0008AB40 File Offset: 0x00088D40
		public void Reset()
		{
			\u000D\u000C\u0007.\u000A(this.B, new bool?(false));
			\u000D\u000C\u0007.\u000A(this.E, new bool?(false));
			\u001C\u001A\u0019.\u000A(this.K, string.Empty);
			IEnumerator<ICategoryModel> enumerator = \u0009\u0004\u0005.\u000A(\u0020\u0019\u0005.\u001D(this));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u0013\u0013\u0018.\u000A(\u0014\u001C\u0018.\u000A(enumerator), false);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.Reset()).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			\u000A\u0018\u0005.\u000A(\u0007\u0018\u0005.\u000A(this), false);
		}

		// Token: 0x0600155B RID: 5467 RVA: 0x0008ABF0 File Offset: 0x00088DF0
		internal bool P(object F)
		{
			ScheduleInfo scheduleInfo = \u0001\u0006\u000E.\u001F(F);
			if (scheduleInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.P(object)).MethodHandle;
				}
				return false;
			}
			this.T(scheduleInfo);
			return true;
		}

		// Token: 0x0600155C RID: 5468 RVA: 0x0008AC2C File Offset: 0x00088E2C
		private bool O(ITreeItem F)
		{
			bool result = false;
			ScheduleInfo scheduleInfo = \u0001\u0006\u000E.\u001F(F);
			if (scheduleInfo != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.O(ITreeItem)).MethodHandle;
				}
				result = \u000D\u0008\u000A.\u001F(\u001D\u0018\u0005.\u000A(scheduleInfo), \u0010\u001A\u0019.\u000A(this.K));
			}
			return result;
		}

		// Token: 0x0600155D RID: 5469 RVA: 0x0008AC78 File Offset: 0x00088E78
		private bool T(ScheduleInfo F)
		{
			\u0004\u0018\u0005.\u000A(F, false);
			bool flag;
			if (!\u001A\u0006\u0007.\u000A(\u0010\u001A\u0019.\u000A(this.K)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.T(ScheduleInfo)).MethodHandle;
				}
				flag = \u000D\u0008\u000A.\u001F(\u001D\u0018\u0005.\u000A(F), \u0010\u001A\u0019.\u000A(this.K));
			}
			else
			{
				flag = true;
			}
			bool flag2 = flag;
			bool? flag3 = \u0003\u0015\u000A.\u000A(this.E);
			if (\u0012\u0015\u000A.\u000A(ref flag3))
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
				bool flag4;
				if (flag2)
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
					flag3 = \u000B\u0018\u0005.\u000A(F);
					flag4 = \u0012\u0015\u000A.\u000A(ref flag3);
				}
				else
				{
					flag4 = false;
				}
				flag2 = flag4;
			}
			List<ScheduleInfo>.Enumerator enumerator = \u0009\u0019\u0005.\u000A(\u0018\u0018\u0005.\u0007(F));
			try
			{
				while (\u0015\u0019\u0005.\u000A(ref enumerator))
				{
					ScheduleInfo f = \u0001\u0019\u0005.\u000A(ref enumerator);
					if (this.T(f))
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
						flag2 = true;
					}
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u0016\u0018\u0005.\u000A(F, new bool?(flag2));
			flag3 = \u0005\u0018\u0005.\u000A(F);
			if (\u0012\u0015\u000A.\u000A(ref flag3))
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
				IEnumerable<ScheduleInfo> enumerable = \u0018\u0018\u0005.\u0007(F);
				Func<ScheduleInfo, bool> func;
				if ((func = ScheduleNavigator.<>c.\u001D) == null)
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
					func = (ScheduleNavigator.<>c.\u001D = new Func<ScheduleInfo, bool>(ScheduleNavigator.<>c.\u001F.\u0006));
				}
				\u0004\u0018\u0005.\u000A(F, Enumerable.Any<ScheduleInfo>(enumerable, func));
				object u001F = \u0018\u0018\u0005.\u0007(F);
				Action<ScheduleInfo> u000A;
				if ((u000A = ScheduleNavigator.<>c.\u0004) == null)
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
					u000A = (ScheduleNavigator.<>c.\u0004 = new Action<ScheduleInfo>(ScheduleNavigator.<>c.\u001F.\u000F));
				}
				\u0019\u0018\u0005.\u000A(u001F, u000A);
			}
			if (\u001A\u0006\u0007.\u000A(\u0010\u001A\u0019.\u000A(this.K)))
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
				\u0004\u0018\u0005.\u000A(F, false);
			}
			return flag2;
		}

		// Token: 0x0600155E RID: 5470 RVA: 0x0008AE4C File Offset: 0x0008904C
		private void I()
		{
			ScheduleNavigator.\u0009\u0003 u0009_u = new ScheduleNavigator.\u0009\u0003();
			u0009_u.\u001F = \u0002\u0010.\u000A(\u001F\u0018\u0005.\u000A(this), true);
			object u001F = Enumerable.ToList<ICategoryModel>(\u0020\u0019\u0005.\u001D(this));
			Action<ICategoryModel> u000A;
			if ((u000A = ScheduleNavigator.<>c.\u0019) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.I()).MethodHandle;
				}
				u000A = (ScheduleNavigator.<>c.\u0019 = new Action<ICategoryModel>(ScheduleNavigator.<>c.\u001F.\u0012));
			}
			\u001B\u0015\u0018.\u000A(u001F, u000A);
			IEnumerable<ICategoryModel> enumerable = Enumerable.Where<ICategoryModel>(\u0020\u0019\u0005.\u001D(this), new Func<ICategoryModel, bool>(u0009_u.\u000A));
			object u001F2 = Enumerable.ToList<ICategoryModel>(enumerable);
			Action<ICategoryModel> u000A2;
			if ((u000A2 = ScheduleNavigator.<>c.\u0018) == null)
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
				u000A2 = (ScheduleNavigator.<>c.\u0018 = new Action<ICategoryModel>(ScheduleNavigator.<>c.\u001F.\u0003));
			}
			\u001B\u0015\u0018.\u000A(u001F2, u000A2);
			\u0011\u0019\u0005.\u000A(this, \u0007\u000C\u0018.\u000A(enumerable));
			EventHandler f = this.F;
			if (f == null)
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
				\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
			}
			this.Q();
		}

		// Token: 0x0600155F RID: 5471 RVA: 0x0008AF44 File Offset: 0x00089144
		private void ChkList_OnKeyUp(object sender, KeyEventArgs e)
		{
			if (\u001A\u001A\u0019.\u000A(e) == Key.Space)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.ChkList_OnKeyUp(object, KeyEventArgs)).MethodHandle;
				}
				if (\u0002\u0018\u0005.\u000A(this.J) != null)
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
					ScheduleInfo scheduleInfo = \u0001\u0006\u000E.\u001F(\u0002\u0018\u0005.\u000A(this.J));
					if (scheduleInfo != null)
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
						ScheduleInfo f = scheduleInfo;
						bool? flag = \u000B\u0018\u0005.\u000A(scheduleInfo);
						bool? flag2;
						bool? flag3;
						if (!\u000D\u0003\u001D.\u000A(ref flag))
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
							\u001B\u000A\u000E.\u001F(ref flag2);
							flag3 = flag2;
						}
						else
						{
							flag3 = new bool?(!\u0012\u0015\u000A.\u000A(ref flag));
						}
						flag2 = flag3;
						this.A(f, \u0012\u0015\u000A.\u000A(ref flag2));
					}
					this.I();
				}
			}
		}

		// Token: 0x06001560 RID: 5472 RVA: 0x0008B004 File Offset: 0x00089204
		internal void Q()
		{
			List<ScheduleInfo> list = \u0002\u0010.\u000A(\u001F\u0018\u0005.\u000A(this), false);
			object b = this.B;
			IEnumerable u001F = list;
			Func<ScheduleInfo, bool> u000A;
			if ((u000A = ScheduleNavigator.<>c.\u0005) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.Q()).MethodHandle;
				}
				u000A = (ScheduleNavigator.<>c.\u0005 = new Func<ScheduleInfo, bool>(ScheduleNavigator.<>c.\u001F.\u001C));
			}
			\u000D\u000C\u0007.\u000A(b, \u0001\u0003.\u001F<ScheduleInfo>(u001F, u000A));
		}

		// Token: 0x06001561 RID: 5473 RVA: 0x0008B068 File Offset: 0x00089268
		private void A(ScheduleInfo F, bool R)
		{
			ScheduleNavigator.\u000A\u001C u000A_u001C = new ScheduleNavigator.\u000A\u001C();
			u000A_u001C.\u001F = this;
			u000A_u001C.\u000A = R;
			\u0017\u0019\u0005.\u000A(F, new bool?(u000A_u001C.\u000A));
			if (\u0006\u001C\u001D.\u000A(F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.A(ScheduleInfo, bool)).MethodHandle;
				}
				\u0019\u0018\u0005.\u000A(\u0018\u0018\u0005.\u0007(F), new Action<ScheduleInfo>(u000A_u001C.\u0007));
			}
		}

		// Token: 0x06001562 RID: 5474 RVA: 0x0008B0D0 File Offset: 0x000892D0
		private void G()
		{
			\u000A\u0016\u0019.\u000A(this.J, \u0007\u0016\u0019.\u000A());
			\u0015\u001A\u0019.\u000A(\u001F\u0016\u0019.\u000A(this.J), "openMenu");
			MenuItem menuItem = \u0019\u0016\u000E.\u001F;
			MenuItem menuItem2 = \u0002\u0016\u0019.\u000A();
			\u000B\u0016\u0019.\u000A(menuItem2, \u000C\u001A\u0019.\u000A());
			menuItem = menuItem2;
			\u0018\u0016\u0019.\u000A(menuItem, new RoutedEventHandler(this.MenuItem_Click));
			\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u001F\u0016\u0019.\u000A(this.J)), menuItem);
		}

		// Token: 0x06001563 RID: 5475 RVA: 0x0008B150 File Offset: 0x00089350
		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			ScheduleInfo scheduleInfo = \u0001\u0006\u000E.\u001F(\u0002\u0018\u0005.\u000A(this.J));
			if (scheduleInfo != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.MenuItem_Click(object, RoutedEventArgs)).MethodHandle;
				}
				string u000A = \u001D\u0018\u0005.\u000A(scheduleInfo);
				ScheduleNavigator.ContextMenuDelegate contextMenuDelegate = \u0019\u0001\u0018.\u001D(this);
				if (contextMenuDelegate == null)
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
					return;
				}
				\u0006\u0018\u0005.\u000A(contextMenuDelegate, u000A);
			}
		}

		// Token: 0x06001564 RID: 5476 RVA: 0x0008B1B0 File Offset: 0x000893B0
		private void ChkList_ContextMenuOpening(object sender, ContextMenuEventArgs e)
		{
			ScheduleInfo scheduleInfo = \u0001\u0006\u000E.\u001F(\u0002\u0018\u0005.\u000A(this.J));
			if (scheduleInfo != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.ChkList_ContextMenuOpening(object, ContextMenuEventArgs)).MethodHandle;
				}
				if (\u0006\u001C\u001D.\u000A(scheduleInfo))
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
					\u0019\u0013\u000A.\u000A(e, true);
				}
			}
		}

		// Token: 0x06001565 RID: 5477 RVA: 0x0008B204 File Offset: 0x00089404
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x06001566 RID: 5478 RVA: 0x0008B22C File Offset: 0x0008942C
		private void cmbBrowserOrg_DropDownClosed(object sender, EventArgs e)
		{
			BrowserOrganizationInfo browserOrganizationInfo = \u0015\u0006\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.W));
			if (browserOrganizationInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.cmbBrowserOrg_DropDownClosed(object, EventArgs)).MethodHandle;
				}
				return;
			}
			if (\u0011\u0016\u001D.\u000A(\u0002\u001E\u000A.\u0007(\u000E\u0019\u0005.\u000A(browserOrganizationInfo)), \u0002\u001E\u000A.\u0007(this.D)))
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
			this.D = \u000E\u0019\u0005.\u000A(browserOrganizationInfo);
			this.FR();
		}

		// Token: 0x06001567 RID: 5479 RVA: 0x0008B2AC File Offset: 0x000894AC
		private void FR()
		{
			List<ScheduleInfo> list = \u0002\u0010.\u001F(\u0020\u0019\u0005.\u001D(this), this.D);
			if (\u001F\u0018\u0005.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.FR()).MethodHandle;
				}
				List<ScheduleInfo> u001F = \u0002\u0010.\u000A(\u001F\u0018\u0005.\u000A(this), false);
				\u0006\u0003\u001D.\u000A(list, \u000C\u0006\u000E.\u001F);
				List<ScheduleInfo>.Enumerator enumerator = \u0009\u0019\u0005.\u000A(\u0002\u0010.\u000A(list, false));
				try
				{
					while (\u0015\u0019\u0005.\u000A(ref enumerator))
					{
						ScheduleNavigator.\u0007\u001C u0007_u001C = new ScheduleNavigator.\u0007\u001C();
						u0007_u001C.\u001F = \u0001\u0019\u0005.\u000A(ref enumerator);
						\u0017\u0019\u0005.\u000A(u0007_u001C.\u001F, new bool?(\u0003\u0018\u0005.\u000A(u001F, new Predicate<ScheduleInfo>(u0007_u001C.\u000A))));
					}
					for (;;)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			\u0012\u0018\u0005.\u000A(this, list);
			object u001F2 = \u0011\u0009\u000A.\u000A(\u001F\u0018\u0005.\u000A(this));
			\u000F\u0018\u0005.\u000A(this, \u0006\u0003\u001D.\u000A(\u001F\u0018\u0005.\u000A(this), new Predicate<ITreeItem>(this.O)));
			\u0005\u0008\u0007.\u000A(u001F2, new Predicate<object>(this.P));
			object u001F3 = \u001F\u0018\u0005.\u000A(this);
			Action<ScheduleInfo> u000A;
			if ((u000A = ScheduleNavigator.<>c.\u0016) == null)
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
				u000A = (ScheduleNavigator.<>c.\u0016 = new Action<ScheduleInfo>(ScheduleNavigator.<>c.\u001F.\u000D));
			}
			\u0019\u0018\u0005.\u000A(u001F3, u000A);
			\u0018\u000C\u0007.\u000A(this.J, \u001F\u0018\u0005.\u000A(this));
		}

		// Token: 0x06001568 RID: 5480 RVA: 0x0008B420 File Offset: 0x00089620
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.N)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.N = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink.core/ui/usercontrols/categorynavigator/schedulenavigator.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001569 RID: 5481 RVA: 0x0008B468 File Offset: 0x00089668
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		internal Delegate RR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x0600156A RID: 5482 RVA: 0x0008B480 File Offset: 0x00089680
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.M(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u0013\u0006\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.B = \u0016\u0009\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.B, new RoutedEventHandler(this.chkSelectAll_Click));
				return;
			case 3:
				this.U = \u001A\u000A\u000E.\u001F(R);
				return;
			case 4:
				this.W = \u000B\u000A\u000E.\u001F(R);
				\u001C\u0018\u0005.\u000A(this.W, new EventHandler(this.cmbBrowserOrg_DropDownClosed));
				return;
			case 5:
				this.K = \u0005\u0009\u0010.\u001F(R);
				\u0007\u000C\u0019.\u000A(this.K, new TextChangedEventHandler(this.txtSearchFilter_TextChanged));
				return;
			case 6:
				this.J = \u001A\u0006\u000E.\u001F(R);
				return;
			case 8:
				this.E = \u0016\u0009\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.E, new RoutedEventHandler(this.chkHideUnCheckedItems_Click));
				return;
			}
			this.N = true;
		}

		// Token: 0x0600156B RID: 5483 RVA: 0x0008B594 File Offset: 0x00089794
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IStyleConnector.V(int F, object R)
		{
			if (F == 7)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.V(int, object)).MethodHandle;
				}
				\u0010\u0015\u000A.\u000A(\u0016\u0009\u0010.\u001F(R), new RoutedEventHandler(this.CheckBox_Click));
			}
		}

		// Token: 0x04000841 RID: 2113
		[CompilerGenerated]
		private EventHandler F;

		// Token: 0x04000842 RID: 2114
		[CompilerGenerated]
		private ScheduleNavigator.ContextMenuDelegate R;

		// Token: 0x04000843 RID: 2115
		private BrowserOrganization D;

		// Token: 0x04000844 RID: 2116
		[CompilerGenerated]
		private List<ScheduleInfo> H;

		// Token: 0x04000845 RID: 2117
		[CompilerGenerated]
		private TreeManager C;

		// Token: 0x04000846 RID: 2118
		[CompilerGenerated]
		private List<EnumInfo> L;

		// Token: 0x04000847 RID: 2119
		[CompilerGenerated]
		private ObservableCollection<ICategoryModel> S;

		// Token: 0x04000848 RID: 2120
		public static readonly DependencyProperty ItemSourceProperty = \u000F\u0006\u001D.\u000A("ItemSource", \u001E\u0011\u000A.\u000A(\u000E\u0006\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u001F\u000F\u000E.\u001F()), \u0002\u001A\u0019.\u000A(new PropertyChangedCallback(ScheduleNavigator.OnSourceChanged)));

		// Token: 0x04000849 RID: 2121
		internal CheckBox B;

		// Token: 0x0400084A RID: 2122
		internal Label U;

		// Token: 0x0400084B RID: 2123
		internal ComboBox W;

		// Token: 0x0400084C RID: 2124
		internal WatermarkTextBox K;

		// Token: 0x0400084D RID: 2125
		internal MultiSelectTreeView J;

		// Token: 0x0400084E RID: 2126
		internal CheckBox E;

		// Token: 0x0400084F RID: 2127
		private bool N;

		// Token: 0x020008F2 RID: 2290
		// (Invoke) Token: 0x0600510C RID: 20748
		public delegate void ContextMenuDelegate(string viewName);

		// Token: 0x020008F4 RID: 2292
		[CompilerGenerated]
		private sealed class \u0009\u0003
		{
			// Token: 0x0600511A RID: 20762 RVA: 0x001E822C File Offset: 0x001E642C
			internal bool \u000A(ICategoryModel \u001F)
			{
				ScheduleNavigator.\u001F\u001C u001F_u001C = new ScheduleNavigator.\u001F\u001C();
				u001F_u001C.\u001F = \u001F;
				return \u0003\u0018\u0005.\u000A(this.\u001F, new Predicate<ScheduleInfo>(u001F_u001C.\u000A));
			}

			// Token: 0x04002375 RID: 9077
			public List<ScheduleInfo> \u001F;
		}

		// Token: 0x020008F5 RID: 2293
		[CompilerGenerated]
		private sealed class \u001F\u001C
		{
			// Token: 0x0600511C RID: 20764 RVA: 0x001E8274 File Offset: 0x001E6474
			internal bool \u000A(ScheduleInfo \u001F)
			{
				return \u001A\u0019\u0005.\u000A(\u001F) == \u0017\u001C\u0018.\u000A(this.\u001F);
			}

			// Token: 0x04002376 RID: 9078
			public ICategoryModel \u001F;
		}

		// Token: 0x020008F6 RID: 2294
		[CompilerGenerated]
		private sealed class \u000A\u001C
		{
			// Token: 0x0600511E RID: 20766 RVA: 0x001E82AC File Offset: 0x001E64AC
			internal void \u0007(ScheduleInfo \u001F)
			{
				this.\u001F.A(\u001F, this.\u000A);
			}

			// Token: 0x04002377 RID: 9079
			public ScheduleNavigator \u001F;

			// Token: 0x04002378 RID: 9080
			public bool \u000A;
		}

		// Token: 0x020008F7 RID: 2295
		[CompilerGenerated]
		private sealed class \u0007\u001C
		{
			// Token: 0x06005120 RID: 20768 RVA: 0x001E82E0 File Offset: 0x001E64E0
			internal bool \u000A(ScheduleInfo \u001F)
			{
				if (\u001A\u0019\u0005.\u000A(\u001F) == \u001A\u0019\u0005.\u000A(this.\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleNavigator.\u0007\u001C.\u000A(ScheduleInfo)).MethodHandle;
					}
					bool? flag = \u000B\u0018\u0005.\u000A(\u001F);
					return \u0012\u0015\u000A.\u000A(ref flag);
				}
				return false;
			}

			// Token: 0x04002379 RID: 9081
			public ScheduleInfo \u001F;
		}
	}
}

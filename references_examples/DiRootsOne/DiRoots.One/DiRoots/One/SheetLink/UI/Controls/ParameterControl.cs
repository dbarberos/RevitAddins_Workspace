using System;
using System.CodeDom.Compiler;
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
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;
using Microsoft.Xaml.Behaviors;

namespace DiRoots.One.SheetLink.UI.Controls
{
	// Token: 0x0200022A RID: 554
	public class ParameterControl : UserControl, IComponentConnector
	{
		// Token: 0x0600159C RID: 5532 RVA: 0x0008C480 File Offset: 0x0008A680
		public ParameterControl()
		{
			\u000B\u0005\u0005.\u000A(this);
			this.N(\u0002\u000F\u000E.\u001F);
		}

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x0600159E RID: 5534 RVA: 0x0008C528 File Offset: 0x0008A728
		// (remove) Token: 0x0600159F RID: 5535 RVA: 0x0008C578 File Offset: 0x0008A778
		public event EventHandler ItemSourceChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.C;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = \u0017\u0015\u0010.\u001F(\u000F\u001E\u000A.\u000A(eventHandler2, value));
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.C, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterControl.add_ItemSourceChanged(EventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.C;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = \u0017\u0015\u0010.\u001F(\u0012\u001E\u000A.\u000A(eventHandler2, value));
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.C, value2, eventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterControl.remove_ItemSourceChanged(EventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x060015A0 RID: 5536 RVA: 0x0008C5C8 File Offset: 0x0008A7C8
		// (set) Token: 0x060015A1 RID: 5537 RVA: 0x0008C5DC File Offset: 0x0008A7DC
		public bool ExportedByType
		{
			get
			{
				return this.F;
			}
			set
			{
				this.F = value;
				this.V(true);
			}
		}

		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x060015A2 RID: 5538 RVA: 0x0008C5F8 File Offset: 0x0008A7F8
		// (set) Token: 0x060015A3 RID: 5539 RVA: 0x0008C60C File Offset: 0x0008A80C
		public bool RemoveType
		{
			get
			{
				return this.R;
			}
			set
			{
				this.R = value;
				this.V(false);
			}
		}

		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x060015A4 RID: 5540 RVA: 0x0008C628 File Offset: 0x0008A828
		// (set) Token: 0x060015A5 RID: 5541 RVA: 0x0008C63C File Offset: 0x0008A83C
		public bool RemoveSelectAll
		{
			get
			{
				return this.D;
			}
			set
			{
				this.D = value;
				this.P();
			}
		}

		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x060015A6 RID: 5542 RVA: 0x0008C658 File Offset: 0x0008A858
		// (set) Token: 0x060015A7 RID: 5543 RVA: 0x0008C67C File Offset: 0x0008A87C
		public string Title
		{
			get
			{
				return \u0013\u0001\u0010.\u001F(\u0004\u0015\u000A.\u0007(this, ParameterControl.TitleProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, ParameterControl.TitleProperty, value);
			}
		}

		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x060015A8 RID: 5544 RVA: 0x0008C698 File Offset: 0x0008A898
		// (set) Token: 0x060015A9 RID: 5545 RVA: 0x0008C6BC File Offset: 0x0008A8BC
		public ObservableCollection<BaseParameter> ItemSource
		{
			get
			{
				return \u000F\u000F\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, ParameterControl.ItemSourceProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, ParameterControl.ItemSourceProperty, value);
			}
		}

		// Token: 0x060015AA RID: 5546 RVA: 0x0008C6D8 File Offset: 0x0008A8D8
		private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ParameterControl parameterControl = \u0006\u000F\u000E.\u001F(d);
			if (parameterControl == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterControl.OnItemSourceChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			ICollectionView collectionView = \u0011\u0009\u000A.\u000A(\u001E\u001A\u0019.\u0007(parameterControl));
			\u0005\u0008\u0007.\u000A(collectionView, new Predicate<object>(parameterControl.E));
			\u0018\u000C\u0007.\u000A(parameterControl.B, collectionView);
		}

		// Token: 0x060015AB RID: 5547 RVA: 0x0008C734 File Offset: 0x0008A934
		internal void J(string F)
		{
			\u0002\u0005\u0005.\u000A(this.B, F);
		}

		// Token: 0x060015AC RID: 5548 RVA: 0x0008C750 File Offset: 0x0008A950
		private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (\u001E\u0009\u000A.\u0007(this.B) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterControl.txtSearch_TextChanged(object, TextChangedEventArgs)).MethodHandle;
				}
				\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.B)));
			}
			this.V(false);
			EventHandler c = this.C;
			if (c == null)
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
			\u001E\u001A\u000A.\u000A(c, this, EventArgs.Empty);
		}

		// Token: 0x060015AD RID: 5549 RVA: 0x0008C7C0 File Offset: 0x0008A9C0
		private void CmbFilter_DropDownClosed(object sender, EventArgs e)
		{
			if (\u001E\u0009\u000A.\u0007(this.B) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterControl.CmbFilter_DropDownClosed(object, EventArgs)).MethodHandle;
				}
				\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.B)));
			}
			this.V(false);
			EventHandler c = this.C;
			if (c == null)
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
			\u001E\u001A\u000A.\u000A(c, this, EventArgs.Empty);
		}

		// Token: 0x060015AE RID: 5550 RVA: 0x0008C830 File Offset: 0x0008AA30
		public void Reset()
		{
			\u001C\u001A\u0019.\u000A(this.S, "");
			this.N(\u0002\u000F\u000E.\u001F);
		}

		// Token: 0x060015AF RID: 5551 RVA: 0x0008C858 File Offset: 0x0008AA58
		internal bool E(object F)
		{
			BaseParameter baseParameter = \u000B\u000F\u000E.\u001F(F);
			if (baseParameter == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterControl.E(object)).MethodHandle;
				}
				return false;
			}
			List<ParameterSource> u001F = Enumerable.ToList<ParameterSource>(Enumerable.Cast<ParameterSource>(\u001D\u0019\u0005.\u000A(\u0004\u0019\u0005.\u000A(this.L))));
			bool flag = true;
			if (\u0012\u0005\u0005.\u000A(u001F) != 3)
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
				bool flag2;
				if (\u000F\u0005\u0005.\u000A(u001F, ParameterSource.Instance))
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
					if (!\u0018\u000C\u0019.\u001D(baseParameter))
					{
						flag2 = true;
						goto IL_AA;
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
				if (\u000F\u0005\u0005.\u000A(u001F, ParameterSource.Type))
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
					flag2 = \u0018\u000C\u0019.\u001D(baseParameter);
				}
				else
				{
					flag2 = false;
				}
				IL_AA:
				flag = flag2;
				if (flag)
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
					if (!\u000F\u0005\u0005.\u000A(u001F, ParameterSource.ReadOnly))
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
						if (\u0005\u000C\u0019.\u001D(baseParameter))
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
							flag = false;
						}
					}
				}
				else if (\u000F\u0005\u0005.\u000A(u001F, ParameterSource.ReadOnly))
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
					flag = \u0005\u000C\u0019.\u001D(baseParameter);
				}
			}
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
				bool flag3;
				if (!\u001A\u0006\u0007.\u000A(\u0010\u001A\u0019.\u000A(this.S)))
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
					flag3 = \u000D\u0008\u000A.\u001F(\u001D\u001B\u0018.\u0007(baseParameter), \u0010\u001A\u0019.\u000A(this.S));
				}
				else
				{
					flag3 = true;
				}
				flag = flag3;
			}
			\u0006\u0005\u0005.\u000A(baseParameter, flag);
			return flag;
		}

		// Token: 0x060015B0 RID: 5552 RVA: 0x0008C9C0 File Offset: 0x0008ABC0
		private void N(Dictionary<string, object> F)
		{
			Dictionary<string, object> dictionary = this.M();
			\u0001\u0017\u0018.\u000A(this.L, dictionary);
			if (F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterControl.N(Dictionary<string, object>)).MethodHandle;
				}
				F = \u0015\u0017\u0018.\u000A(dictionary);
			}
			\u000C\u0017\u0018.\u000A(this.L, F);
			this.P();
		}

		// Token: 0x060015B1 RID: 5553 RVA: 0x0008CA18 File Offset: 0x0008AC18
		private Dictionary<string, object> M()
		{
			Dictionary<string, object> result;
			if (\u001C\u0005\u0005.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterControl.M()).MethodHandle;
				}
				result = \u000A\u0010.\u000A();
			}
			else if (\u0003\u0005\u0005.\u000A(this))
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
				result = \u000A\u0010.\u0007();
			}
			else
			{
				result = \u000A\u0010.\u001D();
			}
			return result;
		}

		// Token: 0x060015B2 RID: 5554 RVA: 0x0008CA74 File Offset: 0x0008AC74
		private void V(bool F = false)
		{
			Dictionary<string, object> dictionary = \u0015\u0017\u0018.\u000A(\u0004\u0019\u0005.\u000A(this.L));
			Dictionary<string, object> u001F = \u0015\u0017\u0018.\u000A(\u0004\u0019\u0005.\u000A(this.L));
			if (F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterControl.V(bool)).MethodHandle;
				}
				if (this.H)
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
					if (!\u000D\u0005\u0005.\u000A(dictionary, ParameterSource.Instance.\u001F()))
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
						\u001F\u0014\u0018.\u000A(dictionary, ParameterSource.Instance.\u001F(), 1);
					}
				}
			}
			Dictionary<string, object> f = \u000A\u0010.\u001F(this.M(), dictionary, \u001C\u0005\u0005.\u000A(this));
			this.N(f);
			if (\u001E\u0009\u000A.\u0007(this.B) != null)
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
				\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.B)));
			}
			this.H = \u000D\u0005\u0005.\u000A(u001F, ParameterSource.Instance.\u001F());
		}

		// Token: 0x060015B3 RID: 5555 RVA: 0x0008CB6C File Offset: 0x0008AD6C
		private void P()
		{
			\u000A\u0016\u0019.\u000A(this.B, \u0007\u0016\u0019.\u000A());
			\u0015\u001A\u0019.\u000A(\u001F\u0016\u0019.\u000A(this.B), "orderMenu");
			MenuItem menuItem = \u0019\u0016\u000E.\u001F;
			if (!\u001C\u0005\u0005.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterControl.P()).MethodHandle;
				}
				MenuItem menuItem2 = \u0002\u0016\u0019.\u000A();
				\u000B\u0016\u0019.\u000A(menuItem2, \u0008\u0005\u0005.\u000A());
				menuItem = menuItem2;
				\u0018\u0016\u0019.\u000A(menuItem, new RoutedEventHandler(this.MenuItem_Click_OrderByInstance));
				\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u001F\u0016\u0019.\u000A(this.B)), menuItem);
			}
			if (!\u0003\u0005\u0005.\u000A(this))
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
				MenuItem menuItem3 = \u0002\u0016\u0019.\u000A();
				\u000B\u0016\u0019.\u000A(menuItem3, \u000E\u0005\u0005.\u000A());
				menuItem = menuItem3;
				\u0018\u0016\u0019.\u000A(menuItem, new RoutedEventHandler(this.MenuItem_Click_OrderByType));
				\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u001F\u0016\u0019.\u000A(this.B)), menuItem);
			}
			if (!this.D)
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
				MenuItem menuItem4 = \u0002\u0016\u0019.\u000A();
				\u000B\u0016\u0019.\u000A(menuItem4, \u0010\u0005\u0005.\u000A());
				menuItem = menuItem4;
				\u0018\u0016\u0019.\u000A(menuItem, new RoutedEventHandler(this.MenuItem_Click_SelectAll));
				\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u001F\u0016\u0019.\u000A(this.B)), menuItem);
			}
		}

		// Token: 0x060015B4 RID: 5556 RVA: 0x0008CCB8 File Offset: 0x0008AEB8
		private void MenuItem_Click_OrderByInstance(object sender, RoutedEventArgs e)
		{
			IEnumerable<BaseParameter> enumerable = \u001E\u001A\u0019.\u001D(this);
			Func<BaseParameter, bool> func;
			if ((func = ParameterControl.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterControl.MenuItem_Click_OrderByInstance(object, RoutedEventArgs)).MethodHandle;
				}
				func = (ParameterControl.<>c.\u000A = new Func<BaseParameter, bool>(ParameterControl.<>c.\u001F.\u0012));
			}
			object u001F = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable, func));
			Action<BaseParameter> u000A;
			if ((u000A = ParameterControl.<>c.\u0007) == null)
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
				u000A = (ParameterControl.<>c.\u0007 = new Action<BaseParameter>(ParameterControl.<>c.\u001F.\u0003));
			}
			\u0020\u001A\u0019.\u000A(u001F, u000A);
			IEnumerable<BaseParameter> enumerable2 = \u001E\u001A\u0019.\u001D(this);
			Func<BaseParameter, bool> func2;
			if ((func2 = ParameterControl.<>c.\u001D) == null)
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
				func2 = (ParameterControl.<>c.\u001D = new Func<BaseParameter, bool>(ParameterControl.<>c.\u001F.\u001C));
			}
			object u001F2 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable2, func2));
			Action<BaseParameter> u000A2;
			if ((u000A2 = ParameterControl.<>c.\u0004) == null)
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
				u000A2 = (ParameterControl.<>c.\u0004 = new Action<BaseParameter>(ParameterControl.<>c.\u001F.\u000D));
			}
			\u0020\u001A\u0019.\u000A(u001F2, u000A2);
			IEnumerable<BaseParameter> enumerable3 = \u001E\u001A\u0019.\u001D(this);
			Func<BaseParameter, bool> func3;
			if ((func3 = ParameterControl.<>c.\u0019) == null)
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
				func3 = (ParameterControl.<>c.\u0019 = new Func<BaseParameter, bool>(ParameterControl.<>c.\u001F.\u0010));
			}
			object u001F3 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable3, func3));
			Action<BaseParameter> u000A3;
			if ((u000A3 = ParameterControl.<>c.\u0018) == null)
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
				u000A3 = (ParameterControl.<>c.\u0018 = new Action<BaseParameter>(ParameterControl.<>c.\u001F.\u000E));
			}
			\u0020\u001A\u0019.\u000A(u001F3, u000A3);
			this.O();
		}

		// Token: 0x060015B5 RID: 5557 RVA: 0x0008CE1C File Offset: 0x0008B01C
		private void MenuItem_Click_OrderByType(object sender, RoutedEventArgs e)
		{
			IEnumerable<BaseParameter> enumerable = \u001E\u001A\u0019.\u001D(this);
			Func<BaseParameter, bool> func;
			if ((func = ParameterControl.<>c.\u0005) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterControl.MenuItem_Click_OrderByType(object, RoutedEventArgs)).MethodHandle;
				}
				func = (ParameterControl.<>c.\u0005 = new Func<BaseParameter, bool>(ParameterControl.<>c.\u001F.\u0008));
			}
			object u001F = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable, func));
			Action<BaseParameter> u000A;
			if ((u000A = ParameterControl.<>c.\u0016) == null)
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
				u000A = (ParameterControl.<>c.\u0016 = new Action<BaseParameter>(ParameterControl.<>c.\u001F.\u001B));
			}
			\u0020\u001A\u0019.\u000A(u001F, u000A);
			IEnumerable<BaseParameter> enumerable2 = \u001E\u001A\u0019.\u001D(this);
			Func<BaseParameter, bool> func2;
			if ((func2 = ParameterControl.<>c.\u000B) == null)
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
				func2 = (ParameterControl.<>c.\u000B = new Func<BaseParameter, bool>(ParameterControl.<>c.\u001F.\u0011));
			}
			object u001F2 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable2, func2));
			Action<BaseParameter> u000A2;
			if ((u000A2 = ParameterControl.<>c.\u0002) == null)
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
				u000A2 = (ParameterControl.<>c.\u0002 = new Action<BaseParameter>(ParameterControl.<>c.\u001F.\u001E));
			}
			\u0020\u001A\u0019.\u000A(u001F2, u000A2);
			IEnumerable<BaseParameter> enumerable3 = \u001E\u001A\u0019.\u001D(this);
			Func<BaseParameter, bool> func3;
			if ((func3 = ParameterControl.<>c.\u0006) == null)
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
				func3 = (ParameterControl.<>c.\u0006 = new Func<BaseParameter, bool>(ParameterControl.<>c.\u001F.\u0020));
			}
			object u001F3 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(enumerable3, func3));
			Action<BaseParameter> u000A3;
			if ((u000A3 = ParameterControl.<>c.\u000F) == null)
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
				u000A3 = (ParameterControl.<>c.\u000F = new Action<BaseParameter>(ParameterControl.<>c.\u001F.\u0017));
			}
			\u0020\u001A\u0019.\u000A(u001F3, u000A3);
			this.O();
		}

		// Token: 0x060015B6 RID: 5558 RVA: 0x0008CF80 File Offset: 0x0008B180
		private void MenuItem_Click_SelectAll(object sender, RoutedEventArgs e)
		{
			\u001B\u0005\u0005.\u000A(this.B);
		}

		// Token: 0x060015B7 RID: 5559 RVA: 0x0008CF98 File Offset: 0x0008B198
		private void O()
		{
			ICollectionView u001F = \u0011\u0009\u000A.\u000A(\u001E\u001A\u0019.\u001D(this));
			\u0013\u001A\u0019.\u000A(\u0014\u001A\u0019.\u000A(u001F));
			\u0017\u001A\u0019.\u000A(\u0014\u001A\u0019.\u000A(u001F), new SortDescription("OrderIndex", ListSortDirection.Ascending));
			\u0017\u001A\u0019.\u000A(\u0014\u001A\u0019.\u000A(u001F), new SortDescription("Name", ListSortDirection.Ascending));
		}

		// Token: 0x060015B8 RID: 5560 RVA: 0x0008CFF0 File Offset: 0x0008B1F0
		private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			ScrollViewer u001F = \u0017\u0001\u0010.\u001F(sender);
			\u0013\u0015\u000A.\u000A(u001F, \u000C\u0015\u000A.\u000A(u001F) - (double)\u001A\u0015\u000A.\u000A(e));
			\u0019\u0013\u000A.\u000A(e, true);
		}

		// Token: 0x060015B9 RID: 5561 RVA: 0x0008D024 File Offset: 0x0008B224
		private void LstParameters_OnContextMenuOpening(object sender, ContextMenuEventArgs e)
		{
			if (\u0018\u0013\u000A.\u000A(\u0011\u001A\u0019.\u0007(this.B)) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterControl.LstParameters_OnContextMenuOpening(object, ContextMenuEventArgs)).MethodHandle;
				}
				\u0019\u0013\u000A.\u000A(e, true);
			}
		}

		// Token: 0x060015BA RID: 5562 RVA: 0x0008D064 File Offset: 0x0008B264
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x060015BB RID: 5563 RVA: 0x0008D08C File Offset: 0x0008B28C
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.W)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterControl.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.W = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink/ui/usercontrols/parameters/parametercontrol.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060015BC RID: 5564 RVA: 0x0008D0D4 File Offset: 0x0008B2D4
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.K(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u001D\u0016\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.L = \u000B\u0009\u0010.\u001F(R);
				\u0005\u0019\u0005.\u000A(this.L, new EventHandler(this.CmbFilter_DropDownClosed));
				return;
			case 3:
				this.S = \u0005\u0009\u0010.\u001F(R);
				\u0007\u000C\u0019.\u000A(this.S, new TextChangedEventHandler(this.txtSearch_TextChanged));
				return;
			case 4:
				this.B = \u0016\u000F\u000E.\u001F(R);
				\u001D\u0002\u0019.\u000A(this.B, new ContextMenuEventHandler(this.LstParameters_OnContextMenuOpening));
				return;
			case 5:
				this.U = \u0007\u000F\u000E.\u001F(R);
				return;
			default:
				this.W = true;
				return;
			}
		}

		// Token: 0x0400088F RID: 2191
		private bool F;

		// Token: 0x04000890 RID: 2192
		private bool R;

		// Token: 0x04000891 RID: 2193
		private bool D;

		// Token: 0x04000892 RID: 2194
		private bool H = true;

		// Token: 0x04000893 RID: 2195
		[CompilerGenerated]
		private EventHandler C;

		// Token: 0x04000894 RID: 2196
		public static readonly DependencyProperty TitleProperty = \u001D\u0015\u000A.\u000A("Title", \u001E\u0011\u000A.\u000A(\u001A\u0001\u0010.\u001F()), \u001E\u0011\u000A.\u000A(\u0012\u000F\u000E.\u001F()));

		// Token: 0x04000895 RID: 2197
		public static readonly DependencyProperty ItemSourceProperty = \u000F\u0006\u001D.\u000A("ItemSource", \u001E\u0011\u000A.\u000A(\u0003\u000F\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0012\u000F\u000E.\u001F()), \u0002\u001A\u0019.\u000A(new PropertyChangedCallback(ParameterControl.OnItemSourceChanged)));

		// Token: 0x04000896 RID: 2198
		internal MultiSelectComboBox L;

		// Token: 0x04000897 RID: 2199
		internal WatermarkTextBox S;

		// Token: 0x04000898 RID: 2200
		internal ListView B;

		// Token: 0x04000899 RID: 2201
		internal InvokeCommandAction U;

		// Token: 0x0400089A RID: 2202
		private bool W;
	}
}

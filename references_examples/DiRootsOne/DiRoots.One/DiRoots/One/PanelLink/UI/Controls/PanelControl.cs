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
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.PanelLink.Models;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.UI.Controls;

namespace DiRoots.One.PanelLink.UI.Controls
{
	// Token: 0x0200019A RID: 410
	public class PanelControl : UserControl, IComponentConnector, IStyleConnector
	{
		// Token: 0x06000F28 RID: 3880 RVA: 0x00061108 File Offset: 0x0005F308
		public PanelControl()
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\UI\\UserControls\\PanelControl.xaml.cs", ".ctor");
			\u000B\u001A\u0019.\u000A(this);
			\u0016\u001A\u0019.\u000A(this, new ObservableCollection<DiRoots.One.PanelLink.Models.Panel>());
			this.G();
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\UI\\UserControls\\PanelControl.xaml.cs", ".ctor");
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000F2A RID: 3882 RVA: 0x000611B0 File Offset: 0x0005F3B0
		// (remove) Token: 0x06000F2B RID: 3883 RVA: 0x00061200 File Offset: 0x0005F400
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
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.add_CheckedChangedEvent(EventHandler)).MethodHandle;
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
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.remove_CheckedChangedEvent(EventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06000F2C RID: 3884 RVA: 0x00061250 File Offset: 0x0005F450
		// (set) Token: 0x06000F2D RID: 3885 RVA: 0x00061264 File Offset: 0x0005F464
		public PanelControl.ContextMenuDelegate OpenView { get; set; }

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06000F2E RID: 3886 RVA: 0x00061278 File Offset: 0x0005F478
		// (set) Token: 0x06000F2F RID: 3887 RVA: 0x0006129C File Offset: 0x0005F49C
		public ObservableCollection<DiRoots.One.PanelLink.Models.Panel> ItemSource
		{
			get
			{
				return \u0016\u0016\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, PanelControl.ItemSourceProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, PanelControl.ItemSourceProperty, value);
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06000F30 RID: 3888 RVA: 0x000612B8 File Offset: 0x0005F4B8
		// (set) Token: 0x06000F31 RID: 3889 RVA: 0x000612CC File Offset: 0x0005F4CC
		public ObservableCollection<DiRoots.One.PanelLink.Models.Panel> SelectedItems { get; set; }

		// Token: 0x06000F32 RID: 3890 RVA: 0x000612E0 File Offset: 0x0005F4E0
		private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			PanelControl panelControl = \u0005\u0016\u000E.\u001F(d);
			if (panelControl == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.OnSourceChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			ICollectionView collectionView = \u0011\u0009\u000A.\u000A(\u0006\u001A\u0019.\u0007(panelControl));
			\u0005\u0008\u0007.\u000A(collectionView, new Predicate<object>(panelControl.P));
			\u0018\u000C\u0007.\u000A(panelControl.S, collectionView);
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x0006133C File Offset: 0x0005F53C
		private void CheckBox_Click(object sender, RoutedEventArgs e)
		{
			this.O(sender);
		}

		// Token: 0x06000F34 RID: 3892 RVA: 0x00061350 File Offset: 0x0005F550
		private void txtSearchFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (\u001E\u0009\u000A.\u0007(this.S) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.txtSearchFilter_TextChanged(object, TextChangedEventArgs)).MethodHandle;
				}
				return;
			}
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.S)));
			EventHandler f = this.F;
			if (f == null)
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
			\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
		}

		// Token: 0x06000F35 RID: 3893 RVA: 0x000613BC File Offset: 0x0005F5BC
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.chkSelectAll_Click(object, RoutedEventArgs)).MethodHandle;
				}
				bool? flag = \u0003\u0015\u000A.\u000A(checkBox);
				IEnumerator u001F;
				if (\u0012\u0015\u000A.\u000A(ref flag))
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
					u001F = \u001D\u0011\u000A.\u000A(\u0010\u000C\u0007.\u000A(this.S));
					try
					{
						while (\u000A\u0017\u000A.\u000A(u001F))
						{
							\u001B\u001E\u0019.\u000A(\u0004\u0016\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F)), true);
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
						goto IL_101;
					}
					finally
					{
						IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
						if (disposable != null)
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
							\u001F\u0017\u000A.\u000A(disposable);
						}
					}
				}
				u001F = \u001D\u0011\u000A.\u000A(\u0010\u000C\u0007.\u000A(this.S));
				try
				{
					while (\u000A\u0017\u000A.\u000A(u001F))
					{
						\u001B\u001E\u0019.\u000A(\u0004\u0016\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F)), false);
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
				finally
				{
					IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
					if (disposable != null)
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
						\u001F\u0017\u000A.\u000A(disposable);
					}
				}
				IL_101:
				IEnumerable<DiRoots.One.PanelLink.Models.Panel> enumerable = \u0006\u001A\u0019.\u001D(this);
				Func<DiRoots.One.PanelLink.Models.Panel, bool> func;
				if ((func = PanelControl.<>c.\u000A) == null)
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
					func = (PanelControl.<>c.\u000A = new Func<DiRoots.One.PanelLink.Models.Panel, bool>(PanelControl.<>c.\u001F.\u001E));
				}
				\u0016\u001A\u0019.\u000A(this, \u000F\u001A\u0019.\u000A(Enumerable.Where<DiRoots.One.PanelLink.Models.Panel>(enumerable, func)));
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
					return;
				}
				\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
			}
		}

		// Token: 0x06000F36 RID: 3894 RVA: 0x0006154C File Offset: 0x0005F74C
		private void chkHideUnCheckedItems_Click(object sender, RoutedEventArgs e)
		{
			if (\u001E\u0009\u000A.\u0007(this.S) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.chkHideUnCheckedItems_Click(object, RoutedEventArgs)).MethodHandle;
				}
				return;
			}
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.S)));
		}

		// Token: 0x06000F37 RID: 3895 RVA: 0x00061598 File Offset: 0x0005F798
		public void Reset()
		{
			\u000D\u000C\u0007.\u000A(this.H, new bool?(false));
			\u000D\u000C\u0007.\u000A(this.B, new bool?(false));
			\u001C\u001A\u0019.\u000A(this.L, "");
			IEnumerator<DiRoots.One.PanelLink.Models.Panel> enumerator = \u000B\u0014\u0019.\u000A(\u0006\u001A\u0019.\u001D(this));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u001B\u001E\u0019.\u000A(\u0016\u0014\u0019.\u000A(enumerator), false);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.Reset()).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			\u0019\u0014\u0019.\u000A(this.U, \u0003\u001A\u0019.\u000A());
			\u0012\u001A\u0019.\u000A(this.U);
			\u0019\u0014\u0019.\u000A(this.W, \u0003\u001A\u0019.\u000A());
			\u0012\u001A\u0019.\u000A(this.W);
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u0006\u001A\u0019.\u001D(this)));
		}

		// Token: 0x06000F38 RID: 3896 RVA: 0x00061688 File Offset: 0x0005F888
		internal bool P(object F)
		{
			DiRoots.One.PanelLink.Models.Panel panel = \u0018\u0016\u000E.\u001F(F);
			if (panel == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.P(object)).MethodHandle;
				}
				return false;
			}
			bool flag = true;
			if (!\u001A\u0006\u0007.\u000A(\u0010\u001A\u0019.\u000A(this.L)))
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
				flag = \u000D\u0008\u000A.\u001F(\u000E\u001A\u0019.\u000A(panel), \u0010\u001A\u0019.\u000A(this.L));
			}
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
				bool? flag2 = \u0003\u0015\u000A.\u000A(this.B);
				if (\u0012\u0015\u000A.\u000A(ref flag2))
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
					flag = \u0005\u0014\u0019.\u000A(panel);
				}
			}
			\u000D\u001A\u0019.\u000A(panel, flag);
			return flag;
		}

		// Token: 0x06000F39 RID: 3897 RVA: 0x00061738 File Offset: 0x0005F938
		private void O(object F)
		{
			CheckBox checkBox = \u0011\u000A\u000E.\u001F(F);
			if (checkBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.O(object)).MethodHandle;
				}
				DiRoots.One.PanelLink.Models.Panel panel = \u0018\u0016\u000E.\u001F(\u0007\u000C\u000A.\u0007(checkBox));
				if (panel != null)
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
					PanelControl.\u000C\u0002 u000C_u = new PanelControl.\u000C\u0002();
					u000C_u.\u001F = \u0005\u0014\u0019.\u000A(panel);
					List<DiRoots.One.PanelLink.Models.Panel> u001F = Enumerable.ToList<DiRoots.One.PanelLink.Models.Panel>(Enumerable.Cast<DiRoots.One.PanelLink.Models.Panel>(\u0011\u001A\u0019.\u0007(this.S)));
					if (\u001B\u001A\u0019.\u000A(u001F, panel))
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
						\u0008\u001A\u0019.\u000A(u001F, new Action<DiRoots.One.PanelLink.Models.Panel>(u000C_u.\u000A));
					}
					IEnumerable<DiRoots.One.PanelLink.Models.Panel> enumerable = \u0006\u001A\u0019.\u001D(this);
					Func<DiRoots.One.PanelLink.Models.Panel, bool> func;
					if ((func = PanelControl.<>c.\u0007) == null)
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
						func = (PanelControl.<>c.\u0007 = new Func<DiRoots.One.PanelLink.Models.Panel, bool>(PanelControl.<>c.\u001F.\u0020));
					}
					\u0016\u001A\u0019.\u000A(this, \u000F\u001A\u0019.\u000A(Enumerable.Where<DiRoots.One.PanelLink.Models.Panel>(enumerable, func)));
					EventHandler f = this.F;
					if (f == null)
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
						return;
					}
					\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
				}
			}
		}

		// Token: 0x06000F3A RID: 3898 RVA: 0x00061844 File Offset: 0x0005FA44
		private void LblInstance_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			this.T(\u001E\u001A\u0019.\u0007(this.U));
			this.T(\u001E\u001A\u0019.\u0007(this.W));
		}

		// Token: 0x06000F3B RID: 3899 RVA: 0x00061878 File Offset: 0x0005FA78
		private void LblType_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			this.I(\u001E\u001A\u0019.\u0007(this.U));
			this.I(\u001E\u001A\u0019.\u0007(this.W));
		}

		// Token: 0x06000F3C RID: 3900 RVA: 0x000618AC File Offset: 0x0005FAAC
		private void T(ObservableCollection<BaseParameter> F)
		{
			if (F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.T(ObservableCollection<BaseParameter>)).MethodHandle;
				}
				return;
			}
			Func<BaseParameter, bool> func;
			if ((func = PanelControl.<>c.\u001D) == null)
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
				func = (PanelControl.<>c.\u001D = new Func<BaseParameter, bool>(PanelControl.<>c.\u001F.\u0017));
			}
			object u001F = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(F, func));
			Action<BaseParameter> u000A;
			if ((u000A = PanelControl.<>c.\u0004) == null)
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
				u000A = (PanelControl.<>c.\u0004 = new Action<BaseParameter>(PanelControl.<>c.\u001F.\u0014));
			}
			\u0020\u001A\u0019.\u000A(u001F, u000A);
			Func<BaseParameter, bool> func2;
			if ((func2 = PanelControl.<>c.\u0019) == null)
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
				func2 = (PanelControl.<>c.\u0019 = new Func<BaseParameter, bool>(PanelControl.<>c.\u001F.\u0013));
			}
			object u001F2 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(F, func2));
			Action<BaseParameter> u000A2;
			if ((u000A2 = PanelControl.<>c.\u0018) == null)
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
				u000A2 = (PanelControl.<>c.\u0018 = new Action<BaseParameter>(PanelControl.<>c.\u001F.\u001A));
			}
			\u0020\u001A\u0019.\u000A(u001F2, u000A2);
			Func<BaseParameter, bool> func3;
			if ((func3 = PanelControl.<>c.\u0005) == null)
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
				func3 = (PanelControl.<>c.\u0005 = new Func<BaseParameter, bool>(PanelControl.<>c.\u001F.\u000C));
			}
			object u001F3 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(F, func3));
			Action<BaseParameter> u000A3;
			if ((u000A3 = PanelControl.<>c.\u0016) == null)
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
				u000A3 = (PanelControl.<>c.\u0016 = new Action<BaseParameter>(PanelControl.<>c.\u001F.\u0015));
			}
			\u0020\u001A\u0019.\u000A(u001F3, u000A3);
			this.A(F);
		}

		// Token: 0x06000F3D RID: 3901 RVA: 0x00061A0C File Offset: 0x0005FC0C
		private void I(ObservableCollection<BaseParameter> F)
		{
			if (F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.I(ObservableCollection<BaseParameter>)).MethodHandle;
				}
				return;
			}
			Func<BaseParameter, bool> func;
			if ((func = PanelControl.<>c.\u000B) == null)
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
				func = (PanelControl.<>c.\u000B = new Func<BaseParameter, bool>(PanelControl.<>c.\u001F.\u0001));
			}
			object u001F = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(F, func));
			Action<BaseParameter> u000A;
			if ((u000A = PanelControl.<>c.\u0002) == null)
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
				u000A = (PanelControl.<>c.\u0002 = new Action<BaseParameter>(PanelControl.<>c.\u001F.\u0009));
			}
			\u0020\u001A\u0019.\u000A(u001F, u000A);
			Func<BaseParameter, bool> func2;
			if ((func2 = PanelControl.<>c.\u0006) == null)
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
				func2 = (PanelControl.<>c.\u0006 = new Func<BaseParameter, bool>(PanelControl.<>c.\u001F.\u001F\u000A));
			}
			object u001F2 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(F, func2));
			Action<BaseParameter> u000A2;
			if ((u000A2 = PanelControl.<>c.\u000F) == null)
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
				u000A2 = (PanelControl.<>c.\u000F = new Action<BaseParameter>(PanelControl.<>c.\u001F.\u000A\u000A));
			}
			\u0020\u001A\u0019.\u000A(u001F2, u000A2);
			Func<BaseParameter, bool> func3;
			if ((func3 = PanelControl.<>c.\u0012) == null)
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
				func3 = (PanelControl.<>c.\u0012 = new Func<BaseParameter, bool>(PanelControl.<>c.\u001F.\u0007\u000A));
			}
			object u001F3 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(F, func3));
			Action<BaseParameter> u000A3;
			if ((u000A3 = PanelControl.<>c.\u0003) == null)
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
				u000A3 = (PanelControl.<>c.\u0003 = new Action<BaseParameter>(PanelControl.<>c.\u001F.\u001D\u000A));
			}
			\u0020\u001A\u0019.\u000A(u001F3, u000A3);
			this.A(F);
		}

		// Token: 0x06000F3E RID: 3902 RVA: 0x00061B6C File Offset: 0x0005FD6C
		private void LblReadonly_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			this.Q(\u001E\u001A\u0019.\u0007(this.U));
			this.Q(\u001E\u001A\u0019.\u0007(this.W));
		}

		// Token: 0x06000F3F RID: 3903 RVA: 0x00061BA0 File Offset: 0x0005FDA0
		private void Q(ObservableCollection<BaseParameter> F)
		{
			if (F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.Q(ObservableCollection<BaseParameter>)).MethodHandle;
				}
				return;
			}
			Func<BaseParameter, bool> func;
			if ((func = PanelControl.<>c.\u001C) == null)
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
				func = (PanelControl.<>c.\u001C = new Func<BaseParameter, bool>(PanelControl.<>c.\u001F.\u0004\u000A));
			}
			object u001F = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(F, func));
			Action<BaseParameter> u000A;
			if ((u000A = PanelControl.<>c.\u000D) == null)
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
				u000A = (PanelControl.<>c.\u000D = new Action<BaseParameter>(PanelControl.<>c.\u001F.\u0019\u000A));
			}
			\u0020\u001A\u0019.\u000A(u001F, u000A);
			Func<BaseParameter, bool> func2;
			if ((func2 = PanelControl.<>c.\u0010) == null)
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
				func2 = (PanelControl.<>c.\u0010 = new Func<BaseParameter, bool>(PanelControl.<>c.\u001F.\u0018\u000A));
			}
			object u001F2 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(F, func2));
			Action<BaseParameter> u000A2;
			if ((u000A2 = PanelControl.<>c.\u000E) == null)
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
				u000A2 = (PanelControl.<>c.\u000E = new Action<BaseParameter>(PanelControl.<>c.\u001F.\u0005\u000A));
			}
			\u0020\u001A\u0019.\u000A(u001F2, u000A2);
			Func<BaseParameter, bool> func3;
			if ((func3 = PanelControl.<>c.\u0008) == null)
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
				func3 = (PanelControl.<>c.\u0008 = new Func<BaseParameter, bool>(PanelControl.<>c.\u001F.\u0016\u000A));
			}
			object u001F3 = Enumerable.ToList<BaseParameter>(Enumerable.Where<BaseParameter>(F, func3));
			Action<BaseParameter> u000A3;
			if ((u000A3 = PanelControl.<>c.\u001B) == null)
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
				u000A3 = (PanelControl.<>c.\u001B = new Action<BaseParameter>(PanelControl.<>c.\u001F.\u000B\u000A));
			}
			\u0020\u001A\u0019.\u000A(u001F3, u000A3);
			this.A(F);
		}

		// Token: 0x06000F40 RID: 3904 RVA: 0x00061D00 File Offset: 0x0005FF00
		private void A(ObservableCollection<BaseParameter> F)
		{
			ICollectionView u001F = \u0011\u0009\u000A.\u000A(F);
			\u0013\u001A\u0019.\u000A(\u0014\u001A\u0019.\u000A(u001F));
			\u0017\u001A\u0019.\u000A(\u0014\u001A\u0019.\u000A(u001F), new SortDescription("OrderIndex", ListSortDirection.Ascending));
			\u0017\u001A\u0019.\u000A(\u0014\u001A\u0019.\u000A(u001F), new SortDescription("Name", ListSortDirection.Ascending));
			\u0014\u0003\u0007.\u000A(u001F);
		}

		// Token: 0x06000F41 RID: 3905 RVA: 0x00061D58 File Offset: 0x0005FF58
		private void ChkList_OnKeyUp(object sender, KeyEventArgs e)
		{
			if (\u001A\u001A\u0019.\u000A(e) == Key.Space)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.ChkList_OnKeyUp(object, KeyEventArgs)).MethodHandle;
				}
				if (\u0019\u000C\u0007.\u001D(this.S) != null)
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
					DiRoots.One.PanelLink.Models.Panel u001F = \u0004\u0016\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.S));
					\u001B\u001E\u0019.\u000A(u001F, !\u0005\u0014\u0019.\u000A(u001F));
					IEnumerable<DiRoots.One.PanelLink.Models.Panel> enumerable = \u0006\u001A\u0019.\u001D(this);
					Func<DiRoots.One.PanelLink.Models.Panel, bool> func;
					if ((func = PanelControl.<>c.\u0011) == null)
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
						func = (PanelControl.<>c.\u0011 = new Func<DiRoots.One.PanelLink.Models.Panel, bool>(PanelControl.<>c.\u001F.\u0002\u000A));
					}
					\u0016\u001A\u0019.\u000A(this, \u000F\u001A\u0019.\u000A(Enumerable.Where<DiRoots.One.PanelLink.Models.Panel>(enumerable, func)));
					EventHandler f = this.F;
					if (f == null)
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
					\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
				}
			}
		}

		// Token: 0x06000F42 RID: 3906 RVA: 0x00061E2C File Offset: 0x0006002C
		private void G()
		{
			\u000A\u0016\u0019.\u000A(this.S, \u0007\u0016\u0019.\u000A());
			\u0015\u001A\u0019.\u000A(\u001F\u0016\u0019.\u000A(this.S), "openMenu");
			MenuItem menuItem = \u0019\u0016\u000E.\u001F;
			MenuItem menuItem2 = \u0002\u0016\u0019.\u000A();
			\u000B\u0016\u0019.\u000A(menuItem2, \u000C\u001A\u0019.\u000A());
			menuItem = menuItem2;
			\u0018\u0016\u0019.\u000A(menuItem, new RoutedEventHandler(this.MenuItem_Click));
			\u0001\u0005\u0019.\u000A(\u0010\u000C\u0007.\u000A(\u001F\u0016\u0019.\u000A(this.S)), menuItem);
		}

		// Token: 0x06000F43 RID: 3907 RVA: 0x00061EAC File Offset: 0x000600AC
		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			if (\u0018\u0013\u000A.\u000A(\u0011\u001A\u0019.\u0007(this.S)) >= 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.MenuItem_Click(object, RoutedEventArgs)).MethodHandle;
				}
				DiRoots.One.PanelLink.Models.Panel u001F = \u0004\u0016\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.S));
				PanelControl.ContextMenuDelegate contextMenuDelegate = \u001F\u0014\u0019.\u001D(this);
				if (contextMenuDelegate == null)
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
				\u0001\u001A\u0019.\u000A(contextMenuDelegate, \u000E\u001A\u0019.\u000A(u001F));
			}
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x00061F1C File Offset: 0x0006011C
		private void ChkList_ContextMenuOpening(object sender, ContextMenuEventArgs e)
		{
			if (\u0018\u0013\u000A.\u000A(\u0011\u001A\u0019.\u0007(this.S)) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.ChkList_ContextMenuOpening(object, ContextMenuEventArgs)).MethodHandle;
				}
				\u0009\u001A\u0019.\u000A(\u001F\u0016\u0019.\u000A(this.S), false);
			}
		}

		// Token: 0x06000F45 RID: 3909 RVA: 0x00061F68 File Offset: 0x00060168
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x06000F46 RID: 3910 RVA: 0x00061F90 File Offset: 0x00060190
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.N)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.N = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/panellink/ui/usercontrols/panelcontrol.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x00061FD8 File Offset: 0x000601D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate FR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06000F48 RID: 3912 RVA: 0x00061FF0 File Offset: 0x000601F0
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.M(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u000A\u0016\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.H = \u0016\u0009\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.H, new RoutedEventHandler(this.chkSelectAll_Click));
				return;
			case 3:
				this.C = \u001A\u000A\u000E.\u001F(R);
				return;
			case 4:
				this.L = \u0005\u0009\u0010.\u001F(R);
				\u0007\u000C\u0019.\u000A(this.L, new TextChangedEventHandler(this.txtSearchFilter_TextChanged));
				return;
			case 5:
				this.S = \u0007\u0016\u000E.\u001F(R);
				\u001D\u0002\u0019.\u000A(this.S, new ContextMenuEventHandler(this.ChkList_ContextMenuOpening));
				\u000A\u000C\u0019.\u000A(this.S, new KeyEventHandler(this.ChkList_OnKeyUp));
				return;
			case 7:
				this.B = \u0016\u0009\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.B, new RoutedEventHandler(this.chkHideUnCheckedItems_Click));
				return;
			case 8:
				this.U = \u001D\u0016\u000E.\u001F(R);
				return;
			case 9:
				this.W = \u001D\u0016\u000E.\u001F(R);
				return;
			case 10:
				this.K = \u001A\u000A\u000E.\u001F(R);
				\u001F\u000C\u0019.\u000A(this.K, new MouseButtonEventHandler(this.LblInstance_OnMouseLeftButtonUp));
				return;
			case 11:
				this.J = \u001A\u000A\u000E.\u001F(R);
				\u001F\u000C\u0019.\u000A(this.J, new MouseButtonEventHandler(this.LblType_OnMouseLeftButtonUp));
				return;
			case 12:
				this.E = \u001A\u000A\u000E.\u001F(R);
				\u001F\u000C\u0019.\u000A(this.E, new MouseButtonEventHandler(this.LblReadonly_OnMouseLeftButtonUp));
				return;
			}
			this.N = true;
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x000621AC File Offset: 0x000603AC
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IStyleConnector.V(int F, object R)
		{
			if (F == 6)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PanelControl.V(int, object)).MethodHandle;
				}
				\u0010\u0015\u000A.\u000A(\u0016\u0009\u0010.\u001F(R), new RoutedEventHandler(this.CheckBox_Click));
			}
		}

		// Token: 0x040005F7 RID: 1527
		[CompilerGenerated]
		private EventHandler F;

		// Token: 0x040005F8 RID: 1528
		[CompilerGenerated]
		private PanelControl.ContextMenuDelegate R;

		// Token: 0x040005F9 RID: 1529
		[CompilerGenerated]
		private ObservableCollection<DiRoots.One.PanelLink.Models.Panel> D;

		// Token: 0x040005FA RID: 1530
		public static readonly DependencyProperty ItemSourceProperty = \u000F\u0006\u001D.\u000A("ItemSource", \u001E\u0011\u000A.\u000A(\u000B\u0016\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0002\u0016\u000E.\u001F()), \u0002\u001A\u0019.\u000A(new PropertyChangedCallback(PanelControl.OnSourceChanged)));

		// Token: 0x040005FB RID: 1531
		internal CheckBox H;

		// Token: 0x040005FC RID: 1532
		internal Label C;

		// Token: 0x040005FD RID: 1533
		internal WatermarkTextBox L;

		// Token: 0x040005FE RID: 1534
		internal ListBox S;

		// Token: 0x040005FF RID: 1535
		internal CheckBox B;

		// Token: 0x04000600 RID: 1536
		internal ParameterControl U;

		// Token: 0x04000601 RID: 1537
		internal ParameterControl W;

		// Token: 0x04000602 RID: 1538
		internal Label K;

		// Token: 0x04000603 RID: 1539
		internal Label J;

		// Token: 0x04000604 RID: 1540
		internal Label E;

		// Token: 0x04000605 RID: 1541
		private bool N;

		// Token: 0x02000869 RID: 2153
		// (Invoke) Token: 0x06004EF0 RID: 20208
		public delegate void ContextMenuDelegate(string viewName);

		// Token: 0x0200086B RID: 2155
		[CompilerGenerated]
		private sealed class \u000C\u0002
		{
			// Token: 0x06004F0B RID: 20235 RVA: 0x001E1D08 File Offset: 0x001DFF08
			internal void \u000A(DiRoots.One.PanelLink.Models.Panel \u001F)
			{
				\u001B\u001E\u0019.\u000A(\u001F, this.\u001F);
			}

			// Token: 0x04002179 RID: 8569
			public bool \u001F;
		}
	}
}

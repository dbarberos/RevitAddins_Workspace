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
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.ViewModels;

namespace DiRoots.One.SheetLink.UI.Controls
{
	// Token: 0x0200021F RID: 543
	public class CategoryNavigator : UserControl, IComponentConnector, IStyleConnector
	{
		// Token: 0x060014ED RID: 5357 RVA: 0x00088640 File Offset: 0x00086840
		public CategoryNavigator()
		{
			\u0015\u0004\u0005.\u000A(this);
			\u000C\u0004\u0005.\u000A(this, new ObservableCollection<ICategoryModel>());
			ItemNavigatorModel.EVR(this.C);
		}

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x060014EF RID: 5359 RVA: 0x000886C0 File Offset: 0x000868C0
		// (remove) Token: 0x060014F0 RID: 5360 RVA: 0x00088710 File Offset: 0x00086910
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
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryNavigator.add_CheckedChangedEvent(EventHandler)).MethodHandle;
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryNavigator.remove_CheckedChangedEvent(EventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x060014F1 RID: 5361 RVA: 0x00088760 File Offset: 0x00086960
		// (set) Token: 0x060014F2 RID: 5362 RVA: 0x00088784 File Offset: 0x00086984
		public ObservableCollection<ICategoryModel> ItemSource
		{
			get
			{
				return \u0010\u0006\u000E.\u001F(\u0004\u0015\u000A.\u0007(this, CategoryNavigator.ItemSourceProperty));
			}
			set
			{
				\u0019\u0015\u000A.\u0007(this, CategoryNavigator.ItemSourceProperty, value);
			}
		}

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x060014F3 RID: 5363 RVA: 0x000887A0 File Offset: 0x000869A0
		// (set) Token: 0x060014F4 RID: 5364 RVA: 0x000887B4 File Offset: 0x000869B4
		public ObservableCollection<ICategoryModel> SelectedItems { get; set; }

		// Token: 0x060014F5 RID: 5365 RVA: 0x000887C8 File Offset: 0x000869C8
		private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			CategoryNavigator categoryNavigator = \u000D\u0006\u000E.\u001F(d);
			if (categoryNavigator != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryNavigator.OnSourceChanged(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				if (\u0001\u0004\u0005.\u0007(categoryNavigator) != null)
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
					ICollectionView collectionView = \u0011\u0009\u000A.\u000A(\u0001\u0004\u0005.\u0007(categoryNavigator));
					\u0005\u0008\u0007.\u000A(collectionView, new Predicate<object>(categoryNavigator.E));
					\u0018\u000C\u0007.\u000A(categoryNavigator.S, collectionView);
					\u001F\u001A\u0018.\u001D(\u0015\u0014\u0018.\u000A(categoryNavigator));
					IEnumerable<ICategoryModel> enumerable = Enumerable.Cast<ICategoryModel>(\u001E\u0009\u000A.\u0007(categoryNavigator.S));
					Func<ICategoryModel, bool> func;
					if ((func = CategoryNavigator.<>c.\u000A) == null)
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
						func = (CategoryNavigator.<>c.\u000A = new Func<ICategoryModel, bool>(CategoryNavigator.<>c.\u001F.\u0019));
					}
					IEnumerator<ICategoryModel> enumerator = \u0013\u001C\u0018.\u000A(Enumerable.Where<ICategoryModel>(enumerable, func));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							ICategoryModel u000A = \u0014\u001C\u0018.\u000A(enumerator);
							\u0014\u0013\u0018.\u000A(\u0015\u0014\u0018.\u000A(categoryNavigator), u000A);
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
					categoryNavigator.M();
				}
			}
		}

		// Token: 0x060014F6 RID: 5366 RVA: 0x000888F0 File Offset: 0x00086AF0
		private void txtSearchFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			this.J();
		}

		// Token: 0x060014F7 RID: 5367 RVA: 0x00088904 File Offset: 0x00086B04
		private void chkSelectAll_Click(object sender, RoutedEventArgs e)
		{
			CheckBox checkBox = \u0011\u000A\u000E.\u001F(sender);
			if (checkBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryNavigator.chkSelectAll_Click(object, RoutedEventArgs)).MethodHandle;
				}
				bool? flag = \u0003\u0015\u000A.\u000A(checkBox);
				bool u000A = \u0012\u0015\u000A.\u000A(ref flag);
				IEnumerator u001F = \u001D\u0011\u000A.\u000A(\u0010\u000C\u0007.\u000A(this.S));
				try
				{
					while (\u000A\u0017\u000A.\u000A(u001F))
					{
						ICategoryModel categoryModel = \u001C\u0006\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F));
						if (categoryModel != null)
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
							\u0013\u0013\u0018.\u000A(categoryModel, u000A);
						}
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
				IEnumerable<ICategoryModel> enumerable = \u0001\u0004\u0005.\u001D(this);
				Func<ICategoryModel, bool> func;
				if ((func = CategoryNavigator.<>c.\u0007) == null)
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
					func = (CategoryNavigator.<>c.\u0007 = new Func<ICategoryModel, bool>(CategoryNavigator.<>c.\u001F.\u0018));
				}
				\u000C\u0004\u0005.\u000A(this, \u0007\u000C\u0018.\u000A(Enumerable.Where<ICategoryModel>(enumerable, func)));
				EventHandler f = this.F;
				if (f == null)
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
				\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
			}
		}

		// Token: 0x060014F8 RID: 5368 RVA: 0x00088A30 File Offset: 0x00086C30
		private void chkHideUnCheckedItems_Click(object sender, RoutedEventArgs e)
		{
			this.J();
		}

		// Token: 0x060014F9 RID: 5369 RVA: 0x00088A44 File Offset: 0x00086C44
		private void CmbFilter_DropDownClosed(object sender, EventArgs e)
		{
			this.J();
		}

		// Token: 0x060014FA RID: 5370 RVA: 0x00088A58 File Offset: 0x00086C58
		private void CheckBox_Click(object sender, RoutedEventArgs e)
		{
			this.N(sender);
		}

		// Token: 0x060014FB RID: 5371 RVA: 0x00088A6C File Offset: 0x00086C6C
		public void Reset()
		{
			\u000D\u000C\u0007.\u000A(this.D, new bool?(false));
			\u000D\u000C\u0007.\u000A(this.B, new bool?(false));
			\u001C\u001A\u0019.\u000A(this.L, "");
			IEnumerator<ICategoryModel> enumerator = \u0009\u0004\u0005.\u000A(\u0001\u0004\u0005.\u001D(this));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					\u0013\u0013\u0018.\u000A(\u0014\u001C\u0018.\u000A(enumerator), false);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryNavigator.Reset()).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			ItemNavigatorModel.EVR(this.C);
			this.J();
		}

		// Token: 0x060014FC RID: 5372 RVA: 0x00088B20 File Offset: 0x00086D20
		private void J()
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryNavigator.J()).MethodHandle;
				}
				return;
			}
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.S)));
			this.M();
		}

		// Token: 0x060014FD RID: 5373 RVA: 0x00088B70 File Offset: 0x00086D70
		internal bool E(object F)
		{
			CategoryNavigator.\u0013\u0003 u0013_u = new CategoryNavigator.\u0013\u0003();
			ICategoryModel categoryModel = \u001C\u0006\u000E.\u001F(F);
			if (categoryModel == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryNavigator.E(object)).MethodHandle;
				}
				return false;
			}
			u0013_u.\u001F = \u0014\u000D\u0007.\u000A();
			List<object> u001F = Enumerable.ToList<object>(\u001D\u0019\u0005.\u000A(\u0004\u0019\u0005.\u000A(this.C)));
			if (\u0007\u0019\u0005.\u000A(u001F, "All"))
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
				\u000A\u0019\u0005.\u000A(u001F, "All");
			}
			List<object>.Enumerator enumerator = \u0017\u0015\u0019.\u000A(u001F);
			try
			{
				while (\u0011\u0015\u0019.\u000A(ref enumerator))
				{
					int num = \u0005\u0005\u000E.\u001F(\u0020\u0015\u0019.\u000A(ref enumerator));
					\u001A\u0008\u0007.\u000A(u0013_u.\u001F, \u000C\u0013\u0007.\u000A(ref num));
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
			bool flag = Enumerable.Any<string>(\u000F\u001C\u0018.\u000A(categoryModel), new Func<string, bool>(u0013_u.\u000A));
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
				if (!\u001A\u0006\u0007.\u000A(\u0010\u001A\u0019.\u000A(this.L)))
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
					flag = \u000D\u0008\u000A.\u001F(\u000B\u0015\u0018.\u000A(categoryModel), \u0010\u001A\u0019.\u000A(this.L));
				}
			}
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
				bool? flag2 = \u0003\u0015\u000A.\u000A(this.B);
				if (\u0012\u0015\u000A.\u000A(ref flag2))
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
					flag = \u001D\u000C\u0018.\u000A(categoryModel);
				}
			}
			\u001F\u0019\u0005.\u000A(categoryModel, flag);
			return flag;
		}

		// Token: 0x060014FE RID: 5374 RVA: 0x00088D04 File Offset: 0x00086F04
		private void N(object F)
		{
			CategoryNavigator.\u001A\u0003 u001A_u = new CategoryNavigator.\u001A\u0003();
			CheckBox checkBox = \u0011\u000A\u000E.\u001F(F);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryNavigator.N(object)).MethodHandle;
				}
				object u001F = \u0007\u000C\u000A.\u0007(checkBox);
				u001A_u.\u001F = \u001C\u0006\u000E.\u001F(u001F);
				if (u001A_u.\u001F != null)
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
					List<ICategoryModel> u001F2 = Enumerable.ToList<ICategoryModel>(Enumerable.Cast<ICategoryModel>(\u0011\u001A\u0019.\u0007(this.S)));
					if (\u0019\u0019\u0005.\u000A(u001F2, u001A_u.\u001F))
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
						\u001B\u0015\u0018.\u000A(u001F2, new Action<ICategoryModel>(u001A_u.\u000A));
					}
					IEnumerable<ICategoryModel> enumerable = \u0001\u0004\u0005.\u001D(this);
					Func<ICategoryModel, bool> func;
					if ((func = CategoryNavigator.<>c.\u001D) == null)
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
						func = (CategoryNavigator.<>c.\u001D = new Func<ICategoryModel, bool>(CategoryNavigator.<>c.\u001F.\u0005));
					}
					\u000C\u0004\u0005.\u000A(this, \u0007\u000C\u0018.\u000A(Enumerable.Where<ICategoryModel>(enumerable, func)));
					EventHandler f = this.F;
					if (f == null)
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
					}
					else
					{
						\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
					}
					this.M();
				}
			}
		}

		// Token: 0x060014FF RID: 5375 RVA: 0x00088E1C File Offset: 0x0008701C
		public List<Disciplines> GetFilterItems()
		{
			return Enumerable.ToList<Disciplines>(Enumerable.Cast<Disciplines>(\u001D\u0019\u0005.\u000A(\u0018\u0019\u0005.\u000A(this.C))));
		}

		// Token: 0x06001500 RID: 5376 RVA: 0x00088E4C File Offset: 0x0008704C
		public void SetFilterItems(List<Disciplines> value)
		{
			Dictionary<string, object> dictionary = \u0006\u0014\u0018.\u000A();
			List<Disciplines>.Enumerator enumerator = \u000B\u0014\u0018.\u000A(value);
			try
			{
				while (\u0009\u0017\u0018.\u000A(ref enumerator))
				{
					Disciplines disciplines = \u0016\u0014\u0018.\u000A(ref enumerator);
					\u001F\u0014\u0018.\u000A(dictionary, disciplines.ToString(), disciplines);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryNavigator.SetFilterItems(List<Disciplines>)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u000C\u0017\u0018.\u000A(this.C, dictionary);
			this.J();
		}

		// Token: 0x06001501 RID: 5377 RVA: 0x00088EE4 File Offset: 0x000870E4
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryNavigator.ChkList_OnKeyUp(object, KeyEventArgs)).MethodHandle;
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
					ICategoryModel categoryModel = \u001C\u0006\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.S));
					if (categoryModel != null)
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
						\u0013\u0013\u0018.\u000A(categoryModel, !\u001D\u000C\u0018.\u000A(categoryModel));
					}
					IEnumerable<ICategoryModel> enumerable = \u0001\u0004\u0005.\u001D(this);
					Func<ICategoryModel, bool> func;
					if ((func = CategoryNavigator.<>c.\u0004) == null)
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
						func = (CategoryNavigator.<>c.\u0004 = new Func<ICategoryModel, bool>(CategoryNavigator.<>c.\u001F.\u0016));
					}
					\u000C\u0004\u0005.\u000A(this, \u0007\u000C\u0018.\u000A(Enumerable.Where<ICategoryModel>(enumerable, func)));
					EventHandler f = this.F;
					if (f == null)
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
					}
					else
					{
						\u001E\u001A\u000A.\u000A(f, this, EventArgs.Empty);
					}
					this.M();
				}
			}
		}

		// Token: 0x06001502 RID: 5378 RVA: 0x00088FD0 File Offset: 0x000871D0
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u001C\u000C\u000A.\u000A(\u000D\u000C\u000A.\u000A(\u0010\u000C\u000A.\u000A(this)));
			\u0003\u000C\u000A.\u0007(this);
		}

		// Token: 0x06001503 RID: 5379 RVA: 0x00088FF8 File Offset: 0x000871F8
		internal void M()
		{
			\u000D\u000C\u0007.\u000A(this.D, \u0001\u0003.\u001F(\u001E\u0009\u000A.\u0007(this.S)));
		}

		// Token: 0x06001504 RID: 5380 RVA: 0x00089024 File Offset: 0x00087224
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.U)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryNavigator.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.U = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink.core/ui/usercontrols/categorynavigator/categorynavigator.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001505 RID: 5381 RVA: 0x0008906C File Offset: 0x0008726C
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.W(int F, object R)
		{
			switch (F)
			{
			case 1:
				\u0011\u000C\u000A.\u0007(\u0003\u0006\u000E.\u001F(R), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.D = \u0016\u0009\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.D, new RoutedEventHandler(this.chkSelectAll_Click));
				return;
			case 3:
				this.H = \u001A\u000A\u000E.\u001F(R);
				return;
			case 4:
				this.C = \u000B\u0009\u0010.\u001F(R);
				\u0005\u0019\u0005.\u000A(this.C, new EventHandler(this.CmbFilter_DropDownClosed));
				return;
			case 5:
				this.L = \u0005\u0009\u0010.\u001F(R);
				\u0007\u000C\u0019.\u000A(this.L, new TextChangedEventHandler(this.txtSearchFilter_TextChanged));
				return;
			case 6:
				this.S = \u0007\u0016\u000E.\u001F(R);
				\u000A\u000C\u0019.\u000A(this.S, new KeyEventHandler(this.ChkList_OnKeyUp));
				return;
			case 8:
				this.B = \u0016\u0009\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.B, new RoutedEventHandler(this.chkHideUnCheckedItems_Click));
				return;
			}
			this.U = true;
		}

		// Token: 0x06001506 RID: 5382 RVA: 0x00089194 File Offset: 0x00087394
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IStyleConnector.K(int F, object R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoryNavigator.K(int, object)).MethodHandle;
				}
				\u0010\u0015\u000A.\u000A(\u0016\u0009\u0010.\u001F(R), new RoutedEventHandler(this.CheckBox_Click));
			}
		}

		// Token: 0x04000825 RID: 2085
		[CompilerGenerated]
		private EventHandler F;

		// Token: 0x04000826 RID: 2086
		public static readonly DependencyProperty ItemSourceProperty = \u000F\u0006\u001D.\u000A("ItemSource", \u001E\u0011\u000A.\u000A(\u000E\u0006\u000E.\u001F()), \u001E\u0011\u000A.\u000A(\u0008\u0006\u000E.\u001F()), \u0002\u001A\u0019.\u000A(new PropertyChangedCallback(CategoryNavigator.OnSourceChanged)));

		// Token: 0x04000827 RID: 2087
		[CompilerGenerated]
		private ObservableCollection<ICategoryModel> R;

		// Token: 0x04000828 RID: 2088
		internal CheckBox D;

		// Token: 0x04000829 RID: 2089
		internal Label H;

		// Token: 0x0400082A RID: 2090
		internal MultiSelectComboBox C;

		// Token: 0x0400082B RID: 2091
		internal WatermarkTextBox L;

		// Token: 0x0400082C RID: 2092
		internal ListBox S;

		// Token: 0x0400082D RID: 2093
		internal CheckBox B;

		// Token: 0x0400082E RID: 2094
		private bool U;

		// Token: 0x020008EA RID: 2282
		[CompilerGenerated]
		private sealed class \u0013\u0003
		{
			// Token: 0x060050F4 RID: 20724 RVA: 0x001E7ED0 File Offset: 0x001E60D0
			internal bool \u000A(string \u001F)
			{
				return \u001F\u0020\u001D.\u000A(this.\u001F, \u001F);
			}

			// Token: 0x0400235F RID: 9055
			public List<string> \u001F;
		}

		// Token: 0x020008EB RID: 2283
		[CompilerGenerated]
		private sealed class \u001A\u0003
		{
			// Token: 0x060050F6 RID: 20726 RVA: 0x001E7F00 File Offset: 0x001E6100
			internal void \u000A(ICategoryModel \u001F)
			{
				\u0013\u0013\u0018.\u000A(\u001F, \u001D\u000C\u0018.\u000A(this.\u001F));
			}

			// Token: 0x04002360 RID: 9056
			public ICategoryModel \u001F;
		}
	}
}

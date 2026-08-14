using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetGen.Data;
using DiRoots.One.SheetGen.DI.Interfaces;
using DiRoots.One.SheetGen.Services;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002D5 RID: 725
	public class SelectView : DiRootsWindow, ISelectView, IComponentConnector, IStyleConnector
	{
		// Token: 0x06001DB6 RID: 7606 RVA: 0x000BB3C0 File Offset: 0x000B95C0
		public SelectView()
		{
			\u0017\u001A\u000A.\u0007(this, this);
			\u0009\u0017\u0016.\u000A(this);
			\u000F\u000F\u0019.\u001D(this, SelectView._width);
			\u0007\u000C\u0007.\u0007(this, SelectView._height);
		}

		// Token: 0x17000835 RID: 2101
		// (get) Token: 0x06001DB8 RID: 7608 RVA: 0x000BB430 File Offset: 0x000B9630
		// (set) Token: 0x06001DB9 RID: 7609 RVA: 0x000BB444 File Offset: 0x000B9644
		public ObservableCollection<DataGridColumn> ColumnCollection
		{
			get
			{
				return this.RU;
			}
			set
			{
				this.RU = value;
				\u0008\u0011\u0016.\u000A(this, "ColumnCollection");
			}
		}

		// Token: 0x17000836 RID: 2102
		// (get) Token: 0x06001DBA RID: 7610 RVA: 0x000BB464 File Offset: 0x000B9664
		// (set) Token: 0x06001DBB RID: 7611 RVA: 0x000BB478 File Offset: 0x000B9678
		public ViewManagerView SelectedView { get; set; }

		// Token: 0x17000837 RID: 2103
		// (get) Token: 0x06001DBC RID: 7612 RVA: 0x000BB48C File Offset: 0x000B968C
		// (set) Token: 0x06001DBD RID: 7613 RVA: 0x000BB4A0 File Offset: 0x000B96A0
		public bool RemoveView
		{
			get
			{
				return this.FU;
			}
			set
			{
				this.FU = value;
				\u0008\u0011\u0016.\u000A(this, "RemoveView");
			}
		}

		// Token: 0x17000838 RID: 2104
		// (get) Token: 0x06001DBE RID: 7614 RVA: 0x000BB4C0 File Offset: 0x000B96C0
		// (set) Token: 0x06001DBF RID: 7615 RVA: 0x000BB4D4 File Offset: 0x000B96D4
		public int DefaultDisplayType { get; set; }

		// Token: 0x06001DC0 RID: 7616 RVA: 0x000BB4E8 File Offset: 0x000B96E8
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\SelectView.xaml.cs", "Window_Loaded");
			this.AB = \u000E\u0013.\u0019(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004));
			IEnumerable<View> enumerable = \u000E\u0013.\u0007(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004));
			Func<View, ViewManagerView> func;
			if ((func = SelectView.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.Window_Loaded(object, RoutedEventArgs)).MethodHandle;
				}
				func = (SelectView.<>c.\u000A = new Func<View, ViewManagerView>(SelectView.<>c.\u001F.\u0018));
			}
			this.GB = Enumerable.ToList<ViewManagerView>(Enumerable.Select<View, ViewManagerView>(enumerable, func));
			List<ViewManagerView>.Enumerator enumerator = \u001A\u0016\u0016.\u000A(this.GB);
			try
			{
				while (\u0020\u0016\u0016.\u000A(ref enumerator))
				{
					ViewManagerView u001F = \u0013\u0016\u0016.\u000A(ref enumerator);
					if (!\u001A\u0008\u0019.\u000A(this.AB, \u0017\u0016\u0016.\u000A(u001F)))
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
						Collector.\u0004.\u0019(\u001F\u000B\u0016.\u0007(u001F));
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
				((IDisposable)enumerator).Dispose();
			}
			object gb = this.GB;
			Comparison<ViewManagerView> u000A;
			if ((u000A = SelectView.<>c.\u0007) == null)
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
				u000A = (SelectView.<>c.\u0007 = new Comparison<ViewManagerView>(SelectView.<>c.\u001F.\u0005));
			}
			\u000B\u0014\u0016.\u000A(gb, u000A);
			Dictionary<int, string> dictionary = \u0016\u0014\u0016.\u000A();
			\u0004\u0014\u0016.\u000A(dictionary, 0, \u000E\u000E\u0004.\u000A());
			IEnumerable<ViewManagerView> gb2 = this.GB;
			Func<ViewManagerView, int> func2;
			if ((func2 = SelectView.<>c.\u001D) == null)
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
				func2 = (SelectView.<>c.\u001D = new Func<ViewManagerView, int>(SelectView.<>c.\u001F.\u0016));
			}
			IEnumerable<IGrouping<int, ViewManagerView>> enumerable2 = Enumerable.GroupBy<ViewManagerView, int>(gb2, func2);
			Func<IGrouping<int, ViewManagerView>, string> func3;
			if ((func3 = SelectView.<>c.\u0004) == null)
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
				func3 = (SelectView.<>c.\u0004 = new Func<IGrouping<int, ViewManagerView>, string>(SelectView.<>c.\u001F.\u000B));
			}
			IEnumerator<IGrouping<int, ViewManagerView>> enumerator2 = \u0005\u0014\u0016.\u000A(Enumerable.OrderBy<IGrouping<int, ViewManagerView>, string>(enumerable2, func3));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator2))
				{
					IGrouping<int, ViewManagerView> grouping = \u0018\u0014\u0016.\u000A(enumerator2);
					\u0004\u0014\u0016.\u000A(dictionary, \u0019\u0014\u0016.\u000A(grouping), \u001C\u0002\u0016.\u000A(Enumerable.First<ViewManagerView>(grouping)));
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
				if (enumerator2 != null)
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
					\u001F\u0017\u000A.\u000A(enumerator2);
				}
			}
			\u0018\u000C\u0007.\u000A(this.JU, dictionary);
			if (\u0007\u0014\u0016.\u000A(dictionary, \u001D\u0014\u0016.\u000A(this)))
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
				\u0012\u0002\u0019.\u000A(this.JU, Enumerable.First<KeyValuePair<int, string>>(dictionary, new Func<KeyValuePair<int, string>, bool>(this.NCR)));
			}
			else
			{
				\u0004\u000C\u000A.\u000A(this.JU, 0);
			}
			ICollectionView collectionView = \u0011\u0009\u000A.\u000A(this.GB);
			\u0005\u0008\u0007.\u000A(collectionView, new Predicate<object>(this.SearchTextFilter));
			\u0018\u000C\u0007.\u000A(this.MU, collectionView);
			this.YCR();
			\u0014\u001A\u000A.\u000A(this.KR, \u0018\u000E\u0007.\u000A("{0} {1}", \u000A\u0014\u0016.\u000A(), \u0001\u000C\u000A.\u000A(\u0010\u000C\u0007.\u000A(this.MU))));
			\u0011\u000E\u0019.\u0007(this.UD);
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen\\UI\\Windows\\SelectView.xaml.cs", "Window_Loaded");
		}

		// Token: 0x06001DC1 RID: 7617 RVA: 0x000BB80C File Offset: 0x000B9A0C
		public bool SearchTextFilter(object o)
		{
			SelectView.\u0018\u0011 u0018_u = new SelectView.\u0018\u0011();
			ViewManagerView u001F = \u001A\u001C\u000E.\u001F(o);
			bool flag = true;
			u0018_u.\u001F = "";
			u0018_u.\u001F = \u0010\u001A\u0019.\u000A(this.UD);
			int num = \u0005\u0005\u000E.\u001F(\u0006\u0014\u0016.\u000A(this.JU));
			if (num != 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.SearchTextFilter(object)).MethodHandle;
				}
				flag = false;
				if (\u0014\u0016\u0016.\u0007(u001F) == num)
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
					flag = true;
				}
			}
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
				if (\u0002\u0014\u0016.\u000A(\u0003\u0015\u000A.\u000A(this.EU)))
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
					if (\u001A\u0008\u0019.\u000A(this.AB, \u0017\u0016\u0016.\u000A(u001F)))
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
						flag = false;
					}
				}
			}
			if (flag)
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
				if (!\u001A\u0006\u0007.\u000A(u0018_u.\u001F))
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
					bool flag2;
					if (!\u000D\u0008\u000A.\u001F(\u0007\u000B\u0016.\u000A(u001F), u0018_u.\u001F))
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
						flag2 = Enumerable.Any<ParameterModel>(\u001A\u0002\u0016.\u0007(u001F), new Func<ParameterModel, bool>(u0018_u.\u000A));
					}
					else
					{
						flag2 = true;
					}
					flag = flag2;
				}
			}
			return flag;
		}

		// Token: 0x06001DC2 RID: 7618 RVA: 0x000BB948 File Offset: 0x000B9B48
		private void cmbViewType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			\u000F\u0014\u0016.\u000A(this);
			object kr = this.KR;
			string u001F = \u000A\u0014\u0016.\u000A();
			string u000A = " ";
			int num = \u0001\u000C\u000A.\u000A(\u0010\u000C\u0007.\u000A(this.MU));
			\u0014\u001A\u000A.\u000A(kr, \u0002\u0013\u000A.\u000A(u001F, u000A, \u000C\u0013\u0007.\u000A(ref num)));
		}

		// Token: 0x06001DC3 RID: 7619 RVA: 0x000BB998 File Offset: 0x000B9B98
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x06001DC4 RID: 7620 RVA: 0x000BB9AC File Offset: 0x000B9BAC
		private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.HCR();
		}

		// Token: 0x06001DC5 RID: 7621 RVA: 0x000BB9C0 File Offset: 0x000B9BC0
		private void btnSelect_Click(object sender, RoutedEventArgs e)
		{
			this.HCR();
		}

		// Token: 0x06001DC6 RID: 7622 RVA: 0x000BB9D4 File Offset: 0x000B9BD4
		private void HCR()
		{
			if (\u000D\u0014\u0016.\u000A(this))
			{
				\u0006\u0015\u0007.\u0007(this, new bool?(true));
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.HCR()).MethodHandle;
			}
			ViewManagerView viewManagerView = \u001A\u001C\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.MU));
			if (viewManagerView == null)
			{
				\u0005\u0013\u0019.\u000A(\u0012\u0014\u0016.\u000A(), this, 250.0);
				return;
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
			if (\u000E\u0013.\u0004(\u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004), \u001F\u000B\u0016.\u0007(viewManagerView)))
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
				\u000C\u000D\u001D.\u000A(\u0001\u0008\u0016.\u000A(), this);
				return;
			}
			\u001C\u0014\u0016.\u000A(this, viewManagerView);
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
			\u0003\u0014\u0016.\u000A(this, \u0005\u0005\u000E.\u001F(\u0006\u0014\u0016.\u000A(this.JU)));
		}

		// Token: 0x06001DC7 RID: 7623 RVA: 0x000BBAB4 File Offset: 0x000B9CB4
		[BindableMethod("RefreshGrid")]
		public void RefreshGrid()
		{
			if (this.MU != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.RefreshGrid()).MethodHandle;
				}
				if (\u001E\u0009\u000A.\u0007(this.MU) != null)
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
					\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(this.MU)));
				}
			}
		}

		// Token: 0x06001DC8 RID: 7624 RVA: 0x000BBB10 File Offset: 0x000B9D10
		[BindableMethod("RemoveViewChecked")]
		public void RemoveViewChecked()
		{
			if (\u000D\u0014\u0016.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.RemoveViewChecked()).MethodHandle;
				}
				\u0014\u001A\u000A.\u000A(this.FS, \u0004\u0008\u0016.\u000A());
				this.DU = \u001A\u001C\u000E.\u001F(\u0019\u000C\u0007.\u001D(this.MU));
				\u0012\u0002\u0019.\u000A(this.MU, \u0019\u001D\u000E.\u001F);
				return;
			}
			\u0014\u001A\u000A.\u000A(this.FS, \u0017\u001F\u0005.\u000A());
			\u0012\u0002\u0019.\u000A(this.MU, this.DU);
		}

		// Token: 0x06001DC9 RID: 7625 RVA: 0x000BBB9C File Offset: 0x000B9D9C
		private void YCR()
		{
			List<ViewManagerView>.Enumerator enumerator = \u001A\u0016\u0016.\u000A(this.GB);
			List<SelectionParameter>.Enumerator enumerator2;
			try
			{
				while (\u0020\u0016\u0016.\u000A(ref enumerator))
				{
					ViewManagerView viewManagerView = \u0013\u0016\u0016.\u000A(ref enumerator);
					View view = \u001F\u000B\u0016.\u0007(viewManagerView);
					List<Parameter> list;
					if (view == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.YCR()).MethodHandle;
						}
						list = \u0012\u0007\u000E.\u001F;
					}
					else
					{
						list = \u0003\u0007\u001D.\u000A(view, false);
					}
					List<Parameter> u000A = list;
					enumerator2 = \u0001\u000D\u0016.\u000A(\u0011\u0014\u0016.\u000A(ParametersManagerService.\u0008));
					try
					{
						while (\u0014\u000D\u0016.\u000A(ref enumerator2))
						{
							SelectionParameter selectionParameter = \u0015\u000D\u0016.\u000A(ref enumerator2);
							if (viewManagerView.\u001F(selectionParameter, false) == null)
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
								ParameterModel parameterModel = \u000C\u000D\u0016.\u000A(selectionParameter);
								\u001E\u001B\u0016.\u001D(viewManagerView, parameterModel);
								if (\u000A\u0003\u0016.\u001D(\u0004\u0005\u0016.\u0007(parameterModel)) == SelectionParameterType.Sheet)
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
									if (view != null)
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
										Parameter u000A2 = parameterModel.\u000A(u000A);
										\u0011\u001B\u0016.\u000A(parameterModel, u000A2, selectionParameter, viewManagerView);
									}
								}
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
						((IDisposable)enumerator2).Dispose();
					}
					\u0020\u0014\u0016.\u000A(viewManagerView, \u0011\u0014\u0016.\u000A(ParametersManagerService.\u0008));
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
			List<DataGridColumn> u001F = \u001E\u0014\u0016.\u000A();
			int num = 0;
			enumerator2 = \u0001\u000D\u0016.\u000A(\u0011\u0014\u0016.\u000A(ParametersManagerService.\u0008));
			try
			{
				while (\u0014\u000D\u0016.\u000A(ref enumerator2))
				{
					SelectView.\u0005\u0011 u0005_u = new SelectView.\u0005\u0011();
					u0005_u.\u001F = \u0015\u000D\u0016.\u000A(ref enumerator2);
					DataGridColumn dataGridColumn = \u0013\u001C\u000E.\u001F;
					ObservableCollection<DataGridColumn> observableCollection = \u001B\u0014\u0016.\u000A(this);
					DataGridColumn dataGridColumn2;
					if (observableCollection == null)
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
						dataGridColumn2 = null;
					}
					else
					{
						dataGridColumn2 = Enumerable.FirstOrDefault<DataGridColumn>(observableCollection, new Func<DataGridColumn, bool>(u0005_u.\u000A));
					}
					if ((dataGridColumn = dataGridColumn2) != null)
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
						\u0011\u0013.\u001D(dataGridColumn, num, this, false, false);
						\u0008\u0014\u0016.\u000A(u001F, dataGridColumn);
					}
					else
					{
						DataGridTextColumn u000A3 = \u0011\u0013.\u0004(num, u0005_u.\u001F, this, false, false);
						\u0008\u0014\u0016.\u000A(u001F, u000A3);
					}
					num++;
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
				((IDisposable)enumerator2).Dispose();
			}
			\u0010\u0014\u0016.\u000A(this, \u000E\u0014\u0016.\u000A(u001F));
			\u000F\u0014\u0016.\u000A(this);
		}

		// Token: 0x06001DCA RID: 7626 RVA: 0x000BBE30 File Offset: 0x000BA030
		private void wndSelectView_Closed(object sender, EventArgs e)
		{
			SelectView._width = \u001C\u000F\u0019.\u001D(this);
			SelectView._height = \u0010\u000F\u0019.\u001D(this);
		}

		// Token: 0x17000839 RID: 2105
		// (get) Token: 0x06001DCB RID: 7627 RVA: 0x000BBE58 File Offset: 0x000BA058
		// (set) Token: 0x06001DCC RID: 7628 RVA: 0x000BBE6C File Offset: 0x000BA06C
		public ObservableCollection<SelectionParameter> TempUsedParams
		{
			get
			{
				return this.SU;
			}
			set
			{
				this.SU = value;
				\u0008\u0011\u0016.\u000A(this, "TempUsedParams");
			}
		}

		// Token: 0x1700083A RID: 2106
		// (get) Token: 0x06001DCD RID: 7629 RVA: 0x000BBE8C File Offset: 0x000BA08C
		// (set) Token: 0x06001DCE RID: 7630 RVA: 0x000BBEA0 File Offset: 0x000BA0A0
		public string SourceLabel
		{
			get
			{
				return this.UU;
			}
			set
			{
				this.UU = value;
				\u0008\u0011\u0016.\u000A(this, "SourceLabel");
			}
		}

		// Token: 0x1700083B RID: 2107
		// (get) Token: 0x06001DCF RID: 7631 RVA: 0x000BBEC0 File Offset: 0x000BA0C0
		// (set) Token: 0x06001DD0 RID: 7632 RVA: 0x000BBED4 File Offset: 0x000BA0D4
		public ObservableCollection<SelectionParameter> TempAvailableParams
		{
			get
			{
				return this.BU;
			}
			set
			{
				this.BU = value;
				\u0008\u0011\u0016.\u000A(this, "TempAvailableParams");
			}
		}

		// Token: 0x1700083C RID: 2108
		// (get) Token: 0x06001DD1 RID: 7633 RVA: 0x000BBEF4 File Offset: 0x000BA0F4
		// (set) Token: 0x06001DD2 RID: 7634 RVA: 0x000BBF08 File Offset: 0x000BA108
		public IList<SelectionParameter> SelectedUsedParams
		{
			get
			{
				return this.CU;
			}
			set
			{
				this.CU = value;
				\u0008\u0011\u0016.\u000A(this, "SelectedUsedParams");
			}
		}

		// Token: 0x1700083D RID: 2109
		// (get) Token: 0x06001DD3 RID: 7635 RVA: 0x000BBF28 File Offset: 0x000BA128
		// (set) Token: 0x06001DD4 RID: 7636 RVA: 0x000BBF3C File Offset: 0x000BA13C
		public IList<SelectionParameter> SelectedAvailableParams
		{
			get
			{
				return this.LU;
			}
			set
			{
				this.LU = value;
				\u0008\u0011\u0016.\u000A(this, "SelectedAvailableParams");
			}
		}

		// Token: 0x1700083E RID: 2110
		// (get) Token: 0x06001DD5 RID: 7637 RVA: 0x000BBF5C File Offset: 0x000BA15C
		// (set) Token: 0x06001DD6 RID: 7638 RVA: 0x000BBF70 File Offset: 0x000BA170
		public ICollectionView TempAvailableView
		{
			get
			{
				return this.WU;
			}
			set
			{
				this.WU = value;
				\u0008\u0011\u0016.\u000A(this, "TempAvailableView");
			}
		}

		// Token: 0x1700083F RID: 2111
		// (get) Token: 0x06001DD7 RID: 7639 RVA: 0x000BBF90 File Offset: 0x000BA190
		public CommandBase AvailableToUsedCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.SCR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000840 RID: 2112
		// (get) Token: 0x06001DD8 RID: 7640 RVA: 0x000BBFB8 File Offset: 0x000BA1B8
		public CommandBase AvailableDoubleClickCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.UCR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000841 RID: 2113
		// (get) Token: 0x06001DD9 RID: 7641 RVA: 0x000BBFE0 File Offset: 0x000BA1E0
		public CommandBase UsedDoubleClickCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.BCR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000842 RID: 2114
		// (get) Token: 0x06001DDA RID: 7642 RVA: 0x000BC008 File Offset: 0x000BA208
		public CommandBase UsedToAvailableCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.LCR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000843 RID: 2115
		// (get) Token: 0x06001DDB RID: 7643 RVA: 0x000BC030 File Offset: 0x000BA230
		public CommandBase MoveToBeginningCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.WCR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000844 RID: 2116
		// (get) Token: 0x06001DDC RID: 7644 RVA: 0x000BC058 File Offset: 0x000BA258
		public CommandBase MoveUpCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.KCR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000845 RID: 2117
		// (get) Token: 0x06001DDD RID: 7645 RVA: 0x000BC080 File Offset: 0x000BA280
		public CommandBase MoveDownCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.JCR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000846 RID: 2118
		// (get) Token: 0x06001DDE RID: 7646 RVA: 0x000BC0A8 File Offset: 0x000BA2A8
		public CommandBase MoveToEndCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.ECR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000847 RID: 2119
		// (get) Token: 0x06001DDF RID: 7647 RVA: 0x000BC0D0 File Offset: 0x000BA2D0
		public CommandBase<Window> ApplyCommand
		{
			get
			{
				return \u0007\u0009\u0004.\u000A(new Action<Window>(this.Apply), \u0003\u0018\u000E.\u001F);
			}
		}

		// Token: 0x17000848 RID: 2120
		// (get) Token: 0x06001DE0 RID: 7648 RVA: 0x000BC0F8 File Offset: 0x000BA2F8
		public CommandBase ReloadCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.CCR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x06001DE1 RID: 7649 RVA: 0x000BC120 File Offset: 0x000BA320
		[BindableMethod("OpenParamsWindow")]
		public void OpenParamsWindow()
		{
			ManageParameters u001F = \u0007\u0013\u0016.\u000A();
			\u0017\u001A\u000A.\u001D(u001F, this);
			\u0015\u000D\u001D.\u000A(u001F, this);
			\u000A\u0013\u0016.\u000A(u001F);
			\u001F\u0013\u0016.\u000A(this, \u0001\u0014\u0016.\u000A(\u0011\u0014\u0016.\u000A(ParametersManagerService.\u0008)));
			\u0015\u0014\u0016.\u000A(this, \u0001\u0014\u0016.\u000A(\u0009\u0014\u0016.\u000A(ParametersManagerService.\u0008)));
			\u000C\u0014\u0016.\u000A(this, \u0011\u0009\u000A.\u000A(\u0014\u0014\u0016.\u000A(this)));
			bool? flag = \u0018\u0020\u000A.\u0007(u001F);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.OpenParamsWindow()).MethodHandle;
				}
				\u0013\u0014\u0016.\u0007(ParametersManagerService.\u0008, Enumerable.ToList<SelectionParameter>(\u001A\u0014\u0016.\u000A(this)));
				\u0017\u0014\u0016.\u0007(ParametersManagerService.\u0008, Enumerable.ToList<SelectionParameter>(\u0014\u0014\u0016.\u000A(this)));
				this.YCR();
			}
		}

		// Token: 0x06001DE2 RID: 7650 RVA: 0x000BC1F8 File Offset: 0x000BA3F8
		private void CCR()
		{
			IEnumerator<SelectionParameter> enumerator = \u0019\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SelectionParameter u000A = \u0008\u0010\u0016.\u000A(enumerator);
					\u0004\u0013\u0016.\u000A(\u0014\u0014\u0016.\u000A(this), u000A);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.CCR()).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			\u001D\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this));
			IEnumerable<SelectionParameter> enumerable = \u0014\u0014\u0016.\u000A(this);
			Func<SelectionParameter, string> func;
			if ((func = SelectView.<>c.\u0019) == null)
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
				func = (SelectView.<>c.\u0019 = new Func<SelectionParameter, string>(SelectView.<>c.\u001F.\u0002));
			}
			List<SelectionParameter> u001F = Enumerable.ToList<SelectionParameter>(Enumerable.OrderBy<SelectionParameter, string>(enumerable, func));
			\u0015\u0014\u0016.\u000A(this, \u0001\u0014\u0016.\u000A(u001F));
		}

		// Token: 0x06001DE3 RID: 7651 RVA: 0x000BC2CC File Offset: 0x000BA4CC
		private void LCR()
		{
			if (\u0005\u0013\u0016.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.LCR()).MethodHandle;
				}
				IEnumerator<SelectionParameter> enumerator = \u001B\u0010\u0016.\u000A(\u0005\u0013\u0016.\u000A(this));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						SelectionParameter u000A = \u0008\u0010\u0016.\u000A(enumerator);
						\u0004\u0013\u0016.\u000A(\u0014\u0014\u0016.\u000A(this), u000A);
						\u0018\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), u000A);
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
					if (enumerator != null)
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
			}
		}

		// Token: 0x06001DE4 RID: 7652 RVA: 0x000BC370 File Offset: 0x000BA570
		private void SCR()
		{
			if (\u0016\u0013\u0016.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.SCR()).MethodHandle;
				}
				IEnumerator<SelectionParameter> enumerator = \u001B\u0010\u0016.\u000A(\u0016\u0013\u0016.\u000A(this));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						SelectionParameter u000A = \u0008\u0010\u0016.\u000A(enumerator);
						\u0004\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), u000A);
						\u0018\u0013\u0016.\u000A(\u0014\u0014\u0016.\u000A(this), u000A);
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
			}
		}

		// Token: 0x06001DE5 RID: 7653 RVA: 0x000BC414 File Offset: 0x000BA614
		private void BCR()
		{
			if (\u0005\u0013\u0016.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.BCR()).MethodHandle;
				}
				IEnumerator<SelectionParameter> enumerator = \u001B\u0010\u0016.\u000A(\u0005\u0013\u0016.\u000A(this));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						SelectionParameter u000A = \u0008\u0010\u0016.\u000A(enumerator);
						\u0004\u0013\u0016.\u000A(\u0014\u0014\u0016.\u000A(this), u000A);
						\u0018\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), u000A);
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
					if (enumerator != null)
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
			}
		}

		// Token: 0x06001DE6 RID: 7654 RVA: 0x000BC4B8 File Offset: 0x000BA6B8
		private void UCR()
		{
			if (\u0016\u0013\u0016.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.UCR()).MethodHandle;
				}
				IEnumerator<SelectionParameter> enumerator = \u001B\u0010\u0016.\u000A(\u0016\u0013\u0016.\u000A(this));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						SelectionParameter u000A = \u0008\u0010\u0016.\u000A(enumerator);
						\u0004\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), u000A);
						\u0018\u0013\u0016.\u000A(\u0014\u0014\u0016.\u000A(this), u000A);
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
					if (enumerator != null)
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
			}
		}

		// Token: 0x06001DE7 RID: 7655 RVA: 0x000BC55C File Offset: 0x000BA75C
		private void WCR()
		{
			if (\u0005\u0013\u0016.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.WCR()).MethodHandle;
				}
				object u001F = Enumerable.ToList<SelectionParameter>(Enumerable.OrderBy<SelectionParameter, int>(\u0005\u0013\u0016.\u000A(this), new Func<SelectionParameter, int>(this.MCR)));
				int num = 0;
				List<SelectionParameter>.Enumerator enumerator = \u0001\u000D\u0016.\u000A(u001F);
				try
				{
					while (\u0014\u000D\u0016.\u000A(ref enumerator))
					{
						SelectionParameter u000A = \u0015\u000D\u0016.\u000A(ref enumerator);
						\u000B\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), \u0002\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), u000A), num++);
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
					((IDisposable)enumerator).Dispose();
				}
			}
		}

		// Token: 0x06001DE8 RID: 7656 RVA: 0x000BC618 File Offset: 0x000BA818
		private void KCR()
		{
			if (\u0005\u0013\u0016.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.KCR()).MethodHandle;
				}
				List<SelectionParameter>.Enumerator enumerator = \u0001\u000D\u0016.\u000A(Enumerable.ToList<SelectionParameter>(Enumerable.OrderBy<SelectionParameter, int>(\u0005\u0013\u0016.\u000A(this), new Func<SelectionParameter, int>(this.VCR))));
				try
				{
					while (\u0014\u000D\u0016.\u000A(ref enumerator))
					{
						SelectionParameter u000A = \u0015\u000D\u0016.\u000A(ref enumerator);
						int num = \u0002\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), u000A);
						int num2 = num - 1;
						if (num2 < 0)
						{
							return;
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
						\u000B\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), num, num2);
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
					((IDisposable)enumerator).Dispose();
				}
			}
		}

		// Token: 0x06001DE9 RID: 7657 RVA: 0x000BC6E4 File Offset: 0x000BA8E4
		private void JCR()
		{
			if (\u0005\u0013\u0016.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.JCR()).MethodHandle;
				}
				List<SelectionParameter>.Enumerator enumerator = \u0001\u000D\u0016.\u000A(Enumerable.ToList<SelectionParameter>(Enumerable.OrderByDescending<SelectionParameter, int>(\u0005\u0013\u0016.\u000A(this), new Func<SelectionParameter, int>(this.ZCR))));
				try
				{
					while (\u0014\u000D\u0016.\u000A(ref enumerator))
					{
						SelectionParameter u000A = \u0015\u000D\u0016.\u000A(ref enumerator);
						int num = \u0002\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), u000A);
						int num2 = num + 1;
						if (num2 >= \u0006\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this)))
						{
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
						\u000B\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), num, num2);
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
		}

		// Token: 0x06001DEA RID: 7658 RVA: 0x000BC7BC File Offset: 0x000BA9BC
		private void ECR()
		{
			if (\u0005\u0013\u0016.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.ECR()).MethodHandle;
				}
				object u001F = Enumerable.ToList<SelectionParameter>(Enumerable.OrderByDescending<SelectionParameter, int>(\u0005\u0013\u0016.\u000A(this), new Func<SelectionParameter, int>(this.XCR)));
				int num = \u0006\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this)) - 1;
				List<SelectionParameter>.Enumerator enumerator = \u0001\u000D\u0016.\u000A(u001F);
				try
				{
					while (\u0014\u000D\u0016.\u000A(ref enumerator))
					{
						SelectionParameter u000A = \u0015\u000D\u0016.\u000A(ref enumerator);
						\u000B\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), \u0002\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), u000A), num--);
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
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
		}

		// Token: 0x06001DEB RID: 7659 RVA: 0x000BC888 File Offset: 0x000BAA88
		public void Apply(Window wnd)
		{
			\u0006\u0015\u0007.\u001D(wnd, new bool?(true));
		}

		// Token: 0x06001DEC RID: 7660 RVA: 0x000BC8A4 File Offset: 0x000BAAA4
		public bool SelectionParameterFilter(object o)
		{
			SelectionParameter selectionParameter = \u0014\u001C\u000E.\u001F(o);
			if (selectionParameter == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.SelectionParameterFilter(object)).MethodHandle;
				}
				return false;
			}
			bool result = true;
			if (\u000A\u0003\u0016.\u001D(selectionParameter) == SelectionParameterType.Schedule)
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
				result = false;
			}
			return result;
		}

		// Token: 0x06001DED RID: 7661 RVA: 0x000BC8EC File Offset: 0x000BAAEC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/selectview.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06001DEE RID: 7662 RVA: 0x000BC934 File Offset: 0x000BAB34
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06001DEF RID: 7663 RVA: 0x000BC94C File Offset: 0x000BAB4C
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.KU = \u0017\u001C\u000E.\u001F(R);
				\u0016\u0015\u0007.\u0007(this.KU, new EventHandler(this.wndSelectView_Closed));
				\u0011\u000C\u000A.\u0007(this.KU, new RoutedEventHandler(this.Window_Loaded));
				return;
			case 2:
				this.JU = \u000B\u000A\u000E.\u001F(R);
				\u001B\u000C\u000A.\u0007(this.JU, new SelectionChangedEventHandler(this.cmbViewType_SelectionChanged));
				return;
			case 3:
				this.VS = \u0019\u0009\u0010.\u001F(R);
				return;
			case 4:
				this.UD = \u0005\u0009\u0010.\u001F(R);
				return;
			case 5:
				this.EU = \u0016\u0009\u0010.\u001F(R);
				return;
			case 6:
				this.NU = \u0016\u0009\u0010.\u001F(R);
				return;
			case 7:
				this.MU = \u0020\u0001\u0010.\u001F(R);
				return;
			case 9:
				this.KR = \u001A\u000A\u000E.\u001F(R);
				return;
			case 10:
				this.YL = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.YL, new RoutedEventHandler(this.btnCancel_Click));
				return;
			case 11:
				this.FS = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.FS, new RoutedEventHandler(this.btnSelect_Click));
				return;
			}
			this.R = true;
		}

		// Token: 0x06001DF0 RID: 7664 RVA: 0x000BCAA4 File Offset: 0x000BACA4
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IStyleConnector.AQ(int F, object R)
		{
			if (F == 8)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.AQ(int, object)).MethodHandle;
				}
				EventSetter eventSetter = \u001B\u0001\u0007.\u000A();
				\u0008\u0001\u0007.\u000A(eventSetter, Control.MouseDoubleClickEvent);
				\u000E\u0001\u0007.\u000A(eventSetter, new MouseButtonEventHandler(this.Row_DoubleClick));
				\u000D\u0001\u0007.\u000A(\u0010\u0001\u0007.\u000A(\u000C\u000A\u000E.\u001F(R)), eventSetter);
			}
		}

		// Token: 0x06001DF1 RID: 7665 RVA: 0x000BCB04 File Offset: 0x000BAD04
		bool? ISelectView.XG()
		{
			return \u0018\u0020\u000A.\u001D(this);
		}

		// Token: 0x06001DF2 RID: 7666 RVA: 0x000BCB1C File Offset: 0x000BAD1C
		Window ISelectView.PG()
		{
			return \u000D\u0011\u0016.\u0007(this);
		}

		// Token: 0x06001DF3 RID: 7667 RVA: 0x000BCB34 File Offset: 0x000BAD34
		void ISelectView.OG(Window F)
		{
			\u000C\u000E\u0007.\u001D(this, F);
		}

		// Token: 0x06001DF4 RID: 7668 RVA: 0x000BCB48 File Offset: 0x000BAD48
		[CompilerGenerated]
		private bool NCR(KeyValuePair<int, string> F)
		{
			return \u000F\u0013\u0016.\u000A(ref F) == \u001D\u0014\u0016.\u000A(this);
		}

		// Token: 0x06001DF5 RID: 7669 RVA: 0x000BCB68 File Offset: 0x000BAD68
		[CompilerGenerated]
		private int MCR(SelectionParameter F)
		{
			return \u0002\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), F);
		}

		// Token: 0x06001DF6 RID: 7670 RVA: 0x000BCB88 File Offset: 0x000BAD88
		[CompilerGenerated]
		private int VCR(SelectionParameter F)
		{
			return \u0002\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), F);
		}

		// Token: 0x06001DF7 RID: 7671 RVA: 0x000BCBA8 File Offset: 0x000BADA8
		[CompilerGenerated]
		private int ZCR(SelectionParameter F)
		{
			return \u0002\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), F);
		}

		// Token: 0x06001DF8 RID: 7672 RVA: 0x000BCBC8 File Offset: 0x000BADC8
		[CompilerGenerated]
		private int XCR(SelectionParameter F)
		{
			return \u0002\u0013\u0016.\u000A(\u001A\u0014\u0016.\u000A(this), F);
		}

		// Token: 0x04000C1D RID: 3101
		private List<long> AB;

		// Token: 0x04000C1E RID: 3102
		private List<ViewManagerView> GB;

		// Token: 0x04000C1F RID: 3103
		private bool FU;

		// Token: 0x04000C20 RID: 3104
		private ObservableCollection<DataGridColumn> RU;

		// Token: 0x04000C21 RID: 3105
		private ViewManagerView DU;

		// Token: 0x04000C22 RID: 3106
		private static double _width = 570.0;

		// Token: 0x04000C23 RID: 3107
		private static double _height = 500.0;

		// Token: 0x04000C24 RID: 3108
		[CompilerGenerated]
		private ViewManagerView HU;

		// Token: 0x04000C25 RID: 3109
		[CompilerGenerated]
		private int YU;

		// Token: 0x04000C26 RID: 3110
		private IList<SelectionParameter> CU;

		// Token: 0x04000C27 RID: 3111
		private IList<SelectionParameter> LU;

		// Token: 0x04000C28 RID: 3112
		private ObservableCollection<SelectionParameter> SU;

		// Token: 0x04000C29 RID: 3113
		private ObservableCollection<SelectionParameter> BU;

		// Token: 0x04000C2A RID: 3114
		private string UU = \u001F\u0014\u0016.\u000A();

		// Token: 0x04000C2B RID: 3115
		private ICollectionView WU;

		// Token: 0x04000C2C RID: 3116
		internal SelectView KU;

		// Token: 0x04000C2D RID: 3117
		internal ComboBox JU;

		// Token: 0x04000C2E RID: 3118
		internal LeftStripButton VS;

		// Token: 0x04000C2F RID: 3119
		internal WatermarkTextBox UD;

		// Token: 0x04000C30 RID: 3120
		internal CheckBox EU;

		// Token: 0x04000C31 RID: 3121
		internal CheckBox NU;

		// Token: 0x04000C32 RID: 3122
		internal DataGrid MU;

		// Token: 0x04000C33 RID: 3123
		internal Label KR;

		// Token: 0x04000C34 RID: 3124
		internal Button YL;

		// Token: 0x04000C35 RID: 3125
		internal Button FS;

		// Token: 0x04000C36 RID: 3126
		private bool R;

		// Token: 0x020009B0 RID: 2480
		[CompilerGenerated]
		private sealed class \u0018\u0011
		{
			// Token: 0x0600538B RID: 21387 RVA: 0x001ED0AC File Offset: 0x001EB2AC
			internal bool \u000A(ParameterModel \u001F)
			{
				string u001F;
				if (\u001F == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectView.\u0018\u0011.\u000A(ParameterModel)).MethodHandle;
					}
					u001F = null;
				}
				else
				{
					ParameterStringValue parameterStringValue = \u0009\u0018\u0016.\u001D(\u001F);
					if (parameterStringValue == null)
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
						u001F = null;
					}
					else
					{
						u001F = \u001A\u000B\u0016.\u001D(parameterStringValue);
					}
				}
				return \u000D\u0008\u000A.\u001F(u001F, this.\u001F);
			}

			// Token: 0x0400252A RID: 9514
			public string \u001F;
		}

		// Token: 0x020009B1 RID: 2481
		[CompilerGenerated]
		private sealed class \u0005\u0011
		{
			// Token: 0x0600538D RID: 21389 RVA: 0x001ED114 File Offset: 0x001EB314
			internal bool \u000A(DataGridColumn \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0010\u000B\u0019.\u001D(\u001F), \u001F\u0016\u0016.\u0007(this.\u001F));
			}

			// Token: 0x0400252B RID: 9515
			public SelectionParameter \u001F;
		}
	}
}

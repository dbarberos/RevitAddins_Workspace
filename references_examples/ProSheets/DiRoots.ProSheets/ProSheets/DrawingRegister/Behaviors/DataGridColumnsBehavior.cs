using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using A;

namespace ProSheets.DrawingRegister.Behaviors
{
	// Token: 0x02000130 RID: 304
	public class DataGridColumnsBehavior
	{
		// Token: 0x06000F6F RID: 3951 RVA: 0x00057D04 File Offset: 0x00055F04
		private static void P(DependencyObject P, DependencyPropertyChangedEventArgs Q)
		{
			DataGridColumnsBehavior.\u0018\u0017\u0018 u0018_u0017_u = new DataGridColumnsBehavior.\u0018\u0017\u0018();
			u0018_u0017_u.\u000C = \u0007\u000B\u000F.\u000C(P);
			if (u0018_u0017_u.\u000C == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridColumnsBehavior.P(DependencyObject, DependencyPropertyChangedEventArgs)).MethodHandle;
				}
				return;
			}
			ObservableCollection<DataGridColumn> observableCollection = \u001F\u0008\u000F.\u000C(\u0012\u000D\u0014.\u0018(ref Q));
			if (observableCollection == null)
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
			if (\u001E\u0014\u0003.\u0018(observableCollection) >= 1)
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
				\u000C\u001C\u000F.\u0018(\u0002\u0014\u0003.\u0018(u0018_u0017_u.\u000C));
			}
			if (!Enumerable.Any<DataGridColumn>(observableCollection))
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
				if (Enumerable.Any<DataGridColumn>(\u0002\u0014\u0003.\u0018(u0018_u0017_u.\u000C)))
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
					\u0009\u0014\u0003.\u0018(observableCollection, 0, \u001C\u000F\u0003.\u0018(\u0002\u0014\u0003.\u0018(u0018_u0017_u.\u000C), 0));
					\u0009\u0014\u0003.\u0018(observableCollection, 1, \u001C\u000F\u0003.\u0018(\u0002\u0014\u0003.\u0018(u0018_u0017_u.\u000C), 1));
				}
			}
			IEnumerator<DataGridColumn> enumerator = \u000E\u000D\u000F.\u0018(observableCollection);
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					DataGridColumn u = \u0005\u000D\u000F.\u0018(enumerator);
					\u000B\u0014\u000F.\u0018(\u0002\u0014\u0003.\u0018(u0018_u0017_u.\u000C), u);
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
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					\u0020\u001E\u0018.\u0018(enumerator);
				}
			}
			\u001B\u000D\u000F.\u0018(observableCollection, new NotifyCollectionChangedEventHandler(u0018_u0017_u.\u0018));
		}

		// Token: 0x06000F70 RID: 3952 RVA: 0x00057E68 File Offset: 0x00056068
		private static void Q(DataGrid P, NotifyCollectionChangedEventArgs Q)
		{
			\u000C\u001C\u000F.\u0018(\u0002\u0014\u0003.\u0018(P));
			DataGridColumnsBehavior.J(P, \u0018\u001C\u000F.\u0018(Q));
		}

		// Token: 0x06000F71 RID: 3953 RVA: 0x00057E90 File Offset: 0x00056090
		private static void J(DataGrid P, IList Q)
		{
			if (Q != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridColumnsBehavior.J(DataGrid, IList)).MethodHandle;
				}
				IEnumerator u000C = \u0016\u000F\u0014.\u0018(Q);
				try
				{
					while (\u001F\u001E\u0018.\u0018(u000C))
					{
						DataGridColumn u = \u0020\u0008\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C));
						\u000B\u0014\u000F.\u0018(\u0002\u0014\u0003.\u0018(P), u);
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
					IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C);
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
						\u0020\u001E\u0018.\u0018(disposable);
					}
				}
			}
		}

		// Token: 0x06000F72 RID: 3954 RVA: 0x00057F20 File Offset: 0x00056120
		private static void F(DataGrid P, IList Q)
		{
			if (Q != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridColumnsBehavior.F(DataGrid, IList)).MethodHandle;
				}
				IEnumerator u000C = \u0016\u000F\u0014.\u0018(Q);
				try
				{
					while (\u001F\u001E\u0018.\u0018(u000C))
					{
						DataGridColumn u = \u0020\u0008\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C));
						\u0013\u0016\u0003.\u0018(\u0002\u0014\u0003.\u0018(P), u);
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
					IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C);
					if (disposable != null)
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
						\u0020\u001E\u0018.\u0018(disposable);
					}
				}
			}
		}

		// Token: 0x06000F73 RID: 3955 RVA: 0x00057FB8 File Offset: 0x000561B8
		private static void H(DataGrid P, NotifyCollectionChangedEventArgs Q)
		{
			if (\u0014\u001C\u000F.\u0018(Q) >= 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridColumnsBehavior.H(DataGrid, NotifyCollectionChangedEventArgs)).MethodHandle;
				}
				IList list = \u0018\u001C\u000F.\u0018(Q);
				object u000C;
				if (list == null)
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
					u000C = null;
				}
				else
				{
					u000C = \u0003\u001C\u000F.\u0018(list, 0);
				}
				DataGridColumn dataGridColumn = \u000A\u0008\u000F.\u000C(u000C);
				if (dataGridColumn != null)
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
					\u0018\u0003\u000F.\u0018(\u0002\u0014\u0003.\u0018(P), \u0014\u001C\u000F.\u0018(Q), dataGridColumn);
				}
			}
		}

		// Token: 0x06000F74 RID: 3956 RVA: 0x00058030 File Offset: 0x00056230
		public static void SetBindableColumns(DependencyObject element, ObservableCollection<DataGridColumn> value)
		{
			\u0007\u001A\u0018.\u0003(element, DataGridColumnsBehavior.BindableColumnsProperty, value);
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x0005804C File Offset: 0x0005624C
		public static ObservableCollection<DataGridColumn> GetBindableColumns(DependencyObject element)
		{
			return \u0009\u0008\u000F.\u000C(\u0019\u001A\u0018.\u0003(element, DataGridColumnsBehavior.BindableColumnsProperty));
		}

		// Token: 0x040006EF RID: 1775
		public static readonly DependencyProperty BindableColumnsProperty = \u000E\u000F\u0014.\u0018("BindableColumns", \u000A\u001D\u0018.\u0018(\u0011\u0008\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0015\u0008\u000F.\u000C()), \u000C\u0012\u0014.\u0018(null, new PropertyChangedCallback(DataGridColumnsBehavior.P)));

		// Token: 0x0200021B RID: 539
		[CompilerGenerated]
		private sealed class \u0018\u0017\u0018
		{
			// Token: 0x06001313 RID: 4883 RVA: 0x00061680 File Offset: 0x0005F880
			internal void \u0018(object \u000C, NotifyCollectionChangedEventArgs \u0018)
			{
				switch (\u0007\u001E\u000F.\u0018(\u0018))
				{
				case 0:
					DataGridColumnsBehavior.J(this.\u000C, \u0018\u001C\u000F.\u0018(\u0018));
					return;
				case 1:
					DataGridColumnsBehavior.F(this.\u000C, \u001A\u001E\u000F.\u0018(\u0018));
					return;
				case 2:
					DataGridColumnsBehavior.H(this.\u000C, \u0018);
					break;
				case 3:
					if (\u0019\u001E\u000F.\u0018(\u0018) >= 0)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridColumnsBehavior.\u0018\u0017\u0018.\u0018(object, NotifyCollectionChangedEventArgs)).MethodHandle;
						}
						if (\u0014\u001C\u000F.\u0018(\u0018) >= 0)
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
							\u000B\u001E\u000F.\u0018(\u0002\u0014\u0003.\u0018(this.\u000C), \u0019\u001E\u000F.\u0018(\u0018), \u0014\u001C\u000F.\u0018(\u0018));
							return;
						}
					}
					break;
				case 4:
					DataGridColumnsBehavior.Q(this.\u000C, \u0018);
					return;
				default:
					return;
				}
			}

			// Token: 0x04000972 RID: 2418
			public DataGrid \u000C;
		}
	}
}

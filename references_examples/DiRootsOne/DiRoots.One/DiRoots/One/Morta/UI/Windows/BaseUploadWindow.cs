using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using A;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.One.Morta.UI.Windows
{
	// Token: 0x020001AF RID: 431
	public class BaseUploadWindow : DiRootsWindow
	{
		// Token: 0x0600101A RID: 4122 RVA: 0x00065F5C File Offset: 0x0006415C
		public BaseUploadWindow()
		{
			\u001C\u000C\u0007.\u0007(this, \u001B\u000A\u0018.\u000A());
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x00065F7C File Offset: 0x0006417C
		public void DataGridColumnSort(object sender, DataGridSortingEventArgs e)
		{
			DataGrid dataGrid = \u001D\u001F\u000E.\u001F(sender);
			if (dataGrid != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(BaseUploadWindow.DataGridColumnSort(object, DataGridSortingEventArgs)).MethodHandle;
				}
				ListCollectionView u001F = \u000F\u0009\u0010.\u001F(\u0011\u0009\u000A.\u000A(\u001E\u0009\u000A.\u0007(dataGrid)));
				if (\u000D\u0009\u000A.\u000A(e) != null)
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
					if (\u0014\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e)))
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
						if (\u0001\u0007\u0018.\u000A(\u000D\u0009\u000A.\u000A(e)) == 0)
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
							ListSortDirection? listSortDirection = \u001B\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e));
							ListSortDirection listSortDirection2 = ListSortDirection.Ascending;
							if (\u0008\u0009\u000A.\u000A(ref listSortDirection) == listSortDirection2 & \u000E\u0009\u000A.\u000A(ref listSortDirection))
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
								\u0010\u0009\u000A.\u000A(u001F, new \u000C\u0006(false));
								\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Descending));
							}
							else
							{
								\u0010\u0009\u000A.\u000A(u001F, new \u000C\u0006(true));
								\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(ListSortDirection.Ascending));
							}
							\u0003\u0009\u000A.\u000A(e, true);
						}
					}
				}
			}
		}
	}
}

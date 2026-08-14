using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using A;

namespace DiRoots.One.TableGen.TableGen.UI.UserControls
{
	// Token: 0x0200017F RID: 383
	public partial class TextStylesTab : UserControl
	{
		// Token: 0x06000E46 RID: 3654 RVA: 0x0005B91C File Offset: 0x00059B1C
		public TextStylesTab()
		{
			\u0006\u000E\u0019.\u000A(this);
		}

		// Token: 0x06000E47 RID: 3655 RVA: 0x0005B938 File Offset: 0x00059B38
		public void OnDataGridSorting(object sender, DataGridSortingEventArgs e)
		{
			DataGrid dataGrid = \u001D\u001F\u000E.\u001F(sender);
			if (dataGrid == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TextStylesTab.OnDataGridSorting(object, DataGridSortingEventArgs)).MethodHandle;
				}
				return;
			}
			ListCollectionView listCollectionView = \u0008\u0005\u000E.\u001F(\u001E\u0009\u000A.\u0007(dataGrid));
			if (listCollectionView == null)
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
			DataGridColumn dataGridColumn = \u000D\u0009\u000A.\u000A(e);
			string u001F;
			if (dataGridColumn == null)
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
				u001F = \u000F\u0015\u0010.\u001F;
			}
			else
			{
				u001F = \u001F\u000E\u0019.\u001D(dataGridColumn);
			}
			if (\u001A\u0006\u0007.\u000A(u001F))
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
			ListSortDirection? listSortDirection = \u001B\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e));
			ListSortDirection listSortDirection2 = ListSortDirection.Ascending;
			ListSortDirection listSortDirection3;
			if (!(\u0008\u0009\u000A.\u000A(ref listSortDirection) == listSortDirection2 & \u000E\u0009\u000A.\u000A(ref listSortDirection)))
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
				listSortDirection3 = ListSortDirection.Ascending;
			}
			else
			{
				listSortDirection3 = ListSortDirection.Descending;
			}
			ListSortDirection listSortDirection4 = listSortDirection3;
			\u0010\u0009\u000A.\u000A(listCollectionView, \u0009\u0010\u0019.\u000A(\u001F\u000E\u0019.\u0007(\u000D\u0009\u000A.\u000A(e)), listSortDirection4, true));
			\u001C\u0009\u000A.\u000A(\u000D\u0009\u000A.\u000A(e), new ListSortDirection?(listSortDirection4));
			\u0003\u0009\u000A.\u000A(e, true);
		}
	}
}

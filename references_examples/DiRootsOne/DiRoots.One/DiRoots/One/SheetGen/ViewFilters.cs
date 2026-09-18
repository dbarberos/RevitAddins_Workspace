using System;
using System.Collections.Generic;
using A;
using DiRoots.One.Commons.Models.Filter;
using DiRoots.One.SheetGen.Models;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002C5 RID: 709
	public class ViewFilters : ViewFilter
	{
		// Token: 0x06001CC4 RID: 7364 RVA: 0x000B6A18 File Offset: 0x000B4C18
		public void GettingDataForColumnFilter(ViewFilters viewFilter, List<SelectionNamedItem> selectionNamedItems, string firstName)
		{
			\u0016\u001B\u0016.\u000A(selectionNamedItems, 0, \u000B\u001B\u0016.\u000A(101, firstName));
			\u0016\u001B\u0016.\u000A(selectionNamedItems, 1, \u000B\u001B\u0016.\u000A(100, \u0002\u001B\u0016.\u000A()));
			\u001A\u0012\u0007.\u000A(\u0011\u0012\u0007.\u000A(selectionNamedItems, 1), true);
			Action<SelectionNamedItem> u000A;
			if ((u000A = ViewFilters.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewFilters.GettingDataForColumnFilter(ViewFilters, List<SelectionNamedItem>, string)).MethodHandle;
				}
				u000A = (ViewFilters.<>c.\u000A = new Action<SelectionNamedItem>(ViewFilters.<>c.\u001F.\u0007));
			}
			\u0005\u001B\u0016.\u000A(selectionNamedItems, u000A);
			\u0007\u0003\u0007.\u000A(viewFilter, selectionNamedItems);
			\u0014\u0012\u0007.\u000A(viewFilter, selectionNamedItems);
			\u001B\u0012\u0007.\u000A(viewFilter, \u0011\u0012\u0007.\u000A(\u001E\u0012\u0007.\u000A(viewFilter), 0));
		}
	}
}

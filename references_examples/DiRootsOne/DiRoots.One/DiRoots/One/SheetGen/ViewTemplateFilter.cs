using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.SheetGen.Models;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002D9 RID: 729
	public class ViewTemplateFilter : ModelBase
	{
		// Token: 0x1700084D RID: 2125
		// (get) Token: 0x06001E2E RID: 7726 RVA: 0x000BED28 File Offset: 0x000BCF28
		// (set) Token: 0x06001E2F RID: 7727 RVA: 0x000BED3C File Offset: 0x000BCF3C
		public Dictionary<string, object> Items { get; set; } = new Dictionary<string, object>();

		// Token: 0x1700084E RID: 2126
		// (get) Token: 0x06001E30 RID: 7728 RVA: 0x000BED50 File Offset: 0x000BCF50
		// (set) Token: 0x06001E31 RID: 7729 RVA: 0x000BED64 File Offset: 0x000BCF64
		public Dictionary<string, object> SelectItems
		{
			get
			{
				return this.VB;
			}
			set
			{
				this.VB = value;
				\u0007\u0013\u000A.\u000A(this, "SelectItems");
			}
		}

		// Token: 0x1700084F RID: 2127
		// (get) Token: 0x06001E32 RID: 7730 RVA: 0x000BED84 File Offset: 0x000BCF84
		// (set) Token: 0x06001E33 RID: 7731 RVA: 0x000BED98 File Offset: 0x000BCF98
		public string SearchText
		{
			get
			{
				return this.ZB;
			}
			set
			{
				this.ZB = value;
				\u0007\u0013\u000A.\u000A(this, "SearchText");
			}
		}

		// Token: 0x06001E34 RID: 7732 RVA: 0x000BEDB8 File Offset: 0x000BCFB8
		public void GettingDisciplineFilterInformation(ViewTemplateFilter filter, List<ViewManagerView> viewInfo, string firstItem)
		{
			Func<ViewManagerView, bool> func;
			if ((func = ViewTemplateFilter.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewTemplateFilter.GettingDisciplineFilterInformation(ViewTemplateFilter, List<ViewManagerView>, string)).MethodHandle;
				}
				func = (ViewTemplateFilter.<>c.\u000A = new Func<ViewManagerView, bool>(ViewTemplateFilter.<>c.\u001F.\u0019));
			}
			IEnumerable<ViewManagerView> enumerable = Enumerable.Where<ViewManagerView>(viewInfo, func);
			Func<ViewManagerView, SelectionNamedItem> func2;
			if ((func2 = ViewTemplateFilter.<>c.\u0007) == null)
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
				func2 = (ViewTemplateFilter.<>c.\u0007 = new Func<ViewManagerView, SelectionNamedItem>(ViewTemplateFilter.<>c.\u001F.\u0018));
			}
			List<SelectionNamedItem> d = Enumerable.ToList<SelectionNamedItem>(Enumerable.Distinct<SelectionNamedItem>(Enumerable.Select<ViewManagerView, SelectionNamedItem>(enumerable, func2), new \u001B\u001A()));
			ViewTemplateFilter.CT(filter, firstItem, d);
		}

		// Token: 0x06001E35 RID: 7733 RVA: 0x000BEE4C File Offset: 0x000BD04C
		public void GettingTypeFilterInformation(ViewTemplateFilter filter, List<ViewManagerView> viewInfo, string firstItem)
		{
			Func<ViewManagerView, SelectionNamedItem> func;
			if ((func = ViewTemplateFilter.<>c.\u001D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewTemplateFilter.GettingTypeFilterInformation(ViewTemplateFilter, List<ViewManagerView>, string)).MethodHandle;
				}
				func = (ViewTemplateFilter.<>c.\u001D = new Func<ViewManagerView, SelectionNamedItem>(ViewTemplateFilter.<>c.\u001F.\u0005));
			}
			List<SelectionNamedItem> list = Enumerable.ToList<SelectionNamedItem>(Enumerable.Distinct<SelectionNamedItem>(Enumerable.Select<ViewManagerView, SelectionNamedItem>(viewInfo, func), new \u001B\u001A()));
			object u001F = list;
			Comparison<SelectionNamedItem> u000A;
			if ((u000A = ViewTemplateFilter.<>c.\u0004) == null)
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
				u000A = (ViewTemplateFilter.<>c.\u0004 = new Comparison<SelectionNamedItem>(ViewTemplateFilter.<>c.\u001F.\u0016));
			}
			\u0020\u001F\u0016.\u000A(u001F, u000A);
			ViewTemplateFilter.CT(filter, firstItem, list);
		}

		// Token: 0x06001E36 RID: 7734 RVA: 0x000BEEE0 File Offset: 0x000BD0E0
		private static void CT(ViewTemplateFilter F, string R, List<SelectionNamedItem> D)
		{
			ViewTemplateFilter.\u0006\u0011 u0006_u = new ViewTemplateFilter.\u0006\u0011();
			u0006_u.\u001F = F;
			\u0016\u001B\u0016.\u000A(D, 0, \u000B\u001B\u0016.\u000A(0, R));
			\u0005\u001B\u0016.\u000A(D, new Action<SelectionNamedItem>(u0006_u.\u000A));
			\u0008\u001A\u0016.\u000A(u0006_u.\u001F, \u0015\u0017\u0018.\u000A(\u001B\u001A\u0016.\u000A(u0006_u.\u001F)));
		}

		// Token: 0x04000C6D RID: 3181
		private Dictionary<string, object> VB;

		// Token: 0x04000C6E RID: 3182
		private string ZB;

		// Token: 0x04000C6F RID: 3183
		[CompilerGenerated]
		private Dictionary<string, object> DY;

		// Token: 0x020009B8 RID: 2488
		[CompilerGenerated]
		private sealed class \u0006\u0011
		{
			// Token: 0x060053A7 RID: 21415 RVA: 0x001ED434 File Offset: 0x001EB634
			internal void \u000A(SelectionNamedItem \u001F)
			{
				\u001F\u0014\u0018.\u000A(\u001B\u001A\u0016.\u000A(this.\u001F), \u0012\u000B\u0002.\u000A(\u001F), \u0015\u001C\u0007.\u0007(\u001F));
			}

			// Token: 0x0400253D RID: 9533
			public ViewTemplateFilter \u001F;
		}
	}
}

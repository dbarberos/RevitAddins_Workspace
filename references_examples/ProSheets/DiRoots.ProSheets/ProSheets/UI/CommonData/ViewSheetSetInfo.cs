using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;

namespace ProSheets.UI.CommonData
{
	// Token: 0x02000098 RID: 152
	public class ViewSheetSetInfo : ModelBase
	{
		// Token: 0x06000938 RID: 2360 RVA: 0x00039654 File Offset: 0x00037854
		public ViewSheetSetInfo(string name, IViewSheetSet vs)
		{
			\u001B\u0014\u0014.\u0003(this, name);
			if (vs != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSheetSetInfo..ctor(string, IViewSheetSet)).MethodHandle;
				}
				\u000E\u001B\u0003.\u0018(this, \u0005\u001B\u0003.\u0018(vs));
				IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0005\u001B\u0003.\u0018(vs));
				Func<View, VSSetItem> func;
				if ((func = ViewSheetSetInfo.<>c.\u0018) == null)
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
					func = (ViewSheetSetInfo.<>c.\u0018 = new Func<View, VSSetItem>(ViewSheetSetInfo.<>c.\u000C.\u0003));
				}
				\u001B\u001B\u0003.\u0018(this, Enumerable.ToList<VSSetItem>(Enumerable.Select<View, VSSetItem>(enumerable, func)));
				\u0001\u001B\u0003.\u0018(this, \u0009\u0002\u0018.\u0018(\u0015\u0007\u000F.\u000C(vs)).\u000C());
			}
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x00039700 File Offset: 0x00037900
		public void UpdateItems(IViewSheetSet vsset)
		{
			IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0005\u001B\u0003.\u0018(vsset));
			Func<View, VSSetItem> func;
			if ((func = ViewSheetSetInfo.<>c.\u0014) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewSheetSetInfo.UpdateItems(IViewSheetSet)).MethodHandle;
				}
				func = (ViewSheetSetInfo.<>c.\u0014 = new Func<View, VSSetItem>(ViewSheetSetInfo.<>c.\u000C.\u0016));
			}
			\u001B\u001B\u0003.\u0018(this, Enumerable.ToList<VSSetItem>(Enumerable.Select<View, VSSetItem>(enumerable, func)));
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x0600093A RID: 2362 RVA: 0x00039764 File Offset: 0x00037964
		// (set) Token: 0x0600093B RID: 2363 RVA: 0x00039778 File Offset: 0x00037978
		public long ElementId { get; set; }

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x0600093C RID: 2364 RVA: 0x0003978C File Offset: 0x0003798C
		// (set) Token: 0x0600093D RID: 2365 RVA: 0x000397A0 File Offset: 0x000379A0
		public string Name
		{
			get
			{
				return this.\u0018;
			}
			set
			{
				this.\u0018 = value;
				\u000C\u0005\u0003.\u0018(this, "Name");
			}
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x0600093E RID: 2366 RVA: 0x000397C0 File Offset: 0x000379C0
		// (set) Token: 0x0600093F RID: 2367 RVA: 0x000397D4 File Offset: 0x000379D4
		public bool IsChecked
		{
			get
			{
				return this.\u0014;
			}
			set
			{
				this.\u0014 = value;
				\u000C\u0005\u0003.\u0018(this, "IsChecked");
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x000397F4 File Offset: 0x000379F4
		// (set) Token: 0x06000941 RID: 2369 RVA: 0x00039808 File Offset: 0x00037A08
		public bool IsHidden
		{
			get
			{
				return this.\u0003;
			}
			set
			{
				this.\u0003 = value;
				\u000C\u0005\u0003.\u0018(this, "IsHidden");
			}
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x00039828 File Offset: 0x00037A28
		// (set) Token: 0x06000943 RID: 2371 RVA: 0x0003983C File Offset: 0x00037A3C
		public ViewSet ItemSet { get; set; }

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x00039850 File Offset: 0x00037A50
		// (set) Token: 0x06000945 RID: 2373 RVA: 0x00039864 File Offset: 0x00037A64
		public List<VSSetItem> Items { get; set; }

		// Token: 0x04000455 RID: 1109
		private string \u0018;

		// Token: 0x04000456 RID: 1110
		private bool \u0014;

		// Token: 0x04000457 RID: 1111
		private bool \u0003;

		// Token: 0x04000458 RID: 1112
		[CompilerGenerated]
		private long \u0016;

		// Token: 0x04000459 RID: 1113
		[CompilerGenerated]
		private ViewSet \u000F;

		// Token: 0x0400045A RID: 1114
		[CompilerGenerated]
		private List<VSSetItem> \u0012;
	}
}

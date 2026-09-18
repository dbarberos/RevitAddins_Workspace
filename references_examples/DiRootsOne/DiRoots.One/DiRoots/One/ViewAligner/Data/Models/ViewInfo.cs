using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.TreeGrid;
using DiRoots.One.ViewAligner.Interfaces;

namespace DiRoots.One.ViewAligner.Data.Models
{
	// Token: 0x020000D4 RID: 212
	public class ViewInfo : BaseTreeItem, IRevitElement
	{
		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000804 RID: 2052 RVA: 0x0002E224 File Offset: 0x0002C424
		// (set) Token: 0x06000805 RID: 2053 RVA: 0x0002E238 File Offset: 0x0002C438
		public string UniqueId { get; set; }

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000806 RID: 2054 RVA: 0x0002E24C File Offset: 0x0002C44C
		// (set) Token: 0x06000807 RID: 2055 RVA: 0x0002E260 File Offset: 0x0002C460
		public long Id { get; set; }

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x0002E274 File Offset: 0x0002C474
		// (set) Token: 0x06000809 RID: 2057 RVA: 0x0002E288 File Offset: 0x0002C488
		public long ViewPortId { get; set; }

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x0600080A RID: 2058 RVA: 0x0002E29C File Offset: 0x0002C49C
		// (set) Token: 0x0600080B RID: 2059 RVA: 0x0002E2B0 File Offset: 0x0002C4B0
		public string Name { get; set; }

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x0600080C RID: 2060 RVA: 0x0002E2C4 File Offset: 0x0002C4C4
		// (set) Token: 0x0600080D RID: 2061 RVA: 0x0002E2D8 File Offset: 0x0002C4D8
		public string SheetNumber { get; set; }

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x0600080E RID: 2062 RVA: 0x0002E2EC File Offset: 0x0002C4EC
		// (set) Token: 0x0600080F RID: 2063 RVA: 0x0002E300 File Offset: 0x0002C500
		public ViewTypeInfo ViewType { get; set; }

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000810 RID: 2064 RVA: 0x0002E314 File Offset: 0x0002C514
		// (set) Token: 0x06000811 RID: 2065 RVA: 0x0002E328 File Offset: 0x0002C528
		public int ViewScale { get; set; }

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000812 RID: 2066 RVA: 0x0002E33C File Offset: 0x0002C53C
		public string DisplayName
		{
			get
			{
				ViewTypeInfo viewTypeInfo = \u0010\u001B\u001D.\u001D(this);
				if (viewTypeInfo == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.get_DisplayName()).MethodHandle;
					}
					return \u0016\u0011\u001D.\u000A(this);
				}
				if (\u000D\u001B\u001D.\u0007(viewTypeInfo) == 6)
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
					return \u0002\u0013\u000A.\u000A(\u0005\u001C\u001D.\u0007(this), " - ", \u0016\u0011\u001D.\u000A(this));
				}
				return \u0002\u0013\u000A.\u000A(\u000B\u0011\u001D.\u000A(\u0010\u001B\u001D.\u001D(this)), ": ", \u0016\u0011\u001D.\u000A(this));
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000813 RID: 2067 RVA: 0x0002E3C8 File Offset: 0x0002C5C8
		// (set) Token: 0x06000814 RID: 2068 RVA: 0x0002E3DC File Offset: 0x0002C5DC
		public bool CanBeAlignedByCoords { get; set; }

		// Token: 0x06000815 RID: 2069 RVA: 0x0002E3F0 File Offset: 0x0002C5F0
		public ViewInfo Clone()
		{
			ViewInfo viewInfo = \u001D\u0011\u001D.\u000A();
			\u0007\u0011\u001D.\u000A(viewInfo, \u0019\u0003\u001D.\u001D(this));
			\u000A\u0011\u001D.\u000A(viewInfo, \u0016\u0011\u001D.\u000A(this));
			\u001E\u0008\u001D.\u000A(viewInfo, \u0005\u001C\u001D.\u0007(this));
			\u001A\u001B\u001D.\u000A(viewInfo, \u000A\u0008\u001D.\u001D(this));
			\u0004\u0011\u001D.\u000A(viewInfo, \u0020\u000E\u001D.\u001D(this));
			\u0013\u001B\u001D.\u000A(viewInfo, \u0018\u001C\u001D.\u0007(this));
			ViewInfo viewInfo2 = viewInfo;
			if (\u0010\u001B\u001D.\u001D(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.Clone()).MethodHandle;
				}
				object u001F = viewInfo2;
				ViewTypeInfo viewTypeInfo = \u001F\u0011\u001D.\u000A();
				\u0009\u001B\u001D.\u000A(viewTypeInfo, \u000D\u001B\u001D.\u0007(\u0010\u001B\u001D.\u001D(this)));
				\u0001\u001B\u001D.\u000A(viewTypeInfo, \u000B\u0011\u001D.\u000A(\u0010\u001B\u001D.\u001D(this)));
				\u0015\u001B\u001D.\u000A(u001F, viewTypeInfo);
			}
			IList<BaseTreeItem> list = \u0015\u0012\u001D.\u0007(this);
			List<ViewInfo> list2;
			if (list == null)
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
				list2 = null;
			}
			else
			{
				Func<BaseTreeItem, ViewInfo> func;
				if ((func = ViewInfo.<>c.\u000A) == null)
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
					func = (ViewInfo.<>c.\u000A = new Func<BaseTreeItem, ViewInfo>(ViewInfo.<>c.\u001F.\u0007));
				}
				list2 = Enumerable.ToList<ViewInfo>(Enumerable.Select<BaseTreeItem, ViewInfo>(list, func));
			}
			List<ViewInfo> list3;
			if ((list3 = list2) == null)
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
				list3 = \u0013\u0008\u001D.\u000A();
			}
			List<ViewInfo> u000A = list3;
			\u000E\u0008\u001D.\u000A(viewInfo2, u000A);
			return viewInfo2;
		}

		// Token: 0x04000330 RID: 816
		[CompilerGenerated]
		private string LR;

		// Token: 0x04000331 RID: 817
		[CompilerGenerated]
		private long W;

		// Token: 0x04000332 RID: 818
		[CompilerGenerated]
		private long SR;

		// Token: 0x04000333 RID: 819
		[CompilerGenerated]
		private string K;

		// Token: 0x04000334 RID: 820
		[CompilerGenerated]
		private string HR;

		// Token: 0x04000335 RID: 821
		[CompilerGenerated]
		private ViewTypeInfo M;

		// Token: 0x04000336 RID: 822
		[CompilerGenerated]
		private int BR;

		// Token: 0x04000337 RID: 823
		[CompilerGenerated]
		private bool UR;
	}
}

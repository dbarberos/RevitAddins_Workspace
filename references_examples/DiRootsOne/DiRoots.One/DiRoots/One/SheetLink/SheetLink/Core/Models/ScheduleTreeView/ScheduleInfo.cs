using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.TreeGrid;
using DiRoots.One.SheetLink.UI.Controls;

namespace DiRoots.One.SheetLink.SheetLink.Core.Models.ScheduleTreeView
{
	// Token: 0x02000264 RID: 612
	public class ScheduleInfo : BaseTreeItem, ICategoryModel
	{
		// Token: 0x060018BA RID: 6330 RVA: 0x000A0ACC File Offset: 0x0009ECCC
		public ScheduleInfo()
		{
			\u000D\u0013\u0005.\u0007(this, new List<ScheduleInfo>());
		}

		// Token: 0x060018BB RID: 6331 RVA: 0x000A0AEC File Offset: 0x0009ECEC
		public ScheduleInfo(string name, long elemId)
		{
			\u000E\u0013\u0005.\u000A(this, name);
			\u0010\u0013\u0005.\u000A(this, elemId);
			\u000D\u0013\u0005.\u0007(this, new List<ScheduleInfo>());
		}

		// Token: 0x060018BC RID: 6332 RVA: 0x000A0B18 File Offset: 0x0009ED18
		public ScheduleInfo(ICategoryModel categoryModel)
		{
			\u0010\u0013\u0005.\u000A(this, \u0017\u001C\u0018.\u000A(categoryModel));
			\u000E\u0013\u0005.\u000A(this, \u000B\u0015\u0018.\u000A(categoryModel));
			\u001E\u0013\u0005.\u000A(this, \u001D\u000C\u0018.\u000A(categoryModel));
			\u001B\u0013\u0005.\u000A(this, \u0011\u0013\u0005.\u000A(categoryModel));
			\u0008\u0013\u0005.\u000A(this, \u000F\u001C\u0018.\u000A(categoryModel));
			\u000D\u0013\u0005.\u0007(this, new List<ScheduleInfo>());
		}

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x060018BD RID: 6333 RVA: 0x000A0B7C File Offset: 0x0009ED7C
		// (set) Token: 0x060018BE RID: 6334 RVA: 0x000A0B90 File Offset: 0x0009ED90
		public new List<ScheduleInfo> Children
		{
			get
			{
				return this.ZC;
			}
			set
			{
				this.ZC = value;
				\u001A\u0013\u0005.\u000A(\u0015\u0012\u001D.\u001D(this));
				List<ScheduleInfo>.Enumerator enumerator = \u0009\u0019\u0005.\u000A(value);
				try
				{
					while (\u0015\u0019\u0005.\u000A(ref enumerator))
					{
						ScheduleInfo scheduleInfo = \u0001\u0019\u0005.\u000A(ref enumerator);
						\u0013\u0013\u0005.\u000A(scheduleInfo, this);
						\u0017\u0013\u0005.\u000A(scheduleInfo, \u0014\u0013\u0005.\u000A(this));
						\u0020\u0013\u0005.\u000A(\u0015\u0012\u001D.\u001D(this), scheduleInfo);
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleInfo.set_Children(List<ScheduleInfo>)).MethodHandle;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				\u0007\u0013\u000A.\u000A(this, "Children");
			}
		}

		// Token: 0x060018BF RID: 6335 RVA: 0x000A0C34 File Offset: 0x0009EE34
		public void Initialize()
		{
			List<ScheduleInfo>.Enumerator enumerator = \u0009\u0019\u0005.\u000A(\u0018\u0018\u0005.\u001D(this));
			try
			{
				while (\u0015\u0019\u0005.\u000A(ref enumerator))
				{
					ScheduleInfo u001F = \u0001\u0019\u0005.\u000A(ref enumerator);
					IEnumerable<ScheduleInfo> enumerable = \u0018\u0018\u0005.\u0007(u001F);
					Func<ScheduleInfo, string> func;
					if ((func = ScheduleInfo.<>c.\u000A) == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleInfo.Initialize()).MethodHandle;
						}
						func = (ScheduleInfo.<>c.\u000A = new Func<ScheduleInfo, string>(ScheduleInfo.<>c.\u001F.\u0007));
					}
					\u000D\u0013\u0005.\u001D(u001F, Enumerable.ToList<ScheduleInfo>(Enumerable.OrderBy<ScheduleInfo, string>(enumerable, func)));
					\u0013\u0013\u0005.\u000A(u001F, this);
					\u000C\u0013\u0005.\u000A(u001F);
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

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x060018C0 RID: 6336 RVA: 0x000A0CEC File Offset: 0x0009EEEC
		// (set) Token: 0x060018C1 RID: 6337 RVA: 0x000A0D00 File Offset: 0x0009EF00
		public bool IsFolder { get; set; }

		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x060018C2 RID: 6338 RVA: 0x000A0D14 File Offset: 0x0009EF14
		// (set) Token: 0x060018C3 RID: 6339 RVA: 0x000A0D28 File Offset: 0x0009EF28
		public long Id { get; set; }

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x060018C4 RID: 6340 RVA: 0x000A0D3C File Offset: 0x0009EF3C
		// (set) Token: 0x060018C5 RID: 6341 RVA: 0x000A0D50 File Offset: 0x0009EF50
		public string Name { get; set; }

		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x060018C6 RID: 6342 RVA: 0x000A0D64 File Offset: 0x0009EF64
		// (set) Token: 0x060018C7 RID: 6343 RVA: 0x000A0D78 File Offset: 0x0009EF78
		public bool IsSelected { get; set; }

		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x060018C8 RID: 6344 RVA: 0x000A0D8C File Offset: 0x0009EF8C
		// (set) Token: 0x060018C9 RID: 6345 RVA: 0x000A0DA0 File Offset: 0x0009EFA0
		public bool FilterPassed { get; set; }

		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x060018CA RID: 6346 RVA: 0x000A0DB4 File Offset: 0x0009EFB4
		// (set) Token: 0x060018CB RID: 6347 RVA: 0x000A0DC8 File Offset: 0x0009EFC8
		public List<string> CatType { get; set; }

		// Token: 0x040009A9 RID: 2473
		private List<ScheduleInfo> ZC;

		// Token: 0x040009AA RID: 2474
		[CompilerGenerated]
		private bool XC;

		// Token: 0x040009AB RID: 2475
		[CompilerGenerated]
		private long W;

		// Token: 0x040009AC RID: 2476
		[CompilerGenerated]
		private string K;

		// Token: 0x040009AD RID: 2477
		[CompilerGenerated]
		private bool PC;

		// Token: 0x040009AE RID: 2478
		[CompilerGenerated]
		private bool TH;

		// Token: 0x040009AF RID: 2479
		[CompilerGenerated]
		private List<string> YY;
	}
}

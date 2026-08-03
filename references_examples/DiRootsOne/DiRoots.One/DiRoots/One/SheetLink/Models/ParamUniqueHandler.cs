using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x0200024A RID: 586
	public class ParamUniqueHandler
	{
		// Token: 0x06001793 RID: 6035 RVA: 0x0009A3F0 File Offset: 0x000985F0
		public ParamUniqueHandler()
		{
			\u0003\u0011\u0005.\u000A(this, new Dictionary<long, List<long>>());
			\u0012\u0011\u0005.\u000A(this, new List<int>());
		}

		// Token: 0x1700067F RID: 1663
		// (get) Token: 0x06001794 RID: 6036 RVA: 0x0009A41C File Offset: 0x0009861C
		// (set) Token: 0x06001795 RID: 6037 RVA: 0x0009A430 File Offset: 0x00098630
		public string UniqueId { get; set; }

		// Token: 0x17000680 RID: 1664
		// (get) Token: 0x06001796 RID: 6038 RVA: 0x0009A444 File Offset: 0x00098644
		// (set) Token: 0x06001797 RID: 6039 RVA: 0x0009A458 File Offset: 0x00098658
		public Dictionary<long, List<long>> CatdWithParams { get; set; }

		// Token: 0x17000681 RID: 1665
		// (get) Token: 0x06001798 RID: 6040 RVA: 0x0009A46C File Offset: 0x0009866C
		// (set) Token: 0x06001799 RID: 6041 RVA: 0x0009A480 File Offset: 0x00098680
		public List<int> UsedParams { get; set; }

		// Token: 0x0600179A RID: 6042 RVA: 0x0009A494 File Offset: 0x00098694
		internal static void \u001D(\u0015\u001C \u001F, List<RevitParameter> \u000A, CategoryCollection \u0007)
		{
			long u000A = 0L;
			if (\u0007 != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParamUniqueHandler.\u001D(\u0015\u001C, List<RevitParameter>, CategoryCollection)).MethodHandle;
				}
				u000A = \u001B\u0020\u0018.\u000A(\u0007);
			}
			List<RevitParameter>.Enumerator enumerator = \u0013\u000D\u0018.\u000A(\u000A);
			try
			{
				while (\u0011\u000D\u0018.\u000A(ref enumerator))
				{
					ParamUniqueHandler.\u0019\u000D u0019_u000D = new ParamUniqueHandler.\u0019\u000D();
					u0019_u000D.\u001F = \u0014\u000D\u0018.\u000A(ref enumerator);
					if (!Enumerable.Contains<RevitParameter>(\u001B\u0011\u0005.\u000A(\u001F), u0019_u000D.\u001F, new \u0012\u000E()))
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
						\u0017\u0010\u0018.\u000A(\u001B\u0011\u0005.\u000A(\u001F), u0019_u000D.\u001F);
						\u000E\u0011\u0005.\u0007(u0019_u000D.\u001F, \u0002\u0005\u0018.\u000A().ToString());
						ParamUniqueHandler paramUniqueHandler = \u0020\u0011\u0005.\u000A();
						\u001E\u0011\u0005.\u000A(paramUniqueHandler, \u000F\u0020\u0018.\u0007(u0019_u000D.\u001F));
						\u000D\u0011\u0005.\u000A(\u0002\u0020\u0018.\u000A(paramUniqueHandler), u000A, \u001F\u001B\u0019.\u000A());
						\u0001\u000E\u0019.\u000A(\u001C\u0011\u0005.\u000A(\u0002\u0020\u0018.\u000A(paramUniqueHandler), u000A), \u0017\u000B\u0018.\u0007(u0019_u000D.\u001F));
						\u0011\u0011\u0005.\u000A(\u0012\u0020\u0018.\u0007(\u001F), \u000F\u0020\u0018.\u0007(u0019_u000D.\u001F), paramUniqueHandler);
					}
					else
					{
						RevitParameter u001F = \u0008\u0011\u0005.\u000A(\u001B\u0011\u0005.\u000A(\u001F), new Predicate<RevitParameter>(u0019_u000D.\u000A));
						\u000E\u0011\u0005.\u0007(u0019_u000D.\u001F, \u000F\u0020\u0018.\u0007(u001F));
						ParamUniqueHandler u001F2 = \u0006\u0020\u0018.\u000A(\u0012\u0020\u0018.\u0007(\u001F), \u000F\u0020\u0018.\u0007(u001F));
						if (!\u0010\u0011\u0005.\u000A(\u0002\u0020\u0018.\u000A(u001F2), u000A))
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
							\u000D\u0011\u0005.\u000A(\u0002\u0020\u0018.\u000A(u001F2), u000A, \u001F\u001B\u0019.\u000A());
						}
						if (!\u001A\u0008\u0019.\u000A(\u001C\u0011\u0005.\u000A(\u0002\u0020\u0018.\u000A(u001F2), u000A), \u0017\u000B\u0018.\u0007(u0019_u000D.\u001F)))
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
							\u0001\u000E\u0019.\u000A(\u001C\u0011\u0005.\u000A(\u0002\u0020\u0018.\u000A(u001F2), u000A), \u0017\u000B\u0018.\u0007(u0019_u000D.\u001F));
						}
					}
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

		// Token: 0x04000949 RID: 2377
		[CompilerGenerated]
		private string \u001F;

		// Token: 0x0400094A RID: 2378
		[CompilerGenerated]
		private Dictionary<long, List<long>> \u000A;

		// Token: 0x0400094B RID: 2379
		[CompilerGenerated]
		private List<int> \u0007;

		// Token: 0x02000922 RID: 2338
		[CompilerGenerated]
		private sealed class \u0019\u000D
		{
			// Token: 0x060051D8 RID: 20952 RVA: 0x001E974C File Offset: 0x001E794C
			internal bool \u000A(RevitParameter \u001F)
			{
				return \u0012\u000E.\u001F(\u001F, this.\u001F);
			}

			// Token: 0x040023FE RID: 9214
			public RevitParameter \u001F;
		}
	}
}

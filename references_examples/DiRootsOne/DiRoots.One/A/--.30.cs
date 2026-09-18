using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.TreeGrid;
using DiRoots.One.ViewAligner.Data.Models;

namespace A
{
	// Token: 0x020000C8 RID: 200
	internal class \u0019\u0019 : \u0004\u0019
	{
		// Token: 0x17000210 RID: 528
		// (get) Token: 0x060007B5 RID: 1973 RVA: 0x0002C8B0 File Offset: 0x0002AAB0
		// (set) Token: 0x060007B6 RID: 1974 RVA: 0x0002C8C4 File Offset: 0x0002AAC4
		public string SearchWord { get; set; }

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x060007B7 RID: 1975 RVA: 0x0002C8D8 File Offset: 0x0002AAD8
		// (set) Token: 0x060007B8 RID: 1976 RVA: 0x0002C8EC File Offset: 0x0002AAEC
		public Predicate<ViewInfo> IsTargetViewFilter { get; set; }

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x060007B9 RID: 1977 RVA: 0x0002C900 File Offset: 0x0002AB00
		// (set) Token: 0x060007BA RID: 1978 RVA: 0x0002C914 File Offset: 0x0002AB14
		public Predicate<ViewInfo> InViewSetFilter { get; set; }

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x060007BB RID: 1979 RVA: 0x0002C928 File Offset: 0x0002AB28
		// (set) Token: 0x060007BC RID: 1980 RVA: 0x0002C93C File Offset: 0x0002AB3C
		public Predicate<ViewInfo> SimilarViewsOnlyFilter { get; set; }

		// Token: 0x060007BD RID: 1981 RVA: 0x0002C950 File Offset: 0x0002AB50
		public bool \u0004(object \u001F)
		{
			ViewInfo viewInfo = \u001B\u001D\u000E.\u001F(\u001F);
			if (viewInfo != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0019.\u0004(object)).MethodHandle;
				}
				if (\u000F\u0010\u001D.\u000A(\u000E\u0010\u001D.\u000A(this), viewInfo))
				{
					bool flag = true;
					if (!\u0010\u0010\u001D.\u000A(\u000D\u0010\u001D.\u000A(this)))
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
						string text = \u001E\u000D\u001D.\u000A(viewInfo);
						bool flag2;
						if (text == null)
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
							flag2 = false;
						}
						else
						{
							flag2 = (\u001C\u0010\u001D.\u0007(text, \u000D\u0010\u001D.\u000A(this), StringComparison.CurrentCultureIgnoreCase) >= 0);
						}
						flag = flag2;
						if (flag)
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
							this.\u0019(viewInfo);
						}
					}
					if (flag)
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
						Predicate<ViewInfo> predicate = \u0003\u0010\u001D.\u000A(this);
						bool flag3;
						if (predicate == null)
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
							flag3 = true;
						}
						else
						{
							flag3 = \u000F\u0010\u001D.\u000A(predicate, viewInfo);
						}
						bool flag4;
						if (flag3)
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
							Predicate<ViewInfo> predicate2 = \u0012\u0010\u001D.\u000A(this);
							if (predicate2 == null)
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
								flag4 = true;
							}
							else
							{
								flag4 = \u000F\u0010\u001D.\u000A(predicate2, viewInfo);
							}
						}
						else
						{
							flag4 = false;
						}
						flag = flag4;
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
						this.\u0018(\u0015\u0012\u001D.\u0007(viewInfo), true);
					}
					return flag;
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
			return false;
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0002CA78 File Offset: 0x0002AC78
		private void \u0019(ITreeItem \u001F)
		{
			for (ITreeItem u001F = \u0008\u0010\u001D.\u000A(\u001F); u001F != null; u001F = \u0008\u0010\u001D.\u000A(u001F))
			{
				if (!\u0011\u0010\u001D.\u000A(u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0019.\u0019(ITreeItem)).MethodHandle;
					}
					\u001B\u0010\u001D.\u000A(u001F, true);
				}
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

		// Token: 0x060007BF RID: 1983 RVA: 0x0002CACC File Offset: 0x0002ACCC
		private void \u0018(IEnumerable<ITreeItem> \u001F, bool \u000A)
		{
			IEnumerator<ITreeItem> enumerator = \u0013\u0010\u001D.\u000A(\u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ITreeItem u001F = \u0014\u0010\u001D.\u000A(enumerator);
					\u0017\u0010\u001D.\u000A(u001F, new bool?(\u000A));
					if (\u0020\u0010\u001D.\u000A(u001F))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u0019.\u0018(IEnumerable<ITreeItem>, bool)).MethodHandle;
						}
						this.\u0018(\u001E\u0010\u001D.\u000A(u001F), \u000A);
					}
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x0400031C RID: 796
		[CompilerGenerated]
		private string \u001F;

		// Token: 0x0400031D RID: 797
		[CompilerGenerated]
		private Predicate<ViewInfo> \u000A;

		// Token: 0x0400031E RID: 798
		[CompilerGenerated]
		private Predicate<ViewInfo> \u0007;

		// Token: 0x0400031F RID: 799
		[CompilerGenerated]
		private Predicate<ViewInfo> \u001D;
	}
}

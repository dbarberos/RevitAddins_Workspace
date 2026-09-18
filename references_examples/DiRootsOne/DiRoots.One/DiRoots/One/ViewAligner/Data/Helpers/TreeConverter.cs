using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.TreeGrid;
using DiRoots.One.ViewAligner.Data.Models;
using DiRoots.Revit.DataCollectors.Models;

namespace DiRoots.One.ViewAligner.Data.Helpers
{
	// Token: 0x020000D7 RID: 215
	public static class TreeConverter
	{
		// Token: 0x06000824 RID: 2084 RVA: 0x0002E670 File Offset: 0x0002C870
		public static List<ViewInfo> Convert(IEnumerable<IBrowserNode> root)
		{
			List<ViewInfo> list = \u0013\u0008\u001D.\u000A();
			IEnumerator<IBrowserNode> enumerator = \u0006\u0011\u001D.\u000A(root);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					IBrowserNode u001F = \u0002\u0011\u001D.\u000A(enumerator);
					Func<IBrowserNode, ViewInfo> u000A;
					if ((u000A = TreeConverter.\u0008\u0019.\u001F) == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(TreeConverter.Convert(IEnumerable<IBrowserNode>)).MethodHandle;
						}
						u000A = (TreeConverter.\u0008\u0019.\u001F = new Func<IBrowserNode, ViewInfo>(\u000E\u0019.\u001F));
					}
					ViewInfo u000A2 = TreeConverter.\u001F(u001F, u000A);
					\u000D\u0008\u001D.\u000A(list, u000A2);
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return list;
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0002E710 File Offset: 0x0002C910
		private static ViewInfo \u001F(IBrowserNode \u001F, Func<IBrowserNode, ViewInfo> \u000A)
		{
			TreeConverter.\u001B\u0019 u001B_u = new TreeConverter.\u001B\u0019();
			u001B_u.\u001F = \u000A;
			ViewInfo viewInfo = \u0003\u0011\u001D.\u000A(u001B_u.\u001F, \u001F);
			if (!\u0012\u0011\u001D.\u000A(\u001F))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(TreeConverter.\u001F(IBrowserNode, Func<IBrowserNode, ViewInfo>)).MethodHandle;
				}
				List<ViewInfo> u000A = Enumerable.ToList<ViewInfo>(Enumerable.Select<IBrowserNode, ViewInfo>(\u000F\u0011\u001D.\u000A(\u001F), new Func<IBrowserNode, ViewInfo>(u001B_u.\u000A)));
				\u000E\u0008\u001D.\u000A(viewInfo, u000A);
			}
			return viewInfo;
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x0002E784 File Offset: 0x0002C984
		public static BaseTreeItem RemoveView(BaseTreeItem node)
		{
			if (node != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TreeConverter.RemoveView(BaseTreeItem)).MethodHandle;
				}
				if (\u000B\u001C\u001D.\u000A(node) == null)
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
				}
				else
				{
					BaseTreeItem baseTreeItem = \u000A\u0004\u000E.\u001F(\u000B\u001C\u001D.\u000A(node));
					IList<BaseTreeItem> u001F = \u0015\u0012\u001D.\u0007(baseTreeItem);
					\u001C\u0011\u001D.\u000A(u001F, node);
					if (\u0010\u0008\u001D.\u000A(u001F) == 0)
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
						BaseTreeItem result;
						if ((result = \u0015\u0008\u001D.\u000A(baseTreeItem)) == null)
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
							result = baseTreeItem;
						}
						return result;
					}
					return null;
				}
			}
			return null;
		}

		// Token: 0x020007E7 RID: 2023
		[CompilerGenerated]
		private static class \u0008\u0019
		{
			// Token: 0x04001FF6 RID: 8182
			public static Func<IBrowserNode, ViewInfo> \u001F;
		}

		// Token: 0x020007E8 RID: 2024
		[CompilerGenerated]
		private sealed class \u001B\u0019
		{
			// Token: 0x06004D08 RID: 19720 RVA: 0x001DD6B8 File Offset: 0x001DB8B8
			internal ViewInfo \u000A(IBrowserNode \u001F)
			{
				return TreeConverter.\u001F(\u001F, this.\u001F);
			}

			// Token: 0x04001FF7 RID: 8183
			public Func<IBrowserNode, ViewInfo> \u001F;
		}
	}
}

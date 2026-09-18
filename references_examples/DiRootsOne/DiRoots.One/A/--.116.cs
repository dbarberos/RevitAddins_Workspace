using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x020001FC RID: 508
	internal static class \u0010\u000F
	{
		// Token: 0x060012F2 RID: 4850 RVA: 0x0006F250 File Offset: 0x0006D450
		internal static bool \u001D(List<ReportInfo> \u001F, ReportInfo \u000A, ChangedColumns \u0007, List<DropDownparamInfo> \u001D)
		{
			\u0010\u000F.\u000D\u000F u000D_u000F = new \u0010\u000F.\u000D\u000F();
			if (\u001E\u000B\u0018.\u000A(\u0020\u001F\u001D.\u0007(\u0014\u0006\u0018.\u000A(\u0007))))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010\u000F.\u001D(List<ReportInfo>, ReportInfo, ChangedColumns, List<DropDownparamInfo>)).MethodHandle;
				}
				return true;
			}
			u000D_u000F.\u001F = \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u0014\u0006\u0018.\u000A(\u0007)));
			StorageType storageType = \u0011\u001F\u001D.\u0007(\u0014\u0006\u0018.\u000A(\u0007));
			if (\u001D != null)
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
				if (u000D_u000F.\u001F == -1001006L)
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
					if (\u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u000D\u0003\u0018.\u0007(\u0010\u0003\u0018.\u000A(\u0014\u0006\u0018.\u000A(\u0007))))) == -2000023L)
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
						if (EnumHandler.\u0003(\u0017\u0006\u0018.\u000A(\u0007)) > 1)
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
							\u0012\u0006\u0018.\u0007(\u000A, \u0004\u001E\u000A.\u000A(\u001F\u001F\u0019.\u000A(), " (ex: Interior, Exterior)"));
							\u000F\u0006\u0018.\u000A(\u001F, \u000A);
							return false;
						}
						return true;
					}
				}
				if (Enumerable.Any<DropDownparamInfo>(\u001D, new Func<DropDownparamInfo, bool>(u000D_u000F.\u000A)))
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
					return true;
				}
			}
			if (u000D_u000F.\u001F != -1006304L)
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
				if (u000D_u000F.\u001F == -1002550L)
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
				}
				else
				{
					if (storageType == 1)
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
						return \u0010\u000F.\u0004(\u001F, \u000A, \u0007);
					}
					if (storageType == 2)
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
						if (\u0012\u0003\u0018.\u0007(\u0014\u0006\u0018.\u000A(\u0007)))
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
							if (!\u0010\u000F.\u000A.\u0018(\u0017\u0006\u0018.\u000A(\u0007), \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u0014\u0006\u0018.\u000A(\u0007)))))
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
								\u0012\u0006\u0018.\u0007(\u000A, \u001C\u0003\u0018.\u000A(\u0010\u000F.\u000A));
								\u000F\u0006\u0018.\u000A(\u001F, \u000A);
								return false;
							}
						}
					}
					return true;
				}
			}
			return \u0010\u000F.\u0019(\u001F, \u000A, \u0007);
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x0006F450 File Offset: 0x0006D650
		private static bool \u0004(List<ReportInfo> \u001F, ReportInfo \u000A, ChangedColumns \u0007)
		{
			if (!\u0010\u000F.\u001F.\u0018(\u0017\u0006\u0018.\u000A(\u0007), \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u0014\u0006\u0018.\u000A(\u0007)))))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010\u000F.\u0004(List<ReportInfo>, ReportInfo, ChangedColumns)).MethodHandle;
				}
				\u0012\u0006\u0018.\u0007(\u000A, \u001C\u0003\u0018.\u000A(\u0010\u000F.\u001F));
				\u000F\u0006\u0018.\u000A(\u001F, \u000A);
				return false;
			}
			return true;
		}

		// Token: 0x060012F4 RID: 4852 RVA: 0x0006F4B8 File Offset: 0x0006D6B8
		private static bool \u0019(List<ReportInfo> \u001F, ReportInfo \u000A, ChangedColumns \u0007)
		{
			if (!\u0010\u000F.\u0007.\u0018(\u0017\u0006\u0018.\u000A(\u0007), \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u0014\u0006\u0018.\u000A(\u0007)))))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010\u000F.\u0019(List<ReportInfo>, ReportInfo, ChangedColumns)).MethodHandle;
				}
				\u0012\u0006\u0018.\u0007(\u000A, \u001C\u0003\u0018.\u000A(\u0010\u000F.\u0007));
				\u000F\u0006\u0018.\u000A(\u001F, \u000A);
				return false;
			}
			return true;
		}

		// Token: 0x04000787 RID: 1927
		private static readonly \u0019\u000E \u001F = new \u0019\u000E();

		// Token: 0x04000788 RID: 1928
		private static readonly \u0007\u000E \u000A = new \u0007\u000E();

		// Token: 0x04000789 RID: 1929
		private static readonly \u000A\u000E \u0007 = new \u000A\u000E();

		// Token: 0x02000898 RID: 2200
		[CompilerGenerated]
		private sealed class \u000D\u000F
		{
			// Token: 0x06004F97 RID: 20375 RVA: 0x001E5600 File Offset: 0x001E3800
			internal bool \u000A(DropDownparamInfo \u001F)
			{
				return \u0005\u0019\u0010.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x04002259 RID: 8793
			public long \u001F;
		}
	}
}

using System;
using System.Collections.Generic;
using DiRoots.RoomPro.Comparers;
using DiRoots.RoomPro.Models;

namespace A
{
	// Token: 0x020000A7 RID: 167
	internal class \u0010\u0004 : IComparer<ModelSpatialElement>
	{
		// Token: 0x060006BD RID: 1725 RVA: 0x00026F7C File Offset: 0x0002517C
		public \u0010\u0004(SpatialElementSortPriority \u001F, SortDirection \u000A = SortDirection.Ascending)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00026FA0 File Offset: 0x000251A0
		public int Compare(ModelSpatialElement x, ModelSpatialElement y)
		{
			int num = \u0010\u0004.\u0004(x, y);
			int num2 = \u0010\u0004.\u001D(x, y);
			int num3 = \u0010\u0004.\u0007(x, y);
			SpatialElementSortPriority u001F = this.\u001F;
			int result;
			if (u001F != SpatialElementSortPriority.Name)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010\u0004.Compare(ModelSpatialElement, ModelSpatialElement)).MethodHandle;
				}
				if (u001F != SpatialElementSortPriority.Level)
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
					result = this.\u0019(num, num2, num3);
				}
				else
				{
					result = this.\u0019(num3, num, num2);
				}
			}
			else
			{
				result = this.\u0019(num2, num, num3);
			}
			return result;
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00027028 File Offset: 0x00025228
		private static int \u0007(ModelSpatialElement \u001F, ModelSpatialElement \u000A)
		{
			bool flag = \u000A\u000D\u0007.\u0007(\u001F) != \u0020\u0007\u000E.\u001F;
			bool flag2 = \u000A\u000D\u0007.\u0007(\u000A) != \u0020\u0007\u000E.\u001F;
			int num = \u000E\u0016\u001D.\u000A(ref flag2, flag);
			if (num == 0 && flag && flag2)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010\u0004.\u0007(ModelSpatialElement, ModelSpatialElement)).MethodHandle;
				}
				double num2 = \u000E\u0007\u001D.\u000A(\u000A\u000D\u0007.\u0007(\u001F));
				num = \u0003\u0014\u0007.\u000A(ref num2, \u000E\u0007\u001D.\u000A(\u000A\u000D\u0007.\u0007(\u000A)));
			}
			return num;
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x000270A8 File Offset: 0x000252A8
		private static int \u001D(ModelSpatialElement \u001F, ModelSpatialElement \u000A)
		{
			if (\u001D\u000D\u0007.\u0007(\u001F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010\u0004.\u001D(ModelSpatialElement, ModelSpatialElement)).MethodHandle;
				}
				return 1;
			}
			return \u0013\u001F\u001D.\u000A(\u001D\u000D\u0007.\u0007(\u001F), \u001D\u000D\u0007.\u0007(\u000A));
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x000270EC File Offset: 0x000252EC
		private static int \u0004(ModelSpatialElement \u001F, ModelSpatialElement \u000A)
		{
			float num;
			bool flag = \u001B\u0016\u001D.\u000A(\u0007\u000D\u0007.\u0007(\u001F), ref num);
			float u000A;
			bool flag2 = \u001B\u0016\u001D.\u000A(\u0007\u000D\u0007.\u0007(\u000A), ref u000A);
			int result;
			if (flag && flag2)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010\u0004.\u0004(ModelSpatialElement, ModelSpatialElement)).MethodHandle;
				}
				result = \u0008\u0016\u001D.\u000A(ref num, u000A);
			}
			else
			{
				if (!flag)
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
					if (!flag2)
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
						return \u0013\u001F\u001D.\u000A(\u0007\u000D\u0007.\u0007(\u001F), \u0007\u000D\u0007.\u0007(\u000A));
					}
				}
				result = \u000E\u0016\u001D.\u000A(ref flag2, flag);
			}
			return result;
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00027184 File Offset: 0x00025384
		private int \u0019(int \u001F, int \u000A, int \u0007)
		{
			int num;
			if (this.\u000A != SortDirection.Descending)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010\u0004.\u0019(int, int, int)).MethodHandle;
				}
				num = 1;
			}
			else
			{
				num = -1;
			}
			int num2 = num;
			int result;
			if (\u001F != 0)
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
				result = \u001F * num2;
			}
			else
			{
				int num3;
				if (\u000A == 0)
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
					num3 = \u0007;
				}
				else
				{
					num3 = \u000A;
				}
				result = num3;
			}
			return result;
		}

		// Token: 0x040002B0 RID: 688
		private readonly SpatialElementSortPriority \u001F;

		// Token: 0x040002B1 RID: 689
		private readonly SortDirection \u000A;
	}
}

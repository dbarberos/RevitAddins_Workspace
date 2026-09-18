using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000245 RID: 581
	public class DropDownparamInfo
	{
		// Token: 0x0600173C RID: 5948 RVA: 0x00098A40 File Offset: 0x00096C40
		public DropDownparamInfo(int grpName, long paramId, BuiltInCategory builtInCategory, bool isType = false, bool isOptional = false)
		{
			\u0010\u0008\u0005.\u000A(this, grpName);
			\u000D\u0008\u0005.\u000A(this, paramId);
			\u001C\u0008\u0005.\u000A(this, builtInCategory);
			\u0003\u0008\u0005.\u000A(this, isOptional);
			\u0012\u0008\u0005.\u000A(this, isType);
		}

		// Token: 0x1700065C RID: 1628
		// (get) Token: 0x0600173E RID: 5950 RVA: 0x00098A94 File Offset: 0x00096C94
		// (set) Token: 0x0600173F RID: 5951 RVA: 0x00098AA8 File Offset: 0x00096CA8
		public int GroupIndex { get; set; }

		// Token: 0x1700065D RID: 1629
		// (get) Token: 0x06001740 RID: 5952 RVA: 0x00098ABC File Offset: 0x00096CBC
		// (set) Token: 0x06001741 RID: 5953 RVA: 0x00098AD0 File Offset: 0x00096CD0
		public long ParamId { get; set; }

		// Token: 0x1700065E RID: 1630
		// (get) Token: 0x06001742 RID: 5954 RVA: 0x00098AE4 File Offset: 0x00096CE4
		// (set) Token: 0x06001743 RID: 5955 RVA: 0x00098AF8 File Offset: 0x00096CF8
		public BuiltInCategory ValueCategory { get; set; }

		// Token: 0x1700065F RID: 1631
		// (get) Token: 0x06001744 RID: 5956 RVA: 0x00098B0C File Offset: 0x00096D0C
		// (set) Token: 0x06001745 RID: 5957 RVA: 0x00098B20 File Offset: 0x00096D20
		public bool IsOptional { get; set; }

		// Token: 0x17000660 RID: 1632
		// (get) Token: 0x06001746 RID: 5958 RVA: 0x00098B34 File Offset: 0x00096D34
		// (set) Token: 0x06001747 RID: 5959 RVA: 0x00098B48 File Offset: 0x00096D48
		public bool IsType { get; set; }

		// Token: 0x17000661 RID: 1633
		// (get) Token: 0x06001748 RID: 5960 RVA: 0x00098B5C File Offset: 0x00096D5C
		// (set) Token: 0x06001749 RID: 5961 RVA: 0x00098B70 File Offset: 0x00096D70
		public bool IsKeyParam { get; set; }

		// Token: 0x17000662 RID: 1634
		// (get) Token: 0x0600174A RID: 5962 RVA: 0x00098B84 File Offset: 0x00096D84
		// (set) Token: 0x0600174B RID: 5963 RVA: 0x00098B98 File Offset: 0x00096D98
		internal static List<DropDownparamInfo> DropDownparamsCache { get; set; } = \u000E\u0008\u0005.\u000A();

		// Token: 0x0600174C RID: 5964 RVA: 0x00098BAC File Offset: 0x00096DAC
		internal static List<DropDownparamInfo> \u0005(bool \u001F)
		{
			if (\u001A\u0008\u0005.\u000A(\u001D\u001A\u0019.\u000A()) == 0)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(DropDownparamInfo.\u0005(bool)).MethodHandle;
				}
				object u001F = \u001D\u001A\u0019.\u000A();
				List<DropDownparamInfo> list = \u000E\u0008\u0005.\u000A();
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1152335L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1001350L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1007702L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1001708L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1002063L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1007200L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1008620L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1001702L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1001365L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1001351L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1002064L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1007201L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1005313L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1140753L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(1, -1001103L, -2000240L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(2, -1114251L, -2008102L, true, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(3, -1114172L, -2008119L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(4, -1012101L, -2000112L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(5, -1002106L, -1L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(6, -1006700L, -2006040L, true, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(7, -1007100L, -2006020L, true, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(8, -1012202L, -2006000L, false, true));
				\u001B\u0008\u0005.\u000A(list, \u001E\u0008\u0005.\u000A(8, -1012201L, -2006000L, false, true));
				\u0013\u0008\u0005.\u000A(u001F, list);
				object u001F2 = \u001D\u001A\u0019.\u000A();
				List<DropDownparamInfo> list2 = \u000E\u0008\u0005.\u000A();
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10000, -1001107L, -2000240L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10000, -1006009L, -2000240L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10000, -1001352L, -2000240L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10000, -1012014L, -2000240L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10000, -1007101L, -2000240L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10000, -1001952L, -2000240L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10000, -1002062L, -2000240L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10000, -1006922L, -2000240L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10000, -1012801L, -2000240L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10000, -1114317L, -2000240L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10000, -1114000L, -2000240L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10001, -1002053L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10002, -1013439L, -2009014L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10002, -1013435L, -2009014L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10002, -1013436L, -2009014L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10002, -1013437L, -2009014L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10002, -1013438L, -2009014L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10002, -1013440L, -2009014L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10003, -1012100L, -2000112L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10003, -1012113L, -2000112L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10004, -1140234L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10004, -1140230L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10004, -1114147L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10005, -1114146L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10005, -1114136L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10006, -1006210L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10007, -1005163L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10008, -1011002L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10009, -1140333L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10010, -1140334L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10011, -1001122L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10012, -1006305L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10013, -1005172L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10014, -1140335L, -1L, false, false));
				\u001B\u0008\u0005.\u000A(list2, \u001E\u0008\u0005.\u000A(10015, -1001006L, -1L, false, false));
				\u0013\u0008\u0005.\u000A(u001F2, list2);
				IEnumerable<DropDownparamInfo> enumerable = \u001D\u001A\u0019.\u000A();
				Func<DropDownparamInfo, bool> func;
				if ((func = DropDownparamInfo.<>c.\u000A) == null)
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
					func = (DropDownparamInfo.<>c.\u000A = new Func<DropDownparamInfo, bool>(DropDownparamInfo.<>c.\u001F.\u001D));
				}
				IEnumerable<DropDownparamInfo> enumerable2 = Enumerable.Where<DropDownparamInfo>(enumerable, func);
				Func<DropDownparamInfo, int> func2;
				if ((func2 = DropDownparamInfo.<>c.\u0007) == null)
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
					func2 = (DropDownparamInfo.<>c.\u0007 = new Func<DropDownparamInfo, int>(DropDownparamInfo.<>c.\u001F.\u0004));
				}
				int num = Enumerable.Max<DropDownparamInfo>(enumerable2, func2);
				num++;
				List<\u001A\u000F>.Enumerator enumerator = \u0014\u0008\u0005.\u000A(\u001A\u000F.\u0018(\u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A()), \u001F));
				try
				{
					while (\u0008\u0008\u0005.\u000A(ref enumerator))
					{
						\u001A\u000F u001F3 = \u0017\u0008\u0005.\u000A(ref enumerator);
						DropDownparamInfo dropDownparamInfo = \u001E\u0008\u0005.\u000A(num++, \u0020\u0008\u0005.\u000A(u001F3), -1L, true, false);
						\u0011\u0008\u0005.\u000A(dropDownparamInfo, true);
						\u001B\u0008\u0005.\u000A(\u001D\u001A\u0019.\u000A(), dropDownparamInfo);
						num++;
					}
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
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			return \u001D\u001A\u0019.\u000A();
		}

		// Token: 0x04000926 RID: 2342
		[CompilerGenerated]
		private int \u001F;

		// Token: 0x04000927 RID: 2343
		[CompilerGenerated]
		private long \u000A;

		// Token: 0x04000928 RID: 2344
		[CompilerGenerated]
		private BuiltInCategory \u0007;

		// Token: 0x04000929 RID: 2345
		[CompilerGenerated]
		private bool \u001D;

		// Token: 0x0400092A RID: 2346
		[CompilerGenerated]
		private bool \u0004;

		// Token: 0x0400092B RID: 2347
		[CompilerGenerated]
		private bool \u0019;

		// Token: 0x0400092C RID: 2348
		[CompilerGenerated]
		private static List<DropDownparamInfo> \u0018;
	}
}

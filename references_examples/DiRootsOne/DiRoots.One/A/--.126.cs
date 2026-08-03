using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x02000230 RID: 560
	internal static class \u0002\u001C
	{
		// Token: 0x06001600 RID: 5632 RVA: 0x0008EAE8 File Offset: 0x0008CCE8
		internal static void \u001F(\u0015\u001C \u001F, Document \u000A, SfSpreadsheet \u0007, IWorkbook \u001D)
		{
			List<Category> u = Enumerable.ToList<Category>(Enumerable.Cast<Category>(\u000D\u0001\u001D.\u000A(\u0010\u0001\u001D.\u000A(\u000A))));
			List<ParamValueInfo> list = \u0008\u001E\u0018.\u000A();
			\u0002\u001C.\u001F(\u001F, \u0007, \u001D, "Model Objects", u, 1, true, list, false);
			\u0002\u001C.\u001F(\u001F, \u0007, \u001D, "Annotation Objects", u, 2, false, list, false);
			\u0002\u001C.\u001F(\u001F, \u0007, \u001D, "Analytical Model Objects", u, 5, false, list, false);
			\u0002\u001C.\u001F(\u001F, \u0007, \u001D, "Imported Categories", u, 1, false, list, true);
			\u0002\u001C.\u0007(\u000A, \u0007, \u001D, list);
		}

		// Token: 0x06001601 RID: 5633 RVA: 0x0008EB6C File Offset: 0x0008CD6C
		private static void \u001F(\u0015\u001C \u001F, SfSpreadsheet \u000A, IWorkbook \u0007, string \u001D, List<Category> \u0004, CategoryType \u0019, bool \u0018, List<ParamValueInfo> \u0005, bool \u0016 = false)
		{
			\u0002\u001C.\u0016\u001C u0016_u001C = new \u0002\u001C.\u0016\u001C();
			u0016_u001C.\u001F = \u001F\u001B\u0019.\u000A();
			\u0001\u000E\u0019.\u000A(u0016_u001C.\u001F, -2000051L);
			List<RevitParameter> list = RevitParameter.YO(\u001F, \u0018);
			if (\u0019 == 2)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u001C.\u001F(\u0015\u001C, SfSpreadsheet, IWorkbook, string, List<Category>, CategoryType, bool, List<ParamValueInfo>, bool)).MethodHandle;
				}
				IEnumerable<Category> enumerable = \u0004;
				Func<Category, bool> func;
				if ((func = \u0002\u001C.<>c.\u000A) == null)
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
					func = (\u0002\u001C.<>c.\u000A = new Func<Category, bool>(\u0002\u001C.<>c.\u001F.\u000E));
				}
				IEnumerable<Category> enumerable2 = Enumerable.Where<Category>(enumerable, func);
				Func<Category, string> func2;
				if ((func2 = \u0002\u001C.<>c.\u0007) == null)
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
					func2 = (\u0002\u001C.<>c.\u0007 = new Func<Category, string>(\u0002\u001C.<>c.\u001F.\u0008));
				}
				\u0004 = Enumerable.ToList<Category>(Enumerable.OrderBy<Category, string>(enumerable2, func2));
				object u001F = list;
				Action<RevitParameter> u000A;
				if ((u000A = \u0002\u001C.<>c.\u001D) == null)
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
					u000A = (\u0002\u001C.<>c.\u001D = new Action<RevitParameter>(\u0002\u001C.<>c.\u001F.\u001B));
				}
				\u001C\u0020\u0018.\u000A(u001F, u000A);
			}
			else if (\u0019 == 1)
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
				IEnumerable<Category> enumerable3 = \u0004;
				Func<Category, bool> func3;
				if ((func3 = \u0002\u001C.<>c.\u0004) == null)
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
					func3 = (\u0002\u001C.<>c.\u0004 = new Func<Category, bool>(\u0002\u001C.<>c.\u001F.\u0011));
				}
				IEnumerable<Category> enumerable4 = Enumerable.Where<Category>(enumerable3, func3);
				Func<Category, string> func4;
				if ((func4 = \u0002\u001C.<>c.\u0019) == null)
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
					func4 = (\u0002\u001C.<>c.\u0019 = new Func<Category, string>(\u0002\u001C.<>c.\u001F.\u001E));
				}
				\u0004 = Enumerable.ToList<Category>(Enumerable.OrderBy<Category, string>(enumerable4, func4));
				object u001F2 = list;
				Action<RevitParameter> u000A2;
				if ((u000A2 = \u0002\u001C.<>c.\u0018) == null)
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
					u000A2 = (\u0002\u001C.<>c.\u0018 = new Action<RevitParameter>(\u0002\u001C.<>c.\u001F.\u0020));
				}
				\u001C\u0020\u0018.\u000A(u001F2, u000A2);
			}
			else
			{
				IEnumerable<Category> enumerable5 = \u0004;
				Func<Category, bool> func5;
				if ((func5 = \u0002\u001C.<>c.\u0005) == null)
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
					func5 = (\u0002\u001C.<>c.\u0005 = new Func<Category, bool>(\u0002\u001C.<>c.\u001F.\u0017));
				}
				IEnumerable<Category> enumerable6 = Enumerable.Where<Category>(enumerable5, func5);
				Func<Category, string> func6;
				if ((func6 = \u0002\u001C.<>c.\u0016) == null)
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
					func6 = (\u0002\u001C.<>c.\u0016 = new Func<Category, string>(\u0002\u001C.<>c.\u001F.\u0014));
				}
				\u0004 = Enumerable.ToList<Category>(Enumerable.OrderBy<Category, string>(enumerable6, func6));
				object u001F3 = list;
				Action<RevitParameter> u000A3;
				if ((u000A3 = \u0002\u001C.<>c.\u000B) == null)
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
					u000A3 = (\u0002\u001C.<>c.\u000B = new Action<RevitParameter>(\u0002\u001C.<>c.\u001F.\u0013));
				}
				\u001C\u0020\u0018.\u000A(u001F3, u000A3);
			}
			if (!\u0016)
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
				\u0004 = Enumerable.ToList<Category>(Enumerable.Where<Category>(\u0004, new Func<Category, bool>(u0016_u001C.\u001D)));
			}
			else
			{
				\u0004 = Enumerable.ToList<Category>(Enumerable.Where<Category>(\u0004, new Func<Category, bool>(u0016_u001C.\u0004)));
			}
			if (\u000A == null)
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
				u0016_u001C.\u000A = \u000A\u000F\u0004.\u000A(\u0003\u001E\u001D.\u000A(\u0007), \u001D);
			}
			else
			{
				u0016_u001C.\u000A = \u000A\u000F\u0004.\u000A(\u0003\u001E\u001D.\u000A(\u0004\u0009\u0018.\u000A(\u000A)), \u001D);
				\u0004\u000B\u0005.\u000A(\u000A, \u001D);
				\u000B\u0009\u0018.\u000A(\u0002\u0009\u0018.\u0007(\u000A), false);
			}
			if (\u001D\u000B\u0005.\u000A(\u0004) != 0)
			{
				\u001F\u000B\u0005.\u000A(list, u0016_u001C.\u000A, 2);
				u0016_u001C.\u0007 = 3;
				List<Category>.Enumerator enumerator = \u0020\u0002\u0004.\u000A(\u0004);
				try
				{
					while (\u0011\u0002\u0004.\u000A(ref enumerator))
					{
						Category u001F4 = \u001E\u0002\u0004.\u000A(ref enumerator);
						u0016_u001C.\u0007 = \u0002\u001C.\u0004(u001F4, \u000A, u0016_u001C.\u000A, list, u0016_u001C.\u0007, \u0005);
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
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				\u0002\u001C.\u001D(\u000A, u0016_u001C.\u000A, list, u0016_u001C.\u0007);
				\u0009\u0016\u0005.\u000A(list, u0016_u001C.\u000A, 2);
				\u0001\u0016\u0005.\u000A(Enumerable.ToList<ParamValueInfo>(Enumerable.Where<ParamValueInfo>(\u0005, new Func<ParamValueInfo, bool>(u0016_u001C.\u0019))), new Action<ParamValueInfo>(u0016_u001C.\u0018));
				\u001A\u0001\u0019.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(u0016_u001C.\u000A), 2, 2));
				return;
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
			if (\u000A == null)
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
				\u0007\u000B\u0005.\u000A(u0016_u001C.\u000A);
				return;
			}
			\u000A\u000B\u0005.\u000A(\u000A, \u001D);
		}

		// Token: 0x06001602 RID: 5634 RVA: 0x0008EF7C File Offset: 0x0008D17C
		internal static void \u000A(\u0015\u001C \u001F, Document \u000A, SfSpreadsheet \u0007, IWorkbook \u001D, string \u0004)
		{
			\u0002\u001C.\u000B\u001C u000B_u001C = new \u0002\u001C.\u000B\u001C();
			List<ParamValueInfo> list = \u0008\u001E\u0018.\u000A();
			Category u001F = \u001B\u0001\u001D.\u000A(\u000D\u0001\u001D.\u000A(\u0010\u0001\u001D.\u000A(\u000A)), -2000051L);
			if (\u0007 == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u001C.\u000A(\u0015\u001C, Document, SfSpreadsheet, IWorkbook, string)).MethodHandle;
				}
				u000B_u001C.\u001F = \u000A\u000F\u0004.\u000A(\u0003\u001E\u001D.\u000A(\u001D), \u0004);
			}
			else
			{
				u000B_u001C.\u001F = \u000A\u000F\u0004.\u000A(\u0003\u001E\u001D.\u000A(\u0004\u0009\u0018.\u000A(\u0007)), \u0004);
				\u0004\u000B\u0005.\u000A(\u0007, \u0004);
				\u000B\u0009\u0018.\u000A(\u0002\u0009\u0018.\u0007(\u0007), false);
			}
			List<RevitParameter> list2 = RevitParameter.YO(\u001F, false);
			object u001F2 = list2;
			Action<RevitParameter> u000A;
			if ((u000A = \u0002\u001C.<>c.\u0002) == null)
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
				u000A = (\u0002\u001C.<>c.\u0002 = new Action<RevitParameter>(\u0002\u001C.<>c.\u001F.\u001A));
			}
			\u001C\u0020\u0018.\u000A(u001F2, u000A);
			\u001F\u000B\u0005.\u000A(list2, u000B_u001C.\u001F, 2);
			u000B_u001C.\u000A = \u0002\u001C.\u0004(u001F, \u0007, u000B_u001C.\u001F, list2, 3, list);
			\u0002\u001C.\u001D(\u0007, u000B_u001C.\u001F, list2, u000B_u001C.\u000A);
			\u0009\u0016\u0005.\u000A(list2, u000B_u001C.\u001F, 2);
			\u0001\u0016\u0005.\u000A(Enumerable.ToList<ParamValueInfo>(Enumerable.Where<ParamValueInfo>(list, new Func<ParamValueInfo, bool>(u000B_u001C.\u0007))), new Action<ParamValueInfo>(u000B_u001C.\u001D));
			\u0002\u001C.\u0007(\u000A, \u0007, \u001D, list);
			\u001A\u0001\u0019.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(u000B_u001C.\u001F), 2, 2));
		}

		// Token: 0x06001603 RID: 5635 RVA: 0x0008F0EC File Offset: 0x0008D2EC
		private static void \u0007(Document \u001F, SfSpreadsheet \u000A, IWorkbook \u0007, List<ParamValueInfo> \u001D)
		{
			Func<ParamValueInfo, int> func;
			if ((func = \u0002\u001C.<>c.\u0006) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u001C.\u0007(Document, SfSpreadsheet, IWorkbook, List<ParamValueInfo>)).MethodHandle;
				}
				func = (\u0002\u001C.<>c.\u0006 = new Func<ParamValueInfo, int>(\u0002\u001C.<>c.\u001F.\u000C));
			}
			IEnumerable<IGrouping<int, ParamValueInfo>> enumerable = Enumerable.GroupBy<ParamValueInfo, int>(\u001D, func);
			Func<IGrouping<int, ParamValueInfo>, int> func2;
			if ((func2 = \u0002\u001C.<>c.\u000F) == null)
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
				func2 = (\u0002\u001C.<>c.\u000F = new Func<IGrouping<int, ParamValueInfo>, int>(\u0002\u001C.<>c.\u001F.\u0015));
			}
			Func<IGrouping<int, ParamValueInfo>, List<ParamValueInfo>> func3;
			if ((func3 = \u0002\u001C.<>c.\u0012) == null)
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
				func3 = (\u0002\u001C.<>c.\u0012 = new Func<IGrouping<int, ParamValueInfo>, List<ParamValueInfo>>(\u0002\u001C.<>c.\u001F.\u0001));
			}
			object u001F = Enumerable.ToDictionary<IGrouping<int, ParamValueInfo>, int, List<ParamValueInfo>>(enumerable, func2, func3);
			int num = 1;
			Dictionary<int, List<ParamValueInfo>>.Enumerator enumerator = \u001B\u0011\u0018.\u000A(u001F);
			try
			{
				while (\u000D\u0011\u0018.\u000A(ref enumerator))
				{
					KeyValuePair<int, List<ParamValueInfo>> keyValuePair = \u0008\u0011\u0018.\u000A(ref enumerator);
					if (\u000E\u0011\u0018.\u000A(\u0010\u0011\u0018.\u000A(ref keyValuePair)) > 0)
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
						if (\u000A == null)
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
							\u0016\u000F.\u001D(\u001F, \u0007, \u0010\u0011\u0018.\u000A(ref keyValuePair), num++);
						}
						else
						{
							\u0016\u000F.\u001D(\u001F, \u000A, \u0007, \u0010\u0011\u0018.\u000A(ref keyValuePair), num++);
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

		// Token: 0x06001604 RID: 5636 RVA: 0x0008F230 File Offset: 0x0008D430
		private static void \u001D(SfSpreadsheet \u001F, IWorksheet \u000A, List<RevitParameter> \u0007, int \u001D)
		{
			\u0013\u001E\u0018.\u000A(\u001A\u001E\u0018.\u000A(\u000A), \u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(\u000A), 2, 1, \u001D, \u0008\u000D\u0018.\u000A(\u0007)));
			\u0002\u001C.\u0018(\u000A, \u001F);
			int u = 4;
			\u000F\u000B\u0005.\u000A(\u000A, 3, 12.0);
			\u0006\u000B\u0005.\u000A(\u001F, 3);
			Func<RevitParameter, bool> func;
			if ((func = \u0002\u001C.<>c.\u0003) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u001C.\u001D(SfSpreadsheet, IWorksheet, List<RevitParameter>, int)).MethodHandle;
				}
				func = (\u0002\u001C.<>c.\u0003 = new Func<RevitParameter, bool>(\u0002\u001C.<>c.\u001F.\u0009));
			}
			if (Enumerable.FirstOrDefault<RevitParameter>(\u0007, func) != null)
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
				\u000F\u000B\u0005.\u000A(\u000A, 4, 12.0);
				\u0006\u000B\u0005.\u000A(\u001F, 4);
				u = 5;
			}
			\u0006\u001F\u0018.\u000A(\u001F\u0014\u001D.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(\u000A), 1, 1, 2, u)), true);
			if (\u001F == null)
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
				\u000B\u000B\u0005.\u000A(\u000A, 1);
				\u0005\u000B\u0005.\u000A(\u000A, 1);
				return;
			}
			\u0002\u000B\u0005.\u000A(\u0002\u0009\u0018.\u0007(\u001F), 2, 2, 70.0);
			\u000B\u000B\u0005.\u000A(\u0015\u0009\u0018.\u000A(\u001F), 1);
			\u0019\u000B\u0005.\u000A(\u0016\u000B\u0005.\u000A(\u0002\u0009\u0018.\u0007(\u001F)), 1, 1, true);
			\u0005\u000B\u0005.\u000A(\u0015\u0009\u0018.\u000A(\u001F), 1);
			\u0019\u000B\u0005.\u000A(\u0018\u000B\u0005.\u000A(\u0002\u0009\u0018.\u0007(\u001F)), 1, 1, true);
		}

		// Token: 0x06001605 RID: 5637 RVA: 0x0008F384 File Offset: 0x0008D584
		private static int \u0004(Category \u001F, SfSpreadsheet \u000A, IWorksheet \u0007, List<RevitParameter> \u001D, int \u0004, List<ParamValueInfo> \u0019)
		{
			IEnumerable<Category> enumerable = Enumerable.Cast<Category>(\u0008\u0001\u001D.\u000A(\u001F));
			Func<Category, string> func;
			if ((func = \u0002\u001C.<>c.\u001C) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u001C.\u0004(Category, SfSpreadsheet, IWorksheet, List<RevitParameter>, int, List<ParamValueInfo>)).MethodHandle;
				}
				func = (\u0002\u001C.<>c.\u001C = new Func<Category, string>(\u0002\u001C.<>c.\u001F.\u001F\u000A));
			}
			List<Category> u001F = Enumerable.ToList<Category>(Enumerable.OrderBy<Category, string>(enumerable, func));
			int i = 0;
			while (i < \u0008\u000D\u0018.\u000A(\u001D))
			{
				string text = \u0002\u001C.\u0005(\u001F, \u0004\u001E\u0018.\u0007(\u0004\u0008\u0018.\u000A(\u001D, i)));
				\u0013\u0009\u0019.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u0007), \u0004, i + 1), text);
				if (\u0005\u000C\u0019.\u001D(\u0004\u0008\u0018.\u000A(\u001D, i)))
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
					\u0012\u000B\u0005.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u0007), \u0004, i + 1), "DiRootsReadOnly");
				}
				if (!\u0020\u000B\u0018.\u000A(\u0004\u0008\u0018.\u000A(\u001D, i)))
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
					if (\u0008\u0013\u000A.\u000A(\u0004\u001E\u0018.\u0007(\u0004\u0008\u0018.\u000A(\u001D, i)), "Projection"))
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
						ParamValueInfo paramValueInfo = \u001B\u000B\u0018.\u000A();
						\u0002\u000B\u0018.\u000A(paramValueInfo, 1);
						\u0019\u000B\u0018.\u000A(paramValueInfo, \u0003\u000B\u0005.\u000A(\u0007));
						\u0004\u000B\u0018.\u000A(paramValueInfo, \u0014\u0011\u001D.\u000A(\u0007));
						\u0005\u000B\u0018.\u000A(paramValueInfo, \u0004 - 1);
						\u0016\u000B\u0018.\u000A(paramValueInfo, i + 1);
						\u0011\u000B\u0018.\u000A(paramValueInfo, ExcelParamTypes.LineStyles);
						\u001D\u000B\u0018.\u000A(\u0019, paramValueInfo);
						\u0007\u000B\u0018.\u000A(\u0004\u0008\u0018.\u000A(\u001D, i), true);
					}
				}
				if (!\u0020\u000B\u0018.\u000A(\u0004\u0008\u0018.\u000A(\u001D, i)))
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
					if (\u0008\u0013\u000A.\u000A(\u0004\u001E\u0018.\u0007(\u0004\u0008\u0018.\u000A(\u001D, i)), "Cut"))
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
						ParamValueInfo paramValueInfo2 = \u001B\u000B\u0018.\u000A();
						\u0002\u000B\u0018.\u000A(paramValueInfo2, 2);
						\u0019\u000B\u0018.\u000A(paramValueInfo2, \u0003\u000B\u0005.\u000A(\u0007));
						\u0004\u000B\u0018.\u000A(paramValueInfo2, \u0014\u0011\u001D.\u000A(\u0007));
						\u0005\u000B\u0018.\u000A(paramValueInfo2, \u0004 - 1);
						\u0016\u000B\u0018.\u000A(paramValueInfo2, i + 1);
						\u0011\u000B\u0018.\u000A(paramValueInfo2, ExcelParamTypes.LineStyles);
						\u001D\u000B\u0018.\u000A(\u0019, paramValueInfo2);
						\u0007\u000B\u0018.\u000A(\u0004\u0008\u0018.\u000A(\u001D, i), true);
					}
				}
				if (\u0008\u0013\u000A.\u000A(\u0004\u001E\u0018.\u0007(\u0004\u0008\u0018.\u000A(\u001D, i)), "Projection"))
				{
					goto IL_26A;
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
				if (\u0008\u0013\u000A.\u000A(\u0004\u001E\u0018.\u0007(\u0004\u0008\u0018.\u000A(\u001D, i)), "Cut"))
				{
					for (;;)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						goto IL_26A;
					}
				}
				IL_2BF:
				if (\u0008\u0013\u000A.\u000A(\u0004\u001E\u0018.\u0007(\u0004\u0008\u0018.\u000A(\u001D, i)), "Color"))
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
					Color? color = \u0002\u001C.\u0019(\u001F);
					if (\u0020\u0006\u0004.\u000A(ref color))
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
						\u0002\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u0007), \u0004, i + 2)), \u0004\u0010\u0004.\u000A(ref color));
					}
				}
				i++;
				continue;
				IL_26A:
				if (!\u001A\u0006\u0007.\u000A(text))
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
					\u0020\u001F\u0018.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u0007), \u0004, i + 1)), ExcelHAlign.HAlignCenter);
					goto IL_2BF;
				}
				\u0012\u000B\u0005.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u0007), \u0004, i + 1), "DiRootsReadOnly");
				goto IL_2BF;
			}
			for (;;)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			int num = \u0004 + 1;
			List<Category>.Enumerator enumerator = \u0020\u0002\u0004.\u000A(u001F);
			try
			{
				while (\u0011\u0002\u0004.\u000A(ref enumerator))
				{
					Category u001F2 = \u001E\u0002\u0004.\u000A(ref enumerator);
					int j = 0;
					while (j < \u0008\u000D\u0018.\u000A(\u001D))
					{
						string text2 = "";
						if (\u0008\u0013\u000A.\u000A(\u0004\u001E\u0018.\u0007(\u0004\u0008\u0018.\u000A(\u001D, j)), "Name"))
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
							text2 = \u0004\u001E\u000A.\u000A(text2, "       |---- ");
						}
						text2 = \u0004\u001E\u000A.\u000A(text2, \u0002\u001C.\u0005(u001F2, \u0004\u001E\u0018.\u0007(\u0004\u0008\u0018.\u000A(\u001D, j))));
						\u0013\u0009\u0019.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u0007), num, j + 1), text2);
						if (\u0005\u000C\u0019.\u001D(\u0004\u0008\u0018.\u000A(\u001D, j)))
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
							\u0012\u000B\u0005.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u0007), num, j + 1), "DiRootsReadOnly");
						}
						if (\u0008\u0013\u000A.\u000A(\u0004\u001E\u0018.\u0007(\u0004\u0008\u0018.\u000A(\u001D, j)), "Projection"))
						{
							goto IL_47F;
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
						if (\u0008\u0013\u000A.\u000A(\u0004\u001E\u0018.\u0007(\u0004\u0008\u0018.\u000A(\u001D, j)), "Cut"))
						{
							for (;;)
							{
								switch (1)
								{
								case 0:
									continue;
								}
								goto IL_47F;
							}
						}
						IL_4D5:
						if (\u0008\u0013\u000A.\u000A(\u0004\u001E\u0018.\u0007(\u0004\u0008\u0018.\u000A(\u001D, j)), "Color"))
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
							Color? color2 = \u0002\u001C.\u0019(u001F2);
							if (\u0020\u0006\u0004.\u000A(ref color2))
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
								\u0002\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u0007), num, j + 2)), \u0004\u0010\u0004.\u000A(ref color2));
							}
						}
						j++;
						continue;
						IL_47F:
						if (!\u001A\u0006\u0007.\u000A(text2))
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
							\u0020\u001F\u0018.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u0007), num, j + 1)), ExcelHAlign.HAlignCenter);
							goto IL_4D5;
						}
						\u0012\u000B\u0005.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u0007), num, j + 1), "DiRootsReadOnly");
						goto IL_4D5;
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
					num++;
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
			return num;
		}

		// Token: 0x06001606 RID: 5638 RVA: 0x0008F940 File Offset: 0x0008DB40
		private static Color? \u0019(Category \u001F)
		{
			if (\u001C\u000B\u0005.\u000A(\u0003\u001C\u0019.\u000A(\u001F)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u001C.\u0019(Category)).MethodHandle;
				}
				return new Color?(\u0001\u000D\u0004.\u000A((int)\u0018\u001C\u0019.\u000A(\u0003\u001C\u0019.\u000A(\u001F)), (int)\u0019\u001C\u0019.\u000A(\u0003\u001C\u0019.\u000A(\u001F)), (int)\u0004\u001C\u0019.\u000A(\u0003\u001C\u0019.\u000A(\u001F))));
			}
			Color? result;
			\u0009\u0019\u000E.\u001F(ref result);
			return result;
		}

		// Token: 0x06001607 RID: 5639 RVA: 0x0008F9B4 File Offset: 0x0008DBB4
		internal static void \u0018(IWorksheet \u001F, SfSpreadsheet \u000A)
		{
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u001C.\u0018(IWorksheet, SfSpreadsheet)).MethodHandle;
				}
				for (int i = 2; i <= Enumerable.Count<IRange>(\u000D\u000B\u0005.\u000A(\u001F)); i++)
				{
					\u0010\u000B\u0005.\u000A(\u001F, i);
					if (\u000A != null)
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
						\u0006\u000B\u0005.\u000A(\u000A, i);
					}
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
		}

		// Token: 0x06001608 RID: 5640 RVA: 0x0008FA18 File Offset: 0x0008DC18
		private static void SetColumnWidth(SfSpreadsheet sfSpreadsheet, int columnIndex)
		{
			if (sfSpreadsheet != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u001C.SetColumnWidth(SfSpreadsheet, int)).MethodHandle;
				}
				int num = \u0005\u001A\u001D.\u000A(\u0015\u0009\u0018.\u000A(sfSpreadsheet), columnIndex);
				\u000E\u000B\u0005.\u000A(\u0002\u0009\u0018.\u0007(sfSpreadsheet), columnIndex, columnIndex, (double)(num + 20));
			}
		}

		// Token: 0x06001609 RID: 5641 RVA: 0x0008FA60 File Offset: 0x0008DC60
		internal static string \u0005(Category \u001F, string \u000A)
		{
			string result = "";
			if (!\u0008\u0013\u000A.\u000A(\u000A, "Id"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u001C.\u0005(Category, string)).MethodHandle;
				}
				if (!\u0008\u0013\u000A.\u000A(\u000A, "Name"))
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
					if (!\u0008\u0013\u000A.\u000A(\u000A, "Projection"))
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
						if (!\u0008\u0013\u000A.\u000A(\u000A, "Cut"))
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
							if (!\u0008\u0013\u000A.\u000A(\u000A, "Color"))
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
							else if (\u001C\u000B\u0005.\u000A(\u0003\u001C\u0019.\u000A(\u001F)))
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
								result = \u001E\u0007\u0007.\u000A("{0}, {1}, {2}", \u0018\u001C\u0019.\u000A(\u0003\u001C\u0019.\u000A(\u001F)), \u0019\u001C\u0019.\u000A(\u0003\u001C\u0019.\u000A(\u001F)), \u0004\u001C\u0019.\u000A(\u0003\u001C\u0019.\u000A(\u001F)));
							}
						}
						else
						{
							result = \u000F\u001C\u0019.\u000A(\u001F, 2).ToString();
						}
					}
					else
					{
						result = \u000F\u001C\u0019.\u000A(\u001F, 1).ToString();
					}
				}
				else
				{
					result = \u0009\u0014\u000A.\u001D(\u001F);
				}
			}
			else
			{
				long num = \u000B\u001E\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u001F));
				result = \u0011\u0013\u000A.\u000A(ref num);
			}
			return result;
		}

		// Token: 0x0600160A RID: 5642 RVA: 0x0008FBD4 File Offset: 0x0008DDD4
		private static void \u0016(Category \u001F, string \u000A, string \u0007)
		{
			if (\u0008\u0013\u000A.\u000A(\u000A, "Projection"))
			{
				int u000A;
				\u001C\u0015\u0004.\u000A(\u0007, ref u000A);
				\u0003\u0001\u001D.\u000A(\u001F, u000A, 1);
				return;
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u001C.\u0016(Category, string, string)).MethodHandle;
			}
			if (\u0008\u0013\u000A.\u000A(\u000A, "Cut"))
			{
				int u000A2;
				\u001C\u0015\u0004.\u000A(\u0007, ref u000A2);
				\u0003\u0001\u001D.\u000A(\u001F, u000A2, 2);
				return;
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
			if (!\u0008\u0013\u000A.\u000A(\u000A, "Color"))
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
				return;
			}
			Color color = \u0002\u001C.\u000B(\u0007);
			if (color != null)
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
				\u000F\u0002\u0004.\u000A(\u001F, color);
			}
		}

		// Token: 0x0600160B RID: 5643 RVA: 0x0008FC7C File Offset: 0x0008DE7C
		private static Color \u000B(string \u001F)
		{
			char[] array = \u001C\u0007\u000E.\u001F(1);
			array[0] = ',';
			string[] array2 = \u0009\u0007\u001D.\u000A(\u001F, array);
			try
			{
				return \u001C\u000C\u001D.\u000A(\u0001\u001B\u0018.\u000A(array2[0]), \u0001\u001B\u0018.\u000A(array2[1]), \u0001\u001B\u0018.\u000A(array2[2]));
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\ProjectStandards\\ExportStyles.cs", "ConvertRgbToColor");
			}
			return null;
		}

		// Token: 0x0600160C RID: 5644 RVA: 0x0008FCF4 File Offset: 0x0008DEF4
		internal unsafe static DiRoots.One.SheetLink.Enums.UpdateStatus \u0002(KeyValuePair<DataTable, List<ParamExportInfo>> \u001F, Document \u000A, out List<ReportInfo> \u0007)
		{
			List<Category> list = \u0011\u001C\u0018.\u000A();
			List<Category> list2 = Enumerable.ToList<Category>(Enumerable.Cast<Category>(\u000D\u0001\u001D.\u000A(\u0010\u0001\u001D.\u000A(\u000A))));
			\u0020\u0009\u0018.\u000A(list, list2);
			List<Category>.Enumerator enumerator = \u0020\u0002\u0004.\u000A(list2);
			try
			{
				while (\u0011\u0002\u0004.\u000A(ref enumerator))
				{
					Category u001F = \u001E\u0002\u0004.\u000A(ref enumerator);
					\u0020\u0009\u0018.\u000A(list, Enumerable.ToList<Category>(Enumerable.Cast<Category>(\u0008\u0001\u001D.\u000A(u001F))));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u001C.\u0002(KeyValuePair<DataTable, List<ParamExportInfo>>, Document, List<ReportInfo>*)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u0007 = \u0012\u000F\u0018.\u000A();
			DiRoots.One.SheetLink.Enums.UpdateStatus updateStatus = DiRoots.One.SheetLink.Enums.UpdateStatus.InvalidModel;
			try
			{
				if (\u000A\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F))) > 0)
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
					if (\u000A\u0012\u0018.\u000A(\u0007\u0012\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F))) > 1)
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
						Dictionary<int, Category> dictionary = \u0017\u000B\u0005.\u000A();
						for (int i = 0; i < \u000A\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F))); i++)
						{
							\u0002\u001C.\u0004\u001C u0004_u001C = new \u0002\u001C.\u0004\u001C();
							u0004_u001C.\u001F = \u001A\u000C\u000A.\u000A(\u001F\u000F\u0018.\u000A(\u0011\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref \u001F)), i), 0));
							if (\u001A\u0006\u0007.\u000A(u0004_u001C.\u001F))
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
								\u0020\u000B\u0005.\u000A(dictionary, i, \u0002\u0019\u000E.\u001F);
							}
							else
							{
								Category u = Enumerable.FirstOrDefault<Category>(list, new Func<Category, bool>(u0004_u001C.\u000A));
								\u0020\u000B\u0005.\u000A(dictionary, i, u);
							}
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
						Dictionary<long, List<ChangedColumns>> u001F2 = \u0002\u001C.\u000F(dictionary, \u001F, \u000A);
						List<ChangedColumns> list3 = \u0008\u000F\u0018.\u000A();
						object u001F3 = list3;
						IEnumerable<List<ChangedColumns>> enumerable = \u001E\u000B\u0005.\u000A(u001F2);
						Func<List<ChangedColumns>, IEnumerable<ChangedColumns>> func;
						if ((func = \u0002\u001C.<>c.\u000D) == null)
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
							func = (\u0002\u001C.<>c.\u000D = new Func<List<ChangedColumns>, IEnumerable<ChangedColumns>>(\u0002\u001C.<>c.\u001F.\u000A\u000A));
						}
						\u0010\u000F\u0018.\u000A(u001F3, Enumerable.SelectMany<List<ChangedColumns>, ChangedColumns>(enumerable, func));
						if (\u0003\u000F\u0018.\u000A(
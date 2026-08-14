using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x020001F9 RID: 505
	internal static class \u0016\u000F
	{
		// Token: 0x060012DE RID: 4830 RVA: 0x0006C6C4 File Offset: 0x0006A8C4
		internal static void \u000A(List<ParamValueInfo> \u001F, int \u000A, string \u0007, int \u001D, int \u0004, int \u0019, int \u0018, Parameter \u0005, RevitParameter \u0016, bool \u000B)
		{
			\u0016\u000F.\u0019\u000F u0019_u000F = new \u0016\u000F.\u0019\u000F();
			u0019_u000F.\u001F = \u0005;
			if (!\u0020\u000B\u0018.\u000A(\u0016))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u000F.\u000A(List<ParamValueInfo>, int, string, int, int, int, int, Parameter, RevitParameter, bool)).MethodHandle;
				}
				if (u0019_u000F.\u001F != null)
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
					ParamValueInfo paramValueInfo = \u000A\u000B\u000E.\u001F;
					if (\u001E\u000B\u0018.\u000A(\u0020\u001F\u001D.\u0007(u0019_u000F.\u001F)))
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
						paramValueInfo = \u001B\u000B\u0018.\u000A();
						\u0011\u000B\u0018.\u000A(paramValueInfo, ExcelParamTypes.YesNo);
						\u0002\u000B\u0018.\u000A(paramValueInfo, 0);
					}
					else
					{
						DropDownparamInfo dropDownparamInfo = Enumerable.FirstOrDefault<DropDownparamInfo>(DropDownparamInfo.\u0005(\u000B), new Func<DropDownparamInfo, bool>(u0019_u000F.\u000A));
						if (dropDownparamInfo != null)
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
							paramValueInfo = \u001B\u000B\u0018.\u000A();
							\u000E\u000B\u0018.\u000A(paramValueInfo, \u0008\u000B\u0018.\u000A(dropDownparamInfo));
							\u000D\u000B\u0018.\u000A(paramValueInfo, \u0010\u000B\u0018.\u000A(dropDownparamInfo));
							\u0003\u000B\u0018.\u000A(paramValueInfo, \u001C\u000B\u0018.\u000A(dropDownparamInfo));
							\u000F\u000B\u0018.\u000A(paramValueInfo, \u0012\u000B\u0018.\u000A(dropDownparamInfo));
							\u0002\u000B\u0018.\u000A(paramValueInfo, \u0006\u000B\u0018.\u000A(dropDownparamInfo));
						}
					}
					if (paramValueInfo != null)
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
						\u000B\u000B\u0018.\u000A(paramValueInfo, \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(u0019_u000F.\u001F)));
						\u0016\u000B\u0018.\u000A(paramValueInfo, \u0018);
						\u0005\u000B\u0018.\u000A(paramValueInfo, \u001D);
						\u0018\u000B\u0018.\u000A(paramValueInfo, \u0004);
						\u0019\u000B\u0018.\u000A(paramValueInfo, \u000A);
						\u0004\u000B\u0018.\u000A(paramValueInfo, \u0007);
						\u001D\u000B\u0018.\u000A(\u001F, paramValueInfo);
						\u0007\u000B\u0018.\u000A(\u0016, true);
					}
				}
			}
		}

		// Token: 0x060012DF RID: 4831 RVA: 0x0006C828 File Offset: 0x0006AA28
		internal static void \u0007(List<ParamValueInfo> \u001F, int \u000A, int \u0007, string \u001D, RevitParameter \u0004)
		{
			\u0016\u000F.\u0018\u000F u0018_u000F = new \u0016\u000F.\u0018\u000F();
			u0018_u000F.\u001F = \u0004;
			ParamValueInfo paramValueInfo = \u001B\u000B\u0018.\u000A();
			DropDownparamInfo dropDownparamInfo = Enumerable.FirstOrDefault<DropDownparamInfo>(DropDownparamInfo.\u0005(false), new Func<DropDownparamInfo, bool>(u0018_u000F.\u000A));
			if (dropDownparamInfo != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u000F.\u0007(List<ParamValueInfo>, int, int, string, RevitParameter)).MethodHandle;
				}
				\u000E\u000B\u0018.\u000A(paramValueInfo, \u0008\u000B\u0018.\u000A(dropDownparamInfo));
				\u000D\u000B\u0018.\u000A(paramValueInfo, \u0010\u000B\u0018.\u000A(dropDownparamInfo));
				\u0003\u000B\u0018.\u000A(paramValueInfo, \u001C\u000B\u0018.\u000A(dropDownparamInfo));
				\u000F\u000B\u0018.\u000A(paramValueInfo, \u0012\u000B\u0018.\u000A(dropDownparamInfo));
				\u0002\u000B\u0018.\u000A(paramValueInfo, \u0006\u000B\u0018.\u000A(dropDownparamInfo));
			}
			\u000B\u000B\u0018.\u000A(paramValueInfo, \u0017\u000B\u0018.\u0007(u0018_u000F.\u001F));
			\u0016\u000B\u0018.\u000A(paramValueInfo, 5);
			\u0005\u000B\u0018.\u000A(paramValueInfo, \u0007);
			\u0018\u000B\u0018.\u000A(paramValueInfo, 1000);
			\u0019\u000B\u0018.\u000A(paramValueInfo, \u000A);
			\u0004\u000B\u0018.\u000A(paramValueInfo, \u001D);
			\u001D\u000B\u0018.\u000A(\u001F, paramValueInfo);
			\u0007\u000B\u0018.\u000A(u0018_u000F.\u001F, true);
		}

		// Token: 0x060012E0 RID: 4832 RVA: 0x0006C910 File Offset: 0x0006AB10
		internal static void \u001D(Document \u001F, Workbook \u000A, List<ParamValueInfo> \u0007, int \u001D)
		{
			List<string> u001F = \u0016\u000F.\u0004(\u001F, \u0007);
			if (\u0015\u0007\u0019.\u000A(u001F) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u000F.\u001D(Document, Workbook, List<ParamValueInfo>, int)).MethodHandle;
				}
				return;
			}
			IEnumerable<Worksheet> enumerable = \u001E\u001D\u0018.\u000A(\u000A);
			Func<Worksheet, bool> func;
			if ((func = \u0016\u000F.<>c.\u000A) == null)
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
				func = (\u0016\u000F.<>c.\u000A = new Func<Worksheet, bool>(\u0016\u000F.<>c.\u001F.\u0016));
			}
			Worksheet worksheet = Enumerable.FirstOrDefault<Worksheet>(enumerable, func);
			if (worksheet == null)
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
				worksheet = \u0012\u0002\u0018.\u000A("ParamValues");
				\u000F\u0002\u0018.\u000A(\u001E\u001D\u0018.\u000A(\u000A), worksheet);
			}
			\u0006\u0002\u0018.\u000A(worksheet, true);
			string u000A = \u0004\u001E\u000A.\u000A("ParamValues", \u000C\u0013\u0007.\u000A(ref \u001D));
			ExcelNamedRange excelNamedRange = \u0002\u0002\u0018.\u000A();
			MergeRange u000A2 = \u000B\u0002\u0018.\u000A(1, \u0015\u0007\u0019.\u000A(u001F), \u001D, \u001D);
			\u0016\u0002\u0018.\u000A(excelNamedRange, u000A);
			\u0005\u0002\u0018.\u000A(excelNamedRange, u000A2);
			List<Range> list = \u0018\u0002\u0018.\u000A();
			for (int i = 0; i < \u0015\u0007\u0019.\u000A(u001F); i++)
			{
				object u001F2 = list;
				Range range = \u0019\u0002\u0018.\u000A(true);
				\u0004\u0002\u0018.\u000A(range, i + 1);
				\u001D\u0002\u0018.\u000A(range, \u001D);
				\u000B\u0019\u0018.\u000A(range, \u0001\u0013\u0007.\u000A(u001F, i));
				\u0007\u0002\u0018.\u000A(u001F2, range);
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
			\u001F\u0002\u0018.\u000A(\u000A\u0002\u0018.\u000A(\u000A), excelNamedRange);
			\u0009\u000B\u0018.\u000A(\u000D\u0004\u0018.\u000A(worksheet), list);
			List<ParamValueInfo>.Enumerator enumerator = \u0001\u000B\u0018.\u000A(\u0007);
			try
			{
				while (\u0014\u000B\u0018.\u000A(ref enumerator))
				{
					ParamValueInfo u001F3 = \u0015\u000B\u0018.\u000A(ref enumerator);
					\u001A\u000B\u0018.\u000A(u001F3, \u000C\u000B\u0018.\u000A());
					\u0013\u000B\u0018.\u000A(u001F3, excelNamedRange);
				}
				for (;;)
				{
					switch (2)
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

		// Token: 0x060012E1 RID: 4833 RVA: 0x0006CAC4 File Offset: 0x0006ACC4
		internal static void \u001D(Document \u001F, SfSpreadsheet \u000A, IWorkbook \u0007, List<ParamValueInfo> \u001D, int \u0004)
		{
			IEnumerable<IWorksheet> enumerable = \u0003\u001E\u001D.\u000A(\u0007);
			Func<IWorksheet, bool> func;
			if ((func = \u0016\u000F.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u000F.\u001D(Document, SfSpreadsheet, IWorkbook, List<ParamValueInfo>, int)).MethodHandle;
				}
				func = (\u0016\u000F.<>c.\u0007 = new Func<IWorksheet, bool>(\u0016\u000F.<>c.\u001F.\u000B));
			}
			IWorksheet worksheet = Enumerable.FirstOrDefault<IWorksheet>(enumerable, func);
			if (worksheet == null)
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
				\u000C\u0002\u0018.\u000A(\u000A, "ParamValues", \u0017\u0011\u001D.\u000A(\u0003\u001E\u001D.\u000A(\u0007)) - 1);
				\u001A\u0002\u0018.\u000A(\u000A, "ParamValues");
				worksheet = \u0012\u001E\u001D.\u000A(\u0003\u001E\u001D.\u000A(\u0007), \u0017\u0011\u001D.\u000A(\u0003\u001E\u001D.\u000A(\u0007)) - 1);
			}
			List<string> u001F = \u0016\u000F.\u0004(\u001F, \u001D);
			if (\u0015\u0007\u0019.\u000A(u001F) == 0)
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
				return;
			}
			if (Enumerable.Count<IRange>(\u0002\u0013\u001D.\u000A(worksheet)) < \u0015\u0007\u0019.\u000A(u001F))
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
				\u0017\u0002\u0018.\u000A(\u0014\u0002\u0018.\u000A(\u0013\u0002\u0018.\u0007(\u000A), "ParamValues"), \u0015\u0007\u0019.\u000A(u001F) + 5);
			}
			string u000A = \u0004\u001E\u000A.\u000A("ParamValues", \u000C\u0013\u0007.\u000A(ref \u0004));
			IName name = \u000C\u0006\u0004.\u000A(\u0007\u0020\u001D.\u000A(\u0007), u000A);
			if (name == null)
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
				name = \u0020\u0002\u0018.\u000A(\u0007\u0020\u001D.\u000A(\u0007), u000A);
			}
			\u001E\u0002\u0018.\u000A(name, \u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(worksheet), 1, \u0004, \u0015\u0007\u0019.\u000A(u001F), \u0004));
			for (int i = 0; i < \u0015\u0007\u0019.\u000A(u001F); i++)
			{
				\u0013\u0009\u0019.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet), i + 1, \u0004), \u0001\u0013\u0007.\u000A(u001F, i));
			}
			for (;;)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			List<ParamValueInfo>.Enumerator enumerator = \u0001\u000B\u0018.\u000A(\u001D);
			try
			{
				while (\u0014\u000B\u0018.\u000A(ref enumerator))
				{
					ParamValueInfo u001F2 = \u0015\u000B\u0018.\u000A(ref enumerator);
					IDataValidation u001F3 = \u0010\u0002\u0018.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(\u0012\u001E\u001D.\u000A(\u0003\u001E\u001D.\u000A(\u0007), \u0011\u0002\u0018.\u000A(u001F2))), \u0008\u0002\u0018.\u000A(u001F2) + 1, \u000E\u0002\u0018.\u000A(u001F2), \u001B\u0002\u0018.\u000A(u001F2) + \u0008\u0002\u0018.\u000A(u001F2), \u000E\u0002\u0018.\u000A(u001F2)));
					\u000D\u0002\u0018.\u000A(u001F3, \u000C\u000B\u0018.\u000A());
					\u001C\u0002\u0018.\u000A(u001F3, ExcelDataType.User);
					\u0003\u0002\u0018.\u000A(u001F3, \u0004\u001E\u000A.\u000A("=", u000A));
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
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060012E2 RID: 4834 RVA: 0x0006CD50 File Offset: 0x0006AF50
		internal static void \u001D(Document \u001F, IWorkbook \u000A, List<ParamValueInfo> \u0007, int \u001D)
		{
			IEnumerable<IWorksheet> enumerable = \u0003\u001E\u001D.\u000A(\u000A);
			Func<IWorksheet, bool> func;
			if ((func = \u0016\u000F.<>c.\u001D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u000F.\u001D(Document, IWorkbook, List<ParamValueInfo>, int)).MethodHandle;
				}
				func = (\u0016\u000F.<>c.\u001D = new Func<IWorksheet, bool>(\u0016\u000F.<>c.\u001F.\u0002));
			}
			IWorksheet worksheet = Enumerable.FirstOrDefault<IWorksheet>(enumerable, func);
			if (worksheet == null)
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
				\u0012\u001F\u0018.\u000A(\u0003\u001E\u001D.\u000A(\u000A), "ParamValues");
				worksheet = \u000A\u000F\u0004.\u000A(\u0003\u001E\u001D.\u000A(\u000A), "ParamValues");
				\u0015\u0002\u0018.\u000A(worksheet, WorksheetVisibility.Hidden);
			}
			List<string> u001F = \u0016\u000F.\u0004(\u001F, \u0007);
			if (\u0015\u0007\u0019.\u000A(u001F) == 0)
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
				return;
			}
			string u000A = \u0004\u001E\u000A.\u000A("ParamValues", \u000C\u0013\u0007.\u000A(ref \u001D));
			IName name = \u000C\u0006\u0004.\u000A(\u0007\u0020\u001D.\u000A(\u000A), u000A);
			if (name == null)
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
				name = \u0020\u0002\u0018.\u000A(\u0007\u0020\u001D.\u000A(\u000A), u000A);
			}
			\u001E\u0002\u0018.\u000A(name, \u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(worksheet), 1, \u001D, \u0015\u0007\u0019.\u000A(u001F), \u001D));
			for (int i = 0; i < \u0015\u0007\u0019.\u000A(u001F); i++)
			{
				\u0013\u0009\u0019.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet), i + 1, \u001D), \u0001\u0013\u0007.\u000A(u001F, i));
			}
			for (;;)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			List<ParamValueInfo>.Enumerator enumerator = \u0001\u000B\u0018.\u000A(\u0007);
			try
			{
				while (\u0014\u000B\u0018.\u000A(ref enumerator))
				{
					ParamValueInfo u001F2 = \u0015\u000B\u0018.\u000A(ref enumerator);
					IDataValidation u001F3 = \u0010\u0002\u0018.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(\u0012\u001E\u001D.\u000A(\u0003\u001E\u001D.\u000A(\u000A), \u0011\u0002\u0018.\u000A(u001F2))), \u0008\u0002\u0018.\u000A(u001F2) + 1, \u000E\u0002\u0018.\u000A(u001F2), \u001B\u0002\u0018.\u000A(u001F2) + \u0008\u0002\u0018.\u000A(u001F2), \u000E\u0002\u0018.\u000A(u001F2)));
					\u000D\u0002\u0018.\u000A(u001F3, \u000C\u000B\u0018.\u000A());
					\u001C\u0002\u0018.\u000A(u001F3, ExcelDataType.User);
					\u0003\u0002\u0018.\u000A(u001F3, \u0004\u001E\u000A.\u000A("=", u000A));
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
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060012E3 RID: 4835 RVA: 0x0006CF7C File Offset: 0x0006B17C
		private static List<string> \u0004(Document \u001F, List<ParamValueInfo> \u000A)
		{
			\u0016\u000F.\u0005\u000F u0005_u000F = new \u0016\u000F.\u0005\u000F();
			List<string> list = \u001F\u000B\u000E.\u001F;
			u0005_u000F.\u001F = Enumerable.First<ParamValueInfo>(\u000A);
			if (\u0019\u0006\u0018.\u000A(u0005_u000F.\u001F) == ExcelParamTypes.YesNo)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u000F.\u0004(Document, List<ParamValueInfo>)).MethodHandle;
				}
				list = \u0014\u000D\u0007.\u000A();
				\u001A\u0008\u0007.\u000A(list, "Yes");
				\u001A\u0008\u0007.\u000A(list, "No");
				\u001A\u0008\u0007.\u000A(list, "");
			}
			else if (\u0019\u0006\u0018.\u000A(u0005_u000F.\u001F) == ExcelParamTypes.LineStyles)
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
				list = \u0014\u000D\u0007.\u000A();
				for (int i = 1; i <= 16; i++)
				{
					\u001A\u0008\u0007.\u000A(list, \u000C\u0013\u0007.\u000A(ref i));
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
			else if (\u0009\u0002\u0018.\u000A(u0005_u000F.\u001F) == -2009014L)
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
				list = \u0017\u000D.\u0007(\u001F);
			}
			else
			{
				if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) != -1114147L)
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
					if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) != -1140230L)
					{
						if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) != -1114146L)
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
							if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) == -1114136L)
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
							}
							else
							{
								if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) == -1140333L)
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
									list = \u0017\u000D.\u0002(\u001F);
									goto IL_4EC;
								}
								if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) == -1140334L)
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
									list = \u0017\u000D.\u000F(\u001F);
									goto IL_4EC;
								}
								if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) == -1002053L)
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
									list = \u0017\u000D.\u000A(\u001F);
									goto IL_4EC;
								}
								if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) == -1006210L)
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
									list = \u0017\u000D.\u0019(\u001F);
									goto IL_4EC;
								}
								if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) == -1005163L)
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
									list = EnumHandler.\u001C<ViewDiscipline>();
									goto IL_4EC;
								}
								if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) == -1011002L)
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
									list = EnumHandler.\u001C<ViewDetailLevel>();
									goto IL_4EC;
								}
								if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) == -1002106L)
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
									list = \u0017\u000D.\u0005(\u001F);
									goto IL_4EC;
								}
								if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) == -1001122L)
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
									IEnumerable<EnumHandler> enumerable = EnumHandler.\u001D();
									Func<EnumHandler, string> func;
									if ((func = \u0016\u000F.<>c.\u0004) == null)
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
										func = (\u0016\u000F.<>c.\u0004 = new Func<EnumHandler, string>(\u0016\u000F.<>c.\u001F.\u0006));
									}
									list = Enumerable.ToList<string>(Enumerable.Select<EnumHandler, string>(enumerable, func));
									goto IL_4EC;
								}
								if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) == -1005172L)
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
									IEnumerable<EnumHandler> enumerable2 = EnumHandler.\u0004();
									Func<EnumHandler, string> func2;
									if ((func2 = \u0016\u000F.<>c.\u0019) == null)
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
										func2 = (\u0016\u000F.<>c.\u0019 = new Func<EnumHandler, string>(\u0016\u000F.<>c.\u001F.\u000F));
									}
									list = Enumerable.ToList<string>(Enumerable.Select<EnumHandler, string>(enumerable2, func2));
									goto IL_4EC;
								}
								if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) == -1006305L)
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
									list = \u0017\u000D.\u0014(\u001F);
									goto IL_4EC;
								}
								if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) == -1140335L)
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
									IEnumerable<EnumHandler> enumerable3 = EnumHandler.\u0019();
									Func<EnumHandler, string> func3;
									if ((func3 = \u0016\u000F.<>c.\u0018) == null)
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
										func3 = (\u0016\u000F.<>c.\u0018 = new Func<EnumHandler, string>(\u0016\u000F.<>c.\u001F.\u0012));
									}
									list = Enumerable.ToList<string>(Enumerable.Select<EnumHandler, string>(enumerable3, func3));
									goto IL_4EC;
								}
								if (\u0004\u0006\u0018.\u000A(u0005_u000F.\u001F) == -1001006L)
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
									IEnumerable<EnumHandler> enumerable4 = EnumHandler.\u0018();
									Func<EnumHandler, string> func4;
									if ((func4 = \u0016\u000F.<>c.\u0005) == null)
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
										func4 = (\u0016\u000F.<>c.\u0005 = new Func<EnumHandler, string>(\u0016\u000F.<>c.\u001F.\u0003));
									}
									list = Enumerable.ToList<string>(Enumerable.Select<EnumHandler, string>(enumerable4, func4));
									goto IL_4EC;
								}
								if (!\u001D\u0006\u0018.\u000A(u0005_u000F.\u001F))
								{
									list = \u0017\u000D.\u0016(\u001F, \u001F\u0006\u0018.\u000A(u0005_u000F.\u001F), \u0009\u0002\u0018.\u000A(u0005_u000F.\u001F));
									goto IL_4EC;
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
								\u001A\u000F u001A_u000F = Enumerable.FirstOrDefault<\u001A\u000F>(\u001A\u000F.\u0018(\u001F, false), new Func<\u001A\u000F, bool>(u0005_u000F.\u000A));
								if (u001A_u000F != null)
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
									list = Enumerable.ToList<string>(\u000A\u0006\u0018.\u000A(\u0007\u0006\u0018.\u000A(u001A_u000F)));
									goto IL_4EC;
								}
								goto IL_4EC;
							}
						}
						list = \u0017\u000D.\u000B();
						goto IL_4EC;
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
				list = \u0017\u000D.\u000D();
			}
			IL_4EC:
			if (\u0001\u0002\u0018.\u000A(u0005_u000F.\u001F))
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
				if (list != null)
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
					\u001A\u0008\u0007.\u000A(list, "None");
				}
			}
			return list;
		}

		// Token: 0x04000786 RID: 1926
		internal static string \u001F;

		// Token: 0x0200088E RID: 2190
		[CompilerGenerated]
		private sealed class \u0019\u000F
		{
			// Token: 0x06004F6D RID: 20333 RVA: 0x001E5148 File Offset: 0x001E3348
			internal bool \u000A(DropDownparamInfo \u001F)
			{
				return \u0005\u0019\u0010.\u000A(\u001F) == \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(this.\u001F));
			}

			// Token: 0x04002239 RID: 8761
			public Parameter \u001F;
		}

		// Token: 0x0200088F RID: 2191
		[CompilerGenerated]
		private sealed class \u0018\u000F
		{
			// Token: 0x06004F6F RID: 20335 RVA: 0x001E5188 File Offset: 0x001E3388
			internal bool \u000A(DropDownparamInfo \u001F)
			{
				return \u0005\u0019\u0010.\u000A(\u001F) == \u0017\u000B\u0018.\u0007(this.\u001F);
			}

			// Token: 0x0400223A RID: 8762
			public RevitParameter \u001F;
		}

		// Token: 0x02000890 RID: 2192
		[CompilerGenerated]
		private sealed class \u0005\u000F
		{
			// Token: 0x06004F71 RID: 20337 RVA: 0x001E51C0 File Offset: 0x001E33C0
			internal bool \u000A(\u001A\u000F \u001F)
			{
				return \u0020\u0008\u0005.\u000A(\u001F) == \u0004\u0006\u0018.\u000A(this.\u001F);
			}

			// Token: 0x0400223B RID: 8763
			public ParamValueInfo \u001F;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using Autodesk.Revit.DB;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.UI.Windows;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x02000218 RID: 536
	internal static class \u0020\u0003
	{
		// Token: 0x06001492 RID: 5266 RVA: 0x00085D80 File Offset: 0x00083F80
		internal unsafe static bool \u001F(List<CategoryCollection> \u001F, Window \u000A, ref string \u0007)
		{
			if (!\u001A\u0006\u0007.\u000A(\u0007))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0003.\u001F(List<CategoryCollection>, Window, string*)).MethodHandle;
				}
				try
				{
					string text = \u0007;
					while (!\u001B\u0012.\u0019(\u001F, \u000A, ref text))
					{
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
					if (\u001A\u0006\u0007.\u000A(text))
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
						return false;
					}
					\u0007 = text;
					return true;
				}
				catch (Exception u001F)
				{
					\u0004\u000F.\u0016(u001F);
					return false;
				}
				return false;
			}
			return false;
		}

		// Token: 0x06001493 RID: 5267 RVA: 0x00085E00 File Offset: 0x00084000
		internal static bool \u000A(List<CategoryCollection> \u001F, string \u000A, bool \u0007, bool \u001D, Delegate \u0004)
		{
			if (!\u001A\u0006\u0007.\u000A(\u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0003.\u000A(List<CategoryCollection>, string, bool, bool, Delegate)).MethodHandle;
				}
				try
				{
					if (\u0010\u0002\u001D.\u000A(\u000A))
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
						\u0007\u0001\u001D.\u000A(\u000A);
					}
				}
				catch (Exception)
				{
					\u0005\u0013\u000A.\u000A(\u001D\u0020\u0018.\u000A(), 350.0);
					return false;
				}
				\u0020\u0003.\u000A(\u001F, \u000A, \u0004);
				if (\u001D)
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
					\u0020\u0003.\u0004(\u000A, \u0007);
					return true;
				}
				return true;
			}
			return true;
		}

		// Token: 0x06001494 RID: 5268 RVA: 0x00085E98 File Offset: 0x00084098
		internal static bool \u000A(List<CategoryCollection> \u001F, string \u000A, Delegate \u0007)
		{
			if (!\u001A\u0006\u0007.\u000A(\u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0003.\u000A(List<CategoryCollection>, string, Delegate)).MethodHandle;
				}
				ExcelEngine excelEngine = \u0008\u001E\u001D.\u000A();
				try
				{
					IApplication u001F = \u000E\u001E\u001D.\u000A(excelEngine);
					\u0010\u001E\u001D.\u000A(u001F, ExcelVersion.Excel2013);
					IWorkbook workbook = \u0002\u0007\u0005.\u000A(\u000D\u001E\u001D.\u000A(u001F), \u0020\u0003.\u001D(\u001F, false));
					\u001D\u0009\u0018.\u000A(workbook);
					\u0020\u0003.\u000A(\u001F, null, workbook, \u0007);
					\u0020\u0003.\u0007(\u0012\u001F\u0018.\u000A(\u0003\u001E\u001D.\u000A(workbook), "Instructions"), \u001C\u0002\u000E.\u001F);
					\u000B\u0007\u0005.\u000A(\u0012\u001E\u001D.\u000A(\u0003\u001E\u001D.\u000A(workbook), 0));
					\u0016\u0007\u0005.\u000A(workbook, \u000A);
					\u0019\u001A\u0004.\u000A(workbook);
				}
				finally
				{
					if (excelEngine != null)
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
						\u001F\u0017\u000A.\u000A(excelEngine);
					}
				}
			}
			return true;
		}

		// Token: 0x06001495 RID: 5269 RVA: 0x00085F6C File Offset: 0x0008416C
		internal static void \u000A(List<CategoryCollection> \u001F, SfSpreadsheet \u000A, IWorkbook \u0007, Delegate \u001D)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UI\\UIHelper.cs", "ExportProjectStandards");
			if (\u000A != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0003.\u000A(List<CategoryCollection>, SfSpreadsheet, IWorkbook, Delegate)).MethodHandle;
				}
				string[] array = \u0020\u0003.\u001D(\u001F, true);
				for (int i = 0; i < (int)\u000C\u0007\u000E.\u001F(array); i++)
				{
					string u000A = array[i];
					\u000C\u0002\u0018.\u000A(\u000A, u000A, \u0017\u0011\u001D.\u000A(\u0003\u001E\u001D.\u000A(\u0004\u0009\u0018.\u000A(\u000A))) - 1);
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
			Document document = \u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A());
			int num = 1;
			Func<CategoryCollection, bool> func;
			if ((func = \u0020\u0003.<>c.\u000A) == null)
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
				func = (\u0020\u0003.<>c.\u000A = new Func<CategoryCollection, bool>(\u0020\u0003.<>c.\u001F.\u0019));
			}
			if (Enumerable.FirstOrDefault<CategoryCollection>(\u001F, func) != null)
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
				List<RevitParameter> list = \u000D\u000E\u0018.\u000A();
				List<Parameter>.Enumerator enumerator = \u0003\u0007\u0005.\u000A(\u0012\u001C.\u001F(\u0013\u0013\u0007.\u000A(document)));
				try
				{
					while (\u0006\u0007\u0005.\u000A(ref enumerator))
					{
						RevitParameter u000A2 = \u000F\u0007\u0005.\u000A(\u0012\u0007\u0005.\u000A(ref enumerator), \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u0013\u0013\u0007.\u000A(document))), false);
						\u0017\u0010\u0018.\u000A(list, u000A2);
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
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				\u0012\u001C.\u000A(document, \u000A, \u0007, "Project Information", \u0013\u0013\u0007.\u000A(document), list);
				if (\u001D != null)
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
					object[] array2 = \u0004\u0015\u0010.\u001F(1);
					array2[0] = num++;
					\u0010\u001F\u0018.\u000A(\u001D, array2);
				}
			}
			\u0015\u001C u001F = new \u0015\u001C();
			Func<CategoryCollection, bool> func2;
			if ((func2 = \u0020\u0003.<>c.\u0007) == null)
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
				func2 = (\u0020\u0003.<>c.\u0007 = new Func<CategoryCollection, bool>(\u0020\u0003.<>c.\u001F.\u0018));
			}
			if (Enumerable.FirstOrDefault<CategoryCollection>(\u001F, func2) != null)
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
				\u0002\u001C.\u001F(u001F, document, \u000A, \u0007);
				if (\u001D != null)
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
					object[] array3 = \u0004\u0015\u0010.\u001F(1);
					array3[0] = num++;
					\u0010\u001F\u0018.\u000A(\u001D, array3);
				}
			}
			Func<CategoryCollection, bool> func3;
			if ((func3 = \u0020\u0003.<>c.\u001D) == null)
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
				func3 = (\u0020\u0003.<>c.\u001D = new Func<CategoryCollection, bool>(\u0020\u0003.<>c.\u001F.\u0005));
			}
			if (Enumerable.FirstOrDefault<CategoryCollection>(\u001F, func3) != null)
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
				\u0002\u001C.\u000A(u001F, document, \u000A, \u0007, "Line Styles");
				if (\u001D != null)
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
					object[] array4 = \u0004\u0015\u0010.\u001F(1);
					array4[0] = num++;
					\u0010\u001F\u0018.\u000A(\u001D, array4);
				}
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
				Func<CategoryCollection, bool> func4;
				if ((func4 = \u0020\u0003.<>c.\u0004) == null)
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
					func4 = (\u0020\u0003.<>c.\u0004 = new Func<CategoryCollection, bool>(\u0020\u0003.<>c.\u001F.\u0016));
				}
				if (Enumerable.FirstOrDefault<CategoryCollection>(\u001F, func4) != null)
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
					\u0006\u001C.\u001F(document, \u000A, \u0007, "Families");
					if (\u001D != null)
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
						object[] array5 = \u0004\u0015\u0010.\u001F(1);
						array5[0] = num;
						\u0010\u001F\u0018.\u000A(\u001D, array5);
					}
				}
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UI\\UIHelper.cs", "ExportProjectStandards");
		}

		// Token: 0x06001496 RID: 5270 RVA: 0x00086298 File Offset: 0x00084498
		internal static void \u0007(IWorksheet \u001F, SfSpreadsheet \u000A)
		{
			\u0009\u001E\u0018.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 2, 2), \u001D\u0017\u0018.\u000A());
			\u001C\u0009\u0018.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 2, 2))), ExcelKnownColors.Black);
			\u0017\u0009\u0019.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 2, 2))), true);
			\u0009\u001E\u0018.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 2, 3), \u0007\u0017\u0018.\u000A());
			\u001C\u0009\u0018.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 2, 3))), ExcelKnownColors.Black);
			\u0017\u0009\u0019.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 2, 3))), true);
			\u0002\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 3, 2)), \u0008\u0007\u0005.\u000A());
			\u0009\u001E\u0018.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 3, 3), \u000A\u0017\u0018.\u000A());
			\u0002\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 4, 2)), \u000E\u0007\u0005.\u000A());
			\u0009\u001E\u0018.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 4, 3), \u001F\u0017\u0018.\u000A());
			\u0002\u0009\u0019.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 5, 2)), \u0010\u0007\u0005.\u000A());
			\u0009\u001E\u0018.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 5, 3), \u0009\u0020\u0018.\u000A());
			\u001C\u0009\u0018.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 7, 2))), ExcelKnownColors.Black);
			\u0017\u0009\u0019.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 7, 2))), true);
			\u0009\u001E\u0018.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 7, 2), \u0013\u0020\u0018.\u000A());
			\u0002\u001C.\u0018(\u001F, \u000A);
			\u001C\u0009\u0018.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 8, 2))), ExcelKnownColors.Black);
			\u0017\u0009\u0019.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 8, 2))), false);
			\u0009\u001E\u0018.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 8, 2), \u001E\u0020\u0018.\u000A());
			\u0015\u0001\u0019.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), 8, 2));
			\u000D\u0007\u0005.\u000A(\u001F, ExcelKnownColors.White);
			if (\u000A != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0003.\u0007(IWorksheet, SfSpreadsheet)).MethodHandle;
				}
				\u001C\u0007\u0005.\u000A(\u0002\u0009\u0018.\u0007(\u000A), false);
			}
		}

		// Token: 0x06001497 RID: 5271 RVA: 0x0008654C File Offset: 0x0008474C
		internal static string[] \u001D(List<CategoryCollection> \u001F, bool \u000A = false)
		{
			List<string> u001F = \u0014\u000D\u0007.\u000A();
			List<CategoryCollection>.Enumerator enumerator = \u0014\u0016\u0018.\u000A(\u001F);
			try
			{
				while (\u001E\u0016\u0018.\u000A(ref enumerator))
				{
					CategoryCollection u001F2 = \u0017\u0016\u0018.\u000A(ref enumerator);
					if (\u0008\u0013\u000A.\u000A(\u0012\u001E\u0018.\u000A(u001F2), "Project Information"))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0003.\u001D(List<CategoryCollection>, bool)).MethodHandle;
						}
						\u001A\u0008\u0007.\u000A(u001F, "Project Information");
					}
					if (\u0008\u0013\u000A.\u000A(\u0012\u001E\u0018.\u000A(u001F2), "Object Styles"))
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
						\u001A\u0008\u0007.\u000A(u001F, "Model Objects");
						\u001A\u0008\u0007.\u000A(u001F, "Annotation Objects");
						\u001A\u0008\u0007.\u000A(u001F, "Analytical Model Objects");
						\u001A\u0008\u0007.\u000A(u001F, "Imported Categories");
					}
					if (\u0008\u0013\u000A.\u000A(\u0012\u001E\u0018.\u000A(u001F2), "Line Styles"))
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
						\u001A\u0008\u0007.\u000A(u001F, "Line Styles");
					}
					if (\u0008\u0013\u000A.\u000A(\u0012\u001E\u0018.\u000A(u001F2), "Families"))
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
						if (!\u000A)
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
							\u001A\u0008\u0007.\u000A(u001F, "Families");
							\u001A\u0008\u0007.\u000A(u001F, "FamilyListingDataSource");
						}
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return \u001B\u0007\u0005.\u000A(u001F);
		}

		// Token: 0x06001498 RID: 5272 RVA: 0x000866B4 File Offset: 0x000848B4
		private static void \u0004(string \u001F, bool \u000A)
		{
			if (\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0003.\u0004(string, bool)).MethodHandle;
				}
				\u0004\u0019\u0019.\u000A(\u001F);
				return;
			}
			\u0008\u0011\u001D.\u000A(\u0001\u0013\u0019.\u000A());
		}

		// Token: 0x06001499 RID: 5273 RVA: 0x000866F0 File Offset: 0x000848F0
		internal static void \u0019(string \u001F, Window \u000A, ProgressModel \u0007, bool \u001D = false)
		{
			if (!\u001A\u0006\u0007.\u000A(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0003.\u0019(string, Window, ProgressModel, bool)).MethodHandle;
				}
				Dictionary<DataTable, List<ParamExportInfo>> u001F = \u001B\u0012.\u000B(\u001F);
				if (\u0010\u0017\u0018.\u000A(u001F) > 0)
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
					\u0020\u0003.\u0019(u001F, \u000A, \u0007, false);
				}
				else
				{
					\u0009\u0009\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "No data found to import.", "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UI\\UIHelper.cs", "ImportExcelFile");
				}
				if (\u001D)
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
					try
					{
						\u0007\u0001\u001D.\u000A(\u001F);
					}
					catch (Exception u000A)
					{
						\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UI\\UIHelper.cs", "ImportExcelFile");
					}
				}
			}
		}

		// Token: 0x0600149A RID: 5274 RVA: 0x000867A0 File Offset: 0x000849A0
		internal static void \u0019(Dictionary<DataTable, List<ParamExportInfo>> \u001F, Window \u000A, ProgressModel \u0007, bool \u001D = false)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UI\\UIHelper.cs", "ImportExcelFile");
			\u0020\u0007\u0005.\u000A(true);
			\u001A\u0010 u001A_u = new \u001A\u0010(\u001F);
			\u001E\u0007\u0005.\u000A(u001A_u, \u000A);
			if (\u001D)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0003.\u0019(Dictionary<DataTable, List<ParamExportInfo>>, Window, ProgressModel, bool)).MethodHandle;
				}
				ProgressWindow u001F = \u0008\u000C\u0018.\u000A(\u0011\u0007\u0005.\u000A(u001A_u));
				\u0015\u000D\u001D.\u000A(u001F, \u000A);
				\u0018\u0020\u000A.\u0007(u001F);
			}
			else
			{
				\u000D\u0014\u0018.\u000A(u001A_u, \u0007);
				\u0003\u0014\u0018.\u000A(\u001C\u0014\u0018.\u0007(u001A_u), new Action<\u001A\u0010>(\u0020\u0003.\u0018));
				\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u001A_u);
				\u0020\u0005\u0019.\u000A(\u0017\u001E\u000A.\u000A());
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\UI\\UIHelper.cs", "ImportExcelFile");
		}

		// Token: 0x0600149B RID: 5275 RVA: 0x0008685C File Offset: 0x00084A5C
		internal static void \u0018(\u001A\u0010 \u001F)
		{
			if (\u0014\u0007\u0005.\u000A(\u001F) != DiRoots.One.SheetLink.Enums.UpdateStatus.Cancel)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0003.\u0018(\u001A\u0010)).MethodHandle;
				}
				if (\u0008\u0006\u0018.\u000A(\u0013\u0007\u0005.\u000A(\u001F)) > 0)
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
					ReportsWindow u001F = \u0003\u0018\u001D.\u000A(\u0007\u0015\u0018.\u000A(Enumerable.ToList<Report>(Enumerable.Cast<Report>(\u0013\u0007\u0005.\u000A(\u001F))), \u001E\u0011\u000A.\u000A(\u001A\u0002\u000E.\u001F()), 1005), false);
					\u000C\u000E\u0007.\u0007(u001F, \u0017\u0007\u0005.\u0007(\u001F));
					\u0018\u0020\u000A.\u0007(u001F);
				}
				else
				{
					\u0020\u0003.\u0005(\u0014\u0007\u0005.\u000A(\u001F), \u0017\u0007\u0005.\u0007(\u001F));
				}
			}
			\u0002\u0013\u0019.\u0007(\u001C\u0014\u0018.\u0007(\u001F));
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x00086918 File Offset: 0x00084B18
		internal static void \u0005(DiRoots.One.SheetLink.Enums.UpdateStatus \u001F, Window \u000A)
		{
			string u001F;
			if (\u001F == DiRoots.One.SheetLink.Enums.UpdateStatus.Updated)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0003.\u0005(DiRoots.One.SheetLink.Enums.UpdateStatus, Window)).MethodHandle;
				}
				u001F = \u0001\u0007\u0005.\u000A();
			}
			else if (\u001F == DiRoots.One.SheetLink.Enums.UpdateStatus.NoChangesFound)
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
				u001F = \u0015\u0007\u0005.\u000A();
			}
			else if (\u001F == DiRoots.One.SheetLink.Enums.UpdateStatus.InvalidModel)
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
				u001F = \u000C\u0007\u0005.\u000A();
			}
			else
			{
				u001F = \u001A\u0007\u0005.\u000A();
			}
			\u000F\u0005\u0019.\u000A(u001F, \u000A, MessageBoxButtons.OK);
		}
	}
}

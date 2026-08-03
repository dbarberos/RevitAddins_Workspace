using System;
using System.Collections.Generic;
using System.Linq;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.OneFilter;
using DiRoots.One.OneFilter.CommonLibrary.UI.Controls;
using DiRoots.One.OneFilter.SelectionsAndRuleFilters.ViewModels;
using DiRoots.One.ReOrdering.Core.Models;
using DiRoots.One.SheetLink.UI.Controls;
using Syncfusion.XlsIO;

namespace DiRoots.One.SheetLink.SheetLink.Core.ExternalCommands
{
	// Token: 0x02000261 RID: 609
	public static class CategoriesComparisonExcelTester
	{
		// Token: 0x060018AF RID: 6319 RVA: 0x0009FB6C File Offset: 0x0009DD6C
		[Obsolete("This method is only for testing purposes and should not be used in production code. Read summary to test properly")]
		public static void PopulateCategoriesComparisonWorkBook(UIApplication uiApp)
		{
			UIDocument u001F = \u0020\u0013\u000A.\u000A(uiApp);
			\u0018\u000D.\u0006(u001F, \u000F\u0011\u0019.\u000A());
			\u0015\u0015.\u001D(u001F);
			\u0019\u0013\u0005.\u000A(new \u000A\u001C\u000A(\u0011\u0020\u000A.\u0007(u001F)));
			\u000B\u000B\u000A.\u001D();
			\u000B\u0012.\u0007();
			\u000C\u0015.\u001D();
			new \u0001\u0002\u000A(\u0011\u0020\u000A.\u0007(u001F));
			new \u0020\u0006\u000A(\u0011\u0020\u000A.\u0007(u001F));
			List<string> u001F2 = \u001C\u001F\u0018.\u000A(2);
			\u001A\u0008\u0007.\u000A(u001F2, "Model And Analytical");
			\u001A\u0008\u0007.\u000A(u001F2, "Annotations");
			\u0010\u0008\u000A u0010_u0008_u000A = new \u0010\u0008\u000A(u001F2);
			IWorkbook workbook = \u0003\u001F\u0018.\u0007(u0010_u0008_u000A);
			if (workbook != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoriesComparisonExcelTester.PopulateCategoriesComparisonWorkBook(UIApplication)).MethodHandle;
				}
				try
				{
					IWorksheet u001F3 = \u0012\u001E\u001D.\u000A(\u0003\u001E\u001D.\u000A(workbook), 0);
					IWorksheet u001F4 = \u0012\u001E\u001D.\u000A(\u0003\u001E\u001D.\u000A(workbook), 1);
					CategoriesComparisonExcelTester.\u0019(u001F3, 2, 11, "The following disciplines are only from SheetLink in which they will be used as a global reference for all tools", false);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 2, "Display Name", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 3, "Id", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 4, "Enum Name", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 5, "Is Cuttable", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 6, "Has Material Quantities", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 7, "Is Visible in UI", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 8, "Allows Bound Parameters", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 9, "Is Valid for Key Schedule", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 10, "Is Valid for Schedule", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 11, \u0005\u0014\u0018.\u000A(), true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 12, \u0018\u0014\u0018.\u000A(), true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 13, \u0019\u0014\u0018.\u000A(), true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 14, \u0004\u0014\u0018.\u000A(), true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 15, \u001D\u0014\u0018.\u000A(), true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 16, \u0007\u0014\u0018.\u000A(), true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 17, \u000A\u0014\u0018.\u000A(), true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 18, "SheetLink", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 19, "SheetLink - ElementsWindowModel", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 20, "SheetLink - FamilyTreeHandler", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 21, "OneFilter", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 22, "OneFilter - ContainsFeature", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 23, "OneFilter - VisualizeFeature", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 24, "OneFilter - SelectionsAndRuleFilter", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 25, "FamilyReviser", true);
					CategoriesComparisonExcelTester.\u0019(u001F3, 3, 26, "ReOrdering", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 2, 9, "The following disciplines are only from SheetLink in which they will be used as a global reference for all tools", false);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 2, "Display Name", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 3, "Id", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 4, "Enum Name", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 5, "Is Tag", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 6, "Is Visible in UI", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 7, "Is Valid for Key Schedule", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 8, "Is Valid for Schedule", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 9, \u0005\u0014\u0018.\u000A(), true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 10, \u0018\u0014\u0018.\u000A(), true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 11, \u0019\u0014\u0018.\u000A(), true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 12, \u0004\u0014\u0018.\u000A(), true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 13, \u001D\u0014\u0018.\u000A(), true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 14, \u0007\u0014\u0018.\u000A(), true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 15, \u000A\u0014\u0018.\u000A(), true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 16, "SheetLink", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 17, "SheetLink - ElementsWindowModel", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 18, "SheetLink - FamilyTreeHandler", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 19, "OneFilter", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 20, "OneFilter - ContainsFeature", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 21, "OneFilter - VisualizeFeature", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 22, "OneFilter - SelectionsAndRuleFilter", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 23, "FamilyReviser", true);
					CategoriesComparisonExcelTester.\u0019(u001F4, 3, 24, "ReOrdering", true);
					IEnumerable<Category> enumerable = Enumerable.Cast<Category>(\u000D\u0001\u001D.\u000A(\u0010\u0001\u001D.\u000A(\u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(uiApp)))));
					Func<Category, bool> func;
					if ((func = CategoriesComparisonExcelTester.<>c.\u000A) == null)
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
						func = (CategoriesComparisonExcelTester.<>c.\u000A = new Func<Category, bool>(CategoriesComparisonExcelTester.<>c.\u001F.\u0018));
					}
					IEnumerable<Category> enumerable2 = Enumerable.Where<Category>(enumerable, func);
					Func<Category, string> func2;
					if ((func2 = CategoriesComparisonExcelTester.<>c.\u0007) == null)
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
						func2 = (CategoriesComparisonExcelTester.<>c.\u0007 = new Func<Category, string>(CategoriesComparisonExcelTester.<>c.\u001F.\u0005));
					}
					object u001F5 = Enumerable.OrderBy<Category, string>(enumerable2, func2);
					int num = 4;
					IEnumerator<Category> enumerator = \u001D\u0013\u0005.\u000A(u001F5);
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							Category category = \u0007\u0013\u0005.\u000A(enumerator);
							CategoriesComparisonExcelTester.\u000A(u001F3, num, category);
							num++;
							if (!\u0004\u0013\u0005.\u000A(\u0008\u0001\u001D.\u000A(category)))
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
								IEnumerable<Category> enumerable3 = Enumerable.OfType<Category>(\u0008\u0001\u001D.\u000A(category));
								Func<Category, bool> func3;
								if ((func3 = CategoriesComparisonExcelTester.<>c.\u001D) == null)
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
									func3 = (CategoriesComparisonExcelTester.<>c.\u001D = new Func<Category, bool>(CategoriesComparisonExcelTester.<>c.\u001F.\u0016));
								}
								IEnumerator<Category> enumerator2 = \u001D\u0013\u0005.\u000A(Enumerable.Where<Category>(enumerable3, func3));
								try
								{
									while (\u000A\u0017\u000A.\u000A(enumerator2))
									{
										Category u = \u0007\u0013\u0005.\u000A(enumerator2);
										CategoriesComparisonExcelTester.\u0007(u001F3, num, u);
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
									if (enumerator2 != null)
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
										\u001F\u0017\u000A.\u000A(enumerator2);
									}
								}
							}
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
								switch (6)
								{
								case 0:
									continue;
								}
								break;
							}
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
					IEnumerable<Category> enumerable4 = Enumerable.Cast<Category>(\u000D\u0001\u001D.\u000A(\u0010\u0001\u001D.\u000A(\u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(uiApp)))));
					Func<Category, bool> func4;
					if ((func4 = CategoriesComparisonExcelTester.<>c.\u0004) == null)
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
						func4 = (CategoriesComparisonExcelTester.<>c.\u0004 = new Func<Category, bool>(CategoriesComparisonExcelTester.<>c.\u001F.\u000B));
					}
					IEnumerable<Category> enumerable5 = Enumerable.Where<Category>(enumerable4, func4);
					Func<Category, string> func5;
					if ((func5 = CategoriesComparisonExcelTester.<>c.\u0019) == null)
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
						func5 = (CategoriesComparisonExcelTester.<>c.\u0019 = new Func<Category, string>(CategoriesComparisonExcelTester.<>c.\u001F.\u0002));
					}
					object u001F6 = Enumerable.OrderBy<Category, string>(enumerable5, func5);
					num = 4;
					enumerator = \u001D\u0013\u0005.\u000A(u001F6);
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							Category u2 = \u0007\u0013\u0005.\u000A(enumerator);
							CategoriesComparisonExcelTester.\u001F(u001F4, num, u2);
							num++;
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
								switch (5)
								{
								case 0:
									continue;
								}
								break;
							}
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
					\u000A\u0013\u0005.\u000A(workbook, 0);
					\u0016\u0007\u0005.\u000A(workbook, "C:\\Users\\pc\\Downloads\\Categories.xlsx");
					u0010_u0008_u000A.\u0019();
				}
				catch
				{
				}
			}
		}

		// Token: 0x060018B0 RID: 6320 RVA: 0x000A0224 File Offset: 0x0009E424
		private static void \u001F(IWorksheet \u001F, int \u000A, Category \u0007)
		{
		}

		// Token: 0x060018B1 RID: 6321 RVA: 0x000A0234 File Offset: 0x0009E434
		private static void \u000A(IWorksheet \u001F, int \u000A, Category \u0007)
		{
		}

		// Token: 0x060018B2 RID: 6322 RVA: 0x000A0244 File Offset: 0x0009E444
		private static void \u0007(IWorksheet \u001F, int \u000A, Category \u0007)
		{
		}

		// Token: 0x060018B3 RID: 6323 RVA: 0x000A0254 File Offset: 0x0009E454
		private static void \u001D(IWorksheet \u001F, int \u000A, Category \u0007, ICategoryModel \u001D, ICategoryModel \u0004, int? \u0019, DiRoots.One.OneFilter.CategoryCollection \u0018, ICategoryViewModel \u0005, ICategoryViewModel \u0016, CategoryViewModel \u000B, long? \u0002, DiRoots.One.ReOrdering.Core.Models.CategoryCollection \u0006)
		{
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 2, \u0012\u0013\u0005.\u000A(\u000F\u0013\u0005.\u000A(\u0007)), false);
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 3, \u001A\u000C\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u0007)), false);
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 4, \u000F\u0013\u0005.\u000A(\u0007).ToString(), false);
			int u = 5;
			string u001D;
			if (!\u0006\u0013\u0005.\u000A(\u0007))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoriesComparisonExcelTester.\u001D(IWorksheet, int, Category, ICategoryModel, ICategoryModel, int?, DiRoots.One.OneFilter.CategoryCollection, ICategoryViewModel, ICategoryViewModel, CategoryViewModel, long?, DiRoots.One.ReOrdering.Core.Models.CategoryCollection)).MethodHandle;
				}
				u001D = "false";
			}
			else
			{
				u001D = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u, u001D, false);
			int u2 = 6;
			string u001D2;
			if (!\u0002\u0013\u0005.\u000A(\u0007))
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
				u001D2 = "false";
			}
			else
			{
				u001D2 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u2, u001D2, false);
			int u3 = 7;
			string u001D3;
			if (!\u000B\u0013\u0005.\u000A(\u0007))
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
				u001D3 = "false";
			}
			else
			{
				u001D3 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u3, u001D3, false);
			int u4 = 8;
			string u001D4;
			if (!\u0016\u0013\u0005.\u000A(\u0007))
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
				u001D4 = "false";
			}
			else
			{
				u001D4 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u4, u001D4, false);
			int u5 = 9;
			string u001D5;
			if (!\u0005\u0013\u0005.\u000A(\u0015\u0014\u000A.\u001D(\u0007)))
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
				u001D5 = "false";
			}
			else
			{
				u001D5 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u5, u001D5, false);
			int u6 = 10;
			string u001D6;
			if (!\u0018\u0013\u0005.\u000A(\u0015\u0014\u000A.\u001D(\u0007)))
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
				u001D6 = "false";
			}
			else
			{
				u001D6 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u6, u001D6, false);
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
				if (\u001F\u0020\u001D.\u000A(\u000F\u001C\u0018.\u000A(\u001D), "1"))
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
					CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 11, "true", false);
				}
				if (\u001F\u0020\u001D.\u000A(\u000F\u001C\u0018.\u000A(\u001D), "2"))
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
					CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 12, "true", false);
				}
				if (\u001F\u0020\u001D.\u000A(\u000F\u001C\u0018.\u000A(\u001D), "3"))
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
					CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 13, "true", false);
				}
				if (\u001F\u0020\u001D.\u000A(\u000F\u001C\u0018.\u000A(\u001D), "4"))
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
					CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 14, "true", false);
				}
				if (\u001F\u0020\u001D.\u000A(\u000F\u001C\u0018.\u000A(\u001D), "5"))
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
					CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 15, "true", false);
				}
				if (\u001F\u0020\u001D.\u000A(\u000F\u001C\u0018.\u000A(\u001D), "6"))
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
					CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 16, "true", false);
				}
				if (\u001F\u0020\u001D.\u000A(\u000F\u001C\u0018.\u000A(\u001D), "7"))
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
					CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 17, "true", false);
				}
			}
			int u7 = 18;
			string u001D7;
			if (\u001D == null)
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
				u001D7 = "false";
			}
			else
			{
				u001D7 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u7, u001D7, false);
			int u8 = 19;
			string u001D8;
			if (\u0004 == null)
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
				u001D8 = "false";
			}
			else
			{
				u001D8 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u8, u001D8, false);
			int u9 = 20;
			string u001D9;
			if (!\u000A\u000A\u001D.\u000A(ref \u0019))
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
				u001D9 = "false";
			}
			else
			{
				u001D9 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u9, u001D9, false);
			int u10 = 21;
			string u001D10;
			if (\u0018 == null)
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
				u001D10 = "false";
			}
			else
			{
				u001D10 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u10, u001D10, false);
			int u11 = 22;
			string u001D11;
			if (\u0005 == null)
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
				u001D11 = "false";
			}
			else
			{
				u001D11 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u11, u001D11, false);
			int u12 = 23;
			string u001D12;
			if (\u0016 == null)
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
				u001D12 = "false";
			}
			else
			{
				u001D12 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u12, u001D12, false);
			int u13 = 24;
			string u001D13;
			if (\u000B == null)
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
				u001D13 = "false";
			}
			else
			{
				u001D13 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u13, u001D13, false);
			int u14 = 25;
			string u001D14;
			if (!\u0016\u0002\u0004.\u000A(ref \u0002))
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
				u001D14 = "false";
			}
			else
			{
				u001D14 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u14, u001D14, false);
			int u15 = 26;
			string u001D15;
			if (\u0006 == null)
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
				u001D15 = "false";
			}
			else
			{
				u001D15 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u15, u001D15, false);
		}

		// Token: 0x060018B4 RID: 6324 RVA: 0x000A066C File Offset: 0x0009E86C
		private static void \u0004(IWorksheet \u001F, int \u000A, Category \u0007, ICategoryModel \u001D, ICategoryModel \u0004, int? \u0019, DiRoots.One.OneFilter.CategoryCollection \u0018, ICategoryViewModel \u0005, ICategoryViewModel \u0016, CategoryViewModel \u000B, long? \u0002, DiRoots.One.ReOrdering.Core.Models.CategoryCollection \u0006)
		{
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 2, \u0012\u0013\u0005.\u000A(\u000F\u0013\u0005.\u000A(\u0007)), false);
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 3, \u001A\u000C\u000A.\u000A(\u0015\u0014\u000A.\u001D(\u0007)), false);
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 4, \u000F\u0013\u0005.\u000A(\u0007).ToString(), false);
			int u = 5;
			string u001D;
			if (!\u0003\u0013\u0005.\u000A(\u0007))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoriesComparisonExcelTester.\u0004(IWorksheet, int, Category, ICategoryModel, ICategoryModel, int?, DiRoots.One.OneFilter.CategoryCollection, ICategoryViewModel, ICategoryViewModel, CategoryViewModel, long?, DiRoots.One.ReOrdering.Core.Models.CategoryCollection)).MethodHandle;
				}
				u001D = "false";
			}
			else
			{
				u001D = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u, u001D, false);
			int u2 = 6;
			string u001D2;
			if (!\u000B\u0013\u0005.\u000A(\u0007))
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
				u001D2 = "false";
			}
			else
			{
				u001D2 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u2, u001D2, false);
			int u3 = 7;
			string u001D3;
			if (!\u0005\u0013\u0005.\u000A(\u0015\u0014\u000A.\u001D(\u0007)))
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
				u001D3 = "false";
			}
			else
			{
				u001D3 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u3, u001D3, false);
			int u4 = 8;
			string u001D4;
			if (!\u0018\u0013\u0005.\u000A(\u0015\u0014\u000A.\u001D(\u0007)))
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
				u001D4 = "false";
			}
			else
			{
				u001D4 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u4, u001D4, false);
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
				if (\u001F\u0020\u001D.\u000A(\u000F\u001C\u0018.\u000A(\u001D), "1"))
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
					CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 9, "true", false);
				}
				if (\u001F\u0020\u001D.\u000A(\u000F\u001C\u0018.\u000A(\u001D), "2"))
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
					CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 10, "true", false);
				}
				if (\u001F\u0020\u001D.\u000A(\u000F\u001C\u0018.\u000A(\u001D), "3"))
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
					CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 11, "true", false);
				}
				if (\u001F\u0020\u001D.\u000A(\u000F\u001C\u0018.\u000A(\u001D), "4"))
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
					CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 12, "true", false);
				}
				if (\u001F\u0020\u001D.\u000A(\u000F\u001C\u0018.\u000A(\u001D), "5"))
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
					CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 13, "true", false);
				}
				if (\u001F\u0020\u001D.\u000A(\u000F\u001C\u0018.\u000A(\u001D), "6"))
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
					CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 14, "true", false);
				}
				if (\u001F\u0020\u001D.\u000A(\u000F\u001C\u0018.\u000A(\u001D), "7"))
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
					CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, 15, "true", false);
				}
			}
			int u5 = 16;
			string u001D5;
			if (\u001D == null)
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
				u001D5 = "false";
			}
			else
			{
				u001D5 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u5, u001D5, false);
			int u6 = 17;
			string u001D6;
			if (\u0004 == null)
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
				u001D6 = "false";
			}
			else
			{
				u001D6 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u6, u001D6, false);
			int u7 = 18;
			string u001D7;
			if (!\u000A\u000A\u001D.\u000A(ref \u0019))
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
				u001D7 = "false";
			}
			else
			{
				u001D7 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u7, u001D7, false);
			int u8 = 19;
			string u001D8;
			if (\u0018 == null)
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
				u001D8 = "false";
			}
			else
			{
				u001D8 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u8, u001D8, false);
			int u9 = 20;
			string u001D9;
			if (\u0005 == null)
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
				u001D9 = "false";
			}
			else
			{
				u001D9 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u9, u001D9, false);
			int u10 = 21;
			string u001D10;
			if (\u0016 == null)
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
				u001D10 = "false";
			}
			else
			{
				u001D10 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u10, u001D10, false);
			int u11 = 22;
			string u001D11;
			if (\u000B == null)
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
				u001D11 = "false";
			}
			else
			{
				u001D11 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u11, u001D11, false);
			int u12 = 23;
			string u001D12;
			if (!\u0016\u0002\u0004.\u000A(ref \u0002))
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
				u001D12 = "false";
			}
			else
			{
				u001D12 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u12, u001D12, false);
			int u13 = 24;
			string u001D13;
			if (\u0006 == null)
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
				u001D13 = "false";
			}
			else
			{
				u001D13 = "true";
			}
			CategoriesComparisonExcelTester.\u0019(\u001F, \u000A, u13, u001D13, false);
		}

		// Token: 0x060018B5 RID: 6325 RVA: 0x000A0A30 File Offset: 0x0009EC30
		private static void \u0019(IWorksheet \u001F, int \u000A, int \u0007, string \u001D, bool \u0004 = false)
		{
			IRange u001F = \u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(\u001F), \u000A, \u0007);
			\u0013\u0009\u0019.\u000A(u001F, \u001D);
			if (\u0004)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CategoriesComparisonExcelTester.\u0019(IWorksheet, int, int, string, bool)).MethodHandle;
				}
				\u0012\u000B\u0005.\u000A(u001F, "DiRootsHeaderStyle");
			}
		}
	}
}

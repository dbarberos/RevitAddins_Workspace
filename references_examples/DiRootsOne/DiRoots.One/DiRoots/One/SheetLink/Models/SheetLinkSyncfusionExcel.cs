using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;
using Syncfusion.XlsIO;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x0200023B RID: 571
	public class SheetLinkSyncfusionExcel
	{
		// Token: 0x0600169D RID: 5789 RVA: 0x00093F20 File Offset: 0x00092120
		public SheetLinkSyncfusionExcel(Workbook workbook, bool closeWorkbook = true)
		{
			List<Workbook> list = new List<Workbook>();
			\u001F\u0003\u0005.\u000A(list, workbook);
			\u0009\u0012\u0005.\u000A(this, list);
			\u0001\u0012\u0005.\u000A(this, closeWorkbook);
			\u0015\u0012\u0005.\u0007(this, new Dictionary<string, List<int>>());
			this.\u0004 = new ExcelEngine();
			this.\u0019 = \u000E\u001E\u001D.\u000A(this.\u0004);
		}

		// Token: 0x0600169E RID: 5790 RVA: 0x00093F78 File Offset: 0x00092178
		public SheetLinkSyncfusionExcel(List<Workbook> workbooks, bool closeWorkbook = true)
		{
			\u0009\u0012\u0005.\u000A(this, new List<Workbook>(workbooks));
			\u0001\u0012\u0005.\u000A(this, closeWorkbook);
			\u0015\u0012\u0005.\u0007(this, new Dictionary<string, List<int>>());
			this.\u0004 = new ExcelEngine();
			this.\u0019 = \u000E\u001E\u001D.\u000A(this.\u0004);
		}

		// Token: 0x17000628 RID: 1576
		// (get) Token: 0x0600169F RID: 5791 RVA: 0x00093FC8 File Offset: 0x000921C8
		// (set) Token: 0x060016A0 RID: 5792 RVA: 0x00093FDC File Offset: 0x000921DC
		public bool CloseWorkbook { get; set; }

		// Token: 0x17000629 RID: 1577
		// (get) Token: 0x060016A1 RID: 5793 RVA: 0x00093FF0 File Offset: 0x000921F0
		// (set) Token: 0x060016A2 RID: 5794 RVA: 0x00094004 File Offset: 0x00092204
		public List<Workbook> Workbooks { get; set; }

		// Token: 0x1700062A RID: 1578
		// (get) Token: 0x060016A3 RID: 5795 RVA: 0x00094018 File Offset: 0x00092218
		// (set) Token: 0x060016A4 RID: 5796 RVA: 0x0009402C File Offset: 0x0009222C
		public List<ParamValueInfo> ParamValues { get; set; }

		// Token: 0x1700062B RID: 1579
		// (get) Token: 0x060016A5 RID: 5797 RVA: 0x00094040 File Offset: 0x00092240
		// (set) Token: 0x060016A6 RID: 5798 RVA: 0x00094054 File Offset: 0x00092254
		public Dictionary<string, List<int>> ColumnIndex { get; set; }

		// Token: 0x060016A7 RID: 5799 RVA: 0x00094068 File Offset: 0x00092268
		public void Export(Delegate progressChanged)
		{
			try
			{
				bool flag = false;
				List<Workbook>.Enumerator enumerator = \u0018\u001C\u0005.\u000A(\u0005\u001C\u0005.\u000A(this));
				try
				{
					while (\u000A\u0003\u0005.\u000A(ref enumerator))
					{
						Workbook workbook = \u0019\u001C\u0005.\u000A(ref enumerator);
						int num = 1;
						IWorkbook workbook2;
						if (\u0010\u0002\u001D.\u000A(\u001D\u0003\u0005.\u000A(workbook)))
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(SheetLinkSyncfusionExcel.Export(Delegate)).MethodHandle;
							}
							workbook2 = \u0004\u001C\u0005.\u000A(\u000D\u001E\u001D.\u000A(this.\u0019), \u001D\u0003\u0005.\u000A(workbook));
						}
						else
						{
							flag = true;
							object u001F = \u000D\u001E\u001D.\u000A(this.\u0019);
							string[] array = \u001B\u001F\u000E.\u001F(1);
							array[0] = "Instructions";
							workbook2 = \u0002\u0007\u0005.\u000A(u001F, array);
						}
						\u001D\u001C\u0005.\u000A(workbook2, false);
						\u0007\u001C\u0005.\u000A(workbook2, ExcelVersion.Xlsx);
						\u000A\u001C\u0005.\u000A(workbook2, "Calibri");
						\u001F\u001C\u0005.\u000A(workbook2, 11.0);
						\u001D\u0009\u0018.\u000A(workbook2);
						List<Worksheet>.Enumerator enumerator2 = \u0009\u0003\u0005.\u000A(\u001E\u001D\u0018.\u000A(workbook));
						try
						{
							while (\u0018\u0003\u0005.\u000A(ref enumerator2))
							{
								SheetLinkSyncfusionExcel.\u000D\u001C u000D_u001C = new SheetLinkSyncfusionExcel.\u000D\u001C();
								u000D_u001C.\u001F = \u0001\u0003\u0005.\u000A(ref enumerator2);
								if (progressChanged != null)
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
									object[] array2 = \u0004\u0015\u0010.\u001F(1);
									array2[0] = num++;
									\u0010\u001F\u0018.\u000A(progressChanged, array2);
								}
								if (!\u0008\u0013\u000A.\u000A(\u0020\u001D\u0018.\u000A(u000D_u001C.\u001F), "ParamValues"))
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
									IWorksheet worksheet = Enumerable.FirstOrDefault<IWorksheet>(\u0003\u001E\u001D.\u000A(workbook2), new Func<IWorksheet, bool>(u000D_u001C.\u000A));
									if (worksheet == null)
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
										worksheet = \u0012\u001F\u0018.\u000A(\u0003\u001E\u001D.\u000A(workbook2), \u0020\u001D\u0018.\u000A(u000D_u001C.\u001F));
									}
									else if (\u0008\u0013\u000A.\u000A(\u0014\u0011\u001D.\u000A(worksheet), "Instructions"))
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
										try
										{
											\u0015\u0003\u0005.\u000A(worksheet, \u0017\u0011\u001D.\u000A(\u0003\u001E\u001D.\u000A(workbook2)) - 1);
										}
										catch (Exception u000A)
										{
											\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Models\\Excels\\SheetLinkSyncfusionExcel.cs", "Export");
										}
										if (!flag)
										{
											continue;
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
									if (worksheet != null)
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
										if (\u001D\u0017\u000A.\u000A(\u0014\u0011\u001D.\u000A(worksheet), "Instructions"))
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
											int num2 = \u000F\u0003\u0005.\u000A(\u0011\u0003\u0005.\u000A(u000D_u001C.\u001F));
											int num3 = \u000B\u0003\u0005.\u000A(\u0011\u0003\u0005.\u000A(u000D_u001C.\u001F));
											\u001C\u0003\u0005.\u000A(this, worksheet, u000D_u001C.\u001F, num2 - 1, \u0020\u001D\u0018.\u000A(u000D_u001C.\u001F));
											List<ExcelRow>.Enumerator enumerator3 = \u000C\u0003\u0005.\u000A(\u0006\u0011\u0018.\u000A(u000D_u001C.\u001F));
											try
											{
												while (\u001E\u0003\u0005.\u000A(ref enumerator3))
												{
													ExcelRow u001F2 = \u001A\u0003\u0005.\u000A(ref enumerator3);
													\u000F\u001F\u0018.\u000A(worksheet, \u0014\u0003\u0005.\u000A(u001F2), !\u0013\u0003\u0005.\u000A(u001F2));
													if (!\u0013\u0003\u0005.\u000A(u001F2))
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
														\u0020\u0003\u0005.\u000A(worksheet, \u0014\u0003\u0005.\u000A(u001F2), \u0017\u0003\u0005.\u000A(u001F2));
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
												((IDisposable)enumerator3).Dispose();
											}
											\u000C\u001E\u0018.\u000A(\u0018\u001E\u001D.\u000A(worksheet));
											IRange u000A2 = \u0016\u0003\u0005.\u000A(worksheet, num2, 1, \u0002\u0003\u0005.\u000A(\u0011\u0003\u0005.\u000A(u000D_u001C.\u001F)), \u000B\u0003\u0005.\u000A(\u0011\u0003\u0005.\u000A(u000D_u001C.\u001F)));
											\u0013\u001E\u0018.\u000A(\u001A\u001E\u0018.\u000A(worksheet), u000A2);
											\u0006\u001F\u0018.\u000A(\u001F\u0014\u001D.\u000A(\u0016\u0003\u0005.\u000A(worksheet, num2, 1, num2, num3 + 1)), true);
											\u0006\u001F\u0018.\u000A(\u001F\u0014\u001D.\u000A(\u0016\u0003\u0005.\u000A(worksheet, num2 - 1, 1, num2 - 1, num3)), true);
											\u001B\u0003\u0005.\u000A(this, worksheet, u000D_u001C.\u001F, num2 - 1);
											\u0008\u0003\u0005.\u000A(worksheet, num2 + 1, 1);
											List<MergeRange>.Enumerator enumerator4 = \u0003\u0003\u0005.\u000A(\u0012\u0011\u0018.\u000A(u000D_u001C.\u001F));
											try
											{
												while (\u0005\u0003\u0005.\u000A(ref enumerator4))
												{
													MergeRange u001F3 = \u0012\u0003\u0005.\u000A(ref enumerator4);
													IRange u001F4 = \u0016\u0003\u0005.\u000A(worksheet, \u000F\u0003\u0005.\u000A(u001F3), \u0006\u0003\u0005.\u000A(u001F3), \u0002\u0003\u0005.\u000A(u001F3), \u000B\u0003\u0005.\u000A(u001F3));
													\u0015\u0001\u0019.\u000A(u001F4);
													\u0012\u000B\u0005.\u000A(u001F4, \u000E\u0003\u0005.\u000A(\u000F\u000A\u0004.\u000A(worksheet, \u000F\u0003\u0005.\u000A(u001F3), \u0006\u0003\u0005.\u000A(u001F3))));
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
												((IDisposable)enumerator4).Dispose();
											}
											List<int> u001F5;
											if (this.\u0005(\u0020\u001D\u0018.\u000A(u000D_u001C.\u001F), \u0014\u0011\u001D.\u000A(worksheet), out u001F5))
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
												List<int>.Enumerator enumerator5 = \u0009\u0013\u0004.\u000A(u001F5);
												try
												{
													while (\u0017\u0013\u0004.\u000A(ref enumerator5))
													{
														int num4 = \u0001\u0013\u0004.\u000A(ref enumerator5);
														\u0015\u001E\u0018.\u000A(\u000D\u000B\u0005.\u000A(worksheet)[num4], "@");
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
													((IDisposable)enumerator5).Dispose();
												}
											}
											\u0010\u0003\u0005.\u000A(worksheet, 1, false);
											\u001A\u0001\u0019.\u000A(\u000F\u000A\u0004.\u000A(worksheet, num2, 2));
										}
										else
										{
											\u000D\u0003\u0005.\u000A(worksheet, false);
											\u001C\u0003\u0005.\u000A(this, worksheet, u000D_u001C.\u001F, -1, \u0020\u001D\u0018.\u000A(u000D_u001C.\u001F));
											List<MergeRange>.Enumerator enumerator4 = \u0003\u0003\u0005.\u000A(\u0012\u0011\u0018.\u000A(u000D_u001C.\u001F));
											try
											{
												while (\u0005\u0003\u0005.\u000A(ref enumerator4))
												{
													MergeRange u001F6 = \u0012\u0003\u0005.\u000A(ref enumerator4);
													\u0015\u0001\u0019.\u000A(\u0016\u0003\u0005.\u000A(worksheet, \u000F\u0003\u0005.\u000A(u001F6), \u0006\u0003\u0005.\u000A(u001F6), \u0002\u0003\u0005.\u000A(u001F6), \u000B\u0003\u0005.\u000A(u001F6)));
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
												((IDisposable)enumerator4).Dispose();
											}
											\u000C\u001E\u0018.\u000A(\u0018\u001E\u001D.\u000A(worksheet));
										}
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
							((IDisposable)enumerator2).Dispose();
						}
						\u0019\u0003\u0005.\u000A(this, workbook2, workbook);
						\u0004\u0003\u0005.\u000A(this, workbook2, progressChanged);
						\u000B\u0007\u0005.\u000A(\u0012\u001E\u001D.\u000A(\u0003\u001E\u001D.\u000A(workbook2), 0));
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
							\u0016\u0007\u0005.\u000A(workbook2, \u001D\u0003\u0005.\u000A(workbook));
						}
						else
						{
							\u0007\u0003\u0005.\u000A(workbook2);
						}
						\u0019\u001A\u0004.\u000A(workbook2);
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
			}
			catch (Exception u000A3)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Models\\Excels\\SheetLinkSyncfusionExcel.cs", "Export");
				throw;
			}
			finally
			{
				\u000D\u0012\u0004.\u001D(this.\u0004);
			}
		}

		// Token: 0x060016A8 RID: 5800 RVA: 0x000947DC File Offset: 0x000929DC
		public void AddHeaderInfo(IWorksheet worksheet, Worksheet dWorksheet, int rowIndex)
		{
			SheetLinkSyncfusionExcel.\u0010\u001C u0010_u001C = new SheetLinkSyncfusionExcel.\u0010\u001C();
			u0010_u001C.\u001F = rowIndex;
			List<Range>.Enumerator enumerator = \u000F\u001C\u0005.\u000A(Enumerable.ToList<Range>(Enumerable.Where<Range>(\u000D\u0004\u0018.\u000A(dWorksheet), new Func<Range, bool>(u0010_u001C.\u000A))));
			try
			{
				while (\u0016\u001C\u0005.\u000A(ref enumerator))
				{
					Range u001F = \u0006\u001C\u0005.\u000A(ref enumerator);
					\u0001\u001E\u0018.\u000A(\u000F\u000A\u0004.\u000A(worksheet, \u0002\u001C\u0005.\u000A(u001F), \u000B\u001C\u0005.\u000A(u001F)), \u001D\u0019\u0018.\u000A(u001F));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetLinkSyncfusionExcel.AddHeaderInfo(IWorksheet, Worksheet, int)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060016A9 RID: 5801 RVA: 0x00094890 File Offset: 0x00092A90
		public void EditWorkSheet(IWorksheet worksheet, Worksheet dWorksheet, int skipIndex, string columnIndexKey = null)
		{
			IEnumerable<Range> enumerable = \u000D\u0004\u0018.\u000A(dWorksheet);
			Func<Range, int> func;
			if ((func = SheetLinkSyncfusionExcel.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetLinkSyncfusionExcel.EditWorkSheet(IWorksheet, Worksheet, int, string)).MethodHandle;
				}
				func = (SheetLinkSyncfusionExcel.<>c.\u000A = new Func<Range, int>(SheetLinkSyncfusionExcel.<>c.\u001F.\u001D));
			}
			Enumerable.Max<Range>(enumerable, func);
			int num = \u0018\u0019\u0018.\u000A(\u000D\u0004\u0018.\u000A(dWorksheet));
			List<int> u001F = \u0017\u000B\u001D.\u000A();
			string text = columnIndexKey;
			if (columnIndexKey == null)
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
				text = \u0014\u0011\u001D.\u000A(worksheet);
			}
			string u001F2 = text;
			List<int> list;
			if (this.\u0005(u001F2, null, out list))
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
				u001F = list;
			}
			int i = 1;
			while (i <= num)
			{
				Range range = \u0004\u0019\u0018.\u000A(\u000D\u0004\u0018.\u000A(dWorksheet), i - 1);
				if (skipIndex == -1)
				{
					goto IL_D1;
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
				if (\u0002\u001C\u0005.\u000A(range) != skipIndex)
				{
					for (;;)
					{
						switch (6)
						{
						case 0:
							continue;
						}
						goto IL_D1;
					}
				}
				IL_2B2:
				i++;
				continue;
				IL_D1:
				IRange range2 = \u000F\u000A\u0004.\u000A(worksheet, \u0002\u001C\u0005.\u000A(range), \u000B\u001C\u0005.\u000A(range));
				if (\u001A\u001C\u0005.\u000A(range))
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
					List<ExcelRichText>.Enumerator enumerator = \u0014\u001C\u0005.\u000A(\u0013\u001C\u0005.\u000A(range));
					try
					{
						while (\u000E\u001C\u0005.\u000A(ref enumerator))
						{
							ExcelRichText u001F3 = \u0017\u001C\u0005.\u000A(ref enumerator);
							IFont font = \u0020\u001C\u0005.\u000A(\u000F\u0020\u001D.\u000A(worksheet));
							\u001E\u0009\u0019.\u000A(font, \u001E\u001C\u0005.\u000A(\u000C\u0020\u0018.\u000A(\u0011\u001C\u0005.\u000A(u001F3))));
							\u0017\u0009\u0019.\u000A(font, \u000D\u001C\u0005.\u000A(\u000C\u0020\u0018.\u000A(\u0011\u001C\u0005.\u000A(u001F3))));
							\u0003\u0009\u0019.\u000A(font, (double)\u0003\u001C\u0005.\u000A(\u000C\u0020\u0018.\u000A(\u0011\u001C\u0005.\u000A(u001F3))));
							\u000D\u0009\u0019.\u000A(font, "Calibri");
							\u0008\u001C\u0005.\u000A(\u0014\u0015\u0004.\u000A(range2), \u001B\u001C\u0005.\u000A(u001F3), font);
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
						goto IL_1EA;
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
					goto IL_1E0;
				}
				goto IL_1E0;
				IL_1EA:
				if (!\u001A\u0006\u0007.\u000A(\u0010\u001C\u0005.\u000A(range)))
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
					\u0012\u000B\u0005.\u000A(range2, \u0010\u001C\u0005.\u000A(range));
				}
				else if (\u001C\u001C\u0005.\u000A(range) != null)
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
					\u0017\u0009\u0019.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(range2)), \u000D\u001C\u0005.\u000A(\u000C\u0020\u0018.\u000A(\u001C\u001C\u0005.\u000A(range))));
					\u0003\u0009\u0019.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(range2)), (double)\u0003\u001C\u0005.\u000A(\u000C\u0020\u0018.\u000A(\u001C\u001C\u0005.\u000A(range))));
				}
				if (!\u001A\u0006\u0007.\u000A(\u0012\u001C\u0005.\u000A(range)))
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
					\u0015\u001E\u0018.\u000A(range2, \u0012\u001C\u0005.\u000A(range));
					goto IL_2B2;
				}
				goto IL_2B2;
				IL_1E0:
				SheetLinkSyncfusionExcel.\u0018(u001F, range, range2);
				goto IL_1EA;
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

		// Token: 0x060016AA RID: 5802 RVA: 0x00094B78 File Offset: 0x00092D78
		private static void \u0018(List<int> \u001F, Range \u000A, IRange \u0007)
		{
			if (!\u0005\u001F\u0018.\u000A(\u001F, \u000B\u001C\u0005.\u000A(\u000A)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetLinkSyncfusionExcel.\u0018(List<int>, Range, IRange)).MethodHandle;
				}
				if (!\u0008\u0013\u000A.\u000A(\u0012\u001C\u0005.\u000A(\u000A), "@"))
				{
					\u0001\u001E\u0018.\u000A(\u0007, \u001D\u0019\u0018.\u000A(\u000A));
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
			}
			\u0015\u001E\u0018.\u000A(\u0007, "@");
			object obj = \u001D\u0019\u0018.\u000A(\u000A);
			string u000A;
			if (obj == null)
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
				u000A = \u000F\u0015\u0010.\u001F;
			}
			else
			{
				u000A = \u001A\u000C\u000A.\u000A(obj);
			}
			\u0009\u001E\u0018.\u000A(\u0007, u000A);
		}

		// Token: 0x060016AB RID: 5803 RVA: 0x00094C10 File Offset: 0x00092E10
		private unsafe bool \u0005(string \u001F, string \u000A, out List<int> \u0007)
		{
			if (!\u001A\u0006\u0007.\u000A(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetLinkSyncfusionExcel.\u0005(string, string, List<int>*)).MethodHandle;
				}
				if (\u000C\u001C\u0005.\u000A(\u0015\u001C\u0005.\u000A(this), \u001F, ref \u0007))
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
					return true;
				}
			}
			if (!\u001A\u0006\u0007.\u000A(\u000A))
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
				if (\u000C\u001C\u0005.\u000A(\u0015\u001C\u0005.\u000A(this), \u000A, ref \u0007))
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
					return true;
				}
			}
			\u0007 = null;
			return false;
		}

		// Token: 0x060016AC RID: 5804 RVA: 0x00094C90 File Offset: 0x00092E90
		public void AddNamedRange(IWorkbook workbook, Workbook dWorkbook)
		{
			IEnumerable<Worksheet> enumerable = \u001E\u001D\u0018.\u000A(dWorkbook);
			Func<Worksheet, bool> func;
			if ((func = SheetLinkSyncfusionExcel.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetLinkSyncfusionExcel.AddNamedRange(IWorkbook, Workbook)).MethodHandle;
				}
				func = (SheetLinkSyncfusionExcel.<>c.\u0007 = new Func<Worksheet, bool>(SheetLinkSyncfusionExcel.<>c.\u001F.\u0004));
			}
			Worksheet worksheet = Enumerable.FirstOrDefault<Worksheet>(enumerable, func);
			if (worksheet == null)
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
			IWorksheet worksheet2 = \u0015\u000F\u000E.\u001F;
			SheetLinkSyncfusionExcel.\u000E\u001C u000E_u001C = new SheetLinkSyncfusionExcel.\u000E\u001C();
			int num = 1;
			u000E_u001C.\u001F = "ParamValues";
			do
			{
				if (Enumerable.All<IWorksheet>(\u0003\u001E\u001D.\u000A(workbook), new Func<IWorksheet, bool>(u000E_u001C.\u000A)))
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
					worksheet2 = \u0012\u001F\u0018.\u000A(\u0003\u001E\u001D.\u000A(workbook), u000E_u001C.\u001F);
				}
				u000E_u001C.\u001F = \u0004\u001E\u000A.\u000A("ParamValues", \u000C\u0013\u0007.\u000A(ref num));
				num++;
			}
			while (worksheet2 == null);
			for (;;)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			\u0015\u0002\u0018.\u000A(worksheet2, WorksheetVisibility.Hidden);
			\u001C\u0003\u0005.\u000A(this, worksheet2, worksheet, -1, \u000F\u0015\u0010.\u001F);
			List<ExcelNamedRange>.Enumerator enumerator = \u001D\u000D\u0005.\u000A(\u000A\u0002\u0018.\u000A(dWorkbook));
			try
			{
				while (\u0001\u001C\u0005.\u000A(ref enumerator))
				{
					ExcelNamedRange u001F = \u0007\u000D\u0005.\u000A(ref enumerator);
					\u0016\u0002\u0018.\u000A(u001F, this.\u0016(workbook, \u000A\u000D\u0005.\u000A(u001F)));
					\u0009\u001C\u0005.\u000A(\u0007\u0020\u001D.\u000A(workbook), \u000A\u000D\u0005.\u000A(u001F), \u0016\u0003\u0005.\u000A(worksheet2, \u000F\u0003\u0005.\u000A(\u001F\u000D\u0005.\u000A(u001F)), \u0006\u0003\u0005.\u000A(\u001F\u000D\u0005.\u000A(u001F)), \u0002\u0003\u0005.\u000A(\u001F\u000D\u0005.\u000A(u001F)), \u000B\u0003\u0005.\u000A(\u001F\u000D\u0005.\u000A(u001F))));
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

		// Token: 0x060016AD RID: 5805 RVA: 0x00094E58 File Offset: 0x00093058
		private string \u0016(IWorkbook \u001F, string \u000A)
		{
			int num = 1;
			string text = \u000A;
			while (\u000C\u0006\u0004.\u000A(\u0007\u0020\u001D.\u000A(\u001F), text) != null)
			{
				text = \u0018\u000E\u0007.\u000A("{0}_{1}", \u000A, num);
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(SheetLinkSyncfusionExcel.\u0016(IWorkbook, string)).MethodHandle;
			}
			return text;
		}

		// Token: 0x060016AE RID: 5806 RVA: 0x00094EAC File Offset: 0x000930AC
		public void AddValidations(IWorkbook workbook, Delegate progressChanged)
		{
			List<ParamValueInfo>.Enumerator enumerator = \u0001\u000B\u0018.\u000A(\u0018\u000D\u0005.\u000A(this));
			try
			{
				while (\u0014\u000B\u0018.\u000A(ref enumerator))
				{
					SheetLinkSyncfusionExcel.\u0008\u001C u0008_u001C = new SheetLinkSyncfusionExcel.\u0008\u001C();
					u0008_u001C.\u001F = \u0015\u000B\u0018.\u000A(ref enumerator);
					IWorksheet worksheet = Enumerable.FirstOrDefault<IWorksheet>(\u0003\u001E\u001D.\u000A(workbook), new Func<IWorksheet, bool>(u0008_u001C.\u000A));
					if (worksheet != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SheetLinkSyncfusionExcel.AddValidations(IWorkbook, Delegate)).MethodHandle;
						}
						IDataValidation u001F = \u0010\u0002\u0018.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(worksheet), \u0008\u0002\u0018.\u000A(u0008_u001C.\u001F) + 1, \u000E\u0002\u0018.\u000A(u0008_u001C.\u001F), \u001B\u0002\u0018.\u000A(u0008_u001C.\u001F) + \u0008\u0002\u0018.\u000A(u0008_u001C.\u001F), \u000E\u0002\u0018.\u000A(u0008_u001C.\u001F)));
						\u000D\u0002\u0018.\u000A(u001F, \u0019\u000D\u0005.\u000A(u0008_u001C.\u001F));
						\u001C\u0002\u0018.\u000A(u001F, ExcelDataType.User);
						\u0003\u0002\u0018.\u000A(u001F, \u0004\u001E\u000A.\u000A("=", \u000A\u000D\u0005.\u000A(\u0004\u000D\u0005.\u000A(u0008_u001C.\u001F))));
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
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x040008FA RID: 2298
		[CompilerGenerated]
		private bool \u001F;

		// Token: 0x040008FB RID: 2299
		[CompilerGenerated]
		private List<Workbook> \u000A;

		// Token: 0x040008FC RID: 2300
		[CompilerGenerated]
		private List<ParamValueInfo> \u0007;

		// Token: 0x040008FD RID: 2301
		[CompilerGenerated]
		private Dictionary<string, List<int>> \u001D;

		// Token: 0x040008FE RID: 2302
		private ExcelEngine \u0004;

		// Token: 0x040008FF RID: 2303
		private IApplication \u0019;

		// Token: 0x0200090B RID: 2315
		[CompilerGenerated]
		private sealed class \u000D\u001C
		{
			// Token: 0x06005180 RID: 20864 RVA: 0x001E8CE4 File Offset: 0x001E6EE4
			internal bool \u000A(IWorksheet \u001F)
			{
				return \u001B\u0003\u0004.\u000A(\u0014\u0011\u001D.\u000A(\u001F), \u0020\u001D\u0018.\u000A(this.\u001F), StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x040023BE RID: 9150
			public Worksheet \u001F;
		}

		// Token: 0x0200090C RID: 2316
		[CompilerGenerated]
		private sealed class \u0010\u001C
		{
			// Token: 0x06005182 RID: 20866 RVA: 0x001E8D24 File Offset: 0x001E6F24
			internal bool \u000A(Range \u001F)
			{
				return \u0002\u001C\u0005.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x040023BF RID: 9151
			public int \u001F;
		}

		// Token: 0x0200090D RID: 2317
		[CompilerGenerated]
		private sealed class \u000E\u001C
		{
			// Token: 0x06005184 RID: 20868 RVA: 0x001E8D58 File Offset: 0x001E6F58
			internal bool \u000A(IWorksheet \u001F)
			{
				return \u001D\u0017\u000A.\u000A(\u0014\u0011\u001D.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x040023C0 RID: 9152
			public string \u001F;
		}

		// Token: 0x0200090E RID: 2318
		[CompilerGenerated]
		private sealed class \u0008\u001C
		{
			// Token: 0x06005186 RID: 20870 RVA: 0x001E8D90 File Offset: 0x001E6F90
			internal bool \u000A(IWorksheet \u001F)
			{
				return \u001B\u0003\u0004.\u000A(\u0014\u0011\u001D.\u000A(\u001F), \u0011\u0010\u0005.\u000A(this.\u001F), StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x040023C1 RID: 9153
			public ParamValueInfo \u001F;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.SheetLink.Enums;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.XlsIO;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x0200023D RID: 573
	public class SyncfusionControlExcel : ControlExcelBase
	{
		// Token: 0x060016BC RID: 5820 RVA: 0x000956B4 File Offset: 0x000938B4
		public SyncfusionControlExcel(Workbook workbook, bool closeWorkbook = true)
		{
			\u0004\u0010\u0005.\u000A(this, new List<Workbook>());
			\u001F\u0003\u0005.\u000A(\u001D\u0010\u0005.\u000A(this), workbook);
			\u0007\u0010\u0005.\u000A(this, closeWorkbook);
		}

		// Token: 0x060016BD RID: 5821 RVA: 0x000956E8 File Offset: 0x000938E8
		public SyncfusionControlExcel(List<Workbook> workbooks, bool closeWorkbook = true)
		{
			\u0004\u0010\u0005.\u000A(this, new List<Workbook>());
			\u0019\u0010\u0005.\u000A(\u001D\u0010\u0005.\u000A(this), workbooks);
			\u0007\u0010\u0005.\u000A(this, closeWorkbook);
		}

		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x060016BE RID: 5822 RVA: 0x0009571C File Offset: 0x0009391C
		// (set) Token: 0x060016BF RID: 5823 RVA: 0x00095730 File Offset: 0x00093930
		public SfSpreadsheet SheetControl { get; set; }

		// Token: 0x1700062D RID: 1581
		// (get) Token: 0x060016C0 RID: 5824 RVA: 0x00095744 File Offset: 0x00093944
		// (set) Token: 0x060016C1 RID: 5825 RVA: 0x00095758 File Offset: 0x00093958
		public ExportTypes ExportType { get; set; }

		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x060016C2 RID: 5826 RVA: 0x0009576C File Offset: 0x0009396C
		// (set) Token: 0x060016C3 RID: 5827 RVA: 0x00095780 File Offset: 0x00093980
		public Dictionary<string, List<int>> ColumnIndex { get; set; }

		// Token: 0x060016C4 RID: 5828 RVA: 0x00095794 File Offset: 0x00093994
		public void Export(Delegate progressChanged)
		{
			IWorkbook workbook = \u0004\u0009\u0018.\u000A(\u0018\u0010\u0005.\u000A(this));
			if (workbook != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SyncfusionControlExcel.Export(Delegate)).MethodHandle;
				}
				IEnumerable<IWorksheet> enumerable = \u0003\u001E\u001D.\u000A(workbook);
				Func<IWorksheet, bool> func;
				if ((func = SyncfusionControlExcel.<>c.\u000A) == null)
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
					func = (SyncfusionControlExcel.<>c.\u000A = new Func<IWorksheet, bool>(SyncfusionControlExcel.<>c.\u001F.\u0019));
				}
				IWorksheet worksheet = Enumerable.FirstOrDefault<IWorksheet>(enumerable, func);
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
					\u0010\u0010\u0005.\u000A(\u0018\u0010\u0005.\u000A(this), \u0014\u0011\u001D.\u000A(worksheet), "tempInstructions");
				}
				\u000C\u0002\u0018.\u000A(\u0018\u0010\u0005.\u000A(this), "Instructions", 0);
				IEnumerable<IWorksheet> enumerable2 = \u0003\u001E\u001D.\u000A(\u0004\u0009\u0018.\u000A(\u0018\u0010\u0005.\u000A(this)));
				Func<IWorksheet, string> func2;
				if ((func2 = SyncfusionControlExcel.<>c.\u0007) == null)
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
					func2 = (SyncfusionControlExcel.<>c.\u0007 = new Func<IWorksheet, string>(SyncfusionControlExcel.<>c.\u001F.\u0018));
				}
				List<string>.Enumerator enumerator = \u0013\u0008\u0007.\u000A(Enumerable.ToList<string>(Enumerable.Select<IWorksheet, string>(enumerable2, func2)));
				try
				{
					while (\u0017\u0008\u0007.\u000A(ref enumerator))
					{
						string u000A = \u0014\u0008\u0007.\u000A(ref enumerator);
						\u000A\u000B\u0005.\u000A(\u0018\u0010\u0005.\u000A(this), u000A);
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
				\u001D\u001C\u0005.\u000A(workbook, false);
			}
			try
			{
				List<Workbook>.Enumerator enumerator2 = \u0018\u001C\u0005.\u000A(\u001D\u0010\u0005.\u000A(this));
				try
				{
					while (\u000A\u0003\u0005.\u000A(ref enumerator2))
					{
						Workbook workbook2 = \u0019\u001C\u0005.\u000A(ref enumerator2);
						if (workbook != null)
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
							if (workbook2 != null)
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
								int num = 0;
								List<Worksheet>.Enumerator enumerator3 = \u0009\u0003\u0005.\u000A(\u001E\u001D\u0018.\u000A(workbook2));
								try
								{
									while (\u0018\u0003\u0005.\u000A(ref enumerator3))
									{
										Worksheet worksheet2 = \u0001\u0003\u0005.\u000A(ref enumerator3);
										if (progressChanged != null)
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
											object[] array = \u0004\u0015\u0010.\u001F(1);
											array[0] = 1;
											\u0010\u001F\u0018.\u000A(progressChanged, array);
										}
										if (!\u0008\u0013\u000A.\u000A(\u0020\u001D\u0018.\u000A(worksheet2), "ParamValues"))
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
											List<MergeRange>.Enumerator enumerator5;
											if (\u001D\u0017\u000A.\u000A(\u0020\u001D\u0018.\u000A(worksheet2), "Instructions"))
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
												int num2 = \u000F\u0003\u0005.\u000A(\u0011\u0003\u0005.\u000A(worksheet2));
												int u = \u000B\u0003\u0005.\u000A(\u0011\u0003\u0005.\u000A(worksheet2));
												\u000C\u0002\u0018.\u000A(\u0018\u0010\u0005.\u000A(this), \u0020\u001D\u0018.\u000A(worksheet2), num);
												\u0004\u000B\u0005.\u000A(\u0018\u0010\u0005.\u000A(this), \u0020\u001D\u0018.\u000A(worksheet2));
												IWorksheet worksheet3 = \u0015\u0009\u0018.\u000A(\u0018\u0010\u0005.\u000A(this));
												object u001F = \u0014\u0002\u0018.\u000A(\u0013\u0002\u0018.\u0007(\u0018\u0010\u0005.\u000A(this)), \u0020\u001D\u0018.\u000A(worksheet2));
												IEnumerable<Range> enumerable3 = \u000D\u0004\u0018.\u000A(worksheet2);
												Func<Range, int> func3;
												if ((func3 = SyncfusionControlExcel.<>c.\u001D) == null)
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
													func3 = (SyncfusionControlExcel.<>c.\u001D = new Func<Range, int>(SyncfusionControlExcel.<>c.\u001F.\u0005));
												}
												\u0017\u0002\u0018.\u000A(u001F, Enumerable.Max<Range>(enumerable3, func3) + 5);
												object u001F2 = \u0014\u0002\u0018.\u000A(\u0013\u0002\u0018.\u0007(\u0018\u0010\u0005.\u000A(this)), \u0020\u001D\u0018.\u000A(worksheet2));
												IEnumerable<Range> enumerable4 = \u000D\u0004\u0018.\u000A(worksheet2);
												Func<Range, int> func4;
												if ((func4 = SyncfusionControlExcel.<>c.\u0004) == null)
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
													func4 = (SyncfusionControlExcel.<>c.\u0004 = new Func<Range, int>(SyncfusionControlExcel.<>c.\u001F.\u0016));
												}
												\u000D\u0010\u0005.\u000A(u001F2, Enumerable.Max<Range>(enumerable4, func4) + 5);
												List<int>.Enumerator enumerator4 = \u0009\u0013\u0004.\u000A(\u0011\u0011\u0018.\u000A(\u001C\u0010\u0005.\u000A(this), \u0020\u001D\u0018.\u000A(worksheet2)));
												try
												{
													while (\u0017\u0013\u0004.\u000A(ref enumerator4))
													{
														int num3 = \u0001\u0013\u0004.\u000A(ref enumerator4);
														\u0015\u001E\u0018.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(worksheet3), num2, num3, \u0002\u0003\u0005.\u000A(\u0011\u0003\u0005.\u000A(worksheet2)), num3), "@");
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
													((IDisposable)enumerator4).Dispose();
												}
												\u000B\u0010\u0005.\u000A(this, worksheet3, worksheet2, num2 - 1);
												if (\u0003\u0010\u0005.\u000A(this) == ExportTypes.Rooms)
												{
													goto IL_3EF;
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
												if (\u0003\u0010\u0005.\u000A(this) == ExportTypes.Spaces)
												{
													for (;;)
													{
														switch (4)
														{
														case 0:
															continue;
														}
														goto IL_3EF;
													}
												}
												IL_455:
												\u000B\u0009\u0018.\u000A(\u0002\u0009\u0018.\u0007(\u0018\u0010\u0005.\u000A(this)), false);
												\u0013\u001E\u0018.\u000A(\u001A\u001E\u0018.\u000A(worksheet3), \u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(worksheet3), num2, 1, \u000B\u0013\u001D.\u000A(\u0018\u001E\u001D.\u000A(worksheet3)), u));
												this.\u0005(worksheet3, \u0018\u0010\u0005.\u000A(this), 1, 2);
												\u0014\u001E\u0018.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(worksheet3), num2, 1, num2, u), true);
												\u0014\u001E\u0018.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(worksheet3), num2 - 1, 1, num2 - 1, u), true);
												\u000B\u000B\u0005.\u000A(\u0015\u0009\u0018.\u000A(\u0018\u0010\u0005.\u000A(this)), num2 - 1);
												\u0019\u000B\u0005.\u000A(\u0016\u000B\u0005.\u000A(\u0002\u0009\u0018.\u0007(\u0018\u0010\u0005.\u000A(this))), num2 - 1, num2 - 1, true);
												\u0002\u000B\u0005.\u000A(\u0002\u0009\u0018.\u0007(\u0018\u0010\u0005.\u000A(this)), num2, num2, 70.0);
												\u0012\u0010\u0005.\u000A(\u0002\u0009\u0018.\u0007(\u0018\u0010\u0005.\u000A(this)), num2 + 1);
												\u0005\u000B\u0005.\u000A(\u0015\u0009\u0018.\u000A(\u0018\u0010\u0005.\u000A(this)), 1);
												\u0019\u000B\u0005.\u000A(\u0018\u000B\u0005.\u000A(\u0002\u0009\u0018.\u0007(\u0018\u0010\u0005.\u000A(this))), 1, 1, true);
												\u000F\u0010\u0005.\u000A(this, worksheet3, worksheet2, num2 - 1);
												enumerator5 = \u0003\u0003\u0005.\u000A(\u0012\u0011\u0018.\u000A(worksheet2));
												try
												{
													while (\u0005\u0003\u0005.\u000A(ref enumerator5))
													{
														MergeRange u001F3 = \u0012\u0003\u0005.\u000A(ref enumerator5);
														IRange u001F4 = \u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(worksheet3), \u000F\u0003\u0005.\u000A(u001F3), \u0006\u0003\u0005.\u000A(u001F3), \u0002\u0003\u0005.\u000A(u001F3), \u000B\u0003\u0005.\u000A(u001F3));
														\u0015\u0001\u0019.\u000A(u001F4);
														\u0012\u000B\u0005.\u000A(u001F4, \u000E\u0003\u0005.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet3), \u000F\u0003\u0005.\u000A(u001F3), \u0006\u0003\u0005.\u000A(u001F3))));
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
													((IDisposable)enumerator5).Dispose();
												}
												if (!\u0006\u0010\u0005.\u000A(worksheet3))
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
													\u0002\u0010\u0005.\u000A(worksheet3, "diroots", ExcelSheetProtection.FormattingColumns | ExcelSheetProtection.FormattingRows | ExcelSheetProtection.LockedCells | ExcelSheetProtection.Sorting | ExcelSheetProtection.UnLockedCells);
												}
												num++;
												continue;
												IL_3EF:
												int num4 = \u0002\u0003\u0005.\u000A(\u0011\u0003\u0005.\u000A(worksheet2));
												int num5 = num4 + 1000;
												\u0017\u0002\u0018.\u000A(\u0014\u0002\u0018.\u000A(\u0013\u0002\u0018.\u0007(\u0018\u0010\u0005.\u000A(this)), \u0020\u001D\u0018.\u000A(worksheet2)), num5);
												\u001F\u0010\u0005.\u000A(\u001F\u0014\u001D.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(worksheet3), num4, 1, num5, u)), false);
												goto IL_455;
											}
											\u0004\u000B\u0005.\u000A(\u0018\u0010\u0005.\u000A(this), \u0020\u001D\u0018.\u000A(worksheet2));
											IWorksheet worksheet4 = \u0015\u0009\u0018.\u000A(\u0018\u0010\u0005.\u000A(this));
											\u001C\u0007\u0005.\u000A(\u0002\u0009\u0018.\u0007(\u0018\u0010\u0005.\u000A(this)), false);
											\u000D\u0007\u0005.\u000A(worksheet4, ExcelKnownColors.White);
											\u000B\u0010\u0005.\u000A(this, worksheet4, worksheet2, -1);
											enumerator5 = \u0003\u0003\u0005.\u000A(\u0012\u0011\u0018.\u000A(worksheet2));
											try
											{
												while (\u0005\u0003\u0005.\u000A(ref enumerator5))
												{
													MergeRange u001F5 = \u0012\u0003\u0005.\u000A(ref enumerator5);
													\u0015\u0001\u0019.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(worksheet4), \u000F\u0003\u0005.\u000A(u001F5), \u0006\u0003\u0005.\u000A(u001F5), \u0002\u0003\u0005.\u000A(u001F5), \u000B\u0003\u0005.\u000A(u001F5)));
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
												((IDisposable)enumerator5).Dispose();
											}
											this.\u0005(worksheet4, \u0018\u0010\u0005.\u000A(this), 1, 2);
											\u0015\u0003\u0005.\u000A(worksheet4, num);
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
									((IDisposable)enumerator3).Dispose();
								}
								\u0016\u0010\u0005.\u000A(this, workbook, workbook2);
								\u0005\u0010\u0005.\u000A(this, workbook);
								\u0004\u000B\u0005.\u000A(\u0018\u0010\u0005.\u000A(this), \u0020\u001D\u0018.\u000A(\u0005\u0004\u0018.\u000A(\u001E\u001D\u0018.\u000A(workbook2), 0)));
								\u000B\u0009\u0018.\u000A(\u0002\u0009\u0018.\u0007(\u0018\u0010\u0005.\u000A(this)), false);
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
			}
			catch (Exception u000A2)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Models\\Excels\\SyncfusionControlExcel.cs", "Export");
			}
		}

		// Token: 0x060016C5 RID: 5829 RVA: 0x00096078 File Offset: 0x00094278
		public void AddHeaderInfo(IWorksheet worksheet, Worksheet dWorksheet, int startIndex)
		{
			SyncfusionControlExcel.\u001B\u001C u001B_u001C = new SyncfusionControlExcel.\u001B\u001C();
			u001B_u001C.\u001F = startIndex;
			List<Range>.Enumerator enumerator = \u000F\u001C\u0005.\u000A(Enumerable.ToList<Range>(Enumerable.Where<Range>(\u000D\u0004\u0018.\u000A(dWorksheet), new Func<Range, bool>(u001B_u001C.\u000A))));
			try
			{
				while (\u0016\u001C\u0005.\u000A(ref enumerator))
				{
					Range u001F = \u0006\u001C\u0005.\u000A(ref enumerator);
					\u0001\u001E\u0018.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet), \u0002\u001C\u0005.\u000A(u001F), \u000B\u001C\u0005.\u000A(u001F)), \u001D\u0019\u0018.\u000A(u001F));
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SyncfusionControlExcel.AddHeaderInfo(IWorksheet, Worksheet, int)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060016C6 RID: 5830 RVA: 0x00096134 File Offset: 0x00094334
		public void EditWorkSheet(IWorksheet worksheet, Worksheet dWorksheet, int startIndex = -1)
		{
			List<int> u001F = \u0017\u000B\u001D.\u000A();
			if (\u0008\u0010\u0005.\u000A(\u001C\u0010\u0005.\u000A(this), \u0014\u0011\u001D.\u000A(worksheet)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SyncfusionControlExcel.EditWorkSheet(IWorksheet, Worksheet, int)).MethodHandle;
				}
				u001F = \u0011\u0011\u0018.\u000A(\u001C\u0010\u0005.\u000A(this), \u0014\u0011\u001D.\u000A(worksheet));
			}
			int num = \u0018\u0019\u0018.\u000A(\u000D\u0004\u0018.\u000A(dWorksheet));
			int i = 1;
			while (i <= num)
			{
				Range range = \u0004\u0019\u0018.\u000A(\u000D\u0004\u0018.\u000A(dWorksheet), i - 1);
				if (startIndex == -1)
				{
					goto IL_9C;
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
				if (\u0002\u001C\u0005.\u000A(range) != startIndex)
				{
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						goto IL_9C;
					}
				}
				IL_297:
				i++;
				continue;
				IL_9C:
				IRange range2 = \u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet), \u0002\u001C\u0005.\u000A(range), \u000B\u001C\u0005.\u000A(range));
				if (\u001A\u001C\u0005.\u000A(range))
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
					IRichTextString u001F2 = \u0014\u0015\u0004.\u000A(range2);
					\u0015\u000D\u0005.\u000A(u001F2);
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
							\u0008\u001C\u0005.\u000A(u001F2, \u001B\u001C\u0005.\u000A(u001F3), font);
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
					\u0013\u000D\u0005.\u000A(u001F2);
				}
				else
				{
					SyncfusionControlExcel.\u0018(u001F, range, range2);
				}
				if (!\u001A\u0006\u0007.\u000A(\u0010\u001C\u0005.\u000A(range)))
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
					\u0012\u000B\u0005.\u000A(range2, \u0010\u001C\u0005.\u000A(range));
					goto IL_297;
				}
				if (\u001C\u001C\u0005.\u000A(range) != null)
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
					\u001E\u0009\u0019.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(range2)), \u001E\u001C\u0005.\u000A(\u000C\u0020\u0018.\u000A(\u001C\u001C\u0005.\u000A(range))));
					\u0017\u0009\u0019.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(range2)), \u000D\u001C\u0005.\u000A(\u000C\u0020\u0018.\u000A(\u001C\u001C\u0005.\u000A(range))));
					\u001B\u0009\u0019.\u000A(\u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(range2)), \u000E\u0010\u0005.\u000A(\u000C\u0020\u0018.\u000A(\u001C\u001C\u0005.\u000A(range))));
					goto IL_297;
				}
				\u001F\u0010\u0005.\u000A(\u001F\u0014\u001D.\u000A(range2), false);
				goto IL_297;
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

		// Token: 0x060016C7 RID: 5831 RVA: 0x00096400 File Offset: 0x00094600
		private static void \u0018(List<int> \u001F, Range \u000A, IRange \u0007)
		{
			if (!\u0005\u001F\u0018.\u000A(\u001F, \u000B\u001C\u0005.\u000A(\u000A)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SyncfusionControlExcel.\u0018(List<int>, Range, IRange)).MethodHandle;
				}
				if (!\u0008\u0013\u000A.\u000A(\u0012\u001C\u0005.\u000A(\u000A), "@"))
				{
					\u0001\u001E\u0018.\u000A(\u0007, \u001D\u0019\u0018.\u000A(\u000A));
					return;
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
			\u0015\u001E\u0018.\u000A(\u0007, "@");
			object obj = \u001D\u0019\u0018.\u000A(\u000A);
			string u000A;
			if (obj == null)
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
				u000A = \u000F\u0015\u0010.\u001F;
			}
			else
			{
				u000A = \u001A\u000C\u000A.\u000A(obj);
			}
			\u0009\u001E\u0018.\u000A(\u0007, u000A);
		}

		// Token: 0x060016C8 RID: 5832 RVA: 0x00096498 File Offset: 0x00094698
		public void AddNamedRange(IWorkbook workbook, Workbook dWorkbook)
		{
			SyncfusionControlExcel.\u0011\u001C u0011_u001C = new SyncfusionControlExcel.\u0011\u001C();
			\u001B\u0010\u0005.\u000A(workbook, true);
			u0011_u001C.\u001F = "ParamValues";
			Worksheet worksheet = Enumerable.FirstOrDefault<Worksheet>(\u001E\u001D\u0018.\u000A(dWorkbook), new Func<Worksheet, bool>(u0011_u001C.\u000A));
			if (worksheet == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SyncfusionControlExcel.AddNamedRange(IWorkbook, Workbook)).MethodHandle;
				}
				return;
			}
			IWorksheet worksheet2 = Enumerable.FirstOrDefault<IWorksheet>(\u0003\u001E\u001D.\u000A(workbook), new Func<IWorksheet, bool>(u0011_u001C.\u0007));
			if (worksheet2 == null)
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
				\u000C\u0002\u0018.\u000A(\u0018\u0010\u0005.\u000A(this), u0011_u001C.\u001F, \u0017\u0011\u001D.\u000A(\u0003\u001E\u001D.\u000A(workbook)) - 1);
				\u001A\u0002\u0018.\u000A(\u0018\u0010\u0005.\u000A(this), u0011_u001C.\u001F);
				worksheet2 = \u0012\u001E\u001D.\u000A(\u0003\u001E\u001D.\u000A(workbook), \u0017\u0011\u001D.\u000A(\u0003\u001E\u001D.\u000A(workbook)) - 1);
			}
			if (Enumerable.Count<IRange>(\u0002\u0013\u001D.\u000A(worksheet2)) < \u0018\u0019\u0018.\u000A(\u000D\u0004\u0018.\u000A(worksheet)))
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
				\u0017\u0002\u0018.\u000A(\u0014\u0002\u0018.\u000A(\u0013\u0002\u0018.\u0007(\u0018\u0010\u0005.\u000A(this)), u0011_u001C.\u001F), \u0018\u0019\u0018.\u000A(\u000D\u0004\u0018.\u000A(worksheet)) + 5);
			}
			List<ExcelNamedRange>.Enumerator enumerator = \u001D\u000D\u0005.\u000A(\u000A\u0002\u0018.\u000A(dWorkbook));
			try
			{
				while (\u0001\u001C\u0005.\u000A(ref enumerator))
				{
					ExcelNamedRange u001F = \u0007\u000D\u0005.\u000A(ref enumerator);
					IName name = \u000C\u0006\u0004.\u000A(\u0007\u0020\u001D.\u000A(workbook), \u000A\u000D\u0005.\u000A(u001F));
					if (name == null)
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
						name = \u0020\u0002\u0018.\u000A(\u0007\u0020\u001D.\u000A(workbook), \u000A\u000D\u0005.\u000A(u001F));
					}
					\u001E\u0002\u0018.\u000A(name, \u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(worksheet2), \u000F\u0003\u0005.\u000A(\u001F\u000D\u0005.\u000A(u001F)), \u0006\u0003\u0005.\u000A(\u001F\u000D\u0005.\u000A(u001F)), \u0002\u0003\u0005.\u000A(\u001F\u000D\u0005.\u000A(u001F)), \u000B\u0003\u0005.\u000A(\u001F\u000D\u0005.\u000A(u001F))));
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
			\u000B\u0010\u0005.\u000A(this, worksheet2, worksheet, -1);
		}

		// Token: 0x060016C9 RID: 5833 RVA: 0x000966C8 File Offset: 0x000948C8
		public void AddValidations(IWorkbook workbook)
		{
			List<ParamValueInfo>.Enumerator enumerator = \u0001\u000B\u0018.\u000A(\u001E\u0010\u0005.\u000A(this));
			try
			{
				while (\u0014\u000B\u0018.\u000A(ref enumerator))
				{
					ParamValueInfo u001F = \u0015\u000B\u0018.\u000A(ref enumerator);
					IDataValidation u001F2 = \u0010\u0002\u0018.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(\u000A\u000F\u0004.\u000A(\u0003\u001E\u001D.\u000A(workbook), \u0011\u0010\u0005.\u000A(u001F))), \u0008\u0002\u0018.\u000A(u001F) + 1, \u000E\u0002\u0018.\u000A(u001F), \u001B\u0002\u0018.\u000A(u001F) + \u0008\u0002\u0018.\u000A(u001F), \u000E\u0002\u0018.\u000A(u001F)));
					\u000D\u0002\u0018.\u000A(u001F2, \u0019\u000D\u0005.\u000A(u001F));
					\u001C\u0002\u0018.\u000A(u001F2, ExcelDataType.User);
					\u0003\u0002\u0018.\u000A(u001F2, \u0004\u001E\u000A.\u000A("=", \u000A\u000D\u0005.\u000A(\u0004\u000D\u0005.\u000A(u001F))));
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SyncfusionControlExcel.AddValidations(IWorkbook)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060016CA RID: 5834 RVA: 0x000967C4 File Offset: 0x000949C4
		private void \u0005(IWorksheet \u001F, SfSpreadsheet \u000A, int \u0007, int \u001D = 2)
		{
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SyncfusionControlExcel.\u0005(IWorksheet, SfSpreadsheet, int, int)).MethodHandle;
				}
				\u000C\u001E\u0018.\u000A(\u0018\u001E\u001D.\u000A(\u001F));
				if (\u0007 < 2)
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
					if (\u000A != null)
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
						for (int i = \u001D; i <= Enumerable.Count<IRange>(\u000D\u000B\u0005.\u000A(\u001F)); i++)
						{
							int num = \u0005\u001A\u001D.\u000A(\u0015\u0009\u0018.\u000A(\u000A), i);
							\u000E\u000B\u0005.\u000A(\u0002\u0009\u0018.\u0007(\u000A), i, i, (double)num);
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
				}
			}
		}

		// Token: 0x04000900 RID: 2304
		[CompilerGenerated]
		private SfSpreadsheet \u001D;

		// Token: 0x04000901 RID: 2305
		[CompilerGenerated]
		private ExportTypes \u0004;

		// Token: 0x04000902 RID: 2306
		[CompilerGenerated]
		private Dictionary<string, List<int>> \u0019;

		// Token: 0x02000910 RID: 2320
		[CompilerGenerated]
		private sealed class \u001B\u001C
		{
			// Token: 0x0600518E RID: 20878 RVA: 0x001E8E6C File Offset: 0x001E706C
			internal bool \u000A(Range \u001F)
			{
				return \u0002\u001C\u0005.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x040023C7 RID: 9159
			public int \u001F;
		}

		// Token: 0x02000911 RID: 2321
		[CompilerGenerated]
		private sealed class \u0011\u001C
		{
			// Token: 0x06005190 RID: 20880 RVA: 0x001E8EA0 File Offset: 0x001E70A0
			internal bool \u000A(Worksheet \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0020\u001D\u0018.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x06005191 RID: 20881 RVA: 0x001E8EC4 File Offset: 0x001E70C4
			internal bool \u0007(IWorksheet \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0014\u0011\u001D.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x040023C8 RID: 9160
			public string \u001F;
		}
	}
}

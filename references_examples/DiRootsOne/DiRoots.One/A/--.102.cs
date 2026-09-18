using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using DiRoots.One.PanelLink;
using DiRoots.One.PanelLink.Models;

namespace A
{
	// Token: 0x02000196 RID: 406
	internal static class \u0013\u0002
	{
		// Token: 0x06000F01 RID: 3841 RVA: 0x0005F2C0 File Offset: 0x0005D4C0
		internal static PanelData \u001F(Document \u001F, Panel \u000A, List<ImageType> \u0007, Dictionary<long, Category> \u001D)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Models\\Excel\\ExcelCollector.cs", "GetPanelData");
			PanelData panelData = \u001B\u0017\u0019.\u000A();
			List<ExcelSheetInfo> list = \u0008\u0017\u0019.\u000A();
			int num = 0;
			List<PanelSectionPart>.Enumerator enumerator = \u0010\u0017\u0019.\u000A(\u000E\u0017\u0019.\u000A(\u000A));
			try
			{
				while (\u0005\u0020\u0019.\u000A(ref enumerator))
				{
					PanelSectionPart u001F = \u000D\u0017\u0019.\u000A(ref enumerator);
					ExcelSheetInfo excelSheetInfo = \u001C\u0017\u0019.\u000A();
					\u0003\u0017\u0019.\u000A(excelSheetInfo, \u000F\u0020\u0019.\u000A(u001F));
					\u0012\u0017\u0019.\u000A(excelSheetInfo, num + 1);
					List<ExcelCell> list2 = \u000F\u0017\u0019.\u000A();
					\u0002\u0017\u0019.\u000A(excelSheetInfo, \u0006\u0017\u0019.\u000A(u001F));
					SectionType sectionType = \u000B\u0017\u0019.\u000A(u001F);
					TableSectionData u001F2 = \u000A\u0020\u0019.\u000A(\u0015\u0020\u0019.\u000A(u001F), sectionType);
					for (int i = 1; i < \u0006\u0020\u0019.\u000A(u001F); i++)
					{
						double u000A = \u000A\u0019\u0004.\u000A(u001F2, i);
						for (int j = 1; j < \u000F\u0020\u0019.\u000A(u001F); j++)
						{
							try
							{
								ExcelCell excelCell = \u0016\u0017\u0019.\u000A();
								\u0005\u0017\u0019.\u000A(excelCell, i + num);
								\u0018\u0017\u0019.\u000A(excelCell, j);
								\u0019\u0017\u0019.\u000A(excelCell, \u001D\u0004\u0004.\u000A(u001F2, j));
								\u0004\u0017\u0019.\u000A(excelCell, u000A);
								bool flag = true;
								\u001D\u0017\u0019.\u000A(excelCell, \u0015\u0002.\u0005(u001F2, i, j, ref flag, num));
								if (\u0016\u0019\u0004.\u000A(u001F2, i, j) == 1)
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
										RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u0002.\u001F(Document, Panel, List<ImageType>, Dictionary<long, Category>)).MethodHandle;
									}
									\u0007\u0017\u0019.\u000A(excelCell, true);
									ImageInfo imageInfo = \u000A\u0017\u0019.\u000A();
									ImageType u001F3 = \u001F\u0017\u0019.\u000A(\u0007, 0);
									Transaction transaction = \u001D\u0014\u0007.\u000A(\u001F, "Get Image");
									try
									{
										\u0007\u0014\u0007.\u000A(transaction);
										for (int k = 0; k < \u0009\u0020\u0019.\u000A(\u0007); k++)
										{
											\u0011\u0001\u000A.\u000A(\u001F, \u0002\u001E\u000A.\u0007(\u001F\u0017\u0019.\u000A(\u0007, k)));
											if (\u0016\u0019\u0004.\u000A(u001F2, i, j) != 1)
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
												u001F3 = \u001F\u0017\u0019.\u000A(\u0007, k);
												IL_1CF:
												\u001F\u0014\u0007.\u000A(transaction);
												goto IL_1F1;
											}
										}
										for (;;)
										{
											switch (4)
											{
											case 0:
												continue;
											}
											goto IL_1CF;
										}
									}
									finally
									{
										if (transaction != null)
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
											\u001F\u0017\u000A.\u000A(transaction);
										}
									}
									IL_1F1:
									\u0001\u0020\u0019.\u000A(imageInfo, \u0017\u000D.\u0018\u000A(u001F3));
									u001F2 = \u000A\u0020\u0019.\u000A(\u0015\u0020\u0019.\u000A(u001F), sectionType);
									if (flag)
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
										\u0020\u0020\u0019.\u000A(imageInfo, 0.0);
										\u001E\u0020\u0019.\u000A(imageInfo, 0.0);
										for (int l = i; l < \u001A\u0020\u0019.\u000A(\u0014\u0020\u0019.\u000A(excelCell)) - num + 1; l++)
										{
											\u0020\u0020\u0019.\u000A(imageInfo, \u000C\u0020\u0019.\u000A(imageInfo) + \u000A\u0019\u0004.\u000A(u001F2, l));
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
										for (int m = j; m < \u0017\u0020\u0019.\u000A(\u0014\u0020\u0019.\u000A(excelCell)) + 1; m++)
										{
											\u001E\u0020\u0019.\u000A(imageInfo, \u0013\u0020\u0019.\u000A(imageInfo) + \u001D\u0004\u0004.\u000A(u001F2, m));
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
									else
									{
										\u0020\u0020\u0019.\u000A(imageInfo, \u000A\u0019\u0004.\u000A(u001F2, i));
										\u001E\u0020\u0019.\u000A(imageInfo, \u001D\u0004\u0004.\u000A(u001F2, j));
									}
									\u0011\u0020\u0019.\u000A(excelCell, imageInfo);
								}
								else
								{
									TableCellStyle tableCellStyle = \u001B\u0020\u0019.\u000A(u001F2, i, j);
									\u000E\u0020\u0019.\u000A(excelCell, \u0015\u0002.\u001F(sectionType, \u0008\u0020\u0019.\u000A(\u000A), i, j));
									\u0010\u0020\u0019.\u000A(excelCell, \u0015\u0002.\u000A(tableCellStyle));
									\u000D\u0020\u0019.\u000A(excelCell, \u0015\u0002.\u001D(tableCellStyle));
									\u001C\u0020\u0019.\u000A(excelCell, \u0015\u0002.\u0004(tableCellStyle));
									\u0003\u0020\u0019.\u000A(excelCell, \u0015\u0002.\u0019(\u001D, tableCellStyle));
								}
								\u0012\u0020\u0019.\u000A(list2, excelCell);
							}
							catch (Exception u000A2)
							{
								\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Models\\Excel\\ExcelCollector.cs", "GetPanelData");
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
					for (;;)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					num = num + \u0006\u0020\u0019.\u000A(u001F) - 1;
					\u0002\u0020\u0019.\u000A(excelSheetInfo, num + 1);
					\u000B\u0020\u0019.\u000A(excelSheetInfo, list2);
					\u0016\u0020\u0019.\u000A(list, excelSheetInfo);
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
			\u0018\u0020\u0019.\u000A(panelData, list);
			\u0019\u0020\u0019.\u000A(panelData, \u0016\u0011\u0019.\u000A(\u000A));
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Models\\Excel\\ExcelCollector.cs", "GetPanelData");
			return panelData;
		}
	}
}

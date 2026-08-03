using System;
using System.Collections.Generic;
using A;
using DiRoots.One.Commons.Models;
using Syncfusion.XlsIO;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x0200023C RID: 572
	public static class SyncfusionExcelStyles
	{
		// Token: 0x060016AF RID: 5807 RVA: 0x00094FF8 File Offset: 0x000931F8
		public static void CreateStyles(IWorkbook workbook)
		{
			\u0006\u000D\u0005.\u000A(workbook);
			\u0002\u000D\u0005.\u000A(workbook);
			\u000A\u0020\u0018.\u000A(workbook);
			\u000B\u000D\u0005.\u000A(workbook);
			\u0016\u000D\u0005.\u000A(workbook);
			\u0005\u000D\u0005.\u000A(workbook);
		}

		// Token: 0x060016B0 RID: 5808 RVA: 0x00095030 File Offset: 0x00093230
		public static void AddTitle(string title, IWorksheet worksheet, int columnCount)
		{
			IStyle u000A = \u0012\u000D\u0005.\u000A(\u0003\u000D\u0005.\u000A(\u000F\u0020\u001D.\u000A(worksheet)), "DiRootsFullNameTitleStyle");
			\u0013\u0009\u0019.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet), 1, 1), \u0004\u001E\u000A.\u000A("Name - ", title));
			\u0015\u0001\u0019.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(worksheet), 1, 1, 1, columnCount));
			\u000F\u000D\u0005.\u000A(\u0001\u0001\u0019.\u000A(\u0010\u0014\u001D.\u000A(worksheet), 1, 1, 1, columnCount), u000A);
		}

		// Token: 0x060016B1 RID: 5809 RVA: 0x000950B0 File Offset: 0x000932B0
		public static void CreateHeader(IWorksheet worksheet, List<string> headers)
		{
			for (int i = 1; i <= \u0015\u0007\u0019.\u000A(headers); i++)
			{
				\u0013\u0009\u0019.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet), 1, i), \u0001\u0013\u0007.\u000A(headers, i - 1));
				\u0012\u000B\u0005.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet), 1, i), "DiRootsHeaderStyle");
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(SyncfusionExcelStyles.CreateHeader(IWorksheet, List<string>)).MethodHandle;
			}
		}

		// Token: 0x060016B2 RID: 5810 RVA: 0x00095120 File Offset: 0x00093320
		public static void CreateHeader(List<RevitParameter> param, IWorksheet worksheet, int startRow)
		{
			IStyle u001F = \u0012\u000D\u0005.\u000A(\u0003\u000D\u0005.\u000A(\u000F\u0020\u001D.\u000A(worksheet)), "RichTextStyle1");
			IStyle u001F2 = \u0012\u000D\u0005.\u000A(\u0003\u000D\u0005.\u000A(\u000F\u0020\u001D.\u000A(worksheet)), "RichTextStyle2");
			for (int i = 1; i <= \u0008\u000D\u0018.\u000A(param); i++)
			{
				RevitParameter u001F3 = \u0004\u0008\u0018.\u000A(param, i - 1);
				IRichTextString u001F4 = \u0014\u0015\u0004.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet), startRow, i));
				IFont font = \u0009\u0017\u001D.\u000A(u001F);
				\u0010\u000D\u0005.\u000A(u001F4, \u001D\u001B\u0018.\u0007(u001F3));
				\u000D\u000D\u0005.\u000A(u001F4, 0, \u001C\u000F\u0007.\u0007(\u001D\u001B\u0018.\u0007(u001F3)), font);
				string text = \u001C\u000D\u0005.\u000A(u001F3);
				if (!\u001A\u0006\u0007.\u000A(text))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SyncfusionExcelStyles.CreateHeader(List<RevitParameter>, IWorksheet, int)).MethodHandle;
					}
					font = \u0009\u0017\u001D.\u000A(u001F2);
					\u0008\u001C\u0005.\u000A(u001F4, text, font);
				}
				\u0012\u000B\u0005.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet), startRow, i), "DiRootsHeaderStyle");
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

		// Token: 0x060016B3 RID: 5811 RVA: 0x00095238 File Offset: 0x00093438
		public static void CreateHeader(List<RevitParameter> param, int startRow, List<Range> ranges)
		{
			for (int i = 1; i <= \u0008\u000D\u0018.\u000A(param); i++)
			{
				RevitParameter u001F = \u0004\u0008\u0018.\u000A(param, i - 1);
				FontInfo fontInfo = \u0017\u000D\u0005.\u000A();
				\u0020\u000D\u0005.\u000A(fontInfo, \u000A\u0002\u0004.\u000A());
				\u0015\u0020\u0018.\u000A(fontInfo, true);
				\u001A\u0020\u0018.\u000A(fontInfo, 11f);
				FontInfo u000A = fontInfo;
				Style style = \u0001\u0020\u0018.\u000A();
				\u001E\u000D\u0005.\u000A(style, u000A);
				Style u000A2 = style;
				ExcelRichText excelRichText = \u0011\u000D\u0005.\u000A();
				\u001B\u000D\u0005.\u000A(excelRichText, \u001D\u001B\u0018.\u0007(u001F));
				\u0008\u000D\u0005.\u000A(excelRichText, u000A2);
				ExcelRichText u000A3 = excelRichText;
				Range range = \u0019\u0002\u0018.\u000A(true);
				\u000B\u0019\u0018.\u000A(range, \u001D\u001B\u0018.\u0007(u001F));
				\u0013\u0011\u0018.\u000A(range, "DiRootsHeaderStyle");
				\u0004\u0002\u0018.\u000A(range, startRow);
				\u001D\u0002\u0018.\u000A(range, i);
				Range range2 = range;
				\u0014\u000D\u0005.\u000A(range2, true);
				\u000E\u000D\u0005.\u000A(\u0013\u001C\u0005.\u000A(range2), u000A3);
				string text = \u001C\u000D\u0005.\u000A(u001F);
				if (!\u001A\u0006\u0007.\u000A(text))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SyncfusionExcelStyles.CreateHeader(List<RevitParameter>, int, List<Range>)).MethodHandle;
					}
					FontInfo fontInfo2 = \u0017\u000D\u0005.\u000A();
					\u0020\u000D\u0005.\u000A(fontInfo2, \u0012\u0014\u001D.\u000A());
					\u0015\u0020\u0018.\u000A(fontInfo2, true);
					\u001A\u0020\u0018.\u000A(fontInfo2, 10f);
					u000A = fontInfo2;
					Style style2 = \u0001\u0020\u0018.\u000A();
					\u001E\u000D\u0005.\u000A(style2, u000A);
					u000A2 = style2;
					ExcelRichText excelRichText2 = \u0011\u000D\u0005.\u000A();
					\u001B\u000D\u0005.\u000A(excelRichText2, text);
					\u0008\u000D\u0005.\u000A(excelRichText2, u000A2);
					u000A3 = excelRichText2;
					\u000E\u000D\u0005.\u000A(\u0013\u001C\u0005.\u000A(range2), u000A3);
				}
				\u0007\u0002\u0018.\u000A(ranges, range2);
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

		// Token: 0x060016B4 RID: 5812 RVA: 0x000953A0 File Offset: 0x000935A0
		public static void CreateHeaderWithoutID(List<RevitParameter> param, IWorksheet worksheet, int startRow)
		{
			for (int i = 1; i <= \u0008\u000D\u0018.\u000A(param); i++)
			{
				IRange u001F = \u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet), startRow, i);
				\u0013\u0009\u0019.\u000A(u001F, \u001D\u001B\u0018.\u0007(\u0004\u0008\u0018.\u000A(param, i - 1)));
				\u0012\u000B\u0005.\u000A(u001F, "DiRootsHeaderStyle");
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(SyncfusionExcelStyles.CreateHeaderWithoutID(List<RevitParameter>, IWorksheet, int)).MethodHandle;
			}
		}

		// Token: 0x060016B5 RID: 5813 RVA: 0x00095408 File Offset: 0x00093608
		public static void AddHeaderInfo(List<RevitParameter> param, IWorksheet worksheet, int startRow)
		{
			for (int i = 1; i <= \u0008\u000D\u0018.\u000A(param); i++)
			{
				RevitParameter u001F = \u0004\u0008\u0018.\u000A(param, i - 1);
				\u0009\u001E\u0018.\u000A(\u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(worksheet), startRow - 1, i), ParamExportInfo.\u0007(u001F, startRow));
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(SyncfusionExcelStyles.AddHeaderInfo(List<RevitParameter>, IWorksheet, int)).MethodHandle;
			}
			\u000B\u000B\u0005.\u000A(worksheet, startRow - 1);
		}

		// Token: 0x060016B6 RID: 5814 RVA: 0x00095474 File Offset: 0x00093674
		public static void AddHeaderInfo(List<RevitParameter> param, int startRow, List<Range> ranges)
		{
			for (int i = 1; i <= \u0008\u000D\u0018.\u000A(param); i++)
			{
				string u000A = ParamExportInfo.\u0007(\u0004\u0008\u0018.\u000A(param, i - 1), startRow);
				Range range = \u0019\u0002\u0018.\u000A(true);
				\u000B\u0019\u0018.\u000A(range, u000A);
				\u0004\u0002\u0018.\u000A(range, startRow - 1);
				\u001D\u0002\u0018.\u000A(range, i);
				\u0007\u0002\u0018.\u000A(ranges, range);
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(SyncfusionExcelStyles.AddHeaderInfo(List<RevitParameter>, int, List<Range>)).MethodHandle;
			}
		}

		// Token: 0x060016B7 RID: 5815 RVA: 0x000954E0 File Offset: 0x000936E0
		public static IStyle CreateTitleStyle(IWorkbook workbook)
		{
			IStyle style = \u0001\u000D\u0005.\u000A(workbook, "DiRootsFullNameTitleStyle");
			\u0015\u000D\u0005.\u000A(style);
			\u0002\u0009\u0019.\u000A(style, \u000C\u000D\u0005.\u000A());
			\u001E\u0009\u0019.\u000A(\u0009\u0017\u001D.\u000A(style), \u001A\u000D\u0005.\u000A());
			\u0017\u0009\u0019.\u000A(\u0009\u0017\u001D.\u000A(style), true);
			\u001E\u001F\u0018.\u000A(\u000A\u0013\u001D.\u000A(\u001D\u0009\u0019.\u000A(style), ExcelBordersIndex.EdgeLeft), ExcelLineStyle.Thin);
			\u001E\u001F\u0018.\u000A(\u000A\u0013\u001D.\u000A(\u001D\u0009\u0019.\u000A(style), ExcelBordersIndex.EdgeRight), ExcelLineStyle.Thin);
			\u001E\u001F\u0018.\u000A(\u000A\u0013\u001D.\u000A(\u001D\u0009\u0019.\u000A(style), ExcelBordersIndex.EdgeTop), ExcelLineStyle.Thin);
			\u001E\u001F\u0018.\u000A(\u000A\u0013\u001D.\u000A(\u001D\u0009\u0019.\u000A(style), ExcelBordersIndex.EdgeBottom), ExcelLineStyle.Thin);
			\u0013\u000D\u0005.\u000A(style);
			return style;
		}

		// Token: 0x060016B8 RID: 5816 RVA: 0x00095590 File Offset: 0x00093790
		public static IStyle CreateHeaderStyle(IWorkbook workbook)
		{
			IStyle result = \u0009\u000D\u0005.\u000A(workbook);
			\u0017\u0009\u0019.\u000A(\u0009\u0017\u001D.\u000A(\u0001\u000D\u0005.\u000A(workbook, "RichTextStyle1")), true);
			IStyle u001F = \u0001\u000D\u0005.\u000A(workbook, "RichTextStyle2");
			\u001C\u0009\u0018.\u000A(\u0009\u0017\u001D.\u000A(u001F), ExcelKnownColors.White);
			\u0017\u0009\u0019.\u000A(\u0009\u0017\u001D.\u000A(u001F), true);
			\u0003\u0009\u0019.\u000A(\u0009\u0017\u001D.\u000A(u001F), 10.0);
			return result;
		}

		// Token: 0x060016B9 RID: 5817 RVA: 0x00095600 File Offset: 0x00093800
		public static void CreateCustomStyle(IWorkbook workbook)
		{
			IStyle u001F = \u0001\u000D\u0005.\u000A(workbook, "DiRootsCustomParamStyle");
			\u0015\u000D\u0005.\u000A(u001F);
			\u0002\u0009\u0019.\u000A(u001F, \u000A\u0010\u0005.\u000A());
			\u001F\u0010\u0005.\u000A(u001F, true);
			\u0013\u000D\u0005.\u000A(u001F);
		}

		// Token: 0x060016BA RID: 5818 RVA: 0x0009563C File Offset: 0x0009383C
		public static void CreateParameterNotFoundStyle(IWorkbook workbook)
		{
			IStyle u001F = \u0001\u000D\u0005.\u000A(workbook, "DiRootsParameterNotFound");
			\u0015\u000D\u0005.\u000A(u001F);
			\u0002\u0009\u0019.\u000A(u001F, \u0010\u0007\u0005.\u000A());
			\u001F\u0010\u0005.\u000A(u001F, true);
			\u0013\u000D\u0005.\u000A(u001F);
		}

		// Token: 0x060016BB RID: 5819 RVA: 0x00095678 File Offset: 0x00093878
		public static void CreateTypeStyle(IWorkbook workbook)
		{
			IStyle u001F = \u0001\u000D\u0005.\u000A(workbook, "DiRootsTypeStyle");
			\u0015\u000D\u0005.\u000A(u001F);
			\u0002\u0009\u0019.\u000A(u001F, \u0008\u0007\u0005.\u000A());
			\u001F\u0010\u0005.\u000A(u001F, false);
			\u0013\u000D\u0005.\u000A(u001F);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using ProSheets.Models;

namespace A
{
	// Token: 0x020000A4 RID: 164
	internal class \u000A\u0020\u0018
	{
		// Token: 0x06000992 RID: 2450 RVA: 0x0003ACF0 File Offset: 0x00038EF0
		public \u000A\u0020\u0018()
		{
			List<PaperSizeInfo> list = new List<PaperSizeInfo>();
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(0, \u001C\u0009\u0018.\u001C\u0016, "Default", ""));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(1, "ANSI A : 8.5 X 11 in", "ANSI A", "216x279"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(2, "ANSI B : 11 X 17 in", "ANSI B", "279x432"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(3, "ANSI C : 17 X 22 in", "ANSI C", "432x559"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(4, "ANSI D : 22 X 34 in", "ANSI D", "559x864"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(5, "ANSI E : 34 X 44 in", "ANSI E", "864x1118"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(6, "ISO A4 : 210 X 297 mm", "A4", "210x297"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(7, "ISO A3 : 297 X 420 mm", "A3", "297x420"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(8, "ISO A2 : 420 X 594 mm", "A2", "420x594"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(9, "ISO A1 : 594 X 841 mm", "A1", "594x841"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(10, "ISO A0 : 841 X 1189 mm", "A0", "841x1189"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(11, "ISO B4 : 250 X 353 mm", "B4", "250x353"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(12, "ISO B3 : 353 X 500 mm", "B3", "353x500"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(13, "ISO B2 : 500 X 707 mm", "B2", "500x707"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(14, "ISO B1 : 707 X 1000 mm", "B1", "707x1000"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(15, "ARCH A : 9 X 12 in", "ARCH A", "229x305"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(16, "ARCH B : 12 X 18 in", "ARCH B", "305x457"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(17, "ARCH C : 18 X 24 in", "ARCH C", "457x610"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(18, "ARCH D : 24 X 36 in", "ARCH D", "610x914"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(19, "ARCH E : 36 X 48 in", "ARCH E", "914x1219"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(20, "ARCH E1 : 30 X 42 in", "ARCH E1", "762x1067"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(21, "ARCH E2 : 26 X 38 in", "ARCH E2", "660x965"));
			\u0009\u000E\u0003.\u0018(list, new PaperSizeInfo(22, "ARCH E3 : 27 X 39 in", "ARCH E3", "686x991"));
			this.PaperSizeMap = list;
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06000993 RID: 2451 RVA: 0x0003AF8C File Offset: 0x0003918C
		public List<PaperSizeInfo> PaperSizeMap { get; }

		// Token: 0x06000994 RID: 2452 RVA: 0x0003AFA0 File Offset: 0x000391A0
		public PDFExportOptions \u0018(string \u000C, string \u0018, string \u0014, bool \u0003)
		{
			PageOrientationType u = 2;
			if (\u000F\u0002\u0018.\u0018(\u0014, \u001C\u0009\u0018.\u0009\u0016))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0020\u0018.\u0018(string, string, string, bool)).MethodHandle;
				}
				u = 1;
			}
			else if (\u000F\u0002\u0018.\u0018(\u0014, \u001C\u0009\u0018.\u000A\u0016))
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
				u = 0;
			}
			PDFExportOptions pdfexportOptions = \u0005\u000E\u0003.\u0018();
			\u001B\u000E\u0003.\u0018(pdfexportOptions, true);
			\u0001\u000E\u0003.\u0018(pdfexportOptions, \u0004\u0006\u0014.\u0018(\u000C));
			\u0008\u000E\u0003.\u0018(pdfexportOptions, this.\u0003(\u0018));
			\u0006\u000E\u0003.\u0018(pdfexportOptions, \u0015\u0006\u0014.\u0018());
			double u2;
			if (\u0020\u0006\u0014.\u0018() != 2)
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
				u2 = 0.0;
			}
			else
			{
				u2 = \u000A\u0006\u0014.\u0018() / 304.8;
			}
			\u0010\u000E\u0003.\u0018(pdfexportOptions, u2);
			double u3;
			if (\u0020\u0006\u0014.\u0018() != 2)
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
				u3 = 0.0;
			}
			else
			{
				u3 = \u0013\u0006\u0014.\u0018() / 304.8;
			}
			\u0007\u000E\u0003.\u0018(pdfexportOptions, u3);
			\u0019\u000E\u0003.\u0018(pdfexportOptions, \u0012\u0006\u0014.\u0018());
			int u4;
			if (\u0012\u0006\u0014.\u0018() != 1)
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
				u4 = 100;
			}
			else
			{
				u4 = \u000F\u0006\u0014.\u0018();
			}
			\u000B\u000E\u0003.\u0018(pdfexportOptions, u4);
			\u001A\u000E\u0003.\u0018(pdfexportOptions, u);
			\u001D\u000E\u0003.\u0018(pdfexportOptions, \u0014\u0006\u0014.\u0018() == 1);
			\u0004\u000E\u0003.\u0018(pdfexportOptions, \u000C\u0006\u0014.\u0018());
			\u0002\u000E\u0003.\u0018(pdfexportOptions, \u0003\u0010\u0014.\u0018());
			\u001E\u000E\u0003.\u0018(pdfexportOptions, \u001B\u0010\u0014.\u0018());
			\u0017\u000E\u0003.\u0018(pdfexportOptions, \u0008\u0010\u0014.\u0018());
			\u0015\u000E\u0003.\u0018(pdfexportOptions, \u0010\u0010\u0014.\u0018());
			\u0011\u000E\u0003.\u0018(pdfexportOptions, \u0019\u0010\u0014.\u0018());
			\u001F\u000E\u0003.\u0018(pdfexportOptions, \u001A\u0010\u0014.\u0018());
			\u0020\u000E\u0003.\u0018(pdfexportOptions, \u0004\u0010\u0014.\u0018());
			\u000A\u000E\u0003.\u0018(pdfexportOptions, \u0010\u0007\u0014.\u0018());
			return pdfexportOptions;
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0003B158 File Offset: 0x00039358
		public static List<ExportPDFSettings> \u0014(Document \u000C)
		{
			return Enumerable.ToList<ExportPDFSettings>(Enumerable.Cast<ExportPDFSettings>(\u0010\u001D\u0014.\u0003(\u0020\u001D\u0018.\u0018(\u000C), \u000A\u001D\u0018.\u0018(\u0007\u0007\u000F.\u000C()))));
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0003B190 File Offset: 0x00039390
		private ExportPaperFormat \u0003(string \u000C)
		{
			\u000A\u0020\u0018.\u0009\u0020\u0018 u0009_u0020_u = new \u000A\u0020\u0018.\u0009\u0020\u0018();
			u0009_u0020_u.\u000C = \u000C;
			PaperSizeInfo paperSizeInfo = Enumerable.FirstOrDefault<PaperSizeInfo>(\u0015\u001C\u0003.\u0018(this), new Func<PaperSizeInfo, bool>(u0009_u0020_u.\u0018));
			if (paperSizeInfo != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0020\u0018.\u0003(string)).MethodHandle;
				}
				if (\u000A\u001C\u0003.\u0003(paperSizeInfo) != null)
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
					return \u000E\u000E\u0003.\u0018(paperSizeInfo);
				}
			}
			return 0;
		}

		// Token: 0x0400047E RID: 1150
		[CompilerGenerated]
		private readonly List<PaperSizeInfo> \u000C;

		// Token: 0x020001B7 RID: 439
		[CompilerGenerated]
		private sealed class \u0009\u0020\u0018
		{
			// Token: 0x060011A0 RID: 4512 RVA: 0x0005D010 File Offset: 0x0005B210
			internal bool \u0018(PaperSizeInfo \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u000A\u001C\u0003.\u0014(\u000C), this.\u000C);
			}

			// Token: 0x0400084F RID: 2127
			public string \u000C;
		}
	}
}

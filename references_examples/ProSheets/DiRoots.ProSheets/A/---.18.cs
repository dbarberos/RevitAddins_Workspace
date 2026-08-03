using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.IFC;
using Autodesk.Revit.UI;
using BIM.IFC.Export.UI;
using DiRoots.One.Commons.Interfaces;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using ProSheets;
using ProSheets.Helpers;
using ProSheets.Models;
using ProSheets.UI;

namespace A
{
	// Token: 0x02000067 RID: 103
	internal class \u000F\u000A\u0018
	{
		// Token: 0x17000239 RID: 569
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x0001D7CC File Offset: 0x0001B9CC
		// (set) Token: 0x0600055C RID: 1372 RVA: 0x0001D7E0 File Offset: 0x0001B9E0
		public static string PrimaryPrinter { get; set; } = "diroots.prosheets";

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x0001D7F4 File Offset: 0x0001B9F4
		// (set) Token: 0x0600055E RID: 1374 RVA: 0x0001D808 File Offset: 0x0001BA08
		public static bool IsFileSaved { get; set; }

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x0600055F RID: 1375 RVA: 0x0001D81C File Offset: 0x0001BA1C
		// (set) Token: 0x06000560 RID: 1376 RVA: 0x0001D830 File Offset: 0x0001BA30
		public static int count { get; set; }

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000561 RID: 1377 RVA: 0x0001D844 File Offset: 0x0001BA44
		// (set) Token: 0x06000562 RID: 1378 RVA: 0x0001D858 File Offset: 0x0001BA58
		public static string PrinterName { get; set; }

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000563 RID: 1379 RVA: 0x0001D86C File Offset: 0x0001BA6C
		// (set) Token: 0x06000564 RID: 1380 RVA: 0x0001D880 File Offset: 0x0001BA80
		public static PaperPlacementType PaperPlacementType { get; set; }

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000565 RID: 1381 RVA: 0x0001D894 File Offset: 0x0001BA94
		// (set) Token: 0x06000566 RID: 1382 RVA: 0x0001D8A8 File Offset: 0x0001BAA8
		public static MarginType MarginType { get; set; }

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000567 RID: 1383 RVA: 0x0001D8BC File Offset: 0x0001BABC
		// (set) Token: 0x06000568 RID: 1384 RVA: 0x0001D8D0 File Offset: 0x0001BAD0
		public static double XValue { get; set; }

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000569 RID: 1385 RVA: 0x0001D8E4 File Offset: 0x0001BAE4
		// (set) Token: 0x0600056A RID: 1386 RVA: 0x0001D8F8 File Offset: 0x0001BAF8
		public static double YValue { get; set; }

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x0600056B RID: 1387 RVA: 0x0001D90C File Offset: 0x0001BB0C
		// (set) Token: 0x0600056C RID: 1388 RVA: 0x0001D920 File Offset: 0x0001BB20
		public static ZoomType ZoomType { get; set; }

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x0600056D RID: 1389 RVA: 0x0001D934 File Offset: 0x0001BB34
		// (set) Token: 0x0600056E RID: 1390 RVA: 0x0001D948 File Offset: 0x0001BB48
		public static int ZoomSize { get; set; }

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x0600056F RID: 1391 RVA: 0x0001D95C File Offset: 0x0001BB5C
		// (set) Token: 0x06000570 RID: 1392 RVA: 0x0001D970 File Offset: 0x0001BB70
		public static HiddenLineViewsType HiddenLineViewsType { get; set; }

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x0001D984 File Offset: 0x0001BB84
		// (set) Token: 0x06000572 RID: 1394 RVA: 0x0001D998 File Offset: 0x0001BB98
		public static RasterQualityType RasterQualityType { get; set; }

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x0001D9AC File Offset: 0x0001BBAC
		// (set) Token: 0x06000574 RID: 1396 RVA: 0x0001D9C0 File Offset: 0x0001BBC0
		public static ColorDepthType ColorDepthType { get; set; }

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x0001D9D4 File Offset: 0x0001BBD4
		// (set) Token: 0x06000576 RID: 1398 RVA: 0x0001D9E8 File Offset: 0x0001BBE8
		public static bool ViewLinksinBlue { get; set; }

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000577 RID: 1399 RVA: 0x0001D9FC File Offset: 0x0001BBFC
		// (set) Token: 0x06000578 RID: 1400 RVA: 0x0001DA10 File Offset: 0x0001BC10
		public static bool JumpToSection { get; set; }

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x0001DA24 File Offset: 0x0001BC24
		// (set) Token: 0x0600057A RID: 1402 RVA: 0x0001DA38 File Offset: 0x0001BC38
		public static bool KeepPageSizeAndOrientation { get; set; }

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x0001DA4C File Offset: 0x0001BC4C
		// (set) Token: 0x0600057C RID: 1404 RVA: 0x0001DA60 File Offset: 0x0001BC60
		public static string JumpToSectionFileName { get; set; }

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x0001DA74 File Offset: 0x0001BC74
		// (set) Token: 0x0600057E RID: 1406 RVA: 0x0001DA88 File Offset: 0x0001BC88
		public static string JumpToSectionFilePath { get; set; }

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x0001DA9C File Offset: 0x0001BC9C
		// (set) Token: 0x06000580 RID: 1408 RVA: 0x0001DAB0 File Offset: 0x0001BCB0
		public static bool HideReforWorkPlanes { get; set; }

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000581 RID: 1409 RVA: 0x0001DAC4 File Offset: 0x0001BCC4
		// (set) Token: 0x06000582 RID: 1410 RVA: 0x0001DAD8 File Offset: 0x0001BCD8
		public static bool HideUnreferencedViewTags { get; set; }

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000583 RID: 1411 RVA: 0x0001DAEC File Offset: 0x0001BCEC
		// (set) Token: 0x06000584 RID: 1412 RVA: 0x0001DB00 File Offset: 0x0001BD00
		public static bool HideScopeBoxes { get; set; }

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000585 RID: 1413 RVA: 0x0001DB14 File Offset: 0x0001BD14
		// (set) Token: 0x06000586 RID: 1414 RVA: 0x0001DB28 File Offset: 0x0001BD28
		public static bool HideCropBoundaries { get; set; }

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000587 RID: 1415 RVA: 0x0001DB3C File Offset: 0x0001BD3C
		// (set) Token: 0x06000588 RID: 1416 RVA: 0x0001DB50 File Offset: 0x0001BD50
		public static bool ReplaceHalftoneWithThinLines { get; set; }

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x0001DB64 File Offset: 0x0001BD64
		// (set) Token: 0x0600058A RID: 1418 RVA: 0x0001DB78 File Offset: 0x0001BD78
		public static bool MaskCoincidentLines { get; set; }

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x0001DB8C File Offset: 0x0001BD8C
		// (set) Token: 0x0600058C RID: 1420 RVA: 0x0001DBA0 File Offset: 0x0001BDA0
		public static bool CombineFlag { get; set; }

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x0600058D RID: 1421 RVA: 0x0001DBB4 File Offset: 0x0001BDB4
		// (set) Token: 0x0600058E RID: 1422 RVA: 0x0001DBC8 File Offset: 0x0001BDC8
		public static string CombineFilename { get; set; }

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x0001DBDC File Offset: 0x0001BDDC
		// (set) Token: 0x06000590 RID: 1424 RVA: 0x0001DBF0 File Offset: 0x0001BDF0
		public static string SaveFilePath { get; set; }

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000591 RID: 1425 RVA: 0x0001DC04 File Offset: 0x0001BE04
		// (set) Token: 0x06000592 RID: 1426 RVA: 0x0001DC18 File Offset: 0x0001BE18
		public static string OriginalFilePath { get; set; }

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x0001DC2C File Offset: 0x0001BE2C
		// (set) Token: 0x06000594 RID: 1428 RVA: 0x0001DC40 File Offset: 0x0001BE40
		public static List<SheetInfo> SelectedRowsInput { get; set; }

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000595 RID: 1429 RVA: 0x0001DC54 File Offset: 0x0001BE54
		// (set) Token: 0x06000596 RID: 1430 RVA: 0x0001DC68 File Offset: 0x0001BE68
		public static bool SplitFlag { get; set; }

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000597 RID: 1431 RVA: 0x0001DC7C File Offset: 0x0001BE7C
		// (set) Token: 0x06000598 RID: 1432 RVA: 0x0001DC90 File Offset: 0x0001BE90
		public static bool IsErrorOccurred { get; set; }

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000599 RID: 1433 RVA: 0x0001DCA4 File Offset: 0x0001BEA4
		// (set) Token: 0x0600059A RID: 1434 RVA: 0x0001DCB8 File Offset: 0x0001BEB8
		public static string SelectedPrinterType { get; set; }

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x0600059B RID: 1435 RVA: 0x0001DCCC File Offset: 0x0001BECC
		// (set) Token: 0x0600059C RID: 1436 RVA: 0x0001DCE0 File Offset: 0x0001BEE0
		public static string ReportSaveType { get; set; } = \u001C\u0009\u0018.\u0001\u0014;

		// Token: 0x0600059D RID: 1437 RVA: 0x0001DCF4 File Offset: 0x0001BEF4
		public static bool \u0003\u0018()
		{
			return \u000F\u0002\u0018.\u0018(\u0001\u0017\u0014.\u0018(), "Revit Native");
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0001DD14 File Offset: 0x0001BF14
		public static List<\u000C> \u0016\u0018<\u000C>(Document \u000C)
		{
			return Enumerable.ToList<\u000C>(Enumerable.Cast<\u000C>(\u0010\u001D\u0014.\u0003(\u0020\u001D\u0018.\u0018(\u000C), \u000A\u001D\u0018.\u0018(typeof(\u000C).TypeHandle))));
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0001DD4C File Offset: 0x0001BF4C
		public void \u000F\u0018(Document \u000C)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "StartTransaction");
			try
			{
				this.\u000C = \u001C\u0007\u0014.\u0018(\u000C);
				\u000D\u0007\u0014.\u0018(this.\u000C, "New");
				FailureHandlingOptions failureHandlingOptions = \u0012\u0007\u0014.\u0018(this.\u000C);
				\u000F\u0007\u0014.\u0018(failureHandlingOptions, new \u0006\u001F\u0018());
				\u0016\u0007\u0014.\u0018(this.\u000C, failureHandlingOptions);
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "StartTransaction");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "StartTransaction");
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "StartTransaction");
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x0001DE10 File Offset: 0x0001C010
		public void \u0012\u0018(Document \u000C)
		{
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "EndTransaction");
				\u000A\u0007\u0014.\u0018(\u000C);
				\u0009\u0007\u0014.\u0018(this.\u000C);
				\u0013\u0007\u0014.\u0018(this.\u000C);
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "EndTransaction");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "EndTransaction");
			}
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x0001DE94 File Offset: 0x0001C094
		public bool \u000D\u0018(Document \u000C, View \u0018, string \u0014, string \u0003, string \u0016, string \u000F, SheetInfo \u0012)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparatePdf");
			bool result = false;
			TransactionGroup transactionGroup = \u0011\u0007\u0014.\u0018(\u000C);
			try
			{
				\u001F\u0007\u0014.\u0018(transactionGroup, "Export To Separate Pdf/PNR");
				result = this.\u0009\u0018(\u000C, \u0018, \u0014, \u0003, \u0016, \u000F, \u0012);
				\u0020\u0007\u0014.\u0018(transactionGroup);
			}
			finally
			{
				if (transactionGroup != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u000D\u0018(Document, View, string, string, string, string, SheetInfo)).MethodHandle;
					}
					\u0020\u001E\u0018.\u0018(transactionGroup);
				}
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparatePdf");
			return result;
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x0001DF34 File Offset: 0x0001C134
		public bool \u001C\u0018(Document \u000C, View \u0018, string \u0014, string \u0003, string \u0016, SheetInfo \u000F)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWF");
			bool result = false;
			TransactionGroup transactionGroup = \u0011\u0007\u0014.\u0018(\u000C);
			try
			{
				\u001F\u0007\u0014.\u0018(transactionGroup, "Export To Separate DWF");
				result = this.\u0020\u0018(\u000C, \u0018, \u0014, \u0003, \u0016, \u000F);
				\u0020\u0007\u0014.\u0018(transactionGroup);
			}
			finally
			{
				if (transactionGroup != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u001C\u0018(Document, View, string, string, string, SheetInfo)).MethodHandle;
					}
					\u0020\u001E\u0018.\u0018(transactionGroup);
				}
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWF");
			return result;
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x0001DFD0 File Offset: 0x0001C1D0
		public static string \u0013\u0018()
		{
			string text = \u0003\u001A\u0018.\u0018(\u000A\u0006\u0018.\u0018(Environment.SpecialFolder.LocalApplicationData), "DiRoots\\ProSheets\\Temp\\PDF");
			if (!\u0012\u0006\u0018.\u0018(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0013\u0018()).MethodHandle;
				}
				\u000F\u0006\u0018.\u0018(text);
			}
			return text;
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x0001E01C File Offset: 0x0001C21C
		public bool \u0009\u0018(Document \u000C, View \u0018, string \u0014, string \u0003, string \u0016, string \u000F, SheetInfo \u0012)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparatePdfV1");
			if (\u0016\u0017\u0014.\u0018())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0009\u0018(Document, View, string, string, string, string, SheetInfo)).MethodHandle;
				}
				return false;
			}
			bool flag = false;
			bool flag2 = false;
			bool result;
			try
			{
				string u = string.Empty;
				\u001E\u0010\u0014.\u0018(\u000F\u0010\u0014.\u0018() + 1);
				ViewSet viewSet = \u0006\u0003\u0014.\u0018();
				\u001F\u0017\u0014.\u0018(\u000D\u0015\u0014.\u0018(), \u000F\u000A\u0018.\u0014\u0014(\u000C, \u0018));
				PrintManager printManager = \u0005\u0003\u0014.\u0018(\u000C);
				ElementId u2 = \u0009\u0002\u0018.\u0018(\u0018);
				View view = \u0018\u0002\u000F.\u000C(\u0003\u0004\u0018.\u0018(\u000C, u2));
				if (view != null)
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
					\u000B\u0003\u0014.\u0018(viewSet, view);
				}
				this.\u0018 = true;
				string u000C = \u000F\u000A\u0018.\u0013\u0018();
				string u3 = \u001D\u001B\u0018.\u0018().ToString();
				string u4 = \u0019\u000C\u0014.\u0018(u000C, "\\", u3, ".pdf");
				View u5 = \u0017\u0010\u0014.\u0018(\u0011\u0005\u0018.\u0018());
				\u001F\u0005\u0018.\u0018(\u0011\u0005\u0018.\u0018(), u5);
				this.\u000F\u0018(\u000C);
				try
				{
					\u000F\u000A\u0018.\u0018\u000A\u0018 u0018_u000A_u = new \u000F\u000A\u0018.\u0018\u000A\u0018();
					u = \u001F\u0010\u0014.\u0018(\u0012, \u0018, \u0015\u0010\u0014.\u0018(), "PDF", \u0003, \u0014, \u0011\u0010\u0014.\u0018());
					if (!\u001F\u001A\u0018.\u0018(\u0014\u0017\u0014.\u0018(\u0012)))
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
						if (this.\u0018)
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
							this.\u0012\u0018(\u000C);
							this.\u0018 = false;
						}
						return false;
					}
					\u0020\u0010\u0014.\u0018(printManager, true);
					\u0019\u0007\u0014.\u0018(printManager);
					\u0004\u0003\u0014.\u0018(printManager, 2);
					ViewSheetSetting u000C2 = \u0002\u0003\u0014.\u0018(printManager);
					\u0011\u0003\u0014.\u0018(\u0015\u0003\u0014.\u0018(u000C2), viewSet);
					string u000C3 = \u000A\u0010\u0014.\u0018(\u0012);
					int num = \u000F\u0010\u0014.\u0018();
					\u0009\u0010\u0014.\u0018(u000C2, \u000D\u001E\u0018.\u0018(u000C3, \u0010\u001E\u0018.\u0018(ref num)));
					\u0019\u0007\u0014.\u0018(printManager);
					\u001C\u0010\u0014.\u0018(printManager, \u0013\u0010\u0014.\u0018());
					\u0019\u0007\u0014.\u0018(printManager);
					\u000D\u0010\u0014.\u0018(printManager, u4);
					\u0019\u0007\u0014.\u0018(printManager);
					\u0012\u0010\u0014.\u0018(printManager, true);
					\u0019\u0007\u0014.\u0018(printManager);
					\u000F\u000A\u0018.\u0018\u000A\u0018 u0018_u000A_u2 = u0018_u000A_u;
					num = \u000F\u0010\u0014.\u0018();
					u0018_u000A_u2.\u000C = \u000D\u001E\u0018.\u0018(\u0003, \u0010\u001E\u0018.\u0018(ref num));
					\u0018\u0010\u0014.\u0018(\u000B\u0007\u0014.\u0018(printManager), \u0016\u0010\u0014.\u0018(\u000B\u0007\u0014.\u0018(printManager)));
					\u0003\u0011\u0018.\u000C(printManager, \u0003\u0010\u0014.\u0018());
					\u0014\u0010\u0014.\u0018(\u000B\u0007\u0014.\u0018(printManager), u0018_u000A_u.\u000C);
					PrintSetting u6 = Enumerable.FirstOrDefault<PrintSetting>(\u000F\u000A\u0018.\u0016\u0018<PrintSetting>(\u000C), new Func<PrintSetting, bool>(u0018_u000A_u.\u0018));
					\u0018\u0010\u0014.\u0018(\u000B\u0007\u0014.\u0018(printManager), u6);
					PaperSize u7 = \u001C\u000B\u000F.\u000C;
					List<PaperSize>.Enumerator enumerator = \u000C\u0010\u0014.\u0018(PdfOptions.objPaperSizeSet);
					try
					{
						while (\u001B\u0007\u0014.\u0018(ref enumerator))
						{
							PaperSize paperSize = \u000E\u0007\u0014.\u0018(ref enumerator);
							if (\u001B\u0013\u0018.\u0018(\u0005\u0007\u0014.\u0018(paperSize), \u0016, true))
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
								u7 = paperSize;
								goto IL_30A;
							}
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
					IL_30A:
					\u0001\u0007\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(printManager))), u7);
					\u000F\u000A\u0018.\u000A\u0018(\u000F, printManager);
					\u0007\u0007\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(printManager))), \u0010\u0007\u0014.\u0018());
					\u0019\u0007\u0014.\u0018(printManager);
					\u001A\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(printManager));
				}
				catch (Exception u8)
				{
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u8, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparatePdfV1");
					throw;
				}
				\u001D\u0007\u0014.\u0018(printManager);
				flag2 = true;
				\u0013\u0017\u0014.\u0018(100);
				this.\u0012\u0018(\u000C);
				this.\u0018 = false;
				\u0013\u0017\u0014.\u0018(500);
				if (\u0003\u001F\u0018.\u0014())
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
					\u001D\u0015\u0014.\u0018(true);
					\u0018\u0017\u0014.\u0014(\u0012, \u001C\u0009\u0018.\u0016\u0003);
					throw \u0004\u0007\u0014.\u0018(\u001C\u0009\u0018.\u0016\u0003);
				}
				PDFFile pdffile = \u0002\u0007\u0014.\u0018();
				\u001E\u0007\u0014.\u0018(pdffile, u4);
				\u0017\u0007\u0014.\u0018(pdffile, u);
				\u0015\u0007\u0014.\u0018(\u001A\u0009\u0018.\u0018, pdffile);
				result = true;
			}
			catch (Exception ex)
			{
				if (flag)
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
					if (!flag2)
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
						\u0019\u0017\u0014.\u0018(Create.objFaildFile, \u0003);
					}
				}
				if (this.\u0018)
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
					this.\u0012\u0018(\u000C);
					this.\u0018 = false;
				}
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparatePdfV1");
				\u0018\u0017\u0014.\u0014(\u0012, \u000A\u0001\u0018.\u0018(ex));
				result = false;
			}
			finally
			{
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparatePdfV1");
			}
			return result;
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x0001E534 File Offset: 0x0001C734
		private static void \u000A\u0018(string \u000C, PrintManager \u0018)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "SetUpPrintManager");
			try
			{
				if (\u0015\u0006\u0014.\u0018() == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u000A\u0018(string, PrintManager)).MethodHandle;
					}
					\u0011\u0006\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u0015\u0006\u0014.\u0018());
				}
				else
				{
					\u0011\u0006\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u0015\u0006\u0014.\u0018());
					\u001F\u0006\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u0020\u0006\u0014.\u0018());
					if (2 == \u0020\u0006\u0014.\u0018())
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
						\u0009\u0006\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u000A\u0006\u0014.\u0018() / 25.4);
						\u001C\u0006\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u0013\u0006\u0014.\u0018() / 25.4);
					}
				}
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "SetUpPrintManager");
			}
			try
			{
				\u000D\u0006\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u0012\u0006\u0014.\u0018());
				if (1 == \u0012\u0006\u0014.\u0018())
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
					\u0016\u0006\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u000F\u0006\u0014.\u0018());
				}
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "SetUpPrintManager");
			}
			object u000C = \u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018)));
			PageOrientationType u3;
			if (!\u000F\u0002\u0018.\u0018(\u000C, "Landscape"))
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
				u3 = 0;
			}
			else
			{
				u3 = 1;
			}
			\u0003\u0006\u0014.\u0018(u000C, u3);
			\u0018\u0006\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u0014\u0006\u0014.\u0018());
			\u000E\u0010\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u000C\u0006\u0014.\u0018());
			\u0005\u0010\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u0003\u0010\u0014.\u0018());
			\u0001\u0010\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u001B\u0010\u0014.\u0018());
			\u0006\u0010\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u0008\u0010\u0014.\u0018());
			\u0007\u0010\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u0010\u0010\u0014.\u0018());
			\u000B\u0010\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u0019\u0010\u0014.\u0018());
			\u001D\u0010\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u001A\u0010\u0014.\u0018());
			\u0002\u0010\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(\u0018))), \u0004\u0010\u0014.\u0018());
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "SetUpPrintManager");
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x0001E878 File Offset: 0x0001CA78
		public bool \u0020\u0018(Document \u000C, View \u0018, string \u0014, string \u0003, string \u0016, SheetInfo \u000F)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWFV1");
			bool flag = false;
			string u000C = "";
			bool result;
			try
			{
				this.\u000F\u0018(\u000C);
				this.\u0018 = true;
				try
				{
					u000C = \u001F\u0010\u0014.\u0018(\u000F, \u0018, \u0015\u0010\u0014.\u0018(), "DWF", \u0003, \u0014, \u0011\u0010\u0014.\u0018());
				}
				catch (Exception u)
				{
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWFV1");
				}
				if (!\u001F\u001A\u0018.\u0018(\u0014\u0017\u0014.\u0018(\u000F)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0020\u0018(Document, View, string, string, string, SheetInfo)).MethodHandle;
					}
					if (this.\u0018)
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
						this.\u0012\u0018(\u000C);
						this.\u0018 = false;
					}
					result = false;
				}
				else
				{
					PrintManager u000C2 = \u0005\u0003\u0014.\u0018(\u000C);
					\u0012\u0010\u0014.\u0018(u000C2, true);
					PrintParameters u2 = \u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(u000C2)));
					\u000F\u000A\u0018.\u0019\u0018(\u0016, u2);
					try
					{
						\u0009\u0010\u0014.\u0018(\u0002\u0003\u0014.\u0018(u000C2), "DiRoots_transmittal");
					}
					catch (Exception u3)
					{
						\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u3, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWFV1");
					}
					try
					{
						\u0014\u0010\u0014.\u0018(\u000B\u0007\u0014.\u0018(u000C2), "DiRoots_transmittal");
					}
					catch (Exception u4)
					{
						\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u4, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWFV1");
					}
					if (\u0015\u0017\u0014.\u0018())
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
						DWFXExportOptions dwfxexportOptions = \u000B\u0006\u0014.\u0018();
						\u000F\u000A\u0018.\u000B\u0018(dwfxexportOptions);
						ViewSet viewSet = \u0006\u0003\u0014.\u0018();
						\u000B\u0003\u0014.\u0018(viewSet, \u0018);
						\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Start export Single Dwfx", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWFV1");
						flag = \u001A\u0006\u0014.\u0018(\u000C, \u0019\u001E\u0018.\u0018(u000C), \u0004\u0006\u0014.\u0018(u000C), viewSet, dwfxexportOptions);
						\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "End export Single Dwfx", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWFV1");
						try
						{
							\u001E\u0006\u0014.\u0018(\u0002\u0003\u0014.\u0018(u000C2));
						}
						catch (Exception u5)
						{
							\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u5, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWFV1");
						}
						try
						{
							\u0017\u0006\u0014.\u0018(\u000B\u0007\u0014.\u0018(u000C2));
							goto IL_30E;
						}
						catch (Exception u6)
						{
							\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u6, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWFV1");
							goto IL_30E;
						}
					}
					DWFExportOptions dwfexportOptions = \u001D\u0006\u0014.\u0018();
					\u000F\u000A\u0018.\u000B\u0018(dwfexportOptions);
					ViewSet viewSet2 = \u0006\u0003\u0014.\u0018();
					\u000B\u0003\u0014.\u0018(viewSet2, \u0018);
					\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Start export Single DWF", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWFV1");
					flag = \u0002\u0006\u0014.\u0018(\u000C, \u0019\u001E\u0018.\u0018(u000C), \u0004\u0006\u0014.\u0018(u000C), viewSet2, dwfexportOptions);
					\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Start export Single DWF", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWFV1");
					try
					{
						\u001E\u0006\u0014.\u0018(\u0002\u0003\u0014.\u0018(u000C2));
					}
					catch (Exception u7)
					{
						\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u7, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWFV1");
					}
					try
					{
						\u0017\u0006\u0014.\u0018(\u000B\u0007\u0014.\u0018(u000C2));
					}
					catch (Exception u8)
					{
						\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u8, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWFV1");
					}
					IL_30E:
					this.\u0012\u0018(\u000C);
					this.\u0018 = false;
					\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWFV1");
					result = flag;
				}
			}
			catch (Exception ex)
			{
				\u0019\u0017\u0014.\u0018(Create.objFaildFile, \u0003);
				if (this.\u0018)
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
					this.\u0012\u0018(\u000C);
					this.\u0018 = false;
				}
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateDWFV1");
				\u0018\u0017\u0014.\u0014(\u000F, \u000A\u0001\u0018.\u0018(ex));
				result = false;
			}
			return result;
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x0001ECE0 File Offset: 0x0001CEE0
		public static Element \u001F\u0018(Document \u000C, long \u0018)
		{
			return \u0003\u0004\u0018.\u0018(\u000C, \u0018.\u0018());
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x0001ED00 File Offset: 0x0001CF00
		public bool \u0011\u0018(Document \u000C, string \u0018, string \u0014, string \u0003)
		{
			bool result = false;
			bool flag = !\u0019\u0006\u0014.\u0018();
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinePdf");
			TransactionGroup transactionGroup = \u0011\u0007\u0014.\u0018(\u000C);
			try
			{
				\u001F\u0007\u0014.\u0018(transactionGroup, "Export To Combine Pdf");
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0011\u0018(Document, string, string, string)).MethodHandle;
					}
					\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Start export Combined PDF with jump to section option is ON", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinePdf");
					\u001B\u0017\u0014.\u0018(\u000D\u0015\u0014.\u0018(), true);
					result = this.\u0006\u0018(\u000C, \u0018, \u0014, \u0003);
					\u001B\u0017\u0014.\u0018(\u000D\u0015\u0014.\u0018(), false);
				}
				else
				{
					try
					{
						\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Start export Combined PDF with jump to section option is OFF", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinePdf");
						result = this.\u0007\u0018(\u000C);
					}
					catch (Exception u000C)
					{
						IEnumerable<SheetInfo> enumerable = \u001C\u0017\u0014.\u0018();
						Func<SheetInfo, bool> func;
						if ((func = \u000F\u000A\u0018.<>c.\u0018) == null)
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
							func = (\u000F\u000A\u0018.<>c.\u0018 = new Func<SheetInfo, bool>(\u000F\u000A\u0018.<>c.\u000C.\u0015));
						}
						IEnumerator<SheetInfo> enumerator = \u0009\u0005\u0018.\u0018(Enumerable.Where<SheetInfo>(enumerable, func));
						try
						{
							while (\u001F\u001E\u0018.\u0018(enumerator))
							{
								\u0018\u0017\u0014.\u0014(\u0013\u0005\u0018.\u0018(enumerator), \u000A\u0001\u0018.\u0018(u000C));
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
							if (enumerator != null)
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
								\u0020\u001E\u0018.\u0018(enumerator);
							}
						}
					}
				}
				\u0020\u0007\u0014.\u0018(transactionGroup);
			}
			finally
			{
				if (transactionGroup != null)
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
					\u0020\u001E\u0018.\u0018(transactionGroup);
				}
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinePdf");
			return result;
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x0001EED8 File Offset: 0x0001D0D8
		public bool \u0015\u0018(Document \u000C, string \u0018)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombineDWF");
			bool result = false;
			TransactionGroup transactionGroup = \u0011\u0007\u0014.\u0018(\u000C);
			try
			{
				\u001F\u0007\u0014.\u0018(transactionGroup, "Export To Combine Dwf");
				result = this.\u001A\u0018(\u000C, \u0018);
				\u0020\u0007\u0014.\u0018(transactionGroup);
			}
			finally
			{
				if (transactionGroup != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0015\u0018(Document, string)).MethodHandle;
					}
					\u0020\u001E\u0018.\u0018(transactionGroup);
				}
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombineDWF");
			return result;
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x0001EF6C File Offset: 0x0001D16C
		public bool \u0017\u0018(Document \u000C)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombineIMG");
			return this.\u0004\u0018(\u000C);
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x0001EF98 File Offset: 0x0001D198
		public bool \u001E\u0018(Document \u000C, View \u0018, string \u0014, SheetInfo \u0003)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateIMGV1");
			bool result = false;
			try
			{
				string text = \u001F\u0010\u0014.\u0018(\u0003, \u0018, \u0015\u0010\u0014.\u0018(), "Images", \u0014, "", \u0011\u0010\u0014.\u0018());
				if (!\u001F\u001A\u0018.\u0018(\u0014\u0017\u0014.\u0018(\u0003)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u001E\u0018(Document, View, string, SheetInfo)).MethodHandle;
					}
					return false;
				}
				string u000C = \u0019\u001E\u0018.\u0018(text);
				IList<ElementId> list = \u0007\u0004\u0018.\u0018();
				\u001F\u0004\u0018.\u0018(list, \u0009\u0002\u0018.\u0018(\u0018));
				ImageExportOptions imageExportOptions = \u000F\u000A\u0018.\u001D\u0018();
				\u000C\u0008\u0014.\u0018(imageExportOptions, text);
				\u000E\u0006\u0014.\u0018(imageExportOptions, false);
				\u0005\u0006\u0014.\u0018(imageExportOptions, 2);
				\u001B\u0006\u0014.\u0018(imageExportOptions, list);
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Start export - single IMG", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateIMGV1");
				\u0001\u0006\u0014.\u0018(\u000C, imageExportOptions);
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "End export - single IMG", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateIMGV1");
				result = true;
				IEnumerable<FileInfo> enumerable = \u001C\u0006\u0018.\u0018(\u0013\u0006\u0018.\u0018(u000C));
				Func<FileInfo, DateTime> func;
				if ((func = \u000F\u000A\u0018.<>c.\u0014) == null)
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
					func = (\u000F\u000A\u0018.<>c.\u0014 = new Func<FileInfo, DateTime>(\u000F\u000A\u0018.<>c.\u000C.\u0017));
				}
				FileInfo u000C2 = Enumerable.First<FileInfo>(Enumerable.OrderByDescending<FileInfo, DateTime>(enumerable, func));
				string u = \u0008\u0006\u0014.\u0018(\u0020\u0020\u0014.\u0018(u000C2));
				string u2 = \u000D\u001E\u0018.\u0018(text, u);
				\u000F\u000A\u0018.\u0002\u0018(u000C2, u2);
				\u0006\u0006\u0014.\u0014(\u0003, \u0020\u0020\u0014.\u0018(u000C2));
				\u0007\u0006\u0014.\u0014(\u0003, \u0010\u0006\u0014.\u0018(u000C2));
			}
			catch (Exception ex)
			{
				result = false;
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateIMGV1");
				\u0018\u0017\u0014.\u0014(\u0003, \u000A\u0001\u0018.\u0018(ex));
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportSeparateIMGV1");
			return result;
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0001F188 File Offset: 0x0001D388
		private static void \u0002\u0018(FileInfo \u000C, string \u0018)
		{
			if (\u000C\u001A\u0018.\u0018(\u0018))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0002\u0018(FileInfo, string)).MethodHandle;
				}
				\u000C\u0020\u0014.\u0018(\u0018);
				\u0018\u0008\u0014.\u0018(\u000C, \u0018);
				return;
			}
			\u0018\u0008\u0014.\u0018(\u000C, \u0018);
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0001F1C8 File Offset: 0x0001D3C8
		public bool \u0004\u0018(Document \u000C)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedIMGV1");
			bool result = false;
			string text = string.Empty;
			string u000C = string.Empty;
			try
			{
				try
				{
					string u000C2 = \u0015\u0010\u0014.\u0018();
					string u = "Images";
					string u2 = \u000F\u0008\u0014.\u0018();
					string u3 = "";
					bool u4 = \u0011\u0010\u0014.\u0018();
					IEnumerable<SheetInfo> enumerable = \u001C\u0017\u0014.\u0018();
					Func<SheetInfo, bool> func;
					if ((func = \u000F\u000A\u0018.<>c.\u0003) == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0004\u0018(Document)).MethodHandle;
						}
						func = (\u000F\u000A\u0018.<>c.\u0003 = new Func<SheetInfo, bool>(\u000F\u000A\u0018.<>c.\u000C.\u001E));
					}
					text = this.\u0008\u0018(u000C2, u, u2, u3, u4, Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable, func)));
					u000C = \u000B\u001E\u0018.\u0018(text);
					IEnumerable<SheetInfo> enumerable2 = \u001C\u0017\u0014.\u0018();
					Func<SheetInfo, bool> func2;
					if ((func2 = \u000F\u000A\u0018.<>c.\u0016) == null)
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
						func2 = (\u000F\u000A\u0018.<>c.\u0016 = new Func<SheetInfo, bool>(\u000F\u000A\u0018.<>c.\u000C.\u0002));
					}
					if (Enumerable.Any<SheetInfo>(enumerable2, func2))
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
						return false;
					}
				}
				catch (Exception u5)
				{
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u5, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedIMGV1");
				}
				List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
				try
				{
					while (\u0019\u000E\u0018.\u0018(ref enumerator))
					{
						SheetInfo u000C3 = \u000C\u000C\u0014.\u0018(ref enumerator);
						if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(u000C3), "Image"))
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
							\u0007\u0006\u0014.\u0014(u000C3, \u000D\u001E\u0018.\u0018(u000C, ".html"));
							\u0006\u0006\u0014.\u0014(u000C3, \u000D\u001E\u0018.\u0018(text, ".html"));
						}
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
				\u0006\u0003\u0014.\u0018();
				List<ElementId> u000C4 = \u0007\u0004\u0018.\u0018();
				IList<ElementId> list = \u0007\u0004\u0018.\u0018();
				List<View> u000C5 = \u000F\u000A\u0018.\u0016\u0018<View>(\u000C);
				enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
				try
				{
					IL_26F:
					while (\u0019\u000E\u0018.\u0018(ref enumerator))
					{
						SheetInfo u000C6 = \u000C\u000C\u0014.\u0018(ref enumerator);
						List<View>.Enumerator enumerator2 = \u0011\u001A\u0014.\u0018(u000C5);
						try
						{
							while (\u000A\u001A\u0014.\u0018(ref enumerator2))
							{
								View u000C7 = \u001F\u001A\u0014.\u0018(ref enumerator2);
								if (\u0016\u0008\u0014.\u0018(\u0015\u0005\u0018.\u0014(u000C6), \u0009\u0002\u0018.\u0018(u000C7)))
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
									if (!\u0003\u0008\u0014.\u0018(u000C4, \u0015\u0005\u0018.\u0014(u000C6)))
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
										\u001F\u0004\u0018.\u0018(list, \u0015\u0005\u0018.\u0014(u000C6));
										\u0014\u0008\u0014.\u0018(u000C4, \u0015\u0005\u0018.\u0014(u000C6));
										goto IL_26F;
									}
								}
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
							((IDisposable)enumerator2).Dispose();
						}
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
				ImageExportOptions imageExportOptions = \u000F\u000A\u0018.\u001D\u0018();
				\u000C\u0008\u0014.\u0018(imageExportOptions, text);
				\u000E\u0006\u0014.\u0018(imageExportOptions, true);
				\u0005\u0006\u0014.\u0018(imageExportOptions, 2);
				\u001B\u0006\u0014.\u0018(imageExportOptions, list);
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Start export - Combined IMG", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedIMGV1");
				\u0001\u0006\u0014.\u0018(\u000C, imageExportOptions);
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "End export - Combined IMG", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedIMGV1");
				result = true;
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedIMGV1");
			}
			catch (Exception u6)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u6, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedIMGV1");
				result = false;
			}
			return result;
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0001F58C File Offset: 0x0001D78C
		private static ImageExportOptions \u001D\u0018()
		{
			ImageExportOptions imageExportOptions = \u001D\u0008\u0014.\u0018();
			if (\u0004\u0008\u0014.\u0018() == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u001D\u0018()).MethodHandle;
				}
				\u0011\u0008\u0014.\u0018(imageExportOptions, 0);
				\u001E\u0008\u0014.\u0018(imageExportOptions, \u0002\u0008\u0014.\u0018());
				\u0015\u0008\u0014.\u0018(imageExportOptions, \u0017\u0008\u0014.\u0018());
			}
			else
			{
				\u0011\u0008\u0014.\u0018(imageExportOptions, 1);
				\u0020\u0008\u0014.\u0018(imageExportOptions, \u001F\u0008\u0014.\u0018());
				\u0009\u0008\u0014.\u0018(imageExportOptions, \u000A\u0008\u0014.\u0018());
			}
			\u001C\u0008\u0014.\u0018(imageExportOptions, \u0013\u0008\u0014.\u0018());
			\u0012\u0008\u0014.\u0018(imageExportOptions, \u000D\u0008\u0014.\u0018());
			return imageExportOptions;
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x0001F61C File Offset: 0x0001D81C
		public bool \u001A\u0018(Document \u000C, string \u0018)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedDWFV1");
			bool flag = false;
			string text = string.Empty;
			string text2 = string.Empty;
			bool result;
			try
			{
				this.\u000F\u0018(\u000C);
				this.\u0018 = true;
				try
				{
					string u000C = \u0015\u0010\u0014.\u0018();
					string u = "DWF";
					string u2 = \u0019\u0008\u0014.\u0018();
					string u3;
					if (!\u0015\u0017\u0014.\u0018())
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u001A\u0018(Document, string)).MethodHandle;
						}
						u3 = ".dwf";
					}
					else
					{
						u3 = ".dwfx";
					}
					bool u4 = \u0011\u0010\u0014.\u0018();
					IEnumerable<SheetInfo> enumerable = \u001C\u0017\u0014.\u0018();
					Func<SheetInfo, bool> func;
					if ((func = \u000F\u000A\u0018.<>c.\u000F) == null)
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
						func = (\u000F\u000A\u0018.<>c.\u000F = new Func<SheetInfo, bool>(\u000F\u000A\u0018.<>c.\u000C.\u0004));
					}
					text = this.\u0008\u0018(u000C, u, u2, u3, u4, Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable, func)));
					text2 = \u000B\u001E\u0018.\u0018(text);
					IEnumerable<SheetInfo> enumerable2 = \u001C\u0017\u0014.\u0018();
					Func<SheetInfo, bool> func2;
					if ((func2 = \u000F\u000A\u0018.<>c.\u0012) == null)
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
						func2 = (\u000F\u000A\u0018.<>c.\u0012 = new Func<SheetInfo, bool>(\u000F\u000A\u0018.<>c.\u000C.\u001D));
					}
					if (Enumerable.Any<SheetInfo>(enumerable2, func2))
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
						return false;
					}
				}
				catch (Exception u5)
				{
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u5, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedDWFV1");
				}
				List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
				try
				{
					while (\u0019\u000E\u0018.\u0018(ref enumerator))
					{
						SheetInfo sheetInfo = \u000C\u000C\u0014.\u0018(ref enumerator);
						if (\u000A\u0017\u0014.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "DWF"))
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
							object u000C2 = sheetInfo;
							string u000C3 = text2;
							string u6;
							if (!\u0015\u0017\u0014.\u0018())
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
								u6 = ".dwf";
							}
							else
							{
								u6 = ".dwfx";
							}
							\u0007\u0006\u0014.\u0014(u000C2, \u000D\u001E\u0018.\u0018(u000C3, u6));
							object u000C4 = sheetInfo;
							string u000C5 = text;
							string u7;
							if (!\u0015\u0017\u0014.\u0018())
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
								u7 = ".dwf";
							}
							else
							{
								u7 = ".dwfx";
							}
							\u0006\u0006\u0014.\u0014(u000C4, \u000D\u001E\u0018.\u0018(u000C5, u7));
						}
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
				PrintManager u000C6 = \u0005\u0003\u0014.\u0018(\u000C);
				\u0012\u0010\u0014.\u0018(u000C6, true);
				PrintParameters u8 = \u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(u000C6)));
				\u000F\u000A\u0018.\u0019\u0018(\u0018, u8);
				try
				{
					\u0009\u0010\u0014.\u0018(\u0002\u0003\u0014.\u0018(u000C6), "DiRoots_transmittal");
				}
				catch (Exception u9)
				{
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u9, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedDWFV1");
				}
				try
				{
					\u0014\u0010\u0014.\u0018(\u000B\u0007\u0014.\u0018(u000C6), "DiRoots_transmittal");
				}
				catch (Exception u10)
				{
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u10, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedDWFV1");
				}
				if (\u0015\u0017\u0014.\u0018())
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
					DWFXExportOptions dwfxexportOptions = \u000B\u0006\u0014.\u0018();
					\u000F\u000A\u0018.\u000B\u0018(dwfxexportOptions);
					\u000B\u0008\u0014.\u0018(dwfxexportOptions, true);
					ViewSet viewSet = \u0006\u0003\u0014.\u0018();
					List<ElementId> u000C7 = \u0007\u0004\u0018.\u0018();
					List<View> u000C8 = \u000F\u000A\u0018.\u0016\u0018<View>(\u000C);
					enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
					try
					{
						IL_3B0:
						while (\u0019\u000E\u0018.\u0018(ref enumerator))
						{
							SheetInfo u000C9 = \u000C\u000C\u0014.\u0018(ref enumerator);
							List<View>.Enumerator enumerator2 = \u0011\u001A\u0014.\u0018(u000C8);
							try
							{
								while (\u000A\u001A\u0014.\u0018(ref enumerator2))
								{
									View view = \u001F\u001A\u0014.\u0018(ref enumerator2);
									if (\u0016\u0008\u0014.\u0018(\u0015\u0005\u0018.\u0014(u000C9), \u0009\u0002\u0018.\u0018(view)))
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
										if (!\u0003\u0008\u0014.\u0018(u000C7, \u0015\u0005\u0018.\u0014(u000C9)))
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
											\u000B\u0003\u0014.\u0018(viewSet, view);
											\u0014\u0008\u0014.\u0018(u000C7, \u0015\u0005\u0018.\u0014(u000C9));
											\u000E\u0017\u0014.\u0018(\u001A\u0008\u0014.\u0014(\u000D\u0015\u0014.\u0018()), \u000F\u000A\u0018.\u0014\u0014(\u000C, view));
											goto IL_3B0;
										}
									}
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
								((IDisposable)enumerator2).Dispose();
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
					\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Start export - Combined Dwfx", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedDWFV1");
					flag = \u001A\u0006\u0014.\u0018(\u000C, \u0019\u001E\u0018.\u0018(text), \u0004\u0006\u0014.\u0018(text), viewSet, dwfxexportOptions);
					\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "End export - Combined Dwfx", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedDWFV1");
					try
					{
						\u001E\u0006\u0014.\u0018(\u0002\u0003\u0014.\u0018(u000C6));
					}
					catch (Exception u11)
					{
						\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u11, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedDWFV1");
					}
					try
					{
						\u0017\u0006\u0014.\u0018(\u000B\u0007\u0014.\u0018(u000C6));
						goto IL_675;
					}
					catch (Exception u12)
					{
						\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u12, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedDWFV1");
						goto IL_675;
					}
				}
				DWFExportOptions dwfexportOptions = \u001D\u0006\u0014.\u0018();
				\u000F\u000A\u0018.\u000B\u0018(dwfexportOptions);
				\u000B\u0008\u0014.\u0018(dwfexportOptions, true);
				ViewSet viewSet2 = \u0006\u0003\u0014.\u0018();
				List<ElementId> u000C10 = \u0007\u0004\u0018.\u0018();
				List<View> u000C11 = \u000F\u000A\u0018.\u0016\u0018<View>(\u000C);
				enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
				try
				{
					IL_59F:
					while (\u0019\u000E\u0018.\u0018(ref enumerator))
					{
						SheetInfo u000C12 = \u000C\u000C\u0014.\u0018(ref enumerator);
						List<View>.Enumerator enumerator2 = \u0011\u001A\u0014.\u0018(u000C11);
						try
						{
							while (\u000A\u001A\u0014.\u0018(ref enumerator2))
							{
								View view2 = \u001F\u001A\u0014.\u0018(ref enumerator2);
								if (\u0016\u0008\u0014.\u0018(\u0015\u0005\u0018.\u0014(u000C12), \u0009\u0002\u0018.\u0018(view2)))
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
									if (!\u0003\u0008\u0014.\u0018(u000C10, \u0015\u0005\u0018.\u0014(u000C12)))
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
										\u000B\u0003\u0014.\u0018(viewSet2, view2);
										\u0014\u0008\u0014.\u0018(u000C10, \u0015\u0005\u0018.\u0014(u000C12));
										\u000E\u0017\u0014.\u0018(\u001A\u0008\u0014.\u0014(\u000D\u0015\u0014.\u0018()), \u000F\u000A\u0018.\u0014\u0014(\u000C, view2));
										goto IL_59F;
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
							((IDisposable)enumerator2).Dispose();
						}
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
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Start export - Combined DWF", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedDWFV1");
				flag = \u0002\u0006\u0014.\u0018(\u000C, \u0019\u001E\u0018.\u0018(text), \u0004\u0006\u0014.\u0018(text), viewSet2, dwfexportOptions);
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "End export - Combined DWF", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedDWFV1");
				try
				{
					\u001E\u0006\u0014.\u0018(\u0002\u0003\u0014.\u0018(u000C6));
				}
				catch (Exception u13)
				{
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u13, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedDWFV1");
				}
				try
				{
					\u0017\u0006\u0014.\u0018(\u000B\u0007\u0014.\u0018(u000C6));
				}
				catch (Exception u14)
				{
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u14, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedDWFV1");
				}
				IL_675:
				this.\u0012\u0018(\u000C);
				this.\u0018 = false;
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedDWFV1");
				result = flag;
			}
			catch (Exception u15)
			{
				\u0019\u0017\u0014.\u0018(Create.objFaildFile, text2);
				if (this.\u0018)
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
					this.\u0012\u0018(\u000C);
					this.\u0018 = false;
				}
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u15, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinedDWFV1");
				result = false;
			}
			return result;
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x0001FE50 File Offset: 0x0001E050
		private static void \u000B\u0018(DWFExportOptions \u000C)
		{
			\u000D\u0001\u0014.\u0018(\u000C, \u001C\u0001\u0014.\u0018());
			\u000F\u0001\u0014.\u0018(\u000C, \u0012\u0001\u0014.\u0018());
			\u0003\u0001\u0014.\u0018(\u000C, \u0016\u0001\u0014.\u0018());
			\u0018\u0001\u0014.\u0018(\u000C, \u0014\u0001\u0014.\u0018());
			\u000E\u0008\u0014.\u0018(\u000C, \u000C\u0001\u0014.\u0018());
			\u001B\u0008\u0014.\u0018(\u000C, \u0005\u0008\u0014.\u0018());
			\u0008\u0008\u0014.\u0018(\u000C, \u0001\u0008\u0014.\u0018() == 0);
			\u0010\u0008\u0014.\u0018(\u000C, \u0006\u0008\u0014.\u0018());
			\u0007\u0008\u0014.\u0018(\u000C, false);
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x0001FED0 File Offset: 0x0001E0D0
		private static void \u0019\u0018(string \u000C, PrintParameters \u0018)
		{
			try
			{
				if (\u0019\u0001\u0014.\u0018() == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0019\u0018(string, PrintParameters)).MethodHandle;
					}
					\u0011\u0006\u0014.\u0018(\u0018, \u0019\u0001\u0014.\u0018());
				}
				else
				{
					\u0011\u0006\u0014.\u0018(\u0018, \u0019\u0001\u0014.\u0018());
					\u001F\u0006\u0014.\u0018(\u0018, \u000B\u0001\u0014.\u0018());
					if (2 == \u000B\u0001\u0014.\u0018())
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
						\u0009\u0006\u0014.\u0018(\u0018, \u001A\u0001\u0014.\u0018() / 25.4);
						\u001C\u0006\u0014.\u0018(\u0018, \u001D\u0001\u0014.\u0018() / 25.4);
					}
				}
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "SetUpDWFExport");
			}
			try
			{
				\u000D\u0006\u0014.\u0018(\u0018, \u0004\u0001\u0014.\u0018());
				if (1 == \u0012\u0006\u0014.\u0018())
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
					\u0016\u0006\u0014.\u0018(\u0018, \u0002\u0001\u0014.\u0018());
				}
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "SetUpDWFExport");
			}
			PageOrientationType u3;
			if (!\u000F\u0002\u0018.\u0018(\u000C, "Landscape"))
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
				u3 = 0;
			}
			else
			{
				u3 = 1;
			}
			\u0003\u0006\u0014.\u0018(\u0018, u3);
			\u0018\u0006\u0014.\u0018(\u0018, \u001E\u0001\u0014.\u0018());
			\u000E\u0010\u0014.\u0018(\u0018, \u0017\u0001\u0014.\u0018());
			\u0005\u0010\u0014.\u0018(\u0018, \u0015\u0001\u0014.\u0018());
			\u0007\u0007\u0014.\u0018(\u0018, \u0011\u0001\u0014.\u0018());
			\u0006\u0010\u0014.\u0018(\u0018, \u001F\u0001\u0014.\u0018());
			\u0007\u0010\u0014.\u0018(\u0018, \u0020\u0001\u0014.\u0018());
			\u000B\u0010\u0014.\u0018(\u0018, \u000A\u0001\u0014.\u0018());
			\u001D\u0010\u0014.\u0018(\u0018, \u0009\u0001\u0014.\u0018());
			\u0002\u0010\u0014.\u0018(\u0018, \u0013\u0001\u0014.\u0018());
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x00020080 File Offset: 0x0001E280
		public bool \u0007\u0018(Document \u000C)
		{
			string u000C = \u0015\u0010\u0014.\u0018();
			string u = "PDF";
			string u2 = \u0016\u001B\u0014.\u0018();
			string u3 = ".pdf";
			bool u4 = \u0011\u0010\u0014.\u0018();
			IEnumerable<SheetInfo> enumerable = \u001C\u0017\u0014.\u0018();
			Func<SheetInfo, bool> func;
			if ((func = \u000F\u000A\u0018.<>c.\u000D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0007\u0018(Document)).MethodHandle;
				}
				func = (\u000F\u000A\u0018.<>c.\u000D = new Func<SheetInfo, bool>(\u000F\u000A\u0018.<>c.\u000C.\u001A));
			}
			string u5 = this.\u0008\u0018(u000C, u, u2, u3, u4, Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable, func)));
			IEnumerable<SheetInfo> enumerable2 = \u001C\u0017\u0014.\u0018();
			Func<SheetInfo, bool> func2;
			if ((func2 = \u000F\u000A\u0018.<>c.\u001C) == null)
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
				func2 = (\u000F\u000A\u0018.<>c.\u001C = new Func<SheetInfo, bool>(\u000F\u000A\u0018.<>c.\u000C.\u000B));
			}
			if (Enumerable.Any<SheetInfo>(enumerable2, func2))
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
				return false;
			}
			List<string> u000C2 = \u0011\u0002\u0018.\u0018();
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinePdfV2");
			List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
			try
			{
				while (\u0019\u000E\u0018.\u0018(ref enumerator))
				{
					SheetInfo sheetInfo = \u000C\u000C\u0014.\u0018(ref enumerator);
					if (!\u0009\u001E\u0018.\u0018(\u0010\u0020\u0014.\u0014(sheetInfo), "PDF"))
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
						View u6 = \u001D\u001A\u000F.\u000C(\u0003\u0004\u0018.\u0018(\u000C, \u0015\u0005\u0018.\u0014(sheetInfo)));
						string u7 = \u001D\u001B\u0018.\u0018().ToString();
						\u0003\u001B\u0014.\u0018(sheetInfo, "");
						this.\u000D\u0018(\u000C, u6, ".pdf", u7, \u0004\u0017\u0014.\u0018(sheetInfo), \u0011\u0017\u0014.\u0014(sheetInfo), sheetInfo);
						\u0019\u0017\u0014.\u0018(u000C2, \u0014\u001B\u0014.\u0014(sheetInfo));
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
				goto IL_1BA;
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			IL_1B3:
			\u0013\u0017\u0014.\u0018(100);
			IL_1BA:
			if (\u0018\u001B\u0014.\u0018(\u001A\u0009\u0018.\u0018) <= 0)
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
				List<PdfDocument> u000C3 = \u000C\u001B\u0014.\u0018();
				List<string>.Enumerator enumerator2 = \u0008\u0015\u0014.\u0018(u000C2);
				try
				{
					while (\u0010\u0015\u0014.\u0018(ref enumerator2))
					{
						string u000C4 = \u0006\u0015\u0014.\u0018(ref enumerator2);
						if (\u000C\u001A\u0018.\u0018(u000C4))
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
							PdfDocument u8 = \u000E\u0001\u0014.\u0018(u000C4, PdfDocumentOpenMode.Import, \u0013\u000B\u000F.\u000C);
							\u0005\u0001\u0014.\u0018(u000C3, u8);
						}
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
					((IDisposable)enumerator2).Dispose();
				}
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Combining PDF files into 1 file.", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinePdfV2");
				if (\u0007\u0001\u0014.\u0018(u000C3) > 0)
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
					PdfDocument pdfDocument = \u001B\u0001\u0014.\u0018();
					try
					{
						List<PdfDocument>.Enumerator enumerator3 = \u0001\u0001\u0014.\u0018(u000C3);
						try
						{
							while (\u0006\u0001\u0014.\u0018(ref enumerator3))
							{
								PdfDocument u000C5 = \u0008\u0001\u0014.\u0018(ref enumerator3);
								this.\u0010\u0018(u000C5, pdfDocument);
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
						\u0010\u0001\u0014.\u0018(pdfDocument, u5);
					}
					finally
					{
						if (pdfDocument != null)
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
							\u0020\u001E\u0018.\u0018(pdfDocument);
						}
					}
				}
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Deleting temp PDF files.", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinePdfV2");
				enumerator2 = \u0008\u0015\u0014.\u0018(u000C2);
				try
				{
					while (\u0010\u0015\u0014.\u0018(ref enumerator2))
					{
						string u000C6 = \u0006\u0015\u0014.\u0018(ref enumerator2);
						if (\u000C\u001A\u0018.\u0018(u000C6))
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
							\u000C\u0020\u0014.\u0018(u000C6);
						}
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
					((IDisposable)enumerator2).Dispose();
				}
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinePdfV2");
				return \u0007\u0001\u0014.\u0018(u000C3) > 0;
			}
			goto IL_1B3;
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x00020444 File Offset: 0x0001E644
		private void \u0010\u0018(PdfDocument \u000C, PdfDocument \u0018)
		{
			for (int i = 0; i < \u000F\u001B\u0014.\u0018(\u000C); i++)
			{
				\u0012\u001B\u0014.\u0018(\u0018, \u000D\u001B\u0014.\u0018(\u001C\u001B\u0014.\u0018(\u000C), i));
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0010\u0018(PdfDocument, PdfDocument)).MethodHandle;
			}
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x00020490 File Offset: 0x0001E690
		public bool \u0006\u0018(Document \u000C, string \u0018, string \u0014, string \u0003)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinePdfV1");
			bool flag = false;
			bool flag2 = false;
			string text = string.Empty;
			string text2 = string.Empty;
			bool result;
			try
			{
				List<ElementId> u000C = \u0007\u0004\u0018.\u0018();
				\u001E\u0010\u0014.\u0018(\u000F\u0010\u0014.\u0018() + 1);
				PrintManager printManager = \u0005\u0003\u0014.\u0018(\u000C);
				List<View> u000C2 = \u000F\u000A\u0018.\u0016\u0018<View>(\u000C);
				List<View> u000C3 = \u000C\u001E\u0014.\u0018();
				List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
				try
				{
					IL_163:
					while (\u0019\u000E\u0018.\u0018(ref enumerator))
					{
						SheetInfo u000C4 = \u000C\u000C\u0014.\u0018(ref enumerator);
						if (!\u0009\u001E\u0018.\u0018(\u0010\u0020\u0014.\u0014(u000C4), "PDF"))
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0006\u0018(Document, string, string, string)).MethodHandle;
							}
							List<View>.Enumerator enumerator2 = \u0011\u001A\u0014.\u0018(u000C2);
							try
							{
								while (\u000A\u001A\u0014.\u0018(ref enumerator2))
								{
									View view = \u001F\u001A\u0014.\u0018(ref enumerator2);
									if (\u0016\u0008\u0014.\u0018(\u0015\u0005\u0018.\u0014(u000C4), \u0009\u0002\u0018.\u0018(view)))
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
										if (!\u0003\u0008\u0014.\u0018(u000C, \u0015\u0005\u0018.\u0014(u000C4)))
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
											\u0017\u000B\u0014.\u0018(u000C3, view);
											\u0014\u0008\u0014.\u0018(u000C, \u0015\u0005\u0018.\u0014(u000C4));
											\u000E\u0017\u0014.\u0018(\u001A\u0008\u0014.\u0014(\u000D\u0015\u0014.\u0018()), \u000F\u000A\u0018.\u0014\u0014(\u000C, view));
											goto IL_163;
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
								((IDisposable)enumerator2).Dispose();
							}
						}
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
				this.\u000F\u0018(\u000C);
				this.\u0018 = true;
				string u000C5 = \u000F\u000A\u0018.\u0013\u0018();
				string u = \u001D\u001B\u0018.\u0018().ToString();
				string u2 = \u0019\u000C\u0014.\u0018(u000C5, "\\", u, ".pdf");
				try
				{
					\u000F\u000A\u0018.\u0014\u000A\u0018 u0014_u000A_u = new \u000F\u000A\u0018.\u0014\u000A\u0018();
					string u000C6 = \u0015\u0010\u0014.\u0018();
					string u3 = "PDF";
					string u4 = \u0016\u001B\u0014.\u0018();
					string u5 = ".pdf";
					bool u6 = \u0011\u0010\u0014.\u0018();
					IEnumerable<SheetInfo> enumerable = \u001C\u0017\u0014.\u0018();
					Func<SheetInfo, bool> func;
					if ((func = \u000F\u000A\u0018.<>c.\u0013) == null)
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
						func = (\u000F\u000A\u0018.<>c.\u0013 = new Func<SheetInfo, bool>(\u000F\u000A\u0018.<>c.\u000C.\u0019));
					}
					text = this.\u0008\u0018(u000C6, u3, u4, u5, u6, Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable, func)));
					IEnumerable<SheetInfo> enumerable2 = \u001C\u0017\u0014.\u0018();
					Func<SheetInfo, bool> func2;
					if ((func2 = \u000F\u000A\u0018.<>c.\u0009) == null)
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
						func2 = (\u000F\u000A\u0018.<>c.\u0009 = new Func<SheetInfo, bool>(\u000F\u000A\u0018.<>c.\u000C.\u0007));
					}
					if (Enumerable.Any<SheetInfo>(enumerable2, func2))
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
						return false;
					}
					text2 = \u000B\u001E\u0018.\u0018(text);
					\u0011\u001B\u0014.\u0018(text2);
					\u001F\u001B\u0014.\u0018(text);
					\u0020\u0010\u0014.\u0018(printManager, true);
					\u0019\u0007\u0014.\u0018(printManager);
					\u0004\u0003\u0014.\u0018(printManager, 2);
					ViewSheetSetting u000C7 = \u0002\u0003\u0014.\u0018(printManager);
					\u0020\u001B\u0014.\u0018(\u0015\u0003\u0014.\u0018(u000C7), false);
					\u0009\u001B\u0014.\u0018(\u0015\u0003\u0014.\u0018(u000C7), \u000A\u001B\u0014.\u0018(u000C3));
					string u000C8 = text2;
					int num = \u000F\u0010\u0014.\u0018();
					\u0009\u0010\u0014.\u0018(u000C7, \u000D\u001E\u0018.\u0018(u000C8, \u0010\u001E\u0018.\u0018(ref num)));
					\u0019\u0007\u0014.\u0018(printManager);
					\u001C\u0010\u0014.\u0018(printManager, \u0013\u0010\u0014.\u0018());
					\u0019\u0007\u0014.\u0018(printManager);
					\u000D\u0010\u0014.\u0018(printManager, u2);
					\u0019\u0007\u0014.\u0018(printManager);
					\u0012\u0010\u0014.\u0018(printManager, true);
					\u0019\u0007\u0014.\u0018(printManager);
					\u000F\u000A\u0018.\u0014\u000A\u0018 u0014_u000A_u2 = u0014_u000A_u;
					string u000C9 = text2;
					num = \u000F\u0010\u0014.\u0018();
					u0014_u000A_u2.\u000C = \u000D\u001E\u0018.\u0018(u000C9, \u0010\u001E\u0018.\u0018(ref num));
					\u0018\u0010\u0014.\u0018(\u000B\u0007\u0014.\u0018(printManager), \u0016\u0010\u0014.\u0018(\u000B\u0007\u0014.\u0018(printManager)));
					\u0003\u0011\u0018.\u000C(printManager, \u0003\u0010\u0014.\u0018());
					\u0014\u0010\u0014.\u0018(\u000B\u0007\u0014.\u0018(printManager), u0014_u000A_u.\u000C);
					PrintSetting u7 = Enumerable.FirstOrDefault<PrintSetting>(\u000F\u000A\u0018.\u0016\u0018<PrintSetting>(\u000C), new Func<PrintSetting, bool>(u0014_u000A_u.\u0018));
					\u0018\u0010\u0014.\u0018(\u000B\u0007\u0014.\u0018(printManager), u7);
					PaperSize u8 = \u001C\u000B\u000F.\u000C;
					List<PaperSize>.Enumerator enumerator3 = \u000C\u0010\u0014.\u0018(PdfOptions.objPaperSizeSet);
					try
					{
						while (\u001B\u0007\u0014.\u0018(ref enumerator3))
						{
							PaperSize paperSize = \u000E\u0007\u0014.\u0018(ref enumerator3);
							if (\u001B\u0013\u0018.\u0018(\u0005\u0007\u0014.\u0018(paperSize), \u0014, true))
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
								u8 = paperSize;
								goto IL_43B;
							}
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
						((IDisposable)enumerator3).Dispose();
					}
					IL_43B:
					\u0001\u0007\u0014.\u0018(\u0006\u0007\u0014.\u0018(\u0008\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(printManager))), u8);
					\u000F\u000A\u0018.\u000A\u0018(\u0003, printManager);
					\u0019\u0007\u0014.\u0018(printManager);
					\u001A\u0007\u0014.\u0018(\u000B\u0007\u0014.\u0018(printManager));
				}
				catch (Exception u9)
				{
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u9, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinePdfV1");
				}
				if (\u000C\u001A\u0018.\u0018(text))
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
					try
					{
						\u000C\u0020\u0014.\u0018(text);
					}
					catch (Exception)
					{
						IEnumerable<SheetInfo> enumerable3 = \u001C\u0017\u0014.\u0018();
						Func<SheetInfo, bool> func3;
						if ((func3 = \u000F\u000A\u0018.<>c.\u000A) == null)
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
							func3 = (\u000F\u000A\u0018.<>c.\u000A = new Func<SheetInfo, bool>(\u000F\u000A\u0018.<>c.\u000C.\u0010));
						}
						object u000C10 = Enumerable.ToList<SheetInfo>(Enumerable.Where<SheetInfo>(enumerable3, func3));
						Action<SheetInfo> u10;
						if ((u10 = \u000F\u000A\u0018.<>c.\u0020) == null)
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
							u10 = (\u000F\u000A\u0018.<>c.\u0020 = new Action<SheetInfo>(\u000F\u000A\u0018.<>c.\u000C.\u0006));
						}
						\u0020\u0005\u0018.\u0018(u000C10, u10);
						throw \u0004\u0007\u0014.\u0018(\u000D\u0009\u0018.\u000F\u0003);
					}
				}
				\u001D\u0007\u0014.\u0018(printManager);
				flag2 = true;
				\u0013\u0017\u0014.\u0018(2000);
				this.\u0012\u0018(\u000C);
				this.\u0018 = false;
				\u0013\u0017\u0014.\u0018(500);
				if (\u0003\u001F\u0018.\u0014())
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
					\u001D\u0015\u0014.\u0018(true);
					throw \u0013\u001B\u0014.\u0018(\u001C\u0009\u0018.\u0016\u0003);
				}
				PDFFile pdffile = \u0002\u0007\u0014.\u0018();
				\u001E\u0007\u0014.\u0018(pdffile, u2);
				\u0017\u0007\u0014.\u0018(pdffile, text);
				\u0015\u0007\u0014.\u0018(\u001A\u0009\u0018.\u0018, pdffile);
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinePdfV1");
				result = true;
			}
			catch (Exception u11)
			{
				if (flag)
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
					if (!flag2)
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
						\u0019\u0017\u0014.\u0018(Create.objFaildFile, text2);
					}
				}
				if (this.\u0018)
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
					this.\u0012\u0018(\u000C);
					this.\u0018 = false;
				}
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u11, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportCombinePdfV1");
				result = false;
			}
			return result;
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x00020B64 File Offset: 0x0001ED64
		private string \u0008\u0018(string \u000C, string \u0018, string \u0014, string \u0003, bool \u0016, List<SheetInfo> \u000F)
		{
			\u000F\u000A\u0018.\u0003\u000A\u0018 u0003_u000A_u = new \u000F\u000A\u0018.\u0003\u000A\u0018();
			string text = \u001E\u001B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0014, "./", "--"), '/', '-');
			\u0010\u0017\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0015\u0010\u0014.\u0018(), "%DrawingName%", text));
			string text2 = \u0010\u000B\u0014.\u0018(\u000C, "%DrawingName%", text);
			text = \u000D\u001E\u0018.\u0018(text, \u0003);
			string text3;
			if (!\u0016)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0008\u0018(string, string, string, string, bool, List<SheetInfo>)).MethodHandle;
				}
				text3 = text2;
			}
			else
			{
				text3 = \u0003\u001A\u0018.\u0018(text2, \u0018);
			}
			string text4 = text3;
			text4 = \u000C\u000A\u0018.\u0008(\u0017\u001B\u0014.\u0018(), text4);
			text4 = \u0003\u001A\u0018.\u0018(text4, text);
			u0003_u000A_u.\u000C = string.Empty;
			if (\u001C\u0002\u0018.\u0014(text4) > 259)
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
				u0003_u000A_u.\u000C = \u001C\u0009\u0018.\u000E\u0014;
			}
			try
			{
				\u0015\u001B\u0014.\u0018(text4);
			}
			catch (Exception ex)
			{
				u0003_u000A_u.\u000C = \u000A\u0001\u0018.\u0018(ex);
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "GetCombinedFileName");
			}
			\u0020\u0005\u0018.\u0018(\u000F, new Action<SheetInfo>(u0003_u000A_u.\u0018));
			return text4;
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x00020C90 File Offset: 0x0001EE90
		public static bool \u0001\u0018(string \u000C)
		{
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "CheckFolderExists");
				if (!\u0012\u0006\u0018.\u0018(\u000C))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0001\u0018(string)).MethodHandle;
					}
					\u000F\u0006\u0018.\u0018(\u000C);
				}
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "CheckFolderExists");
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "CheckFolderExists");
			return true;
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x00020D18 File Offset: 0x0001EF18
		public bool \u001B\u0018(Document \u000C, View \u0018, string \u0014, SheetInfo \u0003, bool \u0016, \u0016\u0020\u0018 \u000F = null)
		{
			\u0002\u001B\u0014.\u0018(true);
			try
			{
				return this.\u0005\u0018(\u000C, \u0018, \u0014, \u0003, \u0016);
			}
			catch (Exception ex)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportIFC");
				\u0018\u0017\u0014.\u0014(\u0003, \u000A\u0001\u0018.\u0018(ex));
			}
			\u0002\u001B\u0014.\u0018(false);
			return false;
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x00020D80 File Offset: 0x0001EF80
		private bool \u0005\u0018(Document \u000C, View \u0018, string \u0014, SheetInfo \u0003, bool \u0016)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportIFCInternal");
			\u0004\u001B\u0014.\u0018(\u0016);
			UIDocument u000C = \u0011\u0005\u0018.\u0018();
			\u0009\u0017\u0014.\u0018(\u0003, \u0019\u0015\u0014.\u0018());
			bool result = false;
			try
			{
				string u000F;
				IFCFileFormat ifcfileFormat;
				\u000E\u001F\u0018.\u000C(\u0016\u000E\u0014.\u0018(), out u000F, out ifcfileFormat);
				\u001F\u0010\u0014.\u0018(\u0003, \u0018, \u0015\u0010\u0014.\u0018(), "IFC", \u0014, u000F, \u0011\u0010\u0014.\u0018());
				if (!\u001F\u001A\u0018.\u0018(\u0014\u0017\u0014.\u0018(\u0003)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0005\u0018(Document, View, string, SheetInfo, bool)).MethodHandle;
					}
					return false;
				}
				IFCExportOptions ifcexportOptions = \u0003\u000E\u0014.\u0018();
				\u0018\u000E\u0014.\u0018(ifcexportOptions, \u0014\u000E\u0014.\u0018());
				\u0007\u001E\u0018.\u0018(ifcexportOptions, "FileType", ifcfileFormat.ToString());
				\u0007\u001E\u0018.\u0018(ifcexportOptions, "IFCFileType", ifcfileFormat.ToString());
				if (\u000E\u001F\u0018.\u0003(\u000E\u0005\u0014.\u0018(\u000C\u000E\u0014.\u0018()).\u0018()))
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
					object u000C2 = ifcexportOptions;
					string u = "ActivePhaseId";
					long num = \u000E\u0005\u0014.\u0018(\u000C\u000E\u0014.\u0018());
					\u0007\u001E\u0018.\u0018(u000C2, u, \u0005\u0005\u0014.\u0018(ref num));
					object u000C3 = ifcexportOptions;
					string u2 = "ActivePhase";
					num = \u000E\u0005\u0014.\u0018(\u000C\u000E\u0014.\u0018());
					\u0007\u001E\u0018.\u0018(u000C3, u2, \u0005\u0005\u0014.\u0018(ref num));
				}
				\u0007\u001E\u0018.\u0018(ifcexportOptions, "SpaceBoundaries", \u000E\u001F\u0018.\u0018(\u001B\u0005\u0014.\u0018()));
				\u0007\u001E\u0018.\u0018(ifcexportOptions, "SitePlacement", \u000E\u001F\u0018.\u0014(\u0001\u0005\u0014.\u0018()));
				\u0006\u0005\u0014.\u0018(ifcexportOptions, \u0008\u0005\u0014.\u0018());
				object u000C4 = ifcexportOptions;
				string u3 = "IncludeSteelElements";
				bool flag = \u0010\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C4, u3, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C5 = ifcexportOptions;
				string u4 = "Export2DElements";
				flag = \u0007\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C5, u4, \u0001\u001B\u0014.\u0018(ref flag));
				IFCLinkedDocumentExporter u000C6 = \u0019\u0005\u0014.\u0018(\u000C, ifcexportOptions, IocContainer.GetService<ICustomLogger>());
				if (!\u0016)
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
					\u000B\u0005\u0014.\u0018(u000C6, \u0019\u001B\u0014.\u0018());
				}
				object u000C7 = ifcexportOptions;
				string u5 = "VisibleElementsOfCurrentView";
				flag = \u0006\u001B\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C7, u5, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C8 = ifcexportOptions;
				string u6 = "ExportRoomsInView";
				flag = \u001A\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C8, u6, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C9 = ifcexportOptions;
				string u7 = "ExportInternalRevitPropertySets";
				flag = \u001D\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C9, u7, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C10 = ifcexportOptions;
				string u8 = "ExportIFCCommonPropertySets";
				flag = \u0004\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C10, u8, \u0001\u001B\u0014.\u0018(ref flag));
				\u001E\u0005\u0014.\u0018(ifcexportOptions, \u0002\u0005\u0014.\u0018());
				object u000C11 = ifcexportOptions;
				string u9 = "ExportSchedulesAsPsets";
				flag = \u0017\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C11, u9, \u0001\u001B\u0014.\u0018(ref flag));
				if (\u0017\u0005\u0014.\u0018())
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
					object u000C12 = ifcexportOptions;
					string u10 = "ExportSpecificSchedules";
					flag = \u0015\u0005\u0014.\u0018();
					\u0007\u001E\u0018.\u0018(u000C12, u10, \u0001\u001B\u0014.\u0018(ref flag));
				}
				else
				{
					\u0007\u001E\u0018.\u0018(ifcexportOptions, "ExportSchedulesAsPsets", "false");
				}
				object u000C13 = ifcexportOptions;
				string u11 = "ExportUserDefinedPsets";
				flag = \u0011\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C13, u11, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C14 = ifcexportOptions;
				string u12 = "UseTypePropertiesInInstacePSets";
				flag = \u001F\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C14, u12, \u0001\u001B\u0014.\u0018(ref flag));
				\u0007\u001E\u0018.\u0018(ifcexportOptions, "ExportUserDefinedPsetsFileName", \u0020\u0005\u0014.\u0018());
				object u000C15 = ifcexportOptions;
				string u13 = "ExportUserDefinedParameterMapping";
				flag = \u000A\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C15, u13, \u0001\u001B\u0014.\u0018(ref flag));
				\u0007\u001E\u0018.\u0018(ifcexportOptions, "ExportUserDefinedParameterMappingFileName", \u0009\u0005\u0014.\u0018());
				double num2 = 0.0;
				if (\u0013\u0005\u0014.\u0018() != -1.0)
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
					num2 = \u0013\u0005\u0014.\u0018();
				}
				else
				{
					num2 = \u000E\u001F\u0018.\u0016(\u001C\u0005\u0014.\u0018());
				}
				\u0007\u001E\u0018.\u0018(ifcexportOptions, "TessellationLevelOfDetail", \u000D\u0005\u0014.\u0018(ref num2));
				object u000C16 = ifcexportOptions;
				string u14 = "ExportPartsAsBuildingElements";
				flag = \u0012\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C16, u14, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C17 = ifcexportOptions;
				string u15 = "ExportSolidModelRep";
				flag = \u000F\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C17, u15, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C18 = ifcexportOptions;
				string u16 = "UseFamilyAndTypeNameForReference";
				flag = \u0016\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C18, u16, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C19 = ifcexportOptions;
				string u17 = "Use2DRoomBoundaryForVolume";
				flag = \u0003\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C19, u17, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C20 = ifcexportOptions;
				string u18 = "IncludeSiteElevation";
				flag = \u0014\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C20, u18, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C21 = ifcexportOptions;
				string u19 = "StoreIFCGUID";
				flag = \u0018\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C21, u19, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C22 = ifcexportOptions;
				string u20 = "ExportBoundingBox";
				flag = \u000C\u0005\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C22, u20, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C23 = ifcexportOptions;
				string u21 = "UseOnlyTriangulation";
				flag = \u000E\u001B\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C23, u21, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C24 = ifcexportOptions;
				string u22 = "UseActiveViewGeometry";
				flag = \u0008\u001B\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C24, u22, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C25 = ifcexportOptions;
				string u23 = "UseTypeNameOnlyForIfcType";
				flag = \u0005\u001B\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C25, u23, \u0001\u001B\u0014.\u0018(ref flag));
				object u000C26 = ifcexportOptions;
				string u24 = "UseVisibleRevitNameAsEntityName";
				flag = \u001B\u001B\u0014.\u0018();
				\u0007\u001E\u0018.\u0018(u000C26, u24, \u0001\u001B\u0014.\u0018(ref flag));
				if (!\u0016)
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
					if (\u0008\u001B\u0014.\u0018())
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
						\u0007\u001E\u0018.\u0018(ifcexportOptions, "ActiveViewId", \u0001\u0017\u0018.\u0018(\u0009\u0002\u0018.\u0018(\u0017\u0010\u0014.\u0018(u000C))));
					}
					if (\u0006\u001B\u0014.\u0018())
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
						\u000C\u001D\u0018.\u0018(ifcexportOptions, \u0009\u0002\u0018.\u0018(\u0018));
					}
				}
				\u0010\u001B\u0014.\u0018(\u000C, \u0007\u001B\u0014.\u0018());
				\u001A\u0011\u0018.\u000C(ifcexportOptions, \u0007\u001B\u0014.\u0018());
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Start export Single IFC", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportIFCInternal");
				this.\u000F\u0018(\u000C);
				this.\u0018 = true;
				\u0004\u001E\u0018.\u0018(\u000C, \u0019\u001E\u0018.\u0018(\u0014\u001B\u0014.\u0014(\u0003)), \u000A\u0010\u0014.\u0018(\u0003), ifcexportOptions);
				\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "End export Single IFC", "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportIFCInternal");
				this.\u0012\u0018(\u000C);
				this.\u0018 = false;
				\u000B\u001B\u0014.\u0018(u000C6, \u0014\u001B\u0014.\u0014(\u0003), \u0019\u001B\u0014.\u0018());
				if (\u001A\u001B\u0014.\u0018())
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
					result = false;
					\u001D\u001B\u0014.\u0018(false);
				}
				else
				{
					result = true;
				}
			}
			catch (Exception ex)
			{
				if (this.\u0018)
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
					this.\u0012\u0018(\u000C);
					this.\u0018 = false;
				}
				result = false;
				\u0018\u0017\u0014.\u0014(\u0003, \u000A\u0001\u0018.\u0018(ex));
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportIFCInternal");
			}
			\u000E\u0015\u0014.\u0018(\u0003, \u0019\u0015\u0014.\u0018());
			\u0004\u001B\u0014.\u0018(false);
			return result;
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x00021444 File Offset: 0x0001F644
		public bool \u000E\u0018(Document \u000C, View \u0018, string \u0014, SheetInfo \u0003)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportNWC");
			bool result = false;
			\u001F\u0010\u0014.\u0018(\u0003, \u0018, \u0015\u0010\u0014.\u0018(), "NWC", \u0014, ".nwc", \u0011\u0010\u0014.\u0018());
			try
			{
				if (\u0018\u0011\u0018.\u000C(\u000C, \u0018))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u000E\u0018(Document, View, string, SheetInfo)).MethodHandle;
					}
					\u0018\u0017\u0014.\u0014(\u0003, \u001C\u0009\u0018.\u0014\u000F);
					return false;
				}
				if (!\u001F\u001A\u0018.\u0018(\u0014\u0017\u0014.\u0018(\u0003)))
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
					if (this.\u0018)
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
						this.\u0018 = false;
					}
					return false;
				}
				NavisworksExportOptions navisworksExportOptions = \u0016\u000C\u0003.\u0018();
				\u0014\u000C\u0003.\u0018(navisworksExportOptions, \u0003\u000C\u0003.\u0018());
				\u000C\u000C\u0003.\u0018(navisworksExportOptions, \u0018\u000C\u0003.\u0018());
				\u0005\u000E\u0014.\u0018(navisworksExportOptions, \u000E\u000E\u0014.\u0018());
				\u0001\u000E\u0014.\u0018(navisworksExportOptions, \u001B\u000E\u0014.\u0018());
				\u0006\u000E\u0014.\u0018(navisworksExportOptions, \u0008\u000E\u0014.\u0018());
				\u0007\u000E\u0014.\u0018(navisworksExportOptions, \u0010\u000E\u0014.\u0018());
				\u000B\u000E\u0014.\u0018(navisworksExportOptions, \u0019\u000E\u0014.\u0018());
				\u001D\u000E\u0014.\u0018(navisworksExportOptions, \u001A\u000E\u0014.\u0018());
				\u0002\u000E\u0014.\u0018(navisworksExportOptions, \u0004\u000E\u0014.\u0018());
				\u0017\u000E\u0014.\u0018(navisworksExportOptions, \u001E\u000E\u0014.\u0018());
				\u0011\u000E\u0014.\u0018(navisworksExportOptions, \u0015\u000E\u0014.\u0018());
				\u0020\u000E\u0014.\u0018(navisworksExportOptions, \u001F\u000E\u0014.\u0018());
				\u0009\u000E\u0014.\u0018(navisworksExportOptions, \u000A\u000E\u0014.\u0018());
				\u001C\u000E\u0014.\u0018(navisworksExportOptions, \u0013\u000E\u0014.\u0018());
				\u000D\u000E\u0014.\u0018(navisworksExportOptions, 1);
				\u0012\u000E\u0014.\u0018(navisworksExportOptions, \u0009\u0002\u0018.\u0018(\u0018));
				\u000F\u000E\u0014.\u0018(\u000C, \u0019\u001E\u0018.\u0018(\u0014\u001B\u0014.\u0014(\u0003)), \u0004\u0006\u0014.\u0018(\u000A\u0010\u0014.\u0018(\u0003)), navisworksExportOptions);
				result = true;
			}
			catch (Exception ex)
			{
				result = false;
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportNWC");
				\u0018\u0017\u0014.\u0014(\u0003, \u000A\u0001\u0018.\u0018(ex));
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportNWC");
			return result;
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00021658 File Offset: 0x0001F858
		public bool \u000C\u0014(Document \u000C, string \u0018, string \u0014, string \u0003, string \u0016, List<SheetInfo> \u000F, bool \u0012 = false)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportPdfUsingRevit");
			bool flag = false;
			TransactionGroup transactionGroup = \u0011\u0007\u0014.\u0018(\u000C);
			bool result;
			try
			{
				\u001F\u0007\u0014.\u0018(transactionGroup, "Export Pdf");
				try
				{
					string text = string.Empty;
					\u001E\u0010\u0014.\u0018(\u000F\u0010\u0014.\u0018() + 1);
					Func<SheetInfo, ElementId> func;
					if ((func = \u000F\u000A\u0018.<>c.\u001F) == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u000C\u0014(Document, string, string, string, string, List<SheetInfo>, bool)).MethodHandle;
						}
						func = (\u000F\u000A\u0018.<>c.\u001F = new Func<SheetInfo, ElementId>(\u000F\u000A\u0018.<>c.\u000C.\u0008));
					}
					List<ElementId> list = Enumerable.ToList<ElementId>(Enumerable.Distinct<ElementId>(Enumerable.Select<SheetInfo, ElementId>(\u000F, func)));
					View u = \u0018\u0002\u000F.\u000C(\u0003\u0004\u0018.\u0018(\u000C, \u0012\u000C\u0003.\u0018(list, 0)));
					string text2;
					if (!\u0012)
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
						text2 = \u001F\u0010\u0014.\u0018(\u000F\u000C\u0003.\u0018(\u000F, 0), u, \u0015\u0010\u0014.\u0018(), "PDF", \u0014, \u0018, \u0011\u0010\u0014.\u0018());
					}
					else
					{
						text2 = this.\u0008\u0018(\u0015\u0010\u0014.\u0018(), "PDF", \u0016\u001B\u0014.\u0018(), \u0018, \u0011\u0010\u0014.\u0018(), \u000F);
					}
					text = text2;
					\u0014 = \u000B\u001E\u0018.\u0018(text);
					Func<SheetInfo, bool> func2;
					if ((func2 = \u000F\u000A\u0018.<>c.\u0011) == null)
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
						func2 = (\u000F\u000A\u0018.<>c.\u0011 = new Func<SheetInfo, bool>(\u000F\u000A\u0018.<>c.\u000C.\u0001));
					}
					if (Enumerable.Any<SheetInfo>(\u000F, func2))
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
						result = false;
					}
					else
					{
						PDFExportOptions u2 = new \u000A\u0020\u0018().\u0018(\u0014, \u0003, \u0016, \u0012);
						\u0013\u0020\u0018 u0013_u0020_u = new \u0013\u0020\u0018();
						List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u000F);
						try
						{
							while (\u0019\u000E\u0018.\u0018(ref enumerator))
							{
								SheetInfo u000C = \u000C\u000C\u0014.\u0018(ref enumerator);
								\u0007\u0006\u0014.\u0014(u000C, \u0014);
								\u0006\u0006\u0014.\u0014(u000C, text);
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
						result = u0013_u0020_u.\u000C(\u000C, text, list, u2);
					}
				}
				catch (Exception ex)
				{
					\u000F\u000A\u0018.\u0016\u000A\u0018 u0016_u000A_u = new \u000F\u000A\u0018.\u0016\u000A\u0018();
					Exception u000C2 = ex;
					u0016_u000A_u.\u000C = u000C2;
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
						\u0019\u0017\u0014.\u0018(Create.objFaildFile, \u0014);
					}
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u0016_u000A_u.\u000C, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportPdfUsingRevit");
					\u0020\u0005\u0018.\u0018(\u000F, new Action<SheetInfo>(u0016_u000A_u.\u0018));
					result = false;
				}
				finally
				{
					\u0020\u0007\u0014.\u0018(transactionGroup);
					\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RevitHelper.cs", "ExportPdfUsingRevit");
				}
			}
			finally
			{
				if (transactionGroup != null)
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
					\u0020\u001E\u0018.\u0018(transactionGroup);
				}
			}
			return result;
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x00021930 File Offset: 0x0001FB30
		private static string \u0018\u0014(SheetInfo \u000C)
		{
			if (!\u001F\u000B\u0018.\u0018(\u000D\u000C\u0003.\u0014(\u000C)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0018\u0014(SheetInfo)).MethodHandle;
				}
				return \u000D\u000C\u0003.\u0014(\u000C);
			}
			return \u0015\u0010\u0014.\u0018();
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x00021974 File Offset: 0x0001FB74
		public static List<View> \u0014\u0014(Document \u000C, View \u0018)
		{
			List<View> list = \u000C\u001E\u0014.\u0018();
			\u0017\u000B\u0014.\u0018(list, \u0018);
			ViewSheet viewSheet = \u000E\u001A\u000F.\u000C(\u0018);
			if (viewSheet != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u000A\u0018.\u0014\u0014(Document, View)).MethodHandle;
				}
				IEnumerator<ElementId> enumerator = \u0015\u001E\u0018.\u0018(\u001C\u000C\u0003.\u0018(viewSheet));
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						ElementId u = \u0011\u001E\u0018.\u0018(enumerator);
						\u0017\u000B\u0014.\u0018(list, \u0018\u0002\u000F.\u000C(\u0003\u0004\u0018.\u0018(\u000C, u)));
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
					if (enumerator != null)
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
						\u0020\u001E\u0018.\u0018(enumerator);
					}
				}
			}
			return list;
		}

		// Token: 0x040001DF RID: 479
		private Transaction \u000C;

		// Token: 0x040001E0 RID: 480
		private bool \u0018;

		// Token: 0x040001E1 RID: 481
		[CompilerGenerated]
		private static string \u0014;

		// Token: 0x040001E2 RID: 482
		[CompilerGenerated]
		private static bool \u0003;

		// Token: 0x040001E3 RID: 483
		[CompilerGenerated]
		private static int \u0016;

		// Token: 0x040001E4 RID: 484
		[CompilerGenerated]
		private static string \u000F;

		// Token: 0x040001E5 RID: 485
		[CompilerGenerated]
		private static PaperPlacementType \u0012;

		// Token: 0x040001E6 RID: 486
		[CompilerGenerated]
		private static MarginType \u000D;

		// Token: 0x040001E7 RID: 487
		[CompilerGenerated]
		private static double \u001C;

		// Token: 0x040001E8 RID: 488
		[CompilerGenerated]
		private static double \u0013;

		// Token: 0x040001E9 RID: 489
		[CompilerGenerated]
		private static ZoomType \u0009;

		// Token: 0x040001EA RID: 490
		[CompilerGenerated]
		private static int \u000A;

		// Token: 0x040001EB RID: 491
		[CompilerGenerated]
		private static HiddenLineViewsType \u0020;

		// Token: 0x040001EC RID: 492
		[CompilerGenerated]
		private static RasterQualityType \u001F;

		// Token: 0x040001ED RID: 493
		[CompilerGenerated]
		private static ColorDepthType \u0011;

		// Token: 0x040001EE RID: 494
		[CompilerGenerated]
		private static bool \u0015;

		// Token: 0x040001EF RID: 495
		[CompilerGenerated]
		private static bool \u0017;

		// Token: 0x040001F0 RID: 496
		[CompilerGenerated]
		private static bool \u001E;

		// Token: 0x040001F1 RID: 497
		[CompilerGenerated]
		private static string \u0002;

		// Token: 0x040001F2 RID: 498
		[CompilerGenerated]
		private static string \u0004;

		// Token: 0x040001F3 RID: 499
		[CompilerGenerated]
		private static bool \u001D;

		// Token: 0x040001F4 RID: 500
		[CompilerGenerated]
		private static bool \u001A;

		// Token: 0x040001F5 RID: 501
		[CompilerGenerated]
		private static bool \u000B;

		// Token: 0x040001F6 RID: 502
		[CompilerGenerated]
		private static bool \u0019;

		// Token: 0x040001F7 RID: 503
		[CompilerGenerated]
		private static bool \u0007;

		// Token: 0x040001F8 RID: 504
		[CompilerGenerated]
		private static bool \u0010;

		// Token: 0x040001F9 RID: 505
		[CompilerGenerated]
		private static bool \u0006;

		// Token: 0x040001FA RID: 506
		[CompilerGenerated]
		private static string \u0008;

		// Token: 0x040001FB RID: 507
		[CompilerGenerated]
		private static string \u0001;

		// Token: 0x040001FC RID: 508
		[CompilerGenerated]
		private static string \u001B;

		// Token: 0x040001FD RID: 509
		[CompilerGenerated]
		private static List<SheetInfo> \u0005;

		// Token: 0x040001FE RID: 510
		[CompilerGenerated]
		private static bool \u000E;

		// Token: 0x040001FF RID: 511
		[CompilerGenerated]
		private static bool \u000C\u0018;

		// Token: 0x04000200 RID: 512
		[CompilerGenerated]
		private static string \u0018\u0018;

		// Token: 0x04000201 RID: 513
		[CompilerGenerated]
		private static string \u0014\u0018;

		// Token: 0x02000186 RID: 390
		[CompilerGenerated]
		private sealed class \u0018\u000A\u0018
		{
			// Token: 0x060010F5 RID: 4341 RVA: 0x0005B108 File Offset: 0x00059308
			internal bool \u0018(PrintSetting \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001E\u0016\u0014.\u0018(\u000C), this.\u000C);
			}

			// Token: 0x040007D7 RID: 2007
			public string \u000C;
		}

		// Token: 0x02000187 RID: 391
		[CompilerGenerated]
		private sealed class \u0014\u000A\u0018
		{
			// Token: 0x060010F7 RID: 4343 RVA: 0x0005B140 File Offset: 0x00059340
			internal bool \u0018(PrintSetting \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001E\u0016\u0014.\u0018(\u000C), this.\u000C);
			}

			// Token: 0x040007D8 RID: 2008
			public string \u000C;
		}

		// Token: 0x02000188 RID: 392
		[CompilerGenerated]
		private sealed class \u0003\u000A\u0018
		{
			// Token: 0x060010F9 RID: 4345 RVA: 0x0005B178 File Offset: 0x00059378
			internal void \u0018(SheetInfo \u000C)
			{
				\u0018\u0017\u0014.\u0014(\u000C, this.\u000C);
			}

			// Token: 0x040007D9 RID: 2009
			public string \u000C;
		}

		// Token: 0x02000189 RID: 393
		[CompilerGenerated]
		private sealed class \u0016\u000A\u0018
		{
			// Token: 0x060010FB RID: 4347 RVA: 0x0005B1A8 File Offset: 0x000593A8
			internal void \u0018(SheetInfo \u000C)
			{
				\u0018\u0017\u0014.\u0014(\u000C, \u000A\u0001\u0018.\u0018(this.\u000C));
			}

			// Token: 0x040007DA RID: 2010
			public Exception \u000C;
		}
	}
}

using System;
using Autodesk.Revit.DB;
using ProSheets.ScheduleAssistant.Attributes;
using ProSheets.ScheduleAssistant.Model.Enum;

namespace ProSheets
{
	// Token: 0x02000070 RID: 112
	[Serializable]
	public class DWFSettings
	{
		// Token: 0x17000278 RID: 632
		// (get) Token: 0x0600065C RID: 1628 RVA: 0x00025DE0 File Offset: 0x00023FE0
		// (set) Token: 0x0600065D RID: 1629 RVA: 0x00025DF4 File Offset: 0x00023FF4
		[UpdateReport("IsDwfx", TabName.FormatDWF, "Report-DWFFormatOptionWasChanged", true)]
		public bool IsDwfx { get; set; }

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x0600065E RID: 1630 RVA: 0x00025E08 File Offset: 0x00024008
		// (set) Token: 0x0600065F RID: 1631 RVA: 0x00025E1C File Offset: 0x0002401C
		[UpdateReport("PaperSize", TabName.FormatDWF, "Report-DWFPaperSizeWasChanged", false)]
		public ExportPaperFormat PaperSize { get; set; }

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x00025E30 File Offset: 0x00024030
		// (set) Token: 0x06000661 RID: 1633 RVA: 0x00025E44 File Offset: 0x00024044
		[UpdateReport("opt_ImageFormat", TabName.FormatDWF, "Report-ImageFormatOptionWasChanged", false)]
		public DWFImageFormat opt_ImageFormat { get; set; }

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x00025E58 File Offset: 0x00024058
		// (set) Token: 0x06000663 RID: 1635 RVA: 0x00025E6C File Offset: 0x0002406C
		[UpdateReport("opt_ImageQuality", TabName.FormatDWF, "Report-ImageQualityOptionWasChanged", false)]
		public DWFImageQuality opt_ImageQuality { get; set; } = 10;

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x00025E80 File Offset: 0x00024080
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x00025E94 File Offset: 0x00024094
		[UpdateReport("opt_CropBoxVisible", TabName.FormatDWF, "Report-CropboxVisibleOptionWasChanged", false)]
		public bool opt_CropBoxVisible { get; set; }

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x00025EA8 File Offset: 0x000240A8
		// (set) Token: 0x06000667 RID: 1639 RVA: 0x00025EBC File Offset: 0x000240BC
		[UpdateReport("opt_ExportingAreas", TabName.FormatDWF, "Report-RoomsSpacesAndAreasGeometryOptionWasChanged", false)]
		public bool opt_ExportingAreas { get; set; }

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000668 RID: 1640 RVA: 0x00025ED0 File Offset: 0x000240D0
		// (set) Token: 0x06000669 RID: 1641 RVA: 0x00025EE4 File Offset: 0x000240E4
		[UpdateReport("opt_ExportTextures", TabName.FormatDWF, "Report-ExportTexturesOptionWasChanged", false)]
		public bool opt_ExportTextures { get; set; }

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x00025EF8 File Offset: 0x000240F8
		// (set) Token: 0x0600066B RID: 1643 RVA: 0x00025F0C File Offset: 0x0002410C
		[UpdateReport("opt_ExpportObjectData", TabName.FormatDWF, "Report-ExportElementPropertiesOptionWasChanged", false)]
		public bool opt_ExpportObjectData { get; set; }

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x0600066D RID: 1645 RVA: 0x00025F34 File Offset: 0x00024134
		// (set) Token: 0x0600066C RID: 1644 RVA: 0x00025F20 File Offset: 0x00024120
		[UpdateReport("IsCenter", TabName.FormatDWF, "Report-PaperPlacementIsChanged", true)]
		public bool IsCenter { get; set; }

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x0600066F RID: 1647 RVA: 0x00025F5C File Offset: 0x0002415C
		// (set) Token: 0x0600066E RID: 1646 RVA: 0x00025F48 File Offset: 0x00024148
		[UpdateReport("SelectedMarginType", TabName.FormatDWF, "Report-OffsetFromCornerMarginIsChanged", false)]
		public string SelectedMarginType { get; set; } = "No Margin";

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000671 RID: 1649 RVA: 0x00025F84 File Offset: 0x00024184
		// (set) Token: 0x06000670 RID: 1648 RVA: 0x00025F70 File Offset: 0x00024170
		[UpdateReport("OffsetX", TabName.FormatDWF, "Report-OffsetFromCornerMarginXIsChanged", false)]
		public string OffsetX { get; set; } = "0";

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000673 RID: 1651 RVA: 0x00025FAC File Offset: 0x000241AC
		// (set) Token: 0x06000672 RID: 1650 RVA: 0x00025F98 File Offset: 0x00024198
		[UpdateReport("OffsetY", TabName.FormatDWF, "Report-OffsetFromCornerMarginYIsChanged", false)]
		public string OffsetY { get; set; } = "0";

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000675 RID: 1653 RVA: 0x00025FD4 File Offset: 0x000241D4
		// (set) Token: 0x06000674 RID: 1652 RVA: 0x00025FC0 File Offset: 0x000241C0
		[UpdateReport("IsFitToPage", TabName.FormatDWF, "Report-ZoomOptionIsChanged", true)]
		public bool IsFitToPage { get; set; }

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000677 RID: 1655 RVA: 0x00025FFC File Offset: 0x000241FC
		// (set) Token: 0x06000676 RID: 1654 RVA: 0x00025FE8 File Offset: 0x000241E8
		[UpdateReport("IsVectorProcessing", TabName.FormatDWF, "Report-HiddenLineViewsIsChanged", true)]
		public bool IsVectorProcessing { get; set; }

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x00026024 File Offset: 0x00024224
		// (set) Token: 0x06000678 RID: 1656 RVA: 0x00026010 File Offset: 0x00024210
		[UpdateReport("RasterQuality", TabName.FormatDWF, "Report-RasterQualityIsChanged", false)]
		public RasterQualityType RasterQuality { get; set; } = 300;

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x0600067B RID: 1659 RVA: 0x0002604C File Offset: 0x0002424C
		// (set) Token: 0x0600067A RID: 1658 RVA: 0x00026038 File Offset: 0x00024238
		[UpdateReport("Color", TabName.FormatDWF, "Report-ColorIsChanged", false)]
		public string Color { get; set; } = "Color";

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x0600067D RID: 1661 RVA: 0x00026074 File Offset: 0x00024274
		// (set) Token: 0x0600067C RID: 1660 RVA: 0x00026060 File Offset: 0x00024260
		[UpdateReport("ViewLink", TabName.FormatDWF, "Report-ViewLinksInBlueOptionIsChanged", false)]
		public bool ViewLink { get; set; }

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x0600067F RID: 1663 RVA: 0x0002609C File Offset: 0x0002429C
		// (set) Token: 0x0600067E RID: 1662 RVA: 0x00026088 File Offset: 0x00024288
		[UpdateReport("HidePlanes", TabName.FormatDWF, "Report-HideRefWorkPlanesOptionIsChanged", false)]
		public bool HidePlanes { get; set; }

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x000260C4 File Offset: 0x000242C4
		// (set) Token: 0x06000680 RID: 1664 RVA: 0x000260B0 File Offset: 0x000242B0
		[UpdateReport("HideScopeBox", TabName.FormatDWF, "Report-HideScopeBoxesOptionIsChanged", false)]
		public bool HideScopeBox { get; set; }

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x000260EC File Offset: 0x000242EC
		// (set) Token: 0x06000682 RID: 1666 RVA: 0x000260D8 File Offset: 0x000242D8
		[UpdateReport("HideUnreferencedTags", TabName.FormatDWF, "Report-HideUnreferencedViewTagsOptionIsChanged", false)]
		public bool HideUnreferencedTags { get; set; }

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000685 RID: 1669 RVA: 0x00026114 File Offset: 0x00024314
		// (set) Token: 0x06000684 RID: 1668 RVA: 0x00026100 File Offset: 0x00024300
		[UpdateReport("HideCropBoundaries", TabName.FormatDWF, "Report-HideCropBoundariesOptionIsChanged", false)]
		public bool HideCropBoundaries { get; set; }

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000687 RID: 1671 RVA: 0x0002613C File Offset: 0x0002433C
		// (set) Token: 0x06000686 RID: 1670 RVA: 0x00026128 File Offset: 0x00024328
		[UpdateReport("ReplaceHalftone", TabName.FormatDWF, "Report-ReplaceHalftoneWithThinLinesOptionIsChanged", false)]
		public bool ReplaceHalftone { get; set; }

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000689 RID: 1673 RVA: 0x00026164 File Offset: 0x00024364
		// (set) Token: 0x06000688 RID: 1672 RVA: 0x00026150 File Offset: 0x00024350
		[UpdateReport("IsSeparateFile", TabName.FormatDWF, "Report-SeparateFileOptionIsChanged", false)]
		public bool IsSeparateFile { get; set; }

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x0600068B RID: 1675 RVA: 0x0002618C File Offset: 0x0002438C
		// (set) Token: 0x0600068A RID: 1674 RVA: 0x00026178 File Offset: 0x00024378
		[UpdateReport("FilePath", TabName.FormatDWF, "Report-CombinedFileNameWasChanged", false)]
		public bool IsFileNameSet { get; set; }

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x0600068D RID: 1677 RVA: 0x000261B4 File Offset: 0x000243B4
		// (set) Token: 0x0600068C RID: 1676 RVA: 0x000261A0 File Offset: 0x000243A0
		public string FilePath { get; set; }
	}
}

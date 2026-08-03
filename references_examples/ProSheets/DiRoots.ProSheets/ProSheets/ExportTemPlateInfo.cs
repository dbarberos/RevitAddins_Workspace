using System;
using System.Collections.Generic;
using A;
using Autodesk.Revit.DB;
using ProSheets.Commons.CustomNameManageWindow.Models;
using ProSheets.ScheduleAssistant.Attributes;
using ProSheets.ScheduleAssistant.Model.Enum;
using ProSheets.Xml.Models.Dto;

namespace ProSheets
{
	// Token: 0x02000077 RID: 119
	[Serializable]
	public class ExportTemPlateInfo
	{
		// Token: 0x0600071D RID: 1821 RVA: 0x00026DBC File Offset: 0x00024FBC
		public ExportTemPlateInfo()
		{
			\u0003\u0012\u0003.\u0018(this, new List<string>());
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x00026E70 File Offset: 0x00025070
		// (set) Token: 0x0600071F RID: 1823 RVA: 0x00026E84 File Offset: 0x00025084
		public DWFSettings DWF { get; set; } = new DWFSettings();

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000720 RID: 1824 RVA: 0x00026E98 File Offset: 0x00025098
		// (set) Token: 0x06000721 RID: 1825 RVA: 0x00026EAC File Offset: 0x000250AC
		public NWCSettings NWC { get; set; } = new NWCSettings();

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06000722 RID: 1826 RVA: 0x00026EC0 File Offset: 0x000250C0
		// (set) Token: 0x06000723 RID: 1827 RVA: 0x00026ED4 File Offset: 0x000250D4
		public IFCSettings IFC { get; set; } = new IFCSettings();

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000724 RID: 1828 RVA: 0x00026EE8 File Offset: 0x000250E8
		// (set) Token: 0x06000725 RID: 1829 RVA: 0x00026EFC File Offset: 0x000250FC
		public IMGSettings IMG { get; set; } = new IMGSettings();

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000726 RID: 1830 RVA: 0x00026F10 File Offset: 0x00025110
		// (set) Token: 0x06000727 RID: 1831 RVA: 0x00026F24 File Offset: 0x00025124
		public SelectionTemPlateInfo SelectionSheets { get; set; } = new SelectionTemPlateInfo();

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x00026F38 File Offset: 0x00025138
		// (set) Token: 0x06000729 RID: 1833 RVA: 0x00026F4C File Offset: 0x0002514C
		public SelectionTemPlateInfo SelectionViews { get; set; } = new SelectionTemPlateInfo();

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x00026F60 File Offset: 0x00025160
		// (set) Token: 0x0600072B RID: 1835 RVA: 0x00026F74 File Offset: 0x00025174
		public SelectionTemPlateInfo SelectedProjectParameters { get; set; } = new SelectionTemPlateInfo();

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x0600072C RID: 1836 RVA: 0x00026F88 File Offset: 0x00025188
		// (set) Token: 0x0600072D RID: 1837 RVA: 0x00026F9C File Offset: 0x0002519C
		[UpdateReport("SelectSheetParameters", TabName.Selection, "Report-CustomSheetFileNameWasChanged", false)]
		public Parameters SelectSheetParameters { get; set; }

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x0600072E RID: 1838 RVA: 0x00026FB0 File Offset: 0x000251B0
		// (set) Token: 0x0600072F RID: 1839 RVA: 0x00026FC4 File Offset: 0x000251C4
		[UpdateReport("SelectViewParameters", TabName.Selection, "Report-CustomViewFileNameWasChanged", false)]
		public Parameters SelectViewParameters { get; set; }

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000730 RID: 1840 RVA: 0x00026FD8 File Offset: 0x000251D8
		// (set) Token: 0x06000731 RID: 1841 RVA: 0x00026FEC File Offset: 0x000251EC
		[UpdateReport("CustomFileNameParameters", TabName.FormatPDF, "Report-CombinedFileNameWasChanged", false)]
		public Parameters CustomFileNameParameters { get; set; }

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000732 RID: 1842 RVA: 0x00027000 File Offset: 0x00025200
		// (set) Token: 0x06000733 RID: 1843 RVA: 0x00027014 File Offset: 0x00025214
		[UpdateReport("CustomFileNameDWFParameters", TabName.FormatDWF, "Report-CombinedFileNameWasChanged", false)]
		public Parameters CustomFileNameDWFParameters { get; set; }

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000734 RID: 1844 RVA: 0x00027028 File Offset: 0x00025228
		// (set) Token: 0x06000735 RID: 1845 RVA: 0x0002703C File Offset: 0x0002523C
		public string CreateExportFolderPath { get; set; }

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x00027050 File Offset: 0x00025250
		// (set) Token: 0x06000737 RID: 1847 RVA: 0x00027064 File Offset: 0x00025264
		public bool CreateSplitFolder { get; set; }

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06000739 RID: 1849 RVA: 0x0002708C File Offset: 0x0002528C
		// (set) Token: 0x06000738 RID: 1848 RVA: 0x00027078 File Offset: 0x00025278
		[UpdateReport("DWGSettingName", TabName.FormatDWG, "Report-ExportSetupIsChanged", false)]
		public string DWGSettingName { get; set; }

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x0600073A RID: 1850 RVA: 0x000270A0 File Offset: 0x000252A0
		// (set) Token: 0x0600073B RID: 1851 RVA: 0x000270B4 File Offset: 0x000252B4
		[UpdateReport("DWG_MergedViews", TabName.FormatDWG, "Report-ExportViewsOnSheetsAndLinks", false)]
		public bool DWG_MergedViews { get; set; }

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x0600073C RID: 1852 RVA: 0x000270C8 File Offset: 0x000252C8
		// (set) Token: 0x0600073D RID: 1853 RVA: 0x000270DC File Offset: 0x000252DC
		[UpdateReport("DWG_BindImages", TabName.FormatDWG, "Report-BindImagesAsOLEInDWGFile", false)]
		public bool DWG_BindImages { get; set; }

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x000270F0 File Offset: 0x000252F0
		// (set) Token: 0x0600073F RID: 1855 RVA: 0x00027104 File Offset: 0x00025304
		[UpdateReport("CleanPcp", TabName.FormatDWG, "Report-CleanPCPoptionChanged", false)]
		public bool CleanPcp { get; set; }

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06000741 RID: 1857 RVA: 0x0002712C File Offset: 0x0002532C
		// (set) Token: 0x06000740 RID: 1856 RVA: 0x00027118 File Offset: 0x00025318
		[UpdateReport("DGNSettingName", TabName.FormatDGN, "Report-ExportSetupIsChanged", false)]
		public string DGNSettingName { get; set; }

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x00027154 File Offset: 0x00025354
		// (set) Token: 0x06000742 RID: 1858 RVA: 0x00027140 File Offset: 0x00025340
		public List<string> Formats { get; set; }

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000745 RID: 1861 RVA: 0x0002717C File Offset: 0x0002537C
		// (set) Token: 0x06000744 RID: 1860 RVA: 0x00027168 File Offset: 0x00025368
		[UpdateReport("PrinterName", TabName.FormatPDF, "Report-PrinterIsChanged", false)]
		public string PrinterName { get; set; }

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000747 RID: 1863 RVA: 0x000271A4 File Offset: 0x000253A4
		// (set) Token: 0x06000746 RID: 1862 RVA: 0x00027190 File Offset: 0x00025390
		[UpdateReport("ExportSetup", TabName.FormatPDF, "Report-ExportSetupIsChanged", false)]
		public string ExportSetup { get; set; }

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06000749 RID: 1865 RVA: 0x000271CC File Offset: 0x000253CC
		// (set) Token: 0x06000748 RID: 1864 RVA: 0x000271B8 File Offset: 0x000253B8
		public string PaperSize { get; set; }

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x0600074B RID: 1867 RVA: 0x000271F4 File Offset: 0x000253F4
		// (set) Token: 0x0600074A RID: 1866 RVA: 0x000271E0 File Offset: 0x000253E0
		public string PaperSource { get; set; }

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x0600074C RID: 1868 RVA: 0x00027208 File Offset: 0x00025408
		// (set) Token: 0x0600074D RID: 1869 RVA: 0x0002721C File Offset: 0x0002541C
		[UpdateReport("JumpToSection", TabName.FormatPDF, "Report-KeepJumpToSectionOptionIsChanged", false)]
		public bool JumpToSection { get; set; }

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x0600074E RID: 1870 RVA: 0x00027230 File Offset: 0x00025430
		// (set) Token: 0x0600074F RID: 1871 RVA: 0x00027244 File Offset: 0x00025444
		public bool KeepPageSizeAndOrientation { get; set; }

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000751 RID: 1873 RVA: 0x0002726C File Offset: 0x0002546C
		// (set) Token: 0x06000750 RID: 1872 RVA: 0x00027258 File Offset: 0x00025458
		[UpdateReport("IsCenter", TabName.FormatPDF, "Report-PaperPlacementIsChanged", true)]
		public bool IsCenter { get; set; }

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000753 RID: 1875 RVA: 0x00027294 File Offset: 0x00025494
		// (set) Token: 0x06000752 RID: 1874 RVA: 0x00027280 File Offset: 0x00025480
		[UpdateReport("SelectedMarginType", TabName.FormatPDF, "Report-OffsetFromCornerMarginIsChanged", false)]
		public string SelectedMarginType { get; set; } = "No Margin";

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000755 RID: 1877 RVA: 0x000272BC File Offset: 0x000254BC
		// (set) Token: 0x06000754 RID: 1876 RVA: 0x000272A8 File Offset: 0x000254A8
		[UpdateReport("OffsetX", TabName.FormatPDF, "Report-OffsetFromCornerMarginXIsChanged", false)]
		public string OffsetX { get; set; } = "0";

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06000757 RID: 1879 RVA: 0x000272E4 File Offset: 0x000254E4
		// (set) Token: 0x06000756 RID: 1878 RVA: 0x000272D0 File Offset: 0x000254D0
		[UpdateReport("OffsetY", TabName.FormatPDF, "Report-OffsetFromCornerMarginYIsChanged", false)]
		public string OffsetY { get; set; } = "0";

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x0002730C File Offset: 0x0002550C
		// (set) Token: 0x06000758 RID: 1880 RVA: 0x000272F8 File Offset: 0x000254F8
		[UpdateReport("IsFitToPage", TabName.FormatPDF, "Report-ZoomOptionIsChanged", true)]
		public bool IsFitToPage { get; set; }

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x0600075A RID: 1882 RVA: 0x00027320 File Offset: 0x00025520
		// (set) Token: 0x0600075B RID: 1883 RVA: 0x00027334 File Offset: 0x00025534
		[UpdateReport("Zoom", TabName.FormatPDF, "Report-ZoomValueIsChanged", false)]
		public int Zoom { get; set; } = 100;

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x0002735C File Offset: 0x0002555C
		// (set) Token: 0x0600075C RID: 1884 RVA: 0x00027348 File Offset: 0x00025548
		public bool IsPortrait { get; set; }

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x00027384 File Offset: 0x00025584
		// (set) Token: 0x0600075E RID: 1886 RVA: 0x00027370 File Offset: 0x00025570
		[UpdateReport("IsVectorProcessing", TabName.FormatPDF, "Report-HiddenLineViewsIsChanged", true)]
		public bool IsVectorProcessing { get; set; }

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000760 RID: 1888 RVA: 0x00027398 File Offset: 0x00025598
		// (set) Token: 0x06000761 RID: 1889 RVA: 0x000273AC File Offset: 0x000255AC
		[UpdateReport("RasterQuality", TabName.FormatPDF, "Report-RasterQualityIsChanged", false)]
		public RasterQualityType RasterQuality { get; set; } = 72;

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x000273D4 File Offset: 0x000255D4
		// (set) Token: 0x06000762 RID: 1890 RVA: 0x000273C0 File Offset: 0x000255C0
		[UpdateReport("Color", TabName.FormatPDF, "Report-ColorIsChanged", false)]
		public string Color { get; set; } = "Color";

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000765 RID: 1893 RVA: 0x000273FC File Offset: 0x000255FC
		// (set) Token: 0x06000764 RID: 1892 RVA: 0x000273E8 File Offset: 0x000255E8
		[UpdateReport("ViewLink", TabName.FormatPDF, "Report-ViewLinksInBlueOptionIsChanged", false)]
		public bool ViewLink { get; set; }

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000767 RID: 1895 RVA: 0x00027424 File Offset: 0x00025624
		// (set) Token: 0x06000766 RID: 1894 RVA: 0x00027410 File Offset: 0x00025610
		[UpdateReport("HidePlanes", TabName.FormatPDF, "Report-HideRefWorkPlanesOptionIsChanged", false)]
		public bool HidePlanes { get; set; }

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000769 RID: 1897 RVA: 0x0002744C File Offset: 0x0002564C
		// (set) Token: 0x06000768 RID: 1896 RVA: 0x00027438 File Offset: 0x00025638
		[UpdateReport("HideScopeBox", TabName.FormatPDF, "Report-HideScopeBoxesOptionIsChanged", false)]
		public bool HideScopeBox { get; set; }

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x00027474 File Offset: 0x00025674
		// (set) Token: 0x0600076A RID: 1898 RVA: 0x00027460 File Offset: 0x00025660
		[UpdateReport("HideUnreferencedTags", TabName.FormatPDF, "Report-HideUnreferencedViewTagsOptionIsChanged", false)]
		public bool HideUnreferencedTags { get; set; }

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x0600076D RID: 1901 RVA: 0x0002749C File Offset: 0x0002569C
		// (set) Token: 0x0600076C RID: 1900 RVA: 0x00027488 File Offset: 0x00025688
		[UpdateReport("HideCropBoundaries", TabName.FormatPDF, "Report-HideCropBoundariesOptionIsChanged", false)]
		public bool HideCropBoundaries { get; set; }

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x0600076F RID: 1903 RVA: 0x000274C4 File Offset: 0x000256C4
		// (set) Token: 0x0600076E RID: 1902 RVA: 0x000274B0 File Offset: 0x000256B0
		[UpdateReport("ReplaceHalftone", TabName.FormatPDF, "Report-ReplaceHalftoneWithThinLinesOptionIsChanged", false)]
		public bool ReplaceHalftone { get; set; }

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x000274D8 File Offset: 0x000256D8
		// (set) Token: 0x06000771 RID: 1905 RVA: 0x000274EC File Offset: 0x000256EC
		[UpdateReport("MaskCoincidentLines", TabName.FormatPDF, "Report-RegionEdgesMaskCoincidentOptionIsChanged", false)]
		public bool MaskCoincidentLines { get; set; }

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000773 RID: 1907 RVA: 0x00027514 File Offset: 0x00025714
		// (set) Token: 0x06000772 RID: 1906 RVA: 0x00027500 File Offset: 0x00025700
		[UpdateReport("IsSeparateFile", TabName.FormatPDF, "Report-SeparateFileOptionIsChanged", false)]
		public bool IsSeparateFile { get; set; }

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x0002753C File Offset: 0x0002573C
		// (set) Token: 0x06000774 RID: 1908 RVA: 0x00027528 File Offset: 0x00025728
		[UpdateReport("IsPDFChecked", TabName.Format, "Report-PDFOptionIsChanged", false)]
		public bool IsPDFChecked { get; set; }

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06000777 RID: 1911 RVA: 0x00027564 File Offset: 0x00025764
		// (set) Token: 0x06000776 RID: 1910 RVA: 0x00027550 File Offset: 0x00025750
		[UpdateReport("IsDWGChecked", TabName.Format, "Report-DWGOptionIsChanged", false)]
		public bool IsDWGChecked { get; set; }

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x0002758C File Offset: 0x0002578C
		// (set) Token: 0x06000778 RID: 1912 RVA: 0x00027578 File Offset: 0x00025778
		[UpdateReport("IsDGNChecked", TabName.Format, "Report-DGNOptionIsChanged", false)]
		public bool IsDGNChecked { get; set; }

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x0600077B RID: 1915 RVA: 0x000275B4 File Offset: 0x000257B4
		// (set) Token: 0x0600077A RID: 1914 RVA: 0x000275A0 File Offset: 0x000257A0
		[UpdateReport("IsDWFChecked", TabName.Format, "Report-DWFOptionIsChanged", false)]
		public bool IsDWFChecked { get; set; }

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x0600077D RID: 1917 RVA: 0x000275DC File Offset: 0x000257DC
		// (set) Token: 0x0600077C RID: 1916 RVA: 0x000275C8 File Offset: 0x000257C8
		[UpdateReport("IsNWCChecked", TabName.Format, "Report-NWCOptionIsChanged", false)]
		public bool IsNWCChecked { get; set; }

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x00027604 File Offset: 0x00025804
		// (set) Token: 0x0600077E RID: 1918 RVA: 0x000275F0 File Offset: 0x000257F0
		[UpdateReport("IsIFCChecked", TabName.Format, "Report-IFCOptionIsChanged", false)]
		public bool IsIFCChecked { get; set; }

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06000781 RID: 1921 RVA: 0x0002762C File Offset: 0x0002582C
		// (set) Token: 0x06000780 RID: 1920 RVA: 0x00027618 File Offset: 0x00025818
		[UpdateReport("IsIMGChecked", TabName.Format, "Report-ImageOptionIsChanged", false)]
		public bool IsIMGChecked { get; set; }

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06000783 RID: 1923 RVA: 0x00027654 File Offset: 0x00025854
		// (set) Token: 0x06000782 RID: 1922 RVA: 0x00027640 File Offset: 0x00025840
		[UpdateReport("IsXmlChecked", TabName.Format, "PS-XML-Report-XmlOptionChanged", false)]
		public bool IsXmlChecked { get; set; }

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06000784 RID: 1924 RVA: 0x00027668 File Offset: 0x00025868
		// (set) Token: 0x06000785 RID: 1925 RVA: 0x0002767C File Offset: 0x0002587C
		public XmlParameterDto XmlExporter { get; set; } = new XmlParameterDto();

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06000787 RID: 1927 RVA: 0x000276A4 File Offset: 0x000258A4
		// (set) Token: 0x06000786 RID: 1926 RVA: 0x00027690 File Offset: 0x00025890
		public bool IsFileNameSet { get; set; }

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000788 RID: 1928 RVA: 0x000276B8 File Offset: 0x000258B8
		// (set) Token: 0x06000789 RID: 1929 RVA: 0x000276CC File Offset: 0x000258CC
		public string FileName { get; set; }
	}
}

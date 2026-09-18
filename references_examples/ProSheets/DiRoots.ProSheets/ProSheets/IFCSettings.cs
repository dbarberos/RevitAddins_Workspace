using System;
using A;
using Autodesk.Revit.DB;
using ProSheets.ScheduleAssistant.Attributes;
using ProSheets.ScheduleAssistant.Model.Enum;

namespace ProSheets
{
	// Token: 0x02000073 RID: 115
	[Serializable]
	public class IFCSettings
	{
		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x060006B1 RID: 1713 RVA: 0x000264E0 File Offset: 0x000246E0
		// (set) Token: 0x060006B2 RID: 1714 RVA: 0x000264F4 File Offset: 0x000246F4
		[UpdateReport("FileVersion", TabName.FormatIFC, "Report-IFCVersionWasChanged", false)]
		public IFCVersion FileVersion { get; set; }

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x060006B3 RID: 1715 RVA: 0x00026508 File Offset: 0x00024708
		// (set) Token: 0x060006B4 RID: 1716 RVA: 0x0002651C File Offset: 0x0002471C
		[UpdateReport("IFCFileType", TabName.FormatIFC, "Report-IFCFileTypeWasChanged", false)]
		public string IFCFileType { get; set; } = "Ifc";

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x060006B5 RID: 1717 RVA: 0x00026530 File Offset: 0x00024730
		// (set) Token: 0x060006B6 RID: 1718 RVA: 0x00026544 File Offset: 0x00024744
		[UpdateReport("ActivePhaseId", TabName.FormatIFC, "Report-ActivePhaseOptionWasChanged", false)]
		public string ActivePhaseId { get; set; }

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x00026558 File Offset: 0x00024758
		// (set) Token: 0x060006B8 RID: 1720 RVA: 0x0002656C File Offset: 0x0002476C
		[UpdateReport("CurrentPhase", TabName.FormatIFC, "Report-PhaseToExportOptionWasChanged", false)]
		public IFCPhase CurrentPhase { get; set; } = new IFCPhase();

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x060006B9 RID: 1721 RVA: 0x00026580 File Offset: 0x00024780
		// (set) Token: 0x060006BA RID: 1722 RVA: 0x00026594 File Offset: 0x00024794
		[UpdateReport("SpaceBoundaries", TabName.FormatIFC, "Report-SpaceBoundariesOptionWasChanged", false)]
		public string SpaceBoundaries { get; set; } = "None";

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x060006BB RID: 1723 RVA: 0x000265A8 File Offset: 0x000247A8
		// (set) Token: 0x060006BC RID: 1724 RVA: 0x000265BC File Offset: 0x000247BC
		[UpdateReport("SitePlacement", TabName.FormatIFC, "Report-ProjectOriginWasChanged", false)]
		public string SitePlacement { get; set; } = "Current Shared Coordinates";

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x000265D0 File Offset: 0x000247D0
		// (set) Token: 0x060006BE RID: 1726 RVA: 0x000265E4 File Offset: 0x000247E4
		[UpdateReport("WallAndColumnSplitting", TabName.FormatIFC, "Report-SplitWallsColumnsDuctsByLevelOptionWasChanged", false)]
		public bool WallAndColumnSplitting { get; set; }

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x000265F8 File Offset: 0x000247F8
		// (set) Token: 0x060006C0 RID: 1728 RVA: 0x0002660C File Offset: 0x0002480C
		[UpdateReport("IncludeSteelElements", TabName.FormatIFC, "Report-IncludeSteelElementsOptionWasChanged", false)]
		public bool IncludeSteelElements { get; set; }

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x060006C1 RID: 1729 RVA: 0x00026620 File Offset: 0x00024820
		// (set) Token: 0x060006C2 RID: 1730 RVA: 0x00026634 File Offset: 0x00024834
		[UpdateReport("Export2DElements", TabName.FormatIFC, "Report-Export2DPlanViewElementsOptionWasChanged", false)]
		public bool Export2DElements { get; set; }

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x060006C3 RID: 1731 RVA: 0x00026648 File Offset: 0x00024848
		// (set) Token: 0x060006C4 RID: 1732 RVA: 0x0002665C File Offset: 0x0002485C
		[UpdateReport("ExportLinkedFiles", TabName.FormatIFC, "Report-ExportLinkedFilesOptionChanged", false)]
		public string ExportLinkedFiles
		{
			get
			{
				return this._exportLinkedFiles;
			}
			set
			{
				bool flag;
				if (\u0018\u0012\u0003.\u0018(value, ref flag))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(IFCSettings.set_ExportLinkedFiles(string)).MethodHandle;
					}
					string exportLinkedFiles;
					if (!flag)
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
						exportLinkedFiles = "DontExport";
					}
					else
					{
						exportLinkedFiles = "ExportAsSeparate";
					}
					this._exportLinkedFiles = exportLinkedFiles;
					return;
				}
				this._exportLinkedFiles = value;
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x000266B0 File Offset: 0x000248B0
		// (set) Token: 0x060006C6 RID: 1734 RVA: 0x000266C4 File Offset: 0x000248C4
		[UpdateReport("ExportRoomsInView", TabName.FormatIFC, "Report-ExportRoomIn3DViewOptionWasChanged", false)]
		public bool ExportRoomsInView { get; set; }

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x060006C7 RID: 1735 RVA: 0x000266D8 File Offset: 0x000248D8
		// (set) Token: 0x060006C8 RID: 1736 RVA: 0x000266EC File Offset: 0x000248EC
		[UpdateReport("ExportInternalRevitPropertySets", TabName.FormatIFC, "Report-ExportRevitPropertySetsOptionWasChanged", false)]
		public bool ExportInternalRevitPropertySets { get; set; }

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x060006C9 RID: 1737 RVA: 0x00026700 File Offset: 0x00024900
		// (set) Token: 0x060006CA RID: 1738 RVA: 0x00026714 File Offset: 0x00024914
		[UpdateReport("ExportIFCCommonPropertySets", TabName.FormatIFC, "Report-ExportIFCCommonPropertySetsOptionWasChanged", false)]
		public bool ExportIFCCommonPropertySets { get; set; }

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x00026728 File Offset: 0x00024928
		// (set) Token: 0x060006CC RID: 1740 RVA: 0x0002673C File Offset: 0x0002493C
		[UpdateReport("ExportBaseQuantities", TabName.FormatIFC, "Report-ExportBaseQuantitiesOptionWasChanged", false)]
		public bool ExportBaseQuantities { get; set; }

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x060006CD RID: 1741 RVA: 0x00026750 File Offset: 0x00024950
		// (set) Token: 0x060006CE RID: 1742 RVA: 0x00026764 File Offset: 0x00024964
		[UpdateReport("ExportSchedulesAsPsets", TabName.FormatIFC, "Report-ExportSchedulesAsPropertySetsOptionWasChanged", false)]
		public bool ExportSchedulesAsPsets { get; set; }

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x060006CF RID: 1743 RVA: 0x00026778 File Offset: 0x00024978
		// (set) Token: 0x060006D0 RID: 1744 RVA: 0x0002678C File Offset: 0x0002498C
		[UpdateReport("ExportSpecificSchedules", TabName.FormatIFC, "Report-ExportOnlySchedulerContainingIFCOptionWasChanged", false)]
		public bool ExportSpecificSchedules { get; set; }

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x060006D1 RID: 1745 RVA: 0x000267A0 File Offset: 0x000249A0
		// (set) Token: 0x060006D2 RID: 1746 RVA: 0x000267B4 File Offset: 0x000249B4
		[UpdateReport("ExportUserDefinedPsets", TabName.FormatIFC, "Report-ExportUserDefinedPropertySetsOptionWasChanged", false)]
		public bool ExportUserDefinedPsets { get; set; }

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x000267C8 File Offset: 0x000249C8
		// (set) Token: 0x060006D4 RID: 1748 RVA: 0x000267DC File Offset: 0x000249DC
		[UpdateReport("UseTypePropertiesInInstancePsets", TabName.FormatIFC, "Report-ExportUseTypePropertiesInInstancePsetsOptionWasChanged", false)]
		public bool UseTypePropertiesInInstancePsets { get; set; }

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x060006D5 RID: 1749 RVA: 0x000267F0 File Offset: 0x000249F0
		// (set) Token: 0x060006D6 RID: 1750 RVA: 0x00026804 File Offset: 0x00024A04
		[UpdateReport("ExportUserDefinedPsetsFileName", TabName.FormatIFC, "Report-ExportUserDefinedPropertySetsFileLocationWasChanged", false)]
		public string ExportUserDefinedPsetsFileName { get; set; }

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x00026818 File Offset: 0x00024A18
		// (set) Token: 0x060006D8 RID: 1752 RVA: 0x0002682C File Offset: 0x00024A2C
		[UpdateReport("ExportUserDefinedParameterMapping", TabName.FormatIFC, "Report-ExportParameterMappingTableOptionWasChanged", false)]
		public bool ExportUserDefinedParameterMapping { get; set; }

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x060006D9 RID: 1753 RVA: 0x00026840 File Offset: 0x00024A40
		// (set) Token: 0x060006DA RID: 1754 RVA: 0x00026854 File Offset: 0x00024A54
		[UpdateReport("ExportUserDefinedParameterMappingFileName", TabName.FormatIFC, "Report-ExportParameterMappingTableFileLocationWasChanged", false)]
		public string ExportUserDefinedParameterMappingFileName { get; set; }

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x00026868 File Offset: 0x00024A68
		// (set) Token: 0x060006DC RID: 1756 RVA: 0x0002687C File Offset: 0x00024A7C
		[UpdateReport("TessellationLevelOfDetail", TabName.FormatIFC, "Report-DetailLevelOptionWasChanged", false)]
		public string TessellationLevelOfDetail { get; set; } = "Extra Low";

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x00026890 File Offset: 0x00024A90
		// (set) Token: 0x060006DE RID: 1758 RVA: 0x000268A4 File Offset: 0x00024AA4
		[UpdateReport("ExportPartsAsBuildingElements", TabName.FormatIFC, "Report-ExportPartsAsBuildingElementsOptionWasChanged", false)]
		public bool ExportPartsAsBuildingElements { get; set; }

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x000268B8 File Offset: 0x00024AB8
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x000268CC File Offset: 0x00024ACC
		[UpdateReport("ExportSolidModelRep", TabName.FormatIFC, "Report-AllowUseOfMixedSolidModelRepresentationOptionWasChanged", false)]
		public bool ExportSolidModelRep { get; set; }

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x060006E1 RID: 1761 RVA: 0x000268E0 File Offset: 0x00024AE0
		// (set) Token: 0x060006E2 RID: 1762 RVA: 0x000268F4 File Offset: 0x00024AF4
		[UpdateReport("UseFamilyAndTypeNameForReference", TabName.FormatIFC, "Report-UseFamilyAndTypeNameReferenceOptionWasChanged", false)]
		public bool UseFamilyAndTypeNameForReference { get; set; }

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x060006E3 RID: 1763 RVA: 0x00026908 File Offset: 0x00024B08
		// (set) Token: 0x060006E4 RID: 1764 RVA: 0x0002691C File Offset: 0x00024B1C
		[UpdateReport("UseActiveViewCreatingGeometry", TabName.FormatIFC, "Report-UseActiveViewWhenCreatingGeometryOptionWasChanged", false)]
		public bool UseActiveViewCreatingGeometry { get; set; }

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x060006E5 RID: 1765 RVA: 0x00026930 File Offset: 0x00024B30
		// (set) Token: 0x060006E6 RID: 1766 RVA: 0x00026944 File Offset: 0x00024B44
		[UpdateReport("Use2DRoomBoundaryForVolume", TabName.FormatIFC, "Report-Use2DRoomBoundariesForRoomVolumeOptionWasChanged", false)]
		public bool Use2DRoomBoundaryForVolume { get; set; }

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x060006E7 RID: 1767 RVA: 0x00026958 File Offset: 0x00024B58
		// (set) Token: 0x060006E8 RID: 1768 RVA: 0x0002696C File Offset: 0x00024B6C
		[UpdateReport("IncludeSiteElevation", TabName.FormatIFC, "Report-IncludeIFCSITEOptionWasChanged", false)]
		public bool IncludeSiteElevation { get; set; }

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x060006E9 RID: 1769 RVA: 0x00026980 File Offset: 0x00024B80
		// (set) Token: 0x060006EA RID: 1770 RVA: 0x00026994 File Offset: 0x00024B94
		[UpdateReport("StoreIFCGUID", TabName.FormatIFC, "Report-StoreIFCGUIDAsElementOptionWasChanged", false)]
		public bool StoreIFCGUID { get; set; }

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x060006EB RID: 1771 RVA: 0x000269A8 File Offset: 0x00024BA8
		// (set) Token: 0x060006EC RID: 1772 RVA: 0x000269BC File Offset: 0x00024BBC
		[UpdateReport("ExportBoundingBox", TabName.FormatIFC, "Report-ExportBoundingBoxOptionWasChanged", false)]
		public bool ExportBoundingBox { get; set; }

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x060006ED RID: 1773 RVA: 0x000269D0 File Offset: 0x00024BD0
		// (set) Token: 0x060006EE RID: 1774 RVA: 0x000269E4 File Offset: 0x00024BE4
		[UpdateReport("UseOnlyTriangulation", TabName.FormatIFC, "Report-KeepTessellatedGeometryAsTriangulationOptionWasChanged", false)]
		public bool UseOnlyTriangulation { get; set; }

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x000269F8 File Offset: 0x00024BF8
		// (set) Token: 0x060006F0 RID: 1776 RVA: 0x00026A0C File Offset: 0x00024C0C
		[UpdateReport("VisibleElementsOfCurrentView", TabName.FormatIFC, "Report-ExportOnlyElementsVisibleInViewOptionWasChanged", false)]
		public bool VisibleElementsOfCurrentView { get; set; }

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x060006F1 RID: 1777 RVA: 0x00026A20 File Offset: 0x00024C20
		// (set) Token: 0x060006F2 RID: 1778 RVA: 0x00026A34 File Offset: 0x00024C34
		public double TessellationFactor { get; set; } = -1.0;

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x060006F3 RID: 1779 RVA: 0x00026A48 File Offset: 0x00024C48
		// (set) Token: 0x060006F4 RID: 1780 RVA: 0x00026A5C File Offset: 0x00024C5C
		[UpdateReport("UseTypeNameOnlyForIfcType", TabName.FormatIFC, "Report-UseTypeNameOnlyForIFCTypeNameOptionWasChanged", false)]
		public bool UseTypeNameOnlyForIfcType { get; set; }

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x00026A70 File Offset: 0x00024C70
		// (set) Token: 0x060006F6 RID: 1782 RVA: 0x00026A84 File Offset: 0x00024C84
		[UpdateReport("UseVisibleRevitNameAsEntityName", TabName.FormatIFC, "Report-UseVisibleRevitNameAsIFCEntityNameOptionWasChanged", false)]
		public bool UseVisibleRevitNameAsEntityName { get; set; }

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x060006F7 RID: 1783 RVA: 0x00026A98 File Offset: 0x00024C98
		// (set) Token: 0x060006F8 RID: 1784 RVA: 0x00026AAC File Offset: 0x00024CAC
		[UpdateReport("SetupName", TabName.FormatIFC, "Report-IFCSetupWasChanged", false)]
		public string SetupName { get; set; } = \u001C\u0009\u0018.\u0019\u0014;

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x060006F9 RID: 1785 RVA: 0x00026AC0 File Offset: 0x00024CC0
		// (set) Token: 0x060006FA RID: 1786 RVA: 0x00026AD4 File Offset: 0x00024CD4
		public string CategoryMapping { get; set; }

		// Token: 0x04000280 RID: 640
		private string _exportLinkedFiles;
	}
}

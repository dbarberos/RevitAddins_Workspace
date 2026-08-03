using System;
using Autodesk.Revit.DB;
using ProSheets.ScheduleAssistant.Attributes;
using ProSheets.ScheduleAssistant.Model.Enum;

namespace ProSheets
{
	// Token: 0x02000071 RID: 113
	[Serializable]
	public class NWCSettings
	{
		// Token: 0x17000291 RID: 657
		// (get) Token: 0x0600068F RID: 1679 RVA: 0x000261DC File Offset: 0x000243DC
		// (set) Token: 0x06000690 RID: 1680 RVA: 0x000261F0 File Offset: 0x000243F0
		[UpdateReport("ConvertLights", TabName.FormatNWC, "Report-ConvertLightsOptionWasChanged", false)]
		public bool ConvertLights { get; set; }

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000691 RID: 1681 RVA: 0x00026204 File Offset: 0x00024404
		// (set) Token: 0x06000692 RID: 1682 RVA: 0x00026218 File Offset: 0x00024418
		[UpdateReport("ConvertLinkedCADFormats", TabName.FormatNWC, "Report-ConvertLinkedCADFormatOptionWasChanged", false)]
		public bool ConvertLinkedCADFormats { get; set; }

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000693 RID: 1683 RVA: 0x0002622C File Offset: 0x0002442C
		// (set) Token: 0x06000694 RID: 1684 RVA: 0x00026240 File Offset: 0x00024440
		[UpdateReport("FacetingFactor", TabName.FormatNWC, "Report-FacetingFactorWasChanged", false)]
		public double FacetingFactor { get; set; }

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000695 RID: 1685 RVA: 0x00026254 File Offset: 0x00024454
		// (set) Token: 0x06000696 RID: 1686 RVA: 0x00026268 File Offset: 0x00024468
		[UpdateReport("ConvertElementProperties", TabName.FormatNWC, "Report-ConvertElementPropertiesOptionWasChanged", false)]
		public bool ConvertElementProperties { get; set; }

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000697 RID: 1687 RVA: 0x0002627C File Offset: 0x0002447C
		// (set) Token: 0x06000698 RID: 1688 RVA: 0x00026290 File Offset: 0x00024490
		[UpdateReport("Coordinates", TabName.FormatNWC, "Report-NavisworksCoordinatesOptionWasChanged", false)]
		public NavisworksCoordinates Coordinates { get; set; }

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06000699 RID: 1689 RVA: 0x000262A4 File Offset: 0x000244A4
		// (set) Token: 0x0600069A RID: 1690 RVA: 0x000262B8 File Offset: 0x000244B8
		[UpdateReport("DivideFileIntoLevels", TabName.FormatNWC, "Report-DivideFilesIntoLevelsOptionWasChanged", false)]
		public bool DivideFileIntoLevels { get; set; }

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x0600069B RID: 1691 RVA: 0x000262CC File Offset: 0x000244CC
		// (set) Token: 0x0600069C RID: 1692 RVA: 0x000262E0 File Offset: 0x000244E0
		[UpdateReport("ExportElementIds", TabName.FormatNWC, "Report-ConvertElementIdsOptionWasChanged", false)]
		public bool ExportElementIds { get; set; }

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x000262F4 File Offset: 0x000244F4
		// (set) Token: 0x0600069E RID: 1694 RVA: 0x00026308 File Offset: 0x00024508
		[UpdateReport("ExportLinks", TabName.FormatNWC, "Report-ConvertLinkedFilesOptionWasChanged", false)]
		public bool ExportLinks { get; set; }

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x0600069F RID: 1695 RVA: 0x0002631C File Offset: 0x0002451C
		// (set) Token: 0x060006A0 RID: 1696 RVA: 0x00026330 File Offset: 0x00024530
		[UpdateReport("ExportParts", TabName.FormatNWC, "Report-ConvertConstructionPartsOptionWasChanged", false)]
		public bool ExportParts { get; set; }

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x060006A1 RID: 1697 RVA: 0x00026344 File Offset: 0x00024544
		// (set) Token: 0x060006A2 RID: 1698 RVA: 0x00026358 File Offset: 0x00024558
		[UpdateReport("ExportRoomAsAttribute", TabName.FormatNWC, "Report-ConvertRoomAsAttributeOptionWasChanged", false)]
		public bool ExportRoomAsAttribute { get; set; }

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x060006A3 RID: 1699 RVA: 0x0002636C File Offset: 0x0002456C
		// (set) Token: 0x060006A4 RID: 1700 RVA: 0x00026380 File Offset: 0x00024580
		[UpdateReport("ExportRoomGeometry", TabName.FormatNWC, "Report-ExportRoomGeometryOptionWasChanged", false)]
		public bool ExportRoomGeometry { get; set; }

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x060006A5 RID: 1701 RVA: 0x00026394 File Offset: 0x00024594
		// (set) Token: 0x060006A6 RID: 1702 RVA: 0x000263A8 File Offset: 0x000245A8
		[UpdateReport("ExportUrls", TabName.FormatNWC, "Report-ConvertUrlsOptionWasChanged", false)]
		public bool ExportUrls { get; set; }

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x000263BC File Offset: 0x000245BC
		// (set) Token: 0x060006A8 RID: 1704 RVA: 0x000263D0 File Offset: 0x000245D0
		[UpdateReport("FindMissingMaterials", TabName.FormatNWC, "Report-TryAndFindMissingMaterialsOptionWasChanged", false)]
		public bool FindMissingMaterials { get; set; }

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x000263E4 File Offset: 0x000245E4
		// (set) Token: 0x060006AA RID: 1706 RVA: 0x000263F8 File Offset: 0x000245F8
		[UpdateReport("Parameters", TabName.FormatNWC, "Report-ConvertElementsParametersOptionWasChanged", false)]
		public NavisworksParameters Parameters { get; set; }
	}
}

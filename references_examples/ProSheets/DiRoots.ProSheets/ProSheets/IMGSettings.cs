using System;
using Autodesk.Revit.DB;
using ProSheets.ScheduleAssistant.Attributes;
using ProSheets.ScheduleAssistant.Model.Enum;

namespace ProSheets
{
	// Token: 0x02000074 RID: 116
	[Serializable]
	public class IMGSettings
	{
		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x060006FC RID: 1788 RVA: 0x00026B0C File Offset: 0x00024D0C
		// (set) Token: 0x060006FD RID: 1789 RVA: 0x00026B20 File Offset: 0x00024D20
		[UpdateReport("IsCombineHTML", TabName.FormatIMG, "Report-CreateSeparateImagesOptionIsChanged", true)]
		public bool IsCombineHTML { get; set; }

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x060006FE RID: 1790 RVA: 0x00026B34 File Offset: 0x00024D34
		// (set) Token: 0x060006FF RID: 1791 RVA: 0x00026B48 File Offset: 0x00024D48
		[UpdateReport("objCombineFilename", TabName.FormatIMG, "Report-CombineFileNameIsChanged", false)]
		public string objCombineFilename { get; set; }

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x06000700 RID: 1792 RVA: 0x00026B5C File Offset: 0x00024D5C
		// (set) Token: 0x06000701 RID: 1793 RVA: 0x00026B70 File Offset: 0x00024D70
		[UpdateReport("FitDirection", TabName.FormatIMG, "Report-DirectionOptionIsChanged", false)]
		public FitDirectionType FitDirection { get; set; }

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06000702 RID: 1794 RVA: 0x00026B84 File Offset: 0x00024D84
		// (set) Token: 0x06000703 RID: 1795 RVA: 0x00026B98 File Offset: 0x00024D98
		[UpdateReport("HLRandWFViewsFileType", TabName.FormatIMG, "Report-ShadedViewsOptionIsChanged", false)]
		public ImageFileType HLRandWFViewsFileType { get; set; } = 4;

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000704 RID: 1796 RVA: 0x00026BAC File Offset: 0x00024DAC
		// (set) Token: 0x06000705 RID: 1797 RVA: 0x00026BC0 File Offset: 0x00024DC0
		[UpdateReport("ImageResolution", TabName.FormatIMG, "Report-RasterImageOptionIsChanged", false)]
		public ImageResolution ImageResolution { get; set; }

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000706 RID: 1798 RVA: 0x00026BD4 File Offset: 0x00024DD4
		// (set) Token: 0x06000707 RID: 1799 RVA: 0x00026BE8 File Offset: 0x00024DE8
		[UpdateReport("PixelSize", TabName.FormatIMG, "Report-PixelSizeIsChanged", false)]
		public int PixelSize { get; set; }

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000708 RID: 1800 RVA: 0x00026BFC File Offset: 0x00024DFC
		// (set) Token: 0x06000709 RID: 1801 RVA: 0x00026C10 File Offset: 0x00024E10
		[UpdateReport("ShadowViewsFileType", TabName.FormatIMG, "Report-NonShadedViewsOptionIsChanged", false)]
		public ImageFileType ShadowViewsFileType { get; set; } = 4;

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x0600070A RID: 1802 RVA: 0x00026C24 File Offset: 0x00024E24
		// (set) Token: 0x0600070B RID: 1803 RVA: 0x00026C38 File Offset: 0x00024E38
		[UpdateReport("Zoom", TabName.FormatIMG, "Report-ZoomPercentageIsChanged", false)]
		public int Zoom { get; set; }

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x0600070C RID: 1804 RVA: 0x00026C4C File Offset: 0x00024E4C
		// (set) Token: 0x0600070D RID: 1805 RVA: 0x00026C60 File Offset: 0x00024E60
		[UpdateReport("ZoomType", TabName.FormatIMG, "Report-ImageSizeOptionIsChanged", false)]
		public ZoomFitType ZoomType { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using A;
using DiRoots.One.SheetLink.Profile;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000256 RID: 598
	[Serializable]
	public class TemplateInfo : ProfileTemplate
	{
		// Token: 0x06001840 RID: 6208 RVA: 0x0009C648 File Offset: 0x0009A848
		public TemplateInfo()
		{
			\u0005\u001A\u0018.\u001D(this, new List<long>());
			\u0018\u001A\u0018.\u001D(this, new List<ParamExportInfo>());
		}

		// Token: 0x170006C3 RID: 1731
		// (get) Token: 0x06001842 RID: 6210 RVA: 0x0009C688 File Offset: 0x0009A888
		// (set) Token: 0x06001841 RID: 6209 RVA: 0x0009C674 File Offset: 0x0009A874
		public int Version { get; set; }

		// Token: 0x170006C4 RID: 1732
		// (get) Token: 0x06001844 RID: 6212 RVA: 0x0009C6B0 File Offset: 0x0009A8B0
		// (set) Token: 0x06001843 RID: 6211 RVA: 0x0009C69C File Offset: 0x0009A89C
		[XmlArrayItem(typeof(long))]
		[XmlArrayItem(typeof(int))]
		public List<long> SelectedCategories { get; set; }

		// Token: 0x170006C5 RID: 1733
		// (get) Token: 0x06001846 RID: 6214 RVA: 0x0009C6D8 File Offset: 0x0009A8D8
		// (set) Token: 0x06001845 RID: 6213 RVA: 0x0009C6C4 File Offset: 0x0009A8C4
		public long SelectedCategoryId { get; set; }

		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x06001848 RID: 6216 RVA: 0x0009C700 File Offset: 0x0009A900
		// (set) Token: 0x06001847 RID: 6215 RVA: 0x0009C6EC File Offset: 0x0009A8EC
		public List<ParamExportInfo> SelectedParameters { get; set; }

		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x0600184A RID: 6218 RVA: 0x0009C728 File Offset: 0x0009A928
		// (set) Token: 0x06001849 RID: 6217 RVA: 0x0009C714 File Offset: 0x0009A914
		public bool IsLinkCheked { get; set; }

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x0600184C RID: 6220 RVA: 0x0009C750 File Offset: 0x0009A950
		// (set) Token: 0x0600184B RID: 6219 RVA: 0x0009C73C File Offset: 0x0009A93C
		public bool IsExportByType { get; set; }

		// Token: 0x0600184D RID: 6221 RVA: 0x0009C764 File Offset: 0x0009A964
		public override ProfileTemplate Clone()
		{
			XmlSerializer u001F = \u0008\u001A\u0004.\u000A(\u0003\u0011\u000A.\u001D(this));
			MemoryStream memoryStream = \u0003\u0002\u001D.\u000A();
			\u000E\u001A\u0004.\u000A(u001F, memoryStream, this);
			\u0005\u0002\u001D.\u000A(memoryStream, 0L);
			return \u000C\u000B\u000E.\u001F(\u000E\u000E\u0019.\u000A(u001F, memoryStream));
		}

		// Token: 0x0600184E RID: 6222 RVA: 0x0009C7A8 File Offset: 0x0009A9A8
		internal static void \u001F()
		{
			\u0005\u0013\u000A.\u000A(\u0011\u0020\u0005.\u000A(), 400.0);
		}
	}
}

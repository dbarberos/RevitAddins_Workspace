using System;
using A;

namespace DiRoots.ProfileControl.Helper
{
	// Token: 0x0200001B RID: 27
	[Serializable]
	public class LastUsedFolder
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00006E90 File Offset: 0x00005090
		// (set) Token: 0x060000FD RID: 253 RVA: 0x00006EA4 File Offset: 0x000050A4
		public string PluginDirectory { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00006EB8 File Offset: 0x000050B8
		// (set) Token: 0x060000FF RID: 255 RVA: 0x00006ECC File Offset: 0x000050CC
		public string TemplateDirectory { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00006EE0 File Offset: 0x000050E0
		// (set) Token: 0x06000101 RID: 257 RVA: 0x00006EF4 File Offset: 0x000050F4
		public string ProfileDirectory { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00006F08 File Offset: 0x00005108
		// (set) Token: 0x06000103 RID: 259 RVA: 0x00006F1C File Offset: 0x0000511C
		public string PanelDirectory { get; set; }

		// Token: 0x06000104 RID: 260 RVA: 0x00006F30 File Offset: 0x00005130
		public void Initialize(FolderHandler folderHandler)
		{
			\u0006\u0010\u0018.\u0003(this, \u0008\u0010\u0018.\u0003(folderHandler));
			\u0007\u0010\u0018.\u0003(this, \u0010\u0010\u0018.\u0003(folderHandler));
			\u000B\u0010\u0018.\u0003(this, \u0019\u0010\u0018.\u0003(folderHandler));
			\u001D\u0010\u0018.\u0003(this, \u001A\u0010\u0018.\u0003(folderHandler));
		}
	}
}

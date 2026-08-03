using System;
using System.Runtime.CompilerServices;
using A;

namespace DiRoots.One.TableGen.TableGen.ViewModels.StyleMappings
{
	// Token: 0x02000174 RID: 372
	public sealed class TextRevitStyleItem : RevitStyleItemBase
	{
		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06000DDF RID: 3551 RVA: 0x00059498 File Offset: 0x00057698
		// (set) Token: 0x06000DE0 RID: 3552 RVA: 0x000594AC File Offset: 0x000576AC
		public string ElementUniqueId { get; set; }

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06000DE1 RID: 3553 RVA: 0x000594C0 File Offset: 0x000576C0
		// (set) Token: 0x06000DE2 RID: 3554 RVA: 0x000594D4 File Offset: 0x000576D4
		public string FontFamily { get; set; }

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06000DE3 RID: 3555 RVA: 0x000594E8 File Offset: 0x000576E8
		// (set) Token: 0x06000DE4 RID: 3556 RVA: 0x000594FC File Offset: 0x000576FC
		public bool IsBold { get; set; }

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06000DE5 RID: 3557 RVA: 0x00059510 File Offset: 0x00057710
		// (set) Token: 0x06000DE6 RID: 3558 RVA: 0x00059524 File Offset: 0x00057724
		public bool IsItalic { get; set; }

		// Token: 0x06000DE7 RID: 3559 RVA: 0x00059538 File Offset: 0x00057738
		public TextRevitStyleItem WithGroupName(string groupName)
		{
			TextRevitStyleItem textRevitStyleItem = \u0007\u000D\u0019.\u000A();
			\u0010\u0003\u0019.\u000A(textRevitStyleItem, \u0004\u0003\u0019.\u001D(this));
			\u0002\u001C\u0019.\u000A(textRevitStyleItem, \u0007\u0003\u0019.\u001D(this));
			\u001F\u000D\u0019.\u000A(textRevitStyleItem, \u000A\u000D\u0019.\u0007(this));
			\u000B\u001C\u0019.\u000A(textRevitStyleItem, \u001F\u0003\u0019.\u001D(this));
			\u0016\u001C\u0019.\u000A(textRevitStyleItem, groupName);
			\u0005\u001C\u0019.\u000A(textRevitStyleItem, \u0014\u001C\u0019.\u0007(this));
			\u001D\u001C\u0019.\u000A(textRevitStyleItem, \u0017\u001C\u0019.\u0007(this));
			\u0001\u001C\u0019.\u000A(textRevitStyleItem, \u0009\u001C\u0019.\u0007(this));
			\u000C\u001C\u0019.\u000A(textRevitStyleItem, \u0015\u001C\u0019.\u0007(this));
			\u0013\u001C\u0019.\u000A(textRevitStyleItem, \u001A\u001C\u0019.\u0007(this));
			return textRevitStyleItem;
		}

		// Token: 0x04000579 RID: 1401
		[CompilerGenerated]
		private string \u0016;

		// Token: 0x0400057A RID: 1402
		[CompilerGenerated]
		private string \u000B;

		// Token: 0x0400057B RID: 1403
		[CompilerGenerated]
		private bool \u0002;

		// Token: 0x0400057C RID: 1404
		[CompilerGenerated]
		private bool \u0006;
	}
}

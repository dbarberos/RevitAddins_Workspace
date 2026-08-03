using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.SheetGen.TemplateTransfer
{
	// Token: 0x020002DD RID: 733
	public class ParameterInfo : ModelBase
	{
		// Token: 0x06001E3E RID: 7742 RVA: 0x000BF1A0 File Offset: 0x000BD3A0
		public ParameterInfo(Parameter p)
		{
			\u0014\u001A\u0016.\u000A(this, p);
		}

		// Token: 0x06001E3F RID: 7743 RVA: 0x000BF1BC File Offset: 0x000BD3BC
		public ParameterInfo(Parameter p, string warring)
		{
			\u0014\u001A\u0016.\u000A(this, p);
			\u0013\u001A\u0016.\u0007(this, warring);
		}

		// Token: 0x17000850 RID: 2128
		// (get) Token: 0x06001E40 RID: 7744 RVA: 0x000BF1E0 File Offset: 0x000BD3E0
		// (set) Token: 0x06001E41 RID: 7745 RVA: 0x000BF1F4 File Offset: 0x000BD3F4
		public Parameter Parameter { get; set; }

		// Token: 0x17000851 RID: 2129
		// (get) Token: 0x06001E42 RID: 7746 RVA: 0x000BF208 File Offset: 0x000BD408
		public string Name
		{
			get
			{
				return \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(\u001A\u001A\u0016.\u0007(this)));
			}
		}

		// Token: 0x17000852 RID: 2130
		// (get) Token: 0x06001E43 RID: 7747 RVA: 0x000BF22C File Offset: 0x000BD42C
		public StorageType StorageType
		{
			get
			{
				return \u0011\u001F\u001D.\u0007(\u001A\u001A\u0016.\u0007(this));
			}
		}

		// Token: 0x17000853 RID: 2131
		// (get) Token: 0x06001E44 RID: 7748 RVA: 0x000BF248 File Offset: 0x000BD448
		// (set) Token: 0x06001E45 RID: 7749 RVA: 0x000BF25C File Offset: 0x000BD45C
		public bool IsChecked
		{
			get
			{
				return this.WR;
			}
			set
			{
				this.WR = value;
				\u0007\u0013\u000A.\u000A(this, "IsChecked");
			}
		}

		// Token: 0x17000854 RID: 2132
		// (get) Token: 0x06001E46 RID: 7750 RVA: 0x000BF27C File Offset: 0x000BD47C
		// (set) Token: 0x06001E47 RID: 7751 RVA: 0x000BF290 File Offset: 0x000BD490
		public bool IsExistInSource { get; set; }

		// Token: 0x17000855 RID: 2133
		// (get) Token: 0x06001E48 RID: 7752 RVA: 0x000BF2A4 File Offset: 0x000BD4A4
		// (set) Token: 0x06001E49 RID: 7753 RVA: 0x000BF2B8 File Offset: 0x000BD4B8
		public bool IsExistInDestination { get; set; }

		// Token: 0x17000856 RID: 2134
		// (get) Token: 0x06001E4A RID: 7754 RVA: 0x000BF2CC File Offset: 0x000BD4CC
		// (set) Token: 0x06001E4B RID: 7755 RVA: 0x000BF2E0 File Offset: 0x000BD4E0
		public bool IsIncluded { get; set; }

		// Token: 0x17000857 RID: 2135
		// (get) Token: 0x06001E4C RID: 7756 RVA: 0x000BF2F4 File Offset: 0x000BD4F4
		// (set) Token: 0x06001E4D RID: 7757 RVA: 0x000BF308 File Offset: 0x000BD508
		public string Warring { get; set; }

		// Token: 0x17000858 RID: 2136
		// (get) Token: 0x06001E4E RID: 7758 RVA: 0x000BF31C File Offset: 0x000BD51C
		public ElementId Id
		{
			get
			{
				return \u0014\u001F\u001D.\u0007(\u001A\u001A\u0016.\u0007(this));
			}
		}

		// Token: 0x04000C72 RID: 3186
		private bool WR;

		// Token: 0x04000C73 RID: 3187
		[CompilerGenerated]
		private Parameter FS;

		// Token: 0x04000C74 RID: 3188
		[CompilerGenerated]
		private bool XB;

		// Token: 0x04000C75 RID: 3189
		[CompilerGenerated]
		private bool PB;

		// Token: 0x04000C76 RID: 3190
		[CompilerGenerated]
		private bool OB;

		// Token: 0x04000C77 RID: 3191
		[CompilerGenerated]
		private string TB;
	}
}

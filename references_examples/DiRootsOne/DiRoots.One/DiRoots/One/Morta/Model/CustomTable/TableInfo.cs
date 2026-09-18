using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Morta.Model.Base;
using DiRoots.One.Morta.Model.Json.Table;

namespace DiRoots.One.Morta.Model.CustomTable
{
	// Token: 0x020001BC RID: 444
	public class TableInfo : BaseInfo
	{
		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06001086 RID: 4230 RVA: 0x00068A3C File Offset: 0x00066C3C
		// (set) Token: 0x06001087 RID: 4231 RVA: 0x00068A50 File Offset: 0x00066C50
		public string OriginalName { get; set; }

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06001088 RID: 4232 RVA: 0x00068A64 File Offset: 0x00066C64
		// (set) Token: 0x06001089 RID: 4233 RVA: 0x00068A78 File Offset: 0x00066C78
		public DateTime LastUpdateAt { get; set; }

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x0600108A RID: 4234 RVA: 0x00068A8C File Offset: 0x00066C8C
		public string ViewId
		{
			get
			{
				return \u000A\u0005\u0018.\u000A(\u0007\u0005\u0018.\u000A(\u001D\u0005\u0018.\u0007(this)));
			}
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x0600108B RID: 4235 RVA: 0x00068AB0 File Offset: 0x00066CB0
		// (set) Token: 0x0600108C RID: 4236 RVA: 0x00068AC4 File Offset: 0x00066CC4
		public List<ColumnInfo> Columns { get; set; } = new List<ColumnInfo>();

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x0600108D RID: 4237 RVA: 0x00068AD8 File Offset: 0x00066CD8
		// (set) Token: 0x0600108E RID: 4238 RVA: 0x00068AEC File Offset: 0x00066CEC
		public List<RowInfo> Rows { get; set; } = new List<RowInfo>();

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x0600108F RID: 4239 RVA: 0x00068B00 File Offset: 0x00066D00
		// (set) Token: 0x06001090 RID: 4240 RVA: 0x00068B14 File Offset: 0x00066D14
		public bool IsSuccess { get; set; }

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06001091 RID: 4241 RVA: 0x00068B28 File Offset: 0x00066D28
		// (set) Token: 0x06001092 RID: 4242 RVA: 0x00068B3C File Offset: 0x00066D3C
		public string Message { get; set; }

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06001093 RID: 4243 RVA: 0x00068B50 File Offset: 0x00066D50
		// (set) Token: 0x06001094 RID: 4244 RVA: 0x00068B64 File Offset: 0x00066D64
		public TableTypeInfo Type { get; set; }

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06001095 RID: 4245 RVA: 0x00068B78 File Offset: 0x00066D78
		// (set) Token: 0x06001096 RID: 4246 RVA: 0x00068B8C File Offset: 0x00066D8C
		public TableInformationClass JsonInfo { get; set; }

		// Token: 0x06001097 RID: 4247 RVA: 0x00068BA0 File Offset: 0x00066DA0
		public string GetName(List<string> existingNames)
		{
			if (!Enumerable.Any<string>(Enumerable.Where<string>(existingNames, new Func<string, bool>(this.\u0006))))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TableInfo.GetName(List<string>)).MethodHandle;
				}
				return \u0004\u0005\u0018.\u000A(this);
			}
			for (int i = 1; i < 2147483647; i++)
			{
				TableInfo.\u001A\u0006 u001A_u = new TableInfo.\u001A\u0006();
				u001A_u.\u001F = \u001E\u0020\u001D.\u000A("duplicated-", \u0004\u0005\u0018.\u000A(this), "-", \u0003\u001F\u0019.\u000A(ref i, "D2"));
				if (Enumerable.FirstOrDefault<string>(existingNames, new Func<string, bool>(u001A_u.\u000A)) == null)
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
					return u001A_u.\u001F;
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
			return "";
		}

		// Token: 0x06001098 RID: 4248 RVA: 0x00068C60 File Offset: 0x00066E60
		[CompilerGenerated]
		private bool \u0006(string \u001F)
		{
			return \u0008\u0013\u000A.\u000A(\u000D\u0003\u0004.\u001D(\u001F), \u000D\u0003\u0004.\u001D(\u0004\u0005\u0018.\u000A(this)));
		}

		// Token: 0x04000688 RID: 1672
		[CompilerGenerated]
		private string \u000A;

		// Token: 0x04000689 RID: 1673
		[CompilerGenerated]
		private DateTime \u0007;

		// Token: 0x0400068A RID: 1674
		[CompilerGenerated]
		private List<ColumnInfo> \u001D;

		// Token: 0x0400068B RID: 1675
		[CompilerGenerated]
		private List<RowInfo> \u0004;

		// Token: 0x0400068C RID: 1676
		[CompilerGenerated]
		private bool \u0019;

		// Token: 0x0400068D RID: 1677
		[CompilerGenerated]
		private string \u0018;

		// Token: 0x0400068E RID: 1678
		[CompilerGenerated]
		private TableTypeInfo \u0005;

		// Token: 0x0400068F RID: 1679
		[CompilerGenerated]
		private TableInformationClass \u0016;

		// Token: 0x0200088A RID: 2186
		[CompilerGenerated]
		private sealed class \u001A\u0006
		{
			// Token: 0x06004F5C RID: 20316 RVA: 0x001E4F80 File Offset: 0x001E3180
			internal bool \u000A(string \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u000D\u0003\u0004.\u001D(\u001F), \u000D\u0003\u0004.\u001D(this.\u001F));
			}

			// Token: 0x0400222C RID: 8748
			public string \u001F;
		}
	}
}

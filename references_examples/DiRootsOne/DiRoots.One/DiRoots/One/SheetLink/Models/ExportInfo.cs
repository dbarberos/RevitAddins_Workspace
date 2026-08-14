using System;
using System.Runtime.CompilerServices;
using A;
using Newtonsoft.Json;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000247 RID: 583
	public class ExportInfo
	{
		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x06001759 RID: 5977 RVA: 0x000997DC File Offset: 0x000979DC
		// (set) Token: 0x06001758 RID: 5976 RVA: 0x000997C8 File Offset: 0x000979C8
		public int StartRow { get; set; }

		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x0600175B RID: 5979 RVA: 0x00099804 File Offset: 0x00097A04
		// (set) Token: 0x0600175A RID: 5978 RVA: 0x000997F0 File Offset: 0x000979F0
		public bool IsSchedule { get; set; }

		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x0600175D RID: 5981 RVA: 0x0009982C File Offset: 0x00097A2C
		// (set) Token: 0x0600175C RID: 5980 RVA: 0x00099818 File Offset: 0x00097A18
		public bool IsKeepFormating { get; set; }

		// Token: 0x0600175E RID: 5982 RVA: 0x00099840 File Offset: 0x00097A40
		internal static string \u001D(int \u001F, bool \u000A, bool \u0007)
		{
			ExportInfo u001F = \u0019\u001B\u0005.\u000A();
			\u0004\u001B\u0005.\u000A(u001F, \u001F);
			\u001D\u001B\u0005.\u000A(u001F, \u000A);
			\u0007\u001B\u0005.\u000A(u001F, \u0007);
			return \u0019\u0005\u0018.\u000A(u001F);
		}

		// Token: 0x0600175F RID: 5983 RVA: 0x00099870 File Offset: 0x00097A70
		internal static ExportInfo \u0004(string \u001F)
		{
			try
			{
				return JsonConvert.DeserializeObject<ExportInfo>(\u001F);
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Models\\Parameter\\ExportInfo.cs", "GetExportInfo");
			}
			return null;
		}

		// Token: 0x04000931 RID: 2353
		[CompilerGenerated]
		private int \u001F;

		// Token: 0x04000932 RID: 2354
		[CompilerGenerated]
		private bool \u000A;

		// Token: 0x04000933 RID: 2355
		[CompilerGenerated]
		private bool \u0007;
	}
}

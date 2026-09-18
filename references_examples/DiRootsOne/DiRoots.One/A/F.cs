using System;
using DiRoots.One.Commons.Models;

namespace A
{
	// Token: 0x02000073 RID: 115
	internal class F : ModelBase
	{
		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060004F8 RID: 1272 RVA: 0x0001EBDC File Offset: 0x0001CDDC
		// (set) Token: 0x060004F9 RID: 1273 RVA: 0x0001EBF0 File Offset: 0x0001CDF0
		public string Number
		{
			get
			{
				return this.E;
			}
			set
			{
				this.E = value;
				\u0007\u0013\u000A.\u000A(this, "Number");
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060004FA RID: 1274 RVA: 0x0001EC10 File Offset: 0x0001CE10
		// (set) Token: 0x060004FB RID: 1275 RVA: 0x0001EC24 File Offset: 0x0001CE24
		public string Message
		{
			get
			{
				return this.N;
			}
			set
			{
				this.N = value;
				\u0007\u0013\u000A.\u000A(this, "Message");
			}
		}

		// Token: 0x040001E4 RID: 484
		private string E;

		// Token: 0x040001E5 RID: 485
		private string N;
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using DiRoots.One.Commons.Models;
using DiRoots.One.Morta.Interfaces;
using DiRoots.One.Morta.Model.CustomTable;
using DiRoots.One.Morta.ViewModel;

namespace A
{
	// Token: 0x020001AC RID: 428
	internal class S : SingleTableUploadViewModel
	{
		// Token: 0x06000FD9 RID: 4057 RVA: 0x00065164 File Offset: 0x00063364
		public S(\u0013\u0006 F, IDataFactory R) : base(F, R)
		{
			\u000D\u000A\u0018.\u000A(this, new CommandBase(new Action(this.YVR), \u0002\u0015\u0010.\u001F));
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06000FDA RID: 4058 RVA: 0x00065198 File Offset: 0x00063398
		// (set) Token: 0x06000FDB RID: 4059 RVA: 0x000651AC File Offset: 0x000633AC
		public bool OverWriteExisting
		{
			get
			{
				return this.FU;
			}
			set
			{
				this.FU = value;
				\u000D\u0020\u000A.\u000A(this, "OverWriteExisting");
			}
		}

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06000FDC RID: 4060 RVA: 0x000651CC File Offset: 0x000633CC
		// (set) Token: 0x06000FDD RID: 4061 RVA: 0x000651E0 File Offset: 0x000633E0
		public ICommand UploadToMorta { get; set; }

		// Token: 0x06000FDE RID: 4062 RVA: 0x000651F4 File Offset: 0x000633F4
		public void YVR()
		{
			this.reports = \u0010\u000A\u0018.\u000A();
			this.CVR();
		}

		// Token: 0x06000FDF RID: 4063 RVA: 0x00065218 File Offset: 0x00063418
		public Task CVR()
		{
			S.\u0019\u0006 u0019_u;
			u0019_u.\u000A = \u0008\u0011\u000A.\u000A();
			u0019_u.\u0007 = this;
			u0019_u.\u001F = -1;
			u0019_u.\u000A.Start<S.\u0019\u0006>(ref u0019_u);
			return \u000E\u0011\u000A.\u000A(ref u0019_u.\u000A);
		}

		// Token: 0x06000FE0 RID: 4064 RVA: 0x00065260 File Offset: 0x00063460
		private Task LVR(List<TableInfo> F, bool R)
		{
			S.\u0004\u0006 u0004_u;
			u0004_u.\u000A = \u0008\u0011\u000A.\u000A();
			u0004_u.\u001D = this;
			u0004_u.\u0007 = F;
			u0004_u.\u0004 = R;
			u0004_u.\u001F = -1;
			u0004_u.\u000A.Start<S.\u0004\u0006>(ref u0004_u);
			return \u000E\u0011\u000A.\u000A(ref u0004_u.\u000A);
		}

		// Token: 0x06000FE1 RID: 4065 RVA: 0x000652B8 File Offset: 0x000634B8
		[CompilerGenerated]
		private void SVR(TableInfo F)
		{
			\u000E\u000A\u0018.\u000A(F, \u0008\u000A\u0018.\u000A(\u001D\u000A\u0018.\u000A(this)));
		}

		// Token: 0x04000651 RID: 1617
		private bool FU;

		// Token: 0x04000652 RID: 1618
		[CompilerGenerated]
		private ICommand RU;

		// Token: 0x02000871 RID: 2161
		[CompilerGenerated]
		private sealed class \u001D\u0006
		{
			// Token: 0x06004F18 RID: 20248 RVA: 0x001E2418 File Offset: 0x001E0618
			internal bool \u000A(TableInfo \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0003\u000A\u0018.\u0007(\u001F), \u0003\u000A\u0018.\u0007(this.\u001F));
			}

			// Token: 0x040021AD RID: 8621
			public TableInfo \u001F;
		}
	}
}

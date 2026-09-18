using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.Morta.Model;

namespace DiRoots.One.Morta.ViewModel
{
	// Token: 0x020001AA RID: 426
	public class ConnectToMortaViewModel : ViewModelBase
	{
		// Token: 0x06000FC9 RID: 4041 RVA: 0x00064D4C File Offset: 0x00062F4C
		public ConnectToMortaViewModel(Login login)
		{
			this.QB = login;
			\u001A\u001F\u0018.\u000A(this, new CommandBase(new Action(this.AccessKeyDetailsSaving), \u0002\u0015\u0010.\u001F));
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x06000FCA RID: 4042 RVA: 0x00064D84 File Offset: 0x00062F84
		// (set) Token: 0x06000FCB RID: 4043 RVA: 0x00064D98 File Offset: 0x00062F98
		public string AccessKey
		{
			get
			{
				return this.IB;
			}
			set
			{
				this.IB = value;
				\u000D\u0020\u000A.\u000A(this, "AccessKey");
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06000FCC RID: 4044 RVA: 0x00064DB8 File Offset: 0x00062FB8
		// (set) Token: 0x06000FCD RID: 4045 RVA: 0x00064DCC File Offset: 0x00062FCC
		public ICommand ConnectToMorta { get; set; }

		// Token: 0x06000FCE RID: 4046 RVA: 0x00064DE0 File Offset: 0x00062FE0
		public void AccessKeyDetailsSaving()
		{
			if (\u001A\u0006\u0007.\u000A(\u0015\u001F\u0018.\u000A(this)))
			{
				\u000C\u000D\u001D.\u000A(\u001F\u000F.\u0002, \u0018\u000B\u0007.\u0007(this));
				return;
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(ConnectToMortaViewModel.AccessKeyDetailsSaving()).MethodHandle;
			}
			if (\u000C\u001F\u0018.\u000A(this.QB, \u0015\u001F\u0018.\u000A(this)))
			{
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				\u0006\u0015\u0007.\u001D(\u0018\u000B\u0007.\u0007(this), new bool?(true));
				\u0019\u000B\u0007.\u001D(\u0018\u000B\u0007.\u0007(this));
				return;
			}
			\u000C\u000D\u001D.\u000A(\u001F\u000F.\u000B, \u0018\u000B\u0007.\u0007(this));
		}

		// Token: 0x0400064D RID: 1613
		private string IB;

		// Token: 0x0400064E RID: 1614
		private readonly Login QB;

		// Token: 0x0400064F RID: 1615
		[CompilerGenerated]
		private ICommand AB;
	}
}

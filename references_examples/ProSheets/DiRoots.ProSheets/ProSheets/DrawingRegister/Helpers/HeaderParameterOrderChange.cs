using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using A;
using DiRoots.One.Commons.Models;
using ProSheets.DrawingRegister.Model;

namespace ProSheets.DrawingRegister.Helpers
{
	// Token: 0x02000128 RID: 296
	public class HeaderParameterOrderChange : DataGridOrderChange<ParameterInformation>
	{
		// Token: 0x06000F4C RID: 3916 RVA: 0x0005717C File Offset: 0x0005537C
		public HeaderParameterOrderChange()
		{
			\u000D\u000D\u000F.\u0018(this, new CommandBase(new Action(this.Refresh), new Predicate<object>(base.CanMoveParameterCmd)));
		}

		// Token: 0x17000548 RID: 1352
		// (get) Token: 0x06000F4D RID: 3917 RVA: 0x000571B4 File Offset: 0x000553B4
		// (set) Token: 0x06000F4E RID: 3918 RVA: 0x000571C8 File Offset: 0x000553C8
		public ICommand RefreshCmd { get; set; }

		// Token: 0x06000F4F RID: 3919 RVA: 0x000571DC File Offset: 0x000553DC
		public void Refresh()
		{
			IEnumerable<ParameterInformation> enumerable = \u0004\u000B\u0016.\u0003(this);
			Func<ParameterInformation, string> func;
			if ((func = HeaderParameterOrderChange.<>c.\u0018) == null)
			{
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(HeaderParameterOrderChange.Refresh()).MethodHandle;
				}
				func = (HeaderParameterOrderChange.<>c.\u0018 = new Func<ParameterInformation, string>(HeaderParameterOrderChange.<>c.\u000C.\u0014));
			}
			List<ParameterInformation> u000C = Enumerable.ToList<ParameterInformation>(Enumerable.OrderBy<ParameterInformation, string>(enumerable, func));
			\u0006\u0006\u0016.\u0003(this, \u0008\u0006\u0016.\u0018(u000C));
		}

		// Token: 0x040006D8 RID: 1752
		[CompilerGenerated]
		private ICommand \u0011\u0012;
	}
}

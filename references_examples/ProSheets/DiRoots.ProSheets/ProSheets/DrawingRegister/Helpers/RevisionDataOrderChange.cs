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
	// Token: 0x0200012A RID: 298
	public class RevisionDataOrderChange : DataGridOrderChange<RevisionData>
	{
		// Token: 0x06000F5F RID: 3935 RVA: 0x00057398 File Offset: 0x00055598
		public RevisionDataOrderChange()
		{
			\u001C\u000D\u000F.\u0018(this, new CommandBase(new Action(this.Refresh), new Predicate<object>(base.CanMoveParameterCmd)));
		}

		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x06000F60 RID: 3936 RVA: 0x000573D0 File Offset: 0x000555D0
		// (set) Token: 0x06000F61 RID: 3937 RVA: 0x000573E4 File Offset: 0x000555E4
		public ICommand RefreshCmd { get; set; }

		// Token: 0x06000F62 RID: 3938 RVA: 0x000573F8 File Offset: 0x000555F8
		public void Refresh()
		{
			IEnumerable<RevisionData> enumerable = \u001E\u000B\u0016.\u0003(this);
			Func<RevisionData, string> func;
			if ((func = RevisionDataOrderChange.<>c.\u0018) == null)
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionDataOrderChange.Refresh()).MethodHandle;
				}
				func = (RevisionDataOrderChange.<>c.\u0018 = new Func<RevisionData, string>(RevisionDataOrderChange.<>c.\u000C.\u0014));
			}
			List<RevisionData> u000C = Enumerable.ToList<RevisionData>(Enumerable.OrderBy<RevisionData, string>(enumerable, func));
			\u0002\u0010\u0016.\u0003(this, \u0004\u0010\u0016.\u0018(u000C));
		}

		// Token: 0x040006E0 RID: 1760
		[CompilerGenerated]
		private ICommand \u0011\u0012;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;

namespace DiRoots.One.SheetGen.Models
{
	// Token: 0x02000375 RID: 885
	public sealed class SheetDeletionBatchResult
	{
		// Token: 0x17000A40 RID: 2624
		// (get) Token: 0x0600245C RID: 9308 RVA: 0x000DEC6C File Offset: 0x000DCE6C
		// (set) Token: 0x0600245D RID: 9309 RVA: 0x000DEC80 File Offset: 0x000DCE80
		public IReadOnlyList<SheetDeletionResult> Results { get; set; }

		// Token: 0x17000A41 RID: 2625
		// (get) Token: 0x0600245E RID: 9310 RVA: 0x000DEC94 File Offset: 0x000DCE94
		public bool AllSucceeded
		{
			get
			{
				IEnumerable<SheetDeletionResult> enumerable = \u0001\u001D\u0016.\u001D(this);
				Func<SheetDeletionResult, bool> func;
				if ((func = SheetDeletionBatchResult.<>c.\u000A) == null)
				{
					for (;;)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetDeletionBatchResult.get_AllSucceeded()).MethodHandle;
					}
					func = (SheetDeletionBatchResult.<>c.\u000A = new Func<SheetDeletionResult, bool>(SheetDeletionBatchResult.<>c.\u001F.\u0007));
				}
				return Enumerable.All<SheetDeletionResult>(enumerable, func);
			}
		}

		// Token: 0x04000E69 RID: 3689
		[CompilerGenerated]
		private IReadOnlyList<SheetDeletionResult> \u001F;
	}
}

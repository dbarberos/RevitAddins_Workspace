using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using DiRoots.One.Commons.Services;
using DiRoots.One.SheetGen;
using DiRoots.One.SheetGen.Delegates;
using DiRoots.One.SheetGen.Models;

namespace A
{
	// Token: 0x0200029E RID: 670
	internal class \u001D\u0008<\u000A> : ExternalEventInfo where \u000A : ISheetModel
	{
		// Token: 0x06001A3A RID: 6714 RVA: 0x000AA83C File Offset: 0x000A8A3C
		public \u001D\u0008(\u0019\u000C<\u000A> \u001F, ICancellationManagerService \u000A)
		{
			\u000D\u0001\u000A.\u0007(this, "SheetGen_DeleteSheets");
			this.\u001C\u000A = \u001F;
			this.\u0013\u000A = \u000A;
		}

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x06001A3B RID: 6715 RVA: 0x000AA868 File Offset: 0x000A8A68
		// (remove) Token: 0x06001A3C RID: 6716 RVA: 0x000AA8B8 File Offset: 0x000A8AB8
		public event DeletingSheetsFinishedHandler \u001F
		{
			[CompilerGenerated]
			add
			{
				DeletingSheetsFinishedHandler deletingSheetsFinishedHandler = this.\u001F;
				DeletingSheetsFinishedHandler deletingSheetsFinishedHandler2;
				do
				{
					deletingSheetsFinishedHandler2 = deletingSheetsFinishedHandler;
					DeletingSheetsFinishedHandler value2 = \u000B\u0003\u000E.\u001F(\u000F\u001E\u000A.\u000A(deletingSheetsFinishedHandler2, value));
					deletingSheetsFinishedHandler = Interlocked.CompareExchange<DeletingSheetsFinishedHandler>(ref this.\u001F, value2, deletingSheetsFinishedHandler2);
				}
				while (deletingSheetsFinishedHandler != deletingSheetsFinishedHandler2);
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0008.add_\u001F(DeletingSheetsFinishedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				DeletingSheetsFinishedHandler deletingSheetsFinishedHandler = this.\u001F;
				DeletingSheetsFinishedHandler deletingSheetsFinishedHandler2;
				do
				{
					deletingSheetsFinishedHandler2 = deletingSheetsFinishedHandler;
					DeletingSheetsFinishedHandler value2 = \u000B\u0003\u000E.\u001F(\u0012\u001E\u000A.\u000A(deletingSheetsFinishedHandler2, value));
					deletingSheetsFinishedHandler = Interlocked.CompareExchange<DeletingSheetsFinishedHandler>(ref this.\u001F, value2, deletingSheetsFinishedHandler2);
				}
				while (deletingSheetsFinishedHandler != deletingSheetsFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0008.remove_\u001F(DeletingSheetsFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x17000735 RID: 1845
		// (get) Token: 0x06001A3D RID: 6717 RVA: 0x000AA908 File Offset: 0x000A8B08
		// (set) Token: 0x06001A3E RID: 6718 RVA: 0x000AA91C File Offset: 0x000A8B1C
		public IEnumerable<\u000A> SheetsToDelete { get; set; }

		// Token: 0x06001A3F RID: 6719 RVA: 0x000AA930 File Offset: 0x000A8B30
		public override void Execute(UIApplication app)
		{
			try
			{
				SheetDeletionBatchResult u001F = this.\u001C\u000A.\u0004(this.SheetsToDelete, this.\u0013\u000A);
				\u0009\u0004\u001D.\u000A(this, \u000B\u0018\u0016.\u000A(u001F));
				List<FailedSheetReport> u001F2 = \u0016\u0018\u0016.\u000A();
				if (!\u0014\u0019\u001D.\u0007(this))
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0008.Execute(UIApplication)).MethodHandle;
					}
					IEnumerable<SheetDeletionResult> enumerable = \u0001\u001D\u0016.\u0007(u001F);
					Func<SheetDeletionResult, bool> func;
					if ((func = \u001D\u0008<\u000A>.<>c.\u000A) == null)
					{
						for (;;)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
						func = (\u001D\u0008<\u000A>.<>c.\u000A = new Func<SheetDeletionResult, bool>(\u001D\u0008<\u000A>.<>c.\u001F.\u0007));
					}
					IEnumerable<SheetDeletionResult> enumerable2 = Enumerable.Where<SheetDeletionResult>(enumerable, func);
					Func<SheetDeletionResult, FailedSheetReport> func2;
					if ((func2 = \u001D\u0008<\u000A>.\u0007\u0008.\u001F) == null)
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
						func2 = (\u001D\u0008<\u000A>.\u0007\u0008.\u001F = new Func<SheetDeletionResult, FailedSheetReport>(\u001D\u0008<\u000A>.\u000B\u0005));
					}
					u001F2 = Enumerable.ToList<FailedSheetReport>(Enumerable.Select<SheetDeletionResult, FailedSheetReport>(enumerable2, func2));
				}
				this.\u0002\u0005(u001F2);
			}
			catch (OperationCanceledException u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\DeleteSheetsEvent.cs", "Execute");
			}
			catch (Exception u000A2)
			{
				\u000F\u000E\u001D.\u000A(\u0016\u000E\u001D.\u000A(this), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\DeleteSheetsEvent.cs", "Execute");
				\u000D\u0014\u0004.\u000A(\u0013\u0007\u0016.\u000A(), u000A2, true);
			}
		}

		// Token: 0x06001A40 RID: 6720 RVA: 0x000AAA64 File Offset: 0x000A8C64
		private static FailedSheetReport \u000B\u0005(SheetDeletionResult \u001F)
		{
			ISheetModel u001F = \u001A\u001D\u0016.\u000A(\u001F);
			FailedSheetReport failedSheetReport = \u001C\u0018\u0016.\u000A();
			\u0012\u0018\u0016.\u000A(failedSheetReport, \u0003\u0018\u0016.\u000A(u001F));
			\u0006\u0018\u0016.\u000A(failedSheetReport, \u000F\u0018\u0016.\u000A(u001F));
			\u0002\u0018\u0016.\u000A(failedSheetReport, \u0020\u001D\u0016.\u000A(\u001F));
			\u0020\u0014\u0007.\u000A(failedSheetReport, \u001E\u001D\u0016.\u000A(\u001F));
			return failedSheetReport;
		}

		// Token: 0x06001A41 RID: 6721 RVA: 0x000AAABC File Offset: 0x000A8CBC
		private void \u0002\u0005(ICollection<FailedSheetReport> \u001F)
		{
			if (\u0010\u0018\u0016.\u000A(this.\u0013\u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0008.\u0002\u0005(ICollection<FailedSheetReport>)).MethodHandle;
				}
				return;
			}
			DeletingSheetsFinishedHandler u001F = this.\u001F;
			if (u001F == null)
			{
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			else
			{
				\u000D\u0018\u0016.\u000A(u001F, \u0014\u0019\u001D.\u0007(this), \u001F);
			}
			this.\u001F = \u0016\u0003\u000E.\u001F;
		}

		// Token: 0x04000A78 RID: 2680
		private readonly \u0019\u000C<\u000A> \u001C\u000A;

		// Token: 0x04000A79 RID: 2681
		private readonly ICancellationManagerService \u0013\u000A;

		// Token: 0x04000A7B RID: 2683
		[CompilerGenerated]
		private IEnumerable<\u000A> \u001A\u000A;

		// Token: 0x02000964 RID: 2404
		[CompilerGenerated]
		private static class \u0007\u0008
		{
			// Token: 0x04002496 RID: 9366
			public static Func<SheetDeletionResult, FailedSheetReport> \u001F;
		}
	}
}

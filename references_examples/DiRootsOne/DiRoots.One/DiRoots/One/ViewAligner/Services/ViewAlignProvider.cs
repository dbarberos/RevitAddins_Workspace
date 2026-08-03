using System;
using System.Runtime.CompilerServices;
using System.Threading;
using A;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Progress;
using DiRoots.One.Revit.Interfaces;
using DiRoots.One.ViewAligner.Data.Models;
using DiRoots.One.ViewAligner.Interfaces;
using DiRoots.Revit.SheetsAndViews;

namespace DiRoots.One.ViewAligner.Services
{
	// Token: 0x020000C6 RID: 198
	public class ViewAlignProvider : IViewAlignProvider
	{
		// Token: 0x060007A9 RID: 1961 RVA: 0x0002C6FC File Offset: 0x0002A8FC
		public ViewAlignProvider(DocumentContext context, IProgressWindowService progressWindowService, IReportingService reportingService, ICustomLogger customLogger)
		{
			this.\u001D = context;
			this.\u001F = progressWindowService;
			this.\u0007 = reportingService;
			this.\u000A = customLogger;
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060007AA RID: 1962 RVA: 0x0002C72C File Offset: 0x0002A92C
		// (remove) Token: 0x060007AB RID: 1963 RVA: 0x0002C77C File Offset: 0x0002A97C
		public event TaskFinishedDelegate TaskFinished
		{
			[CompilerGenerated]
			add
			{
				TaskFinishedDelegate taskFinishedDelegate = this.\u0004;
				TaskFinishedDelegate taskFinishedDelegate2;
				do
				{
					taskFinishedDelegate2 = taskFinishedDelegate;
					TaskFinishedDelegate value2 = \u0017\u001D\u000E.\u001F(\u000F\u001E\u000A.\u000A(taskFinishedDelegate2, value));
					taskFinishedDelegate = Interlocked.CompareExchange<TaskFinishedDelegate>(ref this.\u0004, value2, taskFinishedDelegate2);
				}
				while (taskFinishedDelegate != taskFinishedDelegate2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewAlignProvider.add_TaskFinished(TaskFinishedDelegate)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				TaskFinishedDelegate taskFinishedDelegate = this.\u0004;
				TaskFinishedDelegate taskFinishedDelegate2;
				do
				{
					taskFinishedDelegate2 = taskFinishedDelegate;
					TaskFinishedDelegate value2 = \u0017\u001D\u000E.\u001F(\u0012\u001E\u000A.\u000A(taskFinishedDelegate2, value));
					taskFinishedDelegate = Interlocked.CompareExchange<TaskFinishedDelegate>(ref this.\u0004, value2, taskFinishedDelegate2);
				}
				while (taskFinishedDelegate != taskFinishedDelegate2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewAlignProvider.remove_TaskFinished(TaskFinishedDelegate)).MethodHandle;
				}
			}
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x0002C7CC File Offset: 0x0002A9CC
		public void Align(AlignSettings alignSettings)
		{
			ViewAuthorizingService u000A = \u0002\u0010\u001D.\u000A(\u0016\u0010\u001D.\u000A(this.\u001D));
			ISheetLayoutService u001F = \u000B\u0010\u001D.\u000A(\u0016\u0010\u001D.\u000A(this.\u001D), u000A);
			CropViewService u000A2 = \u0005\u0010\u001D.\u000A(\u0016\u0010\u001D.\u000A(this.\u001D));
			\u0003\u0019 u0003_u = new \u0003\u0019(u001F, u000A2, this.\u0007, this.\u001F);
			\u0018\u0010\u001D.\u000A(u0003_u, alignSettings);
			\u0019\u0010\u001D.\u0007(u0003_u, this.\u000A);
			\u0003\u0019 u0003_u2 = u0003_u;
			u0003_u2.\u001F += this.\u0019;
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u0003_u2);
			\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0002C86C File Offset: 0x0002AA6C
		private void \u0019(ITaskFinishedArgs \u001F)
		{
			TaskFinishedDelegate u = this.\u0004;
			if (u == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewAlignProvider.\u0019(ITaskFinishedArgs)).MethodHandle;
				}
				return;
			}
			\u0006\u0010\u001D.\u000A(u);
		}

		// Token: 0x04000317 RID: 791
		private readonly IProgressWindowService \u001F;

		// Token: 0x04000318 RID: 792
		private readonly ICustomLogger \u000A;

		// Token: 0x04000319 RID: 793
		private readonly IReportingService \u0007;

		// Token: 0x0400031A RID: 794
		private readonly DocumentContext \u001D;

		// Token: 0x0400031B RID: 795
		[CompilerGenerated]
		private TaskFinishedDelegate \u0004;
	}
}

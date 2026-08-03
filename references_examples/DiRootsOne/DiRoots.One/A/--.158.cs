using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using DiRoots.One.SheetGen;
using DiRoots.One.SheetGen.Delegates;

namespace A
{
	// Token: 0x0200029C RID: 668
	internal class \u0013\u000E : ExternalEventInfo
	{
		// Token: 0x14000027 RID: 39
		// (add) Token: 0x06001A1A RID: 6682 RVA: 0x000A8000 File Offset: 0x000A6200
		// (remove) Token: 0x06001A1B RID: 6683 RVA: 0x000A8050 File Offset: 0x000A6250
		public event TaskFinishedHandler \u001F
		{
			[CompilerGenerated]
			add
			{
				TaskFinishedHandler taskFinishedHandler = this.\u001F;
				TaskFinishedHandler taskFinishedHandler2;
				do
				{
					taskFinishedHandler2 = taskFinishedHandler;
					TaskFinishedHandler value2 = \u000A\u0003\u000E.\u001F(\u000F\u001E\u000A.\u000A(taskFinishedHandler2, value));
					taskFinishedHandler = Interlocked.CompareExchange<TaskFinishedHandler>(ref this.\u001F, value2, taskFinishedHandler2);
				}
				while (taskFinishedHandler != taskFinishedHandler2);
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u000E.add_\u001F(TaskFinishedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				TaskFinishedHandler taskFinishedHandler = this.\u001F;
				TaskFinishedHandler taskFinishedHandler2;
				do
				{
					taskFinishedHandler2 = taskFinishedHandler;
					TaskFinishedHandler value2 = \u000A\u0003\u000E.\u001F(\u0012\u001E\u000A.\u000A(taskFinishedHandler2, value));
					taskFinishedHandler = Interlocked.CompareExchange<TaskFinishedHandler>(ref this.\u001F, value2, taskFinishedHandler2);
				}
				while (taskFinishedHandler != taskFinishedHandler2);
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u000E.remove_\u001F(TaskFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x1700072E RID: 1838
		// (get) Token: 0x06001A1C RID: 6684 RVA: 0x000A80A0 File Offset: 0x000A62A0
		// (set) Token: 0x06001A1D RID: 6685 RVA: 0x000A80B4 File Offset: 0x000A62B4
		public List<string> TargetSheets { get; set; } = new List<string>();

		// Token: 0x06001A1E RID: 6686 RVA: 0x000A80C8 File Offset: 0x000A62C8
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\ChangeTemplateEvent.cs", "Execute");
			\u0020\u0013\u000A.\u000A(app);
			List<SheetInfo>.Enumerator enumerator = \u0017\u0007\u0016.\u000A(\u0014\u0007\u0016.\u000A());
			try
			{
				while (\u000D\u0007\u0016.\u000A(ref enumerator))
				{
					SheetInfo u001F = \u0020\u0007\u0016.\u000A(ref enumerator);
					if (\u001F\u0020\u001D.\u000A(\u001E\u0007\u0016.\u000A(this), \u0011\u0007\u0016.\u0007(u001F)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0013\u000E.Execute(UIApplication)).MethodHandle;
						}
						\u0010\u0007\u0016.\u000A(u001F, SheetTemplate.\u0006(\u001B\u0007\u0016.\u0007(\u0008\u0007\u0016.\u0007(u001F)), \u000E\u0007\u0016.\u0007(\u0008\u0007\u0016.\u0007(u001F)), \u001F\u0003\u000E.\u001F));
					}
				}
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			TaskFinishedHandler u001F2 = this.\u001F;
			if (u001F2 == null)
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
			}
			else
			{
				\u001C\u0007\u0016.\u000A(u001F2);
			}
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\ChangeTemplateEvent.cs", "Execute");
		}

		// Token: 0x04000A6B RID: 2667
		[CompilerGenerated]
		private List<string> \u0012\u000A;
	}
}

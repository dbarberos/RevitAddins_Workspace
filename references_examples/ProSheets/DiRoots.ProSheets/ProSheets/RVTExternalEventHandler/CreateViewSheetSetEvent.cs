using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Helpers;

namespace ProSheets.RVTExternalEventHandler
{
	// Token: 0x020000BC RID: 188
	public class CreateViewSheetSetEvent : ExternalEventInfo
	{
		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06000A89 RID: 2697 RVA: 0x000401B8 File Offset: 0x0003E3B8
		// (set) Token: 0x06000A8A RID: 2698 RVA: 0x000401CC File Offset: 0x0003E3CC
		public ViewSheetSetting Setting { get; internal set; }

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06000A8B RID: 2699 RVA: 0x000401E0 File Offset: 0x0003E3E0
		// (set) Token: 0x06000A8C RID: 2700 RVA: 0x000401F4 File Offset: 0x0003E3F4
		public string Name { get; internal set; }

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06000A8D RID: 2701 RVA: 0x00040208 File Offset: 0x0003E408
		// (set) Token: 0x06000A8E RID: 2702 RVA: 0x0004021C File Offset: 0x0003E41C
		public bool Success { get; private set; }

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06000A8F RID: 2703 RVA: 0x00040230 File Offset: 0x0003E430
		// (set) Token: 0x06000A90 RID: 2704 RVA: 0x00040244 File Offset: 0x0003E444
		public PrintManager CurrentPrintManager { get; set; }

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06000A91 RID: 2705 RVA: 0x00040258 File Offset: 0x0003E458
		// (set) Token: 0x06000A92 RID: 2706 RVA: 0x0004026C File Offset: 0x0003E46C
		public Window CurrentMainWindow { get; set; }

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06000A93 RID: 2707 RVA: 0x00040280 File Offset: 0x0003E480
		// (set) Token: 0x06000A94 RID: 2708 RVA: 0x00040294 File Offset: 0x0003E494
		public bool HasSchedulesViews { get; set; }

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000A95 RID: 2709 RVA: 0x000402A8 File Offset: 0x0003E4A8
		// (remove) Token: 0x06000A96 RID: 2710 RVA: 0x000402F4 File Offset: 0x0003E4F4
		public event CreateViewSheetSetEvent.TaskFinishedHandler TaskFinished
		{
			[CompilerGenerated]
			add
			{
				CreateViewSheetSetEvent.TaskFinishedHandler taskFinishedHandler = this.\u001F;
				CreateViewSheetSetEvent.TaskFinishedHandler taskFinishedHandler2;
				do
				{
					taskFinishedHandler2 = taskFinishedHandler;
					CreateViewSheetSetEvent.TaskFinishedHandler value2 = (CreateViewSheetSetEvent.TaskFinishedHandler)\u001C\u0019\u0018.\u0018(taskFinishedHandler2, value);
					taskFinishedHandler = Interlocked.CompareExchange<CreateViewSheetSetEvent.TaskFinishedHandler>(ref this.\u001F, value2, taskFinishedHandler2);
				}
				while (taskFinishedHandler != taskFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CreateViewSheetSetEvent.add_TaskFinished(CreateViewSheetSetEvent.TaskFinishedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				CreateViewSheetSetEvent.TaskFinishedHandler taskFinishedHandler = this.\u001F;
				CreateViewSheetSetEvent.TaskFinishedHandler taskFinishedHandler2;
				do
				{
					taskFinishedHandler2 = taskFinishedHandler;
					CreateViewSheetSetEvent.TaskFinishedHandler value2 = (CreateViewSheetSetEvent.TaskFinishedHandler)\u0013\u0019\u0018.\u0018(taskFinishedHandler2, value);
					taskFinishedHandler = Interlocked.CompareExchange<CreateViewSheetSetEvent.TaskFinishedHandler>(ref this.\u001F, value2, taskFinishedHandler2);
				}
				while (taskFinishedHandler != taskFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CreateViewSheetSetEvent.remove_TaskFinished(CreateViewSheetSetEvent.TaskFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x00040340 File Offset: 0x0003E540
		public override void Execute(UIApplication app)
		{
			TransactionStatus transactionStatus = 0;
			Transaction transaction = \u0018\u0010\u000F.\u000C;
			try
			{
				Transaction transaction2;
				transaction = (transaction2 = \u001F\u000C\u0016.\u0018(\u0017\u0005\u0018.\u0014(\u001F\u001F\u0014.\u0018(app)), "ProSheets_CreateViewSet"));
				try
				{
					FailureHandlingOptions failureHandlingOptions = \u0012\u0007\u0014.\u0018(transaction);
					FailurePreproccessor failurePreproccessor = \u000A\u000D\u0016.\u0018();
					\u0009\u000D\u0016.\u0018(failurePreproccessor, "ProSheets_CreateViewSet");
					FailurePreproccessor u = failurePreproccessor;
					\u000F\u0007\u0014.\u0018(failureHandlingOptions, u);
					\u0016\u0007\u0014.\u0018(transaction, failureHandlingOptions);
					\u0020\u000C\u0016.\u0018(transaction);
					try
					{
						\u0015\u000D\u0016.\u0018(this, \u0009\u0010\u0014.\u0018(\u0014\u0016\u0014.\u0003(this), \u0003\u0016\u0014.\u0003(this)));
						\u0009\u0007\u0014.\u0018(transaction);
					}
					catch (Exception)
					{
						\u0015\u000D\u0016.\u0018(this, false);
					}
					finally
					{
						if (transactionStatus != 5)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(CreateViewSheetSetEvent.Execute(UIApplication)).MethodHandle;
							}
							if (transactionStatus != 2)
							{
								goto IL_BE;
							}
							for (;;)
							{
								switch (4)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						\u0015\u000D\u0016.\u0018(this, false);
						IL_BE:;
					}
					CreateViewSheetSetEvent.TaskFinishedHandler u001F = this.\u001F;
					if (u001F == null)
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
					}
					else
					{
						\u0011\u000D\u0016.\u0018(u001F);
					}
				}
				finally
				{
					if (transaction2 != null)
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
						\u0020\u001E\u0018.\u0018(transaction2);
					}
				}
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RVTExternalEventHandler\\CreateViewSheetSetEvent.cs", "Execute");
				if (transaction != null)
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
					if (\u001F\u000D\u0016.\u0018(transaction))
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
						\u0020\u000D\u0016.\u0018(transaction);
					}
				}
			}
		}

		// Token: 0x040004F9 RID: 1273
		[CompilerGenerated]
		private ViewSheetSetting \u0016;

		// Token: 0x040004FA RID: 1274
		[CompilerGenerated]
		private string \u000F;

		// Token: 0x040004FB RID: 1275
		[CompilerGenerated]
		private bool \u0012;

		// Token: 0x040004FC RID: 1276
		[CompilerGenerated]
		private PrintManager \u000D;

		// Token: 0x040004FD RID: 1277
		[CompilerGenerated]
		private Window \u0013;

		// Token: 0x040004FE RID: 1278
		[CompilerGenerated]
		private bool \u0009;

		// Token: 0x040004FF RID: 1279
		[CompilerGenerated]
		private CreateViewSheetSetEvent.TaskFinishedHandler \u001F;

		// Token: 0x020001C5 RID: 453
		// (Invoke) Token: 0x060011D6 RID: 4566
		public delegate void TaskFinishedHandler();
	}
}

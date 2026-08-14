using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;

namespace ProSheets.RVTExternalEventHandler
{
	// Token: 0x020000BB RID: 187
	public class AddToViewSheetSetEvent : ExternalEventInfo
	{
		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06000A73 RID: 2675 RVA: 0x0003FD4C File Offset: 0x0003DF4C
		// (set) Token: 0x06000A74 RID: 2676 RVA: 0x0003FD60 File Offset: 0x0003DF60
		public ViewSheetSetting Setting { get; internal set; }

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06000A75 RID: 2677 RVA: 0x0003FD74 File Offset: 0x0003DF74
		// (set) Token: 0x06000A76 RID: 2678 RVA: 0x0003FD88 File Offset: 0x0003DF88
		public string Name { get; internal set; }

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06000A77 RID: 2679 RVA: 0x0003FD9C File Offset: 0x0003DF9C
		// (set) Token: 0x06000A78 RID: 2680 RVA: 0x0003FDB0 File Offset: 0x0003DFB0
		public bool Success { get; set; }

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06000A79 RID: 2681 RVA: 0x0003FDC4 File Offset: 0x0003DFC4
		// (set) Token: 0x06000A7A RID: 2682 RVA: 0x0003FDD8 File Offset: 0x0003DFD8
		public PrintManager CurrentPrintManager { get; set; }

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000A7B RID: 2683 RVA: 0x0003FDEC File Offset: 0x0003DFEC
		// (set) Token: 0x06000A7C RID: 2684 RVA: 0x0003FE00 File Offset: 0x0003E000
		public ViewSet Set { get; set; }

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06000A7D RID: 2685 RVA: 0x0003FE14 File Offset: 0x0003E014
		// (set) Token: 0x06000A7E RID: 2686 RVA: 0x0003FE28 File Offset: 0x0003E028
		public Window CurrentMainWindow { get; set; }

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06000A7F RID: 2687 RVA: 0x0003FE3C File Offset: 0x0003E03C
		// (set) Token: 0x06000A80 RID: 2688 RVA: 0x0003FE50 File Offset: 0x0003E050
		public bool HasSchedulesViews { get; set; }

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06000A81 RID: 2689 RVA: 0x0003FE64 File Offset: 0x0003E064
		// (set) Token: 0x06000A82 RID: 2690 RVA: 0x0003FE78 File Offset: 0x0003E078
		public bool OverrideExisting { get; set; }

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06000A83 RID: 2691 RVA: 0x0003FE8C File Offset: 0x0003E08C
		// (set) Token: 0x06000A84 RID: 2692 RVA: 0x0003FEA0 File Offset: 0x0003E0A0
		public ViewSheetSet ExistingViewSheetSet { get; set; }

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000A85 RID: 2693 RVA: 0x0003FEB4 File Offset: 0x0003E0B4
		// (remove) Token: 0x06000A86 RID: 2694 RVA: 0x0003FF00 File Offset: 0x0003E100
		public event AddToViewSheetSetEvent.TaskFinishedHandler TaskFinished
		{
			[CompilerGenerated]
			add
			{
				AddToViewSheetSetEvent.TaskFinishedHandler taskFinishedHandler = this.\u001F;
				AddToViewSheetSetEvent.TaskFinishedHandler taskFinishedHandler2;
				do
				{
					taskFinishedHandler2 = taskFinishedHandler;
					AddToViewSheetSetEvent.TaskFinishedHandler value2 = (AddToViewSheetSetEvent.TaskFinishedHandler)\u001C\u0019\u0018.\u0018(taskFinishedHandler2, value);
					taskFinishedHandler = Interlocked.CompareExchange<AddToViewSheetSetEvent.TaskFinishedHandler>(ref this.\u001F, value2, taskFinishedHandler2);
				}
				while (taskFinishedHandler != taskFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddToViewSheetSetEvent.add_TaskFinished(AddToViewSheetSetEvent.TaskFinishedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				AddToViewSheetSetEvent.TaskFinishedHandler taskFinishedHandler = this.\u001F;
				AddToViewSheetSetEvent.TaskFinishedHandler taskFinishedHandler2;
				do
				{
					taskFinishedHandler2 = taskFinishedHandler;
					AddToViewSheetSetEvent.TaskFinishedHandler value2 = (AddToViewSheetSetEvent.TaskFinishedHandler)\u0013\u0019\u0018.\u0018(taskFinishedHandler2, value);
					taskFinishedHandler = Interlocked.CompareExchange<AddToViewSheetSetEvent.TaskFinishedHandler>(ref this.\u001F, value2, taskFinishedHandler2);
				}
				while (taskFinishedHandler != taskFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddToViewSheetSetEvent.remove_TaskFinished(AddToViewSheetSetEvent.TaskFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x0003FF4C File Offset: 0x0003E14C
		public override void Execute(UIApplication app)
		{
			TransactionStatus transactionStatus = 0;
			Document u000C = \u0017\u0005\u0018.\u0014(\u001F\u001F\u0014.\u0018(app));
			Transaction transaction = \u001F\u000C\u0016.\u0018(u000C, "ProSheets_AddToViewSet");
			try
			{
				FailureHandlingOptions failureHandlingOptions = \u0012\u0007\u0014.\u0018(transaction);
				FailurePreproccessor failurePreproccessor = \u000A\u000D\u0016.\u0018();
				\u0009\u000D\u0016.\u0018(failurePreproccessor, "ProSheets_AddToViewSet");
				FailurePreproccessor u = failurePreproccessor;
				\u000F\u0007\u0014.\u0018(failureHandlingOptions, u);
				\u0016\u0007\u0014.\u0018(transaction, failureHandlingOptions);
				\u0020\u000C\u0016.\u0018(transaction);
				try
				{
					string u2 = \u001E\u0016\u0014.\u0018(\u000D\u000D\u0016.\u0018(this));
					if (!\u001A\u0016\u0014.\u0003(this))
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
						if (!true)
						{
							RuntimeMethodHandle runtimeMethodHandle = methodof(AddToViewSheetSetEvent.Execute(UIApplication)).MethodHandle;
						}
						IEnumerator u000C2 = \u001C\u000D\u0016.\u0018(\u0013\u000D\u0016.\u0018(\u000D\u000D\u0016.\u0018(this)));
						try
						{
							while (\u001F\u001E\u0018.\u0018(u000C2))
							{
								View u3 = \u001D\u001A\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C2));
								\u000B\u0003\u0014.\u0018(\u000F\u000D\u0016.\u0018(this), u3);
							}
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
						finally
						{
							IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C2);
							if (disposable != null)
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
								\u0020\u001E\u0018.\u0018(disposable);
							}
						}
					}
					\u0012\u000D\u0016.\u0018(u000C, \u0009\u0002\u0018.\u0018(\u000D\u000D\u0016.\u0018(this)));
					\u0017\u0003\u0014.\u0018(\u0019\u0016\u0014.\u0003(this), \u001E\u0003\u0014.\u0018(\u0019\u0016\u0014.\u0003(this)));
					\u0011\u0003\u0014.\u0018(\u0015\u0003\u0014.\u0018(\u0019\u0016\u0014.\u0003(this)), \u000F\u000D\u0016.\u0018(this));
					\u0003\u000D\u0016.\u0018(this, \u0009\u0010\u0014.\u0018(\u0019\u0016\u0014.\u0003(this), u2));
					transactionStatus = \u0009\u0007\u0014.\u0018(transaction);
				}
				catch (Exception u000C3)
				{
					\u0003\u000D\u0016.\u0018(this, false);
					\u0017\u0014\u0014.\u0018(\u000A\u0001\u0018.\u0018(u000C3), \u0016\u000D\u0016.\u0018(this));
				}
				finally
				{
					if (transactionStatus != 5)
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
						if (transactionStatus != 2)
						{
							goto IL_1B4;
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
					\u0003\u000D\u0016.\u0018(this, false);
					IL_1B4:;
				}
				AddToViewSheetSetEvent.TaskFinishedHandler u001F = this.\u001F;
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
					\u0014\u000D\u0016.\u0018(u001F);
				}
			}
			finally
			{
				if (transaction != null)
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
					\u0020\u001E\u0018.\u0018(transaction);
				}
			}
		}

		// Token: 0x040004EF RID: 1263
		[CompilerGenerated]
		private ViewSheetSetting \u0016;

		// Token: 0x040004F0 RID: 1264
		[CompilerGenerated]
		private string \u000F;

		// Token: 0x040004F1 RID: 1265
		[CompilerGenerated]
		private bool \u0012;

		// Token: 0x040004F2 RID: 1266
		[CompilerGenerated]
		private PrintManager \u000D;

		// Token: 0x040004F3 RID: 1267
		[CompilerGenerated]
		private ViewSet \u001C;

		// Token: 0x040004F4 RID: 1268
		[CompilerGenerated]
		private Window \u0013;

		// Token: 0x040004F5 RID: 1269
		[CompilerGenerated]
		private bool \u0009;

		// Token: 0x040004F6 RID: 1270
		[CompilerGenerated]
		private bool \u000A;

		// Token: 0x040004F7 RID: 1271
		[CompilerGenerated]
		private ViewSheetSet \u0020;

		// Token: 0x040004F8 RID: 1272
		[CompilerGenerated]
		private AddToViewSheetSetEvent.TaskFinishedHandler \u001F;

		// Token: 0x020001C4 RID: 452
		// (Invoke) Token: 0x060011D2 RID: 4562
		public delegate void TaskFinishedHandler();
	}
}

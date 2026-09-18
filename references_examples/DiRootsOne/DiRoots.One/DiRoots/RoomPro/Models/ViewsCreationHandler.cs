using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Enums;
using DiRoots.RoomPro.UI.Windows.ProgressWindows;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000074 RID: 116
	public class ViewsCreationHandler
	{
		// Token: 0x060004FC RID: 1276 RVA: 0x0001EC44 File Offset: 0x0001CE44
		public ViewsCreationHandler(string progressWindowTitle = "")
		{
			\u0007\u0009\u0007.\u000A(this, new ProgressBarWindow(progressWindowTitle));
			ProgressBarWindow u001F = \u001F\u0009\u0007.\u0007(this);
			\u000A\u0009\u0007.\u000A(u001F, \u0005\u0007\u000E.\u001F(\u000F\u001E\u000A.\u000A(\u0011\u0015\u0007.\u001D(u001F), new Action(this.ProgressChanged))));
			\u0009\u0001\u0007.\u0007(\u001F\u0009\u0007.\u0007(this));
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x0001ECB8 File Offset: 0x0001CEB8
		// (set) Token: 0x060004FE RID: 1278 RVA: 0x0001ECCC File Offset: 0x0001CECC
		public Transaction Transaction { get; set; }

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060004FF RID: 1279 RVA: 0x0001ECE0 File Offset: 0x0001CEE0
		// (set) Token: 0x06000500 RID: 1280 RVA: 0x0001ECF4 File Offset: 0x0001CEF4
		public ProgressBarWindow ProgressWindow { get; set; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x0001ED08 File Offset: 0x0001CF08
		// (set) Token: 0x06000502 RID: 1282 RVA: 0x0001ED1C File Offset: 0x0001CF1C
		public int TotalViewsCount { get; set; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000503 RID: 1283 RVA: 0x0001ED30 File Offset: 0x0001CF30
		// (set) Token: 0x06000504 RID: 1284 RVA: 0x0001ED44 File Offset: 0x0001CF44
		public int FinishedTasksCount { get; set; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x0001ED58 File Offset: 0x0001CF58
		// (set) Token: 0x06000506 RID: 1286 RVA: 0x0001ED6C File Offset: 0x0001CF6C
		public bool TaskFinished { get; set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x0001ED80 File Offset: 0x0001CF80
		// (set) Token: 0x06000508 RID: 1288 RVA: 0x0001ED94 File Offset: 0x0001CF94
		public string ViewInfo { get; set; } = string.Empty;

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x0001EDA8 File Offset: 0x0001CFA8
		// (set) Token: 0x0600050A RID: 1290 RVA: 0x0001EDBC File Offset: 0x0001CFBC
		public ObservableCollection<ViewsReport> Reports { get; set; } = new ObservableCollection<ViewsReport>();

		// Token: 0x0600050B RID: 1291 RVA: 0x0001EDD0 File Offset: 0x0001CFD0
		public void HandleViewsCreation(TransactionGroup tg, ModelSpatialElement spatialElement, string viewType, Exception e)
		{
			if (\u0019\u0009\u0007.\u000A(\u001F\u0009\u0007.\u0007(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsCreationHandler.HandleViewsCreation(TransactionGroup, ModelSpatialElement, string, Exception)).MethodHandle;
				}
				\u001A\u0017\u0007.\u000A(tg);
			}
			ViewsReport viewsReport = \u0015\u0014\u0007.\u000A();
			\u000C\u0014\u0007.\u000A(viewsReport, \u0018\u0018\u0007.\u0007(spatialElement));
			\u0013\u0014\u0007.\u000A(viewsReport, \u001D\u000D\u0007.\u0007(spatialElement));
			\u0017\u0014\u0007.\u000A(viewsReport, \u0007\u000D\u0007.\u0007(spatialElement));
			\u0020\u0014\u0007.\u000A(viewsReport, ReportStates.Error);
			\u0011\u0014\u0007.\u000A(viewsReport, viewType);
			ViewsReport viewsReport2 = viewsReport;
			if (\u000D\u0008\u000A.\u001F(\u0003\u001A\u000A.\u000A(e), "name"))
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
				if (\u000D\u0008\u000A.\u001F(\u0003\u001A\u000A.\u000A(e), "unique"))
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
					\u0008\u0014\u0007.\u000A(viewsReport2, "Some or all views are already created. Can't create views with the same name.");
					goto IL_C7;
				}
			}
			\u0008\u0014\u0007.\u000A(viewsReport2, "An Internal error has occured.");
			IL_C7:
			\u001D\u0009\u0007.\u000A(\u0004\u0009\u0007.\u0007(this), viewsReport2);
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0001EEB4 File Offset: 0x0001D0B4
		public void ProgressChanged()
		{
			if (\u0016\u0009\u0007.\u000A(this) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsCreationHandler.ProgressChanged()).MethodHandle;
				}
				if (\u001F\u0009\u0007.\u0007(this) != null)
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
					if (!\u0003\u0009\u0007.\u000A(this))
					{
						if (\u0019\u0009\u0007.\u000A(\u001F\u0009\u0007.\u0007(this)))
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
							if (\u000F\u0009\u0007.\u0007(this) != null)
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
								if (\u0012\u0009\u0007.\u000A(\u000F\u0009\u0007.\u0007(this)))
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
									\u001F\u0014\u0007.\u000A(\u000F\u0009\u0007.\u0007(this));
									return;
								}
							}
						}
						if (\u000B\u0009\u0007.\u000A(this) >= \u0016\u0009\u0007.\u000A(this))
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
							if (!\u0019\u0009\u0007.\u000A(\u001F\u0009\u0007.\u0007(this)))
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
								\u0006\u0009\u0007.\u000A(this, true);
								return;
							}
						}
						int num = \u000B\u0009\u0007.\u000A(this);
						\u0002\u0009\u0007.\u000A(this, num + 1);
						int num2 = \u000B\u0009\u0007.\u000A(this) * 100 / \u0016\u0009\u0007.\u000A(this);
						\u0018\u0009\u0007.\u000A(\u001F\u0009\u0007.\u0007(this), (double)num2, "", \u0005\u0009\u0007.\u000A(this));
						return;
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
			}
		}

		// Token: 0x040001E6 RID: 486
		[CompilerGenerated]
		private Transaction \u001F;

		// Token: 0x040001E7 RID: 487
		[CompilerGenerated]
		private ProgressBarWindow \u000A;

		// Token: 0x040001E8 RID: 488
		[CompilerGenerated]
		private int \u0007;

		// Token: 0x040001E9 RID: 489
		[CompilerGenerated]
		private int \u001D;

		// Token: 0x040001EA RID: 490
		[CompilerGenerated]
		private bool \u0004;

		// Token: 0x040001EB RID: 491
		[CompilerGenerated]
		private string \u0019;

		// Token: 0x040001EC RID: 492
		[CompilerGenerated]
		private ObservableCollection<ViewsReport> \u0018;
	}
}
